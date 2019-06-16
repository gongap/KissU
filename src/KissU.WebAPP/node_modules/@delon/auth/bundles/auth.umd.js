/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs/operators'), require('@angular/common/http'), require('rxjs'), require('@angular/common'), require('@angular/router'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('@delon/auth', ['exports', 'rxjs/operators', '@angular/common/http', 'rxjs', '@angular/common', '@angular/router', '@angular/core'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.auth = {}),global.rxjs.operators,global.ng.common.http,global.rxjs,global.ng.common,global.ng.router,global.ng.core));
}(this, (function (exports,operators,http,rxjs,common,router,i0) { 'use strict';

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
    /* global Reflect, Promise */
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b)
                if (b.hasOwnProperty(p))
                    d[p] = b[p]; };
        return extendStatics(d, b);
    };
    function __extends(d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    }
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
    function __values(o) {
        var m = typeof Symbol === "function" && o[Symbol.iterator], i = 0;
        if (m)
            return m.call(o);
        return {
            next: function () {
                if (o && i >= o.length)
                    o = void 0;
                return { value: o && o[i++], done: !o };
            }
        };
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var DelonAuthConfig = /** @class */ (function () {
        function DelonAuthConfig() {
            /**
             * 存储KEY值
             */
            this.store_key = '_token';
            /**
             * 无效时跳转至登录页，包括：
             * - 无效token值
             * - token已过期（限JWT）
             */
            this.token_invalid_redirect = true;
            /**
             * token过期时间偏移值，默认：`10` 秒（单位：秒）
             */
            this.token_exp_offset = 10;
            /**
             * 发送token参数名，默认：token
             */
            this.token_send_key = 'token';
            /**
             * 发送token模板（默认为：`${token}`），使用 `${token}` 表示token点位符，例如：
             *
             * - `Bearer ${token}`
             */
            // tslint:disable-next-line:no-invalid-template-strings
            this.token_send_template = '${token}';
            /**
             * 发送token参数位置，默认：header
             */
            this.token_send_place = 'header';
            /**
             * 登录页路由地址
             */
            this.login_url = "/login";
            /**
             * 忽略TOKEN的URL地址列表，默认值为：[ /\/login/, /assets\//, /passport\// ]
             */
            this.ignores = [/\/login/, /assets\//, /passport\//];
            /**
             * 允许匿名登录KEY，若请求参数中带有该KEY表示忽略TOKEN
             */
            this.allow_anonymous_key = "_allow_anonymous";
            /**
             * 是否校验失效时命中后继续调用后续拦截器的 `intercept` 方法，默认：`true`
             */
            this.executeOtherInterceptors = true;
        }
        DelonAuthConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ DelonAuthConfig.ngInjectableDef = i0.defineInjectable({ factory: function DelonAuthConfig_Factory() { return new DelonAuthConfig(); }, token: DelonAuthConfig, providedIn: "root" });
        return DelonAuthConfig;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * @return {?}
     */
    function DA_STORE_TOKEN_LOCAL_FACTORY() {
        return new LocalStorageStore();
    }
    var LocalStorageStore = /** @class */ (function () {
        function LocalStorageStore() {
        }
        /**
         * @param {?} key
         * @return {?}
         */
        LocalStorageStore.prototype.get = /**
         * @param {?} key
         * @return {?}
         */
            function (key) {
                return JSON.parse(localStorage.getItem(key) || '{}') || {};
            };
        /**
         * @param {?} key
         * @param {?} value
         * @return {?}
         */
        LocalStorageStore.prototype.set = /**
         * @param {?} key
         * @param {?} value
         * @return {?}
         */
            function (key, value) {
                localStorage.setItem(key, JSON.stringify(value));
                return true;
            };
        /**
         * @param {?} key
         * @return {?}
         */
        LocalStorageStore.prototype.remove = /**
         * @param {?} key
         * @return {?}
         */
            function (key) {
                localStorage.removeItem(key);
            };
        return LocalStorageStore;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var DA_STORE_TOKEN = new i0.InjectionToken('AUTH_STORE_TOKEN', {
        providedIn: 'root',
        factory: DA_STORE_TOKEN_LOCAL_FACTORY,
    });

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * @return {?}
     */
    function DA_SERVICE_TOKEN_FACTORY() {
        return new TokenService(i0.inject(DelonAuthConfig), i0.inject(DA_STORE_TOKEN));
    }
    var TokenService = /** @class */ (function () {
        function TokenService(options, store) {
            this.options = options;
            this.store = store;
            this.change$ = new rxjs.BehaviorSubject(null);
            this._referrer = {};
        }
        Object.defineProperty(TokenService.prototype, "login_url", {
            get: /**
             * @return {?}
             */ function () {
                return this.options.login_url;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(TokenService.prototype, "referrer", {
            get: /**
             * @return {?}
             */ function () {
                return this._referrer;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @param {?} data
         * @return {?}
         */
        TokenService.prototype.set = /**
         * @param {?} data
         * @return {?}
         */
            function (data) {
                this.change$.next(data);
                return this.store.set(this.options.store_key, data);
            };
        /**
         * @template T
         * @param {?=} type
         * @return {?}
         */
        TokenService.prototype.get = /**
         * @template T
         * @param {?=} type
         * @return {?}
         */
            function (type) {
                /** @type {?} */
                var data = this.store.get(this.options.store_key);
                return type ? (( /** @type {?} */(Object.assign(new type(), data)))) : (( /** @type {?} */(data)));
            };
        /**
         * @return {?}
         */
        TokenService.prototype.clear = /**
         * @return {?}
         */
            function () {
                this.change$.next(null);
                this.store.remove(this.options.store_key);
            };
        /**
         * @return {?}
         */
        TokenService.prototype.change = /**
         * @return {?}
         */
            function () {
                return this.change$.pipe(operators.share());
            };
        /** @nocollapse */
        TokenService.ctorParameters = function () {
            return [
                { type: DelonAuthConfig },
                { type: undefined, decorators: [{ type: i0.Inject, args: [DA_STORE_TOKEN,] }] }
            ];
        };
        return TokenService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var DA_SERVICE_TOKEN = new i0.InjectionToken('DA_SERVICE_TOKEN', {
        providedIn: 'root',
        factory: DA_SERVICE_TOKEN_FACTORY,
    });

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var OPENTYPE = '_delonAuthSocialType';
    /** @type {?} */
    var HREFCALLBACK = '_delonAuthSocialCallbackByHref';
    var SocialService = /** @class */ (function () {
        function SocialService(tokenService, doc, router$$1) {
            this.tokenService = tokenService;
            this.doc = doc;
            this.router = router$$1;
        }
        /**
         * 跳转至登录页，若为 `type=window` 时，返回值是 `Observable<ITokenModel>`
         * @param url 获取授权地址
         * @param callback 当 `type=href` 成功时的回调路由地址
         * @param options.type 打开方式，默认 `window`
         * @param options.windowFeatures 等同 `window.open` 的 `features` 参数值
         */
        /**
         * 跳转至登录页，若为 `type=window` 时，返回值是 `Observable<ITokenModel>`
         * @param {?} url 获取授权地址
         * @param {?=} callback 当 `type=href` 成功时的回调路由地址
         * @param {?=} options
         * @return {?}
         */
        SocialService.prototype.login = /**
         * 跳转至登录页，若为 `type=window` 时，返回值是 `Observable<ITokenModel>`
         * @param {?} url 获取授权地址
         * @param {?=} callback 当 `type=href` 成功时的回调路由地址
         * @param {?=} options
         * @return {?}
         */
            function (url, callback, options) {
                var _this = this;
                if (callback === void 0) {
                    callback = '/';
                }
                if (options === void 0) {
                    options = {};
                }
                options = __assign({ type: 'window', windowFeatures: 'location=yes,height=570,width=520,scrollbars=yes,status=yes' }, options);
                localStorage.setItem(OPENTYPE, options.type);
                localStorage.setItem(HREFCALLBACK, callback);
                if (options.type === 'href') {
                    this.doc.location.href = url;
                    return;
                }
                this._win = window.open(url, '_blank', options.windowFeatures);
                this._winTime = setInterval(( /**
                 * @return {?}
                 */function () {
                    if (_this._win && _this._win.closed) {
                        _this.ngOnDestroy();
                        /** @type {?} */
                        var model = _this.tokenService.get();
                        if (model && !model.token)
                            model = null;
                        // 触发变更通知
                        if (model) {
                            _this.tokenService.set(model);
                        }
                        _this.observer.next(model);
                        _this.observer.complete();
                    }
                }), 100);
                return rxjs.Observable.create(( /**
                 * @param {?} observer
                 * @return {?}
                 */function (observer) {
                    _this.observer = observer;
                }));
            };
        /**
         * 授权成功后的回调处理
         *
         * @param rawData 指定回调认证信息，为空时从根据当前URL解析
         */
        /**
         * 授权成功后的回调处理
         *
         * @param {?=} rawData 指定回调认证信息，为空时从根据当前URL解析
         * @return {?}
         */
        SocialService.prototype.callback = /**
         * 授权成功后的回调处理
         *
         * @param {?=} rawData 指定回调认证信息，为空时从根据当前URL解析
         * @return {?}
         */
            function (rawData) {
                // from uri
                if (!rawData && this.router.url.indexOf('?') === -1) {
                    throw new Error("url muse contain a ?");
                }
                // parse
                /** @type {?} */
                var data = { token: "" };
                if (typeof rawData === 'string') {
                    /** @type {?} */
                    var rightUrl = rawData.split('?')[1].split('#')[0];
                    data = ( /** @type {?} */(this.router.parseUrl('./?' + rightUrl).queryParams));
                }
                else {
                    data = rawData;
                }
                if (!data || !data.token)
                    throw new Error("invalide token data");
                this.tokenService.set(data);
                /** @type {?} */
                var url = localStorage.getItem(HREFCALLBACK) || '/';
                localStorage.removeItem(HREFCALLBACK);
                /** @type {?} */
                var type = localStorage.getItem(OPENTYPE);
                localStorage.removeItem(OPENTYPE);
                if (type === 'window') {
                    window.close();
                }
                else {
                    this.router.navigateByUrl(url);
                }
                return data;
            };
        /**
         * @return {?}
         */
        SocialService.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                clearInterval(this._winTime);
                this._winTime = null;
            };
        SocialService.decorators = [
            { type: i0.Injectable }
        ];
        /** @nocollapse */
        SocialService.ctorParameters = function () {
            return [
                { type: undefined, decorators: [{ type: i0.Inject, args: [DA_SERVICE_TOKEN,] }] },
                { type: undefined, decorators: [{ type: i0.Inject, args: [common.DOCUMENT,] }] },
                { type: router.Router }
            ];
        };
        return SocialService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var MemoryStore = /** @class */ (function () {
        function MemoryStore() {
            this.cache = {};
        }
        /**
         * @param {?} key
         * @return {?}
         */
        MemoryStore.prototype.get = /**
         * @param {?} key
         * @return {?}
         */
            function (key) {
                return this.cache[key] || (( /** @type {?} */({})));
            };
        /**
         * @param {?} key
         * @param {?} value
         * @return {?}
         */
        MemoryStore.prototype.set = /**
         * @param {?} key
         * @param {?} value
         * @return {?}
         */
            function (key, value) {
                this.cache[key] = value;
                return true;
            };
        /**
         * @param {?} key
         * @return {?}
         */
        MemoryStore.prototype.remove = /**
         * @param {?} key
         * @return {?}
         */
            function (key) {
                this.cache[key] = null;
            };
        return MemoryStore;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var SessionStorageStore = /** @class */ (function () {
        function SessionStorageStore() {
        }
        /**
         * @param {?} key
         * @return {?}
         */
        SessionStorageStore.prototype.get = /**
         * @param {?} key
         * @return {?}
         */
            function (key) {
                return JSON.parse(sessionStorage.getItem(key) || '{}') || {};
            };
        /**
         * @param {?} key
         * @param {?} value
         * @return {?}
         */
        SessionStorageStore.prototype.set = /**
         * @param {?} key
         * @param {?} value
         * @return {?}
         */
            function (key, value) {
                sessionStorage.setItem(key, JSON.stringify(value));
                return true;
            };
        /**
         * @param {?} key
         * @return {?}
         */
        SessionStorageStore.prototype.remove = /**
         * @param {?} key
         * @return {?}
         */
            function (key) {
                sessionStorage.removeItem(key);
            };
        return SessionStorageStore;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * @param {?} model
     * @return {?}
     */
    function CheckSimple(model) {
        return model != null && typeof model.token === 'string' && model.token.length > 0;
    }
    /**
     * @param {?} model
     * @param {?} offset
     * @return {?}
     */
    function CheckJwt(model, offset) {
        return model != null && model.token && !model.isExpired(offset);
    }
    /**
     * @param {?} options
     * @param {?} injector
     * @param {?} url
     * @return {?}
     */
    function ToLogin(options, injector, url) {
        (( /** @type {?} */(injector.get(DA_SERVICE_TOKEN)))).referrer.url = url;
        if (options.token_invalid_redirect === true) {
            setTimeout(( /**
             * @return {?}
             */function () {
                if (/^https?:\/\//g.test(options.login_url)) {
                    injector.get(common.DOCUMENT).location.href = options.login_url;
                }
                else {
                    injector.get(router.Router).navigate([options.login_url]);
                }
            }));
        }
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var HttpAuthInterceptorHandler = /** @class */ (function () {
        function HttpAuthInterceptorHandler(next, interceptor) {
            this.next = next;
            this.interceptor = interceptor;
        }
        /**
         * @param {?} req
         * @return {?}
         */
        HttpAuthInterceptorHandler.prototype.handle = /**
         * @param {?} req
         * @return {?}
         */
            function (req) {
                return this.interceptor.intercept(req, this.next);
            };
        return HttpAuthInterceptorHandler;
    }());
    /**
     * @abstract
     */
    var BaseInterceptor = /** @class */ (function () {
        function BaseInterceptor(injector) {
            this.injector = injector;
        }
        /**
         * @param {?} req
         * @param {?} next
         * @return {?}
         */
        BaseInterceptor.prototype.intercept = /**
         * @param {?} req
         * @param {?} next
         * @return {?}
         */
            function (req, next) {
                var e_1, _a;
                /** @type {?} */
                var options = __assign({}, new DelonAuthConfig(), this.injector.get(DelonAuthConfig, null));
                if (options.ignores) {
                    try {
                        for (var _b = __values(( /** @type {?} */(options.ignores))), _c = _b.next(); !_c.done; _c = _b.next()) {
                            var item = _c.value;
                            if (item.test(req.url))
                                return next.handle(req);
                        }
                    }
                    catch (e_1_1) {
                        e_1 = { error: e_1_1 };
                    }
                    finally {
                        try {
                            if (_c && !_c.done && (_a = _b.return))
                                _a.call(_b);
                        }
                        finally {
                            if (e_1)
                                throw e_1.error;
                        }
                    }
                }
                if (options.allow_anonymous_key &&
                    (req.params.has(options.allow_anonymous_key) ||
                        new RegExp("[?|&]" + options.allow_anonymous_key + "=[^&]+").test(req.urlWithParams))) {
                    return next.handle(req);
                }
                if (this.isAuth(options)) {
                    req = this.setReq(req, options);
                }
                else {
                    ToLogin(options, this.injector, req.urlWithParams);
                    // Interrupt Http request, so need to generate a new Observable
                    /** @type {?} */
                    var err$_1 = new rxjs.Observable(( /**
                     * @param {?} observer
                     * @return {?}
                     */function (observer) {
                        /** @type {?} */
                        var res = new http.HttpErrorResponse({
                            url: req.url,
                            headers: req.headers,
                            status: 401,
                            statusText: "From Auth Intercept --> https://ng-alain.com/docs/auth",
                        });
                        observer.error(res);
                    }));
                    if (options.executeOtherInterceptors) {
                        /** @type {?} */
                        var interceptors = this.injector.get(http.HTTP_INTERCEPTORS, []);
                        /** @type {?} */
                        var lastInterceptors = interceptors.slice(interceptors.indexOf(this) + 1);
                        if (lastInterceptors.length > 0) {
                            /** @type {?} */
                            var chain = lastInterceptors.reduceRight(( /**
                             * @param {?} _next
                             * @param {?} _interceptor
                             * @return {?}
                             */function (_next, _interceptor) { return new HttpAuthInterceptorHandler(_next, _interceptor); }), { handle: ( /**
                                     * @param {?} _
                                     * @return {?}
                                     */function (_) { return err$_1; }) });
                            return chain.handle(req);
                        }
                    }
                    return err$_1;
                }
                return next.handle(req);
            };
        /** @nocollapse */
        BaseInterceptor.ctorParameters = function () {
            return [
                { type: i0.Injector, decorators: [{ type: i0.Optional }] }
            ];
        };
        return BaseInterceptor;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * @param {?} str
     * @return {?}
     */
    function urlBase64Decode(str) {
        /** @type {?} */
        var output = str.replace(/-/g, '+').replace(/_/g, '/');
        switch (output.length % 4) {
            case 0: {
                break;
            }
            case 2: {
                output += '==';
                break;
            }
            case 3: {
                output += '=';
                break;
            }
            default: {
                throw new Error("'atob' failed: The string to be decoded is not correctly encoded.");
            }
        }
        return b64DecodeUnicode(output);
    }
    /**
     * @param {?} str
     * @return {?}
     */
    function b64decode(str) {
        /** @type {?} */
        var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
        /** @type {?} */
        var output = '';
        str = String(str).replace(/=+$/, '');
        for (
        // initialize result and counters
        // tslint:disable:no-conditional-assignment binary-expression-operand-order
        var bc = 0, bs = void 0, buffer = void 0, idx = 0; 
        // get next character
        (buffer = str.charAt(idx++)); 
        // character found in table? initialize bit storage and add its ascii value;
        ~buffer &&
            ((bs = bc % 4 ? bs * 64 + buffer : buffer),
                // and if not first of each 4 characters,
                // convert the first 8 bits to one ascii character
                bc++ % 4)
            ? (output += String.fromCharCode(255 & (bs >> ((-2 * bc) & 6))))
            : 0) {
            // try to find character in table (0-63, not found => -1)
            buffer = chars.indexOf(buffer);
        }
        return output;
    }
    // https://developer.mozilla.org/en/docs/Web/API/WindowBase64/Base64_encoding_and_decoding#The_Unicode_Problem
    /**
     * @param {?} str
     * @return {?}
     */
    function b64DecodeUnicode(str) {
        return decodeURIComponent(Array.prototype.map
            .call(b64decode(str), ( /**
     * @param {?} c
     * @return {?}
     */function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }))
            .join(''));
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var JWTTokenModel = /** @class */ (function () {
        function JWTTokenModel() {
        }
        Object.defineProperty(JWTTokenModel.prototype, "payload", {
            /**
             * 获取载荷信息
             */
            get: /**
             * 获取载荷信息
             * @return {?}
             */ function () {
                /** @type {?} */
                var parts = (this.token || '').split('.');
                if (parts.length !== 3)
                    throw new Error('JWT must have 3 parts');
                /** @type {?} */
                var decoded = urlBase64Decode(parts[1]);
                return JSON.parse(decoded);
            },
            enumerable: true,
            configurable: true
        });
        /**
         * 检查Token是否过期，`payload` 必须包含 `exp` 时有效
         *
         * @param offsetSeconds 偏移量
         */
        /**
         * 检查Token是否过期，`payload` 必须包含 `exp` 时有效
         *
         * @param {?=} offsetSeconds 偏移量
         * @return {?}
         */
        JWTTokenModel.prototype.isExpired = /**
         * 检查Token是否过期，`payload` 必须包含 `exp` 时有效
         *
         * @param {?=} offsetSeconds 偏移量
         * @return {?}
         */
            function (offsetSeconds) {
                if (offsetSeconds === void 0) {
                    offsetSeconds = 0;
                }
                /** @type {?} */
                var decoded = this.payload;
                if (!decoded.hasOwnProperty('exp'))
                    return null;
                /** @type {?} */
                var date = new Date(0);
                date.setUTCSeconds(decoded.exp);
                return !(date.valueOf() > new Date().valueOf() + offsetSeconds * 1000);
            };
        return JWTTokenModel;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var JWTInterceptor = /** @class */ (function (_super) {
        __extends(JWTInterceptor, _super);
        function JWTInterceptor() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        /**
         * @param {?} options
         * @return {?}
         */
        JWTInterceptor.prototype.isAuth = /**
         * @param {?} options
         * @return {?}
         */
            function (options) {
                this.model = this.injector.get(DA_SERVICE_TOKEN).get(JWTTokenModel);
                return CheckJwt(( /** @type {?} */(this.model)), options.token_exp_offset);
            };
        /**
         * @param {?} req
         * @param {?} options
         * @return {?}
         */
        JWTInterceptor.prototype.setReq = /**
         * @param {?} req
         * @param {?} options
         * @return {?}
         */
            function (req, options) {
                return req.clone({
                    setHeaders: {
                        Authorization: "Bearer " + this.model.token,
                    },
                });
            };
        JWTInterceptor.decorators = [
            { type: i0.Injectable }
        ];
        return JWTInterceptor;
    }(BaseInterceptor));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var JWTGuard = /** @class */ (function () {
        function JWTGuard(srv, injector, cog) {
            this.srv = srv;
            this.injector = injector;
            this.cog = __assign({}, new DelonAuthConfig(), cog);
        }
        /**
         * @private
         * @return {?}
         */
        JWTGuard.prototype.process = /**
         * @private
         * @return {?}
         */
            function () {
                /** @type {?} */
                var res = CheckJwt(this.srv.get(JWTTokenModel), this.cog.token_exp_offset);
                if (!res) {
                    ToLogin(this.cog, this.injector, this.url);
                }
                return res;
            };
        // lazy loading
        // lazy loading
        /**
         * @param {?} route
         * @param {?} segments
         * @return {?}
         */
        JWTGuard.prototype.canLoad =
            // lazy loading
            /**
             * @param {?} route
             * @param {?} segments
             * @return {?}
             */
            function (route, segments) {
                this.url = route.path;
                return this.process();
            };
        // all children route
        // all children route
        /**
         * @param {?} childRoute
         * @param {?} state
         * @return {?}
         */
        JWTGuard.prototype.canActivateChild =
            // all children route
            /**
             * @param {?} childRoute
             * @param {?} state
             * @return {?}
             */
            function (childRoute, state) {
                this.url = state.url;
                return this.process();
            };
        // route
        // route
        /**
         * @param {?} route
         * @param {?} state
         * @return {?}
         */
        JWTGuard.prototype.canActivate =
            // route
            /**
             * @param {?} route
             * @param {?} state
             * @return {?}
             */
            function (route, state) {
                this.url = state.url;
                return this.process();
            };
        JWTGuard.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        JWTGuard.ctorParameters = function () {
            return [
                { type: undefined, decorators: [{ type: i0.Inject, args: [DA_SERVICE_TOKEN,] }] },
                { type: i0.Injector },
                { type: DelonAuthConfig }
            ];
        };
        /** @nocollapse */ JWTGuard.ngInjectableDef = i0.defineInjectable({ factory: function JWTGuard_Factory() { return new JWTGuard(i0.inject(DA_SERVICE_TOKEN), i0.inject(i0.INJECTOR), i0.inject(DelonAuthConfig)); }, token: JWTGuard, providedIn: "root" });
        return JWTGuard;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var SimpleTokenModel = /** @class */ (function () {
        function SimpleTokenModel() {
        }
        return SimpleTokenModel;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var SimpleInterceptor = /** @class */ (function (_super) {
        __extends(SimpleInterceptor, _super);
        function SimpleInterceptor() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        /**
         * @param {?} options
         * @return {?}
         */
        SimpleInterceptor.prototype.isAuth = /**
         * @param {?} options
         * @return {?}
         */
            function (options) {
                this.model = ( /** @type {?} */(this.injector.get(DA_SERVICE_TOKEN).get()));
                return CheckSimple(( /** @type {?} */(this.model)));
            };
        /**
         * @param {?} req
         * @param {?} options
         * @return {?}
         */
        SimpleInterceptor.prototype.setReq = /**
         * @param {?} req
         * @param {?} options
         * @return {?}
         */
            function (req, options) {
                var _this = this;
                /** @type {?} */
                var token = options.token_send_template.replace(/\$\{([\w]+)\}/g, ( /**
                 * @param {?} _
                 * @param {?} g
                 * @return {?}
                 */function (_, g) { return _this.model[g]; }));
                switch (options.token_send_place) {
                    case 'header':
                        /** @type {?} */
                        var obj = {};
                        obj[options.token_send_key] = token;
                        req = req.clone({
                            setHeaders: obj,
                        });
                        break;
                    case 'body':
                        /** @type {?} */
                        var body = req.body || {};
                        body[options.token_send_key] = token;
                        req = req.clone({
                            body: body,
                        });
                        break;
                    case 'url':
                        req = req.clone({
                            params: req.params.append(options.token_send_key, token),
                        });
                        break;
                }
                return req;
            };
        SimpleInterceptor.decorators = [
            { type: i0.Injectable }
        ];
        return SimpleInterceptor;
    }(BaseInterceptor));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var SimpleGuard = /** @class */ (function () {
        function SimpleGuard(srv, injector, cog) {
            this.srv = srv;
            this.injector = injector;
            this.cog = __assign({}, new DelonAuthConfig(), cog);
        }
        /**
         * @private
         * @return {?}
         */
        SimpleGuard.prototype.process = /**
         * @private
         * @return {?}
         */
            function () {
                /** @type {?} */
                var res = CheckSimple(this.srv.get());
                if (!res) {
                    ToLogin(this.cog, this.injector, this.url);
                }
                return res;
            };
        // lazy loading
        // lazy loading
        /**
         * @param {?} route
         * @param {?} segments
         * @return {?}
         */
        SimpleGuard.prototype.canLoad =
            // lazy loading
            /**
             * @param {?} route
             * @param {?} segments
             * @return {?}
             */
            function (route, segments) {
                this.url = route.path;
                return this.process();
            };
        // all children route
        // all children route
        /**
         * @param {?} childRoute
         * @param {?} state
         * @return {?}
         */
        SimpleGuard.prototype.canActivateChild =
            // all children route
            /**
             * @param {?} childRoute
             * @param {?} state
             * @return {?}
             */
            function (childRoute, state) {
                this.url = state.url;
                return this.process();
            };
        // route
        // route
        /**
         * @param {?} route
         * @param {?} state
         * @return {?}
         */
        SimpleGuard.prototype.canActivate =
            // route
            /**
             * @param {?} route
             * @param {?} state
             * @return {?}
             */
            function (route, state) {
                this.url = state.url;
                return this.process();
            };
        SimpleGuard.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        SimpleGuard.ctorParameters = function () {
            return [
                { type: undefined, decorators: [{ type: i0.Inject, args: [DA_SERVICE_TOKEN,] }] },
                { type: i0.Injector },
                { type: DelonAuthConfig }
            ];
        };
        /** @nocollapse */ SimpleGuard.ngInjectableDef = i0.defineInjectable({ factory: function SimpleGuard_Factory() { return new SimpleGuard(i0.inject(DA_SERVICE_TOKEN), i0.inject(i0.INJECTOR), i0.inject(DelonAuthConfig)); }, token: SimpleGuard, providedIn: "root" });
        return SimpleGuard;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var DelonAuthModule = /** @class */ (function () {
        function DelonAuthModule() {
        }
        DelonAuthModule.decorators = [
            { type: i0.NgModule, args: [{},] }
        ];
        return DelonAuthModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.SocialService = SocialService;
    exports.DA_STORE_TOKEN = DA_STORE_TOKEN;
    exports.DA_STORE_TOKEN_LOCAL_FACTORY = DA_STORE_TOKEN_LOCAL_FACTORY;
    exports.LocalStorageStore = LocalStorageStore;
    exports.MemoryStore = MemoryStore;
    exports.SessionStorageStore = SessionStorageStore;
    exports.BaseInterceptor = BaseInterceptor;
    exports.DA_SERVICE_TOKEN = DA_SERVICE_TOKEN;
    exports.DA_SERVICE_TOKEN_FACTORY = DA_SERVICE_TOKEN_FACTORY;
    exports.TokenService = TokenService;
    exports.urlBase64Decode = urlBase64Decode;
    exports.JWTTokenModel = JWTTokenModel;
    exports.JWTInterceptor = JWTInterceptor;
    exports.JWTGuard = JWTGuard;
    exports.SimpleTokenModel = SimpleTokenModel;
    exports.SimpleInterceptor = SimpleInterceptor;
    exports.SimpleGuard = SimpleGuard;
    exports.DelonAuthConfig = DelonAuthConfig;
    exports.DelonAuthModule = DelonAuthModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=auth.umd.js.map