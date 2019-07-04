/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import * as i0 from "@angular/core";
var DelonAuthConfig = /** @class */ (function () {
    function DelonAuthConfig() {
        /**
         * 存储KEY值
         */
        this.store_key = '_token';
        /**
         * 无效时跳转至登录页，包括：
         * - 无效token值
         * - token已过期（限JWT）
         */
        this.token_invalid_redirect = true;
        /**
         * token过期时间偏移值，默认：`10` 秒（单位：秒）
         */
        this.token_exp_offset = 10;
        /**
         * 发送token参数名，默认：token
         */
        this.token_send_key = 'token';
        /**
         * 发送token模板（默认为：`${token}`），使用 `${token}` 表示token点位符，例如：
         *
         * - `Bearer ${token}`
         */
        // tslint:disable-next-line:no-invalid-template-strings
        this.token_send_template = '${token}';
        /**
         * 发送token参数位置，默认：header
         */
        this.token_send_place = 'header';
        /**
         * 登录页路由地址
         */
        this.login_url = "/login";
        /**
         * 忽略TOKEN的URL地址列表，默认值为：[ /\/login/, /assets\//, /passport\// ]
         */
        this.ignores = [/\/login/, /assets\//, /passport\//];
        /**
         * 允许匿名登录KEY，若请求参数中带有该KEY表示忽略TOKEN
         */
        this.allow_anonymous_key = "_allow_anonymous";
        /**
         * 是否校验失效时命中后继续调用后续拦截器的 `intercept` 方法，默认：`true`
         */
        this.executeOtherInterceptors = true;
    }
    DelonAuthConfig.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */ DelonAuthConfig.ngInjectableDef = i0.defineInjectable({ factory: function DelonAuthConfig_Factory() { return new DelonAuthConfig(); }, token: DelonAuthConfig, providedIn: "root" });
    return DelonAuthConfig;
}());
export { DelonAuthConfig };
if (false) {
    /**
     * 存储KEY值
     * @type {?}
     */
    DelonAuthConfig.prototype.store_key;
    /**
     * 无效时跳转至登录页，包括：
     * - 无效token值
     * - token已过期（限JWT）
     * @type {?}
     */
    DelonAuthConfig.prototype.token_invalid_redirect;
    /**
     * token过期时间偏移值，默认：`10` 秒（单位：秒）
     * @type {?}
     */
    DelonAuthConfig.prototype.token_exp_offset;
    /**
     * 发送token参数名，默认：token
     * @type {?}
     */
    DelonAuthConfig.prototype.token_send_key;
    /**
     * 发送token模板（默认为：`${token}`），使用 `${token}` 表示token点位符，例如：
     *
     * - `Bearer ${token}`
     * @type {?}
     */
    DelonAuthConfig.prototype.token_send_template;
    /**
     * 发送token参数位置，默认：header
     * @type {?}
     */
    DelonAuthConfig.prototype.token_send_place;
    /**
     * 登录页路由地址
     * @type {?}
     */
    DelonAuthConfig.prototype.login_url;
    /**
     * 忽略TOKEN的URL地址列表，默认值为：[ /\/login/, /assets\//, /passport\// ]
     * @type {?}
     */
    DelonAuthConfig.prototype.ignores;
    /**
     * 允许匿名登录KEY，若请求参数中带有该KEY表示忽略TOKEN
     * @type {?}
     */
    DelonAuthConfig.prototype.allow_anonymous_key;
    /**
     * 是否校验失效时命中后继续调用后续拦截器的 `intercept` 方法，默认：`true`
     * @type {?}
     */
    DelonAuthConfig.prototype.executeOtherInterceptors;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiYXV0aC5jb25maWcuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYXV0aC8iLCJzb3VyY2VzIjpbInNyYy9hdXRoLmNvbmZpZy50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLGVBQWUsQ0FBQzs7QUFFM0M7SUFBQTs7OztRQUtFLGNBQVMsR0FBWSxRQUFRLENBQUM7Ozs7OztRQU05QiwyQkFBc0IsR0FBYSxJQUFJLENBQUM7Ozs7UUFJeEMscUJBQWdCLEdBQVksRUFBRSxDQUFDOzs7O1FBSS9CLG1CQUFjLEdBQVksT0FBTyxDQUFDOzs7Ozs7O1FBT2xDLHdCQUFtQixHQUFZLFVBQVUsQ0FBQzs7OztRQUkxQyxxQkFBZ0IsR0FBK0IsUUFBUSxDQUFDOzs7O1FBSXhELGNBQVMsR0FBWSxRQUFRLENBQUM7Ozs7UUFJOUIsWUFBTyxHQUFjLENBQUMsU0FBUyxFQUFFLFVBQVUsRUFBRSxZQUFZLENBQUMsQ0FBQzs7OztRQUkzRCx3QkFBbUIsR0FBWSxrQkFBa0IsQ0FBQzs7OztRQUlsRCw2QkFBd0IsR0FBYSxJQUFJLENBQUM7S0FDM0M7O2dCQS9DQSxVQUFVLFNBQUMsRUFBRSxVQUFVLEVBQUUsTUFBTSxFQUFFOzs7MEJBRmxDO0NBaURDLEFBL0NELElBK0NDO1NBOUNZLGVBQWU7Ozs7OztJQUkxQixvQ0FBOEI7Ozs7Ozs7SUFNOUIsaURBQXdDOzs7OztJQUl4QywyQ0FBK0I7Ozs7O0lBSS9CLHlDQUFrQzs7Ozs7OztJQU9sQyw4Q0FBMEM7Ozs7O0lBSTFDLDJDQUF3RDs7Ozs7SUFJeEQsb0NBQThCOzs7OztJQUk5QixrQ0FBMkQ7Ozs7O0lBSTNELDhDQUFrRDs7Ozs7SUFJbEQsbURBQTBDIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgSW5qZWN0YWJsZSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuXG5ASW5qZWN0YWJsZSh7IHByb3ZpZGVkSW46ICdyb290JyB9KVxuZXhwb3J0IGNsYXNzIERlbG9uQXV0aENvbmZpZyB7XG4gIC8qKlxuICAgKiDlrZjlgqhLRVnlgLxcbiAgICovXG4gIHN0b3JlX2tleT86IHN0cmluZyA9ICdfdG9rZW4nO1xuICAvKipcbiAgICog5peg5pWI5pe26Lez6L2s6Iez55m75b2V6aG177yM5YyF5ous77yaXG4gICAqIC0g5peg5pWIdG9rZW7lgLxcbiAgICogLSB0b2tlbuW3sui/h+acn++8iOmZkEpXVO+8iVxuICAgKi9cbiAgdG9rZW5faW52YWxpZF9yZWRpcmVjdD86IGJvb2xlYW4gPSB0cnVlO1xuICAvKipcbiAgICogdG9rZW7ov4fmnJ/ml7bpl7TlgY/np7vlgLzvvIzpu5jorqTvvJpgMTBgIOenku+8iOWNleS9je+8muenku+8iVxuICAgKi9cbiAgdG9rZW5fZXhwX29mZnNldD86IG51bWJlciA9IDEwO1xuICAvKipcbiAgICog5Y+R6YCBdG9rZW7lj4LmlbDlkI3vvIzpu5jorqTvvJp0b2tlblxuICAgKi9cbiAgdG9rZW5fc2VuZF9rZXk/OiBzdHJpbmcgPSAndG9rZW4nO1xuICAvKipcbiAgICog5Y+R6YCBdG9rZW7mqKHmnb/vvIjpu5jorqTkuLrvvJpgJHt0b2tlbn1g77yJ77yM5L2/55SoIGAke3Rva2VufWAg6KGo56S6dG9rZW7ngrnkvY3nrKbvvIzkvovlpoLvvJpcbiAgICpcbiAgICogLSBgQmVhcmVyICR7dG9rZW59YFxuICAgKi9cbiAgLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOm5vLWludmFsaWQtdGVtcGxhdGUtc3RyaW5nc1xuICB0b2tlbl9zZW5kX3RlbXBsYXRlPzogc3RyaW5nID0gJyR7dG9rZW59JztcbiAgLyoqXG4gICAqIOWPkemAgXRva2Vu5Y+C5pWw5L2N572u77yM6buY6K6k77yaaGVhZGVyXG4gICAqL1xuICB0b2tlbl9zZW5kX3BsYWNlPzogJ2hlYWRlcicgfCAnYm9keScgfCAndXJsJyA9ICdoZWFkZXInO1xuICAvKipcbiAgICog55m75b2V6aG16Lev55Sx5Zyw5Z2AXG4gICAqL1xuICBsb2dpbl91cmw/OiBzdHJpbmcgPSBgL2xvZ2luYDtcbiAgLyoqXG4gICAqIOW/veeVpVRPS0VO55qEVVJM5Zyw5Z2A5YiX6KGo77yM6buY6K6k5YC85Li677yaWyAvXFwvbG9naW4vLCAvYXNzZXRzXFwvLywgL3Bhc3Nwb3J0XFwvLyBdXG4gICAqL1xuICBpZ25vcmVzPzogUmVnRXhwW10gPSBbL1xcL2xvZ2luLywgL2Fzc2V0c1xcLy8sIC9wYXNzcG9ydFxcLy9dO1xuICAvKipcbiAgICog5YWB6K645Yy/5ZCN55m75b2VS0VZ77yM6Iul6K+35rGC5Y+C5pWw5Lit5bim5pyJ6K+lS0VZ6KGo56S65b+955WlVE9LRU5cbiAgICovXG4gIGFsbG93X2Fub255bW91c19rZXk/OiBzdHJpbmcgPSBgX2FsbG93X2Fub255bW91c2A7XG4gIC8qKlxuICAgKiDmmK/lkKbmoKHpqozlpLHmlYjml7blkb3kuK3lkI7nu6fnu63osIPnlKjlkI7nu63mi6bmiKrlmajnmoQgYGludGVyY2VwdGAg5pa55rOV77yM6buY6K6k77yaYHRydWVgXG4gICAqL1xuICBleGVjdXRlT3RoZXJJbnRlcmNlcHRvcnM/OiBib29sZWFuID0gdHJ1ZTtcbn1cbiJdfQ==