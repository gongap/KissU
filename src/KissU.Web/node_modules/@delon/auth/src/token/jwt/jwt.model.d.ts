import { ITokenModel } from '../interface';
export declare class JWTTokenModel implements ITokenModel {
    [key: string]: any;
    token: string;
    /**
     * 获取载荷信息
     */
    readonly payload: any;
    /**
     * 检查Token是否过期，`payload` 必须包含 `exp` 时有效
     *
     * @param offsetSeconds 偏移量
     */
    isExpired(offsetSeconds?: number): boolean;
}
