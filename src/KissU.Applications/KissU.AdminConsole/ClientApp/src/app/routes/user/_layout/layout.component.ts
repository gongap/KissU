import { Component } from '@angular/core';
import { MSServiceNavConfig, MSMenu } from '@brand';

@Component({
  selector: 'user-layout',
  template: `
    <service-layout *ngIf="navList" nav [navConfig]="navConfig" [navList]="navList">
      <router-outlet></router-outlet>
    </service-layout>
  `,
})
export class UserLayoutComponent {
  nav = true;
  navConfig: MSServiceNavConfig = {
    titleI18n: 'user.title',
    docI18n: 'user.title.doc',
  };
  navList: MSMenu[] = [
    {
      text: '',
      i18n: 'user.menu.basic',
      link: '/user/basic',
    },
    {
      text: '',
      i18n: 'user.menu.secure',
      link: '/user/secure',
    },
  ];
}
