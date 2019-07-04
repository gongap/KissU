/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { NzDrawerService } from 'ng-zorro-antd';
import { Observable } from 'rxjs';
import * as i0 from "@angular/core";
import * as i1 from "ng-zorro-antd";
/**
 * @record
 */
export function DrawerHelperOptions() { }
if (false) {
    /**
     * 大小，若值为数值类型，则根据 `nzPlacement` 自动转化为 `nzHeight` 或 `nzWidth`；例如：lg、600，默认：`md`
     *
     * | 类型 | 默认大小 |
     * | --- | ------ |
     * | `sm` | `300` |
     * | `md` | `600` |
     * | `lg` | `900` |
     * | `xl` | `1200` |
     *
     * > 以上值，可通过覆盖相应的LESS参数自行调整
     * @type {?|undefined}
     */
    DrawerHelperOptions.prototype.size;
    /**
     * 是否包含底部工具条，默认：`true`
     * @type {?|undefined}
     */
    DrawerHelperOptions.prototype.footer;
    /**
     * 底部工具条高度，默认：`55`
     * @type {?|undefined}
     */
    DrawerHelperOptions.prototype.footerHeight;
    /**
     * 抽屉 [NzDrawerOptions](https://ng.ant.design/components/drawer/zh#nzdraweroptions) 参数
     * @type {?|undefined}
     */
    DrawerHelperOptions.prototype.drawerOptions;
}
/**
 * 抽屉辅助类
 *
 * **注意：** 构建结果都可被订阅，但永远都不会触发 `observer.error`
 *
 * 示例：
 * ```ts
 * this.drawerHelper.create('Edit', FormEditComponent, { i }).subscribe(res => this.load());
 * // 对于组件的成功&关闭的处理说明
 * // 成功
 * this.NzDrawerRef.close(data);
 * this.NzDrawerRef.close(true);
 * // 关闭
 * this.NzDrawerRef.close();
 * this.NzDrawerRef.close(false);
 * ```
 */
