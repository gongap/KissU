/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@delon/util'), require('@angular/common'), require('@angular/core'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/avatar-list', ['exports', '@delon/util', '@angular/common', '@angular/core', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['avatar-list'] = {}),global.delon.util,global.ng.common,global.ng.core,global['ng-zorro-antd']));
}(this, (function (exports,util,common,core,ngZorroAntd) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var AvatarListItemComponent = /** @class */ (function () {
        function AvatarListItemComponent() {
        }
        AvatarListItemComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'avatar-list-item, [avatar-list-item]',
                        template: "<ng-content></ng-content>"
                    }] }
        ];
        AvatarListItemComponent.propDecorators = {
            src: [{ type: core.Input }],
            text: [{ type: core.Input }],
            icon: [{ type: core.Input }],
            tips: [{ type: core.Input }]
        };
        return AvatarListItemComponent;
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
    var AvatarListComponent = /** @class */ (function () {
        function AvatarListComponent(cdr) {
            this.cdr = cdr;
            this.inited = false;
            this.items = [];
            this.exceedCount = 0;
            this.cls = '';
            this.avatarSize = '';
            this.maxLength = 0;
        }
        Object.defineProperty(AvatarListComponent.prototype, "size", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this.cls = 'avatar-list__item' + (value === 'default' ? '' : " avatar-list__" + value);
                switch (value) {
                    case 'large':
                    case 'small':
                    case 'default':
                        this.avatarSize = value;
                        break;
                    default:
                        this.avatarSize = 'small';
                        break;
                }
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @private
         * @return {?}
         */
        AvatarListComponent.prototype.gen = /**
         * @private
         * @return {?}
         */
            function () {
                var _items = this._items;
                /** @type {?} */
                var maxLength = this.maxLength > 0 ? this.maxLength : _items.length;
                /** @type {?} */
                var numOfChildren = _items.length;
                /** @type {?} */
                var numToShow = maxLength > 0 && maxLength >= numOfChildren ? numOfChildren : maxLength;
                this.items = _items.toArray().slice(0, numToShow);
                this.exceedCount = numToShow < numOfChildren ? numOfChildren - maxLength : 0;
                this.cdr.detectChanges();
            };
        /**
         * @return {?}
         */
        AvatarListComponent.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                this.gen();
                this.inited = true;
            };
        /**
         * @return {?}
         */
        AvatarListComponent.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                if (this.inited) {
                    this.gen();
                }
            };
        AvatarListComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'avatar-list',
                        template: "<ul class=\"avatar-list__wrap\">\n  <li *ngFor=\"let i of items\"\n      [class]=\"cls\">\n    <nz-tooltip *ngIf=\"i.tips\"\n                [nzTitle]=\"i.tips\">\n      <nz-avatar nz-tooltip\n                 [nzSrc]=\"i.src\"\n                 [nzText]=\"i.text\"\n                 [nzIcon]=\"i.icon\"\n                 [nzSize]=\"avatarSize\"></nz-avatar>\n    </nz-tooltip>\n    <nz-avatar *ngIf=\"!i.tips\"\n               [nzSrc]=\"i.src\"\n               [nzText]=\"i.text\"\n               [nzIcon]=\"i.icon\"\n               [nzSize]=\"avatarSize\"></nz-avatar>\n  </li>\n  <li *ngIf=\"exceedCount > 0\"\n      [class]=\"cls\">\n    <nz-avatar [nzSize]=\"avatarSize\"\n               style=\"cursor: auto\"\n               [ngStyle]=\"excessItemsStyle\"\n               [nzText]=\"'+' + exceedCount\"></nz-avatar>\n  </li>\n</ul>\n",
                        host: { '[class.avatar-list]': 'true' },
                        changeDetection: core.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        AvatarListComponent.ctorParameters = function () {
            return [
                { type: core.ChangeDetectorRef }
            ];
        };
        AvatarListComponent.propDecorators = {
            _items: [{ type: core.ContentChildren, args: [AvatarListItemComponent, { descendants: false },] }],
            size: [{ type: core.Input }],
            maxLength: [{ type: core.Input }],
            excessItemsStyle: [{ type: core.Input }]
        };
        __decorate([
            util.InputNumber(),
            __metadata("design:type", Object)
        ], AvatarListComponent.prototype, "maxLength", void 0);
        return AvatarListComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [AvatarListComponent, AvatarListItemComponent];
    var AvatarListModule = /** @class */ (function () {
        function AvatarListModule() {
        }
        AvatarListModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, ngZorroAntd.NgZorroAntdModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return AvatarListModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.AvatarListItemComponent = AvatarListItemComponent;
    exports.AvatarListComponent = AvatarListComponent;
    exports.AvatarListModule = AvatarListModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=avatarList.umd.js.map