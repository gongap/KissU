(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/cdk/a11y'), require('@angular/common'), require('ng-zorro-antd/core'), require('ng-zorro-antd/icon'), require('@angular/cdk/overlay'), require('@angular/cdk/portal'), require('@angular/core'), require('rxjs'), require('rxjs/operators')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/drawer', ['exports', '@angular/cdk/a11y', '@angular/common', 'ng-zorro-antd/core', 'ng-zorro-antd/icon', '@angular/cdk/overlay', '@angular/cdk/portal', '@angular/core', 'rxjs', 'rxjs/operators'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].drawer = {}),global.ng.cdk.a11y,global.ng.common,global['ng-zorro-antd'].core,global['ng-zorro-antd'].icon,global.ng.cdk.overlay,global.ng.cdk.portal,global.ng.core,global.rxjs,global.rxjs.operators));
}(this, (function (exports,a11y,common,core,icon,i1,portal,i0,rxjs,operators) { 'use strict';

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
    function __rest(s, e) {
        var t = {};
        for (var p in s)
            if (Object.prototype.hasOwnProperty.call(s, p) && e.indexOf(p) < 0)
                t[p] = s[p];
        if (s != null && typeof Object.getOwnPropertySymbols === "function")
            for (var i = 0, p = Object.getOwnPropertySymbols(s); i < p.length; i++)
                if (e.indexOf(p[i]) < 0)
                    t[p[i]] = s[p[i]];
        return t;
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
    var  
    // tslint:disable-next-line:no-any
    /**
     * @abstract
     * @template R
     */
    NzDrawerRef = /** @class */ (function () {
        function NzDrawerRef() {
        }
        return NzDrawerRef;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var DRAWER_ANIMATE_DURATION = 300;
    /**
     * @template T, R, D
     */
    var NzDrawerComponent = /** @class */ (function (_super) {
        __extends(NzDrawerComponent, _super);
        function NzDrawerComponent(document, renderer, overlay, injector, changeDetectorRef, focusTrapFactory, viewContainerRef) {
            var _this = _super.call(this) || this;
            _this.document = document;
            _this.renderer = renderer;
            _this.overlay = overlay;
            _this.injector = injector;
            _this.changeDetectorRef = changeDetectorRef;
            _this.focusTrapFactory = focusTrapFactory;
            _this.viewContainerRef = viewContainerRef;
            _this.nzClosable = true;
            _this.nzMaskClosable = true;
            _this.nzMask = true;
            _this.nzNoAnimation = false;
            _this.nzPlacement = 'right';
            _this.nzMaskStyle = {};
            _this.nzBodyStyle = {};
            _this.nzWidth = 256;
            _this.nzHeight = 256;
            _this.nzZIndex = 1000;
            _this.nzOffsetX = 0;
            _this.nzOffsetY = 0;
            _this.nzOnViewInit = new i0.EventEmitter();
            _this.nzOnClose = new i0.EventEmitter();
            _this.isOpen = false;
            _this.templateContext = {
                $implicit: undefined,
                drawerRef: ( /** @type {?} */(_this))
            };
            _this.nzAfterOpen = new rxjs.Subject();
            _this.nzAfterClose = new rxjs.Subject();
            return _this;
        }
        Object.defineProperty(NzDrawerComponent.prototype, "nzVisible", {
            get: /**
             * @return {?}
             */ function () {
                return this.isOpen;
            },
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this.isOpen = value;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzDrawerComponent.prototype, "offsetTransform", {
            get: /**
             * @return {?}
             */ function () {
                if (!this.isOpen || this.nzOffsetX + this.nzOffsetY === 0) {
                    return null;
                }
                switch (this.nzPlacement) {
                    case 'left':
                        return "translateX(" + this.nzOffsetX + "px)";
                    case 'right':
                        return "translateX(-" + this.nzOffsetX + "px)";
                    case 'top':
                        return "translateY(" + this.nzOffsetY + "px)";
                    case 'bottom':
                        return "translateY(-" + this.nzOffsetY + "px)";
                }
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzDrawerComponent.prototype, "transform", {
            get: /**
             * @return {?}
             */ function () {
                if (this.isOpen) {
                    return null;
                }
                switch (this.nzPlacement) {
                    case 'left':
                        return "translateX(-100%)";
                    case 'right':
                        return "translateX(100%)";
                    case 'top':
                        return "translateY(-100%)";
                    case 'bottom':
                        return "translateY(100%)";
                }
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzDrawerComponent.prototype, "width", {
            get: /**
             * @return {?}
             */ function () {
                return this.isLeftOrRight ? core.toCssPixel(this.nzWidth) : null;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzDrawerComponent.prototype, "height", {
            get: /**
             * @return {?}
             */ function () {
                return !this.isLeftOrRight ? core.toCssPixel(this.nzHeight) : null;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzDrawerComponent.prototype, "isLeftOrRight", {
            get: /**
             * @return {?}
             */ function () {
                return this.nzPlacement === 'left' || this.nzPlacement === 'right';
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzDrawerComponent.prototype, "afterOpen", {
            get: /**
             * @return {?}
             */ function () {
                return this.nzAfterOpen.asObservable();
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzDrawerComponent.prototype, "afterClose", {
            get: /**
             * @return {?}
             */ function () {
                return this.nzAfterClose.asObservable();
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @param {?} value
         * @return {?}
         */
        NzDrawerComponent.prototype.isTemplateRef = /**
         * @param {?} value
         * @return {?}
         */
            function (value) {
                return value instanceof i0.TemplateRef;
            };
        /**
         * @return {?}
         */
        NzDrawerComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.attachOverlay();
                this.updateOverlayStyle();
                this.updateBodyOverflow();
                this.templateContext = { $implicit: this.nzContentParams, drawerRef: ( /** @type {?} */(this)) };
                this.changeDetectorRef.detectChanges();
            };
        /**
         * @return {?}
         */
        NzDrawerComponent.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.attachBodyContent();
                setTimeout(( /**
                 * @return {?}
                 */function () {
                    _this.nzOnViewInit.emit();
                }));
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzDrawerComponent.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                var _this = this;
                if (changes.hasOwnProperty('nzVisible')) {
                    /** @type {?} */
                    var value = changes.nzVisible.currentValue;
                    this.updateOverlayStyle();
                    if (value) {
                        this.updateBodyOverflow();
                        this.savePreviouslyFocusedElement();
                        this.trapFocus();
                    }
                    else {
                        setTimeout(( /**
                         * @return {?}
                         */function () {
                            _this.updateBodyOverflow();
                            _this.restoreFocus();
                        }), this.getAnimationDuration());
                    }
                }
            };
        /**
         * @return {?}
         */
        NzDrawerComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.disposeOverlay();
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.getAnimationDuration = /**
         * @private
         * @return {?}
         */
            function () {
                return this.nzNoAnimation ? 0 : DRAWER_ANIMATE_DURATION;
            };
        /**
         * @param {?=} result
         * @return {?}
         */
        NzDrawerComponent.prototype.close = /**
         * @param {?=} result
         * @return {?}
         */
            function (result) {
                var _this = this;
                this.isOpen = false;
                this.updateOverlayStyle();
                this.changeDetectorRef.detectChanges();
                setTimeout(( /**
                 * @return {?}
                 */function () {
                    _this.updateBodyOverflow();
                    _this.restoreFocus();
                    _this.nzAfterClose.next(result);
                    _this.nzAfterClose.complete();
                }), this.getAnimationDuration());
            };
        /**
         * @return {?}
         */
        NzDrawerComponent.prototype.open = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.isOpen = true;
                this.updateOverlayStyle();
                this.updateBodyOverflow();
                this.savePreviouslyFocusedElement();
                this.trapFocus();
                this.changeDetectorRef.detectChanges();
                setTimeout(( /**
                 * @return {?}
                 */function () {
                    _this.nzAfterOpen.next();
                }), this.getAnimationDuration());
            };
        /**
         * @return {?}
         */
        NzDrawerComponent.prototype.closeClick = /**
         * @return {?}
         */
            function () {
                this.nzOnClose.emit();
            };
        /**
         * @return {?}
         */
        NzDrawerComponent.prototype.maskClick = /**
         * @return {?}
         */
            function () {
                if (this.nzMaskClosable && this.nzMask) {
                    this.nzOnClose.emit();
                }
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.attachBodyContent = /**
         * @private
         * @return {?}
         */
            function () {
                this.bodyPortalOutlet.dispose();
                if (this.nzContent instanceof i0.Type) {
                    /** @type {?} */
                    var childInjector = new portal.PortalInjector(this.injector, new WeakMap([[NzDrawerRef, this]]));
                    /** @type {?} */
                    var componentPortal = new portal.ComponentPortal(this.nzContent, null, childInjector);
                    /** @type {?} */
                    var componentRef = this.bodyPortalOutlet.attachComponentPortal(componentPortal);
                    Object.assign(componentRef.instance, this.nzContentParams);
                    componentRef.changeDetectorRef.detectChanges();
                }
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.attachOverlay = /**
         * @private
         * @return {?}
         */
            function () {
                if (!this.overlayRef) {
                    this.portal = new portal.TemplatePortal(this.drawerTemplate, this.viewContainerRef);
                    this.overlayRef = this.overlay.create(this.getOverlayConfig());
                }
                if (this.overlayRef && !this.overlayRef.hasAttached()) {
                    this.overlayRef.attach(this.portal);
                }
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.disposeOverlay = /**
         * @private
         * @return {?}
         */
            function () {
                if (this.overlayRef) {
                    this.overlayRef.dispose();
                }
                this.overlayRef = null;
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.getOverlayConfig = /**
         * @private
         * @return {?}
         */
            function () {
                return new i1.OverlayConfig({
                    positionStrategy: this.overlay.position().global(),
                    scrollStrategy: this.overlay.scrollStrategies.block()
                });
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.updateOverlayStyle = /**
         * @private
         * @return {?}
         */
            function () {
                if (this.overlayRef && this.overlayRef.overlayElement) {
                    this.renderer.setStyle(this.overlayRef.overlayElement, 'pointer-events', this.isOpen ? 'auto' : 'none');
                }
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.updateBodyOverflow = /**
         * @private
         * @return {?}
         */
            function () {
                if (this.overlayRef) {
                    if (this.isOpen) {
                        ( /** @type {?} */(this.overlayRef.getConfig().scrollStrategy)).enable();
                    }
                    else {
                        ( /** @type {?} */(this.overlayRef.getConfig().scrollStrategy)).disable();
                    }
                }
            };
        /**
         * @return {?}
         */
        NzDrawerComponent.prototype.savePreviouslyFocusedElement = /**
         * @return {?}
         */
            function () {
                if (this.document && !this.previouslyFocusedElement) {
                    this.previouslyFocusedElement = ( /** @type {?} */(this.document.activeElement));
                    // We need the extra check, because IE's svg element has no blur method.
                    if (this.previouslyFocusedElement && typeof this.previouslyFocusedElement.blur === 'function') {
                        this.previouslyFocusedElement.blur();
                    }
                }
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.trapFocus = /**
         * @private
         * @return {?}
         */
            function () {
                if (!this.focusTrap && this.overlayRef && this.overlayRef.overlayElement) {
                    this.focusTrap = this.focusTrapFactory.create(( /** @type {?} */(this.overlayRef)).overlayElement);
                    this.focusTrap.focusInitialElement();
                }
            };
        /**
         * @private
         * @return {?}
         */
        NzDrawerComponent.prototype.restoreFocus = /**
         * @private
         * @return {?}
         */
            function () {
                // We need the extra check, because IE can set the `activeElement` to null in some cases.
                if (this.previouslyFocusedElement && typeof this.previouslyFocusedElement.focus === 'function') {
                    this.previouslyFocusedElement.focus();
                }
                if (this.focusTrap) {
                    this.focusTrap.destroy();
                }
            };
        NzDrawerComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'nz-drawer',
                        exportAs: 'nzDrawer',
                        template: "<ng-template #drawerTemplate>\n  <div\n    class=\"ant-drawer\"\n    [nzNoAnimation]=\"nzNoAnimation\"\n    [class.ant-drawer-open]=\"isOpen\"\n    [class.ant-drawer-top]=\"nzPlacement === 'top'\"\n    [class.ant-drawer-bottom]=\"nzPlacement === 'bottom'\"\n    [class.ant-drawer-right]=\"nzPlacement === 'right'\"\n    [class.ant-drawer-left]=\"nzPlacement === 'left'\"\n    [style.transform]=\"offsetTransform\"\n    [style.zIndex]=\"nzZIndex\">\n    <div  class=\"ant-drawer-mask\" (click)=\"maskClick()\" *ngIf=\"nzMask\" [ngStyle]=\"nzMaskStyle\"></div>\n    <div class=\"ant-drawer-content-wrapper {{ nzWrapClassName }}\"\n         [style.width]=\"width\"\n         [style.height]=\"height\"\n         [style.transform]=\"transform\">\n      <div class=\"ant-drawer-content\">\n        <div class=\"ant-drawer-wrapper-body\"\n          [style.overflow]=\"isLeftOrRight ? 'auto' : null\"\n          [style.height]=\"isLeftOrRight ? '100%' : null\">\n          <div *ngIf=\"nzTitle\" class=\"ant-drawer-header\">\n            <div class=\"ant-drawer-title\">\n              <ng-container *nzStringTemplateOutlet=\"nzTitle\"><div [innerHTML]=\"nzTitle\"></div></ng-container>\n            </div>\n          </div>\n          <button *ngIf=\"nzClosable\" (click)=\"closeClick()\" aria-label=\"Close\" class=\"ant-drawer-close\">\n            <span class=\"ant-drawer-close-x\"><i nz-icon type=\"close\"></i></span>\n          </button>\n          <div class=\"ant-drawer-body\" [ngStyle]=\"nzBodyStyle\">\n            <ng-template cdkPortalOutlet></ng-template>\n            <ng-container *ngIf=\"isTemplateRef(nzContent)\">\n              <ng-container *ngTemplateOutlet=\"nzContent; context: templateContext\"></ng-container>\n            </ng-container>\n            <ng-content *ngIf=\"!nzContent\"></ng-content>\n          </div>\n        </div>\n      </div>\n    </div>\n  </div>\n</ng-template>",
                        preserveWhitespaces: false,
                        changeDetection: i0.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        NzDrawerComponent.ctorParameters = function () {
            return [
                { type: undefined, decorators: [{ type: i0.Optional }, { type: i0.Inject, args: [common.DOCUMENT,] }] },
                { type: i0.Renderer2 },
                { type: i1.Overlay },
                { type: i0.Injector },
                { type: i0.ChangeDetectorRef },
                { type: a11y.FocusTrapFactory },
                { type: i0.ViewContainerRef }
            ];
        };
        NzDrawerComponent.propDecorators = {
            nzContent: [{ type: i0.Input }],
            nzClosable: [{ type: i0.Input }],
            nzMaskClosable: [{ type: i0.Input }],
            nzMask: [{ type: i0.Input }],
            nzNoAnimation: [{ type: i0.Input }],
            nzTitle: [{ type: i0.Input }],
            nzPlacement: [{ type: i0.Input }],
            nzMaskStyle: [{ type: i0.Input }],
            nzBodyStyle: [{ type: i0.Input }],
            nzWrapClassName: [{ type: i0.Input }],
            nzWidth: [{ type: i0.Input }],
            nzHeight: [{ type: i0.Input }],
            nzZIndex: [{ type: i0.Input }],
            nzOffsetX: [{ type: i0.Input }],
            nzOffsetY: [{ type: i0.Input }],
            nzVisible: [{ type: i0.Input }],
            nzOnViewInit: [{ type: i0.Output }],
            nzOnClose: [{ type: i0.Output }],
            drawerTemplate: [{ type: i0.ViewChild, args: ['drawerTemplate',] }],
            contentTemplate: [{ type: i0.ViewChild, args: ['contentTemplate',] }],
            bodyPortalOutlet: [{ type: i0.ViewChild, args: [portal.CdkPortalOutlet,] }]
        };
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzDrawerComponent.prototype, "nzClosable", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzDrawerComponent.prototype, "nzMaskClosable", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzDrawerComponent.prototype, "nzMask", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzDrawerComponent.prototype, "nzNoAnimation", void 0);
        return NzDrawerComponent;
    }(NzDrawerRef));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * @template R
     */
    var /**
     * @template R
     */ DrawerBuilderForService = /** @class */ (function () {
        function DrawerBuilderForService(overlay, options) {
            var _this = this;
            this.overlay = overlay;
            this.options = options;
            this.unsubscribe$ = new rxjs.Subject();
            /**
             * pick {\@link NzDrawerOptions.nzOnCancel} and omit this option
             */
            var _a = this.options, nzOnCancel = _a.nzOnCancel, componentOption = __rest(_a, ["nzOnCancel"]);
            this.createDrawer();
            this.updateOptions(componentOption);
            // Prevent repeatedly open drawer when tap focus element.
            ( /** @type {?} */(this.drawerRef)).instance.savePreviouslyFocusedElement();
            ( /** @type {?} */(this.drawerRef)).instance.nzOnViewInit.pipe(operators.takeUntil(this.unsubscribe$)).subscribe(( /**
             * @return {?}
             */function () {
                ( /** @type {?} */(_this.drawerRef)).instance.open();
            }));
            ( /** @type {?} */(this.drawerRef)).instance.nzOnClose.subscribe(( /**
             * @return {?}
             */function () {
                if (nzOnCancel) {
                    nzOnCancel().then(( /**
                     * @param {?} canClose
                     * @return {?}
                     */function (canClose) {
                        if (canClose !== false) {
                            ( /** @type {?} */(_this.drawerRef)).instance.close();
                        }
                    }));
                }
                else {
                    ( /** @type {?} */(_this.drawerRef)).instance.close();
                }
            }));
            ( /** @type {?} */(this.drawerRef)).instance.afterClose.pipe(operators.takeUntil(this.unsubscribe$)).subscribe(( /**
             * @return {?}
             */function () {
                _this.overlayRef.dispose();
                _this.drawerRef = null;
                _this.unsubscribe$.next();
                _this.unsubscribe$.complete();
            }));
        }
        /**
         * @return {?}
         */
        DrawerBuilderForService.prototype.getInstance = /**
         * @return {?}
         */
            function () {
                return ( /** @type {?} */(this.drawerRef)) && ( /** @type {?} */(this.drawerRef)).instance;
            };
        /**
         * @return {?}
         */
        DrawerBuilderForService.prototype.createDrawer = /**
         * @return {?}
         */
            function () {
                this.overlayRef = this.overlay.create();
                this.drawerRef = this.overlayRef.attach(new portal.ComponentPortal(NzDrawerComponent));
            };
        /**
         * @param {?} options
         * @return {?}
         */
        DrawerBuilderForService.prototype.updateOptions = /**
         * @param {?} options
         * @return {?}
         */
            function (options) {
                Object.assign(( /** @type {?} */(this.drawerRef)).instance, options);
            };
        return DrawerBuilderForService;
    }());
    var NzDrawerService = /** @class */ (function () {
        function NzDrawerService(overlay) {
            this.overlay = overlay;
        }
        // tslint:disable-next-line:no-any
        // tslint:disable-next-line:no-any
        /**
         * @template T, D, R
         * @param {?} options
         * @return {?}
         */
        NzDrawerService.prototype.create =
            // tslint:disable-next-line:no-any
            /**
             * @template T, D, R
             * @param {?} options
             * @return {?}
             */
            function (options) {
                return new DrawerBuilderForService(this.overlay, options).getInstance();
            };
        NzDrawerService.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        NzDrawerService.ctorParameters = function () {
            return [
                { type: i1.Overlay }
            ];
        };
        /** @nocollapse */ NzDrawerService.ngInjectableDef = i0.defineInjectable({ factory: function NzDrawerService_Factory() { return new NzDrawerService(i0.inject(i1.Overlay)); }, token: NzDrawerService, providedIn: "root" });
        return NzDrawerService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzDrawerModule = /** @class */ (function () {
        function NzDrawerModule() {
        }
        NzDrawerModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, i1.OverlayModule, portal.PortalModule, icon.NzIconModule, core.NzAddOnModule, core.NzNoAnimationModule],
                        exports: [NzDrawerComponent],
                        declarations: [NzDrawerComponent],
                        entryComponents: [NzDrawerComponent],
                        providers: [NzDrawerService]
                    },] }
        ];
        return NzDrawerModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.DRAWER_ANIMATE_DURATION = DRAWER_ANIMATE_DURATION;
    exports.NzDrawerComponent = NzDrawerComponent;
    exports.NzDrawerModule = NzDrawerModule;
    exports.DrawerBuilderForService = DrawerBuilderForService;
    exports.NzDrawerService = NzDrawerService;
    exports.NzDrawerRef = NzDrawerRef;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-drawer.umd.js.map