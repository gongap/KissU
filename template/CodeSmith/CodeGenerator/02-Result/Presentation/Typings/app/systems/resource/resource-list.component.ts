import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { ResourceQuery } from './model/resource-query';
import { ResourceViewModel } from './model/resource-view-model';

/**
 * 资源列表页
 */
@Component({
    selector: 'resource-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/resource'
})
export class ResourceListComponent extends TreeTableQueryComponentBase<ResourceViewModel, ResourceQuery>  {
    /**
     * 初始化资源列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
}