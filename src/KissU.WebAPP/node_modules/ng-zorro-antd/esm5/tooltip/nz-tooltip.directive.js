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
import { ComponentFactoryResolver, Directive, ElementRef, EventEmitter, Host, Input, Optional, Output, Renderer2, ViewContainerRef } from '@angular/core';
import { Subscription } from 'rxjs';
import { distinctUntilChanged } from 'rxjs/operators';
import { isNotNil, NzNoAnimationDirective } from 'ng-zorro-antd/core';
import { NzToolTipComponent } from './nz-tooltip.component';
var NzTooltipDirective = /** @class */ (function () {
    function NzTooltipDirective(elementRef, hostView, resolver, renderer, tooltip, noAnimation) {
        this.elementRef = elementRef;
        this.hostView = hostView;
        this.resolver = resolver;
        this.renderer = renderer;
        this.tooltip = tooltip;
        this.noAnimation = noAnimation;
        // [NOTE] Here hard coded, and nzTitle used only under NzTooltipDirective currently.
        this.isTooltipOpen = false;
        this.isDynamicTooltip = false; // Indicate whether current tooltip is dynamic created
        this.factory = this.resolver.resolveComponentFactory(NzToolTipComponent);
        /**
         * Names of properties that should be proxy to child component.
         */
        this.needProxyProperties = [
            'nzTitle',
            'nzContent',
            'nzOverlayClassName',
            'nzOverlayStyle',
            'nzMouseEnterDelay',
            'nzMouseLeaveDelay',
            'nzVisible',
            'nzTrigger',
            'nzPlacement'
        ];
        this.subs_ = new Subscription();
        this.listeners = [];
        this.nzVisibleChange = new EventEmitter();
    }
    Object.defineProperty(NzTooltipDirective.prototype, "setTitle", {
        set: /**
         * @param {?} title
         * @return {?}
         */
        function (title) {
            this.nzTitle = title;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @param {?} changes
     * @return {?}
     */
    NzTooltipDirective.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        this.updateProxies(changes);
    };
    /**
     * @return {?}
     */
    NzTooltipDirective.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        // Support faster tooltip mode: <a nz-tooltip="xxx"></a>. [NOTE] Used only under NzTooltipDirective currently.
        if (!this.tooltip) {
            /** @type {?} */
            var tooltipComponent = this.hostView.createComponent(this.factory);
            this.tooltip = tooltipComponent.instance;
            this.tooltip.noAnimation = this.noAnimation;
            // Remove element when use directive https://github.com/NG-ZORRO/ng-zorro-antd/issues/1967
            this.renderer.removeChild(this.renderer.parentNode(this.elementRef.nativeElement), tooltipComponent.location.nativeElement);
            this.isDynamicTooltip = true;
            this.needProxyProperties.forEach((/**
             * @param {?} property
             * @return {?}
             */
            function (property) { return _this.updateCompValue(property, _this[property]); }));
            /** @type {?} */
            var visible_ = this.tooltip.nzVisibleChange.pipe(distinctUntilChanged()).subscribe((/**
             * @param {?} data
             * @return {?}
             */
            function (data) {
                _this.visible = data;
                _this.nzVisibleChange.emit(data);
            }));
            this.subs_.add(visible_);
        }
        this.tooltip.setOverlayOrigin(this);
    };
    /**
     * @return {?}
     */
    NzTooltipDirective.prototype.ngAfterViewInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        if (this.tooltip.nzTrigger === 'hover') {
            /** @type {?} */
            var overlayElement_1;
            /** @type {?} */
            var listenerMouseEnter = this.renderer.listen(this.elementRef.nativeElement, 'mouseenter', (/**
             * @return {?}
             */
            function () {
                return _this.delayEnterLeave(true, true, _this.tooltip.nzMouseEnterDelay);
            }));
            this.listeners.push(listenerMouseEnter);
            /** @type {?} */
            var listenerMouseLeave = this.renderer.listen(this.elementRef.nativeElement, 'mouseleave', (/**
             * @return {?}
             */
            function () {
                _this.delayEnterLeave(true, false, _this.tooltip.nzMouseLeaveDelay);
                if (_this.tooltip.overlay.overlayRef && !overlayElement_1) {
                    // NOTE: we bind events under "mouseleave" due to the overlayRef is only created after the overlay was completely shown up
                    overlayElement_1 = _this.tooltip.overlay.overlayRef.overlayElement;
                    /** @type {?} */
                    var listenerOverlayMouseEnter = _this.renderer.listen(overlayElement_1, 'mouseenter', (/**
                     * @return {?}
                     */
                    function () {
                        return _this.delayEnterLeave(false, true);
                    }));
                    _this.listeners.push(listenerOverlayMouseEnter);
                    /** @type {?} */
                    var listenerOverlayMouseLeave = _this.renderer.listen(overlayElement_1, 'mouseleave', (/**
                     * @return {?}
                     */
                    function () {
                        return _this.delayEnterLeave(false, false);
                    }));
                    _this.listeners.push(listenerOverlayMouseLeave);
                }
            }));
            this.listeners.push(listenerMouseLeave);
        }
        else if (this.tooltip.nzTrigger === 'focus') {
            /** @type {?} */
            var listenerFocus = this.renderer.listen(this.elementRef.nativeElement, 'focus', (/**
             * @return {?}
             */
            function () { return _this.show(); }));
            this.listeners.push(listenerFocus);
            /** @type {?} */
            var listenerBlur = this.renderer.listen(this.elementRef.nativeElement, 'blur', (/**
             * @return {?}
             */
            function () { return _this.hide(); }));
            this.listeners.push(listenerBlur);
        }
        else if (this.tooltip.nzTrigger === 'click') {
            /** @type {?} */
            var listenerClick = this.renderer.listen(this.elementRef.nativeElement, 'click', (/**
             * @param {?} e
             * @return {?}
             */
            function (e) {
                e.preventDefault();
                _this.show();
            }));
            this.listeners.push(listenerClick);
        }
    };
    /**
     * @return {?}
     */
    NzTooltipDirective.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.subs_.unsubscribe();
        this.listeners.forEach((/**
         * @param {?} listener
         * @return {?}
         */
        function (listener) {
            listener();
        }));
    };
    // tslint:disable-next-line:no-any
    // tslint:disable-next-line:no-any
    /**
     * @protected
     * @param {?} key
     * @param {?} value
     * @return {?}
     */
    NzTooltipDirective.prototype.updateCompValue = 
    // tslint:disable-next-line:no-any
    /**
     * @protected
     * @param {?} key
     * @param {?} value
     * @return {?}
     */
    function (key, value) {
        if (this.isDynamicTooltip && isNotNil(value)) {
            this.tooltip[key] = value;
        }
    };
    /**
     * @private
     * @return {?}
     */
    NzTooltipDirective.prototype.show = /**
     * @private
     * @return {?}
     */
    function () {
        this.tooltip.show();
        this.isTooltipOpen = true;
    };
    /**
     * @private
     * @return {?}
     */
    NzTooltipDirective.prototype.hide = /**
     * @private
     * @return {?}
     */
    function () {
        this.tooltip.hide();
        this.isTooltipOpen = false;
    };
    /**
     * @private
     * @param {?} isOrigin
     * @param {?} isEnter
     * @param {?=} delay
     * @return {?}
     */
    NzTooltipDirective.prototype.delayEnterLeave = /**
     * @private
     * @param {?} isOrigin
     * @param {?} isEnter
     * @param {?=} delay
     * @return {?}
     */
    function (isOrigin, isEnter, delay) {
        var _this = this;
        if (delay === void 0) { delay = -1; }
        if (this.delayTimer) {
            // Clear timer during the delay time
            clearTimeout(this.delayTimer);
            this.delayTimer = null;
        }
        else if (delay > 0) {
            this.delayTimer = setTimeout((/**
             * @return {?}
             */
            function () {
                _this.delayTimer = null;
                isEnter ? _this.show() : _this.hide();
            }), delay * 1000);
        }
        else {
            isEnter && isOrigin ? this.show() : this.hide(); // [Compatible] The "isOrigin" is used due to the tooltip will not hide immediately (may caused by the fade-out animation)
        }
    };
    /**
     * Set inputs of child components when this component's inputs change.
     * @param changes
     */
    /**
     * Set inputs of child components when this component's inputs change.
     * @private
     * @param {?} changes
     * @return {?}
     */
    NzTooltipDirective.prototype.updateProxies = /**
     * Set inputs of child components when this component's inputs change.
     * @private
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        var _this = this;
        if (this.tooltip) {
            Object.keys(changes).forEach((/**
             * @param {?} key
             * @return {?}
             */
            function (key) {
                /** @type {?} */
                var change = changes[key];
                if (change) {
                    _this.updateCompValue(key, change.currentValue);
                }
            }));
            if (changes.setTitle) {
                this.nzTitle = changes.setTitle.currentValue;
                this.updateCompValue('nzTitle', changes.setTitle.currentValue);
            }
            this.tooltip.cdr.markForCheck(); // Manually trigger change detection of component.
        }
    };
    NzTooltipDirective.decorators = [
        { type: Directive, args: [{
                    selector: '[nz-tooltip]',
                    exportAs: 'nzTooltip',
                    host: {
                        '[class.ant-tooltip-open]': 'isTooltipOpen'
                    }
                },] }
    ];
    /** @nocollapse */
    NzTooltipDirective.ctorParameters = function () { return [
        { type: ElementRef },
        { type: ViewContainerRef },
        { type: ComponentFactoryResolver },
        { type: Renderer2 },
        { type: NzToolTipComponent, decorators: [{ type: Optional }] },
        { type: NzNoAnimationDirective, decorators: [{ type: Host }, { type: Optional }] }
    ]; };
    NzTooltipDirective.propDecorators = {
        nzVisibleChange: [{ type: Output }],
        nzTitle: [{ type: Input, args: ['nz-tooltip',] }],
        setTitle: [{ type: Input, args: ['nzTitle',] }],
        nzContent: [{ type: Input }],
        nzMouseEnterDelay: [{ type: Input }],
        nzMouseLeaveDelay: [{ type: Input }],
        nzOverlayClassName: [{ type: Input }],
        nzOverlayStyle: [{ type: Input }],
        nzTrigger: [{ type: Input }],
        nzVisible: [{ type: Input }],
        nzPlacement: [{ type: Input }]
    };
    return NzTooltipDirective;
}());
export { NzTooltipDirective };
if (false) {
    /** @type {?} */
    NzTooltipDirective.prototype.isTooltipOpen;
    /** @type {?} */
    NzTooltipDirective.prototype.isDynamicTooltip;
    /** @type {?} */
    NzTooltipDirective.prototype.delayTimer;
    /** @type {?} */
    NzTooltipDirective.prototype.visible;
    /** @type {?} */
    NzTooltipDirective.prototype.factory;
    /**
     * Names of properties that should be proxy to child component.
     * @type {?}
     * @protected
     */
    NzTooltipDirective.prototype.needProxyProperties;
    /**
     * @type {?}
     * @protected
     */
    NzTooltipDirective.prototype.subs_;
    /**
     * @type {?}
     * @protected
     */
    NzTooltipDirective.prototype.listeners;
    /** @type {?} */
    NzTooltipDirective.prototype.nzVisibleChange;
    /** @type {?} */
    NzTooltipDirective.prototype.nzTitle;
    /** @type {?} */
    NzTooltipDirective.prototype.nzContent;
    /** @type {?} */
    NzTooltipDirective.prototype.nzMouseEnterDelay;
    /** @type {?} */
    NzTooltipDirective.prototype.nzMouseLeaveDelay;
    /** @type {?} */
    NzTooltipDirective.prototype.nzOverlayClassName;
    /** @type {?} */
    NzTooltipDirective.prototype.nzOverlayStyle;
    /** @type {?} */
    NzTooltipDirective.prototype.nzTrigger;
    /** @type {?} */
    NzTooltipDirective.prototype.nzVisible;
    /** @type {?} */
    NzTooltipDirective.prototype.nzPlacement;
    /** @type {?} */
    NzTooltipDirective.prototype.elementRef;
    /** @type {?} */
    NzTooltipDirective.prototype.hostView;
    /** @type {?} */
    NzTooltipDirective.prototype.resolver;
    /** @type {?} */
    NzTooltipDirective.prototype.renderer;
    /** @type {?} */
    NzTooltipDirective.prototype.tooltip;
    /** @type {?} */
    NzTooltipDirective.prototype.noAnimation;
    /* Skipping unhandled member: [property: string]: any;*/
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotdG9vbHRpcC5kaXJlY3RpdmUuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9uZy16b3Jyby1hbnRkL3Rvb2x0aXAvIiwic291cmNlcyI6WyJuei10b29sdGlwLmRpcmVjdGl2ZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7OztBQVFBLE9BQU8sRUFHTCx3QkFBd0IsRUFDeEIsU0FBUyxFQUNULFVBQVUsRUFDVixZQUFZLEVBQ1osSUFBSSxFQUNKLEtBQUssRUFJTCxRQUFRLEVBQ1IsTUFBTSxFQUNOLFNBQVMsRUFHVCxnQkFBZ0IsRUFDakIsTUFBTSxlQUFlLENBQUM7QUFFdkIsT0FBTyxFQUFFLFlBQVksRUFBRSxNQUFNLE1BQU0sQ0FBQztBQUNwQyxPQUFPLEVBQUUsb0JBQW9CLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUV0RCxPQUFPLEVBQUUsUUFBUSxFQUFFLHNCQUFzQixFQUFFLE1BQU0sb0JBQW9CLENBQUM7QUFFdEUsT0FBTyxFQUFFLGtCQUFrQixFQUFFLE1BQU0sd0JBQXdCLENBQUM7QUFFNUQ7SUFrREUsNEJBQ1MsVUFBc0IsRUFDdEIsUUFBMEIsRUFDMUIsUUFBa0MsRUFDbEMsUUFBbUIsRUFDUCxPQUEyQixFQUNuQixXQUFvQztRQUx4RCxlQUFVLEdBQVYsVUFBVSxDQUFZO1FBQ3RCLGFBQVEsR0FBUixRQUFRLENBQWtCO1FBQzFCLGFBQVEsR0FBUixRQUFRLENBQTBCO1FBQ2xDLGFBQVEsR0FBUixRQUFRLENBQVc7UUFDUCxZQUFPLEdBQVAsT0FBTyxDQUFvQjtRQUNuQixnQkFBVyxHQUFYLFdBQVcsQ0FBeUI7O1FBL0NqRSxrQkFBYSxHQUFZLEtBQUssQ0FBQztRQUMvQixxQkFBZ0IsR0FBRyxLQUFLLENBQUMsQ0FBQyxzREFBc0Q7UUFHaEYsWUFBTyxHQUF5QyxJQUFJLENBQUMsUUFBUSxDQUFDLHVCQUF1QixDQUFDLGtCQUFrQixDQUFDLENBQUM7Ozs7UUFHaEcsd0JBQW1CLEdBQUc7WUFDOUIsU0FBUztZQUNULFdBQVc7WUFDWCxvQkFBb0I7WUFDcEIsZ0JBQWdCO1lBQ2hCLG1CQUFtQjtZQUNuQixtQkFBbUI7WUFDbkIsV0FBVztZQUNYLFdBQVc7WUFDWCxhQUFhO1NBQ2QsQ0FBQztRQUVRLFVBQUssR0FBRyxJQUFJLFlBQVksRUFBRSxDQUFDO1FBQzNCLGNBQVMsR0FBc0IsRUFBRSxDQUFDO1FBRXpCLG9CQUFlLEdBQUcsSUFBSSxZQUFZLEVBQVcsQ0FBQztJQTBCOUQsQ0FBQztJQXRCSixzQkFBc0Isd0NBQVE7Ozs7O1FBQTlCLFVBQStCLEtBQXdDO1lBQ3JFLElBQUksQ0FBQyxPQUFPLEdBQUcsS0FBSyxDQUFDO1FBQ3ZCLENBQUM7OztPQUFBOzs7OztJQXNCRCx3Q0FBVzs7OztJQUFYLFVBQVksT0FBc0I7UUFDaEMsSUFBSSxDQUFDLGFBQWEsQ0FBQyxPQUFPLENBQUMsQ0FBQztJQUM5QixDQUFDOzs7O0lBRUQscUNBQVE7OztJQUFSO1FBQUEsaUJBb0JDO1FBbkJDLDhHQUE4RztRQUM5RyxJQUFJLENBQUMsSUFBSSxDQUFDLE9BQU8sRUFBRTs7Z0JBQ1gsZ0JBQWdCLEdBQUcsSUFBSSxDQUFDLFFBQVEsQ0FBQyxlQUFlLENBQUMsSUFBSSxDQUFDLE9BQU8sQ0FBQztZQUNwRSxJQUFJLENBQUMsT0FBTyxHQUFHLGdCQUFnQixDQUFDLFFBQVEsQ0FBQztZQUN6QyxJQUFJLENBQUMsT0FBTyxDQUFDLFdBQVcsR0FBRyxJQUFJLENBQUMsV0FBVyxDQUFDO1lBQzVDLDBGQUEwRjtZQUMxRixJQUFJLENBQUMsUUFBUSxDQUFDLFdBQVcsQ0FDdkIsSUFBSSxDQUFDLFFBQVEsQ0FBQyxVQUFVLENBQUMsSUFBSSxDQUFDLFVBQVUsQ0FBQyxhQUFhLENBQUMsRUFDdkQsZ0JBQWdCLENBQUMsUUFBUSxDQUFDLGFBQWEsQ0FDeEMsQ0FBQztZQUNGLElBQUksQ0FBQyxnQkFBZ0IsR0FBRyxJQUFJLENBQUM7WUFDN0IsSUFBSSxDQUFDLG1CQUFtQixDQUFDLE9BQU87Ozs7WUFBQyxVQUFBLFFBQVEsSUFBSSxPQUFBLEtBQUksQ0FBQyxlQUFlLENBQUMsUUFBUSxFQUFFLEtBQUksQ0FBQyxRQUFRLENBQUMsQ0FBQyxFQUE5QyxDQUE4QyxFQUFDLENBQUM7O2dCQUN2RixRQUFRLEdBQUcsSUFBSSxDQUFDLE9BQU8sQ0FBQyxlQUFlLENBQUMsSUFBSSxDQUFDLG9CQUFvQixFQUFFLENBQUMsQ0FBQyxTQUFTOzs7O1lBQUMsVUFBQSxJQUFJO2dCQUN2RixLQUFJLENBQUMsT0FBTyxHQUFHLElBQUksQ0FBQztnQkFDcEIsS0FBSSxDQUFDLGVBQWUsQ0FBQyxJQUFJLENBQUMsSUFBSSxDQUFDLENBQUM7WUFDbEMsQ0FBQyxFQUFDO1lBQ0YsSUFBSSxDQUFDLEtBQUssQ0FBQyxHQUFHLENBQUMsUUFBUSxDQUFDLENBQUM7U0FDMUI7UUFDRCxJQUFJLENBQUMsT0FBTyxDQUFDLGdCQUFnQixDQUFDLElBQUksQ0FBQyxDQUFDO0lBQ3RDLENBQUM7Ozs7SUFFRCw0Q0FBZTs7O0lBQWY7UUFBQSxpQkFzQ0M7UUFyQ0MsSUFBSSxJQUFJLENBQUMsT0FBTyxDQUFDLFNBQVMsS0FBSyxPQUFPLEVBQUU7O2dCQUNsQyxnQkFBMkI7O2dCQUN6QixrQkFBa0IsR0FBRyxJQUFJLENBQUMsUUFBUSxDQUFDLE1BQU0sQ0FBQyxJQUFJLENBQUMsVUFBVSxDQUFDLGFBQWEsRUFBRSxZQUFZOzs7WUFBRTtnQkFDM0YsT0FBQSxLQUFJLENBQUMsZUFBZSxDQUFDLElBQUksRUFBRSxJQUFJLEVBQUUsS0FBSSxDQUFDLE9BQU8sQ0FBQyxpQkFBaUIsQ0FBQztZQUFoRSxDQUFnRSxFQUNqRTtZQUNELElBQUksQ0FBQyxTQUFTLENBQUMsSUFBSSxDQUFDLGtCQUFrQixDQUFDLENBQUM7O2dCQUVsQyxrQkFBa0IsR0FBRyxJQUFJLENBQUMsUUFBUSxDQUFDLE1BQU0sQ0FBQyxJQUFJLENBQUMsVUFBVSxDQUFDLGFBQWEsRUFBRSxZQUFZOzs7WUFBRTtnQkFDM0YsS0FBSSxDQUFDLGVBQWUsQ0FBQyxJQUFJLEVBQUUsS0FBSyxFQUFFLEtBQUksQ0FBQyxPQUFPLENBQUMsaUJBQWlCLENBQUMsQ0FBQztnQkFDbEUsSUFBSSxLQUFJLENBQUMsT0FBTyxDQUFDLE9BQU8sQ0FBQyxVQUFVLElBQUksQ0FBQyxnQkFBYyxFQUFFO29CQUN0RCwwSEFBMEg7b0JBQzFILGdCQUFjLEdBQUcsS0FBSSxDQUFDLE9BQU8sQ0FBQyxPQUFPLENBQUMsVUFBVSxDQUFDLGNBQWMsQ0FBQzs7d0JBQzFELHlCQUF5QixHQUFHLEtBQUksQ0FBQyxRQUFRLENBQUMsTUFBTSxDQUFDLGdCQUFjLEVBQUUsWUFBWTs7O29CQUFFO3dCQUNuRixPQUFBLEtBQUksQ0FBQyxlQUFlLENBQUMsS0FBSyxFQUFFLElBQUksQ0FBQztvQkFBakMsQ0FBaUMsRUFDbEM7b0JBQ0QsS0FBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMseUJBQXlCLENBQUMsQ0FBQzs7d0JBRXpDLHlCQUF5QixHQUFHLEtBQUksQ0FBQyxRQUFRLENBQUMsTUFBTSxDQUFDLGdCQUFjLEVBQUUsWUFBWTs7O29CQUFFO3dCQUNuRixPQUFBLEtBQUksQ0FBQyxlQUFlLENBQUMsS0FBSyxFQUFFLEtBQUssQ0FBQztvQkFBbEMsQ0FBa0MsRUFDbkM7b0JBQ0QsS0FBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMseUJBQXlCLENBQUMsQ0FBQztpQkFDaEQ7WUFDSCxDQUFDLEVBQUM7WUFDRixJQUFJLENBQUMsU0FBUyxDQUFDLElBQUksQ0FBQyxrQkFBa0IsQ0FBQyxDQUFDO1NBQ3pDO2FBQU0sSUFBSSxJQUFJLENBQUMsT0FBTyxDQUFDLFNBQVMsS0FBSyxPQUFPLEVBQUU7O2dCQUN2QyxhQUFhLEdBQUcsSUFBSSxDQUFDLFFBQVEsQ0FBQyxNQUFNLENBQUMsSUFBSSxDQUFDLFVBQVUsQ0FBQyxhQUFhLEVBQUUsT0FBTzs7O1lBQUUsY0FBTSxPQUFBLEtBQUksQ0FBQyxJQUFJLEVBQUUsRUFBWCxDQUFXLEVBQUM7WUFDckcsSUFBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMsYUFBYSxDQUFDLENBQUM7O2dCQUU3QixZQUFZLEdBQUcsSUFBSSxDQUFDLFFBQVEsQ0FBQyxNQUFNLENBQUMsSUFBSSxDQUFDLFVBQVUsQ0FBQyxhQUFhLEVBQUUsTUFBTTs7O1lBQUUsY0FBTSxPQUFBLEtBQUksQ0FBQyxJQUFJLEVBQUUsRUFBWCxDQUFXLEVBQUM7WUFDbkcsSUFBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMsWUFBWSxDQUFDLENBQUM7U0FDbkM7YUFBTSxJQUFJLElBQUksQ0FBQyxPQUFPLENBQUMsU0FBUyxLQUFLLE9BQU8sRUFBRTs7Z0JBQ3ZDLGFBQWEsR0FBRyxJQUFJLENBQUMsUUFBUSxDQUFDLE1BQU0sQ0FBQyxJQUFJLENBQUMsVUFBVSxDQUFDLGFBQWEsRUFBRSxPQUFPOzs7O1lBQUUsVUFBQSxDQUFDO2dCQUNsRixDQUFDLENBQUMsY0FBYyxFQUFFLENBQUM7Z0JBQ25CLEtBQUksQ0FBQyxJQUFJLEVBQUUsQ0FBQztZQUNkLENBQUMsRUFBQztZQUNGLElBQUksQ0FBQyxTQUFTLENBQUMsSUFBSSxDQUFDLGFBQWEsQ0FBQyxDQUFDO1NBQ3BDO0lBQ0gsQ0FBQzs7OztJQUVELHdDQUFXOzs7SUFBWDtRQUNFLElBQUksQ0FBQyxLQUFLLENBQUMsV0FBVyxFQUFFLENBQUM7UUFDekIsSUFBSSxDQUFDLFNBQVMsQ0FBQyxPQUFPOzs7O1FBQUMsVUFBQSxRQUFRO1lBQzdCLFFBQVEsRUFBRSxDQUFDO1FBQ2IsQ0FBQyxFQUFDLENBQUM7SUFDTCxDQUFDO0lBRUQsa0NBQWtDOzs7Ozs7OztJQUN4Qiw0Q0FBZTs7Ozs7Ozs7SUFBekIsVUFBMEIsR0FBVyxFQUFFLEtBQVU7UUFDL0MsSUFBSSxJQUFJLENBQUMsZ0JBQWdCLElBQUksUUFBUSxDQUFDLEtBQUssQ0FBQyxFQUFFO1lBQzVDLElBQUksQ0FBQyxPQUFPLENBQUMsR0FBRyxDQUFDLEdBQUcsS0FBSyxDQUFDO1NBQzNCO0lBQ0gsQ0FBQzs7Ozs7SUFFTyxpQ0FBSTs7OztJQUFaO1FBQ0UsSUFBSSxDQUFDLE9BQU8sQ0FBQyxJQUFJLEVBQUUsQ0FBQztRQUNwQixJQUFJLENBQUMsYUFBYSxHQUFHLElBQUksQ0FBQztJQUM1QixDQUFDOzs7OztJQUVPLGlDQUFJOzs7O0lBQVo7UUFDRSxJQUFJLENBQUMsT0FBTyxDQUFDLElBQUksRUFBRSxDQUFDO1FBQ3BCLElBQUksQ0FBQyxhQUFhLEdBQUcsS0FBSyxDQUFDO0lBQzdCLENBQUM7Ozs7Ozs7O0lBRU8sNENBQWU7Ozs7Ozs7SUFBdkIsVUFBd0IsUUFBaUIsRUFBRSxPQUFnQixFQUFFLEtBQWtCO1FBQS9FLGlCQWFDO1FBYjRELHNCQUFBLEVBQUEsU0FBaUIsQ0FBQztRQUM3RSxJQUFJLElBQUksQ0FBQyxVQUFVLEVBQUU7WUFDbkIsb0NBQW9DO1lBQ3BDLFlBQVksQ0FBQyxJQUFJLENBQUMsVUFBVSxDQUFDLENBQUM7WUFDOUIsSUFBSSxDQUFDLFVBQVUsR0FBRyxJQUFJLENBQUM7U0FDeEI7YUFBTSxJQUFJLEtBQUssR0FBRyxDQUFDLEVBQUU7WUFDcEIsSUFBSSxDQUFDLFVBQVUsR0FBRyxVQUFVOzs7WUFBQztnQkFDM0IsS0FBSSxDQUFDLFVBQVUsR0FBRyxJQUFJLENBQUM7Z0JBQ3ZCLE9BQU8sQ0FBQyxDQUFDLENBQUMsS0FBSSxDQUFDLElBQUksRUFBRSxDQUFDLENBQUMsQ0FBQyxLQUFJLENBQUMsSUFBSSxFQUFFLENBQUM7WUFDdEMsQ0FBQyxHQUFFLEtBQUssR0FBRyxJQUFJLENBQUMsQ0FBQztTQUNsQjthQUFNO1lBQ0wsT0FBTyxJQUFJLFFBQVEsQ0FBQyxDQUFDLENBQUMsSUFBSSxDQUFDLElBQUksRUFBRSxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsSUFBSSxFQUFFLENBQUMsQ0FBQywwSEFBMEg7U0FDNUs7SUFDSCxDQUFDO0lBRUQ7OztPQUdHOzs7Ozs7O0lBQ0ssMENBQWE7Ozs7OztJQUFyQixVQUFzQixPQUFzQjtRQUE1QyxpQkFnQkM7UUFmQyxJQUFJLElBQUksQ0FBQyxPQUFPLEVBQUU7WUFDaEIsTUFBTSxDQUFDLElBQUksQ0FBQyxPQUFPLENBQUMsQ0FBQyxPQUFPOzs7O1lBQUMsVUFBQSxHQUFHOztvQkFDeEIsTUFBTSxHQUFHLE9BQU8sQ0FBQyxHQUFHLENBQUM7Z0JBQzNCLElBQUksTUFBTSxFQUFFO29CQUNWLEtBQUksQ0FBQyxlQUFlLENBQUMsR0FBRyxFQUFFLE1BQU0sQ0FBQyxZQUFZLENBQUMsQ0FBQztpQkFDaEQ7WUFDSCxDQUFDLEVBQUMsQ0FBQztZQUVILElBQUksT0FBTyxDQUFDLFFBQVEsRUFBRTtnQkFDcEIsSUFBSSxDQUFDLE9BQU8sR0FBRyxPQUFPLENBQUMsUUFBUSxDQUFDLFlBQVksQ0FBQztnQkFDN0MsSUFBSSxDQUFDLGVBQWUsQ0FBQyxTQUFTLEVBQUUsT0FBTyxDQUFDLFFBQVEsQ0FBQyxZQUFZLENBQUMsQ0FBQzthQUNoRTtZQUVELElBQUksQ0FBQyxPQUFPLENBQUMsR0FBRyxDQUFDLFlBQVksRUFBRSxDQUFDLENBQUMsa0RBQWtEO1NBQ3BGO0lBQ0gsQ0FBQzs7Z0JBeExGLFNBQVMsU0FBQztvQkFDVCxRQUFRLEVBQUUsY0FBYztvQkFDeEIsUUFBUSxFQUFFLFdBQVc7b0JBQ3JCLElBQUksRUFBRTt3QkFDSiwwQkFBMEIsRUFBRSxlQUFlO3FCQUM1QztpQkFDRjs7OztnQkE1QkMsVUFBVTtnQkFZVixnQkFBZ0I7Z0JBZGhCLHdCQUF3QjtnQkFXeEIsU0FBUztnQkFXRixrQkFBa0IsdUJBeUR0QixRQUFRO2dCQTNETSxzQkFBc0IsdUJBNERwQyxJQUFJLFlBQUksUUFBUTs7O2tDQXpCbEIsTUFBTTswQkFFTixLQUFLLFNBQUMsWUFBWTsyQkFFbEIsS0FBSyxTQUFDLFNBQVM7NEJBSWYsS0FBSztvQ0FDTCxLQUFLO29DQUNMLEtBQUs7cUNBQ0wsS0FBSztpQ0FDTCxLQUFLOzRCQUNMLEtBQUs7NEJBQ0wsS0FBSzs4QkFDTCxLQUFLOztJQTJJUix5QkFBQztDQUFBLEFBekxELElBeUxDO1NBbExZLGtCQUFrQjs7O0lBRTdCLDJDQUErQjs7SUFDL0IsOENBQXlCOztJQUN6Qix3Q0FBMEI7O0lBQzFCLHFDQUFpQjs7SUFDakIscUNBQTBHOzs7Ozs7SUFHMUcsaURBVUU7Ozs7O0lBRUYsbUNBQXFDOzs7OztJQUNyQyx1Q0FBNEM7O0lBRTVDLDZDQUFpRTs7SUFFakUscUNBQWdFOztJQU1oRSx1Q0FBK0M7O0lBQy9DLCtDQUFtQzs7SUFDbkMsK0NBQW1DOztJQUNuQyxnREFBb0M7O0lBQ3BDLDRDQUFtRDs7SUFDbkQsdUNBQTJCOztJQUMzQix1Q0FBNEI7O0lBQzVCLHlDQUE2Qjs7SUFLM0Isd0NBQTZCOztJQUM3QixzQ0FBaUM7O0lBQ2pDLHNDQUF5Qzs7SUFDekMsc0NBQTBCOztJQUMxQixxQ0FBOEM7O0lBQzlDLHlDQUErRCIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQge1xuICBBZnRlclZpZXdJbml0LFxuICBDb21wb25lbnRGYWN0b3J5LFxuICBDb21wb25lbnRGYWN0b3J5UmVzb2x2ZXIsXG4gIERpcmVjdGl2ZSxcbiAgRWxlbWVudFJlZixcbiAgRXZlbnRFbWl0dGVyLFxuICBIb3N0LFxuICBJbnB1dCxcbiAgT25DaGFuZ2VzLFxuICBPbkRlc3Ryb3ksXG4gIE9uSW5pdCxcbiAgT3B0aW9uYWwsXG4gIE91dHB1dCxcbiAgUmVuZGVyZXIyLFxuICBTaW1wbGVDaGFuZ2VzLFxuICBUZW1wbGF0ZVJlZixcbiAgVmlld0NvbnRhaW5lclJlZlxufSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuaW1wb3J0IHsgU3Vic2NyaXB0aW9uIH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyBkaXN0aW5jdFVudGlsQ2hhbmdlZCB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuaW1wb3J0IHsgaXNOb3ROaWwsIE56Tm9BbmltYXRpb25EaXJlY3RpdmUgfSBmcm9tICduZy16b3Jyby1hbnRkL2NvcmUnO1xuXG5pbXBvcnQgeyBOelRvb2xUaXBDb21wb25lbnQgfSBmcm9tICcuL256LXRvb2x0aXAuY29tcG9uZW50JztcblxuQERpcmVjdGl2ZSh7XG4gIHNlbGVjdG9yOiAnW256LXRvb2x0aXBdJyxcbiAgZXhwb3J0QXM6ICduelRvb2x0aXAnLFxuICBob3N0OiB7XG4gICAgJ1tjbGFzcy5hbnQtdG9vbHRpcC1vcGVuXSc6ICdpc1Rvb2x0aXBPcGVuJ1xuICB9XG59KVxuZXhwb3J0IGNsYXNzIE56VG9vbHRpcERpcmVjdGl2ZSBpbXBsZW1lbnRzIEFmdGVyVmlld0luaXQsIE9uQ2hhbmdlcywgT25Jbml0LCBPbkRlc3Ryb3kge1xuICAvLyBbTk9URV0gSGVyZSBoYXJkIGNvZGVkLCBhbmQgbnpUaXRsZSB1c2VkIG9ubHkgdW5kZXIgTnpUb29sdGlwRGlyZWN0aXZlIGN1cnJlbnRseS5cbiAgaXNUb29sdGlwT3BlbjogYm9vbGVhbiA9IGZhbHNlO1xuICBpc0R5bmFtaWNUb29sdGlwID0gZmFsc2U7IC8vIEluZGljYXRlIHdoZXRoZXIgY3VycmVudCB0b29sdGlwIGlzIGR5bmFtaWMgY3JlYXRlZFxuICBkZWxheVRpbWVyOiBudW1iZXIgfCBudWxsOyAvLyBUaW1lciBmb3IgZGVsYXkgZW50ZXIvbGVhdmVcbiAgdmlzaWJsZTogYm9vbGVhbjtcbiAgZmFjdG9yeTogQ29tcG9uZW50RmFjdG9yeTxOelRvb2xUaXBDb21wb25lbnQ+ID0gdGhpcy5yZXNvbHZlci5yZXNvbHZlQ29tcG9uZW50RmFjdG9yeShOelRvb2xUaXBDb21wb25lbnQpO1xuXG4gIC8qKiBOYW1lcyBvZiBwcm9wZXJ0aWVzIHRoYXQgc2hvdWxkIGJlIHByb3h5IHRvIGNoaWxkIGNvbXBvbmVudC4gKi9cbiAgcHJvdGVjdGVkIG5lZWRQcm94eVByb3BlcnRpZXMgPSBbXG4gICAgJ256VGl0bGUnLFxuICAgICduekNvbnRlbnQnLFxuICAgICduek92ZXJsYXlDbGFzc05hbWUnLFxuICAgICduek92ZXJsYXlTdHlsZScsXG4gICAgJ256TW91c2VFbnRlckRlbGF5JyxcbiAgICAnbnpNb3VzZUxlYXZlRGVsYXknLFxuICAgICduelZpc2libGUnLFxuICAgICduelRyaWdnZXInLFxuICAgICduelBsYWNlbWVudCdcbiAgXTtcblxuICBwcm90ZWN0ZWQgc3Vic18gPSBuZXcgU3Vic2NyaXB0aW9uKCk7XG4gIHByb3RlY3RlZCBsaXN0ZW5lcnM6IEFycmF5PCgpID0+IHZvaWQ+ID0gW107XG5cbiAgQE91dHB1dCgpIHJlYWRvbmx5IG56VmlzaWJsZUNoYW5nZSA9IG5ldyBFdmVudEVtaXR0ZXI8Ym9vbGVhbj4oKTtcblxuICBASW5wdXQoJ256LXRvb2x0aXAnKSBuelRpdGxlOiBzdHJpbmcgfCBUZW1wbGF0ZVJlZjx2b2lkPiB8IG51bGw7XG5cbiAgQElucHV0KCduelRpdGxlJykgc2V0IHNldFRpdGxlKHRpdGxlOiBzdHJpbmcgfCBUZW1wbGF0ZVJlZjx2b2lkPiB8IG51bGwpIHtcbiAgICB0aGlzLm56VGl0bGUgPSB0aXRsZTtcbiAgfVxuXG4gIEBJbnB1dCgpIG56Q29udGVudDogc3RyaW5nIHwgVGVtcGxhdGVSZWY8dm9pZD47XG4gIEBJbnB1dCgpIG56TW91c2VFbnRlckRlbGF5OiBudW1iZXI7XG4gIEBJbnB1dCgpIG56TW91c2VMZWF2ZURlbGF5OiBudW1iZXI7XG4gIEBJbnB1dCgpIG56T3ZlcmxheUNsYXNzTmFtZTogc3RyaW5nO1xuICBASW5wdXQoKSBuek92ZXJsYXlTdHlsZTogeyBba2V5OiBzdHJpbmddOiBzdHJpbmcgfTtcbiAgQElucHV0KCkgbnpUcmlnZ2VyOiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56VmlzaWJsZTogYm9vbGVhbjtcbiAgQElucHV0KCkgbnpQbGFjZW1lbnQ6IHN0cmluZztcblxuICBbcHJvcGVydHk6IHN0cmluZ106IGFueTsgLy8gdHNsaW50OmRpc2FibGUtbGluZTpuby1hbnlcblxuICBjb25zdHJ1Y3RvcihcbiAgICBwdWJsaWMgZWxlbWVudFJlZjogRWxlbWVudFJlZixcbiAgICBwdWJsaWMgaG9zdFZpZXc6IFZpZXdDb250YWluZXJSZWYsXG4gICAgcHVibGljIHJlc29sdmVyOiBDb21wb25lbnRGYWN0b3J5UmVzb2x2ZXIsXG4gICAgcHVibGljIHJlbmRlcmVyOiBSZW5kZXJlcjIsXG4gICAgQE9wdGlvbmFsKCkgcHVibGljIHRvb2x0aXA6IE56VG9vbFRpcENvbXBvbmVudCxcbiAgICBASG9zdCgpIEBPcHRpb25hbCgpIHB1YmxpYyBub0FuaW1hdGlvbj86IE56Tm9BbmltYXRpb25EaXJlY3RpdmVcbiAgKSB7fVxuXG4gIG5nT25DaGFuZ2VzKGNoYW5nZXM6IFNpbXBsZUNoYW5nZXMpOiB2b2lkIHtcbiAgICB0aGlzLnVwZGF0ZVByb3hpZXMoY2hhbmdlcyk7XG4gIH1cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICAvLyBTdXBwb3J0IGZhc3RlciB0b29sdGlwIG1vZGU6IDxhIG56LXRvb2x0aXA9XCJ4eHhcIj48L2E+LiBbTk9URV0gVXNlZCBvbmx5IHVuZGVyIE56VG9vbHRpcERpcmVjdGl2ZSBjdXJyZW50bHkuXG4gICAgaWYgKCF0aGlzLnRvb2x0aXApIHtcbiAgICAgIGNvbnN0IHRvb2x0aXBDb21wb25lbnQgPSB0aGlzLmhvc3RWaWV3LmNyZWF0ZUNvbXBvbmVudCh0aGlzLmZhY3RvcnkpO1xuICAgICAgdGhpcy50b29sdGlwID0gdG9vbHRpcENvbXBvbmVudC5pbnN0YW5jZTtcbiAgICAgIHRoaXMudG9vbHRpcC5ub0FuaW1hdGlvbiA9IHRoaXMubm9BbmltYXRpb247XG4gICAgICAvLyBSZW1vdmUgZWxlbWVudCB3aGVuIHVzZSBkaXJlY3RpdmUgaHR0cHM6Ly9naXRodWIuY29tL05HLVpPUlJPL25nLXpvcnJvLWFudGQvaXNzdWVzLzE5NjdcbiAgICAgIHRoaXMucmVuZGVyZXIucmVtb3ZlQ2hpbGQoXG4gICAgICAgIHRoaXMucmVuZGVyZXIucGFyZW50Tm9kZSh0aGlzLmVsZW1lbnRSZWYubmF0aXZlRWxlbWVudCksXG4gICAgICAgIHRvb2x0aXBDb21wb25lbnQubG9jYXRpb24ubmF0aXZlRWxlbWVudFxuICAgICAgKTtcbiAgICAgIHRoaXMuaXNEeW5hbWljVG9vbHRpcCA9IHRydWU7XG4gICAgICB0aGlzLm5lZWRQcm94eVByb3BlcnRpZXMuZm9yRWFjaChwcm9wZXJ0eSA9PiB0aGlzLnVwZGF0ZUNvbXBWYWx1ZShwcm9wZXJ0eSwgdGhpc1twcm9wZXJ0eV0pKTtcbiAgICAgIGNvbnN0IHZpc2libGVfID0gdGhpcy50b29sdGlwLm56VmlzaWJsZUNoYW5nZS5waXBlKGRpc3RpbmN0VW50aWxDaGFuZ2VkKCkpLnN1YnNjcmliZShkYXRhID0+IHtcbiAgICAgICAgdGhpcy52aXNpYmxlID0gZGF0YTtcbiAgICAgICAgdGhpcy5uelZpc2libGVDaGFuZ2UuZW1pdChkYXRhKTtcbiAgICAgIH0pO1xuICAgICAgdGhpcy5zdWJzXy5hZGQodmlzaWJsZV8pO1xuICAgIH1cbiAgICB0aGlzLnRvb2x0aXAuc2V0T3ZlcmxheU9yaWdpbih0aGlzKTtcbiAgfVxuXG4gIG5nQWZ0ZXJWaWV3SW5pdCgpOiB2b2lkIHtcbiAgICBpZiAodGhpcy50b29sdGlwLm56VHJpZ2dlciA9PT0gJ2hvdmVyJykge1xuICAgICAgbGV0IG92ZXJsYXlFbGVtZW50OiBIVE1MRWxlbWVudDtcbiAgICAgIGNvbnN0IGxpc3RlbmVyTW91c2VFbnRlciA9IHRoaXMucmVuZGVyZXIubGlzdGVuKHRoaXMuZWxlbWVudFJlZi5uYXRpdmVFbGVtZW50LCAnbW91c2VlbnRlcicsICgpID0+XG4gICAgICAgIHRoaXMuZGVsYXlFbnRlckxlYXZlKHRydWUsIHRydWUsIHRoaXMudG9vbHRpcC5uek1vdXNlRW50ZXJEZWxheSlcbiAgICAgICk7XG4gICAgICB0aGlzLmxpc3RlbmVycy5wdXNoKGxpc3RlbmVyTW91c2VFbnRlcik7XG5cbiAgICAgIGNvbnN0IGxpc3RlbmVyTW91c2VMZWF2ZSA9IHRoaXMucmVuZGVyZXIubGlzdGVuKHRoaXMuZWxlbWVudFJlZi5uYXRpdmVFbGVtZW50LCAnbW91c2VsZWF2ZScsICgpID0+IHtcbiAgICAgICAgdGhpcy5kZWxheUVudGVyTGVhdmUodHJ1ZSwgZmFsc2UsIHRoaXMudG9vbHRpcC5uek1vdXNlTGVhdmVEZWxheSk7XG4gICAgICAgIGlmICh0aGlzLnRvb2x0aXAub3ZlcmxheS5vdmVybGF5UmVmICYmICFvdmVybGF5RWxlbWVudCkge1xuICAgICAgICAgIC8vIE5PVEU6IHdlIGJpbmQgZXZlbnRzIHVuZGVyIFwibW91c2VsZWF2ZVwiIGR1ZSB0byB0aGUgb3ZlcmxheVJlZiBpcyBvbmx5IGNyZWF0ZWQgYWZ0ZXIgdGhlIG92ZXJsYXkgd2FzIGNvbXBsZXRlbHkgc2hvd24gdXBcbiAgICAgICAgICBvdmVybGF5RWxlbWVudCA9IHRoaXMudG9vbHRpcC5vdmVybGF5Lm92ZXJsYXlSZWYub3ZlcmxheUVsZW1lbnQ7XG4gICAgICAgICAgY29uc3QgbGlzdGVuZXJPdmVybGF5TW91c2VFbnRlciA9IHRoaXMucmVuZGVyZXIubGlzdGVuKG92ZXJsYXlFbGVtZW50LCAnbW91c2VlbnRlcicsICgpID0+XG4gICAgICAgICAgICB0aGlzLmRlbGF5RW50ZXJMZWF2ZShmYWxzZSwgdHJ1ZSlcbiAgICAgICAgICApO1xuICAgICAgICAgIHRoaXMubGlzdGVuZXJzLnB1c2gobGlzdGVuZXJPdmVybGF5TW91c2VFbnRlcik7XG5cbiAgICAgICAgICBjb25zdCBsaXN0ZW5lck92ZXJsYXlNb3VzZUxlYXZlID0gdGhpcy5yZW5kZXJlci5saXN0ZW4ob3ZlcmxheUVsZW1lbnQsICdtb3VzZWxlYXZlJywgKCkgPT5cbiAgICAgICAgICAgIHRoaXMuZGVsYXlFbnRlckxlYXZlKGZhbHNlLCBmYWxzZSlcbiAgICAgICAgICApO1xuICAgICAgICAgIHRoaXMubGlzdGVuZXJzLnB1c2gobGlzdGVuZXJPdmVybGF5TW91c2VMZWF2ZSk7XG4gICAgICAgIH1cbiAgICAgIH0pO1xuICAgICAgdGhpcy5saXN0ZW5lcnMucHVzaChsaXN0ZW5lck1vdXNlTGVhdmUpO1xuICAgIH0gZWxzZSBpZiAodGhpcy50b29sdGlwLm56VHJpZ2dlciA9PT0gJ2ZvY3VzJykge1xuICAgICAgY29uc3QgbGlzdGVuZXJGb2N1cyA9IHRoaXMucmVuZGVyZXIubGlzdGVuKHRoaXMuZWxlbWVudFJlZi5uYXRpdmVFbGVtZW50LCAnZm9jdXMnLCAoKSA9PiB0aGlzLnNob3coKSk7XG4gICAgICB0aGlzLmxpc3RlbmVycy5wdXNoKGxpc3RlbmVyRm9jdXMpO1xuXG4gICAgICBjb25zdCBsaXN0ZW5lckJsdXIgPSB0aGlzLnJlbmRlcmVyLmxpc3Rlbih0aGlzLmVsZW1lbnRSZWYubmF0aXZlRWxlbWVudCwgJ2JsdXInLCAoKSA9PiB0aGlzLmhpZGUoKSk7XG4gICAgICB0aGlzLmxpc3RlbmVycy5wdXNoKGxpc3RlbmVyQmx1cik7XG4gICAgfSBlbHNlIGlmICh0aGlzLnRvb2x0aXAubnpUcmlnZ2VyID09PSAnY2xpY2snKSB7XG4gICAgICBjb25zdCBsaXN0ZW5lckNsaWNrID0gdGhpcy5yZW5kZXJlci5saXN0ZW4odGhpcy5lbGVtZW50UmVmLm5hdGl2ZUVsZW1lbnQsICdjbGljaycsIGUgPT4ge1xuICAgICAgICBlLnByZXZlbnREZWZhdWx0KCk7XG4gICAgICAgIHRoaXMuc2hvdygpO1xuICAgICAgfSk7XG4gICAgICB0aGlzLmxpc3RlbmVycy5wdXNoKGxpc3RlbmVyQ2xpY2spO1xuICAgIH1cbiAgfVxuXG4gIG5nT25EZXN0cm95KCk6IHZvaWQge1xuICAgIHRoaXMuc3Vic18udW5zdWJzY3JpYmUoKTtcbiAgICB0aGlzLmxpc3RlbmVycy5mb3JFYWNoKGxpc3RlbmVyID0+IHtcbiAgICAgIGxpc3RlbmVyKCk7XG4gICAgfSk7XG4gIH1cblxuICAvLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6bm8tYW55XG4gIHByb3RlY3RlZCB1cGRhdGVDb21wVmFsdWUoa2V5OiBzdHJpbmcsIHZhbHVlOiBhbnkpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5pc0R5bmFtaWNUb29sdGlwICYmIGlzTm90TmlsKHZhbHVlKSkge1xuICAgICAgdGhpcy50b29sdGlwW2tleV0gPSB2YWx1ZTtcbiAgICB9XG4gIH1cblxuICBwcml2YXRlIHNob3coKTogdm9pZCB7XG4gICAgdGhpcy50b29sdGlwLnNob3coKTtcbiAgICB0aGlzLmlzVG9vbHRpcE9wZW4gPSB0cnVlO1xuICB9XG5cbiAgcHJpdmF0ZSBoaWRlKCk6IHZvaWQge1xuICAgIHRoaXMudG9vbHRpcC5oaWRlKCk7XG4gICAgdGhpcy5pc1Rvb2x0aXBPcGVuID0gZmFsc2U7XG4gIH1cblxuICBwcml2YXRlIGRlbGF5RW50ZXJMZWF2ZShpc09yaWdpbjogYm9vbGVhbiwgaXNFbnRlcjogYm9vbGVhbiwgZGVsYXk6IG51bWJlciA9IC0xKTogdm9pZCB7XG4gICAgaWYgKHRoaXMuZGVsYXlUaW1lcikge1xuICAgICAgLy8gQ2xlYXIgdGltZXIgZHVyaW5nIHRoZSBkZWxheSB0aW1lXG4gICAgICBjbGVhclRpbWVvdXQodGhpcy5kZWxheVRpbWVyKTtcbiAgICAgIHRoaXMuZGVsYXlUaW1lciA9IG51bGw7XG4gICAgfSBlbHNlIGlmIChkZWxheSA+IDApIHtcbiAgICAgIHRoaXMuZGVsYXlUaW1lciA9IHNldFRpbWVvdXQoKCkgPT4ge1xuICAgICAgICB0aGlzLmRlbGF5VGltZXIgPSBudWxsO1xuICAgICAgICBpc0VudGVyID8gdGhpcy5zaG93KCkgOiB0aGlzLmhpZGUoKTtcbiAgICAgIH0sIGRlbGF5ICogMTAwMCk7XG4gICAgfSBlbHNlIHtcbiAgICAgIGlzRW50ZXIgJiYgaXNPcmlnaW4gPyB0aGlzLnNob3coKSA6IHRoaXMuaGlkZSgpOyAvLyBbQ29tcGF0aWJsZV0gVGhlIFwiaXNPcmlnaW5cIiBpcyB1c2VkIGR1ZSB0byB0aGUgdG9vbHRpcCB3aWxsIG5vdCBoaWRlIGltbWVkaWF0ZWx5IChtYXkgY2F1c2VkIGJ5IHRoZSBmYWRlLW91dCBhbmltYXRpb24pXG4gICAgfVxuICB9XG5cbiAgLyoqXG4gICAqIFNldCBpbnB1dHMgb2YgY2hpbGQgY29tcG9uZW50cyB3aGVuIHRoaXMgY29tcG9uZW50J3MgaW5wdXRzIGNoYW5nZS5cbiAgICogQHBhcmFtIGNoYW5nZXNcbiAgICovXG4gIHByaXZhdGUgdXBkYXRlUHJveGllcyhjaGFuZ2VzOiBTaW1wbGVDaGFuZ2VzKTogdm9pZCB7XG4gICAgaWYgKHRoaXMudG9vbHRpcCkge1xuICAgICAgT2JqZWN0LmtleXMoY2hhbmdlcykuZm9yRWFjaChrZXkgPT4ge1xuICAgICAgICBjb25zdCBjaGFuZ2UgPSBjaGFuZ2VzW2tleV07XG4gICAgICAgIGlmIChjaGFuZ2UpIHtcbiAgICAgICAgICB0aGlzLnVwZGF0ZUNvbXBWYWx1ZShrZXksIGNoYW5nZS5jdXJyZW50VmFsdWUpO1xuICAgICAgICB9XG4gICAgICB9KTtcblxuICAgICAgaWYgKGNoYW5nZXMuc2V0VGl0bGUpIHtcbiAgICAgICAgdGhpcy5uelRpdGxlID0gY2hhbmdlcy5zZXRUaXRsZS5jdXJyZW50VmFsdWU7XG4gICAgICAgIHRoaXMudXBkYXRlQ29tcFZhbHVlKCduelRpdGxlJywgY2hhbmdlcy5zZXRUaXRsZS5jdXJyZW50VmFsdWUpO1xuICAgICAgfVxuXG4gICAgICB0aGlzLnRvb2x0aXAuY2RyLm1hcmtGb3JDaGVjaygpOyAvLyBNYW51YWxseSB0cmlnZ2VyIGNoYW5nZSBkZXRlY3Rpb24gb2YgY29tcG9uZW50LlxuICAgIH1cbiAgfVxufVxuIl19