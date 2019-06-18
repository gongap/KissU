import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { RoleQuery } from './model/role-query';
import { RoleViewModel } from './model/role-view-model';

/**
 * 角色首页
 */
@Component({
    selector: 'role-index',
    templateUrl: env.prod() ? './html/role-index.component.html' : '/view/systems/role'
})
export class RoleIndexComponent extends TreeTableQueryComponentBase<RoleViewModel, RoleQuery>  {
    /**
     * 初始化角色首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new RoleQuery();
    }
}