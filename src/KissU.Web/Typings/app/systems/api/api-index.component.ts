import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { ApiQuery } from './model/api-query';
import { ApiViewModel } from './model/api-view-model';

/**
 * Api资源首页
 */
@Component({
    selector: 'api-index',
    templateUrl: env.prod() ? './html/api-index.component.html' : '/view/systems/api'
})
export class ApiIndexComponent extends TableQueryComponentBase<ApiViewModel, ApiQuery>  {
    /**
     * 初始化Api资源首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new ApiQuery();
    }
}