import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { ComponentRoutingModule } from './component-routing.module';

import { CompLayoutComponent } from './_layout/layout.component';
import { CompAntdComponent } from './antd/antd.component';
import { CompTableComponent } from './table/table.component';
import { CompDelonComponent } from './delon/delon.component';

const COMPONENTS = [CompLayoutComponent, CompAntdComponent, CompTableComponent, CompDelonComponent];

const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [SharedModule, ComponentRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class ComponentModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
