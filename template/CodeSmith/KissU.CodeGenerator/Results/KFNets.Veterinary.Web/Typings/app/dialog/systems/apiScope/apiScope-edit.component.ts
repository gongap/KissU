import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { DialogEditComponentBase } from '../../../util';
import { ApiScopeViewModel } from './model/apiScope-view-model';

/**
 * Api许可范围编辑页
 */
@Component({
    selector: 'apiScope-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/apiScope/edit'
})
export class ApiScopeEditComponent extends DialogEditComponentBase<ApiScopeViewModel> {
    /**
     * 初始化Api许可范围编辑页
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