var DrawerHelper = /** @class */ (function () {
    function DrawerHelper(srv) {
        this.srv = srv;
        // 大部分情况下抽屉的层级比 Modal 会更低一些
        this.zIndex = 400;
    }
    /**
     * 构建一个抽屉
     */
    /**
     * 构建一个抽屉
     * @param {?} title
     * @param {?} comp
     * @param {?=} params
     * @param {?=} options
     * @return {?}
     */
    DrawerHelper.prototype.create = /**
     * 构建一个抽屉
     * @param {?} title
     * @param {?} comp
     * @param {?=} params
     * @param {?=} options
     * @return {?}
     */
    function (title, comp, params, options) {
        var _this = this;
        options = tslib_1.__assign({ size: 'md', footer: true, footerHeight: 55, drawerOptions: {
                nzPlacement: 'right',
                nzWrapClassName: '',
            } }, options);
        return new Observable((/**
         * @param {?} observer
         * @return {?}
         */
        function (observer) {
            var size = options.size, footer = options.footer, footerHeight = options.footerHeight, drawerOptions = options.drawerOptions;
            /** @type {?} */
            var defaultOptions = {
                nzContent: comp,
                nzContentParams: params,
                nzZIndex: ++_this.zIndex,
                nzTitle: title,
            };
            if (typeof size === 'number') {
                defaultOptions[drawerOptions.nzPlacement === 'top' || drawerOptions.nzPlacement === 'bottom'
                    ? 'nzHeight'
                    : 'nzWidth'] = options.size;
            }
            else {
                defaultOptions.nzWrapClassName = (drawerOptions.nzWrapClassName + (" drawer-" + options.size)).trim();
                delete drawerOptions.nzWrapClassName;
            }
            if (footer) {
                var nzPlacement = drawerOptions.nzPlacement, nzHeight = drawerOptions.nzHeight;
                // Should be header * footer, because of includes header
                /** @type {?} */
                var reduceHeight = (footerHeight * 2) - 2;
                if (nzPlacement === 'left' || nzPlacement === 'right') {
                    defaultOptions.nzBodyStyle = {
                        height: "calc(100% - " + reduceHeight + "px)",
                        overflow: 'auto',
                    };
                }
                else {
                    defaultOptions.nzBodyStyle = {
                        height: +(nzHeight || 256) - reduceHeight + "px",
                        overflow: 'auto',
                    };
                }
            }
            /** @type {?} */
            var subject = _this.srv.create(tslib_1.__assign({}, defaultOptions, drawerOptions));
            /** @type {?} */
            var afterClose$ = subject.afterClose.subscribe((/**
             * @param {?} res
             * @return {?}
             */
            function (res) {
                if (res != null && res !== false) {
                    observer.next(res);
                }
                observer.complete();
                afterClose$.unsubscribe();
            }));
        }));
    };
    /**
     * 构建一个抽屉，点击蒙层不允许关闭
     */
    /**
     * 构建一个抽屉，点击蒙层不允许关闭
     * @param {?} title
     * @param {?} comp
     * @param {?=} params
     * @param {?=} options
     * @return {?}
     */
    DrawerHelper.prototype.static = /**
     * 构建一个抽屉，点击蒙层不允许关闭
     * @param {?} title
     * @param {?} comp
     * @param {?=} params
     * @param {?=} options
     * @return {?}
     */
    function (title, comp, params, options) {
        /** @type {?} */
        var drawerOptions = tslib_1.__assign({ nzMaskClosable: false }, (options && options.drawerOptions));
        return this.create(title, comp, params, tslib_1.__assign({}, options, { drawerOptions: drawerOptions }));
    };
    DrawerHelper.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */
    DrawerHelper.ctorParameters = function () { return [
        { type: NzDrawerService }
    ]; };
    /** @nocollapse */ DrawerHelper.ngInjectableDef = i0.defineInjectable({ factory: function DrawerHelper_Factory() { return new DrawerHelper(i0.inject(i1.NzDrawerService)); }, token: DrawerHelper, providedIn: "root" });
    return DrawerHelper;
}());
export { DrawerHelper };
if (false) {
    /**
     * @type {?}
     * @private
     */
    DrawerHelper.prototype.zIndex;
    /**
     * @type {?}
     * @private
     */
    DrawerHelper.prototype.srv;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiZHJhd2VyLmhlbHBlci5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi90aGVtZS8iLCJzb3VyY2VzIjpbInNyYy9zZXJ2aWNlcy9kcmF3ZXIvZHJhd2VyLmhlbHBlci50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7OztBQUFBLE9BQU8sRUFBRSxVQUFVLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFDM0MsT0FBTyxFQUFtQixlQUFlLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFDakUsT0FBTyxFQUFFLFVBQVUsRUFBWSxNQUFNLE1BQU0sQ0FBQzs7Ozs7O0FBRTVDLHlDQXdCQzs7Ozs7Ozs7Ozs7Ozs7O0lBWEMsbUNBQTBDOzs7OztJQUkxQyxxQ0FBaUI7Ozs7O0lBSWpCLDJDQUFzQjs7Ozs7SUFFdEIsNENBQWdDOzs7Ozs7Ozs7Ozs7Ozs7Ozs7O0FBb0JsQztJQUtFLHNCQUFvQixHQUFvQjtRQUFwQixRQUFHLEdBQUgsR0FBRyxDQUFpQjs7UUFGaEMsV0FBTSxHQUFHLEdBQUcsQ0FBQztJQUVzQixDQUFDO0lBRTVDOztPQUVHOzs7Ozs7Ozs7SUFDSCw2QkFBTTs7Ozs7Ozs7SUFBTixVQUFPLEtBQWEsRUFBRSxJQUFTLEVBQUUsTUFBWSxFQUFFLE9BQTZCO1FBQTVFLGlCQTJEQztRQTFEQyxPQUFPLHNCQUNMLElBQUksRUFBRSxJQUFJLEVBQ1YsTUFBTSxFQUFFLElBQUksRUFDWixZQUFZLEVBQUUsRUFBRSxFQUNoQixhQUFhLEVBQUU7Z0JBQ2IsV0FBVyxFQUFFLE9BQU87Z0JBQ3BCLGVBQWUsRUFBRSxFQUFFO2FBQ3BCLElBQ0UsT0FBTyxDQUNYLENBQUM7UUFDRixPQUFPLElBQUksVUFBVTs7OztRQUFDLFVBQUMsUUFBdUI7WUFDcEMsSUFBQSxtQkFBSSxFQUFFLHVCQUFNLEVBQUUsbUNBQVksRUFBRSxxQ0FBYTs7Z0JBQzNDLGNBQWMsR0FBb0I7Z0JBQ3RDLFNBQVMsRUFBRSxJQUFJO2dCQUNmLGVBQWUsRUFBRSxNQUFNO2dCQUN2QixRQUFRLEVBQUUsRUFBRSxLQUFJLENBQUMsTUFBTTtnQkFDdkIsT0FBTyxFQUFFLEtBQUs7YUFDZjtZQUVELElBQUksT0FBTyxJQUFJLEtBQUssUUFBUSxFQUFFO2dCQUM1QixjQUFjLENBQ1osYUFBYSxDQUFDLFdBQVcsS0FBSyxLQUFLLElBQUksYUFBYSxDQUFDLFdBQVcsS0FBSyxRQUFRO29CQUMzRSxDQUFDLENBQUMsVUFBVTtvQkFDWixDQUFDLENBQUMsU0FBUyxDQUNkLEdBQUcsT0FBTyxDQUFDLElBQUksQ0FBQzthQUNsQjtpQkFBTTtnQkFDTCxjQUFjLENBQUMsZUFBZSxHQUFHLENBQy9CLGFBQWEsQ0FBQyxlQUFlLElBQUcsYUFBVyxPQUFPLENBQUMsSUFBTSxDQUFBLENBQzFELENBQUMsSUFBSSxFQUFFLENBQUM7Z0JBQ1QsT0FBTyxhQUFhLENBQUMsZUFBZSxDQUFDO2FBQ3RDO1lBRUQsSUFBSSxNQUFNLEVBQUU7Z0JBQ0YsSUFBQSx1Q0FBVyxFQUFFLGlDQUFROzs7b0JBRXZCLFlBQVksR0FBRyxDQUFDLFlBQVksR0FBRyxDQUFDLENBQUMsR0FBRyxDQUFDO2dCQUMzQyxJQUFJLFdBQVcsS0FBSyxNQUFNLElBQUksV0FBVyxLQUFLLE9BQU8sRUFBRTtvQkFDckQsY0FBYyxDQUFDLFdBQVcsR0FBRzt3QkFDM0IsTUFBTSxFQUFFLGlCQUFlLFlBQVksUUFBSzt3QkFDeEMsUUFBUSxFQUFFLE1BQU07cUJBQ2pCLENBQUM7aUJBQ0g7cUJBQU07b0JBQ0wsY0FBYyxDQUFDLFdBQVcsR0FBRzt3QkFDM0IsTUFBTSxFQUFLLENBQUMsQ0FBQyxRQUFRLElBQUksR0FBRyxDQUFDLEdBQUcsWUFBWSxPQUFJO3dCQUNoRCxRQUFRLEVBQUUsTUFBTTtxQkFDakIsQ0FBQztpQkFDSDthQUNGOztnQkFFSyxPQUFPLEdBQUcsS0FBSSxDQUFDLEdBQUcsQ0FBQyxNQUFNLHNCQUFNLGNBQWMsRUFBSyxhQUFhLEVBQUc7O2dCQUNsRSxXQUFXLEdBQUcsT0FBTyxDQUFDLFVBQVUsQ0FBQyxTQUFTOzs7O1lBQUMsVUFBQyxHQUFRO2dCQUN4RCxJQUFJLEdBQUcsSUFBSSxJQUFJLElBQUksR0FBRyxLQUFLLEtBQUssRUFBRTtvQkFDaEMsUUFBUSxDQUFDLElBQUksQ0FBQyxHQUFHLENBQUMsQ0FBQztpQkFDcEI7Z0JBQ0QsUUFBUSxDQUFDLFFBQVEsRUFBRSxDQUFDO2dCQUNwQixXQUFXLENBQUMsV0FBVyxFQUFFLENBQUM7WUFDNUIsQ0FBQyxFQUFDO1FBQ0osQ0FBQyxFQUFDLENBQUM7SUFDTCxDQUFDO0lBRUQ7O09BRUc7Ozs7Ozs7OztJQUNILDZCQUFNOzs7Ozs7OztJQUFOLFVBQU8sS0FBYSxFQUFFLElBQVMsRUFBRSxNQUFZLEVBQUUsT0FBNkI7O1lBQ3BFLGFBQWEsc0JBQ2pCLGNBQWMsRUFBRSxLQUFLLElBQ2xCLENBQUMsT0FBTyxJQUFJLE9BQU8sQ0FBQyxhQUFhLENBQUMsQ0FDdEM7UUFDRCxPQUFPLElBQUksQ0FBQyxNQUFNLENBQUMsS0FBSyxFQUFFLElBQUksRUFBRSxNQUFNLHVCQUFPLE9BQU8sSUFBRSxhQUFhLGVBQUEsSUFBRyxDQUFDO0lBQ3pFLENBQUM7O2dCQWhGRixVQUFVLFNBQUMsRUFBRSxVQUFVLEVBQUUsTUFBTSxFQUFFOzs7O2dCQTlDUixlQUFlOzs7dUJBRHpDO0NBZ0lDLEFBakZELElBaUZDO1NBaEZZLFlBQVk7Ozs7OztJQUV2Qiw4QkFBcUI7Ozs7O0lBRVQsMkJBQTRCIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgSW5qZWN0YWJsZSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgTnpEcmF3ZXJPcHRpb25zLCBOekRyYXdlclNlcnZpY2UgfSBmcm9tICduZy16b3Jyby1hbnRkJztcbmltcG9ydCB7IE9ic2VydmFibGUsIE9ic2VydmVyIH0gZnJvbSAncnhqcyc7XG5cbmV4cG9ydCBpbnRlcmZhY2UgRHJhd2VySGVscGVyT3B0aW9ucyB7XG4gIC8qKlxuICAgKiDlpKflsI/vvIzoi6XlgLzkuLrmlbDlgLznsbvlnovvvIzliJnmoLnmja4gYG56UGxhY2VtZW50YCDoh6rliqjovazljJbkuLogYG56SGVpZ2h0YCDmiJYgYG56V2lkdGhg77yb5L6L5aaC77yabGfjgIE2MDDvvIzpu5jorqTvvJpgbWRgXG4gICAqXG4gICAqIHwg57G75Z6LIHwg6buY6K6k5aSn5bCPIHxcbiAgICogfCAtLS0gfCAtLS0tLS0gfFxuICAgKiB8IGBzbWAgfCBgMzAwYCB8XG4gICAqIHwgYG1kYCB8IGA2MDBgIHxcbiAgICogfCBgbGdgIHwgYDkwMGAgfFxuICAgKiB8IGB4bGAgfCBgMTIwMGAgfFxuICAgKlxuICAgKiA+IOS7peS4iuWAvO+8jOWPr+mAmui/h+imhuebluebuOW6lOeahExFU1Plj4LmlbDoh6rooYzosIPmlbRcbiAgICovXG4gIHNpemU/OiAnc20nIHwgJ21kJyB8ICdsZycgfCAneGwnIHwgbnVtYmVyO1xuICAvKipcbiAgICog5piv5ZCm5YyF5ZCr5bqV6YOo5bel5YW35p2h77yM6buY6K6k77yaYHRydWVgXG4gICAqL1xuICBmb290ZXI/OiBib29sZWFuO1xuICAvKipcbiAgICog5bqV6YOo5bel5YW35p2h6auY5bqm77yM6buY6K6k77yaYDU1YFxuICAgKi9cbiAgZm9vdGVySGVpZ2h0PzogbnVtYmVyO1xuICAvKiog5oq95bGJIFtOekRyYXdlck9wdGlvbnNdKGh0dHBzOi8vbmcuYW50LmRlc2lnbi9jb21wb25lbnRzL2RyYXdlci96aCNuemRyYXdlcm9wdGlvbnMpIOWPguaVsCAqL1xuICBkcmF3ZXJPcHRpb25zPzogTnpEcmF3ZXJPcHRpb25zO1xufVxuXG4vKipcbiAqIOaKveWxiei+heWKqeexu1xuICpcbiAqICoq5rOo5oSP77yaKiog5p6E5bu657uT5p6c6YO95Y+v6KKr6K6i6ZiF77yM5L2G5rC46L+c6YO95LiN5Lya6Kem5Y+RIGBvYnNlcnZlci5lcnJvcmBcbiAqXG4gKiDnpLrkvovvvJpcbmBgYHRzXG50aGlzLmRyYXdlckhlbHBlci5jcmVhdGUoJ0VkaXQnLCBGb3JtRWRpdENvbXBvbmVudCwgeyBpIH0pLnN1YnNjcmliZShyZXMgPT4gdGhpcy5sb2FkKCkpO1xuLy8g5a+55LqO57uE5Lu255qE5oiQ5YqfJuWFs+mXreeahOWkhOeQhuivtOaYjlxuLy8g5oiQ5YqfXG50aGlzLk56RHJhd2VyUmVmLmNsb3NlKGRhdGEpO1xudGhpcy5OekRyYXdlclJlZi5jbG9zZSh0cnVlKTtcbi8vIOWFs+mXrVxudGhpcy5OekRyYXdlclJlZi5jbG9zZSgpO1xudGhpcy5OekRyYXdlclJlZi5jbG9zZShmYWxzZSk7XG5gYGBcbiAqL1xuQEluamVjdGFibGUoeyBwcm92aWRlZEluOiAncm9vdCcgfSlcbmV4cG9ydCBjbGFzcyBEcmF3ZXJIZWxwZXIge1xuICAvLyDlpKfpg6jliIbmg4XlhrXkuIvmir3lsYnnmoTlsYLnuqfmr5QgTW9kYWwg5Lya5pu05L2O5LiA5LqbXG4gIHByaXZhdGUgekluZGV4ID0gNDAwO1xuXG4gIGNvbnN0cnVjdG9yKHByaXZhdGUgc3J2OiBOekRyYXdlclNlcnZpY2UpIHt9XG5cbiAgLyoqXG4gICAqIOaehOW7uuS4gOS4quaKveWxiVxuICAgKi9cbiAgY3JlYXRlKHRpdGxlOiBzdHJpbmcsIGNvbXA6IGFueSwgcGFyYW1zPzogYW55LCBvcHRpb25zPzogRHJhd2VySGVscGVyT3B0aW9ucyk6IE9ic2VydmFibGU8YW55PiB7XG4gICAgb3B0aW9ucyA9IHtcbiAgICAgIHNpemU6ICdtZCcsXG4gICAgICBmb290ZXI6IHRydWUsXG4gICAgICBmb290ZXJIZWlnaHQ6IDU1LFxuICAgICAgZHJhd2VyT3B0aW9uczoge1xuICAgICAgICBuelBsYWNlbWVudDogJ3JpZ2h0JyxcbiAgICAgICAgbnpXcmFwQ2xhc3NOYW1lOiAnJyxcbiAgICAgIH0sXG4gICAgICAuLi5vcHRpb25zLFxuICAgIH07XG4gICAgcmV0dXJuIG5ldyBPYnNlcnZhYmxlKChvYnNlcnZlcjogT2JzZXJ2ZXI8YW55PikgPT4ge1xuICAgICAgY29uc3QgeyBzaXplLCBmb290ZXIsIGZvb3RlckhlaWdodCwgZHJhd2VyT3B0aW9ucyB9ID0gb3B0aW9ucztcbiAgICAgIGNvbnN0IGRlZmF1bHRPcHRpb25zOiBOekRyYXdlck9wdGlvbnMgPSB7XG4gICAgICAgIG56Q29udGVudDogY29tcCxcbiAgICAgICAgbnpDb250ZW50UGFyYW1zOiBwYXJhbXMsXG4gICAgICAgIG56WkluZGV4OiArK3RoaXMuekluZGV4LFxuICAgICAgICBuelRpdGxlOiB0aXRsZSxcbiAgICAgIH07XG5cbiAgICAgIGlmICh0eXBlb2Ygc2l6ZSA9PT0gJ251bWJlcicpIHtcbiAgICAgICAgZGVmYXVsdE9wdGlvbnNbXG4gICAgICAgICAgZHJhd2VyT3B0aW9ucy5uelBsYWNlbWVudCA9PT0gJ3RvcCcgfHwgZHJhd2VyT3B0aW9ucy5uelBsYWNlbWVudCA9PT0gJ2JvdHRvbSdcbiAgICAgICAgICAgID8gJ256SGVpZ2h0J1xuICAgICAgICAgICAgOiAnbnpXaWR0aCdcbiAgICAgICAgXSA9IG9wdGlvbnMuc2l6ZTtcbiAgICAgIH0gZWxzZSB7XG4gICAgICAgIGRlZmF1bHRPcHRpb25zLm56V3JhcENsYXNzTmFtZSA9IChcbiAgICAgICAgICBkcmF3ZXJPcHRpb25zLm56V3JhcENsYXNzTmFtZSArIGAgZHJhd2VyLSR7b3B0aW9ucy5zaXplfWBcbiAgICAgICAgKS50cmltKCk7XG4gICAgICAgIGRlbGV0ZSBkcmF3ZXJPcHRpb25zLm56V3JhcENsYXNzTmFtZTtcbiAgICAgIH1cblxuICAgICAgaWYgKGZvb3Rlcikge1xuICAgICAgICBjb25zdCB7IG56UGxhY2VtZW50LCBuekhlaWdodCB9ID0gZHJhd2VyT3B0aW9ucztcbiAgICAgICAgLy8gU2hvdWxkIGJlIGhlYWRlciAqIGZvb3RlciwgYmVjYXVzZSBvZiBpbmNsdWRlcyBoZWFkZXJcbiAgICAgICAgY29uc3QgcmVkdWNlSGVpZ2h0ID0gKGZvb3RlckhlaWdodCAqIDIpIC0gMjtcbiAgICAgICAgaWYgKG56UGxhY2VtZW50ID09PSAnbGVmdCcgfHwgbnpQbGFjZW1lbnQgPT09ICdyaWdodCcpIHtcbiAgICAgICAgICBkZWZhdWx0T3B0aW9ucy5uekJvZHlTdHlsZSA9IHtcbiAgICAgICAgICAgIGhlaWdodDogYGNhbGMoMTAwJSAtICR7cmVkdWNlSGVpZ2h0fXB4KWAsXG4gICAgICAgICAgICBvdmVyZmxvdzogJ2F1dG8nLFxuICAgICAgICAgIH07XG4gICAgICAgIH0gZWxzZSB7XG4gICAgICAgICAgZGVmYXVsdE9wdGlvbnMubnpCb2R5U3R5bGUgPSB7XG4gICAgICAgICAgICBoZWlnaHQ6IGAkeysobnpIZWlnaHQgfHwgMjU2KSAtIHJlZHVjZUhlaWdodH1weGAsXG4gICAgICAgICAgICBvdmVyZmxvdzogJ2F1dG8nLFxuICAgICAgICAgIH07XG4gICAgICAgIH1cbiAgICAgIH1cblxuICAgICAgY29uc3Qgc3ViamVjdCA9IHRoaXMuc3J2LmNyZWF0ZSh7IC4uLmRlZmF1bHRPcHRpb25zLCAuLi5kcmF3ZXJPcHRpb25zIH0pO1xuICAgICAgY29uc3QgYWZ0ZXJDbG9zZSQgPSBzdWJqZWN0LmFmdGVyQ2xvc2Uuc3Vic2NyaWJlKChyZXM6IGFueSkgPT4ge1xuICAgICAgICBpZiAocmVzICE9IG51bGwgJiYgcmVzICE9PSBmYWxzZSkge1xuICAgICAgICAgIG9ic2VydmVyLm5leHQocmVzKTtcbiAgICAgICAgfVxuICAgICAgICBvYnNlcnZlci5jb21wbGV0ZSgpO1xuICAgICAgICBhZnRlckNsb3NlJC51bnN1YnNjcmliZSgpO1xuICAgICAgfSk7XG4gICAgfSk7XG4gIH1cblxuICAvKipcbiAgICog5p6E5bu65LiA5Liq5oq95bGJ77yM54K55Ye76JKZ5bGC5LiN5YWB6K645YWz6ZetXG4gICAqL1xuICBzdGF0aWModGl0bGU6IHN0cmluZywgY29tcDogYW55LCBwYXJhbXM/OiBhbnksIG9wdGlvbnM/OiBEcmF3ZXJIZWxwZXJPcHRpb25zKTogT2JzZXJ2YWJsZTxhbnk+IHtcbiAgICBjb25zdCBkcmF3ZXJPcHRpb25zID0ge1xuICAgICAgbnpNYXNrQ2xvc2FibGU6IGZhbHNlLFxuICAgICAgLi4uKG9wdGlvbnMgJiYgb3B0aW9ucy5kcmF3ZXJPcHRpb25zKSxcbiAgICB9O1xuICAgIHJldHVybiB0aGlzLmNyZWF0ZSh0aXRsZSwgY29tcCwgcGFyYW1zLCB7IC4uLm9wdGlvbnMsIGRyYXdlck9wdGlvbnMgfSk7XG4gIH1cbn1cbiJdfQ==