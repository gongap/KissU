import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase, ComponentBase } from '../../../util';
import { MenuQuery } from './model/menu-query';
import { MenuViewModel } from './model/menu-view-model';

/**
 * 菜单首页
 */
@Component({
    selector: 'menu-index',
    templateUrl: env.prod() ? './html/menu-index.component.html' : '/view/systems/menu'
})
export class MenuIndexComponent extends ComponentBase  {
    /**
     * 查询参数
     */
    queryParam: MenuQuery;

    /**
     * 初始化
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new MenuQuery();
    }
}