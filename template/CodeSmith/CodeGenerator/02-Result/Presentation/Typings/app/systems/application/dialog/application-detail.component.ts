import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { DialogEditComponentBase } from '../../../util';
import { ApplicationViewModel } from './model/application-view-model';

/**
 * 应用程序详情页
 */
@Component({
    selector: 'application-detail',
    templateUrl: !env.dev() ? './html/detail.component.html' : '/view/systems/application/detail'
})
export class ApplicationDetailComponent extends DialogEditComponentBase<ApplicationViewModel> {
    /**
     * 初始化应用程序详情页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
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