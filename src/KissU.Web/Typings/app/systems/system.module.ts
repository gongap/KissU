import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
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