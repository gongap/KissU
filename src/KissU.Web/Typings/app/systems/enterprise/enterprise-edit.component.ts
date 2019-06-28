import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { EnterpriseViewModel } from './model/enterprise-view-model';

/**
 * 企业编辑页
 */
@Component({
    selector: 'enterprise-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/enterprise/edit'
})
export class EnterpriseEditComponent extends EditComponentBase<EnterpriseViewModel> {
    /**
     * 初始化企业编辑页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 创建视图模型
     */
    protected createModel() {
	    var model = new EnterpriseViewModel();
        return model;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "enterprise";
    }
}