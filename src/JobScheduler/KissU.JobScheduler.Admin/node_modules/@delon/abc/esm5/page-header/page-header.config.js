/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import * as i0 from "@angular/core";
var PageHeaderConfig = /** @class */ (function () {
    function PageHeaderConfig() {
        /**
         * 首页文本，若指定空表示不显示
         */
        this.home = '首页';
        /**
         * 首页链接
         */
        this.homeLink = '/';
        /**
         * 自动生成导航，以当前路由从主菜单中定位
         */
        this.autoBreadcrumb = true;
        /**
         * 自动向上递归查找
         *  - 菜单数据源包含 `/ware`，则 `/ware/1` 也视为 `/ware` 项
         */
        this.recursiveBreadcrumb = false;
        /**
         * 自动生成标题，以当前路由从主菜单中定位
         */
        this.autoTitle = true;
        /**
         * 是否自动将标准信息同步至 `TitleService`、`ReuseService` 下
         */
        this.syncTitle = false;
        /**
         * 是否固定模式
         */
        this.fixed = false;
        /**
         * 固定偏移值
         */
        this.fixedOffsetTop = 64;
    }
    PageHeaderConfig.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */ PageHeaderConfig.ngInjectableDef = i0.defineInjectable({ factory: function PageHeaderConfig_Factory() { return new PageHeaderConfig(); }, token: PageHeaderConfig, providedIn: "root" });
    return PageHeaderConfig;
}());
export { PageHeaderConfig };
if (false) {
    /**
     * 首页文本，若指定空表示不显示
     * @type {?}
     */
    PageHeaderConfig.prototype.home;
    /**
     * 首页链接
     * @type {?}
     */
    PageHeaderConfig.prototype.homeLink;
    /**
     * 首页链接国际化参数
     * @type {?}
     */
    PageHeaderConfig.prototype.homeI18n;
    /**
     * 自动生成导航，以当前路由从主菜单中定位
     * @type {?}
     */
    PageHeaderConfig.prototype.autoBreadcrumb;
    /**
     * 自动向上递归查找
     *  - 菜单数据源包含 `/ware`，则 `/ware/1` 也视为 `/ware` 项
     * @type {?}
     */
    PageHeaderConfig.prototype.recursiveBreadcrumb;
    /**
     * 自动生成标题，以当前路由从主菜单中定位
     * @type {?}
     */
    PageHeaderConfig.prototype.autoTitle;
    /**
     * 是否自动将标准信息同步至 `TitleService`、`ReuseService` 下
     * @type {?}
     */
    PageHeaderConfig.prototype.syncTitle;
    /**
     * 是否固定模式
     * @type {?}
     */
    PageHeaderConfig.prototype.fixed;
    /**
     * 固定偏移值
     * @type {?}
     */
    PageHeaderConfig.prototype.fixedOffsetTop;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicGFnZS1oZWFkZXIuY29uZmlnLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy9wYWdlLWhlYWRlci8iLCJzb3VyY2VzIjpbInBhZ2UtaGVhZGVyLmNvbmZpZy50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLGVBQWUsQ0FBQzs7QUFFM0M7SUFBQTs7OztRQUtFLFNBQUksR0FBWSxJQUFJLENBQUM7Ozs7UUFJckIsYUFBUSxHQUFZLEdBQUcsQ0FBQzs7OztRQVF4QixtQkFBYyxHQUFhLElBQUksQ0FBQzs7Ozs7UUFLaEMsd0JBQW1CLEdBQWEsS0FBSyxDQUFDOzs7O1FBSXRDLGNBQVMsR0FBYSxJQUFJLENBQUM7Ozs7UUFJM0IsY0FBUyxHQUFhLEtBQUssQ0FBQzs7OztRQUk1QixVQUFLLEdBQWEsS0FBSyxDQUFDOzs7O1FBSXhCLG1CQUFjLEdBQVksRUFBRSxDQUFDO0tBQzlCOztnQkF2Q0EsVUFBVSxTQUFDLEVBQUUsVUFBVSxFQUFFLE1BQU0sRUFBRTs7OzJCQUZsQztDQXlDQyxBQXZDRCxJQXVDQztTQXRDWSxnQkFBZ0I7Ozs7OztJQUkzQixnQ0FBcUI7Ozs7O0lBSXJCLG9DQUF3Qjs7Ozs7SUFJeEIsb0NBQWtCOzs7OztJQUlsQiwwQ0FBZ0M7Ozs7OztJQUtoQywrQ0FBc0M7Ozs7O0lBSXRDLHFDQUEyQjs7Ozs7SUFJM0IscUNBQTRCOzs7OztJQUk1QixpQ0FBd0I7Ozs7O0lBSXhCLDBDQUE2QiIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IEluamVjdGFibGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuQEluamVjdGFibGUoeyBwcm92aWRlZEluOiAncm9vdCcgfSlcbmV4cG9ydCBjbGFzcyBQYWdlSGVhZGVyQ29uZmlnIHtcbiAgLyoqXG4gICAqIOmmlumhteaWh+acrO+8jOiLpeaMh+WumuepuuihqOekuuS4jeaYvuekulxuICAgKi9cbiAgaG9tZT86IHN0cmluZyA9ICfpppbpobUnO1xuICAvKipcbiAgICog6aaW6aG16ZO+5o6lXG4gICAqL1xuICBob21lTGluaz86IHN0cmluZyA9ICcvJztcbiAgLyoqXG4gICAqIOmmlumhtemTvuaOpeWbvemZheWMluWPguaVsFxuICAgKi9cbiAgaG9tZUkxOG4/OiBzdHJpbmc7XG4gIC8qKlxuICAgKiDoh6rliqjnlJ/miJDlr7zoiKrvvIzku6XlvZPliY3ot6/nlLHku47kuLvoj5zljZXkuK3lrprkvY1cbiAgICovXG4gIGF1dG9CcmVhZGNydW1iPzogYm9vbGVhbiA9IHRydWU7XG4gIC8qKlxuICAgKiDoh6rliqjlkJHkuIrpgJLlvZLmn6Xmib5cbiAgICogIC0g6I+c5Y2V5pWw5o2u5rqQ5YyF5ZCrIGAvd2FyZWDvvIzliJkgYC93YXJlLzFgIOS5n+inhuS4uiBgL3dhcmVgIOmhuVxuICAgKi9cbiAgcmVjdXJzaXZlQnJlYWRjcnVtYj86IGJvb2xlYW4gPSBmYWxzZTtcbiAgLyoqXG4gICAqIOiHquWKqOeUn+aIkOagh+mimO+8jOS7peW9k+WJjei3r+eUseS7juS4u+iPnOWNleS4reWumuS9jVxuICAgKi9cbiAgYXV0b1RpdGxlPzogYm9vbGVhbiA9IHRydWU7XG4gIC8qKlxuICAgKiDmmK/lkKboh6rliqjlsIbmoIflh4bkv6Hmga/lkIzmraXoh7MgYFRpdGxlU2VydmljZWDjgIFgUmV1c2VTZXJ2aWNlYCDkuItcbiAgICovXG4gIHN5bmNUaXRsZT86IGJvb2xlYW4gPSBmYWxzZTtcbiAgLyoqXG4gICAqIOaYr+WQpuWbuuWumuaooeW8j1xuICAgKi9cbiAgZml4ZWQ/OiBib29sZWFuID0gZmFsc2U7XG4gIC8qKlxuICAgKiDlm7rlrprlgY/np7vlgLxcbiAgICovXG4gIGZpeGVkT2Zmc2V0VG9wPzogbnVtYmVyID0gNjQ7XG59XG4iXX0=