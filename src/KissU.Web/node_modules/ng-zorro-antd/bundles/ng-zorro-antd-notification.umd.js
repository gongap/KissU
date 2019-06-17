(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs'), require('ng-zorro-antd/core'), require('@angular/common'), require('ng-zorro-antd/icon'), require('@angular/cdk/overlay'), require('@angular/core'), require('ng-zorro-antd/message')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/notification', ['exports', 'rxjs', 'ng-zorro-antd/core', '@angular/common', 'ng-zorro-antd/icon', '@angular/cdk/overlay', '@angular/core', 'ng-zorro-antd/message'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].notification = {}),global.rxjs,global['ng-zorro-antd'].core,global.ng.common,global['ng-zorro-antd'].icon,global.ng.cdk.overlay,global.ng.core,global['ng-zorro-antd'].message));
}(this, (function (exports,rxjs,core,common,icon,i1,i0,message) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var NZ_NOTIFICATION_DEFAULT_CONFIG = new i0.InjectionToken('NZ_NOTIFICATION_DEFAULT_CONFIG');
    /** @type {?} */
    var NZ_NOTIFICATION_CONFIG = new i0.InjectionToken('NZ_NOTIFICATION_CONFIG');
    /** @type {?} */
    var NZ_NOTIFICATION_DEFAULT_CONFIG_PROVIDER = {
        provide: NZ_NOTIFICATION_DEFAULT_CONFIG,
        useValue: {
            nzTop: '24px',
            nzBottom: '24px',
            nzPlacement: 'topRight',
            nzDuration: 4500,
            nzMaxStack: 7,
            nzPauseOnHover: true,
            nzAnimate: true
        }
    };

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

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzNotificationContainerComponent = /** @class */ (function (_super) {
        __extends(NzNotificationContainerComponent, _super);
        function NzNotificationContainerComponent(cdr, defaultConfig, config) {
            var _this = _super.call(this, cdr, defaultConfig, config) || this;
            /**
             * @override
             */
            _this.messages = [];
            return _this;
        }
        /**
         * @override
         */
        /**
         * @override
         * @param {?} config
         * @return {?}
         */
        NzNotificationContainerComponent.prototype.setConfig = /**
         * @override
         * @param {?} config
         * @return {?}
         */
            function (config) {
                /** @type {?} */
                var newConfig = (this.config = __assign({}, this.config, config));
                /** @type {?} */
                var placement = this.config.nzPlacement;
                this.top = placement === 'topLeft' || placement === 'topRight' ? core.toCssPixel(newConfig.nzTop) : null;
                this.bottom = placement === 'bottomLeft' || placement === 'bottomRight' ? core.toCssPixel(newConfig.nzBottom) : null;
                this.cdr.markForCheck();
            };
        /**
         * Create a new notification.
         * If there's a notification whose `nzKey` is same with `nzKey` in `NzNotificationDataFilled`,
         * replace its content instead of create a new one.
         * @override
         * @param notification
         */
        /**
         * Create a new notification.
         * If there's a notification whose `nzKey` is same with `nzKey` in `NzNotificationDataFilled`,
         * replace its content instead of create a new one.
         * @override
         * @param {?} notification
         * @return {?}
         */
        NzNotificationContainerComponent.prototype.createMessage = /**
         * Create a new notification.
         * If there's a notification whose `nzKey` is same with `nzKey` in `NzNotificationDataFilled`,
         * replace its content instead of create a new one.
         * @override
         * @param {?} notification
         * @return {?}
         */
            function (notification) {
                notification.options = this._mergeMessageOptions(notification.options);
                notification.onClose = new rxjs.Subject();
                /** @type {?} */
                var key = notification.options.nzKey;
                /** @type {?} */
                var notificationWithSameKey = this.messages.find(( /**
                 * @param {?} msg
                 * @return {?}
                 */function (msg) { return msg.options.nzKey === (( /** @type {?} */(notification.options))).nzKey; }));
                if (key && notificationWithSameKey) {
                    this.replaceNotification(notificationWithSameKey, notification);
                }
                else {
                    if (this.messages.length >= this.config.nzMaxStack) {
                        this.messages.splice(0, 1);
                    }
                    this.messages.push(( /** @type {?} */(notification)));
                }
                this.cdr.detectChanges();
            };
        /**
         * @private
         * @param {?} old
         * @param {?} _new
         * @return {?}
         */
        NzNotificationContainerComponent.prototype.replaceNotification = /**
         * @private
         * @param {?} old
         * @param {?} _new
         * @return {?}
         */
            function (old, _new) {
                old.title = _new.title;
                old.content = _new.content;
                old.template = _new.template;
                old.type = _new.type;
            };
        NzNotificationContainerComponent.decorators = [
            { type: i0.Component, args: [{
                        changeDetection: i0.ChangeDetectionStrategy.OnPush,
                        encapsulation: i0.ViewEncapsulation.None,
                        selector: 'nz-notification-container',
                        exportAs: 'nzNotificationContainer',
                        preserveWhitespaces: false,
                        template: "<div\n  class=\"ant-notification ant-notification-{{config.nzPlacement}}\"\n  [style.top]=\"(config.nzPlacement === 'topLeft' || config.nzPlacement === 'topRight') ? top : null\"\n  [style.bottom]=\"(config.nzPlacement === 'bottomLeft' || config.nzPlacement === 'bottomRight') ? bottom : null\"\n  [style.right]=\"(config.nzPlacement === 'bottomRight' || config.nzPlacement === 'topRight') ? '0px' : null\"\n  [style.left]=\"(config.nzPlacement === 'topLeft' || config.nzPlacement === 'bottomLeft') ? '0px' : null\">\n  <nz-notification\n    *ngFor=\"let message of messages; let i = index\"\n    [nzMessage]=\"message\"\n    [nzIndex]=\"i\">\n  </nz-notification>\n</div>"
                    }] }
        ];
        /** @nocollapse */
        NzNotificationContainerComponent.ctorParameters = function () {
            return [
                { type: i0.ChangeDetectorRef },
                { type: undefined, decorators: [{ type: i0.Optional }, { type: i0.Inject, args: [NZ_NOTIFICATION_DEFAULT_CONFIG,] }] },
                { type: undefined, decorators: [{ type: i0.Optional }, { type: i0.Inject, args: [NZ_NOTIFICATION_CONFIG,] }] }
            ];
        };
        return NzNotificationContainerComponent;
    }(message.NzMessageContainerComponent));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzNotificationComponent = /** @class */ (function (_super) {
        __extends(NzNotificationComponent, _super);
        function NzNotificationComponent(container, cdr) {
            var _this = _super.call(this, container, cdr) || this;
            _this.container = container;
            _this.cdr = cdr;
            return _this;
        }
        /**
         * @return {?}
         */
        NzNotificationComponent.prototype.close = /**
         * @return {?}
         */
            function () {
                this._destroy(true);
            };
        Object.defineProperty(NzNotificationComponent.prototype, "state", {
            get: /**
             * @return {?}
             */ function () {
                if (this.nzMessage.state === 'enter') {
                    if (this.container.config.nzPlacement === 'topLeft' || this.container.config.nzPlacement === 'bottomLeft') {
                        return 'enterLeft';
                    }
                    else {
                        return 'enterRight';
                    }
                }
                else {
                    return this.nzMessage.state;
                }
            },
            enumerable: true,
            configurable: true
        });
        NzNotificationComponent.decorators = [
            { type: i0.Component, args: [{
                        encapsulation: i0.ViewEncapsulation.None,
                        selector: 'nz-notification',
                        exportAs: 'nzNotification',
                        preserveWhitespaces: false,
                        animations: [core.notificationMotion],
                        template: "<div class=\"ant-notification-notice ant-notification-notice-closable\"\n  [ngStyle]=\"nzMessage.options?.nzStyle\"\n  [ngClass]=\"nzMessage.options?.nzClass\"\n  [@notificationMotion]=\"state\"\n  (mouseenter)=\"onEnter()\"\n  (mouseleave)=\"onLeave()\">\n  <div *ngIf=\"!nzMessage.template\" class=\"ant-notification-notice-content\">\n    <div class=\"ant-notification-notice-content\" [ngClass]=\"{ 'ant-notification-notice-with-icon': nzMessage.type !== 'blank' }\">\n      <div [class.ant-notification-notice-with-icon]=\"nzMessage.type !== 'blank'\">\n        <ng-container [ngSwitch]=\"nzMessage.type\">\n          <i *ngSwitchCase=\"'success'\" nz-icon type=\"check-circle\" class=\"ant-notification-notice-icon ant-notification-notice-icon-success\"></i>\n          <i *ngSwitchCase=\"'info'\" nz-icon type=\"info-circle\" class=\"ant-notification-notice-icon ant-notification-notice-icon-info\"></i>\n          <i *ngSwitchCase=\"'warning'\" nz-icon type=\"exclamation-circle\" class=\"ant-notification-notice-icon ant-notification-notice-icon-warning\"></i>\n          <i *ngSwitchCase=\"'error'\" nz-icon type=\"close-circle\" class=\"ant-notification-notice-icon ant-notification-notice-icon-error\"></i>\n        </ng-container>\n        <div class=\"ant-notification-notice-message\" [innerHTML]=\"nzMessage.title\"></div>\n        <div class=\"ant-notification-notice-description\" [innerHTML]=\"nzMessage.content\"></div>\n      </div>\n    </div>\n  </div>\n  <ng-template\n    [ngIf]=\"nzMessage.template\"\n    [ngTemplateOutlet]=\"nzMessage.template\"\n    [ngTemplateOutletContext]=\"{ $implicit: this, data: nzMessage.options?.nzData }\">\n  </ng-template>\n  <a tabindex=\"0\" class=\"ant-notification-notice-close\" (click)=\"close()\">\n    <span class=\"ant-notification-notice-close-x\">\n      <i nz-icon type=\"close\" class=\"ant-notification-close-icon\"></i>\n    </span>\n  </a>\n</div>"
                    }] }
        ];
        /** @nocollapse */
        NzNotificationComponent.ctorParameters = function () {
            return [
                { type: NzNotificationContainerComponent },
                { type: i0.ChangeDetectorRef }
            ];
        };
        NzNotificationComponent.propDecorators = {
            nzMessage: [{ type: i0.Input }]
        };
        return NzNotificationComponent;
    }(message.NzMessageComponent));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzNotificationService = /** @class */ (function (_super) {
        __extends(NzNotificationService, _super);
        function NzNotificationService(overlay, injector, cfr, appRef) {
            return _super.call(this, overlay, NzNotificationContainerComponent, injector, cfr, appRef, 'notification-') || this;
        }
        // Shortcut methods
        // Shortcut methods
        /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
        NzNotificationService.prototype.success =
            // Shortcut methods
            /**
             * @param {?} title
             * @param {?} content
             * @param {?=} options
             * @return {?}
             */
            function (title, content, options) {
                return ( /** @type {?} */(this.createMessage({ type: 'success', title: title, content: content }, options)));
            };
        /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
        NzNotificationService.prototype.error = /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
            function (title, content, options) {
                return ( /** @type {?} */(this.createMessage({ type: 'error', title: title, content: content }, options)));
            };
        /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
        NzNotificationService.prototype.info = /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
            function (title, content, options) {
                return ( /** @type {?} */(this.createMessage({ type: 'info', title: title, content: content }, options)));
            };
        /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
        NzNotificationService.prototype.warning = /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
            function (title, content, options) {
                return ( /** @type {?} */(this.createMessage({ type: 'warning', title: title, content: content }, options)));
            };
        /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
        NzNotificationService.prototype.blank = /**
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
            function (title, content, options) {
                return ( /** @type {?} */(this.createMessage({ type: 'blank', title: title, content: content }, options)));
            };
        /**
         * @param {?} type
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
        NzNotificationService.prototype.create = /**
         * @param {?} type
         * @param {?} title
         * @param {?} content
         * @param {?=} options
         * @return {?}
         */
            function (type, title, content, options) {
                return ( /** @type {?} */(this.createMessage({ type: type, title: title, content: content }, options)));
            };
        // For content with template
        // For content with template
        /**
         * @param {?} template
         * @param {?=} options
         * @return {?}
         */
        NzNotificationService.prototype.template =
            // For content with template
            /**
             * @param {?} template
             * @param {?=} options
             * @return {?}
             */
            function (template, options) {
                return ( /** @type {?} */(this.createMessage({ template: template }, options)));
            };
        NzNotificationService.decorators = [
            { type: i0.Injectable, args: [{
                        providedIn: 'root'
                    },] }
        ];
        /** @nocollapse */
        NzNotificationService.ctorParameters = function () {
            return [
                { type: i1.Overlay },
                { type: i0.Injector },
                { type: i0.ComponentFactoryResolver },
                { type: i0.ApplicationRef }
            ];
        };
        /** @nocollapse */ NzNotificationService.ngInjectableDef = i0.defineInjectable({ factory: function NzNotificationService_Factory() { return new NzNotificationService(i0.inject(i1.Overlay), i0.inject(i0.INJECTOR), i0.inject(i0.ComponentFactoryResolver), i0.inject(i0.ApplicationRef)); }, token: NzNotificationService, providedIn: "root" });
        return NzNotificationService;
    }(message.NzMessageBaseService));

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzNotificationModule = /** @class */ (function () {
        function NzNotificationModule() {
        }
        NzNotificationModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, i1.OverlayModule, icon.NzIconModule],
                        declarations: [NzNotificationComponent, NzNotificationContainerComponent],
                        providers: [NZ_NOTIFICATION_DEFAULT_CONFIG_PROVIDER, NzNotificationService],
                        entryComponents: [NzNotificationContainerComponent]
                    },] }
        ];
        return NzNotificationModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NZ_NOTIFICATION_DEFAULT_CONFIG = NZ_NOTIFICATION_DEFAULT_CONFIG;
    exports.NZ_NOTIFICATION_CONFIG = NZ_NOTIFICATION_CONFIG;
    exports.NZ_NOTIFICATION_DEFAULT_CONFIG_PROVIDER = NZ_NOTIFICATION_DEFAULT_CONFIG_PROVIDER;
    exports.NzNotificationComponent = NzNotificationComponent;
    exports.NzNotificationModule = NzNotificationModule;
    exports.NzNotificationService = NzNotificationService;
    exports.NzNotificationContainerComponent = NzNotificationContainerComponent;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-notification.umd.js.map