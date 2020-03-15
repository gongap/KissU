import { Component } from '@angular/core';
import { MSServiceNavConfig, MSMenu } from '@brand';

@Component({
  selector: 'layout-api',
  template: `
    <service-layout nav [navConfig]="navConfig" [navList]="navList">
      <router-outlet></router-outlet>
    </service-layout>
  `,
})
export class APILayoutComponent {
  nav = true;
  navConfig: MSServiceNavConfig = {
    titleI18n: 'api.title',
    docI18n: 'api.title.doc',
  };
  navList: MSMenu[] = [
    {
      text: '',
      i18n: 'apigateway.menu.root.openapi',
      children: [
        { text: '', i18n: 'apigateway.menu.children.group', link: '/api/groups' },
        { text: '', i18n: 'apigateway.menu.children.api', link: '/api/apis' },
      ],
    },
    {
      text: '',
      i18n: 'apigateway.menu.root.document',
      externalLink: 'https://e.ng-alain.com/theme/ms/docs',
      target: '_blank',
    },
  ];
}
