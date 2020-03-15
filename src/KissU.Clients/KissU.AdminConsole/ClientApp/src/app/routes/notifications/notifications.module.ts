import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { NotificationsService } from './_core/notifications.service';

import { ComponentRoutingModule } from './notifications-routing.module';

import { NotificationsLayoutComponent } from './_layout/layout.component';
import { NotificationsInnerComponent } from './inner/inner.component';
import { NotificationsInnerDetailComponent } from './detail/detail.component';
import { NotificationsSubscribeComponent } from './subscribe/subscribe.component';
import { NotificationsTTSComponent } from './tts/tts.component';

const COMPONENTS = [
  NotificationsLayoutComponent,
  NotificationsInnerComponent,
  NotificationsInnerDetailComponent,
  NotificationsSubscribeComponent,
  NotificationsTTSComponent,
];

const COMPONENTS_NOROUNT = [];

const SERVICES = [NotificationsService];

@NgModule({
  imports: [SharedModule, ComponentRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
  providers: SERVICES,
})
export class NotificationsModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
