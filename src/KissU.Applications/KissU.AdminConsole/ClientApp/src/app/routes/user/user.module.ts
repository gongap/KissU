import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { UserRoutingModule } from './user-routing.module';

import { UserLayoutComponent } from './_layout/layout.component';
import { UserBasicComponent } from './basic/basic.component';
import { UserSecureComponent } from './secure/secure.component';
import { UserSecureAvatarComponent } from './secure/avatar/avatar.component';

const COMPONENTS = [UserLayoutComponent, UserBasicComponent, UserSecureComponent];

const COMPONENTS_NOROUNT = [UserSecureAvatarComponent];

@NgModule({
  imports: [SharedModule, UserRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class UserModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
