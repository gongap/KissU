import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { LinkViewModel } from './model/link-view-model';

/**
 * 链接详情页
 */
@Component({
    selector: 'link-detail',
    templateUrl: !env.dev() ? './html/detail.component.html' : '/view/systems/link/detail'
})
export class LinkDetailComponent extends EditComponentBase<LinkViewModel> {
    /**
     * 初始化链接详情页
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