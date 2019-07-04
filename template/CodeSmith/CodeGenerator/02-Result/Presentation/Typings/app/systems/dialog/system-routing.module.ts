import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationListComponent } from './application/application-list.component';
import { ResourceListComponent } from './resource/resource-list.component';
import { RoleListComponent } from './role/role-list.component';
import { UserListComponent } from './user/user-list.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'application', component: ApplicationListComponent },
            { path: 'resource', component: ResourceListComponent },
            { path: 'role', component: RoleListComponent },
            { path: 'user', component: UserListComponent },
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