/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs'), require('rxjs/operators'), require('@delon/abc/reuse-tab'), require('@delon/theme'), require('@angular/common'), require('@angular/core'), require('@angular/router'), require('@delon/util'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/page-header', ['exports', 'rxjs', 'rxjs/operators', '@delon/abc/reuse-tab', '@delon/theme', '@angular/common', '@angular/core', '@angular/router', '@delon/util', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['page-header'] = {}),global.rxjs,global.rxjs.operators,global.delon.abc['reuse-tab'],global.delon.theme,global.ng.common,global.ng.core,global.ng.router,global.delon.util,global['ng-zorro-antd']));
}(this, (function (exports,rxjs,operators,reuseTab,theme,common,i0,router,util,ngZorroAntd) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var PageHeaderConfig = /** @class */ (function () {
        function PageHeaderConfig() {
            /**
             * 首页文本，若指定空表示不显示
             */
            this.home = '首页';
            /**
             * 首页链接
             */
            this.homeLink = '/';
            /**
             * 自动生成导航，以当前路由从主菜单中定位
             */
            this.autoBreadcrumb = true;
            /**
             * 自动向上递归查找
             *  - 菜单数据源包含 `/ware`，则 `/ware/1` 也视为 `/ware` 项
             */
            this.recursiveBreadcrumb = false;
            /**
             * 自动生成标题，以当前路由从主菜单中定位
             */
            this.autoTitle = true;
            /**
             * 是否自动将标准信息同步至 `TitleService`、`ReuseService` 下
             */
            this.syncTitle = false;
            /**
             * 是否固定模式
             */
            this.fixed = false;
            /**
             * 固定偏移值
             */
            this.fixedOffsetTop = 64;
        }
        PageHeaderConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ PageHeaderConfig.ngInjectableDef = i0.defineInjectable({ factory: function PageHeaderConfig_Factory() { return new PageHeaderConfig(); }, token: PageHeaderConfig, providedIn: "root" });
        return PageHeaderConfig;
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
    var PageHeaderComponent = /** @class */ (function () {
        // #endregion
        function PageHeaderComponent(cog, settings, renderer, router$$1, menuSrv, i18nSrv, titleSrv, reuseSrv, cdr) {
            var _this = this;
            this.renderer = renderer;
            this.router = router$$1;
            this.menuSrv = menuSrv;
            this.i18nSrv = i18nSrv;
            this.titleSrv = titleSrv;
            this.reuseSrv = reuseSrv;
            this.cdr = cdr;
            this.inited = false;
            this.unsubscribe$ = new rxjs.Subject();
            this.paths = [];
            this.loading = false;
            this.wide = false;
            Object.assign(this, __assign({}, new PageHeaderConfig(), cog));
            settings.notify
                .pipe(operators.takeUntil(this.unsubscribe$), operators.filter(( /**
         * @param {?} w
         * @return {?}
         */function (w) { return _this.affix && w.type === 'layout' && w.name === 'collapsed'; })))
                .subscribe(( /**
         * @return {?}
         */function () { return _this.affix.updatePosition(( /** @type {?} */({}))); }));
            rxjs.merge(menuSrv.change.pipe(operators.filter(( /**
             * @return {?}
             */function () { return _this.inited; }))), router$$1.events.pipe(operators.filter(( /**
             * @param {?} event
             * @return {?}
             */function (event) { return event instanceof router.NavigationEnd; }))), i18nSrv.change)
                .pipe(operators.takeUntil(this.unsubscribe$))
                .subscribe(( /**
         * @return {?}
         */function () {
                _this._menus = null;
                _this.refresh();
            }));
        }
        Object.defineProperty(PageHeaderComponent.prototype, "menus", {
            get: /**
             * @private
             * @return {?}
             */ function () {
                if (this._menus) {
                    return this._menus;
                }
                this._menus = this.menuSrv.getPathByUrl(this.router.url.split('?')[0], this.recursiveBreadcrumb);
                return this._menus;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(PageHeaderComponent.prototype, "title", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                if (value instanceof i0.TemplateRef) {
                    this._title = null;
                    this._titleTpl = value;
                }
                else {
                    this._title = value;
                }
                this._titleVal = this._title;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @return {?}
         */
        PageHeaderComponent.prototype.refresh = /**
         * @return {?}
         */
            function () {
                this.setTitle().genBreadcrumb();
                this.cdr.detectChanges();
            };
        /**
         * @private
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
        PageHeaderComponent.prototype.genBreadcrumb = /**
         * @private
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
            function () {
                var _this = this;
                if (( /** @type {?} */(this)).breadcrumb || !( /** @type {?} */(this)).autoBreadcrumb || ( /** @type {?} */(this)).menus.length <= 0) {
                    ( /** @type {?} */(this)).paths = [];
                    return;
                }
                /** @type {?} */
                var paths = [];
                ( /** @type {?} */(this)).menus.forEach(( /**
                 * @param {?} item
                 * @return {?}
                 */function (item) {
                    if (typeof item.hideInBreadcrumb !== 'undefined' && item.hideInBreadcrumb)
                        return;
                    /** @type {?} */
                    var title = item.text;
                    if (item.i18n && ( /** @type {?} */(_this)).i18nSrv)
                        title = ( /** @type {?} */(_this)).i18nSrv.fanyi(item.i18n);
                    paths.push({ title: title, link: item.link && [item.link] });
                }));
                // add home
                if (( /** @type {?} */(this)).home) {
                    paths.splice(0, 0, {
                        title: (( /** @type {?} */(this)).homeI18n && ( /** @type {?} */(this)).i18nSrv && ( /** @type {?} */(this)).i18nSrv.fanyi(( /** @type {?} */(this)).homeI18n)) || ( /** @type {?} */(this)).home,
                        link: [( /** @type {?} */(this)).homeLink],
                    });
                }
                ( /** @type {?} */(this)).paths = paths;
                return ( /** @type {?} */(this));
            };
        /**
         * @private
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
        PageHeaderComponent.prototype.setTitle = /**
         * @private
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
            function () {
                if (typeof ( /** @type {?} */(this))._title === 'undefined' &&
                    typeof ( /** @type {?} */(this))._titleTpl === 'undefined' &&
                    ( /** @type {?} */(this)).autoTitle &&
                    ( /** @type {?} */(this)).menus.length > 0) {
                    /** @type {?} */
                    var item = ( /** @type {?} */(this)).menus[( /** @type {?} */(this)).menus.length - 1];
                    /** @type {?} */
                    var title = item.text;
                    if (item.i18n && ( /** @type {?} */(this)).i18nSrv)
                        title = ( /** @type {?} */(this)).i18nSrv.fanyi(item.i18n);
                    ( /** @type {?} */(this))._titleVal = title;
                }
                if (( /** @type {?} */(this))._titleVal && ( /** @type {?} */(this)).syncTitle) {
                    if (( /** @type {?} */(this)).titleSrv) {
                        ( /** @type {?} */(this)).titleSrv.setTitle(( /** @type {?} */(this))._titleVal);
                    }
                    if (( /** @type {?} */(this)).reuseSrv) {
                        ( /** @type {?} */(this)).reuseSrv.title = ( /** @type {?} */(this))._titleVal;
                    }
                }
                return ( /** @type {?} */(this));
            };
        /**
         * @return {?}
         */
        PageHeaderComponent.prototype.checkContent = /**
         * @return {?}
         */
            function () {
                if (util.isEmpty(this.conTpl.nativeElement)) {
                    this.renderer.setAttribute(this.conTpl.nativeElement, 'hidden', '');
                }
                else {
                    this.renderer.removeAttribute(this.conTpl.nativeElement, 'hidden');
                }
            };
        /**
         * @return {?}
         */
        PageHeaderComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.refresh();
                this.inited = true;
            };
        /**
         * @return {?}
         */
        PageHeaderComponent.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                this.checkContent();
            };
        /**
         * @return {?}
         */
        PageHeaderComponent.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                if (this.inited)
                    this.refresh();
            };
        /**
         * @return {?}
         */
        PageHeaderComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                var unsubscribe$ = this.unsubscribe$;
                unsubscribe$.next();
                unsubscribe$.complete();
            };
        PageHeaderComponent.decorators = [
            { type: i0.Component, args: [{
                        selector: 'page-header',
                        template: "<nz-affix #affix\n          *ngIf=\"fixed;else phTpl\"\n          [nzOffsetTop]=\"fixedOffsetTop\">\n  <ng-template [ngTemplateOutlet]=\"phTpl\"></ng-template>\n</nz-affix>\n<ng-template #phTpl>\n  <div class=\"page-header\">\n    <div [ngClass]=\"{'page-header__wide': wide}\">\n      <nz-skeleton [nzLoading]=\"loading\"\n                   [nzTitle]=\"false\"\n                   [nzActive]=\"true\"\n                   [nzParagraph]=\"{rows: 3}\"\n                   [nzAvatar]=\"{ size: 'large', shape: 'circle' }\">\n        <ng-container *ngIf=\"!breadcrumb; else breadcrumb\">\n          <nz-breadcrumb *ngIf=\"paths && paths.length > 0\">\n            <nz-breadcrumb-item *ngFor=\"let i of paths\">\n              <ng-container *ngIf=\"i.link\">\n                <a [routerLink]=\"i.link\">{{i.title}}</a>\n              </ng-container>\n              <ng-container *ngIf=\"!i.link\">{{i.title}}</ng-container>\n            </nz-breadcrumb-item>\n          </nz-breadcrumb>\n        </ng-container>\n        <div class=\"page-header__detail\">\n          <div *ngIf=\"logo\"\n               class=\"page-header__logo\">\n            <ng-template [ngTemplateOutlet]=\"logo\"></ng-template>\n          </div>\n          <div class=\"page-header__main\">\n            <div class=\"page-header__row\">\n              <h1 *ngIf=\"_titleVal || _titleTpl\"\n                  class=\"page-header__title\">\n                <ng-container *ngIf=\"_titleVal; else _titleTpl\">{{_titleVal}}</ng-container>\n              </h1>\n              <div *ngIf=\"action\"\n                   class=\"page-header__action\">\n                <ng-template [ngTemplateOutlet]=\"action\"></ng-template>\n              </div>\n            </div>\n            <div class=\"page-header__row\">\n              <div class=\"page-header__desc\"\n                   (cdkObserveContent)=\"checkContent()\"\n                   #conTpl>\n                <ng-content></ng-content>\n                <ng-template [ngTemplateOutlet]=\"content\"></ng-template>\n              </div>\n              <div *ngIf=\"extra\"\n                   class=\"page-header__extra\">\n                <ng-template [ngTemplateOutlet]=\"extra\"></ng-template>\n              </div>\n            </div>\n          </div>\n        </div>\n        <ng-template [ngTemplateOutlet]=\"tab\"></ng-template>\n      </nz-skeleton>\n    </div>\n  </div>\n</ng-template>\n",
                        changeDetection: i0.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        PageHeaderComponent.ctorParameters = function () {
            return [
                { type: PageHeaderConfig },
                { type: theme.SettingsService },
                { type: i0.Renderer2 },
                { type: router.Router },
                { type: theme.MenuService },
                { type: undefined, decorators: [{ type: i0.Optional }, { type: i0.Inject, args: [theme.ALAIN_I18N_TOKEN,] }] },
                { type: theme.TitleService, decorators: [{ type: i0.Optional }, { type: i0.Inject, args: [theme.TitleService,] }] },
                { type: reuseTab.ReuseTabService, decorators: [{ type: i0.Optional }, { type: i0.Inject, args: [reuseTab.ReuseTabService,] }] },
                { type: i0.ChangeDetectorRef }
            ];
        };
        PageHeaderComponent.propDecorators = {
            conTpl: [{ type: i0.ViewChild, args: ['conTpl',] }],
            affix: [{ type: i0.ViewChild, args: ['affix',] }],
            title: [{ type: i0.Input }],
            loading: [{ type: i0.Input }],
            wide: [{ type: i0.Input }],
            home: [{ type: i0.Input }],
            homeLink: [{ type: i0.Input }],
            homeI18n: [{ type: i0.Input }],
            autoBreadcrumb: [{ type: i0.Input }],
            autoTitle: [{ type: i0.Input }],
            syncTitle: [{ type: i0.Input }],
            fixed: [{ type: i0.Input }],
            fixedOffsetTop: [{ type: i0.Input }],
            breadcrumb: [{ type: i0.Input }],
            recursiveBreadcrumb: [{ type: i0.Input }],
            logo: [{ type: i0.Input }],
            action: [{ type: i0.Input }],
            content: [{ type: i0.Input }],
            extra: [{ type: i0.Input }],
            tab: [{ type: i0.Input }]
        };
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], PageHeaderComponent.prototype, "loading", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], PageHeaderComponent.prototype, "wide", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], PageHeaderComponent.prototype, "autoBreadcrumb", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], PageHeaderComponent.prototype, "autoTitle", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], PageHeaderComponent.prototype, "syncTitle", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], PageHeaderComponent.prototype, "fixed", void 0);
        __decorate([
            util.InputNumber(),
            __metadata("design:type", Number)
        ], PageHeaderComponent.prototype, "fixedOffsetTop", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Boolean)
        ], PageHeaderComponent.prototype, "recursiveBreadcrumb", void 0);
        return PageHeaderComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [PageHeaderComponent];
    var PageHeaderModule = /** @class */ (function () {
        function PageHeaderModule() {
        }
        PageHeaderModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule, router.RouterModule, util.DelonUtilModule, ngZorroAntd.NgZorroAntdModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return PageHeaderModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.PageHeaderConfig = PageHeaderConfig;
    exports.PageHeaderComponent = PageHeaderComponent;
    exports.PageHeaderModule = PageHeaderModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=pageHeader.umd.js.map