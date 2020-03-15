import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { DnsRoutingModule } from './dns-routing.module';

import { DnsGroupComponent } from './_shared/group/group.component';
import { DnsStatusComponent } from './_shared/status/status.component';

import { DnsLayoutComponent } from './_layout/layout.component';
import { DnsSettingLayoutComponent } from './_layout/layout-settings.component';

import { DnsDomainComponent } from './domain/domain.component';
import { DnsSettingComponent } from './setting/setting.component';
import { DnsSettingEditComponent } from './setting/edit/edit.component';
import { DnsDetailComponent } from './detail/detail.component';
import { DnsMonitorComponent } from './monitor/monitor.component';
import { DnsGTMComponent } from './gtm/gtm.component';
import { DnsLogComponent } from './log/log.component';

const COMPONENTS = [
  DnsLayoutComponent,
  DnsSettingLayoutComponent,
  DnsDomainComponent,
  DnsSettingComponent,
  DnsDetailComponent,
  DnsMonitorComponent,
  DnsGTMComponent,
  DnsLogComponent,
];

const COMPONENTS_NOROUNT = [DnsGroupComponent, DnsStatusComponent, DnsSettingEditComponent];

@NgModule({
  imports: [SharedModule, DnsRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class DnsModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
