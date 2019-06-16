/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import * as i0 from "@angular/core";
var LodopConfig = /** @class */ (function () {
    function LodopConfig() {
    }
    LodopConfig.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */ LodopConfig.ngInjectableDef = i0.defineInjectable({ factory: function LodopConfig_Factory() { return new LodopConfig(); }, token: LodopConfig, providedIn: "root" });
    return LodopConfig;
}());
export { LodopConfig };
if (false) {
    /**
     * 注册信息：主注册号
     * @type {?}
     */
    LodopConfig.prototype.license;
    /**
     * 注册信息：附加注册号A
     * @type {?}
     */
    LodopConfig.prototype.licenseA;
    /**
     * 注册信息：附加注册号B
     * @type {?}
     */
    LodopConfig.prototype.licenseB;
    /**
     * 注册信息：注册单位名称
     * @type {?}
     */
    LodopConfig.prototype.companyName;
    /**
     * Lodop 远程脚本URL地址，**注意**务必使用 `name` 属性指定变量值
     *
     * - http://localhost:18000/CLodopfuncs.js
     * - https://localhost:8443/CLodopfuncs.js [默认]
     * @type {?}
     */
    LodopConfig.prototype.url;
    /**
     * Lodop 变量名，默认：`CLODOP`
     * @type {?}
     */
    LodopConfig.prototype.name;
    /**
     * 检查次数，默认 `100`，当检查超过时视为异常，这是因为 Lodop 需要连接 WebSocket
     * @type {?}
     */
    LodopConfig.prototype.checkMaxCount;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibG9kb3AuY29uZmlnLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy9sb2RvcC8iLCJzb3VyY2VzIjpbImxvZG9wLmNvbmZpZy50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLGVBQWUsQ0FBQzs7QUFFM0M7SUFBQTtLQWlDQzs7Z0JBakNBLFVBQVUsU0FBQyxFQUFFLFVBQVUsRUFBRSxNQUFNLEVBQUU7OztzQkFGbEM7Q0FtQ0MsQUFqQ0QsSUFpQ0M7U0FoQ1ksV0FBVzs7Ozs7O0lBSXRCLDhCQUFnQjs7Ozs7SUFJaEIsK0JBQWlCOzs7OztJQUlqQiwrQkFBa0I7Ozs7O0lBSWxCLGtDQUFxQjs7Ozs7Ozs7SUFPckIsMEJBQWE7Ozs7O0lBSWIsMkJBQWM7Ozs7O0lBSWQsb0NBQXVCIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgSW5qZWN0YWJsZSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuXG5ASW5qZWN0YWJsZSh7IHByb3ZpZGVkSW46ICdyb290JyB9KVxuZXhwb3J0IGNsYXNzIExvZG9wQ29uZmlnIHtcbiAgLyoqXG4gICAqIOazqOWGjOS/oeaBr++8muS4u+azqOWGjOWPt1xuICAgKi9cbiAgbGljZW5zZTogc3RyaW5nO1xuICAvKipcbiAgICog5rOo5YaM5L+h5oGv77ya6ZmE5Yqg5rOo5YaM5Y+3QVxuICAgKi9cbiAgbGljZW5zZUE6IHN0cmluZztcbiAgLyoqXG4gICAqIOazqOWGjOS/oeaBr++8mumZhOWKoOazqOWGjOWPt0JcbiAgICovXG4gIGxpY2Vuc2VCPzogc3RyaW5nO1xuICAvKipcbiAgICog5rOo5YaM5L+h5oGv77ya5rOo5YaM5Y2V5L2N5ZCN56ewXG4gICAqL1xuICBjb21wYW55TmFtZT86IHN0cmluZztcbiAgLyoqXG4gICAqIExvZG9wIOi/nOeoi+iEmuacrFVSTOWcsOWdgO+8jCoq5rOo5oSPKirliqHlv4Xkvb/nlKggYG5hbWVgIOWxnuaAp+aMh+WumuWPmOmHj+WAvFxuICAgKlxuICAgKiAtIGh0dHA6Ly9sb2NhbGhvc3Q6MTgwMDAvQ0xvZG9wZnVuY3MuanNcbiAgICogLSBodHRwczovL2xvY2FsaG9zdDo4NDQzL0NMb2RvcGZ1bmNzLmpzIFvpu5jorqRdXG4gICAqL1xuICB1cmw/OiBzdHJpbmc7XG4gIC8qKlxuICAgKiBMb2RvcCDlj5jph4/lkI3vvIzpu5jorqTvvJpgQ0xPRE9QYFxuICAgKi9cbiAgbmFtZT86IHN0cmluZztcbiAgLyoqXG4gICAqIOajgOafpeasoeaVsO+8jOm7mOiupCBgMTAwYO+8jOW9k+ajgOafpei2hei/h+aXtuinhuS4uuW8guW4uO+8jOi/meaYr+WboOS4uiBMb2RvcCDpnIDopoHov57mjqUgV2ViU29ja2V0XG4gICAqL1xuICBjaGVja01heENvdW50PzogbnVtYmVyO1xufVxuIl19