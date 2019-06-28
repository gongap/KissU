import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { MenuQuery } from './model/menu-query';
import { MenuViewModel } from './model/menu-view-model';

/**
 * 菜单列表页
 */
@Component({
    selector: 'menu-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/menu'
})
export class MenuListComponent extends TreeTableQueryComponentBase<MenuViewModel, MenuQuery>  {
    /**
     * 初始化菜单列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
}