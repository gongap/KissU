import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { RoleQuery } from './model/role-query';
import { RoleViewModel } from './model/role-view-model';

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
}