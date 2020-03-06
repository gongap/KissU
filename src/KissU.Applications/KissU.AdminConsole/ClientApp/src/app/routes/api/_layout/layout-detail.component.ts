import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { deepCopy } from '@delon/util';

import { MSServiceNavConfig, MSMenu } from '@brand';

const NAVS: MSMenu[] = [
  {
    text: '',
    i18n: 'apigateway.menu.children.apidefine',
    link: '/api/detail/:id/definition',
  },
  {
    text: '',
    i18n: 'apigateway.menu.children.authorization',
    link: '/api/detail/:id/authorization',
  },
];

@Component({
  selector: 'layout-api-detail',
  template: `
    <service-layout nav [navConfig]="navConfig" [navList]="navList">
      <router-outlet></router-outlet>
    </service-layout>
  `,
})
export class APIDetailLayoutComponent implements OnInit, OnDestroy {
  private route$: Subscription;
  nav = true;
  navConfig: MSServiceNavConfig = {
    backHref: '/api/apis',
    docI18n: 'api.title.doc',
  };
  navList: MSMenu[] = [];

  constructor(private route: ActivatedRoute, private router: Router) {}

  private ref() {
    const id = this.route.parent.firstChild.snapshot.params.id;
    this.navList = (deepCopy(NAVS) as MSMenu[]).map(i => {
      i.link = i.link.replace(':id', id);
      return i;
    });
  }

  ngOnInit() {
    this.route$ = this.router.events.pipe(filter(e => e instanceof NavigationEnd)).subscribe(() => this.ref());

    this.ref();
  }

  ngOnDestroy() {
    this.route$.unsubscribe();
  }
}
