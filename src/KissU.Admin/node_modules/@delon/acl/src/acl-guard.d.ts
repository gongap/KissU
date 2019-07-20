import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { DelonACLConfig } from './acl.config';
import { ACLService } from './acl.service';
export declare class ACLGuard implements CanActivate, CanActivateChild, CanLoad {
    private srv;
    private router;
    private options;
    constructor(srv: ACLService, router: Router, options: DelonACLConfig);
    private process;
    canLoad(route: Route): Observable<boolean>;
    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean>;
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean>;
}
