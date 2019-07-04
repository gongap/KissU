(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/common'), require('ng-zorro-antd/core'), require('@angular/cdk/portal'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/comment', ['exports', '@angular/common', 'ng-zorro-antd/core', '@angular/cdk/portal', '@angular/core'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].comment = {}),global.ng.common,global['ng-zorro-antd'].core,global.ng.cdk.portal,global.ng.core));
}(this, (function (exports,common,core,portal,core$1) { 'use strict';

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
    var NzCommentAvatarDirective = /** @class */ (function () {
        function NzCommentAvatarDirective() {
        }
        NzCommentAvatarDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-avatar[nz-comment-avatar]',
                        exportAs: 'nzCommentAvatar'
                    },] }
        ];
        return NzCommentAvatarDirective;
    }());
    var NzCommentContentDirective = /** @class */ (function () {
        function NzCommentContentDirective() {
        }
        NzCommentContentDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: 'nz-comment-content, [nz-comment-content]',
                        exportAs: 'nzCommentContent',
                        host: { class: 'ant-comment-content-detail' }
                    },] }
        ];
        return NzCommentContentDirective;
    }());
    var NzCommentActionHostDirective = /** @class */ (function (_super) {
        __extends(NzCommentActionHostDirective, _super);
        function NzCommentActionHostDirective(componentFactoryResolver, viewContainerRef) {
            return _super.call(this, componentFactoryResolver, viewContainerRef) || this;
        }
        /**
         * @return {?}
         */
        NzCommentActionHostDirective.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                _super.prototype.ngOnInit.call(this);
                this.attach(this.nzCommentActionHost);
            };
        /**
         * @return {?}
         */
        NzCommentActionHostDirective.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                _super.prototype.ngOnDestroy.call(this);
            };
        NzCommentActionHostDirective.decorators = [
            { type: core$1.Directive, args: [{
                        selector: '[nzCommentActionHost]',
                        exportAs: 'nzCommentActionHost'
                    },] }
        ];
        /** @nocollapse */
        NzCommentActionHostDirective.ctorParameters = function () {
            return [
                { type: core$1.ComponentFactoryResolver },
                { type: core$1.ViewContainerRef }
            ];
        };
        NzCommentActionHostDirective.propDecorators = {
            nzCommentActionHost: [{ type: core$1.Input }]
        };
        return NzCommentActionHostDirective;
    }(portal.CdkPortalOutlet));
    var NzCommentActionComponent = /** @class */ (function () {
        function NzCommentActionComponent(viewContainerRef) {
            this.viewContainerRef = viewContainerRef;
            this.contentPortal = null;
        }
        Object.defineProperty(NzCommentActionComponent.prototype, "content", {
            get: /**
             * @return {?}
             */ function () {
                return this.contentPortal;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @return {?}
         */
        NzCommentActionComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.contentPortal = new portal.TemplatePortal(this.implicitContent, this.viewContainerRef);
            };
        NzCommentActionComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-comment-action',
                        exportAs: 'nzCommentAction',
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        template: '<ng-template><ng-content></ng-content></ng-template>'
                    }] }
        ];
        /** @nocollapse */
        NzCommentActionComponent.ctorParameters = function () {
            return [
                { type: core$1.ViewContainerRef }
            ];
        };
        NzCommentActionComponent.propDecorators = {
            implicitContent: [{ type: core$1.ViewChild, args: [core$1.TemplateRef,] }]
        };
        return NzCommentActionComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzCommentComponent = /** @class */ (function () {
        function NzCommentComponent() {
        }
        NzCommentComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-comment',
                        exportAs: 'nzComment',
                        template: "<div class=\"ant-comment-inner\">\n  <div class=\"ant-comment-avatar\">\n    <ng-content select=\"nz-avatar[nz-comment-avatar]\"></ng-content>\n  </div>\n  <div class=\"ant-comment-content\">\n    <div class=\"ant-comment-content-author\">\n      <span *ngIf=\"nzAuthor\" class=\"ant-comment-content-author-name\">\n        <ng-container *nzStringTemplateOutlet=\"nzAuthor\">{{ nzAuthor }}</ng-container>\n      </span>\n      <span *ngIf=\"nzDatetime\" class=\"ant-comment-content-author-time\">\n        <ng-container *nzStringTemplateOutlet=\"nzDatetime\">{{ nzDatetime }}</ng-container>\n      </span>\n    </div>\n    <ng-content select=\"nz-comment-content\"></ng-content>\n    <ul class=\"ant-comment-actions\" *ngIf=\"actions?.length\">\n      <li *ngFor=\"let action of actions\">\n        <span><ng-template [nzCommentActionHost]=\"action.content\"></ng-template></span>\n      </li>\n    </ul>\n  </div>\n</div>\n<div class=\"ant-comment-nested\">\n  <ng-content></ng-content>\n</div>",
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        host: {
                            class: 'ant-comment'
                        },
                        styles: ["\n      nz-comment {\n        display: block;\n      }\n\n      nz-comment-content {\n        display: block;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzCommentComponent.ctorParameters = function () { return []; };
        NzCommentComponent.propDecorators = {
            nzAuthor: [{ type: core$1.Input }],
            nzDatetime: [{ type: core$1.Input }],
            actions: [{ type: core$1.ContentChildren, args: [NzCommentActionComponent,] }]
        };
        return NzCommentComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var NZ_COMMENT_CELLS = [
        NzCommentAvatarDirective,
        NzCommentContentDirective,
        NzCommentActionComponent,
        NzCommentActionHostDirective
    ];
    var NzCommentModule = /** @class */ (function () {
        function NzCommentModule() {
        }
        NzCommentModule.decorators = [
            { type: core$1.NgModule, args: [{
                        imports: [common.CommonModule, core.NzAddOnModule],
                        exports: __spread([NzCommentComponent], NZ_COMMENT_CELLS),
                        declarations: __spread([NzCommentComponent], NZ_COMMENT_CELLS)
                    },] }
        ];
        return NzCommentModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzCommentModule = NzCommentModule;
    exports.NzCommentComponent = NzCommentComponent;
    exports.NzCommentAvatarDirective = NzCommentAvatarDirective;
    exports.NzCommentContentDirective = NzCommentContentDirective;
    exports.NzCommentActionHostDirective = NzCommentActionHostDirective;
    exports.NzCommentActionComponent = NzCommentActionComponent;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-comment.umd.js.map