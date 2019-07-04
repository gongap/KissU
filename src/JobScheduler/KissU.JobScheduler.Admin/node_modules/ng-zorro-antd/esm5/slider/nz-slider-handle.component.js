/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, ViewChild, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { InputBoolean } from 'ng-zorro-antd/core';
import { NzToolTipComponent } from 'ng-zorro-antd/tooltip';
import { NzSliderComponent } from './nz-slider.component';
var NzSliderHandleComponent = /** @class */ (function () {
    function NzSliderHandleComponent(sliderComponent, cdr) {
        var _this = this;
        this.sliderComponent = sliderComponent;
        this.cdr = cdr;
        this.nzTooltipVisible = 'default';
        this.nzActive = false;
        this.style = {};
        this.hovers_ = new Subscription();
        this.enterHandle = (/**
         * @return {?}
         */
        function () {
            if (!_this.sliderComponent.isDragging) {
                _this.toggleTooltip(true);
                _this.updateTooltipPosition();
                _this.cdr.detectChanges();
            }
        });
        this.leaveHandle = (/**
         * @return {?}
         */
        function () {
            if (!_this.sliderComponent.isDragging) {
                _this.toggleTooltip(false);
                _this.cdr.detectChanges();
            }
        });
    }
    /**
     * @param {?} changes
     * @return {?}
     */
    NzSliderHandleComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        var _this = this;
        var nzOffset = changes.nzOffset, nzValue = changes.nzValue, nzActive = changes.nzActive, nzTooltipVisible = changes.nzTooltipVisible;
        if (nzOffset) {
            this.updateStyle();
        }
        if (nzValue) {
            this.updateTooltipTitle();
            this.updateTooltipPosition();
        }
        if (nzActive) {
            if (nzActive.currentValue) {
                this.toggleTooltip(true);
            }
            else {
                this.toggleTooltip(false);
            }
        }
        if (nzTooltipVisible && nzTooltipVisible.currentValue === 'always') {
            Promise.resolve().then((/**
             * @return {?}
             */
            function () { return _this.toggleTooltip(true, true); }));
        }
    };
    /**
     * @return {?}
     */
    NzSliderHandleComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.hovers_.unsubscribe();
    };
    /**
     * @private
     * @param {?} show
     * @param {?=} force
     * @return {?}
     */
    NzSliderHandleComponent.prototype.toggleTooltip = /**
     * @private
     * @param {?} show
     * @param {?=} force
     * @return {?}
     */
    function (show, force) {
        if (force === void 0) { force = false; }
        if (!force && (this.nzTooltipVisible !== 'default' || !this.tooltip)) {
            return;
        }
        if (show) {
            this.tooltip.show();
        }
        else {
            this.tooltip.hide();
        }
    };
    /**
     * @private
     * @return {?}
     */
    NzSliderHandleComponent.prototype.updateTooltipTitle = /**
     * @private
     * @return {?}
     */
    function () {
        this.tooltipTitle = this.nzTipFormatter ? this.nzTipFormatter(this.nzValue) : "" + this.nzValue;
    };
    /**
     * @private
     * @return {?}
     */
    NzSliderHandleComponent.prototype.updateTooltipPosition = /**
     * @private
     * @return {?}
     */
    function () {
        var _this = this;
        if (this.tooltip) {
            Promise.resolve().then((/**
             * @return {?}
             */
            function () { return _this.tooltip.updatePosition(); }));
        }
    };
    /**
     * @private
     * @return {?}
     */
    NzSliderHandleComponent.prototype.updateStyle = /**
     * @private
     * @return {?}
     */
    function () {
        this.style[this.nzVertical ? 'bottom' : 'left'] = this.nzOffset + "%";
    };
    NzSliderHandleComponent.decorators = [
        { type: Component, args: [{
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    encapsulation: ViewEncapsulation.None,
                    selector: 'nz-slider-handle',
                    exportAs: 'nzSliderHandle',
                    preserveWhitespaces: false,
                    template: "<nz-tooltip\n  *ngIf=\"nzTipFormatter !== null && nzTooltipVisible !== 'never'\"\n  [nzTitle]=\"tooltipTitle\"\n  [nzTrigger]=\"null\">\n  <div nz-tooltip class=\"ant-slider-handle\" [ngStyle]=\"style\"></div>\n</nz-tooltip>\n<div *ngIf=\"nzTipFormatter === null || nzTooltipVisible === 'never'\" class=\"ant-slider-handle\" [ngStyle]=\"style\"></div>\n",
                    host: {
                        '(mouseenter)': 'enterHandle()',
                        '(mouseleave)': 'leaveHandle()'
                    }
                }] }
    ];
    /** @nocollapse */
    NzSliderHandleComponent.ctorParameters = function () { return [
        { type: NzSliderComponent },
        { type: ChangeDetectorRef }
    ]; };
    NzSliderHandleComponent.propDecorators = {
        tooltip: [{ type: ViewChild, args: [NzToolTipComponent,] }],
        nzVertical: [{ type: Input }],
        nzOffset: [{ type: Input }],
        nzValue: [{ type: Input }],
        nzTooltipVisible: [{ type: Input }],
        nzTipFormatter: [{ type: Input }],
        nzActive: [{ type: Input }]
    };
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzSliderHandleComponent.prototype, "nzActive", void 0);
    return NzSliderHandleComponent;
}());
export { NzSliderHandleComponent };
if (false) {
    /** @type {?} */
    NzSliderHandleComponent.prototype.tooltip;
    /** @type {?} */
    NzSliderHandleComponent.prototype.nzVertical;
    /** @type {?} */
    NzSliderHandleComponent.prototype.nzOffset;
    /** @type {?} */
    NzSliderHandleComponent.prototype.nzValue;
    /** @type {?} */
    NzSliderHandleComponent.prototype.nzTooltipVisible;
    /** @type {?} */
    NzSliderHandleComponent.prototype.nzTipFormatter;
    /** @type {?} */
    NzSliderHandleComponent.prototype.nzActive;
    /** @type {?} */
    NzSliderHandleComponent.prototype.tooltipTitle;
    /** @type {?} */
    NzSliderHandleComponent.prototype.style;
    /**
     * @type {?}
     * @private
     */
    NzSliderHandleComponent.prototype.hovers_;
    /** @type {?} */
    NzSliderHandleComponent.prototype.enterHandle;
    /** @type {?} */
    NzSliderHandleComponent.prototype.leaveHandle;
    /**
     * @type {?}
     * @private
     */
    NzSliderHandleComponent.prototype.sliderComponent;
    /**
     * @type {?}
     * @private
     */
    NzSliderHandleComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotc2xpZGVyLWhhbmRsZS5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9uZy16b3Jyby1hbnRkL3NsaWRlci8iLCJzb3VyY2VzIjpbIm56LXNsaWRlci1oYW5kbGUuY29tcG9uZW50LnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7OztBQVFBLE9BQU8sRUFDTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxLQUFLLEVBSUwsU0FBUyxFQUNULGlCQUFpQixFQUNsQixNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQUUsWUFBWSxFQUFFLE1BQU0sTUFBTSxDQUFDO0FBRXBDLE9BQU8sRUFBRSxZQUFZLEVBQW9CLE1BQU0sb0JBQW9CLENBQUM7QUFDcEUsT0FBTyxFQUFFLGtCQUFrQixFQUFFLE1BQU0sdUJBQXVCLENBQUM7QUFHM0QsT0FBTyxFQUFFLGlCQUFpQixFQUFFLE1BQU0sdUJBQXVCLENBQUM7QUFFMUQ7SUEyQkUsaUNBQW9CLGVBQWtDLEVBQVUsR0FBc0I7UUFBdEYsaUJBQTBGO1FBQXRFLG9CQUFlLEdBQWYsZUFBZSxDQUFtQjtRQUFVLFFBQUcsR0FBSCxHQUFHLENBQW1CO1FBVDdFLHFCQUFnQixHQUFzQixTQUFTLENBQUM7UUFFaEMsYUFBUSxHQUFHLEtBQUssQ0FBQztRQUcxQyxVQUFLLEdBQXFCLEVBQUUsQ0FBQztRQUVyQixZQUFPLEdBQUcsSUFBSSxZQUFZLEVBQUUsQ0FBQztRQThCckMsZ0JBQVc7OztRQUFHO1lBQ1osSUFBSSxDQUFDLEtBQUksQ0FBQyxlQUFlLENBQUMsVUFBVSxFQUFFO2dCQUNwQyxLQUFJLENBQUMsYUFBYSxDQUFDLElBQUksQ0FBQyxDQUFDO2dCQUN6QixLQUFJLENBQUMscUJBQXFCLEVBQUUsQ0FBQztnQkFDN0IsS0FBSSxDQUFDLEdBQUcsQ0FBQyxhQUFhLEVBQUUsQ0FBQzthQUMxQjtRQUNILENBQUMsRUFBQztRQUVGLGdCQUFXOzs7UUFBRztZQUNaLElBQUks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O29CQUNoRCxJQUFJLEVBQUU7d0JBQ0osY0FBYyxFQUFFLGVBQWU7d0JBQy9CLGNBQWMsRUFBRSxlQUFlO3FCQUNoQztpQkFDRjs7OztnQkFiUSxpQkFBaUI7Z0JBZnhCLGlCQUFpQjs7OzBCQThCaEIsU0FBUyxTQUFDLGtCQUFrQjs2QkFFNUIsS0FBSzsyQkFDTCxLQUFLOzBCQUNMLEtBQUs7bUNBQ0wsS0FBSztpQ0FDTCxLQUFLOzJCQUNMLEtBQUs7O0lBQW1CO1FBQWYsWUFBWSxFQUFFOzs2REFBa0I7SUEyRTVDLDhCQUFDO0NBQUEsQUEvRkQsSUErRkM7U0FuRlksdUJBQXVCOzs7SUFDbEMsMENBQTJEOztJQUUzRCw2Q0FBNEI7O0lBQzVCLDJDQUEwQjs7SUFDMUIsMENBQXlCOztJQUN6QixtREFBeUQ7O0lBQ3pELGlEQUFtRDs7SUFDbkQsMkNBQTBDOztJQUUxQywrQ0FBcUI7O0lBQ3JCLHdDQUE2Qjs7Ozs7SUFFN0IsMENBQXFDOztJQThCckMsOENBTUU7O0lBRUYsOENBS0U7Ozs7O0lBekNVLGtEQUEwQzs7Ozs7SUFBRSxzQ0FBOEIiLCJzb3VyY2VzQ29udGVudCI6WyIvKipcbiAqIEBsaWNlbnNlXG4gKiBDb3B5cmlnaHQgQWxpYmFiYS5jb20gQWxsIFJpZ2h0cyBSZXNlcnZlZC5cbiAqXG4gKiBVc2Ugb2YgdGhpcyBzb3VyY2UgY29kZSBpcyBnb3Zlcm5lZCBieSBhbiBNSVQtc3R5bGUgbGljZW5zZSB0aGF0IGNhbiBiZVxuICogZm91bmQgaW4gdGhlIExJQ0VOU0UgZmlsZSBhdCBodHRwczovL2dpdGh1Yi5jb20vTkctWk9SUk8vbmctem9ycm8tYW50ZC9ibG9iL21hc3Rlci9MSUNFTlNFXG4gKi9cblxuaW1wb3J0IHtcbiAgQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3ksXG4gIENoYW5nZURldGVjdG9yUmVmLFxuICBDb21wb25lbnQsXG4gIElucHV0LFxuICBPbkNoYW5nZXMsXG4gIE9uRGVzdHJveSxcbiAgU2ltcGxlQ2hhbmdlcyxcbiAgVmlld0NoaWxkLFxuICBWaWV3RW5jYXBzdWxhdGlvblxufSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IFN1YnNjcmlwdGlvbiB9IGZyb20gJ3J4anMnO1xuXG5pbXBvcnQgeyBJbnB1dEJvb2xlYW4sIE5HU3R5bGVJbnRlcmZhY2UgfSBmcm9tICduZy16b3Jyby1hbnRkL2NvcmUnO1xuaW1wb3J0IHsgTnpUb29sVGlwQ29tcG9uZW50IH0gZnJvbSAnbmctem9ycm8tYW50ZC90b29sdGlwJztcblxuaW1wb3J0IHsgU2xpZGVyU2hvd1Rvb2x0aXAgfSBmcm9tICcuL256LXNsaWRlci1kZWZpbml0aW9ucyc7XG5pbXBvcnQgeyBOelNsaWRlckNvbXBvbmVudCB9IGZyb20gJy4vbnotc2xpZGVyLmNvbXBvbmVudCc7XG5cbkBDb21wb25lbnQoe1xuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbiAgZW5jYXBzdWxhdGlvbjogVmlld0VuY2Fwc3VsYXRpb24uTm9uZSxcbiAgc2VsZWN0b3I6ICduei1zbGlkZXItaGFuZGxlJyxcbiAgZXhwb3J0QXM6ICduelNsaWRlckhhbmRsZScsXG4gIHByZXNlcnZlV2hpdGVzcGFjZXM6IGZhbHNlLFxuICB0ZW1wbGF0ZVVybDogJy4vbnotc2xpZGVyLWhhbmRsZS5jb21wb25lbnQuaHRtbCcsXG4gIGhvc3Q6IHtcbiAgICAnKG1vdXNlZW50ZXIpJzogJ2VudGVySGFuZGxlKCknLFxuICAgICcobW91c2VsZWF2ZSknOiAnbGVhdmVIYW5kbGUoKSdcbiAgfVxufSlcbmV4cG9ydCBjbGFzcyBOelNsaWRlckhhbmRsZUNvbXBvbmVudCBpbXBsZW1lbnRzIE9uQ2hhbmdlcywgT25EZXN0cm95IHtcbiAgQFZpZXdDaGlsZChOelRvb2xUaXBDb21wb25lbnQpIHRvb2x0aXA6IE56VG9vbFRpcENvbXBvbmVudDtcblxuICBASW5wdXQoKSBuelZlcnRpY2FsOiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56T2Zmc2V0OiBudW1iZXI7XG4gIEBJbnB1dCgpIG56VmFsdWU6IG51bWJlcjtcbiAgQElucHV0KCkgbnpUb29sdGlwVmlzaWJsZTogU2xpZGVyU2hvd1Rvb2x0aXAgPSAnZGVmYXVsdCc7XG4gIEBJbnB1dCgpIG56VGlwRm9ybWF0dGVyOiAodmFsdWU6IG51bWJlcikgPT4gc3RyaW5nO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpBY3RpdmUgPSBmYWxzZTtcblxuICB0b29sdGlwVGl0bGU6IHN0cmluZztcbiAgc3R5bGU6IE5HU3R5bGVJbnRlcmZhY2UgPSB7fTtcblxuICBwcml2YXRlIGhvdmVyc18gPSBuZXcgU3Vic2NyaXB0aW9uKCk7XG5cbiAgY29uc3RydWN0b3IocHJpdmF0ZSBzbGlkZXJDb21wb25lbnQ6IE56U2xpZGVyQ29tcG9uZW50LCBwcml2YXRlIGNkcjogQ2hhbmdlRGV0ZWN0b3JSZWYpIHt9XG5cbiAgbmdPbkNoYW5nZXMoY2hhbmdlczogU2ltcGxlQ2hhbmdlcyk6IHZvaWQge1xuICAgIGNvbnN0IHsgbnpPZmZzZXQsIG56VmFsdWUsIG56QWN0aXZlLCBuelRvb2x0aXBWaXNpYmxlIH0gPSBjaGFuZ2VzO1xuXG4gICAgaWYgKG56T2Zmc2V0KSB7XG4gICAgICB0aGlzLnVwZGF0ZVN0eWxlKCk7XG4gICAgfVxuICAgIGlmIChuelZhbHVlKSB7XG4gICAgICB0aGlzLnVwZGF0ZVRvb2x0aXBUaXRsZSgpO1xuICAgICAgdGhpcy51cGRhdGVUb29sdGlwUG9zaXRpb24oKTtcbiAgICB9XG4gICAgaWYgKG56QWN0aXZlKSB7XG4gICAgICBpZiAobnpBY3RpdmUuY3VycmVudFZhbHVlKSB7XG4gICAgICAgIHRoaXMudG9nZ2xlVG9vbHRpcCh0cnVlKTtcbiAgICAgIH0gZWxzZSB7XG4gICAgICAgIHRoaXMudG9nZ2xlVG9vbHRpcChmYWxzZSk7XG4gICAgICB9XG4gICAgfVxuICAgIGlmIChuelRvb2x0aXBWaXNpYmxlICYmIG56VG9vbHRpcFZpc2libGUuY3VycmVudFZhbHVlID09PSAnYWx3YXlzJykge1xuICAgICAgUHJvbWlzZS5yZXNvbHZlKCkudGhlbigoKSA9PiB0aGlzLnRvZ2dsZVRvb2x0aXAodHJ1ZSwgdHJ1ZSkpO1xuICAgIH1cbiAgfVxuXG4gIG5nT25EZXN0cm95KCk6IHZvaWQge1xuICAgIHRoaXMuaG92ZXJzXy51bnN1YnNjcmliZSgpO1xuICB9XG5cbiAgZW50ZXJIYW5kbGUgPSAoKSA9PiB7XG4gICAgaWYgKCF0aGlzLnNsaWRlckNvbXBvbmVudC5pc0RyYWdnaW5nKSB7XG4gICAgICB0aGlzLnRvZ2dsZVRvb2x0aXAodHJ1ZSk7XG4gICAgICB0aGlzLnVwZGF0ZVRvb2x0aXBQb3NpdGlvbigpO1xuICAgICAgdGhpcy5jZHIuZGV0ZWN0Q2hhbmdlcygpO1xuICAgIH1cbiAgfTtcblxuICBsZWF2ZUhhbmRsZSA9ICgpID0+IHtcbiAgICBpZiAoIXRoaXMuc2xpZGVyQ29tcG9uZW50LmlzRHJhZ2dpbmcpIHtcbiAgICAgIHRoaXMudG9nZ2xlVG9vbHRpcChmYWxzZSk7XG4gICAgICB0aGlzLmNkci5kZXRlY3RDaGFuZ2VzKCk7XG4gICAgfVxuICB9O1xuXG4gIHByaXZhdGUgdG9nZ2xlVG9vbHRpcChzaG93OiBib29sZWFuLCBmb3JjZTogYm9vbGVhbiA9IGZhbHNlKTogdm9pZCB7XG4gICAgaWYgKCFmb3JjZSAmJiAodGhpcy5uelRvb2x0aXBWaXNpYmxlICE9PSAnZGVmYXVsdCcgfHwgIXRoaXMudG9vbHRpcCkpIHtcbiAgICAgIHJldHVybjtcbiAgICB9XG5cbiAgICBpZiAoc2hvdykge1xuICAgICAgdGhpcy50b29sdGlwLnNob3coKTtcbiAgICB9IGVsc2Uge1xuICAgICAgdGhpcy50b29sdGlwLmhpZGUoKTtcbiAgICB9XG4gIH1cblxuICBwcml2YXRlIHVwZGF0ZVRvb2x0aXBUaXRsZSgpOiB2b2lkIHtcbiAgICB0aGlzLnRvb2x0aXBUaXRsZSA9IHRoaXMubnpUaXBGb3JtYXR0ZXIgPyB0aGlzLm56VGlwRm9ybWF0dGVyKHRoaXMubnpWYWx1ZSkgOiBgJHt0aGlzLm56VmFsdWV9YDtcbiAgfVxuXG4gIHByaXZhdGUgdXBkYXRlVG9vbHRpcFBvc2l0aW9uKCk6IHZvaWQge1xuICAgIGlmICh0aGlzLnRvb2x0aXApIHtcbiAgICAgIFByb21pc2UucmVzb2x2ZSgpLnRoZW4oKCkgPT4gdGhpcy50b29sdGlwLnVwZGF0ZVBvc2l0aW9uKCkpO1xuICAgIH1cbiAgfVxuXG4gIHByaXZhdGUgdXBkYXRlU3R5bGUoKTogdm9pZCB7XG4gICAgdGhpcy5zdHlsZVt0aGlzLm56VmVydGljYWwgPyAnYm90dG9tJyA6ICdsZWZ0J10gPSBgJHt0aGlzLm56T2Zmc2V0fSVgO1xuICB9XG59XG4iXX0=