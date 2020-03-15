import { Component } from '@angular/core';
import { MSServiceNavConfig, MSMenu } from '@brand';

@Component({
  selector: 'layout-authorize',
  templateUrl: './layout.component.html',
})
export class AuthorizeLayoutComponent {
  nav = true;
  navConfig: MSServiceNavConfig = {
    titleI18n: 'authorize.title',
    docI18n: 'authorize.title',
  };
  navList: MSMenu[] = [
    {
      text: '',
      i18n: 'authorize.menu.local.deny',
      link: '/authorize/local/deny',
    },
    {
      text: '',
      i18n: 'authorize.menu.local.grant',
      link: '/authorize/local/grant',
    },
    {
      text: '',
      i18n: 'authorize.menu.remote.deny',
      link: '/authorize/remote/deny',
    },
    {
      text: '',
      i18n: 'authorize.menu.remote.grant',
      link: '/authorize/remote/grant',
    },
  ];
}
