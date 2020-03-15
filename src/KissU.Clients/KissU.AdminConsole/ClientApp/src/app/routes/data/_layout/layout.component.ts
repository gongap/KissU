import { Component } from '@angular/core';
import { MSServiceNavConfig, MSMenu } from '@brand';

@Component({
  selector: 'data-layout',
  template: `
    <service-layout nav [navConfig]="navConfig" [navList]="navList">
      <router-outlet></router-outlet>
    </service-layout>
  `,
})
export class DataLayoutComponent {
  nav = true;
  navConfig: MSServiceNavConfig = {
    titleI18n: 'data.title',
    docI18n: 'data.title.doc',
  };
  navList: MSMenu[] = [
    { text: '', i18n: 'data.menu.summary', link: '/data/summary' },
    { text: '', i18n: 'data.menu.healthy', link: '/data/healthy' },
    { text: '', i18n: 'data.menu.mermaid', link: '/data/mermaid' },
    { text: '', i18n: 'data.menu.gantt', link: '/data/gantt' },
    { text: '', i18n: 'data.menu.trend', link: '/data/trend' },
  ];
}
