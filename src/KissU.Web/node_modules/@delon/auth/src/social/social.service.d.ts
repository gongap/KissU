import { OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ITokenModel, ITokenService } from '../token/interface';
export declare type SocialOpenType = 'href' | 'window';
export declare class SocialService implements OnDestroy {
    private tokenService;
    private doc;
    private router;
    private _win;
    private _winTime;
    private observer;
    constructor(tokenService: ITokenService, doc: any, router: Router);
    /**
     * 使用窗体打开授权页，返回值是 `Observable<ITokenModel>` 用于订阅授权后返回的结果
     * @param url 获取授权地址
     * @param callback 回调路由地址
     * @param options.windowFeatures 等同 `window.open` 的 `features` 参数值
     */
    login(url: string, callback?: string, options?: {
        type?: 'window';
        windowFeatures?: string;
    }): Observable<ITokenModel>;
    /**
     * 跳转至授权页
     * @param url 获取授权地址
     * @param callback 回调路由地址
     */
    login(url: string, callback?: string, options?: {
        type?: 'href';
    }): void;
    /**
     * 授权成功后的回调处理
     *
     * @param rawData 指定回调认证信息，为空时从根据当前URL解析
     */
    callback(rawData?: string | ITokenModel): ITokenModel;
    ngOnDestroy(): void;
}
