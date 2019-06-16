/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common/http'), require('file-saver'), require('@angular/common'), require('@angular/core'), require('@delon/util')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/xlsx', ['exports', '@angular/common/http', 'file-saver', '@angular/common', '@angular/core', '@delon/util'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc.xlsx = {}),global.ng.common.http,global.saveAs,global.ng.common,global.ng.core,global.delon.util));
}(this, (function (exports,i2,fileSaver,common,i0,i3) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var XlsxConfig = /** @class */ (function () {
        function XlsxConfig() {
            /**
             * Xlsx library path
             */
            this.url = '//cdn.bootcss.com/xlsx/0.12.13/xlsx.full.min.js';
            /**
             * Defines which Xlsx optional modules should get loaded, e.g:
             *
             * `[ '//cdn.bootcss.com/xlsx/0.12.13/cpexcel.js' ]`
             */
            this.modules = [];
        }
        XlsxConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ XlsxConfig.ngInjectableDef = i0.defineInjectable({ factory: function XlsxConfig_Factory() { return new XlsxConfig(); }, token: XlsxConfig, providedIn: "root" });
        return XlsxConfig;
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
    var XlsxService = /** @class */ (function () {
        function XlsxService(cog, http, lazy) {
            this.cog = cog;
            this.http = http;
            this.lazy = lazy;
        }
        /**
         * @private
         * @return {?}
         */
        XlsxService.prototype.init = /**
         * @private
         * @return {?}
         */
            function () {
                return this.lazy.load([this.cog.url].concat(this.cog.modules));
            };
        /**
         * @private
         * @param {?} wb
         * @return {?}
         */
        XlsxService.prototype.read = /**
         * @private
         * @param {?} wb
         * @return {?}
         */
            function (wb) {
                /** @type {?} */
                var ret = {};
                wb.SheetNames.forEach(( /**
                 * @param {?} name
                 * @return {?}
                 */function (name) {
                    /** @type {?} */
                    var sheet = wb.Sheets[name];
                    ret[name] = XLSX.utils.sheet_to_json(sheet, { header: 1 });
                }));
                return ret;
            };
        /**
         * 导入Excel并输出JSON，支持 `<input type="file">`、URL 形式
         * @param rABS 加载数据方式 `readAsBinaryString` （默认） 或 `readAsArrayBuffer`，[更多细节](http://t.cn/R3n63A0)
         */
        /**
         * 导入Excel并输出JSON，支持 `<input type="file">`、URL 形式
         * @param {?} fileOrUrl
         * @param {?=} rABS 加载数据方式 `readAsBinaryString` （默认） 或 `readAsArrayBuffer`，[更多细节](http://t.cn/R3n63A0)
         * @return {?}
         */
        XlsxService.prototype.import = /**
         * 导入Excel并输出JSON，支持 `<input type="file">`、URL 形式
         * @param {?} fileOrUrl
         * @param {?=} rABS 加载数据方式 `readAsBinaryString` （默认） 或 `readAsArrayBuffer`，[更多细节](http://t.cn/R3n63A0)
         * @return {?}
         */
            function (fileOrUrl, rABS) {
                var _this = this;
                if (rABS === void 0) {
                    rABS = 'readAsBinaryString';
                }
                return new Promise(( /**
                 * @param {?} resolver
                 * @param {?} reject
                 * @return {?}
                 */function (resolver, reject) {
                    _this.init().then(( /**
                     * @return {?}
                     */function () {
                        // from url
                        if (typeof fileOrUrl === 'string') {
                            _this.http.request('GET', fileOrUrl, { responseType: 'arraybuffer' }).subscribe(( /**
                             * @param {?} res
                             * @return {?}
                             */function (res) {
                                /** @type {?} */
                                var wb = XLSX.read(new Uint8Array(res), { type: 'array' });
                                resolver(_this.read(wb));
                            }), ( /**
                             * @param {?} err
                             * @return {?}
                             */function (err) {
                                reject(err);
                            }));
                            return;
                        }
                        // from file
                        /** @type {?} */
                        var reader = new FileReader();
                        reader.onload = ( /**
                         * @param {?} e
                         * @return {?}
                         */function (e) {
                            /** @type {?} */
                            var wb = XLSX.read(e.target.result, { type: 'binary' });
                            resolver(_this.read(wb));
                        });
                        reader[rABS](fileOrUrl);
                    }));
                }));
            };
        /** 导出 */
        /**
         * 导出
         * @param {?} options
         * @return {?}
         */
        XlsxService.prototype.export = /**
         * 导出
         * @param {?} options
         * @return {?}
         */
            function (options) {
                return this.init().then(( /**
                 * @return {?}
                 */function () {
                    /** @type {?} */
                    var wb = XLSX.utils.book_new();
                    if (Array.isArray(options.sheets)) {
                        (( /** @type {?} */(options.sheets))).forEach(( /**
                         * @param {?} value
                         * @param {?} index
                         * @return {?}
                         */function (value, index) {
                            /** @type {?} */
                            var ws = XLSX.utils.aoa_to_sheet(value.data);
                            XLSX.utils.book_append_sheet(wb, ws, value.name || "Sheet" + (index + 1));
                        }));
                    }
                    else {
                        wb.SheetNames = Object.keys(options.sheets);
                        wb.Sheets = options.sheets;
                    }
                    if (options.callback)
                        options.callback(wb);
                    /** @type {?} */
                    var wbout = XLSX.write(wb, __assign({ bookType: 'xlsx', bookSST: false, type: 'array' }, options.opts));
                    fileSaver.saveAs(new Blob([wbout], { type: 'application/octet-stream' }), options.filename || 'export.xlsx');
                }));
            };
        XlsxService.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        XlsxService.ctorParameters = function () {
            return [
                { type: XlsxConfig },
                { type: i2.HttpClient },
                { type: i3.LazyService }
            ];
        };
        /** @nocollapse */ XlsxService.ngInjectableDef = i0.defineInjectable({ factory: function XlsxService_Factory() { return new XlsxService(i0.inject(XlsxConfig), i0.inject(i2.HttpClient), i0.inject(i3.LazyService)); }, token: XlsxService, providedIn: "root" });
        return XlsxService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var XlsxDirective = /** @class */ (function () {
        function XlsxDirective(srv) {
            this.srv = srv;
        }
        /**
         * @return {?}
         */
        XlsxDirective.prototype._click = /**
         * @return {?}
         */
            function () {
                this.srv.export(this.data);
            };
        XlsxDirective.decorators = [
            { type: i0.Directive, args: [{
                        selector: '[xlsx]',
                        host: {
                            '(click)': '_click()',
                        },
                        exportAs: 'xlsxDirective',
                    },] }
        ];
        /** @nocollapse */
        XlsxDirective.ctorParameters = function () {
            return [
                { type: XlsxService }
            ];
        };
        XlsxDirective.propDecorators = {
            data: [{ type: i0.Input, args: ['xlsx',] }]
        };
        return XlsxDirective;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [XlsxDirective];
    var XlsxModule = /** @class */ (function () {
        function XlsxModule() {
        }
        XlsxModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, i3.DelonUtilModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return XlsxModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.XlsxConfig = XlsxConfig;
    exports.XlsxService = XlsxService;
    exports.XlsxDirective = XlsxDirective;
    exports.XlsxModule = XlsxModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=xlsx.umd.js.map