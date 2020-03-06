import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { FinanceRoutingModule } from './finance-routing.module';

import { FinanceLayoutComponent } from './_layout/layout.component';
import { FinanceHomeComponent } from './home/home.component';
import { FinanceBillComponent } from './bill/bill.component';
import { FinanceInvoiceComponent } from './invoice/invoice.component';
import { FinanceBillOverviewComponent } from './bill/overview/overview.component';
import { FinanceBillListComponent } from './bill/list/list.component';
import { FinanceBillReportComponent } from './bill/report/report.component';

const COMPONENTS = [FinanceLayoutComponent, FinanceHomeComponent, FinanceBillComponent, FinanceInvoiceComponent];

const COMPONENTS_NOROUNT = [FinanceBillOverviewComponent, FinanceBillListComponent, FinanceBillReportComponent];

@NgModule({
  imports: [SharedModule, FinanceRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class FinanceModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
