import { Component } from '@angular/core';
import { MSServiceNavConfig, MSMenu } from '@brand';

@Component({
  selector: 'layout-dns',
  template: `
    <service-layout nav [navConfig]="navConfig" [navList]="navList">
      <router-outlet></router-outlet>
    </service-layout>
  `,
})
export class DnsLayoutComponent {
  nav = true;
  navConfig: MSServiceNavConfig = {
    titleI18n: 'dns.title',
    docI18n: 'dns.title.doc',
  };
  navList: MSMenu[] = [
    {
      text: '',
      i18n: 'dns.menu.domain',
      children: [
        { text: '', i18n: 'dns.menu.domainList', link: '/dns/domain' },
        { text: '', i18n: 'dns.menu.log', link: '/dns/log' },
      ],
    },
    { text: '', i18n: 'dns.menu.gtm', link: '/dns/gtm' },
  ];
}
