/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Inject, Injectable, Optional, SkipSelf } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import zhCN from './languages/zh-CN';
import { DELON_LOCALE } from './locale.tokens';
export class DelonLocaleService {
    /**
     * @param {?} locale
     */
    constructor(locale) {
        this.change$ = new BehaviorSubject(this._locale);
        this.setLocale(locale || zhCN);
    }
    /**
     * @return {?}
     */
    get change() {
        return this.change$.asObservable();
    }
    /**
     * @param {?} locale
     * @return {?}
     */
    setLocale(locale) {
        if (this._locale && this._locale.abbr === locale.abbr) {
            return;
        }
        this._locale = locale;
        this.change$.next(locale);
    }
    /**
     * @return {?}
     */
    get locale() {
        return this._locale;
    }
    /**
     * @param {?} path
     * @return {?}
     */
    getData(path) {
        return this._locale[path] || {};
    }
}
DelonLocaleService.decorators = [
    { type: Injectable }
];
/** @nocollapse */
DelonLocaleService.ctorParameters = () => [
    { type: undefined, decorators: [{ type: Inject, args: [DELON_LOCALE,] }] }
];
if (false) {
    /**
     * @type {?}
     * @private
     */
    DelonLocaleService.prototype._locale;
    /**
     * @type {?}
     * @private
     */
    DelonLocaleService.prototype.change$;
}
/**
 * @param {?} exist
 * @param {?} locale
 * @return {?}
 */
