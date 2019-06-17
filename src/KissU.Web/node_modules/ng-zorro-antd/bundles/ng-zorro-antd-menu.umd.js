(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/cdk/platform'), require('rxjs'), require('rxjs/operators'), require('@angular/cdk/overlay'), require('@angular/common'), require('@angular/core'), require('@angular/forms'), require('ng-zorro-antd/button'), require('ng-zorro-antd/core'), require('ng-zorro-antd/icon')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/menu', ['exports', '@angular/cdk/platform', 'rxjs', 'rxjs/operators', '@angular/cdk/overlay', '@angular/common', '@angular/core', '@angular/forms', 'ng-zorro-antd/button', 'ng-zorro-antd/core', 'ng-zorro-antd/icon'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].menu = {}),global.ng.cdk.platform,global.rxjs,global.rxjs.operators,global.ng.cdk.overlay,global.ng.common,global.ng.core,global.ng.forms,global['ng-zorro-antd'].button,global['ng-zorro-antd'].core,global['ng-zorro-antd'].icon));
}(this, (function (exports,platform,rxjs,operators,overlay,common,core,forms,button,core$1,icon) { 'use strict';

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
    var NzMenuService = /** @class */ (function (_super) {
        __extends(NzMenuService, _super);
        function NzMenuService() {
            var _this = _super !== null && _super.apply(this, arguments) || this;
            _this.isInDropDown = false;
            return _this;
        }
        NzMenuService.decorators = [
            { type: core.Injectable }
        ];
        return NzMenuService;
    }(core$1.NzMenuBaseService));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzSubmenuService = /** @class */ (function () {
        function NzSubmenuService(nzHostSubmenuService, nzMenuService) {
            var _this = this;
            this.nzHostSubmenuService = nzHostSubmenuService;
            this.nzMenuService = nzMenuService;
            this.disabled = false;
            this.mode = 'vertical';
            this.mode$ = this.nzMenuService.mode$.pipe(operators.map(( /**
             * @param {?} mode
             * @return {?}
             */function (mode) {
                if (mode === 'inline') {
                    return 'inline';
                }
                else if (mode === 'vertical' || _this.nzHostSubmenuService) {
                    return 'vertical';
                }
                else {
                    return 'horizontal';
                }
            })), operators.tap(( /**
             * @param {?} mode
             * @return {?}
             */function (mode) { return (_this.mode = ( /** @type {?} */(mode))); })));
            this.level = 1;
            this.level$ = new rxjs.BehaviorSubject(1);
            this.subMenuOpen$ = new rxjs.BehaviorSubject(false);
            this.open$ = new rxjs.BehaviorSubject(false);
            this.mouseEnterLeave$ = new rxjs.Subject();
            this.menuOpen$ = rxjs.combineLatest(this.subMenuOpen$, this.mouseEnterLeave$).pipe(operators.map(( /**
             * @param {?} value
             * @return {?}
             */function (value) { return value[0] || value[1]; })), operators.auditTime(150), operators.distinctUntilChanged(), operators.tap(( /**
             * @param {?} data
             * @return {?}
             */function (data) {
                _this.setOpenState(data);
                if (_this.nzHostSubmenuService) {
                    _this.nzHostSubmenuService.subMenuOpen$.next(data);
                }
            })));
            if (this.nzHostSubmenuService) {
                this.setLevel(this.nzHostSubmenuService.level + 1);
            }
        }
        /**
         * @param {?} value
         * @return {?}
         */
        NzSubmenuService.prototype.setOpenState = /**
         * @param {?} value
         * @return {?}
         */
            function (value) {
                this.open$.next(value);
            };
        /**
         * @return {?}
         */
        NzSubmenuService.prototype.onMenuItemClick = /**
         * @return {?}
         */
            function () {
                this.setMouseEnterState(false);
            };
        /**
         * @param {?} value
         * @return {?}
         */
        NzSubmenuService.prototype.setLevel = /**
         * @param {?} value
         * @return {?}
         */
            function (value) {
                this.level$.next(value);
                this.level = value;
            };
        /**
         * @param {?} value
         * @return {?}
         */
        NzSubmenuService.prototype.setMouseEnterState = /**
         * @param {?} value
         * @return {?}
         */
            function (value) {
                if ((this.mode === 'horizontal' || this.mode === 'vertical' || this.nzMenuService.isInDropDown) && !this.disabled) {
                    this.mouseEnterLeave$.next(value);
                }
            };
        NzSubmenuService.decorators = [
            { type: core.Injectable }
        ];
        /** @nocollapse */
        NzSubmenuService.ctorParameters = function () {
            return [
                { type: NzSubmenuService, decorators: [{ type: core.SkipSelf }, { type: core.Optional }] },
                { type: NzMenuService }
            ];
        };
        return NzSubmenuService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzMenuItemDirective = /** @class */ (function () {
        function NzMenuItemDirective(nzUpdateHostClassService, nzMenuService, nzSubmenuService, renderer, elementRef) {
            this.nzUpdateHostClassService = nzUpdateHostClassService;
            this.nzMenuService = nzMenuService;
            this.nzSubmenuService = nzSubmenuService;
            this.renderer = renderer;
            this.elementRef = elementRef;
            this.el = this.elementRef.nativeElement;
            this.destroy$ = new rxjs.Subject();
            this.originalPadding = null;
            this.selected$ = new rxjs.Subject();
            this.nzDisabled = false;
            this.nzSelected = false;
        }
        /** clear all item selected status except this */
        /**
         * clear all item selected status except this
         * @param {?} e
         * @return {?}
         */
        NzMenuItemDirective.prototype.clickMenuItem = /**
         * clear all item selected status except this
         * @param {?} e
         * @return {?}
         */
            function (e) {
                if (this.nzDisabled) {
                    e.preventDefault();
                    e.stopPropagation();
                    return;
                }
                this.nzMenuService.onMenuItemClick(this);
                if (this.nzSubmenuService) {
                    this.nzSubmenuService.onMenuItemClick();
                }
            };
        /**
         * @return {?}
         */
        NzMenuItemDirective.prototype.setClassMap = /**
         * @return {?}
         */
            function () {
                var _a;
                /** @type {?} */
                var prefixName = this.nzMenuService.isInDropDown ? 'ant-dropdown-menu-item' : 'ant-menu-item';
                this.nzUpdateHostClassService.updateHostClass(this.el, (_a = {},
                    _a["" + prefixName] = true,
                    _a[prefixName + "-selected"] = this.nzSelected,
                    _a[prefixName + "-disabled"] = this.nzDisabled,
                    _a));
            };
        /**
         * @param {?} value
         * @return {?}
         */
        NzMenuItemDirective.prototype.setSelectedState = /**
         * @param {?} value
         * @return {?}
         */
            function (value) {
                this.nzSelected = value;
                this.selected$.next(value);
                this.setClassMap();
            };
        /**
         * @return {?}
         */
        NzMenuItemDirective.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                /**
                 * store origin padding in padding
                 * @type {?}
                 */
                var paddingLeft = this.el.style.paddingLeft;
                if (paddingLeft) {
                    this.originalPadding = parseInt(paddingLeft, 10);
                }
                rxjs.merge(this.nzMenuService.mode$, this.nzMenuService.inlineIndent$, this.nzSubmenuService ? this.nzSubmenuService.level$ : rxjs.EMPTY)
                    .pipe(operators.takeUntil(this.destroy$))
                    .subscribe(( /**
             * @return {?}
             */function () {
                    /** @type {?} */
                    var padding = null;
                    if (_this.nzMenuService.mode === 'inline') {
                        if (core$1.isNotNil(_this.nzPaddingLeft)) {
                            padding = _this.nzPaddingLeft;
                        }
                        else {
                            /** @type {?} */
                            var level = _this.nzSubmenuService ? _this.nzSubmenuService.level + 1 : 1;
                            padding = level * _this.nzMenuService.inlineIndent;
                        }
                    }
                    else {
                        padding = _this.originalPadding;
                    }
                    if (padding) {
                        _this.renderer.setStyle(_this.el, 'padding-left', padding + "px");
                    }
                    else {
                        _this.renderer.removeStyle(_this.el, 'padding-left');
                    }
                }));
                this.setClassMap();
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzMenuItemDirective.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (changes.nzSelected) {
                    this.setSelectedState(this.nzSelected);
                }
                if (changes.nzDisabled) {
                    this.setClassMap();
                }
            };
        /**
         * @return {?}
         */
        NzMenuItemDirective.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.destroy$.next();
                this.destroy$.complete();
            };
        NzMenuItemDirective.decorators = [
            { type: core.Directive, args: [{
                        selector: '[nz-menu-item]',
                        exportAs: 'nzMenuItem',
                        providers: [core$1.NzUpdateHostClassService],
                        host: {
                            '(click)': 'clickMenuItem($event)'
                        }
                    },] }
        ];
        /** @nocollapse */
        NzMenuItemDirective.ctorParameters = function () {
            return [
                { type: core$1.NzUpdateHostClassService },
                { type: core$1.NzMenuBaseService },
                { type: NzSubmenuService, decorators: [{ type: core.Optional }] },
                { type: core.Renderer2 },
                { type: core.ElementRef }
            ];
        };
        NzMenuItemDirective.propDecorators = {
            nzPaddingLeft: [{ type: core.Input }],
            nzDisabled: [{ type: core.Input }],
            nzSelected: [{ type: core.Input }]
        };
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzMenuItemDirective.prototype, "nzDisabled", void 0);
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzMenuItemDirective.prototype, "nzSelected", void 0);
        return NzMenuItemDirective;
    }());

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
    /**
     * @param {?} higherOrderService
     * @param {?} menuService
     * @return {?}
     */
    function NzMenuServiceFactory(higherOrderService, menuService) {
        return higherOrderService ? higherOrderService : menuService;
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzSubMenuComponent = /** @class */ (function () {
        function NzSubMenuComponent(elementRef, nzMenuService, cdr, nzSubmenuService, nzUpdateHostClassService, platform$$1, noAnimation) {
            this.elementRef = elementRef;
            this.nzMenuService = nzMenuService;
            this.cdr = cdr;
            this.nzSubmenuService = nzSubmenuService;
            this.nzUpdateHostClassService = nzUpdateHostClassService;
            this.platform = platform$$1;
            this.noAnimation = noAnimation;
            this.nzOpen = false;
            this.nzDisabled = false;
            this.nzOpenChange = new core.EventEmitter();
            this.placement = 'rightTop';
            this.expandState = 'collapsed';
            this.overlayPositions = __spread(core$1.DEFAULT_SUBMENU_POSITIONS);
            this.destroy$ = new rxjs.Subject();
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
                this.placement = ( /** @type {?} */(core$1.getPlacementName(position)));
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
                rxjs.combineLatest(this.nzSubmenuService.mode$, this.nzSubmenuService.open$)
                    .pipe(operators.takeUntil(this.destroy$))
                    .subscribe(( /**
             * @param {?} data
             * @return {?}
             */function (data) {
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
                        mode === 'horizontal' ? [core$1.POSITION_MAP.bottomLeft] : [core$1.POSITION_MAP.rightTop, core$1.POSITION_MAP.leftTop];
                    if (open !== _this.nzOpen) {
                        _this.nzOpen = open;
                        _this.nzOpenChange.emit(_this.nzOpen);
                    }
                    _this.setClassMap();
                    _this.setTriggerWidth();
                }));
                this.nzSubmenuService.menuOpen$.pipe(operators.takeUntil(this.destroy$)).subscribe(( /**
                 * @param {?} data
                 * @return {?}
                 */function (data) {
                    _this.nzMenuService.menuOpen$.next(data);
                }));
                rxjs.merge(this.nzMenuService.mode$, this.nzMenuService.inlineIndent$, this.nzSubmenuService.level$, this.nzSubmenuService.open$, this.nzSubmenuService.mode$)
                    .pipe(operators.takeUntil(this.destroy$))
                    .subscribe(( /**
             * @return {?}
             */function () {
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
                    .pipe(operators.startWith(true), operators.flatMap(( /**
             * @return {?}
             */function () {
                    return rxjs.merge.apply(void 0, __spread([_this.listOfNzMenuItemDirective.changes], _this.listOfNzMenuItemDirective.map(( /**
                     * @param {?} menu
                     * @return {?}
                     */function (menu) { return menu.selected$; }))));
                })), operators.map(( /**
                 * @return {?}
                 */function () {
                    return _this.listOfNzMenuItemDirective.some(( /**
                     * @param {?} e
                     * @return {?}
                     */function (e) { return e.nzSelected; }));
                })), operators.takeUntil(this.destroy$))
                    .subscribe(( /**
             * @param {?} selected
             * @return {?}
             */function (selected) {
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
            { type: core.Component, args: [{
                        selector: '[nz-submenu]',
                        exportAs: 'nzSubmenu',
                        providers: [NzSubmenuService, core$1.NzUpdateHostClassService],
                        animations: [core$1.collapseMotion, core$1.zoomBigMotion, core$1.slideMotion],
                        encapsulation: core.ViewEncapsulation.None,
                        changeDetection: core.ChangeDetectionStrategy.OnPush,
                        preserveWhitespaces: false,
                        template: "<div cdkOverlayOrigin\n  #origin=\"cdkOverlayOrigin\"\n  [class.ant-dropdown-menu-submenu-title]=\"nzMenuService.isInDropDown\"\n  [class.ant-menu-submenu-title]=\"!nzMenuService.isInDropDown\"\n  [style.paddingLeft.px]=\"nzMenuService.mode === 'inline'? (nzPaddingLeft ? nzPaddingLeft : nzSubmenuService.level * nzMenuService.inlineIndent) : null\"\n  (mouseenter)=\"setMouseEnterState(true)\"\n  (mouseleave)=\"setMouseEnterState(false)\"\n  (click)=\"clickSubMenuTitle()\">\n  <ng-content select=\"[title]\"></ng-content>\n  <span *ngIf=\"nzMenuService.isInDropDown; else notDropdownTpl\" class=\"ant-dropdown-menu-submenu-arrow\">\n    <i nz-icon type=\"right\" class=\"anticon-right ant-dropdown-menu-submenu-arrow-icon\"></i>\n  </span>\n  <ng-template #notDropdownTpl><i class=\"ant-menu-submenu-arrow\"></i></ng-template>\n</div>\n<ul *ngIf=\"nzMenuService.mode === 'inline'\"\n  [@collapseMotion]=\"expandState\"\n  [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n  [ngClass]=\"nzMenuClassName\"\n  class=\"ant-menu ant-menu-inline ant-menu-sub\">\n  <ng-template [ngTemplateOutlet]=\"subMenuTemplate\"></ng-template>\n</ul>\n<ng-template cdkConnectedOverlay\n  (positionChange)=\"onPositionChange($event)\"\n  [cdkConnectedOverlayPositions]=\"overlayPositions\"\n  [cdkConnectedOverlayOrigin]=\"origin\"\n  [cdkConnectedOverlayWidth]=\"triggerWidth\"\n  [cdkConnectedOverlayOpen]=\"nzOpen && nzMenuService.mode !== 'inline'\">\n  <div class=\"ant-menu-submenu ant-menu-submenu-popup\"\n    [@slideMotion]=\"expandState\"\n    [@zoomBigMotion]=\"expandState\"\n    [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n    [class.ant-menu-light]=\"nzMenuService.theme === 'light'\"\n    [class.ant-menu-dark]=\"nzMenuService.theme === 'dark'\"\n    [class.ant-menu-submenu-placement-bottomLeft]=\"nzSubmenuService.mode === 'horizontal'\"\n    [class.ant-menu-submenu-placement-rightTop]=\"nzSubmenuService.mode === 'vertical' && placement === 'rightTop'\"\n    [class.ant-menu-submenu-placement-leftTop]=\"nzSubmenuService.mode === 'vertical' && placement === 'leftTop'\"\n    (mouseleave)=\"setMouseEnterState(false)\"\n    (mouseenter)=\"setMouseEnterState(true)\">\n    <ul [class.ant-dropdown-menu]=\"nzMenuService.isInDropDown\"\n      [class.ant-menu]=\"!nzMenuService.isInDropDown\"\n      [class.ant-dropdown-menu-vertical]=\"nzMenuService.isInDropDown\"\n      [class.ant-menu-vertical]=\"!nzMenuService.isInDropDown\"\n      [class.ant-dropdown-menu-sub]=\"nzMenuService.isInDropDown\"\n      [class.ant-menu-sub]=\"!nzMenuService.isInDropDown\"\n      [ngClass]=\"nzMenuClassName\">\n      <ng-template [ngTemplateOutlet]=\"subMenuTemplate\"></ng-template>\n    </ul>\n  </div>\n</ng-template>\n\n<ng-template #subMenuTemplate>\n  <ng-content></ng-content>\n</ng-template>",
                        styles: ["\n      .ant-menu-submenu-placement-bottomLeft {\n        top: 6px;\n        position: relative;\n      }\n\n      .ant-menu-submenu-placement-rightTop {\n        left: 4px;\n        position: relative;\n      }\n\n      .ant-menu-submenu-placement-leftTop {\n        right: 4px;\n        position: relative;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzSubMenuComponent.ctorParameters = function () {
            return [
                { type: core.ElementRef },
                { type: core$1.NzMenuBaseService },
                { type: core.ChangeDetectorRef },
                { type: NzSubmenuService },
                { type: core$1.NzUpdateHostClassService },
                { type: platform.Platform },
                { type: core$1.NzNoAnimationDirective, decorators: [{ type: core.Host }, { type: core.Optional }] }
            ];
        };
        NzSubMenuComponent.propDecorators = {
            nzMenuClassName: [{ type: core.Input }],
            nzPaddingLeft: [{ type: core.Input }],
            nzOpen: [{ type: core.Input }],
            nzDisabled: [{ type: core.Input }],
            nzOpenChange: [{ type: core.Output }],
            cdkConnectedOverlay: [{ type: core.ViewChild, args: [overlay.CdkConnectedOverlay,] }],
            cdkOverlayOrigin: [{ type: core.ViewChild, args: [overlay.CdkOverlayOrigin, { read: core.ElementRef },] }],
            listOfNzSubMenuComponent: [{ type: core.ContentChildren, args: [NzSubMenuComponent, { descendants: true },] }],
            listOfNzMenuItemDirective: [{ type: core.ContentChildren, args: [NzMenuItemDirective, { descendants: true },] }]
        };
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzSubMenuComponent.prototype, "nzOpen", void 0);
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzSubMenuComponent.prototype, "nzDisabled", void 0);
        return NzSubMenuComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ɵ0 = NzMenuServiceFactory;
    var NzMenuDirective = /** @class */ (function () {
        function NzMenuDirective(elementRef, nzMenuService, nzUpdateHostClassService) {
            this.elementRef = elementRef;
            this.nzMenuService = nzMenuService;
            this.nzUpdateHostClassService = nzUpdateHostClassService;
            this.destroy$ = new rxjs.Subject();
            this.listOfOpenedNzSubMenuComponent = [];
            this.nzInlineIndent = 24;
            this.nzTheme = 'light';
            this.nzMode = 'vertical';
            this.nzInDropDown = false;
            this.nzInlineCollapsed = false;
            this.nzSelectable = !this.nzMenuService.isInDropDown;
            this.nzClick = new core.EventEmitter();
        }
        /**
         * @return {?}
         */
        NzMenuDirective.prototype.updateInlineCollapse = /**
         * @return {?}
         */
            function () {
                if (this.listOfNzMenuItemDirective) {
                    if (this.nzInlineCollapsed) {
                        this.listOfOpenedNzSubMenuComponent = this.listOfNzSubMenuComponent.filter(( /**
                         * @param {?} submenu
                         * @return {?}
                         */function (submenu) { return submenu.nzOpen; }));
                        this.listOfNzSubMenuComponent.forEach(( /**
                         * @param {?} submenu
                         * @return {?}
                         */function (submenu) { return submenu.setOpenState(false); }));
                        this.nzMode = 'vertical';
                    }
                    else {
                        this.listOfOpenedNzSubMenuComponent.forEach(( /**
                         * @param {?} submenu
                         * @return {?}
                         */function (submenu) { return submenu.setOpenState(true); }));
                        this.listOfOpenedNzSubMenuComponent = [];
                        this.nzMode = this.cacheMode;
                    }
                    this.nzMenuService.setMode(this.nzMode);
                }
            };
        /**
         * @return {?}
         */
        NzMenuDirective.prototype.setClassMap = /**
         * @return {?}
         */
            function () {
                var _a;
                /** @type {?} */
                var prefixName = this.nzMenuService.isInDropDown ? 'ant-dropdown-menu' : 'ant-menu';
                this.nzUpdateHostClassService.updateHostClass(this.elementRef.nativeElement, (_a = {},
                    _a["" + prefixName] = true,
                    _a[prefixName + "-root"] = true,
                    _a[prefixName + "-" + this.nzTheme] = true,
                    _a[prefixName + "-" + this.nzMode] = true,
                    _a[prefixName + "-inline-collapsed"] = this.nzInlineCollapsed,
                    _a));
            };
        /**
         * @return {?}
         */
        NzMenuDirective.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.setClassMap();
                this.nzMenuService.menuItemClick$.pipe(operators.takeUntil(this.destroy$)).subscribe(( /**
                 * @param {?} menu
                 * @return {?}
                 */function (menu) {
                    _this.nzClick.emit(menu);
                    if (_this.nzSelectable) {
                        _this.listOfNzMenuItemDirective.forEach(( /**
                         * @param {?} item
                         * @return {?}
                         */function (item) { return item.setSelectedState(item === menu); }));
                    }
                }));
            };
        /**
         * @return {?}
         */
        NzMenuDirective.prototype.ngAfterContentInit = /**
         * @return {?}
         */
            function () {
                this.cacheMode = this.nzMode;
                this.updateInlineCollapse();
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzMenuDirective.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (changes.nzInlineCollapsed) {
                    this.updateInlineCollapse();
                }
                if (changes.nzInlineIndent) {
                    this.nzMenuService.setInlineIndent(this.nzInlineIndent);
                }
                if (changes.nzInDropDown) {
                    this.nzMenuService.isInDropDown = this.nzInDropDown;
                }
                if (changes.nzTheme) {
                    this.nzMenuService.setTheme(this.nzTheme);
                }
                if (changes.nzMode) {
                    this.nzMenuService.setMode(this.nzMode);
                    if (!changes.nzMode.isFirstChange() && this.listOfNzSubMenuComponent) {
                        this.listOfNzSubMenuComponent.forEach(( /**
                         * @param {?} submenu
                         * @return {?}
                         */function (submenu) { return submenu.setOpenState(false); }));
                    }
                }
                if (changes.nzTheme || changes.nzMode || changes.nzInlineCollapsed) {
                    this.setClassMap();
                }
            };
        /**
         * @return {?}
         */
        NzMenuDirective.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.destroy$.next();
                this.destroy$.complete();
            };
        NzMenuDirective.decorators = [
            { type: core.Directive, args: [{
                        selector: '[nz-menu]',
                        exportAs: 'nzMenu',
                        providers: [
                            core$1.NzUpdateHostClassService,
                            NzMenuService,
                            {
                                provide: core$1.NzMenuBaseService,
                                useFactory: ɵ0,
                                deps: [[new core.SkipSelf(), new core.Optional(), core$1.NzDropdownHigherOrderServiceToken], NzMenuService]
                            }
                        ]
                    },] }
        ];
        /** @nocollapse */
        NzMenuDirective.ctorParameters = function () {
            return [
                { type: core.ElementRef },
                { type: core$1.NzMenuBaseService },
                { type: core$1.NzUpdateHostClassService }
            ];
        };
        NzMenuDirective.propDecorators = {
            listOfNzMenuItemDirective: [{ type: core.ContentChildren, args: [NzMenuItemDirective, { descendants: true },] }],
            listOfNzSubMenuComponent: [{ type: core.ContentChildren, args: [NzSubMenuComponent, { descendants: true },] }],
            nzInlineIndent: [{ type: core.Input }],
            nzTheme: [{ type: core.Input }],
            nzMode: [{ type: core.Input }],
            nzInDropDown: [{ type: core.Input }],
            nzInlineCollapsed: [{ type: core.Input }],
            nzSelectable: [{ type: core.Input }],
            nzClick: [{ type: core.Output }]
        };
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzMenuDirective.prototype, "nzInDropDown", void 0);
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzMenuDirective.prototype, "nzInlineCollapsed", void 0);
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzMenuDirective.prototype, "nzSelectable", void 0);
        return NzMenuDirective;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzMenuGroupComponent = /** @class */ (function () {
        function NzMenuGroupComponent(elementRef, renderer) {
            this.elementRef = elementRef;
            this.renderer = renderer;
            this.renderer.addClass(elementRef.nativeElement, 'ant-menu-item-group');
        }
        NzMenuGroupComponent.decorators = [
            { type: core.Component, args: [{
                        selector: '[nz-menu-group]',
                        exportAs: 'nzMenuGroup',
                        changeDetection: core.ChangeDetectionStrategy.OnPush,
                        encapsulation: core.ViewEncapsulation.None,
                        template: "<div class=\"ant-menu-item-group-title\">\n  <ng-content select=\"[title]\"></ng-content>\n</div>\n<ul class=\"ant-menu-item-group-list\">\n  <ng-content></ng-content>\n</ul>",
                        preserveWhitespaces: false
                    }] }
        ];
        /** @nocollapse */
        NzMenuGroupComponent.ctorParameters = function () {
            return [
                { type: core.ElementRef },
                { type: core.Renderer2 }
            ];
        };
        return NzMenuGroupComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzMenuDividerDirective = /** @class */ (function () {
        function NzMenuDividerDirective(elementRef, renderer) {
            this.elementRef = elementRef;
            this.renderer = renderer;
            this.renderer.addClass(elementRef.nativeElement, 'ant-dropdown-menu-item-divider');
        }
        NzMenuDividerDirective.decorators = [
            { type: core.Directive, args: [{
                        selector: '[nz-menu-divider]',
                        exportAs: 'nzMenuDivider'
                    },] }
        ];
        /** @nocollapse */
        NzMenuDividerDirective.ctorParameters = function () {
            return [
                { type: core.ElementRef },
                { type: core.Renderer2 }
            ];
        };
        return NzMenuDividerDirective;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzMenuModule = /** @class */ (function () {
        function NzMenuModule() {
        }
        NzMenuModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, forms.FormsModule, button.NzButtonModule, overlay.OverlayModule, icon.NzIconModule, core$1.NzNoAnimationModule],
                        declarations: [
                            NzMenuDirective,
                            NzMenuItemDirective,
                            NzSubMenuComponent,
                            NzMenuDividerDirective,
                            NzMenuGroupComponent
                        ],
                        exports: [NzMenuDirective, NzMenuItemDirective, NzSubMenuComponent, NzMenuDividerDirective, NzMenuGroupComponent]
                    },] }
        ];
        return NzMenuModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzMenuDirective = NzMenuDirective;
    exports.NzMenuGroupComponent = NzMenuGroupComponent;
    exports.NzMenuDividerDirective = NzMenuDividerDirective;
    exports.NzMenuItemDirective = NzMenuItemDirective;
    exports.NzSubMenuComponent = NzSubMenuComponent;
    exports.NzMenuModule = NzMenuModule;
    exports.NzMenuService = NzMenuService;
    exports.NzSubmenuService = NzSubmenuService;
    exports.NzMenuServiceFactory = NzMenuServiceFactory;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-menu.umd.js.map