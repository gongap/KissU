/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Pipe } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
var HTMLPipe = /** @class */ (function () {
    function HTMLPipe(dom) {
        this.dom = dom;
    }
    /**
     * @param {?} html
     * @return {?}
     */
    HTMLPipe.prototype.transform = /**
     * @param {?} html
     * @return {?}
     */
    function (html) {
        return html ? this.dom.bypassSecurityTrustHtml(html) : '';
    };
    HTMLPipe.decorators = [
        { type: Pipe, args: [{ name: 'html' },] }
    ];
    /** @nocollapse */
    HTMLPipe.ctorParameters = function () { return [
        { type: DomSanitizer }
    ]; };
    return HTMLPipe;
}());
export { HTMLPipe };
if (false) {
    /**
     * @type {?}
     * @private
     */
    HTMLPipe.prototype.dom;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiaHRtbC5waXBlLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL3RoZW1lLyIsInNvdXJjZXMiOlsic3JjL3BpcGVzL3NhZmUvaHRtbC5waXBlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsSUFBSSxFQUFpQixNQUFNLGVBQWUsQ0FBQztBQUNwRCxPQUFPLEVBQUUsWUFBWSxFQUFZLE1BQU0sMkJBQTJCLENBQUM7QUFFbkU7SUFFRSxrQkFBb0IsR0FBaUI7UUFBakIsUUFBRyxHQUFILEdBQUcsQ0FBYztJQUFJLENBQUM7Ozs7O0lBRTFDLDRCQUFTOzs7O0lBQVQsVUFBVSxJQUFZO1FBQ3BCLE9BQU8sSUFBSSxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsR0FBRyxDQUFDLHVCQUF1QixDQUFDLElBQUksQ0FBQyxDQUFDLENBQUMsQ0FBQyxFQUFFLENBQUM7SUFDNUQsQ0FBQzs7Z0JBTkYsSUFBSSxTQUFDLEVBQUUsSUFBSSxFQUFFLE1BQU0sRUFBRTs7OztnQkFGYixZQUFZOztJQVNyQixlQUFDO0NBQUEsQUFQRCxJQU9DO1NBTlksUUFBUTs7Ozs7O0lBQ1AsdUJBQXlCIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgUGlwZSwgUGlwZVRyYW5zZm9ybSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgRG9tU2FuaXRpemVyLCBTYWZlSHRtbCB9IGZyb20gJ0Bhbmd1bGFyL3BsYXRmb3JtLWJyb3dzZXInO1xuXG5AUGlwZSh7IG5hbWU6ICdodG1sJyB9KVxuZXhwb3J0IGNsYXNzIEhUTUxQaXBlIGltcGxlbWVudHMgUGlwZVRyYW5zZm9ybSB7XG4gIGNvbnN0cnVjdG9yKHByaXZhdGUgZG9tOiBEb21TYW5pdGl6ZXIpIHsgfVxuXG4gIHRyYW5zZm9ybShodG1sOiBzdHJpbmcpOiBzdHJpbmcgfCBTYWZlSHRtbCB7XG4gICAgcmV0dXJuIGh0bWwgPyB0aGlzLmRvbS5ieXBhc3NTZWN1cml0eVRydXN0SHRtbChodG1sKSA6ICcnO1xuICB9XG59XG4iXX0=