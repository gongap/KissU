import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { ModuleQuery } from './model/module-query';
import { ModuleViewModel } from './model/module-view-model';
import { ApplicationViewModel } from "../application/model/application-view-model";
import { ModuleEditComponent } from './module-edit.component';
import { ModuleDetailComponent } from './module-detail.component';

/**
 * 模块列表页
 */
@Component( {
    selector: 'module-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/module'
} )
export class ModuleListComponent extends TreeTableQueryComponentBase<ModuleViewModel, ModuleQuery>  {
    /**
     * 当前应用程序
     */
    selectedApplication: ApplicationViewModel;

    /**
     * 初始化模块列表页
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
        this.selectedApplication = new ApplicationViewModel();
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        let result = new ModuleQuery();
        if ( this.selectedApplication )
            result.applicationId = this.selectedApplication.id;
        return result;
    }

    /**
     * 选择应用程序
     * @param application 应用程序
     */
    selectApplication( application: ApplicationViewModel ) {
        this.selectedApplication = application;
        this.queryParam.applicationId = application.id;
        this.query();
    }

    /**
     * 获取创建弹出层组件
     */
    getCreateDialogComponent() {
        return ModuleEditComponent;
    }

    /**
     * 获取创建弹出层数据
     */
    protected getCreateDialogData( data?) {
        return {
            parent: data,
            applicationId: this.selectedApplication.id,
            applicationName: this.selectedApplication.name
        }
    }

    /**
     * 创建弹出框打开前回调函数
     */
    onCreateBeforeOpen() {
        if ( this.selectedApplication.id )
            return true;
        this.util.message.warn( "请选择应用程序" );
        return false;
    }

    /**
     * 获取更新弹出框数据
     */
    protected getEditDialogData( data ) {
        if ( !data )
            return null;
        return {
            id: data.id,
            data: data,
            applicationId: this.selectedApplication.id,
            applicationName: this.selectedApplication.name
        };
    }

    /**
     * 获取详情弹出框组件
     */
    getDetailDialogComponent() {
        return ModuleDetailComponent;
    }
}