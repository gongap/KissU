import { Component, Injector, Input } from '@angular/core';
import { env } from '../../env';
import { DialogTreeEditComponentBase } from '../../../util';
import { ModuleViewModel } from './model/module-view-model';
import { ModuleSelectComponent } from './module-select.component';

/**
 * 模块编辑页
 */
@Component( {
    selector: 'module-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/module/edit'
} )
export class ModuleEditComponent extends DialogTreeEditComponentBase<ModuleViewModel> {
    /**
     * 应用程序标识
     */
    @Input() applicationId;
    /**
     * 应用程序名称
     */
    @Input() applicationName;

    /**
     * 初始化模块编辑页
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
    }

    /**
     * 初始化
     */
    ngOnInit() {
        super.ngOnInit();
        this.model.applicationId = this.applicationId;
    }

    /**
     * 创建模型
     */
    createModel() {
        let result = new ModuleViewModel();
        result.enabled = true;
        return result;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "module";
    }

    /**
     * 获取选择框组件
     */
    getSelectDialogComponent() {
        return ModuleSelectComponent;
    }

    /**
     * 获取选择框数据
     */
    protected getSelectDialogData() {
        return { applicationId: this.applicationId, data: this.parent };
    }

    /**
     * 是否请求加载
     */
    isRequestLoad() {
        return false;
    }
}