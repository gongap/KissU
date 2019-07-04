/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import { BaseInterceptor } from '../base.interceptor';
import { CheckSimple } from '../helper';
import { DA_SERVICE_TOKEN } from '../interface';
export class SimpleInterceptor extends BaseInterceptor {
    /**
     * @param {?} options
     * @return {?}
     */
    isAuth(options) {
        this.model = (/** @type {?} */ (this.injector.get(DA_SERVICE_TOKEN).get()));
        return CheckSimple((/** @type {?} */ (this.model)));
    }
    /**
     * @param {?} req
     * @param {?} options
     * @return {?}
     */
    setReq(req, options) {
        /** @type {?} */
        const token = options.token_send_template.replace(/\$\{([\w]+)\}/g, (/**
         * @param {?} _
         * @param {?} g
         * @return {?}
         */
        (_, g) => this.model[g]));
        switch (options.token_send_place) {
            case 'header':
                /** @type {?} */
                const obj = {};
                obj[options.token_send_key] = token;
                req = req.clone({
                    setHeaders: obj,
                });
                break;
            case 'body':
                /** @type {?} */
                const body = req.body || {};
                body[options.token_send_key] = token;
                req = req.clone({
                    body,
                });
                break;
            case 'url':
                req = req.clone({
                    params: req.params.append(options.token_send_key, token),
                });
                break;
        }
        return req;
    }
}
SimpleInterceptor.decorators = [
    { type: Injectable }
];
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoic2ltcGxlLmludGVyY2VwdG9yLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2F1dGgvIiwic291cmNlcyI6WyJzcmMvdG9rZW4vc2ltcGxlL3NpbXBsZS5pbnRlcmNlcHRvci50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQ0EsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLGVBQWUsQ0FBQztBQUczQyxPQUFPLEVBQUUsZUFBZSxFQUFFLE1BQU0scUJBQXFCLENBQUM7QUFDdEQsT0FBTyxFQUFFLFdBQVcsRUFBRSxNQUFNLFdBQVcsQ0FBQztBQUN4QyxPQUFPLEVBQUUsZ0JBQWdCLEVBQUUsTUFBTSxjQUFjLENBQUM7QUFJaEQsTUFBTSxPQUFPLGlCQUFrQixTQUFRLGVBQWU7Ozs7O0lBQ3BELE1BQU0sQ0FBQyxPQUF3QjtRQUM3QixJQUFJLENBQUMsS0FBSyxHQUFHLG1CQUFBLElBQUksQ0FBQyxRQUFRLENBQUMsR0FBRyxDQUFDLGdCQUFnQixDQUFDLENBQUMsR0FBRyxFQUFFLEVBQW9CLENBQUM7UUFDM0UsT0FBTyxXQUFXLENBQUMsbUJBQUEsSUFBSSxDQUFDLEtBQUssRUFBb0IsQ0FBQyxDQUFDO0lBQ3JELENBQUM7Ozs7OztJQUVELE1BQU0sQ0FBQyxHQUFxQixFQUFFLE9BQXdCOztjQUM5QyxLQUFLLEdBQUcsT0FBTyxDQUFDLG1CQUFtQixDQUFDLE9BQU8sQ0FDL0MsZ0JBQWdCOzs7OztRQUNoQixDQUFDLENBQVMsRUFBRSxDQUFDLEVBQUUsRUFBRSxDQUFDLElBQUksQ0FBQyxLQUFLLENBQUMsQ0FBQyxDQUFDLEVBQ2hDO1FBQ0QsUUFBUSxPQUFPLENBQUMsZ0JBQWdCLEVBQUU7WUFDaEMsS0FBSyxRQUFROztzQkFDTCxHQUFHLEdBQUcsRUFBRTtnQkFDZCxHQUFHLENBQUMsT0FBTyxDQUFDLGNBQWMsQ0FBQyxHQUFHLEtBQUssQ0FBQztnQkFDcEMsR0FBRyxHQUFHLEdBQUcsQ0FBQyxLQUFLLENBQUM7b0JBQ2QsVUFBVSxFQUFFLEdBQUc7aUJBQ2hCLENBQUMsQ0FBQztnQkFDSCxNQUFNO1lBQ1IsS0FBSyxNQUFNOztzQkFDSCxJQUFJLEdBQUcsR0FBRyxDQUFDLElBQUksSUFBSSxFQUFFO2dCQUMzQixJQUFJLENBQUMsT0FBTyxDQUFDLGNBQWMsQ0FBQyxHQUFHLEtBQUssQ0FBQztnQkFDckMsR0FBRyxHQUFHLEdBQUcsQ0FBQyxLQUFLLENBQUM7b0JBQ2QsSUFBSTtpQkFDTCxDQUFDLENBQUM7Z0JBQ0gsTUFBTTtZQUNSLEtBQUssS0FBSztnQkFDUixHQUFHLEdBQUcsR0FBRyxDQUFDLEtBQUssQ0FBQztvQkFDZCxNQUFNLEVBQUUsR0FBRyxDQUFDLE1BQU0sQ0FBQyxNQUFNLENBQUMsT0FBTyxDQUFDLGNBQWMsRUFBRSxLQUFLLENBQUM7aUJBQ3pELENBQUMsQ0FBQztnQkFDSCxNQUFNO1NBQ1Q7UUFDRCxPQUFPLEdBQUcsQ0FBQztJQUNiLENBQUM7OztZQWxDRixVQUFVIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgSHR0cFJlcXVlc3QgfSBmcm9tICdAYW5ndWxhci9jb21tb24vaHR0cCc7XG5pbXBvcnQgeyBJbmplY3RhYmxlIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmltcG9ydCB7IERlbG9uQXV0aENvbmZpZyB9IGZyb20gJy4uLy4uL2F1dGguY29uZmlnJztcbmltcG9ydCB7IEJhc2VJbnRlcmNlcHRvciB9IGZyb20gJy4uL2Jhc2UuaW50ZXJjZXB0b3InO1xuaW1wb3J0IHsgQ2hlY2tTaW1wbGUgfSBmcm9tICcuLi9oZWxwZXInO1xuaW1wb3J0IHsgREFfU0VSVklDRV9UT0tFTiB9IGZyb20gJy4uL2ludGVyZmFjZSc7XG5pbXBvcnQgeyBTaW1wbGVUb2tlbk1vZGVsIH0gZnJvbSAnLi9zaW1wbGUubW9kZWwnO1xuXG5ASW5qZWN0YWJsZSgpXG5leHBvcnQgY2xhc3MgU2ltcGxlSW50ZXJjZXB0b3IgZXh0ZW5kcyBCYXNlSW50ZXJjZXB0b3Ige1xuICBpc0F1dGgob3B0aW9uczogRGVsb25BdXRoQ29uZmlnKTogYm9vbGVhbiB7XG4gICAgdGhpcy5tb2RlbCA9IHRoaXMuaW5qZWN0b3IuZ2V0KERBX1NFUlZJQ0VfVE9LRU4pLmdldCgpIGFzIFNpbXBsZVRva2VuTW9kZWw7XG4gICAgcmV0dXJuIENoZWNrU2ltcGxlKHRoaXMubW9kZWwgYXMgU2ltcGxlVG9rZW5Nb2RlbCk7XG4gIH1cblxuICBzZXRSZXEocmVxOiBIdHRwUmVxdWVzdDxhbnk+LCBvcHRpb25zOiBEZWxvbkF1dGhDb25maWcpOiBIdHRwUmVxdWVzdDxhbnk+IHtcbiAgICBjb25zdCB0b2tlbiA9IG9wdGlvbnMudG9rZW5fc2VuZF90ZW1wbGF0ZS5yZXBsYWNlKFxuICAgICAgL1xcJFxceyhbXFx3XSspXFx9L2csXG4gICAgICAoXzogc3RyaW5nLCBnKSA9PiB0aGlzLm1vZGVsW2ddLFxuICAgICk7XG4gICAgc3dpdGNoIChvcHRpb25zLnRva2VuX3NlbmRfcGxhY2UpIHtcbiAgICAgIGNhc2UgJ2hlYWRlcic6XG4gICAgICAgIGNvbnN0IG9iaiA9IHt9O1xuICAgICAgICBvYmpbb3B0aW9ucy50b2tlbl9zZW5kX2tleV0gPSB0b2tlbjtcbiAgICAgICAgcmVxID0gcmVxLmNsb25lKHtcbiAgICAgICAgICBzZXRIZWFkZXJzOiBvYmosXG4gICAgICAgIH0pO1xuICAgICAgICBicmVhaztcbiAgICAgIGNhc2UgJ2JvZHknOlxuICAgICAgICBjb25zdCBib2R5ID0gcmVxLmJvZHkgfHwge307XG4gICAgICAgIGJvZHlbb3B0aW9ucy50b2tlbl9zZW5kX2tleV0gPSB0b2tlbjtcbiAgICAgICAgcmVxID0gcmVxLmNsb25lKHtcbiAgICAgICAgICBib2R5LFxuICAgICAgICB9KTtcbiAgICAgICAgYnJlYWs7XG4gICAgICBjYXNlICd1cmwnOlxuICAgICAgICByZXEgPSByZXEuY2xvbmUoe1xuICAgICAgICAgIHBhcmFtczogcmVxLnBhcmFtcy5hcHBlbmQob3B0aW9ucy50b2tlbl9zZW5kX2tleSwgdG9rZW4pLFxuICAgICAgICB9KTtcbiAgICAgICAgYnJlYWs7XG4gICAgfVxuICAgIHJldHVybiByZXE7XG4gIH1cbn1cbiJdfQ==