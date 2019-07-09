import { Component, Injector, OnInit, Output, EventEmitter } from '@angular/core';
import { env } from '../../env';
import { ComponentBase } from '../../../util';
import { ApplicationViewModel } from './model/application-view-model';

/**
 * 公共组件 - 选择应用程序
 */
@Component({
    selector: 'application-select',
    templateUrl: !env.dev() ? './html/select.component.html' : '/view/systems/application/select'
})
export class ApplicationSelectComponent extends ComponentBase implements OnInit {
    /**
     * 应用程序列表
     */
    list: ApplicationViewModel[];
    /**
     * 当前应用程序
     */
    selected: ApplicationViewModel;
    /**
     * 加载状态
     */
    loading;
    /**
     * 单击事件
     */
    @Output() onClick = new EventEmitter<ApplicationViewModel>();

    /**
     * 初始化选择应用程序
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super( injector );
        this.list = new Array<ApplicationViewModel>();
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.loadApplications();
    }

    /**
     * 加载应用程序列表
     */
    loadApplications() {
        this.util.webapi.get<ApplicationViewModel[]>( "/api/application/all" ).handle( {
            before: () => this.loading = true,
            ok: result => {
                this.list = result;
                this.selectApplication();
            },
            complete: () => this.loading = false
        } );
    }

    /**
     * 选择当前应用程序
     */
    private selectApplication() {
        if ( !this.list || this.list.length === 0 )
            return;
        this.click( this.list[0] );
    }

    /**
     * 单击
     */
    click( item ) {
        this.selected = item;
        this.onClick.emit( item );
    }
}