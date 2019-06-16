(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs'), require('rxjs/operators'), require('ng-zorro-antd/core'), require('@angular/cdk/observers'), require('@angular/common'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/spin', ['exports', 'rxjs', 'rxjs/operators', 'ng-zorro-antd/core', '@angular/cdk/observers', '@angular/common', '@angular/core'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].spin = {}),global.rxjs,global.rxjs.operators,global['ng-zorro-antd'].core,global.ng.cdk.observers,global.ng.common,global.ng.core));
}(this, (function (exports,rxjs,operators,core,observers,common,core$1) { 'use strict';

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

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzSpinComponent = /** @class */ (function () {
        function NzSpinComponent(cdr) {
            this.cdr = cdr;
            this.nzSize = 'default';
            this.nzDelay = 0;
            this.nzSimple = false;
            this.nzSpinning = true;
            this.loading = true;
            this.spinning$ = new rxjs.BehaviorSubject(this.nzSpinning);
            this.loading$ = this.spinning$.pipe(operators.debounceTime(this.nzDelay));
        }
        /**
         * @return {?}
         */
        NzSpinComponent.prototype.subscribeLoading = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.unsubscribeLoading();
                this.loading_ = this.loading$.subscribe(( /**
                 * @param {?} data
                 * @return {?}
                 */function (data) {
                    _this.loading = data;
                    _this.cdr.markForCheck();
                }));
            };
        /**
         * @return {?}
         */
        NzSpinComponent.prototype.unsubscribeLoading = /**
         * @return {?}
         */
            function () {
                if (this.loading_) {
                    this.loading_.unsubscribe();
                    this.loading_ = null;
                }
            };
        /**
         * @return {?}
         */
        NzSpinComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.subscribeLoading();
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzSpinComponent.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (changes.nzSpinning) {
                    if (changes.nzSpinning.isFirstChange()) {
                        this.loading = this.nzSpinning;
                    }
                    this.spinning$.next(this.nzSpinning);
                }
                if (changes.nzDelay) {
                    this.loading$ = this.spinning$.pipe(operators.debounceTime(this.nzDelay));
                    this.subscribeLoading();
                }
            };
        /**
         * @return {?}
         */
        NzSpinComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.unsubscribeLoading();
            };
        NzSpinComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-spin',
                        exportAs: 'nzSpin',
                        preserveWhitespaces: false,
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        template: "<ng-template #defaultIndicatorTemplate>\n  <span class=\"ant-spin-dot\" [class.ant-spin-dot-spin]=\"loading\">\n    <i class=\"ant-spin-dot-item\"></i><i class=\"ant-spin-dot-item\"></i><i class=\"ant-spin-dot-item\"></i><i class=\"ant-spin-dot-item\"></i>\n  </span>\n</ng-template>\n<div *ngIf=\"loading\">\n  <div class=\"ant-spin\"\n    [class.ant-spin-spinning]=\"loading\"\n    [class.ant-spin-lg]=\"nzSize === 'large'\"\n    [class.ant-spin-sm]=\"nzSize === 'small'\"\n    [class.ant-spin-show-text]=\"nzTip\">\n    <ng-template [ngTemplateOutlet]=\"nzIndicator || defaultIndicatorTemplate\"></ng-template>\n    <div class=\"ant-spin-text\" *ngIf=\"nzTip\">{{ nzTip }}</div>\n  </div>\n</div>\n<div *ngIf=\"!nzSimple\"\n  class=\"ant-spin-container\"\n  [class.ant-spin-blur]=\"loading\">\n  <ng-content></ng-content>\n</div>\n",
                        host: {
                            '[class.ant-spin-nested-loading]': '!nzSimple'
                        },
                        styles: ["\n      nz-spin {\n        display: block;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzSpinComponent.ctorParameters = function () {
            return [
                { type: core$1.ChangeDetectorRef }
            ];
        };
        NzSpinComponent.propDecorators = {
            nzIndicator: [{ type: core$1.Input }],
            nzSize: [{ type: core$1.Input }],
            nzTip: [{ type: core$1.Input }],
            nzDelay: [{ type: core$1.Input }],
            nzSimple: [{ type: core$1.Input }],
            nzSpinning: [{ type: core$1.Input }]
        };
        __decorate([
            core.InputNumber(),
            __metadata("design:type", Object)
        ], NzSpinComponent.prototype, "nzDelay", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzSpinComponent.prototype, "nzSimple", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzSpinComponent.prototype, "nzSpinning", void 0);
        return NzSpinComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzSpinModule = /** @class */ (function () {
        function NzSpinModule() {
        }
        NzSpinModule.decorators = [
            { type: core$1.NgModule, args: [{
                        exports: [NzSpinComponent],
                        declarations: [NzSpinComponent],
                        imports: [common.CommonModule, observers.ObserversModule]
                    },] }
        ];
        return NzSpinModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzSpinComponent = NzSpinComponent;
    exports.NzSpinModule = NzSpinModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-spin.umd.js.map