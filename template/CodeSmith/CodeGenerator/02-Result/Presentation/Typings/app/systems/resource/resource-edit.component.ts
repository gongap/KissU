import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ResourceViewModel } from './model/resource-view-model';

/**
 * 资源编辑页
 */
@Component({
    selector: 'resource-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/resource/edit'
})
export class ResourceEditComponent extends EditComponentBase<ResourceViewModel> {
    /**
     * 初始化资源编辑页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "resource";
    }
}