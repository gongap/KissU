/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs'), require('rxjs/operators'), require('@delon/theme'), require('@angular/common'), require('@angular/core'), require('@angular/router'), require('@delon/util'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/sidebar-nav', ['exports', 'rxjs', 'rxjs/operators', '@delon/theme', '@angular/common', '@angular/core', '@angular/router', '@delon/util', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc['sidebar-nav'] = {}),global.rxjs,global.rxjs.operators,global.delon.theme,global.ng.common,global.ng.core,global.ng.router,global.delon.util,global['ng-zorro-antd']));
}(this, (function (exports,rxjs,operators,theme,common,core,router,util,ngZorroAntd) { 'use strict';

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
    /** @type {?} */
    var SHOWCLS = 'sidebar-nav__floating-show';
    /** @type {?} */
    var FLOATINGCLS = 'sidebar-nav__floating';
    var SidebarNavComponent = /** @class */ (function () {
        function SidebarNavComponent(menuSrv, settings, router$$1, render, cdr, ngZone, doc, win) {
            this.menuSrv = menuSrv;
            this.settings = settings;
            this.router = router$$1;
            this.render = render;
            this.cdr = cdr;
            this.ngZone = ngZone;
            this.doc = doc;
            this.win = win;
            this.unsubscribe$ = new rxjs.Subject();
            this.list = [];
            this.disabledAcl = false;
            this.autoCloseUnderPad = true;
            this.recursivePath = true;
            this.openStrictly = false;
            this.select = new core.EventEmitter();
        }
        Object.defineProperty(SidebarNavComponent.prototype, "collapsed", {
            get: /**
             * @return {?}
             */ function () {
                return this.settings.layout.collapsed;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(SidebarNavComponent.prototype, "_d", {
            get: /**
             * @private
             * @return {?}
             */ function () {
                return this.menuSrv.menus;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @private
         * @param {?} e
         * @return {?}
         */
        SidebarNavComponent.prototype.floatingAreaClickHandle = /**
         * @private
         * @param {?} e
         * @return {?}
         */
            function (e) {
                e.stopPropagation();
                /** @type {?} */
                var linkNode = ( /** @type {?} */(e.target));
                if (linkNode.nodeName !== 'A') {
                    return false;
                }
                /** @type {?} */
                var id = +( /** @type {?} */(linkNode.dataset)).id;
                /** @type {?} */
                var item;
                this.menuSrv.visit(this._d, ( /**
                 * @param {?} i
                 * @return {?}
                 */function (i) {
                    if (!item && i.__id === id) {
                        item = i;
                    }
                }));
                this.to(item);
                this.hideAll();
                e.preventDefault();
                return false;
            };
        /**
         * @private
         * @return {?}
         */
        SidebarNavComponent.prototype.clearFloatingContainer = /**
         * @private
         * @return {?}
         */
            function () {
                if (!this.floatingEl)
                    return;
                this.floatingEl.removeEventListener('click', this.floatingAreaClickHandle.bind(this));
                // fix ie: https://github.com/ng-alain/delon/issues/52
                if (this.floatingEl.hasOwnProperty('remove')) {
                    this.floatingEl.remove();
                }
                else if (this.floatingEl.parentNode) {
                    this.floatingEl.parentNode.removeChild(this.floatingEl);
                }
            };
        /**
         * @private
         * @return {?}
         */
        SidebarNavComponent.prototype.genFloatingContainer = /**
         * @private
         * @return {?}
         */
            function () {
                this.clearFloatingContainer();
                this.floatingEl = this.render.createElement('div');
                this.floatingEl.classList.add(FLOATINGCLS + '-container');
                this.floatingEl.addEventListener('click', this.floatingAreaClickHandle.bind(this), false);
                this.bodyEl.appendChild(this.floatingEl);
            };
        /**
         * @private
         * @param {?} linkNode
         * @param {?} item
         * @return {?}
         */
        SidebarNavComponent.prototype.genSubNode = /**
         * @private
         * @param {?} linkNode
         * @param {?} item
         * @return {?}
         */
            function (linkNode, item) {
                /** @type {?} */
                var id = "_sidebar-nav-" + item.__id;
                /** @type {?} */
                var node = ( /** @type {?} */(linkNode.nextElementSibling.cloneNode(true)));
                node.id = id;
                node.classList.add(FLOATINGCLS);
                node.addEventListener('mouseleave', ( /**
                 * @return {?}
                 */function () {
                    node.classList.remove(SHOWCLS);
                }), false);
                this.floatingEl.appendChild(node);
                return node;
            };
        /**
         * @private
         * @return {?}
         */
        SidebarNavComponent.prototype.hideAll = /**
         * @private
         * @return {?}
         */
            function () {
                /** @type {?} */
                var allNode = this.floatingEl.querySelectorAll('.' + FLOATINGCLS);
                // tslint:disable-next-line:prefer-for-of
                for (var i = 0; i < allNode.length; i++) {
                    allNode[i].classList.remove(SHOWCLS);
                }
            };
        // calculate the node position values.
        // calculate the node position values.
        /**
         * @private
         * @param {?} linkNode
         * @param {?} node
         * @return {?}
         */
        SidebarNavComponent.prototype.calPos =
            // calculate the node position values.
            /**
             * @private
             * @param {?} linkNode
             * @param {?} node
             * @return {?}
             */
            function (linkNode, node) {
                /** @type {?} */
                var rect = linkNode.getBoundingClientRect();
                // bug: https://developer.microsoft.com/en-us/microsoft-edge/platform/issues/14721015/
                /** @type {?} */
                var scrollTop = Math.max(this.doc.documentElement.scrollTop, this.bodyEl.scrollTop);
                /** @type {?} */
                var docHeight = Math.max(this.doc.documentElement.clientHeight, this.bodyEl.clientHeight);
                /** @type {?} */
                var offsetHeight = 0;
                if (docHeight < rect.top + node.clientHeight) {
                    offsetHeight = rect.top + node.clientHeight - docHeight;
                }
                node.style.top = rect.top + scrollTop - offsetHeight + "px";
                node.style.left = rect.right + 5 + "px";
            };
        /**
         * @param {?} e
         * @param {?} item
         * @return {?}
         */
        SidebarNavComponent.prototype.showSubMenu = /**
         * @param {?} e
         * @param {?} item
         * @return {?}
         */
            function (e, item) {
                var _this = this;
                if (this.collapsed !== true) {
                    return;
                }
                this.ngZone.runOutsideAngular(( /**
                 * @return {?}
                 */function () {
                    e.preventDefault();
                    /** @type {?} */
                    var linkNode = ( /** @type {?} */(e.target));
                    _this.genFloatingContainer();
                    /** @type {?} */
                    var subNode = _this.genSubNode(( /** @type {?} */(linkNode)), item);
                    _this.hideAll();
                    subNode.classList.add(SHOWCLS);
                    _this.calPos(( /** @type {?} */(linkNode)), subNode);
                }));
            };
        /**
         * @param {?} item
         * @return {?}
         */
        SidebarNavComponent.prototype.to = /**
         * @param {?} item
         * @return {?}
         */
            function (item) {
                var _this = this;
                this.select.emit(item);
                if (item.disabled)
                    return;
                if (item.externalLink) {
                    if (item.target === '_blank') {
                        this.win.open(item.externalLink);
                    }
                    else {
                        this.win.location.href = item.externalLink;
                    }
                    return false;
                }
                this.ngZone.run(( /**
                 * @return {?}
                 */function () { return _this.router.navigateByUrl(item.link); }));
            };
        /**
         * @param {?} item
         * @return {?}
         */
        SidebarNavComponent.prototype.toggleOpen = /**
         * @param {?} item
         * @return {?}
         */
            function (item) {
                if (!this.openStrictly) {
                    this.menuSrv.visit(this._d, ( /**
                     * @param {?} i
                     * @param {?} p
                     * @return {?}
                     */function (i, p) {
                        if (i !== item)
                            i._open = false;
                    }));
                    /** @type {?} */
                    var pItem = item.__parent;
                    while (pItem) {
                        pItem._open = true;
                        pItem = pItem.__parent;
                    }
                }
                item._open = !item._open;
                this.cdr.markForCheck();
            };
        /**
         * @return {?}
         */
        SidebarNavComponent.prototype._click = /**
         * @return {?}
         */
            function () {
                if (this.isPad && this.collapsed) {
                    this.openAside(false);
                    this.hideAll();
                }
            };
        /**
         * @return {?}
         */
        SidebarNavComponent.prototype._docClick = /**
         * @return {?}
         */
            function () {
                this.hideAll();
            };
        /**
         * @return {?}
         */
        SidebarNavComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                var _a = this, doc = _a.doc, router$$1 = _a.router, unsubscribe$ = _a.unsubscribe$, menuSrv = _a.menuSrv, cdr = _a.cdr;
                this.bodyEl = doc.querySelector('body');
                menuSrv.openedByUrl(router$$1.url, this.recursivePath);
                this.ngZone.runOutsideAngular(( /**
                 * @return {?}
                 */function () { return _this.genFloatingContainer(); }));
                menuSrv.change.pipe(operators.takeUntil(unsubscribe$)).subscribe(( /**
                 * @param {?} data
                 * @return {?}
                 */function (data) {
                    menuSrv.visit(data, ( /**
                     * @param {?} i
                     * @return {?}
                     */function (i) {
                        if (!i._aclResult) {
                            if (_this.disabledAcl) {
                                i.disabled = true;
                            }
                            else {
                                i._hidden = true;
                            }
                        }
                        if (_this.openStrictly) {
                            i._open = i.open != null ? i.open : false;
                        }
                    }));
                    _this.list = menuSrv.menus;
                    cdr.detectChanges();
                }));
                router$$1.events
                    .pipe(operators.takeUntil(unsubscribe$), operators.filter(( /**
             * @param {?} e
             * @return {?}
             */function (e) { return e instanceof router.NavigationEnd; })))
                    .subscribe(( /**
             * @param {?} e
             * @return {?}
             */function (e) {
                    _this.menuSrv.openedByUrl(e.urlAfterRedirects, _this.recursivePath);
                    _this.underPad();
                    _this.cdr.detectChanges();
                }));
                this.underPad();
            };
        /**
         * @return {?}
         */
        SidebarNavComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                var unsubscribe$ = this.unsubscribe$;
                unsubscribe$.next();
                unsubscribe$.complete();
                this.clearFloatingContainer();
            };
        Object.defineProperty(SidebarNavComponent.prototype, "isPad", {
            // #region Under pad
            get: 
            // #region Under pad
            /**
             * @private
             * @return {?}
             */
            function () {
                return window.innerWidth < 768;
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @private
         * @return {?}
         */
        SidebarNavComponent.prototype.underPad = /**
         * @private
         * @return {?}
         */
            function () {
                var _this = this;
                if (this.autoCloseUnderPad && this.isPad && !this.collapsed) {
                    setTimeout(( /**
                     * @return {?}
                     */function () { return _this.openAside(true); }));
                }
            };
        /**
         * @private
         * @param {?} status
         * @return {?}
         */
        SidebarNavComponent.prototype.openAside = /**
         * @private
         * @param {?} status
         * @return {?}
         */
            function (status) {
                this.settings.setLayout('collapsed', status);
            };
        SidebarNavComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'sidebar-nav',
                        template: "<ng-template #icon\n             let-i>\n  <ng-container *ngIf=\"i\"\n                [ngSwitch]=\"i.type\">\n    <i *ngSwitchCase=\"'icon'\"\n       class=\"sidebar-nav__item-icon\"\n       nz-icon\n       [type]=\"i.value\"\n       [theme]=\"i.theme\"\n       [spin]=\"i.spin\"\n       [twoToneColor]=\"i.twoToneColor\"\n       [iconfont]=\"i.iconfont\"></i>\n    <img *ngSwitchCase=\"'img'\"\n         src=\"{{ i.value }}\"\n         class=\"sidebar-nav__item-icon sidebar-nav__item-img\">\n    <i *ngSwitchDefault\n       class=\"sidebar-nav__item-icon {{ i.value }}\"></i>\n  </ng-container>\n</ng-template>\n<ul class=\"sidebar-nav\">\n  <ng-container *ngFor=\"let group of list\">\n    <ng-container *ngIf=\"group._hidden !== true\">\n      <li class=\"sidebar-nav__item sidebar-nav__group-title\"\n          *ngIf=\"group.group\">\n        <span>{{ group.text }}</span>\n      </li>\n      <ng-container *ngFor=\"let child1 of group.children\">\n        <li *ngIf=\"child1._hidden !== true\"\n            class=\"sidebar-nav__item\"\n            [class.sidebar-nav__selected]=\"child1._selected\"\n            [class.sidebar-nav__open]=\"child1._open\">\n          <!-- link -->\n          <a *ngIf=\"child1._type <= 2\"\n             (click)=\"to(child1)\"\n             [attr.data-id]=\"child1.__id\"\n             class=\"sidebar-nav__item-link\"\n             [ngClass]=\"{'sidebar-nav__item-disabled': child1.disabled}\">\n            <ng-container *ngIf=\"!collapsed\">\n              <ng-template [ngTemplateOutlet]=\"icon\"\n                           [ngTemplateOutletContext]=\"{$implicit: child1.icon}\"></ng-template>\n            </ng-container>\n            <nz-tooltip *ngIf=\"collapsed\"\n                        nzPlacement=\"right\"\n                        [nzTitle]=\"child1.text\">\n              <span nz-tooltip>\n                <ng-template [ngTemplateOutlet]=\"icon\"\n                             [ngTemplateOutletContext]=\"{$implicit: child1.icon}\"></ng-template>\n              </span>\n            </nz-tooltip>\n            <span class=\"sidebar-nav__item-text\">{{ child1.text }}</span>\n          </a>\n          <!-- has children link -->\n          <a *ngIf=\"child1._type === 3\"\n             (click)=\"toggleOpen(child1)\"\n             (mouseenter)=\"showSubMenu($event, child1)\"\n             class=\"sidebar-nav__item-link\">\n            <ng-template [ngTemplateOutlet]=\"icon\"\n                         [ngTemplateOutletContext]=\"{$implicit: child1.icon}\"></ng-template>\n            <span class=\"sidebar-nav__item-text\">{{ child1.text }}</span>\n            <i class=\"sidebar-nav__sub-arrow\"></i>\n          </a>\n          <!-- badge -->\n          <div *ngIf=\"child1.badge\"\n               title=\"{{child1.badge}}\"\n               class=\"badge badge-{{child1.badgeStatus}}\"\n               [class.badge-dot]=\"child1.badgeDot\">\n            <em>{{child1.badge}}</em>\n          </div>\n          <!-- Level 2 -->\n          <ul *ngIf=\"child1._type === 3\"\n              class=\"sidebar-nav sidebar-nav__sub sidebar-nav__depth{{child1._depth}}\">\n            <ng-container *ngFor=\"let child2 of child1.children\">\n              <li *ngIf=\"child2._hidden !== true\"\n                  class=\"sidebar-nav__item\"\n                  [class.sidebar-nav__selected]=\"child2._selected\"\n                  [class.sidebar-nav__open]=\"child2._open\">\n                <!-- link -->\n                <a *ngIf=\"child2._type <= 2\"\n                   (click)=\"to(child2)\"\n                   [attr.data-id]=\"child2.__id\"\n                   class=\"sidebar-nav__item-link\"\n                   [ngClass]=\"{'sidebar-nav__item-disabled': child2.disabled}\">{{\n                  child2.text }}</a>\n                <!-- has children link -->\n                <a *ngIf=\"child2._type === 3\"\n                   (click)=\"toggleOpen(child2)\"\n                   class=\"sidebar-nav__item-link\">\n                  {{ child2.text }}\n                  <i class=\"sidebar-nav__sub-arrow\"></i>\n                </a>\n                <!-- badge -->\n                <div *ngIf=\"child2.badge\"\n                     title=\"{{child2.badge}}\"\n                     class=\"badge badge-{{child2.badgeStatus}}\"\n                     [class.badge-dot]=\"child2.badgeDot\">\n                  <em>{{child2.badge}}</em>\n                </div>\n                <!-- Level 3 -->\n                <ul *ngIf=\"child2._type === 3\"\n                    class=\"sidebar-nav sidebar-nav__sub sidebar-nav__depth{{child2._depth}}\">\n                  <ng-container *ngFor=\"let child3 of child2.children\">\n                    <li *ngIf=\"child3._hidden !== true\"\n                        class=\"sidebar-nav__item\"\n                        [class.sidebar-nav__selected]=\"child3._selected\"\n                        [class.sidebar-nav__open]=\"child3._open\">\n                      <!-- link -->\n                      <a *ngIf=\"child3._type <= 2\"\n                         (click)=\"to(child3)\"\n                         [attr.data-id]=\"child3.__id\"\n                         class=\"sidebar-nav__item-link\"\n                         [ngClass]=\"{'sidebar-nav__item-disabled': child3.disabled}\">{{ child3.text }}</a>\n                      <!-- external link -->\n                      <a *ngIf=\"child3._type === 2\"\n                         href=\"{{ child3.externalLink }}\"\n                         target=\"{{ child3.target }}\"\n                         data-type=\"external\"\n                         class=\"sidebar-nav__item-link\">{{ child3.text }}</a>\n                      <!-- badge -->\n                      <div *ngIf=\"child3.badge\"\n                           title=\"{{child3.badge}}\"\n                           class=\"badge badge-{{child3.badgeStatus}}\"\n                           [class.badge-dot]=\"child3.badgeDot\">\n                        <em>{{child3.badge}}</em>\n                      </div>\n                    </li>\n                  </ng-container>\n                </ul>\n              </li>\n            </ng-container>\n          </ul>\n        </li>\n      </ng-container>\n    </ng-container>\n  </ng-container>\n</ul>\n",
                        host: {
                            '(click)': '_click()',
                            '(document:click)': '_docClick()',
                        },
                        changeDetection: core.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        SidebarNavComponent.ctorParameters = function () {
            return [
                { type: theme.MenuService },
                { type: theme.SettingsService },
                { type: router.Router },
                { type: core.Renderer2 },
                { type: core.ChangeDetectorRef },
                { type: core.NgZone },
                { type: undefined, decorators: [{ type: core.Inject, args: [common.DOCUMENT,] }] },
                { type: Window, decorators: [{ type: core.Inject, args: [theme.WINDOW,] }] }
            ];
        };
        SidebarNavComponent.propDecorators = {
            disabledAcl: [{ type: core.Input }],
            autoCloseUnderPad: [{ type: core.Input }],
            recursivePath: [{ type: core.Input }],
            openStrictly: [{ type: core.Input }],
            select: [{ type: core.Output }]
        };
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], SidebarNavComponent.prototype, "disabledAcl", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], SidebarNavComponent.prototype, "autoCloseUnderPad", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], SidebarNavComponent.prototype, "recursivePath", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], SidebarNavComponent.prototype, "openStrictly", void 0);
        return SidebarNavComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var SidebarNavModule = /** @class */ (function () {
        function SidebarNavModule() {
        }
        SidebarNavModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, router.RouterModule, ngZorroAntd.NgZorroAntdModule, util.DelonUtilModule],
                        declarations: [SidebarNavComponent],
                        exports: [SidebarNavComponent],
                    },] }
        ];
        return SidebarNavModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.SidebarNavComponent = SidebarNavComponent;
    exports.SidebarNavModule = SidebarNavModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=sidebarNav.umd.js.map