import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { MenuQuery } from './model/menu-query';
import { MenuViewModel } from './model/menu-view-model';

/**
 * 菜单首页
 */
@Component({
    selector: 'menu-index',
    templateUrl: env.prod() ? './html/menu-index.component.html' : '/view/systems/menu'
})
export class MenuIndexComponent extends TreeTableQueryComponentBase<MenuViewModel, MenuQuery>  {
    /**
     * 初始化菜单首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new MenuQuery();
    }
}