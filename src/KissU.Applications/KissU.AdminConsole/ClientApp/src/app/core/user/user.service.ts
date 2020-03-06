import { Injectable, Inject } from '@angular/core';
import { DA_SERVICE_TOKEN, ITokenService } from '@delon/auth';
import { SettingsService } from '@delon/theme';
import { Session } from "@util";

@Injectable({ providedIn: 'root' })
export class UserService {
  logout() {
    this.tokenSrv.clear();
  }

  get login_url() {
    return this.tokenSrv.login_url;
  }

  get item() {
    return this.tokenSrv.get();
  }

  get isLogin() {
    //return !!this.item.token;
    return this.session.isAuthenticated;
  }

  get name() {
    return this.settingsSrv.user.name;
  }

  get email() {
    return this.settingsSrv.user.email;
  }

  get avatar() {
    return this.settingsSrv.user.avatar;
  }

  constructor(@Inject(DA_SERVICE_TOKEN) private tokenSrv: ITokenService, private session: Session, private settingsSrv: SettingsService) {}
}
