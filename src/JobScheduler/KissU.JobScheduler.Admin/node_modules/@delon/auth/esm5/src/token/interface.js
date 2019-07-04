/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { InjectionToken } from '@angular/core';
import { DA_SERVICE_TOKEN_FACTORY } from './token.service';
/** @type {?} */
export var DA_SERVICE_TOKEN = new InjectionToken('DA_SERVICE_TOKEN', {
    providedIn: 'root',
    factory: DA_SERVICE_TOKEN_FACTORY,
});
/**
 * @record
 */
export function ITokenModel() { }
if (false) {
    /** @type {?} */
    ITokenModel.prototype.token;
    /* Skipping unhandled member: [key: string]: any;*/
}
/**
 * @record
 */
export function AuthReferrer() { }
if (false) {
    /** @type {?|undefined} */
    AuthReferrer.prototype.url;
}
/**
 * @record
 */
export function ITokenService() { }
if (false) {
    /**
     * 获取登录地址
     * @type {?}
     */
    ITokenService.prototype.login_url;
    /**
     * 获取授权失败前路由信息
     * @type {?|undefined}
     */
    ITokenService.prototype.referrer;
    /**
     * @param {?} data
     * @return {?}
     */
    ITokenService.prototype.set = function (data) { };
    /**
     * 获取Token，形式包括：
     * - `get()` 获取 Simple Token
     * - `get<JWTTokenModel>(JWTTokenModel)` 获取 JWT Token
     * @param {?=} type
     * @return {?}
     */
    ITokenService.prototype.get = function (type) { };
    /**
     * 获取Token，形式包括：
     * - `get()` 获取 Simple Token
     * - `get<JWTTokenModel>(JWTTokenModel)` 获取 JWT Token
     * @template T
     * @param {?=} type
     * @return {?}
     */
    ITokenService.prototype.get = function (type) { };
    /**
     * @return {?}
     */
    ITokenService.prototype.clear = function () { };
    /**
     * @return {?}
     */
    ITokenService.prototype.change = function () { };
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiaW50ZXJmYWNlLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2F1dGgvIiwic291cmNlcyI6WyJzcmMvdG9rZW4vaW50ZXJmYWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsY0FBYyxFQUFFLE1BQU0sZUFBZSxDQUFDO0FBRS9DLE9BQU8sRUFBRSx3QkFBd0IsRUFBRSxNQUFNLGlCQUFpQixDQUFDOztBQUUzRCxNQUFNLEtBQU8sZ0JBQWdCLEdBQUcsSUFBSSxjQUFjLENBQWdCLGtCQUFrQixFQUFFO0lBQ3BGLFVBQVUsRUFBRSxNQUFNO0lBQ2xCLE9BQU8sRUFBRSx3QkFBd0I7Q0FDbEMsQ0FBQzs7OztBQUVGLGlDQUlDOzs7SUFEQyw0QkFBYzs7Ozs7O0FBR2hCLGtDQUVDOzs7SUFEQywyQkFBYTs7Ozs7QUFHZixtQ0EwQkM7Ozs7OztJQUpDLGtDQUEyQjs7Ozs7SUFHM0IsaUNBQWlDOzs7OztJQXhCakMsa0RBQWdDOzs7Ozs7OztJQU9oQyxrREFBNkI7Ozs7Ozs7OztJQU83QixrREFBMEM7Ozs7SUFFMUMsZ0RBQWM7Ozs7SUFFZCxpREFBa0MiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBJbmplY3Rpb25Ub2tlbiB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgT2JzZXJ2YWJsZSB9IGZyb20gJ3J4anMnO1xuaW1wb3J0IHsgREFfU0VSVklDRV9UT0tFTl9GQUNUT1JZIH0gZnJvbSAnLi90b2tlbi5zZXJ2aWNlJztcblxuZXhwb3J0IGNvbnN0IERBX1NFUlZJQ0VfVE9LRU4gPSBuZXcgSW5qZWN0aW9uVG9rZW48SVRva2VuU2VydmljZT4oJ0RBX1NFUlZJQ0VfVE9LRU4nLCB7XG4gIHByb3ZpZGVkSW46ICdyb290JyxcbiAgZmFjdG9yeTogREFfU0VSVklDRV9UT0tFTl9GQUNUT1JZLFxufSk7XG5cbmV4cG9ydCBpbnRlcmZhY2UgSVRva2VuTW9kZWwge1xuICBba2V5OiBzdHJpbmddOiBhbnk7XG5cbiAgdG9rZW46IHN0cmluZztcbn1cblxuZXhwb3J0IGludGVyZmFjZSBBdXRoUmVmZXJyZXIge1xuICB1cmw/OiBzdHJpbmc7XG59XG5cbmV4cG9ydCBpbnRlcmZhY2UgSVRva2VuU2VydmljZSB7XG4gIHNldChkYXRhOiBJVG9rZW5Nb2RlbCk6IGJvb2xlYW47XG5cbiAgLyoqXG4gICAqIOiOt+WPllRva2Vu77yM5b2i5byP5YyF5ous77yaXG4gICAqIC0gYGdldCgpYCDojrflj5YgU2ltcGxlIFRva2VuXG4gICAqIC0gYGdldDxKV1RUb2tlbk1vZGVsPihKV1RUb2tlbk1vZGVsKWAg6I635Y+WIEpXVCBUb2tlblxuICAgKi9cbiAgZ2V0KHR5cGU/OiBhbnkpOiBJVG9rZW5Nb2RlbDtcblxuICAvKipcbiAgICog6I635Y+WVG9rZW7vvIzlvaLlvI/ljIXmi6zvvJpcbiAgICogLSBgZ2V0KClgIOiOt+WPliBTaW1wbGUgVG9rZW5cbiAgICogLSBgZ2V0PEpXVFRva2VuTW9kZWw+KEpXVFRva2VuTW9kZWwpYCDojrflj5YgSldUIFRva2VuXG4gICAqL1xuICBnZXQ8VCBleHRlbmRzIElUb2tlbk1vZGVsPih0eXBlPzogYW55KTogVDtcblxuICBjbGVhcigpOiB2b2lkO1xuXG4gIGNoYW5nZSgpOiBPYnNlcnZhYmxlPElUb2tlbk1vZGVsPjtcblxuICAvKiog6I635Y+W55m75b2V5Zyw5Z2AICovXG4gIHJlYWRvbmx5IGxvZ2luX3VybDogc3RyaW5nO1xuXG4gIC8qKiDojrflj5bmjojmnYPlpLHotKXliY3ot6/nlLHkv6Hmga8gKi9cbiAgcmVhZG9ubHkgcmVmZXJyZXI/OiBBdXRoUmVmZXJyZXI7XG59XG4iXX0=