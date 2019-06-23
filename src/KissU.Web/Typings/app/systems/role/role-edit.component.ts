import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { RoleViewModel } from './model/role-view-model';

/**
 * 角色编辑
 */
@Component({
    selector: 'role-edit',
    templateUrl: env.prod() ? './html/role-edit.component.html' : '/view/systems/role/edit'
})
export class RoleEditComponent extends EditComponentBase<RoleViewModel> {
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
	    var model = new RoleViewModel();
        var parentId = null || this.util.router.getParam("parentId");
        model.parentId = parentId;
        return model;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "role";
    }
}