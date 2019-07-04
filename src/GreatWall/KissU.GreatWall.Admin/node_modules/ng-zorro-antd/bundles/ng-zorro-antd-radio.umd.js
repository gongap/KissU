(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/cdk/a11y'), require('rxjs'), require('rxjs/operators'), require('ng-zorro-antd/core'), require('@angular/common'), require('@angular/core'), require('@angular/forms')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/radio', ['exports', '@angular/cdk/a11y', 'rxjs', 'rxjs/operators', 'ng-zorro-antd/core', '@angular/common', '@angular/core', '@angular/forms'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].radio = {}),global.ng.cdk.a11y,global.rxjs,global.rxjs.operators,global['ng-zorro-antd'].core,global.ng.common,global.ng.core,global.ng.forms));
}(this, (function (exports,a11y,rxjs,operators,core,common,core$1,forms) { 'use strict';

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
    var NzRadioComponent = /** @class */ (function () {
        /* tslint:disable-next-line:no-any */
        function NzRadioComponent(elementRef, renderer, cdr, focusMonitor) {
            this.elementRef = elementRef;
            this.renderer = renderer;
            this.cdr = cdr;
            this.focusMonitor = focusMonitor;
            this.select$ = new rxjs.Subject();
            this.touched$ = new rxjs.Subject();
            this.checked = false;
            this.isNgModel = false;
            this.onChange = ( /**
             * @return {?}
             */function () { return null; });
            this.onTouched = ( /**
             * @return {?}
             */function () { return null; });
            this.nzDisabled = false;
            this.nzAutoFocus = false;
            this.renderer.addClass(elementRef.nativeElement, 'ant-radio-wrapper');
        }
        /**
         * @return {?}
         */
        NzRadioComponent.prototype.updateAutoFocus = /**
         * @return {?}
         */
            function () {
                if (this.inputElement) {
                    if (this.nzAutoFocus) {
                        this.renderer.setAttribute(this.inputElement.nativeElement, 'autofocus', 'autofocus');
                    }
                    else {
                        this.renderer.removeAttribute(this.inputElement.nativeElement, 'autofocus');
                    }
                }
            };
        /**
         * @param {?} event
         * @return {?}
         */
        NzRadioComponent.prototype.onClick = /**
         * @param {?} event
         * @return {?}
         */
            function (event) {
                // Prevent label click triggered twice.
                event.stopPropagation();
                event.preventDefault();
                if (!this.nzDisabled && !this.checked) {
                    this.select$.next(this);
                    if (this.isNgModel) {
                        this.checked = true;
                        this.onChange(true);
                    }
                }
            };
        /**
         * @return {?}
         */
        NzRadioComponent.prototype.focus = /**
         * @return {?}
         */
            function () {
                this.focusMonitor.focusVia(this.inputElement, 'keyboard');
            };
        /**
         * @return {?}
         */
        NzRadioComponent.prototype.blur = /**
         * @return {?}
         */
            function () {
                this.inputElement.nativeElement.blur();
            };
        /**
         * @return {?}
         */
        NzRadioComponent.prototype.markForCheck = /**
         * @return {?}
         */
            function () {
                this.cdr.markForCheck();
            };
        /**
         * @param {?} isDisabled
         * @return {?}
         */
        NzRadioComponent.prototype.setDisabledState = /**
         * @param {?} isDisabled
         * @return {?}
         */
            function (isDisabled) {
                this.nzDisabled = isDisabled;
                this.cdr.markForCheck();
            };
        /**
         * @param {?} value
         * @return {?}
         */
        NzRadioComponent.prototype.writeValue = /**
         * @param {?} value
         * @return {?}
         */
            function (value) {
                this.checked = value;
                this.cdr.markForCheck();
            };
        /**
         * @param {?} fn
         * @return {?}
         */
        NzRadioComponent.prototype.registerOnChange = /**
         * @param {?} fn
         * @return {?}
         */
            function (fn) {
                this.isNgModel = true;
                this.onChange = fn;
            };
        /**
         * @param {?} fn
         * @return {?}
         */
        NzRadioComponent.prototype.registerOnTouched = /**
         * @param {?} fn
         * @return {?}
         */
            function (fn) {
                this.onTouched = fn;
            };
        /**
         * @return {?}
         */
        NzRadioComponent.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.focusMonitor.monitor(this.elementRef, true).subscribe(( /**
                 * @param {?} focusOrigin
                 * @return {?}
                 */function (focusOrigin) {
                    if (!focusOrigin) {
                        Promise.resolve().then(( /**
                         * @return {?}
                         */function () { return _this.onTouched(); }));
                        _this.touched$.next();
                    }
                }));
                this.updateAutoFocus();
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzRadioComponent.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (changes.nzAutoFocus) {
                    this.updateAutoFocus();
                }
            };
        /**
         * @return {?}
         */
        NzRadioComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.focusMonitor.stopMonitoring(this.elementRef);
            };
        NzRadioComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: '[nz-radio]',
                        exportAs: 'nzRadio',
                        preserveWhitespaces: false,
                        template: "<span class=\"ant-radio\" [class.ant-radio-checked]=\"checked\" [class.ant-radio-disabled]=\"nzDisabled\">\n  <input #inputElement type=\"radio\" class=\"ant-radio-input\" [disabled]=\"nzDisabled\" [checked]=\"checked\" [attr.name]=\"name\">\n  <span class=\"ant-radio-inner\"></span>\n</span>\n<span><ng-content></ng-content></span>",
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        providers: [
                            {
                                provide: forms.NG_VALUE_ACCESSOR,
                                useExisting: core$1.forwardRef(( /**
                                 * @return {?}
                                 */function () { return NzRadioComponent; })),
                                multi: true
                            }
                        ],
                        host: {
                            '[class.ant-radio-wrapper-checked]': 'checked',
                            '[class.ant-radio-wrapper-disabled]': 'nzDisabled'
                        }
                    }] }
        ];
        /** @nocollapse */
        NzRadioComponent.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.Renderer2 },
                { type: core$1.ChangeDetectorRef },
                { type: a11y.FocusMonitor }
            ];
        };
        NzRadioComponent.propDecorators = {
            inputElement: [{ type: core$1.ViewChild, args: ['inputElement',] }],
            nzValue: [{ type: core$1.Input }],
            nzDisabled: [{ type: core$1.Input }],
            nzAutoFocus: [{ type: core$1.Input }],
            onClick: [{ type: core$1.HostListener, args: ['click', ['$event'],] }]
        };
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzRadioComponent.prototype, "nzDisabled", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzRadioComponent.prototype, "nzAutoFocus", void 0);
        return NzRadioComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzRadioButtonComponent = /** @class */ (function (_super) {
        __extends(NzRadioButtonComponent, _super);
        /* tslint:disable-next-line:no-any */
        function NzRadioButtonComponent(elementRef, renderer, cdr, focusMonitor) {
            var _this = _super.call(this, elementRef, renderer, cdr, focusMonitor) || this;
            renderer.removeClass(elementRef.nativeElement, 'ant-radio-wrapper');
            renderer.addClass(elementRef.nativeElement, 'ant-radio-button-wrapper');
            return _this;
        }
        NzRadioButtonComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: '[nz-radio-button]',
                        exportAs: 'nzRadioButton',
                        providers: [
                            {
                                provide: forms.NG_VALUE_ACCESSOR,
                                useExisting: core$1.forwardRef(( /**
                                 * @return {?}
                                 */function () { return NzRadioComponent; })),
                                multi: true
                            },
                            {
                                provide: NzRadioComponent,
                                useExisting: core$1.forwardRef(( /**
                                 * @return {?}
                                 */function () { return NzRadioButtonComponent; }))
                            }
                        ],
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        preserveWhitespaces: false,
                        template: "<span class=\"ant-radio-button\" [class.ant-radio-button-checked]=\"checked\" [class.ant-radio-button-disabled]=\"nzDisabled\">\n  <input type=\"radio\" #inputElement class=\"ant-radio-button-input\" [disabled]=\"nzDisabled\" [checked]=\"checked\" [attr.name]=\"name\">\n  <span class=\"ant-radio-button-inner\"></span>\n</span>\n<span><ng-content></ng-content></span>",
                        host: {
                            '[class.ant-radio-button-wrapper-checked]': 'checked',
                            '[class.ant-radio-button-wrapper-disabled]': 'nzDisabled'
                        }
                    }] }
        ];
        /** @nocollapse */
        NzRadioButtonComponent.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.Renderer2 },
                { type: core$1.ChangeDetectorRef },
                { type: a11y.FocusMonitor }
            ];
        };
        return NzRadioButtonComponent;
    }(NzRadioComponent));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzRadioGroupComponent = /** @class */ (function () {
        function NzRadioGroupComponent(cdr, renderer, elementRef) {
            this.cdr = cdr;
            this.destroy$ = new rxjs.Subject();
            this.onChange = ( /**
             * @return {?}
             */function () { return null; });
            this.onTouched = ( /**
             * @return {?}
             */function () { return null; });
            this.nzButtonStyle = 'outline';
            this.nzSize = 'default';
            renderer.addClass(elementRef.nativeElement, 'ant-radio-group');
        }
        /**
         * @return {?}
         */
        NzRadioGroupComponent.prototype.updateChildrenStatus = /**
         * @return {?}
         */
            function () {
                var _this = this;
                if (this.radios) {
                    Promise.resolve().then(( /**
                     * @return {?}
                     */function () {
                        _this.radios.forEach(( /**
                         * @param {?} radio
                         * @return {?}
                         */function (radio) {
                            radio.checked = radio.nzValue === _this.value;
                            if (core.isNotNil(_this.nzDisabled)) {
                                radio.nzDisabled = _this.nzDisabled;
                            }
                            if (_this.nzName) {
                                radio.name = _this.nzName;
                            }
                            radio.markForCheck();
                        }));
                    }));
                }
            };
        /**
         * @return {?}
         */
        NzRadioGroupComponent.prototype.ngAfterContentInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.radios.changes
                    .pipe(operators.startWith(null), operators.takeUntil(this.destroy$))
                    .subscribe(( /**
             * @return {?}
             */function () {
                    _this.updateChildrenStatus();
                    if (_this.selectSubscription) {
                        _this.selectSubscription.unsubscribe();
                    }
                    _this.selectSubscription = rxjs.merge.apply(void 0, __spread(_this.radios.map(( /**
                     * @param {?} radio
                     * @return {?}
                     */function (radio) { return radio.select$; })))).pipe(operators.takeUntil(_this.destroy$))
                        .subscribe(( /**
                 * @param {?} radio
                 * @return {?}
                 */function (radio) {
                        if (_this.value !== radio.nzValue) {
                            _this.value = radio.nzValue;
                            _this.updateChildrenStatus();
                            _this.onChange(_this.value);
                        }
                    }));
                    if (_this.touchedSubscription) {
                        _this.touchedSubscription.unsubscribe();
                    }
                    _this.touchedSubscription = rxjs.merge.apply(void 0, __spread(_this.radios.map(( /**
                     * @param {?} radio
                     * @return {?}
                     */function (radio) { return radio.touched$; })))).pipe(operators.takeUntil(_this.destroy$))
                        .subscribe(( /**
                 * @return {?}
                 */function () {
                        Promise.resolve().then(( /**
                         * @return {?}
                         */function () { return _this.onTouched(); }));
                    }));
                }));
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzRadioGroupComponent.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (changes.nzDisabled || changes.nzName) {
                    this.updateChildrenStatus();
                }
            };
        /**
         * @return {?}
         */
        NzRadioGroupComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.destroy$.next();
                this.destroy$.complete();
            };
        /* tslint:disable-next-line:no-any */
        /* tslint:disable-next-line:no-any */
        /**
         * @param {?} value
         * @return {?}
         */
        NzRadioGroupComponent.prototype.writeValue = /* tslint:disable-next-line:no-any */
            /**
             * @param {?} value
             * @return {?}
             */
            function (value) {
                this.value = value;
                this.updateChildrenStatus();
                this.cdr.markForCheck();
            };
        /**
         * @param {?} fn
         * @return {?}
         */
        NzRadioGroupComponent.prototype.registerOnChange = /**
         * @param {?} fn
         * @return {?}
         */
            function (fn) {
                this.onChange = fn;
            };
        /**
         * @param {?} fn
         * @return {?}
         */
        NzRadioGroupComponent.prototype.registerOnTouched = /**
         * @param {?} fn
         * @return {?}
         */
            function (fn) {
                this.onTouched = fn;
            };
        /**
         * @param {?} isDisabled
         * @return {?}
         */
        NzRadioGroupComponent.prototype.setDisabledState = /**
         * @param {?} isDisabled
         * @return {?}
         */
            function (isDisabled) {
                this.nzDisabled = isDisabled;
                this.cdr.markForCheck();
            };
        NzRadioGroupComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-radio-group',
                        exportAs: 'nzRadioGroup',
                        preserveWhitespaces: false,
                        template: "<ng-content></ng-content>",
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        providers: [
                            {
                                provide: forms.NG_VALUE_ACCESSOR,
                                useExisting: core$1.forwardRef(( /**
                                 * @return {?}
                                 */function () { return NzRadioGroupComponent; })),
                                multi: true
                            }
                        ],
                        host: {
                            '[class.ant-radio-group-large]': "nzSize === 'large'",
                            '[class.ant-radio-group-small]': "nzSize === 'small'",
                            '[class.ant-radio-group-solid]': "nzButtonStyle === 'solid'"
                        }
                    }] }
        ];
        /** @nocollapse */
        NzRadioGroupComponent.ctorParameters = function () {
            return [
                { type: core$1.ChangeDetectorRef },
                { type: core$1.Renderer2 },
                { type: core$1.ElementRef }
            ];
        };
        NzRadioGroupComponent.propDecorators = {
            radios: [{ type: core$1.ContentChildren, args: [core$1.forwardRef(( /**
                                     * @return {?}
                                     */function () { return NzRadioComponent; })), { descendants: true },] }],
            nzDisabled: [{ type: core$1.Input }],
            nzButtonStyle: [{ type: core$1.Input }],
            nzSize: [{ type: core$1.Input }],
            nzName: [{ type: core$1.Input }]
        };
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Boolean)
        ], NzRadioGroupComponent.prototype, "nzDisabled", void 0);
        return NzRadioGroupComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzRadioModule = /** @class */ (function () {
        function NzRadioModule() {
        }
        NzRadioModule.decorators = [
            { type: core$1.NgModule, args: [{
                        imports: [common.CommonModule, forms.FormsModule],
                        exports: [NzRadioComponent, NzRadioButtonComponent, NzRadioGroupComponent],
                        declarations: [NzRadioComponent, NzRadioButtonComponent, NzRadioGroupComponent]
                    },] }
        ];
        return NzRadioModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzRadioButtonComponent = NzRadioButtonComponent;
    exports.NzRadioGroupComponent = NzRadioGroupComponent;
    exports.NzRadioComponent = NzRadioComponent;
    exports.NzRadioModule = NzRadioModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-radio.umd.js.map