import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditDialogComponentBase } from '../../../util';
import { MenuViewModel } from './model/menu-view-model';

/**
 * 菜单编辑页
 */
@Component({
    selector: 'menu-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/menu/edit'
})
export class MenuEditComponent extends EditDialogComponentBase<MenuViewModel> {
    /**
     * 初始化菜单编辑页
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