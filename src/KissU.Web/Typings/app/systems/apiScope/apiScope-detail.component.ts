import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ApiScopeViewModel } from './model/apiScope-view-model';

/**
 * Api许可范围详细
 */
@Component({
    selector: 'apiScope-detail',
    templateUrl: env.prod() ? './html/apiScope-detail.component.html' : '/view/systems/apiScope/detail'
})
export class ApiScopeDetailComponent extends EditComponentBase<ApiScopeViewModel> {
    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 创建视图模型
     */
    protected createModel() {
        return new ApiScopeViewModel();
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "apiScope";
    }
}