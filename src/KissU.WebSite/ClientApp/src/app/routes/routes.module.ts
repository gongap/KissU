import { NgModule } from '@angular/core';

import { SharedModule } from '@shared';
import { RouteRoutingModule } from './routes-routing.module';
import { UserLoginComponent } from './passport/login/login.component';
import { UserRegisterComponent } from './passport/register/register.component';
import { UserRegisterResultComponent } from './passport/register-result/register-result.component';
import { CallbackComponent } from './callback/callback.component';
import { UserLockComponent } from './passport/lock/lock.component';

const COMPONENTS = [
  UserLoginComponent,
  UserRegisterComponent,
  UserRegisterResultComponent,
  CallbackComponent,
  UserLockComponent,
];
const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [ SharedModule, RouteRoutingModule ],
  declarations: [
    ...COMPONENTS,
    ...COMPONENTS_NOROUNT
  ],
  entryComponents: COMPONENTS_NOROUNT
})
export class RoutesModule {}
