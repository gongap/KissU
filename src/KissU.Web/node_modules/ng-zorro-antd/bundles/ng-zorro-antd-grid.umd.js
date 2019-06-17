(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs'), require('rxjs/operators'), require('ng-zorro-antd/core'), require('@angular/cdk/layout'), require('@angular/cdk/platform'), require('@angular/common'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/grid', ['exports', 'rxjs', 'rxjs/operators', 'ng-zorro-antd/core', '@angular/cdk/layout', '@angular/cdk/platform', '@angular/common', '@angular/core'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].grid = {}),global.rxjs,global.rxjs.operators,global['ng-zorro-antd'].core,global.ng.cdk.layout,global.ng.cdk.platform,global.ng.common,global.ng.core));
}(this, (function (exports,rxjs,operators,core,layout,platform,common,core$1) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @enum {number} */
    var Breakpoint = {
        'xxl': 0,
        'xl': 1,
        'lg': 2,
        'md': 3,
        'sm': 4,
        'xs': 5,
    };
    Breakpoint[Breakpoint['xxl']] = 'xxl';
    Breakpoint[Breakpoint['xl']] = 'xl';
    Breakpoint[Breakpoint['lg']] = 'lg';
    Breakpoint[Breakpoint['md']] = 'md';
    Breakpoint[Breakpoint['sm']] = 'sm';
    Breakpoint[Breakpoint['xs']] = 'xs';
    /** @type {?} */
    var responsiveMap = {
        xs: '(max-width: 575px)',
        sm: '(min-width: 576px)',
        md: '(min-width: 768px)',
        lg: '(min-width: 992px)',
        xl: '(min-width: 1200px)',
        xxl: '(min-width: 1600px)'
    };
    var NzRowDirective = /** @class */ (function () {
        function NzRowDirective(elementRef, renderer, nzUpdateHostClassService, mediaMatcher, ngZone, platform$$1) {
            this.elementRef = elementRef;
            this.renderer = renderer;
            this.nzUpdateHostClassService = nzUpdateHostClassService;
            this.mediaMatcher = mediaMatcher;
            this.ngZone = ngZone;
            this.platform = platform$$1;
            this.nzAlign = 'top';
            this.nzJustify = 'start';
            this.el = this.elementRef.nativeElement;
            this.prefixCls = 'ant-row';
            this.actualGutter$ = new rxjs.Subject();
            this.destroy$ = new rxjs.Subject();
        }
        /**
         * @return {?}
         */
        NzRowDirective.prototype.calculateGutter = /**
         * @return {?}
         */
            function () {
                if (typeof this.nzGutter !== 'object') {
                    return this.nzGutter;
                }
                else if (this.breakPoint && this.nzGutter[this.breakPoint]) {
                    return this.nzGutter[this.breakPoint];
                }
                else {
                    return 0;
                }
            };
        /**
         * @return {?}
         */
        NzRowDirective.prototype.updateGutter = /**
         * @return {?}
         */
            function () {
                /** @type {?} */
                var actualGutter = this.calculateGutter();
                if (this.actualGutter !== actualGutter) {
                    this.actualGutter = actualGutter;
                    this.actualGutter$.next(this.actualGutter);
                    this.renderer.setStyle(this.el, 'margin-left', "-" + this.actualGutter / 2 + "px");
                    this.renderer.setStyle(this.el, 'margin-right', "-" + this.actualGutter / 2 + "px");
                }
            };
        /**
         * @return {?}
         */
        NzRowDirective.prototype.watchMedia = /**
         * @return {?}
         */
            function () {
                var _this = this;
                // @ts-ignore
                Object.keys(responsiveMap).map(( /**
                 * @param {?} screen
                 * @return {?}
                 */function (screen) {
                    /** @type {?} */
                    var matchBelow = _this.mediaMatcher.matchMedia(responsiveMap[screen]).matches;
                    if (matchBelow) {
                        _this.breakPoint = screen;
                    }
                }));
                this.updateGutter();
            };
        /** temp solution since no method add classMap to host https://github.com/angular/angular/issues/7289*/
        /**
         * temp solution since no method add classMap to host https://github.com/angular/angular/issues/7289
         * @return {?}
         */
        NzRowDirective.prototype.setClassMap = /**
         * temp solution since no method add classMap to host https://github.com/angular/angular/issues/7289
         * @return {?}
         */
            function () {
                var _a;
                /** @type {?} */
                var classMap = (_a = {},
                    _a["" + this.prefixCls] = !this.nzType,
                    _a[this.prefixCls + "-" + this.nzType] = this.nzType,
                    _a[this.prefixCls + "-" + this.nzType + "-" + this.nzAlign] = this.nzType && this.nzAlign,
                    _a[this.prefixCls + "-" + this.nzType + "-" + this.nzJustify] = this.nzType && this.nzJustify,
                    _a);
                this.nzUpdateHostClassService.updateHostClass(this.el, classMap);
            };
        /**
         * @return {?}
         */
        NzRowDirective.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.setClassMap();
                this.watchMedia();
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzRowDirective.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (changes.nzType || changes.nzAlign || changes.nzJustify) {
                    this.setClassMap();
                }
                if (changes.nzGutter) {
                    this.updateGutter();
                }
            };
        /**
         * @return {?}
         */
        NzRowDirective.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                if (this.platform.isBrowser) {
                    this.ngZone.runOutsideAngular(( /**
                     * @return {?}
                     */function () {
                        rxjs.fromEvent(window, 'resize')
                            .pipe(operators.auditTime(16), operators.takeUntil(_this.destroy$))
                            .subscribe(( /**
                     * @return {?}
                     */function () { return _this.watchMedia(); }));
                    }));
                }
            };
        /**
         * @return {?}
         */
        NzRowDirective.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.destroy$.next();
                this.destroy$.complete();
            };
        NzRowDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: '[nz-row],nz-row',
                        exportAs: 'nzRow',
                        providers: [core.NzUpdateHostClassService]
                    },] }
        ];
        /** @nocollapse */
        NzRowDirective.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.Renderer2 },
                { type: core.NzUpdateHostClassService },
                { type: layout.MediaMatcher },
                { type: core$1.NgZone },
                { type: platform.Platform }
            ];
        };
        NzRowDirective.propDecorators = {
            nzType: [{ type: core$1.Input }],
            nzAlign: [{ type: core$1.Input }],
            nzJustify: [{ type: core$1.Input }],
            nzGutter: [{ type: core$1.Input }]
        };
        return NzRowDirective;
    }());

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
    var __assign = function () {
        __assign = Object.assign || function __assign(t) {
            for (var s, i = 1, n = arguments.length; i < n; i++) {
                s = arguments[i];
                for (var p in s)
                    if (Object.prototype.hasOwnProperty.call(s, p))
                        t[p] = s[p];
            }
            return t;
        };
        return __assign.apply(this, arguments);
    };

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzColDirective = /** @class */ (function () {
        function NzColDirective(nzUpdateHostClassService, elementRef, nzRowDirective, renderer) {
            this.nzUpdateHostClassService = nzUpdateHostClassService;
            this.elementRef = elementRef;
            this.nzRowDirective = nzRowDirective;
            this.renderer = renderer;
            this.el = this.elementRef.nativeElement;
            this.prefixCls = 'ant-col';
            this.destroy$ = new rxjs.Subject();
        }
        /** temp solution since no method add classMap to host https://github.com/angular/angular/issues/7289*/
        // tslint:disable-line:no-any
        /**
         * temp solution since no method add classMap to host https://github.com/angular/angular/issues/7289
         * @return {?}
         */
        NzColDirective.prototype.setClassMap =
            // tslint:disable-line:no-any
            /**
             * temp solution since no method add classMap to host https://github.com/angular/angular/issues/7289
             * @return {?}
             */
            function () {
                var _a;
                /** @type {?} */
                var classMap = __assign((_a = {}, _a[this.prefixCls + "-" + this.nzSpan] = core.isNotNil(this.nzSpan), _a[this.prefixCls + "-order-" + this.nzOrder] = core.isNotNil(this.nzOrder), _a[this.prefixCls + "-offset-" + this.nzOffset] = core.isNotNil(this.nzOffset), _a[this.prefixCls + "-pull-" + this.nzPull] = core.isNotNil(this.nzPull), _a[this.prefixCls + "-push-" + this.nzPush] = core.isNotNil(this.nzPush), _a), this.generateClass());
                this.nzUpdateHostClassService.updateHostClass(this.el, classMap);
            };
        /**
         * @return {?}
         */
        NzColDirective.prototype.generateClass = /**
         * @return {?}
         */
            function () {
                var _this = this;
                /** @type {?} */
                var listOfSizeInputName = ['nzXs', 'nzSm', 'nzMd', 'nzLg', 'nzXl', 'nzXXl'];
                /** @type {?} */
                var listClassMap = {};
                listOfSizeInputName.forEach(( /**
                 * @param {?} name
                 * @return {?}
                 */function (name) {
                    /** @type {?} */
                    var sizeName = name.replace('nz', '').toLowerCase();
                    if (core.isNotNil(_this[name])) {
                        if (typeof _this[name] === 'number' || typeof _this[name] === 'string') {
                            listClassMap[_this.prefixCls + "-" + sizeName + "-" + _this[name]] = true;
                        }
                        else {
                            listClassMap[_this.prefixCls + "-" + sizeName + "-" + _this[name].span] = _this[name] && core.isNotNil(_this[name].span);
                            listClassMap[_this.prefixCls + "-" + sizeName + "-pull-" + _this[name].pull] =
                                _this[name] && core.isNotNil(_this[name].pull);
                            listClassMap[_this.prefixCls + "-" + sizeName + "-push-" + _this[name].push] =
                                _this[name] && core.isNotNil(_this[name].push);
                            listClassMap[_this.prefixCls + "-" + sizeName + "-offset-" + _this[name].offset] =
                                _this[name] && core.isNotNil(_this[name].offset);
                            listClassMap[_this.prefixCls + "-" + sizeName + "-order-" + _this[name].order] =
                                _this[name] && core.isNotNil(_this[name].order);
                        }
                    }
                }));
                return listClassMap;
            };
        /**
         * @return {?}
         */
        NzColDirective.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                this.setClassMap();
            };
        /**
         * @return {?}
         */
        NzColDirective.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                if (this.nzRowDirective) {
                    this.nzRowDirective.actualGutter$
                        .pipe(operators.startWith(this.nzRowDirective.actualGutter), operators.takeUntil(this.destroy$))
                        .subscribe(( /**
                 * @param {?} actualGutter
                 * @return {?}
                 */function (actualGutter) {
                        _this.renderer.setStyle(_this.el, 'padding-left', actualGutter / 2 + "px");
                        _this.renderer.setStyle(_this.el, 'padding-right', actualGutter / 2 + "px");
                    }));
                }
            };
        /**
         * @return {?}
         */
        NzColDirective.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.setClassMap();
            };
        /**
         * @return {?}
         */
        NzColDirective.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.destroy$.next();
                this.destroy$.complete();
            };
        NzColDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: '[nz-col],nz-col',
                        exportAs: 'nzCol',
                        providers: [core.NzUpdateHostClassService]
                    },] }
        ];
        /** @nocollapse */
        NzColDirective.ctorParameters = function () {
            return [
                { type: core.NzUpdateHostClassService },
                { type: core$1.ElementRef },
                { type: NzRowDirective, decorators: [{ type: core$1.Optional }, { type: core$1.Host }] },
                { type: core$1.Renderer2 }
            ];
        };
        NzColDirective.propDecorators = {
            nzSpan: [{ type: core$1.Input }],
            nzOrder: [{ type: core$1.Input }],
            nzOffset: [{ type: core$1.Input }],
            nzPush: [{ type: core$1.Input }],
            nzPull: [{ type: core$1.Input }],
            nzXs: [{ type: core$1.Input }],
            nzSm: [{ type: core$1.Input }],
            nzMd: [{ type: core$1.Input }],
            nzLg: [{ type: core$1.Input }],
            nzXl: [{ type: core$1.Input }],
            nzXXl: [{ type: core$1.Input }]
        };
        return NzColDirective;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzGridModule = /** @class */ (function () {
        function NzGridModule() {
        }
        NzGridModule.decorators = [
            { type: core$1.NgModule, args: [{
                        declarations: [NzColDirective, NzRowDirective],
                        exports: [NzColDirective, NzRowDirective],
                        imports: [common.CommonModule, layout.LayoutModule, platform.PlatformModule]
                    },] }
        ];
        return NzGridModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.Breakpoint = Breakpoint;
    exports.NzRowDirective = NzRowDirective;
    exports.NzColDirective = NzColDirective;
    exports.NzGridModule = NzGridModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-grid.umd.js.map