/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common/http'), require('file-saver'), require('@angular/common'), require('@angular/core'), require('@delon/util')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/zip', ['exports', '@angular/common/http', 'file-saver', '@angular/common', '@angular/core', '@delon/util'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc.zip = {}),global.ng.common.http,global.saveAs,global.ng.common,global.ng.core,global.delon.util));
}(this, (function (exports,i2,fileSaver,common,i0,i3) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ZipConfig = /** @class */ (function () {
        function ZipConfig() {
            /**
             * Zip library path
             */
            this.url = '//cdn.bootcss.com/jszip/3.1.5/jszip.min.js';
            /**
             * Defines which zip optional utils should get loaded
             */
            this.utils = [];
        }
        ZipConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ ZipConfig.ngInjectableDef = i0.defineInjectable({ factory: function ZipConfig_Factory() { return new ZipConfig(); }, token: ZipConfig, providedIn: "root" });
        return ZipConfig;
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
    var ZipService = /** @class */ (function () {
        function ZipService(cog, http, lazy) {
            this.cog = cog;
            this.http = http;
            this.lazy = lazy;
        }
        /**
         * @private
         * @return {?}
         */
        ZipService.prototype.init = /**
         * @private
         * @return {?}
         */
            function () {
                return this.lazy.load([this.cog.url].concat(this.cog.utils));
            };
        /**
         * @private
         * @param {?} zip
         * @return {?}
         */
        ZipService.prototype.check = /**
         * @private
         * @param {?} zip
         * @return {?}
         */
            function (zip) {
                if (!zip)
                    throw new Error('get instance via `ZipService.create()`');
            };
        /** 解压 */
        /**
         * 解压
         * @param {?} fileOrUrl
         * @param {?=} options
         * @return {?}
         */
        ZipService.prototype.read = /**
         * 解压
         * @param {?} fileOrUrl
         * @param {?=} options
         * @return {?}
         */
            function (fileOrUrl, options) {
                var _this = this;
                return new Promise(( /**
                 * @param {?} resolve
                 * @param {?} reject
                 * @return {?}
                 */function (resolve, reject) {
                    _this.init().then(( /**
                     * @return {?}
                     */function () {
                        // from url
                        if (typeof fileOrUrl === 'string') {
                            _this.http.request('GET', fileOrUrl, { responseType: 'arraybuffer' }).subscribe(( /**
                             * @param {?} res
                             * @return {?}
                             */function (res) {
                                JSZip.loadAsync(res, options).then(( /**
                                 * @param {?} ret
                                 * @return {?}
                                 */function (ret) { return resolve(ret); }));
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
                            JSZip.loadAsync(e.target.result, options).then(( /**
                             * @param {?} ret
                             * @return {?}
                             */function (ret) { return resolve(ret); }));
                        });
                        reader.readAsBinaryString(( /** @type {?} */(fileOrUrl)));
                    }));
                }));
            };
        /** 创建 Zip 实例，用于创建压缩文件 */
        /**
         * 创建 Zip 实例，用于创建压缩文件
         * @return {?}
         */
        ZipService.prototype.create = /**
         * 创建 Zip 实例，用于创建压缩文件
         * @return {?}
         */
            function () {
                var _this = this;
                return new Promise(( /**
                 * @param {?} resolve
                 * @return {?}
                 */function (resolve) {
                    _this.init().then(( /**
                     * @return {?}
                     */function () {
                        /** @type {?} */
                        var zipFile = new JSZip();
                        resolve(zipFile);
                    }));
                }));
            };
        /**
         * 下载URL资源并写入 zip
         * @param zip Zip 实例
         * @param path Zip 路径，例如： `text.txt`、`txt/hi.txt`
         * @param url URL 地址
         */
        /**
         * 下载URL资源并写入 zip
         * @param {?} zip Zip 实例
         * @param {?} path Zip 路径，例如： `text.txt`、`txt/hi.txt`
         * @param {?} url URL 地址
         * @return {?}
         */
        ZipService.prototype.pushUrl = /**
         * 下载URL资源并写入 zip
         * @param {?} zip Zip 实例
         * @param {?} path Zip 路径，例如： `text.txt`、`txt/hi.txt`
         * @param {?} url URL 地址
         * @return {?}
         */
            function (zip, path, url) {
                var _this = this;
                this.check(zip);
                return new Promise(( /**
                 * @param {?} resolve
                 * @param {?} reject
                 * @return {?}
                 */function (resolve, reject) {
                    _this.http.request('GET', url, { responseType: 'arraybuffer' }).subscribe(( /**
                     * @param {?} res
                     * @return {?}
                     */function (res) {
                        zip.file(path, res);
                        resolve();
                    }), ( /**
                     * @param {?} error
                     * @return {?}
                     */function (error) {
                        reject({ url: url, error: error });
                    }));
                }));
            };
        /**
         * 保存Zip并执行打开保存对话框
         *
         * @param zip zip 对象，务必通过 `create()` 构建
         * @param options 额外参数，
         */
        /**
         * 保存Zip并执行打开保存对话框
         *
         * @param {?} zip zip 对象，务必通过 `create()` 构建
         * @param {?=} options 额外参数，
         * @return {?}
         */
        ZipService.prototype.save = /**
         * 保存Zip并执行打开保存对话框
         *
         * @param {?} zip zip 对象，务必通过 `create()` 构建
         * @param {?=} options 额外参数，
         * @return {?}
         */
            function (zip, options) {
                this.check(zip);
                /** @type {?} */
                var opt = __assign({}, options);
                return new Promise(( /**
                 * @param {?} resolve
                 * @param {?} reject
                 * @return {?}
                 */function (resolve, reject) {
                    zip.generateAsync(__assign({ type: 'blob' }, opt.options), opt.update).then(( /**
                     * @param {?} data
                     * @return {?}
                     */function (data) {
                        if (opt.callback)
                            opt.callback(data);
                        fileSaver.saveAs(data, opt.filename || 'download.zip');
                        resolve();
                    }), ( /**
                     * @param {?} err
                     * @return {?}
                     */function (err) {
                        reject(err);
                    }));
                }));
            };
        ZipService.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        ZipService.ctorParameters = function () {
            return [
                { type: ZipConfig },
                { type: i2.HttpClient },
                { type: i3.LazyService }
            ];
        };
        /** @nocollapse */ ZipService.ngInjectableDef = i0.defineInjectable({ factory: function ZipService_Factory() { return new ZipService(i0.inject(ZipConfig), i0.inject(i2.HttpClient), i0.inject(i3.LazyService)); }, token: ZipService, providedIn: "root" });
        return ZipService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ZipModule = /** @class */ (function () {
        function ZipModule() {
        }
        ZipModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, i3.DelonUtilModule],
                    },] }
        ];
        return ZipModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.ZipService = ZipService;
    exports.ZipModule = ZipModule;
    exports.ZipConfig = ZipConfig;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=zip.umd.js.map