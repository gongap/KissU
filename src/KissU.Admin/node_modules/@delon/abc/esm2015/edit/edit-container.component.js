/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { toNumber, InputBoolean, InputNumber } from '@delon/util';
import { SEConfig } from './edit.config';
export class SEContainerComponent {
    // #endregion
    /**
     * @param {?} cog
     */
    constructor(cog) {
        this.line = false;
        Object.assign(this, Object.assign({}, new SEConfig(), cog));
    }
    /**
     * @return {?}
     */
    get gutter() {
        return this.nzLayout === 'horizontal' ? this._gutter : 0;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set gutter(value) {
        this._gutter = toNumber(value);
    }
    /**
     * @return {?}
     */
    get nzLayout() {
        return this._nzLayout;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set nzLayout(value) {
        this._nzLayout = value;
        if (value === 'inline') {
            this.size = 'compact';
        }
    }
}
SEContainerComponent.decorators = [
    { type: Component, args: [{
                selector: 'se-container, [se-container]',
                template: "<div class=\"ant-row se__container se__{{nzLayout}} se__{{size}}\"\n     [ngStyle]=\"{'margin-left.px': -(gutter / 2), 'margin-right.px': -(gutter / 2)}\">\n  <se-title *ngIf=\"title\">\n    <ng-container *stringTemplateOutlet=\"title\">{{ title }}</ng-container>\n  </se-title>\n  <ng-content></ng-content>\n</div>\n",
                changeDetection: ChangeDetectionStrategy.OnPush,
                exportAs: 'seContainer'
            }] }
];
/** @nocollapse */
SEContainerComponent.ctorParameters = () => [
    { type: SEConfig }
];
SEContainerComponent.propDecorators = {
    colInCon: [{ type: Input, args: ['se-container',] }],
    col: [{ type: Input }],
    labelWidth: [{ type: Input }],
    title: [{ type: Input }],
    gutter: [{ type: Input }],
    nzLayout: [{ type: Input }],
    size: [{ type: Input }],
    firstVisual: [{ type: Input }],
    line: [{ type: Input }]
};
tslib_1.__decorate([
    InputNumber(null),
    tslib_1.__metadata("design:type", Number)
], SEContainerComponent.prototype, "colInCon", void 0);
tslib_1.__decorate([
    InputNumber(null),
    tslib_1.__metadata("design:type", Number)
], SEContainerComponent.prototype, "col", void 0);
tslib_1.__decorate([
    InputNumber(null),
    tslib_1.__metadata("design:type", Number)
], SEContainerComponent.prototype, "labelWidth", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], SEContainerComponent.prototype, "firstVisual", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], SEContainerComponent.prototype, "line", void 0);
if (false) {
    /** @type {?} */
    SEContainerComponent.prototype.colInCon;
    /** @type {?} */
    SEContainerComponent.prototype.col;
    /** @type {?} */
    SEContainerComponent.prototype.labelWidth;
    /** @type {?} */
    SEContainerComponent.prototype.title;
    /**
     * @type {?}
     * @private
     */
    SEContainerComponent.prototype._gutter;
    /**
     * @type {?}
     * @private
     */
    SEContainerComponent.prototype._nzLayout;
    /** @type {?} */
    SEContainerComponent.prototype.size;
    /** @type {?} */
    SEContainerComponent.prototype.firstVisual;
    /** @type {?} */
    SEContainerComponent.prototype.line;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiZWRpdC1jb250YWluZXIuY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy9lZGl0LyIsInNvdXJjZXMiOlsiZWRpdC1jb250YWluZXIuY29tcG9uZW50LnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7O0FBQUEsT0FBTyxFQUFFLHVCQUF1QixFQUFFLFNBQVMsRUFBRSxLQUFLLEVBQWUsTUFBTSxlQUFlLENBQUM7QUFFdkYsT0FBTyxFQUFFLFFBQVEsRUFBRSxZQUFZLEVBQUUsV0FBVyxFQUFFLE1BQU0sYUFBYSxDQUFDO0FBQ2xFLE9BQU8sRUFBRSxRQUFRLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFRekMsTUFBTSxPQUFPLG9CQUFvQjs7Ozs7SUFtQy9CLFlBQVksR0FBYTtRQUpBLFNBQUksR0FBRyxLQUFLLENBQUM7UUFLcEMsTUFBTSxDQUFDLE1BQU0sQ0FBQyxJQUFJLG9CQUFPLElBQUksUUFBUSxFQUFFLEVBQUssR0FBRyxFQUFHLENBQUM7SUFDckQsQ0FBQzs7OztJQTdCRCxJQUNJLE1BQU07UUFDUixPQUFPLElBQUksQ0FBQyxRQUFRLEtBQUssWUFBWSxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsT0FBTyxDQUFDLENBQUMsQ0FBQyxDQUFDLENBQUM7SUFDM0QsQ0FBQzs7Ozs7SUFDRCxJQUFJLE1BQU0sQ0FBQyxLQUFhO1FBQ3RCLElBQUksQ0FBQyxPQUFPLEdBQUcsUUFBUSxDQUFDLEtBQUssQ0FBQyxDQUFDO0lBQ2pDLENBQUM7Ozs7SUFHRCxJQUNJLFFBQVE7UUFDVixPQUFPLElBQUksQ0FBQyxTQUFTLENBQUM7SUFDeEIsQ0FBQzs7Ozs7SUFDRCxJQUFJLFFBQVEsQ0FBQyxLQUFhO1FBQ3hCLElBQUksQ0FBQyxTQUFTLEdBQUcsS0FBSyxDQUFDO1FBQ3ZCLElBQUksS0FBSyxLQUFLLFFBQVEsRUFBRTtZQUN0QixJQUFJLENBQUMsSUFBSSxHQUFHLFNBQVMsQ0FBQztTQUN2QjtJQUNILENBQUM7OztZQWhDRixTQUFTLFNBQUM7Z0JBQ1QsUUFBUSxFQUFFLDhCQUE4QjtnQkFDeEMseVVBQThDO2dCQUM5QyxlQUFlLEVBQUUsdUJBQXVCLENBQUMsTUFBTTtnQkFDL0MsUUFBUSxFQUFFLGFBQWE7YUFDeEI7Ozs7WUFQUSxRQUFROzs7dUJBV2QsS0FBSyxTQUFDLGNBQWM7a0JBQ3BCLEtBQUs7eUJBQ0wsS0FBSztvQkFDTCxLQUFLO3FCQUVMLEtBQUs7dUJBU0wsS0FBSzttQkFZTCxLQUFLOzBCQUNMLEtBQUs7bUJBQ0wsS0FBSzs7QUE1Qm9DO0lBQWxCLFdBQVcsQ0FBQyxJQUFJLENBQUM7O3NEQUFvQjtBQUNqQztJQUFsQixXQUFXLENBQUMsSUFBSSxDQUFDOztpREFBZTtBQUNkO0lBQWxCLFdBQVcsQ0FBQyxJQUFJLENBQUM7O3dEQUFvQjtBQXlCdEI7SUFBZixZQUFZLEVBQUU7O3lEQUFzQjtBQUNyQjtJQUFmLFlBQVksRUFBRTs7a0RBQWM7OztJQTVCdEMsd0NBQTZEOztJQUM3RCxtQ0FBMEM7O0lBQzFDLDBDQUErQzs7SUFDL0MscUNBQTJDOzs7OztJQVMzQyx1Q0FBd0I7Ozs7O0lBWXhCLHlDQUEwQjs7SUFFMUIsb0NBQXFDOztJQUNyQywyQ0FBOEM7O0lBQzlDLG9DQUFzQyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IENoYW5nZURldGVjdGlvblN0cmF0ZWd5LCBDb21wb25lbnQsIElucHV0LCBUZW1wbGF0ZVJlZiB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgUkVQX1RZUEUgfSBmcm9tICdAZGVsb24vdGhlbWUnO1xuaW1wb3J0IHsgdG9OdW1iZXIsIElucHV0Qm9vbGVhbiwgSW5wdXROdW1iZXIgfSBmcm9tICdAZGVsb24vdXRpbCc7XG5pbXBvcnQgeyBTRUNvbmZpZyB9IGZyb20gJy4vZWRpdC5jb25maWcnO1xuXG5AQ29tcG9uZW50KHtcbiAgc2VsZWN0b3I6ICdzZS1jb250YWluZXIsIFtzZS1jb250YWluZXJdJyxcbiAgdGVtcGxhdGVVcmw6ICcuL2VkaXQtY29udGFpbmVyLmNvbXBvbmVudC5odG1sJyxcbiAgY2hhbmdlRGV0ZWN0aW9uOiBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneS5PblB1c2gsXG4gIGV4cG9ydEFzOiAnc2VDb250YWluZXInLFxufSlcbmV4cG9ydCBjbGFzcyBTRUNvbnRhaW5lckNvbXBvbmVudCB7XG4gIC8vICNyZWdpb24gZmllbGRzXG5cbiAgQElucHV0KCdzZS1jb250YWluZXInKSBASW5wdXROdW1iZXIobnVsbCkgY29sSW5Db246IFJFUF9UWVBFO1xuICBASW5wdXQoKSBASW5wdXROdW1iZXIobnVsbCkgY29sOiBSRVBfVFlQRTtcbiAgQElucHV0KCkgQElucHV0TnVtYmVyKG51bGwpIGxhYmVsV2lkdGg6IG51bWJlcjtcbiAgQElucHV0KCkgdGl0bGU6IHN0cmluZyB8IFRlbXBsYXRlUmVmPHZvaWQ+O1xuXG4gIEBJbnB1dCgpXG4gIGdldCBndXR0ZXIoKTogbnVtYmVyIHtcbiAgICByZXR1cm4gdGhpcy5uekxheW91dCA9PT0gJ2hvcml6b250YWwnID8gdGhpcy5fZ3V0dGVyIDogMDtcbiAgfVxuICBzZXQgZ3V0dGVyKHZhbHVlOiBudW1iZXIpIHtcbiAgICB0aGlzLl9ndXR0ZXIgPSB0b051bWJlcih2YWx1ZSk7XG4gIH1cbiAgcHJpdmF0ZSBfZ3V0dGVyOiBudW1iZXI7XG5cbiAgQElucHV0KClcbiAgZ2V0IG56TGF5b3V0KCkge1xuICAgIHJldHVybiB0aGlzLl9uekxheW91dDtcbiAgfVxuICBzZXQgbnpMYXlvdXQodmFsdWU6IHN0cmluZykge1xuICAgIHRoaXMuX256TGF5b3V0ID0gdmFsdWU7XG4gICAgaWYgKHZhbHVlID09PSAnaW5saW5lJykge1xuICAgICAgdGhpcy5zaXplID0gJ2NvbXBhY3QnO1xuICAgIH1cbiAgfVxuICBwcml2YXRlIF9uekxheW91dDogc3RyaW5nO1xuXG4gIEBJbnB1dCgpIHNpemU6ICdkZWZhdWx0JyB8ICdjb21wYWN0JztcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIGZpcnN0VmlzdWFsOiBib29sZWFuO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbGluZSA9IGZhbHNlO1xuXG4gIC8vICNlbmRyZWdpb25cblxuICBjb25zdHJ1Y3Rvcihjb2c6IFNFQ29uZmlnKSB7XG4gICAgT2JqZWN0LmFzc2lnbih0aGlzLCB7IC4uLm5ldyBTRUNvbmZpZygpLCAuLi5jb2cgfSk7XG4gIH1cbn1cbiJdfQ==