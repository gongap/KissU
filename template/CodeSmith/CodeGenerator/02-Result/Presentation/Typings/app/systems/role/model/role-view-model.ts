import { TreeViewModel } from '../../../../util';

/**
 * 角色参数
 */
export class RoleViewModel extends TreeViewModel {
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
    remark;
    /**
     * 拼音简码
     */
    pinYin;
    /**
     * 签名
     */
    sign;
    /**
     * 创建时间
     */
    creationTime;
    /**
     * 创建人编号
     */
    creatorId;
    /**
     * 最后修改时间
     */
    lastModificationTime;
    /**
     * 最后修改人编号
     */
    lastModifierId;
    /**
     * 版本号
     */
    version;
}