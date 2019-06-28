import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { EnterpriseQuery } from './model/enterprise-query';
import { EnterpriseViewModel } from './model/enterprise-view-model';

/**
 * 企业列表页
 */
@Component({
    selector: 'enterprise-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/enterprise'
})
export class EnterpriseListComponent extends TableQueryComponentBase<EnterpriseViewModel, EnterpriseQuery>  {
    /**
     * 初始化企业列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
}