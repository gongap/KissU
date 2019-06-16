import { FocusTrapFactory } from '@angular/cdk/a11y';
import { DOCUMENT, CommonModule } from '@angular/common';
import { toCssPixel, InputBoolean, NzAddOnModule, NzNoAnimationModule } from 'ng-zorro-antd/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { __rest, __decorate, __metadata } from 'tslib';
import { Overlay, OverlayConfig, OverlayModule } from '@angular/cdk/overlay';
import { CdkPortalOutlet, ComponentPortal, PortalInjector, TemplatePortal, PortalModule } from '@angular/cdk/portal';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Inject, Injector, Input, Optional, Output, Renderer2, TemplateRef, Type, ViewChild, ViewContainerRef, Injectable, NgModule, defineInjectable, inject } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

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
// tslint:disable-next-line:no-any
/**
 * @abstract
 * @template R
 */
class NzDrawerRef {
}

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
const DRAWER_ANIMATE_DURATION = 300;
/**
 * @template T, R, D
 */
// tslint:disable-next-line:no-any
class NzDrawerComponent extends NzDrawerRef {
    /**
     * @param {?} document
     * @param {?} renderer
     * @param {?} overlay
     * @param {?} injector
     * @param {?} changeDetectorRef
     * @param {?} focusTrapFactory
     * @param {?} viewContainerRef
     */
    constructor(document, renderer, overlay, injector, changeDetectorRef, focusTrapFactory, viewContainerRef) {
        super();
        this.document = document;
        this.renderer = renderer;
        this.overlay = overlay;
        this.injector = injector;
        this.changeDetectorRef = changeDetectorRef;
        this.focusTrapFactory = focusTrapFactory;
        this.viewContainerRef = viewContainerRef;
        this.nzClosable = true;
        this.nzMaskClosable = true;
        this.nzMask = true;
        this.nzNoAnimation = false;
        this.nzPlacement = 'right';
        this.nzMaskStyle = {};
        this.nzBodyStyle = {};
        this.nzWidth = 256;
        this.nzHeight = 256;
        this.nzZIndex = 1000;
        this.nzOffsetX = 0;
        this.nzOffsetY = 0;
        this.nzOnViewInit = new EventEmitter();
        this.nzOnClose = new EventEmitter();
        this.isOpen = false;
        this.templateContext = {
            $implicit: undefined,
            drawerRef: (/** @type {?} */ (this))
        };
        this.nzAfterOpen = new Subject();
        this.nzAfterClose = new Subject();
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set nzVisible(value) {
        this.isOpen = value;
    }
    /**
     * @return {?}
     */
    get nzVisible() {
        return this.isOpen;
    }
    /**
     * @return {?}
     */
    get offsetTransform() {
        if (!this.isOpen || this.nzOffsetX + this.nzOffsetY === 0) {
            return null;
        }
        switch (this.nzPlacement) {
            case 'left':
                return `translateX(${this.nzOffsetX}px)`;
            case 'right':
                return `translateX(-${this.nzOffsetX}px)`;
            case 'top':
                return `translateY(${this.nzOffsetY}px)`;
            case 'bottom':
                return `translateY(-${this.nzOffsetY}px)`;
        }
    }
    /**
     * @return {?}
     */
    get transform() {
        if (this.isOpen) {
            return null;
        }
        switch (this.nzPlacement) {
            case 'left':
                return `translateX(-100%)`;
            case 'right':
                return `translateX(100%)`;
            case 'top':
                return `translateY(-100%)`;
            case 'bottom':
                return `translateY(100%)`;
        }
    }
    /**
     * @return {?}
     */
    get width() {
        return this.isLeftOrRight ? toCssPixel(this.nzWidth) : null;
    }
    /**
     * @return {?}
     */
    get height() {
        return !this.isLeftOrRight ? toCssPixel(this.nzHeight) : null;
    }
    /**
     * @return {?}
     */
    get isLeftOrRight() {
        return this.nzPlacement === 'left' || this.nzPlacement === 'right';
    }
    /**
     * @return {?}
     */
    get afterOpen() {
        return this.nzAfterOpen.asObservable();
    }
    /**
     * @return {?}
     */
    get afterClose() {
        return this.nzAfterClose.asObservable();
    }
    /**
     * @param {?} value
     * @return {?}
     */
    isTemplateRef(value) {
        return value instanceof TemplateRef;
    }
    /**
     * @return {?}
     */
    ngOnInit() {
        this.attachOverlay();
        this.updateOverlayStyle();
        this.updateBodyOverflow();
        this.templateContext = { $implicit: this.nzContentParams, drawerRef: (/** @type {?} */ (this)) };
        this.changeDetectorRef.detectChanges();
    }
    /**
     * @return {?}
     */
    ngAfterViewInit() {
        this.attachBodyContent();
        setTimeout((/**
         * @return {?}
         */
        () => {
            this.nzOnViewInit.emit();
        }));
    }
    /**
     * @param {?} changes
     * @return {?}
     */
    ngOnChanges(changes) {
        if (changes.hasOwnProperty('nzVisible')) {
            /** @type {?} */
            const value = changes.nzVisible.currentValue;
            this.updateOverlayStyle();
            if (value) {
                this.updateBodyOverflow();
                this.savePreviouslyFocusedElement();
                this.trapFocus();
            }
            else {
                setTimeout((/**
                 * @return {?}
                 */
                () => {
                    this.updateBodyOverflow();
                    this.restoreFocus();
                }), this.getAnimationDuration());
            }
        }
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this.disposeOverlay();
    }
    /**
     * @private
     * @return {?}
     */
    getAnimationDuration() {
        return this.nzNoAnimation ? 0 : DRAWER_ANIMATE_DURATION;
    }
    /**
     * @param {?=} result
     * @return {?}
     */
    close(result) {
        this.isOpen = false;
        this.updateOverlayStyle();
        this.changeDetectorRef.detectChanges();
        setTimeout((/**
         * @return {?}
         */
        () => {
            this.updateBodyOverflow();
            this.restoreFocus();
            this.nzAfterClose.next(result);
            this.nzAfterClose.complete();
        }), this.getAnimationDuration());
    }
    /**
     * @return {?}
     */
    open() {
        this.isOpen = true;
        this.updateOverlayStyle();
        this.updateBodyOverflow();
        this.savePreviouslyFocusedElement();
        this.trapFocus();
        this.changeDetectorRef.detectChanges();
        setTimeout((/**
         * @return {?}
         */
        () => {
            this.nzAfterOpen.next();
        }), this.getAnimationDuration());
    }
    /**
     * @return {?}
     */
    closeClick() {
        this.nzOnClose.emit();
    }
    /**
     * @return {?}
     */
    maskClick() {
        if (this.nzMaskClosable && this.nzMask) {
            this.nzOnClose.emit();
        }
    }
    /**
     * @private
     * @return {?}
     */
    attachBodyContent() {
        this.bodyPortalOutlet.dispose();
        if (this.nzContent instanceof Type) {
            /** @type {?} */
            const childInjector = new PortalInjector(this.injector, new WeakMap([[NzDrawerRef, this]]));
            /** @type {?} */
            const componentPortal = new ComponentPortal(this.nzContent, null, childInjector);
            /** @type {?} */
            const componentRef = this.bodyPortalOutlet.attachComponentPortal(componentPortal);
            Object.assign(componentRef.instance, this.nzContentParams);
            componentRef.changeDetectorRef.detectChanges();
        }
    }
    /**
     * @private
     * @return {?}
     */
    attachOverlay() {
        if (!this.overlayRef) {
            this.portal = new TemplatePortal(this.drawerTemplate, this.viewContainerRef);
            this.overlayRef = this.overlay.create(this.getOverlayConfig());
        }
        if (this.overlayRef && !this.overlayRef.hasAttached()) {
            this.overlayRef.attach(this.portal);
        }
    }
    /**
     * @private
     * @return {?}
     */
    disposeOverlay() {
        if (this.overlayRef) {
            this.overlayRef.dispose();
        }
        this.overlayRef = null;
    }
    /**
     * @private
     * @return {?}
     */
    getOverlayConfig() {
        return new OverlayConfig({
            positionStrategy: this.overlay.position().global(),
            scrollStrategy: this.overlay.scrollStrategies.block()
        });
    }
    /**
     * @private
     * @return {?}
     */
    updateOverlayStyle() {
        if (this.overlayRef && this.overlayRef.overlayElement) {
            this.renderer.setStyle(this.overlayRef.overlayElement, 'pointer-events', this.isOpen ? 'auto' : 'none');
        }
    }
    /**
     * @private
     * @return {?}
     */
    updateBodyOverflow() {
        if (this.overlayRef) {
            if (this.isOpen) {
                (/** @type {?} */ (this.overlayRef.getConfig().scrollStrategy)).enable();
            }
            else {
                (/** @type {?} */ (this.overlayRef.getConfig().scrollStrategy)).disable();
            }
        }
    }
    /**
     * @return {?}
     */
    savePreviouslyFocusedElement() {
        if (this.document && !this.previouslyFocusedElement) {
            this.previouslyFocusedElement = (/** @type {?} */ (this.document.activeElement));
            // We need the extra check, because IE's svg element has no blur method.
            if (this.previouslyFocusedElement && typeof this.previouslyFocusedElement.blur === 'function') {
                this.previouslyFocusedElement.blur();
            }
        }
    }
    /**
     * @private
     * @return {?}
     */
    trapFocus() {
        if (!this.focusTrap && this.overlayRef && this.overlayRef.overlayElement) {
            this.focusTrap = this.focusTrapFactory.create((/** @type {?} */ (this.overlayRef)).overlayElement);
            this.focusTrap.focusInitialElement();
        }
    }
    /**
     * @private
     * @return {?}
     */
    restoreFocus() {
        // We need the extra check, because IE can set the `activeElement` to null in some cases.
        if (this.previouslyFocusedElement && typeof this.previouslyFocusedElement.focus === 'function') {
            this.previouslyFocusedElement.focus();
        }
        if (this.focusTrap) {
            this.focusTrap.destroy();
        }
    }
}
NzDrawerComponent.decorators = [
    { type: Component, args: [{
                selector: 'nz-drawer',
                exportAs: 'nzDrawer',
                template: "<ng-template #drawerTemplate>\n  <div\n    class=\"ant-drawer\"\n    [nzNoAnimation]=\"nzNoAnimation\"\n    [class.ant-drawer-open]=\"isOpen\"\n    [class.ant-drawer-top]=\"nzPlacement === 'top'\"\n    [class.ant-drawer-bottom]=\"nzPlacement === 'bottom'\"\n    [class.ant-drawer-right]=\"nzPlacement === 'right'\"\n    [class.ant-drawer-left]=\"nzPlacement === 'left'\"\n    [style.transform]=\"offsetTransform\"\n    [style.zIndex]=\"nzZIndex\">\n    <div  class=\"ant-drawer-mask\" (click)=\"maskClick()\" *ngIf=\"nzMask\" [ngStyle]=\"nzMaskStyle\"></div>\n    <div class=\"ant-drawer-content-wrapper {{ nzWrapClassName }}\"\n         [style.width]=\"width\"\n         [style.height]=\"height\"\n         [style.transform]=\"transform\">\n      <div class=\"ant-drawer-content\">\n        <div class=\"ant-drawer-wrapper-body\"\n          [style.overflow]=\"isLeftOrRight ? 'auto' : null\"\n          [style.height]=\"isLeftOrRight ? '100%' : null\">\n          <div *ngIf=\"nzTitle\" class=\"ant-drawer-header\">\n            <div class=\"ant-drawer-title\">\n              <ng-container *nzStringTemplateOutlet=\"nzTitle\"><div [innerHTML]=\"nzTitle\"></div></ng-container>\n            </div>\n          </div>\n          <button *ngIf=\"nzClosable\" (click)=\"closeClick()\" aria-label=\"Close\" class=\"ant-drawer-close\">\n            <span class=\"ant-drawer-close-x\"><i nz-icon type=\"close\"></i></span>\n          </button>\n          <div class=\"ant-drawer-body\" [ngStyle]=\"nzBodyStyle\">\n            <ng-template cdkPortalOutlet></ng-template>\n            <ng-container *ngIf=\"isTemplateRef(nzContent)\">\n              <ng-container *ngTemplateOutlet=\"nzContent; context: templateContext\"></ng-container>\n            </ng-container>\n            <ng-content *ngIf=\"!nzContent\"></ng-content>\n          </div>\n        </div>\n      </div>\n    </div>\n  </div>\n</ng-template>",
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush
            }] }
];
/** @nocollapse */
NzDrawerComponent.ctorParameters = () => [
    { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [DOCUMENT,] }] },
    { type: Renderer2 },
    { type: Overlay },
    { type: Injector },
    { type: ChangeDetectorRef },
    { type: FocusTrapFactory },
    { type: ViewContainerRef }
];
NzDrawerComponent.propDecorators = {
    nzContent: [{ type: Input }],
    nzClosable: [{ type: Input }],
    nzMaskClosable: [{ type: Input }],
    nzMask: [{ type: Input }],
    nzNoAnimation: [{ type: Input }],
    nzTitle: [{ type: Input }],
    nzPlacement: [{ type: Input }],
    nzMaskStyle: [{ type: Input }],
    nzBodyStyle: [{ type: Input }],
    nzWrapClassName: [{ type: Input }],
    nzWidth: [{ type: Input }],
    nzHeight: [{ type: Input }],
    nzZIndex: [{ type: Input }],
    nzOffsetX: [{ type: Input }],
    nzOffsetY: [{ type: Input }],
    nzVisible: [{ type: Input }],
    nzOnViewInit: [{ type: Output }],
    nzOnClose: [{ type: Output }],
    drawerTemplate: [{ type: ViewChild, args: ['drawerTemplate',] }],
    contentTemplate: [{ type: ViewChild, args: ['contentTemplate',] }],
    bodyPortalOutlet: [{ type: ViewChild, args: [CdkPortalOutlet,] }]
};
__decorate([
    InputBoolean(),
    __metadata("design:type", Object)
], NzDrawerComponent.prototype, "nzClosable", void 0);
__decorate([
    InputBoolean(),
    __metadata("design:type", Object)
], NzDrawerComponent.prototype, "nzMaskClosable", void 0);
__decorate([
    InputBoolean(),
    __metadata("design:type", Object)
], NzDrawerComponent.prototype, "nzMask", void 0);
__decorate([
    InputBoolean(),
    __metadata("design:type", Object)
], NzDrawerComponent.prototype, "nzNoAnimation", void 0);

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @template R
 */
