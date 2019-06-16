/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('@angular/core'), require('@delon/util'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/result', ['exports', '@angular/common', '@angular/core', '@delon/util', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc.result = {}),global.ng.common,global.ng.core,global.util,global.ngZorroAntd));
}(this, (function (exports,common,core,util,ngZorroAntd) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ResultComponent = /** @class */ (function () {
        function ResultComponent() {
            this._type = '';
            this._icon = '';
        }
        Object.defineProperty(ResultComponent.prototype, "type", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._type = value;
                switch (value) {
                    case 'success':
                        this._icon = 'check-circle';
                        break;
                    case 'error':
                        this._icon = 'close-circle';
                        break;
                    default:
                        this._icon = value;
                        break;
                }
            },
            enumerable: true,
            configurable: true
        });
        ResultComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'result',
                        template: "<div class=\"result__icon\">\n  <i nz-icon\n     [nzType]=\"_icon\"\n     class=\"result__icon-{{_type}}\"></i>\n</div>\n<div class=\"result__title\">\n  <ng-container *stringTemplateOutlet=\"title\">{{title}}</ng-container>\n</div>\n<div *ngIf=\"description\"\n     class=\"result__desc\">\n  <ng-container *stringTemplateOutlet=\"description\">{{description}}</ng-container>\n</div>\n<div *ngIf=\"extra\"\n     class=\"result__extra\">\n  <ng-container *stringTemplateOutlet=\"extra\">{{extra}}</ng-container>\n</div>\n<div class=\"result__actions\">\n  <ng-content></ng-content>\n</div>\n",
                        host: { '[class.result]': 'true' }
                    }] }
        ];
        ResultComponent.propDecorators = {
            type: [{ type: core.Input }],
            title: [{ type: core.Input }],
            description: [{ type: core.Input }],
            extra: [{ type: core.Input }]
        };
        return ResultComponent;
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
    var COMPONENTS = [ResultComponent];
    var ResultModule = /** @class */ (function () {
        function ResultModule() {
        }
        ResultModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, ngZorroAntd.NgZorroAntdModule, util.DelonUtilModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return ResultModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.ResultComponent = ResultComponent;
    exports.ResultModule = ResultModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=result.umd.js.map