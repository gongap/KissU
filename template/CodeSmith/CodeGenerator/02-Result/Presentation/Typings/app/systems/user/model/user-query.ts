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
     * 用户名
     */
    userName;
    /**
     * 标准化用户名
     */
    normalizedUserName;
    /**
     * 安全邮箱
     */
    email;
    /**
     * 标准化邮箱
     */
    normalizedEmail;
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
     * 密码
     */
    password;
    /**
     * 密码散列
     */
    passwordHash;
    /**
     * 安全码
     */
    safePassword;
    /**
     * 安全码散列
     */
    safePasswordHash;
    /**
     * 启用两阶段认证
     */
    twoFactorEnabled;
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
     * 启用锁定
     */
    lockoutEnabled;
    /**
     * 锁定截止
     */
    lockoutEnd;
    /**
     * 登录失败次数
     */
    accessFailedCount;
    /**
     * 登录次数
     */
    loginCount;
    /**
     * 注册Ip
     */
    registerIp;
    /**
     * 起始上次登陆时间
     */
    beginLastLoginTime;
    /**
     * 结束上次登陆时间
     */
    endLastLoginTime;
    /**
     * 上次登陆Ip
     */
    lastLoginIp;
    /**
     * 起始本次登陆时间
     */
    beginCurrentLoginTime;
    /**
     * 结束本次登陆时间
     */
    endCurrentLoginTime;
    /**
     * 本次登陆Ip
     */
    currentLoginIp;
    /**
     * 安全戳
     */
    securityStamp;
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
    /**
     * 创建人
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
     * 最后修改人
     */
    lastModifierId;
}