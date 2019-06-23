import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { MenuViewModel } from './model/menu-view-model';

/**
 * 菜单编辑
 */
@Component({
    selector: 'menu-edit',
    templateUrl: env.prod() ? './html/menu-edit.component.html' : '/view/systems/menu/edit'
})
export class MenuEditComponent extends EditComponentBase<MenuViewModel> {
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
	    var model = new MenuViewModel();
        var parentId = null || this.util.router.getParam("parentId");
        model.parentId = parentId;
        return model;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "menu";
    }
}