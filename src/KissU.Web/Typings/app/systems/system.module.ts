import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
import { ApiIndexComponent } from './api/api-index.component';
import { ApiEditComponent } from './api/api-edit.component';
import { ApiDetailComponent } from './api/api-detail.component';
import { ApiScopeIndexComponent } from './apiScope/apiScope-index.component';
import { ApiScopeEditComponent } from './apiScope/apiScope-edit.component';
import { ApiScopeDetailComponent } from './apiScope/apiScope-detail.component';
import { ApplicationIndexComponent } from './application/application-index.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { MenuIndexComponent } from './menu/menu-index.component';
import { MenuEditComponent } from './menu/menu-edit.component';
import { MenuDetailComponent } from './menu/menu-detail.component';
import { RoleIndexComponent } from './role/role-index.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';

/**
 * systems模块
 */
@NgModule({
    declarations: [
        ApiIndexComponent,ApiEditComponent,ApiDetailComponent,
        ApiScopeIndexComponent,ApiScopeEditComponent,ApiScopeDetailComponent,
        ApplicationIndexComponent,ApplicationEditComponent,ApplicationDetailComponent,
        MenuIndexComponent,MenuEditComponent,MenuDetailComponent,
        RoleIndexComponent,RoleEditComponent,RoleDetailComponent,
    ],
    imports: [
        FrameworkModule,SystemRoutingModule
    ]
})
export class SystemModule {
}