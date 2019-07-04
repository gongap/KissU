/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('date-fns/add_seconds'), require('date-fns/format'), require('@angular/common'), require('@angular/core'), require('ngx-countdown')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/count-down', ['exports', 'date-fns/add_seconds', 'date-fns/format', '@angular/common', '@angular/core', 'ngx-countdown'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['count-down'] = {}),global.addSeconds,global.format,global.ng.common,global.ng.core,global.ngxCountDown));
}(this, (function (exports,addSeconds,format,common,core,ngxCountdown) { 'use strict';

    addSeconds = addSeconds && addSeconds.hasOwnProperty('default') ? addSeconds['default'] : addSeconds;
    format = format && format.hasOwnProperty('default') ? format['default'] : format;

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var CountDownComponent = /** @class */ (function () {
        function CountDownComponent() {
            this.begin = new core.EventEmitter();
            this.notify = new core.EventEmitter();
            this.end = new core.EventEmitter();
        }
        Object.defineProperty(CountDownComponent.prototype, "target", {
            /**
             * 目标时间
             */
            set: /**
             * 目标时间
             * @param {?} value
             * @return {?}
             */ function (value) {
                this.config = {
                    template: "$!h!:$!m!:$!s!",
                    stopTime: typeof value === 'number' ? addSeconds(new Date(), value).valueOf() : format(value, 'x'),
                };
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @return {?}
         */
        CountDownComponent.prototype._start = /**
         * @return {?}
         */
            function () {
                this.begin.emit();
            };
        /**
         * @param {?} time
         * @return {?}
         */
        CountDownComponent.prototype._notify = /**
         * @param {?} time
         * @return {?}
         */
            function (time) {
                this.notify.emit(time);
            };
        /**
         * @return {?}
         */
        CountDownComponent.prototype._finished = /**
         * @return {?}
         */
            function () {
                this.end.emit();
            };
        CountDownComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'count-down',
                        template: "\n    <countdown\n      *ngIf=\"config\"\n      [config]=\"config\"\n      (start)=\"_start()\"\n      (finished)=\"_finished()\"\n      (notify)=\"_notify($event)\"\n    ></countdown>\n  "
                    }] }
        ];
        CountDownComponent.propDecorators = {
            config: [{ type: core.Input }],
            target: [{ type: core.Input }],
            begin: [{ type: core.Output }],
            notify: [{ type: core.Output }],
            end: [{ type: core.Output }]
        };
        return CountDownComponent;
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
    var COMPONENTS = [CountDownComponent];
    var CountDownModule = /** @class */ (function () {
        function CountDownModule() {
        }
        CountDownModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, ngxCountdown.CountdownModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return CountDownModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.CountDownComponent = CountDownComponent;
    exports.CountDownModule = CountDownModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=count-down.umd.js.map