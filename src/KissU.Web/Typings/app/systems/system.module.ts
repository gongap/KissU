import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
import { ApplicationListComponent } from './application/application-list.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';

/**
 * systems模块
 */
@NgModule({
    declarations: [
        ApplicationListComponent,ApplicationEditComponent,ApplicationDetailComponent,
    ],
    imports: [
        FrameworkModule,SystemRoutingModule
    ]
})
export class SystemModule {
}