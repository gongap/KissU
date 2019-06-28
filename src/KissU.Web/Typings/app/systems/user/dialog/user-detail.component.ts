import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditDialogComponentBase } from '../../../util';
import { UserViewModel } from './model/user-view-model';

/**
 * 用户详情页
 */
@Component({
    selector: 'user-detail',
    templateUrl: !env.dev() ? './html/detail.component.html' : '/view/systems/user/detail'
})
export class UserDetailComponent extends EditDialogComponentBase<UserViewModel> {
    /**
     * 初始化用户详情页
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