/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@delon/theme'), require('@angular/common'), require('@angular/core'), require('@angular/router'), require('@delon/util')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/global-footer', ['exports', '@delon/theme', '@angular/common', '@angular/core', '@angular/router', '@delon/util'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['global-footer'] = {}),global.delon.theme,global.ng.common,global.ng.core,global.ng.router,global.delon.util));
}(this, (function (exports,theme,common,core,router,util) { 'use strict';

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
    var GlobalFooterItemComponent = /** @class */ (function () {
        function GlobalFooterItemComponent() {
        }
        GlobalFooterItemComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'global-footer-item',
                        template: "\n    <ng-template #host><ng-content></ng-content></ng-template>\n  "
                    }] }
        ];
        GlobalFooterItemComponent.propDecorators = {
            host: [{ type: core.ViewChild, args: ['host',] }],
            href: [{ type: core.Input }],
            blankTarget: [{ type: core.Input }]
        };
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], GlobalFooterItemComponent.prototype, "blankTarget", void 0);
        return GlobalFooterItemComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var GlobalFooterComponent = /** @class */ (function () {
        function GlobalFooterComponent(router$$1, win) {
            this.router = router$$1;
            this.win = win;
            this.links = [];
        }
        /**
         * @param {?} item
         * @return {?}
         */
        GlobalFooterComponent.prototype.to = /**
         * @param {?} item
         * @return {?}
         */
            function (item) {
                if (!item.href) {
                    return;
                }
                if (item.blankTarget) {
                    this.win.open(item.href);
                    return;
                }
                if (/^https?:\/\//.test(item.href)) {
                    this.win.location.href = item.href;
                }
                else {
                    this.router.navigateByUrl(item.href);
                }
            };
        GlobalFooterComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'global-footer',
                        template: "<div *ngIf=\"links.length > 0 || items.length > 0\" class=\"global-footer__links\">\n  <a *ngFor=\"let i of links\" class=\"global-footer__links-item\" (click)=\"to(i)\" [innerHTML]=\"i.title\"></a>\n  <a *ngFor=\"let i of items\" class=\"global-footer__links-item\" (click)=\"to(i)\">\n    <ng-container *ngTemplateOutlet=\"i.host\"></ng-container>\n  </a>\n</div>\n<div class=\"global-footer__copyright\">\n  <ng-content></ng-content>\n</div>\n",
                        host: { '[class.global-footer]': 'true' },
                        changeDetection: core.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        GlobalFooterComponent.ctorParameters = function () {
            return [
                { type: router.Router },
                { type: Window, decorators: [{ type: core.Inject, args: [theme.WINDOW,] }] }
            ];
        };
        GlobalFooterComponent.propDecorators = {
            links: [{ type: core.Input }],
            items: [{ type: core.ContentChildren, args: [GlobalFooterItemComponent,] }]
        };
        return GlobalFooterComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [GlobalFooterComponent, GlobalFooterItemComponent];
    var GlobalFooterModule = /** @class */ (function () {
        function GlobalFooterModule() {
        }
        GlobalFooterModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, router.RouterModule, util.DelonUtilModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return GlobalFooterModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.GlobalFooterComponent = GlobalFooterComponent;
    exports.GlobalFooterItemComponent = GlobalFooterItemComponent;
    exports.GlobalFooterModule = GlobalFooterModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=globalFooter.umd.js.map