/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs'), require('@angular/core'), require('@delon/util')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/lodop', ['exports', 'rxjs', '@angular/core', '@delon/util'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc.lodop = {}),global.rxjs,global.ng.core,global.delon.util));
}(this, (function (exports,rxjs,i0,i2) { 'use strict';

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
    var LodopConfig = /** @class */ (function () {
        function LodopConfig() {
        }
        LodopConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ LodopConfig.ngInjectableDef = i0.defineInjectable({ factory: function LodopConfig_Factory() { return new LodopConfig(); }, token: LodopConfig, providedIn: "root" });
        return LodopConfig;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var LodopService = /** @class */ (function () {
        function LodopService(defCog, scriptSrv) {
            this.defCog = defCog;
            this.scriptSrv = scriptSrv;
            this.pending = false;
            this._lodop = null;
            this._init = new rxjs.Subject();
            this._events = new rxjs.Subject();
            this.printBuffer = [];
            this.cog = defCog;
        }
        Object.defineProperty(LodopService.prototype, "cog", {
            /**
             * 获取或重新设置配置
             *
             * **注：**重新设置会倒置重新加载脚本资源
             */
            get: /**
             * 获取或重新设置配置
             *
             * **注：**重新设置会倒置重新加载脚本资源
             * @return {?}
             */ function () {
                return this._cog;
            },
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._cog = __assign({ url: 'https://localhost:8443/CLodopfuncs.js', name: 'CLODOP', companyName: '', checkMaxCount: 100 }, this.defCog, value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(LodopService.prototype, "events", {
            /** 事件变更通知 */
            get: /**
             * 事件变更通知
             * @return {?}
             */ function () {
                return this._events.asObservable();
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @private
         * @return {?}
         */
        LodopService.prototype.check = /**
         * @private
         * @return {?}
         */
            function () {
                if (!this._lodop)
                    throw new Error("\u8BF7\u52A1\u5FC5\u5148\u8C03\u7528 lodop \u83B7\u53D6\u5BF9\u8C61");
            };
        /**
         * @private
         * @return {?}
         */
        LodopService.prototype.request = /**
         * @private
         * @return {?}
         */
            function () {
                var _this = this;
                this.pending = true;
                /** @type {?} */
                var url = this.cog.url + "?name=" + this.cog.name;
                /** @type {?} */
                var checkMaxCount = this.cog.checkMaxCount;
                /** @type {?} */
                var onResolve = ( /**
                 * @param {?} status
                 * @param {?=} error
                 * @return {?}
                 */function (status, error) {
                    _this._init.next({
                        ok: status === 'ok',
                        status: status,
                        error: error,
                        lodop: _this._lodop,
                    });
                });
                /** @type {?} */
                var checkStatus = ( /**
                 * @return {?}
                 */function () {
                    --checkMaxCount;
                    if (_this._lodop.webskt && _this._lodop.webskt.readyState === 1) {
                        onResolve('ok');
                    }
                    else {
                        if (checkMaxCount < 0) {
                            onResolve('check-limit');
                            return;
                        }
                        setTimeout(( /**
                         * @return {?}
                         */function () { return checkStatus(); }), 100);
                    }
                });
                this.scriptSrv.loadScript(url).then(( /**
                 * @param {?} res
                 * @return {?}
                 */function (res) {
                    if (res.status !== 'ok') {
                        _this.pending = false;
                        onResolve('script-load-error', res[0]);
                        return;
                    }
                    _this._lodop = window.hasOwnProperty(_this.cog.name) && (( /** @type {?} */(window[_this.cog.name])));
                    if (_this._lodop === null) {
                        onResolve('load-variable-name-error', { name: _this.cog.name });
                        return;
                    }
                    _this._lodop.SET_LICENSES(_this.cog.companyName, _this.cog.license, _this.cog.licenseA, _this.cog.licenseB);
                    checkStatus();
                }));
            };
        /** 重置 lodop 对象 */
        /**
         * 重置 lodop 对象
         * @return {?}
         */
        LodopService.prototype.reset = /**
         * 重置 lodop 对象
         * @return {?}
         */
            function () {
                this._lodop = null;
                this.pending = false;
                this.request();
            };
        Object.defineProperty(LodopService.prototype, "lodop", {
            /** 获取 lodop 对象 */
            get: /**
             * 获取 lodop 对象
             * @return {?}
             */ function () {
                if (this._lodop)
                    return rxjs.of(( /** @type {?} */({ ok: true, lodop: this._lodop })));
                if (this.pending)
                    return this._init.asObservable();
                this.request();
                return this._init.asObservable();
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(LodopService.prototype, "printer", {
            /** 获取打印机列表 */
            get: /**
             * 获取打印机列表
             * @return {?}
             */ function () {
                this.check();
                /** @type {?} */
                var ret = [];
                /** @type {?} */
                var count = this._lodop.GET_PRINTER_COUNT();
                for (var index = 0; index < count; index++) {
                    ret.push(this._lodop.GET_PRINTER_NAME(index));
                }
                return ret;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * 附加代码至 `lodop` 对象上，字符串类支持 `{{key}}` 的动态参数
         *
         * **注：** 代码是指打印设计所产生字符串数据
         *
         * @param code 代码
         * @param contextObj 动态参数上下文对象
         * @param parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
         */
        /**
         * 附加代码至 `lodop` 对象上，字符串类支持 `{{key}}` 的动态参数
         *
         * **注：** 代码是指打印设计所产生字符串数据
         *
         * @param {?} code 代码
         * @param {?=} contextObj 动态参数上下文对象
         * @param {?=} parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
         * @return {?}
         */
        LodopService.prototype.attachCode = /**
         * 附加代码至 `lodop` 对象上，字符串类支持 `{{key}}` 的动态参数
         *
         * **注：** 代码是指打印设计所产生字符串数据
         *
         * @param {?} code 代码
         * @param {?=} contextObj 动态参数上下文对象
         * @param {?=} parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
         * @return {?}
         */
            function (code, contextObj, parser) {
                var _this = this;
                this.check();
                if (!parser)
                    parser = /LODOP\.([^(]+)\(([^\n]+)\);/i;
                code.split('\n').forEach(( /**
                 * @param {?} line
                 * @return {?}
                 */function (line) {
                    /** @type {?} */
                    var res = parser.exec(line.trim());
                    if (!res)
                        return;
                    /** @type {?} */
                    var fn = _this._lodop[res[1]];
                    if (fn) {
                        /** @type {?} */
                        var arr = void 0;
                        try {
                            /** @type {?} */
                            var fakeFn = new Function("return [" + res[2] + "]");
                            arr = fakeFn();
                        }
                        catch (_a) { }
                        if (Array.isArray(arr) && contextObj) {
                            for (var i = 0; i < arr.length; i++) {
                                if (typeof arr[i] === 'string') {
                                    arr[i] = arr[i].replace(/{{(.*?)}}/g, ( /**
                                     * @param {?} match
                                     * @param {?} key
                                     * @return {?}
                                     */function (match, key) { return contextObj[key.trim()] || ''; }));
                                }
                            }
                        }
                        fn.apply(_this._lodop, arr);
                    }
                }));
            };
        /**
         * 打开打印设计关闭后自动返回代码
         *
         * **注：** 自动监听 `On_Return` 事件，运行后会移除
         */
        /**
         * 打开打印设计关闭后自动返回代码
         *
         * **注：** 自动监听 `On_Return` 事件，运行后会移除
         * @return {?}
         */
        LodopService.prototype.design = /**
         * 打开打印设计关闭后自动返回代码
         *
         * **注：** 自动监听 `On_Return` 事件，运行后会移除
         * @return {?}
         */
            function () {
                var _this = this;
                this.check();
                /** @type {?} */
                var tid = this._lodop.PRINT_DESIGN();
                return new Promise(( /**
                 * @param {?} resolve
                 * @return {?}
                 */function (resolve) {
                    _this._lodop.On_Return = ( /**
                     * @param {?} taskID
                     * @param {?} value
                     * @return {?}
                     */function (taskID, value) {
                        if (tid !== taskID)
                            return;
                        _this._lodop.On_Return = null;
                        resolve('' + value);
                    });
                }));
            };
        /**
         * @private
         * @return {?}
         */
        LodopService.prototype.printDo = /**
         * @private
         * @return {?}
         */
            function () {
                var _this = this;
                /** @type {?} */
                var data = this.printBuffer.shift();
                if (!data)
                    return;
                this.attachCode(data.code, data.item, data.parser);
                /** @type {?} */
                var tid = this._lodop.PRINT();
                this._lodop.On_Return = ( /**
                 * @param {?} taskID
                 * @param {?} value
                 * @return {?}
                 */function (taskID, value) {
                    if (tid !== taskID)
                        return;
                    _this._lodop.On_Return = null;
                    _this._events.next(__assign({ ok: value === true, error: value === true ? null : value }, data));
                    _this.printDo();
                });
            };
        /**
         * 立即打印，一般用于批量套打
         *
         * @param code 代码
         * @param contextObj 动态参数上下文对象
         * @param parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
         */
        /**
         * 立即打印，一般用于批量套打
         *
         * @param {?} code 代码
         * @param {?} contextObj 动态参数上下文对象
         * @param {?=} parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
         * @return {?}
         */
        LodopService.prototype.print = /**
         * 立即打印，一般用于批量套打
         *
         * @param {?} code 代码
         * @param {?} contextObj 动态参数上下文对象
         * @param {?=} parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
         * @return {?}
         */
            function (code, contextObj, parser) {
                var _a;
                this.check();
                if (contextObj) {
                    (_a = this.printBuffer).push.apply(_a, __spread((Array.isArray(contextObj) ? contextObj : [contextObj]).map(( /**
                     * @param {?} item
                     * @return {?}
                     */function (item) {
                        return { code: code, parser: parser, item: item };
                    }))));
                }
                this.printDo();
            };
        /**
         * @return {?}
         */
        LodopService.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this._init.unsubscribe();
                this._events.unsubscribe();
            };
        LodopService.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        LodopService.ctorParameters = function () {
            return [
                { type: LodopConfig },
                { type: i2.LazyService }
            ];
        };
        /** @nocollapse */ LodopService.ngInjectableDef = i0.defineInjectable({ factory: function LodopService_Factory() { return new LodopService(i0.inject(LodopConfig), i0.inject(i2.LazyService)); }, token: LodopService, providedIn: "root" });
        return LodopService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var LodopModule = /** @class */ (function () {
        function LodopModule() {
        }
        LodopModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [i2.DelonUtilModule],
                    },] }
        ];
        return LodopModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.LodopService = LodopService;
    exports.LodopConfig = LodopConfig;
    exports.LodopModule = LodopModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=lodop.umd.js.map