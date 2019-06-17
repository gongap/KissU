(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('ng-zorro-antd/core'), require('@angular/common'), require('@angular/core'), require('@angular/forms'), require('ng-zorro-antd/icon')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/tag', ['exports', 'ng-zorro-antd/core', '@angular/common', '@angular/core', '@angular/forms', 'ng-zorro-antd/icon'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].tag = {}),global['ng-zorro-antd'].core,global.ng.common,global.ng.core,global.ng.forms,global['ng-zorro-antd'].icon));
}(this, (function (exports,core,common,core$1,forms,icon) { 'use strict';

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
    var NzTagComponent = /** @class */ (function () {
        function NzTagComponent(renderer, elementRef, nzUpdateHostClassService) {
            this.renderer = renderer;
            this.elementRef = elementRef;
            this.nzUpdateHostClassService = nzUpdateHostClassService;
            this.presetColor = false;
            this.nzMode = 'default';
            this.nzChecked = false;
            this.nzNoAnimation = false;
            this.nzAfterClose = new core$1.EventEmitter();
            this.nzOnClose = new core$1.EventEmitter();
            this.nzCheckedChange = new core$1.EventEmitter();
        }
        /**
         * @private
         * @param {?=} color
         * @return {?}
         */
        NzTagComponent.prototype.isPresetColor = /**
         * @private
         * @param {?=} color
         * @return {?}
         */
            function (color) {
                if (!color) {
                    return false;
                }
                return /^(pink|red|yellow|orange|cyan|green|blue|purple|geekblue|magenta|volcano|gold|lime)(-inverse)?$/.test(color);
            };
        /**
         * @private
         * @return {?}
         */
        NzTagComponent.prototype.updateClassMap = /**
         * @private
         * @return {?}
         */
            function () {
                var _a;
                this.presetColor = this.isPresetColor(this.nzColor);
                /** @type {?} */
                var prefix = 'ant-tag';
                this.nzUpdateHostClassService.updateHostClass(this.elementRef.nativeElement, (_a = {},
                    _a["" + prefix] = true,
                    _a[prefix + "-has-color"] = this.nzColor && !this.presetColor,
                    _a[prefix + "-" + this.nzColor] = this.presetColor,
                    _a[prefix + "-checkable"] = this.nzMode === 'checkable',
                    _a[prefix + "-checkable-checked"] = this.nzChecked,
                    _a));
            };
        /**
         * @return {?}
         */
        NzTagComponent.prototype.updateCheckedStatus = /**
         * @return {?}
         */
            function () {
                if (this.nzMode === 'checkable') {
                    this.nzChecked = !this.nzChecked;
                    this.nzCheckedChange.emit(this.nzChecked);
                    this.updateClassMap();
                }
            };
        /**
         * @param {?} e
         * @return {?}
         */
        NzTagComponent.prototype.closeTag = /**
         * @param {?} e
         * @return {?}
         */
            function (e) {
                this.nzOnClose.emit(e);
                if (!e.defaultPrevented) {
                    this.renderer.removeChild(this.renderer.parentNode(this.elementRef.nativeElement), this.elementRef.nativeElement);
                }
            };
        /**
         * @param {?} e
         * @return {?}
         */
        NzTagComponent.prototype.afterAnimation = /**
         * @param {?} e
         * @return {?}
         */
            function (e) {
                if (e.toState === 'void') {
                    this.nzAfterClose.emit();
                }
            };
        /**
         * @return {?}
         */
        NzTagComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.updateClassMap();
            };
        /**
         * @return {?}
         */
        NzTagComponent.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                this.updateClassMap();
            };
        NzTagComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-tag',
                        exportAs: 'nzTag',
                        preserveWhitespaces: false,
                        providers: [core.NzUpdateHostClassService],
                        animations: [core.fadeMotion],
                        template: "<ng-content></ng-content>\n<i nz-icon type=\"close\" *ngIf=\"nzMode==='closeable'\" tabindex=\"-1\" (click)=\"closeTag($event)\"></i>\n",
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        encapsulation: core$1.ViewEncapsulation.None,
                        host: {
                            '[@fadeMotion]': '',
                            '(@fadeMotion.done)': 'afterAnimation($event)',
                            '(click)': 'updateCheckedStatus()',
                            '[style.background-color]': 'presetColor? null : nzColor'
                        }
                    }] }
        ];
        /** @nocollapse */
        NzTagComponent.ctorParameters = function () {
            return [
                { type: core$1.Renderer2 },
                { type: core$1.ElementRef },
                { type: core.NzUpdateHostClassService }
            ];
        };
        NzTagComponent.propDecorators = {
            nzMode: [{ type: core$1.Input }],
            nzColor: [{ type: core$1.Input }],
            nzChecked: [{ type: core$1.Input }],
            nzNoAnimation: [{ type: core$1.Input }],
            nzAfterClose: [{ type: core$1.Output }],
            nzOnClose: [{ type: core$1.Output }],
            nzCheckedChange: [{ type: core$1.Output }]
        };
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Boolean)
        ], NzTagComponent.prototype, "nzChecked", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Boolean)
        ], NzTagComponent.prototype, "nzNoAnimation", void 0);
        return NzTagComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzTagModule = /** @class */ (function () {
        function NzTagModule() {
        }
        NzTagModule.decorators = [
            { type: core$1.NgModule, args: [{
                        imports: [common.CommonModule, forms.FormsModule, icon.NzIconModule],
                        declarations: [NzTagComponent],
                        exports: [NzTagComponent]
                    },] }
        ];
        return NzTagModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzTagComponent = NzTagComponent;
    exports.NzTagModule = NzTagModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-tag.umd.js.map