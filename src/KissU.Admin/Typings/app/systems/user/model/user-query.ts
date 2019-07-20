import { QueryParameter } from '../../../../util';

/**
 * 用户查询参数
 */
export class UserQuery extends QueryParameter {
    /**
     * 用户标识
     */
    userId;
    /**
    * 角色编号
    */
    roleId;
    /**
     * 排除的角色标识
     */
    exceptRoleId;
    /**
     * 用户名
     */
    userName;
    /**
     * 安全邮箱
     */
    email;
    /**
     * 邮箱已确认
     */
    emailConfirmed;
    /**
     * 安全手机
     */
    phoneNumber;
    /**
     * 手机已确认
     */
    phoneNumberConfirmed;
    /**
     * 启用
     */
    enabled;
    /**
     * 起始冻结时间
     */
    beginDisabledTime;
    /**
     * 结束冻结时间
     */
    endDisabledTime;
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