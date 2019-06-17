(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('ng-zorro-antd/core'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/card', ['exports', '@angular/common', 'ng-zorro-antd/core', '@angular/core'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].card = {}),global.ng.common,global['ng-zorro-antd'].core,global.ng.core));
}(this, (function (exports,common,core,core$1) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzCardGridDirective = /** @class */ (function () {
        function NzCardGridDirective(elementRef, renderer) {
            renderer.addClass(elementRef.nativeElement, 'ant-card-grid');
        }
        NzCardGridDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: '[nz-card-grid]',
                        exportAs: 'nzCardGrid'
                    },] }
        ];
        /** @nocollapse */
        NzCardGridDirective.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.Renderer2 }
            ];
        };
        return NzCardGridDirective;
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

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzCardTabComponent = /** @class */ (function () {
        function NzCardTabComponent() {
        }
        NzCardTabComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-card-tab',
                        exportAs: 'nzCardTab',
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        template: "<ng-template>\n  <ng-content></ng-content>\n</ng-template>"
                    }] }
        ];
        NzCardTabComponent.propDecorators = {
            template: [{ type: core$1.ViewChild, args: [core$1.TemplateRef,] }]
        };
        return NzCardTabComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzCardComponent = /** @class */ (function () {
        function NzCardComponent(renderer, elementRef) {
            this.nzBordered = true;
            this.nzLoading = false;
            this.nzHoverable = false;
            this.nzActions = [];
            this.nzSize = 'default';
            renderer.addClass(elementRef.nativeElement, 'ant-card');
        }
        NzCardComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-card',
                        exportAs: 'nzCard',
                        preserveWhitespaces: false,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        encapsulation: core$1.ViewEncapsulation.None,
                        template: "<div class=\"ant-card-head\" *ngIf=\"nzTitle || nzExtra || tab\">\n  <div class=\"ant-card-head-wrapper\">\n    <div class=\"ant-card-head-title\" *ngIf=\"nzTitle\">\n      <ng-container *nzStringTemplateOutlet=\"nzTitle\">{{ nzTitle }}</ng-container>\n    </div>\n    <div class=\"ant-card-extra\" *ngIf=\"nzExtra\">\n      <ng-container *nzStringTemplateOutlet=\"nzExtra\">{{ nzExtra }}</ng-container>\n    </div>\n  </div>\n  <ng-container *ngIf=\"tab\">\n    <ng-template [ngTemplateOutlet]=\"tab.template\"></ng-template>\n  </ng-container>\n</div>\n<div class=\"ant-card-cover\" *ngIf=\"nzCover\">\n  <ng-template [ngTemplateOutlet]=\"nzCover\"></ng-template>\n</div>\n<div class=\"ant-card-body\" [ngStyle]=\"nzBodyStyle\">\n  <ng-container *ngIf=\"!nzLoading\">\n    <ng-content></ng-content>\n  </ng-container>\n  <nz-card-loading *ngIf=\"nzLoading\"></nz-card-loading>\n</div>\n<ul class=\"ant-card-actions\" *ngIf=\"nzActions.length\">\n  <li *ngFor=\"let action of nzActions\" [style.width.%]=\"100 / nzActions.length\">\n    <span><ng-template [ngTemplateOutlet]=\"action\"></ng-template></span>\n  </li>\n</ul>",
                        host: {
                            '[class.ant-card-loading]': 'nzLoading',
                            '[class.ant-card-bordered]': 'nzBordered',
                            '[class.ant-card-hoverable]': 'nzHoverable',
                            '[class.ant-card-small]': 'nzSize === "small"',
                            '[class.ant-card-contain-grid]': 'grids && grids.length',
                            '[class.ant-card-type-inner]': 'nzType === "inner"',
                            '[class.ant-card-contain-tabs]': '!!tab'
                        },
                        styles: ["\n      nz-card {\n        display: block;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzCardComponent.ctorParameters = function () {
            return [
                { type: core$1.Renderer2 },
                { type: core$1.ElementRef }
            ];
        };
        NzCardComponent.propDecorators = {
            nzBordered: [{ type: core$1.Input }],
            nzLoading: [{ type: core$1.Input }],
            nzHoverable: [{ type: core$1.Input }],
            nzBodyStyle: [{ type: core$1.Input }],
            nzCover: [{ type: core$1.Input }],
            nzActions: [{ type: core$1.Input }],
            nzType: [{ type: core$1.Input }],
            nzSize: [{ type: core$1.Input }],
            nzTitle: [{ type: core$1.Input }],
            nzExtra: [{ type: core$1.Input }],
            tab: [{ type: core$1.ContentChild, args: [NzCardTabComponent,] }],
            grids: [{ type: core$1.ContentChildren, args: [NzCardGridDirective,] }]
        };
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzCardComponent.prototype, "nzBordered", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzCardComponent.prototype, "nzLoading", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzCardComponent.prototype, "nzHoverable", void 0);
        return NzCardComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzCardLoadingComponent = /** @class */ (function () {
        function NzCardLoadingComponent(elementRef, renderer) {
            renderer.addClass(elementRef.nativeElement, 'ant-card-loading-content');
        }
        NzCardLoadingComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-card-loading',
                        exportAs: 'nzCardLoading',
                        template: "<div class=\"ant-card-loading-content\">\n  <div class=\"ant-row\" style=\"margin-left: -4px; margin-right: -4px;\">\n    <div class=\"ant-col-22\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n  </div>\n  <div class=\"ant-row\" style=\"margin-left: -4px; margin-right: -4px;\">\n    <div class=\"ant-col-8\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n    <div class=\"ant-col-15\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n  </div>\n  <div class=\"ant-row\" style=\"margin-left: -4px; margin-right: -4px;\">\n    <div class=\"ant-col-6\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n    <div class=\"ant-col-18\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n  </div>\n  <div class=\"ant-row\" style=\"margin-left: -4px; margin-right: -4px;\">\n    <div class=\"ant-col-13\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n    <div class=\"ant-col-9\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n  </div>\n  <div class=\"ant-row\" style=\"margin-left: -4px; margin-right: -4px;\">\n    <div class=\"ant-col-4\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n    <div class=\"ant-col-3\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n    <div class=\"ant-col-16\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n  </div>\n  <div class=\"ant-row\" style=\"margin-left: -4px; margin-right: -4px;\">\n    <div class=\"ant-col-8\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n    <div class=\"ant-col-6\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n    <div class=\"ant-col-8\" style=\"padding-left: 4px; padding-right: 4px;\">\n      <div class=\"ant-card-loading-block\"></div>\n    </div>\n  </div>\n</div>",
                        preserveWhitespaces: false,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        encapsulation: core$1.ViewEncapsulation.None,
                        styles: ["\n      nz-card-loading {\n        display: block;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzCardLoadingComponent.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.Renderer2 }
            ];
        };
        return NzCardLoadingComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzCardMetaComponent = /** @class */ (function () {
        function NzCardMetaComponent(elementRef, renderer) {
            renderer.addClass(elementRef.nativeElement, 'ant-card-meta');
        }
        NzCardMetaComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-card-meta',
                        exportAs: 'nzCardMeta',
                        preserveWhitespaces: false,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        encapsulation: core$1.ViewEncapsulation.None,
                        template: "<div class=\"ant-card-meta-avatar\" *ngIf=\"nzAvatar\">\n  <ng-template [ngTemplateOutlet]=\"nzAvatar\"></ng-template>\n</div>\n<div class=\"ant-card-meta-detail\" *ngIf=\"nzTitle || nzDescription\">\n  <div class=\"ant-card-meta-title\" *ngIf=\"nzTitle\">\n    <ng-container *nzStringTemplateOutlet=\"nzTitle\">{{ nzTitle }}</ng-container>\n  </div>\n  <div class=\"ant-card-meta-description\" *ngIf=\"nzDescription\">\n    <ng-container *nzStringTemplateOutlet=\"nzDescription\">{{ nzDescription }}</ng-container>\n  </div>\n</div>",
                        styles: ["\n      nz-card-meta {\n        display: block;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzCardMetaComponent.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.Renderer2 }
            ];
        };
        NzCardMetaComponent.propDecorators = {
            nzTitle: [{ type: core$1.Input }],
            nzDescription: [{ type: core$1.Input }],
            nzAvatar: [{ type: core$1.Input }]
        };
        return NzCardMetaComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzCardModule = /** @class */ (function () {
        function NzCardModule() {
        }
        NzCardModule.decorators = [
            { type: core$1.NgModule, args: [{
                        imports: [common.CommonModule, core.NzAddOnModule],
                        declarations: [NzCardComponent, NzCardGridDirective, NzCardMetaComponent, NzCardLoadingComponent, NzCardTabComponent],
                        exports: [NzCardComponent, NzCardGridDirective, NzCardMetaComponent, NzCardLoadingComponent, NzCardTabComponent]
                    },] }
        ];
        return NzCardModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzCardGridDirective = NzCardGridDirective;
    exports.NzCardComponent = NzCardComponent;
    exports.NzCardModule = NzCardModule;
    exports.NzCardLoadingComponent = NzCardLoadingComponent;
    exports.NzCardMetaComponent = NzCardMetaComponent;
    exports.NzCardTabComponent = NzCardTabComponent;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-card.umd.js.map