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
export class NzSubMenuComponent {
    /**
     * @param {?} elementRef
     * @param {?} nzMenuService
     * @param {?} cdr
     * @param {?} nzSubmenuService
     * @param {?} nzUpdateHostClassService
     * @param {?} platform
     * @param {?=} noAnimation
     */
    constructor(elementRef, nzMenuService, cdr, nzSubmenuService, nzUpdateHostClassService, platform, noAnimation) {
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
        this.overlayPositions = [...DEFAULT_SUBMENU_POSITIONS];
        this.destroy$ = new Subject();
        this.isChildMenuSelected = false;
        this.isMouseHover = false;
    }
    /**
     * @param {?} open
     * @return {?}
     */
    setOpenState(open) {
        this.nzSubmenuService.setOpenState(open);
    }
    /**
     * @return {?}
     */
    clickSubMenuTitle() {
        if (this.nzSubmenuService.mode === 'inline' && !this.nzMenuService.isInDropDown && !this.nzDisabled) {
            this.setOpenState(!this.nzOpen);
        }
    }
    /**
     * @param {?} value
     * @return {?}
     */
    setMouseEnterState(value) {
        this.isMouseHover = value;
        this.setClassMap();
        this.nzSubmenuService.setMouseEnterState(value);
    }
    /**
     * @return {?}
     */
    setTriggerWidth() {
        if (this.nzSubmenuService.mode === 'horizontal' && this.platform.isBrowser) {
            this.triggerWidth = this.cdkOverlayOrigin.nativeElement.getBoundingClientRect().width;
        }
    }
    /**
     * @param {?} position
     * @return {?}
     */
    onPositionChange(position) {
        this.placement = (/** @type {?} */ (getPlacementName(position)));
        this.cdr.markForCheck();
    }
    /**
     * @return {?}
     */
    setClassMap() {
        /** @type {?} */
        const prefixName = this.nzMenuService.isInDropDown ? 'ant-dropdown-menu-submenu' : 'ant-menu-submenu';
        this.nzUpdateHostClassService.updateHostClass(this.elementRef.nativeElement, {
            [`${prefixName}`]: true,
            [`${prefixName}-disabled`]: this.nzDisabled,
            [`${prefixName}-open`]: this.nzOpen,
            [`${prefixName}-selected`]: this.isChildMenuSelected,
            [`${prefixName}-${this.nzSubmenuService.mode}`]: true,
            [`${prefixName}-active`]: this.isMouseHover && !this.nzDisabled
        });
    }
    /**
     * @return {?}
     */
    ngOnInit() {
        combineLatest(this.nzSubmenuService.mode$, this.nzSubmenuService.open$)
            .pipe(takeUntil(this.destroy$))
            .subscribe((/**
         * @param {?} data
         * @return {?}
         */
        data => {
            /** @type {?} */
            const mode = data[0];
            /** @type {?} */
            const open = data[1];
            if (open && mode === 'inline') {
                this.expandState = 'expanded';
            }
            else if (open && mode === 'horizontal') {
                this.expandState = 'bottom';
            }
            else if (open && mode === 'vertical') {
                this.expandState = 'active';
            }
            else {
                this.isMouseHover = false;
                this.expandState = 'collapsed';
            }
            this.overlayPositions =
                mode === 'horizontal' ? [POSITION_MAP.bottomLeft] : [POSITION_MAP.rightTop, POSITION_MAP.leftTop];
            if (open !== this.nzOpen) {
                this.nzOpen = open;
                this.nzOpenChange.emit(this.nzOpen);
            }
            this.setClassMap();
            this.setTriggerWidth();
        }));
        this.nzSubmenuService.menuOpen$.pipe(takeUntil(this.destroy$)).subscribe((/**
         * @param {?} data
         * @return {?}
         */
        (data) => {
            this.nzMenuService.menuOpen$.next(data);
        }));
        merge(this.nzMenuService.mode$, this.nzMenuService.inlineIndent$, this.nzSubmenuService.level$, this.nzSubmenuService.open$, this.nzSubmenuService.mode$)
            .pipe(takeUntil(this.destroy$))
            .subscribe((/**
         * @return {?}
         */
        () => {
            this.cdr.markForCheck();
        }));
    }
    /**
     * @return {?}
     */
    ngAfterContentInit() {
        this.setTriggerWidth();
        this.listOfNzMenuItemDirective.changes
            .pipe(startWith(true), flatMap((/**
         * @return {?}
         */
        () => merge(this.listOfNzMenuItemDirective.changes, ...this.listOfNzMenuItemDirective.map((/**
         * @param {?} menu
         * @return {?}
         */
        menu => menu.selected$))))), map((/**
         * @return {?}
         */
        () => this.listOfNzMenuItemDirective.some((/**
         * @param {?} e
         * @return {?}
         */
        e => e.nzSelected)))), takeUntil(this.destroy$))
            .subscribe((/**
         * @param {?} selected
         * @return {?}
         */
        selected => {
            this.isChildMenuSelected = selected;
            this.setClassMap();
        }));
    }
    /**
     * @param {?} changes
     * @return {?}
     */
    ngOnChanges(changes) {
        if (changes.nzOpen) {
            this.nzSubmenuService.setOpenState(this.nzOpen);
        }
        if (changes.nzDisabled) {
            this.nzSubmenuService.disabled = this.nzDisabled;
            this.setClassMap();
        }
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this.destroy$.next();
        this.destroy$.complete();
    }
}
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
                styles: [`
      .ant-menu-submenu-placement-bottomLeft {
        top: 6px;
        position: relative;
      }

      .ant-menu-submenu-placement-rightTop {
        left: 4px;
        position: relative;
      }

      .ant-menu-submenu-placement-leftTop {
        right: 4px;
        position: relative;
      }
    `]
            }] }
];
/** @nocollapse */
NzSubMenuComponent.ctorParameters = () => [
    { type: ElementRef },
    { type: NzMenuBaseService },
    { type: ChangeDetectorRef },
    { type: NzSubmenuService },
    { type: NzUpdateHostClassService },
    { type: Platform },
    { type: NzNoAnimationDirective, decorators: [{ type: Host }, { type: Optional }] }
];
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
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotc3VibWVudS5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9uZy16b3Jyby1hbnRkL21lbnUvIiwic291cmNlcyI6WyJuei1zdWJtZW51LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQUUsbUJBQW1CLEVBQUUsZ0JBQWdCLEVBQWtDLE1BQU0sc0JBQXNCLENBQUM7QUFDN0csT0FBTyxFQUFFLFFBQVEsRUFBRSxNQUFNLHVCQUF1QixDQUFDO0FBQ2pELE9BQU8sRUFFTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxlQUFlLEVBQ2YsVUFBVSxFQUNWLFlBQVksRUFDWixJQUFJLEVBQ0osS0FBSyxFQUlMLFFBQVEsRUFDUixNQUFNLEVBQ04sU0FBUyxFQUVULFNBQVMsRUFDVCxpQkFBaUIsRUFDbEIsTUFBTSxlQUFlLENBQUM7QUFFdkIsT0FBTyxFQUFFLGFBQWEsRUFBRSxLQUFLLEVBQUUsT0FBTyxFQUFFLE1BQU0sTUFBTSxDQUFDO0FBQ3JELE9BQU8sRUFBRSxPQUFPLEVBQUUsR0FBRyxFQUFFLFNBQVMsRUFBRSxTQUFTLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUVwRSxPQUFPLEVBQ0wsY0FBYyxFQUNkLGdCQUFnQixFQUNoQixXQUFXLEVBQ1gsYUFBYSxFQUNiLHlCQUF5QixFQUN6QixZQUFZLEVBQ1osaUJBQWlCLEVBQ2pCLHNCQUFzQixFQUN0Qix3QkFBd0IsRUFDeEIsWUFBWSxFQUNiLE1BQU0sb0JBQW9CLENBQUM7QUFFNUIsT0FBTyxFQUFFLG1CQUFtQixFQUFFLE1BQU0sMEJBQTBCLENBQUM7QUFDL0QsT0FBTyxFQUFFLGdCQUFnQixFQUFFLE1BQU0sc0JBQXNCLENBQUM7QUE4QnhELE1BQU0sT0FBTyxrQkFBa0I7Ozs7Ozs7Ozs7SUE4RDdCLFlBQ1UsVUFBc0IsRUFDdkIsYUFBZ0MsRUFDL0IsR0FBc0IsRUFDdkIsZ0JBQWtDLEVBQ2pDLHdCQUFr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QixFQUFFLEtBQUs7Z0JBQzFCLDh1RkFBMEM7eUJBRXhDOzs7Ozs7Ozs7Ozs7Ozs7S0FlQzthQUVKOzs7O1lBN0RDLFVBQVU7WUF5QlYsaUJBQWlCO1lBNUJqQixpQkFBaUI7WUFtQ1YsZ0JBQWdCO1lBTHZCLHdCQUF3QjtZQWxDakIsUUFBUTtZQWlDZixzQkFBc0IsdUJBeUduQixJQUFJLFlBQUksUUFBUTs7OzhCQXBFbEIsS0FBSzs0QkFDTCxLQUFLO3FCQUNMLEtBQUs7eUJBQ0wsS0FBSzsyQkFDTCxNQUFNO2tDQUVOLFNBQVMsU0FBQyxtQkFBbUI7K0JBQzdCLFNBQVMsU0FBQyxnQkFBZ0IsRUFBRSxFQUFFLElBQUksRUFBRSxVQUFVLEVBQUU7dUNBQ2hELGVBQWUsU0FBQyxrQkFBa0IsRUFBRSxFQUFFLFdBQVcsRUFBRSxJQUFJLEVBQUU7d0NBRXpELGVBQWUsU0FBQyxtQkFBbUIsRUFBRSxFQUFFLFdBQVcsRUFBRSxJQUFJLEVBQUU7O0FBUmxDO0lBQWYsWUFBWSxFQUFFOztrREFBZ0I7QUFDZjtJQUFmLFlBQVksRUFBRTs7c0RBQW9COzs7SUFINUMsNkNBQWlDOztJQUNqQywyQ0FBK0I7O0lBQy9CLG9DQUF3Qzs7SUFDeEMsd0NBQTRDOztJQUM1QywwQ0FBNEU7O0lBRTVFLGlEQUF5RTs7SUFDekUsOENBQWdGOztJQUNoRixzREFDd0Q7O0lBQ3hELHVEQUMwRDs7SUFFMUQsdUNBQXVCOztJQUN2QiwwQ0FBcUI7O0lBQ3JCLHlDQUEwQjs7SUFDMUIsOENBQWtEOzs7OztJQUVsRCxzQ0FBdUM7Ozs7O0lBQ3ZDLGlEQUFvQzs7Ozs7SUFDcEMsMENBQTZCOzs7OztJQTBDM0Isd0NBQThCOztJQUM5QiwyQ0FBdUM7Ozs7O0lBQ3ZDLGlDQUE4Qjs7SUFDOUIsOENBQXlDOzs7OztJQUN6QyxzREFBMEQ7Ozs7O0lBQzFELHNDQUEwQjs7SUFDMUIseUNBQStEIiwic291cmNlc0NvbnRlbnQiOlsiLyoqXG4gKiBAbGljZW5zZVxuICogQ29weXJpZ2h0IEFsaWJhYmEuY29tIEFsbCBSaWdodHMgUmVzZXJ2ZWQuXG4gKlxuICogVXNlIG9mIHRoaXMgc291cmNlIGNvZGUgaXMgZ292ZXJuZWQgYnkgYW4gTUlULXN0eWxlIGxpY2Vuc2UgdGhhdCBjYW4gYmVcbiAqIGZvdW5kIGluIHRoZSBMSUNFTlNFIGZpbGUgYXQgaHR0cHM6Ly9naXRodWIuY29tL05HLVpPUlJPL25nLXpvcnJvLWFudGQvYmxvYi9tYXN0ZXIvTElDRU5TRVxuICovXG5cbmltcG9ydCB7IENka0Nvbm5lY3RlZE92ZXJsYXksIENka092ZXJsYXlPcmlnaW4sIENvbm5lY3RlZE92ZXJsYXlQb3NpdGlvbkNoYW5nZSB9IGZyb20gJ0Bhbmd1bGFyL2Nkay9vdmVybGF5JztcbmltcG9ydCB7IFBsYXRmb3JtIH0gZnJvbSAnQGFuZ3VsYXIvY2RrL3BsYXRmb3JtJztcbmltcG9ydCB7XG4gIEFmdGVyQ29udGVudEluaXQsXG4gIENoYW5nZURldGVjdGlvblN0cmF0ZWd5LFxuICBDaGFuZ2VEZXRlY3RvclJlZixcbiAgQ29tcG9uZW50LFxuICBDb250ZW50Q2hpbGRyZW4sXG4gIEVsZW1lbnRSZWYsXG4gIEV2ZW50RW1pdHRlcixcbiAgSG9zdCxcbiAgSW5wdXQsXG4gIE9uQ2hhbmdlcyxcbiAgT25EZXN0cm95LFxuICBPbkluaXQsXG4gIE9wdGlvbmFsLFxuICBPdXRwdXQsXG4gIFF1ZXJ5TGlzdCxcbiAgU2ltcGxlQ2hhbmdlcyxcbiAgVmlld0NoaWxkLFxuICBWaWV3RW5jYXBzdWxhdGlvblxufSBmcm9tICdAYW5ndWxhci9jb3JlJztcblxuaW1wb3J0IHsgY29tYmluZUxhdGVzdCwgbWVyZ2UsIFN1YmplY3QgfSBmcm9tICdyeGpzJztcbmltcG9ydCB7IGZsYXRNYXAsIG1hcCwgc3RhcnRXaXRoLCB0YWtlVW50aWwgfSBmcm9tICdyeGpzL29wZXJhdG9ycyc7XG5cbmltcG9ydCB7XG4gIGNvbGxhcHNlTW90aW9uLFxuICBnZXRQbGFjZW1lbnROYW1lLFxuICBzbGlkZU1vdGlvbixcbiAgem9vbUJpZ01vdGlvbixcbiAgREVGQVVMVF9TVUJNRU5VX1BPU0lUSU9OUyxcbiAgSW5wdXRCb29sZWFuLFxuICBOek1lbnVCYXNlU2VydmljZSxcbiAgTnpOb0FuaW1hdGlvbkRpcmVjdGl2ZSxcbiAgTnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlLFxuICBQT1NJVElPTl9NQVBcbn0gZnJvbSAnbmctem9ycm8tYW50ZC9jb3JlJztcblxuaW1wb3J0IHsgTnpNZW51SXRlbURpcmVjdGl2ZSB9IGZyb20gJy4vbnotbWVudS1pdGVtLmRpcmVjdGl2ZSc7XG5pbXBvcnQgeyBOelN1Ym1lbnVTZXJ2aWNlIH0gZnJvbSAnLi9uei1zdWJtZW51LnNlcnZpY2UnO1xuXG5AQ29tcG9uZW50KHtcbiAgc2VsZWN0b3I6ICdbbnotc3VibWVudV0nLFxuICBleHBvcnRBczogJ256U3VibWVudScsXG4gIHByb3ZpZGVyczogW056U3VibWVudVNlcnZpY2UsIE56VXBkYXRlSG9zdENsYXNzU2VydmljZV0sXG4gIGFuaW1hdGlvbnM6IFtjb2xsYXBzZU1vdGlvbiwgem9vbUJpZ01vdGlvbiwgc2xpZGVNb3Rpb25dLFxuICBlbmNhcHN1bGF0aW9uOiBWaWV3RW5jYXBzdWxhdGlvbi5Ob25lLFxuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbiAgcHJlc2VydmVXaGl0ZXNwYWNlczogZmFsc2UsXG4gIHRlbXBsYXRlVXJsOiAnLi9uei1zdWJtZW51LmNvbXBvbmVudC5odG1sJyxcbiAgc3R5bGVzOiBbXG4gICAgYFxuICAgICAgLmFudC1tZW51LXN1Ym1lbnUtcGxhY2VtZW50LWJvdHRvbUxlZnQge1xuICAgICAgICB0b3A6IDZweDtcbiAgICAgICAgcG9zaXRpb246IHJlbGF0aXZlO1xuICAgICAgfVxuXG4gICAgICAuYW50LW1lbnUtc3VibWVudS1wbGFjZW1lbnQtcmlnaHRUb3Age1xuICAgICAgICBsZWZ0OiA0cHg7XG4gICAgICAgIHBvc2l0aW9uOiByZWxhdGl2ZTtcbiAgICAgIH1cblxuICAgICAgLmFudC1tZW51LXN1Ym1lbnUtcGxhY2VtZW50LWxlZnRUb3Age1xuICAgICAgICByaWdodDogNHB4O1xuICAgICAgICBwb3NpdGlvbjogcmVsYXRpdmU7XG4gICAgICB9XG4gICAgYFxuICBdXG59KVxuZXhwb3J0IGNsYXNzIE56U3ViTWVudUNvbXBvbmVudCBpbXBsZW1lbnRzIE9uSW5pdCwgT25EZXN0cm95LCBBZnRlckNvbnRlbnRJbml0LCBPbkNoYW5nZXMge1xuICBASW5wdXQoKSBuek1lbnVDbGFzc05hbWU6IHN0cmluZztcbiAgQElucHV0KCkgbnpQYWRkaW5nTGVmdDogbnVtYmVyO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpPcGVuID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekRpc2FibGVkID0gZmFsc2U7XG4gIEBPdXRwdXQoKSByZWFkb25seSBuek9wZW5DaGFuZ2U6IEV2ZW50RW1pdHRlcjxib29sZWFuPiA9IG5ldyBFdmVudEVtaXR0ZXIoKTtcblxuICBAVmlld0NoaWxkKENka0Nvbm5lY3RlZE92ZXJsYXkpIGNka0Nvbm5lY3RlZE92ZXJsYXk6IENka0Nvbm5lY3RlZE92ZXJsYXk7XG4gIEBWaWV3Q2hpbGQoQ2RrT3ZlcmxheU9yaWdpbiwgeyByZWFkOiBFbGVtZW50UmVmIH0pIGNka092ZXJsYXlPcmlnaW46IEVsZW1lbnRSZWY7XG4gIEBDb250ZW50Q2hpbGRyZW4oTnpTdWJNZW51Q29tcG9uZW50LCB7IGRlc2NlbmRhbnRzOiB0cnVlIH0pXG4gIGxpc3RPZk56U3ViTWVudUNvbXBvbmVudDogUXVlcnlMaXN0PE56U3ViTWVudUNvbXBvbmVudD47XG4gIEBDb250ZW50Q2hpbGRyZW4oTnpNZW51SXRlbURpcmVjdGl2ZSwgeyBkZXNjZW5kYW50czogdHJ1ZSB9KVxuICBsaXN0T2ZOek1lbnVJdGVtRGlyZWN0aXZlOiBRdWVyeUxpc3Q8TnpNZW51SXRlbURpcmVjdGl2ZT47XG5cbiAgcGxhY2VtZW50ID0gJ3JpZ2h0VG9wJztcbiAgdHJpZ2dlcldpZHRoOiBudW1iZXI7XG4gIGV4cGFuZFN0YXRlID0gJ2NvbGxhcHNlZCc7XG4gIG92ZXJsYXlQb3NpdGlvbnMgPSBbLi4uREVGQVVMVF9TVUJNRU5VX1BPU0lUSU9OU107XG5cbiAgcHJpdmF0ZSBkZXN0cm95JCA9IG5ldyBTdWJqZWN0PHZvaWQ+KCk7XG4gIHByaXZhdGUgaXNDaGlsZE1lbnVTZWxlY3RlZCA9IGZhbHNlO1xuICBwcml2YXRlIGlzTW91c2VIb3ZlciA9IGZhbHNlO1xuXG4gIHNldE9wZW5TdGF0ZShvcGVuOiBib29sZWFuKTogdm9pZCB7XG4gICAgdGhpcy5uelN1Ym1lbnVTZXJ2aWNlLnNldE9wZW5TdGF0ZShvcGVuKTtcbiAgfVxuXG4gIGNsaWNrU3ViTWVudVRpdGxlKCk6IHZvaWQge1xuICAgIGlmICh0aGlzLm56U3VibWVudVNlcnZpY2UubW9kZSA9PT0gJ2lubGluZScgJiYgIXRoaXMubnpNZW51U2VydmljZS5pc0luRHJvcERvd24gJiYgIXRoaXMubnpEaXNhYmxlZCkge1xuICAgICAgdGhpcy5zZXRPcGVuU3RhdGUoIXRoaXMubnpPcGVuKTtcbiAgICB9XG4gIH1cblxuICBzZXRNb3VzZUVudGVyU3RhdGUodmFsdWU6IGJvb2xlYW4pOiB2b2lkIHtcbiAgICB0aGlzLmlzTW91c2VIb3ZlciA9IHZhbHVlO1xuICAgIHRoaXMuc2V0Q2xhc3NNYXAoKTtcbiAgICB0aGlzLm56U3VibWVudVNlcnZpY2Uuc2V0TW91c2VFbnRlclN0YXRlKHZhbHVlKTtcbiAgfVxuXG4gIHNldFRyaWdnZXJXaWR0aCgpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5uelN1Ym1lbnVTZXJ2aWNlLm1vZGUgPT09ICdob3Jpem9udGFsJyAmJiB0aGlzLnBsYXRmb3JtLmlzQnJvd3Nlcikge1xuICAgICAgdGhpcy50cmlnZ2VyV2lkdGggPSB0aGlzLmNka092ZXJsYXlPcmlnaW4ubmF0aXZlRWxlbWVudC5nZXRCb3VuZGluZ0NsaWVudFJlY3QoKS53aWR0aDtcbiAgICB9XG4gIH1cblxuICBvblBvc2l0aW9uQ2hhbmdlKHBvc2l0aW9uOiBDb25uZWN0ZWRPdmVybGF5UG9zaXRpb25DaGFuZ2UpOiB2b2lkIHtcbiAgICB0aGlzLnBsYWNlbWVudCA9IGdldFBsYWNlbWVudE5hbWUocG9zaXRpb24pITtcbiAgICB0aGlzLmNkci5tYXJrRm9yQ2hlY2soKTtcbiAgfVxuXG4gIHNldENsYXNzTWFwKCk6IHZvaWQge1xuICAgIGNvbnN0IHByZWZpeE5hbWUgPSB0aGlzLm56TWVudVNlcnZpY2UuaXNJbkRyb3BEb3duID8gJ2FudC1kcm9wZG93bi1tZW51LXN1Ym1lbnUnIDogJ2FudC1tZW51LXN1Ym1lbnUnO1xuICAgIHRoaXMubnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlLnVwZGF0ZUhvc3RDbGFzcyh0aGlzLmVsZW1lbnRSZWYubmF0aXZlRWxlbWVudCwge1xuICAgICAgW2Ake3ByZWZpeE5hbWV9YF06IHRydWUsXG4gICAgICBbYCR7cHJlZml4TmFtZX0tZGlzYWJsZWRgXTogdGhpcy5uekRpc2FibGVkLFxuICAgICAgW2Ake3ByZWZpeE5hbWV9LW9wZW5gXTogdGhpcy5uek9wZW4sXG4gICAgICBbYCR7cHJlZml4TmFtZX0tc2VsZWN0ZWRgXTogdGhpcy5pc0NoaWxkTWVudVNlbGVjdGVkLFxuICAgICAgW2Ake3ByZWZpeE5hbWV9LSR7dGhpcy5uelN1Ym1lbnVTZXJ2aWNlLm1vZGV9YF06IHRydWUsXG4gICAgICBbYCR7cHJlZml4TmFtZX0tYWN0aXZlYF06IHRoaXMuaXNNb3VzZUhvdmVyICYmICF0aGlzLm56RGlzYWJsZWRcbiAgICB9KTtcbiAgfVxuXG4gIGNvbnN0cnVjdG9yKFxuICAgIHByaXZhdGUgZWxlbWVudFJlZjogRWxlbWVudFJlZixcbiAgICBwdWJsaWMgbnpNZW51U2VydmljZTogTnpNZW51QmFzZVNlcnZpY2UsXG4gICAgcHJpdmF0ZSBjZHI6IENoYW5nZURldGVjdG9yUmVmLFxuICAgIHB1YmxpYyBuelN1Ym1lbnVTZXJ2aWNlOiBOelN1Ym1lbnVTZXJ2aWNlLFxuICAgIHByaXZhdGUgbnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlOiBOelVwZGF0ZUhvc3RDbGFzc1NlcnZpY2UsXG4gICAgcHJpdmF0ZSBwbGF0Zm9ybTogUGxhdGZvcm0sXG4gICAgQEhvc3QoKSBAT3B0aW9uYWwoKSBwdWJsaWMgbm9BbmltYXRpb24/OiBOek5vQW5pbWF0aW9uRGlyZWN0aXZlXG4gICkge31cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICBjb21iaW5lTGF0ZXN0KHRoaXMubnpTdWJtZW51U2VydmljZS5tb2RlJCwgdGhpcy5uelN1Ym1lbnVTZXJ2aWNlLm9wZW4kKVxuICAgICAgLnBpcGUodGFrZVVudGlsKHRoaXMuZGVzdHJveSQpKVxuICAgICAgLnN1YnNjcmliZShkYXRhID0+IHtcbiAgICAgICAgY29uc3QgbW9kZSA9IGRhdGFbMF07XG4gICAgICAgIGNvbnN0IG9wZW4gPSBkYXRhWzFdO1xuICAgICAgICBpZiAob3BlbiAmJiBtb2RlID09PSAnaW5saW5lJykge1xuICAgICAgICAgIHRoaXMuZXhwYW5kU3RhdGUgPSAnZXhwYW5kZWQnO1xuICAgICAgICB9IGVsc2UgaWYgKG9wZW4gJiYgbW9kZSA9PT0gJ2hvcml6b250YWwnKSB7XG4gICAgICAgICAgdGhpcy5leHBhbmRTdGF0ZSA9ICdib3R0b20nO1xuICAgICAgICB9IGVsc2UgaWYgKG9wZW4gJiYgbW9kZSA9PT0gJ3ZlcnRpY2FsJykge1xuICAgICAgICAgIHRoaXMuZXhwYW5kU3RhdGUgPSAnYWN0aXZlJztcbiAgICAgICAgfSBlbHNlIHtcbiAgICAgICAgICB0aGlzLmlzTW91c2VIb3ZlciA9IGZhbHNlO1xuICAgICAgICAgIHRoaXMuZXhwYW5kU3RhdGUgPSAnY29sbGFwc2VkJztcbiAgICAgICAgfVxuICAgICAgICB0aGlzLm92ZXJsYXlQb3NpdGlvbnMgPVxuICAgICAgICAgIG1vZGUgPT09ICdob3Jpem9udGFsJyA/IFtQT1NJVElPTl9NQVAuYm90dG9tTGVmdF0gOiBbUE9TSVRJT05fTUFQLnJpZ2h0VG9wLCBQT1NJVElPTl9NQVAubGVmdFRvcF07XG4gICAgICAgIGlmIChvcGVuICE9PSB0aGlzLm56T3Blbikge1xuICAgICAgICAgIHRoaXMubnpPcGVuID0gb3BlbjtcbiAgICAgICAgICB0aGlzLm56T3BlbkNoYW5nZS5lbWl0KHRoaXMubnpPcGVuKTtcbiAgICAgICAgfVxuICAgICAgICB0aGlzLnNldENsYXNzTWFwKCk7XG4gICAgICAgIHRoaXMuc2V0VHJpZ2dlcldpZHRoKCk7XG4gICAgICB9KTtcbiAgICB0aGlzLm56U3VibWVudVNlcnZpY2UubWVudU9wZW4kLnBpcGUodGFrZVVudGlsKHRoaXMuZGVzdHJveSQpKS5zdWJzY3JpYmUoKGRhdGE6IGJvb2xlYW4pID0+IHtcbiAgICAgIHRoaXMubnpNZW51U2VydmljZS5tZW51T3BlbiQubmV4dChkYXRhKTtcbiAgICB9KTtcbiAgICBtZXJnZShcbiAgICAgIHRoaXMubnpNZW51U2VydmljZS5tb2RlJCxcbiAgICAgIHRoaXMubnpNZW51U2VydmljZS5pbmxpbmVJbmRlbnQkLFxuICAgICAgdGhpcy5uelN1Ym1lbnVTZXJ2aWNlLmxldmVsJCxcbiAgICAgIHRoaXMubnpTdWJtZW51U2VydmljZS5vcGVuJCxcbiAgICAgIHRoaXMubnpTdWJtZW51U2VydmljZS5tb2RlJFxuICAgIClcbiAgICAgIC5waXBlKHRha2VVbnRpbCh0aGlzLmRlc3Ryb3kkKSlcbiAgICAgIC5zdWJzY3JpYmUoKCkgPT4ge1xuICAgICAgICB0aGlzLmNkci5tYXJrRm9yQ2hlY2soKTtcbiAgICAgIH0pO1xuICB9XG5cbiAgbmdBZnRlckNvbnRlbnRJbml0KCk6IHZvaWQge1xuICAgIHRoaXMuc2V0VHJpZ2dlcldpZHRoKCk7XG4gICAgdGhpcy5saXN0T2ZOek1lbnVJdGVtRGlyZWN0aXZlLmNoYW5nZXNcbiAgICAgIC5waXBlKFxuICAgICAgICBzdGFydFdpdGgodHJ1ZSksXG4gICAgICAgIGZsYXRNYXAoKCkgPT5cbiAgICAgICAgICBtZXJnZSh0aGlzLmxpc3RPZk56TWVudUl0ZW1EaXJlY3RpdmUuY2hhbmdlcywgLi4udGhpcy5saXN0T2ZOek1lbnVJdGVtRGlyZWN0aXZlLm1hcChtZW51ID0+IG1lbnUuc2VsZWN0ZWQkKSlcbiAgICAgICAgKSxcbiAgICAgICAgbWFwKCgpID0+IHRoaXMubGlzdE9mTnpNZW51SXRlbURpcmVjdGl2ZS5zb21lKGUgPT4gZS5uelNlbGVjdGVkKSksXG4gICAgICAgIHRha2VVbnRpbCh0aGlzLmRlc3Ryb3kkKVxuICAgICAgKVxuICAgICAgLnN1YnNjcmliZShzZWxlY3RlZCA9PiB7XG4gICAgICAgIHRoaXMuaXNDaGlsZE1lbnVTZWxlY3RlZCA9IHNlbGVjdGVkO1xuICAgICAgICB0aGlzLnNldENsYXNzTWFwKCk7XG4gICAgICB9KTtcbiAgfVxuXG4gIG5nT25DaGFuZ2VzKGNoYW5nZXM6IFNpbXBsZUNoYW5nZXMpOiB2b2lkIHtcbiAgICBpZiAoY2hhbmdlcy5uek9wZW4pIHtcbiAgICAgIHRoaXMubnpTdWJtZW51U2VydmljZS5zZXRPcGVuU3RhdGUodGhpcy5uek9wZW4pO1xuICAgIH1cbiAgICBpZiAoY2hhbmdlcy5uekRpc2FibGVkKSB7XG4gICAgICB0aGlzLm56U3VibWVudVNlcnZpY2UuZGlzYWJsZWQgPSB0aGlzLm56RGlzYWJsZWQ7XG4gICAgICB0aGlzLnNldENsYXNzTWFwKCk7XG4gICAgfVxuICB9XG5cbiAgbmdPbkRlc3Ryb3koKTogdm9pZCB7XG4gICAgdGhpcy5kZXN0cm95JC5uZXh0KCk7XG4gICAgdGhpcy5kZXN0cm95JC5jb21wbGV0ZSgpO1xuICB9XG59XG4iXX0=