import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { RoleQuery } from './model/role-query';
import { RoleViewModel } from './model/role-view-model';
import { RoleEditComponent } from './role-edit.component';
import { RoleDetailComponent } from './role-detail.component';
import { RoleUserListComponent } from './role-user-list.component';
import { PermissionComponent } from './permission.component';

/**
 * 角色列表页
 */
@Component({
    selector: 'role-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/role'
})
export class RoleListComponent extends TableQueryComponentBase<RoleViewModel, RoleQuery>  {
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

    /**
     * 打开用户设置弹出框
     */
    openUserDialog( role ) {
        this.util.dialog.open( {
            component: RoleUserListComponent,
            data: { data: role },
            showOk:false,
            disableClose: true,
            width: "60%"
        } );
    }

    /**
     * 打开权限设置弹出框
     */
    openPermissionDialog( role ) {
        this.util.dialog.open( {
            component: PermissionComponent,
            data: { role: role },
            disableClose: true,
            width: "80%",
            onOk: instance => {
                instance.save();
                return false;
            },
        } );
    }
}