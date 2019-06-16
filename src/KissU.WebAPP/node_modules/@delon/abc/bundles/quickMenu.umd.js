/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('@angular/core'), require('@delon/util'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/quick-menu', ['exports', '@angular/common', '@angular/core', '@delon/util', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['quick-menu'] = {}),global.ng.common,global.ng.core,global.delon.util,global.ngZorroAntd));
}(this, (function (exports,common,core,util,ngZorroAntd) { 'use strict';

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
    var QuickMenuComponent = /** @class */ (function () {
        // #endregion
        function QuickMenuComponent(cdr, el, render) {
            this.cdr = cdr;
            this.el = el;
            this.render = render;
            // #region fields
            this.icon = 'question-circle';
            this.top = 120;
            this.width = 200;
            this.bgColor = '#fff';
            this.borderColor = '#ddd';
            this.show = false;
            this.ctrlStyle = {};
            this.initFlag = false;
        }
        /**
         * @return {?}
         */
        QuickMenuComponent.prototype._click = /**
         * @return {?}
         */
            function () {
                this.show = !this.show;
                this.setStyle();
            };
        /**
         * @private
         * @return {?}
         */
        QuickMenuComponent.prototype.setStyle = /**
         * @private
         * @return {?}
         */
            function () {
                this.ctrlStyle = {
                    'background-color': this.bgColor,
                    'border-color': this.borderColor,
                };
                /** @type {?} */
                var res = [
                    "top:" + this.top + "px",
                    "width:" + this.width + "px",
                    "background-color:" + this.bgColor,
                    "border-color:" + this.borderColor,
                    "margin-right:-" + (this.show ? 0 : this.width) + "px",
                ];
                this.render.setAttribute(this.el.nativeElement, 'style', res.join(';'));
                this.cdr.detectChanges();
            };
        /**
         * @return {?}
         */
        QuickMenuComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.initFlag = true;
                this.setStyle();
            };
        /**
         * @return {?}
         */
        QuickMenuComponent.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                if (this.initFlag)
                    this.setStyle();
            };
        QuickMenuComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'quick-menu',
                        template: "<div class=\"quick-menu__inner\">\n  <div class=\"quick-menu__ctrl\"\n       [ngStyle]=\"ctrlStyle\">\n    <div class=\"quick-menu__ctrl-icon\">\n      <ng-container *stringTemplateOutlet=\"icon\"><i nz-icon\n           [type]=\"icon\"></i></ng-container>\n    </div>\n  </div>\n  <ng-content></ng-content>\n</div>\n",
                        host: {
                            '[class.quick-menu]': 'true',
                            '(click)': '_click()',
                        },
                        changeDetection: core.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        QuickMenuComponent.ctorParameters = function () {
            return [
                { type: core.ChangeDetectorRef },
                { type: core.ElementRef },
                { type: core.Renderer2 }
            ];
        };
        QuickMenuComponent.propDecorators = {
            icon: [{ type: core.Input }],
            top: [{ type: core.Input }],
            width: [{ type: core.Input }],
            bgColor: [{ type: core.Input }],
            borderColor: [{ type: core.Input }]
        };
        __decorate([
            util.InputNumber(),
            __metadata("design:type", Object)
        ], QuickMenuComponent.prototype, "top", void 0);
        __decorate([
            util.InputNumber(),
            __metadata("design:type", Object)
        ], QuickMenuComponent.prototype, "width", void 0);
        return QuickMenuComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [QuickMenuComponent];
    var QuickMenuModule = /** @class */ (function () {
        function QuickMenuModule() {
        }
        QuickMenuModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, ngZorroAntd.NgZorroAntdModule, util.DelonUtilModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return QuickMenuModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.QuickMenuComponent = QuickMenuComponent;
    exports.QuickMenuModule = QuickMenuModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=quickMenu.umd.js.map