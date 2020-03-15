import { Component, ChangeDetectionStrategy } from '@angular/core';
import { MSServiceNavConfig, MSMenu } from '@brand';
import { SettingsService, MenuService, TitleService } from '@delon/theme';

@Component({
  selector: 'finance-layout',
  templateUrl: './layout.component.html',
  host: {
    '[class.alain-ms__product]': 'true',
    '[class.alain-ms__product-col-1]': 'true',
  },
  styleUrls: ['./layout.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FinanceLayoutComponent {
  navConfig: MSServiceNavConfig = {
    titleI18n: 'finance.title',
    docI18n: 'finance.title.doc',
  };
  menus: MSMenu[] = [
    {
      text: '',
      i18n: 'finance.menu.home',
      link: '/finance/home',
    },
    {
      text: '',
      i18n: 'finance.menu.bill',
      link: '/finance/bill',
    },
    {
      text: '',
      i18n: 'finance.menu.invoice',
      link: '/finance/invoice',
    },
  ];

  get user() {
    return this.settings.user;
  }

  constructor(private settings: SettingsService, private titSrv: TitleService, private menuSrv: MenuService) {
    this.menuSrv.add(this.menus);
    this.titSrv.setTitleByI18n(this.navConfig.docI18n);
  }
}
