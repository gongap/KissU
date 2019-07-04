/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output, } from '@angular/core';
import { InputNumber } from '@delon/util';
import { QRConfig } from './qr.config';
import { QRService } from './qr.service';
var QRComponent = /** @class */ (function () {
    // #endregion
    function QRComponent(cog, srv, cdr) {
        this.srv = srv;
        this.cdr = cdr;
        this.change = new EventEmitter();
        Object.assign(this, tslib_1.__assign({}, new QRConfig(), cog));
    }
    /**
     * @return {?}
     */
    QRComponent.prototype.ngOnChanges = /**
     * @return {?}
     */
    function () {
        this.dataURL = this.srv.refresh({
            background: this.background,
            backgroundAlpha: this.backgroundAlpha,
            foreground: this.foreground,
            foregroundAlpha: this.foregroundAlpha,
            level: this.level,
            mime: this.mime,
            padding: this.padding,
            size: this.size,
            value: this.value,
        });
        this.cdr.detectChanges();
        this.change.emit(this.dataURL);
    };
    QRComponent.decorators = [
        { type: Component, args: [{
                    selector: 'qr',
                    template: "\n    <img class=\"qr__img\" src=\"{{ dataURL }}\" />\n  ",
                    host: {
                        '[class.qr]': 'true',
                        '[style.height.px]': 'size',
                        '[style.width.px]': 'size',
                    },
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    QRComponent.ctorParameters = function () { return [
        { type: QRConfig },
        { type: QRService },
        { type: ChangeDetectorRef }
    ]; };
    QRComponent.propDecorators = {
        background: [{ type: Input }],
        backgroundAlpha: [{ type: Input }],
        foreground: [{ type: Input }],
        foregroundAlpha: [{ type: Input }],
        level: [{ type: Input }],
        mime: [{ type: Input }],
        padding: [{ type: Input }],
        size: [{ type: Input }],
        value: [{ type: Input }],
        change: [{ type: Output }]
    };
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Number)
    ], QRComponent.prototype, "padding", void 0);
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Number)
    ], QRComponent.prototype, "size", void 0);
    return QRComponent;
}());
export { QRComponent };
if (false) {
    /** @type {?} */
    QRComponent.prototype.dataURL;
    /** @type {?} */
    QRComponent.prototype.background;
    /** @type {?} */
    QRComponent.prototype.backgroundAlpha;
    /** @type {?} */
    QRComponent.prototype.foreground;
    /** @type {?} */
    QRComponent.prototype.foregroundAlpha;
    /** @type {?} */
    QRComponent.prototype.level;
    /** @type {?} */
    QRComponent.prototype.mime;
    /** @type {?} */
    QRComponent.prototype.padding;
    /** @type {?} */
    QRComponent.prototype.size;
    /** @type {?} */
    QRComponent.prototype.value;
    /** @type {?} */
    QRComponent.prototype.change;
    /**
     * @type {?}
     * @private
     */
    QRComponent.prototype.srv;
    /**
     * @type {?}
     * @private
     */
    QRComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicXIuY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy9xci8iLCJzb3VyY2VzIjpbInFyLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7OztBQUFBLE9BQU8sRUFDTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxZQUFZLEVBQ1osS0FBSyxFQUVMLE1BQU0sR0FDUCxNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQUUsV0FBVyxFQUFFLE1BQU0sYUFBYSxDQUFDO0FBRTFDLE9BQU8sRUFBRSxRQUFRLEVBQUUsTUFBTSxhQUFhLENBQUM7QUFDdkMsT0FBTyxFQUFFLFNBQVMsRUFBRSxNQUFNLGNBQWMsQ0FBQztBQUV6QztJQTRCRSxhQUFhO0lBRWIscUJBQVksR0FBYSxFQUFVLEdBQWMsRUFBVSxHQUFzQjtRQUE5QyxRQUFHLEdBQUgsR0FBRyxDQUFXO1FBQVUsUUFBRyxHQUFILEdBQUcsQ0FBbUI7UUFKOUQsV0FBTSxHQUFHLElBQUksWUFBWSxFQUFVLENBQUM7UUFLckQsTUFBTSxDQUFDLE1BQU0sQ0FBQyxJQUFJLHVCQUFPLElBQUksUUFBUSxFQUFFLEVBQUssR0FBRyxFQUFHLENBQUM7SUFDckQsQ0FBQzs7OztJQUVELGlDQUFXOzs7SUFBWDtRQUNFLElBQUksQ0FBQyxPQUFPLEdBQUcsSUFBSSxDQUFDLEdBQUcsQ0FBQyxPQUFPLENBQUM7WUFDOUIsVUFBVSxFQUFFLElBQUksQ0FBQyxVQUFVO1lBQzNCLGVBQWUsRUFBRSxJQUFJLENBQUMsZUFBZTtZQUNyQyxVQUFVLEVBQUUsSUFBSSxDQUFDLFVBQVU7WUFDM0IsZUFBZSxFQUFFLElBQUksQ0FBQyxlQUFlO1lBQ3JDLEtBQUssRUFBRSxJQUFJLENBQUMsS0FBSztZQUNqQixJQUFJLEVBQUUsSUFBSSxDQUFDLElBQUk7WUFDZixPQUFPLEVBQUUsSUFBSSxDQUFDLE9BQU87WUFDckIsSUFBSSxFQUFFLElBQUksQ0FBQyxJQUFJO1lBQ2YsS0FBSyxFQUFFLElBQUksQ0FBQyxLQUFLO1NBQ2xCLENBQUMsQ0FBQztRQUNILElBQUksQ0FBQyxHQUFHLENBQUMsYUFBYSxFQUFFLENBQUM7UUFDekIsSUFBSSxDQUFDLE1BQU0sQ0FBQyxJQUFJLENBQUMsSUFBSSxDQUFDLE9BQU8sQ0FBQyxDQUFDO0lBQ2pDLENBQUM7O2dCQWhERixTQUFTLFNBQUM7b0JBQ1QsUUFBUSxFQUFFLElBQUk7b0JBQ2QsUUFBUSxFQUFFLDJEQUVUO29CQUNELElBQUksRUFBRTt3QkFDSixZQUFZLEVBQUUsTUFBTTt3QkFDcEIsbUJBQW1CLEVBQUUsTUFBTTt3QkFDM0Isa0JBQWtCLEVBQUUsTUFBTTtxQkFDM0I7b0JBQ0QsZUFBZSxFQUFFLHVCQUF1QixDQUFDLE1BQU07aUJBQ2hEOzs7O2dCQWRRLFFBQVE7Z0JBQ1IsU0FBUztnQkFWaEIsaUJBQWlCOzs7NkJBNkJoQixLQUFLO2tDQUNMLEtBQUs7NkJBQ0wsS0FBSztrQ0FDTCxLQUFLO3dCQUNMLEtBQUs7dUJBQ0wsS0FBSzswQkFDTCxLQUFLO3VCQUNMLEtBQUs7d0JBQ0wsS0FBSzt5QkFDTCxNQUFNOztJQUhpQjtRQUFkLFdBQVcsRUFBRTs7Z0RBQWlCO0lBQ2hCO1FBQWQsV0FBVyxFQUFFOzs2Q0FBYztJQXlCdkMsa0JBQUM7Q0FBQSxBQWpERCxJQWlEQztTQXJDWSxXQUFXOzs7SUFDdEIsOEJBQWdCOztJQUloQixpQ0FBNEI7O0lBQzVCLHNDQUFpQzs7SUFDakMsaUNBQTRCOztJQUM1QixzQ0FBaUM7O0lBQ2pDLDRCQUF1Qjs7SUFDdkIsMkJBQXNCOztJQUN0Qiw4QkFBd0M7O0lBQ3hDLDJCQUFxQzs7SUFDckMsNEJBQXVCOztJQUN2Qiw2QkFBdUQ7Ozs7O0lBSTVCLDBCQUFzQjs7Ozs7SUFBRSwwQkFBOEIiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gIENvbXBvbmVudCxcbiAgRXZlbnRFbWl0dGVyLFxuICBJbnB1dCxcbiAgT25DaGFuZ2VzLFxuICBPdXRwdXQsXG59IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgSW5wdXROdW1iZXIgfSBmcm9tICdAZGVsb24vdXRpbCc7XG5cbmltcG9ydCB7IFFSQ29uZmlnIH0gZnJvbSAnLi9xci5jb25maWcnO1xuaW1wb3J0IHsgUVJTZXJ2aWNlIH0gZnJvbSAnLi9xci5zZXJ2aWNlJztcblxuQENvbXBvbmVudCh7XG4gIHNlbGVjdG9yOiAncXInLFxuICB0ZW1wbGF0ZTogYFxuICAgIDxpbWcgY2xhc3M9XCJxcl9faW1nXCIgc3JjPVwie3sgZGF0YVVSTCB9fVwiIC8+XG4gIGAsXG4gIGhvc3Q6IHtcbiAgICAnW2NsYXNzLnFyXSc6ICd0cnVlJyxcbiAgICAnW3N0eWxlLmhlaWdodC5weF0nOiAnc2l6ZScsXG4gICAgJ1tzdHlsZS53aWR0aC5weF0nOiAnc2l6ZScsXG4gIH0sXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxufSlcbmV4cG9ydCBjbGFzcyBRUkNvbXBvbmVudCBpbXBsZW1lbnRzIE9uQ2hhbmdlcyB7XG4gIGRhdGFVUkw6IHN0cmluZztcblxuICAvLyAjcmVnaW9uIGZpZWxkc1xuXG4gIEBJbnB1dCgpIGJhY2tncm91bmQ6IHN0cmluZztcbiAgQElucHV0KCkgYmFja2dyb3VuZEFscGhhOiBudW1iZXI7XG4gIEBJbnB1dCgpIGZvcmVncm91bmQ6IHN0cmluZztcbiAgQElucHV0KCkgZm9yZWdyb3VuZEFscGhhOiBudW1iZXI7XG4gIEBJbnB1dCgpIGxldmVsOiBzdHJpbmc7XG4gIEBJbnB1dCgpIG1pbWU6IHN0cmluZztcbiAgQElucHV0KCkgQElucHV0TnVtYmVyKCkgcGFkZGluZzogbnVtYmVyO1xuICBASW5wdXQoKSBASW5wdXROdW1iZXIoKSBzaXplOiBudW1iZXI7XG4gIEBJbnB1dCgpIHZhbHVlOiBzdHJpbmc7XG4gIEBPdXRwdXQoKSByZWFkb25seSBjaGFuZ2UgPSBuZXcgRXZlbnRFbWl0dGVyPHN0cmluZz4oKTtcblxuICAvLyAjZW5kcmVnaW9uXG5cbiAgY29uc3RydWN0b3IoY29nOiBRUkNvbmZpZywgcHJpdmF0ZSBzcnY6IFFSU2VydmljZSwgcHJpdmF0ZSBjZHI6IENoYW5nZURldGVjdG9yUmVmKSB7XG4gICAgT2JqZWN0LmFzc2lnbih0aGlzLCB7IC4uLm5ldyBRUkNvbmZpZygpLCAuLi5jb2cgfSk7XG4gIH1cblxuICBuZ09uQ2hhbmdlcygpOiB2b2lkIHtcbiAgICB0aGlzLmRhdGFVUkwgPSB0aGlzLnNydi5yZWZyZXNoKHtcbiAgICAgIGJhY2tncm91bmQ6IHRoaXMuYmFja2dyb3VuZCxcbiAgICAgIGJhY2tncm91bmRBbHBoYTogdGhpcy5iYWNrZ3JvdW5kQWxwaGEsXG4gICAgICBmb3JlZ3JvdW5kOiB0aGlzLmZvcmVncm91bmQsXG4gICAgICBmb3JlZ3JvdW5kQWxwaGE6IHRoaXMuZm9yZWdyb3VuZEFscGhhLFxuICAgICAgbGV2ZWw6IHRoaXMubGV2ZWwsXG4gICAgICBtaW1lOiB0aGlzLm1pbWUsXG4gICAgICBwYWRkaW5nOiB0aGlzLnBhZGRpbmcsXG4gICAgICBzaXplOiB0aGlzLnNpemUsXG4gICAgICB2YWx1ZTogdGhpcy52YWx1ZSxcbiAgICB9KTtcbiAgICB0aGlzLmNkci5kZXRlY3RDaGFuZ2VzKCk7XG4gICAgdGhpcy5jaGFuZ2UuZW1pdCh0aGlzLmRhdGFVUkwpO1xuICB9XG59XG4iXX0=