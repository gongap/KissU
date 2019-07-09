import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OidcAuthorize as Authorize } from "../util";
import { LayoutDefaultComponent } from './home/layout/default/default.component';
import { DashboardV1Component } from './home/dashboard/v1.component';
import { LoginCallbackComponent } from "./login-callback.component";

//路由配置
const routes: Routes = [
    {
        path: '',
        component: LayoutDefaultComponent,
        canActivate: [Authorize],
        canActivateChild: [Authorize],
        children: [
            { path: '', redirectTo: 'dashboard/v1', pathMatch: 'full' },
            { path: 'dashboard', redirectTo: 'dashboard/v1', pathMatch: 'full' },
            { path: 'dashboard/v1', component: DashboardV1Component },
            { path: 'systems', loadChildren: "./systems/system.module#SystemModule" }
        ]
    },
    { path: 'callback', component: LoginCallbackComponent }
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