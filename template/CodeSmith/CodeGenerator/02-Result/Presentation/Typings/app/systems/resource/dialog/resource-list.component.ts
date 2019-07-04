import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { ResourceQuery } from './model/resource-query';
import { ResourceViewModel } from './model/resource-view-model';
import { ResourceEditComponent } from './resource-edit.component';
import { ResourceDetailComponent } from './resource-detail.component';

/**
 * 资源列表页
 */
@Component({
    selector: 'resource-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/resource'
})
export class ResourceListComponent extends TableQueryComponentBase<ResourceViewModel, ResourceQuery>  {
    /**
     * 初始化资源列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 获取创建弹出框组件
     */
    getCreateDialogComponent() {
        return ResourceEditComponent;
    }

    /**
     * 获取详情弹出框组件
     */
    getDetailDialogComponent() {
        return ResourceDetailComponent;
    }
}