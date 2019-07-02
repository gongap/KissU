import { Component, Inject, ChangeDetectionStrategy  } from '@angular/core';
import { Router } from '@angular/router';
import { SettingsService } from '@delon/theme';
import { DA_SERVICE_TOKEN, ITokenService } from '@delon/auth';
import { OAuthService } from 'angular-oauth2-oidc';
import { environment } from '@env/environment';

@Component({
  selector: 'header-user',
  template: `
  <nz-dropdown nzPlacement="bottomRight">
    <div class="alain-default__nav-item d-flex align-items-center px-sm" nz-dropdown>
      {{settings.user.name}}
    </div>
    <div nz-menu class="width-sm">
      <div nz-menu-item routerLink="/account"><i nz-icon type="setting" class="mr-sm"></i>
        {{ 'menu.account.settings' | translate }}
      </div>
      <li nz-menu-divider></li>
      <div nz-menu-item (click)="logout()"><i nz-icon type="logout" class="mr-sm"></i>
        {{ 'menu.account.logout' | translate }}
      </div>
    </div>
  </nz-dropdown>
  `,
  // changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderUserComponent {
  constructor(
    public settings: SettingsService,
    private router: Router,
    @Inject(DA_SERVICE_TOKEN) private tokenService: ITokenService,
    private oauthService: OAuthService,
  ) {}

  logout() {
    this.tokenService.clear();
    this.oauthService.logOut();
    //this.router.navigateByUrl(this.tokenService.login_url);
  }
}
