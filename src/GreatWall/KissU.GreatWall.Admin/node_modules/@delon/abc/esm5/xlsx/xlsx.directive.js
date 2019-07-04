/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Directive, Input } from '@angular/core';
import { XlsxService } from './xlsx.service';
var XlsxDirective = /** @class */ (function () {
    function XlsxDirective(srv) {
        this.srv = srv;
    }
    /**
     * @return {?}
     */
    XlsxDirective.prototype._click = /**
     * @return {?}
     */
    function () {
        this.srv.export(this.data);
    };
    XlsxDirective.decorators = [
        { type: Directive, args: [{
                    selector: '[xlsx]',
                    host: {
                        '(click)': '_click()',
                    },
                    exportAs: 'xlsxDirective',
                },] }
    ];
    /** @nocollapse */
    XlsxDirective.ctorParameters = function () { return [
        { type: XlsxService }
    ]; };
    XlsxDirective.propDecorators = {
        data: [{ type: Input, args: ['xlsx',] }]
    };
    return XlsxDirective;
}());
export { XlsxDirective };
if (false) {
    /** @type {?} */
    XlsxDirective.prototype.data;
    /**
     * @type {?}
     * @private
     */
    XlsxDirective.prototype.srv;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoieGxzeC5kaXJlY3RpdmUuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL3hsc3gvIiwic291cmNlcyI6WyJ4bHN4LmRpcmVjdGl2ZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUFFLFNBQVMsRUFBRSxLQUFLLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFDakQsT0FBTyxFQUFFLFdBQVcsRUFBRSxNQUFNLGdCQUFnQixDQUFDO0FBRzdDO0lBVUUsdUJBQW9CLEdBQWdCO1FBQWhCLFFBQUcsR0FBSCxHQUFHLENBQWE7SUFBRyxDQUFDOzs7O0lBRXhDLDhCQUFNOzs7SUFBTjtRQUNFLElBQUksQ0FBQyxHQUFHLENBQUMsTUFBTSxDQUFDLElBQUksQ0FBQyxJQUFJLENBQUMsQ0FBQztJQUM3QixDQUFDOztnQkFkRixTQUFTLFNBQUM7b0JBQ1QsUUFBUSxFQUFFLFFBQVE7b0JBQ2xCLElBQUksRUFBRTt3QkFDSixTQUFTLEVBQUUsVUFBVTtxQkFDdEI7b0JBQ0QsUUFBUSxFQUFFLGVBQWU7aUJBQzFCOzs7O2dCQVRRLFdBQVc7Ozt1QkFXakIsS0FBSyxTQUFDLE1BQU07O0lBT2Ysb0JBQUM7Q0FBQSxBQWZELElBZUM7U0FSWSxhQUFhOzs7SUFDeEIsNkJBQXVDOzs7OztJQUUzQiw0QkFBd0IiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBEaXJlY3RpdmUsIElucHV0IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBYbHN4U2VydmljZSB9IGZyb20gJy4veGxzeC5zZXJ2aWNlJztcbmltcG9ydCB7IFhsc3hFeHBvcnRPcHRpb25zIH0gZnJvbSAnLi94bHN4LnR5cGVzJztcblxuQERpcmVjdGl2ZSh7XG4gIHNlbGVjdG9yOiAnW3hsc3hdJyxcbiAgaG9zdDoge1xuICAgICcoY2xpY2spJzogJ19jbGljaygpJyxcbiAgfSxcbiAgZXhwb3J0QXM6ICd4bHN4RGlyZWN0aXZlJyxcbn0pXG5leHBvcnQgY2xhc3MgWGxzeERpcmVjdGl2ZSB7XG4gIEBJbnB1dCgneGxzeCcpIGRhdGE6IFhsc3hFeHBvcnRPcHRpb25zO1xuXG4gIGNvbnN0cnVjdG9yKHByaXZhdGUgc3J2OiBYbHN4U2VydmljZSkge31cblxuICBfY2xpY2soKSB7XG4gICAgdGhpcy5zcnYuZXhwb3J0KHRoaXMuZGF0YSk7XG4gIH1cbn1cbiJdfQ==