(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('ng-zorro-antd/core'), require('ng-zorro-antd/divider'), require('ng-zorro-antd/icon'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/page-header', ['exports', '@angular/common', 'ng-zorro-antd/core', 'ng-zorro-antd/divider', 'ng-zorro-antd/icon', '@angular/core'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd']['page-header'] = {}),global.ng.common,global['ng-zorro-antd'].core,global['ng-zorro-antd'].divider,global['ng-zorro-antd'].icon,global.ng.core));
}(this, (function (exports,common,core,divider,icon,core$1) { 'use strict';

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
    var NzPageHeaderTitleDirective = /** @class */ (function () {
        function NzPageHeaderTitleDirective() {
        }
        NzPageHeaderTitleDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-page-header-title, [nz-page-header-title]',
                        exportAs: 'nzPageHeaderTitle',
                        host: {
                            class: 'ant-page-header-title-view-title'
                        }
                    },] }
        ];
        return NzPageHeaderTitleDirective;
    }());
    var NzPageHeaderSubtitleDirective = /** @class */ (function () {
        function NzPageHeaderSubtitleDirective() {
        }
        NzPageHeaderSubtitleDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-page-header-subtitle, [nz-page-header-subtitle]',
                        exportAs: 'nzPageHeaderSubtitle',
                        host: {
                            class: 'ant-page-header-title-view-sub-title'
                        }
                    },] }
        ];
        return NzPageHeaderSubtitleDirective;
    }());
    var NzPageHeaderContentDirective = /** @class */ (function () {
        function NzPageHeaderContentDirective() {
        }
        NzPageHeaderContentDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-page-header-content, [nz-page-header-content]',
                        exportAs: 'nzPageHeaderContent',
                        host: {
                            class: 'ant-page-header-content-view'
                        }
                    },] }
        ];
        return NzPageHeaderContentDirective;
    }());
    var NzPageHeaderTagDirective = /** @class */ (function () {
        function NzPageHeaderTagDirective() {
        }
        NzPageHeaderTagDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-page-header-tags, [nz-page-header-tags]',
                        exportAs: 'nzPageHeaderTags',
                        host: {
                            class: 'ant-page-header-title-view-tags'
                        }
                    },] }
        ];
        return NzPageHeaderTagDirective;
    }());
    var NzPageHeaderExtraDirective = /** @class */ (function () {
        function NzPageHeaderExtraDirective() {
        }
        NzPageHeaderExtraDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-page-header-extra, [nz-page-header-extra]',
                        exportAs: 'nzPageHeaderExtra',
                        host: {
                            class: 'ant-page-header-title-view-extra'
                        }
                    },] }
        ];
        return NzPageHeaderExtraDirective;
    }());
    var NzPageHeaderFooterDirective = /** @class */ (function () {
        function NzPageHeaderFooterDirective() {
        }
        NzPageHeaderFooterDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-page-header-footer, [nz-page-header-footer]',
                        exportAs: 'nzPageHeaderFooter',
                        host: {
                            class: 'ant-page-header-footer'
                        }
                    },] }
        ];
        return NzPageHeaderFooterDirective;
    }());
    var NzPageHeaderBreadcrumbDirective = /** @class */ (function () {
        function NzPageHeaderBreadcrumbDirective() {
        }
        NzPageHeaderBreadcrumbDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-breadcrumb[nz-page-header-breadcrumb]',
                        exportAs: 'nzPageHeaderBreadcrumb'
                    },] }
        ];
        return NzPageHeaderBreadcrumbDirective;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzPageHeaderComponent = /** @class */ (function () {
        function NzPageHeaderComponent() {
            this.isTemplateRefBackIcon = false;
            this.isStringBackIcon = false;
            this.nzBackIcon = null;
            this.nzBack = new core$1.EventEmitter();
        }
        /**
         * @return {?}
         */
        NzPageHeaderComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () { };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzPageHeaderComponent.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (changes.hasOwnProperty('nzBackIcon')) {
                    this.isTemplateRefBackIcon = changes.nzBackIcon.currentValue instanceof core$1.TemplateRef;
                    this.isStringBackIcon = typeof changes.nzBackIcon.currentValue === 'string';
                }
            };
        /**
         * @return {?}
         */
        NzPageHeaderComponent.prototype.onBack = /**
         * @return {?}
         */
            function () {
                this.nzBack.emit();
            };
        NzPageHeaderComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-page-header',
                        exportAs: 'nzPageHeader',
                        template: "<ng-content select=\"nz-breadcrumb[nz-page-header-breadcrumb]\"></ng-content>\n\n<div *ngIf=\"nzBackIcon !== null\" (click)=\"onBack()\" class=\"ant-page-header-back-icon\">\n  <i *ngIf=\"isStringBackIcon\" nz-icon [type]=\"nzBackIcon ? nzBackIcon : 'arrow-left'\" theme=\"outline\"></i>\n  <ng-container *ngIf=\"isTemplateRefBackIcon\" [ngTemplateOutlet]=\"nzBackIcon\"></ng-container>\n  <nz-divider nzType=\"vertical\"></nz-divider>\n</div>\n\n<div class=\"ant-page-header-title-view\">\n  <span class=\"ant-page-header-title-view-title\" *ngIf=\"nzTitle\">\n    <ng-container *nzStringTemplateOutlet=\"nzTitle\">{{ nzTitle }}</ng-container>\n  </span>\n  <ng-content *ngIf=\"!nzTitle\" select=\"nz-page-header-title, [nz-page-header-title]\"></ng-content>\n  <span class=\"ant-page-header-title-view-sub-title\" *ngIf=\"nzSubtitle\">\n    <ng-container *nzStringTemplateOutlet=\"nzSubtitle\">{{ nzSubtitle }}</ng-container>\n  </span>\n  <ng-content *ngIf=\"!nzSubtitle\" select=\"nz-page-header-subtitle, [nz-page-header-subtitle]\"></ng-content>\n  <ng-content select=\"nz-page-header-tags, [nz-page-header-tags]\"></ng-content>\n  <ng-content select=\"nz-page-header-extra, [nz-page-header-extra]\"></ng-content>\n</div>\n\n<ng-content select=\"nz-page-header-content, [nz-page-header-content]\"></ng-content>\n<ng-content select=\"nz-page-header-footer, [nz-page-header-footer]\"></ng-content>\n",
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        encapsulation: core$1.ViewEncapsulation.None,
                        host: {
                            class: 'ant-page-header',
                            '[class.ant-page-header-has-footer]': 'nzPageHeaderFooter'
                        },
                        styles: ["nz-page-header,nz-page-header-content,nz-page-header-footer{display:block}"]
                    }] }
        ];
        /** @nocollapse */
        NzPageHeaderComponent.ctorParameters = function () { return []; };
        NzPageHeaderComponent.propDecorators = {
            nzBackIcon: [{ type: core$1.Input }],
            nzTitle: [{ type: core$1.Input }],
            nzSubtitle: [{ type: core$1.Input }],
            nzBack: [{ type: core$1.Output }],
            nzPageHeaderFooter: [{ type: core$1.ContentChild, args: [NzPageHeaderFooterDirective,] }]
        };
        return NzPageHeaderComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var NzPageHeaderCells = [
        NzPageHeaderTitleDirective,
        NzPageHeaderSubtitleDirective,
        NzPageHeaderContentDirective,
        NzPageHeaderTagDirective,
        NzPageHeaderExtraDirective,
        NzPageHeaderFooterDirective,
        NzPageHeaderBreadcrumbDirective
    ];
    var NzPageHeaderModule = /** @class */ (function () {
        function NzPageHeaderModule() {
        }
        NzPageHeaderModule.decorators = [
            { type: core$1.NgModule, args: [{
                        imports: [common.CommonModule, core.NzAddOnModule, icon.NzIconModule, divider.NzDividerModule],
                        exports: __spread([NzPageHeaderComponent], NzPageHeaderCells),
                        declarations: __spread([NzPageHeaderComponent], NzPageHeaderCells)
                    },] }
        ];
        return NzPageHeaderModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzPageHeaderModule = NzPageHeaderModule;
    exports.NzPageHeaderComponent = NzPageHeaderComponent;
    exports.NzPageHeaderTitleDirective = NzPageHeaderTitleDirective;
    exports.NzPageHeaderSubtitleDirective = NzPageHeaderSubtitleDirective;
    exports.NzPageHeaderContentDirective = NzPageHeaderContentDirective;
    exports.NzPageHeaderTagDirective = NzPageHeaderTagDirective;
    exports.NzPageHeaderExtraDirective = NzPageHeaderExtraDirective;
    exports.NzPageHeaderFooterDirective = NzPageHeaderFooterDirective;
    exports.NzPageHeaderBreadcrumbDirective = NzPageHeaderBreadcrumbDirective;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-page-header.umd.js.map