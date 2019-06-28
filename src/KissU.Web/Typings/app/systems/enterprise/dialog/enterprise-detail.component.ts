import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditDialogComponentBase } from '../../../util';
import { EnterpriseViewModel } from './model/enterprise-view-model';

/**
 * 企业详情页
 */
@Component({
    selector: 'enterprise-detail',
    templateUrl: !env.dev() ? './html/detail.component.html' : '/view/systems/enterprise/detail'
})
export class EnterpriseDetailComponent extends EditDialogComponentBase<EnterpriseViewModel> {
    /**
     * 初始化企业详情页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "enterprise";
    }
}