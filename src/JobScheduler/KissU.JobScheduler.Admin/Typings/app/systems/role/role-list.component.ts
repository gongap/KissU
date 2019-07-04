import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { RoleQuery } from './model/role-query';
import { RoleViewModel } from './model/role-view-model';
import { RoleEditComponent } from './role-edit.component';
import { RoleDetailComponent } from './role-detail.component';

/**
 * 角色列表页
 */
@Component({
    selector: 'role-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/role'
})
export class RoleListComponent extends TreeTableQueryComponentBase<RoleViewModel, RoleQuery>  {
    /**
     * 初始化角色列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
	    
    /**
     * 获取创建弹出框组件
     */
    getCreateDialogComponent() {
        return RoleEditComponent;
    }

    /**
     * 获取详情弹出框组件
     */
    getDetailDialogComponent() {
        return RoleDetailComponent;
    }
}