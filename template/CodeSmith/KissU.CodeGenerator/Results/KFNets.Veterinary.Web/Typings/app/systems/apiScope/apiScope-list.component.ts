import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { ApiScopeQuery } from './model/apiScope-query';
import { ApiScopeViewModel } from './model/apiScope-view-model';

/**
 * Api许可范围列表页
 */
@Component({
    selector: 'apiScope-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/apiScope'
})
export class ApiScopeListComponent extends TableQueryComponentBase<ApiScopeViewModel, ApiScopeQuery>  {
    /**
     * 初始化Api许可范围列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
}