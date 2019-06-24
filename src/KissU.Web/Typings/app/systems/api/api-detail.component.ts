import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ApiViewModel } from './model/api-view-model';

/**
 * Api资源详细
 */
@Component({
    selector: 'api-detail',
    templateUrl: env.prod() ? './html/api-detail.component.html' : '/view/systems/api/detail'
})
export class ApiDetailComponent extends EditComponentBase<ApiViewModel> {
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
        return new ApiViewModel();
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "api";
    }
}