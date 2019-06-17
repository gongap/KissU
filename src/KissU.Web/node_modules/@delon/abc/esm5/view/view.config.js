/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import * as i0 from "@angular/core";
var SVConfig = /** @class */ (function () {
    function SVConfig() {
        /**
         * 间距，默认：`32`
         */
        this.gutter = 32;
        /**
         * 布局，默认：`horizontal`
         */
        this.layout = 'horizontal';
        /**
         * 列数，默认：`3`
         */
        this.col = 3;
        /**
         * 是否显示默认值，当内容为空值时显示 `-`，默认：`true`
         */
        this.default = true;
        /**
         * `label` 固定宽度，若 `null` 或 `undefined` 表示非固定，默认：`null`
         */
        this.labelWidth = null;
    }
    SVConfig.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */ SVConfig.ngInjectableDef = i0.defineInjectable({ factory: function SVConfig_Factory() { return new SVConfig(); }, token: SVConfig, providedIn: "root" });
    return SVConfig;
}());
export { SVConfig };
if (false) {
    /**
     * 大小
     * @type {?}
     */
    SVConfig.prototype.size;
    /**
     * 间距，默认：`32`
     * @type {?}
     */
    SVConfig.prototype.gutter;
    /**
     * 布局，默认：`horizontal`
     * @type {?}
     */
    SVConfig.prototype.layout;
    /**
     * 列数，默认：`3`
     * @type {?}
     */
    SVConfig.prototype.col;
    /**
     * 是否显示默认值，当内容为空值时显示 `-`，默认：`true`
     * @type {?}
     */
    SVConfig.prototype.default;
    /**
     * `label` 固定宽度，若 `null` 或 `undefined` 表示非固定，默认：`null`
     * @type {?}
     */
    SVConfig.prototype.labelWidth;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidmlldy5jb25maWcuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL3ZpZXcvIiwic291cmNlcyI6WyJ2aWV3LmNvbmZpZy50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLGVBQWUsQ0FBQzs7QUFFM0M7SUFBQTs7OztRQUtFLFdBQU0sR0FBRyxFQUFFLENBQUM7Ozs7UUFFWixXQUFNLEdBQUcsWUFBWSxDQUFDOzs7O1FBRXRCLFFBQUcsR0FBRyxDQUFDLENBQUM7Ozs7UUFFUixZQUFPLEdBQUcsSUFBSSxDQUFDOzs7O1FBRWYsZUFBVSxHQUFHLElBQUksQ0FBQztLQUNuQjs7Z0JBZEEsVUFBVSxTQUFDLEVBQUUsVUFBVSxFQUFFLE1BQU0sRUFBRTs7O21CQUZsQztDQWdCQyxBQWRELElBY0M7U0FiWSxRQUFROzs7Ozs7SUFFbkIsd0JBQXdCOzs7OztJQUV4QiwwQkFBWTs7Ozs7SUFFWiwwQkFBc0I7Ozs7O0lBRXRCLHVCQUFROzs7OztJQUVSLDJCQUFlOzs7OztJQUVmLDhCQUFrQiIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IEluamVjdGFibGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuQEluamVjdGFibGUoeyBwcm92aWRlZEluOiAncm9vdCcgfSlcbmV4cG9ydCBjbGFzcyBTVkNvbmZpZyB7XG4gIC8qKiDlpKflsI8gKi9cbiAgc2l6ZTogJ3NtYWxsJyB8ICdsYXJnZSc7XG4gIC8qKiDpl7Tot53vvIzpu5jorqTvvJpgMzJgICovXG4gIGd1dHRlciA9IDMyO1xuICAvKiog5biD5bGA77yM6buY6K6k77yaYGhvcml6b250YWxgICovXG4gIGxheW91dCA9ICdob3Jpem9udGFsJztcbiAgLyoqIOWIl+aVsO+8jOm7mOiupO+8mmAzYCAqL1xuICBjb2wgPSAzO1xuICAvKiog5piv5ZCm5pi+56S66buY6K6k5YC877yM5b2T5YaF5a655Li656m65YC85pe25pi+56S6IGAtYO+8jOm7mOiupO+8mmB0cnVlYCAqL1xuICBkZWZhdWx0ID0gdHJ1ZTtcbiAgLyoqIGBsYWJlbGAg5Zu65a6a5a695bqm77yM6IulIGBudWxsYCDmiJYgYHVuZGVmaW5lZGAg6KGo56S66Z2e5Zu65a6a77yM6buY6K6k77yaYG51bGxgICovXG4gIGxhYmVsV2lkdGggPSBudWxsO1xufVxuIl19