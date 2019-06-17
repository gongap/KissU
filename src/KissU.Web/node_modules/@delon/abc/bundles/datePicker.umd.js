/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@delon/util'), require('@angular/common'), require('@angular/core'), require('@angular/forms'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/date-picker', ['exports', '@delon/util', '@angular/common', '@angular/core', '@angular/forms', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['date-picker'] = {}),global.delon.util,global.ng.common,global.ng.core,global.ng.forms,global['ng-zorro-antd']));
}(this, (function (exports,util,common,i0,forms,ngZorroAntd) { 'use strict';

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
    var DateRangePickerConfig = /** @class */ (function () {
        function DateRangePickerConfig() {
            this.nzFormat = 'yyyy-MM-dd';
            this.nzAllowClear = true;
            this.nzAutoFocus = false;
            this.nzDisabled = false;
            this.nzPopupStyle = { position: 'relative' };
            this.nzShowToday = true;
            this.shortcuts = {
                enabled: false,
                closed: true,
                list: [
                    {
                        text: '今天',
                        fn: ( /**
                         * @return {?}
                         */function () { return util.getTimeDistance('today'); }),
                    },
                    {
                        text: '昨天',
                        fn: ( /**
                         * @return {?}
                         */function () { return util.getTimeDistance('yesterday'); }),
                    },
                    {
                        text: '近3天',
                        fn: ( /**
                         * @return {?}
                         */function () { return util.getTimeDistance(-2); }),
                    },
                    {
                        text: '近7天',
                        fn: ( /**
                         * @return {?}
                         */function () { return util.getTimeDistance(-6); }),
                    },
                    {
                        text: '本周',
                        fn: ( /**
                         * @return {?}
                         */function () { return util.getTimeDistance('week'); }),
                    },
                    {
                        text: '本月',
                        fn: ( /**
                         * @return {?}
                         */function () { return util.getTimeDistance('month'); }),
                    },
                    {
                        text: '全年',
                        fn: ( /**
                         * @return {?}
                         */function () { return util.getTimeDistance('year'); }),
                    },
                ],
            };
        }
        return DateRangePickerConfig;
    }());
    var DatePickerConfig = /** @class */ (function () {
        function DatePickerConfig() {
        }
        DatePickerConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ DatePickerConfig.ngInjectableDef = i0.defineInjectable({ factory: function DatePickerConfig_Factory() { return new DatePickerConfig(); }, token: DatePickerConfig, providedIn: "root" });
        return DatePickerConfig;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var RangePickerComponent = /** @class */ (function () {
        // #endregion
        function RangePickerComponent(cog) {
            this.value = [];
            this.ngModelEndChange = new i0.EventEmitter();
            // #region Native properties
            this.nzAllowClear = true;
            this.nzAutoFocus = false;
            this.nzOnOpenChange = new i0.EventEmitter();
            this.nzShowToday = true;
            this.nzOnPanelChange = new i0.EventEmitter();
            this.nzOnOk = new i0.EventEmitter();
            this._cog = util.deepMergeKey(new DateRangePickerConfig(), true, cog && cog.range);
            Object.assign(this, this._cog);
        }
        Object.defineProperty(RangePickerComponent.prototype, "shortcut", {
            get: /**
             * @return {?}
             */ function () {
                return this._shortcut;
            },
            set: /**
             * @param {?} val
             * @return {?}
             */ function (val) {
                /** @type {?} */
                var item = ( /** @type {?} */(util.deepMergeKey({}, true, this._cog.shortcuts, val == null ? {} : val)));
                if (typeof val === 'boolean') {
                    item.enabled = val;
                }
                this._shortcut = item;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @param {?} e
         * @return {?}
         */
        RangePickerComponent.prototype._nzOnOpenChange = /**
         * @param {?} e
         * @return {?}
         */
            function (e) {
                this.nzOnOpenChange.emit(e);
            };
        /**
         * @param {?} e
         * @return {?}
         */
        RangePickerComponent.prototype._nzOnPanelChange = /**
         * @param {?} e
         * @return {?}
         */
            function (e) {
                this.nzOnPanelChange.emit(e);
            };
        /**
         * @param {?} e
         * @return {?}
         */
        RangePickerComponent.prototype._nzOnOk = /**
         * @param {?} e
         * @return {?}
         */
            function (e) {
                this.nzOnOk.emit(e);
            };
        /**
         * @param {?} e
         * @return {?}
         */
        RangePickerComponent.prototype.valueChange = /**
         * @param {?} e
         * @return {?}
         */
            function (e) {
                e = util.fixEndTimeOfRange(e);
                this.onChangeFn(e[0]);
                this.ngModelEnd = e[1];
                this.ngModelEndChange.emit(e[1]);
            };
        /**
         * @param {?} value
         * @return {?}
         */
        RangePickerComponent.prototype.writeValue = /**
         * @param {?} value
         * @return {?}
         */
            function (value) {
                this.value = value && this.ngModelEnd ? [value, this.ngModelEnd] : [];
            };
        /**
         * @param {?} fn
         * @return {?}
         */
        RangePickerComponent.prototype.registerOnChange = /**
         * @param {?} fn
         * @return {?}
         */
            function (fn) {
                this.onChangeFn = fn;
            };
        /**
         * @param {?} fn
         * @return {?}
         */
        RangePickerComponent.prototype.registerOnTouched = /**
         * @param {?} fn
         * @return {?}
         */
            function (fn) {
                this.onTouchedFn = fn;
            };
        /**
         * @param {?} disabled
         * @return {?}
         */
        RangePickerComponent.prototype.setDisabledState = /**
         * @param {?} disabled
         * @return {?}
         */
            function (disabled) {
                this.nzDisabled = disabled;
            };
        /**
         * @param {?} item
         * @return {?}
         */
        RangePickerComponent.prototype.clickShortcut = /**
         * @param {?} item
         * @return {?}
         */
            function (item) {
                this.value = item.fn(( /** @type {?} */(this.value)));
                this.valueChange(( /** @type {?} */(this.value)));
                if (this._shortcut.closed) {
                    this.comp.closeOverlay();
                }
            };
        RangePickerComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'range-picker',
                        template: "<nz-range-picker #comp\n                 [ngModel]=\"value\"\n                 (ngModelChange)=\"valueChange($event)\"\n                 [nzAllowClear]=\"nzAllowClear\"\n                 [nzAutoFocus]=\"nzAutoFocus\"\n                 [nzClassName]=\"nzClassName\"\n                 [nzDisabled]=\"nzDisabled\"\n                 [nzSize]=\"nzSize\"\n                 [nzDisabledDate]=\"nzDisabledDate\"\n                 [nzLocale]=\"nzLocale\"\n                 [nzPopupStyle]=\"nzPopupStyle\"\n                 [nzDropdownClassName]=\"nzDropdownClassName\"\n                 [nzStyle]=\"nzStyle\"\n                 [nzPlaceHolder]=\"nzPlaceHolder\"\n                 (nzOnOpenChange)=\"_nzOnOpenChange($event)\"\n                 [nzDateRender]=\"nzDateRender\"\n                 [nzDisabledTime]=\"nzDisabledTime\"\n                 [nzFormat]=\"nzFormat\"\n                 [nzRenderExtraFooter]=\"nzRenderExtraFooter || (shortcut?.enabled ? shortcutTpl : null)\"\n                 [nzShowTime]=\"nzShowTime\"\n                 [nzShowToday]=\"nzShowToday\"\n                 [nzMode]=\"nzMode\"\n                 [nzRanges]=\"nzRanges\"\n                 (nzOnPanelChange)=\"_nzOnPanelChange($event)\"\n                 (nzOnOk)=\"_nzOnOk($event)\"></nz-range-picker>\n<ng-template #shortcutTpl>\n  <a *ngFor=\"let i of shortcut.list;let first=first\"\n     (click)=\"clickShortcut(i)\"\n     [innerHTML]=\"i.text\"\n     [ngClass]=\"{'ml-sm': !first}\"></a>\n</ng-template>\n",
                        providers: [
                            {
                                provide: forms.NG_VALUE_ACCESSOR,
                                multi: true,
                                useExisting: i0.forwardRef(( /**
                                 * @return {?}
                                 */function () { return RangePickerComponent; })),
                            },
                        ]
                    }] }
        ];
        /** @nocollapse */
        RangePickerComponent.ctorParameters = function () {
            return [
                { type: DatePickerConfig }
            ];
        };
        RangePickerComponent.propDecorators = {
            comp: [{ type: i0.ViewChild, args: ['comp',] }],
            ngModelEnd: [{ type: i0.Input }],
            shortcut: [{ type: i0.Input }],
            ngModelEndChange: [{ type: i0.Output }],
            nzAllowClear: [{ type: i0.Input }],
            nzAutoFocus: [{ type: i0.Input }],
            nzClassName: [{ type: i0.Input }],
            nzDisabled: [{ type: i0.Input }],
            nzSize: [{ type: i0.Input }],
            nzStyle: [{ type: i0.Input }],
            nzDisabledDate: [{ type: i0.Input }],
            nzLocale: [{ type: i0.Input }],
            nzPopupStyle: [{ type: i0.Input }],
            nzDropdownClassName: [{ type: i0.Input }],
            nzPlaceHolder: [{ type: i0.Input }],
            nzOnOpenChange: [{ type: i0.Output }],
            nzDateRender: [{ type: i0.Input }],
            nzFormat: [{ type: i0.Input }],
            nzDisabledTime: [{ type: i0.Input }],
            nzRenderExtraFooter: [{ type: i0.Input }],
            nzShowTime: [{ type: i0.Input }],
            nzShowToday: [{ type: i0.Input }],
            nzMode: [{ type: i0.Input }],
            nzRanges: [{ type: i0.Input }],
            nzOnPanelChange: [{ type: i0.Output }],
            nzOnOk: [{ type: i0.Output }]
        };
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], RangePickerComponent.prototype, "nzShowToday", void 0);
        return RangePickerComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [RangePickerComponent];
    var DatePickerModule = /** @class */ (function () {
        function DatePickerModule() {
        }
        DatePickerModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, forms.FormsModule, ngZorroAntd.NgZorroAntdModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return DatePickerModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.RangePickerComponent = RangePickerComponent;
    exports.DatePickerModule = DatePickerModule;
    exports.DateRangePickerConfig = DateRangePickerConfig;
    exports.DatePickerConfig = DatePickerConfig;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=datePicker.umd.js.map