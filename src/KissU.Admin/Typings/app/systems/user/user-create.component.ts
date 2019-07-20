import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { DialogEditComponentBase } from '../../../util';
import { CreateUserViewModel } from './model/create-user-view-model';

/**
 * 用户创建页
 */
@Component({
    selector: 'user-edit',
    templateUrl: !env.dev() ? './html/create.component.html' : '/view/systems/user/create'
})
export class UserCreateComponent extends DialogEditComponentBase<CreateUserViewModel> {
    /**
     * 初始化用户创建页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "user";
    }
}