/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output, } from '@angular/core';
import { DelonLocaleService } from '@delon/theme';
import { InputBoolean, InputNumber } from '@delon/util';
var NoticeIconComponent = /** @class */ (function () {
    function NoticeIconComponent(i18n, cdr) {
        this.i18n = i18n;
        this.cdr = cdr;
        this.locale = {};
        this.data = [];
        this.loading = false;
        this.popoverVisible = false;
        this.btnClass = '';
        this.btnIconClass = '';
        this.select = new EventEmitter();
        this.clear = new EventEmitter();
        this.popoverVisibleChange = new EventEmitter();
    }
    /**
     * @param {?} result
     * @return {?}
     */
    NoticeIconComponent.prototype.onVisibleChange = /**
     * @param {?} result
     * @return {?}
     */
    function (result) {
        this.popoverVisibleChange.emit(result);
    };
    /**
     * @param {?} i
     * @return {?}
     */
    NoticeIconComponent.prototype.onSelect = /**
     * @param {?} i
     * @return {?}
     */
    function (i) {
        this.select.emit(i);
    };
    /**
     * @param {?} title
     * @return {?}
     */
    NoticeIconComponent.prototype.onClear = /**
     * @param {?} title
     * @return {?}
     */
    function (title) {
        this.clear.emit(title);
    };
    /**
     * @return {?}
     */
    NoticeIconComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        this.i18n$ = this.i18n.change.subscribe((/**
         * @return {?}
         */
        function () {
            _this.locale = _this.i18n.getData('noticeIcon');
            _this.cdr.markForCheck();
        }));
    };
    /**
     * @return {?}
     */
    NoticeIconComponent.prototype.ngOnChanges = /**
     * @return {?}
     */
    function () {
        this.cdr.markForCheck();
    };
    /**
     * @return {?}
     */
    NoticeIconComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.i18n$.unsubscribe();
    };
    NoticeIconComponent.decorators = [
        { type: Component, args: [{
                    selector: 'notice-icon',
                    template: "<ng-template #badgeTpl>\n  <nz-badge [nzCount]=\"count\"\n            [ngClass]=\"btnClass\"\n            [nzStyle]=\"{ 'box-shadow': 'none' }\">\n    <i nz-icon\n       type=\"bell\"\n       [ngClass]=\"btnIconClass\"></i>\n  </nz-badge>\n</ng-template>\n<div *ngIf=\"data?.length === 0\">\n  <ng-template [ngTemplateOutlet]=\"badgeTpl\"></ng-template>\n</div>\n<nz-dropdown *ngIf=\"data?.length > 0\"\n             [nzVisible]=\"popoverVisible\"\n             (nzVisibleChange)=\"onVisibleChange($event)\"\n             nzTrigger=\"click\"\n             nzPlacement=\"bottomRight\"\n             [nzOverlayClassName]=\"['header-dropdown', 'notice-icon']\">\n  <div nz-dropdown>\n    <ng-template [ngTemplateOutlet]=\"badgeTpl\"></ng-template>\n  </div>\n  <nz-spin [nzSpinning]=\"loading\"\n           [nzDelay]=\"0\">\n    <nz-tabset nzSelectedIndex=\"0\">\n      <nz-tab *ngFor=\"let i of data\"\n              [nzTitle]=\"i.title\">\n        <notice-icon-tab [locale]=\"locale\"\n                         [data]=\"i\"\n                         (select)=\"onSelect($event)\"\n                         (clear)=\"onClear($event)\"></notice-icon-tab>\n      </nz-tab>\n    </nz-tabset>\n  </nz-spin>\n</nz-dropdown>\n",
                    host: { '[class.notice-icon__btn]': 'true' },
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    NoticeIconComponent.ctorParameters = function () { return [
        { type: DelonLocaleService },
        { type: ChangeDetectorRef }
    ]; };
    NoticeIconComponent.propDecorators = {
        data: [{ type: Input }],
        count: [{ type: Input }],
        loading: [{ type: Input }],
        popoverVisible: [{ type: Input }],
        btnClass: [{ type: Input }],
        btnIconClass: [{ type: Input }],
        select: [{ type: Output }],
        clear: [{ type: Output }],
        popoverVisibleChange: [{ type: Output }]
    };
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Number)
    ], NoticeIconComponent.prototype, "count", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NoticeIconComponent.prototype, "loading", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NoticeIconComponent.prototype, "popoverVisible", void 0);
    return NoticeIconComponent;
}());
export { NoticeIconComponent };
if (false) {
    /**
     * @type {?}
     * @private
     */
    NoticeIconComponent.prototype.i18n$;
    /** @type {?} */
    NoticeIconComponent.prototype.locale;
    /** @type {?} */
    NoticeIconComponent.prototype.data;
    /** @type {?} */
    NoticeIconComponent.prototype.count;
    /** @type {?} */
    NoticeIconComponent.prototype.loading;
    /** @type {?} */
    NoticeIconComponent.prototype.popoverVisible;
    /** @type {?} */
    NoticeIconComponent.prototype.btnClass;
    /** @type {?} */
    NoticeIconComponent.prototype.btnIconClass;
    /** @type {?} */
    NoticeIconComponent.prototype.select;
    /** @type {?} */
    NoticeIconComponent.prototype.clear;
    /** @type {?} */
    NoticeIconComponent.prototype.popoverVisibleChange;
    /**
     * @type {?}
     * @private
     */
    NoticeIconComponent.prototype.i18n;
    /**
     * @type {?}
     * @private
     */
    NoticeIconComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibm90aWNlLWljb24uY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy9ub3RpY2UtaWNvbi8iLCJzb3VyY2VzIjpbIm5vdGljZS1pY29uLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7OztBQUFBLE9BQU8sRUFDTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxZQUFZLEVBQ1osS0FBSyxFQUlMLE1BQU0sR0FDUCxNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQUUsa0JBQWtCLEVBQWMsTUFBTSxjQUFjLENBQUM7QUFDOUQsT0FBTyxFQUFFLFlBQVksRUFBRSxXQUFXLEVBQUUsTUFBTSxhQUFhLENBQUM7QUFLeEQ7SUFvQkUsNkJBQW9CLElBQXdCLEVBQVUsR0FBc0I7UUFBeEQsU0FBSSxHQUFKLElBQUksQ0FBb0I7UUFBVSxRQUFHLEdBQUgsR0FBRyxDQUFtQjtRQVo1RSxXQUFNLEdBQWUsRUFBRSxDQUFDO1FBRWYsU0FBSSxHQUFpQixFQUFFLENBQUM7UUFFUixZQUFPLEdBQUcsS0FBSyxDQUFDO1FBQ2hCLG1CQUFjLEdBQUcsS0FBSyxDQUFDO1FBQ3ZDLGFBQVEsR0FBRyxFQUFFLENBQUM7UUFDZCxpQkFBWSxHQUFHLEVBQUUsQ0FBQztRQUNSLFdBQU0sR0FBRyxJQUFJLFlBQVksRUFBb0IsQ0FBQztRQUM5QyxVQUFLLEdBQUcsSUFBSSxZQUFZLEVBQVUsQ0FBQztRQUNuQyx5QkFBb0IsR0FBRyxJQUFJLFlBQVksRUFBVyxDQUFDO0lBRVMsQ0FBQzs7Ozs7SUFFaEYsNkNBQWU7Ozs7SUFBZixVQUFnQixNQUFlO1FBQzdCLElBQUksQ0FBQyxvQkFBb0IsQ0FBQyxJQUFJLENBQUMsTUFBTSxDQUFDLENBQUM7SUFDekMsQ0FBQzs7Ozs7SUFFRCxzQ0FBUTs7OztJQUFSLFVBQVMsQ0FBbUI7UUFDMUIsSUFBSSxDQUFDLE1BQU0sQ0FBQyxJQUFJLENBQUMsQ0FBQyxDQUFDLENBQUM7SUFDdEIsQ0FBQzs7Ozs7SUFFRCxxQ0FBTzs7OztJQUFQLFVBQVEsS0FBYTtRQUNuQixJQUFJLENBQUMsS0FBSyxDQUFDLElBQUksQ0FBQyxLQUFLLENBQUMsQ0FBQztJQUN6QixDQUFDOzs7O0lBRUQsc0NBQVE7OztJQUFSO1FBQUEsaUJBS0M7UUFKQyxJQUFJLENBQUMsS0FBSyxHQUFHLElBQUksQ0FBQyxJQUFJLENBQUMsTUFBTSxDQUFDLFNBQVM7OztRQUFDO1lBQ3RDLEtBQUksQ0FBQyxNQUFNLEdBQUcsS0FBSSxDQUFDLElBQUksQ0FBQyxPQUFPLENBQUMsWUFBWSxDQUFDLENBQUM7WUFDOUMsS0FBSSxDQUFDLEdBQUcsQ0FBQyxZQUFZLEVBQUUsQ0FBQztRQUMxQixDQUFDLEVBQUMsQ0FBQztJQUNMLENBQUM7Ozs7SUFFRCx5Q0FBVzs7O0lBQVg7UUFDRSxJQUFJLENBQUMsR0FBRyxDQUFDLFlBQVksRUFBRSxDQUFDO0lBQzFCLENBQUM7Ozs7SUFFRCx5Q0FBVzs7O0lBQVg7UUFDRSxJQUFJLENBQUMsS0FBSyxDQUFDLFdBQVcsRUFBRSxDQUFDO0lBQzNCLENBQUM7O2dCQS9DRixTQUFTLFNBQUM7b0JBQ1QsUUFBUSxFQUFFLGFBQWE7b0JBQ3ZCLDhzQ0FBMkM7b0JBQzNDLElBQUksRUFBRSxFQUFFLDBCQUEwQixFQUFFLE1BQU0sRUFBRTtvQkFDNUMsZUFBZSxFQUFFLHVCQUF1QixDQUFDLE1BQU07aUJBQ2hEOzs7O2dCQVhRLGtCQUFrQjtnQkFUekIsaUJBQWlCOzs7dUJBeUJoQixLQUFLO3dCQUNMLEtBQUs7MEJBQ0wsS0FBSztpQ0FDTCxLQUFLOzJCQUNMLEtBQUs7K0JBQ0wsS0FBSzt5QkFDTCxNQUFNO3dCQUNOLE1BQU07dUNBQ04sTUFBTTs7SUFQaUI7UUFBZCxXQUFXLEVBQUU7O3NEQUFlO0lBQ2I7UUFBZixZQUFZLEVBQUU7O3dEQUFpQjtJQUNoQjtRQUFmLFlBQVksRUFBRTs7K0RBQXdCO0lBbUNsRCwwQkFBQztDQUFBLEFBaERELElBZ0RDO1NBMUNZLG1CQUFtQjs7Ozs7O0lBQzlCLG9DQUE0Qjs7SUFDNUIscUNBQXdCOztJQUV4QixtQ0FBaUM7O0lBQ2pDLG9DQUFzQzs7SUFDdEMsc0NBQXlDOztJQUN6Qyw2Q0FBZ0Q7O0lBQ2hELHVDQUF1Qjs7SUFDdkIsMkNBQTJCOztJQUMzQixxQ0FBaUU7O0lBQ2pFLG9DQUFzRDs7SUFDdEQsbURBQXNFOzs7OztJQUUxRCxtQ0FBZ0M7Ozs7O0lBQUUsa0NBQThCIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHtcbiAgQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3ksXG4gIENoYW5nZURldGVjdG9yUmVmLFxuICBDb21wb25lbnQsXG4gIEV2ZW50RW1pdHRlcixcbiAgSW5wdXQsXG4gIE9uQ2hhbmdlcyxcbiAgT25EZXN0cm95LFxuICBPbkluaXQsXG4gIE91dHB1dCxcbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBEZWxvbkxvY2FsZVNlcnZpY2UsIExvY2FsZURhdGEgfSBmcm9tICdAZGVsb24vdGhlbWUnO1xuaW1wb3J0IHsgSW5wdXRCb29sZWFuLCBJbnB1dE51bWJlciB9IGZyb20gJ0BkZWxvbi91dGlsJztcbmltcG9ydCB7IFN1YnNjcmlwdGlvbiB9IGZyb20gJ3J4anMnO1xuXG5pbXBvcnQgeyBOb3RpY2VJY29uU2VsZWN0LCBOb3RpY2VJdGVtIH0gZnJvbSAnLi9ub3RpY2UtaWNvbi50eXBlcyc7XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ25vdGljZS1pY29uJyxcbiAgdGVtcGxhdGVVcmw6ICcuL25vdGljZS1pY29uLmNvbXBvbmVudC5odG1sJyxcbiAgaG9zdDogeyAnW2NsYXNzLm5vdGljZS1pY29uX19idG5dJzogJ3RydWUnIH0sXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxufSlcbmV4cG9ydCBjbGFzcyBOb3RpY2VJY29uQ29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0LCBPbkNoYW5nZXMsIE9uRGVzdHJveSB7XG4gIHByaXZhdGUgaTE4biQ6IFN1YnNjcmlwdGlvbjtcbiAgbG9jYWxlOiBMb2NhbGVEYXRhID0ge307XG5cbiAgQElucHV0KCkgZGF0YTogTm90aWNlSXRlbVtdID0gW107XG4gIEBJbnB1dCgpIEBJbnB1dE51bWJlcigpIGNvdW50OiBudW1iZXI7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBsb2FkaW5nID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBwb3BvdmVyVmlzaWJsZSA9IGZhbHNlO1xuICBASW5wdXQoKSBidG5DbGFzcyA9ICcnO1xuICBASW5wdXQoKSBidG5JY29uQ2xhc3MgPSAnJztcbiAgQE91dHB1dCgpIHJlYWRvbmx5IHNlbGVjdCA9IG5ldyBFdmVudEVtaXR0ZXI8Tm90aWNlSWNvblNlbGVjdD4oKTtcbiAgQE91dHB1dCgpIHJlYWRvbmx5IGNsZWFyID0gbmV3IEV2ZW50RW1pdHRlcjxzdHJpbmc+KCk7XG4gIEBPdXRwdXQoKSByZWFkb25seSBwb3BvdmVyVmlzaWJsZUNoYW5nZSA9IG5ldyBFdmVudEVtaXR0ZXI8Ym9vbGVhbj4oKTtcblxuICBjb25zdHJ1Y3Rvcihwcml2YXRlIGkxOG46IERlbG9uTG9jYWxlU2VydmljZSwgcHJpdmF0ZSBjZHI6IENoYW5nZURldGVjdG9yUmVmKSB7fVxuXG4gIG9uVmlzaWJsZUNoYW5nZShyZXN1bHQ6IGJvb2xlYW4pIHtcbiAgICB0aGlzLnBvcG92ZXJWaXNpYmxlQ2hhbmdlLmVtaXQocmVzdWx0KTtcbiAgfVxuXG4gIG9uU2VsZWN0KGk6IE5vdGljZUljb25TZWxlY3QpIHtcbiAgICB0aGlzLnNlbGVjdC5lbWl0KGkpO1xuICB9XG5cbiAgb25DbGVhcih0aXRsZTogc3RyaW5nKSB7XG4gICAgdGhpcy5jbGVhci5lbWl0KHRpdGxlKTtcbiAgfVxuXG4gIG5nT25Jbml0KCkge1xuICAgIHRoaXMuaTE4biQgPSB0aGlzLmkxOG4uY2hhbmdlLnN1YnNjcmliZSgoKSA9PiB7XG4gICAgICB0aGlzLmxvY2FsZSA9IHRoaXMuaTE4bi5nZXREYXRhKCdub3RpY2VJY29uJyk7XG4gICAgICB0aGlzLmNkci5tYXJrRm9yQ2hlY2soKTtcbiAgICB9KTtcbiAgfVxuXG4gIG5nT25DaGFuZ2VzKCkge1xuICAgIHRoaXMuY2RyLm1hcmtGb3JDaGVjaygpO1xuICB9XG5cbiAgbmdPbkRlc3Ryb3koKSB7XG4gICAgdGhpcy5pMThuJC51bnN1YnNjcmliZSgpO1xuICB9XG59XG4iXX0=