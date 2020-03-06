import { Component } from '@angular/core';
import { MSServiceNavConfig, MSMenu } from '@brand';

@Component({
  selector: 'comp-layout',
  template: `
    <service-layout nav [navConfig]="navConfig" [navList]="navList">
      <router-outlet></router-outlet>
    </service-layout>
  `,
})
export class CompLayoutComponent {
  nav = true;
  navConfig: MSServiceNavConfig = {
    titleI18n: 'comp.title',
    docI18n: 'comp.title.doc',
  };
  navList: MSMenu[] = [
    { text: '', i18n: 'comp.menu.basic', link: '/component/antd' },
    { text: '', i18n: 'comp.menu.table', link: '/component/table' },
    { text: '', i18n: 'comp.menu.delon', link: '/component/delon' },
  ];
}
