import { NgModule, Optional, SkipSelf, Injector } from '@angular/core';
import { throwIfAlreadyLoaded } from './module-import-guard';

//服务
import { I18NService } from './i18n/i18n.service';

//模块
import { UtilModule } from "./util";

@NgModule({
  imports: [
    UtilModule
  ],
  providers: [
    I18NService
  ]
})
export class CoreModule {
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
