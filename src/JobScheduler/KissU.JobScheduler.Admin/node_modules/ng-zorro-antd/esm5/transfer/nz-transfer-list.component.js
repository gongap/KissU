/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, EventEmitter, Input, Output, TemplateRef, ViewEncapsulation } from '@angular/core';
import { NzUpdateHostClassService } from 'ng-zorro-antd/core';
var NzTransferListComponent = /** @class */ (function () {
    // #endregion
    function NzTransferListComponent(el, updateHostClassService, cdr) {
        this.el = el;
        this.updateHostClassService = updateHostClassService;
        this.cdr = cdr;
        // #region fields
        this.direction = '';
        this.titleText = '';
        this.dataSource = [];
        this.itemUnit = '';
        this.itemsUnit = '';
        this.filter = '';
        // events
        this.handleSelectAll = new EventEmitter();
        this.handleSelect = new EventEmitter();
        this.filterChange = new EventEmitter();
        // #endregion
        // #region styles
        this.prefixCls = 'ant-transfer-list';
        // #endregion
        // #region select all
        this.stat = {
            checkAll: false,
            checkHalf: false,
            checkCount: 0,
            shownCount: 0
        };
    }
    /**
     * @return {?}
     */
    NzTransferListComponent.prototype.setClassMap = /**
     * @return {?}
     */
    function () {
        var _a;
        /** @type {?} */
        var classMap = (_a = {},
            _a[this.prefixCls] = true,
            _a[this.prefixCls + "-with-footer"] = !!this.footer,
            _a);
        this.updateHostClassService.updateHostClass(this.el.nativeElement, classMap);
    };
    /**
     * @param {?} status
     * @return {?}
     */
    NzTransferListComponent.prototype.onHandleSelectAll = /**
     * @param {?} status
     * @return {?}
     */
    function (status) {
        this.dataSource.forEach((/**
         * @param {?} item
         * @return {?}
         */
        function (item) {
            if (!item.disabled && !item._hiden) {
                item.checked = status;
            }
        }));
        this.updateCheckStatus();
        this.handleSelectAll.emit(status);
    };
    /**
     * @private
     * @return {?}
     */
    NzTransferListComponent.prototype.updateCheckStatus = /**
     * @private
     * @return {?}
     */
    function () {
        /** @type {?} */
        var validCount = this.dataSource.filter((/**
         * @param {?} w
         * @return {?}
         */
        function (w) { return !w.disabled; })).length;
        this.stat.checkCount = this.dataSource.filter((/**
         * @param {?} w
         * @return {?}
         */
        function (w) { return w.checked && !w.disabled; })).length;
        this.stat.shownCount = this.dataSource.filter((/**
         * @param {?} w
         * @return {?}
         */
        function (w) { return !w._hiden; })).length;
        this.stat.checkAll = validCount > 0 && validCount === this.stat.checkCount;
        this.stat.checkHalf = this.stat.checkCount > 0 && !this.stat.checkAll;
    };
    // #endregion
    // #region search
    // #endregion
    // #region search
    /**
     * @param {?} value
     * @return {?}
     */
    NzTransferListComponent.prototype.handleFilter = 
    // #endregion
    // #region search
    /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        var _this = this;
        this.filter = value;
        this.dataSource.forEach((/**
         * @param {?} item
         * @return {?}
         */
        function (item) {
            item._hiden = value.length > 0 && !_this.matchFilter(value, item);
        }));
        this.stat.shownCount = this.dataSource.filter((/**
         * @param {?} w
         * @return {?}
         */
        function (w) { return !w._hiden; })).length;
        this.filterChange.emit({ direction: this.direction, value: value });
    };
    /**
     * @return {?}
     */
    NzTransferListComponent.prototype.handleClear = /**
     * @return {?}
     */
    function () {
        this.handleFilter('');
    };
    /**
     * @private
     * @param {?} text
     * @param {?} item
     * @return {?}
     */
    NzTransferListComponent.prototype.matchFilter = /**
     * @private
     * @param {?} text
     * @param {?} item
     * @return {?}
     */
    function (text, item) {
        if (this.filterOption) {
            return this.filterOption(text, item);
        }
        return item.title.includes(text);
    };
    /**
     * @param {?} changes
     * @return {?}
     */
    NzTransferListComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        if ('footer' in changes) {
            this.setClassMap();
        }
    };
    /**
     * @return {?}
     */
    NzTransferListComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        this.setClassMap();
    };
    /**
     * @return {?}
     */
    NzTransferListComponent.prototype.markForCheck = /**
     * @return {?}
     */
    function () {
        this.updateCheckStatus();
        this.cdr.markForCheck();
    };
    /**
     * @param {?} item
     * @return {?}
     */
    NzTransferListComponent.prototype._handleSelect = /**
     * @param {?} item
     * @return {?}
     */
    function (item) {
        if (this.disabled || item.disabled) {
            return;
        }
        item.checked = !item.checked;
        this.updateCheckStatus();
        this.handleSelect.emit(item);
    };
    NzTransferListComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-transfer-list',
                    exportAs: 'nzTransferList',
                    preserveWhitespaces: false,
                    providers: [NzUpdateHostClassService],
                    template: "<div class=\"ant-transfer-list-header\">\n  <label nz-checkbox [nzChecked]=\"stat.checkAll\" (nzCheckedChange)=\"onHandleSelectAll($event)\"\n    [nzIndeterminate]=\"stat.checkHalf\" [nzDisabled]=\"stat.shownCount == 0 || disabled\">\n  </label>\n  <span class=\"ant-transfer-list-header-selected\">\n    <span>{{ (stat.checkCount > 0 ? stat.checkCount + '/' : '') + stat.shownCount }} {{ dataSource.length > 1 ? itemsUnit : itemUnit }}</span>\n    <span *ngIf=\"titleText\" class=\"ant-transfer-list-header-title\">{{ titleText }}</span>\n  </span>\n</div>\n<div class=\"{{showSearch ? 'ant-transfer-list-body ant-transfer-list-body-with-search' : 'ant-transfer-list-body'}}\"\n  [ngClass]=\"{'ant-transfer__nodata': stat.shownCount === 0}\">\n  <div *ngIf=\"showSearch\" class=\"ant-transfer-list-body-search-wrapper\">\n    <div nz-transfer-search\n      (valueChanged)=\"handleFilter($event)\"\n      (valueClear)=\"handleClear()\"\n      [placeholder]=\"searchPlaceholder\"\n      [disabled]=\"disabled\"\n      [value]=\"filter\"></div>\n  </div>\n  <ul *ngIf=\"stat.shownCount > 0\" class=\"ant-transfer-list-content\">\n    <div class=\"LazyLoad\" *ngFor=\"let item of dataSource\">\n      <li *ngIf=\"!item._hiden\" (click)=\"_handleSelect(item)\"\n        class=\"ant-transfer-list-content-item\" [ngClass]=\"{'ant-transfer-list-content-item-disabled': disabled || item.disabled}\">\n        <label nz-checkbox [nzChecked]=\"item.checked\" (nzCheckedChange)=\"_handleSelect(item)\"\n          (click)=\"$event.stopPropagation()\" [nzDisabled]=\"disabled || item.disabled\">\n          <ng-container *ngIf=\"!render; else renderContainer\">{{ item.title }}</ng-container>\n          <ng-template #renderContainer [ngTemplateOutlet]=\"render\" [ngTemplateOutletContext]=\"{ $implicit: item }\"></ng-template>\n        </label>\n      </li>\n    </div>\n  </ul>\n  <div *ngIf=\"stat.shownCount === 0\" class=\"ant-transfer-list-body-not-found\">\n    <nz-embed-empty [nzComponentName]=\"'transfer'\" [specificContent]=\"notFoundContent\"></nz-embed-empty>\n  </div>\n</div>\n<div *ngIf=\"footer\" class=\"ant-transfer-list-footer\">\n  <ng-template [ngTemplateOutlet]=\"footer\" [ngTemplateOutletContext]=\"{ $implicit: direction }\"></ng-template>\n</div>",
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    NzTransferListComponent.ctorParameters = function () { return [
        { type: ElementRef },
        { type: NzUpdateHostClassService },
        { type: ChangeDetectorRef }
    ]; };
    NzTransferListComponent.propDecorators = {
        direction: [{ type: Input }],
        titleText: [{ type: Input }],
        dataSource: [{ type: Input }],
        itemUnit: [{ type: Input }],
        itemsUnit: [{ type: Input }],
        filter: [{ type: Input }],
        disabled: [{ type: Input }],
        showSearch: [{ type: Input }],
        searchPlaceholder: [{ type: Input }],
        notFoundContent: [{ type: Input }],
        filterOption: [{ type: Input }],
        render: [{ type: Input }],
        footer: [{ type: Input }],
        handleSelectAll: [{ type: Output }],
        handleSelect: [{ type: Output }],
        filterChange: [{ type: Output }]
    };
    return NzTransferListComponent;
}());
export { NzTransferListComponent };
if (false) {
    /** @type {?} */
    NzTransferListComponent.prototype.direction;
    /** @type {?} */
    NzTransferListComponent.prototype.titleText;
    /** @type {?} */
    NzTransferListComponent.prototype.dataSource;
    /** @type {?} */
    NzTransferListComponent.prototype.itemUnit;
    /** @type {?} */
    NzTransferListComponent.prototype.itemsUnit;
    /** @type {?} */
    NzTransferListComponent.prototype.filter;
    /** @type {?} */
    NzTransferListComponent.prototype.disabled;
    /** @type {?} */
    NzTransferListComponent.prototype.showSearch;
    /** @type {?} */
    NzTransferListComponent.prototype.searchPlaceholder;
    /** @type {?} */
    NzTransferListComponent.prototype.notFoundContent;
    /** @type {?} */
    NzTransferListComponent.prototype.filterOption;
    /** @type {?} */
    NzTransferListComponent.prototype.render;
    /** @type {?} */
    NzTransferListComponent.prototype.footer;
    /** @type {?} */
    NzTransferListComponent.prototype.handleSelectAll;
    /** @type {?} */
    NzTransferListComponent.prototype.handleSelect;
    /** @type {?} */
    NzTransferListComponent.prototype.filterChange;
    /** @type {?} */
    NzTransferListComponent.prototype.prefixCls;
    /** @type {?} */
    NzTransferListComponent.prototype.stat;
    /**
     * @type {?}
     * @private
     */
    NzTransferListComponent.prototype.el;
    /**
     * @type {?}
     * @private
     */
    NzTransferListComponent.prototype.updateHostClassService;
    /**
     * @type {?}
     * @private
     */
    NzTransferListComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotdHJhbnNmZXItbGlzdC5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9uZy16b3Jyby1hbnRkL3RyYW5zZmVyLyIsInNvdXJjZXMiOlsibnotdHJhbnNmZXItbGlzdC5jb21wb25lbnQudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQ0wsdUJBQXVCLEVBQ3ZCLGlCQUFpQixFQUNqQixTQUFTLEVBQ1QsVUFBVSxFQUNWLFlBQVksRUFDWixLQUFLLEVBR0wsTUFBTSxFQUVOLFdBQVcsRUFDWCxpQkFBaUIsRUFDbEIsTUFBTSxlQUFlLENBQUM7QUFFdkIsT0FBTyxFQUFFLHdCQUF3QixFQUFFLE1BQU0sb0JBQW9CLENBQUM7QUFJOUQ7SUFzR0UsYUFBYTtJQUViLGlDQUNVLEVBQWMsRUFDZCxzQkFBZ0QsRUFDaEQsR0FBc0I7UUFGdEIsT0FBRSxHQUFGLEVBQUUsQ0FBWTtRQUNkLDJCQUFzQixHQUF0QixzQkFBc0IsQ0FBMEI7UUFDaEQsUUFBRyxHQUFILEdBQUcsQ0FBbUI7O1FBL0Z2QixjQUFTLEdBQUcsRUFBRSxDQUFDO1FBQ2YsY0FBUyxHQUFHLEVBQUUsQ0FBQztRQUVmLGVBQVUsR0FBbUIsRUFBRSxDQUFDO1FBRWhDLGFBQVEsR0FBRyxFQUFFLENBQUM7UUFDZCxjQUFTLEdBQUcsRUFBRSxDQUFDO1FBQ2YsV0FBTSxHQUFHLEVBQUUsQ0FBQzs7UUFXRixvQkFBZSxHQUEwQixJQUFJLFlBQVksRUFBVyxDQUFDO1FBQ3JFLGlCQUFZLEdBQStCLElBQUksWUFBWSxFQUFFLENBQUM7UUFDOUQsaUJBQVksR0FBdUQsSUFBSSxZQUFZLEVBQUUsQ0FBQzs7O1FBTXpHLGNBQVMsR0FBRyxtQkFBbUIsQ0FBQzs7O1FBY2hDLFNBQUksR0FBRztZQUNMLFFBQVEsRUFBRSxLQUFLO1lBQ2YsU0FBUyxFQUFFLEtBQUs7WUFDaEIsVUFBVSxFQUFFLENBQUM7WUFDYixVQUFVLEVBQUUsQ0FBQztTQUNkLENBQUM7SUFt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SUFBSTtvQkFDckMsZUFBZSxFQUFFLHVCQUF1QixDQUFDLE1BQU07aUJBQ2hEOzs7O2dCQXZCQyxVQUFVO2dCQVdILHdCQUF3QjtnQkFiL0IsaUJBQWlCOzs7NEJBNkJoQixLQUFLOzRCQUNMLEtBQUs7NkJBRUwsS0FBSzsyQkFFTCxLQUFLOzRCQUNMLEtBQUs7eUJBQ0wsS0FBSzsyQkFDTCxLQUFLOzZCQUNMLEtBQUs7b0NBQ0wsS0FBSztrQ0FDTCxLQUFLOytCQUNMLEtBQUs7eUJBRUwsS0FBSzt5QkFDTCxLQUFLO2tDQUdMLE1BQU07K0JBQ04sTUFBTTsrQkFDTixNQUFNOztJQXFHVCw4QkFBQztDQUFBLEFBcklELElBcUlDO1NBNUhZLHVCQUF1Qjs7O0lBR2xDLDRDQUF3Qjs7SUFDeEIsNENBQXdCOztJQUV4Qiw2Q0FBeUM7O0lBRXpDLDJDQUF1Qjs7SUFDdkIsNENBQXdCOztJQUN4Qix5Q0FBcUI7O0lBQ3JCLDJDQUEyQjs7SUFDM0IsNkNBQTZCOztJQUM3QixvREFBbUM7O0lBQ25DLGtEQUFpQzs7SUFDakMsK0NBQTJFOztJQUUzRSx5Q0FBbUM7O0lBQ25DLHlDQUFtQzs7SUFHbkMsa0RBQXdGOztJQUN4RiwrQ0FBaUY7O0lBQ2pGLCtDQUF5Rzs7SUFNekcsNENBQWdDOztJQWNoQyx1Q0FLRTs7Ozs7SUFnREEscUNBQXNCOzs7OztJQUN0Qix5REFBd0Q7Ozs7O0lBQ3hELHNDQUE4QiIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gIENvbXBvbmVudCxcbiAgRWxlbWVudFJlZixcbiAgRXZlbnRFbWl0dGVyLFxuICBJbnB1dCxcbiAgT25DaGFuZ2VzLFxuICBPbkluaXQsXG4gIE91dHB1dCxcbiAgU2ltcGxlQ2hhbmdlcyxcbiAgVGVtcGxhdGVSZWYsXG4gIFZpZXdFbmNhcHN1bGF0aW9uXG59IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuXG5pbXBvcnQgeyBOelVwZGF0ZUhvc3RDbGFzc1NlcnZpY2UgfSBmcm9tICduZy16b3Jyby1hbnRkL2NvcmUnO1xuXG5pbXBvcnQgeyBUcmFuc2Zlckl0ZW0gfSBmcm9tICcuL2ludGVyZmFjZSc7XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ256LXRyYW5zZmVyLWxpc3QnLFxuICBleHBvcnRBczogJ256VHJhbnNmZXJMaXN0JyxcbiAgcHJlc2VydmVXaGl0ZXNwYWNlczogZmFsc2UsXG4gIHByb3ZpZGVyczogW056VXBkYXRlSG9zdENsYXNzU2VydmljZV0sXG4gIHRlbXBsYXRlVXJsOiAnLi9uei10cmFuc2Zlci1saXN0LmNvbXBvbmVudC5odG1sJyxcbiAgZW5jYXBzdWxhdGlvbjogVmlld0VuY2Fwc3VsYXRpb24uTm9uZSxcbiAgY2hhbmdlRGV0ZWN0aW9uOiBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneS5PblB1c2hcbn0pXG5leHBvcnQgY2xhc3MgTnpUcmFuc2Zlckxpc3RDb21wb25lbnQgaW1wbGVtZW50cyBPbkNoYW5nZXMsIE9uSW5pdCB7XG4gIC8vICNyZWdpb24gZmllbGRzXG5cbiAgQElucHV0KCkgZGlyZWN0aW9uID0gJyc7XG4gIEBJbnB1dCgpIHRpdGxlVGV4dCA9ICcnO1xuXG4gIEBJbnB1dCgpIGRhdGFTb3VyY2U6IFRyYW5zZmVySXRlbVtdID0gW107XG5cbiAgQElucHV0KCkgaXRlbVVuaXQgPSAnJztcbiAgQElucHV0KCkgaXRlbXNVbml0ID0gJyc7XG4gIEBJbnB1dCgpIGZpbHRlciA9ICcnO1xuICBASW5wdXQoKSBkaXNhYmxlZDogYm9vbGVhbjtcbiAgQElucHV0KCkgc2hvd1NlYXJjaDogYm9vbGVhbjtcbiAgQElucHV0KCkgc2VhcmNoUGxhY2Vob2xkZXI6IHN0cmluZztcbiAgQElucHV0KCkgbm90Rm91bmRDb250ZW50OiBzdHJpbmc7XG4gIEBJbnB1dCgpIGZpbHRlck9wdGlvbjogKGlucHV0VmFsdWU6IHN0cmluZywgaXRlbTogVHJhbnNmZXJJdGVtKSA9PiBib29sZWFuO1xuXG4gIEBJbnB1dCgpIHJlbmRlcjogVGVtcGxhdGVSZWY8dm9pZD47XG4gIEBJbnB1dCgpIGZvb3RlcjogVGVtcGxhdGVSZWY8dm9pZD47XG5cbiAgLy8gZXZlbnRzXG4gIEBPdXRwdXQoKSByZWFkb25seSBoYW5kbGVTZWxlY3RBbGw6IEV2ZW50RW1pdHRlcjxib29sZWFuPiA9IG5ldyBFdmVudEVtaXR0ZXI8Ym9vbGVhbj4oKTtcbiAgQE91dHB1dCgpIHJlYWRvbmx5IGhhbmRsZVNlbGVjdDogRXZlbnRFbWl0dGVyPFRyYW5zZmVySXRlbT4gPSBuZXcgRXZlbnRFbWl0dGVyKCk7XG4gIEBPdXRwdXQoKSByZWFkb25seSBmaWx0ZXJDaGFuZ2U6IEV2ZW50RW1pdHRlcjx7IGRpcmVjdGlvbjogc3RyaW5nOyB2YWx1ZTogc3RyaW5nIH0+ID0gbmV3IEV2ZW50RW1pdHRlcigpO1xuXG4gIC8vICNlbmRyZWdpb25cblxuICAvLyAjcmVnaW9uIHN0eWxlc1xuXG4gIHByZWZpeENscyA9ICdhbnQtdHJhbnNmZXItbGlzdCc7XG5cbiAgc2V0Q2xhc3NNYXAoKTogdm9pZCB7XG4gICAgY29uc3QgY2xhc3NNYXAgPSB7XG4gICAgICBbdGhpcy5wcmVmaXhDbHNdOiB0cnVlLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS13aXRoLWZvb3RlcmBdOiAhIXRoaXMuZm9vdGVyXG4gICAgfTtcbiAgICB0aGlzLnVwZGF0ZUhvc3RDbGFzc1NlcnZpY2UudXBkYXRlSG9zdENsYXNzKHRoaXMuZWwubmF0aXZlRWxlbWVudCwgY2xhc3NNYXApO1xuICB9XG5cbiAgLy8gI2VuZHJlZ2lvblxuXG4gIC8vICNyZWdpb24gc2VsZWN0IGFsbFxuXG4gIHN0YXQgPSB7XG4gICAgY2hlY2tBbGw6IGZhbHNlLFxuICAgIGNoZWNrSGFsZjogZmFsc2UsXG4gICAgY2hlY2tDb3VudDogMCxcbiAgICBzaG93bkNvdW50OiAwXG4gIH07XG5cbiAgb25IYW5kbGVTZWxlY3RBbGwoc3RhdHVzOiBib29sZWFuKTogdm9pZCB7XG4gICAgdGhpcy5kYXRhU291cmNlLmZvckVhY2goaXRlbSA9PiB7XG4gICAgICBpZiAoIWl0ZW0uZGlzYWJsZWQgJiYgIWl0ZW0uX2hpZGVuKSB7XG4gICAgICAgIGl0ZW0uY2hlY2tlZCA9IHN0YXR1cztcbiAgICAgIH1cbiAgICB9KTtcblxuICAgIHRoaXMudXBkYXRlQ2hlY2tTdGF0dXMoKTtcbiAgICB0aGlzLmhhbmRsZVNlbGVjdEFsbC5lbWl0KHN0YXR1cyk7XG4gIH1cblxuICBwcml2YXRlIHVwZGF0ZUNoZWNrU3RhdHVzKCk6IHZvaWQge1xuICAgIGNvbnN0IHZhbGlkQ291bnQgPSB0aGlzLmRhdGFTb3VyY2UuZmlsdGVyKHcgPT4gIXcuZGlzYWJsZWQpLmxlbmd0aDtcbiAgICB0aGlzLnN0YXQuY2hlY2tDb3VudCA9IHRoaXMuZGF0YVNvdXJjZS5maWx0ZXIodyA9PiB3LmNoZWNrZWQgJiYgIXcuZGlzYWJsZWQpLmxlbmd0aDtcbiAgICB0aGlzLnN0YXQuc2hvd25Db3VudCA9IHRoaXMuZGF0YVNvdXJjZS5maWx0ZXIodyA9PiAhdy5faGlkZW4pLmxlbmd0aDtcbiAgICB0aGlzLnN0YXQuY2hlY2tBbGwgPSB2YWxpZENvdW50ID4gMCAmJiB2YWxpZENvdW50ID09PSB0aGlzLnN0YXQuY2hlY2tDb3VudDtcbiAgICB0aGlzLnN0YXQuY2hlY2tIYWxmID0gdGhpcy5zdGF0LmNoZWNrQ291bnQgPiAwICYmICF0aGlzLnN0YXQuY2hlY2tBbGw7XG4gIH1cblxuICAvLyAjZW5kcmVnaW9uXG5cbiAgLy8gI3JlZ2lvbiBzZWFyY2hcblxuICBoYW5kbGVGaWx0ZXIodmFsdWU6IHN0cmluZyk6IHZvaWQge1xuICAgIHRoaXMuZmlsdGVyID0gdmFsdWU7XG4gICAgdGhpcy5kYXRhU291cmNlLmZvckVhY2goaXRlbSA9PiB7XG4gICAgICBpdGVtLl9oaWRlbiA9IHZhbHVlLmxlbmd0aCA+IDAgJiYgIXRoaXMubWF0Y2hGaWx0ZXIodmFsdWUsIGl0ZW0pO1xuICAgIH0pO1xuICAgIHRoaXMuc3RhdC5zaG93bkNvdW50ID0gdGhpcy5kYXRhU291cmNlLmZpbHRlcih3ID0+ICF3Ll9oaWRlbikubGVuZ3RoO1xuICAgIHRoaXMuZmlsdGVyQ2hhbmdlLmVtaXQoeyBkaXJlY3Rpb246IHRoaXMuZGlyZWN0aW9uLCB2YWx1ZSB9KTtcbiAgfVxuXG4gIGhhbmRsZUNsZWFyKCk6IHZvaWQge1xuICAgIHRoaXMuaGFuZGxlRmlsdGVyKCcnKTtcbiAgfVxuXG4gIHByaXZhdGUgbWF0Y2hGaWx0ZXIodGV4dDogc3RyaW5nLCBpdGVtOiBUcmFuc2Zlckl0ZW0pOiBib29sZWFuIHtcbiAgICBpZiAodGhpcy5maWx0ZXJPcHRpb24pIHtcbiAgICAgIHJldHVybiB0aGlzLmZpbHRlck9wdGlvbih0ZXh0LCBpdGVtKTtcbiAgICB9XG4gICAgcmV0dXJuIGl0ZW0udGl0bGUuaW5jbHVkZXModGV4dCk7XG4gIH1cblxuICAvLyAjZW5kcmVnaW9uXG5cbiAgY29uc3RydWN0b3IoXG4gICAgcHJpdmF0ZSBlbDogRWxlbWVudFJlZixcbiAgICBwcml2YXRlIHVwZGF0ZUhvc3RDbGFzc1NlcnZpY2U6IE56VXBkYXRlSG9zdENsYXNzU2VydmljZSxcbiAgICBwcml2YXRlIGNkcjogQ2hhbmdlRGV0ZWN0b3JSZWZcbiAgKSB7fVxuXG4gIG5nT25DaGFuZ2VzKGNoYW5nZXM6IFNpbXBsZUNoYW5nZXMpOiB2b2lkIHtcbiAgICBpZiAoJ2Zvb3RlcicgaW4gY2hhbmdlcykge1xuICAgICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICAgIH1cbiAgfVxuXG4gIG5nT25Jbml0KCk6IHZvaWQge1xuICAgIHRoaXMuc2V0Q2xhc3NNYXAoKTtcbiAgfVxuXG4gIG1hcmtGb3JDaGVjaygpOiB2b2lkIHtcbiAgICB0aGlzLnVwZGF0ZUNoZWNrU3RhdHVzKCk7XG4gICAgdGhpcy5jZHIubWFya0ZvckNoZWNrKCk7XG4gIH1cblxuICBfaGFuZGxlU2VsZWN0KGl0ZW06IFRyYW5zZmVySXRlbSk6IHZvaWQge1xuICAgIGlmICh0aGlzLmRpc2FibGVkIHx8IGl0ZW0uZGlzYWJsZWQpIHtcbiAgICAgIHJldHVybjtcbiAgICB9XG4gICAgaXRlbS5jaGVja2VkID0gIWl0ZW0uY2hlY2tlZDtcbiAgICB0aGlzLnVwZGF0ZUNoZWNrU3RhdHVzKCk7XG4gICAgdGhpcy5oYW5kbGVTZWxlY3QuZW1pdChpdGVtKTtcbiAgfVxufVxuIl19