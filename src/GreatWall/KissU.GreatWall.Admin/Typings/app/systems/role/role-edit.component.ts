import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { DialogEditComponentBase } from '../../../util';
import { RoleViewModel } from './model/role-view-model';

/**
 * 角色编辑页
 */
@Component({
    selector: 'role-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/role/edit'
})
export class RoleEditComponent extends DialogEditComponentBase<RoleViewModel> {
    /**
     * 初始化角色编辑页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "role";
    }

    /**
     * 创建模型
     */
    createModel() {
        let result = new RoleViewModel();
        result.enabled = true;
        return result;
    }
}