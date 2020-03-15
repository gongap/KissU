import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { APILayoutComponent } from './_layout/layout.component';
import { APIDetailLayoutComponent } from './_layout/layout-detail.component';

import { APIsComponent } from './apis/apis.component';
import { APIGroupsComponent } from './groups/groups.component';
import { APIDefinitionComponent } from './detail/definition/definition.component';
import { APIAuthorizationComponent } from './detail/authorization/authorization.component';

const routes: Routes = [
  {
    path: '',
    component: APILayoutComponent,
    children: [
      { path: '', redirectTo: 'apis', pathMatch: 'full' },
      { path: 'groups', component: APIGroupsComponent },
      { path: 'apis', component: APIsComponent },
    ],
  },
  {
    path: 'detail/:id',
    component: APIDetailLayoutComponent,
    children: [
      { path: '', redirectTo: 'definition', pathMatch: 'full' },
      { path: 'definition', component: APIDefinitionComponent },
      { path: 'authorization', component: APIAuthorizationComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class APIRoutingModule {}
