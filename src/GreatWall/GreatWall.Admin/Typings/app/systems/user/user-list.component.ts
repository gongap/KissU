import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { UserQuery } from './model/user-query';
import { UserViewModel } from './model/user-view-model';
import { UserCreateComponent } from './user-create.component';
import { UserDetailComponent } from './user-detail.component';

/**
 * 用户列表页
 */
@Component({
    selector: 'user-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/user'
})
export class UserListComponent extends TableQueryComponentBase<UserViewModel, UserQuery>  {
    /**
     * 初始化用户列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取创建弹出框组件
     */
    getCreateDialogComponent() {
        return UserCreateComponent;
    }

    /**
     * 获取详情弹出框组件
     */
    getDetailDialogComponent() {
        return UserDetailComponent;
    }

    /**
     * 获取创建弹出层宽度
     */
    getCreateDialogWidth() {
        return "30%";
    }
}