import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ApplicationViewModel } from './model/application-view-model';

/**
 * 应用程序编辑
 */
@Component({
    selector: 'application-edit',
    templateUrl: env.prod() ? './html/application-edit.component.html' : '/view/systems/application/edit'
})
export class ApplicationEditComponent extends EditComponentBase<ApplicationViewModel> {
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
	    var model = new ApplicationViewModel();
        return model;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "application";
    }
}