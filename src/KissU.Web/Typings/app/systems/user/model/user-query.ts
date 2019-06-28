import { QueryParameter } from '../../../../util';

/**
 * 用户查询参数
 */
export class UserQuery extends QueryParameter {
    /**
     * 
     */
    userId;
    /**
     * 用户名
     */
    userName;
    /**
     * 真实姓名
     */
    realName;
    /**
     * 昵称
     */
    nickName;
    /**
     * 邮箱
     */
    email;
    /**
     * 邮箱是否验证
     */
    emailConfirmed;
    /**
     * 手机号码
     */
    phoneNumber;
    /**
     * 手机号码是否验证
     */
    phoneNumberConfirmed;
    /**
     * 密码
     */
    password;
    /**
     * 密码哈希值
     */
    passwordHash;
    /**
     * 起始
     */
    beginCreationTime;
    /**
     * 结束
     */
    endCreationTime;
    /**
     * 
     */
    creatorId;
    /**
     * 起始
     */
    beginLastModificationTime;
    /**
     * 结束
     */
    endLastModificationTime;
    /**
     * 
     */
    lastModifierId;
}