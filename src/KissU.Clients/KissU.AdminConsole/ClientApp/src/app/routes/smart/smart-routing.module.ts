import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SmartComponent } from './smart/smart.component';

const routes: Routes = [
  {
    path: '',
    component: SmartComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SmartRoutingModule {}
