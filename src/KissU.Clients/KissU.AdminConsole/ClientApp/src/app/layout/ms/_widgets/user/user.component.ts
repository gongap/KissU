import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import { SettingsService } from '@delon/theme';
import { Router } from '@angular/router';
import { UserService } from '@core';
import { MSTopbarService } from '../../services/topbar.service';

@Component({
  selector: 'ms-user',
  templateUrl: './user.component.html',
  host: {
    '[class.alain-ms__topbar-item]': 'true',
    '[class.alain-ms__topbar-dd]': 'true',
    '[class.alain-ms__user]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MSUserComponent {
  private _l: any;

  mainLinks: any[] = [];
  subLinks: any[] = [];

  @Input()
  set l(res: any) {
    this._l = res;
    this.mainLinks = (res.links as any[]).slice(0, 3);
    this.subLinks = (res.links as any[]).slice(3);
  }
  get l() {
    return this._l;
  }

  constructor(
    srv: MSTopbarService,
    private router: Router,
    public settings: SettingsService,
    public userSrv: UserService,
  ) {
    this.l = srv.getNav('user');
  }

  logout() {
    this.userSrv.logout();
    this.router.navigateByUrl(this.userSrv.login_url);
  }
}
