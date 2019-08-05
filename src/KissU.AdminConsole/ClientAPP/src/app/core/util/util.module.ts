import { NgModule, Injector } from '@angular/core';
import { HTTP_INTERCEPTORS } from "@angular/common/http";

//Util服务
import { DicService } from './services/dic.service';
import { Session } from './security/session';

//授权
import { Authorize as OidcAuthorize } from './security/openid-connect/authorize';
import { AuthorizeService as OidcAuthorizeService } from './security/openid-connect/authorize-service';
import { AuthorizeConfig as OidcAuthorizeConfig } from './security/openid-connect/authorize-config';
import { AuthorizeInterceptor } from "./security/openid-connect/authorize-interceptor";

/**
 * Util模块
 */
@NgModule( {
    providers: [
        DicService, Session
    ]
} )
export class UtilModule {
}

/**
 * 创建OpenId Connect服务DI配置
 */
export function createOidcProviders() {
    return [
        { provide: OidcAuthorizeService, useClass: OidcAuthorizeService, deps: [OidcAuthorizeConfig] },
        { provide: OidcAuthorize, useClass: OidcAuthorize, deps: [Injector, Session, OidcAuthorizeService] },
        { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, deps: [OidcAuthorizeService], multi: true }
    ];
}
