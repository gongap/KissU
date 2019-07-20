import { Component, Injector, Input, OnInit } from '@angular/core';
import { env } from '../../env';
import { TreeTableQueryComponentBase } from '../../../util';
import { ModuleQuery } from '../module/model/module-query';
import { ModuleViewModel } from '../module/model/module-view-model';
import { PermissionViewModel } from './model/permission-view-model';
import { ApplicationViewModel } from "../application/model/application-view-model";
import { RoleViewModel } from "../role/model/role-view-model";

/**
 * 权限设置
 */
@Component( {
    selector: 'permission',
    templateUrl: !env.dev() ? './html/permission.component.html' : '/view/systems/role/permission'
} )
export class PermissionComponent extends TreeTableQueryComponentBase<ModuleViewModel, ModuleQuery> implements OnInit {
    /**
     * 角色参数
     */
    @Input() role: RoleViewModel;
    /**
     * 权限参数
     */
    model: PermissionViewModel;

    /**
     * 初始化权限设置
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
        this.model = new PermissionViewModel();
    }

    /**
     * 初始化
     */
    ngOnInit() {
        if ( !this.role )
            return;
        this.model.roleId = this.role.id;
        this.model.roleName = this.role.name;
        this.queryParam.roleId = this.role.id;
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        let result = new ModuleQuery();
        if ( this.model ) {
            result.applicationId = this.model.applicationId;
            result.roleId = this.model.roleId;
        }
        return result;
    }

    /**
     * 选择应用程序
     * @param application 应用程序
     */
    selectApplication( application: ApplicationViewModel ) {
        this.model.applicationId = application.id;
        this.model.applicationName = application.name;
        this.queryParam.applicationId = application.id;
        this.util.helper.clear( this.checkedIds );
        this.query( null, () => this.loadPermissions() );
    }

    /**
     * 加载权限
     */
    private loadPermissions() {
        this.util.webapi.get<string[]>( `/api/permission/resourceIds` ).param( this.queryParam ).handle( {
            ok: result => {
                this.checkIds( result );
            }
        } );
    }

    /**
     * 刷新完成后操作
     */
    protected refreshAfter = () => {
        this.loadPermissions();
    }

    /**
     * 保存
     */
    save() {
        this.model.resourceIds = this.getCheckedIds();
        this.util.form.submit( {
            url: `/api/permission`,
            data: this.model,
            confirm: `确定保存吗?`
        } );
    }
}