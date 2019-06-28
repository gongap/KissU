import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditDialogComponentBase } from '../../../util';
import { MenuViewModel } from './model/menu-view-model';

/**
 * 菜单详情页
 */
@Component({
    selector: 'menu-detail',
    templateUrl: !env.dev() ? './html/detail.component.html' : '/view/systems/menu/detail'
})
export class MenuDetailComponent extends EditDialogComponentBase<MenuViewModel> {
    /**
     * 初始化菜单详情页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "menu";
    }
}