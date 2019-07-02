import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Exception401Component } from './401.component';
import { Exception403Component } from './403.component';
import { Exception404Component } from './404.component';
import { Exception500Component } from './500.component';

const routes: Routes = [
  { path: '401', component: Exception401Component, data: { title: '401' } },
  { path: '403', component: Exception403Component, data: { title: '403' } },
  { path: '404', component: Exception404Component, data: { title: '404' } },
  { path: '500', component: Exception500Component, data: { title: '500' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ExceptionRoutingModule {}
