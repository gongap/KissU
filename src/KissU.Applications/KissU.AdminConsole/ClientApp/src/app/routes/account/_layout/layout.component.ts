import { Component, OnDestroy } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';

import { TitleService } from '@delon/theme';

@Component({
  selector: 'layout-account',
  templateUrl: './layout.component.html',
})
export class AccountLayoutComponent implements OnDestroy {
  private router$: Subscription;

  constructor(router: Router, titSrv: TitleService) {
    this.router$ = router.events.pipe(filter(e => e instanceof NavigationEnd)).subscribe(() => titSrv.setTitle());
  }

  ngOnDestroy() {
    this.router$.unsubscribe();
  }
}
