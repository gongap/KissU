import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase, util } from '../../../util';
import { MenuViewModel } from './model/menu-view-model';



/**
 * 编辑
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
        util.webapi.post(`htpp:///bm/user`).param({ id: '123' }).handleAsync({
            ok: () => {

            },
            
        })
        
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