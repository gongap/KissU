import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditDialogComponentBase } from '../../../util';
import { LinkViewModel } from './model/link-view-model';

/**
 * 链接编辑页
 */
@Component({
    selector: 'link-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/link/edit'
})
export class LinkEditComponent extends EditDialogComponentBase<LinkViewModel> {
    /**
     * 初始化链接编辑页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "link";
    }
}