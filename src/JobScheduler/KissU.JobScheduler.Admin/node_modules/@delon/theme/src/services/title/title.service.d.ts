import { Injector, OnDestroy } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { AlainI18NService } from '../i18n/i18n';
import { MenuService } from '../menu/menu.service';
export declare class TitleService implements OnDestroy {
    private injector;
    private title;
    private menuSrv;
    private i18nSrv;
    private doc;
    private _prefix;
    private _suffix;
    private _separator;
    private _reverse;
    private i18n$;
    constructor(injector: Injector, title: Title, menuSrv: MenuService, i18nSrv: AlainI18NService, doc: any);
    /** 设置分隔符 */
    separator: string;
    /** 设置前缀 */
    prefix: string;
    /** 设置后缀 */
    suffix: string;
    /** 设置是否反转 */
    reverse: boolean;
    /** 设置默认标题名 */
    default: string;
    private getByElement;
    private getByRoute;
    private getByMenu;
    /**
     * 设置标题
     */
    setTitle(title?: string | string[]): void;
    /**
     * 设置国际化标题
     */
    setTitleByI18n(key: string, params?: {}): void;
    ngOnDestroy(): void;
}
