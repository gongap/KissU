import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { ApplicationQuery } from './model/application-query';
import { ApplicationViewModel } from './model/application-view-model';

/**
 * 应用程序列表页
 */
@Component({
    selector: 'application-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/application'
})
export class ApplicationListComponent extends TableQueryComponentBase<ApplicationViewModel, ApplicationQuery>  {
    /**
     * 初始化应用程序列表页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
}