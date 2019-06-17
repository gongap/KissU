/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('extend'), require('date-fns/add_days'), require('date-fns/end_of_day'), require('date-fns/end_of_month'), require('date-fns/end_of_week'), require('date-fns/end_of_year'), require('date-fns/parse'), require('date-fns/start_of_day'), require('date-fns/start_of_month'), require('date-fns/start_of_week'), require('date-fns/start_of_year'), require('date-fns/sub_months'), require('date-fns/sub_weeks'), require('date-fns/sub_years'), require('rxjs'), require('rxjs/operators'), require('ng-zorro-antd'), require('@angular/common'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('@delon/util', ['exports', 'extend', 'date-fns/add_days', 'date-fns/end_of_day', 'date-fns/end_of_month', 'date-fns/end_of_week', 'date-fns/end_of_year', 'date-fns/parse', 'date-fns/start_of_day', 'date-fns/start_of_month', 'date-fns/start_of_week', 'date-fns/start_of_year', 'date-fns/sub_months', 'date-fns/sub_weeks', 'date-fns/sub_years', 'rxjs', 'rxjs/operators', 'ng-zorro-antd', '@angular/common', '@angular/core'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.util = {}),global.Extend,global.addDays,global.endOfDay,global.endOfMonth,global.endOfWeek,global.endOfYear,global.parse,global.startOfDay,global.startOfMonth,global.startOfWeek,global.startOfYear,global.subMonths,global.subWeeks,global.subYears,global.rxjs,global.rxjs.operators,global['ng-zorro-antd'],global.ng.common,global.ng.core));
}(this, (function (exports,extend,addDays,endOfDay,endOfMonth,endOfWeek,endOfYear,parse,startOfDay,startOfMonth,startOfWeek,startOfYear,subMonths,subWeeks,subYears,rxjs,operators,ngZorroAntd,i1,i0) { 'use strict';

    extend = extend && extend.hasOwnProperty('default') ? extend['default'] : extend;
    addDays = addDays && addDays.hasOwnProperty('default') ? addDays['default'] : addDays;
    endOfDay = endOfDay && endOfDay.hasOwnProperty('default') ? endOfDay['default'] : endOfDay;
    endOfMonth = endOfMonth && endOfMonth.hasOwnProperty('default') ? endOfMonth['default'] : endOfMonth;
    endOfWeek = endOfWeek && endOfWeek.hasOwnProperty('default') ? endOfWeek['default'] : endOfWeek;
    endOfYear = endOfYear && endOfYear.hasOwnProperty('default') ? endOfYear['default'] : endOfYear;
    parse = parse && parse.hasOwnProperty('default') ? parse['default'] : parse;
    startOfDay = startOfDay && startOfDay.hasOwnProperty('default') ? startOfDay['default'] : startOfDay;
    startOfMonth = startOfMonth && startOfMonth.hasOwnProperty('default') ? startOfMonth['default'] : startOfMonth;
    startOfWeek = startOfWeek && startOfWeek.hasOwnProperty('default') ? startOfWeek['default'] : startOfWeek;
    startOfYear = startOfYear && startOfYear.hasOwnProperty('default') ? startOfYear['default'] : startOfYear;
    subMonths = subMonths && subMonths.hasOwnProperty('default') ? subMonths['default'] : subMonths;
    subWeeks = subWeeks && subWeeks.hasOwnProperty('default') ? subWeeks['default'] : subWeeks;
    subYears = subYears && subYears.hasOwnProperty('default') ? subYears['default'] : subYears;

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var StringTemplateOutletDirective = /** @class */ (function () {
        function StringTemplateOutletDirective(viewContainer, defaultTemplate) {
            this.viewContainer = viewContainer;
            this.defaultTemplate = defaultTemplate;
            this.inputTemplate = null;
            this.inputViewRef = null;
            this.defaultViewRef = null;
        }
        Object.defineProperty(StringTemplateOutletDirective.prototype, "stringTemplateOutlet", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                if (value instanceof i0.TemplateRef) {
                    this.isTemplate = true;
                    this.inputTemplate = value;
                }
                else {
                    this.isTemplate = false;
                }
                this.updateView();
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @return {?}
         */
        StringTemplateOutletDirective.prototype.updateView = /**
         * @return {?}
         */
            function () {
                if (!this.isTemplate) {
                    /** use default template when input is string **/
                    if (!this.defaultViewRef) {
                        this.viewContainer.clear();
                        this.inputViewRef = null;
                        this.defaultViewRef = this.viewContainer.createEmbeddedView(this.defaultTemplate);
                    }
                }
                else {
                    // clear previous view if any.
                    if (this.inputViewRef) {
                        this.inputViewRef = null;
                    }
                    /** use input template when input is templateRef **/
                    this.viewContainer.clear();
                    this.defaultViewRef = null;
                    this.inputViewRef = this.viewContainer.createEmbeddedView(this.inputTemplate);
                }
            };
        StringTemplateOutletDirective.decorators = [
            { type: i0.Directive, args: [{
                        selector: '[stringTemplateOutlet]',
                    },] }
        ];
        /** @nocollapse */
        StringTemplateOutletDirective.ctorParameters = function () {
            return [
                { type: i0.ViewContainerRef },
                { type: i0.TemplateRef }
            ];
        };
        StringTemplateOutletDirective.propDecorators = {
            stringTemplateOutlet: [{ type: i0.Input }]
        };
        return StringTemplateOutletDirective;
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
    /**
     * 类似 `_.get`，根据 `path` 获取安全值
     * jsperf: https://jsperf.com/es-deep-getttps://jsperf.com/es-deep-get
     *
     * @param {?} obj 数据源，无效时直接返回 `defaultValue` 值
     * @param {?} path 若 `null`、`[]`、未定义及未找到时返回 `defaultValue` 值
     * @param {?=} defaultValue 默认值
     * @return {?}
     */
    function deepGet(obj, path, defaultValue) {
        if (!obj || path == null || path.length === 0)
            return defaultValue;
        if (!Array.isArray(path)) {
            path = ~path.indexOf('.') ? path.split('.') : [path];
        }
        if (path.length === 1) {
            /** @type {?} */
            var checkObj = obj[path[0]];
            return typeof checkObj === 'undefined' ? defaultValue : checkObj;
        }
        /** @type {?} */
        var res = path.reduce(( /**
         * @param {?} o
         * @param {?} k
         * @return {?}
         */function (o, k) { return (o || {})[k]; }), obj);
        return typeof res === 'undefined' ? defaultValue : res;
    }
    /**
     * @param {?} obj
     * @return {?}
     */
    function deepCopy(obj) {
        /** @type {?} */
        var result = extend(true, {}, { _: obj });
        return result._;
    }
    /**
     * 复制内容至剪贴板
     * @param {?} value
     * @return {?}
     */
    function copy(value) {
        return new Promise(( /**
         * @param {?} resolve
         * @param {?} reject
         * @return {?}
         */function (resolve, reject) {
            /** @type {?} */
            var copyTextArea = ( /** @type {?} */(null));
            try {
                copyTextArea = document.createElement('textarea');
                copyTextArea.style.height = '0px';
                copyTextArea.style.opacity = '0';
                copyTextArea.style.width = '0px';
                document.body.appendChild(copyTextArea);
                copyTextArea.value = value;
                copyTextArea.select();
                document.execCommand('copy');
                resolve(value);
            }
            finally {
                if (copyTextArea && copyTextArea.parentNode) {
                    copyTextArea.parentNode.removeChild(copyTextArea);
                }
            }
        }));
    }
    /**
     * @param {?} original
     * @param {?} ingoreArray
     * @param {...?} objects
     * @return {?}
     */
    function deepMergeKey(original, ingoreArray) {
        var objects = [];
        for (var _i = 2; _i < arguments.length; _i++) {
            objects[_i - 2] = arguments[_i];
        }
        if (Array.isArray(original) || typeof original !== 'object')
            return original;
        /** @type {?} */
        var isObject = ( /**
         * @param {?} v
         * @return {?}
         */function (v) { return typeof v === 'object' || typeof v === 'function'; });
        /** @type {?} */
        var merge = ( /**
         * @param {?} target
         * @param {?} obj
         * @return {?}
         */function (target, obj) {
            Object.keys(obj)
                .filter(( /**
         * @param {?} key
         * @return {?}
         */function (key) { return key !== '__proto__' && Object.prototype.hasOwnProperty.call(obj, key); }))
                .forEach(( /**
         * @param {?} key
         * @return {?}
         */function (key) {
                /** @type {?} */
                var oldValue = obj[key];
                /** @type {?} */
                var newValue = target[key];
                if (!ingoreArray && Array.isArray(newValue)) {
                    target[key] = __spread(newValue, oldValue);
                }
                else if (oldValue != null &&
                    isObject(oldValue) &&
                    newValue != null &&
                    isObject(newValue)) {
                    target[key] = merge(newValue, oldValue);
                }
                else {
                    target[key] = deepCopy(oldValue);
                }
            }));
            return target;
        });
        objects.filter(( /**
         * @param {?} v
         * @return {?}
         */function (v) { return isObject(v); })).forEach(( /**
         * @param {?} v
         * @return {?}
         */function (v) { return merge(original, v); }));
        return original;
    }
    /**
     * @param {?} original
     * @param {...?} objects
     * @return {?}
     */
    function deepMerge(original) {
        var objects = [];
        for (var _i = 1; _i < arguments.length; _i++) {
            objects[_i - 1] = arguments[_i];
        }
        return deepMergeKey.apply(void 0, __spread([original, false], objects));
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * 字符串格式化
     * ```
     * format('this is ${name}', { name: 'asdf' })
     * // output: this is asdf
     * format('this is ${user.name}', { user: { name: 'asdf' } }, true)
     * // output: this is asdf
     * ```
     * @param {?} str
     * @param {?} obj
     * @param {?=} needDeepGet
     * @return {?}
     */
    function format(str, obj, needDeepGet) {
        if (needDeepGet === void 0) {
            needDeepGet = false;
        }
        return (str || '').replace(/\${([^}]+)}/g, ( /**
         * @param {?} work
         * @param {?} key
         * @return {?}
         */function (work, key) {
            return needDeepGet ? deepGet(obj, key.split('.'), '') : (obj || {})[key] || '';
        }));
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * 获取时间范围
     * @param {?} type 类型，带 `-` 表示过去一个时间，若指定 `number` 表示天数
     * @param {?=} time 开始时间
     * @return {?}
     */
    function getTimeDistance(type, time) {
        time = parse(time || new Date());
        /** @type {?} */
        var options = { weekStartsOn: 1 };
        /** @type {?} */
        var res;
        switch (type) {
            case 'today':
                res = [time, time];
                break;
            case '-today':
                res = [addDays(time, -1), time];
                break;
            case 'yesterday':
                res = [addDays(time, -1), addDays(time, -1)];
                break;
            case 'week':
                res = [startOfWeek(time, options), endOfWeek(time, options)];
                break;
            case '-week':
                res = [startOfWeek(subWeeks(time, 1), options), endOfWeek(subWeeks(time, 1), options)];
                break;
            case 'month':
                res = [startOfMonth(time), endOfMonth(time)];
                break;
            case '-month':
                res = [startOfMonth(subMonths(time, 1)), endOfMonth(subMonths(time, 1))];
                break;
            case 'year':
                res = [startOfYear(time), endOfYear(time)];
                break;
            case '-year':
                res = [startOfYear(subYears(time, 1)), endOfYear(subYears(time, 1))];
                break;
            default:
                res = type > 0 ? [time, addDays(time, type)] : [addDays(time, type), time];
                break;
        }
        return fixEndTimeOfRange(res);
    }
    /**
     * fix time is the most, big value
     * @param {?} dates
     * @return {?}
     */
    function fixEndTimeOfRange(dates) {
        return [startOfDay(dates[0]), endOfDay(dates[1])];
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var LazyService = /** @class */ (function () {
        function LazyService(doc) {
            this.doc = doc;
            this.list = {};
            this.cached = {};
            this._notify = new rxjs.BehaviorSubject([]);
        }
        Object.defineProperty(LazyService.prototype, "change", {
            get: /**
             * @return {?}
             */ function () {
                return this._notify.asObservable().pipe(operators.share(), operators.filter(( /**
                 * @param {?} ls
                 * @return {?}
                 */function (ls) { return ls.length !== 0; })));
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @return {?}
         */
        LazyService.prototype.clear = /**
         * @return {?}
         */
            function () {
                this.list = {};
                this.cached = {};
            };
        /**
         * @param {?} paths
         * @return {?}
         */
        LazyService.prototype.load = /**
         * @param {?} paths
         * @return {?}
         */
            function (paths) {
                var _this = this;
                if (!Array.isArray(paths)) {
                    paths = [paths];
                }
                /** @type {?} */
                var promises = [];
                paths.forEach(( /**
                 * @param {?} path
                 * @return {?}
                 */function (path) {
                    if (path.endsWith('.js')) {
                        promises.push(_this.loadScript(path));
                    }
                    else {
                        promises.push(_this.loadStyle(path));
                    }
                }));
                return Promise.all(promises).then(( /**
                 * @param {?} res
                 * @return {?}
                 */function (res) {
                    _this._notify.next(res);
                    return Promise.resolve(res);
                }));
            };
        /**
         * @param {?} path
         * @param {?=} innerContent
         * @return {?}
         */
        LazyService.prototype.loadScript = /**
         * @param {?} path
         * @param {?=} innerContent
         * @return {?}
         */
            function (path, innerContent) {
                var _this = this;
                return new Promise(( /**
                 * @param {?} resolve
                 * @return {?}
                 */function (resolve) {
                    if (_this.list[path] === true) {
                        resolve(_this.cached[path]);
                        return;
                    }
                    _this.list[path] = true;
                    /** @type {?} */
                    var onSuccess = ( /**
                     * @param {?} item
                     * @return {?}
                     */function (item) {
                        _this.cached[path] = item;
                        resolve(item);
                    });
                    /** @type {?} */
                    var node = ( /** @type {?} */(_this.doc.createElement('script')));
                    node.type = 'text/javascript';
                    node.src = path;
                    node.charset = 'utf-8';
                    if (innerContent) {
                        node.innerHTML = innerContent;
                    }
                    if (node.readyState) {
                        // IE
                        node.onreadystatechange = ( /**
                         * @return {?}
                         */function () {
                            if (node.readyState === 'loaded' || node.readyState === 'complete') {
                                node.onreadystatechange = null;
                                onSuccess({
                                    path: path,
                                    loaded: true,
                                    status: 'ok',
                                });
                            }
                        });
                    }
                    else {
                        node.onload = ( /**
                         * @return {?}
                         */function () {
                            return onSuccess({
                                path: path,
                                loaded: true,
                                status: 'ok',
                            });
                        });
                    }
                    node.onerror = ( /**
                     * @param {?} error
                     * @return {?}
                     */function (error) {
                        return onSuccess({
                            path: path,
                            loaded: false,
                            status: 'error',
                            error: error,
                        });
                    });
                    _this.doc.getElementsByTagName('head')[0].appendChild(node);
                }));
            };
        /**
         * @param {?} path
         * @param {?=} rel
         * @param {?=} innerContent
         * @return {?}
         */
        LazyService.prototype.loadStyle = /**
         * @param {?} path
         * @param {?=} rel
         * @param {?=} innerContent
         * @return {?}
         */
            function (path, rel, innerContent) {
                var _this = this;
                if (rel === void 0) {
                    rel = 'stylesheet';
                }
                return new Promise(( /**
                 * @param {?} resolve
                 * @return {?}
                 */function (resolve) {
                    if (_this.list[path] === true) {
                        resolve(_this.cached[path]);
                        return;
                    }
                    _this.list[path] = true;
                    /** @type {?} */
                    var node = ( /** @type {?} */(_this.doc.createElement('link')));
                    node.rel = rel;
                    node.type = 'text/css';
                    node.href = path;
                    if (innerContent) {
                        node.innerHTML = innerContent;
                    }
                    _this.doc.getElementsByTagName('head')[0].appendChild(node);
                    /** @type {?} */
                    var item = {
                        path: path,
                        loaded: true,
                        status: 'ok',
                    };
                    _this.cached[path] = item;
                    resolve(item);
                }));
            };
        LazyService.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        LazyService.ctorParameters = function () {
            return [
                { type: undefined, decorators: [{ type: i0.Inject, args: [i1.DOCUMENT,] }] }
            ];
        };
        /** @nocollapse */ LazyService.ngInjectableDef = i0.defineInjectable({ factory: function LazyService_Factory() { return new LazyService(i0.inject(i1.DOCUMENT)); }, token: LazyService, providedIn: "root" });
        return LazyService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * 是否为数字
     * @param {?} value
     * @return {?}
     */
    function isNum(value) {
        return /^((-?\d+\.\d+)|(-?\d+)|(-?\.\d+))$/.test(value.toString());
    }
    /**
     * 是否为整数
     * @param {?} value
     * @return {?}
     */
    function isInt(value) {
        // tslint:disable-next-line:triple-equals
        return isNum(value) && parseInt(value.toString(), 10) == value;
    }
    /**
     * 是否为小数
     * @param {?} value
     * @return {?}
     */
    function isDecimal(value) {
        return isNum(value) && !isInt(value);
    }
    /**
     * 是否为身份证
     * @param {?} value
     * @return {?}
     */
    function isIdCard(value) {
        return typeof value === 'string' && /(^\d{15}$)|(^\d{17}([0-9]|X)$)/i.test(value);
    }
    /**
     * 是否为手机号
     * @param {?} value
     * @return {?}
     */
    function isMobile(value) {
        return (typeof value === 'string' &&
            /^(0|\+?86|17951)?(13[0-9]|15[0-9]|17[0678]|18[0-9]|14[57])[0-9]{8}$/.test(value));
    }
    /**
     * 是否URL地址
     * @param {?} url
     * @return {?}
     */
    function isUrl(url) {
        return /(((^https?:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+(?::\d+)?|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)$/.test(url);
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * 一套日常验证器
     */
    // tslint:disable-next-line:class-name
    var  /**
     * 一套日常验证器
     */ 
    // tslint:disable-next-line:class-name
    _Validators = /** @class */ (function () {
        function _Validators() {
        }
        /** 是否为数字 */
        /**
         * 是否为数字
         * @param {?} control
         * @return {?}
         */
        _Validators.num = /**
         * 是否为数字
         * @param {?} control
         * @return {?}
         */
            function (control) {
                return isNum(control.value) ? null : { num: true };
            };
        /** 是否为整数 */
        /**
         * 是否为整数
         * @param {?} control
         * @return {?}
         */
        _Validators.int = /**
         * 是否为整数
         * @param {?} control
         * @return {?}
         */
            function (control) {
                return isInt(control.value) ? null : { int: true };
            };
        /** 是否为小数 */
        /**
         * 是否为小数
         * @param {?} control
         * @return {?}
         */
        _Validators.decimal = /**
         * 是否为小数
         * @param {?} control
         * @return {?}
         */
            function (control) {
                return isDecimal(control.value) ? null : { decimal: true };
            };
        /** 是否为身份证 */
        /**
         * 是否为身份证
         * @param {?} control
         * @return {?}
         */
        _Validators.idCard = /**
         * 是否为身份证
         * @param {?} control
         * @return {?}
         */
            function (control) {
                return isIdCard(control.value) ? null : { idCard: true };
            };
        /** 是否为手机号 */
        /**
         * 是否为手机号
         * @param {?} control
         * @return {?}
         */
        _Validators.mobile = /**
         * 是否为手机号
         * @param {?} control
         * @return {?}
         */
            function (control) {
                return isMobile(control.value) ? null : { mobile: true };
            };
        /** 是否URL地址 */
        /**
         * 是否URL地址
         * @param {?} control
         * @return {?}
         */
        _Validators.url = /**
         * 是否URL地址
         * @param {?} control
         * @return {?}
         */
            function (control) {
                return isUrl(control.value) ? null : { url: true };
            };
        return _Validators;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * @param {?} element
     * @return {?}
     */
    function isEmpty(element) {
        /** @type {?} */
        var nodes = element.childNodes;
        for (var i = 0; i < nodes.length; i++) {
            /** @type {?} */
            var node = nodes.item(i);
            if (node.nodeType === 1 && (( /** @type {?} */(node))).outerHTML.toString().trim().length !== 0) {
                return false;
            }
            else if (node.nodeType === 3 && node.textContent.toString().trim().length !== 0) {
                return false;
            }
        }
        return true;
    }
    /**
     * @param {?} value
     * @param {?=} allowUndefined
     * @return {?}
     */
    function toBoolean(value, allowUndefined) {
        if (allowUndefined === void 0) {
            allowUndefined = false;
        }
        return allowUndefined && typeof value === 'undefined'
            ? undefined
            : value != null && "" + value !== 'false';
    }
    /**
     * Input decorator that handle a prop to do get/set automatically with toBoolean
     * \@example
     * ```typescript
     * \@Input() \@InputBoolean() visible: boolean = false; / \@InputBoolean(null) visible: boolean = false;
     * ```
     * @param {?=} allowUndefined
     * @return {?}
     */
    function InputBoolean(allowUndefined) {
        if (allowUndefined === void 0) {
            allowUndefined = false;
        }
        return ( /**
         * @param {?} target
         * @param {?} name
         * @return {?}
         */function InputBooleanPropDecorator(target, name) {
            // Add our own private prop
            /** @type {?} */
            var privatePropName = "$$__" + name;
            if (Object.prototype.hasOwnProperty.call(target, privatePropName)) {
                console.warn("The prop \"" + privatePropName + "\" is already exist, it will be overrided by InputBoolean decorator.");
            }
            Object.defineProperty(target, privatePropName, {
                configurable: true,
                writable: true,
            });
            Object.defineProperty(target, name, {
                get: /**
                 * @return {?}
                 */ function () {
                    return this[privatePropName]; // tslint:disable-line:no-invalid-this
                },
                set: /**
                 * @param {?} value
                 * @return {?}
                 */ function (value) {
                    this[privatePropName] = toBoolean(value, allowUndefined); // tslint:disable-line:no-invalid-this
                },
            });
        });
    }
    /**
     * @param {?} value
     * @param {?=} fallbackValue
     * @return {?}
     */
    function toNumber(value, fallbackValue) {
        if (fallbackValue === void 0) {
            fallbackValue = 0;
        }
        return !isNaN(parseFloat(( /** @type {?} */(value)))) && !isNaN(Number(value)) ? Number(value) : fallbackValue;
    }
    /**
     * Input decorator that handle a prop to do get/set automatically with toNumber
     * \@example
     * ```typescript
     * \@Input() \@InputNumber() visible: number = 1; / \@InputNumber(null) visible: number = 2;
     * ```
     * @param {?=} fallback
     * @return {?}
     */
    function InputNumber(fallback) {
        if (fallback === void 0) {
            fallback = 0;
        }
        return ( /**
         * @param {?} target
         * @param {?} name
         * @return {?}
         */function InputBooleanPropDecorator(target, name) {
            // Add our own private prop
            /** @type {?} */
            var privatePropName = "$$__" + name;
            if (Object.prototype.hasOwnProperty.call(target, privatePropName)) {
                console.warn("The prop \"" + privatePropName + "\" is already exist, it will be overrided by InputNumber decorator.");
            }
            Object.defineProperty(target, privatePropName, {
                configurable: true,
                writable: true,
            });
            Object.defineProperty(target, name, {
                get: /**
                 * @return {?}
                 */ function () {
                    return this[privatePropName]; // tslint:disable-line:no-invalid-this
                },
                set: /**
                 * @param {?} value
                 * @return {?}
                 */ function (value) {
                    this[privatePropName] = toNumber(value, fallback); // tslint:disable-line:no-invalid-this
                },
            });
        });
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * @param {?} el
     * @param {?} classMap
     * @param {?} renderer
     * @return {?}
     */
    function removeClass(el, classMap, renderer) {
        for (var i in classMap) {
            renderer.removeClass(el, i);
        }
    }
    /**
     * @param {?} el
     * @param {?} classMap
     * @param {?} renderer
     * @return {?}
     */
    function addClass(el, classMap, renderer) {
        for (var i in classMap) {
            if (classMap[i]) {
                renderer.addClass(el, i);
            }
        }
    }
    /**
     * 更新宿主组件样式 `class`，例如：
     *
     * ```ts
     * updateHostClass(
     *  this.el.nativeElement,
     *  this.renderer,
     *  {
     *    [ 'classname' ]: true,
     *    [ 'classname' ]: this.type === '1',
     *    [ this.cls ]: true,
     *    [ `a-${this.cls}` ]: true
     *  })
     * ```
     *
     * @param {?} el
     * @param {?} renderer
     * @param {?} classMap
     * @param {?=} cleanAll
     * @return {?}
     */
    function updateHostClass(el, renderer, classMap, cleanAll) {
        if (cleanAll === void 0) {
            cleanAll = false;
        }
        if (cleanAll === true) {
            renderer.removeAttribute(el, 'class');
        }
        else {
            removeClass(el, classMap, renderer);
        }
        classMap = __assign({}, classMap);
        addClass(el, classMap, renderer);
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var DelonUtilConfig = /** @class */ (function () {
        function DelonUtilConfig() {
        }
        DelonUtilConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ DelonUtilConfig.ngInjectableDef = i0.defineInjectable({ factory: function DelonUtilConfig_Factory() { return new DelonUtilConfig(); }, token: DelonUtilConfig, providedIn: "root" });
        return DelonUtilConfig;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ArrayService = /** @class */ (function () {
        function ArrayService(cog) {
            this.c = __assign({ deepMapName: 'deep', parentMapName: 'parent', idMapName: 'id', parentIdMapName: 'parent_id', childrenMapName: 'children', titleMapName: 'title', checkedMapname: 'checked', selectedMapname: 'selected', expandedMapname: 'expanded', disabledMapname: 'disabled' }, (cog && cog.array));
        }
        /**
         * 将树结构转换成数组结构
         */
        /**
         * 将树结构转换成数组结构
         * @param {?} tree
         * @param {?=} options
         * @return {?}
         */
        ArrayService.prototype.treeToArr = /**
         * 将树结构转换成数组结构
         * @param {?} tree
         * @param {?=} options
         * @return {?}
         */
            function (tree, options) {
                options = __assign({ deepMapName: this.c.deepMapName, parentMapName: this.c.parentMapName, childrenMapName: this.c.childrenMapName, clearChildren: true, cb: null }, options);
                /** @type {?} */
                var result = [];
                /** @type {?} */
                var inFn = ( /**
                 * @param {?} list
                 * @param {?} parent
                 * @param {?} deep
                 * @return {?}
                 */function (list, parent, deep) {
                    var e_1, _a;
                    try {
                        for (var list_1 = __values(list), list_1_1 = list_1.next(); !list_1_1.done; list_1_1 = list_1.next()) {
                            var i = list_1_1.value;
                            i[options.deepMapName] = deep;
                            i[options.parentMapName] = parent;
                            if (options.cb) {
                                options.cb(i, parent, deep);
                            }
                            result.push(i);
                            /** @type {?} */
                            var children = i[options.childrenMapName];
                            if (children != null && Array.isArray(children) && children.length > 0) {
                                inFn(children, i, deep + 1);
                            }
                            if (options.clearChildren) {
                                delete i[options.childrenMapName];
                            }
                        }
                    }
                    catch (e_1_1) {
                        e_1 = { error: e_1_1 };
                    }
                    finally {
                        try {
                            if (list_1_1 && !list_1_1.done && (_a = list_1.return))
                                _a.call(list_1);
                        }
                        finally {
                            if (e_1)
                                throw e_1.error;
                        }
                    }
                });
                inFn(tree, 1, null);
                return result;
            };
        /**
         * 数组转换成树数据
         */
        /**
         * 数组转换成树数据
         * @param {?} arr
         * @param {?=} options
         * @return {?}
         */
        ArrayService.prototype.arrToTree = /**
         * 数组转换成树数据
         * @param {?} arr
         * @param {?=} options
         * @return {?}
         */
            function (arr, options) {
                var e_2, _a;
                options = __assign({ idMapName: this.c.idMapName, parentIdMapName: this.c.parentIdMapName, childrenMapName: this.c.childrenMapName, cb: null }, options);
                /** @type {?} */
                var tree = [];
                /** @type {?} */
                var childrenOf = {};
                try {
                    for (var arr_1 = __values(arr), arr_1_1 = arr_1.next(); !arr_1_1.done; arr_1_1 = arr_1.next()) {
                        var item = arr_1_1.value;
                        /** @type {?} */
                        var id = item[options.idMapName];
                        /** @type {?} */
                        var pid = item[options.parentIdMapName];
                        childrenOf[id] = childrenOf[id] || [];
                        item[options.childrenMapName] = childrenOf[id];
                        if (options.cb) {
                            options.cb(item);
                        }
                        if (pid) {
                            childrenOf[pid] = childrenOf[pid] || [];
                            childrenOf[pid].push(item);
                        }
                        else {
                            tree.push(item);
                        }
                    }
                }
                catch (e_2_1) {
                    e_2 = { error: e_2_1 };
                }
                finally {
                    try {
                        if (arr_1_1 && !arr_1_1.done && (_a = arr_1.return))
                            _a.call(arr_1);
                    }
                    finally {
                        if (e_2)
                            throw e_2.error;
                    }
                }
                return tree;
            };
        /**
         * 数组转换成 `nz-tree` 数据源，通过 `options` 转化项名，也可以使用 `options.cb` 更高级决定数据项
         */
        /**
         * 数组转换成 `nz-tree` 数据源，通过 `options` 转化项名，也可以使用 `options.cb` 更高级决定数据项
         * @param {?} arr
         * @param {?=} options
         * @return {?}
         */
        ArrayService.prototype.arrToTreeNode = /**
         * 数组转换成 `nz-tree` 数据源，通过 `options` 转化项名，也可以使用 `options.cb` 更高级决定数据项
         * @param {?} arr
         * @param {?=} options
         * @return {?}
         */
            function (arr, options) {
                options = __assign({ idMapName: this.c.idMapName, parentIdMapName: this.c.parentIdMapName, titleMapName: this.c.titleMapName, isLeafMapName: 'isLeaf', checkedMapname: this.c.checkedMapname, selectedMapname: this.c.selectedMapname, expandedMapname: this.c.expandedMapname, disabledMapname: this.c.disabledMapname, cb: null }, options);
                /** @type {?} */
                var tree = this.arrToTree(arr, {
                    idMapName: options.idMapName,
                    parentIdMapName: options.parentIdMapName,
                    childrenMapName: 'children',
                });
                this.visitTree(tree, ( /**
                 * @param {?} item
                 * @param {?} parent
                 * @param {?} deep
                 * @return {?}
                 */function (item, parent, deep) {
                    item.key = item[options.idMapName];
                    item.title = item[options.titleMapName];
                    item.checked = item[options.checkedMapname];
                    item.selected = item[options.selectedMapname];
                    item.expanded = item[options.expandedMapname];
                    item.disabled = item[options.disabledMapname];
                    if (item[options.isLeafMapName] == null) {
                        item.isLeaf = item.children.length === 0;
                    }
                    else {
                        item.isLeaf = item[options.isLeafMapName];
                    }
                    if (options.cb) {
                        options.cb(item, parent, deep);
                    }
                }));
                return tree.map(( /**
                 * @param {?} node
                 * @return {?}
                 */function (node) { return new ngZorroAntd.NzTreeNode(node); }));
            };
        /**
         * 递归访问整个树
         */
        /**
         * 递归访问整个树
         * @param {?} tree
         * @param {?} cb
         * @param {?=} options
         * @return {?}
         */
        ArrayService.prototype.visitTree = /**
         * 递归访问整个树
         * @param {?} tree
         * @param {?} cb
         * @param {?=} options
         * @return {?}
         */
            function (tree, cb, options) {
                options = __assign({ childrenMapName: this.c.childrenMapName }, options);
                /** @type {?} */
                var inFn = ( /**
                 * @param {?} data
                 * @param {?} parent
                 * @param {?} deep
                 * @return {?}
                 */function (data, parent, deep) {
                    var e_3, _a;
                    try {
                        for (var data_1 = __values(data), data_1_1 = data_1.next(); !data_1_1.done; data_1_1 = data_1.next()) {
                            var item = data_1_1.value;
                            cb(item, parent, deep);
                            /** @type {?} */
                            var childrenVal = item[options.childrenMapName];
                            if (childrenVal && childrenVal.length > 0) {
                                inFn(childrenVal, item, deep + 1);
                            }
                        }
                    }
                    catch (e_3_1) {
                        e_3 = { error: e_3_1 };
                    }
                    finally {
                        try {
                            if (data_1_1 && !data_1_1.done && (_a = data_1.return))
                                _a.call(data_1);
                        }
                        finally {
                            if (e_3)
                                throw e_3.error;
                        }
                    }
                });
                inFn(tree, null, 1);
            };
        /**
         * 获取所有已经选中的 `key` 值
         */
        /**
         * 获取所有已经选中的 `key` 值
         * @param {?} tree
         * @param {?=} options
         * @return {?}
         */
        ArrayService.prototype.getKeysByTreeNode = /**
         * 获取所有已经选中的 `key` 值
         * @param {?} tree
         * @param {?=} options
         * @return {?}
         */
            function (tree, options) {
                options = __assign({ includeHalfChecked: true }, options);
                /** @type {?} */
                var keys = [];
                this.visitTree(tree, ( /**
                 * @param {?} item
                 * @param {?} parent
                 * @param {?} deep
                 * @return {?}
                 */function (item, parent, deep) {
                    if (item.isChecked || (options.includeHalfChecked && item.isHalfChecked)) {
                        keys.push(options.cb
                            ? options.cb(item, parent, deep)
                            : options.keyMapName
                                ? item.origin[options.keyMapName]
                                : item.key);
                    }
                }));
                return keys;
            };
        ArrayService.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        ArrayService.ctorParameters = function () {
            return [
                { type: DelonUtilConfig }
            ];
        };
        /** @nocollapse */ ArrayService.ngInjectableDef = i0.defineInjectable({ factory: function ArrayService_Factory() { return new ArrayService(i0.inject(DelonUtilConfig)); }, token: ArrayService, providedIn: "root" });
        return ArrayService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var DelonUtilModule = /** @class */ (function () {
        function DelonUtilModule() {
        }
        DelonUtilModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [i1.CommonModule],
                        declarations: [StringTemplateOutletDirective],
                        exports: [StringTemplateOutletDirective],
                    },] }
        ];
        return DelonUtilModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports._Validators = _Validators;
    exports.StringTemplateOutletDirective = StringTemplateOutletDirective;
    exports.format = format;
    exports.getTimeDistance = getTimeDistance;
    exports.fixEndTimeOfRange = fixEndTimeOfRange;
    exports.LazyService = LazyService;
    exports.isNum = isNum;
    exports.isInt = isInt;
    exports.isDecimal = isDecimal;
    exports.isIdCard = isIdCard;
    exports.isMobile = isMobile;
    exports.isUrl = isUrl;
    exports.isEmpty = isEmpty;
    exports.toBoolean = toBoolean;
    exports.InputBoolean = InputBoolean;
    exports.toNumber = toNumber;
    exports.InputNumber = InputNumber;
    exports.deepGet = deepGet;
    exports.deepCopy = deepCopy;
    exports.copy = copy;
    exports.deepMergeKey = deepMergeKey;
    exports.deepMerge = deepMerge;
    exports.updateHostClass = updateHostClass;
    exports.ArrayService = ArrayService;
    exports.DelonUtilConfig = DelonUtilConfig;
    exports.DelonUtilModule = DelonUtilModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=util.umd.js.map