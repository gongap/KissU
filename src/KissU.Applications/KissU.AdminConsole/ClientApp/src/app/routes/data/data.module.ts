import { NgModule, Inject } from '@angular/core';
import { TrendModule } from 'ngx-trend';

import { SharedModule } from '@shared';

import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { DataRoutingModule } from './data-routing.module';
import { DataLayoutComponent } from './_layout/layout.component';
import { DataSummaryComponent } from './summary/summary.component';
import { DataSummaryStatusComponent } from './summary/status/status.component';
import { DataSummaryMonthComponent } from './summary/month/month.component';
import { DataSummaryPayComponent } from './summary/pay/pay.component';
import { DataSummaryTradeComponent } from './summary/trade/trade.component';
import { DataSummaryGenderComponent } from './summary/gender/gender.component';
import { DataSummaryRegionComponent } from './summary/region/region.component';
import { DataSummaryRealtimeComponent } from './summary/realtime/realtime.component';
import { DataHealthyComponent } from './healthy/healthy.component';
import { DataHealthyGaugeComponent } from './healthy/gauge/gauge.component';
import { DataHealthyNumComponent } from './healthy/num/num.component';
import { DataHealthyDiskComponent } from './healthy/disk/disk.component';
import { DataHealthyGPUComponent } from './healthy/gpu/gpu.component';
import { DataHealthyInternalComponent } from './healthy/internal/internal.component';
import { DataHealthyNetworkComponent } from './healthy/network/network.component';
import { DataMermaidComponent } from './mermaid/mermaid.component';
import { DataGanttComponent } from './gantt/gantt.component';
import { DataTrendComponent } from './trend/trend.component';

const COMPONENTS = [
  DataLayoutComponent,
  DataSummaryComponent,
  DataHealthyComponent,
  DataMermaidComponent,
  DataGanttComponent,
  DataTrendComponent,
];
const COMPONENTS_NOROUNT = [
  DataSummaryStatusComponent,
  DataSummaryMonthComponent,
  DataSummaryPayComponent,
  DataSummaryTradeComponent,
  DataSummaryGenderComponent,
  DataSummaryRegionComponent,
  DataSummaryRealtimeComponent,
  DataHealthyNumComponent,
  DataHealthyGaugeComponent,
  DataHealthyDiskComponent,
  DataHealthyGPUComponent,
  DataHealthyInternalComponent,
  DataHealthyNetworkComponent,
];

@NgModule({
  imports: [SharedModule, DataRoutingModule, TrendModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class DataModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
