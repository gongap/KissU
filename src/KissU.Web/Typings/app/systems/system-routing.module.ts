import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationListComponent } from './application/application-list.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'application', component: ApplicationListComponent },
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