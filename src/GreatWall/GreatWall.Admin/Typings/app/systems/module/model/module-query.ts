import { TreeQueryParameter } from '../../../../util';

/**
 * 模块查询参数
 */
export class ModuleQuery extends TreeQueryParameter {
    /**
     * 标识
     */
    resourceId;
    /**
     * 应用程序标识
     */
    applicationId;
    /**
     * 角色标识
     */
    roleId;
    /**
     * 资源标识
     */
    uri;
    /**
     * 资源名称
     */
    name;
    /**
     * 备注
     */
    remark;
    /**
     * 起始创建时间
     */
    beginCreationTime;
    /**
     * 结束创建时间
     */
    endCreationTime;
}