import { ViewModel } from '../../../../util';

/**
 * 用户视图模型
 */
export class UserViewModel extends ViewModel {
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
     * 
     */
    creationTime;
    /**
     * 
     */
    creatorId;
    /**
     * 
     */
    lastModificationTime;
    /**
     * 
     */
    lastModifierId;
    /**
     * 
     */
    version;
}