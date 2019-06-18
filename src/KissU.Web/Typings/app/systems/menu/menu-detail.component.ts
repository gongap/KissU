import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { MenuViewModel } from './model/menu-view-model';

/**
 * 菜单详细
 */
@Component({
    selector: 'menu-detail',
    templateUrl: env.prod() ? './html/menu-detail.component.html' : '/view/systems/menu/detail'
})
export class MenuDetailComponent extends EditComponentBase<MenuViewModel> {
    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 创建视图模型
     */
    protected createModel() {
        return new MenuViewModel();
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "menu";
    }
}