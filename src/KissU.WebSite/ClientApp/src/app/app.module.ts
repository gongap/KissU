import { NgModule, LOCALE_ID, APP_INITIALIZER, Injector } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '@env/environment';
import { util } from '@shared/util';

// #region default language
// 参考：https://ng-alain.com/docs/i18n
import { default as ngLang } from '@angular/common/locales/zh';
import { NZ_I18N, zh_CN as zorroLang } from 'ng-zorro-antd';
import { DELON_LOCALE, zh_CN as delonLang } from '@delon/theme';
const LANG = {
  abbr: 'zh',
  ng: ngLang,
  zorro: zorroLang,
  delon: delonLang,
};
// register angular
import { registerLocaleData } from '@angular/common';
registerLocaleData(LANG.ng, LANG.abbr);
const LANG_PROVIDES = [
  { provide: LOCALE_ID, useValue: LANG.abbr },
  { provide: NZ_I18N, useValue: LANG.zorro },
  { provide: DELON_LOCALE, useValue: LANG.delon },
];
// #endregion
// #region i18n services
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';

// 加载i18n语言文件
export function I18nHttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, `assets/i18n/`, '.json');
}

const I18NSERVICE_MODULES = [
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: I18nHttpLoaderFactory,
        deps: [HttpClient]
      }
    })
];

const I18NSERVICE_PROVIDES = [
  { provide: ALAIN_I18N_TOKEN, useClass: I18NService, multi: false }
];
// #region

// #region JSON Schema form (using @delon/form)
import { JsonSchemaModule } from '@shared/json-schema/json-schema.module';
const FORM_MODULES = [ JsonSchemaModule ];
// #endregion

// #region global third module
import { OAuthModule} from 'angular-oauth2-oidc';
const GLOBAL_THIRD_MODULES = [
  OAuthModule.forRoot({
    resourceServer: {
      allowedUrls: [environment.SERVER_URL],
      sendAccessToken: true
    }
  }),
];
import { AuthConfig, OAuthStorage, ValidationHandler, NullValidationHandler } from 'angular-oauth2-oidc';
export function fnAuthConfig(): AuthConfig {
  return Object.assign(new AuthConfig(), <AuthConfig>{
    issuer: environment.AUTH_URL,
    redirectUri: window.location.origin,
    clientId: 'KissU.WebSite',
    // tslint:disable-next-line:max-line-length
    scope: 'openid profile permission tenant Identity.API IdentityServer.API System.API Portal.API FileService.API Ocelot.Administration BenchMark.API',
    oidc: environment.useImplicitFlow,
    requireHttps: false,
    dummyClientSecret: 'secret',
    sessionChecksEnabled: true,
    sessionCheckIntervall: 3 * 1000,
    logoutUrl: '/passport/login',
    // 刷新相关
    silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
    silentRefreshTimeout: 1000 * 60
  });
}
const GLOBAL_THIRD_PROVIDES = [
  { provide: AuthConfig, useFactory: fnAuthConfig },
  { provide: OAuthStorage, useValue: localStorage },
  { provide: ValidationHandler, useClass: NullValidationHandler },
];
// #endregion

// #region Http Interceptors
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { SimpleInterceptor } from '@delon/auth';
import { DefaultInterceptor } from '@core/net/default.interceptor';
import { DefaultOAuthInterceptor} from 'angular-oauth2-oidc';
const INTERCEPTOR_PROVIDES = [
  // { provide: HTTP_INTERCEPTORS, useClass: SimpleInterceptor, multi: true},
  { provide: HTTP_INTERCEPTORS, useClass: DefaultInterceptor, multi: true},
  { provide: HTTP_INTERCEPTORS, useClass: DefaultOAuthInterceptor, multi: true },
];
// #endregion

// #region Startup Service
import { StartupService } from '@core/startup/startup.service';
export function StartupServiceFactory(startupService: StartupService): Function {
  return () => startupService.load();
}
const APPINIT_PROVIDES = [
  StartupService,
  {
    provide: APP_INITIALIZER,
    useFactory: StartupServiceFactory,
    deps: [StartupService],
    multi: true
  }
];
// #endregion

import { DelonModule } from './delon.module';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { RoutesModule } from './routes/routes.module';
import { LayoutModule } from './layout/layout.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DelonModule.forRoot(),
    CoreModule,
    SharedModule,
    LayoutModule,
    RoutesModule,
    ...I18NSERVICE_MODULES,
    ...FORM_MODULES,
    ...GLOBAL_THIRD_MODULES
  ],
  providers: [
    ...LANG_PROVIDES,
    ...INTERCEPTOR_PROVIDES,
    ...I18NSERVICE_PROVIDES,
    ...GLOBAL_THIRD_PROVIDES,
    ...APPINIT_PROVIDES
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
      util.ioc.injector = injector;
  }
 }

