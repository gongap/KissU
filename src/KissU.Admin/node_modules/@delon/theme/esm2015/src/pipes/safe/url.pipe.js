/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Pipe } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
export class URLPipe {
    /**
     * @param {?} dom
     */
    constructor(dom) {
        this.dom = dom;
    }
    /**
     * @param {?} url
     * @return {?}
     */
    transform(url) {
        return url ? this.dom.bypassSecurityTrustUrl(url) : '';
    }
}
URLPipe.decorators = [
    { type: Pipe, args: [{ name: 'url' },] }
];
/** @nocollapse */
URLPipe.ctorParameters = () => [
    { type: DomSanitizer }
];
if (false) {
    /**
     * @type {?}
     * @private
     */
    URLPipe.prototype.dom;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidXJsLnBpcGUuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vdGhlbWUvIiwic291cmNlcyI6WyJzcmMvcGlwZXMvc2FmZS91cmwucGlwZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUFFLElBQUksRUFBaUIsTUFBTSxlQUFlLENBQUM7QUFDcEQsT0FBTyxFQUFFLFlBQVksRUFBVyxNQUFNLDJCQUEyQixDQUFDO0FBR2xFLE1BQU0sT0FBTyxPQUFPOzs7O0lBQ2xCLFlBQW9CLEdBQWlCO1FBQWpCLFFBQUcsR0FBSCxHQUFHLENBQWM7SUFBSSxDQUFDOzs7OztJQUUxQyxTQUFTLENBQUMsR0FBVztRQUNuQixPQUFPLEdBQUcsQ0FBQyxDQUFDLENBQUMsSUFBSSxDQUFDLEdBQUcsQ0FBQyxzQkFBc0IsQ0FBQyxHQUFHLENBQUMsQ0FBQyxDQUFDLENBQUMsRUFBRSxDQUFDO0lBQ3pELENBQUM7OztZQU5GLElBQUksU0FBQyxFQUFFLElBQUksRUFBRSxLQUFLLEVBQUU7Ozs7WUFGWixZQUFZOzs7Ozs7O0lBSVAsc0JBQXlCIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgUGlwZSwgUGlwZVRyYW5zZm9ybSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgRG9tU2FuaXRpemVyLCBTYWZlVXJsIH0gZnJvbSAnQGFuZ3VsYXIvcGxhdGZvcm0tYnJvd3Nlcic7XG5cbkBQaXBlKHsgbmFtZTogJ3VybCcgfSlcbmV4cG9ydCBjbGFzcyBVUkxQaXBlIGltcGxlbWVudHMgUGlwZVRyYW5zZm9ybSB7XG4gIGNvbnN0cnVjdG9yKHByaXZhdGUgZG9tOiBEb21TYW5pdGl6ZXIpIHsgfVxuXG4gIHRyYW5zZm9ybSh1cmw6IHN0cmluZyk6IHN0cmluZyB8IFNhZmVVcmwge1xuICAgIHJldHVybiB1cmwgPyB0aGlzLmRvbS5ieXBhc3NTZWN1cml0eVRydXN0VXJsKHVybCkgOiAnJztcbiAgfVxufVxuIl19