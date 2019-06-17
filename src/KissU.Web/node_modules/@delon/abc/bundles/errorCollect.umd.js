/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('@angular/core'), require('@delon/util')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/error-collect', ['exports', '@angular/common', '@angular/core', '@delon/util'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['error-collect'] = {}),global.ng.common,global.ng.core,global.delon.util));
}(this, (function (exports,common,i0,util) { 'use strict';

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
    var ErrorCollectConfig = /** @class */ (function () {
        function ErrorCollectConfig() {
            /**
             * 监听频率
             */
            this.freq = 500;
            /**
             * 顶部偏移值
             */
            this.offsetTop = 65 + 64 + 8 * 2;
        }
        ErrorCollectConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ ErrorCollectConfig.ngInjectableDef = i0.defineInjectable({ factory: function ErrorCollectConfig_Factory() { return new ErrorCollectConfig(); }, token: ErrorCollectConfig, providedIn: "root" });
        return ErrorCollectConfig;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ErrorCollectComponent = /** @class */ (function () {
        function ErrorCollectComponent(cog, el, cdr, doc) {
            this.el = el;
            this.cdr = cdr;
            this.doc = doc;
            this.$time = null;
            this._hiden = true;
            this.count = 0;
            Object.assign(this, __assign({}, new ErrorCollectConfig(), cog));
        }
        Object.defineProperty(ErrorCollectComponent.prototype, "errEls", {
            get: /**
             * @private
             * @return {?}
             */ function () {
                return this.formEl.querySelectorAll('.has-error');
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @private
         * @return {?}
         */
        ErrorCollectComponent.prototype.update = /**
         * @private
         * @return {?}
         */
            function () {
                /** @type {?} */
                var count = this.errEls.length;
                if (count === this.count)
                    return;
                this.count = count;
                this._hiden = count === 0;
                this.cdr.markForCheck();
            };
        /**
         * @return {?}
         */
        ErrorCollectComponent.prototype._click = /**
         * @return {?}
         */
            function () {
                if (this.count === 0)
                    return false;
                // nz-form-control
                /** @type {?} */
                var els = this.errEls;
                /** @type {?} */
                var formItemEl = this.findParent(els[0], '[nz-form-control]') || els[0];
                formItemEl.scrollIntoView(true);
                // fix header height
                this.doc.documentElement.scrollTop -= this.offsetTop;
            };
        /**
         * @private
         * @return {?}
         */
        ErrorCollectComponent.prototype.install = /**
         * @private
         * @return {?}
         */
            function () {
                var _this = this;
                this.uninstall();
                this.$time = setInterval(( /**
                 * @return {?}
                 */function () { return _this.update(); }), this.freq);
                this.update();
            };
        /**
         * @private
         * @return {?}
         */
        ErrorCollectComponent.prototype.uninstall = /**
         * @private
         * @return {?}
         */
            function () {
                clearInterval(this.$time);
            };
        /**
         * @private
         * @param {?} el
         * @param {?} selector
         * @return {?}
         */
        ErrorCollectComponent.prototype.findParent = /**
         * @private
         * @param {?} el
         * @param {?} selector
         * @return {?}
         */
            function (el, selector) {
                /** @type {?} */
                var retEl = null;
                while (el) {
                    if (el.querySelector(selector)) {
                        retEl = el;
                        break;
                    }
                    el = el.parentElement;
                }
                return retEl;
            };
        /**
         * @return {?}
         */
        ErrorCollectComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.formEl = this.findParent(this.el.nativeElement, 'form');
                if (this.formEl === null)
                    throw new Error('No found form element');
                this.install();
            };
        /**
         * @return {?}
         */
        ErrorCollectComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.uninstall();
            };
        ErrorCollectComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'error-collect, [error-collect]',
                        template: "\n    <i nz-icon type=\"exclamation-circle\"></i>\n    <span class=\"pl-sm\">{{ count }}</span>\n  ",
                        host: {
                            '[class.error-collect]': 'true',
                            '[class.d-none]': '_hiden',
                            '(click)': '_click()',
                        },
                        changeDetection: i0.ChangeDetectionStrategy.OnPush,
                        exportAs: 'errorCollect'
                    }] }
        ];
        /** @nocollapse */
        ErrorCollectComponent.ctorParameters = function () {
            return [
                { type: ErrorCollectConfig },
                { type: i0.ElementRef },
                { type: i0.ChangeDetectorRef },
                { type: undefined, decorators: [{ type: i0.Inject, args: [common.DOCUMENT,] }] }
            ];
        };
        ErrorCollectComponent.propDecorators = {
            freq: [{ type: i0.Input }],
            offsetTop: [{ type: i0.Input }]
        };
        __decorate([
            util.InputNumber(),
            __metadata("design:type", Number)
        ], ErrorCollectComponent.prototype, "freq", void 0);
        __decorate([
            util.InputNumber(),
            __metadata("design:type", Number)
        ], ErrorCollectComponent.prototype, "offsetTop", void 0);
        return ErrorCollectComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [ErrorCollectComponent];
    var ErrorCollectModule = /** @class */ (function () {
        function ErrorCollectModule() {
        }
        ErrorCollectModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, util.DelonUtilModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return ErrorCollectModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.ErrorCollectComponent = ErrorCollectComponent;
    exports.ErrorCollectConfig = ErrorCollectConfig;
    exports.ErrorCollectModule = ErrorCollectModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=errorCollect.umd.js.map