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
import { FocusTrapFactory } from '@angular/cdk/a11y';
import { ESCAPE } from '@angular/cdk/keycodes';
import { Overlay, OverlayKeyboardDispatcher, OverlayRef } from '@angular/cdk/overlay';
import { DOCUMENT } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ComponentFactoryResolver, ElementRef, EventEmitter, Inject, Injector, Input, Optional, Output, TemplateRef, Type, ViewChild, ViewContainerRef } from '@angular/core';
import { fromEvent, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { getElementOffset, isPromise, InputBoolean } from 'ng-zorro-antd/core';
import { NzI18nService } from 'ng-zorro-antd/i18n';
import { NZ_MODAL_CONFIG } from './nz-modal-config';
import { NzModalControlService } from './nz-modal-control.service';
import { NzModalRef } from './nz-modal-ref.class';
/** @type {?} */
export const MODAL_ANIMATE_DURATION = 200;
/** @type {?} */
export const WRAP_CLASS_NAME = 'ant-modal-wrap';
/**
 * @template T, R
 */
// tslint:disable-next-line:no-any
export class NzModalComponent extends NzModalRef {
    // tslint:disable-line:no-any
    /**
     * @param {?} overlay
     * @param {?} overlayKeyboardDispatcher
     * @param {?} i18n
     * @param {?} cfr
     * @param {?} elementRef
     * @param {?} viewContainer
     * @param {?} modalControl
     * @param {?} focusTrapFactory
     * @param {?} cdr
     * @param {?} nzModalGlobalConfig
     * @param {?} document
     */
    constructor(overlay, overlayKeyboardDispatcher, i18n, cfr, elementRef, viewContainer, modalControl, focusTrapFactory, cdr, nzModalGlobalConfig, document // tslint:disable-line:no-any
    ) {
        super();
        this.overlay = overlay;
        this.overlayKeyboardDispatcher = overlayKeyboardDispatcher;
        this.i18n = i18n;
        this.cfr = cfr;
        this.elementRef = elementRef;
        this.viewContainer = viewContainer;
        this.modalControl = modalControl;
        this.focusTrapFactory = focusTrapFactory;
        this.cdr = cdr;
        this.nzModalGlobalConfig = nzModalGlobalConfig;
        this.document = document;
        this.nzVisible = false;
        this.nzClosable = true;
        this.nzOkLoading = false;
        this.nzOkDisabled = false;
        this.nzCancelDisabled = false;
        this.nzCancelLoading = false;
        this.nzKeyboard = true;
        this.nzNoAnimation = false;
        // [STATIC] Default Modal ONLY
        this.nzGetContainer = (/**
         * @return {?}
         */
        () => this.overlay.create()); // [STATIC]
        // [STATIC]
        this.nzZIndex = 1000;
        this.nzWidth = 520;
        this.nzOkType = 'primary';
        this.nzIconType = 'question-circle'; // Confirm Modal ONLY
        // Confirm Modal ONLY
        this.nzModalType = 'default';
        this.nzOnOk = new EventEmitter();
        this.nzOnCancel = new EventEmitter();
        this.nzAfterOpen = new EventEmitter(); // Trigger when modal open(visible) after animations
        // Trigger when modal open(visible) after animations
        this.nzAfterClose = new EventEmitter(); // Trigger when modal leave-animation over
        // Trigger when modal leave-animation over
        this.nzVisibleChange = new EventEmitter();
        this.locale = {};
        this.transformOrigin = '0px 0px 0px'; // The origin point that animation based on
        this.unsubscribe$ = new Subject();
        this.dialogMouseDown = false;
        this.scrollStrategy = this.overlay.scrollStrategies.block();
    }
    // Only aim to focus the ok button that needs to be auto focused
    /**
     * @return {?}
     */
    get afterOpen() {
        // Observable alias for nzAfterOpen
        return this.nzAfterOpen.asObservable();
    }
    /**
     * @return {?}
     */
    get afterClose() {
        // Observable alias for nzAfterClose
        return this.nzAfterClose.asObservable();
    }
    /**
     * @return {?}
     */
    get cancelText() {
        return this.nzCancelText || (/** @type {?} */ (this.locale.cancelText));
    }
    /**
     * @return {?}
     */
    get okText() {
        return this.nzOkText || (/** @type {?} */ (this.locale.okText));
    }
    /**
     * @return {?}
     */
    get hidden() {
        return !this.nzVisible && !this.animationState;
    } // Indicate whether this dialog should hidden
    // Indicate whether this dialog should hidden
    /**
     * \@description
     * The calculated highest weight of mask value
     *
     * Weight of different mask input:
     * component default value < global configuration < component input value
     * @return {?}
     */
    get mask() {
        if (this.nzMask != null) {
            return this.nzMask;
        }
        else if (this.nzModalGlobalConfig && this.nzModalGlobalConfig.nzMask != null) {
            return this.nzModalGlobalConfig.nzMask;
        }
        else {
            return true;
        }
    }
    /**
     * \@description
     * The calculated highest weight of maskClosable value
     *
     * Weight of different maskClosable input:
     * component default value < global configuration < component input value
     * @return {?}
     */
    get maskClosable() {
        if (this.nzMaskClosable != null) {
            return this.nzMaskClosable;
        }
        else if (this.nzModalGlobalConfig && this.nzModalGlobalConfig.nzMaskClosable != null) {
            return this.nzModalGlobalConfig.nzMaskClosable;
        }
        else {
            return true;
        }
    }
    /**
     * @return {?}
     */
    ngOnInit() {
        this.i18n.localeChange.pipe(takeUntil(this.unsubscribe$)).subscribe((/**
         * @return {?}
         */
        () => {
            this.locale = (/** @type {?} */ (this.i18n.getLocaleData('Modal')));
        }));
        if (this.isComponent(this.nzContent)) {
            this.createDynamicComponent((/** @type {?} */ (this.nzContent))); // Create component along without View
        }
        if (this.isModalButtons(this.nzFooter)) {
            // Setup default button options
            this.nzFooter = this.formatModalButtons((/** @type {?} */ (this.nzFooter)));
        }
        // Place the modal dom to elsewhere
        this.container = typeof this.nzGetContainer === 'function' ? this.nzGetContainer() : this.nzGetContainer;
        if (this.container instanceof HTMLElement) {
            this.container.appendChild(this.elementRef.nativeElement);
            fromEvent(this.document.body, 'keydown')
                .pipe(takeUntil(this.unsubscribe$))
                .subscribe((/**
             * @param {?} e
             * @return {?}
             */
            e => this.keydownListener(e)));
        }
        else if (this.container instanceof OverlayRef) {
            // NOTE: only attach the dom to overlay, the view container is not changed actually
            this.setOverlayRef(this.container);
            this.container.overlayElement.appendChild(this.elementRef.nativeElement);
        }
        if (this.overlayRef) {
            this.overlayRef
                .keydownEvents()
                .pipe(takeUntil(this.unsubscribe$))
                .subscribe((/**
             * @param {?} e
             * @return {?}
             */
            e => this.keydownListener(e)));
        }
        // Register modal when afterOpen/afterClose is stable
        this.modalControl.registerModal(this);
    }
    // [NOTE] NOT available when using by service!
    // Because ngOnChanges never be called when using by service,
    // here we can't support "nzContent"(Component) etc. as inputs that initialized dynamically.
    // BUT: User also can change "nzContent" dynamically to trigger UI changes (provided you don't use Component that needs initializations)
    /**
     * @param {?} changes
     * @return {?}
     */
    ngOnChanges(changes) {
        if (changes.nzVisible) {
            this.handleVisibleStateChange(this.nzVisible, !changes.nzVisible.firstChange); // Do not trigger animation while initializing
        }
    }
    /**
     * @return {?}
     */
    ngAfterViewInit() {
        // If using Component, it is the time to attach View while bodyContainer is ready
        if (this.contentComponentRef) {
            this.bodyContainer.insert(this.contentComponentRef.hostView);
        }
        if (this.autoFocusButtonOk) {
            ((/** @type {?} */ (this.autoFocusButtonOk.nativeElement))).focus();
        }
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        // Close self before destructing
        this.changeVisibleFromInside(false).then((/**
         * @return {?}
         */
        () => {
            this.modalControl.deregisterModal(this);
            if (this.container instanceof OverlayRef) {
                this.container.dispose();
            }
            this.unsubscribe$.next();
            this.unsubscribe$.complete();
        }));
        clearTimeout(this.timeoutId);
    }
    /**
     * @param {?} overlayRef
     * @return {?}
     */
    setOverlayRef(overlayRef) {
        this.overlayRef = overlayRef;
    }
    /**
     * @param {?} event
     * @return {?}
     */
    keydownListener(event) {
        if (event.keyCode === ESCAPE && this.nzKeyboard) {
            this.onClickOkCancel('cancel');
        }
    }
    /**
     * @return {?}
     */
    open() {
        this.changeVisibleFromInside(true);
    }
    /**
     * @param {?=} result
     * @return {?}
     */
    close(result) {
        this.changeVisibleFromInside(false, result);
    }
    /**
     * @param {?=} result
     * @return {?}
     */
    destroy(result) {
        // Destroy equals Close
        this.close(result);
    }
    /**
     * @return {?}
     */
    triggerOk() {
        this.onClickOkCancel('ok');
    }
    /**
     * @return {?}
     */
    triggerCancel() {
        this.onClickOkCancel('cancel');
    }
    /**
     * @return {?}
     */
    getInstance() {
        return this;
    }
    /**
     * @return {?}
     */
    getContentComponentRef() {
        return this.contentComponentRef;
    }
    /**
     * @return {?}
     */
    getContentComponent() {
        return this.contentComponentRef && this.contentComponentRef.instance;
    }
    /**
     * @return {?}
     */
    getElement() {
        return this.elementRef && this.elementRef.nativeElement;
    }
    /**
     * @return {?}
     */
    onMaskDialogDown() {
        this.dialogMouseDown = true;
    }
    /**
     * @return {?}
     */
    onDialogUp() {
        if (this.dialogMouseDown) {
            this.timeoutId = setTimeout((/**
             * @return {?}
             */
            () => {
                this.dialogMouseDown = false;
            }), 0);
        }
    }
    /**
     * @param {?} $event
     * @return {?}
     */
    onClickMask($event) {
        if (this.mask &&
            this.maskClosable &&
            ((/** @type {?} */ ($event.target))).classList.contains(WRAP_CLASS_NAME) &&
            this.nzVisible &&
            !this.dialogMouseDown) {
            this.onClickOkCancel('cancel');
        }
    }
    /**
     * @param {?} type
     * @return {?}
     */
    isModalType(type) {
        return this.nzModalType === type;
    }
    /**
     * @return {?}
     */
    onClickCloseBtn() {
        if (this.nzVisible) {
            this.onClickOkCancel('cancel');
        }
    }
    /**
     * @param {?} type
     * @return {?}
     */
    onClickOkCancel(type) {
        /** @type {?} */
        const trigger = { ok: this.nzOnOk, cancel: this.nzOnCancel }[type];
        /** @type {?} */
        const loadingKey = { ok: 'nzOkLoading', cancel: 'nzCancelLoading' }[type];
        if (trigger instanceof EventEmitter) {
            trigger.emit(this.getContentComponent());
        }
        else if (typeof trigger === 'function') {
            /** @type {?} */
            const result = trigger(this.getContentComponent());
            /** @type {?} */
            const caseClose = (/**
             * @param {?} doClose
             * @return {?}
             */
            (doClose) => doClose !== false && this.close((/** @type {?} */ (doClose))));
            if (isPromise(result)) {
                this[loadingKey] = true;
                /** @type {?} */
                const handleThen = (/**
                 * @param {?} doClose
                 * @return {?}
                 */
                (doClose) => {
                    this[loadingKey] = false;
                    caseClose(doClose);
                });
                ((/** @type {?} */ (result))).then(handleThen).catch(handleThen);
            }
            else {
                caseClose(result);
            }
        }
    }
    /**
     * @param {?} value
     * @return {?}
     */
    isNonEmptyString(value) {
        return typeof value === 'string' && value !== '';
    }
    /**
     * @param {?} value
     * @return {?}
     */
    isTemplateRef(value) {
        return value instanceof TemplateRef;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    isComponent(value) {
        return value instanceof Type;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    isModalButtons(value) {
        return Array.isArray(value) && value.length > 0;
    }
    // Do rest things when visible state changed
    /**
     * @private
     * @param {?} visible
     * @param {?=} animation
     * @param {?=} closeResult
     * @return {?}
     */
    handleVisibleStateChange(visible, animation = true, closeResult) {
        if (visible) {
            // Hide scrollbar at the first time when shown up
            this.scrollStrategy.enable();
            this.savePreviouslyFocusedElement();
            this.trapFocus();
            if (this.container instanceof OverlayRef) {
                this.overlayKeyboardDispatcher.add(this.overlayRef);
            }
        }
        else {
            if (this.container instanceof OverlayRef) {
                this.overlayKeyboardDispatcher.remove(this.overlayRef);
            }
        }
        return Promise.resolve(animation ? this.animateTo(visible) : undefined).then((/**
         * @return {?}
         */
        () => {
            // Emit open/close event after animations over
            if (visible) {
                this.nzAfterOpen.emit();
            }
            else {
                this.nzAfterClose.emit(closeResult);
                this.restoreFocus();
                this.scrollStrategy.disable();
                // Mark the for check so it can react if the view container is using OnPush change detection.
                this.cdr.markForCheck();
            }
        }));
    }
    // Lookup a button's property, if the prop is a function, call & then return the result, otherwise, return itself.
    /**
     * @param {?} options
     * @param {?} prop
     * @return {?}
     */
    getButtonCallableProp(options, prop) {
        /** @type {?} */
        const value = options[prop];
        /** @type {?} */
        const args = [];
        if (this.contentComponentRef) {
            args.push(this.contentComponentRef.instance);
        }
        return typeof value === 'function' ? value.apply(options, args) : value;
    }
    // On nzFooter's modal button click
    /**
     * @param {?} button
     * @return {?}
     */
    onButtonClick(button) {
        /** @type {?} */
        const result = this.getButtonCallableProp(button, 'onClick');
        if (isPromise(result)) {
            button.loading = true;
            ((/** @type {?} */ (result))).then((/**
             * @return {?}
             */
            () => (button.loading = false))).catch((/**
             * @return {?}
             */
            () => (button.loading = false)));
        }
    }
    // Change nzVisible from inside
    /**
     * @private
     * @param {?} visible
     * @param {?=} closeResult
     * @return {?}
     */
    changeVisibleFromInside(visible, closeResult) {
        if (this.nzVisible !== visible) {
            // Change nzVisible value immediately
            this.nzVisible = visible;
            this.nzVisibleChange.emit(visible);
            return this.handleVisibleStateChange(visible, true, closeResult);
        }
        return Promise.resolve();
    }
    /**
     * @private
     * @param {?} state
     * @return {?}
     */
    changeAnimationState(state) {
        this.animationState = state;
        if (state) {
            this.maskAnimationClassMap = {
                [`fade-${state}`]: true,
                [`fade-${state}-active`]: true
            };
            this.modalAnimationClassMap = {
                [`zoom-${state}`]: true,
                [`zoom-${state}-active`]: true
            };
        }
        else {
            this.maskAnimationClassMap = this.modalAnimationClassMap = null;
        }
    }
    /**
     * @private
     * @param {?} isVisible
     * @return {?}
     */
    animateTo(isVisible) {
        if (isVisible) {
            // Figure out the lastest click position when shows up
            setTimeout((/**
             * @return {?}
             */
            () => this.updateTransformOrigin())); // [NOTE] Using timeout due to the document.click event is fired later than visible change, so if not postponed to next event-loop, we can't get the lastest click position
        }
        this.changeAnimationState(isVisible ? 'enter' : 'leave');
        return new Promise((/**
         * @param {?} resolve
         * @return {?}
         */
        resolve => setTimeout((/**
         * @return {?}
         */
        () => {
            // Return when animation is over
            this.changeAnimationState(null);
            resolve();
        }), this.nzNoAnimation ? 0 : MODAL_ANIMATE_DURATION)));
    }
    /**
     * @private
     * @param {?} buttons
     * @return {?}
     */
    formatModalButtons(buttons) {
        return buttons.map((/**
         * @param {?} button
         * @return {?}
         */
        button => {
            return Object.assign({
                type: 'default',
                size: 'default',
                autoLoading: true,
                show: true,
                loading: false,
                disabled: false
            }, button);
        }));
    }
    /**
     * Create a component dynamically but not attach to any View (this action will be executed when bodyContainer is ready)
     * @private
     * @param {?} component Component class
     * @return {?}
     */
    createDynamicComponent(component) {
        /** @type {?} */
        const factory = this.cfr.resolveComponentFactory(component);
        /** @type {?} */
        const childInjector = Injector.create({
            providers: [{ provide: NzModalRef, useValue: this }],
            parent: this.viewContainer.parentInjector
        });
        this.contentComponentRef = factory.create(childInjector);
        if (this.nzComponentParams) {
            Object.assign(this.contentComponentRef.instance, this.nzComponentParams);
        }
        // Do the first change detection immediately (or we do detection at ngAfterViewInit, multi-changes error will be thrown)
        this.contentComponentRef.changeDetectorRef.detectChanges();
    }
    // Update transform-origin to the last click position on document
    /**
     * @private
     * @return {?}
     */
    updateTransformOrigin() {
        /** @type {?} */
        const modalElement = (/** @type {?} */ (this.modalContainer.nativeElement));
        if (this.previouslyFocusedElement) {
            /** @type {?} */
            const previouslyDOMRect = this.previouslyFocusedElement.getBoundingClientRect();
            /** @type {?} */
            const lastPosition = getElementOffset(this.previouslyFocusedElement);
            /** @type {?} */
            const x = lastPosition.left + previouslyDOMRect.width / 2;
            /** @type {?} */
            const y = lastPosition.top + previouslyDOMRect.height / 2;
            this.transformOrigin = `${x - modalElement.offsetLeft}px ${y - modalElement.offsetTop}px 0px`;
        }
    }
    /**
     * @private
     * @return {?}
     */
    savePreviouslyFocusedElement() {
        if (this.document) {
            this.previouslyFocusedElement = (/** @type {?} */ (this.document.activeElement));
        }
    }
    /**
     * @private
     * @return {?}
     */
    trapFocus() {
        if (!this.focusTrap) {
            this.focusTrap = this.focusTrapFactory.create(this.elementRef.nativeElement);
        }
        this.focusTrap.focusInitialElementWhenReady();
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
NzModalComponent.decorators = [
    { type: Component, args: [{
                selector: 'nz-modal',
                exportAs: 'nzModal',
                template: "<ng-template #tplOriginContent><ng-content></ng-content></ng-template> <!-- Compatible: the <ng-content> can appear only once -->\n\n<div [nzNoAnimation]=\"nzNoAnimation\">\n  <div *ngIf=\"mask\"\n    class=\"ant-modal-mask\"\n    [ngClass]=\"maskAnimationClassMap\"\n    [class.ant-modal-mask-hidden]=\"hidden\"\n    [ngStyle]=\"nzMaskStyle\"\n    [style.zIndex]=\"nzZIndex\"\n  ></div>\n  <div\n    (click)=\"onClickMask($event)\"\n    (mouseup)=\"onDialogUp()\"\n    class=\"ant-modal-wrap {{ nzWrapClassName }}\"\n    [style.zIndex]=\"nzZIndex\"\n    [style.visibility]=\"hidden ? 'hidden' : null\"\n    tabindex=\"-1\"\n    role=\"dialog\"\n  >\n    <div #modalContainer\n      class=\"ant-modal {{ nzClassName }}\"\n      (mousedown)=\"onMaskDialogDown()\"\n      [ngClass]=\"modalAnimationClassMap\"\n      [ngStyle]=\"nzStyle\"\n      [style.width]=\"nzWidth | toCssUnit\"\n      [style.transform-origin]=\"transformOrigin\"\n      role=\"document\"\n    >\n      <div class=\"ant-modal-content\">\n        <button *ngIf=\"nzClosable\" (click)=\"onClickCloseBtn()\" class=\"ant-modal-close\" aria-label=\"Close\">\n          <span class=\"ant-modal-close-x\">\n            <i nz-icon type=\"close\" class=\"ant-modal-close-icon\"></i>\n          </span>\n        </button>\n        <ng-container *ngIf=\"!hidden\" [ngSwitch]=\"true\">\n          <ng-container *ngSwitchCase=\"isModalType('default')\" [ngTemplateOutlet]=\"tplContentDefault\"></ng-container>\n          <ng-container *ngSwitchCase=\"isModalType('confirm')\" [ngTemplateOutlet]=\"tplContentConfirm\"></ng-container>\n        </ng-container>\n      </div>\n    </div>\n  </div>\n</div>\n\n<!-- [Predefined] Default Modal Content -->\n<ng-template #tplContentDefault>\n  <div *ngIf=\"nzTitle\" class=\"ant-modal-header\">\n    <div class=\"ant-modal-title\">\n      <ng-container [ngSwitch]=\"true\">\n        <ng-container *ngSwitchCase=\"isTemplateRef(nzTitle)\" [ngTemplateOutlet]=\"nzTitle\"></ng-container>\n        <ng-container *ngSwitchCase=\"isNonEmptyString(nzTitle)\"><div [innerHTML]=\"nzTitle\"></div></ng-container>\n      </ng-container>\n    </div>\n  </div>\n  <div class=\"ant-modal-body\" [ngStyle]=\"nzBodyStyle\">\n    <ng-container #bodyContainer>\n      <ng-container *ngIf=\"!isComponent(nzContent)\" [ngSwitch]=\"true\">\n        <ng-container *ngSwitchCase=\"isTemplateRef(nzContent)\" [ngTemplateOutlet]=\"nzContent\"></ng-container>\n        <ng-container *ngSwitchCase=\"isNonEmptyString(nzContent)\"><div [innerHTML]=\"nzContent\"></div></ng-container>\n        <ng-container *ngSwitchDefault [ngTemplateOutlet]=\"tplOriginContent\"></ng-container>\n      </ng-container>\n    </ng-container>\n  </div>\n  <div *ngIf=\"nzFooter !== null\" class=\"ant-modal-footer\">\n    <ng-container [ngSwitch]=\"true\">\n      <ng-container *ngSwitchCase=\"isTemplateRef(nzFooter)\" [ngTemplateOutlet]=\"nzFooter\"></ng-container>\n      <ng-container *ngSwitchCase=\"isNonEmptyString(nzFooter)\"><div [innerHTML]=\"nzFooter\"></div></ng-container>\n      <ng-container *ngSwitchCase=\"isModalButtons(nzFooter)\">\n        <button *ngFor=\"let button of nzFooter\" nz-button\n          (click)=\"onButtonClick(button)\"\n          [hidden]=\"!getButtonCallableProp(button, 'show')\"\n          [nzLoading]=\"getButtonCallableProp(button, 'loading')\"\n          [disabled]=\"getButtonCallableProp(button, 'disabled')\"\n          [nzType]=\"button.type\"\n          [nzShape]=\"button.shape\"\n          [nzSize]=\"button.size\"\n          [nzGhost]=\"button.ghost\"\n        >{{ button.label }}</button>\n      </ng-container>\n      <ng-container *ngSwitchDefault>\n        <button *ngIf=\"nzCancelText!==null\" nz-button (click)=\"onClickOkCancel('cancel')\" [nzLoading]=\"nzCancelLoading\" [disabled]=\"nzCancelDisabled\">\n          {{ cancelText }}\n        </button>\n        <button *ngIf=\"nzOkText!==null\" nz-button [nzType]=\"nzOkType\" (click)=\"onClickOkCancel('ok')\" [nzLoading]=\"nzOkLoading\" [disabled]=\"nzOkDisabled\">\n          {{ okText }}\n        </button>\n      </ng-container>\n    </ng-container>\n  </div>\n</ng-template>\n<!-- /[Predefined] Default Modal Content -->\n\n<!-- [Predefined] Confirm Modal Content -->\n<ng-template #tplContentConfirm>\n  <div class=\"ant-modal-body\" [ngStyle]=\"nzBodyStyle\">\n    <div class=\"ant-modal-confirm-body-wrapper\">\n      <div class=\"ant-modal-confirm-body\">\n        <i nz-icon [type]=\"nzIconType\"></i>\n        <span class=\"ant-modal-confirm-title\">\n          <ng-container [ngSwitch]=\"true\">\n            <ng-container *ngSwitchCase=\"isTemplateRef(nzTitle)\" [ngTemplateOutlet]=\"nzTitle\"></ng-container>\n            <ng-container *ngSwitchCase=\"isNonEmptyString(nzTitle)\"><span [innerHTML]=\"nzTitle\"></span></ng-container>\n          </ng-container>\n        </span>\n        <div class=\"ant-modal-confirm-content\">\n          <ng-container #bodyContainer>\n            <ng-container *ngIf=\"!isComponent(nzContent)\" [ngSwitch]=\"true\">\n              <ng-container *ngSwitchCase=\"isTemplateRef(nzContent)\" [ngTemplateOutlet]=\"nzContent\"></ng-container>\n              <ng-container *ngSwitchCase=\"isNonEmptyString(nzContent)\"><div [innerHTML]=\"nzContent\"></div></ng-container>\n              <ng-container *ngSwitchDefault [ngTemplateOutlet]=\"tplOriginContent\"></ng-container>\n            </ng-container>\n          </ng-container>\n        </div>\n      </div>\n      <div class=\"ant-modal-confirm-btns\">\n        <button nz-button *ngIf=\"nzCancelText!==null\" (click)=\"onClickOkCancel('cancel')\" [nzLoading]=\"nzCancelLoading\">\n          {{ cancelText }}\n        </button>\n        <button *ngIf=\"nzOkText!==null\" #autoFocusButtonOk nz-button [nzType]=\"nzOkType\" (click)=\"onClickOkCancel('ok')\" [nzLoading]=\"nzOkLoading\">\n          {{ okText }}\n        </button>\n      </div>\n    </div> <!-- /.ant-modal-confirm-body-wrapper -->\n  </div>\n</ng-template>\n<!-- /[Predefined] Confirm Modal Content -->\n",
                // Using OnPush for modal caused footer can not to detect changes. we can fix it when 8.x.
                changeDetection: ChangeDetectionStrategy.Default
            }] }
];
/** @nocollapse */
NzModalComponent.ctorParameters = () => [
    { type: Overlay },
    { type: OverlayKeyboardDispatcher },
    { type: NzI18nService },
    { type: ComponentFactoryResolver },
    { type: ElementRef },
    { type: ViewContainerRef },
    { type: NzModalControlService },
    { type: FocusTrapFactory },
    { type: ChangeDetectorRef },
    { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [NZ_MODAL_CONFIG,] }] },
    { type: undefined, decorators: [{ type: Inject, args: [DOCUMENT,] }] }
];
NzModalComponent.propDecorators = {
    nzVisible: [{ type: Input }],
    nzClosable: [{ type: Input }],
    nzOkLoading: [{ type: Input }],
    nzOkDisabled: [{ type: Input }],
    nzCancelDisabled: [{ type: Input }],
    nzCancelLoading: [{ type: Input }],
    nzKeyboard: [{ type: Input }],
    nzNoAnimation: [{ type: Input }],
    nzMask: [{ type: Input }],
    nzMaskClosable: [{ type: Input }],
    nzContent: [{ type: Input }],
    nzComponentParams: [{ type: Input }],
    nzFooter: [{ type: Input }],
    nzGetContainer: [{ type: Input }],
    nzZIndex: [{ type: Input }],
    nzWidth: [{ type: Input }],
    nzWrapClassName: [{ type: Input }],
    nzClassName: [{ type: Input }],
    nzStyle: [{ type: Input }],
    nzTitle: [{ type: Input }],
    nzMaskStyle: [{ type: Input }],
    nzBodyStyle: [{ type: Input }],
    nzOkText: [{ type: Input }],
    nzCancelText: [{ type: Input }],
    nzOkType: [{ type: Input }],
    nzIconType: [{ type: Input }],
    nzModalType: [{ type: Input }],
    nzOnOk: [{ type: Input }, { type: Output }],
    nzOnCancel: [{ type: Input }, { type: Output }],
    nzAfterOpen: [{ type: Output }],
    nzAfterClose: [{ type: Output }],
    nzVisibleChange: [{ type: Output }],
    modalContainer: [{ type: ViewChild, args: ['modalContainer',] }],
    bodyContainer: [{ type: ViewChild, args: ['bodyContainer', { read: ViewContainerRef },] }],
    autoFocusButtonOk: [{ type: ViewChild, args: ['autoFocusButtonOk', { read: ElementRef },] }]
};
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzVisible", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzClosable", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzOkLoading", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzOkDisabled", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzCancelDisabled", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzCancelLoading", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzKeyboard", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzModalComponent.prototype, "nzNoAnimation", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzMask", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzModalComponent.prototype, "nzMaskClosable", void 0);
if (false) {
    /** @type {?} */
    NzModalComponent.prototype.nzVisible;
    /** @type {?} */
    NzModalComponent.prototype.nzClosable;
    /** @type {?} */
    NzModalComponent.prototype.nzOkLoading;
    /** @type {?} */
    NzModalComponent.prototype.nzOkDisabled;
    /** @type {?} */
    NzModalComponent.prototype.nzCancelDisabled;
    /** @type {?} */
    NzModalComponent.prototype.nzCancelLoading;
    /** @type {?} */
    NzModalComponent.prototype.nzKeyboard;
    /** @type {?} */
    NzModalComponent.prototype.nzNoAnimation;
    /** @type {?} */
    NzModalComponent.prototype.nzMask;
    /** @type {?} */
    NzModalComponent.prototype.nzMaskClosable;
    /** @type {?} */
    NzModalComponent.prototype.nzContent;
    /** @type {?} */
    NzModalComponent.prototype.nzComponentParams;
    /** @type {?} */
    NzModalComponent.prototype.nzFooter;
    /** @type {?} */
    NzModalComponent.prototype.nzGetContainer;
    /** @type {?} */
    NzModalComponent.prototype.nzZIndex;
    /** @type {?} */
    NzModalComponent.prototype.nzWidth;
    /** @type {?} */
    NzModalComponent.prototype.nzWrapClassName;
    /** @type {?} */
    NzModalComponent.prototype.nzClassName;
    /** @type {?} */
    NzModalComponent.prototype.nzStyle;
    /** @type {?} */
    NzModalComponent.prototype.nzTitle;
    /** @type {?} */
    NzModalComponent.prototype.nzMaskStyle;
    /** @type {?} */
    NzModalComponent.prototype.nzBodyStyle;
    /** @type {?} */
    NzModalComponent.prototype.nzOkText;
    /** @type {?} */
    NzModalComponent.prototype.nzCancelText;
    /** @type {?} */
    NzModalComponent.prototype.nzOkType;
    /** @type {?} */
    NzModalComponent.prototype.nzIconType;
    /** @type {?} */
    NzModalComponent.prototype.nzModalType;
    /** @type {?} */
    NzModalComponent.prototype.nzOnOk;
    /** @type {?} */
    NzModalComponent.prototype.nzOnCancel;
    /** @type {?} */
    NzModalComponent.prototype.nzAfterOpen;
    /** @type {?} */
    NzModalComponent.prototype.nzAfterClose;
    /** @type {?} */
    NzModalComponent.prototype.nzVisibleChange;
    /** @type {?} */
    NzModalComponent.prototype.modalContainer;
    /** @type {?} */
    NzModalComponent.prototype.bodyContainer;
    /** @type {?} */
    NzModalComponent.prototype.autoFocusButtonOk;
    /** @type {?} */
    NzModalComponent.prototype.locale;
    /** @type {?} */
    NzModalComponent.prototype.maskAnimationClassMap;
    /** @type {?} */
    NzModalComponent.prototype.modalAnimationClassMap;
    /** @type {?} */
    NzModalComponent.prototype.transformOrigin;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.contentComponentRef;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.animationState;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.container;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.unsubscribe$;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.previouslyFocusedElement;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.focusTrap;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.scrollStrategy;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.overlayRef;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.dialogMouseDown;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.timeoutId;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.overlay;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.overlayKeyboardDispatcher;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.i18n;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.cfr;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.elementRef;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.viewContainer;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.modalControl;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.focusTrapFactory;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.cdr;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.nzModalGlobalConfig;
    /**
     * @type {?}
     * @private
     */
    NzModalComponent.prototype.document;
    /* Skipping unhandled member: [key: string]: any;*/
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotbW9kYWwuY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC9tb2RhbC8iLCJzb3VyY2VzIjpbIm56LW1vZGFsLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQWEsZ0JBQWdCLEVBQUUsTUFBTSxtQkFBbUIsQ0FBQztBQUVoRSxPQUFPLEVBQUUsTUFBTSxFQUFFLE1BQU0sdUJBQXVCLENBQUM7QUFDL0MsT0FBTyxFQUF1QixPQUFPLEVBQUUseUJBQXlCLEVBQUUsVUFBVSxFQUFFLE1BQU0sc0JBQXNCLENBQUM7QUFDM0csT0FBTyxFQUFFLFFBQVEsRUFBRSxNQUFNLGlCQUFpQixDQUFDO0FBQzNDLE9BQU8sRUFFTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCx3QkFBd0IsRUFFeEIsVUFBVSxFQUNWLFlBQVksRUFDWixNQUFNLEVBQ04sUUFBUSxFQUNSLEtBQUssRUFJTCxRQUFRLEVBQ1IsTUFBTSxFQUVOLFdBQVcsRUFDWCxJQUFJLEVBQ0osU0FBUyxFQUNULGdCQUFnQixFQUNqQixNQUFNLGVBQWUsQ0FBQztBQUV2QixPQUFPLEVBQUUsU0FBUyxFQUFjLE9BQU8sRUFBRSxNQUFNLE1BQU0sQ0FBQztBQUN0RCxPQUFPLEVBQUUsU0FBUyxFQUFFLE1BQU0sZ0JBQWdCLENBQUM7QUFFM0MsT0FBTyxFQUFFLGdCQUFnQixFQUFFLFNBQVMsRUFBRSxZQUFZLEVBQUUsTUFBTSxvQkFBb0IsQ0FBQztBQUMvRSxPQUFPLEVBQUUsYUFBYSxFQUFFLE1BQU0sb0JBQW9CLENBQUM7QUFFbkQsT0FBTyxFQUFpQixlQUFlLEVBQUUsTUFBTSxtQkFBbUIsQ0FBQztBQUNuRSxPQUFPLEVBQUUscUJBQXFCLEVBQUUsTUFBTSw0QkFBNEIsQ0FBQztBQUNuRSxPQUFPLEVBQUUsVUFBVSxFQUFFLE1BQU0sc0JBQXNCLENBQUM7O0FBR2xELE1BQU0sT0FBTyxzQkFB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d0Q7O0lBQ3hELDJDQUFpRTs7SUFFakUsMENBQXdEOztJQUN4RCx5Q0FBd0Y7O0lBQ3hGLDZDQUFvRjs7SUEwRHBGLGtDQUFzRDs7SUFDdEQsaURBQXFDOztJQUNyQyxrREFBc0M7O0lBQ3RDLDJDQUFnQzs7Ozs7SUFFaEMsK0NBQTZDOzs7OztJQUM3QywwQ0FBdUM7Ozs7O0lBQ3ZDLHFDQUE0Qzs7Ozs7SUFDNUMsd0NBQTJDOzs7OztJQUMzQyxvREFBOEM7Ozs7O0lBQzlDLHFDQUE2Qjs7Ozs7SUFDN0IsMENBQTRDOzs7OztJQUM1QyxzQ0FBK0I7Ozs7O0lBQy9CLDJDQUFnQzs7Ozs7SUFDaEMscUNBQTBCOzs7OztJQUt4QixtQ0FBd0I7Ozs7O0lBQ3hCLHFEQUE0RDs7Ozs7SUFDNUQsZ0NBQTJCOzs7OztJQUMzQiwrQkFBcUM7Ozs7O0lBQ3JDLHNDQUE4Qjs7Ozs7SUFDOUIseUNBQXVDOzs7OztJQUN2Qyx3Q0FBMkM7Ozs7O0lBQzNDLDRDQUEwQzs7Ozs7SUFDMUMsK0JBQThCOzs7OztJQUM5QiwrQ0FBK0U7Ozs7O0lBQy9FLG9DQUF1QyIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQgeyBGb2N1c1RyYXAsIEZvY3VzVHJhcEZhY3RvcnkgfSBmcm9tICdAYW5ndWxhci9jZGsvYTExeSc7XG5cbmltcG9ydCB7IEVTQ0FQRSB9IGZyb20gJ0Bhbmd1bGFyL2Nkay9rZXljb2Rlcyc7XG5pbXBvcnQgeyBCbG9ja1Njcm9sbFN0cmF0ZWd5LCBPdmVybGF5LCBPdmVybGF5S2V5Ym9hcmREaXNwYXRjaGVyLCBPdmVybGF5UmVmIH0gZnJvbSAnQGFuZ3VsYXIvY2RrL292ZXJsYXknO1xuaW1wb3J0IHsgRE9DVU1FTlQgfSBmcm9tICdAYW5ndWxhci9jb21tb24nO1xuaW1wb3J0IHtcbiAgQWZ0ZXJWaWV3SW5pdCxcbiAgQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3ksXG4gIENoYW5nZURldGVjdG9yUmVmLFxuICBDb21wb25lbnQsXG4gIENvbXBvbmVudEZhY3RvcnlSZXNvbHZlcixcbiAgQ29tcG9uZW50UmVmLFxuICBFbGVtZW50UmVmLFxuICBFdmVudEVtaXR0ZXIsXG4gIEluamVjdCxcbiAgSW5qZWN0b3IsXG4gIElucHV0LFxuICBPbkNoYW5nZXMsXG4gIE9uRGVzdHJveSxcbiAgT25Jbml0LFxuICBPcHRpb25hbCxcbiAgT3V0cHV0LFxuICBTaW1wbGVDaGFuZ2VzLFxuICBUZW1wbGF0ZVJlZixcbiAgVHlwZSxcbiAgVmlld0NoaWxkLFxuICBWaWV3Q29udGFpbmVyUmVmXG59IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuXG5pbXBvcnQgeyBmcm9tRXZlbnQsIE9ic2VydmFibGUsIFN1YmplY3QgfSBmcm9tICdyeGpzJztcbmltcG9ydCB7IHRha2VVbnRpbCB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuaW1wb3J0IHsgZ2V0RWxlbWVudE9mZnNldCwgaXNQcm9taXNlLCBJbnB1dEJvb2xlYW4gfSBmcm9tICduZy16b3Jyby1hbnRkL2NvcmUnO1xuaW1wb3J0IHsgTnpJMThuU2VydmljZSB9IGZyb20gJ25nLXpvcnJvLWFudGQvaTE4bic7XG5cbmltcG9ydCB7IE56TW9kYWxDb25maWcsIE5aX01PREFMX0NPTkZJRyB9IGZyb20gJy4vbnotbW9kYWwtY29uZmlnJztcbmltcG9ydCB7IE56TW9kYWxDb250cm9sU2VydmljZSB9IGZyb20gJy4vbnotbW9kYWwtY29udHJvbC5zZXJ2aWNlJztcbmltcG9ydCB7IE56TW9kYWxSZWYgfSBmcm9tICcuL256LW1vZGFsLXJlZi5jbGFzcyc7XG5pbXBvcnQgeyBNb2RhbEJ1dHRvbk9wdGlvbnMsIE1vZGFsT3B0aW9ucywgTW9kYWxUeXBlLCBPbkNsaWNrQ2FsbGJhY2sgfSBmcm9tICcuL256LW1vZGFsLnR5cGUnO1xuXG5leHBvcnQgY29uc3QgTU9EQUxfQU5JTUFURV9EVVJBVElPTiA9IDIwMDsgLy8gRHVyYXRpb24gd2hlbiBwZXJmb3JtIGFuaW1hdGlvbnMgKG1zKVxuXG50eXBlIEFuaW1hdGlvblN0YXRlID0gJ2VudGVyJyB8ICdsZWF2ZScgfCBudWxsO1xuZXhwb3J0IGNvbnN0IFdSQVBfQ0xBU1NfTkFNRSA9ICdhbnQtbW9kYWwtd3JhcCc7XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ256LW1vZGFsJyxcbiAgZXhwb3J0QXM6ICduek1vZGFsJyxcbiAgdGVtcGxhdGVVcmw6ICcuL256LW1vZGFsLmNvbXBvbmVudC5odG1sJyxcbiAgLy8gVXNpbmcgT25QdXNoIGZvciBtb2RhbCBjYXVzZWQgZm9vdGVyIGNhbiBub3QgdG8gZGV0ZWN0IGNoYW5nZXMuIHdlIGNhbiBmaXggaXQgd2hlbiA4LnguXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuRGVmYXVsdFxufSlcblxuLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOm5vLWFueVxuZXhwb3J0IGNsYXNzIE56TW9kYWxDb21wb25lbnQ8VCA9IGFueSwgUiA9IGFueT4gZXh0ZW5kcyBOek1vZGFsUmVmPFQsIFI+XG4gIGltcGxlbWVudHMgT25Jbml0LCBPbkNoYW5nZXMsIEFmdGVyVmlld0luaXQsIE9uRGVzdHJveSwgTW9kYWxPcHRpb25zPFQ+IHtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56VmlzaWJsZTogYm9vbGVhbiA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpDbG9zYWJsZTogYm9vbGVhbiA9IHRydWU7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuek9rTG9hZGluZzogYm9vbGVhbiA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpPa0Rpc2FibGVkOiBib29sZWFuID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekNhbmNlbERpc2FibGVkOiBib29sZWFuID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekNhbmNlbExvYWRpbmc6IGJvb2xlYW4gPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56S2V5Ym9hcmQ6IGJvb2xlYW4gPSB0cnVlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpOb0FuaW1hdGlvbiA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpNYXNrOiBib29sZWFuO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpNYXNrQ2xvc2FibGU6IGJvb2xlYW47XG4gIEBJbnB1dCgpIG56Q29udGVudDogc3RyaW5nIHwgVGVtcGxhdGVSZWY8e30+IHwgVHlwZTxUPjsgLy8gW1NUQVRJQ10gSWYgbm90IHNwZWNpZmllZCwgd2lsbCB1c2UgPG5nLWNvbnRlbnQ+XG4gIEBJbnB1dCgpIG56Q29tcG9uZW50UGFyYW1zOiBUOyAvLyBbU1RBVElDXSBPTkxZIGF2YWxpYWJsZSB3aGVuIG56Q29udGVudCBpcyBhIGNvbXBvbmVudFxuICBASW5wdXQoKSBuekZvb3Rlcjogc3RyaW5nIHwgVGVtcGxhdGVSZWY8e30+IHwgQXJyYXk8TW9kYWxCdXR0b25PcHRpb25zPFQ+PiB8IG51bGw7IC8vIFtTVEFUSUNdIERlZmF1bHQgTW9kYWwgT05MWVxuICBASW5wdXQoKSBuekdldENvbnRhaW5lcjogSFRNTEVsZW1lbnQgfCBPdmVybGF5UmVmIHwgKCgpID0+IEhUTUxFbGVtZW50IHwgT3ZlcmxheVJlZikgPSAoKSA9PiB0aGlzLm92ZXJsYXkuY3JlYXRlKCk7IC8vIFtTVEFUSUNdXG4gIEBJbnB1dCgpIG56WkluZGV4OiBudW1iZXIgPSAxMDAwO1xuICBASW5wdXQoKSBueldpZHRoOiBudW1iZXIgfCBzdHJpbmcgPSA1MjA7XG4gIEBJbnB1dCgpIG56V3JhcENsYXNzTmFtZTogc3RyaW5nO1xuICBASW5wdXQoKSBuekNsYXNzTmFtZTogc3RyaW5nO1xuICBASW5wdXQoKSBuelN0eWxlOiBvYmplY3Q7XG4gIEBJbnB1dCgpIG56VGl0bGU6IHN0cmluZyB8IFRlbXBsYXRlUmVmPHt9PjtcbiAgQElucHV0KCkgbnpNYXNrU3R5bGU6IG9iamVjdDtcbiAgQElucHV0KCkgbnpCb2R5U3R5bGU6IG9iamVjdDtcbiAgQElucHV0KCkgbnpPa1RleHQ6IHN0cmluZyB8IG51bGw7XG4gIEBJbnB1dCgpIG56Q2FuY2VsVGV4dDogc3RyaW5nIHwgbnVsbDtcbiAgQElucHV0KCkgbnpPa1R5cGUgPSAncHJpbWFyeSc7XG4gIEBJbnB1dCgpIG56SWNvblR5cGU6IHN0cmluZyA9ICdxdWVzdGlvbi1jaXJjbGUnOyAvLyBDb25maXJtIE1vZGFsIE9OTFlcbiAgQElucHV0KCkgbnpNb2RhbFR5cGU6IE1vZGFsVHlwZSA9ICdkZWZhdWx0JztcblxuICBASW5wdXQoKSBAT3V0cHV0KCkgcmVhZG9ubHkgbnpPbk9rOiBFdmVudEVtaXR0ZXI8VD4gfCBPbkNsaWNrQ2FsbGJhY2s8VD4gPSBuZXcgRXZlbnRFbWl0dGVyPFQ+KCk7XG4gIEBJbnB1dCgpIEBPdXRwdXQoKSByZWFkb25seSBuek9uQ2FuY2VsOiBFdmVudEVtaXR0ZXI8VD4gfCBPbkNsaWNrQ2FsbGJhY2s8VD4gPSBuZXcgRXZlbnRFbWl0dGVyPFQ+KCk7XG5cbiAgQE91dHB1dCgpIHJlYWRvbmx5IG56QWZ0ZXJPcGVuID0gbmV3IEV2ZW50RW1pdHRlcjx2b2lkPigpOyAvLyBUcmlnZ2VyIHdoZW4gbW9kYWwgb3Blbih2aXNpYmxlKSBhZnRlciBhbmltYXRpb25zXG4gIEBPdXRwdXQoKSByZWFkb25seSBuekFmdGVyQ2xvc2UgPSBuZXcgRXZlbnRFbWl0dGVyPFI+KCk7IC8vIFRyaWdnZXIgd2hlbiBtb2RhbCBsZWF2ZS1hbmltYXRpb24gb3ZlclxuICBAT3V0cHV0KCkgcmVhZG9ubHkgbnpWaXNpYmxlQ2hhbmdlID0gbmV3IEV2ZW50RW1pdHRlcjxib29sZWFuPigpO1xuXG4gIEBWaWV3Q2hpbGQoJ21vZGFsQ29udGFpbmVyJykgbW9kYWxDb250YWluZXI6IEVsZW1lbnRSZWY7XG4gIEBWaWV3Q2hpbGQoJ2JvZHlDb250YWluZXInLCB7IHJlYWQ6IFZpZXdDb250YWluZXJSZWYgfSkgYm9keUNvbnRhaW5lcjogVmlld0NvbnRhaW5lclJlZjtcbiAgQFZpZXdDaGlsZCgnYXV0b0ZvY3VzQnV0dG9uT2snLCB7IHJlYWQ6IEVsZW1lbnRSZWYgfSkgYXV0b0ZvY3VzQnV0dG9uT2s6IEVsZW1lbnRSZWY7IC8vIE9ubHkgYWltIHRvIGZvY3VzIHRoZSBvayBidXR0b24gdGhhdCBuZWVkcyB0byBiZSBhdXRvIGZvY3VzZWRcblxuICBnZXQgYWZ0ZXJPcGVuKCk6IE9ic2VydmFibGU8dm9pZD4ge1xuICAgIC8vIE9ic2VydmFibGUgYWxpYXMgZm9yIG56QWZ0ZXJPcGVuXG4gICAgcmV0dXJuIHRoaXMubnpBZnRlck9wZW4uYXNPYnNlcnZhYmxlKCk7XG4gIH1cblxuICBnZXQgYWZ0ZXJDbG9zZSgpOiBPYnNlcnZhYmxlPFI+IHtcbiAgICAvLyBPYnNlcnZhYmxlIGFsaWFzIGZvciBuekFmdGVyQ2xvc2VcbiAgICByZXR1cm4gdGhpcy5uekFmdGVyQ2xvc2UuYXNPYnNlcnZhYmxlKCk7XG4gIH1cblxuICBnZXQgY2FuY2VsVGV4dCgpOiBzdHJpbmcge1xuICAgIHJldHVybiB0aGlzLm56Q2FuY2VsVGV4dCB8fCB0aGlzLmxvY2FsZS5jYW5jZWxUZXh0ITtcbiAgfVxuXG4gIGdldCBva1RleHQoKTogc3RyaW5nIHtcbiAgICByZXR1cm4gdGhpcy5uek9rVGV4dCB8fCB0aGlzLmxvY2FsZS5va1RleHQhO1xuICB9XG5cbiAgZ2V0IGhpZGRlbigpOiBib29sZWFuIHtcbiAgICByZXR1cm4gIXRoaXMubnpWaXNpYmxlICYmICF0aGlzLmFuaW1hdGlvblN0YXRlO1xuICB9IC8vIEluZGljYXRlIHdoZXRoZXIgdGhpcyBkaWFsb2cgc2hvdWxkIGhpZGRlblxuXG4gIC8qKlxuICAgKiBAZGVzY3JpcHRpb25cbiAgICogVGhlIGNhbGN1bGF0ZWQgaGlnaGVzdCB3ZWlnaHQgb2YgbWFzayB2YWx1ZVxuICAgKlxuICAgKiBXZWlnaHQgb2YgZGlmZmVyZW50IG1hc2sgaW5wdXQ6XG4gICAqIGNvbXBvbmVudCBkZWZhdWx0IHZhbHVlIDwgZ2xvYmFsIGNvbmZpZ3VyYXRpb24gPCBjb21wb25lbnQgaW5wdXQgdmFsdWVcbiAgICovXG4gIGdldCBtYXNrKCk6IGJvb2xlYW4ge1xuICAgIGlmICh0aGlzLm56TWFzayAhPSBudWxsKSB7XG4gICAgICByZXR1cm4gdGhpcy5uek1hc2s7XG4gICAgfSBlbHNlIGlmICh0aGlzLm56TW9kYWxHbG9iYWxDb25maWcgJiYgdGhpcy5uek1vZGFsR2xvYmFsQ29uZmlnLm56TWFzayAhPSBudWxsKSB7XG4gICAgICByZXR1cm4gdGhpcy5uek1vZGFsR2xvYmFsQ29uZmlnLm56TWFzaztcbiAgICB9IGVsc2Uge1xuICAgICAgcmV0dXJuIHRydWU7XG4gICAgfVxuICB9XG5cbiAgLyoqXG4gICAqIEBkZXNjcmlwdGlvblxuICAgKiBUaGUgY2FsY3VsYXRlZCBoaWdoZXN0IHdlaWdodCBvZiBtYXNrQ2xvc2FibGUgdmFsdWVcbiAgICpcbiAgICogV2VpZ2h0IG9mIGRpZmZlcmVudCBtYXNrQ2xvc2FibGUgaW5wdXQ6XG4gICAqIGNvbXBvbmVudCBkZWZhdWx0IHZhbHVlIDwgZ2xvYmFsIGNvbmZpZ3VyYXRpb24gPCBjb21wb25lbnQgaW5wdXQgdmFsdWVcbiAgICovXG4gIGdldCBtYXNrQ2xvc2FibGUoKTogYm9vbGVhbiB7XG4gICAgaWYgKHRoaXMubnpNYXNrQ2xvc2FibGUgIT0gbnVsbCkge1xuICAgICAgcmV0dXJuIHRoaXMubnpNYXNrQ2xvc2FibGU7XG4gICAgfSBlbHNlIGlmICh0aGlzLm56TW9kYWxHbG9iYWxDb25maWcgJiYgdGhpcy5uek1vZGFsR2xvYmFsQ29uZmlnLm56TWFza0Nsb3NhYmxlICE9IG51bGwpIHtcbiAgICAgIHJldHVybiB0aGlzLm56TW9kYWxHbG9iYWxDb25maWcubnpNYXNrQ2xvc2FibGU7XG4gICAgfSBlbHNlIHtcbiAgICAgIHJldHVybiB0cnVlO1xuICAgIH1cbiAgfVxuXG4gIGxvY2FsZTogeyBva1RleHQ/OiBzdHJpbmc7IGNhbmNlbFRleHQ/OiBzdHJpbmcgfSA9IHt9O1xuICBtYXNrQW5pbWF0aW9uQ2xhc3NNYXA6IG9iamVjdCB8IG51bGw7XG4gIG1vZGFsQW5pbWF0aW9uQ2xhc3NNYXA6IG9iamVjdCB8IG51bGw7XG4gIHRyYW5zZm9ybU9yaWdpbiA9ICcwcHggMHB4IDBweCc7IC8vIFRoZSBvcmlnaW4gcG9pbnQgdGhhdCBhbmltYXRpb24gYmFzZWQgb25cblxuICBwcml2YXRlIGNvbnRlbnRDb21wb25lbnRSZWY6IENvbXBvbmVudFJlZjxUPjsgLy8gSGFuZGxlIHRoZSByZWZlcmVuY2Ugd2hlbiB1c2luZyBuekNvbnRlbnQgYXMgQ29tcG9uZW50XG4gIHByaXZhdGUgYW5pbWF0aW9uU3RhdGU6IEFuaW1hdGlvblN0YXRlOyAvLyBDdXJyZW50IGFuaW1hdGlvbiBzdGF0ZVxuICBwcml2YXRlIGNvbnRhaW5lcjogSFRNTEVsZW1lbnQgfCBPdmVybGF5UmVmO1xuICBwcml2YXRlIHVuc3Vic2NyaWJlJCA9IG5ldyBTdWJqZWN0PHZvaWQ+KCk7XG4gIHByaXZhdGUgcHJldmlvdXNseUZvY3VzZWRFbGVtZW50OiBIVE1MRWxlbWVudDtcbiAgcHJpdmF0ZSBmb2N1c1RyYXA6IEZvY3VzVHJhcDtcbiAgcHJpdmF0ZSBzY3JvbGxTdHJhdGVneTogQmxvY2tTY3JvbGxTdHJhdGVneTtcbiAgcHJpdmF0ZSBvdmVybGF5UmVmOiBPdmVybGF5UmVmO1xuICBwcml2YXRlIGRpYWxvZ01vdXNlRG93biA9IGZhbHNlO1xuICBwcml2YXRlIHRpbWVvdXRJZDogbnVtYmVyO1xuXG4gIFtrZXk6IHN0cmluZ106IGFueTsgLy8gdHNsaW50OmRpc2FibGUtbGluZTpuby1hbnlcblxuICBjb25zdHJ1Y3RvcihcbiAgICBwcml2YXRlIG92ZXJsYXk6IE92ZXJsYXksXG4gICAgcHJpdmF0ZSBvdmVybGF5S2V5Ym9hcmREaXNwYXRjaGVyOiBPdmVybGF5S2V5Ym9hcmREaXNwYXRjaGVyLFxuICAgIHByaXZhdGUgaTE4bjogTnpJMThuU2VydmljZSxcbiAgICBwcml2YXRlIGNmcjogQ29tcG9uZW50RmFjdG9yeVJlc29sdmVyLFxuICAgIHByaXZhdGUgZWxlbWVudFJlZjogRWxlbWVudFJlZixcbiAgICBwcml2YXRlIHZpZXdDb250YWluZXI6IFZpZXdDb250YWluZXJSZWYsXG4gICAgcHJpdmF0ZSBtb2RhbENvbnRyb2w6IE56TW9kYWxDb250cm9sU2VydmljZSxcbiAgICBwcml2YXRlIGZvY3VzVHJhcEZhY3Rvcnk6IEZvY3VzVHJhcEZhY3RvcnksXG4gICAgcHJpdmF0ZSBjZHI6IENoYW5nZURldGVjdG9yUmVmLFxuICAgIEBPcHRpb25hbCgpIEBJbmplY3QoTlpfTU9EQUxfQ09ORklHKSBwcml2YXRlIG56TW9kYWxHbG9iYWxDb25maWc6IE56TW9kYWxDb25maWcsXG4gICAgQEluamVjdChET0NVTUVOVCkgcHJpdmF0ZSBkb2N1bWVudDogYW55IC8vIHRzbGludDpkaXNhYmxlLWxpbmU6bm8tYW55XG4gICkge1xuICAgIHN1cGVyKCk7XG4gICAgdGhpcy5zY3JvbGxTdHJhdGVneSA9IHRoaXMub3ZlcmxheS5zY3JvbGxTdHJhdGVnaWVzLmJsb2NrKCk7XG4gIH1cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICB0aGlzLmkxOG4ubG9jYWxlQ2hhbmdlLnBpcGUodGFrZVVudGlsKHRoaXMudW5zdWJzY3JpYmUkKSkuc3Vic2NyaWJlKCgpID0+IHtcbiAgICAgIHRoaXMubG9jYWxlID0gdGhpcy5pMThuLmdldExvY2FsZURhdGEoJ01vZGFsJykgYXMgeyBva1RleHQ6IHN0cmluZzsgY2FuY2VsVGV4dDogc3RyaW5nIH07XG4gICAgfSk7XG5cbiAgICBpZiAodGhpcy5pc0NvbXBvbmVudCh0aGlzLm56Q29udGVudCkpIHtcbiAgICAgIHRoaXMuY3JlYXRlRHluYW1pY0NvbXBvbmVudCh0aGlzLm56Q29udGVudCBhcyBUeXBlPFQ+KTsgLy8gQ3JlYXRlIGNvbXBvbmVudCBhbG9uZyB3aXRob3V0IFZpZXdcbiAgICB9XG5cbiAgICBpZiAodGhpcy5pc01vZGFsQnV0dG9ucyh0aGlzLm56Rm9vdGVyKSkge1xuICAgICAgLy8gU2V0dXAgZGVmYXVsdCBidXR0b24gb3B0aW9uc1xuICAgICAgdGhpcy5uekZvb3RlciA9IHRoaXMuZm9ybWF0TW9kYWxCdXR0b25zKHRoaXMubnpGb290ZXIgYXMgQXJyYXk8TW9kYWxCdXR0b25PcHRpb25zPFQ+Pik7XG4gICAgfVxuXG4gICAgLy8gUGxhY2UgdGhlIG1vZGFsIGRvbSB0byBlbHNld2hlcmVcbiAgICB0aGlzLmNvbnRhaW5lciA9IHR5cGVvZiB0aGlzLm56R2V0Q29udGFpbmVyID09PSAnZnVuY3Rpb24nID8gdGhpcy5uekdldENvbnRhaW5lcigpIDogdGhpcy5uekdldENvbnRhaW5lcjtcbiAgICBpZiAodGhpcy5jb250YWluZXIgaW5zdGFuY2VvZiBIVE1MRWxlbWVudCkge1xuICAgICAgdGhpcy5jb250YWluZXIuYXBwZW5kQ2hpbGQodGhpcy5lbGVtZW50UmVmLm5hdGl2ZUVsZW1lbnQpO1xuICAgICAgZnJvbUV2ZW50PEtleWJvYXJkRXZlbnQ+KHRoaXMuZG9jdW1lbnQuYm9keSwgJ2tleWRvd24nKVxuICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy51bnN1YnNjcmliZSQpKVxuICAgICAgICAuc3Vic2NyaWJlKGUgPT4gdGhpcy5rZXlkb3duTGlzdGVuZXIoZSkpO1xuICAgIH0gZWxzZSBpZiAodGhpcy5jb250YWluZXIgaW5zdGFuY2VvZiBPdmVybGF5UmVmKSB7XG4gICAgICAvLyBOT1RFOiBvbmx5IGF0dGFjaCB0aGUgZG9tIHRvIG92ZXJsYXksIHRoZSB2aWV3IGNvbnRhaW5lciBpcyBub3QgY2hhbmdlZCBhY3R1YWxseVxuICAgICAgdGhpcy5zZXRPdmVybGF5UmVmKHRoaXMuY29udGFpbmVyKTtcbiAgICAgIHRoaXMuY29udGFpbmVyLm92ZXJsYXlFbGVtZW50LmFwcGVuZENoaWxkKHRoaXMuZWxlbWVudFJlZi5uYXRpdmVFbGVtZW50KTtcbiAgICB9XG5cbiAgICBpZiAodGhpcy5vdmVybGF5UmVmKSB7XG4gICAgICB0aGlzLm92ZXJsYXlSZWZcbiAgICAgICAgLmtleWRvd25FdmVudHMoKVxuICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy51bnN1YnNjcmliZSQpKVxuICAgICAgICAuc3Vic2NyaWJlKGUgPT4gdGhpcy5rZXlkb3duTGlzdGVuZXIoZSkpO1xuICAgIH1cblxuICAgIC8vIFJlZ2lzdGVyIG1vZGFsIHdoZW4gYWZ0ZXJPcGVuL2FmdGVyQ2xvc2UgaXMgc3RhYmxlXG4gICAgdGhpcy5tb2RhbENvbnRyb2wucmVnaXN0ZXJNb2RhbCh0aGlzKTtcbiAgfVxuXG4gIC8vIFtOT1RFXSBOT1QgYXZhaWxhYmxlIHdoZW4gdXNpbmcgYnkgc2VydmljZSFcbiAgLy8gQmVjYXVzZSBuZ09uQ2hhbmdlcyBuZXZlciBiZSBjYWxsZWQgd2hlbiB1c2luZyBieSBzZXJ2aWNlLFxuICAvLyBoZXJlIHdlIGNhbid0IHN1cHBvcnQgXCJuekNvbnRlbnRcIihDb21wb25lbnQpIGV0Yy4gYXMgaW5wdXRzIHRoYXQgaW5pdGlhbGl6ZWQgZHluYW1pY2FsbHkuXG4gIC8vIEJVVDogVXNlciBhbHNvIGNhbiBjaGFuZ2UgXCJuekNvbnRlbnRcIiBkeW5hbWljYWxseSB0byB0cmlnZ2VyIFVJIGNoYW5nZXMgKHByb3ZpZGVkIHlvdSBkb24ndCB1c2UgXGJDb21wb25lbnQgdGhhdCBuZWVkcyBpbml0aWFsaXphdGlvbnMpXG4gIG5nT25DaGFuZ2VzKGNoYW5nZXM6IFNpbXBsZUNoYW5nZXMpOiB2b2lkIHtcbiAgICBpZiAoY2hhbmdlcy5uelZpc2libGUpIHtcbiAgICAgIHRoaXMuaGFuZGxlVmlzaWJsZVN0YXRlQ2hhbmdlKHRoaXMubnpWaXNpYmxlLCAhY2hhbmdlcy5uelZpc2libGUuZmlyc3RDaGFuZ2UpOyAvLyBEbyBub3QgdHJpZ2dlciBhbmltYXRpb24gd2hpbGUgaW5pdGlhbGl6aW5nXG4gICAgfVxuICB9XG5cbiAgbmdBZnRlclZpZXdJbml0KCk6IHZvaWQge1xuICAgIC8vIElmIHVzaW5nIENvbXBvbmVudCwgaXQgaXMgdGhlIHRpbWUgdG8gYXR0YWNoIFZpZXcgd2hpbGUgYm9keUNvbnRhaW5lciBpcyByZWFkeVxuICAgIGlmICh0aGlzLmNvbnRlbnRDb21wb25lbnRSZWYpIHtcbiAgICAgIHRoaXMuYm9keUNvbnRhaW5lci5pbnNlcnQodGhpcy5jb250ZW50Q29tcG9uZW50UmVmLmhvc3RWaWV3KTtcbiAgICB9XG5cbiAgICBpZiAodGhpcy5hdXRvRm9jdXNCdXR0b25Paykge1xuICAgICAgKHRoaXMuYXV0b0ZvY3VzQnV0dG9uT2submF0aXZlRWxlbWVudCBhcyBIVE1MQnV0dG9uRWxlbWVudCkuZm9jdXMoKTtcbiAgICB9XG4gIH1cblxuICBuZ09uRGVzdHJveSgpOiB2b2lkIHtcbiAgICAvLyBDbG9zZSBzZWxmIGJlZm9yZSBkZXN0cnVjdGluZ1xuICAgIHRoaXMuY2hhbmdlVmlzaWJsZUZyb21JbnNpZGUoZmFsc2UpLnRoZW4oKCkgPT4ge1xuICAgICAgdGhpcy5tb2RhbENvbnRyb2wuZGVyZWdpc3Rlck1vZGFsKHRoaXMpO1xuXG4gICAgICBpZiAodGhpcy5jb250YWluZXIgaW5zdGFuY2VvZiBPdmVybGF5UmVmKSB7XG4gICAgICAgIHRoaXMuY29udGFpbmVyLmRpc3Bvc2UoKTtcbiAgICAgIH1cblxuICAgICAgdGhpcy51bnN1YnNjcmliZSQubmV4dCgpO1xuICAgICAgdGhpcy51bnN1YnNjcmliZSQuY29tcGxldGUoKTtcbiAgICB9KTtcbiAgICBjbGVhclRpbWVvdXQodGhpcy50aW1lb3V0SWQpO1xuICB9XG5cbiAgc2V0T3ZlcmxheVJlZihvdmVybGF5UmVmOiBPdmVybGF5UmVmKTogdm9pZCB7XG4gICAgdGhpcy5vdmVybGF5UmVmID0gb3ZlcmxheVJlZjtcbiAgfVxuXG4gIGtleWRvd25MaXN0ZW5lcihldmVudDogS2V5Ym9hcmRFdmVudCk6IHZvaWQge1xuICAgIGlmIChldmVudC5rZXlDb2RlID09PSBFU0NBUEUgJiYgdGhpcy5uektleWJvYXJkKSB7XG4gICAgICB0aGlzLm9uQ2xpY2tPa0NhbmNlbCgnY2FuY2VsJyk7XG4gICAgfVxuICB9XG5cbiAgb3BlbigpOiB2b2lkIHtcbiAgICB0aGlzLmNoYW5nZVZpc2libGVGcm9tSW5zaWRlKHRydWUpO1xuICB9XG5cbiAgY2xvc2UocmVzdWx0PzogUik6IHZvaWQge1xuICAgIHRoaXMuY2hhbmdlVmlzaWJsZUZyb21JbnNpZGUoZmFsc2UsIHJlc3VsdCk7XG4gIH1cblxuICBkZXN0cm95KHJlc3VsdD86IFIpOiB2b2lkIHtcbiAgICAvLyBEZXN0cm95IGVxdWFscyBDbG9zZVxuICAgIHRoaXMuY2xvc2UocmVzdWx0KTtcbiAgfVxuXG4gIHRyaWdnZXJPaygpOiB2b2lkIHtcbiAgICB0aGlzLm9uQ2xpY2tPa0NhbmNlbCgnb2snKTtcbiAgfVxuXG4gIHRyaWdnZXJDYW5jZWwoKTogdm9pZCB7XG4gICAgdGhpcy5vbkNsaWNrT2tDYW5jZWwoJ2NhbmNlbCcpO1xuICB9XG5cbiAgZ2V0SW5zdGFuY2UoKTogTnpNb2RhbENvbXBvbmVudCB7XG4gICAgcmV0dXJuIHRoaXM7XG4gIH1cblxuICBnZXRDb250ZW50Q29tcG9uZW50UmVmKCk6IENvbXBvbmVudFJlZjxUPiB7XG4gICAgcmV0dXJuIHRoaXMuY29udGVudENvbXBvbmVudFJlZjtcbiAgfVxuXG4gIGdldENvbnRlbnRDb21wb25lbnQoKTogVCB7XG4gICAgcmV0dXJuIHRoaXMuY29udGVudENvbXBvbmVudFJlZiAmJiB0aGlzLmNvbnRlbnRDb21wb25lbnRSZWYuaW5zdGFuY2U7XG4gIH1cblxuICBnZXRFbGVtZW50KCk6IEhUTUxFbGVtZW50IHtcbiAgICByZXR1cm4gdGhpcy5lbGVtZW50UmVmICYmIHRoaXMuZWxlbWVudFJlZi5uYXRpdmVFbGVtZW50O1xuICB9XG5cbiAgb25NYXNrRGlhbG9nRG93bigpOiB2b2lkIHtcbiAgICB0aGlzLmRpYWxvZ01vdXNlRG93biA9IHRydWU7XG4gIH1cblxuICBvbkRpYWxvZ1VwKCk6IHZvaWQge1xuICAgIGlmICh0aGlzLmRpYWxvZ01vdXNlRG93bikge1xuICAgICAgdGhpcy50aW1lb3V0SWQgPSBzZXRUaW1lb3V0KCgpID0+IHtcbiAgICAgICAgdGhpcy5kaWFsb2dNb3VzZURvd24gPSBmYWxzZTtcbiAgICAgIH0sIDApO1xuICAgIH1cbiAgfVxuXG4gIG9uQ2xpY2tNYXNrKCRldmVudDogTW91c2VFdmVudCk6IHZvaWQge1xuICAgIGlmIChcbiAgICAgIHRoaXMubWFzayAmJlxuICAgICAgdGhpcy5tYXNrQ2xvc2FibGUgJiZcbiAgICAgICgkZXZlbnQudGFyZ2V0IGFzIEhUTUxFbGVtZW50KS5jbGFzc0xpc3QuY29udGFpbnMoV1JBUF9DTEFTU19OQU1FKSAmJlxuICAgICAgdGhpcy5uelZpc2libGUgJiZcbiAgICAgICF0aGlzLmRpYWxvZ01vdXNlRG93blxuICAgICkge1xuICAgICAgdGhpcy5vbkNsaWNrT2tDYW5jZWwoJ2NhbmNlbCcpO1xuICAgIH1cbiAgfVxuXG4gIGlzTW9kYWxUeXBlKHR5cGU6IE1vZGFsVHlwZSk6IGJvb2xlYW4ge1xuICAgIHJldHVybiB0aGlzLm56TW9kYWxUeXBlID09PSB0eXBlO1xuICB9XG5cbiAgcHVibGljIG9uQ2xpY2tDbG9zZUJ0bigpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5uelZpc2libGUpIHtcbiAgICAgIHRoaXMub25DbGlja09rQ2FuY2VsKCdjYW5jZWwnKTtcbiAgICB9XG4gIH1cblxuICBwdWJsaWMgb25DbGlja09rQ2FuY2VsKHR5cGU6ICdvaycgfCAnY2FuY2VsJyk6IHZvaWQge1xuICAgIGNvbnN0IHRyaWdnZXIgPSB7IG9rOiB0aGlzLm56T25PaywgY2FuY2VsOiB0aGlzLm56T25DYW5jZWwgfVt0eXBlXTtcbiAgICBjb25zdCBsb2FkaW5nS2V5ID0geyBvazogJ256T2tMb2FkaW5nJywgY2FuY2VsOiAnbnpDYW5jZWxMb2FkaW5nJyB9W3R5cGVdO1xuICAgIGlmICh0cmlnZ2VyIGluc3RhbmNlb2YgRXZlbnRFbWl0dGVyKSB7XG4gICAgICB0cmlnZ2VyLmVtaXQodGhpcy5nZXRDb250ZW50Q29tcG9uZW50KCkpO1xuICAgIH0gZWxzZSBpZiAodHlwZW9mIHRyaWdnZXIgPT09ICdmdW5jdGlvbicpIHtcbiAgICAgIGNvbnN0IHJlc3VsdCA9IHRyaWdnZXIodGhpcy5nZXRDb250ZW50Q29tcG9uZW50KCkpO1xuICAgICAgY29uc3QgY2FzZUNsb3NlID0gKGRvQ2xvc2U6IGJvb2xlYW4gfCB2b2lkIHwge30pID0+IGRvQ2xvc2UgIT09IGZhbHNlICYmIHRoaXMuY2xvc2UoZG9DbG9zZSBhcyBSKTsgLy8gVXNlcnMgY2FuIHJldHVybiBcImZhbHNlXCIgdG8gcHJldmVudCBjbG9zaW5nIGJ5IGRlZmF1bHRcbiAgICAgIGlmIChpc1Byb21pc2UocmVzdWx0KSkge1xuICAgICAgICB0aGlzW2xvYWRpbmdLZXldID0gdHJ1ZTtcbiAgICAgICAgY29uc3QgaGFuZGxlVGhlbiA9IChkb0Nsb3NlOiBib29sZWFuIHwgdm9pZCB8IHt9KSA9PiB7XG4gICAgICAgICAgdGhpc1tsb2FkaW5nS2V5XSA9IGZhbHNlO1xuICAgICAgICAgIGNhc2VDbG9zZShkb0Nsb3NlKTtcbiAgICAgICAgfTtcbiAgICAgICAgKHJlc3VsdCBhcyBQcm9taXNlPHZvaWQ+KS50aGVuKGhhbmRsZVRoZW4pLmNhdGNoKGhhbmRsZVRoZW4pO1xuICAgICAgfSBlbHNlIHtcbiAgICAgICAgY2FzZUNsb3NlKHJlc3VsdCk7XG4gICAgICB9XG4gICAgfVxuICB9XG5cbiAgcHVibGljIGlzTm9uRW1wdHlTdHJpbmcodmFsdWU6IHt9KTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHR5cGVvZiB2YWx1ZSA9PT0gJ3N0cmluZycgJiYgdmFsdWUgIT09ICcnO1xuICB9XG5cbiAgcHVibGljIGlzVGVtcGxhdGVSZWYodmFsdWU6IHt9KTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHZhbHVlIGluc3RhbmNlb2YgVGVtcGxhdGVSZWY7XG4gIH1cblxuICBwdWJsaWMgaXNDb21wb25lbnQodmFsdWU6IHt9KTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHZhbHVlIGluc3RhbmNlb2YgVHlwZTtcbiAgfVxuXG4gIHB1YmxpYyBpc01vZGFsQnV0dG9ucyh2YWx1ZTogc3RyaW5nIHwgVGVtcGxhdGVSZWY8e30+IHwgQXJyYXk8TW9kYWxCdXR0b25PcHRpb25zPFQ+PiB8IG51bGwpOiBib29sZWFuIHtcbiAgICByZXR1cm4gQXJyYXkuaXNBcnJheSh2YWx1ZSkgJiYgdmFsdWUubGVuZ3RoID4gMDtcbiAgfVxuXG4gIC8vIERvIHJlc3QgdGhpbmdzIHdoZW4gdmlzaWJsZSBzdGF0ZSBjaGFuZ2VkXG4gIHByaXZhdGUgaGFuZGxlVmlzaWJsZVN0YXRlQ2hhbmdlKHZpc2libGU6IGJvb2xlYW4sIGFuaW1hdGlvbjogYm9vbGVhbiA9IHRydWUsIGNsb3NlUmVzdWx0PzogUik6IFByb21pc2U8dm9pZD4ge1xuICAgIGlmICh2aXNpYmxlKSB7XG4gICAgICAvLyBIaWRlIHNjcm9sbGJhciBhdCB0aGUgZmlyc3QgdGltZSB3aGVuIHNob3duIHVwXG4gICAgICB0aGlzLnNjcm9sbFN0cmF0ZWd5LmVuYWJsZSgpO1xuICAgICAgdGhpcy5zYXZlUHJldmlvdXNseUZvY3VzZWRFbGVtZW50KCk7XG4gICAgICB0aGlzLnRyYXBGb2N1cygpO1xuICAgICAgaWYgKHRoaXMuY29udGFpbmVyIGluc3RhbmNlb2YgT3ZlcmxheVJlZikge1xuICAgICAgICB0aGlzLm92ZXJsYXlLZXlib2FyZERpc3BhdGNoZXIuYWRkKHRoaXMub3ZlcmxheVJlZik7XG4gICAgICB9XG4gICAgfSBlbHNlIHtcbiAgICAgIGlmICh0aGlzLmNvbnRhaW5lciBpbnN0YW5jZW9mIE92ZXJsYXlSZWYpIHtcbiAgICAgICAgdGhpcy5vdmVybGF5S2V5Ym9hcmREaXNwYXRjaGVyLnJlbW92ZSh0aGlzLm92ZXJsYXlSZWYpO1xuICAgICAgfVxuICAgIH1cblxuICAgIHJldHVybiBQcm9taXNlLnJlc29sdmUoYW5pbWF0aW9uID8gdGhpcy5hbmltYXRlVG8odmlzaWJsZSkgOiB1bmRlZmluZWQpLnRoZW4oKCkgPT4ge1xuICAgICAgLy8gRW1pdCBvcGVuL2Nsb3NlIGV2ZW50IGFmdGVyIGFuaW1hdGlvbnMgb3ZlclxuICAgICAgaWYgKHZpc2libGUpIHtcbiAgICAgICAgdGhpcy5uekFmdGVyT3Blbi5lbWl0KCk7XG4gICAgICB9IGVsc2Uge1xuICAgICAgICB0aGlzLm56QWZ0ZXJDbG9zZS5lbWl0KGNsb3NlUmVzdWx0KTtcbiAgICAgICAgdGhpcy5yZXN0b3JlRm9jdXMoKTtcbiAgICAgICAgdGhpcy5zY3JvbGxTdHJhdGVneS5kaXNhYmxlKCk7XG4gICAgICAgIC8vIE1hcmsgdGhlIGZvciBjaGVjayBzbyBpdCBjYW4gcmVhY3QgaWYgdGhlIHZpZXcgY29udGFpbmVyIGlzIHVzaW5nIE9uUHVzaCBjaGFuZ2UgZGV0ZWN0aW9uLlxuICAgICAgICB0aGlzLmNkci5tYXJrRm9yQ2hlY2soKTtcbiAgICAgIH1cbiAgICB9KTtcbiAgfVxuXG4gIC8vIExvb2t1cCBhIGJ1dHRvbidzIHByb3BlcnR5LCBpZiB0aGUgcHJvcCBpcyBhIGZ1bmN0aW9uLCBjYWxsICYgdGhlbiByZXR1cm4gdGhlIHJlc3VsdCwgb3RoZXJ3aXNlLCByZXR1cm4gaXRzZWxmLlxuICBwdWJsaWMgZ2V0QnV0dG9uQ2FsbGFibGVQcm9wKG9wdGlvbnM6IE1vZGFsQnV0dG9uT3B0aW9uczxUPiwgcHJvcDogc3RyaW5nKToge30ge1xuICAgIGNvbnN0IHZhbHVlID0gb3B0aW9uc1twcm9wXTtcbiAgICBjb25zdCBhcmdzOiBUW10gPSBbXTtcbiAgICBpZiAodGhpcy5jb250ZW50Q29tcG9uZW50UmVmKSB7XG4gICAgICBhcmdzLnB1c2godGhpcy5jb250ZW50Q29tcG9uZW50UmVmLmluc3RhbmNlKTtcbiAgICB9XG4gICAgcmV0dXJuIHR5cGVvZiB2YWx1ZSA9PT0gJ2Z1bmN0aW9uJyA/IHZhbHVlLmFwcGx5KG9wdGlvbnMsIGFyZ3MpIDogdmFsdWU7XG4gIH1cblxuICAvLyBPbiBuekZvb3RlcidzIG1vZGFsIGJ1dHRvbiBjbGlja1xuICBwdWJsaWMgb25CdXR0b25DbGljayhidXR0b246IE1vZGFsQnV0dG9uT3B0aW9uczxUPik6IHZvaWQge1xuICAgIGNvbnN0IHJlc3VsdCA9IHRoaXMuZ2V0QnV0dG9uQ2FsbGFibGVQcm9wKGJ1dHRvbiwgJ29uQ2xpY2snKTsgLy8gQ2FsbCBvbkNsaWNrIGRpcmVjdGx5XG4gICAgaWYgKGlzUHJvbWlzZShyZXN1bHQpKSB7XG4gICAgICBidXR0b24ubG9hZGluZyA9IHRydWU7XG4gICAgICAocmVzdWx0IGFzIFByb21pc2U8e30+KS50aGVuKCgpID0+IChidXR0b24ubG9hZGluZyA9IGZhbHNlKSkuY2F0Y2goKCkgPT4gKGJ1dHRvbi5sb2FkaW5nID0gZmFsc2UpKTtcbiAgICB9XG4gIH1cblxuICAvLyBDaGFuZ2UgbnpWaXNpYmxlIGZyb20gaW5zaWRlXG4gIHByaXZhdGUgY2hhbmdlVmlzaWJsZUZyb21JbnNpZGUodmlzaWJsZTogYm9vbGVhbiwgY2xvc2VSZXN1bHQ/OiBSKTogUHJvbWlzZTx2b2lkPiB7XG4gICAgaWYgKHRoaXMubnpWaXNpYmxlICE9PSB2aXNpYmxlKSB7XG4gICAgICAvLyBDaGFuZ2UgbnpWaXNpYmxlIHZhbHVlIGltbWVkaWF0ZWx5XG4gICAgICB0aGlzLm56VmlzaWJsZSA9IHZpc2libGU7XG4gICAgICB0aGlzLm56VmlzaWJsZUNoYW5nZS5lbWl0KHZpc2libGUpO1xuICAgICAgcmV0dXJuIHRoaXMuaGFuZGxlVmlzaWJsZVN0YXRlQ2hhbmdlKHZpc2libGUsIHRydWUsIGNsb3NlUmVzdWx0KTtcbiAgICB9XG4gICAgcmV0dXJuIFByb21pc2UucmVzb2x2ZSgpO1xuICB9XG5cbiAgcHJpdmF0ZSBjaGFuZ2VBbmltYXRpb25TdGF0ZShzdGF0ZTogQW5pbWF0aW9uU3RhdGUpOiB2b2lkIHtcbiAgICB0aGlzLmFuaW1hdGlvblN0YXRlID0gc3RhdGU7XG4gICAgaWYgKHN0YXRlKSB7XG4gICAgICB0aGlzLm1hc2tBbmltYXRpb25DbGFzc01hcCA9IHtcbiAgICAgICAgW2BmYWRlLSR7c3RhdGV9YF06IHRydWUsXG4gICAgICAgIFtgZmFkZS0ke3N0YXRlfS1hY3RpdmVgXTogdHJ1ZVxuICAgICAgfTtcbiAgICAgIHRoaXMubW9kYWxBbmltYXRpb25DbGFzc01hcCA9IHtcbiAgICAgICAgW2B6b29tLSR7c3RhdGV9YF06IHRydWUsXG4gICAgICAgIFtgem9vbS0ke3N0YXRlfS1hY3RpdmVgXTogdHJ1ZVxuICAgICAgfTtcbiAgICB9IGVsc2Uge1xuICAgICAgdGhpcy5tYXNrQW5pbWF0aW9uQ2xhc3NNYXAgPSB0aGlzLm1vZGFsQW5pbWF0aW9uQ2xhc3NNYXAgPSBudWxsO1xuICAgIH1cbiAgfVxuXG4gIHByaXZhdGUgYW5pbWF0ZVRvKGlzVmlzaWJsZTogYm9vbGVhbik6IFByb21pc2U8dm9pZD4ge1xuICAgIGlmIChpc1Zpc2libGUpIHtcbiAgICAgIC8vIEZpZ3VyZSBvdXQgdGhlIGxhc3Rlc3QgY2xpY2sgcG9zaXRpb24gd2hlbiBzaG93cyB1cFxuICAgICAgc2V0VGltZW91dCgoKSA9PiB0aGlzLnVwZGF0ZVRyYW5zZm9ybU9yaWdpbigpKTsgLy8gW05PVEVdIFVzaW5nIHRpbWVvdXQgZHVlIHRvIHRoZSBkb2N1bWVudC5jbGljayBldmVudCBpcyBmaXJlZCBsYXRlciB0aGFuIHZpc2libGUgY2hhbmdlLCBzbyBpZiBub3QgcG9zdHBvbmVkIHRvIG5leHQgZXZlbnQtbG9vcCwgd2UgY2FuJ3QgZ2V0IHRoZSBsYXN0ZXN0IGNsaWNrIHBvc2l0aW9uXG4gICAgfVxuXG4gICAgdGhpcy5jaGFuZ2VBbmltYXRpb25TdGF0ZShpc1Zpc2libGUgPyAnZW50ZXInIDogJ2xlYXZlJyk7XG4gICAgcmV0dXJuIG5ldyBQcm9taXNlKHJlc29sdmUgPT5cbiAgICAgIHNldFRpbWVvdXQoXG4gICAgICAgICgpID0+IHtcbiAgICAgICAgICAvLyBSZXR1cm4gd2hlbiBhbmltYXRpb24gaXMgb3ZlclxuICAgICAgICAgIHRoaXMuY2hhbmdlQW5pbWF0aW9uU3RhdGUobnVsbCk7XG4gICAgICAgICAgcmVzb2x2ZSgpO1xuICAgICAgICB9LFxuICAgICAgICB0aGlzLm56Tm9BbmltYXRpb24gPyAwIDogTU9EQUxfQU5JTUFURV9EVVJBVElPTlxuICAgICAgKVxuICAgICk7XG4gIH1cblxuICBwcml2YXRlIGZvcm1hdE1vZGFsQnV0dG9ucyhidXR0b25zOiBBcnJheTxNb2RhbEJ1dHRvbk9wdGlvbnM8VD4+KTogQXJyYXk8TW9kYWxCdXR0b25PcHRpb25zPFQ+PiB7XG4gICAgcmV0dXJuIGJ1dHRvbnMubWFwKGJ1dHRvbiA9PiB7XG4gICAgICByZXR1cm4ge1xuICAgICAgICAuLi57XG4gICAgICAgICAgdHlwZTogJ2RlZmF1bHQnLFxuICAgICAgICAgIHNpemU6ICdkZWZhdWx0JyxcbiAgICAgICAgICBhdXRvTG9hZGluZzogdHJ1ZSxcbiAgICAgICAgICBzaG93OiB0cnVlLFxuICAgICAgICAgIGxvYWRpbmc6IGZhbHNlLFxuICAgICAgICAgIGRpc2FibGVkOiBmYWxzZVxuICAgICAgICB9LFxuICAgICAgICAuLi5idXR0b25cbiAgICAgIH07XG4gICAgfSk7XG4gIH1cblxuICAvKipcbiAgICogQ3JlYXRlIGEgY29tcG9uZW50IGR5bmFtaWNhbGx5IGJ1dCBub3QgYXR0YWNoIHRvIGFueSBWaWV3ICh0aGlzIGFjdGlvbiB3aWxsIGJlIGV4ZWN1dGVkIHdoZW4gYm9keUNvbnRhaW5lciBpcyByZWFkeSlcbiAgICogQHBhcmFtIGNvbXBvbmVudCBDb21wb25lbnQgY2xhc3NcbiAgICovXG4gIHByaXZhdGUgY3JlYXRlRHluYW1pY0NvbXBvbmVudChjb21wb25lbnQ6IFR5cGU8VD4pOiB2b2lkIHtcbiAgICBjb25zdCBmYWN0b3J5ID0gdGhpcy5jZnIucmVzb2x2ZUNvbXBvbmVudEZhY3RvcnkoY29tcG9uZW50KTtcbiAgICBjb25zdCBjaGlsZEluamVjdG9yID0gSW5qZWN0b3IuY3JlYXRlKHtcbiAgICAgIHByb3ZpZGVyczogW3sgcHJvdmlkZTogTnpNb2RhbFJlZiwgdXNlVmFsdWU6IHRoaXMgfV0sXG4gICAgICBwYXJlbnQ6IHRoaXMudmlld0NvbnRhaW5lci5wYXJlbnRJbmplY3RvclxuICAgIH0pO1xuICAgIHRoaXMuY29udGVudENvbXBvbmVudFJlZiA9IGZhY3RvcnkuY3JlYXRlKGNoaWxkSW5qZWN0b3IpO1xuICAgIGlmICh0aGlzLm56Q29tcG9uZW50UGFyYW1zKSB7XG4gICAgICBPYmplY3QuYXNzaWduKHRoaXMuY29udGVudENvbXBvbmVudFJlZi5pbnN0YW5jZSwgdGhpcy5uekNvbXBvbmVudFBhcmFtcyk7XG4gICAgfVxuICAgIC8vIERvIHRoZSBmaXJzdCBjaGFuZ2UgZGV0ZWN0aW9uIGltbWVkaWF0ZWx5IChvciB3ZSBkbyBkZXRlY3Rpb24gYXQgbmdBZnRlclZpZXdJbml0LCBtdWx0aS1jaGFuZ2VzIGVycm9yIHdpbGwgYmUgdGhyb3duKVxuICAgIHRoaXMuY29udGVudENvbXBvbmVudFJlZi5jaGFuZ2VEZXRlY3RvclJlZi5kZXRlY3RDaGFuZ2VzKCk7XG4gIH1cblxuICAvLyBVcGRhdGUgdHJhbnNmb3JtLW9yaWdpbiB0byB0aGUgbGFzdCBjbGljayBwb3NpdGlvbiBvbiBkb2N1bWVudFxuICBwcml2YXRlIHVwZGF0ZVRyYW5zZm9ybU9yaWdpbigpOiB2b2lkIHtcbiAgICBjb25zdCBtb2RhbEVsZW1lbnQgPSB0aGlzLm1vZGFsQ29udGFpbmVyLm5hdGl2ZUVsZW1lbnQgYXMgSFRNTEVsZW1lbnQ7XG4gICAgaWYgKHRoaXMucHJldmlvdXNseUZvY3VzZWRFbGVtZW50KSB7XG4gICAgICBjb25zdCBwcmV2aW91c2x5RE9NUmVjdCA9IHRoaXMucHJldmlvdXNseUZvY3VzZWRFbGVtZW50LmdldEJvdW5kaW5nQ2xpZW50UmVjdCgpO1xuICAgICAgY29uc3QgbGFzdFBvc2l0aW9uID0gZ2V0RWxlbWVudE9mZnNldCh0aGlzLnByZXZpb3VzbHlGb2N1c2VkRWxlbWVudCk7XG4gICAgICBjb25zdCB4ID0gbGFzdFBvc2l0aW9uLmxlZnQgKyBwcmV2aW91c2x5RE9NUmVjdC53aWR0aCAvIDI7XG4gICAgICBjb25zdCB5ID0gbGFzdFBvc2l0aW9uLnRvcCArIHByZXZpb3VzbHlET01SZWN0LmhlaWdodCAvIDI7XG4gICAgICB0aGlzLnRyYW5zZm9ybU9yaWdpbiA9IGAke3ggLSBtb2RhbEVsZW1lbnQub2Zmc2V0TGVmdH1weCAke3kgLSBtb2RhbEVsZW1lbnQub2Zmc2V0VG9wfXB4IDBweGA7XG4gICAgfVxuICB9XG5cbiAgcHJpdmF0ZSBzYXZlUHJldmlvdXNseUZvY3VzZWRFbGVtZW50KCk6IHZvaWQge1xuICAgIGlmICh0aGlzLmRvY3VtZW50KSB7XG4gICAgICB0aGlzLnByZXZpb3VzbHlGb2N1c2VkRWxlbWVudCA9IHRoaXMuZG9jdW1lbnQuYWN0aXZlRWxlbWVudCBhcyBIVE1MRWxlbWVudDtcbiAgICB9XG4gIH1cblxuICBwcml2YXRlIHRyYXBGb2N1cygpOiB2b2lkIHtcbiAgICBpZiAoIXRoaXMuZm9jdXNUcmFwKSB7XG4gICAgICB0aGlzLmZvY3VzVHJhcCA9IHRoaXMuZm9jdXNUcmFwRmFjdG9yeS5jcmVhdGUodGhpcy5lbGVtZW50UmVmLm5hdGl2ZUVsZW1lbnQpO1xuICAgIH1cbiAgICB0aGlzLmZvY3VzVHJhcC5mb2N1c0luaXRpYWxFbGVtZW50V2hlblJlYWR5KCk7XG4gIH1cblxuICBwcml2YXRlIHJlc3RvcmVGb2N1cygpOiB2b2lkIHtcbiAgICAvLyBXZSBuZWVkIHRoZSBleHRyYSBjaGVjaywgYmVjYXVzZSBJRSBjYW4gc2V0IHRoZSBgYWN0aXZlRWxlbWVudGAgdG8gbnVsbCBpbiBzb21lIGNhc2VzLlxuICAgIGlmICh0aGlzLnByZXZpb3VzbHlGb2N1c2VkRWxlbWVudCAmJiB0eXBlb2YgdGhpcy5wcmV2aW91c2x5Rm9jdXNlZEVsZW1lbnQuZm9jdXMgPT09ICdmdW5jdGlvbicpIHtcbiAgICAgIHRoaXMucHJldmlvdXNseUZvY3VzZWRFbGVtZW50LmZvY3VzKCk7XG4gICAgfVxuICAgIGlmICh0aGlzLmZvY3VzVHJhcCkge1xuICAgICAgdGhpcy5mb2N1c1RyYXAuZGVzdHJveSgpO1xuICAgIH1cbiAgfVxufVxuIl19