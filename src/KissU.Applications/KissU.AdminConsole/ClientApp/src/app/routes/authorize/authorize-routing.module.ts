import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthorizeCan, AuthorizeCanType } from './_shared/authorize.can';

import { AuthorizeLayoutComponent } from './_layout/layout.component';

import { AuthorizeLocalComponent } from './local/local.component';
import { AuthorizeRemoteComponent } from './remote/remote.component';
import { AuthorizeRejectComponent } from './reject/reject.component';

const routes: Routes = [
  {
    path: '',
    component: AuthorizeLayoutComponent,
    children: [
      { path: '', redirectTo: 'local/grant', pathMatch: 'full' },
      {
        path: 'local/deny',
        component: AuthorizeLocalComponent,
        canActivate: [AuthorizeCan],
        data: { type: 'local', result: false },
      },
      {
        path: 'local/grant',
        component: AuthorizeLocalComponent,
        canActivate: [AuthorizeCan],
        data: { type: 'local', result: true },
      },
      {
        path: 'remote/deny',
        component: AuthorizeRemoteComponent,
        canActivate: [AuthorizeCan],
        data: { type: 'remote', url: `/authorize/deny` },
      },
      {
        path: 'remote/grant',
        component: AuthorizeRemoteComponent,
        canActivate: [AuthorizeCan],
        data: { type: 'remote', url: `/authorize/grant` },
      },
    ],
  },
  {
    path: 'reject',
    component: AuthorizeRejectComponent,
    data: { titleI18n: 'authorize.deny.title' },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthorizeRoutingModule {}
