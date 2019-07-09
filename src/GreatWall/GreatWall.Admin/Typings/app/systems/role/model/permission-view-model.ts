import { ViewModel } from '../../../../util';

/**
 * 权限参数
 */
export class PermissionViewModel extends ViewModel {
    /**
     * 应用程序标识
     */
    applicationId;
    /**
     * 应用程序名称
     */
    applicationName;
    /**
     * 角色标识
     */
    roleId;
    /**
     * 角色名称
     */
    roleName;
    /**
     * 资源标识列表
     */
    resourceIds;
    /**
     * 拒绝
     */
    isDeny;
}