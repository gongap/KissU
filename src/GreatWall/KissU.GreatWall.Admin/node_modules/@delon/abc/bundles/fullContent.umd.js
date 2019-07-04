/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/router'), require('rxjs'), require('rxjs/operators'), require('@angular/common'), require('@angular/core'), require('@delon/util')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/full-content', ['exports', '@angular/router', 'rxjs', 'rxjs/operators', '@angular/common', '@angular/core', '@delon/util'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['full-content'] = {}),global.ng.router,global.rxjs,global.rxjs.operators,global.ng.common,global.ng.core,global.delon.util));
}(this, (function (exports,router,rxjs,operators,common,i0,util) { 'use strict';

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
    var FullContentService = /** @class */ (function () {
        function FullContentService() {
            this._change = new rxjs.BehaviorSubject(null);
        }
        /** 切换全屏工作区状态 */
        /**
         * 切换全屏工作区状态
         * @return {?}
         */
        FullContentService.prototype.toggle = /**
         * 切换全屏工作区状态
         * @return {?}
         */
            function () {
                this._change.next(true);
            };
        Object.defineProperty(FullContentService.prototype, "change", {
            get: /**
             * @return {?}
             */ function () {
                return this._change.pipe(operators.share());
            },
            enumerable: true,
            configurable: true
        });
        FullContentService.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ FullContentService.ngInjectableDef = i0.defineInjectable({ factory: function FullContentService_Factory() { return new FullContentService(); }, token: FullContentService, providedIn: "root" });
        return FullContentService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var wrapCls = "full-content__body";
    /** @type {?} */
    var openedCls = "full-content__opened";
    /** @type {?} */
    var hideTitleCls = "full-content__hidden-title";
    var FullContentComponent = /** @class */ (function () {
        // #endregion
        function FullContentComponent(el, cdr, srv, router$$1, doc) {
            this.el = el;
            this.cdr = cdr;
            this.srv = srv;
            this.router = router$$1;
            this.doc = doc;
            this.inited = false;
            this.id = "_full-content-" + Math.random()
                .toString(36)
                .substring(2);
            this.scroll$ = null;
            this._height = 0;
            this.hideTitle = true;
            this.padding = 24;
            this.fullscreenChange = new i0.EventEmitter();
        }
        /**
         * @private
         * @return {?}
         */
        FullContentComponent.prototype.updateCls = /**
         * @private
         * @return {?}
         */
            function () {
                /** @type {?} */
                var clss = this.bodyEl.classList;
                if (this.fullscreen) {
                    clss.add(openedCls);
                    if (this.hideTitle) {
                        clss.add(hideTitleCls);
                    }
                }
                else {
                    clss.remove(openedCls);
                    if (this.hideTitle) {
                        clss.remove(hideTitleCls);
                    }
                }
            };
        /**
         * @private
         * @return {?}
         */
        FullContentComponent.prototype.update = /**
         * @private
         * @return {?}
         */
            function () {
                this.updateCls();
                this.updateHeight();
                this.fullscreenChange.emit(this.fullscreen);
            };
        /**
         * @private
         * @return {?}
         */
        FullContentComponent.prototype.updateHeight = /**
         * @private
         * @return {?}
         */
            function () {
                this._height =
                    this.bodyEl.getBoundingClientRect().height -
                        (( /** @type {?} */(this.el.nativeElement))).getBoundingClientRect().top -
                        this.padding;
                this.cdr.detectChanges();
            };
        /**
         * @private
         * @return {?}
         */
        FullContentComponent.prototype.removeInBody = /**
         * @private
         * @return {?}
         */
            function () {
                this.bodyEl.classList.remove(wrapCls, openedCls, hideTitleCls);
            };
        /**
         * @return {?}
         */
        FullContentComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.inited = true;
                this.bodyEl = this.doc.querySelector('body');
                this.bodyEl.classList.add(wrapCls);
                (( /** @type {?} */(this.el.nativeElement))).id = this.id;
                this.updateCls();
                // when window resize
                this.scroll$ = rxjs.fromEvent(window, 'resize')
                    .pipe(operators.debounceTime(200))
                    .subscribe(( /**
             * @return {?}
             */function () { return _this.updateHeight(); }));
                // when servier changed
                this.srv$ = this.srv.change.pipe(operators.filter(( /**
                 * @param {?} res
                 * @return {?}
                 */function (res) { return res !== null; }))).subscribe(( /**
                 * @return {?}
                 */function () { return _this.toggle(); }));
                // when router changed
                this.route$ = this.router.events
                    .pipe(operators.filter(( /**
             * @param {?} e
             * @return {?}
             */function (e) { return e instanceof router.ActivationStart || e instanceof router.ActivationEnd; })), operators.debounceTime(200))
                    .subscribe(( /**
             * @return {?}
             */function () {
                    if (!!_this.doc.querySelector('#' + _this.id)) {
                        _this.bodyEl.classList.add(wrapCls);
                        _this.updateCls();
                    }
                    else {
                        _this.removeInBody();
                    }
                }));
            };
        /**
         * @return {?}
         */
        FullContentComponent.prototype.toggle = /**
         * @return {?}
         */
            function () {
                this.fullscreen = !this.fullscreen;
                this.update();
                this.updateHeight();
            };
        /**
         * @return {?}
         */
        FullContentComponent.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                setTimeout(( /**
                 * @return {?}
                 */function () { return _this.updateHeight(); }));
            };
        /**
         * @return {?}
         */
        FullContentComponent.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                if (this.inited)
                    this.update();
            };
        /**
         * @return {?}
         */
        FullContentComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.removeInBody();
                this.scroll$.unsubscribe();
                this.srv$.unsubscribe();
                this.route$.unsubscribe();
            };
        FullContentComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'full-content',
                        template: "\n    <ng-content></ng-content>\n  ",
                        host: {
                            '[class.full-content]': 'true',
                            '[style.height.px]': '_height',
                        },
                        changeDetection: i0.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        FullContentComponent.ctorParameters = function () {
            return [
                { type: i0.ElementRef },
                { type: i0.ChangeDetectorRef },
                { type: FullContentService },
                { type: router.Router },
                { type: undefined, decorators: [{ type: i0.Inject, args: [common.DOCUMENT,] }] }
            ];
        };
        FullContentComponent.propDecorators = {
            fullscreen: [{ type: i0.Input }],
            hideTitle: [{ type: i0.Input }],
            padding: [{ type: i0.Input }],
            fullscreenChange: [{ type: i0.Output }]
        };
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], FullContentComponent.prototype, "fullscreen", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], FullContentComponent.prototype, "hideTitle", void 0);
        __decorate([
            util.InputNumber(),
            __metadata("design:type", Object)
        ], FullContentComponent.prototype, "padding", void 0);
        return FullContentComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var FullContentToggleDirective = /** @class */ (function () {
        function FullContentToggleDirective(parent) {
            this.parent = parent;
        }
        /**
         * @return {?}
         */
        FullContentToggleDirective.prototype._click = /**
         * @return {?}
         */
            function () {
                this.parent.toggle();
            };
        FullContentToggleDirective.decorators = [
            { type: i0.Directive, args: [{
                        selector: '[full-toggle]',
                        host: {
                            '(click)': '_click()',
                        },
                    },] }
        ];
        /** @nocollapse */
        FullContentToggleDirective.ctorParameters = function () {
            return [
                { type: FullContentComponent }
            ];
        };
        return FullContentToggleDirective;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [FullContentComponent, FullContentToggleDirective];
    var FullContentModule = /** @class */ (function () {
        function FullContentModule() {
        }
        FullContentModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, util.DelonUtilModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return FullContentModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.FullContentComponent = FullContentComponent;
    exports.FullContentService = FullContentService;
    exports.FullContentToggleDirective = FullContentToggleDirective;
    exports.FullContentModule = FullContentModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=fullContent.umd.js.map