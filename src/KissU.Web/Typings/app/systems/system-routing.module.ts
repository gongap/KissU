import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApiIndexComponent } from './api/api-index.component';
import { ApiEditComponent } from './api/api-edit.component';
import { ApiDetailComponent } from './api/api-detail.component';
import { ApplicationIndexComponent } from './application/application-index.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { MenuIndexComponent } from './menu/menu-index.component';
import { MenuEditComponent } from './menu/menu-edit.component';
import { MenuDetailComponent } from './menu/menu-detail.component';
import { RoleIndexComponent } from './role/role-index.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            {path: 'api', children: [
                { path: '', component: ApiIndexComponent },
                { path: 'create', component: ApiEditComponent },
                { path: 'update/:id', component: ApiEditComponent },
                { path: 'detail/:id', component: ApiDetailComponent }
            ]},
            {path: 'application', children: [
                { path: '', component: ApplicationIndexComponent },
                { path: 'create', component: ApplicationEditComponent },
                { path: 'update/:id', component: ApplicationEditComponent },
                { path: 'detail/:id', component: ApplicationDetailComponent }
            ]},
            {path: 'menu', children: [
                { path: '', component: MenuIndexComponent },
                { path: 'create', component: MenuEditComponent },
                { path: 'create/:parentId', component: MenuEditComponent },
                { path: 'update/:id', component: MenuEditComponent },
                { path: 'detail/:id', component: MenuDetailComponent }
            ]},
            {path: 'role', children: [
                { path: '', component: RoleIndexComponent },
                { path: 'create', component: RoleEditComponent },
                { path: 'create/:parentId', component: RoleEditComponent },
                { path: 'update/:id', component: RoleEditComponent },
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