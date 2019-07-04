/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable, InjectionToken } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { filter } from 'rxjs/operators';
import * as i0 from "@angular/core";
/**
 * @record
 */
export function AlainI18NService() { }
if (false) {
    /**
     * 调用 `use` 触发变更通知
     * @type {?}
     */
    AlainI18NService.prototype.change;
    /* Skipping unhandled member: [key: string]: any;*/
    /**
     * 变更语言
     * @param {?} lang 语言代码
     * @param {?=} emit 是否触发 `change`，默认：true
     * @return {?}
     */
    AlainI18NService.prototype.use = function (lang, emit) { };
    /**
     * 返回当前语言列表
     * @return {?}
     */
    AlainI18NService.prototype.getLangs = function () { };
    /**
     * 翻译
     * - `params` 模板所需要的参数对象
     * - `isSafe` 是否返回安全字符，自动调用 `bypassSecurityTrustHtml`
     * @param {?} key
     * @param {?=} params
     * @param {?=} isSafe
     * @return {?}
     */
    AlainI18NService.prototype.fanyi = function (key, params, isSafe) { };
}
/** @type {?} */
export const ALAIN_I18N_TOKEN = new InjectionToken('alainTranslatorToken', {
    providedIn: 'root',
    factory: ALAIN_I18N_TOKEN_FACTORY,
});
/**
 * @return {?}
 */
