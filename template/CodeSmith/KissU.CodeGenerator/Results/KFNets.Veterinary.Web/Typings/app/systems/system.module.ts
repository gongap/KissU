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
import { RoleListComponent } from './role/role-list.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';

/**
 * systems模块
 */
@NgModule({
    declarations: [
        ApiListComponent,ApiEditComponent,ApiDetailComponent,
        ApiScopeListComponent,ApiScopeEditComponent,ApiScopeDetailComponent,
        ApplicationListComponent,ApplicationEditComponent,ApplicationDetailComponent,
        RoleListComponent,RoleEditComponent,RoleDetailComponent,
    ],
    imports: [
        FrameworkModule,SystemRoutingModule
    ]
})
export class SystemModule {
}