class DrawerBuilderForService {
    /**
     * @param {?} overlay
     * @param {?} options
     */
    constructor(overlay, options) {
        this.overlay = overlay;
        this.options = options;
        this.unsubscribe$ = new Subject();
        /**
         * pick {\@link NzDrawerOptions.nzOnCancel} and omit this option
         */
        const _a = this.options, { nzOnCancel } = _a, componentOption = __rest(_a, ["nzOnCancel"]);
        this.createDrawer();
        this.updateOptions(componentOption);
        // Prevent repeatedly open drawer when tap focus element.
        (/** @type {?} */ (this.drawerRef)).instance.savePreviouslyFocusedElement();
        (/** @type {?} */ (this.drawerRef)).instance.nzOnViewInit.pipe(takeUntil(this.unsubscribe$)).subscribe((/**
         * @return {?}
         */
        () => {
            (/** @type {?} */ (this.drawerRef)).instance.open();
        }));
        (/** @type {?} */ (this.drawerRef)).instance.nzOnClose.subscribe((/**
         * @return {?}
         */
        () => {
            if (nzOnCancel) {
                nzOnCancel().then((/**
                 * @param {?} canClose
                 * @return {?}
                 */
                canClose => {
                    if (canClose !== false) {
                        (/** @type {?} */ (this.drawerRef)).instance.close();
                    }
                }));
            }
            else {
                (/** @type {?} */ (this.drawerRef)).instance.close();
            }
        }));
        (/** @type {?} */ (this.drawerRef)).instance.afterClose.pipe(takeUntil(this.unsubscribe$)).subscribe((/**
         * @return {?}
         */
        () => {
            this.overlayRef.dispose();
            this.drawerRef = null;
            this.unsubscribe$.next();
            this.unsubscribe$.complete();
        }));
    }
    /**
     * @return {?}
     */
    getInstance() {
        return (/** @type {?} */ (this.drawerRef)) && (/** @type {?} */ (this.drawerRef)).instance;
    }
    /**
     * @return {?}
     */
    createDrawer() {
        this.overlayRef = this.overlay.create();
        this.drawerRef = this.overlayRef.attach(new ComponentPortal(NzDrawerComponent));
    }
    /**
     * @param {?} options
     * @return {?}
     */
    updateOptions(options) {
        Object.assign((/** @type {?} */ (this.drawerRef)).instance, options);
    }
}
class NzDrawerService {
    /**
     * @param {?} overlay
     */
    constructor(overlay) {
        this.overlay = overlay;
    }
    // tslint:disable-next-line:no-any
    /**
     * @template T, D, R
     * @param {?} options
     * @return {?}
     */
    create(options) {
        return new DrawerBuilderForService(this.overlay, options).getInstance();
    }
}
NzDrawerService.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */
NzDrawerService.ctorParameters = () => [
    { type: Overlay }
];
/** @nocollapse */ NzDrawerService.ngInjectableDef = defineInjectable({ factory: function NzDrawerService_Factory() { return new NzDrawerService(inject(Overlay)); }, token: NzDrawerService, providedIn: "root" });

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class NzDrawerModule {
}
NzDrawerModule.decorators = [
    { type: NgModule, args: [{
                imports: [CommonModule, OverlayModule, PortalModule, NzIconModule, NzAddOnModule, NzNoAnimationModule],
                exports: [NzDrawerComponent],
                declarations: [NzDrawerComponent],
                entryComponents: [NzDrawerComponent],
                providers: [NzDrawerService]
            },] }
];

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

export { DRAWER_ANIMATE_DURATION, NzDrawerComponent, NzDrawerModule, DrawerBuilderForService, NzDrawerService, NzDrawerRef };

//# sourceMappingURL=ng-zorro-antd-drawer.js.map