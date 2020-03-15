import { Injectable, OnDestroy } from '@angular/core';
import { Router, NavigationEnd, Navigation } from '@angular/router';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { deepGet, deepMergeKey } from '@delon/util';
import { STConfig } from '@delon/abc';

@Injectable({ providedIn: 'root' })
export class RouteService implements OnDestroy {
  private router$: Subscription;
  private _nav: Navigation;
  private _zeroIndexed = false;

  /**
   * Get the `pi` value (service by `st`)
   */
  get pi() {
    const pi = this.get('pi', null);
    return pi == null ? (this._zeroIndexed ? 1 : 0) : pi;
  }

  /** Get all the data */
  get data() {
    return deepGet(this._nav, `extras.state`);
  }

  constructor(private router: Router, stCog: STConfig) {
    this._zeroIndexed = (deepMergeKey(new STConfig(), true, stCog) as STConfig).page.zeroIndexed;
    this.router$ = router.events
      .pipe(filter(e => e instanceof NavigationEnd))
      .subscribe(() => (this._nav = this.router.getCurrentNavigation()));
  }

  /** Get the value via `key` */
  get(key: string, defaultValue: any = null): any {
    return deepGet(this._nav, `extras.state.${key}`, defaultValue);
  }

  ngOnDestroy(): void {
    this.router$.unsubscribe();
  }
}
