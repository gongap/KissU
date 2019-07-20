/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Pipe } from '@angular/core';
import { numberToChinese } from './number-to-chinese';
var NaNumberToChinesePipe = /** @class */ (function () {
    function NaNumberToChinesePipe() {
    }
    /**
     * @param {?} value
     * @param {?=} rmb
     * @param {?=} minusSymbol
     * @return {?}
     */
    NaNumberToChinesePipe.prototype.transform = /**
     * @param {?} value
     * @param {?=} rmb
     * @param {?=} minusSymbol
     * @return {?}
     */
    function (value, rmb, minusSymbol) {
        if (rmb === void 0) { rmb = true; }
        if (minusSymbol === void 0) { minusSymbol = '负'; }
        return numberToChinese(value, rmb, { minusSymbol: minusSymbol });
    };
    NaNumberToChinesePipe.decorators = [
        { type: Pipe, args: [{ name: 'n2c' },] }
    ];
    return NaNumberToChinesePipe;
}());
export { NaNumberToChinesePipe };
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnVtYmVyLXRvLWNoaW5lc2UucGlwZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi9hYmMvbnVtYmVyLXRvLWNoaW5lc2UvIiwic291cmNlcyI6WyJudW1iZXItdG8tY2hpbmVzZS5waXBlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsSUFBSSxFQUFpQixNQUFNLGVBQWUsQ0FBQztBQUNwRCxPQUFPLEVBQUUsZUFBZSxFQUFFLE1BQU0scUJBQXFCLENBQUM7QUFFdEQ7SUFBQTtJQUtBLENBQUM7Ozs7Ozs7SUFIQyx5Q0FBUzs7Ozs7O0lBQVQsVUFBVSxLQUFzQixFQUFFLEdBQW1CLEVBQUUsV0FBeUI7UUFBOUMsb0JBQUEsRUFBQSxVQUFtQjtRQUFFLDRCQUFBLEVBQUEsaUJBQXlCO1FBQzlFLE9BQU8sZUFBZSxDQUFDLEtBQUssRUFBRSxHQUFHLEVBQUUsRUFBRSxXQUFXLGFBQUEsRUFBRSxDQUFDLENBQUM7SUFDdEQsQ0FBQzs7Z0JBSkYsSUFBSSxTQUFDLEVBQUUsSUFBSSxFQUFFLEtBQUssRUFBRTs7SUFLckIsNEJBQUM7Q0FBQSxBQUxELElBS0M7U0FKWSxxQkFBcUIiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBQaXBlLCBQaXBlVHJhbnNmb3JtIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBudW1iZXJUb0NoaW5lc2UgfSBmcm9tICcuL251bWJlci10by1jaGluZXNlJztcblxuQFBpcGUoeyBuYW1lOiAnbjJjJyB9KVxuZXhwb3J0IGNsYXNzIE5hTnVtYmVyVG9DaGluZXNlUGlwZSBpbXBsZW1lbnRzIFBpcGVUcmFuc2Zvcm0ge1xuICB0cmFuc2Zvcm0odmFsdWU6IG51bWJlciB8IHN0cmluZywgcm1iOiBib29sZWFuID0gdHJ1ZSwgbWludXNTeW1ib2w6IHN0cmluZyA9ICfotJ8nKTogc3RyaW5nIHtcbiAgICByZXR1cm4gbnVtYmVyVG9DaGluZXNlKHZhbHVlLCBybWIsIHsgbWludXNTeW1ib2wgfSk7XG4gIH1cbn1cbiJdfQ==