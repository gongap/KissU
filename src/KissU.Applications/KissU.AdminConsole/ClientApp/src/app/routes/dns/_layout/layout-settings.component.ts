import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { deepCopy } from '@delon/util';

import { MSServiceNavConfig, MSMenu } from '@brand';

const NAVS: MSMenu[] = [
  {
    text: '',
    i18n: 'dns.menu.detail',
    link: '/dns/detail/:domain',
  },
  {
    text: '',
    i18n: 'dns.menu.setting',
    link: '/dns/setting/:domain',
  },
  {
    text: '',
    i18n: 'dns.menu.monitor',
    link: '/dns/monitor/:domain',
  },
];

@Component({
  selector: 'layout-dns-setting',
  template: `
    <service-layout nav [navConfig]="navConfig" [navList]="navList">
      <router-outlet></router-outlet>
    </service-layout>
  `,
})
export class DnsSettingLayoutComponent implements OnInit, OnDestroy {
  private route$: Subscription;
  nav = true;
  navConfig: MSServiceNavConfig = {
    backHref: '/dns/domain',
    docI18n: 'dns.title.doc',
  };
  navList: MSMenu[] = [];

  constructor(private route: ActivatedRoute, private router: Router) {}

  private ref() {
    const domain = this.route.firstChild.snapshot.params.domain;
    this.navList = (deepCopy(NAVS) as MSMenu[]).map(i => {
      i.link = i.link.replace(':domain', domain);
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
