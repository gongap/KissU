import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { DialogEditComponentBase } from '../../../util';
import { ApiViewModel } from './model/api-view-model';

/**
 * Api资源详情页
 */
@Component({
    selector: 'api-detail',
    templateUrl: !env.dev() ? './html/detail.component.html' : '/view/systems/api/detail'
})
export class ApiDetailComponent extends DialogEditComponentBase<ApiViewModel> {
    /**
     * 初始化Api资源详情页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "api";
    }

	/**
     * 是否远程加载
     */
    isRequestLoad() {
        return false;
    }
}