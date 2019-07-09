import { NgModule } from '@angular/core';

//框架模块
import { FrameworkModule } from '../framework.module';

//仪表盘
import { DashboardIndexComponent } from './dashboard/dashboard-index.component';

//组件列表
const components = [
    DashboardIndexComponent
];

/**
 * 主界面模块
 */
@NgModule({
    imports: [FrameworkModule],
    declarations: components,
    exports: components
})
export class HomeModule { }
