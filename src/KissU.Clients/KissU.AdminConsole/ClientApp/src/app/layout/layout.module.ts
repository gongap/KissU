import { NgModule, Inject } from '@angular/core';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { SharedModule } from '@shared';

import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './ms/_i18n/zh-CN';
import { default as zh_TW } from './ms/_i18n/zh-TW';
import { default as en_US } from './ms/_i18n/en-US';

import { MS_ENTRYCOMPONENTS, MS_COMPONENTS } from './ms/index';

// passport

@NgModule({
  imports: [SharedModule, DragDropModule],
  entryComponents: MS_ENTRYCOMPONENTS,
  declarations: [...MS_COMPONENTS],
  exports: [...MS_COMPONENTS],
})
export class LayoutModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
