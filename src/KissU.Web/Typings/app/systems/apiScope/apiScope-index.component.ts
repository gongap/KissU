import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { ApiScopeQuery } from './model/apiScope-query';
import { ApiScopeViewModel } from './model/apiScope-view-model';

/**
 * Api许可范围首页
 */
@Component({
    selector: 'apiScope-index',
    templateUrl: env.prod() ? './html/apiScope-index.component.html' : '/view/systems/apiScope'
})
export class ApiScopeIndexComponent extends TableQueryComponentBase<ApiScopeViewModel, ApiScopeQuery>  {
    /**
     * 初始化Api许可范围首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new ApiScopeQuery();
    }
}