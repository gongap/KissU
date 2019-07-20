import { Component, Input, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { ModuleQuery } from './model/module-query';
import { ModuleViewModel } from './model/module-view-model';

/**
 * 模块选择页
 */
@Component( {
    selector: 'module-select',
    templateUrl: !env.dev() ? './html/select.component.html' : '/view/systems/module/select'
} )
export class ModuleSelectComponent extends TreeTableQueryComponentBase<ModuleViewModel, ModuleQuery>  {
    /**
     * 应用程序标识
     */
    @Input() applicationId;

    /**
     * 初始化模块列表页
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        let result = new ModuleQuery();
        result.applicationId = this.applicationId;
        return result;
    }
}