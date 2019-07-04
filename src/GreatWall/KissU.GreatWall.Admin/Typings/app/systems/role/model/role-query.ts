import { QueryParameter } from '../../../../util';

/**
 * 角色查询参数
 */
export class RoleQuery extends QueryParameter {
    /**
     * 角色标识
     */
    roleId;
    /**
     * 角色编码
     */
    code;
    /**
     * 角色名称
     */
    name;
    /**
     * 角色类型
     */
    type;
    /**
     * 管理员
     */
    isAdmin;
    /**
     * 备注
     */
    remark;
    /**
     * 拼音简码
     */
    pinYin;
    /**
     * 起始创建时间
     */
    beginCreationTime;
    /**
     * 结束创建时间
     */
    endCreationTime;
}