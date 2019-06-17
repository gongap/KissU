/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('@angular/core'), require('@delon/util')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/image', ['exports', '@angular/common', '@angular/core', '@delon/util'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc.image = {}),global.ng.common,global.ng.core,global.delon.util));
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
    var ImageConfig = /** @class */ (function () {
        function ImageConfig() {
            /**
             * 默认大小，默认值：`64`，单位：px
             */
            this.size = 64;
            /**
             * 错误图片
             */
            this.error = './assets/img/logo.svg';
        }
        ImageConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ ImageConfig.ngInjectableDef = i0.defineInjectable({ factory: function ImageConfig_Factory() { return new ImageConfig(); }, token: ImageConfig, providedIn: "root" });
        return ImageConfig;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * img标签
     * + 支持微信、qq头像规则缩略图规则
     * + 支持移除http&https协议http
     * + 支持增加onerror事件
     */
    var ImageDirective = /** @class */ (function () {
        function ImageDirective(cog, el, render) {
            this.el = el;
            this.render = render;
            this.size = 64;
            this.error = './assets/img/logo.svg';
            this.inited = false;
            Object.assign(this, __assign({}, new ImageConfig(), cog));
        }
        /**
         * @return {?}
         */
        ImageDirective.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.update();
                this.updateError();
                this.inited = true;
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        ImageDirective.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (!this.inited)
                    return;
                if (changes.error) {
                    this.updateError();
                }
                else {
                    this.update();
                }
            };
        /**
         * @private
         * @return {?}
         */
        ImageDirective.prototype.update = /**
         * @private
         * @return {?}
         */
            function () {
                /** @type {?} */
                var newSrc = this.src;
                if (newSrc.includes('qlogo.cn')) {
                    /** @type {?} */
                    var arr = newSrc.split('/');
                    /** @type {?} */
                    var size = arr[arr.length - 1];
                    arr[arr.length - 1] = size === '0' || +size !== this.size ? this.size.toString() : size;
                    newSrc = arr.join('/');
                }
                /** @type {?} */
                var isHttp = newSrc.startsWith('http:');
                /** @type {?} */
                var isHttps = newSrc.startsWith('https:');
                if (isHttp || isHttps) {
                    newSrc = newSrc.substr(isHttp ? 5 : 6);
                }
                this.render.setAttribute(this.el.nativeElement, 'src', newSrc);
            };
        /**
         * @private
         * @return {?}
         */
        ImageDirective.prototype.updateError = /**
         * @private
         * @return {?}
         */
            function () {
                this.render.setAttribute(this.el.nativeElement, 'onerror', "this.src='" + this.error + "'");
            };
        ImageDirective.decorators = [
            { type: i0.Directive, args: [{
                        selector: '[_src]',
                        exportAs: 'srcDirective',
                    },] }
        ];
        /** @nocollapse */
        ImageDirective.ctorParameters = function () {
            return [
                { type: ImageConfig },
                { type: i0.ElementRef },
                { type: i0.Renderer2 }
            ];
        };
        ImageDirective.propDecorators = {
            src: [{ type: i0.Input, args: ['_src',] }],
            size: [{ type: i0.Input }],
            error: [{ type: i0.Input }]
        };
        __decorate([
            util.InputNumber(),
            __metadata("design:type", Object)
        ], ImageDirective.prototype, "size", void 0);
        return ImageDirective;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var DIRECTIVES = [ImageDirective];
    var ImageModule = /** @class */ (function () {
        function ImageModule() {
        }
        ImageModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, util.DelonUtilModule],
                        declarations: __spread(DIRECTIVES),
                        exports: __spread(DIRECTIVES),
                    },] }
        ];
        return ImageModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.ImageDirective = ImageDirective;
    exports.ImageConfig = ImageConfig;
    exports.ImageModule = ImageModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=image.umd.js.map