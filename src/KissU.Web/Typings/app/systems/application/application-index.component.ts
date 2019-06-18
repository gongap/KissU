import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { ApplicationQuery } from './model/application-query';
import { ApplicationViewModel } from './model/application-view-model';

/**
 * 应用程序首页
 */
@Component({
    selector: 'application-index',
    templateUrl: env.prod() ? './html/application-index.component.html' : '/view/systems/application'
})
export class ApplicationIndexComponent extends TableQueryComponentBase<ApplicationViewModel, ApplicationQuery>  {
    /**
     * 初始化应用程序首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }
    
    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new ApplicationQuery();
    }
}