import { Component, Injector, OnInit } from "@angular/core";
import { ComponentBase, OidcAuthorizeService } from "../util";

/**
 * 登录回调处理
 */
@Component({
    template: ``
})
export class LoginCallbackComponent extends ComponentBase implements OnInit {
    /**
     * 初始化
     * @param injector 注入器
     * @param authService 授权服务
     * @param startupService 启动服务
     */
    constructor( injector: Injector, private authService: OidcAuthorizeService) {
        super(injector);
    }

    /**
     * 初始化
     */
    async ngOnInit() {
        await this.authService.loginCallback();
    }
}