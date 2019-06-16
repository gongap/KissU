/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/animations'), require('@angular/forms'), require('@delon/theme'), require('@angular/common'), require('@angular/core'), require('@delon/util'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/edit', ['exports', '@angular/animations', '@angular/forms', '@delon/theme', '@angular/common', '@angular/core', '@delon/util', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc.edit = {}),global.ng.animations,global.ng.forms,global.delon.theme,global.ng.common,global.ng.core,global.delon.util,global['ng-zorro-antd']));
}(this, (function (exports,animations,forms,theme,common,i0,util,ngZorroAntd) { 'use strict';

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
    var SEConfig = /** @class */ (function () {
        function SEConfig() {
            /**
             * 大小，默认：`default`
             * - `compact` 紧凑型，强制忽略 `error`、`extra` 展示
             */
            this.size = 'default';
            /**
             * 布局类型，等同 `nzLayout`
             * - `inline` 时强制大小为 `compact`
             */
            this.nzLayout = 'horizontal';
            /**
             * 间距，当 `nzLayout:horizontal` 时有效，默认：`32`
             */
            this.gutter = 32;
            /**
             * 列数，默认：`2`
             */
            this.col = 2;
            /**
             * 标签文本宽度，单位：`px`，默认：`150`
             */
            this.labelWidth = 150;
            /**
             * 是否立即呈现错误视觉
             */
            this.firstVisual = false;
        }
        SEConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ SEConfig.ngInjectableDef = i0.defineInjectable({ factory: function SEConfig_Factory() { return new SEConfig(); }, token: SEConfig, providedIn: "root" });
        return SEConfig;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var SEContainerComponent = /** @class */ (function () {
        // #endregion
        function SEContainerComponent(cog) {
            this.line = false;
            Object.assign(this, __assign({}, new SEConfig(), cog));
        }
        Object.defineProperty(SEContainerComponent.prototype, "gutter", {
            get: /**
             * @return {?}
             */ function () {
                return this.nzLayout === 'horizontal' ? this._gutter : 0;
            },
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._gutter = util.toNumber(value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(SEContainerComponent.prototype, "nzLayout", {
            get: /**
             * @return {?}
             */ function () {
                return this._nzLayout;
            },
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._nzLayout = value;
                if (value === 'inline') {
                    this.size = 'compact';
                }
            },
            enumerable: true,
            configurable: true
        });
        SEContainerComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'se-container, [se-container]',
                        template: "<div class=\"ant-row se__container se__{{nzLayout}} se__{{size}}\"\n     [ngStyle]=\"{'margin-left.px': -(gutter / 2), 'margin-right.px': -(gutter / 2)}\">\n  <se-title *ngIf=\"title\">\n    <ng-container *stringTemplateOutlet=\"title\">{{ title }}</ng-container>\n  </se-title>\n  <ng-content></ng-content>\n</div>\n",
                        changeDetection: i0.ChangeDetectionStrategy.OnPush,
                        exportAs: 'seContainer'
                    }] }
        ];
        /** @nocollapse */
        SEContainerComponent.ctorParameters = function () {
            return [
                { type: SEConfig }
            ];
        };
        SEContainerComponent.propDecorators = {
            colInCon: [{ type: i0.Input, args: ['se-container',] }],
            col: [{ type: i0.Input }],
            labelWidth: [{ type: i0.Input }],
            title: [{ type: i0.Input }],
            gutter: [{ type: i0.Input }],
            nzLayout: [{ type: i0.Input }],
            size: [{ type: i0.Input }],
            firstVisual: [{ type: i0.Input }],
            line: [{ type: i0.Input }]
        };
        __decorate([
            util.InputNumber(null),
            __metadata("design:type", Number)
        ], SEContainerComponent.prototype, "colInCon", void 0);
        __decorate([
            util.InputNumber(null),
            __metadata("design:type", Number)
        ], SEContainerComponent.prototype, "col", void 0);
        __decorate([
            util.InputNumber(null),
            __metadata("design:type", Number)
        ], SEContainerComponent.prototype, "labelWidth", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], SEContainerComponent.prototype, "firstVisual", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], SEContainerComponent.prototype, "line", void 0);
        return SEContainerComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var SEErrorComponent = /** @class */ (function () {
        function SEErrorComponent() {
        }
        SEErrorComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'se-error',
                        animations: [
                            animations.trigger('errorAnt', [
                                animations.transition('void => *', [
                                    animations.style({
                                        opacity: 0,
                                        transform: 'translateY(-5px)',
                                    }),
                                    animations.animate('0.3s cubic-bezier(0.645, 0.045, 0.355, 1)', animations.style({
                                        opacity: 1,
                                        transform: 'translateY(0)',
                                    })),
                                ]),
                                animations.transition('* => void', [
                                    animations.style({
                                        opacity: 1,
                                        transform: 'translateY(0)',
                                    }),
                                    animations.animate('0.3s cubic-bezier(0.645, 0.045, 0.355, 1)', animations.style({
                                        opacity: 0,
                                        transform: 'translateY(-5px)',
                                    })),
                                ]),
                            ]),
                        ],
                        template: "\n    <div [@errorAnt]><ng-content></ng-content></div>\n  ",
                        host: {
                            '[class.ant-form-explain]': 'true',
                        },
                        changeDetection: i0.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        return SEErrorComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var SETitleComponent = /** @class */ (function () {
        function SETitleComponent(parent, el, ren) {
            this.parent = parent;
            this.ren = ren;
            if (parent == null) {
                throw new Error("[se-title] must include 'se-container' component");
            }
            this.el = el.nativeElement;
        }
        /**
         * @private
         * @return {?}
         */
        SETitleComponent.prototype.setClass = /**
         * @private
         * @return {?}
         */
            function () {
                var gutter = this.parent.gutter;
                var el = this.el;
                this.ren.setStyle(el, 'padding-left', gutter / 2 + "px");
                this.ren.setStyle(el, 'padding-right', gutter / 2 + "px");
            };
        /**
         * @return {?}
         */
        SETitleComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.setClass();
            };
        SETitleComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'se-title, [se-title]',
                        template: '<ng-content></ng-content>',
                        host: {
                            '[class.se__title]': 'true',
                        },
                        changeDetection: i0.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        SETitleComponent.ctorParameters = function () {
            return [
                { type: SEContainerComponent, decorators: [{ type: i0.Host }, { type: i0.Optional }] },
                { type: i0.ElementRef },
                { type: i0.Renderer2 }
            ];
        };
        return SETitleComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var prefixCls = "se";
    /** @type {?} */
    var nextUniqueId = 0;
    var SEComponent = /** @class */ (function () {
        function SEComponent(el, parent, rep, ren, cdr) {
            this.parent = parent;
            this.rep = rep;
            this.ren = ren;
            this.cdr = cdr;
            this.clsMap = [];
            this.inited = false;
            this.onceFlag = false;
            this.invalid = false;
            this._labelWidth = null;
            this.required = false;
            this.controlClass = '';
            this._id = "_se-" + nextUniqueId++;
            this._autoId = true;
            if (parent == null) {
                throw new Error("[se] must include 'se-container' component");
            }
            this.el = el.nativeElement;
        }
        Object.defineProperty(SEComponent.prototype, "id", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._id = value;
                this._autoId = false;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(SEComponent.prototype, "paddingValue", {
            // #endregion
            get: 
            // #endregion
            /**
             * @return {?}
             */
            function () {
                return this.parent.gutter / 2;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(SEComponent.prototype, "showErr", {
            get: /**
             * @return {?}
             */ function () {
                return this.invalid && this.parent.size !== 'compact' && !!this.error;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(SEComponent.prototype, "ngControl", {
            get: /**
             * @private
             * @return {?}
             */ function () {
                return this.ngModel || this.formControlName;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @private
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
        SEComponent.prototype.setClass = /**
         * @private
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
            function () {
                var _a = ( /** @type {?} */(this)), el = _a.el, ren = _a.ren, clsMap = _a.clsMap, col = _a.col, parent = _a.parent, cdr = _a.cdr, line = _a.line, labelWidth = _a.labelWidth, rep = _a.rep;
                ( /** @type {?} */(this))._labelWidth = labelWidth != null ? labelWidth : parent.labelWidth;
                clsMap.forEach(( /**
                 * @param {?} cls
                 * @return {?}
                 */function (cls) { return ren.removeClass(el, cls); }));
                clsMap.length = 0;
                /** @type {?} */
                var repCls = parent.nzLayout === 'horizontal'
                    ? rep.genCls(col != null ? col : parent.colInCon || parent.col)
                    : [];
                clsMap.push.apply(clsMap, __spread(["ant-form-item"], repCls, [prefixCls + "__item"]));
                if (line || parent.line) {
                    clsMap.push(prefixCls + "__line");
                }
                clsMap.forEach(( /**
                 * @param {?} cls
                 * @return {?}
                 */function (cls) { return ren.addClass(el, cls); }));
                cdr.detectChanges();
                return ( /** @type {?} */(this));
            };
        /**
         * @private
         * @return {?}
         */
        SEComponent.prototype.bindModel = /**
         * @private
         * @return {?}
         */
            function () {
                var _this = this;
                if (!this.ngControl || this.status$)
                    return;
                this.status$ = this.ngControl.statusChanges.subscribe(( /**
                 * @param {?} res
                 * @return {?}
                 */function (res) {
                    return _this.updateStatus(res === 'INVALID');
                }));
                if (this._autoId) {
                    /** @type {?} */
                    var control = ( /** @type {?} */(util.deepGet(this.ngControl.valueAccessor, '_elementRef.nativeElement')));
                    if (control) {
                        control.id = this._id;
                    }
                }
            };
        /**
         * @private
         * @param {?} invalid
         * @return {?}
         */
        SEComponent.prototype.updateStatus = /**
         * @private
         * @param {?} invalid
         * @return {?}
         */
            function (invalid) {
                if (this.ngControl.disabled || this.ngControl.isDisabled) {
                    return;
                }
                this.invalid = (invalid && this.onceFlag) || (this.ngControl.dirty && invalid);
                this.cdr.detectChanges();
            };
        /**
         * @return {?}
         */
        SEComponent.prototype.checkContent = /**
         * @return {?}
         */
            function () {
                /** @type {?} */
                var el = this.contentElement.nativeElement;
                /** @type {?} */
                var cls = prefixCls + "__item-empty";
                if (util.isEmpty(el)) {
                    this.ren.addClass(el, cls);
                }
                else {
                    this.ren.removeClass(el, cls);
                }
            };
        /**
         * @return {?}
         */
        SEComponent.prototype.ngAfterContentInit = /**
         * @return {?}
         */
            function () {
                this.checkContent();
            };
        /**
         * @return {?}
         */
        SEComponent.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                this.onceFlag = this.parent.firstVisual;
                if (this.inited)
                    this.setClass().bindModel();
            };
        /**
         * @return {?}
         */
        SEComponent.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.setClass().bindModel();
                this.inited = true;
                if (this.onceFlag) {
                    Promise.resolve().then(( /**
                     * @return {?}
                     */function () {
                        _this.updateStatus(_this.ngControl.invalid);
                        _this.onceFlag = false;
                    }));
                }
            };
        /**
         * @return {?}
         */
        SEComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                if (this.status$) {
                    this.status$.unsubscribe();
                }
            };
        SEComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'se',
                        template: "<div class=\"ant-form-item-label se__label\"\n     [class.se__nolabel]=\"!label\"\n     [style.width.px]=\"_labelWidth\">\n  <label *ngIf=\"label\"\n         [attr.for]=\"_id\"\n         [ngClass]=\"{'ant-form-item-required': required}\">\n    <ng-container *stringTemplateOutlet=\"label\">{{ label }}</ng-container>\n    <span class=\"se__label-optional\">\n      {{ optional }}\n      <nz-tooltip *ngIf=\"optionalHelp\"\n                  [nzTitle]=\"optionalHelp\">\n        <i nz-tooltip\n           nz-icon\n           type=\"question-circle\"></i>\n      </nz-tooltip>\n    </span>\n  </label>\n</div>\n<div class=\"ant-form-item-control-wrapper se__control\">\n  <div class=\"ant-form-item-control {{controlClass}}\"\n       [class.has-error]=\"invalid\">\n    <span (cdkObserveContent)=\"checkContent()\" #contentElement><ng-content></ng-content></span>\n    <se-error *ngIf=\"showErr\">{{error}}</se-error>\n    <div *ngIf=\"extra\"\n         class=\"ant-form-extra\">{{extra}}</div>\n  </div>\n</div>\n",
                        host: {
                            '[style.padding-left.px]': 'paddingValue',
                            '[style.padding-right.px]': 'paddingValue',
                            '[class.ant-form-item-with-help]': 'showErr',
                        },
                        changeDetection: i0.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        SEComponent.ctorParameters = function () {
            return [
                { type: i0.ElementRef },
                { type: SEContainerComponent, decorators: [{ type: i0.Optional }, { type: i0.Host }] },
                { type: theme.ResponsiveService },
                { type: i0.Renderer2 },
                { type: i0.ChangeDetectorRef }
            ];
        };
        SEComponent.propDecorators = {
            ngModel: [{ type: i0.ContentChild, args: [forms.NgModel,] }],
            formControlName: [{ type: i0.ContentChild, args: [forms.FormControlName,] }],
            contentElement: [{ type: i0.ViewChild, args: ['contentElement',] }],
            optional: [{ type: i0.Input }],
            optionalHelp: [{ type: i0.Input }],
            error: [{ type: i0.Input }],
            extra: [{ type: i0.Input }],
            label: [{ type: i0.Input }],
            col: [{ type: i0.Input }],
            required: [{ type: i0.Input }],
            controlClass: [{ type: i0.Input }],
            line: [{ type: i0.Input }],
            labelWidth: [{ type: i0.Input }],
            id: [{ type: i0.Input }]
        };
        __decorate([
            util.InputNumber(null),
            __metadata("design:type", Number)
        ], SEComponent.prototype, "col", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], SEComponent.prototype, "required", void 0);
        __decorate([
            util.InputBoolean(null),
            __metadata("design:type", Boolean)
        ], SEComponent.prototype, "line", void 0);
        __decorate([
            util.InputNumber(null),
            __metadata("design:type", Number)
        ], SEComponent.prototype, "labelWidth", void 0);
        return SEComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [SEContainerComponent, SEComponent, SEErrorComponent, SETitleComponent];
    var SEModule = /** @class */ (function () {
        function SEModule() {
        }
        SEModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, util.DelonUtilModule, ngZorroAntd.NgZorroAntdModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return SEModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.SEContainerComponent = SEContainerComponent;
    exports.SEErrorComponent = SEErrorComponent;
    exports.SETitleComponent = SETitleComponent;
    exports.SEComponent = SEComponent;
    exports.SEConfig = SEConfig;
    exports.SEModule = SEModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=edit.umd.js.map