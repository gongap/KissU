import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationListComponent } from './application/application-list.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { ResourceListComponent } from './resource/resource-list.component';
import { ResourceEditComponent } from './resource/resource-edit.component';
import { ResourceDetailComponent } from './resource/resource-detail.component';
import { RoleListComponent } from './role/role-list.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';
import { UserListComponent } from './user/user-list.component';
import { UserEditComponent } from './user/user-edit.component';
import { UserDetailComponent } from './user/user-detail.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            {path: 'application', children: [
                { path: '', component: ApplicationListComponent },
                { path: 'create', component: ApplicationEditComponent },
                { path: 'edit/:id', component: ApplicationEditComponent },
                { path: 'detail/:id', component: ApplicationDetailComponent }
            ]},
            {path: 'resource', children: [
                { path: '', component: ResourceListComponent },
                { path: 'create', component: ResourceEditComponent },
                { path: 'edit/:id', component: ResourceEditComponent },
                { path: 'detail/:id', component: ResourceDetailComponent }
            ]},
            {path: 'role', children: [
                { path: '', component: RoleListComponent },
                { path: 'create', component: RoleEditComponent },
                { path: 'edit/:id', component: RoleEditComponent },
                { path: 'detail/:id', component: RoleDetailComponent }
            ]},
            {path: 'user', children: [
                { path: '', component: UserListComponent },
                { path: 'create', component: UserEditComponent },
                { path: 'edit/:id', component: UserEditComponent },
                { path: 'detail/:id', component: UserDetailComponent }
            ]},
        ]
    }
];

/**
 * systems路由模块
 */
@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class SystemRoutingModule { }