import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { LinkQuery } from './model/link-query';
import { LinkViewModel } from './model/link-view-model';

/**
 * 链接列表页
 */
@Component({
    selector: 'link-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/link'
})
export class LinkListComponent extends TableQueryComponentBase<LinkViewModel, LinkQuery>  {
    /**
     * 初始化链接列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
}