import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
import { ApiListComponent } from './api/api-list.component';
import { ApiEditComponent } from './api/api-edit.component';
import { ApiDetailComponent } from './api/api-detail.component';
import { ApiScopeListComponent } from './apiScope/apiScope-list.component';
import { ApiScopeEditComponent } from './apiScope/apiScope-edit.component';
import { ApiScopeDetailComponent } from './apiScope/apiScope-detail.component';
import { ApplicationListComponent } from './application/application-list.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { EnterpriseListComponent } from './enterprise/enterprise-list.component';
import { EnterpriseEditComponent } from './enterprise/enterprise-edit.component';
import { EnterpriseDetailComponent } from './enterprise/enterprise-detail.component';
import { LinkListComponent } from './link/link-list.component';
import { LinkEditComponent } from './link/link-edit.component';
import { LinkDetailComponent } from './link/link-detail.component';
import { MenuListComponent } from './menu/menu-list.component';
import { MenuEditComponent } from './menu/menu-edit.component';
import { MenuDetailComponent } from './menu/menu-detail.component';
import { RoleListComponent } from './role/role-list.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';
import { UserListComponent } from './user/user-list.component';
import { UserEditComponent } from './user/user-edit.component';
import { UserDetailComponent } from './user/user-detail.component';

/**
 * systems模块
 */
@NgModule({
    declarations: [
        ApiListComponent,ApiEditComponent,ApiDetailComponent,
        ApiScopeListComponent,ApiScopeEditComponent,ApiScopeDetailComponent,
        ApplicationListComponent,ApplicationEditComponent,ApplicationDetailComponent,
        EnterpriseListComponent,EnterpriseEditComponent,EnterpriseDetailComponent,
        LinkListComponent,LinkEditComponent,LinkDetailComponent,
        MenuListComponent,MenuEditComponent,MenuDetailComponent,
        RoleListComponent,RoleEditComponent,RoleDetailComponent,
        UserListComponent,UserEditComponent,UserDetailComponent,
    ],
    imports: [
        FrameworkModule,SystemRoutingModule
    ]
})
export class SystemModule {
}