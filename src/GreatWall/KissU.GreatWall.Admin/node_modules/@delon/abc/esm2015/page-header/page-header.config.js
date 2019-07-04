/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import * as i0 from "@angular/core";
export class PageHeaderConfig {
    constructor() {
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
}
PageHeaderConfig.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */ PageHeaderConfig.ngInjectableDef = i0.defineInjectable({ factory: function PageHeaderConfig_Factory() { return new PageHeaderConfig(); }, token: PageHeaderConfig, providedIn: "root" });
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
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicGFnZS1oZWFkZXIuY29uZmlnLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy9wYWdlLWhlYWRlci8iLCJzb3VyY2VzIjpbInBhZ2UtaGVhZGVyLmNvbmZpZy50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLGVBQWUsQ0FBQzs7QUFHM0MsTUFBTSxPQUFPLGdCQUFnQjtJQUQ3Qjs7OztRQUtFLFNBQUksR0FBWSxJQUFJLENBQUM7Ozs7UUFJckIsYUFBUSxHQUFZLEdBQUcsQ0FBQzs7OztRQVF4QixtQkFBYyxHQUFhLElBQUksQ0FBQzs7Ozs7UUFLaEMsd0JBQW1CLEdBQWEsS0FBSyxDQUFDOzs7O1FBSXRDLGNBQVMsR0FBYSxJQUFJLENBQUM7Ozs7UUFJM0IsY0FBUyxHQUFhLEtBQUssQ0FBQzs7OztRQUk1QixVQUFLLEdBQWEsS0FBSyxDQUFDOzs7O1FBSXhCLG1CQUFjLEdBQVksRUFBRSxDQUFDO0tBQzlCOzs7WUF2Q0EsVUFBVSxTQUFDLEVBQUUsVUFBVSxFQUFFLE1BQU0sRUFBRTs7Ozs7Ozs7SUFLaEMsZ0NBQXFCOzs7OztJQUlyQixvQ0FBd0I7Ozs7O0lBSXhCLG9DQUFrQjs7Ozs7SUFJbEIsMENBQWdDOzs7Ozs7SUFLaEMsK0NBQXNDOzs7OztJQUl0QyxxQ0FBMkI7Ozs7O0lBSTNCLHFDQUE0Qjs7Ozs7SUFJNUIsaUNBQXdCOzs7OztJQUl4QiwwQ0FBNkIiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBJbmplY3RhYmxlIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbkBJbmplY3RhYmxlKHsgcHJvdmlkZWRJbjogJ3Jvb3QnIH0pXG5leHBvcnQgY2xhc3MgUGFnZUhlYWRlckNvbmZpZyB7XG4gIC8qKlxuICAgKiDpppbpobXmlofmnKzvvIzoi6XmjIflrprnqbrooajnpLrkuI3mmL7npLpcbiAgICovXG4gIGhvbWU/OiBzdHJpbmcgPSAn6aaW6aG1JztcbiAgLyoqXG4gICAqIOmmlumhtemTvuaOpVxuICAgKi9cbiAgaG9tZUxpbms/OiBzdHJpbmcgPSAnLyc7XG4gIC8qKlxuICAgKiDpppbpobXpk77mjqXlm73pmYXljJblj4LmlbBcbiAgICovXG4gIGhvbWVJMThuPzogc3RyaW5nO1xuICAvKipcbiAgICog6Ieq5Yqo55Sf5oiQ5a+86Iiq77yM5Lul5b2T5YmN6Lev55Sx5LuO5Li76I+c5Y2V5Lit5a6a5L2NXG4gICAqL1xuICBhdXRvQnJlYWRjcnVtYj86IGJvb2xlYW4gPSB0cnVlO1xuICAvKipcbiAgICog6Ieq5Yqo5ZCR5LiK6YCS5b2S5p+l5om+XG4gICAqICAtIOiPnOWNleaVsOaNrua6kOWMheWQqyBgL3dhcmVg77yM5YiZIGAvd2FyZS8xYCDkuZ/op4bkuLogYC93YXJlYCDpoblcbiAgICovXG4gIHJlY3Vyc2l2ZUJyZWFkY3J1bWI/OiBib29sZWFuID0gZmFsc2U7XG4gIC8qKlxuICAgKiDoh6rliqjnlJ/miJDmoIfpopjvvIzku6XlvZPliY3ot6/nlLHku47kuLvoj5zljZXkuK3lrprkvY1cbiAgICovXG4gIGF1dG9UaXRsZT86IGJvb2xlYW4gPSB0cnVlO1xuICAvKipcbiAgICog5piv5ZCm6Ieq5Yqo5bCG5qCH5YeG5L+h5oGv5ZCM5q2l6IezIGBUaXRsZVNlcnZpY2Vg44CBYFJldXNlU2VydmljZWAg5LiLXG4gICAqL1xuICBzeW5jVGl0bGU/OiBib29sZWFuID0gZmFsc2U7XG4gIC8qKlxuICAgKiDmmK/lkKblm7rlrprmqKHlvI9cbiAgICovXG4gIGZpeGVkPzogYm9vbGVhbiA9IGZhbHNlO1xuICAvKipcbiAgICog5Zu65a6a5YGP56e75YC8XG4gICAqL1xuICBmaXhlZE9mZnNldFRvcD86IG51bWJlciA9IDY0O1xufVxuIl19