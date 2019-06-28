import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApiListComponent } from './api/api-list.component';
import { ApiScopeListComponent } from './apiScope/apiScope-list.component';
import { ApplicationListComponent } from './application/application-list.component';
import { EnterpriseListComponent } from './enterprise/enterprise-list.component';
import { LinkListComponent } from './link/link-list.component';
import { MenuListComponent } from './menu/menu-list.component';
import { RoleListComponent } from './role/role-list.component';
import { UserListComponent } from './user/user-list.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'api', component: ApiListComponent },
            { path: 'apiScope', component: ApiScopeListComponent },
            { path: 'application', component: ApplicationListComponent },
            { path: 'enterprise', component: EnterpriseListComponent },
            { path: 'link', component: LinkListComponent },
            { path: 'menu', component: MenuListComponent },
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