export function ALAIN_I18N_TOKEN_FACTORY() {
    return new AlainI18NServiceFake();
}
export class AlainI18NServiceFake {
    constructor() {
        this.change$ = new BehaviorSubject(null);
    }
    /**
     * @return {?}
     */
    get change() {
        return this.change$.asObservable().pipe(filter((/**
         * @param {?} w
         * @return {?}
         */
        w => w != null)));
    }
    /**
     * @param {?} lang
     * @return {?}
     */
    use(lang) {
        this.change$.next(lang);
    }
    /**
     * @return {?}
     */
    getLangs() {
        return [];
    }
    /**
     * @param {?} key
     * @return {?}
     */
    fanyi(key) {
        return key;
    }
}
AlainI18NServiceFake.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */ AlainI18NServiceFake.ngInjectableDef = i0.defineInjectable({ factory: function AlainI18NServiceFake_Factory() { return new AlainI18NServiceFake(); }, token: AlainI18NServiceFake, providedIn: "root" });
if (false) {
    /**
     * @type {?}
     * @private
     */
    AlainI18NServiceFake.prototype.change$;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiaTE4bi5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi90aGVtZS8iLCJzb3VyY2VzIjpbInNyYy9zZXJ2aWNlcy9pMThuL2kxOG4udHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7OztBQUFBLE9BQU8sRUFBRSxVQUFVLEVBQUUsY0FBYyxFQUFFLE1BQU0sZUFBZSxDQUFDO0FBQzNELE9BQU8sRUFBRSxlQUFlLEVBQWMsTUFBTSxNQUFNLENBQUM7QUFDbkQsT0FBTyxFQUFFLE1BQU0sRUFBRSxNQUFNLGdCQUFnQixDQUFDOzs7OztBQUV4QyxzQ0EwQkM7Ozs7OztJQURDLGtDQUFvQzs7Ozs7Ozs7SUFqQnBDLDJEQUF3Qzs7Ozs7SUFLeEMsc0RBQWtCOzs7Ozs7Ozs7O0lBT2xCLHNFQUEwRDs7O0FBUTVELE1BQU0sT0FBTyxnQkFBZ0IsR0FBRyxJQUFJLGNBQWMsQ0FDaEQsc0JBQXNCLEVBQ3RCO0lBQ0UsVUFBVSxFQUFFLE1BQU07SUFDbEIsT0FBTyxFQUFFLHdCQUF3QjtDQUNsQyxDQUNGOzs7O0FBRUQsTUFBTSxVQUFVLHdCQUF3QjtJQUN0QyxPQUFPLElBQUksb0JBQW9CLEVBQUUsQ0FBQztBQUNwQyxDQUFDO0FBR0QsTUFBTSxPQUFPLG9CQUFvQjtJQURqQztRQUVVLFlBQU8sR0FBRyxJQUFJLGVBQWUsQ0FBUyxJQUFJLENBQUMsQ0FBQztLQWlCckQ7Ozs7SUFmQyxJQUFJLE1BQU07UUFDUixPQUFPLElBQUksQ0FBQyxPQUFPLENBQUMsWUFBWSxFQUFFLENBQUMsSUFBSSxDQUFDLE1BQU07Ozs7UUFBQyxDQUFDLENBQUMsRUFBRSxDQUFDLENBQUMsSUFBSSxJQUFJLEVBQUMsQ0FBQyxDQUFDO0lBQ2xFLENBQUM7Ozs7O0lBRUQsR0FBRyxDQUFDLElBQVk7UUFDZCxJQUFJLENBQUMsT0FBTyxDQUFDLElBQUksQ0FBQyxJQUFJLENBQUMsQ0FBQztJQUMxQixDQUFDOzs7O0lBRUQsUUFBUTtRQUNOLE9BQU8sRUFBRSxDQUFDO0lBQ1osQ0FBQzs7Ozs7SUFFRCxLQUFLLENBQUMsR0FBVztRQUNmLE9BQU8sR0FBRyxDQUFDO0lBQ2IsQ0FBQzs7O1lBbEJGLFVBQVUsU0FBQyxFQUFFLFVBQVUsRUFBRSxNQUFNLEVBQUU7Ozs7Ozs7O0lBRWhDLHVDQUFvRCIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IEluamVjdGFibGUsIEluamVjdGlvblRva2VuIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBCZWhhdmlvclN1YmplY3QsIE9ic2VydmFibGUgfSBmcm9tICdyeGpzJztcbmltcG9ydCB7IGZpbHRlciB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuZXhwb3J0IGludGVyZmFjZSBBbGFpbkkxOE5TZXJ2aWNlIHtcbiAgW2tleTogc3RyaW5nXTogYW55O1xuXG4gIC8qKlxuICAgKiDlj5jmm7Tor63oqIBcbiAgICogQHBhcmFtIGxhbmcg6K+t6KiA5Luj56CBXG4gICAqIEBwYXJhbSBlbWl0IOaYr+WQpuinpuWPkSBgY2hhbmdlYO+8jOm7mOiupO+8mnRydWVcbiAgICovXG4gIHVzZShsYW5nOiBzdHJpbmcsIGVtaXQ/OiBib29sZWFuKTogdm9pZDtcblxuICAvKipcbiAgICog6L+U5Zue5b2T5YmN6K+t6KiA5YiX6KGoXG4gICAqL1xuICBnZXRMYW5ncygpOiBhbnlbXTtcblxuICAvKipcbiAgICog57+76K+RXG4gICAqIC0gYHBhcmFtc2Ag5qih5p2/5omA6ZyA6KaB55qE5Y+C5pWw5a+56LGhXG4gICAqIC0gYGlzU2FmZWAg5piv5ZCm6L+U5Zue5a6J5YWo5a2X56ym77yM6Ieq5Yqo6LCD55SoIGBieXBhc3NTZWN1cml0eVRydXN0SHRtbGBcbiAgICovXG4gIGZhbnlpKGtleTogc3RyaW5nLCBwYXJhbXM/OiB7fSwgaXNTYWZlPzogYm9vbGVhbik6IHN0cmluZztcblxuICAvKipcbiAgICog6LCD55SoIGB1c2VgIOinpuWPkeWPmOabtOmAmuefpVxuICAgKi9cbiAgcmVhZG9ubHkgY2hhbmdlOiBPYnNlcnZhYmxlPHN0cmluZz47XG59XG5cbmV4cG9ydCBjb25zdCBBTEFJTl9JMThOX1RPS0VOID0gbmV3IEluamVjdGlvblRva2VuPEFsYWluSTE4TlNlcnZpY2U+KFxuICAnYWxhaW5UcmFuc2xhdG9yVG9rZW4nLFxuICB7XG4gICAgcHJvdmlkZWRJbjogJ3Jvb3QnLFxuICAgIGZhY3Rvcnk6IEFMQUlOX0kxOE5fVE9LRU5fRkFDVE9SWSxcbiAgfSxcbik7XG5cbmV4cG9ydCBmdW5jdGlvbiBBTEFJTl9JMThOX1RPS0VOX0ZBQ1RPUlkoKSB7XG4gIHJldHVybiBuZXcgQWxhaW5JMThOU2VydmljZUZha2UoKTtcbn1cblxuQEluamVjdGFibGUoeyBwcm92aWRlZEluOiAncm9vdCcgfSlcbmV4cG9ydCBjbGFzcyBBbGFpbkkxOE5TZXJ2aWNlRmFrZSBpbXBsZW1lbnRzIEFsYWluSTE4TlNlcnZpY2Uge1xuICBwcml2YXRlIGNoYW5nZSQgPSBuZXcgQmVoYXZpb3JTdWJqZWN0PHN0cmluZz4obnVsbCk7XG5cbiAgZ2V0IGNoYW5nZSgpOiBPYnNlcnZhYmxlPHN0cmluZz4ge1xuICAgIHJldHVybiB0aGlzLmNoYW5nZSQuYXNPYnNlcnZhYmxlKCkucGlwZShmaWx0ZXIodyA9PiB3ICE9IG51bGwpKTtcbiAgfVxuXG4gIHVzZShsYW5nOiBzdHJpbmcpOiB2b2lkIHtcbiAgICB0aGlzLmNoYW5nZSQubmV4dChsYW5nKTtcbiAgfVxuXG4gIGdldExhbmdzKCk6IGFueVtdIHtcbiAgICByZXR1cm4gW107XG4gIH1cblxuICBmYW55aShrZXk6IHN0cmluZykge1xuICAgIHJldHVybiBrZXk7XG4gIH1cbn1cbiJdfQ==