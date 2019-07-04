import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
import { ApiListComponent } from './api/api-list.component';
import { ApiEditComponent } from './api/api-edit.component';
import { ApiDetailComponent } from './api/api-detail.component';
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
        ApplicationListComponent,ApplicationEditComponent,ApplicationDetailComponent,
        RoleListComponent,RoleEditComponent,RoleDetailComponent,
    ],
    imports: [
        FrameworkModule,SystemRoutingModule
    ],
    entryComponents: [
        ApiEditComponent,ApiDetailComponent,
        ApplicationEditComponent,ApplicationDetailComponent,
        RoleEditComponent,RoleDetailComponent,
    ]
})
export class SystemModule {
}