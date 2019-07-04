/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/number-to-chinese', ['exports', '@angular/common', '@angular/core'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['number-to-chinese'] = {}),global.ng.common,global.ng.core));
}(this, (function (exports,common,core) { 'use strict';

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

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /**
     * @param {?} value
     * @param {?=} rmb
     * @param {?=} options
     * @return {?}
     */
    function numberToChinese(value, rmb, options) {
        if (rmb === void 0) {
            rmb = true;
        }
        var _a;
        options = __assign({ minusSymbol: '负', validThrow: false }, options);
        if (typeof value === 'number')
            value = value.toString();
        if (!/^-?\d+(\.\d+)?$/.test(value) && options.validThrow)
            throw new Error(value + " is invalid number type");
        /** @type {?} */
        var integer;
        /** @type {?} */
        var decimal;
        _a = __read(value.split('.'), 2), integer = _a[0], decimal = _a[1];
        /** @type {?} */
        var symbol = '';
        if (integer.startsWith('-')) {
            symbol = options.minusSymbol;
            integer = integer.substr(1);
        }
        if (/^-?\d+$/.test(value))
            decimal = null;
        integer = (+integer).toString();
        /** @type {?} */
        var unit = {
            num: rmb
                ? ['', '壹', '贰', '叁', '肆', '伍', '陆', '柒', '捌', '玖', '点']
                : ['', '一', '二', '三', '四', '五', '六', '七', '八', '九', '点'],
            radice: rmb
                ? [
                    '',
                    '拾',
                    '佰',
                    '仟',
                    '万',
                    '拾',
                    '佰',
                    '仟',
                    '亿',
                    '拾',
                    '佰',
                    '仟',
                    '万亿',
                    '拾',
                    '佰',
                    '仟',
                    '兆',
                    '拾',
                    '佰',
                    '仟',
                ]
                : [
                    '',
                    '十',
                    '百',
                    '千',
                    '万',
                    '十',
                    '百',
                    '千',
                    '亿',
                    '十',
                    '百',
                    '千',
                    '万亿',
                    '十',
                    '百',
                    '千',
                    '兆',
                    '十',
                    '百',
                    '千',
                ],
            dec: ['角', '分', '厘', '毫'],
        };
        if (rmb)
            value = (+value).toFixed(5).toString();
        /** @type {?} */
        var integerRes = '';
        /** @type {?} */
        var integerCount = integer.length;
        if (integer === '0' || integerCount === 0) {
            integerRes = '零';
        }
        else {
            /** @type {?} */
            var cnDesc = '';
            for (var i = 0; i < integerCount; i++) {
                /** @type {?} */
                var n = +integer[i];
                /** @type {?} */
                var j = integerCount - i - 1;
                /** @type {?} */
                var isZero = i > 1 && n !== 0 && integer[i - 1] === '0';
                /** @type {?} */
                var cnZero = isZero ? '零' : '';
                /** @type {?} */
                var isEmpptyUnit = (n === 0 && j % 4 !== 0) || integer.substr(i - 3, 4) === '0000';
                /** @type {?} */
                var descMark = cnDesc;
                /** @type {?} */
                var cnNum = unit.num[n];
                cnDesc = isEmpptyUnit ? '' : unit.radice[j];
                // 第一位是一十
                if (i === 0 && cnNum === '一' && cnDesc === '十')
                    cnNum = '';
                /** @type {?} */
                var isChangeEr = n > 1 &&
                    cnNum === '二' && // 去除首位
                    ['', '十', '百'].indexOf(cnDesc) === -1 && // 不读两\两十\两百
                    descMark !== '十';
                if (isChangeEr)
                    cnNum = '两';
                integerRes += cnZero + cnNum + cnDesc;
            }
        }
        // 小数部分拼接
        /** @type {?} */
        var decimalRes = '';
        /** @type {?} */
        var decimalCount = decimal ? decimal.toString().length : 0;
        if (decimal === null) {
            decimalRes = rmb ? '整' : '';
        }
        else if (decimal === '0') {
            decimalRes = '零';
        }
        else {
            for (var i = 0; i < decimalCount; i++) {
                if (rmb && i > unit.dec.length - 1)
                    break;
                /** @type {?} */
                var n = decimal[i];
                /** @type {?} */
                var cnZero = n === '0' ? '零' : '';
                /** @type {?} */
                var cnNum = unit.num[n];
                /** @type {?} */
                var cnDesc = rmb ? unit.dec[i] : '';
                decimalRes += cnZero + cnNum + cnDesc;
            }
        }
        /** @type {?} */
        var ret = symbol +
            (rmb
                ? integerRes + (decimalRes === '零' ? '元整' : "\u5143" + decimalRes)
                : integerRes + (decimalRes === '' ? '' : "\u70B9" + decimalRes));
        return ret;
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NaNumberToChinesePipe = /** @class */ (function () {
        function NaNumberToChinesePipe() {
        }
        /**
         * @param {?} value
         * @param {?=} rmb
         * @param {?=} minusSymbol
         * @return {?}
         */
        NaNumberToChinesePipe.prototype.transform = /**
         * @param {?} value
         * @param {?=} rmb
         * @param {?=} minusSymbol
         * @return {?}
         */
            function (value, rmb, minusSymbol) {
                if (rmb === void 0) {
                    rmb = true;
                }
                if (minusSymbol === void 0) {
                    minusSymbol = '负';
                }
                return numberToChinese(value, rmb, { minusSymbol: minusSymbol });
            };
        NaNumberToChinesePipe.decorators = [
            { type: core.Pipe, args: [{ name: 'n2c' },] }
        ];
        return NaNumberToChinesePipe;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var PIPES = [NaNumberToChinesePipe];
    var NumberToChineseModule = /** @class */ (function () {
        function NumberToChineseModule() {
        }
        NumberToChineseModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule],
                        declarations: PIPES,
                        exports: PIPES,
                    },] }
        ];
        return NumberToChineseModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.numberToChinese = numberToChinese;
    exports.NaNumberToChinesePipe = NaNumberToChinesePipe;
    exports.NumberToChineseModule = NumberToChineseModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=numberToChinese.umd.js.map