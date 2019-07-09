import { Component, Injector, OnInit } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { UserQuery } from '../user/model/user-query';
import { UserViewModel } from '../user/model/user-view-model';
import { SelectUserListComponent } from './select-user-list.component';

/**
 * 已选用户列表页
 */
@Component( {
    selector: 'role-user-list',
    templateUrl: !env.dev() ? './html/role-user-list.component.html' : '/view/systems/role/RoleUserList'
} )
export class RoleUserListComponent extends TableQueryComponentBase<UserViewModel, UserQuery> implements OnInit {
    /**
     * 初始化已选用户列表页
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.queryParam.roleId = this.getRoleId();
    }

    /**
     * 获取角色标识
     */
    getRoleId() {
        return this.data.id;
    }

    /**
     * 创建查询参数
     */
    createQuery() {
        let result = new UserQuery();
        if ( this.data )
            result.roleId = this.getRoleId();
        return result;
    }

    /**
     * 打开选择用户列表弹出框
     */
    openSelectDialog() {
        this.util.dialog.open( {
            component: SelectUserListComponent,
            data: { data: this.data },
            width: "60%",
            disableClose: true,
            onOk: instance => {
                let userIds = instance.getCheckedIds();
                this.select( userIds );
                return false;
            },
            onClose: result => {
                if ( result )
                    this.query();
            }
        } );
    }

    /**
     * 选中用户
     */
    select( userIds ) {
        if ( !userIds ) {
            this.util.message.warn( "请选择用户" );
            return;
        }
        this.util.form.submit( {
            url: "/api/role/AddUsersToRole",
            data: { roleId: this.getRoleId(), userIds: userIds },
            confirm: `确定将选中的用户添加到角色?`,
            closeDialog: true
        } );
    }

    /**
     * 从角色移除用户
     */
    removeUsersFromRole( btn? ) {
        let userIds = this.getCheckedIds();
        if ( !userIds ) {
            this.util.message.warn( "请选择待移除的用户" );
            return;
        }
        this.util.form.submit( {
            url: "/api/role/RemoveUsersFromRole",
            data: { roleId: this.getRoleId(), userIds: userIds },
            button: btn,
            confirm: `确定从角色移除用户?`,
            ok: () => {
                this.query();
            }
        } );
    }
}