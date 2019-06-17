(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/cdk/portal'), require('rxjs'), require('rxjs/operators'), require('@angular/cdk/overlay'), require('@angular/common'), require('@angular/forms'), require('ng-zorro-antd/button'), require('ng-zorro-antd/core'), require('ng-zorro-antd/icon'), require('ng-zorro-antd/menu'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/dropdown', ['exports', '@angular/cdk/portal', 'rxjs', 'rxjs/operators', '@angular/cdk/overlay', '@angular/common', '@angular/forms', 'ng-zorro-antd/button', 'ng-zorro-antd/core', 'ng-zorro-antd/icon', 'ng-zorro-antd/menu', '@angular/core'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].dropdown = {}),global.ng.cdk.portal,global.rxjs,global.rxjs.operators,global.ng.cdk.overlay,global.ng.common,global.ng.forms,global['ng-zorro-antd'].button,global['ng-zorro-antd'].core,global['ng-zorro-antd'].icon,global['ng-zorro-antd'].menu,global.ng.core));
}(this, (function (exports,portal,rxjs,operators,overlay,common,forms,button,core,icon,menu,core$1) { 'use strict';

    /*! *****************************************************************************
    Copyright (c) Microsoft Corporation. All rights reserved.
    Licensed under the Apache License, Version 2.0 (the "License"); you may not use
    this file except in compliance with the License. You may obtain a copy of the
    License at http://www.apache.org/licenses/LICENSE-2.0

    THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
    KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
    WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
    MERCHANTABLITY OR NON-INFRINGEMENT.

    See the Apache Version 2.0 License for specific language governing permissions
    and limitations under the License.
    ***************************************************************************** */
    /* global Reflect, Promise */
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b)
                if (b.hasOwnProperty(p))
                    d[p] = b[p]; };
        return extendStatics(d, b);
    };
    function __extends(d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    }
    function __decorate(decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function")
            r = Reflect.decorate(decorators, target, key, desc);
        else
            for (var i = decorators.length - 1; i >= 0; i--)
                if (d = decorators[i])
                    r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    }
    function __metadata(metadataKey, metadataValue) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function")
            return Reflect.metadata(metadataKey, metadataValue);
    }
    function __read(o, n) {
        var m = typeof Symbol === "function" && o[Symbol.iterator];
        if (!m)
            return o;
        var i = m.call(o), r, ar = [], e;
        try {
            while ((n === void 0 || n-- > 0) && !(r = i.next()).done)
                ar.push(r.value);
        }
        catch (error) {
            e = { error: error };
        }
        finally {
            try {
                if (r && !r.done && (m = i["return"]))
                    m.call(i);
            }
            finally {
                if (e)
                    throw e.error;
            }
        }
        return ar;
    }
    function __spread() {
        for (var ar = [], i = 0; i < arguments.length; i++)
            ar = ar.concat(__read(arguments[i]));
        return ar;
    }

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
            { type: core$1.Injectable }
        ];
        return NzMenuDropdownService;
    }(core.NzMenuBaseService));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzDropdownContextComponent = /** @class */ (function () {
        function NzDropdownContextComponent(cdr) {
            this.cdr = cdr;
            this.open = true;
            this.dropDownPosition = 'bottom';
            this.destroy$ = new rxjs.Subject();
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
                positionChanges.pipe(operators.takeUntil(this.destroy$)).subscribe(( /**
                 * @param {?} data
                 * @return {?}
                 */function (data) {
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
            { type: core$1.Component, args: [{
                        selector: 'nz-dropdown-context',
                        exportAs: 'nzDropdownContext',
                        animations: [core.slideMotion],
                        preserveWhitespaces: false,
                        template: "<div *ngIf=\"open\"\n  class=\"ant-dropdown ant-dropdown-placement-bottomLeft\"\n  [@slideMotion]=\"dropDownPosition\"\n  (@slideMotion.done)=\"afterAnimation()\">\n  <ng-template [ngTemplateOutlet]=\"templateRef\"></ng-template>\n</div>",
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        providers: [NzMenuDropdownService],
                        styles: ["\n      nz-dropdown-context {\n        display: block;\n      }\n\n      .ant-dropdown {\n        top: 100%;\n        left: 0;\n        position: relative;\n        width: 100%;\n        margin-top: 4px;\n        margin-bottom: 4px;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzDropdownContextComponent.ctorParameters = function () {
            return [
                { type: core$1.ChangeDetectorRef }
            ];
        };
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
            this.hover$ = rxjs.merge(rxjs.fromEvent(this.el, 'mouseenter').pipe(operators.mapTo(true)), rxjs.fromEvent(this.el, 'mouseleave').pipe(operators.mapTo(false)));
            this.$click = rxjs.fromEvent(this.el, 'click').pipe(operators.tap(( /**
             * @param {?} e
             * @return {?}
             */function (e) { return e.stopPropagation(); })), operators.mapTo(true));
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
            { type: core$1.Directive, args: [{
                        selector: '[nz-dropdown]',
                        exportAs: 'nzDropdown'
                    },] }
        ];
        /** @nocollapse */
        NzDropDownDirective.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.Renderer2 }
            ];
        };
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
            this.positions = __spread(core.DEFAULT_DROPDOWN_POSITIONS);
            this.visible$ = new rxjs.Subject();
            this.destroy$ = new rxjs.Subject();
            this.nzTrigger = 'hover';
            this.nzOverlayClassName = '';
            this.nzOverlayStyle = {};
            this.nzPlacement = 'bottomLeft';
            this.nzClickHide = true;
            this.nzDisabled = false;
            this.nzVisible = false;
            this.nzTableFilter = false;
            this.nzVisibleChange = new core$1.EventEmitter();
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
                if (trigger === void 0) {
                    trigger = 'all';
                }
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
                var click$ = this.nzClickHide ? this.nzMenuDropdownService.menuItemClick$.pipe(operators.mapTo(false)) : rxjs.EMPTY;
                rxjs.combineLatest(rxjs.merge(observable$, click$), this.nzMenuDropdownService.menuOpen$)
                    .pipe(operators.map(( /**
             * @param {?} value
             * @return {?}
             */function (value) { return value[0] || value[1]; })), operators.debounceTime(50), operators.distinctUntilChanged(), operators.takeUntil(this.destroy$))
                    .subscribe(( /**
             * @param {?} visible
             * @return {?}
             */function (visible) {
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
                this.startSubscribe(rxjs.merge(this.visible$, this.nzTrigger === 'hover' ? this.nzDropDownDirective.hover$ : this.nzDropDownDirective.$click));
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
                    this.positions = __spread([core.POSITION_MAP[this.nzPlacement]], this.positions);
                }
            };
        NzDropDownComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-dropdown',
                        exportAs: 'nzDropdown',
                        preserveWhitespaces: false,
                        providers: [
                            NzMenuDropdownService,
                            {
                                provide: core.NzDropdownHigherOrderServiceToken,
                                useFactory: menuServiceFactory,
                                deps: [[new core$1.Self(), core$1.Injector]]
                            }
                        ],
                        animations: [core.slideMotion],
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        template: "<ng-content select=\"[nz-dropdown]\"></ng-content>\n<ng-template\n  cdkConnectedOverlay\n  nzConnectedOverlay\n  [cdkConnectedOverlayHasBackdrop]=\"nzTrigger === 'click'\"\n  [cdkConnectedOverlayPositions]=\"positions\"\n  [cdkConnectedOverlayOrigin]=\"nzDropDownDirective\"\n  [cdkConnectedOverlayMinWidth]=\"triggerWidth\"\n  [cdkConnectedOverlayOpen]=\"nzVisible\"\n  (backdropClick)=\"setVisibleStateWhen(false)\"\n  (detach)=\"setVisibleStateWhen(false)\"\n  (positionChange)=\"onPositionChange($event)\">\n  <div class=\"{{'ant-dropdown ant-dropdown-placement-'+nzPlacement}}\"\n    [ngClass]=\"nzOverlayClassName\"\n    [ngStyle]=\"nzOverlayStyle\"\n    [@slideMotion]=\"dropDownPosition\"\n    [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n    [style.minWidth.px]=\"triggerWidth\"\n    (mouseenter)=\"setVisibleStateWhen(true,'hover')\"\n    (mouseleave)=\"setVisibleStateWhen(false,'hover')\">\n    <div [class.ant-table-filter-dropdown]=\"nzTableFilter\">\n      <ng-content select=\"[nz-menu]\"></ng-content>\n      <ng-content></ng-content>\n    </div>\n  </div>\n</ng-template>",
                        styles: ["\n      .ant-dropdown {\n        top: 100%;\n        left: 0;\n        position: relative;\n        width: 100%;\n        margin-top: 4px;\n        margin-bottom: 4px;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzDropDownComponent.ctorParameters = function () {
            return [
                { type: core$1.ChangeDetectorRef },
                { type: NzMenuDropdownService },
                { type: core.NzNoAnimationDirective, decorators: [{ type: core$1.Host }, { type: core$1.Optional }] }
            ];
        };
        NzDropDownComponent.propDecorators = {
            nzDropDownDirective: [{ type: core$1.ContentChild, args: [NzDropDownDirective,] }],
            nzMenuDirective: [{ type: core$1.ContentChild, args: [menu.NzMenuDirective,] }],
            cdkConnectedOverlay: [{ type: core$1.ViewChild, args: [overlay.CdkConnectedOverlay,] }],
            nzTrigger: [{ type: core$1.Input }],
            nzOverlayClassName: [{ type: core$1.Input }],
            nzOverlayStyle: [{ type: core$1.Input }],
            nzPlacement: [{ type: core$1.Input }],
            nzClickHide: [{ type: core$1.Input }],
            nzDisabled: [{ type: core$1.Input }],
            nzVisible: [{ type: core$1.Input }],
            nzTableFilter: [{ type: core$1.Input }],
            nzVisibleChange: [{ type: core$1.Output }]
        };
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzDropDownComponent.prototype, "nzClickHide", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzDropDownComponent.prototype, "nzDisabled", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzDropDownComponent.prototype, "nzVisible", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzDropDownComponent.prototype, "nzTableFilter", void 0);
        return NzDropDownComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzDropdownService = /** @class */ (function () {
        function NzDropdownService(overlay$$1) {
            this.overlay = overlay$$1;
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
                this.overlayRef = this.overlay.create(new overlay.OverlayConfig({
                    scrollStrategy: this.overlay.scrollStrategies.close(),
                    panelClass: 'nz-dropdown-panel',
                    positionStrategy: this.overlay
                        .position()
                        .flexibleConnectedTo({
                        x: $event.x,
                        y: $event.y
                    })
                        .withPositions([
                        new overlay.ConnectionPositionPair({ originX: 'start', originY: 'top' }, { overlayX: 'start', overlayY: 'top' }),
                        new overlay.ConnectionPositionPair({ originX: 'start', originY: 'top' }, { overlayX: 'start', overlayY: 'bottom' }),
                        new overlay.ConnectionPositionPair({ originX: 'start', originY: 'top' }, { overlayX: 'end', overlayY: 'bottom' }),
                        new overlay.ConnectionPositionPair({ originX: 'start', originY: 'top' }, { overlayX: 'end', overlayY: 'top' })
                    ])
                }));
                /** @type {?} */
                var positionChanges = (( /** @type {?} */(this.overlayRef.getConfig().positionStrategy)))
                    .positionChanges;
                /** @type {?} */
                var instance = this.overlayRef.attach(new portal.ComponentPortal(NzDropdownContextComponent)).instance;
                rxjs.fromEvent(document, 'click')
                    .pipe(operators.filter(( /**
             * @param {?} event
             * @return {?}
             */function (event) { return !!_this.overlayRef && !_this.overlayRef.overlayElement.contains(( /** @type {?} */(event.target))); })), operators.take(1))
                    .subscribe(( /**
             * @return {?}
             */function () { return instance.close(); }));
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
            { type: core$1.Injectable }
        ];
        /** @nocollapse */
        NzDropdownService.ctorParameters = function () {
            return [
                { type: overlay.Overlay }
            ];
        };
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
            _this.nzClick = new core$1.EventEmitter();
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
            { type: core$1.Component, args: [{
                        selector: 'nz-dropdown-button',
                        exportAs: 'nzDropdownButton',
                        preserveWhitespaces: false,
                        animations: [core.slideMotion],
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        providers: [
                            NzMenuDropdownService,
                            {
                                provide: core.NzDropdownHigherOrderServiceToken,
                                useFactory: ɵ0,
                                deps: [[new core$1.Self(), core$1.Injector]]
                            }
                        ],
                        template: "<div class=\"ant-btn-group ant-dropdown-button\" nz-dropdown>\n  <button nz-button\n    type=\"button\"\n    [disabled]=\"nzDisabled\"\n    [nzType]=\"nzType\"\n    [nzSize]=\"nzSize\"\n    (click)=\"nzClick.emit($event)\">\n    <span><ng-content></ng-content></span>\n  </button>\n  <button nz-button\n    type=\"button\"\n    class=\"ant-dropdown-trigger\"\n    [nzType]=\"nzType\"\n    [nzSize]=\"nzSize\"\n    [disabled]=\"nzDisabled\"\n    (click)=\"setVisibleStateWhen(true,'click')\"\n    (mouseenter)=\"setVisibleStateWhen(true,'hover')\"\n    (mouseleave)=\"setVisibleStateWhen(false,'hover')\">\n    <i nz-icon type=\"ellipsis\"></i>\n  </button>\n</div>\n<ng-template\n  cdkConnectedOverlay\n  nzConnectedOverlay\n  [cdkConnectedOverlayHasBackdrop]=\"nzTrigger === 'click'\"\n  [cdkConnectedOverlayPositions]=\"positions\"\n  [cdkConnectedOverlayOrigin]=\"nzDropDownDirective\"\n  (backdropClick)=\"setVisibleStateWhen(false)\"\n  (detach)=\"setVisibleStateWhen(false)\"\n  [cdkConnectedOverlayMinWidth]=\"triggerWidth\"\n  (positionChange)=\"onPositionChange($event)\"\n  [cdkConnectedOverlayOpen]=\"nzVisible\">\n  <div class=\"{{'ant-dropdown ant-dropdown-placement-'+nzPlacement}}\"\n    [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n    [@slideMotion]=\"dropDownPosition\"\n    (mouseenter)=\"setVisibleStateWhen(true,'hover')\"\n    (mouseleave)=\"setVisibleStateWhen(false,'hover')\"\n    [style.minWidth.px]=\"triggerWidth\">\n    <ng-content select=\"[nz-menu]\"></ng-content>\n  </div>\n</ng-template>",
                        styles: ["\n      nz-dropdown-button {\n        position: relative;\n        display: inline-block;\n      }\n\n      .ant-dropdown {\n        top: 100%;\n        left: 0;\n        position: relative;\n        width: 100%;\n        margin-top: 4px;\n        margin-bottom: 4px;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzDropDownButtonComponent.ctorParameters = function () {
            return [
                { type: core$1.ChangeDetectorRef },
                { type: NzMenuDropdownService },
                { type: core.NzNoAnimationDirective, decorators: [{ type: core$1.Host }, { type: core$1.Optional }] }
            ];
        };
        NzDropDownButtonComponent.propDecorators = {
            nzSize: [{ type: core$1.Input }],
            nzType: [{ type: core$1.Input }],
            nzClick: [{ type: core$1.Output }],
            nzDropDownDirective: [{ type: core$1.ViewChild, args: [NzDropDownDirective,] }]
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
            { type: core$1.Directive, args: [{
                        selector: 'a[nz-dropdown]'
                    },] }
        ];
        /** @nocollapse */
        NzDropDownADirective.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.Renderer2 }
            ];
        };
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
            { type: core$1.NgModule, args: [{
                        imports: [
                            common.CommonModule,
                            overlay.OverlayModule,
                            forms.FormsModule,
                            button.NzButtonModule,
                            menu.NzMenuModule,
                            icon.NzIconModule,
                            core.NzNoAnimationModule,
                            core.NzOverlayModule
                        ],
                        entryComponents: [NzDropdownContextComponent],
                        declarations: [
                            NzDropDownComponent,
                            NzDropDownButtonComponent,
                            NzDropDownDirective,
                            NzDropDownADirective,
                            NzDropdownContextComponent
                        ],
                        exports: [menu.NzMenuModule, NzDropDownComponent, NzDropDownButtonComponent, NzDropDownDirective, NzDropDownADirective],
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

    exports.NzDropdownContextComponent = NzDropdownContextComponent;
    exports.menuServiceFactory = menuServiceFactory;
    exports.NzDropDownComponent = NzDropDownComponent;
    exports.NzDropDownDirective = NzDropDownDirective;
    exports.NzDropdownService = NzDropdownService;
    exports.NzDropDownButtonComponent = NzDropDownButtonComponent;
    exports.NzDropDownModule = NzDropDownModule;
    exports.NzMenuDropdownService = NzMenuDropdownService;
    exports.NzDropDownADirective = NzDropDownADirective;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-dropdown.umd.js.map