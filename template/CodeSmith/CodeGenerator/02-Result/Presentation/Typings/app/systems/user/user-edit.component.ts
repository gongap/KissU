import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { UserViewModel } from './model/user-view-model';

/**
 * 用户编辑页
 */
@Component({
    selector: 'user-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/user/edit'
})
export class UserEditComponent extends EditComponentBase<UserViewModel> {
    /**
     * 初始化用户编辑页
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