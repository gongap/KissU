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
import { CdkConnectedOverlay, CdkOverlayOrigin } from '@angular/cdk/overlay';
import { Platform } from '@angular/cdk/platform';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ContentChildren, ElementRef, EventEmitter, Host, Input, Optional, Output, QueryList, ViewChild, ViewEncapsulation } from '@angular/core';
import { combineLatest, merge, Subject } from 'rxjs';
import { flatMap, map, startWith, takeUntil } from 'rxjs/operators';
import { collapseMotion, getPlacementName, slideMotion, zoomBigMotion, DEFAULT_SUBMENU_POSITIONS, InputBoolean, NzMenuBaseService, NzNoAnimationDirective, NzUpdateHostClassService, POSITION_MAP } from 'ng-zorro-antd/core';
import { NzMenuItemDirective } from './nz-menu-item.directive';
import { NzSubmenuService } from './nz-submenu.service';
var NzSubMenuComponent = /** @class */ (function () {
    function NzSubMenuComponent(elementRef, nzMenuService, cdr, nzSubmenuService, nzUpdateHostClassService, platform, noAnimation) {
        this.elementRef = elementRef;
        this.nzMenuService = nzMenuService;
        this.cdr = cdr;
        this.nzSubmenuService = nzSubmenuService;
        this.nzUpdateHostClassService = nzUpdateHostClassService;
        this.platform = platform;
        this.noAnimation = noAnimation;
        this.nzOpen = false;
        this.nzDisabled = false;
        this.nzOpenChange = new EventEmitter();
        this.placement = 'rightTop';
        this.expandState = 'collapsed';
        this.overlayPositions = tslib_1.__spread(DEFAULT_SUBMENU_POSITIONS);
        this.destroy$ = new Subject();
        this.isChildMenuSelected = false;
        this.isMouseHover = false;
    }
    /**
     * @param {?} open
     * @return {?}
     */
    NzSubMenuComponent.prototype.setOpenState = /**
     * @param {?} open
     * @return {?}
     */
    function (open) {
        this.nzSubmenuService.setOpenState(open);
    };
    /**
     * @return {?}
     */
    NzSubMenuComponent.prototype.clickSubMenuTitle = /**
     * @return {?}
     */
    function () {
        if (this.nzSubmenuService.mode === 'inline' && !this.nzMenuService.isInDropDown && !this.nzDisabled) {
            this.setOpenState(!this.nzOpen);
        }
    };
    /**
     * @param {?} value
     * @return {?}
     */
    NzSubMenuComponent.prototype.setMouseEnterState = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        this.isMouseHover = value;
        this.setClassMap();
        this.nzSubmenuService.setMouseEnterState(value);
    };
    /**
     * @return {?}
     */
    NzSubMenuComponent.prototype.setTriggerWidth = /**
     * @return {?}
     */
    function () {
        if (this.nzSubmenuService.mode === 'horizontal' && this.platform.isBrowser) {
            this.triggerWidth = this.cdkOverlayOrigin.nativeElement.getBoundingClientRect().width;
        }
    };
    /**
     * @param {?} position
     * @return {?}
     */
    NzSubMenuComponent.prototype.onPositionChange = /**
     * @param {?} position
     * @return {?}
     */
    function (position) {
        this.placement = (/** @type {?} */ (getPlacementName(position)));
        this.cdr.markForCheck();
    };
    /**
     * @return {?}
     */
    NzSubMenuComponent.prototype.setClassMap = /**
     * @return {?}
     */
    function () {
        var _a;
        /** @type {?} */
        var prefixName = this.nzMenuService.isInDropDown ? 'ant-dropdown-menu-submenu' : 'ant-menu-submenu';
        this.nzUpdateHostClassService.updateHostClass(this.elementRef.nativeElement, (_a = {},
            _a["" + prefixName] = true,
            _a[prefixName + "-disabled"] = this.nzDisabled,
            _a[prefixName + "-open"] = this.nzOpen,
            _a[prefixName + "-selected"] = this.isChildMenuSelected,
            _a[prefixName + "-" + this.nzSubmenuService.mode] = true,
            _a[prefixName + "-active"] = this.isMouseHover && !this.nzDisabled,
            _a));
    };
    /**
     * @return {?}
     */
    NzSubMenuComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        combineLatest(this.nzSubmenuService.mode$, this.nzSubmenuService.open$)
            .pipe(takeUntil(this.destroy$))
            .subscribe((/**
         * @param {?} data
         * @return {?}
         */
        function (data) {
            /** @type {?} */
            var mode = data[0];
            /** @type {?} */
            var open = data[1];
            if (open && mode === 'inline') {
                _this.expandState = 'expanded';
            }
            else if (open && mode === 'horizontal') {
                _this.expandState = 'bottom';
            }
            else if (open && mode === 'vertical') {
                _this.expandState = 'active';
            }
            else {
                _this.isMouseHover = false;
                _this.expandState = 'collapsed';
            }
            _this.overlayPositions =
                mode === 'horizontal' ? [POSITION_MAP.bottomLeft] : [POSITION_MAP.rightTop, POSITION_MAP.leftTop];
            if (open !== _this.nzOpen) {
                _this.nzOpen = open;
                _this.nzOpenChange.emit(_this.nzOpen);
            }
            _this.setClassMap();
            _this.setTriggerWidth();
        }));
        this.nzSubmenuService.menuOpen$.pipe(takeUntil(this.destroy$)).subscribe((/**
         * @param {?} data
         * @return {?}
         */
        function (data) {
            _this.nzMenuService.menuOpen$.next(data);
        }));
        merge(this.nzMenuService.mode$, this.nzMenuService.inlineIndent$, this.nzSubmenuService.level$, this.nzSubmenuService.open$, this.nzSubmenuService.mode$)
            .pipe(takeUntil(this.destroy$))
            .subscribe((/**
         * @return {?}
         */
        function () {
            _this.cdr.markForCheck();
        }));
    };
    /**
     * @return {?}
     */
    NzSubMenuComponent.prototype.ngAfterContentInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        this.setTriggerWidth();
        this.listOfNzMenuItemDirective.changes
            .pipe(startWith(true), flatMap((/**
         * @return {?}
         */
        function () {
            return merge.apply(void 0, tslib_1.__spread([_this.listOfNzMenuItemDirective.changes], _this.listOfNzMenuItemDirective.map((/**
             * @param {?} menu
             * @return {?}
             */
            function (menu) { return menu.selected$; }))));
        })), map((/**
         * @return {?}
         */
        function () { return _this.listOfNzMenuItemDirective.some((/**
         * @param {?} e
         * @return {?}
         */
        function (e) { return e.nzSelected; })); })), takeUntil(this.destroy$))
            .subscribe((/**
         * @param {?} selected
         * @return {?}
         */
        function (selected) {
            _this.isChildMenuSelected = selected;
            _this.setClassMap();
        }));
    };
    /**
     * @param {?} changes
     * @return {?}
     */
    NzSubMenuComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        if (changes.nzOpen) {
            this.nzSubmenuService.setOpenState(this.nzOpen);
        }
        if (changes.nzDisabled) {
            this.nzSubmenuService.disabled = this.nzDisabled;
            this.setClassMap();
        }
    };
    /**
     * @return {?}
     */
    NzSubMenuComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.destroy$.next();
        this.destroy$.complete();
    };
    NzSubMenuComponent.decorators = [
        { type: Component, args: [{
                    selector: '[nz-submenu]',
                    exportAs: 'nzSubmenu',
                    providers: [NzSubmenuService, NzUpdateHostClassService],
                    animations: [collapseMotion, zoomBigMotion, slideMotion],
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    preserveWhitespaces: false,
                    template: "<div cdkOverlayOrigin\n  #origin=\"cdkOverlayOrigin\"\n  [class.ant-dropdown-menu-submenu-title]=\"nzMenuService.isInDropDown\"\n  [class.ant-menu-submenu-title]=\"!nzMenuService.isInDropDown\"\n  [style.paddingLeft.px]=\"nzMenuService.mode === 'inline'? (nzPaddingLeft ? nzPaddingLeft : nzSubmenuService.level * nzMenuService.inlineIndent) : null\"\n  (mouseenter)=\"setMouseEnterState(true)\"\n  (mouseleave)=\"setMouseEnterState(false)\"\n  (click)=\"clickSubMenuTitle()\">\n  <ng-content select=\"[title]\"></ng-content>\n  <span *ngIf=\"nzMenuService.isInDropDown; else notDropdownTpl\" class=\"ant-dropdown-menu-submenu-arrow\">\n    <i nz-icon type=\"right\" class=\"anticon-right ant-dropdown-menu-submenu-arrow-icon\"></i>\n  </span>\n  <ng-template #notDropdownTpl><i class=\"ant-menu-submenu-arrow\"></i></ng-template>\n</div>\n<ul *ngIf=\"nzMenuService.mode === 'inline'\"\n  [@collapseMotion]=\"expandState\"\n  [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n  [ngClass]=\"nzMenuClassName\"\n  class=\"ant-menu ant-menu-inline ant-menu-sub\">\n  <ng-template [ngTemplateOutlet]=\"subMenuTemplate\"></ng-template>\n</ul>\n<ng-template cdkConnectedOverlay\n  (positionChange)=\"onPositionChange($event)\"\n  [cdkConnectedOverlayPositions]=\"overlayPositions\"\n  [cdkConnectedOverlayOrigin]=\"origin\"\n  [cdkConnectedOverlayWidth]=\"triggerWidth\"\n  [cdkConnectedOverlayOpen]=\"nzOpen && nzMenuService.mode !== 'inline'\">\n  <div class=\"ant-menu-submenu ant-menu-submenu-popup\"\n    [@slideMotion]=\"expandState\"\n    [@zoomBigMotion]=\"expandState\"\n    [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n    [class.ant-menu-light]=\"nzMenuService.theme === 'light'\"\n    [class.ant-menu-dark]=\"nzMenuService.theme === 'dark'\"\n    [class.ant-menu-submenu-placement-bottomLeft]=\"nzSubmenuService.mode === 'horizontal'\"\n    [class.ant-menu-submenu-placement-rightTop]=\"nzSubmenuService.mode === 'vertical' && placement === 'rightTop'\"\n    [class.ant-menu-submenu-placement-leftTop]=\"nzSubmenuService.mode === 'vertical' && placement === 'leftTop'\"\n    (mouseleave)=\"setMouseEnterState(false)\"\n    (mouseenter)=\"setMouseEnterState(true)\">\n    <ul [class.ant-dropdown-menu]=\"nzMenuService.isInDropDown\"\n      [class.ant-menu]=\"!nzMenuService.isInDropDown\"\n      [class.ant-dropdown-menu-vertical]=\"nzMenuService.isInDropDown\"\n      [class.ant-menu-vertical]=\"!nzMenuService.isInDropDown\"\n      [class.ant-dropdown-menu-sub]=\"nzMenuService.isInDropDown\"\n      [class.ant-menu-sub]=\"!nzMenuService.isInDropDown\"\n      [ngClass]=\"nzMenuClassName\">\n      <ng-template [ngTemplateOutlet]=\"subMenuTemplate\"></ng-template>\n    </ul>\n  </div>\n</ng-template>\n\n<ng-template #subMenuTemplate>\n  <ng-content></ng-content>\n</ng-template>",
                    styles: ["\n      .ant-menu-submenu-placement-bottomLeft {\n        top: 6px;\n        position: relative;\n      }\n\n      .ant-menu-submenu-placement-rightTop {\n        left: 4px;\n        position: relative;\n      }\n\n      .ant-menu-submenu-placement-leftTop {\n        right: 4px;\n        position: relative;\n      }\n    "]
                }] }
    ];
    /** @nocollapse */
    NzSubMenuComponent.ctorParameters = function () { return [
        { type: ElementRef },
        { type: NzMenuBaseService },
        { type: ChangeDetectorRef },
        { type: NzSubmenuService },
        { type: NzUpdateHostClassService },
        { type: Platform },
        { type: NzNoAnimationDirective, decorators: [{ type: Host }, { type: Optional }] }
    ]; };
    NzSubMenuComponent.propDecorators = {
        nzMenuClassName: [{ type: Input }],
        nzPaddingLeft: [{ type: Input }],
        nzOpen: [{ type: Input }],
        nzDisabled: [{ type: Input }],
        nzOpenChange: [{ type: Output }],
        cdkConnectedOverlay: [{ type: ViewChild, args: [CdkConnectedOverlay,] }],
        cdkOverlayOrigin: [{ type: ViewChild, args: [CdkOverlayOrigin, { read: ElementRef },] }],
        listOfNzSubMenuComponent: [{ type: ContentChildren, args: [NzSubMenuComponent, { descendants: true },] }],
        listOfNzMenuItemDirective: [{ type: ContentChildren, args: [NzMenuItemDirective, { descendants: true },] }]
    };
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzSubMenuComponent.prototype, "nzOpen", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzSubMenuComponent.prototype, "nzDisabled", void 0);
    return NzSubMenuComponent;
}());
export { NzSubMenuComponent };
if (false) {
    /** @type {?} */
    NzSubMenuComponent.prototype.nzMenuClassName;
    /** @type {?} */
    NzSubMenuComponent.prototype.nzPaddingLeft;
    /** @type {?} */
    NzSubMenuComponent.prototype.nzOpen;
    /** @type {?} */
    NzSubMenuComponent.prototype.nzDisabled;
    /** @type {?} */
    NzSubMenuComponent.prototype.nzOpenChange;
    /** @type {?} */
    NzSubMenuComponent.prototype.cdkConnectedOverlay;
    /** @type {?} */
    NzSubMenuComponent.prototype.cdkOverlayOrigin;
    /** @type {?} */
    NzSubMenuComponent.prototype.listOfNzSubMenuComponent;
    /** @type {?} */
    NzSubMenuComponent.prototype.listOfNzMenuItemDirective;
    /** @type {?} */
    NzSubMenuComponent.prototype.placement;
    /** @type {?} */
    NzSubMenuComponent.prototype.triggerWidth;
    /** @type {?} */
    NzSubMenuComponent.prototype.expandState;
    /** @type {?} */
    NzSubMenuComponent.prototype.overlayPositions;
    /**
     * @type {?}
     * @private
     */
    NzSubMenuComponent.prototype.destroy$;
    /**
     * @type {?}
     * @private
     */
    NzSubMenuComponent.prototype.isChildMenuSelected;
    /**
     * @type {?}
     * @private
     */
    NzSubMenuComponent.prototype.isMouseHover;
    /**
     * @type {?}
     * @private
     */
    NzSubMenuComponent.prototype.elementRef;
    /** @type {?} */
    NzSubMenuComponent.prototype.nzMenuService;
    /**
     * @type {?}
     * @private
     */
    NzSubMenuComponent.prototype.cdr;
    /** @type {?} */
    NzSubMenuComponent.prototype.nzSubmenuService;
    /**
     * @type {?}
     * @private
     */
    NzSubMenuComponent.prototype.nzUpdateHostClassService;
    /**
     * @type {?}
     * @private
     */
    NzSubMenuComponent.prototype.platform;
    /** @type {?} */
    NzSubMenuComponent.prototype.noAnimation;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotc3VibWVudS5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9uZy16b3Jyby1hbnRkL21lbnUvIiwic291cmNlcyI6WyJuei1zdWJtZW51LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQUUsbUJBQW1CLEVBQUUsZ0JBQWdCLEVBQWtDLE1BQU0sc0JBQXNCLENBQUM7QUFDN0csT0FBTyxFQUFFLFFBQVEsRUFBRSxNQUFNLHVCQUF1QixDQUFDO0FBQ2pELE9BQU8sRUFFTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxlQUFlLEVBQ2YsVUFBVSxFQUNWLFlBQVksRUFDWixJQUFJLEVBQ0osS0FBSyxFQUlMLFFBQVEsRUFDUixNQUFNLEVBQ04sU0FBUyxFQUVULFNBQVMsRUFDVCxpQkFBaUIsRUFDbEIsTUFBTSxlQUFlLENBQUM7QUFFdkIsT0FBTyxFQUFFLGFBQWEsRUFBRSxLQUFLLEVBQUUsT0FBTyxFQUFFLE1BQU0sTUFBTSxDQUFDO0FBQ3JELE9BQU8sRUFBRSxPQUFPLEVBQUUsR0FBRyxFQUFFLFNBQVMsRUFBRSxTQUFTLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUVwRSxPQUFPLEVBQ0wsY0FBYyxFQUNkLGdCQUFnQixFQUNoQixXQUFXLEVBQ1gsYUFBYSxFQUNiLHlCQUF5QixFQUN6QixZQUFZLEVBQ1osaUJBQWlCLEVBQ2pCLHNCQUFzQixFQUN0Qix3QkFBd0IsRUFDeEIsWUFBWSxFQUNiLE1BQU0sb0JBQW9CLENBQUM7QUFFNUIsT0FBTyxFQUFFLG1CQUFtQixFQUFFLE1BQU0sMEJBQTBCLENBQUM7QUFDL0QsT0FBTyxFQUFFLGdCQUFnQixFQUFFLE1BQU0sc0JBQXNCLENBQUM7QUFFeEQ7SUEwRkUsNEJBQ1UsVUFBc0IsRUFDdkIsYUFBZ0MsRUFDL0IsR0FBc0IsRUFDdkIsZ0JBQWtDLEVBQ2pDLHdCQUFrRCxFQUNsRCxRQUFrQixFQUNDLFdBQW9DO1FB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bGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQgeyBDZGtDb25uZWN0ZWRPdmVybGF5LCBDZGtPdmVybGF5T3JpZ2luLCBDb25uZWN0ZWRPdmVybGF5UG9zaXRpb25DaGFuZ2UgfSBmcm9tICdAYW5ndWxhci9jZGsvb3ZlcmxheSc7XG5pbXBvcnQgeyBQbGF0Zm9ybSB9IGZyb20gJ0Bhbmd1bGFyL2Nkay9wbGF0Zm9ybSc7XG5pbXBvcnQge1xuICBBZnRlckNvbnRlbnRJbml0LFxuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gIENvbXBvbmVudCxcbiAgQ29udGVudENoaWxkcmVuLFxuICBFbGVtZW50UmVmLFxuICBFdmVudEVtaXR0ZXIsXG4gIEhvc3QsXG4gIElucHV0LFxuICBPbkNoYW5nZXMsXG4gIE9uRGVzdHJveSxcbiAgT25Jbml0LFxuICBPcHRpb25hbCxcbiAgT3V0cHV0LFxuICBRdWVyeUxpc3QsXG4gIFNpbXBsZUNoYW5nZXMsXG4gIFZpZXdDaGlsZCxcbiAgVmlld0VuY2Fwc3VsYXRpb25cbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmltcG9ydCB7IGNvbWJpbmVMYXRlc3QsIG1lcmdlLCBTdWJqZWN0IH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyBmbGF0TWFwLCBtYXAsIHN0YXJ0V2l0aCwgdGFrZVVudGlsIH0gZnJvbSAncnhqcy9vcGVyYXRvcnMnO1xuXG5pbXBvcnQge1xuICBjb2xsYXBzZU1vdGlvbixcbiAgZ2V0UGxhY2VtZW50TmFtZSxcbiAgc2xpZGVNb3Rpb24sXG4gIHpvb21CaWdNb3Rpb24sXG4gIERFRkFVTFRfU1VCTUVOVV9QT1NJVElPTlMsXG4gIElucHV0Qm9vbGVhbixcbiAgTnpNZW51QmFzZVNlcnZpY2UsXG4gIE56Tm9BbmltYXRpb25EaXJlY3RpdmUsXG4gIE56VXBkYXRlSG9zdENsYXNzU2VydmljZSxcbiAgUE9TSVRJT05fTUFQXG59IGZyb20gJ25nLXpvcnJvLWFudGQvY29yZSc7XG5cbmltcG9ydCB7IE56TWVudUl0ZW1EaXJlY3RpdmUgfSBmcm9tICcuL256LW1lbnUtaXRlbS5kaXJlY3RpdmUnO1xuaW1wb3J0IHsgTnpTdWJtZW51U2VydmljZSB9IGZyb20gJy4vbnotc3VibWVudS5zZXJ2aWNlJztcblxuQENvbXBvbmVudCh7XG4gIHNlbGVjdG9yOiAnW256LXN1Ym1lbnVdJyxcbiAgZXhwb3J0QXM6ICduelN1Ym1lbnUnLFxuICBwcm92aWRlcnM6IFtOelN1Ym1lbnVTZXJ2aWNlLCBOelVwZGF0ZUhvc3RDbGFzc1NlcnZpY2VdLFxuICBhbmltYXRpb25zOiBbY29sbGFwc2VNb3Rpb24sIHpvb21CaWdNb3Rpb24sIHNsaWRlTW90aW9uXSxcbiAgZW5jYXBzdWxhdGlvbjogVmlld0VuY2Fwc3VsYXRpb24uTm9uZSxcbiAgY2hhbmdlRGV0ZWN0aW9uOiBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneS5PblB1c2gsXG4gIHByZXNlcnZlV2hpdGVzcGFjZXM6IGZhbHNlLFxuICB0ZW1wbGF0ZVVybDogJy4vbnotc3VibWVudS5jb21wb25lbnQuaHRtbCcsXG4gIHN0eWxlczogW1xuICAgIGBcbiAgICAgIC5hbnQtbWVudS1zdWJtZW51LXBsYWNlbWVudC1ib3R0b21MZWZ0IHtcbiAgICAgICAgdG9wOiA2cHg7XG4gICAgICAgIHBvc2l0aW9uOiByZWxhdGl2ZTtcbiAgICAgIH1cblxuICAgICAgLmFudC1tZW51LXN1Ym1lbnUtcGxhY2VtZW50LXJpZ2h0VG9wIHtcbiAgICAgICAgbGVmdDogNHB4O1xuICAgICAgICBwb3NpdGlvbjogcmVsYXRpdmU7XG4gICAgICB9XG5cbiAgICAgIC5hbnQtbWVudS1zdWJtZW51LXBsYWNlbWVudC1sZWZ0VG9wIHtcbiAgICAgICAgcmlnaHQ6IDRweDtcbiAgICAgICAgcG9zaXRpb246IHJlbGF0aXZlO1xuICAgICAgfVxuICAgIGBcbiAgXVxufSlcbmV4cG9ydCBjbGFzcyBOelN1Yk1lbnVDb21wb25lbnQgaW1wbGVtZW50cyBPbkluaXQsIE9uRGVzdHJveSwgQWZ0ZXJDb250ZW50SW5pdCwgT25DaGFuZ2VzIHtcbiAgQElucHV0KCkgbnpNZW51Q2xhc3NOYW1lOiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56UGFkZGluZ0xlZnQ6IG51bWJlcjtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56T3BlbiA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpEaXNhYmxlZCA9IGZhbHNlO1xuICBAT3V0cHV0KCkgcmVhZG9ubHkgbnpPcGVuQ2hhbmdlOiBFdmVudEVtaXR0ZXI8Ym9vbGVhbj4gPSBuZXcgRXZlbnRFbWl0dGVyKCk7XG5cbiAgQFZpZXdDaGlsZChDZGtDb25uZWN0ZWRPdmVybGF5KSBjZGtDb25uZWN0ZWRPdmVybGF5OiBDZGtDb25uZWN0ZWRPdmVybGF5O1xuICBAVmlld0NoaWxkKENka092ZXJsYXlPcmlnaW4sIHsgcmVhZDogRWxlbWVudFJlZiB9KSBjZGtPdmVybGF5T3JpZ2luOiBFbGVtZW50UmVmO1xuICBAQ29udGVudENoaWxkcmVuKE56U3ViTWVudUNvbXBvbmVudCwgeyBkZXNjZW5kYW50czogdHJ1ZSB9KVxuICBsaXN0T2ZOelN1Yk1lbnVDb21wb25lbnQ6IFF1ZXJ5TGlzdDxOelN1Yk1lbnVDb21wb25lbnQ+O1xuICBAQ29udGVudENoaWxkcmVuKE56TWVudUl0ZW1EaXJlY3RpdmUsIHsgZGVzY2VuZGFudHM6IHRydWUgfSlcbiAgbGlzdE9mTnpNZW51SXRlbURpcmVjdGl2ZTogUXVlcnlMaXN0PE56TWVudUl0ZW1EaXJlY3RpdmU+O1xuXG4gIHBsYWNlbWVudCA9ICdyaWdodFRvcCc7XG4gIHRyaWdnZXJXaWR0aDogbnVtYmVyO1xuICBleHBhbmRTdGF0ZSA9ICdjb2xsYXBzZWQnO1xuICBvdmVybGF5UG9zaXRpb25zID0gWy4uLkRFRkFVTFRfU1VCTUVOVV9QT1NJVElPTlNdO1xuXG4gIHByaXZhdGUgZGVzdHJveSQgPSBuZXcgU3ViamVjdDx2b2lkPigpO1xuICBwcml2YXRlIGlzQ2hpbGRNZW51U2VsZWN0ZWQgPSBmYWxzZTtcbiAgcHJpdmF0ZSBpc01vdXNlSG92ZXIgPSBmYWxzZTtcblxuICBzZXRPcGVuU3RhdGUob3BlbjogYm9vbGVhbik6IHZvaWQge1xuICAgIHRoaXMubnpTdWJtZW51U2VydmljZS5zZXRPcGVuU3RhdGUob3Blbik7XG4gIH1cblxuICBjbGlja1N1Yk1lbnVUaXRsZSgpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5uelN1Ym1lbnVTZXJ2aWNlLm1vZGUgPT09ICdpbmxpbmUnICYmICF0aGlzLm56TWVudVNlcnZpY2UuaXNJbkRyb3BEb3duICYmICF0aGlzLm56RGlzYWJsZWQpIHtcbiAgICAgIHRoaXMuc2V0T3BlblN0YXRlKCF0aGlzLm56T3Blbik7XG4gICAgfVxuICB9XG5cbiAgc2V0TW91c2VFbnRlclN0YXRlKHZhbHVlOiBib29sZWFuKTogdm9pZCB7XG4gICAgdGhpcy5pc01vdXNlSG92ZXIgPSB2YWx1ZTtcbiAgICB0aGlzLnNldENsYXNzTWFwKCk7XG4gICAgdGhpcy5uelN1Ym1lbnVTZXJ2aWNlLnNldE1vdXNlRW50ZXJTdGF0ZSh2YWx1ZSk7XG4gIH1cblxuICBzZXRUcmlnZ2VyV2lkdGgoKTogdm9pZCB7XG4gICAgaWYgKHRoaXMubnpTdWJtZW51U2VydmljZS5tb2RlID09PSAnaG9yaXpvbnRhbCcgJiYgdGhpcy5wbGF0Zm9ybS5pc0Jyb3dzZXIpIHtcbiAgICAgIHRoaXMudHJpZ2dlcldpZHRoID0gdGhpcy5jZGtPdmVybGF5T3JpZ2luLm5hdGl2ZUVsZW1lbnQuZ2V0Qm91bmRpbmdDbGllbnRSZWN0KCkud2lkdGg7XG4gICAgfVxuICB9XG5cbiAgb25Qb3NpdGlvbkNoYW5nZShwb3NpdGlvbjogQ29ubmVjdGVkT3ZlcmxheVBvc2l0aW9uQ2hhbmdlKTogdm9pZCB7XG4gICAgdGhpcy5wbGFjZW1lbnQgPSBnZXRQbGFjZW1lbnROYW1lKHBvc2l0aW9uKSE7XG4gICAgdGhpcy5jZHIubWFya0ZvckNoZWNrKCk7XG4gIH1cblxuICBzZXRDbGFzc01hcCgpOiB2b2lkIHtcbiAgICBjb25zdCBwcmVmaXhOYW1lID0gdGhpcy5uek1lbnVTZXJ2aWNlLmlzSW5Ecm9wRG93biA/ICdhbnQtZHJvcGRvd24tbWVudS1zdWJtZW51JyA6ICdhbnQtbWVudS1zdWJtZW51JztcbiAgICB0aGlzLm56VXBkYXRlSG9zdENsYXNzU2VydmljZS51cGRhdGVIb3N0Q2xhc3ModGhpcy5lbGVtZW50UmVmLm5hdGl2ZUVsZW1lbnQsIHtcbiAgICAgIFtgJHtwcmVmaXhOYW1lfWBdOiB0cnVlLFxuICAgICAgW2Ake3ByZWZpeE5hbWV9LWRpc2FibGVkYF06IHRoaXMubnpEaXNhYmxlZCxcbiAgICAgIFtgJHtwcmVmaXhOYW1lfS1vcGVuYF06IHRoaXMubnpPcGVuLFxuICAgICAgW2Ake3ByZWZpeE5hbWV9LXNlbGVjdGVkYF06IHRoaXMuaXNDaGlsZE1lbnVTZWxlY3RlZCxcbiAgICAgIFtgJHtwcmVmaXhOYW1lfS0ke3RoaXMubnpTdWJtZW51U2VydmljZS5tb2RlfWBdOiB0cnVlLFxuICAgICAgW2Ake3ByZWZpeE5hbWV9LWFjdGl2ZWBdOiB0aGlzLmlzTW91c2VIb3ZlciAmJiAhdGhpcy5uekRpc2FibGVkXG4gICAgfSk7XG4gIH1cblxuICBjb25zdHJ1Y3RvcihcbiAgICBwcml2YXRlIGVsZW1lbnRSZWY6IEVsZW1lbnRSZWYsXG4gICAgcHVibGljIG56TWVudVNlcnZpY2U6IE56TWVudUJhc2VTZXJ2aWNlLFxuICAgIHByaXZhdGUgY2RyOiBDaGFuZ2VEZXRlY3RvclJlZixcbiAgICBwdWJsaWMgbnpTdWJtZW51U2VydmljZTogTnpTdWJtZW51U2VydmljZSxcbiAgICBwcml2YXRlIG56VXBkYXRlSG9zdENsYXNzU2VydmljZTogTnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlLFxuICAgIHByaXZhdGUgcGxhdGZvcm06IFBsYXRmb3JtLFxuICAgIEBIb3N0KCkgQE9wdGlvbmFsKCkgcHVibGljIG5vQW5pbWF0aW9uPzogTnpOb0FuaW1hdGlvbkRpcmVjdGl2ZVxuICApIHt9XG5cbiAgbmdPbkluaXQoKTogdm9pZCB7XG4gICAgY29tYmluZUxhdGVzdCh0aGlzLm56U3VibWVudVNlcnZpY2UubW9kZSQsIHRoaXMubnpTdWJtZW51U2VydmljZS5vcGVuJClcbiAgICAgIC5waXBlKHRha2VVbnRpbCh0aGlzLmRlc3Ryb3kkKSlcbiAgICAgIC5zdWJzY3JpYmUoZGF0YSA9PiB7XG4gICAgICAgIGNvbnN0IG1vZGUgPSBkYXRhWzBdO1xuICAgICAgICBjb25zdCBvcGVuID0gZGF0YVsxXTtcbiAgICAgICAgaWYgKG9wZW4gJiYgbW9kZSA9PT0gJ2lubGluZScpIHtcbiAgICAgICAgICB0aGlzLmV4cGFuZFN0YXRlID0gJ2V4cGFuZGVkJztcbiAgICAgICAgfSBlbHNlIGlmIChvcGVuICYmIG1vZGUgPT09ICdob3Jpem9udGFsJykge1xuICAgICAgICAgIHRoaXMuZXhwYW5kU3RhdGUgPSAnYm90dG9tJztcbiAgICAgICAgfSBlbHNlIGlmIChvcGVuICYmIG1vZGUgPT09ICd2ZXJ0aWNhbCcpIHtcbiAgICAgICAgICB0aGlzLmV4cGFuZFN0YXRlID0gJ2FjdGl2ZSc7XG4gICAgICAgIH0gZWxzZSB7XG4gICAgICAgICAgdGhpcy5pc01vdXNlSG92ZXIgPSBmYWxzZTtcbiAgICAgICAgICB0aGlzLmV4cGFuZFN0YXRlID0gJ2NvbGxhcHNlZCc7XG4gICAgICAgIH1cbiAgICAgICAgdGhpcy5vdmVybGF5UG9zaXRpb25zID1cbiAgICAgICAgICBtb2RlID09PSAnaG9yaXpvbnRhbCcgPyBbUE9TSVRJT05fTUFQLmJvdHRvbUxlZnRdIDogW1BPU0lUSU9OX01BUC5yaWdodFRvcCwgUE9TSVRJT05fTUFQLmxlZnRUb3BdO1xuICAgICAgICBpZiAob3BlbiAhPT0gdGhpcy5uek9wZW4pIHtcbiAgICAgICAgICB0aGlzLm56T3BlbiA9IG9wZW47XG4gICAgICAgICAgdGhpcy5uek9wZW5DaGFuZ2UuZW1pdCh0aGlzLm56T3Blbik7XG4gICAgICAgIH1cbiAgICAgICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICAgICAgICB0aGlzLnNldFRyaWdnZXJXaWR0aCgpO1xuICAgICAgfSk7XG4gICAgdGhpcy5uelN1Ym1lbnVTZXJ2aWNlLm1lbnVPcGVuJC5waXBlKHRha2VVbnRpbCh0aGlzLmRlc3Ryb3kkKSkuc3Vic2NyaWJlKChkYXRhOiBib29sZWFuKSA9PiB7XG4gICAgICB0aGlzLm56TWVudVNlcnZpY2UubWVudU9wZW4kLm5leHQoZGF0YSk7XG4gICAgfSk7XG4gICAgbWVyZ2UoXG4gICAgICB0aGlzLm56TWVudVNlcnZpY2UubW9kZSQsXG4gICAgICB0aGlzLm56TWVudVNlcnZpY2UuaW5saW5lSW5kZW50JCxcbiAgICAgIHRoaXMubnpTdWJtZW51U2VydmljZS5sZXZlbCQsXG4gICAgICB0aGlzLm56U3VibWVudVNlcnZpY2Uub3BlbiQsXG4gICAgICB0aGlzLm56U3VibWVudVNlcnZpY2UubW9kZSRcbiAgICApXG4gICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAuc3Vic2NyaWJlKCgpID0+IHtcbiAgICAgICAgdGhpcy5jZHIubWFya0ZvckNoZWNrKCk7XG4gICAgICB9KTtcbiAgfVxuXG4gIG5nQWZ0ZXJDb250ZW50SW5pdCgpOiB2b2lkIHtcbiAgICB0aGlzLnNldFRyaWdnZXJXaWR0aCgpO1xuICAgIHRoaXMubGlzdE9mTnpNZW51SXRlbURpcmVjdGl2ZS5jaGFuZ2VzXG4gICAgICAucGlwZShcbiAgICAgICAgc3RhcnRXaXRoKHRydWUpLFxuICAgICAgICBmbGF0TWFwKCgpID0+XG4gICAgICAgICAgbWVyZ2UodGhpcy5saXN0T2ZOek1lbnVJdGVtRGlyZWN0aXZlLmNoYW5nZXMsIC4uLnRoaXMubGlzdE9mTnpNZW51SXRlbURpcmVjdGl2ZS5tYXAobWVudSA9PiBtZW51LnNlbGVjdGVkJCkpXG4gICAgICAgICksXG4gICAgICAgIG1hcCgoKSA9PiB0aGlzLmxpc3RPZk56TWVudUl0ZW1EaXJlY3RpdmUuc29tZShlID0+IGUubnpTZWxlY3RlZCkpLFxuICAgICAgICB0YWtlVW50aWwodGhpcy5kZXN0cm95JClcbiAgICAgIClcbiAgICAgIC5zdWJzY3JpYmUoc2VsZWN0ZWQgPT4ge1xuICAgICAgICB0aGlzLmlzQ2hpbGRNZW51U2VsZWN0ZWQgPSBzZWxlY3RlZDtcbiAgICAgICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICAgICAgfSk7XG4gIH1cblxuICBuZ09uQ2hhbmdlcyhjaGFuZ2VzOiBTaW1wbGVDaGFuZ2VzKTogdm9pZCB7XG4gICAgaWYgKGNoYW5nZXMubnpPcGVuKSB7XG4gICAgICB0aGlzLm56U3VibWVudVNlcnZpY2Uuc2V0T3BlblN0YXRlKHRoaXMubnpPcGVuKTtcbiAgICB9XG4gICAgaWYgKGNoYW5nZXMubnpEaXNhYmxlZCkge1xuICAgICAgdGhpcy5uelN1Ym1lbnVTZXJ2aWNlLmRpc2FibGVkID0gdGhpcy5uekRpc2FibGVkO1xuICAgICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICAgIH1cbiAgfVxuXG4gIG5nT25EZXN0cm95KCk6IHZvaWQge1xuICAgIHRoaXMuZGVzdHJveSQubmV4dCgpO1xuICAgIHRoaXMuZGVzdHJveSQuY29tcGxldGUoKTtcbiAgfVxufVxuIl19