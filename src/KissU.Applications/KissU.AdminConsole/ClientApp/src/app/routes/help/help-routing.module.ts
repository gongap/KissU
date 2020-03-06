import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HelpLayoutComponent } from './_layout/layout.component';
import { HelpHomeComponent } from './home/home.component';
import { HelpDetailComponent } from './detail/detail.component';

const routes: Routes = [
  {
    path: '',
    component: HelpLayoutComponent,
    children: [{ path: '', component: HelpHomeComponent }, { path: ':id', component: HelpDetailComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HelpRoutingModule {}
