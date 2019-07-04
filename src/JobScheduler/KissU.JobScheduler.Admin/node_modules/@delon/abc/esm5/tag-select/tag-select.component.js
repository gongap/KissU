/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output, } from '@angular/core';
import { DelonLocaleService } from '@delon/theme';
import { InputBoolean } from '@delon/util';
var TagSelectComponent = /** @class */ (function () {
    function TagSelectComponent(i18n, cdr) {
        this.i18n = i18n;
        this.cdr = cdr;
        this.locale = {};
        this.expand = false;
        /**
         * 是否启用 `展开与收进`
         */
        this.expandable = true;
        this.change = new EventEmitter();
    }
    /**
     * @return {?}
     */
    TagSelectComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        this.i18n$ = this.i18n.change.subscribe((/**
         * @return {?}
         */
        function () {
            _this.locale = _this.i18n.getData('tagSelect');
            _this.cdr.detectChanges();
        }));
    };
    /**
     * @return {?}
     */
    TagSelectComponent.prototype.trigger = /**
     * @return {?}
     */
    function () {
        this.expand = !this.expand;
        this.change.emit(this.expand);
    };
    /**
     * @return {?}
     */
    TagSelectComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.i18n$.unsubscribe();
    };
    TagSelectComponent.decorators = [
        { type: Component, args: [{
                    selector: 'tag-select',
                    template: "<ng-content></ng-content>\n<a *ngIf=\"expandable\" class=\"tag-select__trigger\" (click)=\"trigger()\">\n  {{expand ? locale.collapse : locale.expand}}<i nz-icon [type]=\"expand ? 'up' : 'down'\" class=\"tag-select__trigger-icon\"></i>\n</a>\n",
                    host: {
                        '[class.tag-select]': 'true',
                        '[class.tag-select__has-expand]': 'expandable',
                        '[class.tag-select__expanded]': 'expand',
                    },
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    TagSelectComponent.ctorParameters = function () { return [
        { type: DelonLocaleService },
        { type: ChangeDetectorRef }
    ]; };
    TagSelectComponent.propDecorators = {
        expandable: [{ type: Input }],
        change: [{ type: Output }]
    };
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], TagSelectComponent.prototype, "expandable", void 0);
    return TagSelectComponent;
}());
export { TagSelectComponent };
if (false) {
    /**
     * @type {?}
     * @private
     */
    TagSelectComponent.prototype.i18n$;
    /** @type {?} */
    TagSelectComponent.prototype.locale;
    /** @type {?} */
    TagSelectComponent.prototype.expand;
    /**
     * 是否启用 `展开与收进`
     * @type {?}
     */
    TagSelectComponent.prototype.expandable;
    /** @type {?} */
    TagSelectComponent.prototype.change;
    /**
     * @type {?}
     * @private
     */
    TagSelectComponent.prototype.i18n;
    /**
     * @type {?}
     * @private
     */
    TagSelectComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidGFnLXNlbGVjdC5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL3RhZy1zZWxlY3QvIiwic291cmNlcyI6WyJ0YWctc2VsZWN0LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7OztBQUFBLE9BQU8sRUFDTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxZQUFZLEVBQ1osS0FBSyxFQUdMLE1BQU0sR0FDUCxNQUFNLGVBQWUsQ0FBQztBQUd2QixPQUFPLEVBQUUsa0JBQWtCLEVBQWMsTUFBTSxjQUFjLENBQUM7QUFDOUQsT0FBTyxFQUFFLFlBQVksRUFBRSxNQUFNLGFBQWEsQ0FBQztBQUUzQztJQW1CRSw0QkFBb0IsSUFBd0IsRUFBVSxHQUFzQjtRQUF4RCxTQUFJLEdBQUosSUFBSSxDQUFvQjtRQUFVLFFBQUcsR0FBSCxHQUFHLENBQW1CO1FBUDVFLFdBQU0sR0FBZSxFQUFFLENBQUM7UUFDeEIsV0FBTSxHQUFHLEtBQUssQ0FBQzs7OztRQUdVLGVBQVUsR0FBRyxJQUFJLENBQUM7UUFDeEIsV0FBTSxHQUFHLElBQUksWUFBWSxFQUFXLENBQUM7SUFFdUIsQ0FBQzs7OztJQUVoRixxQ0FBUTs7O0lBQVI7UUFBQSxpQkFLQztRQUpDLElBQUksQ0FBQyxLQUFLLEdBQUcsSUFBSSxDQUFDLElBQUksQ0FBQyxNQUFNLENBQUMsU0FBUzs7O1FBQUM7WUFDdEMsS0FBSSxDQUFDLE1BQU0sR0FBRyxLQUFJLENBQUMsSUFBSSxDQUFDLE9BQU8sQ0FBQyxXQUFXLENBQUMsQ0FBQztZQUM3QyxLQUFJLENBQUMsR0FBRyxDQUFDLGFBQWEsRUFBRSxDQUFDO1FBQzNCLENBQUMsRUFBQyxDQUFDO0lBQ0wsQ0FBQzs7OztJQUVELG9DQUFPOzs7SUFBUDtRQUNFLElBQUksQ0FBQyxNQUFNLEdBQUcsQ0FBQyxJQUFJLENBQUMsTUFBTSxDQUFDO1FBQzNCLElBQUksQ0FBQyxNQUFNLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxNQUFNLENBQUMsQ0FBQztJQUNoQyxDQUFDOzs7O0lBRUQsd0NBQVc7OztJQUFYO1FBQ0UsSUFBSSxDQUFDLEtBQUssQ0FBQyxXQUFXLEVBQUUsQ0FBQztJQUMzQixDQUFDOztnQkFuQ0YsU0FBUyxTQUFDO29CQUNULFFBQVEsRUFBRSxZQUFZO29CQUN0QiwrUEFBMEM7b0JBQzFDLElBQUksRUFBRTt3QkFDSixvQkFBb0IsRUFBRSxNQUFNO3dCQUM1QixnQ0FBZ0MsRUFBRSxZQUFZO3dCQUM5Qyw4QkFBOEIsRUFBRSxRQUFRO3FCQUN6QztvQkFDRCxlQUFlLEVBQUUsdUJBQXVCLENBQUMsTUFBTTtpQkFDaEQ7Ozs7Z0JBWlEsa0JBQWtCO2dCQVZ6QixpQkFBaUI7Ozs2QkE2QmhCLEtBQUs7eUJBQ0wsTUFBTTs7SUFEa0I7UUFBZixZQUFZLEVBQUU7OzBEQUFtQjtJQW9CN0MseUJBQUM7Q0FBQSxBQXBDRCxJQW9DQztTQTFCWSxrQkFBa0I7Ozs7OztJQUM3QixtQ0FBNEI7O0lBQzVCLG9DQUF3Qjs7SUFDeEIsb0NBQWU7Ozs7O0lBR2Ysd0NBQTJDOztJQUMzQyxvQ0FBd0Q7Ozs7O0lBRTVDLGtDQUFnQzs7Ozs7SUFBRSxpQ0FBOEIiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gIENvbXBvbmVudCxcbiAgRXZlbnRFbWl0dGVyLFxuICBJbnB1dCxcbiAgT25EZXN0cm95LFxuICBPbkluaXQsXG4gIE91dHB1dCxcbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBTdWJzY3JpcHRpb24gfSBmcm9tICdyeGpzJztcblxuaW1wb3J0IHsgRGVsb25Mb2NhbGVTZXJ2aWNlLCBMb2NhbGVEYXRhIH0gZnJvbSAnQGRlbG9uL3RoZW1lJztcbmltcG9ydCB7IElucHV0Qm9vbGVhbiB9IGZyb20gJ0BkZWxvbi91dGlsJztcblxuQENvbXBvbmVudCh7XG4gIHNlbGVjdG9yOiAndGFnLXNlbGVjdCcsXG4gIHRlbXBsYXRlVXJsOiAnLi90YWctc2VsZWN0LmNvbXBvbmVudC5odG1sJyxcbiAgaG9zdDoge1xuICAgICdbY2xhc3MudGFnLXNlbGVjdF0nOiAndHJ1ZScsXG4gICAgJ1tjbGFzcy50YWctc2VsZWN0X19oYXMtZXhwYW5kXSc6ICdleHBhbmRhYmxlJyxcbiAgICAnW2NsYXNzLnRhZy1zZWxlY3RfX2V4cGFuZGVkXSc6ICdleHBhbmQnLFxuICB9LFxuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbn0pXG5leHBvcnQgY2xhc3MgVGFnU2VsZWN0Q29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0LCBPbkRlc3Ryb3kge1xuICBwcml2YXRlIGkxOG4kOiBTdWJzY3JpcHRpb247XG4gIGxvY2FsZTogTG9jYWxlRGF0YSA9IHt9O1xuICBleHBhbmQgPSBmYWxzZTtcblxuICAvKiog5piv5ZCm5ZCv55SoIGDlsZXlvIDkuI7mlLbov5tgICovXG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBleHBhbmRhYmxlID0gdHJ1ZTtcbiAgQE91dHB1dCgpIHJlYWRvbmx5IGNoYW5nZSA9IG5ldyBFdmVudEVtaXR0ZXI8Ym9vbGVhbj4oKTtcblxuICBjb25zdHJ1Y3Rvcihwcml2YXRlIGkxOG46IERlbG9uTG9jYWxlU2VydmljZSwgcHJpdmF0ZSBjZHI6IENoYW5nZURldGVjdG9yUmVmKSB7fVxuXG4gIG5nT25Jbml0KCkge1xuICAgIHRoaXMuaTE4biQgPSB0aGlzLmkxOG4uY2hhbmdlLnN1YnNjcmliZSgoKSA9PiB7XG4gICAgICB0aGlzLmxvY2FsZSA9IHRoaXMuaTE4bi5nZXREYXRhKCd0YWdTZWxlY3QnKTtcbiAgICAgIHRoaXMuY2RyLmRldGVjdENoYW5nZXMoKTtcbiAgICB9KTtcbiAgfVxuXG4gIHRyaWdnZXIoKSB7XG4gICAgdGhpcy5leHBhbmQgPSAhdGhpcy5leHBhbmQ7XG4gICAgdGhpcy5jaGFuZ2UuZW1pdCh0aGlzLmV4cGFuZCk7XG4gIH1cblxuICBuZ09uRGVzdHJveSgpIHtcbiAgICB0aGlzLmkxOG4kLnVuc3Vic2NyaWJlKCk7XG4gIH1cbn1cbiJdfQ==