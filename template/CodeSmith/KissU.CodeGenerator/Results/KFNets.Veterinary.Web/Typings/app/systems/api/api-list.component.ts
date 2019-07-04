import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { ApiQuery } from './model/api-query';
import { ApiViewModel } from './model/api-view-model';

/**
 * Api资源列表页
 */
@Component({
    selector: 'api-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/api'
})
export class ApiListComponent extends TableQueryComponentBase<ApiViewModel, ApiQuery>  {
    /**
     * 初始化Api资源列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
}