import { ComponentPortal } from '@angular/cdk/portal';
import { Subject, fromEvent, merge, combineLatest, EMPTY } from 'rxjs';
import { takeUntil, mapTo, tap, debounceTime, distinctUntilChanged, map, filter, take } from 'rxjs/operators';
import { __extends, __spread, __decorate, __metadata } from 'tslib';
import { CdkConnectedOverlay, ConnectionPositionPair, Overlay, OverlayConfig, OverlayModule } from '@angular/cdk/overlay';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzMenuBaseService, slideMotion, DEFAULT_DROPDOWN_POSITIONS, InputBoolean, NzDropdownHigherOrderServiceToken, NzNoAnimationDirective, POSITION_MAP, NzNoAnimationModule, NzOverlayModule } from 'ng-zorro-antd/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuDirective, NzMenuModule } from 'ng-zorro-antd/menu';
import { Injectable, ChangeDetectionStrategy, ChangeDetectorRef, Component, ViewEncapsulation, Directive, ElementRef, Renderer2, ContentChild, EventEmitter, Host, Injector, Input, Optional, Output, Self, ViewChild, NgModule } from '@angular/core';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var NzMenuDropdownService = /** @class */ (function (_super) {
    __extends(NzMenuDropdownService, _super);
    function NzMenuDropdownService() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.isInDropDown = true;
        return _this;
    }
    NzMenuDropdownService.decorators = [
        { type: Injectable }
    ];
    return NzMenuDropdownService;
}(NzMenuBaseService));

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var NzDropdownContextComponent = /** @class */ (function () {
    function NzDropdownContextComponent(cdr) {
        this.cdr = cdr;
        this.open = true;
        this.dropDownPosition = 'bottom';
        this.destroy$ = new Subject();
    }
    /**
     * @param {?} open
     * @param {?} templateRef
     * @param {?} positionChanges
     * @param {?} control
     * @return {?}
     */
    NzDropdownContextComponent.prototype.init = /**
     * @param {?} open
     * @param {?} templateRef
     * @param {?} positionChanges
     * @param {?} control
     * @return {?}
     */
    function (open, templateRef, positionChanges, control) {
        var _this = this;
        this.open = open;
        this.templateRef = templateRef;
        this.control = control;
        positionChanges.pipe(takeUntil(this.destroy$)).subscribe((/**
         * @param {?} data
         * @return {?}
         */
        function (data) {
            _this.dropDownPosition = data.connectionPair.overlayY === 'bottom' ? 'top' : 'bottom';
            _this.cdr.markForCheck();
        }));
    };
    /**
     * @return {?}
     */
    NzDropdownContextComponent.prototype.close = /**
     * @return {?}
     */
    function () {
        this.open = false;
        this.cdr.markForCheck();
    };
    /**
     * @return {?}
     */
    NzDropdownContextComponent.prototype.afterAnimation = /**
     * @return {?}
     */
    function () {
        if (!this.open) {
            this.control.dispose();
        }
    };
    // TODO auto set dropdown class after the bug resolved
    /** https://github.com/angular/angular/issues/14842 **/
    // TODO auto set dropdown class after the bug resolved
    /**
     * https://github.com/angular/angular/issues/14842 *
     * @return {?}
     */
    NzDropdownContextComponent.prototype.ngOnDestroy = 
    // TODO auto set dropdown class after the bug resolved
    /**
     * https://github.com/angular/angular/issues/14842 *
     * @return {?}
     */
    function () {
        this.destroy$.next();
        this.destroy$.complete();
    };
    NzDropdownContextComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-dropdown-context',
                    exportAs: 'nzDropdownContext',
                    animations: [slideMotion],
                    preserveWhitespaces: false,
                    template: "<div *ngIf=\"open\"\n  class=\"ant-dropdown ant-dropdown-placement-bottomLeft\"\n  [@slideMotion]=\"dropDownPosition\"\n  (@slideMotion.done)=\"afterAnimation()\">\n  <ng-template [ngTemplateOutlet]=\"templateRef\"></ng-template>\n</div>",
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    providers: [NzMenuDropdownService],
                    styles: ["\n      nz-dropdown-context {\n        display: block;\n      }\n\n      .ant-dropdown {\n        top: 100%;\n        left: 0;\n        position: relative;\n        width: 100%;\n        margin-top: 4px;\n        margin-bottom: 4px;\n      }\n    "]
                }] }
    ];
    /** @nocollapse */
    NzDropdownContextComponent.ctorParameters = function () { return [
        { type: ChangeDetectorRef }
    ]; };
    return NzDropdownContextComponent;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var NzDropDownDirective = /** @class */ (function () {
    function NzDropDownDirective(elementRef, renderer) {
        this.elementRef = elementRef;
        this.renderer = renderer;
        this.el = this.elementRef.nativeElement;
        this.hover$ = merge(fromEvent(this.el, 'mouseenter').pipe(mapTo(true)), fromEvent(this.el, 'mouseleave').pipe(mapTo(false)));
        this.$click = fromEvent(this.el, 'click').pipe(tap((/**
         * @param {?} e
         * @return {?}
         */
        function (e) { return e.stopPropagation(); })), mapTo(true));
        renderer.addClass(elementRef.nativeElement, 'ant-dropdown-trigger');
    }
    /**
     * @param {?} disabled
     * @return {?}
     */
    NzDropDownDirective.prototype.setDisabled = /**
     * @param {?} disabled
     * @return {?}
     */
    function (disabled) {
        if (disabled) {
            this.renderer.setAttribute(this.el, 'disabled', '');
        }
        else {
            this.renderer.removeAttribute(this.el, 'disabled');
        }
    };
    NzDropDownDirective.decorators = [
        { type: Directive, args: [{
                    selector: '[nz-dropdown]',
                    exportAs: 'nzDropdown'
                },] }
    ];
    /** @nocollapse */
    NzDropDownDirective.ctorParameters = function () { return [
        { type: ElementRef },
        { type: Renderer2 }
    ]; };
    return NzDropDownDirective;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @param {?} injector
 * @return {?}
 */
function menuServiceFactory(injector) {
    return injector.get(NzMenuDropdownService);
}
var NzDropDownComponent = /** @class */ (function () {
    function NzDropDownComponent(cdr, nzMenuDropdownService, noAnimation) {
        this.cdr = cdr;
        this.nzMenuDropdownService = nzMenuDropdownService;
        this.noAnimation = noAnimation;
        this.triggerWidth = 0;
        this.dropDownPosition = 'bottom';
        this.positions = __spread(DEFAULT_DROPDOWN_POSITIONS);
        this.visible$ = new Subject();
        this.destroy$ = new Subject();
        this.nzTrigger = 'hover';
        this.nzOverlayClassName = '';
        this.nzOverlayStyle = {};
        this.nzPlacement = 'bottomLeft';
        this.nzClickHide = true;
        this.nzDisabled = false;
        this.nzVisible = false;
        this.nzTableFilter = false;
        this.nzVisibleChange = new EventEmitter();
    }
    /**
     * @param {?} visible
     * @param {?=} trigger
     * @return {?}
     */
    NzDropDownComponent.prototype.setVisibleStateWhen = /**
     * @param {?} visible
     * @param {?=} trigger
     * @return {?}
     */
    function (visible, trigger) {
        if (trigger === void 0) { trigger = 'all'; }
        if (this.nzTrigger === trigger || trigger === 'all') {
            this.visible$.next(visible);
        }
    };
    /**
     * @param {?} position
     * @return {?}
     */
    NzDropDownComponent.prototype.onPositionChange = /**
     * @param {?} position
     * @return {?}
     */
    function (position) {
        this.dropDownPosition = position.connectionPair.originY;
        this.cdr.markForCheck();
    };
    /**
     * @param {?} observable$
     * @return {?}
     */
    NzDropDownComponent.prototype.startSubscribe = /**
     * @param {?} observable$
     * @return {?}
     */
    function (observable$) {
        var _this = this;
        /** @type {?} */
        var click$ = this.nzClickHide ? this.nzMenuDropdownService.menuItemClick$.pipe(mapTo(false)) : EMPTY;
        combineLatest(merge(observable$, click$), this.nzMenuDropdownService.menuOpen$)
            .pipe(map((/**
         * @param {?} value
         * @return {?}
         */
        function (value) { return value[0] || value[1]; })), debounceTime(50), distinctUntilChanged(), takeUntil(this.destroy$))
            .subscribe((/**
         * @param {?} visible
         * @return {?}
         */
        function (visible) {
            if (!_this.nzDisabled && _this.nzVisible !== visible) {
                _this.nzVisible = visible;
                _this.nzVisibleChange.emit(_this.nzVisible);
                _this.triggerWidth = _this.nzDropDownDirective.elementRef.nativeElement.getBoundingClientRect().width;
                _this.cdr.markForCheck();
            }
        }));
    };
    /**
     * @return {?}
     */
    NzDropDownComponent.prototype.updateDisabledState = /**
     * @return {?}
     */
    function () {
        if (this.nzDropDownDirective) {
            this.nzDropDownDirective.setDisabled(this.nzDisabled);
        }
    };
    /**
     * @return {?}
     */
    NzDropDownComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.destroy$.next();
        this.destroy$.complete();
    };
    /**
     * @return {?}
     */
    NzDropDownComponent.prototype.ngAfterContentInit = /**
     * @return {?}
     */
    function () {
        this.startSubscribe(merge(this.visible$, this.nzTrigger === 'hover' ? this.nzDropDownDirective.hover$ : this.nzDropDownDirective.$click));
        this.updateDisabledState();
    };
    /**
     * @param {?} changes
     * @return {?}
     */
    NzDropDownComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        if (changes.nzVisible) {
            this.visible$.next(this.nzVisible);
        }
        if (changes.nzDisabled) {
            this.updateDisabledState();
        }
        if (changes.nzPlacement) {
            this.dropDownPosition = this.nzPlacement.indexOf('top') !== -1 ? 'top' : 'bottom';
            this.positions = __spread([POSITION_MAP[this.nzPlacement]], this.positions);
        }
    };
    NzDropDownComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-dropdown',
                    exportAs: 'nzDropdown',
                    preserveWhitespaces: false,
                    providers: [
                        NzMenuDropdownService,
                        {
                            provide: NzDropdownHigherOrderServiceToken,
                            useFactory: menuServiceFactory,
                            deps: [[new Self(), Injector]]
                        }
                    ],
                    animations: [slideMotion],
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    template: "<ng-content select=\"[nz-dropdown]\"></ng-content>\n<ng-template\n  cdkConnectedOverlay\n  nzConnectedOverlay\n  [cdkConnectedOverlayHasBackdrop]=\"nzTrigger === 'click'\"\n  [cdkConnectedOverlayPositions]=\"positions\"\n  [cdkConnectedOverlayOrigin]=\"nzDropDownDirective\"\n  [cdkConnectedOverlayMinWidth]=\"triggerWidth\"\n  [cdkConnectedOverlayOpen]=\"nzVisible\"\n  (backdropClick)=\"setVisibleStateWhen(false)\"\n  (detach)=\"setVisibleStateWhen(false)\"\n  (positionChange)=\"onPositionChange($event)\">\n  <div class=\"{{'ant-dropdown ant-dropdown-placement-'+nzPlacement}}\"\n    [ngClass]=\"nzOverlayClassName\"\n    [ngStyle]=\"nzOverlayStyle\"\n    [@slideMotion]=\"dropDownPosition\"\n    [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n    [style.minWidth.px]=\"triggerWidth\"\n    (mouseenter)=\"setVisibleStateWhen(true,'hover')\"\n    (mouseleave)=\"setVisibleStateWhen(false,'hover')\">\n    <div [class.ant-table-filter-dropdown]=\"nzTableFilter\">\n      <ng-content select=\"[nz-menu]\"></ng-content>\n      <ng-content></ng-content>\n    </div>\n  </div>\n</ng-template>",
                    styles: ["\n      .ant-dropdown {\n        top: 100%;\n        left: 0;\n        position: relative;\n        width: 100%;\n        margin-top: 4px;\n        margin-bottom: 4px;\n      }\n    "]
                }] }
    ];
    /** @nocollapse */
    NzDropDownComponent.ctorParameters = function () { return [
        { type: ChangeDetectorRef },
        { type: NzMenuDropdownService },
        { type: NzNoAnimationDirective, decorators: [{ type: Host }, { type: Optional }] }
    ]; };
    NzDropDownComponent.propDecorators = {
        nzDropDownDirective: [{ type: ContentChild, args: [NzDropDownDirective,] }],
        nzMenuDirective: [{ type: ContentChild, args: [NzMenuDirective,] }],
        cdkConnectedOverlay: [{ type: ViewChild, args: [CdkConnectedOverlay,] }],
        nzTrigger: [{ type: Input }],
        nzOverlayClassName: [{ type: Input }],
        nzOverlayStyle: [{ type: Input }],
        nzPlacement: [{ type: Input }],
        nzClickHide: [{ type: Input }],
        nzDisabled: [{ type: Input }],
        nzVisible: [{ type: Input }],
        nzTableFilter: [{ type: Input }],
        nzVisibleChange: [{ type: Output }]
    };
    __decorate([
        InputBoolean(),
        __metadata("design:type", Object)
    ], NzDropDownComponent.prototype, "nzClickHide", void 0);
    __decorate([
        InputBoolean(),
        __metadata("design:type", Object)
    ], NzDropDownComponent.prototype, "nzDisabled", void 0);
    __decorate([
        InputBoolean(),
        __metadata("design:type", Object)
    ], NzDropDownComponent.prototype, "nzVisible", void 0);
    __decorate([
        InputBoolean(),
        __metadata("design:type", Object)
    ], NzDropDownComponent.prototype, "nzTableFilter", void 0);
    return NzDropDownComponent;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var NzDropdownService = /** @class */ (function () {
    function NzDropdownService(overlay) {
        this.overlay = overlay;
    }
    /**
     * @param {?} $event
     * @param {?} templateRef
     * @return {?}
     */
    NzDropdownService.prototype.create = /**
     * @param {?} $event
     * @param {?} templateRef
     * @return {?}
     */
    function ($event, templateRef) {
        var _this = this;
        $event.preventDefault();
        this.dispose();
        this.overlayRef = this.overlay.create(new OverlayConfig({
            scrollStrategy: this.overlay.scrollStrategies.close(),
            panelClass: 'nz-dropdown-panel',
            positionStrategy: this.overlay
                .position()
                .flexibleConnectedTo({
                x: $event.x,
                y: $event.y
            })
                .withPositions([
                new ConnectionPositionPair({ originX: 'start', originY: 'top' }, { overlayX: 'start', overlayY: 'top' }),
                new ConnectionPositionPair({ originX: 'start', originY: 'top' }, { overlayX: 'start', overlayY: 'bottom' }),
                new ConnectionPositionPair({ originX: 'start', originY: 'top' }, { overlayX: 'end', overlayY: 'bottom' }),
                new ConnectionPositionPair({ originX: 'start', originY: 'top' }, { overlayX: 'end', overlayY: 'top' })
            ])
        }));
        /** @type {?} */
        var positionChanges = ((/** @type {?} */ (this.overlayRef.getConfig().positionStrategy)))
            .positionChanges;
        /** @type {?} */
        var instance = this.overlayRef.attach(new ComponentPortal(NzDropdownContextComponent)).instance;
        fromEvent(document, 'click')
            .pipe(filter((/**
         * @param {?} event
         * @return {?}
         */
        function (event) { return !!_this.overlayRef && !_this.overlayRef.overlayElement.contains((/** @type {?} */ (event.target))); })), take(1))
            .subscribe((/**
         * @return {?}
         */
        function () { return instance.close(); }));
        instance.init(true, templateRef, positionChanges, this);
        return instance;
    };
    /**
     * @return {?}
     */
    NzDropdownService.prototype.dispose = /**
     * @return {?}
     */
    function () {
        if (this.overlayRef) {
            this.overlayRef.dispose();
            this.overlayRef = null;
        }
    };
    NzDropdownService.decorators = [
        { type: Injectable }
    ];
    /** @nocollapse */
    NzDropdownService.ctorParameters = function () { return [
        { type: Overlay }
    ]; };
    return NzDropdownService;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var ɵ0 = menuServiceFactory;
var NzDropDownButtonComponent = /** @class */ (function (_super) {
    __extends(NzDropDownButtonComponent, _super);
    function NzDropDownButtonComponent(cdr, nzMenuDropdownService, noAnimation) {
        var _this = _super.call(this, cdr, nzMenuDropdownService, noAnimation) || this;
        _this.noAnimation = noAnimation;
        _this.nzSize = 'default';
        _this.nzType = 'default';
        _this.nzClick = new EventEmitter();
        return _this;
    }
    /** rewrite afterViewInit hook */
    /**
     * rewrite afterViewInit hook
     * @return {?}
     */
    NzDropDownButtonComponent.prototype.ngAfterContentInit = /**
     * rewrite afterViewInit hook
     * @return {?}
     */
    function () {
        this.startSubscribe(this.visible$);
    };
    NzDropDownButtonComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-dropdown-button',
                    exportAs: 'nzDropdownButton',
                    preserveWhitespaces: false,
                    animations: [slideMotion],
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    providers: [
                        NzMenuDropdownService,
                        {
                            provide: NzDropdownHigherOrderServiceToken,
                            useFactory: ɵ0,
                            deps: [[new Self(), Injector]]
                        }
                    ],
                    template: "<div class=\"ant-btn-group ant-dropdown-button\" nz-dropdown>\n  <button nz-button\n    type=\"button\"\n    [disabled]=\"nzDisabled\"\n    [nzType]=\"nzType\"\n    [nzSize]=\"nzSize\"\n    (click)=\"nzClick.emit($event)\">\n    <span><ng-content></ng-content></span>\n  </button>\n  <button nz-button\n    type=\"button\"\n    class=\"ant-dropdown-trigger\"\n    [nzType]=\"nzType\"\n    [nzSize]=\"nzSize\"\n    [disabled]=\"nzDisabled\"\n    (click)=\"setVisibleStateWhen(true,'click')\"\n    (mouseenter)=\"setVisibleStateWhen(true,'hover')\"\n    (mouseleave)=\"setVisibleStateWhen(false,'hover')\">\n    <i nz-icon type=\"ellipsis\"></i>\n  </button>\n</div>\n<ng-template\n  cdkConnectedOverlay\n  nzConnectedOverlay\n  [cdkConnectedOverlayHasBackdrop]=\"nzTrigger === 'click'\"\n  [cdkConnectedOverlayPositions]=\"positions\"\n  [cdkConnectedOverlayOrigin]=\"nzDropDownDirective\"\n  (backdropClick)=\"setVisibleStateWhen(false)\"\n  (detach)=\"setVisibleStateWhen(false)\"\n  [cdkConnectedOverlayMinWidth]=\"triggerWidth\"\n  (positionChange)=\"onPositionChange($event)\"\n  [cdkConnectedOverlayOpen]=\"nzVisible\">\n  <div class=\"{{'ant-dropdown ant-dropdown-placement-'+nzPlacement}}\"\n    [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n    [@slideMotion]=\"dropDownPosition\"\n    (mouseenter)=\"setVisibleStateWhen(true,'hover')\"\n    (mouseleave)=\"setVisibleStateWhen(false,'hover')\"\n    [style.minWidth.px]=\"triggerWidth\">\n    <ng-content select=\"[nz-menu]\"></ng-content>\n  </div>\n</ng-template>",
                    styles: ["\n      nz-dropdown-button {\n        position: relative;\n        display: inline-block;\n      }\n\n      .ant-dropdown {\n        top: 100%;\n        left: 0;\n        position: relative;\n        width: 100%;\n        margin-top: 4px;\n        margin-bottom: 4px;\n      }\n    "]
                }] }
    ];
    /** @nocollapse */
    NzDropDownButtonComponent.ctorParameters = function () { return [
        { type: ChangeDetectorRef },
        { type: NzMenuDropdownService },
        { type: NzNoAnimationDirective, decorators: [{ type: Host }, { type: Optional }] }
    ]; };
    NzDropDownButtonComponent.propDecorators = {
        nzSize: [{ type: Input }],
        nzType: [{ type: Input }],
        nzClick: [{ type: Output }],
        nzDropDownDirective: [{ type: ViewChild, args: [NzDropDownDirective,] }]
    };
    return NzDropDownButtonComponent;
}(NzDropDownComponent));

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var NzDropDownADirective = /** @class */ (function () {
    function NzDropDownADirective(elementRef, renderer) {
        this.elementRef = elementRef;
        this.renderer = renderer;
        this.renderer.addClass(this.elementRef.nativeElement, 'ant-dropdown-link');
    }
    NzDropDownADirective.decorators = [
        { type: Directive, args: [{
                    selector: 'a[nz-dropdown]'
                },] }
    ];
    /** @nocollapse */
    NzDropDownADirective.ctorParameters = function () { return [
        { type: ElementRef },
        { type: Renderer2 }
    ]; };
    return NzDropDownADirective;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var NzDropDownModule = /** @class */ (function () {
    function NzDropDownModule() {
    }
    NzDropDownModule.decorators = [
        { type: NgModule, args: [{
                    imports: [
                        CommonModule,
                        OverlayModule,
                        FormsModule,
                        NzButtonModule,
                        NzMenuModule,
                        NzIconModule,
                        NzNoAnimationModule,
                        NzOverlayModule
                    ],
                    entryComponents: [NzDropdownContextComponent],
                    declarations: [
                        NzDropDownComponent,
                        NzDropDownButtonComponent,
                        NzDropDownDirective,
                        NzDropDownADirective,
                        NzDropdownContextComponent
                    ],
                    exports: [NzMenuModule, NzDropDownComponent, NzDropDownButtonComponent, NzDropDownDirective, NzDropDownADirective],
                    providers: [NzDropdownService]
                },] }
    ];
    return NzDropDownModule;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

export { NzDropdownContextComponent, menuServiceFactory, NzDropDownComponent, NzDropDownDirective, NzDropdownService, NzDropDownButtonComponent, NzDropDownModule, NzMenuDropdownService, NzDropDownADirective };

//# sourceMappingURL=ng-zorro-antd-dropdown.js.map