import { ViewModel } from '../../../../util';

/**
 * 创建用户参数
 */
export class CreateUserViewModel extends ViewModel {
    /**
     * 用户名
     */
    userName;
    /**
     * 安全邮箱
     */
    email;
    /**
     * 安全手机
     */
    phoneNumber;
    /**
     * 密码
     */
    password;
}