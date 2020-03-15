import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { environment } from '@env/environment';
import { SimpleGuard } from '@delon/auth';
// layout
import { MSLayoutComponent } from '@brand';
// single pages
import { CallbackComponent } from './callback/callback.component';

const routes: Routes = [
  // Full pages
  {
    path: '',
    component: MSLayoutComponent,
    canActivate: [SimpleGuard],
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', loadChildren: './home/home.module#HomeModule' },
      {
        path: 'component',
        loadChildren: './component/component.module#ComponentModule',
      },
      {
        path: 'dns',
        loadChildren: './dns/dns.module#DnsModule',
      },
      {
        path: 'api',
        loadChildren: './api/api.module#APIModule',
      },
      {
        path: 'authorize',
        loadChildren: './authorize/authorize.module#AuthorizeModule',
      },
      {
        path: 'user',
        loadChildren: './user/user.module#UserModule',
      },
      {
        path: 'notifications',
        loadChildren: './notifications/notifications.module#NotificationsModule',
      },
      // Exception
      {
        path: 'exception',
        loadChildren: './exception/exception.module#ExceptionModule',
      },
    ],
  },
  // Single pages (Not sidebar)
  {
    path: '',
    component: MSLayoutComponent,
    canActivate: [SimpleGuard],
    data: { hasAllNav: true, hasSidebar: false },
    children: [
      { path: 'smart', loadChildren: './smart/smart.module#SmartModule' },
      { path: 'data', loadChildren: './data/data.module#DataModule' },
      {
        path: 'finance',
        loadChildren: './finance/finance.module#FinanceModule',
      },
    ],
  },
  // Help Document
  {
    path: 'help',
    component: MSLayoutComponent,
    data: { hasAllNav: true, hasSidebar: false },
    children: [{ path: '', loadChildren: './help/help.module#HelpModule' }],
  },
  // account
  {
    path: 'account',
    loadChildren: './account/account.module#AccountModule',
  },
  // 单页不包裹Layout
  { path: 'callback/:type', component: CallbackComponent },
  { path: '**', redirectTo: 'exception/404' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      useHash: environment.useHash,
      scrollPositionRestoration: 'top',
    }),
  ],
  exports: [RouterModule],
})
export class RouteRoutingModule {}
