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
     * 创建时间
     */
    creationTime;
    /**
     * 版本号
     */
    version;
}