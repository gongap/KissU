import { InjectionToken } from '@angular/core';
import { Observable } from 'rxjs';
export declare const DA_SERVICE_TOKEN: InjectionToken<ITokenService>;
export interface ITokenModel {
    [key: string]: any;
    token: string;
}
export interface AuthReferrer {
    url?: string;
}
export interface ITokenService {
    set(data: ITokenModel): boolean;
    /**
     * 获取Token，形式包括：
     * - `get()` 获取 Simple Token
     * - `get<JWTTokenModel>(JWTTokenModel)` 获取 JWT Token
     */
    get(type?: any): ITokenModel;
    /**
     * 获取Token，形式包括：
     * - `get()` 获取 Simple Token
     * - `get<JWTTokenModel>(JWTTokenModel)` 获取 JWT Token
     */
    get<T extends ITokenModel>(type?: any): T;
    clear(): void;
    change(): Observable<ITokenModel>;
    /** 获取登录地址 */
    readonly login_url: string;
    /** 获取授权失败前路由信息 */
    readonly referrer?: AuthReferrer;
}
