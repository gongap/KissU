/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import * as i0 from "@angular/core";
/** @type {?} */
export var LAYOUT = 'layout';
/** @type {?} */
export var USER = 'user';
/** @type {?} */
export var APP = 'app';
var SettingsService = /** @class */ (function () {
    function SettingsService() {
        this.notify$ = new Subject();
        this._app = null;
        this._user = null;
        this._layout = null;
    }
    /**
     * @private
     * @param {?} key
     * @return {?}
     */
    SettingsService.prototype.get = /**
     * @private
     * @param {?} key
     * @return {?}
     */
    function (key) {
        return JSON.parse(localStorage.getItem(key) || 'null') || null;
    };
    /**
     * @private
     * @param {?} key
     * @param {?} value
     * @return {?}
     */
    SettingsService.prototype.set = /**
     * @private
     * @param {?} key
     * @param {?} value
     * @return {?}
     */
    function (key, value) {
        localStorage.setItem(key, JSON.stringify(value));
    };
    Object.defineProperty(SettingsService.prototype, "layout", {
        get: /**
         * @return {?}
         */
        function () {
            if (!this._layout) {
                this._layout = tslib_1.__assign({ fixed: true, collapsed: false, boxed: false, lang: null }, this.get(LAYOUT));
                this.set(LAYOUT, this._layout);
            }
            return this._layout;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SettingsService.prototype, "app", {
        get: /**
         * @return {?}
         */
        function () {
            if (!this._app) {
                this._app = tslib_1.__assign({ year: new Date().getFullYear() }, this.get(APP));
                this.set(APP, this._app);
            }
            return this._app;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SettingsService.prototype, "user", {
        get: /**
         * @return {?}
         */
        function () {
            if (!this._user) {
                this._user = tslib_1.__assign({}, this.get(USER));
                this.set(USER, this._user);
            }
            return this._user;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SettingsService.prototype, "notify", {
        get: /**
         * @return {?}
         */
        function () {
            return this.notify$.asObservable();
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @param {?} name
     * @param {?=} value
     * @return {?}
     */
    SettingsService.prototype.setLayout = /**
     * @param {?} name
     * @param {?=} value
     * @return {?}
     */
    function (name, value) {
        if (typeof name === 'string') {
            this.layout[name] = value;
        }
        else {
            this._layout = name;
        }
        this.set(LAYOUT, this._layout);
        this.notify$.next((/** @type {?} */ ({ type: 'layout', name: name, value: value })));
        return true;
    };
    /**
     * @param {?} value
     * @return {?}
     */
    SettingsService.prototype.setApp = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        this._app = value;
        this.set(APP, value);
        this.notify$.next({ type: 'app', value: value });
        return true;
    };
    /**
     * @param {?} value
     * @return {?}
     */
    SettingsService.prototype.setUser = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        this._user = value;
        this.set(USER, value);
        this.notify$.next({ type: 'user', value: value });
        return true;
    };
    SettingsService.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */ SettingsService.ngInjectableDef = i0.defineInjectable({ factory: function SettingsService_Factory() { return new SettingsService(); }, token: SettingsService, providedIn: "root" });
    return SettingsService;
}());
export { SettingsService };
if (false) {
    /**
     * @type {?}
     * @private
     */
    SettingsService.prototype.notify$;
    /**
     * @type {?}
     * @private
     */
    SettingsService.prototype._app;
    /**
     * @type {?}
     * @private
     */
    SettingsService.prototype._user;
    /**
     * @type {?}
     * @private
     */
    SettingsService.prototype._layout;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoic2V0dGluZ3Muc2VydmljZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi90aGVtZS8iLCJzb3VyY2VzIjpbInNyYy9zZXJ2aWNlcy9zZXR0aW5ncy9zZXR0aW5ncy5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7O0FBQUEsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLGVBQWUsQ0FBQztBQUMzQyxPQUFPLEVBQWMsT0FBTyxFQUFFLE1BQU0sTUFBTSxDQUFDOzs7QUFHM0MsTUFBTSxLQUFPLE1BQU0sR0FBRyxRQUFROztBQUU5QixNQUFNLEtBQU8sSUFBSSxHQUFHLE1BQU07O0FBRTFCLE1BQU0sS0FBTyxHQUFHLEdBQUcsS0FBSztBQUV4QjtJQUFBO1FBRVUsWUFBTyxHQUFHLElBQUksT0FBTyxFQUFrQixDQUFDO1FBQ3hDLFNBQUksR0FBUSxJQUFJLENBQUM7UUFDakIsVUFBSyxHQUFTLElBQUksQ0FBQztRQUNuQixZQUFPLEdBQVcsSUFBSSxDQUFDO0tBdUVoQzs7Ozs7O0lBckVTLDZCQUFHOzs7OztJQUFYLFVBQVksR0FBVztRQUNyQixPQUFPLElBQUksQ0FBQyxLQUFLLENBQUMsWUFBWSxDQUFDLE9BQU8sQ0FBQyxHQUFHLENBQUMsSUFBSSxNQUFNLENBQUMsSUFBSSxJQUFJLENBQUM7SUFDakUsQ0FBQzs7Ozs7OztJQUVPLDZCQUFHOzs7Ozs7SUFBWCxVQUFZLEdBQVcsRUFBRSxLQUFVO1FBQ2pDLFlBQVksQ0FBQyxPQUFPLENBQUMsR0FBRyxFQUFFLElBQUksQ0FBQyxTQUFTLENBQUMsS0FBSyxDQUFDLENBQUMsQ0FBQztJQUNuRCxDQUFDO0lBRUQsc0JBQUksbUNBQU07Ozs7UUFBVjtZQUNFLElBQUksQ0FBQyxJQUFJLENBQUMsT0FBTyxFQUFFO2dCQUNqQixJQUFJLENBQUMsT0FBTyxzQkFDVixLQUFLLEVBQUUsSUFBSSxFQUNYLFNBQVMsRUFBRSxLQUFLLEVBQ2hCLEtBQUssRUFBRSxLQUFLLEVBQ1osSUFBSSxFQUFF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c291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgSW5qZWN0YWJsZSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgT2JzZXJ2YWJsZSwgU3ViamVjdCB9IGZyb20gJ3J4anMnO1xuaW1wb3J0IHsgQXBwLCBMYXlvdXQsIFNldHRpbmdzTm90aWZ5LCBVc2VyIH0gZnJvbSAnLi9pbnRlcmZhY2UnO1xuXG5leHBvcnQgY29uc3QgTEFZT1VUID0gJ2xheW91dCc7XG5cbmV4cG9ydCBjb25zdCBVU0VSID0gJ3VzZXInO1xuXG5leHBvcnQgY29uc3QgQVBQID0gJ2FwcCc7XG5cbkBJbmplY3RhYmxlKHsgcHJvdmlkZWRJbjogJ3Jvb3QnIH0pXG5leHBvcnQgY2xhc3MgU2V0dGluZ3NTZXJ2aWNlIHtcbiAgcHJpdmF0ZSBub3RpZnkkID0gbmV3IFN1YmplY3Q8U2V0dGluZ3NOb3RpZnk+KCk7XG4gIHByaXZhdGUgX2FwcDogQXBwID0gbnVsbDtcbiAgcHJpdmF0ZSBfdXNlcjogVXNlciA9IG51bGw7XG4gIHByaXZhdGUgX2xheW91dDogTGF5b3V0ID0gbnVsbDtcblxuICBwcml2YXRlIGdldChrZXk6IHN0cmluZykge1xuICAgIHJldHVybiBKU09OLnBhcnNlKGxvY2FsU3RvcmFnZS5nZXRJdGVtKGtleSkgfHwgJ251bGwnKSB8fCBudWxsO1xuICB9XG5cbiAgcHJpdmF0ZSBzZXQoa2V5OiBzdHJpbmcsIHZhbHVlOiBhbnkpIHtcbiAgICBsb2NhbFN0b3JhZ2Uuc2V0SXRlbShrZXksIEpTT04uc3RyaW5naWZ5KHZhbHVlKSk7XG4gIH1cblxuICBnZXQgbGF5b3V0KCk6IExheW91dCB7XG4gICAgaWYgKCF0aGlzLl9sYXlvdXQpIHtcbiAgICAgIHRoaXMuX2xheW91dCA9IHtcbiAgICAgICAgZml4ZWQ6IHRydWUsXG4gICAgICAgIGNvbGxhcHNlZDogZmFsc2UsXG4gICAgICAgIGJveGVkOiBmYWxzZSxcbiAgICAgICAgbGFuZzogbnVsbCxcbiAgICAgICAgLi4udGhpcy5nZXQoTEFZT1VUKSxcbiAgICAgIH07XG4gICAgICB0aGlzLnNldChMQVlPVVQsIHRoaXMuX2xheW91dCk7XG4gICAgfVxuICAgIHJldHVybiB0aGlzLl9sYXlvdXQ7XG4gIH1cblxuICBnZXQgYXBwKCk6IEFwcCB7XG4gICAgaWYgKCF0aGlzLl9hcHApIHtcbiAgICAgIHRoaXMuX2FwcCA9IHtcbiAgICAgICAgeWVhcjogbmV3IERhdGUoKS5nZXRGdWxsWWVhcigpLFxuICAgICAgICAuLi50aGlzLmdldChBUFApLFxuICAgICAgfTtcbiAgICAgIHRoaXMuc2V0KEFQUCwgdGhpcy5fYXBwKTtcbiAgICB9XG4gICAgcmV0dXJuIHRoaXMuX2FwcDtcbiAgfVxuXG4gIGdldCB1c2VyKCk6IFVzZXIge1xuICAgIGlmICghdGhpcy5fdXNlcikge1xuICAgICAgdGhpcy5fdXNlciA9IHsgLi4udGhpcy5nZXQoVVNFUikgfTtcbiAgICAgIHRoaXMuc2V0KFVTRVIsIHRoaXMuX3VzZXIpO1xuICAgIH1cbiAgICByZXR1cm4gdGhpcy5fdXNlcjtcbiAgfVxuXG4gIGdldCBub3RpZnkoKTogT2JzZXJ2YWJsZTxTZXR0aW5nc05vdGlmeT4ge1xuICAgIHJldHVybiB0aGlzLm5vdGlmeSQuYXNPYnNlcnZhYmxlKCk7XG4gIH1cblxuICBzZXRMYXlvdXQobmFtZTogc3RyaW5nIHwgTGF5b3V0LCB2YWx1ZT86IGFueSk6IGJvb2xlYW4ge1xuICAgIGlmICh0eXBlb2YgbmFtZSA9PT0gJ3N0cmluZycpIHtcbiAgICAgIHRoaXMubGF5b3V0W25hbWVdID0gdmFsdWU7XG4gICAgfSBlbHNlIHtcbiAgICAgIHRoaXMuX2xheW91dCA9IG5hbWU7XG4gICAgfVxuICAgIHRoaXMuc2V0KExBWU9VVCwgdGhpcy5fbGF5b3V0KTtcbiAgICB0aGlzLm5vdGlmeSQubmV4dCh7IHR5cGU6ICdsYXlvdXQnLCBuYW1lLCB2YWx1ZSB9IGFzIGFueSk7XG4gICAgcmV0dXJuIHRydWU7XG4gIH1cblxuICBzZXRBcHAodmFsdWU6IEFwcCkge1xuICAgIHRoaXMuX2FwcCA9IHZhbHVlO1xuICAgIHRoaXMuc2V0KEFQUCwgdmFsdWUpO1xuICAgIHRoaXMubm90aWZ5JC5uZXh0KHsgdHlwZTogJ2FwcCcsIHZhbHVlIH0pO1xuICAgIHJldHVybiB0cnVlO1xuICB9XG5cbiAgc2V0VXNlcih2YWx1ZTogVXNlcikge1xuICAgIHRoaXMuX3VzZXIgPSB2YWx1ZTtcbiAgICB0aGlzLnNldChVU0VSLCB2YWx1ZSk7XG4gICAgdGhpcy5ub3RpZnkkLm5leHQoeyB0eXBlOiAndXNlcicsIHZhbHVlIH0pO1xuICAgIHJldHVybiB0cnVlO1xuICB9XG59XG4iXX0=