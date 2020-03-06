import { NgModule, Inject } from '@angular/core';

import { SharedModule } from '@shared';

import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';
import { default as zh_CN } from './_i18n/zh-CN';
import { default as zh_TW } from './_i18n/zh-TW';
import { default as en_US } from './_i18n/en-US';

import { HelpCategoryService } from './_core/help-category.service';

import { HelpRoutingModule } from './help-routing.module';
import { HelpLayoutComponent } from './_layout/layout.component';
import { HelpHomeComponent } from './home/home.component';
import { HelpDetailComponent } from './detail/detail.component';
import { HelpDetailMenuComponent } from './detail/menu/menu.component';
import { HelpDetailShareComponent } from './detail/share/share.component';

const COMPONENTS = [HelpLayoutComponent, HelpHomeComponent, HelpDetailComponent];
const COMPONENTS_NOROUNT = [HelpDetailMenuComponent, HelpDetailShareComponent];
const SERVICES = [HelpCategoryService];

@NgModule({
  imports: [SharedModule, HelpRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
  providers: SERVICES,
})
export class HelpModule {
  constructor(@Inject(ALAIN_I18N_TOKEN) i18n: I18NService) {
    i18n.load('zh-CN', zh_CN);
    i18n.load('zh-TW', zh_TW);
    i18n.load('en-US', en_US);
  }
}
