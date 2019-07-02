import { Injectable, Injector, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { zip } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { MenuService, SettingsService, TitleService, ALAIN_I18N_TOKEN } from '@delon/theme';
import { DA_SERVICE_TOKEN, ITokenService } from '@delon/auth';
import { ACLService } from '@delon/acl';
import { TranslateService } from '@ngx-translate/core';
import { I18NService } from '../i18n/i18n.service';
import { NzIconService } from 'ng-zorro-antd';
import { ICONS_AUTO } from '../../../style-icons-auto';
import { ICONS } from '../../../style-icons';
import { OAuthService } from 'angular-oauth2-oidc';
import { environment } from '@env/environment';

/**
 * 用于应用启动时
 * 一般用来获取应用所需要的基础数据等
 */
@Injectable()
export class StartupService {
  constructor(
    iconSrv: NzIconService,
    private menuService: MenuService,
    private translate: TranslateService,
    @Inject(ALAIN_I18N_TOKEN) private i18n: I18NService,
    private settingService: SettingsService,
    private aclService: ACLService,
    private titleService: TitleService,
    @Inject(DA_SERVICE_TOKEN) private tokenService: ITokenService,
    private httpClient: HttpClient,
    private injector: Injector,
    private oauthService: OAuthService,
  ) {
    iconSrv.addIcon(...ICONS_AUTO, ...ICONS);
  }

  private initApp(resolve: any, reject: any) {
    zip(
      this.httpClient.get(`${window.location.origin}/assets/i18n/${this.i18n.defaultLang}.json`),
      this.httpClient.get(`${window.location.origin}/assets/app-data.json`)
    ).pipe(
      // 接收其他拦截器后产生的异常消息
      catchError(([langData, appData]) => {
        resolve(null);
        return [langData, appData];
      })
    ).subscribe(([langData, appData]) => {
      // 设置语言数据
      this.translate.setTranslation(this.i18n.defaultLang, langData);
      this.translate.setDefaultLang(this.i18n.defaultLang);
      // 应用数据
      const res: any = appData;
      // 应用信息：包括站点名、描述、年份
      this.settingService.setApp(res.app);
      // 设置页面标题的后缀
      this.titleService.suffix = res.app.name;
      // 初始化菜单
      this.menuService.add(res.menu);
      
    },
      () => { },
      () => {
        resolve(null);
      });
  }

  initUser(): Promise<any> {
    // 设置用户Token信息
    this.tokenService.set({ token: this.oauthService.getAccessToken() });
    return this.oauthService.loadUserProfile().then((userProfile: any) => {
      //设置当前用户
      this.settingService.setUser(userProfile);
      // 设置当前用户角色（会先清除所有）
      const role: string = this.settingService.user.role;
      if (role) this.aclService.setRole(role.split(','));
      // 设置当前用户权限能力（会先清除所有）
      const ability: string = this.settingService.user.permission;
      if (ability) this.aclService.setAbility(ability.split(','));
      //重置菜单
      this.menuService.resume();
    });
  }

  load(): Promise<any> {
    // only works with promises
    // https://github.com/angular/angular/issues/15088

    return new Promise((resolve, reject) => {
      if (environment.useImplicitFlow) {
        this.oauthService.loadDiscoveryDocumentAndLogin().then((hasValidToken) => {
          if (hasValidToken) {
            this.initUser().then(()=>this.initApp(resolve, reject));
          }
        });
      } else {
        this.oauthService.loadDiscoveryDocument().then(() => {
          if (this.oauthService.hasValidAccessToken()) {
            this.initUser().then(() => this.initApp(resolve, reject));
          } else {
            this.initApp(resolve, reject);
            this.oauthService.logOut();
          }
        });
      }
    });
  }
}
