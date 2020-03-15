import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DnsLayoutComponent } from './_layout/layout.component';
import { DnsSettingLayoutComponent } from './_layout/layout-settings.component';

import { DnsDomainComponent } from './domain/domain.component';
import { DnsSettingComponent } from './setting/setting.component';
import { DnsDetailComponent } from './detail/detail.component';
import { DnsMonitorComponent } from './monitor/monitor.component';
import { DnsGTMComponent } from './gtm/gtm.component';
import { DnsLogComponent } from './log/log.component';

const routes: Routes = [
  {
    path: '',
    component: DnsLayoutComponent,
    children: [
      { path: '', redirectTo: 'domain', pathMatch: 'full' },
      { path: 'domain', component: DnsDomainComponent },
      { path: 'gtm', component: DnsGTMComponent },
      { path: 'log', component: DnsLogComponent },
    ],
  },
  {
    path: '',
    component: DnsSettingLayoutComponent,
    children: [
      { path: 'setting/:domain', component: DnsSettingComponent },
      { path: 'detail/:domain', component: DnsDetailComponent },
      { path: 'monitor/:domain', component: DnsMonitorComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DnsRoutingModule {}
