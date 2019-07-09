import { Component, Injector,OnInit } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { UserQuery } from '../user/model/user-query';
import { UserViewModel } from '../user/model/user-view-model';

/**
 * 选择用户列表页
 */
@Component({
    selector: 'select-user-list',
    templateUrl: !env.dev() ? './html/select-user-list.component.html' : '/view/systems/role/SelectUserList'
} )
export class SelectUserListComponent extends TableQueryComponentBase<UserViewModel, UserQuery> implements OnInit {
    /**
     * 初始化选择用户列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.queryParam.exceptRoleId = this.getRoleId();
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
            result.exceptRoleId = this.getRoleId();
        return result;
    }
}