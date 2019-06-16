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
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, EventEmitter, Host, Input, NgZone, Optional, Output, Renderer2, TemplateRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';
import { Platform } from '@angular/cdk/platform';
import { fromEvent, Subject } from 'rxjs';
import { auditTime, takeUntil } from 'rxjs/operators';
import { InputBoolean } from 'ng-zorro-antd/core';
import { NzLayoutComponent } from './nz-layout.component';
var NzSiderComponent = /** @class */ (function () {
    function NzSiderComponent(nzLayoutComponent, mediaMatcher, ngZone, platform, cdr, renderer, elementRef) {
        this.nzLayoutComponent = nzLayoutComponent;
        this.mediaMatcher = mediaMatcher;
        this.ngZone = ngZone;
        this.platform = platform;
        this.cdr = cdr;
        this.below = false;
        this.destroy$ = new Subject();
        this.dimensionMap = {
            xs: '480px',
            sm: '576px',
            md: '768px',
            lg: '992px',
            xl: '1200px',
            xxl: '1600px'
        };
        this.nzWidth = 200;
        this.nzTheme = 'dark';
        this.nzCollapsedWidth = 80;
        this.nzReverseArrow = false;
        this.nzCollapsible = false;
        this.nzCollapsed = false;
        this.nzCollapsedChange = new EventEmitter();
        renderer.addClass(elementRef.nativeElement, 'ant-layout-sider');
    }
    Object.defineProperty(NzSiderComponent.prototype, "flexSetting", {
        get: /**
         * @return {?}
         */
        function () {
            if (this.nzCollapsed) {
                return "0 0 " + this.nzCollapsedWidth + "px";
            }
            else {
                return "0 0 " + this.nzWidth + "px";
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzSiderComponent.prototype, "widthSetting", {
        get: /**
         * @return {?}
         */
        function () {
            if (this.nzCollapsed) {
                return this.nzCollapsedWidth;
            }
            else {
                return this.nzWidth;
            }
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    NzSiderComponent.prototype.watchMatchMedia = /**
     * @return {?}
     */
    function () {
        var _this = this;
        if (this.nzBreakpoint) {
            /** @type {?} */
            var matchBelow = this.mediaMatcher.matchMedia("(max-width: " + this.dimensionMap[this.nzBreakpoint] + ")").matches;
            this.below = matchBelow;
            this.nzCollapsed = matchBelow;
            this.nzCollapsedChange.emit(matchBelow);
            this.ngZone.run((/**
             * @return {?}
             */
            function () {
                _this.cdr.markForCheck();
            }));
        }
    };
    /**
     * @return {?}
     */
    NzSiderComponent.prototype.toggleCollapse = /**
     * @return {?}
     */
    function () {
        this.nzCollapsed = !this.nzCollapsed;
        this.nzCollapsedChange.emit(this.nzCollapsed);
    };
    Object.defineProperty(NzSiderComponent.prototype, "isZeroTrigger", {
        get: /**
         * @return {?}
         */
        function () {
            return (this.nzCollapsible &&
                this.nzTrigger &&
                this.nzCollapsedWidth === 0 &&
                ((this.nzBreakpoint && this.below) || !this.nzBreakpoint));
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzSiderComponent.prototype, "isSiderTrigger", {
        get: /**
         * @return {?}
         */
        function () {
            return this.nzCollapsible && this.nzTrigger && this.nzCollapsedWidth !== 0;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    NzSiderComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        if (this.nzLayoutComponent) {
            this.nzLayoutComponent.initSider();
        }
    };
    /**
     * @return {?}
     */
    NzSiderComponent.prototype.ngAfterViewInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        if (this.platform.isBrowser) {
            Promise.resolve().then((/**
             * @return {?}
             */
            function () { return _this.watchMatchMedia(); }));
            this.ngZone.runOutsideAngular((/**
             * @return {?}
             */
            function () {
                fromEvent(window, 'resize')
                    .pipe(auditTime(16), takeUntil(_this.destroy$))
                    .subscribe((/**
                 * @return {?}
                 */
                function () { return _this.watchMatchMedia(); }));
            }));
        }
    };
    /**
     * @return {?}
     */
    NzSiderComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.destroy$.next();
        this.destroy$.complete();
        if (this.nzLayoutComponent) {
            this.nzLayoutComponent.destroySider();
        }
    };
    NzSiderComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-sider',
                    exportAs: 'nzSider',
                    preserveWhitespaces: false,
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    template: "<div class=\"ant-layout-sider-children\">\n  <ng-content></ng-content>\n</div>\n<span class=\"ant-layout-sider-zero-width-trigger\" *ngIf=\"isZeroTrigger\" (click)=\"toggleCollapse()\">\n  <ng-template [ngTemplateOutlet]=\"nzZeroTrigger || zeroTrigger\"></ng-template>\n</span>\n<div class=\"ant-layout-sider-trigger\"\n  *ngIf=\"isSiderTrigger\"\n  (click)=\"toggleCollapse()\"\n  [style.width.px]=\"nzCollapsed ? nzCollapsedWidth : nzWidth\">\n  <ng-template [ngTemplateOutlet]=\"nzTrigger\"></ng-template>\n</div>\n<ng-template #defaultTrigger>\n  <i nz-icon [type]=\"nzCollapsed ? 'right' : 'left'\" *ngIf=\"!nzReverseArrow\"></i>\n  <i nz-icon [type]=\"nzCollapsed ? 'left' : 'right'\" *ngIf=\"nzReverseArrow\"></i>\n</ng-template>\n<ng-template #zeroTrigger>\n  <i nz-icon type=\"bars\"></i>\n</ng-template>",
                    host: {
                        '[class.ant-layout-sider-zero-width]': 'nzCollapsed && nzCollapsedWidth === 0',
                        '[class.ant-layout-sider-light]': "nzTheme === 'light'",
                        '[class.ant-layout-sider-collapsed]': 'nzCollapsed',
                        '[style.flex]': 'flexSetting',
                        '[style.max-width.px]': 'widthSetting',
                        '[style.min-width.px]': 'widthSetting',
                        '[style.width.px]': 'widthSetting'
                    }
                }] }
    ];
    /** @nocollapse */
    NzSiderComponent.ctorParameters = function () { return [
        { type: NzLayoutComponent, decorators: [{ type: Optional }, { type: Host }] },
        { type: MediaMatcher },
        { type: NgZone },
        { type: Platform },
        { type: ChangeDetectorRef },
        { type: Renderer2 },
        { type: ElementRef }
    ]; };
    NzSiderComponent.propDecorators = {
        nzWidth: [{ type: Input }],
        nzTheme: [{ type: Input }],
        nzCollapsedWidth: [{ type: Input }],
        nzBreakpoint: [{ type: Input }],
        nzZeroTrigger: [{ type: Input }],
        nzTrigger: [{ type: Input }, { type: ViewChild, args: ['defaultTrigger',] }],
        nzReverseArrow: [{ type: Input }],
        nzCollapsible: [{ type: Input }],
        nzCollapsed: [{ type: Input }],
        nzCollapsedChange: [{ type: Output }]
    };
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzSiderComponent.prototype, "nzReverseArrow", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzSiderComponent.prototype, "nzCollapsible", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzSiderComponent.prototype, "nzCollapsed", void 0);
    return NzSiderComponent;
}());
export { NzSiderComponent };
if (false) {
    /**
     * @type {?}
     * @private
     */
    NzSiderComponent.prototype.below;
    /**
     * @type {?}
     * @private
     */
    NzSiderComponent.prototype.destroy$;
    /**
     * @type {?}
     * @private
     */
    NzSiderComponent.prototype.dimensionMap;
    /** @type {?} */
    NzSiderComponent.prototype.nzWidth;
    /** @type {?} */
    NzSiderComponent.prototype.nzTheme;
    /** @type {?} */
    NzSiderComponent.prototype.nzCollapsedWidth;
    /** @type {?} */
    NzSiderComponent.prototype.nzBreakpoint;
    /** @type {?} */
    NzSiderComponent.prototype.nzZeroTrigger;
    /** @type {?} */
    NzSiderComponent.prototype.nzTrigger;
    /** @type {?} */
    NzSiderComponent.prototype.nzReverseArrow;
    /** @type {?} */
    NzSiderComponent.prototype.nzCollapsible;
    /** @type {?} */
    NzSiderComponent.prototype.nzCollapsed;
    /** @type {?} */
    NzSiderComponent.prototype.nzCollapsedChange;
    /**
     * @type {?}
     * @private
     */
    NzSiderComponent.prototype.nzLayoutComponent;
    /**
     * @type {?}
     * @private
     */
    NzSiderComponent.prototype.mediaMatcher;
    /**
     * @type {?}
     * @private
     */
    NzSiderComponent.prototype.ngZone;
    /**
     * @type {?}
     * @private
     */
    NzSiderComponent.prototype.platform;
    /**
     * @type {?}
     * @private
     */
    NzSiderComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotc2lkZXIuY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC9sYXlvdXQvIiwic291cmNlcyI6WyJuei1zaWRlci5jb21wb25lbnQudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7O0FBUUEsT0FBTyxFQUVMLHVCQUF1QixFQUN2QixpQkFBaUIsRUFDakIsU0FBUyxFQUNULFVBQVUsRUFDVixZQUFZLEVBQ1osSUFBSSxFQUNKLEtBQUssRUFDTCxNQUFNLEVBR04sUUFBUSxFQUNSLE1BQU0sRUFDTixTQUFTLEVBQ1QsV0FBVyxFQUNYLFNBQVMsRUFDVCxpQkFBaUIsRUFDbEIsTUFBTSxlQUFlLENBQUM7QUFFdkIsT0FBTyxFQUFFLFlBQVksRUFBRSxNQUFNLHFCQUFxQixDQUFDO0FBQ25ELE9BQU8sRUFBRSxRQUFRLEVBQUUsTUFBTSx1QkFBdUIsQ0FBQztBQUNqRCxPQUFPLEVBQUUsU0FBUyxFQUFFLE9BQU8sRUFBRSxNQUFNLE1BQU0sQ0FBQztBQUMxQyxPQUFPLEVBQUUsU0FBUyxFQUFFLFNBQVMsRUFBRSxNQUFNLGdCQUFnQixDQUFDO0FBRXRELE9BQU8sRUFBRSxZQUFZLEVBQUUsTUFBTSxvQkFBb0IsQ0FBQztBQUVsRCxPQUFPLEVBQUUsaUJBQWlCLEVBQUUsTUFBTSx1QkFBdUIsQ0FBQztBQUkxRDtJQXFGRSwwQkFDOEIsaUJBQW9DLEVBQ3hELFlBQTBCLEVBQzFCLE1BQWMsRUFDZCxRQUFrQixFQUNsQixHQUFzQixFQUM5QixRQUFtQixFQUNuQixVQUFzQjtRQU5NLHNCQUFpQixHQUFqQixpQkFBaUIsQ0FBbUI7UUFDeEQsaUJBQVksR0FBWixZQUFZLENBQWM7UUFDMUIsV0FBTSxHQUFOLE1BQU0sQ0FBUTtRQUNkLGFBQVEsR0FBUixRQUFRLENBQVU7UUFDbEIsUUFBRyxHQUFILEdBQUcsQ0FBbUI7UUF4RXhCLFVBQUssR0FBRyxLQUFLLENBQUM7UUFDZCxhQUFRLEdBQUcsSUFBSSxPQUFPLEVB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c0IsRUFBRSxjQUFjO3dCQUN0QyxzQkFBc0IsRUFBRSxjQUFjO3dCQUN0QyxrQkFBa0IsRUFBRSxjQUFjO3FCQUNuQztpQkFDRjs7OztnQkFwQlEsaUJBQWlCLHVCQTBGckIsUUFBUSxZQUFJLElBQUk7Z0JBakdaLFlBQVk7Z0JBWG5CLE1BQU07Z0JBWUMsUUFBUTtnQkFsQmYsaUJBQWlCO2dCQVdqQixTQUFTO2dCQVRULFVBQVU7OzswQkFzRFQsS0FBSzswQkFDTCxLQUFLO21DQUNMLEtBQUs7K0JBQ0wsS0FBSztnQ0FDTCxLQUFLOzRCQUNMLEtBQUssWUFBSSxTQUFTLFNBQUMsZ0JBQWdCO2lDQUNuQyxLQUFLO2dDQUNMLEtBQUs7OEJBQ0wsS0FBSztvQ0FDTCxNQUFNOztJQUhrQjtRQUFmLFlBQVksRUFBRTs7NERBQXdCO0lBQ3ZCO1FBQWYsWUFBWSxFQUFFOzsyREFBdUI7SUFDdEI7UUFBZixZQUFZLEVBQUU7O3lEQUFxQjtJQXdGL0MsdUJBQUM7Q0FBQSxBQTVIRCxJQTRIQztTQTNHWSxnQkFBZ0I7Ozs7OztJQUMzQixpQ0FBc0I7Ozs7O0lBQ3RCLG9DQUFpQzs7Ozs7SUFDakMsd0NBT0U7O0lBQ0YsbUNBQXVCOztJQUN2QixtQ0FBNEM7O0lBQzVDLDRDQUErQjs7SUFDL0Isd0NBQW9DOztJQUNwQyx5Q0FBMEM7O0lBQzFDLHFDQUFtRTs7SUFDbkUsMENBQWdEOztJQUNoRCx5Q0FBK0M7O0lBQy9DLHVDQUE2Qzs7SUFDN0MsNkNBQTBEOzs7OztJQWlEeEQsNkNBQWdFOzs7OztJQUNoRSx3Q0FBa0M7Ozs7O0lBQ2xDLGtDQUFzQjs7Ozs7SUFDdEIsb0NBQTBCOzs7OztJQUMxQiwrQkFBOEIiLCJzb3VyY2VzQ29udGVudCI6WyIvKipcbiAqIEBsaWNlbnNlXG4gKiBDb3B5cmlnaHQgQWxpYmFiYS5jb20gQWxsIFJpZ2h0cyBSZXNlcnZlZC5cbiAqXG4gKiBVc2Ugb2YgdGhpcyBzb3VyY2UgY29kZSBpcyBnb3Zlcm5lZCBieSBhbiBNSVQtc3R5bGUgbGljZW5zZSB0aGF0IGNhbiBiZVxuICogZm91bmQgaW4gdGhlIExJQ0VOU0UgZmlsZSBhdCBodHRwczovL2dpdGh1Yi5jb20vTkctWk9SUk8vbmctem9ycm8tYW50ZC9ibG9iL21hc3Rlci9MSUNFTlNFXG4gKi9cblxuaW1wb3J0IHtcbiAgQWZ0ZXJWaWV3SW5pdCxcbiAgQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3ksXG4gIENoYW5nZURldGVjdG9yUmVmLFxuICBDb21wb25lbnQsXG4gIEVsZW1lbnRSZWYsXG4gIEV2ZW50RW1pdHRlcixcbiAgSG9zdCxcbiAgSW5wdXQsXG4gIE5nWm9uZSxcbiAgT25EZXN0cm95LFxuICBPbkluaXQsXG4gIE9wdGlvbmFsLFxuICBPdXRwdXQsXG4gIFJlbmRlcmVyMixcbiAgVGVtcGxhdGVSZWYsXG4gIFZpZXdDaGlsZCxcbiAgVmlld0VuY2Fwc3VsYXRpb25cbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmltcG9ydCB7IE1lZGlhTWF0Y2hlciB9IGZyb20gJ0Bhbmd1bGFyL2Nkay9sYXlvdXQnO1xuaW1wb3J0IHsgUGxhdGZvcm0gfSBmcm9tICdAYW5ndWxhci9jZGsvcGxhdGZvcm0nO1xuaW1wb3J0IHsgZnJvbUV2ZW50LCBTdWJqZWN0IH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyBhdWRpdFRpbWUsIHRha2VVbnRpbCB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuaW1wb3J0IHsgSW5wdXRCb29sZWFuIH0gZnJvbSAnbmctem9ycm8tYW50ZC9jb3JlJztcblxuaW1wb3J0IHsgTnpMYXlvdXRDb21wb25lbnQgfSBmcm9tICcuL256LWxheW91dC5jb21wb25lbnQnO1xuXG5leHBvcnQgdHlwZSBOekJyZWFrUG9pbnQgPSAneHMnIHwgJ3NtJyB8ICdtZCcgfCAnbGcnIHwgJ3hsJyB8ICd4eGwnO1xuXG5AQ29tcG9uZW50KHtcbiAgc2VsZWN0b3I6ICduei1zaWRlcicsXG4gIGV4cG9ydEFzOiAnbnpTaWRlcicsXG4gIHByZXNlcnZlV2hpdGVzcGFjZXM6IGZhbHNlLFxuICBlbmNhcHN1bGF0aW9uOiBWaWV3RW5jYXBzdWxhdGlvbi5Ob25lLFxuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbiAgdGVtcGxhdGVVcmw6ICcuL256LXNpZGVyLmNvbXBvbmVudC5odG1sJyxcbiAgaG9zdDoge1xuICAgICdbY2xhc3MuYW50LWxheW91dC1zaWRlci16ZXJvLXdpZHRoXSc6ICduekNvbGxhcHNlZCAmJiBuekNvbGxhcHNlZFdpZHRoID09PSAwJyxcbiAgICAnW2NsYXNzLmFudC1sYXlvdXQtc2lkZXItbGlnaHRdJzogYG56VGhlbWUgPT09ICdsaWdodCdgLFxuICAgICdbY2xhc3MuYW50LWxheW91dC1zaWRlci1jb2xsYXBzZWRdJzogJ256Q29sbGFwc2VkJyxcbiAgICAnW3N0eWxlLmZsZXhdJzogJ2ZsZXhTZXR0aW5nJyxcbiAgICAnW3N0eWxlLm1heC13aWR0aC5weF0nOiAnd2lkdGhTZXR0aW5nJyxcbiAgICAnW3N0eWxlLm1pbi13aWR0aC5weF0nOiAnd2lkdGhTZXR0aW5nJyxcbiAgICAnW3N0eWxlLndpZHRoLnB4XSc6ICd3aWR0aFNldHRpbmcnXG4gIH1cbn0pXG5leHBvcnQgY2xhc3MgTnpTaWRlckNvbXBvbmVudCBpbXBsZW1lbnRzIE9uSW5pdCwgQWZ0ZXJWaWV3SW5pdCwgT25EZXN0cm95IHtcbiAgcHJpdmF0ZSBiZWxvdyA9IGZhbHNlO1xuICBwcml2YXRlIGRlc3Ryb3kkID0gbmV3IFN1YmplY3QoKTtcbiAgcHJpdmF0ZSBkaW1lbnNpb25NYXAgPSB7XG4gICAgeHM6ICc0ODBweCcsXG4gICAgc206ICc1NzZweCcsXG4gICAgbWQ6ICc3NjhweCcsXG4gICAgbGc6ICc5OTJweCcsXG4gICAgeGw6ICcxMjAwcHgnLFxuICAgIHh4bDogJzE2MDBweCdcbiAgfTtcbiAgQElucHV0KCkgbnpXaWR0aCA9IDIwMDtcbiAgQElucHV0KCkgbnpUaGVtZTogJ2xpZ2h0JyB8ICdkYXJrJyA9ICdkYXJrJztcbiAgQElucHV0KCkgbnpDb2xsYXBzZWRXaWR0aCA9IDgwO1xuICBASW5wdXQoKSBuekJyZWFrcG9pbnQ6IE56QnJlYWtQb2ludDtcbiAgQElucHV0KCkgbnpaZXJvVHJpZ2dlcjogVGVtcGxhdGVSZWY8dm9pZD47XG4gIEBJbnB1dCgpIEBWaWV3Q2hpbGQoJ2RlZmF1bHRUcmlnZ2VyJykgbnpUcmlnZ2VyOiBUZW1wbGF0ZVJlZjx2b2lkPjtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56UmV2ZXJzZUFycm93ID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekNvbGxhcHNpYmxlID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekNvbGxhcHNlZCA9IGZhbHNlO1xuICBAT3V0cHV0KCkgcmVhZG9ubHkgbnpDb2xsYXBzZWRDaGFuZ2UgPSBuZXcgRXZlbnRFbWl0dGVyKCk7XG5cbiAgZ2V0IGZsZXhTZXR0aW5nKCk6IHN0cmluZyB7XG4gICAgaWYgKHRoaXMubnpDb2xsYXBzZWQpIHtcbiAgICAgIHJldHVybiBgMCAwICR7dGhpcy5uekNvbGxhcHNlZFdpZHRofXB4YDtcbiAgICB9IGVsc2Uge1xuICAgICAgcmV0dXJuIGAwIDAgJHt0aGlzLm56V2lkdGh9cHhgO1xuICAgIH1cbiAgfVxuXG4gIGdldCB3aWR0aFNldHRpbmcoKTogbnVtYmVyIHtcbiAgICBpZiAodGhpcy5uekNvbGxhcHNlZCkge1xuICAgICAgcmV0dXJuIHRoaXMubnpDb2xsYXBzZWRXaWR0aDtcbiAgICB9IGVsc2Uge1xuICAgICAgcmV0dXJuIHRoaXMubnpXaWR0aDtcbiAgICB9XG4gIH1cblxuICB3YXRjaE1hdGNoTWVkaWEoKTogdm9pZCB7XG4gICAgaWYgKHRoaXMubnpCcmVha3BvaW50KSB7XG4gICAgICBjb25zdCBtYXRjaEJlbG93ID0gdGhpcy5tZWRpYU1hdGNoZXIubWF0Y2hNZWRpYShgKG1heC13aWR0aDogJHt0aGlzLmRpbWVuc2lvbk1hcFt0aGlzLm56QnJlYWtwb2ludF19KWApLm1hdGNoZXM7XG4gICAgICB0aGlzLmJlbG93ID0gbWF0Y2hCZWxvdztcbiAgICAgIHRoaXMubnpDb2xsYXBzZWQgPSBtYXRjaEJlbG93O1xuICAgICAgdGhpcy5uekNvbGxhcHNlZENoYW5nZS5lbWl0KG1hdGNoQmVsb3cpO1xuICAgICAgdGhpcy5uZ1pvbmUucnVuKCgpID0+IHtcbiAgICAgICAgdGhpcy5jZHIubWFya0ZvckNoZWNrKCk7XG4gICAgICB9KTtcbiAgICB9XG4gIH1cblxuICB0b2dnbGVDb2xsYXBzZSgpOiB2b2lkIHtcbiAgICB0aGlzLm56Q29sbGFwc2VkID0gIXRoaXMubnpDb2xsYXBzZWQ7XG4gICAgdGhpcy5uekNvbGxhcHNlZENoYW5nZS5lbWl0KHRoaXMubnpDb2xsYXBzZWQpO1xuICB9XG5cbiAgZ2V0IGlzWmVyb1RyaWdnZXIoKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIChcbiAgICAgIHRoaXMubnpDb2xsYXBzaWJsZSAmJlxuICAgICAgdGhpcy5uelRyaWdnZXIgJiZcbiAgICAgIHRoaXMubnpDb2xsYXBzZWRXaWR0aCA9PT0gMCAmJlxuICAgICAgKCh0aGlzLm56QnJlYWtwb2ludCAmJiB0aGlzLmJlbG93KSB8fCAhdGhpcy5uekJyZWFrcG9pbnQpXG4gICAgKTtcbiAgfVxuXG4gIGdldCBpc1NpZGVyVHJpZ2dlcigpOiBib29sZWFuIHtcbiAgICByZXR1cm4gdGhpcy5uekNvbGxhcHNpYmxlICYmIHRoaXMubnpUcmlnZ2VyICYmIHRoaXMubnpDb2xsYXBzZWRXaWR0aCAhPT0gMDtcbiAgfVxuXG4gIGNvbnN0cnVjdG9yKFxuICAgIEBPcHRpb25hbCgpIEBIb3N0KCkgcHJpdmF0ZSBuekxheW91dENvbXBvbmVudDogTnpMYXlvdXRDb21wb25lbnQsXG4gICAgcHJpdmF0ZSBtZWRpYU1hdGNoZXI6IE1lZGlhTWF0Y2hlcixcbiAgICBwcml2YXRlIG5nWm9uZTogTmdab25lLFxuICAgIHByaXZhdGUgcGxhdGZvcm06IFBsYXRmb3JtLFxuICAgIHByaXZhdGUgY2RyOiBDaGFuZ2VEZXRlY3RvclJlZixcbiAgICByZW5kZXJlcjogUmVuZGVyZXIyLFxuICAgIGVsZW1lbnRSZWY6IEVsZW1lbnRSZWZcbiAgKSB7XG4gICAgcmVuZGVyZXIuYWRkQ2xhc3MoZWxlbWVudFJlZi5uYXRpdmVFbGVtZW50LCAnYW50LWxheW91dC1zaWRlcicpO1xuICB9XG5cbiAgbmdPbkluaXQoKTogdm9pZCB7XG4gICAgaWYgKHRoaXMubnpMYXlvdXRDb21wb25lbnQpIHtcbiAgICAgIHRoaXMubnpMYXlvdXRDb21wb25lbnQuaW5pdFNpZGVyKCk7XG4gICAgfVxuICB9XG5cbiAgbmdBZnRlclZpZXdJbml0KCk6IHZvaWQge1xuICAgIGlmICh0aGlzLnBsYXRmb3JtLmlzQnJvd3Nlcikge1xuICAgICAgUHJvbWlzZS5yZXNvbHZlKCkudGhlbigoKSA9PiB0aGlzLndhdGNoTWF0Y2hNZWRpYSgpKTtcbiAgICAgIHRoaXMubmdab25lLnJ1bk91dHNpZGVBbmd1bGFyKCgpID0+IHtcbiAgICAgICAgZnJvbUV2ZW50KHdpbmRvdywgJ3Jlc2l6ZScpXG4gICAgICAgICAgLnBpcGUoXG4gICAgICAgICAgICBhdWRpdFRpbWUoMTYpLFxuICAgICAgICAgICAgdGFrZVVudGlsKHRoaXMuZGVzdHJveSQpXG4gICAgICAgICAgKVxuICAgICAgICAgIC5zdWJzY3JpYmUoKCkgPT4gdGhpcy53YXRjaE1hdGNoTWVkaWEoKSk7XG4gICAgICB9KTtcbiAgICB9XG4gIH1cblxuICBuZ09uRGVzdHJveSgpOiB2b2lkIHtcbiAgICB0aGlzLmRlc3Ryb3kkLm5leHQoKTtcbiAgICB0aGlzLmRlc3Ryb3kkLmNvbXBsZXRlKCk7XG4gICAgaWYgKHRoaXMubnpMYXlvdXRDb21wb25lbnQpIHtcbiAgICAgIHRoaXMubnpMYXlvdXRDb21wb25lbnQuZGVzdHJveVNpZGVyKCk7XG4gICAgfVxuICB9XG59XG4iXX0=