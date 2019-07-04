﻿import { TreeQueryParameter } from '../../../../util';

/**
 * 角色查询参数
 */
export class RoleQuery extends TreeQueryParameter {
    /**
     * 角色编号
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
     * 标准化角色名称
     */
    normalizedName;
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
    comment;
    /**
     * 拼音简码
     */
    pinYin;
    /**
     * 签名
     */
    sign;
    /**
     * 起始创建时间
     */
    beginCreationTime;
    /**
     * 结束创建时间
     */
    endCreationTime;
    /**
     * 创建人编号
     */
    creatorId;
    /**
     * 起始最后修改时间
     */
    beginLastModificationTime;
    /**
     * 结束最后修改时间
     */
    endLastModificationTime;
    /**
     * 最后修改人编号
     */
    lastModifierId;
}