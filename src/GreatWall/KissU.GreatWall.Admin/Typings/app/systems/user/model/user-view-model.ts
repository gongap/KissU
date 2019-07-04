﻿import { ViewModel } from '../../../../util';

/**
 * 用户参数
 */
export class UserViewModel extends ViewModel {
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
     * 启用两阶段认证
     */
    twoFactorEnabled;
    /**
     * 启用
     */
    enabled;
    /**
     * 冻结时间
     */
    disabledTime;
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
     * 上次登陆时间
     */
    lastLoginTime;
    /**
     * 上次登陆Ip
     */
    lastLoginIp;
    /**
     * 本次登陆时间
     */
    currentLoginTime;
    /**
     * 本次登陆Ip
     */
    currentLoginIp;
    /**
     * 备注
     */
    remark;
    /**
     * 创建时间
     */
    creationTime;
    /**
     * 创建人
     */
    creatorId;
    /**
     * 版本号
     */
    version;
}