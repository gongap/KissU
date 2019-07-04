import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApiListComponent } from './api/api-list.component';
import { ApiEditComponent } from './api/api-edit.component';
import { ApiDetailComponent } from './api/api-detail.component';
import { ApiScopeListComponent } from './apiScope/apiScope-list.component';
import { ApiScopeEditComponent } from './apiScope/apiScope-edit.component';
import { ApiScopeDetailComponent } from './apiScope/apiScope-detail.component';
import { ApplicationListComponent } from './application/application-list.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { RoleListComponent } from './role/role-list.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            {path: 'api', children: [
                { path: '', component: ApiListComponent },
                { path: 'create', component: ApiEditComponent },
				{ path: 'edit/:id', component: ApiEditComponent },
                { path: 'detail/:id', component: ApiDetailComponent }
            ]},
            {path: 'apiScope', children: [
                { path: '', component: ApiScopeListComponent },
                { path: 'create', component: ApiScopeEditComponent },
				{ path: 'edit/:id', component: ApiScopeEditComponent },
                { path: 'detail/:id', component: ApiScopeDetailComponent }
            ]},
            {path: 'application', children: [
                { path: '', component: ApplicationListComponent },
                { path: 'create', component: ApplicationEditComponent },
				{ path: 'edit/:id', component: ApplicationEditComponent },
                { path: 'detail/:id', component: ApplicationDetailComponent }
            ]},
            {path: 'role', children: [
                { path: '', component: RoleListComponent },
                { path: 'create', component: RoleEditComponent },
                { path: 'create/:parentId', component: RoleEditComponent },
				{ path: 'edit/:id', component: RoleEditComponent },
                { path: 'detail/:id', component: RoleDetailComponent }
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