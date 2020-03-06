import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CompLayoutComponent } from './_layout/layout.component';
import { CompAntdComponent } from './antd/antd.component';
import { CompTableComponent } from './table/table.component';
import { CompDelonComponent } from './delon/delon.component';

const routes: Routes = [
  {
    path: '',
    component: CompLayoutComponent,
    children: [
      { path: '', redirectTo: 'antd', pathMatch: 'full' },
      { path: 'antd', component: CompAntdComponent },
      { path: 'table', component: CompTableComponent },
      { path: 'delon', component: CompDelonComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ComponentRoutingModule {}
