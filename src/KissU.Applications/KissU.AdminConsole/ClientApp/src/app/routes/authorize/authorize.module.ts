import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { AuthorizeRoutingModule } from './authorize-routing.module';
import { AuthorizeCan } from './_shared/authorize.can';

import { AuthorizeLayoutComponent } from './_layout/layout.component';

import { AuthorizeLocalComponent } from './local/local.component';
import { AuthorizeRemoteComponent } from './remote/remote.component';
import { AuthorizeRejectComponent } from './reject/reject.component';

const COMPONENTS = [
  AuthorizeLayoutComponent,
  AuthorizeLocalComponent,
  AuthorizeRemoteComponent,
  AuthorizeRejectComponent,
];

const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [SharedModule, AuthorizeRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
  providers: [AuthorizeCan],
})
export class AuthorizeModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
