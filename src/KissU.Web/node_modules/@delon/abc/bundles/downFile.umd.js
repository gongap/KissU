/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('file-saver'), require('@angular/common'), require('@angular/core'), require('@delon/theme')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/down-file', ['exports', 'file-saver', '@angular/common', '@angular/core', '@delon/theme'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['down-file'] = {}),global.saveAs,global.ng.common,global.ng.core,global.delon.theme));
}(this, (function (exports,fileSaver,common,core,theme) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var DownFileDirective = /** @class */ (function () {
        function DownFileDirective(el, _http) {
            this.el = el;
            this._http = _http;
            /**
             * 请求类型
             */
            this.httpMethod = 'get';
            /**
             * 成功回调
             */
            this.success = new core.EventEmitter();
            /**
             * 错误回调
             */
            this.error = new core.EventEmitter();
        }
        /**
         * @private
         * @param {?} data
         * @return {?}
         */
        DownFileDirective.prototype.getDisposition = /**
         * @private
         * @param {?} data
         * @return {?}
         */
            function (data) {
                /** @type {?} */
                var arr = (data || '')
                    .split(';')
                    .filter(( /**
             * @param {?} i
             * @return {?}
             */function (i) { return i.includes('='); }))
                    .map(( /**
             * @param {?} v
             * @return {?}
             */function (v) {
                    var _a;
                    /** @type {?} */
                    var strArr = v.split('=');
                    /** @type {?} */
                    var utfId = "UTF-8''";
                    /** @type {?} */
                    var value = strArr[1];
                    if (value.startsWith(utfId))
                        value = value.substr(utfId.length);
                    return _a = {}, _a[strArr[0].trim()] = value, _a;
                }));
                return arr.reduce(( /**
                 * @param {?} o
                 * @param {?} item
                 * @return {?}
                 */function (o, item) { return item; }), {});
            };
        /**
         * @return {?}
         */
        DownFileDirective.prototype._click = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.el.nativeElement.disabled = true;
                this._http
                    .request(this.httpMethod, this.httpUrl, {
                    params: this.httpData || {},
                    responseType: 'blob',
                    observe: 'response',
                })
                    .subscribe(( /**
             * @param {?} res
             * @return {?}
             */function (res) {
                    if (res.status !== 200 || res.body.size <= 0) {
                        _this.error.emit(res);
                        return;
                    }
                    /** @type {?} */
                    var disposition = _this.getDisposition(res.headers.get('content-disposition'));
                    /** @type {?} */
                    var fileName = _this.fileName ||
                        disposition["filename*"] ||
                        disposition["filename"] ||
                        res.headers.get('filename') ||
                        res.headers.get('x-filename');
                    fileSaver.saveAs(res.body, decodeURI(fileName));
                    _this.success.emit(res);
                    _this.el.nativeElement.disabled = false;
                }), ( /**
                 * @param {?} err
                 * @return {?}
                 */function (err) {
                    _this.error.emit(err);
                    _this.el.nativeElement.disabled = false;
                }));
            };
        DownFileDirective.decorators = [
            { type: core.Directive, args: [{
                        selector: '[down-file]',
                        host: {
                            '(click)': '_click()',
                        },
                        exportAs: 'downFileDirective',
                    },] }
        ];
        /** @nocollapse */
        DownFileDirective.ctorParameters = function () {
            return [
                { type: core.ElementRef },
                { type: theme._HttpClient }
            ];
        };
        DownFileDirective.propDecorators = {
            httpData: [{ type: core.Input, args: ['http-data',] }],
            httpMethod: [{ type: core.Input, args: ['http-method',] }],
            httpUrl: [{ type: core.Input, args: ['http-url',] }],
            fileName: [{ type: core.Input, args: ['file-name',] }],
            success: [{ type: core.Output }],
            error: [{ type: core.Output }]
        };
        return DownFileDirective;
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
    var DIRECTIVES = [DownFileDirective];
    var DownFileModule = /** @class */ (function () {
        function DownFileModule() {
        }
        DownFileModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, theme.AlainThemeModule],
                        declarations: __spread(DIRECTIVES),
                        exports: __spread(DIRECTIVES),
                    },] }
        ];
        return DownFileModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.DownFileDirective = DownFileDirective;
    exports.DownFileModule = DownFileModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=downFile.umd.js.map