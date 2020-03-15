import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccountLayoutComponent } from './_layout/layout.component';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RegisterResultComponent } from './register-result/register-result.component';
import { ForgetComponent } from './forget/forget.component';

const routes: Routes = [
  {
    path: '',
    component: AccountLayoutComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent,
        data: { titleI18n: 'account.menu.login' },
      },
      {
        path: 'register',
        component: RegisterComponent,
        data: { titleI18n: 'account.menu.register' },
      },
      {
        path: 'register-result',
        component: RegisterResultComponent,
        data: { titleI18n: 'account.menu.register-result' },
      },
      {
        path: 'forget',
        component: ForgetComponent,
        data: { titleI18n: 'account.menu.forget' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
