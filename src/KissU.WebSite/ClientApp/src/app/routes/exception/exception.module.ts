import { NgModule } from '@angular/core';
import { SharedModule } from '@shared';

import { ExceptionRoutingModule } from './exception-routing.module';

import { Exception401Component } from './401.component';
import { Exception403Component } from './403.component';
import { Exception404Component } from './404.component';
import { Exception500Component } from './500.component';

const COMPONENTS = [
  Exception401Component,
  Exception403Component,
  Exception404Component,
  Exception500Component
];
const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [SharedModule, ExceptionRoutingModule],
  declarations: [ ...COMPONENTS, ...COMPONENTS_NOROUNT ],
  entryComponents: COMPONENTS_NOROUNT,
})
export class ExceptionModule { }
