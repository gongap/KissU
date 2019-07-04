import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
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

/**
 * systems模块
 */
@NgModule({
    declarations: [
        ApplicationListComponent,ApplicationEditComponent,ApplicationDetailComponent,
        ResourceListComponent,ResourceEditComponent,ResourceDetailComponent,
        RoleListComponent,RoleEditComponent,RoleDetailComponent,
        UserListComponent,UserEditComponent,UserDetailComponent,
    ],
    imports: [
        FrameworkModule,SystemRoutingModule
    ]
})
export class SystemModule {
}