export function DELON_LOCALE_SERVICE_PROVIDER_FACTORY(exist, locale) {
    return exist || new DelonLocaleService(locale);
}
/** @type {?} */
export const DELON_LOCALE_SERVICE_PROVIDER = {
    provide: DelonLocaleService,
    useFactory: DELON_LOCALE_SERVICE_PROVIDER_FACTORY,
    deps: [[new Optional(), new SkipSelf(), DelonLocaleService], DELON_LOCALE],
};
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibG9jYWxlLnNlcnZpY2UuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vdGhlbWUvIiwic291cmNlcyI6WyJzcmMvbG9jYWxlL2xvY2FsZS5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsTUFBTSxFQUFFLFVBQVUsRUFBRSxRQUFRLEVBQVksUUFBUSxFQUFFLE1BQU0sZUFBZSxDQUFDO0FBQ2pGLE9BQU8sRUFBRSxlQUFlLEVBQWMsTUFBTSxNQUFNLENBQUM7QUFFbkQsT0FBTyxJQUFJLE1BQU0sbUJBQW1CLENBQUM7QUFDckMsT0FBTyxFQUFFLFlBQVksRUFBRSxNQUFNLGlCQUFpQixDQUFDO0FBSS9DLE1BQU0sT0FBTyxrQkFBa0I7Ozs7SUFJN0IsWUFBa0MsTUFBc0I7UUFGaEQsWUFBTyxHQUFHLElBQUksZUFBZSxDQUFpQixJQUFJLENBQUMsT0FBTyxDQUFDLENBQUM7UUFHbEUsSUFBSSxDQUFDLFNBQVMsQ0FBQyxNQUFNLElBQUksSUFBSSxDQUFDLENBQUM7SUFDakMsQ0FBQzs7OztJQUVELElBQUksTUFBTTtRQUNSLE9BQU8sSUFBSSxDQUFDLE9BQU8sQ0FBQyxZQUFZLEVBQUUsQ0FBQztJQUNyQyxDQUFDOzs7OztJQUVELFNBQVMsQ0FBQyxNQUFzQjtRQUM5QixJQUFJLElBQUksQ0FBQyxPQUFPLElBQUksSUFBSSxDQUFDLE9BQU8sQ0FBQyxJQUFJLEtBQUssTUFBTSxDQUFDLElBQUksRUFBRTtZQUNyRCxPQUFPO1NBQ1I7UUFDRCxJQUFJLENBQUMsT0FBTyxHQUFHLE1BQU0sQ0FBQztRQUN0QixJQUFJLENBQUMsT0FBTyxDQUFDLElBQUksQ0FBQyxNQUFNLENBQUMsQ0FBQztJQUM1QixDQUFDOzs7O0lBRUQsSUFBSSxNQUFNO1FBQ1IsT0FBTyxJQUFJLENBQUMsT0FBTyxDQUFDO0lBQ3RCLENBQUM7Ozs7O0lBRUQsT0FBTyxDQUFDLElBQVk7UUFDbEIsT0FBTyxJQUFJLENBQUMsT0FBTyxDQUFDLElBQUksQ0FBQyxJQUFJLEVBQUUsQ0FBQztJQUNsQyxDQUFDOzs7WUEzQkYsVUFBVTs7Ozs0Q0FLSSxNQUFNLFNBQUMsWUFBWTs7Ozs7OztJQUhoQyxxQ0FBZ0M7Ozs7O0lBQ2hDLHFDQUFvRTs7Ozs7OztBQTJCdEUsTUFBTSxVQUFVLHFDQUFxQyxDQUNuRCxLQUF5QixFQUN6QixNQUFzQjtJQUV0QixPQUFPLEtBQUssSUFBSSxJQUFJLGtCQUFrQixDQUFDLE1BQU0sQ0FBQyxDQUFDO0FBQ2pELENBQUM7O0FBRUQsTUFBTSxPQUFPLDZCQUE2QixHQUFhO0lBQ3JELE9BQU8sRUFBRSxrQkFBa0I7SUFDM0IsVUFBVSxFQUFFLHFDQUFxQztJQUNqRCxJQUFJLEVBQUUsQ0FBQyxDQUFDLElBQUksUUFBUSxFQUFFLEVBQUUsSUFBSSxRQUFRLEVBQUUsRUFBRSxrQkFBa0IsQ0FBQyxFQUFFLFlBQVksQ0FBQztDQUMzRSIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IEluamVjdCwgSW5qZWN0YWJsZSwgT3B0aW9uYWwsIFByb3ZpZGVyLCBTa2lwU2VsZiB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgQmVoYXZpb3JTdWJqZWN0LCBPYnNlcnZhYmxlIH0gZnJvbSAncnhqcyc7XG5cbmltcG9ydCB6aENOIGZyb20gJy4vbGFuZ3VhZ2VzL3poLUNOJztcbmltcG9ydCB7IERFTE9OX0xPQ0FMRSB9IGZyb20gJy4vbG9jYWxlLnRva2Vucyc7XG5pbXBvcnQgeyBGdWxsTG9jYWxlRGF0YSwgTG9jYWxlRGF0YSB9IGZyb20gJy4vbG9jYWxlLnR5cGVzJztcblxuQEluamVjdGFibGUoKVxuZXhwb3J0IGNsYXNzIERlbG9uTG9jYWxlU2VydmljZSB7XG4gIHByaXZhdGUgX2xvY2FsZTogRnVsbExvY2FsZURhdGE7XG4gIHByaXZhdGUgY2hhbmdlJCA9IG5ldyBCZWhhdmlvclN1YmplY3Q8RnVsbExvY2FsZURhdGE+KHRoaXMuX2xvY2FsZSk7XG5cbiAgY29uc3RydWN0b3IoQEluamVjdChERUxPTl9MT0NBTEUpIGxvY2FsZTogRnVsbExvY2FsZURhdGEpIHtcbiAgICB0aGlzLnNldExvY2FsZShsb2NhbGUgfHwgemhDTik7XG4gIH1cblxuICBnZXQgY2hhbmdlKCk6IE9ic2VydmFibGU8RnVsbExvY2FsZURhdGE+IHtcbiAgICByZXR1cm4gdGhpcy5jaGFuZ2UkLmFzT2JzZXJ2YWJsZSgpO1xuICB9XG5cbiAgc2V0TG9jYWxlKGxvY2FsZTogRnVsbExvY2FsZURhdGEpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5fbG9jYWxlICYmIHRoaXMuX2xvY2FsZS5hYmJyID09PSBsb2NhbGUuYWJicikge1xuICAgICAgcmV0dXJuO1xuICAgIH1cbiAgICB0aGlzLl9sb2NhbGUgPSBsb2NhbGU7XG4gICAgdGhpcy5jaGFuZ2UkLm5leHQobG9jYWxlKTtcbiAgfVxuXG4gIGdldCBsb2NhbGUoKTogRnVsbExvY2FsZURhdGEge1xuICAgIHJldHVybiB0aGlzLl9sb2NhbGU7XG4gIH1cblxuICBnZXREYXRhKHBhdGg6IHN0cmluZyk6IExvY2FsZURhdGEge1xuICAgIHJldHVybiB0aGlzLl9sb2NhbGVbcGF0aF0gfHwge307XG4gIH1cbn1cblxuZXhwb3J0IGZ1bmN0aW9uIERFTE9OX0xPQ0FMRV9TRVJWSUNFX1BST1ZJREVSX0ZBQ1RPUlkoXG4gIGV4aXN0OiBEZWxvbkxvY2FsZVNlcnZpY2UsXG4gIGxvY2FsZTogRnVsbExvY2FsZURhdGEsXG4pOiBEZWxvbkxvY2FsZVNlcnZpY2Uge1xuICByZXR1cm4gZXhpc3QgfHwgbmV3IERlbG9uTG9jYWxlU2VydmljZShsb2NhbGUpO1xufVxuXG5leHBvcnQgY29uc3QgREVMT05fTE9DQUxFX1NFUlZJQ0VfUFJPVklERVI6IFByb3ZpZGVyID0ge1xuICBwcm92aWRlOiBEZWxvbkxvY2FsZVNlcnZpY2UsXG4gIHVzZUZhY3Rvcnk6IERFTE9OX0xPQ0FMRV9TRVJWSUNFX1BST1ZJREVSX0ZBQ1RPUlksXG4gIGRlcHM6IFtbbmV3IE9wdGlvbmFsKCksIG5ldyBTa2lwU2VsZigpLCBEZWxvbkxvY2FsZVNlcnZpY2VdLCBERUxPTl9MT0NBTEVdLFxufTtcbiJdfQ==