/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('@angular/core'), require('@angular/router'), require('@delon/theme'), require('@delon/util'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/exception', ['exports', '@angular/common', '@angular/core', '@angular/router', '@delon/theme', '@delon/util', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc.exception = {}),global.ng.common,global.ng.core,global.ng.router,global.delon.theme,global.delon.util,global['ng-zorro-antd']));
}(this, (function (exports,common,core,router,theme,util,ngZorroAntd) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ExceptionComponent = /** @class */ (function () {
        function ExceptionComponent(i18n) {
            this.i18n = i18n;
            this.locale = {};
            this.hasCon = false;
            this._img = '';
            this._title = '';
            this._desc = '';
        }
        Object.defineProperty(ExceptionComponent.prototype, "type", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                /** @type {?} */
                var item = {
                    403: {
                        img: 'https://gw.alipayobjects.com/zos/rmsportal/wZcnGqRDyhPOEYFcZDnb.svg',
                        title: '403',
                    },
                    404: {
                        img: 'https://gw.alipayobjects.com/zos/rmsportal/KpnpchXsobRgLElEozzI.svg',
                        title: '404',
                    },
                    500: {
                        img: 'https://gw.alipayobjects.com/zos/rmsportal/RVRUAYdCGeYNBWoKiIwB.svg',
                        title: '500',
                    },
                }[value];
                if (!item)
                    return;
                this._type = value;
                this._img = item.img;
                this._title = item.title;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(ExceptionComponent.prototype, "img", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._img = value;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(ExceptionComponent.prototype, "title", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._title = value;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(ExceptionComponent.prototype, "desc", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._desc = value;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @return {?}
         */
        ExceptionComponent.prototype.checkContent = /**
         * @return {?}
         */
            function () {
                this.hasCon = !util.isEmpty(this.conTpl.nativeElement);
            };
        /**
         * @return {?}
         */
        ExceptionComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.i18n$ = this.i18n.change.subscribe(( /**
                 * @return {?}
                 */function () { return (_this.locale = _this.i18n.getData('exception')); }));
                this.checkContent();
            };
        /**
         * @return {?}
         */
        ExceptionComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.i18n$.unsubscribe();
            };
        ExceptionComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'exception',
                        template: "<div class=\"exception__img-block\">\n  <div class=\"exception__img\"\n       [ngStyle]=\"{'background-image': 'url(' + _img + ')'}\"></div>\n</div>\n<div class=\"exception__cont\">\n  <h1 class=\"exception__cont-title\"\n      [innerHTML]=\"_title\"></h1>\n  <div class=\"exception__cont-desc\"\n       [innerHTML]=\"_desc || locale[_type]\"></div>\n  <div class=\"exception__cont-actions\">\n    <div (cdkObserveContent)=\"checkContent()\"\n         #conTpl>\n      <ng-content></ng-content>\n    </div>\n    <button *ngIf=\"!hasCon\"\n            nz-button\n            [routerLink]=\"['/']\"\n            [nzType]=\"'primary'\">{{locale.backToHome}}</button>\n  </div>\n</div>\n",
                        host: { '[class.exception]': 'true' }
                    }] }
        ];
        /** @nocollapse */
        ExceptionComponent.ctorParameters = function () {
            return [
                { type: theme.DelonLocaleService }
            ];
        };
        ExceptionComponent.propDecorators = {
            conTpl: [{ type: core.ViewChild, args: ['conTpl',] }],
            type: [{ type: core.Input }],
            img: [{ type: core.Input }],
            title: [{ type: core.Input }],
            desc: [{ type: core.Input }]
        };
        return ExceptionComponent;
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
    /** @type {?} */
    var COMPONENTS = [ExceptionComponent];
    var ExceptionModule = /** @class */ (function () {
        function ExceptionModule() {
        }
        ExceptionModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, router.RouterModule, util.DelonUtilModule, theme.DelonLocaleModule, ngZorroAntd.NgZorroAntdModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return ExceptionModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.ExceptionModule = ExceptionModule;
    exports.ExceptionComponent = ExceptionComponent;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=exception.umd.js.map