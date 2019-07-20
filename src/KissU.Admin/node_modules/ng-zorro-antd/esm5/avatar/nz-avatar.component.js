/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { Platform } from '@angular/cdk/platform';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, Input, Renderer2, ViewChild, ViewEncapsulation } from '@angular/core';
import { NzUpdateHostClassService } from 'ng-zorro-antd/core';
/**
 * @record
 */
export function NzAvatarSizeMap() { }
var NzAvatarComponent = /** @class */ (function () {
    function NzAvatarComponent(elementRef, cd, updateHostClassService, renderer, platform) {
        this.elementRef = elementRef;
        this.cd = cd;
        this.updateHostClassService = updateHostClassService;
        this.renderer = renderer;
        this.platform = platform;
        this.nzShape = 'circle';
        this.nzSize = 'default';
        this.oldAPIIcon = true; // Make the user defined icon compatible to old API. Should be removed in 2.0.
        // Make the user defined icon compatible to old API. Should be removed in 2.0.
        this.hasText = false;
        this.hasSrc = true;
        this.hasIcon = false;
        this.el = this.elementRef.nativeElement;
        this.prefixCls = 'ant-avatar';
        this.sizeMap = { large: 'lg', small: 'sm' };
    }
    /**
     * @template THIS
     * @this {THIS}
     * @return {THIS}
     */
    NzAvatarComponent.prototype.setClass = /**
     * @template THIS
     * @this {THIS}
     * @return {THIS}
     */
    function () {
        var _a;
        /** @type {?} */
        var classMap = (_a = {},
            _a[(/** @type {?} */ (this)).prefixCls] = true,
            _a[(/** @type {?} */ (this)).prefixCls + "-" + (/** @type {?} */ (this)).sizeMap[(/** @type {?} */ (this)).nzSize]] = (/** @type {?} */ (this)).sizeMap[(/** @type {?} */ (this)).nzSize],
            _a[(/** @type {?} */ (this)).prefixCls + "-" + (/** @type {?} */ (this)).nzShape] = (/** @type {?} */ (this)).nzShape,
            _a[(/** @type {?} */ (this)).prefixCls + "-icon"] = (/** @type {?} */ (this)).nzIcon,
            _a[(/** @type {?} */ (this)).prefixCls + "-image"] = (/** @type {?} */ (this)).hasSrc // downgrade after image error
        ,
            _a);
        (/** @type {?} */ (this)).updateHostClassService.updateHostClass((/** @type {?} */ (this)).el, classMap);
        (/** @type {?} */ (this)).cd.detectChanges();
        return (/** @type {?} */ (this));
    };
    /**
     * @return {?}
     */
    NzAvatarComponent.prototype.imgError = /**
     * @return {?}
     */
    function () {
        this.hasSrc = false;
        this.hasIcon = false;
        this.hasText = false;
        if (this.nzIcon) {
            this.hasIcon = true;
        }
        else if (this.nzText) {
            this.hasText = true;
        }
        this.setClass().notifyCalc();
        this.setSizeStyle();
    };
    /**
     * @param {?} changes
     * @return {?}
     */
    NzAvatarComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        if (changes.hasOwnProperty('nzIcon') && changes.nzIcon.currentValue) {
            this.oldAPIIcon = changes.nzIcon.currentValue.indexOf('anticon') > -1;
        }
        this.hasText = !this.nzSrc && !!this.nzText;
        this.hasIcon = !this.nzSrc && !!this.nzIcon;
        this.hasSrc = !!this.nzSrc;
        this.setClass().notifyCalc();
        this.setSizeStyle();
    };
    /**
     * @private
     * @return {?}
     */
    NzAvatarComponent.prototype.calcStringSize = /**
     * @private
     * @return {?}
     */
    function () {
        if (!this.hasText) {
            return;
        }
        /** @type {?} */
        var childrenWidth = this.textEl.nativeElement.offsetWidth;
        /** @type {?} */
        var avatarWidth = this.el.getBoundingClientRect().width;
        /** @type {?} */
        var scale = avatarWidth - 8 < childrenWidth ? (avatarWidth - 8) / childrenWidth : 1;
        this.textStyles = {
            transform: "scale(" + scale + ") translateX(-50%)"
        };
        if (typeof this.nzSize === 'number') {
            Object.assign(this.textStyles, {
                lineHeight: this.nzSize + "px"
            });
        }
        this.cd.detectChanges();
    };
    /**
     * @private
     * @template THIS
     * @this {THIS}
     * @return {THIS}
     */
    NzAvatarComponent.prototype.notifyCalc = /**
     * @private
     * @template THIS
     * @this {THIS}
     * @return {THIS}
     */
    function () {
        var _this = this;
        // If use ngAfterViewChecked, always demands more computations, so......
        if ((/** @type {?} */ (this)).platform.isBrowser) {
            setTimeout((/**
             * @return {?}
             */
            function () {
                (/** @type {?} */ (_this)).calcStringSize();
            }));
        }
        return (/** @type {?} */ (this));
    };
    /**
     * @private
     * @return {?}
     */
    NzAvatarComponent.prototype.setSizeStyle = /**
     * @private
     * @return {?}
     */
    function () {
        if (typeof this.nzSize === 'string') {
            return;
        }
        this.renderer.setStyle(this.el, 'width', this.nzSize + "px");
        this.renderer.setStyle(this.el, 'height', this.nzSize + "px");
        this.renderer.setStyle(this.el, 'line-height', this.nzSize + "px");
        if (this.hasIcon) {
            this.renderer.setStyle(this.el, 'font-size', this.nzSize / 2 + "px");
        }
    };
    NzAvatarComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-avatar',
                    exportAs: 'nzAvatar',
                    template: "<i nz-icon *ngIf=\"nzIcon && hasIcon\" [type]=\"!oldAPIIcon && nzIcon\" [ngClass]=\"oldAPIIcon && nzIcon\"></i>\n<img [src]=\"nzSrc\" *ngIf=\"nzSrc && hasSrc\" (error)=\"imgError()\"/>\n<span class=\"ant-avatar-string\" #textEl [ngStyle]=\"textStyles\" *ngIf=\"nzText && hasText\">{{ nzText }}</span>",
                    providers: [NzUpdateHostClassService],
                    preserveWhitespaces: false,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    encapsulation: ViewEncapsulation.None
                }] }
    ];
    /** @nocollapse */
    NzAvatarComponent.ctorParameters = function () { return [
        { type: ElementRef },
        { type: ChangeDetectorRef },
        { type: NzUpdateHostClassService },
        { type: Renderer2 },
        { type: Platform }
    ]; };
    NzAvatarComponent.propDecorators = {
        nzShape: [{ type: Input }],
        nzSize: [{ type: Input }],
        nzText: [{ type: Input }],
        nzSrc: [{ type: Input }],
        nzIcon: [{ type: Input }],
        textEl: [{ type: ViewChild, args: ['textEl',] }]
    };
    return NzAvatarComponent;
}());
export { NzAvatarComponent };
if (false) {
    /** @type {?} */
    NzAvatarComponent.prototype.nzShape;
    /** @type {?} */
    NzAvatarComponent.prototype.nzSize;
    /** @type {?} */
    NzAvatarComponent.prototype.nzText;
    /** @type {?} */
    NzAvatarComponent.prototype.nzSrc;
    /** @type {?} */
    NzAvatarComponent.prototype.nzIcon;
    /** @type {?} */
    NzAvatarComponent.prototype.oldAPIIcon;
    /** @type {?} */
    NzAvatarComponent.prototype.hasText;
    /** @type {?} */
    NzAvatarComponent.prototype.hasSrc;
    /** @type {?} */
    NzAvatarComponent.prototype.hasIcon;
    /** @type {?} */
    NzAvatarComponent.prototype.textStyles;
    /** @type {?} */
    NzAvatarComponent.prototype.textEl;
    /**
     * @type {?}
     * @private
     */
    NzAvatarComponent.prototype.el;
    /**
     * @type {?}
     * @private
     */
    NzAvatarComponent.prototype.prefixCls;
    /**
     * @type {?}
     * @private
     */
    NzAvatarComponent.prototype.sizeMap;
    /**
     * @type {?}
     * @private
     */
    NzAvatarComponent.prototype.elementRef;
    /**
     * @type {?}
     * @private
     */
    NzAvatarComponent.prototype.cd;
    /**
     * @type {?}
     * @private
     */
    NzAvatarComponent.prototype.updateHostClassService;
    /**
     * @type {?}
     * @private
     */
    NzAvatarComponent.prototype.renderer;
    /**
     * @type {?}
     * @private
     */
    NzAvatarComponent.prototype.platform;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotYXZhdGFyLmNvbXBvbmVudC5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvYXZhdGFyLyIsInNvdXJjZXMiOlsibnotYXZhdGFyLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7OztBQVFBLE9BQU8sRUFBRSxRQUFRLEVBQUUsTUFBTSx1QkFBdUIsQ0FBQztBQUNqRCxPQUFPLEVBQ0wsdUJBQXVCLEVBQ3ZCLGlCQUFpQixFQUNqQixTQUFTLEVBQ1QsVUFBVSxFQUNWLEtBQUssRUFFTCxTQUFTLEVBRVQsU0FBUyxFQUNULGlCQUFpQixFQUNsQixNQUFNLGVBQWUsQ0FBQztBQUV2QixPQUFPLEVBQTRCLHdCQUF3QixFQUFFLE1BQU0sb0JBQW9CLENBQUM7Ozs7QUFLeEYscUNBRUM7QUFFRDtJQTRCRSwyQkFDVSxVQUFzQixFQUN0QixFQUFxQixFQUNyQixzQkFBZ0QsRUFDaEQsUUFBbUIsRUFDbkIsUUFBa0I7UUFKbEIsZUFBVSxHQUFWLFVBQVUsQ0FBWTtRQUN0QixPQUFFLEdBQUYsRUFBRSxDQUFtQjtRQUNyQiwyQkFBc0IsR0FBdEIsc0JBQXNCLENBQTBCO1FBQ2hELGFBQVEsR0FBUixRQUFRLENBQVc7UUFDbkIsYUFBUSxHQUFSLFFBQVEsQ0FBVTtRQXZCbkIsWUFBTyxHQUFrQixRQUFRLENBQUM7UUFDbEMsV0FBTSxHQUFpQixTQUFTLENBQUM7UUFLMUMsZUFBVSxHQUFHLElBQUksQ0FBQyxDQUFDLDhFQUE4RTs7UUFDakcsWUFBTyxHQUFZLEtBQUssQ0FBQztRQUN6QixXQUFNLEdBQVksSUFBSSxDQUFDO1FBQ3ZCLFlBQU8sR0FBWSxLQUFLLENBQUM7UUFLakIsT0FBRSxHQUFnQixJQUFJLENBQUMsVUFBVSxDQUFDLGFBQWEsQ0FBQztRQUNoRCxjQUFTLEdBQUcsWUFBWSxDQUFDO1FBQ3pCLFlBQU8sR0FBYyxFQUFFLEtBQUssRUFBRSxJQUFJLEVBQUUsS0FBSyxFQUFFLElBQUksRUFBRSxDQUFDO0lBUXZELENBQUM7Ozs7OztJQUVKLG9DQUFROzs7OztJQUFSOzs7WUFDUSxRQUFRO1lBQ1osR0FBQyxtQkFBQSxJQUFJLEVBQUEsQ0FBQyxTQUFTLElBQUcsSUFBSTtZQUN0QixHQUFJLG1CQUFBLElBQUksRUFBQSxDQUFDLFNBQVMsU0FBSSxtQkFBQSxJQUFJLEVBQUEsQ0FBQyxPQUFPLENBQUMsbUJBQUEsSUFBSSxFQUFBLENBQUMsTUFBTSxDQUFHLElBQUcsbUJBQUEsSUFBSSxFQUFBLENBQUMsT0FBTyxDQUFDLG1CQUFBLElBQUksRUFBQSxDQUFDLE1BQU0sQ0FBQztZQUM3RSxHQUFJLG1CQUFBLElBQUksRUFBQSxDQUFDLFNBQVMsU0FBSSxtQkFBQSxJQUFJLEVBQUEsQ0FBQyxPQUFTLElBQUcsbUJBQUEsSUFBSSxFQUFBLENBQUMsT0FBTztZQUNuRCxHQUFJLG1CQUFBLElBQUksRUFBQSxDQUFDLFNBQVMsVUFBTyxJQUFHLG1CQUFBLElBQUksRUFBQSxDQUFDLE1BQU07WUFDdkMsR0FBSSxtQkFBQSxJQUFJLEVBQUEsQ0FBQyxTQUFTLFdBQVEsSUFBRyxtQkFBQSxJQUFJLEVBQUEsQ0FBQyxNQUFNLENBQUMsOEJBQThCOztlQUN4RTtRQUNELG1CQUFBLElBQUksRUFBQSxDQUFDLHNCQUFzQixDQUFDLGVBQWUsQ0FBQyxtQkFBQSxJQUFJLEVBQUEsQ0FBQyxFQUFFLEVBQUUsUUFBUSxDQUFDLENBQUM7UUFDL0QsbUJBQUEsSUFBSSxFQUFBLENBQUMsRUFBRSxDQUFDLGFBQWEsRUFBRSxDQUFDO1FBQ3hCLE9BQU8sbUJBQUEsSUFBSSxFQUFBLENBQUM7SUFDZCxDQUFDOzs7O0lBRUQsb0NBQVE7OztJQUFSO1FBQ0UsSUFBSSxDQUFDLE1BQU0sR0FBRyxLQUFLLENBQUM7UUFDcEIsSUFBSSxDQUFDLE9BQU8sR0FBRyxLQUFLLENBQUM7UUFDckIsSUFBSSxDQUFDLE9BQU8sR0FBRyxLQUFLLENBQUM7UUFDckIsSUFBSSxJQUFJLENBQUMsTUFBTSxFQUFFO1lBQ2YsSUFBSSxDQUFDLE9BQU8sR0FBRyxJQUFJLENBQUM7U0FDckI7YUFBTSxJQUFJLElBQUksQ0FBQyxNQUFNLEVBQUU7WUFDdEIsSUFBSSxDQUFDLE9BQU8sR0FBRyxJQUFJLENBQUM7U0FDckI7UUFDRCxJQUFJLENBQUMsUUFBUSxFQUFFLENBQUMsVUFBVSxFQUFFLENBQUM7UUFDN0IsSUFBSSxDQUFDLFlBQVksRUFBRSxDQUFDO0lBQ3RCLENBQUM7Ozs7O0lBRUQsdUNBQVc7Ozs7SUFBWCxVQUFZLE9BQXNCO1FBQ2hDLElBQUksT0FBTyxDQUFDLGNBQWMsQ0FBQyxRQUFRLENBQUMsSUFBSSxPQUFPLENBQUMsTUFBTSxDQUFDLFlBQVksRUFBRTtZQUNuRSxJQUFJLENBQUMsVUFBVSxHQUFHLE9BQU8sQ0FBQyxNQUFNLENBQUMsWUFBWSxDQUFDLE9BQU8sQ0FBQyxTQUFTLENBQUMsR0FBRyxDQUFDLENBQUMsQ0FBQztTQUN2RTtRQUNELElBQUksQ0FBQyxPQUFPLEdBQUcsQ0FBQyxJQUFJLENBQUMsS0FBSyxJQUFJLENBQUMsQ0FBQyxJQUFJLENBQUMsTUFBTSxDQUFDO1FBQzVDLElBQUksQ0FBQyxPQUFPLEdBQUcsQ0FBQyxJQUFJLENBQUMsS0FBSyxJQUFJLENBQUMsQ0FBQyxJQUFJLENBQUMsTUFBTSxDQUFDO1FBQzVDLElBQUksQ0FBQyxNQUFNLEdBQUcsQ0FBQyxDQUFDLElBQUksQ0FBQyxLQUFLLENBQUM7UUFFM0IsSUFBSSxDQUFDLFFBQVEsRUFBRSxDQUFDLFVBQVUsRUFBRSxDQUFDO1FBQzdCLElBQUksQ0FBQyxZQUFZLEVBQUUsQ0FBQztJQUN0QixDQUFDOzs7OztJQUVPLDBDQUFjOzs7O0lBQXRCO1FBQ0UsSUFBSSxDQUFDLElBQUksQ0FBQyxPQUFPLEVBQUU7WUFDakIsT0FBTztTQUNSOztZQUVLLGFBQWEsR0FBRyxJQUFJLENBQUMsTUFBTSxDQUFDLGFBQWEsQ0FBQyxXQUFXOztZQUNyRCxXQUFXLEdBQUcsSUFBSSxDQUFDLEVBQUUsQ0FBQyxxQkFBcUIsRUFBRSxDQUFDLEtBQUs7O1lBQ25ELEtBQUssR0FBRyxXQUFXLEdBQUcsQ0FBQyxHQUFHLGFBQWEsQ0FBQyxDQUFDLENBQUMsQ0FBQyxXQUFXLEdBQUcsQ0FBQyxDQUFDLEdBQUcsYUFBYSxDQUFDLENBQUMsQ0FBQyxDQUFDO1FBQ3JGLElBQUksQ0FBQyxVQUFVLEdBQUc7WUFDaEIsU0FBUyxFQUFFLFdBQVMsS0FBSyx1QkFBb0I7U0FDOUMsQ0FBQztRQUNGLElBQUksT0FBTyxJQUFJLENBQUMsTUFBTSxLQUFLLFFBQVEsRUFBRTtZQUNuQyxNQUFNLENBQUMsTUFBTSxDQUFDLElBQUksQ0FBQyxVQUFVLEVBQUU7Z0JBQzdCLFVBQVUsRUFBSyxJQUFJLENBQUMsTUFBTSxPQUFJO2FBQy9CLENBQUMsQ0FBQztTQUNKO1FBQ0QsSUFBSSxDQUFDLEVBQUUsQ0FBQyxhQUFhLEVBQUUsQ0FBQztJQUMxQixDQUFDOzs7Ozs7O0lBRU8sc0NBQVU7Ozs7OztJQUFsQjtRQUFBLGlCQVFDO1FBUEMsd0VBQXdFO1FBQ3hFLElBQUksbUJBQUEsSUFBSSxFQUFBLENBQUMsUUFBUSxDQUFDLFNBQVMsRUFBRTtZQUMzQixVQUFVOzs7WUFBQztnQkFDVCxtQkFBQSxLQUFJLEVBQUEsQ0FBQyxjQUFjLEVBQUUsQ0FBQztZQUN4QixDQUFDLEVBQUMsQ0FBQztTQUNKO1FBQ0QsT0FBTyxtQkFBQSxJQUFJLEVBQUEsQ0FBQztJQUNkLENBQUM7Ozs7O0lBRU8sd0NBQVk7Ozs7SUFBcEI7UUFDRSxJQUFJLE9BQU8sSUFBSSxDQUFDLE1BQU0sS0FBSyxRQUFRLEVBQUU7WUFDbkMsT0FBTztTQUNSO1FBQ0QsSUFBSSxDQUFDLFFBQVEsQ0FBQyxRQUFRLENBQUMsSUFBSSxDQUFDLEVBQUUsRUFBRSxPQUFPLEVBQUssSUFBSSxDQUFDLE1BQU0sT0FBSSxDQUFDLENBQUM7UUFDN0QsSUFBSSxDQUFDLFFBQVEsQ0FBQyxRQUFRLENBQUMsSUFBSSxDQUFDLEVBQUUsRUFBRSxRQUFRLEVBQUssSUFBSSxDQUFDLE1BQU0sT0FBSSxDQUFDLENBQUM7UUFDOUQsSUFBSSxDQUFDLFFBQVEsQ0FBQyxRQUFRLENBQUMsSUFBSSxDQUFDLEVBQUUsRUFBRSxhQUFhLEVBQUssSUFBSSxDQUFDLE1BQU0sT0FBSSxDQUFDLENBQUM7UUFDbkUsSUFBSSxJQUFJLENBQUMsT0FBTyxFQUFFO1lBQ2hCLElBQUksQ0FBQyxRQUFRLENBQUMsUUFBUSxDQUFDLElBQUksQ0FBQyxFQUFFLEVBQUUsV0FBVyxFQUFLLElBQUksQ0FBQyxNQUFNLEdBQUcsQ0FBQyxPQUFJLENBQUMsQ0FBQztTQUN0RTtJQUNILENBQUM7O2dCQWpIRixTQUFTLFNBQUM7b0JBQ1QsUUFBUSxFQUFFLFdBQVc7b0JBQ3JCLFFBQVEsRUFBRSxVQUFVO29CQUNwQix3VEFBeUM7b0JBQ3pDLFNBQVMsRUFBRSxDQUFDLHdCQUF3QixDQUFDO29CQUNyQyxtQkFBbUIsRUFBRSxLQUFLO29CQUMxQixlQUFlLEVBQUUsdUJBQXVCLENBQUMsTUFBTTtvQkFDL0MsYUFBYSxFQUFFLGlCQUFpQixDQUFDLElBQUk7aUJBQ3RDOzs7O2dCQTFCQyxVQUFVO2dCQUZWLGlCQUFpQjtnQkFXZ0Isd0JBQXdCO2dCQU56RCxTQUFTO2dCQVJGLFFBQVE7OzswQkFpQ2QsS0FBSzt5QkFDTCxLQUFLO3lCQUNMLEtBQUs7d0JBQ0wsS0FBSzt5QkFDTCxLQUFLO3lCQVFMLFNBQVMsU0FBQyxRQUFROztJQTRGckIsd0JBQUM7Q0FBQSxBQWxIRCxJQWtIQztTQXpHWSxpQkFBaUI7OztJQUM1QixvQ0FBMkM7O0lBQzNDLG1DQUEwQzs7SUFDMUMsbUNBQXdCOztJQUN4QixrQ0FBdUI7O0lBQ3ZCLG1DQUF3Qjs7SUFFeEIsdUNBQWtCOztJQUNsQixvQ0FBeUI7O0lBQ3pCLG1DQUF1Qjs7SUFDdkIsb0NBQXlCOztJQUN6Qix1Q0FBZTs7SUFFZixtQ0FBd0M7Ozs7O0lBRXhDLCtCQUF3RDs7Ozs7SUFDeEQsc0NBQWlDOzs7OztJQUNqQyxvQ0FBMEQ7Ozs7O0lBR3hELHVDQUE4Qjs7Ozs7SUFDOUIsK0JBQTZCOzs7OztJQUM3QixtREFBd0Q7Ozs7O0lBQ3hELHFDQUEyQjs7Ozs7SUFDM0IscUNBQTBCIiwic291cmNlc0NvbnRlbnQiOlsiLyoqXG4gKiBAbGljZW5zZVxuICogQ29weXJpZ2h0IEFsaWJhYmEuY29tIEFsbCBSaWdodHMgUmVzZXJ2ZWQuXG4gKlxuICogVXNlIG9mIHRoaXMgc291cmNlIGNvZGUgaXMgZ292ZXJuZWQgYnkgYW4gTUlULXN0eWxlIGxpY2Vuc2UgdGhhdCBjYW4gYmVcbiAqIGZvdW5kIGluIHRoZSBMSUNFTlNFIGZpbGUgYXQgaHR0cHM6Ly9naXRodWIuY29tL05HLVpPUlJPL25nLXpvcnJvLWFudGQvYmxvYi9tYXN0ZXIvTElDRU5TRVxuICovXG5cbmltcG9ydCB7IFBsYXRmb3JtIH0gZnJvbSAnQGFuZ3VsYXIvY2RrL3BsYXRmb3JtJztcbmltcG9ydCB7XG4gIENoYW5nZURldGVjdGlvblN0cmF0ZWd5LFxuICBDaGFuZ2VEZXRlY3RvclJlZixcbiAgQ29tcG9uZW50LFxuICBFbGVtZW50UmVmLFxuICBJbnB1dCxcbiAgT25DaGFuZ2VzLFxuICBSZW5kZXJlcjIsXG4gIFNpbXBsZUNoYW5nZXMsXG4gIFZpZXdDaGlsZCxcbiAgVmlld0VuY2Fwc3VsYXRpb25cbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmltcG9ydCB7IE56U2l6ZUxEU1R5cGUsIE56U2l6ZU1hcCwgTnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlIH0gZnJvbSAnbmctem9ycm8tYW50ZC9jb3JlJztcblxuZXhwb3J0IHR5cGUgTnpBdmF0YXJTaGFwZSA9ICdzcXVhcmUnIHwgJ2NpcmNsZSc7XG5leHBvcnQgdHlwZSBOekF2YXRhclNpemUgPSBOelNpemVMRFNUeXBlIHwgbnVtYmVyO1xuXG5leHBvcnQgaW50ZXJmYWNlIE56QXZhdGFyU2l6ZU1hcCB7XG4gIFtzaXplOiBzdHJpbmddOiBzdHJpbmc7XG59XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ256LWF2YXRhcicsXG4gIGV4cG9ydEFzOiAnbnpBdmF0YXInLFxuICB0ZW1wbGF0ZVVybDogJy4vbnotYXZhdGFyLmNvbXBvbmVudC5odG1sJyxcbiAgcHJvdmlkZXJzOiBbTnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlXSxcbiAgcHJlc2VydmVXaGl0ZXNwYWNlczogZmFsc2UsXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxuICBlbmNhcHN1bGF0aW9uOiBWaWV3RW5jYXBzdWxhdGlvbi5Ob25lXG59KVxuZXhwb3J0IGNsYXNzIE56QXZhdGFyQ29tcG9uZW50IGltcGxlbWVudHMgT25DaGFuZ2VzIHtcbiAgQElucHV0KCkgbnpTaGFwZTogTnpBdmF0YXJTaGFwZSA9ICdjaXJjbGUnO1xuICBASW5wdXQoKSBuelNpemU6IE56QXZhdGFyU2l6ZSA9ICdkZWZhdWx0JztcbiAgQElucHV0KCkgbnpUZXh0OiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56U3JjOiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56SWNvbjogc3RyaW5nO1xuXG4gIG9sZEFQSUljb24gPSB0cnVlOyAvLyBNYWtlIHRoZSB1c2VyIGRlZmluZWQgaWNvbiBjb21wYXRpYmxlIHRvIG9sZCBBUEkuIFNob3VsZCBiZSByZW1vdmVkIGluIDIuMC5cbiAgaGFzVGV4dDogYm9vbGVhbiA9IGZhbHNlO1xuICBoYXNTcmM6IGJvb2xlYW4gPSB0cnVlO1xuICBoYXNJY29uOiBib29sZWFuID0gZmFsc2U7XG4gIHRleHRTdHlsZXM6IHt9O1xuXG4gIEBWaWV3Q2hpbGQoJ3RleHRFbCcpIHRleHRFbDogRWxlbWVudFJlZjtcblxuICBwcml2YXRlIGVsOiBIVE1MRWxlbWVudCA9IHRoaXMuZWxlbWVudFJlZi5uYXRpdmVFbGVtZW50O1xuICBwcml2YXRlIHByZWZpeENscyA9ICdhbnQtYXZhdGFyJztcbiAgcHJpdmF0ZSBzaXplTWFwOiBOelNpemVNYXAgPSB7IGxhcmdlOiAnbGcnLCBzbWFsbDogJ3NtJyB9O1xuXG4gIGNvbnN0cnVjdG9yKFxuICAgIHByaXZhdGUgZWxlbWVudFJlZjogRWxlbWVudFJlZixcbiAgICBwcml2YXRlIGNkOiBDaGFuZ2VEZXRlY3RvclJlZixcbiAgICBwcml2YXRlIHVwZGF0ZUhvc3RDbGFzc1NlcnZpY2U6IE56VXBkYXRlSG9zdENsYXNzU2VydmljZSxcbiAgICBwcml2YXRlIHJlbmRlcmVyOiBSZW5kZXJlcjIsXG4gICAgcHJpdmF0ZSBwbGF0Zm9ybTogUGxhdGZvcm1cbiAgKSB7fVxuXG4gIHNldENsYXNzKCk6IHRoaXMge1xuICAgIGNvbnN0IGNsYXNzTWFwID0ge1xuICAgICAgW3RoaXMucHJlZml4Q2xzXTogdHJ1ZSxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tJHt0aGlzLnNpemVNYXBbdGhpcy5uelNpemVdfWBdOiB0aGlzLnNpemVNYXBbdGhpcy5uelNpemVdLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS0ke3RoaXMubnpTaGFwZX1gXTogdGhpcy5uelNoYXBlLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1pY29uYF06IHRoaXMubnpJY29uLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1pbWFnZWBdOiB0aGlzLmhhc1NyYyAvLyBkb3duZ3JhZGUgYWZ0ZXIgaW1hZ2UgZXJyb3JcbiAgICB9O1xuICAgIHRoaXMudXBkYXRlSG9zdENsYXNzU2VydmljZS51cGRhdGVIb3N0Q2xhc3ModGhpcy5lbCwgY2xhc3NNYXApO1xuICAgIHRoaXMuY2QuZGV0ZWN0Q2hhbmdlcygpO1xuICAgIHJldHVybiB0aGlzO1xuICB9XG5cbiAgaW1nRXJyb3IoKTogdm9pZCB7XG4gICAgdGhpcy5oYXNTcmMgPSBmYWxzZTtcbiAgICB0aGlzLmhhc0ljb24gPSBmYWxzZTtcbiAgICB0aGlzLmhhc1RleHQgPSBmYWxzZTtcbiAgICBpZiAodGhpcy5uekljb24pIHtcbiAgICAgIHRoaXMuaGFzSWNvbiA9IHRydWU7XG4gICAgfSBlbHNlIGlmICh0aGlzLm56VGV4dCkge1xuICAgICAgdGhpcy5oYXNUZXh0ID0gdHJ1ZTtcbiAgICB9XG4gICAgdGhpcy5zZXRDbGFzcygpLm5vdGlmeUNhbGMoKTtcbiAgICB0aGlzLnNldFNpemVTdHlsZSgpO1xuICB9XG5cbiAgbmdPbkNoYW5nZXMoY2hhbmdlczogU2ltcGxlQ2hhbmdlcyk6IHZvaWQge1xuICAgIGlmIChjaGFuZ2VzLmhhc093blByb3BlcnR5KCduekljb24nKSAmJiBjaGFuZ2VzLm56SWNvbi5jdXJyZW50VmFsdWUpIHtcbiAgICAgIHRoaXMub2xkQVBJSWNvbiA9IGNoYW5nZXMubnpJY29uLmN1cnJlbnRWYWx1ZS5pbmRleE9mKCdhbnRpY29uJykgPiAtMTtcbiAgICB9XG4gICAgdGhpcy5oYXNUZXh0ID0gIXRoaXMubnpTcmMgJiYgISF0aGlzLm56VGV4dDtcbiAgICB0aGlzLmhhc0ljb24gPSAhdGhpcy5uelNyYyAmJiAhIXRoaXMubnpJY29uO1xuICAgIHRoaXMuaGFzU3JjID0gISF0aGlzLm56U3JjO1xuXG4gICAgdGhpcy5zZXRDbGFzcygpLm5vdGlmeUNhbGMoKTtcbiAgICB0aGlzLnNldFNpemVTdHlsZSgpO1xuICB9XG5cbiAgcHJpdmF0ZSBjYWxjU3RyaW5nU2l6ZSgpOiB2b2lkIHtcbiAgICBpZiAoIXRoaXMuaGFzVGV4dCkge1xuICAgICAgcmV0dXJuO1xuICAgIH1cblxuICAgIGNvbnN0IGNoaWxkcmVuV2lkdGggPSB0aGlzLnRleHRFbC5uYXRpdmVFbGVtZW50Lm9mZnNldFdpZHRoO1xuICAgIGNvbnN0IGF2YXRhcldpZHRoID0gdGhpcy5lbC5nZXRCb3VuZGluZ0NsaWVudFJlY3QoKS53aWR0aDtcbiAgICBjb25zdCBzY2FsZSA9IGF2YXRhcldpZHRoIC0gOCA8IGNoaWxkcmVuV2lkdGggPyAoYXZhdGFyV2lkdGggLSA4KSAvIGNoaWxkcmVuV2lkdGggOiAxO1xuICAgIHRoaXMudGV4dFN0eWxlcyA9IHtcbiAgICAgIHRyYW5zZm9ybTogYHNjYWxlKCR7c2NhbGV9KSB0cmFuc2xhdGVYKC01MCUpYFxuICAgIH07XG4gICAgaWYgKHR5cGVvZiB0aGlzLm56U2l6ZSA9PT0gJ251bWJlcicpIHtcbiAgICAgIE9iamVjdC5hc3NpZ24odGhpcy50ZXh0U3R5bGVzLCB7XG4gICAgICAgIGxpbmVIZWlnaHQ6IGAke3RoaXMubnpTaXplfXB4YFxuICAgICAgfSk7XG4gICAgfVxuICAgIHRoaXMuY2QuZGV0ZWN0Q2hhbmdlcygpO1xuICB9XG5cbiAgcHJpdmF0ZSBub3RpZnlDYWxjKCk6IHRoaXMge1xuICAgIC8vIElmIHVzZSBuZ0FmdGVyVmlld0NoZWNrZWQsIGFsd2F5cyBkZW1hbmRzIG1vcmUgY29tcHV0YXRpb25zLCBzby4uLi4uLlxuICAgIGlmICh0aGlzLnBsYXRmb3JtLmlzQnJvd3Nlcikge1xuICAgICAgc2V0VGltZW91dCgoKSA9PiB7XG4gICAgICAgIHRoaXMuY2FsY1N0cmluZ1NpemUoKTtcbiAgICAgIH0pO1xuICAgIH1cbiAgICByZXR1cm4gdGhpcztcbiAgfVxuXG4gIHByaXZhdGUgc2V0U2l6ZVN0eWxlKCk6IHZvaWQge1xuICAgIGlmICh0eXBlb2YgdGhpcy5uelNpemUgPT09ICdzdHJpbmcnKSB7XG4gICAgICByZXR1cm47XG4gICAgfVxuICAgIHRoaXMucmVuZGVyZXIuc2V0U3R5bGUodGhpcy5lbCwgJ3dpZHRoJywgYCR7dGhpcy5uelNpemV9cHhgKTtcbiAgICB0aGlzLnJlbmRlcmVyLnNldFN0eWxlKHRoaXMuZWwsICdoZWlnaHQnLCBgJHt0aGlzLm56U2l6ZX1weGApO1xuICAgIHRoaXMucmVuZGVyZXIuc2V0U3R5bGUodGhpcy5lbCwgJ2xpbmUtaGVpZ2h0JywgYCR7dGhpcy5uelNpemV9cHhgKTtcbiAgICBpZiAodGhpcy5oYXNJY29uKSB7XG4gICAgICB0aGlzLnJlbmRlcmVyLnNldFN0eWxlKHRoaXMuZWwsICdmb250LXNpemUnLCBgJHt0aGlzLm56U2l6ZSAvIDJ9cHhgKTtcbiAgICB9XG4gIH1cbn1cbiJdfQ==