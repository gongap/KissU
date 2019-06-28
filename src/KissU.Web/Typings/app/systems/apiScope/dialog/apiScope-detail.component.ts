import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditDialogComponentBase } from '../../../util';
import { ApiScopeViewModel } from './model/apiScope-view-model';

/**
 * Api许可范围详情页
 */
@Component({
    selector: 'apiScope-detail',
    templateUrl: !env.dev() ? './html/detail.component.html' : '/view/systems/apiScope/detail'
})
export class ApiScopeDetailComponent extends EditDialogComponentBase<ApiScopeViewModel> {
    /**
     * 初始化Api许可范围详情页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "apiScope";
    }
}