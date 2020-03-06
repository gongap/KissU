import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';

import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { SmartRoutingModule } from './smart-routing.module';
import { SmartComponent } from './smart/smart.component';
import { SmartToolsComponent } from './smart/smart-tools.component';

const COMPONENTS = [SmartComponent];
const COMPONENTS_NOROUNT = [SmartToolsComponent];

@NgModule({
  imports: [SharedModule, SmartRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class SmartModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
