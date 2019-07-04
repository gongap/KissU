/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/router'), require('rxjs'), require('rxjs/operators'), require('@angular/common'), require('@angular/core')) :
    typeof define === 'function' && define.amd ? define('@delon/acl', ['exports', '@angular/router', 'rxjs', 'rxjs/operators', '@angular/common', '@angular/core'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.acl = {}),global.ng.router,global.rxjs,global.rxjs.operators,global.ng.common,global.ng.core));
}(this, (function (exports,i2,rxjs,operators,common,i0) { 'use strict';

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
    function __values(o) {
        var m = typeof Symbol === "function" && o[Symbol.iterator], i = 0;
        if (m)
            return m.call(o);
        return {
            next: function () {
                if (o && i >= o.length)
                    o = void 0;
                return { value: o && o[i++], done: !o };
            }
        };
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
    /**
     * 访问控制服务
     */
    var ACLService = /** @class */ (function () {
        function ACLService() {
            this.roles = [];
            this.abilities = [];
            this.full = false;
            this.aclChange = new rxjs.BehaviorSubject(null);
        }
        Object.defineProperty(ACLService.prototype, "change", {
            /** ACL变更通知 */
            get: /**
             * ACL变更通知
             * @return {?}
             */ function () {
                return this.aclChange.asObservable();
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(ACLService.prototype, "data", {
            /** 获取所有数据 */
            get: /**
             * 获取所有数据
             * @return {?}
             */ function () {
                return {
                    full: this.full,
                    roles: this.roles,
                    abilities: this.abilities,
                };
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @private
         * @param {?} val
         * @return {?}
         */
        ACLService.prototype.parseACLType = /**
         * @private
         * @param {?} val
         * @return {?}
         */
            function (val) {
                if (typeof val !== 'string' && !Array.isArray(val)) {
                    return ( /** @type {?} */(val));
                }
                if (Array.isArray(val)) {
                    return ( /** @type {?} */({ role: ( /** @type {?} */(val)) }));
                }
                return ( /** @type {?} */({
                    role: [val],
                }));
            };
        /**
         * 设置当前用户角色或权限能力（会先清除所有）
         */
        /**
         * 设置当前用户角色或权限能力（会先清除所有）
         * @param {?} value
         * @return {?}
         */
        ACLService.prototype.set = /**
         * 设置当前用户角色或权限能力（会先清除所有）
         * @param {?} value
         * @return {?}
         */
            function (value) {
                this.abilities = [];
                this.roles = [];
                this.add(value);
                this.aclChange.next(value);
            };
        /**
         * 标识当前用户为全量，即不受限
         */
        /**
         * 标识当前用户为全量，即不受限
         * @param {?} val
         * @return {?}
         */
        ACLService.prototype.setFull = /**
         * 标识当前用户为全量，即不受限
         * @param {?} val
         * @return {?}
         */
            function (val) {
                this.full = val;
                this.aclChange.next(val);
            };
        /**
         * 设置当前用户权限能力（会先清除所有）
         */
        /**
         * 设置当前用户权限能力（会先清除所有）
         * @param {?} abilities
         * @return {?}
         */
        ACLService.prototype.setAbility = /**
         * 设置当前用户权限能力（会先清除所有）
         * @param {?} abilities
         * @return {?}
         */
            function (abilities) {
                this.set(( /** @type {?} */({ ability: abilities })));
            };
        /**
         * 设置当前用户角色（会先清除所有）
         */
        /**
         * 设置当前用户角色（会先清除所有）
         * @param {?} roles
         * @return {?}
         */
        ACLService.prototype.setRole = /**
         * 设置当前用户角色（会先清除所有）
         * @param {?} roles
         * @return {?}
         */
            function (roles) {
                this.set(( /** @type {?} */({ role: roles })));
            };
        /**
         * 为当前用户增加角色或权限能力
         */
        /**
         * 为当前用户增加角色或权限能力
         * @param {?} value
         * @return {?}
         */
        ACLService.prototype.add = /**
         * 为当前用户增加角色或权限能力
         * @param {?} value
         * @return {?}
         */
            function (value) {
                var _a, _b;
                if (value.role && value.role.length > 0) {
                    (_a = this.roles).push.apply(_a, __spread(value.role));
                }
                if (value.ability && value.ability.length > 0) {
                    (_b = this.abilities).push.apply(_b, __spread(value.ability));
                }
            };
        /**
         * 为当前用户附加角色
         */
        /**
         * 为当前用户附加角色
         * @param {?} roles
         * @return {?}
         */
        ACLService.prototype.attachRole = /**
         * 为当前用户附加角色
         * @param {?} roles
         * @return {?}
         */
            function (roles) {
                var e_1, _a;
                try {
                    for (var roles_1 = __values(roles), roles_1_1 = roles_1.next(); !roles_1_1.done; roles_1_1 = roles_1.next()) {
                        var val = roles_1_1.value;
                        if (!this.roles.includes(val)) {
                            this.roles.push(val);
                        }
                    }
                }
                catch (e_1_1) {
                    e_1 = { error: e_1_1 };
                }
                finally {
                    try {
                        if (roles_1_1 && !roles_1_1.done && (_a = roles_1.return))
                            _a.call(roles_1);
                    }
                    finally {
                        if (e_1)
                            throw e_1.error;
                    }
                }
                this.aclChange.next(this.data);
            };
        /**
         * 为当前用户附加权限
         */
        /**
         * 为当前用户附加权限
         * @param {?} abilities
         * @return {?}
         */
        ACLService.prototype.attachAbility = /**
         * 为当前用户附加权限
         * @param {?} abilities
         * @return {?}
         */
            function (abilities) {
                var e_2, _a;
                try {
                    for (var abilities_1 = __values(abilities), abilities_1_1 = abilities_1.next(); !abilities_1_1.done; abilities_1_1 = abilities_1.next()) {
                        var val = abilities_1_1.value;
                        if (!this.abilities.includes(val)) {
                            this.abilities.push(val);
                        }
                    }
                }
                catch (e_2_1) {
                    e_2 = { error: e_2_1 };
                }
                finally {
                    try {
                        if (abilities_1_1 && !abilities_1_1.done && (_a = abilities_1.return))
                            _a.call(abilities_1);
                    }
                    finally {
                        if (e_2)
                            throw e_2.error;
                    }
                }
                this.aclChange.next(this.data);
            };
        /**
         * 为当前用户移除角色
         */
        /**
         * 为当前用户移除角色
         * @param {?} roles
         * @return {?}
         */
        ACLService.prototype.removeRole = /**
         * 为当前用户移除角色
         * @param {?} roles
         * @return {?}
         */
            function (roles) {
                var e_3, _a;
                try {
                    for (var roles_2 = __values(roles), roles_2_1 = roles_2.next(); !roles_2_1.done; roles_2_1 = roles_2.next()) {
                        var val = roles_2_1.value;
                        /** @type {?} */
                        var idx = this.roles.indexOf(val);
                        if (idx !== -1) {
                            this.roles.splice(idx, 1);
                        }
                    }
                }
                catch (e_3_1) {
                    e_3 = { error: e_3_1 };
                }
                finally {
                    try {
                        if (roles_2_1 && !roles_2_1.done && (_a = roles_2.return))
                            _a.call(roles_2);
                    }
                    finally {
                        if (e_3)
                            throw e_3.error;
                    }
                }
                this.aclChange.next(this.data);
            };
        /**
         * 为当前用户移除权限
         */
        /**
         * 为当前用户移除权限
         * @param {?} abilities
         * @return {?}
         */
        ACLService.prototype.removeAbility = /**
         * 为当前用户移除权限
         * @param {?} abilities
         * @return {?}
         */
            function (abilities) {
                var e_4, _a;
                try {
                    for (var abilities_2 = __values(abilities), abilities_2_1 = abilities_2.next(); !abilities_2_1.done; abilities_2_1 = abilities_2.next()) {
                        var val = abilities_2_1.value;
                        /** @type {?} */
                        var idx = this.abilities.indexOf(val);
                        if (idx !== -1) {
                            this.abilities.splice(idx, 1);
                        }
                    }
                }
                catch (e_4_1) {
                    e_4 = { error: e_4_1 };
                }
                finally {
                    try {
                        if (abilities_2_1 && !abilities_2_1.done && (_a = abilities_2.return))
                            _a.call(abilities_2);
                    }
                    finally {
                        if (e_4)
                            throw e_4.error;
                    }
                }
                this.aclChange.next(this.data);
            };
        /**
         * 当前用户是否有对应角色，其实 `number` 表示Ability
         *
         * - 当 `full: true` 或参数 `null` 时返回 `true`
         * - 若使用 `ACLType` 参数，可以指定 `mode` 校验模式
         */
        /**
         * 当前用户是否有对应角色，其实 `number` 表示Ability
         *
         * - 当 `full: true` 或参数 `null` 时返回 `true`
         * - 若使用 `ACLType` 参数，可以指定 `mode` 校验模式
         * @param {?} roleOrAbility
         * @return {?}
         */
        ACLService.prototype.can = /**
         * 当前用户是否有对应角色，其实 `number` 表示Ability
         *
         * - 当 `full: true` 或参数 `null` 时返回 `true`
         * - 若使用 `ACLType` 参数，可以指定 `mode` 校验模式
         * @param {?} roleOrAbility
         * @return {?}
         */
            function (roleOrAbility) {
                var _this = this;
                if (this.full === true || !roleOrAbility) {
                    return true;
                }
                /** @type {?} */
                var t = {};
                if (typeof roleOrAbility === 'number') {
                    t = { ability: [roleOrAbility] };
                }
                else if (Array.isArray(roleOrAbility) &&
                    roleOrAbility.length > 0 &&
                    typeof roleOrAbility[0] === 'number') {
                    t = { ability: roleOrAbility };
                }
                else {
                    t = this.parseACLType(roleOrAbility);
                }
                if (t.role) {
                    if (t.mode === 'allOf')
                        return t.role.every(( /**
                         * @param {?} v
                         * @return {?}
                         */function (v) { return _this.roles.includes(v); }));
                    else
                        return t.role.some(( /**
                         * @param {?} v
                         * @return {?}
                         */function (v) { return _this.roles.includes(v); }));
                }
                if (t.ability) {
                    if (t.mode === 'allOf') {
                        return (( /** @type {?} */(t.ability))).every(( /**
                         * @param {?} v
                         * @return {?}
                         */function (v) { return _this.abilities.includes(v); }));
                    }
                    else {
                        return (( /** @type {?} */(t.ability))).some(( /**
                         * @param {?} v
                         * @return {?}
                         */function (v) { return _this.abilities.includes(v); }));
                    }
                }
                return false;
            };
        /** @inner */
        /**
         * \@inner
         * @param {?} value
         * @return {?}
         */
        ACLService.prototype.parseAbility = /**
         * \@inner
         * @param {?} value
         * @return {?}
         */
            function (value) {
                if (typeof value === 'number' || typeof value === 'string' || Array.isArray(value)) {
                    value = ( /** @type {?} */({ ability: Array.isArray(value) ? value : [value] }));
                }
                delete value.role;
                return value;
            };
        /**
         * 当前用户是否有对应权限点
         */
        /**
         * 当前用户是否有对应权限点
         * @param {?} value
         * @return {?}
         */
        ACLService.prototype.canAbility = /**
         * 当前用户是否有对应权限点
         * @param {?} value
         * @return {?}
         */
            function (value) {
                return this.can(this.parseAbility(value));
            };
        ACLService.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ ACLService.ngInjectableDef = i0.defineInjectable({ factory: function ACLService_Factory() { return new ACLService(); }, token: ACLService, providedIn: "root" });
        return ACLService;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ACLDirective = /** @class */ (function () {
        function ACLDirective(el, renderer, srv) {
            var _this = this;
            this.el = el;
            this.renderer = renderer;
            this.srv = srv;
            this.change$ = this.srv.change.subscribe(( /**
             * @return {?}
             */function () { return _this.set(_this._value); }));
        }
        Object.defineProperty(ACLDirective.prototype, "acl", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this.set(value);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(ACLDirective.prototype, "ability", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this.set(this.srv.parseAbility(value));
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @private
         * @param {?} value
         * @return {?}
         */
        ACLDirective.prototype.set = /**
         * @private
         * @param {?} value
         * @return {?}
         */
            function (value) {
                /** @type {?} */
                var CLS = 'acl__hide';
                /** @type {?} */
                var el = this.el.nativeElement;
                if (this.srv.can(value)) {
                    this.renderer.removeClass(el, CLS);
                }
                else {
                    this.renderer.addClass(el, CLS);
                }
                this._value = value;
            };
        /**
         * @return {?}
         */
        ACLDirective.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.change$.unsubscribe();
            };
        ACLDirective.decorators = [
            { type: i0.Directive, args: [{ selector: '[acl]' },] }
        ];
        /** @nocollapse */
        ACLDirective.ctorParameters = function () {
            return [
                { type: i0.ElementRef },
                { type: i0.Renderer2 },
                { type: ACLService }
            ];
        };
        ACLDirective.propDecorators = {
            acl: [{ type: i0.Input, args: ['acl',] }],
            ability: [{ type: i0.Input, args: ['acl-ability',] }]
        };
        return ACLDirective;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var DelonACLConfig = /** @class */ (function () {
        function DelonACLConfig() {
            /**
             * 路由守卫失败后跳转，默认：`/403`
             */
            this.guard_url = '/403';
        }
        DelonACLConfig.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */ DelonACLConfig.ngInjectableDef = i0.defineInjectable({ factory: function DelonACLConfig_Factory() { return new DelonACLConfig(); }, token: DelonACLConfig, providedIn: "root" });
        return DelonACLConfig;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var ACLGuard = /** @class */ (function () {
        function ACLGuard(srv, router, options) {
            this.srv = srv;
            this.router = router;
            this.options = options;
        }
        /**
         * @private
         * @param {?} guard
         * @return {?}
         */
        ACLGuard.prototype.process = /**
         * @private
         * @param {?} guard
         * @return {?}
         */
            function (guard) {
                var _this = this;
                return (guard && guard instanceof rxjs.Observable
                    ? guard
                    : rxjs.of(typeof guard !== 'undefined' && guard !== null ? (( /** @type {?} */(guard))) : null)).pipe(operators.map(( /**
             * @param {?} v
             * @return {?}
             */function (v) { return _this.srv.can(v); })), operators.tap(( /**
                 * @param {?} v
                 * @return {?}
                 */function (v) {
                    if (v)
                        return;
                    _this.router.navigateByUrl(_this.options.guard_url);
                })));
            };
        // lazy loading
        // lazy loading
        /**
         * @param {?} route
         * @return {?}
         */
        ACLGuard.prototype.canLoad =
            // lazy loading
            /**
             * @param {?} route
             * @return {?}
             */
            function (route) {
                return this.process((route.data && route.data.guard) || null);
            };
        // all children route
        // all children route
        /**
         * @param {?} childRoute
         * @param {?} state
         * @return {?}
         */
        ACLGuard.prototype.canActivateChild =
            // all children route
            /**
             * @param {?} childRoute
             * @param {?} state
             * @return {?}
             */
            function (childRoute, state) {
                return this.canActivate(childRoute, state);
            };
        // route
        // route
        /**
         * @param {?} route
         * @param {?} state
         * @return {?}
         */
        ACLGuard.prototype.canActivate =
            // route
            /**
             * @param {?} route
             * @param {?} state
             * @return {?}
             */
            function (route, state) {
                return this.process((route.data && route.data.guard) || null);
            };
        ACLGuard.decorators = [
            { type: i0.Injectable, args: [{ providedIn: 'root' },] }
        ];
        /** @nocollapse */
        ACLGuard.ctorParameters = function () {
            return [
                { type: ACLService },
                { type: i2.Router },
                { type: DelonACLConfig }
            ];
        };
        /** @nocollapse */ ACLGuard.ngInjectableDef = i0.defineInjectable({ factory: function ACLGuard_Factory() { return new ACLGuard(i0.inject(ACLService), i0.inject(i2.Router), i0.inject(DelonACLConfig)); }, token: ACLGuard, providedIn: "root" });
        return ACLGuard;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [ACLDirective];
    var DelonACLModule = /** @class */ (function () {
        function DelonACLModule() {
        }
        DelonACLModule.decorators = [
            { type: i0.NgModule, args: [{
                        imports: [common.CommonModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return DelonACLModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.ACLService = ACLService;
    exports.ACLDirective = ACLDirective;
    exports.DelonACLConfig = DelonACLConfig;
    exports.ACLGuard = ACLGuard;
    exports.DelonACLModule = DelonACLModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=acl.umd.js.map