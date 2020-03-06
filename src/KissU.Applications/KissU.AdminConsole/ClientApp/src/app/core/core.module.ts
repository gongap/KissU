import { NgModule, Optional, SkipSelf, Injector } from '@angular/core';
import { throwIfAlreadyLoaded } from './module-import-guard';
import { HTTP_INTERCEPTORS } from "@angular/common/http";

import { I18NService } from './i18n/i18n.service';
import { LocalUploadService } from "./services/local-upload.service";
import { UploadService } from "./util/services/upload.service";
import { DicService } from './util/services/dic.service';
import { Session } from './util/security/session';
import { Authorize as OidcAuthorize } from './util/security/openid-connect/authorize';
import { AuthorizeService as OidcAuthorizeService } from './util/security/openid-connect/authorize-service';
import { AuthorizeConfig as OidcAuthorizeConfig } from './util/security/openid-connect/authorize-config';
import { AuthorizeInterceptor } from "./util/security/openid-connect/authorize-interceptor";

@NgModule({
  providers: [
    I18NService, DicService, Session,
    { provide: OidcAuthorizeConfig, useFactory: getAuthorizeConfig },
    { provide: UploadService, useClass: LocalUploadService },
    { provide: OidcAuthorizeService, useClass: OidcAuthorizeService, deps: [OidcAuthorizeConfig] },
    { provide: OidcAuthorize, useClass: OidcAuthorize, deps: [Injector, Session, OidcAuthorizeService] },
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, deps: [OidcAuthorizeService], multi: true }
  ]
})
export class CoreModule {
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}

export function getAuthorizeConfig() {
  let result = new OidcAuthorizeConfig();
  result.authority = "http://localhost:10080",
  result.clientId = "AdminConsole";
  result.scope = "openid profile api";
  return result;
}
