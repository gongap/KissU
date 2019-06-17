import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuIndexComponent } from './menu/menu-index.component';
import { MenuEditComponent } from './menu/menu-edit.component';
import { MenuDetailComponent } from './menu/menu-detail.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            {path: 'menu', children: [
                { path: '', component: MenuIndexComponent },
                { path: 'create', component: MenuEditComponent },
                { path: 'update/:id', component: MenuEditComponent },
                { path: 'detail/:id', component: MenuDetailComponent }
            ]},
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