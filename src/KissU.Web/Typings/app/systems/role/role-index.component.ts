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
     * 查询参数
     */
    queryParam: RoleQuery;

    /**
     * 初始化
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new RoleQuery();
    }
}