import { Router } from '@angular/router';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { CommonModule } from '@angular/common';
import { Injectable, Directive, ElementRef, Input, Renderer2, defineInjectable, inject, NgModule } from '@angular/core';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * 访问控制服务
 */
class ACLService {
    constructor() {
        this.roles = [];
        this.abilities = [];
        this.full = false;
        this.aclChange = new BehaviorSubject(null);
    }
    /**
     * ACL变更通知
     * @return {?}
     */
    get change() {
        return this.aclChange.asObservable();
    }
    /**
     * 获取所有数据
     * @return {?}
     */
    get data() {
        return {
            full: this.full,
            roles: this.roles,
            abilities: this.abilities,
        };
    }
    /**
     * @private
     * @param {?} val
     * @return {?}
     */
    parseACLType(val) {
        if (typeof val !== 'string' && !Array.isArray(val)) {
            return (/** @type {?} */ (val));
        }
        if (Array.isArray(val)) {
            return (/** @type {?} */ ({ role: (/** @type {?} */ (val)) }));
        }
        return (/** @type {?} */ ({
            role: [val],
        }));
    }
    /**
     * 设置当前用户角色或权限能力（会先清除所有）
     * @param {?} value
     * @return {?}
     */
    set(value) {
        this.abilities = [];
        this.roles = [];
        this.add(value);
        this.aclChange.next(value);
    }
    /**
     * 标识当前用户为全量，即不受限
     * @param {?} val
     * @return {?}
     */
    setFull(val) {
        this.full = val;
        this.aclChange.next(val);
    }
    /**
     * 设置当前用户权限能力（会先清除所有）
     * @param {?} abilities
     * @return {?}
     */
    setAbility(abilities) {
        this.set((/** @type {?} */ ({ ability: abilities })));
    }
    /**
     * 设置当前用户角色（会先清除所有）
     * @param {?} roles
     * @return {?}
     */
    setRole(roles) {
        this.set((/** @type {?} */ ({ role: roles })));
    }
    /**
     * 为当前用户增加角色或权限能力
     * @param {?} value
     * @return {?}
     */
    add(value) {
        if (value.role && value.role.length > 0) {
            this.roles.push(...value.role);
        }
        if (value.ability && value.ability.length > 0) {
            this.abilities.push(...value.ability);
        }
    }
    /**
     * 为当前用户附加角色
     * @param {?} roles
     * @return {?}
     */
    attachRole(roles) {
        for (const val of roles) {
            if (!this.roles.includes(val)) {
                this.roles.push(val);
            }
        }
        this.aclChange.next(this.data);
    }
    /**
     * 为当前用户附加权限
     * @param {?} abilities
     * @return {?}
     */
    attachAbility(abilities) {
        for (const val of abilities) {
            if (!this.abilities.includes(val)) {
                this.abilities.push(val);
            }
        }
        this.aclChange.next(this.data);
    }
    /**
     * 为当前用户移除角色
     * @param {?} roles
     * @return {?}
     */
    removeRole(roles) {
        for (const val of roles) {
            /** @type {?} */
            const idx = this.roles.indexOf(val);
            if (idx !== -1) {
                this.roles.splice(idx, 1);
            }
        }
        this.aclChange.next(this.data);
    }
    /**
     * 为当前用户移除权限
     * @param {?} abilities
     * @return {?}
     */
    removeAbility(abilities) {
        for (const val of abilities) {
            /** @type {?} */
            const idx = this.abilities.indexOf(val);
            if (idx !== -1) {
                this.abilities.splice(idx, 1);
            }
        }
        this.aclChange.next(this.data);
    }
    /**
     * 当前用户是否有对应角色，其实 `number` 表示Ability
     *
     * - 当 `full: true` 或参数 `null` 时返回 `true`
     * - 若使用 `ACLType` 参数，可以指定 `mode` 校验模式
     * @param {?} roleOrAbility
     * @return {?}
     */
    can(roleOrAbility) {
        if (this.full === true || !roleOrAbility) {
            return true;
        }
        /** @type {?} */
        let t = {};
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
                return t.role.every((/**
                 * @param {?} v
                 * @return {?}
                 */
                v => this.roles.includes(v)));
            else
                return t.role.some((/**
                 * @param {?} v
                 * @return {?}
                 */
                v => this.roles.includes(v)));
        }
        if (t.ability) {
            if (t.mode === 'allOf') {
                return ((/** @type {?} */ (t.ability))).every((/**
                 * @param {?} v
                 * @return {?}
                 */
                v => this.abilities.includes(v)));
            }
            else {
                return ((/** @type {?} */ (t.ability))).some((/**
                 * @param {?} v
                 * @return {?}
                 */
                v => this.abilities.includes(v)));
            }
        }
        return false;
    }
    /**
     * \@inner
     * @param {?} value
     * @return {?}
     */
    parseAbility(value) {
        if (typeof value === 'number' || typeof value === 'string' || Array.isArray(value)) {
            value = (/** @type {?} */ ({ ability: Array.isArray(value) ? value : [value] }));
        }
        delete value.role;
        return value;
    }
    /**
     * 当前用户是否有对应权限点
     * @param {?} value
     * @return {?}
     */
    canAbility(value) {
        return this.can(this.parseAbility(value));
    }
}
ACLService.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */ ACLService.ngInjectableDef = defineInjectable({ factory: function ACLService_Factory() { return new ACLService(); }, token: ACLService, providedIn: "root" });

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class ACLDirective {
    /**
     * @param {?} el
     * @param {?} renderer
     * @param {?} srv
     */
    constructor(el, renderer, srv) {
        this.el = el;
        this.renderer = renderer;
        this.srv = srv;
        this.change$ = this.srv.change.subscribe((/**
         * @return {?}
         */
        () => this.set(this._value)));
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set acl(value) {
        this.set(value);
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set ability(value) {
        this.set(this.srv.parseAbility(value));
    }
    /**
     * @private
     * @param {?} value
     * @return {?}
     */
    set(value) {
        /** @type {?} */
        const CLS = 'acl__hide';
        /** @type {?} */
        const el = this.el.nativeElement;
        if (this.srv.can(value)) {
            this.renderer.removeClass(el, CLS);
        }
        else {
            this.renderer.addClass(el, CLS);
        }
        this._value = value;
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this.change$.unsubscribe();
    }
}
ACLDirective.decorators = [
    { type: Directive, args: [{ selector: '[acl]' },] }
];
/** @nocollapse */
ACLDirective.ctorParameters = () => [
    { type: ElementRef },
    { type: Renderer2 },
    { type: ACLService }
];
ACLDirective.propDecorators = {
    acl: [{ type: Input, args: ['acl',] }],
    ability: [{ type: Input, args: ['acl-ability',] }]
};

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class DelonACLConfig {
    constructor() {
        /**
         * 路由守卫失败后跳转，默认：`/403`
         */
        this.guard_url = '/403';
    }
}
DelonACLConfig.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */ DelonACLConfig.ngInjectableDef = defineInjectable({ factory: function DelonACLConfig_Factory() { return new DelonACLConfig(); }, token: DelonACLConfig, providedIn: "root" });

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class ACLGuard {
    /**
     * @param {?} srv
     * @param {?} router
     * @param {?} options
     */
    constructor(srv, router, options) {
        this.srv = srv;
        this.router = router;
        this.options = options;
    }
    /**
     * @private
     * @param {?} guard
     * @return {?}
     */
    process(guard) {
        return (guard && guard instanceof Observable
            ? guard
            : of(typeof guard !== 'undefined' && guard !== null ? ((/** @type {?} */ (guard))) : null)).pipe(map((/**
         * @param {?} v
         * @return {?}
         */
        v => this.srv.can(v))), tap((/**
         * @param {?} v
         * @return {?}
         */
        v => {
            if (v)
                return;
            this.router.navigateByUrl(this.options.guard_url);
        })));
    }
    // lazy loading
    /**
     * @param {?} route
     * @return {?}
     */
    canLoad(route) {
        return this.process((route.data && route.data.guard) || null);
    }
    // all children route
    /**
     * @param {?} childRoute
     * @param {?} state
     * @return {?}
     */
    canActivateChild(childRoute, state) {
        return this.canActivate(childRoute, state);
    }
    // route
    /**
     * @param {?} route
     * @param {?} state
     * @return {?}
     */
    canActivate(route, state) {
        return this.process((route.data && route.data.guard) || null);
    }
}
ACLGuard.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */
ACLGuard.ctorParameters = () => [
    { type: ACLService },
    { type: Router },
    { type: DelonACLConfig }
];
/** @nocollapse */ ACLGuard.ngInjectableDef = defineInjectable({ factory: function ACLGuard_Factory() { return new ACLGuard(inject(ACLService), inject(Router), inject(DelonACLConfig)); }, token: ACLGuard, providedIn: "root" });

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
const COMPONENTS = [ACLDirective];
class DelonACLModule {
}
DelonACLModule.decorators = [
    { type: NgModule, args: [{
                imports: [CommonModule],
                declarations: [...COMPONENTS],
                exports: [...COMPONENTS],
            },] }
];

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

export { ACLService, ACLDirective, DelonACLConfig, ACLGuard, DelonACLModule };

//# sourceMappingURL=acl.js.map