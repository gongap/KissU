import { NgModule, Injector } from '@angular/core';

//Angular模块
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from "@angular/common/http";

//Ant Design模块
import { AlainThemeModule } from '@delon/theme';

//语言设置
import { default as ngLang } from '@angular/common/locales/zh';
import { registerLocaleData } from '@angular/common';
registerLocaleData(ngLang, "zh_CN");

//图标设置
import { NZ_ICONS } from 'ng-zorro-antd';
import { IconDefinition } from '@ant-design/icons-angular';
import * as AllIcons from '@ant-design/icons-angular/icons';
const icons: IconDefinition[] = Object.keys(AllIcons).map(key => AllIcons[key]);

//框架模块
import { FrameworkModule } from './framework.module';
import { util, UploadService, createOidcProviders,OidcAuthorizeConfig } from '../util';

//通用服务
import { LocalUploadService } from "../common/services/local-upload.service";

//路由模块
import { AppRoutingModule } from './app-routing.module';

//主界面模块
import { HomeModule } from "./home/home.module";

//根组件
import { AppComponent } from './app.component';

//登录回调
import { LoginCallbackComponent } from "./login-callback.component";

//启动服务
import { StartupService } from "./home/startup/startup.service";

/**
 * 应用根模块
 */
@NgModule( {
    declarations: [AppComponent, LoginCallbackComponent],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        AlainThemeModule.forRoot(),
        FrameworkModule,
        HomeModule,
        AppRoutingModule
    ],
    providers: [
        { provide: OidcAuthorizeConfig, useFactory: getAuthorizeConfig },
        ...createOidcProviders(),
        { provide: NZ_ICONS, useValue: icons },
        StartupService,
        { provide: UploadService, useClass: LocalUploadService }
    ],
    bootstrap: [AppComponent],
} )
export class AppModule {
    /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        util.ioc.injector = injector;
    }
}

/**
 * 获取授权配置
 */
export function getAuthorizeConfig() {
    let result = new OidcAuthorizeConfig();
    result.authority = "http://localhost:10080",
    result.clientId = "GreatWall-Admin";
    result.scope = "openid profile api";
    return result;
}