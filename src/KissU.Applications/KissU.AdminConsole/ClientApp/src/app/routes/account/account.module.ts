import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { AccountTopbarComponent } from './_shared/topbar/topbar.component';

import { AccountLayoutComponent } from './_layout/layout.component';
import { AccountRoutingModule } from './account-routing.module';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RegisterResultComponent } from './register-result/register-result.component';
import { ForgetComponent } from './forget/forget.component';

const COMPONENTS = [
  AccountLayoutComponent,
  LoginComponent,
  RegisterComponent,
  RegisterResultComponent,
  ForgetComponent,
];

const COMPONENTS_NOROUNT = [AccountTopbarComponent];

@NgModule({
  imports: [SharedModule, AccountRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class AccountModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
