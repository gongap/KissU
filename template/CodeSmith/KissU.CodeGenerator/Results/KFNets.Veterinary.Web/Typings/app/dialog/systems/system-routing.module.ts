import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApiListComponent } from './api/api-list.component';
import { ApiScopeListComponent } from './apiScope/apiScope-list.component';
import { ApplicationListComponent } from './application/application-list.component';
import { RoleListComponent } from './role/role-list.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'api', component: ApiListComponent },
            { path: 'apiScope', component: ApiScopeListComponent },
            { path: 'application', component: ApplicationListComponent },
            { path: 'role', component: RoleListComponent },
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