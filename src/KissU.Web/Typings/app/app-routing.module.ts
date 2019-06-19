import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutDefaultComponent } from './home/layout/default/default.component';
import { DashboardIndexComponent } from './home/dashboard/dashboard-index.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        component: LayoutDefaultComponent,
        children: [
            { path: '', redirectTo: 'dashboard/index', pathMatch: 'full' },
            { path: 'dashboard', redirectTo: 'dashboard/index', pathMatch: 'full' },
            { path: 'dashboard/index', component: DashboardIndexComponent },
            { path: 'system', loadChildren: "./systems/system.module#SystemModule" },
        ]
    }
];

/**
 * 路由配置模块
 */
@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ]
})
export class AppRoutingModule { }