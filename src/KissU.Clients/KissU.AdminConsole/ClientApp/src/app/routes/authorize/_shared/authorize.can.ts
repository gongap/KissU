import { Injectable } from '@angular/core';
import {
  CanActivate,
  CanActivateChild,
  CanLoad,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Route,
  Router,
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { _HttpClient } from '@delon/theme';

export interface AuthorizeCanType {
  type: 'remote' | 'local';
  result?: boolean;
  url?: string;
}

@Injectable()
export class AuthorizeCan implements CanActivate, CanActivateChild, CanLoad {
  constructor(private http: _HttpClient, private router: Router) {}

  private process(options?: AuthorizeCanType): Observable<boolean> {
    options = { type: 'local', result: false, ...options };
    const result$: Observable<boolean> = options.type === 'local' ? of(options.result) : this.http.get(options.url);
    return result$.pipe(
      tap(result => {
        if (!result) {
          this.router.navigateByUrl(`/authorize/reject`);
        }
      }),
    );
  }

  // lazy loading
  canLoad(route: Route): Observable<boolean> {
    return this.process(route.data as any);
  }
  // all children route
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.canActivate(childRoute, state);
  }
  // route
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.process(route.data as any);
  }
}
