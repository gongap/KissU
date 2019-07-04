/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';
import { DA_SERVICE_TOKEN } from './interface';
/**
 * @param {?} model
 * @return {?}
 */
export function CheckSimple(model) {
    return model != null && typeof model.token === 'string' && model.token.length > 0;
}
/**
 * @param {?} model
 * @param {?} offset
 * @return {?}
 */
export function CheckJwt(model, offset) {
    return model != null && model.token && !model.isExpired(offset);
}
/**
 * @param {?} options
 * @param {?} injector
 * @param {?} url
 * @return {?}
 */
export function ToLogin(options, injector, url) {
    ((/** @type {?} */ (injector.get(DA_SERVICE_TOKEN)))).referrer.url = url;
    if (options.token_invalid_redirect === true) {
        setTimeout((/**
         * @return {?}
         */
        function () {
            if (/^https?:\/\//g.test(options.login_url)) {
                injector.get(DOCUMENT).location.href = options.login_url;
            }
            else {
                injector.get(Router).navigate([options.login_url]);
            }
        }));
    }
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiaGVscGVyLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2F1dGgvIiwic291cmNlcyI6WyJzcmMvdG9rZW4vaGVscGVyLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsUUFBUSxFQUFFLE1BQU0saUJBQWlCLENBQUM7QUFFM0MsT0FBTyxFQUFFLE1BQU0sRUFBRSxNQUFNLGlCQUFpQixDQUFDO0FBRXpDLE9BQU8sRUFBRSxnQkFBZ0IsRUFBaUIsTUFBTSxhQUFhLENBQUM7Ozs7O0FBSTlELE1BQU0sVUFBVSxXQUFXLENBQUMsS0FBdUI7SUFDakQsT0FBTyxLQUFLLElBQUksSUFBSSxJQUFJLE9BQU8sS0FBSyxDQUFDLEtBQUssS0FBSyxRQUFRLElBQUksS0FBSyxDQUFDLEtBQUssQ0FBQyxNQUFNLEdBQUcsQ0FBQyxDQUFDO0FBQ3BGLENBQUM7Ozs7OztBQUVELE1BQU0sVUFBVSxRQUFRLENBQUMsS0FBb0IsRUFBRSxNQUFjO0lBQzNELE9BQU8sS0FBSyxJQUFJLElBQUksSUFBSSxLQUFLLENBQUMsS0FBSyxJQUFJLENBQUMsS0FBSyxDQUFDLFNBQVMsQ0FBQyxNQUFNLENBQUMsQ0FBQztBQUNsRSxDQUFDOzs7Ozs7O0FBRUQsTUFBTSxVQUFVLE9BQU8sQ0FBQyxPQUF3QixFQUFFLFFBQWtCLEVBQUUsR0FBVztJQUMvRSxDQUFDLG1CQUFBLFFBQVEsQ0FBQyxHQUFHLENBQUMsZ0JBQWdCLENBQUMsRUFBaUIsQ0FBQyxDQUFDLFFBQVEsQ0FBQyxHQUFHLEdBQUcsR0FBRyxDQUFDO0lBQ3JFLElBQUksT0FBTyxDQUFDLHNCQUFzQixLQUFLLElBQUksRUFBRTtRQUMzQyxVQUFVOzs7UUFBQztZQUNULElBQUksZUFBZSxDQUFDLElBQUksQ0FBQyxPQUFPLENBQUMsU0FBUyxDQUFDLEVBQUU7Z0JBQzNDLFFBQVEsQ0FBQyxHQUFHLENBQUMsUUFBUSxDQUFDLENBQUMsUUFBUSxDQUFDLElBQUksR0FBRyxPQUFPLENBQUMsU0FBUyxDQUFDO2FBQzFEO2lCQUFNO2dCQUNMLFFBQVEsQ0FBQyxHQUFHLENBQUMsTUFBTSxDQUFDLENBQUMsUUFBUSxDQUFDLENBQUMsT0FBTyxDQUFDLFNBQVMsQ0FBQyxDQUFDLENBQUM7YUFDcEQ7UUFDSCxDQUFDLEVBQUMsQ0FBQztLQUNKO0FBQ0gsQ0FBQyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IERPQ1VNRU5UIH0gZnJvbSAnQGFuZ3VsYXIvY29tbW9uJztcbmltcG9ydCB7IEluamVjdG9yIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBSb3V0ZXIgfSBmcm9tICdAYW5ndWxhci9yb3V0ZXInO1xuaW1wb3J0IHsgRGVsb25BdXRoQ29uZmlnIH0gZnJvbSAnLi4vYXV0aC5jb25maWcnO1xuaW1wb3J0IHsgREFfU0VSVklDRV9UT0tFTiwgSVRva2VuU2VydmljZSB9IGZyb20gJy4vaW50ZXJmYWNlJztcbmltcG9ydCB7IEpXVFRva2VuTW9kZWwgfSBmcm9tICcuL2p3dC9qd3QubW9kZWwnO1xuaW1wb3J0IHsgU2ltcGxlVG9rZW5Nb2RlbCB9IGZyb20gJy4vc2ltcGxlL3NpbXBsZS5tb2RlbCc7XG5cbmV4cG9ydCBmdW5jdGlvbiBDaGVja1NpbXBsZShtb2RlbDogU2ltcGxlVG9rZW5Nb2RlbCk6IGJvb2xlYW4ge1xuICByZXR1cm4gbW9kZWwgIT0gbnVsbCAmJiB0eXBlb2YgbW9kZWwudG9rZW4gPT09ICdzdHJpbmcnICYmIG1vZGVsLnRva2VuLmxlbmd0aCA+IDA7XG59XG5cbmV4cG9ydCBmdW5jdGlvbiBDaGVja0p3dChtb2RlbDogSldUVG9rZW5Nb2RlbCwgb2Zmc2V0OiBudW1iZXIpOiBib29sZWFuIHtcbiAgcmV0dXJuIG1vZGVsICE9IG51bGwgJiYgbW9kZWwudG9rZW4gJiYgIW1vZGVsLmlzRXhwaXJlZChvZmZzZXQpO1xufVxuXG5leHBvcnQgZnVuY3Rpb24gVG9Mb2dpbihvcHRpb25zOiBEZWxvbkF1dGhDb25maWcsIGluamVjdG9yOiBJbmplY3RvciwgdXJsOiBzdHJpbmcpIHtcbiAgKGluamVjdG9yLmdldChEQV9TRVJWSUNFX1RPS0VOKSBhcyBJVG9rZW5TZXJ2aWNlKS5yZWZlcnJlci51cmwgPSB1cmw7XG4gIGlmIChvcHRpb25zLnRva2VuX2ludmFsaWRfcmVkaXJlY3QgPT09IHRydWUpIHtcbiAgICBzZXRUaW1lb3V0KCgpID0+IHtcbiAgICAgIGlmICgvXmh0dHBzPzpcXC9cXC8vZy50ZXN0KG9wdGlvbnMubG9naW5fdXJsKSkge1xuICAgICAgICBpbmplY3Rvci5nZXQoRE9DVU1FTlQpLmxvY2F0aW9uLmhyZWYgPSBvcHRpb25zLmxvZ2luX3VybDtcbiAgICAgIH0gZWxzZSB7XG4gICAgICAgIGluamVjdG9yLmdldChSb3V0ZXIpLm5hdmlnYXRlKFtvcHRpb25zLmxvZ2luX3VybF0pO1xuICAgICAgfVxuICAgIH0pO1xuICB9XG59XG4iXX0=