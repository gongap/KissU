import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { APIRoutingModule } from './api-routing.module';
import { APILayoutComponent } from './_layout/layout.component';

import { APIGroupsComponent } from './groups/groups.component';
import { APIsComponent } from './apis/apis.component';
// detail
import { APIDefinitionComponent } from './detail/definition/definition.component';
import { APIDetailLayoutComponent } from './_layout/layout-detail.component';
import { APIAuthorizationComponent } from './detail/authorization/authorization.component';

const COMPONENTS = [
  APILayoutComponent,
  APIGroupsComponent,
  APIsComponent,
  // detail
  APIDetailLayoutComponent,
  APIDefinitionComponent,
  APIAuthorizationComponent,
];

const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [SharedModule, APIRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class APIModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
