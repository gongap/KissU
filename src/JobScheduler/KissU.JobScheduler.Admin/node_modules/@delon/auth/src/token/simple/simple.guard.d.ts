import { Injector } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, RouterStateSnapshot, UrlSegment } from '@angular/router';
import { DelonAuthConfig } from '../../auth.config';
import { ITokenService } from '../interface';
export declare class SimpleGuard implements CanActivate, CanActivateChild, CanLoad {
    private srv;
    private injector;
    private cog;
    private url;
    constructor(srv: ITokenService, injector: Injector, cog: DelonAuthConfig);
    private process;
    canLoad(route: Route, segments: UrlSegment[]): boolean;
    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean;
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean;
}
