/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import * as i0 from "@angular/core";
var QRConfig = /** @class */ (function () {
    function QRConfig() {
        /**
         * 背景，默认：`white`
         */
        this.background = 'white';
        /**
         * 背景透明级别，范围：`0-1` 之间，默认：`1.0`
         */
        this.backgroundAlpha = 1;
        /**
         * 前景，默认：`black`
         */
        this.foreground = 'black';
        /**
         * 前景透明级别，范围：`0-1` 之间，默认：`1.0`
         */
        this.foregroundAlpha = 1;
        /**
         * 误差校正级别，默认：`L`
         */
        this.level = 'L';
        /**
         * 二维码输出图片MIME类型，默认：`image/png`
         */
        this.mime = 'image/png';
        /**
         * 内边距（单位：px），默认：`10`
         */
        this.padding = 10;
        /**
         * 大小（单位：px），默认：`220`
         */
        this.size = 220;
    }
    QRConfig.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */ QRConfig.ngInjectableDef = i0.defineInjectable({ factory: function QRConfig_Factory() { return new QRConfig(); }, token: QRConfig, providedIn: "root" });
    return QRConfig;
}());
export { QRConfig };
if (false) {
    /**
     * 背景，默认：`white`
     * @type {?}
     */
    QRConfig.prototype.background;
    /**
     * 背景透明级别，范围：`0-1` 之间，默认：`1.0`
     * @type {?}
     */
    QRConfig.prototype.backgroundAlpha;
    /**
     * 前景，默认：`black`
     * @type {?}
     */
    QRConfig.prototype.foreground;
    /**
     * 前景透明级别，范围：`0-1` 之间，默认：`1.0`
     * @type {?}
     */
    QRConfig.prototype.foregroundAlpha;
    /**
     * 误差校正级别，默认：`L`
     * @type {?}
     */
    QRConfig.prototype.level;
    /**
     * 二维码输出图片MIME类型，默认：`image/png`
     * @type {?}
     */
    QRConfig.prototype.mime;
    /**
     * 内边距（单位：px），默认：`10`
     * @type {?}
     */
    QRConfig.prototype.padding;
    /**
     * 大小（单位：px），默认：`220`
     * @type {?}
     */
    QRConfig.prototype.size;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicXIuY29uZmlnLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy9xci8iLCJzb3VyY2VzIjpbInFyLmNvbmZpZy50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLGVBQWUsQ0FBQzs7QUFFM0M7SUFBQTs7OztRQUdFLGVBQVUsR0FBRyxPQUFPLENBQUM7Ozs7UUFFckIsb0JBQWUsR0FBRyxDQUFDLENBQUM7Ozs7UUFFcEIsZUFBVSxHQUFHLE9BQU8sQ0FBQzs7OztRQUVyQixvQkFBZSxHQUFHLENBQUMsQ0FBQzs7OztRQUVwQixVQUFLLEdBQTBCLEdBQUcsQ0FBQzs7OztRQUVuQyxTQUFJLEdBQUcsV0FBVyxDQUFDOzs7O1FBRW5CLFlBQU8sR0FBRyxFQUFFLENBQUM7Ozs7UUFFYixTQUFJLEdBQUcsR0FBRyxDQUFDO0tBQ1o7O2dCQWxCQSxVQUFVLFNBQUMsRUFBRSxVQUFVLEVBQUUsTUFBTSxFQUFFOzs7bUJBRmxDO0NBb0JDLEFBbEJELElBa0JDO1NBakJZLFFBQVE7Ozs7OztJQUVuQiw4QkFBcUI7Ozs7O0lBRXJCLG1DQUFvQjs7Ozs7SUFFcEIsOEJBQXFCOzs7OztJQUVyQixtQ0FBb0I7Ozs7O0lBRXBCLHlCQUFtQzs7Ozs7SUFFbkMsd0JBQW1COzs7OztJQUVuQiwyQkFBYTs7Ozs7SUFFYix3QkFBVyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IEluamVjdGFibGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuQEluamVjdGFibGUoeyBwcm92aWRlZEluOiAncm9vdCcgfSlcbmV4cG9ydCBjbGFzcyBRUkNvbmZpZyB7XG4gIC8qKiDog4zmma/vvIzpu5jorqTvvJpgd2hpdGVgICovXG4gIGJhY2tncm91bmQgPSAnd2hpdGUnO1xuICAvKiog6IOM5pmv6YCP5piO57qn5Yir77yM6IyD5Zu077yaYDAtMWAg5LmL6Ze077yM6buY6K6k77yaYDEuMGAgKi9cbiAgYmFja2dyb3VuZEFscGhhID0gMTtcbiAgLyoqIOWJjeaZr++8jOm7mOiupO+8mmBibGFja2AgKi9cbiAgZm9yZWdyb3VuZCA9ICdibGFjayc7XG4gIC8qKiDliY3mma/pgI/mmI7nuqfliKvvvIzojIPlm7TvvJpgMC0xYCDkuYvpl7TvvIzpu5jorqTvvJpgMS4wYCAqL1xuICBmb3JlZ3JvdW5kQWxwaGEgPSAxO1xuICAvKiog6K+v5beu5qCh5q2j57qn5Yir77yM6buY6K6k77yaYExgICovXG4gIGxldmVsOiAnTCcgfCAnTScgfCAnUScgfCAnSCcgPSAnTCc7XG4gIC8qKiDkuoznu7TnoIHovpPlh7rlm77niYdNSU1F57G75Z6L77yM6buY6K6k77yaYGltYWdlL3BuZ2AgKi9cbiAgbWltZSA9ICdpbWFnZS9wbmcnO1xuICAvKiog5YaF6L656Led77yI5Y2V5L2N77yacHjvvInvvIzpu5jorqTvvJpgMTBgICovXG4gIHBhZGRpbmcgPSAxMDtcbiAgLyoqIOWkp+Wwj++8iOWNleS9je+8mnB477yJ77yM6buY6K6k77yaYDIyMGAgKi9cbiAgc2l6ZSA9IDIyMDtcbn1cbiJdfQ==