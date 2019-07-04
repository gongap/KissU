/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import { QRConfig } from './qr.config';
import * as i0 from "@angular/core";
import * as i1 from "./qr.config";
var QRService = /** @class */ (function () {
    function QRService(cog) {
        /**
         * 背景透明级别，范围：`0-1` 之间
         */
        this.backgroundAlpha = 1;
        Object.assign(this, cog);
        this.qr = new QRious();
    }
    /**
     * 生成二维码，并返回Base64编码
     *
     * @param [value] 重新指定值
     */
    /**
     * 生成二维码，并返回Base64编码
     *
     * @param {?=} value
     * @return {?}
     */
    QRService.prototype.refresh = /**
     * 生成二维码，并返回Base64编码
     *
     * @param {?=} value
     * @return {?}
     */
    function (value) {
        this.qr.set(typeof value === 'object'
            ? value
            : {
                background: this.background,
                backgroundAlpha: this.backgroundAlpha,
                foreground: this.foreground,
                foregroundAlpha: this.foregroundAlpha,
                level: this.level,
                padding: this.padding,
                size: this.size,
                value: value || this.value,
            });
        return this.dataURL;
    };
    Object.defineProperty(QRService.prototype, "dataURL", {
        /**
         * 返回当前二维码Base64编码
         */
        get: /**
         * 返回当前二维码Base64编码
         * @return {?}
         */
        function () {
            return this.qr.toDataURL();
        },
        enumerable: true,
        configurable: true
    });
    QRService.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */
    QRService.ctorParameters = function () { return [
        { type: QRConfig }
    ]; };
    /** @nocollapse */ QRService.ngInjectableDef = i0.defineInjectable({ factory: function QRService_Factory() { return new QRService(i0.inject(i1.QRConfig)); }, token: QRService, providedIn: "root" });
    return QRService;
}());
export { QRService };
if (false) {
    /**
     * 当前qr实例
     * @type {?}
     */
    QRService.prototype.qr;
    /**
     * 背景
     * @type {?}
     */
    QRService.prototype.background;
    /**
     * 背景透明级别，范围：`0-1` 之间
     * @type {?}
     */
    QRService.prototype.backgroundAlpha;
    /**
     * 前景
     * @type {?}
     */
    QRService.prototype.foreground;
    /**
     * 前景透明级别，范围：`0-1` 之间
     * @type {?}
     */
    QRService.prototype.foregroundAlpha;
    /**
     * 误差校正级别
     * @type {?}
     */
    QRService.prototype.level;
    /**
     * 二维码输出图片MIME类型
     * @type {?}
     */
    QRService.prototype.mime;
    /**
     * 内边距（单位：px）
     * @type {?}
     */
    QRService.prototype.padding;
    /**
     * 大小（单位：px）
     * @type {?}
     */
    QRService.prototype.size;
    /**
     * 值
     * @type {?}
     */
    QRService.prototype.value;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicXIuc2VydmljZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi9hYmMvcXIvIiwic291cmNlcyI6WyJxci5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsVUFBVSxFQUFFLE1BQU0sZUFBZSxDQUFDO0FBQzNDLE9BQU8sRUFBRSxRQUFRLEVBQUUsTUFBTSxhQUFhLENBQUM7OztBQUl2QztJQXVCRSxtQkFBWSxHQUFhOzs7O1FBaEJ6QixvQkFBZSxHQUFHLENBQUMsQ0FBQztRQWlCbEIsTUFBTSxDQUFDLE1BQU0sQ0FBQyxJQUFJLEVBQUUsR0FBRyxDQUFDLENBQUM7UUFDekIsSUFBSSxDQUFDLEVBQUUsR0FBRyxJQUFJLE1BQU0sRUFBRSxDQUFDO0lBQ3pCLENBQUM7SUFFRDs7OztPQUlHOzs7Ozs7O0lBQ0gsMkJBQU87Ozs7OztJQUFQLFVBQVEsS0FBbUI7UUFDekIsSUFBSSxDQUFDLEVBQUUsQ0FBQyxHQUFHLENBQ1QsT0FBTyxLQUFLLEtBQUssUUFBUTtZQUN2QixDQUFDLENBQUMsS0FBSztZQUNQLENBQUMsQ0FBQztnQkFDRSxVQUFVLEVBQUUsSUFBSSxDQUFDLFVBQVU7Z0JBQzNCLGVBQWUsRUFBRSxJQUFJLENBQUMsZUFBZTtnQkFDckMsVUFBVSxFQUFFLElBQUksQ0FBQyxVQUFVO2dCQUMzQixlQUFlLEVBQUUsSUFBSSxDQUFDLGVBQWU7Z0JBQ3JDLEtBQUssRUFBRSxJQUFJLENBQUMsS0FBSztnQkFDakIsT0FBTyxFQUFFLElBQUksQ0FBQyxPQUFPO2dCQUNyQixJQUFJLEVBQUUsSUFBSSxDQUFDLElBQUk7Z0JBQ2YsS0FBSyxFQUFFLEtBQUssSUFBSSxJQUFJLENBQUMsS0FBSzthQUMzQixDQUNOLENBQUM7UUFDRixPQUFPLElBQUksQ0FBQyxPQUFPLENBQUM7SUFDdEIsQ0FBQztJQUtELHNCQUFJLDhCQUFPO1FBSFg7O1dBRUc7Ozs7O1FBQ0g7WUFDRSxPQUFPLElBQUksQ0FBQyxFQUFFLENBQUMsU0FBUyxFQUFFLENBQUM7UUFDN0IsQ0FBQzs7O09BQUE7O2dCQXhERixVQUFVLFNBQUMsRUFBRSxVQUFVLEVBQUUsTUFBTSxFQUFFOzs7O2dCQUp6QixRQUFROzs7b0JBRGpCO0NBOERDLEFBekRELElBeURDO1NBeERZLFNBQVM7Ozs7OztJQUVwQix1QkFBaUI7Ozs7O0lBRWpCLCtCQUFtQjs7Ozs7SUFFbkIsb0NBQW9COzs7OztJQUVwQiwrQkFBbUI7Ozs7O0lBRW5CLG9DQUF3Qjs7Ozs7SUFFeEIsMEJBQWM7Ozs7O0lBRWQseUJBQWE7Ozs7O0lBRWIsNEJBQWdCOzs7OztJQUVoQix5QkFBYTs7Ozs7SUFFYiwwQkFBYyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IEluamVjdGFibGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IFFSQ29uZmlnIH0gZnJvbSAnLi9xci5jb25maWcnO1xuXG5kZWNsYXJlIHZhciBRUmlvdXM6IGFueTtcblxuQEluamVjdGFibGUoeyBwcm92aWRlZEluOiAncm9vdCcgfSlcbmV4cG9ydCBjbGFzcyBRUlNlcnZpY2Uge1xuICAvKiog5b2T5YmNcXLlrp7kvosgKi9cbiAgcmVhZG9ubHkgcXI6IGFueTtcbiAgLyoqIOiDjOaZryAqL1xuICBiYWNrZ3JvdW5kOiBzdHJpbmc7XG4gIC8qKiDog4zmma/pgI/mmI7nuqfliKvvvIzojIPlm7TvvJpgMC0xYCDkuYvpl7QgKi9cbiAgYmFja2dyb3VuZEFscGhhID0gMTtcbiAgLyoqIOWJjeaZryAqL1xuICBmb3JlZ3JvdW5kOiBzdHJpbmc7XG4gIC8qKiDliY3mma/pgI/mmI7nuqfliKvvvIzojIPlm7TvvJpgMC0xYCDkuYvpl7QgKi9cbiAgZm9yZWdyb3VuZEFscGhhOiBudW1iZXI7XG4gIC8qKiDor6/lt67moKHmraPnuqfliKsgKi9cbiAgbGV2ZWw6IHN0cmluZztcbiAgLyoqIOS6jOe7tOeggei+k+WHuuWbvueJh01JTUXnsbvlnosgKi9cbiAgbWltZTogc3RyaW5nO1xuICAvKiog5YaF6L656Led77yI5Y2V5L2N77yacHjvvIkgKi9cbiAgcGFkZGluZzogbnVtYmVyO1xuICAvKiog5aSn5bCP77yI5Y2V5L2N77yacHjvvIkgKi9cbiAgc2l6ZTogbnVtYmVyO1xuICAvKiog5YC8ICovXG4gIHZhbHVlOiBzdHJpbmc7XG5cbiAgY29uc3RydWN0b3IoY29nOiBRUkNvbmZpZykge1xuICAgIE9iamVjdC5hc3NpZ24odGhpcywgY29nKTtcbiAgICB0aGlzLnFyID0gbmV3IFFSaW91cygpO1xuICB9XG5cbiAgLyoqXG4gICAqIOeUn+aIkOS6jOe7tOegge+8jOW5tui/lOWbnkJhc2U2NOe8lueggVxuICAgKlxuICAgKiBAcGFyYW0gW3ZhbHVlXSDph43mlrDmjIflrprlgLxcbiAgICovXG4gIHJlZnJlc2godmFsdWU/OiBzdHJpbmcgfCB7fSk6IHN0cmluZyB7XG4gICAgdGhpcy5xci5zZXQoXG4gICAgICB0eXBlb2YgdmFsdWUgPT09ICdvYmplY3QnXG4gICAgICAgID8gdmFsdWVcbiAgICAgICAgOiB7XG4gICAgICAgICAgICBiYWNrZ3JvdW5kOiB0aGlzLmJhY2tncm91bmQsXG4gICAgICAgICAgICBiYWNrZ3JvdW5kQWxwaGE6IHRoaXMuYmFja2dyb3VuZEFscGhhLFxuICAgICAgICAgICAgZm9yZWdyb3VuZDogdGhpcy5mb3JlZ3JvdW5kLFxuICAgICAgICAgICAgZm9yZWdyb3VuZEFscGhhOiB0aGlzLmZvcmVncm91bmRBbHBoYSxcbiAgICAgICAgICAgIGxldmVsOiB0aGlzLmxldmVsLFxuICAgICAgICAgICAgcGFkZGluZzogdGhpcy5wYWRkaW5nLFxuICAgICAgICAgICAgc2l6ZTogdGhpcy5zaXplLFxuICAgICAgICAgICAgdmFsdWU6IHZhbHVlIHx8IHRoaXMudmFsdWUsXG4gICAgICAgICAgfSxcbiAgICApO1xuICAgIHJldHVybiB0aGlzLmRhdGFVUkw7XG4gIH1cblxuICAvKipcbiAgICog6L+U5Zue5b2T5YmN5LqM57u056CBQmFzZTY057yW56CBXG4gICAqL1xuICBnZXQgZGF0YVVSTCgpOiBzdHJpbmcge1xuICAgIHJldHVybiB0aGlzLnFyLnRvRGF0YVVSTCgpO1xuICB9XG59XG4iXX0=