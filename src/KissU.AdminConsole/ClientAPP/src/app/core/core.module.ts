import { NgModule, Optional, SkipSelf, Injector } from '@angular/core';
import { throwIfAlreadyLoaded } from './module-import-guard';

import { I18NService } from './i18n/i18n.service';
import { UtilModule, createOidcProviders, OidcAuthorizeConfig, UploadService } from "./util";
import { LocalUploadService } from "./services/local-upload.service";

@NgModule({
  imports: [
    UtilModule
  ],
  providers: [
    I18NService,
    { provide: OidcAuthorizeConfig, useFactory: getAuthorizeConfig },
    ...createOidcProviders(),
    { provide: UploadService, useClass: LocalUploadService }
  ]
})
export class CoreModule {
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}

/**
 * 获取授权配置
 */
export function getAuthorizeConfig() {
  let result = new OidcAuthorizeConfig();
  result.authority = "http://localhost:10080",
    result.clientId = "GreatWall-Admin";
  result.scope = "openid profile api";
  return result;
}
