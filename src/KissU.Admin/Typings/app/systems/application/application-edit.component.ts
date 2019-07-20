import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { DialogEditComponentBase } from '../../../util';
import { ApplicationViewModel } from './model/application-view-model';

/**
 * 应用程序编辑页
 */
@Component({
    selector: 'application-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/application/edit'
})
export class ApplicationEditComponent extends DialogEditComponentBase<ApplicationViewModel> {
    /**
     * 初始化应用程序编辑页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 创建模型
     */
    protected createModel() {
        let result = new ApplicationViewModel();
        result.enabled = true;
        result.registerEnabled = true;
        return result;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "application";
    }

    /**
     * 是否远程加载
     */
    isRequestLoad() {
        return false;
    }
}