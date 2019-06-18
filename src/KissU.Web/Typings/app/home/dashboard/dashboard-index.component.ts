import { Component, OnInit } from '@angular/core';
import { env } from '../../env';
import { LineWrapperComponent } from "../../../util";

/**
 * Dashboard 默认页组件
 */
@Component({
    selector: 'app-dashboard-index',
    templateUrl: !env.dev() ? './html/index.component.html' : '/View/Home/Dashboard/Index',
})
export class DashboardIndexComponent implements OnInit {
    /**
     * 初始化
     */
    ngOnInit() {
    }
}