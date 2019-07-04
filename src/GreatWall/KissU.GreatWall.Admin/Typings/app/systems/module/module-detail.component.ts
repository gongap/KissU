import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ModuleViewModel } from './model/module-view-model';

/**
 * 模块详情页
 */
@Component({
    selector: 'module-detail',
    templateUrl: !env.dev() ? './html/detail.component.html' : '/view/systems/module/detail'
})
export class ModuleDetailComponent extends EditComponentBase<ModuleViewModel> {
    /**
     * 初始化模块详情页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "module";
    }

    /**
     * 是否远程加载
     */
    isRequestLoad() {
        return false;
    }
}