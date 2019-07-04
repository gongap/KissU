/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { isNotNil, InputBoolean } from 'ng-zorro-antd/core';
import { NzDropDownComponent } from 'ng-zorro-antd/dropdown';
import { NzI18nService } from 'ng-zorro-antd/i18n';
/**
 * @record
 */
export function NzThItemInterface() { }
if (false) {
    /** @type {?} */
    NzThItemInterface.prototype.text;
    /** @type {?} */
    NzThItemInterface.prototype.value;
    /** @type {?} */
    NzThItemInterface.prototype.checked;
}
var NzThComponent = /** @class */ (function () {
    function NzThComponent(cdr, i18n) {
        this.cdr = cdr;
        this.i18n = i18n;
        this.hasFilterValue = false;
        this.filterVisible = false;
        this.multipleFilterList = [];
        this.singleFilterList = [];
        /* tslint:disable-next-line:no-any */
        this.locale = (/** @type {?} */ ({}));
        this.nzWidthChange$ = new Subject();
        this.destroy$ = new Subject();
        this.hasDefaultFilter = false;
        /* tslint:disable-next-line:no-any */
        this.nzSelections = [];
        this.nzChecked = false;
        this.nzDisabled = false;
        this.nzIndeterminate = false;
        this.nzFilterMultiple = true;
        this.nzSort = null;
        this.nzFilters = [];
        this.nzExpand = false;
        this.nzShowCheckbox = false;
        this.nzCustomFilter = false;
        this.nzShowSort = false;
        this.nzShowFilter = false;
        this.nzShowRowSelection = false;
        this.nzCheckedChange = new EventEmitter();
        this.nzSortChange = new EventEmitter();
        this.nzSortChangeWithKey = new EventEmitter();
        /* tslint:disable-next-line:no-any */
        this.nzFilterChange = new EventEmitter();
    }
    /**
     * @return {?}
     */
    NzThComponent.prototype.updateSortValue = /**
     * @return {?}
     */
    function () {
        if (this.nzShowSort) {
            if (this.nzSort === 'descend') {
                this.setSortValue('ascend');
            }
            else if (this.nzSort === 'ascend') {
                this.setSortValue(null);
            }
            else {
                this.setSortValue('descend');
            }
        }
    };
    /**
     * @param {?} value
     * @return {?}
     */
    NzThComponent.prototype.setSortValue = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        this.nzSort = value;
        this.nzSortChangeWithKey.emit({ key: this.nzSortKey, value: this.nzSort });
        this.nzSortChange.emit(this.nzSort);
    };
    Object.defineProperty(NzThComponent.prototype, "filterList", {
        get: /**
         * @return {?}
         */
        function () {
            return this.multipleFilterList.filter((/**
             * @param {?} item
             * @return {?}
             */
            function (item) { return item.checked; })).map((/**
             * @param {?} item
             * @return {?}
             */
            function (item) { return item.value; }));
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzThComponent.prototype, "filterValue", {
        /* tslint:disable-next-line:no-any */
        get: /* tslint:disable-next-line:no-any */
        /**
         * @return {?}
         */
        function () {
            /** @type {?} */
            var checkedFilter = this.singleFilterList.find((/**
             * @param {?} item
             * @return {?}
             */
            function (item) { return item.checked; }));
            return checkedFilter ? checkedFilter.value : null;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    NzThComponent.prototype.updateFilterStatus = /**
     * @return {?}
     */
    function () {
        if (this.nzFilterMultiple) {
            this.hasFilterValue = this.filterList.length > 0;
        }
        else {
            this.hasFilterValue = isNotNil(this.filterValue);
        }
    };
    /**
     * @return {?}
     */
    NzThComponent.prototype.search = /**
     * @return {?}
     */
    function () {
        this.updateFilterStatus();
        if (this.nzFilterMultiple) {
            this.nzFilterChange.emit(this.filterList);
        }
        else {
            this.nzFilterChange.emit(this.filterValue);
        }
    };
    /**
     * @return {?}
     */
    NzThComponent.prototype.reset = /**
     * @return {?}
     */
    function () {
        this.initMultipleFilterList(true);
        this.initSingleFilterList(true);
        this.hasFilterValue = false;
    };
    /**
     * @param {?} filter
     * @return {?}
     */
    NzThComponent.prototype.checkMultiple = /**
     * @param {?} filter
     * @return {?}
     */
    function (filter) {
        filter.checked = !filter.checked;
    };
    /**
     * @param {?} filter
     * @return {?}
     */
    NzThComponent.prototype.checkSingle = /**
     * @param {?} filter
     * @return {?}
     */
    function (filter) {
        this.singleFilterList.forEach((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return (item.checked = item === filter); }));
    };
    /**
     * @return {?}
     */
    NzThComponent.prototype.hideDropDown = /**
     * @return {?}
     */
    function () {
        this.nzDropDownComponent.setVisibleStateWhen(false);
        this.filterVisible = false;
    };
    /**
     * @param {?} value
     * @return {?}
     */
    NzThComponent.prototype.dropDownVisibleChange = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        this.filterVisible = value;
        if (!value) {
            this.search();
        }
    };
    /**
     * @param {?=} force
     * @return {?}
     */
    NzThComponent.prototype.initMultipleFilterList = /**
     * @param {?=} force
     * @return {?}
     */
    function (force) {
        var _this = this;
        this.multipleFilterList = this.nzFilters.map((/**
         * @param {?} item
         * @return {?}
         */
        function (item) {
            /** @type {?} */
            var checked = force ? false : !!item.byDefault;
            if (checked) {
                _this.hasDefaultFilter = true;
            }
            return { text: item.text, value: item.value, checked: checked };
        }));
        this.checkDefaultFilters();
    };
    /**
     * @param {?=} force
     * @return {?}
     */
    NzThComponent.prototype.initSingleFilterList = /**
     * @param {?=} force
     * @return {?}
     */
    function (force) {
        var _this = this;
        this.singleFilterList = this.nzFilters.map((/**
         * @param {?} item
         * @return {?}
         */
        function (item) {
            /** @type {?} */
            var checked = force ? false : !!item.byDefault;
            if (checked) {
                _this.hasDefaultFilter = true;
            }
            return { text: item.text, value: item.value, checked: checked };
        }));
        this.checkDefaultFilters();
    };
    /**
     * @return {?}
     */
    NzThComponent.prototype.checkDefaultFilters = /**
     * @return {?}
     */
    function () {
        if (!this.nzFilters || this.nzFilters.length === 0 || !this.hasDefaultFilter) {
            return;
        }
        this.updateFilterStatus();
    };
    /**
     * @return {?}
     */
    NzThComponent.prototype.marForCheck = /**
     * @return {?}
     */
    function () {
        this.cdr.markForCheck();
    };
    /**
     * @return {?}
     */
    NzThComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        this.i18n.localeChange.pipe(takeUntil(this.destroy$)).subscribe((/**
         * @return {?}
         */
        function () {
            _this.locale = _this.i18n.getLocaleData('Table');
            _this.cdr.markForCheck();
        }));
    };
    /**
     * @param {?} changes
     * @return {?}
     */
    NzThComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        if (changes.nzFilters) {
            this.initMultipleFilterList();
            this.initSingleFilterList();
            this.updateFilterStatus();
        }
        if (changes.nzWidth) {
            this.nzWidthChange$.next(this.nzWidth);
        }
    };
    /**
     * @return {?}
     */
    NzThComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.destroy$.next();
        this.destroy$.complete();
    };
    NzThComponent.decorators = [
        { type: Component, args: [{
                    // tslint:disable-next-line:component-selector
                    selector: 'th:not(.nz-disable-th)',
                    preserveWhitespaces: false,
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    template: "<ng-template #checkboxTemplate>\n  <label nz-checkbox\n    [class.ant-table-selection-select-all-custom]=\"nzShowRowSelection\"\n    [(ngModel)]=\"nzChecked\"\n    [nzDisabled]=\"nzDisabled\"\n    [nzIndeterminate]=\"nzIndeterminate\"\n    (ngModelChange)=\"nzCheckedChange.emit($event)\">\n  </label>\n</ng-template>\n<span class=\"ant-table-header-column\">\n  <div [class.ant-table-column-sorters]=\"nzShowSort\" (click)=\"updateSortValue()\">\n    <span class=\"ant-table-column-title\">\n      <ng-container *ngIf=\"nzShowCheckbox && !nzShowRowSelection\">\n        <ng-template [ngTemplateOutlet]=\"checkboxTemplate\"></ng-template>\n      </ng-container>\n      <div class=\"ant-table-selection\" *ngIf=\"nzShowRowSelection\">\n        <ng-container *ngIf=\"nzShowCheckbox\">\n          <ng-template [ngTemplateOutlet]=\"checkboxTemplate\"></ng-template>\n        </ng-container>\n        <nz-dropdown nzPlacement=\"bottomLeft\">\n          <div nz-dropdown class=\"ant-table-selection-down\">\n            <i nz-icon type=\"down\"></i>\n          </div>\n          <ul nz-menu class=\"ant-table-selection-menu\">\n            <li nz-menu-item *ngFor=\"let selection of nzSelections\" (click)=\"selection.onSelect()\">{{selection.text}}</li>\n          </ul>\n        </nz-dropdown>\n      </div>\n      <ng-content></ng-content>\n    </span>\n    <ng-content selector=\"nz-dropdown\"></ng-content>\n    <div class=\"ant-table-column-sorter\" *ngIf=\"nzShowSort\">\n      <div class=\"ant-table-column-sorter-inner ant-table-column-sorter-inner-full\">\n        <i nz-icon\n          type=\"caret-up\"\n          class=\"ant-table-column-sorter-up\"\n          [class.on]=\"nzSort == 'ascend'\"\n          [class.off]=\"nzSort != 'ascend'\"></i>\n        <i nz-icon\n          type=\"caret-down\"\n          class=\"ant-table-column-sorter-down\"\n          [class.on]=\"nzSort == 'descend'\"\n          [class.off]=\"nzSort != 'descend'\"></i>\n      </div>\n    </div>\n  </div>\n</span>\n<nz-dropdown nzTrigger=\"click\" *ngIf=\"nzShowFilter\" [nzClickHide]=\"false\" nzTableFilter (nzVisibleChange)=\"dropDownVisibleChange($event)\">\n  <i nz-icon type=\"filter\" theme=\"fill\" [class.ant-table-filter-selected]=\"hasFilterValue\" [class.ant-table-filter-open]=\"filterVisible\" nz-dropdown></i>\n  <ul nz-menu>\n    <ng-container *ngIf=\"nzFilterMultiple\">\n      <li nz-menu-item *ngFor=\"let filter of multipleFilterList\" (click)=\"checkMultiple(filter)\">\n        <label nz-checkbox [ngModel]=\"filter.checked\" (ngModelChange)=\"checkMultiple(filter)\"></label><span>{{filter.text}}</span>\n      </li>\n    </ng-container>\n    <ng-container *ngIf=\"!nzFilterMultiple\">\n      <li nz-menu-item *ngFor=\"let filter of singleFilterList\" (click)=\"checkSingle(filter)\">\n        <label nz-radio [ngModel]=\"filter.checked\" (ngModelChange)=\"checkSingle(filter)\">{{filter.text}}</label>\n      </li>\n    </ng-container>\n  </ul>\n  <div class=\"ant-table-filter-dropdown-btns\">\n    <a class=\"ant-table-filter-dropdown-link confirm\" (click)=\"hideDropDown()\">\n      <span>{{ locale.filterConfirm }}</span>\n    </a>\n    <a class=\"ant-table-filter-dropdown-link clear\" (click)=\"reset();hideDropDown()\">\n      <span>{{ locale.filterReset }}</span>\n    </a>\n  </div>\n</nz-dropdown>\n",
                    host: {
                        '[class.ant-table-column-has-actions]': 'nzShowFilter || nzShowSort || nzCustomFilter',
                        '[class.ant-table-column-has-filters]': 'nzShowFilter || nzCustomFilter',
                        '[class.ant-table-column-has-sorters]': 'nzShowSort',
                        '[class.ant-table-selection-column-custom]': 'nzShowRowSelection',
                        '[class.ant-table-selection-column]': 'nzShowCheckbox',
                        '[class.ant-table-expand-icon-th]': 'nzExpand',
                        '[class.ant-table-th-left-sticky]': 'nzLeft',
                        '[class.ant-table-th-right-sticky]': 'nzRight',
                        '[class.ant-table-column-sort]': "nzSort === 'descend' || nzSort === 'ascend'",
                        '[style.left]': 'nzLeft',
                        '[style.right]': 'nzRight',
                        '[style.text-align]': 'nzAlign'
                    }
                }] }
    ];
    /** @nocollapse */
    NzThComponent.ctorParameters = function () { return [
        { type: ChangeDetectorRef },
        { type: NzI18nService }
    ]; };
    NzThComponent.propDecorators = {
        nzDropDownComponent: [{ type: ViewChild, args: [NzDropDownComponent,] }],
        nzSelections: [{ type: Input }],
        nzChecked: [{ type: Input }],
        nzDisabled: [{ type: Input }],
        nzIndeterminate: [{ type: Input }],
        nzSortKey: [{ type: Input }],
        nzFilterMultiple: [{ type: Input }],
        nzWidth: [{ type: Input }],
        nzLeft: [{ type: Input }],
        nzRight: [{ type: Input }],
        nzAlign: [{ type: Input }],
        nzSort: [{ type: Input }],
        nzFilters: [{ type: Input }],
        nzExpand: [{ type: Input }],
        nzShowCheckbox: [{ type: Input }],
        nzCustomFilter: [{ type: Input }],
        nzShowSort: [{ type: Input }],
        nzShowFilter: [{ type: Input }],
        nzShowRowSelection: [{ type: Input }],
        nzCheckedChange: [{ type: Output }],
        nzSortChange: [{ type: Output }],
        nzSortChangeWithKey: [{ type: Output }],
        nzFilterChange: [{ type: Output }]
    };
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzThComponent.prototype, "nzExpand", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzThComponent.prototype, "nzShowCheckbox", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzThComponent.prototype, "nzCustomFilter", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzThComponent.prototype, "nzShowSort", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzThComponent.prototype, "nzShowFilter", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzThComponent.prototype, "nzShowRowSelection", void 0);
    return NzThComponent;
}());
export { NzThComponent };
if (false) {
    /** @type {?} */
    NzThComponent.prototype.hasFilterValue;
    /** @type {?} */
    NzThComponent.prototype.filterVisible;
    /** @type {?} */
    NzThComponent.prototype.multipleFilterList;
    /** @type {?} */
    NzThComponent.prototype.singleFilterList;
    /** @type {?} */
    NzThComponent.prototype.locale;
    /** @type {?} */
    NzThComponent.prototype.nzWidthChange$;
    /**
     * @type {?}
     * @private
     */
    NzThComponent.prototype.destroy$;
    /**
     * @type {?}
     * @private
     */
    NzThComponent.prototype.hasDefaultFilter;
    /** @type {?} */
    NzThComponent.prototype.nzDropDownComponent;
    /** @type {?} */
    NzThComponent.prototype.nzSelections;
    /** @type {?} */
    NzThComponent.prototype.nzChecked;
    /** @type {?} */
    NzThComponent.prototype.nzDisabled;
    /** @type {?} */
    NzThComponent.prototype.nzIndeterminate;
    /** @type {?} */
    NzThComponent.prototype.nzSortKey;
    /** @type {?} */
    NzThComponent.prototype.nzFilterMultiple;
    /** @type {?} */
    NzThComponent.prototype.nzWidth;
    /** @type {?} */
    NzThComponent.prototype.nzLeft;
    /** @type {?} */
    NzThComponent.prototype.nzRight;
    /** @type {?} */
    NzThComponent.prototype.nzAlign;
    /** @type {?} */
    NzThComponent.prototype.nzSort;
    /** @type {?} */
    NzThComponent.prototype.nzFilters;
    /** @type {?} */
    NzThComponent.prototype.nzExpand;
    /** @type {?} */
    NzThComponent.prototype.nzShowCheckbox;
    /** @type {?} */
    NzThComponent.prototype.nzCustomFilter;
    /** @type {?} */
    NzThComponent.prototype.nzShowSort;
    /** @type {?} */
    NzThComponent.prototype.nzShowFilter;
    /** @type {?} */
    NzThComponent.prototype.nzShowRowSelection;
    /** @type {?} */
    NzThComponent.prototype.nzCheckedChange;
    /** @type {?} */
    NzThComponent.prototype.nzSortChange;
    /** @type {?} */
    NzThComponent.prototype.nzSortChangeWithKey;
    /** @type {?} */
    NzThComponent.prototype.nzFilterChange;
    /**
     * @type {?}
     * @private
     */
    NzThComponent.prototype.cdr;
    /**
     * @type {?}
     * @private
     */
    NzThComponent.prototype.i18n;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotdGguY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC90YWJsZS8iLCJzb3VyY2VzIjpbIm56LXRoLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQ0wsdUJBQXVCLEVBQ3ZCLGlCQUFpQixFQUNqQixTQUFTLEVBQ1QsWUFBWSxFQUNaLEtBQUssRUFJTCxNQUFNLEVBRU4sU0FBUyxFQUNULGlCQUFpQixFQUNsQixNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQUUsT0FBTyxFQUFFLE1BQU0sTUFBTSxDQUFDO0FBQy9CLE9BQU8sRUFBRSxTQUFTLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUUzQyxPQUFPLEVBQUUsUUFBUSxFQUFFLFlBQVksRUFBRSxNQUFNLG9CQUFvQixDQUFDO0FBQzVELE9BQU8sRUFBRSxtQkFBbUIsRUFBRSxNQUFNLHdCQUF3QixDQUFDO0FBQzdELE9BQU8sRUFBbUIsYUFBYSxFQUFFLE1BQU0sb0JBQW9CLENBQUM7Ozs7QUFLcEUsdUNBS0M7OztJQUpDLGlDQUFhOztJQUViLGtDQUFXOztJQUNYLG9DQUFpQjs7QUFHbkI7SUFrS0UsdUJBQW9CLEdBQXNCLEVBQVUsSUFBbUI7UUFBbkQsUUFBRyxHQUFILEdBQUcsQ0FBbUI7UUFBVSxTQUFJLEdBQUosSUFBSSxDQUFlO1FBM0l2RSxtQkFBYyxHQUFHLEtBQUssQ0FBQztRQUN2QixrQkFBYSxHQUFHLEtBQUssQ0FBQztRQUN0Qix1QkFBa0IsR0FBd0IsRUFBRSxDQUFDO1FBQzdDLHFCQUFnQixHQUF3QixFQUFFLENBQUM7O1FBRTNDLFdBQU0sR0FBNkIsbUJBQUEsRUFBRSxFQUE0QixDQUFDO1FBQ2xFLG1CQUFjLEdBQUcsSUFBSSxPQUFPLEVBQUUsQ0FBQztRQUN2QixhQUFRLEdBQUcsSUFBSSxPQUFPLEVBQUUsQ0FBQztRQUN6QixxQkFBZ0IsR0FBRyxLQUFLLENBQUM7O1FBR3hCLGlC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QUN2QixzQ0FBc0I7O0lBQ3RCLDJDQUE2Qzs7SUFDN0MseUNBQTJDOztJQUUzQywrQkFBa0U7O0lBQ2xFLHVDQUErQjs7Ozs7SUFDL0IsaUNBQWlDOzs7OztJQUNqQyx5Q0FBaUM7O0lBQ2pDLDRDQUF5RTs7SUFFekUscUNBQW1GOztJQUNuRixrQ0FBMkI7O0lBQzNCLG1DQUE0Qjs7SUFDNUIsd0NBQWlDOztJQUNqQyxrQ0FBMkI7O0lBQzNCLHlDQUFpQzs7SUFDakMsZ0NBQXlCOztJQUN6QiwrQkFBd0I7O0lBQ3hCLGdDQUF5Qjs7SUFDekIsZ0NBQThDOztJQUM5QywrQkFBb0Q7O0lBQ3BELGtDQUF3Qzs7SUFDeEMsaUNBQTBDOztJQUMxQyx1Q0FBZ0Q7O0lBQ2hELHVDQUFnRDs7SUFDaEQsbUNBQTRDOztJQUM1QyxxQ0FBOEM7O0lBQzlDLDJDQUFvRDs7SUFDcEQsd0NBQWlFOztJQUNqRSxxQ0FBb0U7O0lBQ3BFLDRDQUFtRzs7SUFFbkcsdUNBQW9FOzs7OztJQTBHeEQsNEJBQThCOzs7OztJQUFFLDZCQUEyQiIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gIENvbXBvbmVudCxcbiAgRXZlbnRFbWl0dGVyLFxuICBJbnB1dCxcbiAgT25DaGFuZ2VzLFxuICBPbkRlc3Ryb3ksXG4gIE9uSW5pdCxcbiAgT3V0cHV0LFxuICBTaW1wbGVDaGFuZ2VzLFxuICBWaWV3Q2hpbGQsXG4gIFZpZXdFbmNhcHN1bGF0aW9uXG59IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgU3ViamVjdCB9IGZyb20gJ3J4anMnO1xuaW1wb3J0IHsgdGFrZVVudGlsIH0gZnJvbSAncnhqcy9vcGVyYXRvcnMnO1xuXG5pbXBvcnQgeyBpc05vdE5pbCwgSW5wdXRCb29sZWFuIH0gZnJvbSAnbmctem9ycm8tYW50ZC9jb3JlJztcbmltcG9ydCB7IE56RHJvcERvd25Db21wb25lbnQgfSBmcm9tICduZy16b3Jyby1hbnRkL2Ryb3Bkb3duJztcbmltcG9ydCB7IE56STE4bkludGVyZmFjZSwgTnpJMThuU2VydmljZSB9IGZyb20gJ25nLXpvcnJvLWFudGQvaTE4bic7XG5cbi8qIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpuby1hbnkgKi9cbmV4cG9ydCB0eXBlIE56VGhGaWx0ZXJUeXBlID0gQXJyYXk8eyB0ZXh0OiBzdHJpbmc7IHZhbHVlOiBhbnk7IGJ5RGVmYXVsdD86IGJvb2xlYW4gfT47XG5cbmV4cG9ydCBpbnRlcmZhY2UgTnpUaEl0ZW1JbnRlcmZhY2Uge1xuICB0ZXh0OiBzdHJpbmc7XG4gIC8qIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpuby1hbnkgKi9cbiAgdmFsdWU6IGFueTtcbiAgY2hlY2tlZDogYm9vbGVhbjtcbn1cblxuQENvbXBvbmVudCh7XG4gIC8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpjb21wb25lbnQtc2VsZWN0b3JcbiAgc2VsZWN0b3I6ICd0aDpub3QoLm56LWRpc2FibGUtdGgpJyxcbiAgcHJlc2VydmVXaGl0ZXNwYWNlczogZmFsc2UsXG4gIGVuY2Fwc3VsYXRpb246IFZpZXdFbmNhcHN1bGF0aW9uLk5vbmUsXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxuICB0ZW1wbGF0ZVVybDogJy4vbnotdGguY29tcG9uZW50Lmh0bWwnLFxuICBob3N0OiB7XG4gICAgJ1tjbGFzcy5hbnQtdGFibGUtY29sdW1uLWhhcy1hY3Rpb25zXSc6ICduelNob3dGaWx0ZXIgfHwgbnpTaG93U29ydCB8fCBuekN1c3RvbUZpbHRlcicsXG4gICAgJ1tjbGFzcy5hbnQtdGFibGUtY29sdW1uLWhhcy1maWx0ZXJzXSc6ICduelNob3dGaWx0ZXIgfHwgbnpDdXN0b21GaWx0ZXInLFxuICAgICdbY2xhc3MuYW50LXRhYmxlLWNvbHVtbi1oYXMtc29ydGVyc10nOiAnbnpTaG93U29ydCcsXG4gICAgJ1tjbGFzcy5hbnQtdGFibGUtc2VsZWN0aW9uLWNvbHVtbi1jdXN0b21dJzogJ256U2hvd1Jvd1NlbGVjdGlvbicsXG4gICAgJ1tjbGFzcy5hbnQtdGFibGUtc2VsZWN0aW9uLWNvbHVtbl0nOiAnbnpTaG93Q2hlY2tib3gnLFxuICAgICdbY2xhc3MuYW50LXRhYmxlLWV4cGFuZC1pY29uLXRoXSc6ICduekV4cGFuZCcsXG4gICAgJ1tjbGFzcy5hbnQtdGFibGUtdGgtbGVmdC1zdGlja3ldJzogJ256TGVmdCcsXG4gICAgJ1tjbGFzcy5hbnQtdGFibGUtdGgtcmlnaHQtc3RpY2t5XSc6ICduelJpZ2h0JyxcbiAgICAnW2NsYXNzLmFudC10YWJsZS1jb2x1bW4tc29ydF0nOiBgbnpTb3J0ID09PSAnZGVzY2VuZCcgfHwgbnpTb3J0ID09PSAnYXNjZW5kJ2AsXG4gICAgJ1tzdHlsZS5sZWZ0XSc6ICduekxlZnQnLFxuICAgICdbc3R5bGUucmlnaHRdJzogJ256UmlnaHQnLFxuICAgICdbc3R5bGUudGV4dC1hbGlnbl0nOiAnbnpBbGlnbidcbiAgfVxufSlcbmV4cG9ydCBjbGFzcyBOelRoQ29tcG9uZW50IGltcGxlbWVudHMgT25DaGFuZ2VzLCBPbkluaXQsIE9uRGVzdHJveSB7XG4gIGhhc0ZpbHRlclZhbHVlID0gZmFsc2U7XG4gIGZpbHRlclZpc2libGUgPSBmYWxzZTtcbiAgbXVsdGlwbGVGaWx0ZXJMaXN0OiBOelRoSXRlbUludGVyZmFjZVtdID0gW107XG4gIHNpbmdsZUZpbHRlckxpc3Q6IE56VGhJdGVtSW50ZXJmYWNlW10gPSBbXTtcbiAgLyogdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOm5vLWFueSAqL1xuICBsb2NhbGU6IE56STE4bkludGVyZmFjZVsnVGFibGUnXSA9IHt9IGFzIE56STE4bkludGVyZmFjZVsnVGFibGUnXTtcbiAgbnpXaWR0aENoYW5nZSQgPSBuZXcgU3ViamVjdCgpO1xuICBwcml2YXRlIGRlc3Ryb3kkID0gbmV3IFN1YmplY3QoKTtcbiAgcHJpdmF0ZSBoYXNEZWZhdWx0RmlsdGVyID0gZmFsc2U7XG4gIEBWaWV3Q2hpbGQoTnpEcm9wRG93bkNvbXBvbmVudCkgbnpEcm9wRG93bkNvbXBvbmVudDogTnpEcm9wRG93bkNvbXBvbmVudDtcbiAgLyogdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOm5vLWFueSAqL1xuICBASW5wdXQoKSBuelNlbGVjdGlvbnM6IEFycmF5PHsgdGV4dDogc3RyaW5nOyBvblNlbGVjdCguLi5hcmdzOiBhbnlbXSk6IGFueSB9PiA9IFtdO1xuICBASW5wdXQoKSBuekNoZWNrZWQgPSBmYWxzZTtcbiAgQElucHV0KCkgbnpEaXNhYmxlZCA9IGZhbHNlO1xuICBASW5wdXQoKSBuekluZGV0ZXJtaW5hdGUgPSBmYWxzZTtcbiAgQElucHV0KCkgbnpTb3J0S2V5OiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56RmlsdGVyTXVsdGlwbGUgPSB0cnVlO1xuICBASW5wdXQoKSBueldpZHRoOiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56TGVmdDogc3RyaW5nO1xuICBASW5wdXQoKSBuelJpZ2h0OiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56QWxpZ246ICdsZWZ0JyB8ICdyaWdodCcgfCAnY2VudGVyJztcbiAgQElucHV0KCkgbnpTb3J0OiAnYXNjZW5kJyB8ICdkZXNjZW5kJyB8IG51bGwgPSBudWxsO1xuICBASW5wdXQoKSBuekZpbHRlcnM6IE56VGhGaWx0ZXJUeXBlID0gW107XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekV4cGFuZCA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpTaG93Q2hlY2tib3ggPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56Q3VzdG9tRmlsdGVyID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuelNob3dTb3J0ID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuelNob3dGaWx0ZXIgPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56U2hvd1Jvd1NlbGVjdGlvbiA9IGZhbHNlO1xuICBAT3V0cHV0KCkgcmVhZG9ubHkgbnpDaGVja2VkQ2hhbmdlID0gbmV3IEV2ZW50RW1pdHRlcjxib29sZWFuPigpO1xuICBAT3V0cHV0KCkgcmVhZG9ubHkgbnpTb3J0Q2hhbmdlID0gbmV3IEV2ZW50RW1pdHRlcjxzdHJpbmcgfCBudWxsPigpO1xuICBAT3V0cHV0KCkgcmVhZG9ubHkgbnpTb3J0Q2hhbmdlV2l0aEtleSA9IG5ldyBFdmVudEVtaXR0ZXI8eyBrZXk6IHN0cmluZzsgdmFsdWU6IHN0cmluZyB8IG51bGwgfT4oKTtcbiAgLyogdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOm5vLWFueSAqL1xuICBAT3V0cHV0KCkgcmVhZG9ubHkgbnpGaWx0ZXJDaGFuZ2UgPSBuZXcgRXZlbnRFbWl0dGVyPGFueVtdIHwgYW55PigpO1xuXG4gIHVwZGF0ZVNvcnRWYWx1ZSgpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5uelNob3dTb3J0KSB7XG4gICAgICBpZiAodGhpcy5uelNvcnQgPT09ICdkZXNjZW5kJykge1xuICAgICAgICB0aGlzLnNldFNvcnRWYWx1ZSgnYXNjZW5kJyk7XG4gICAgICB9IGVsc2UgaWYgKHRoaXMubnpTb3J0ID09PSAnYXNjZW5kJykge1xuICAgICAgICB0aGlzLnNldFNvcnRWYWx1ZShudWxsKTtcbiAgICAgIH0gZWxzZSB7XG4gICAgICAgIHRoaXMuc2V0U29ydFZhbHVlKCdkZXNjZW5kJyk7XG4gICAgICB9XG4gICAgfVxuICB9XG5cbiAgc2V0U29ydFZhbHVlKHZhbHVlOiAnYXNjZW5kJyB8ICdkZXNjZW5kJyB8IG51bGwpOiB2b2lkIHtcbiAgICB0aGlzLm56U29ydCA9IHZhbHVlO1xuICAgIHRoaXMubnpTb3J0Q2hhbmdlV2l0aEtleS5lbWl0KHsga2V5OiB0aGlzLm56U29ydEtleSwgdmFsdWU6IHRoaXMubnpTb3J0IH0pO1xuICAgIHRoaXMubnpTb3J0Q2hhbmdlLmVtaXQodGhpcy5uelNvcnQpO1xuICB9XG5cbiAgZ2V0IGZpbHRlckxpc3QoKTogTnpUaEl0ZW1JbnRlcmZhY2VbXSB7XG4gICAgcmV0dXJuIHRoaXMubXVsdGlwbGVGaWx0ZXJMaXN0LmZpbHRlcihpdGVtID0+IGl0ZW0uY2hlY2tlZCkubWFwKGl0ZW0gPT4gaXRlbS52YWx1ZSk7XG4gIH1cblxuICAvKiB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6bm8tYW55ICovXG4gIGdldCBmaWx0ZXJWYWx1ZSgpOiBhbnkge1xuICAgIGNvbnN0IGNoZWNrZWRGaWx0ZXIgPSB0aGlzLnNpbmdsZUZpbHRlckxpc3QuZmluZChpdGVtID0+IGl0ZW0uY2hlY2tlZCk7XG4gICAgcmV0dXJuIGNoZWNrZWRGaWx0ZXIgPyBjaGVja2VkRmlsdGVyLnZhbHVlIDogbnVsbDtcbiAgfVxuXG4gIHVwZGF0ZUZpbHRlclN0YXR1cygpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5uekZpbHRlck11bHRpcGxlKSB7XG4gICAgICB0aGlzLmhhc0ZpbHRlclZhbHVlID0gdGhpcy5maWx0ZXJMaXN0Lmxlbmd0aCA+IDA7XG4gICAgfSBlbHNlIHtcbiAgICAgIHRoaXMuaGFzRmlsdGVyVmFsdWUgPSBpc05vdE5pbCh0aGlzLmZpbHRlclZhbHVlKTtcbiAgICB9XG4gIH1cblxuICBzZWFyY2goKTogdm9pZCB7XG4gICAgdGhpcy51cGRhdGVGaWx0ZXJTdGF0dXMoKTtcbiAgICBpZiAodGhpcy5uekZpbHRlck11bHRpcGxlKSB7XG4gICAgICB0aGlzLm56RmlsdGVyQ2hhbmdlLmVtaXQodGhpcy5maWx0ZXJMaXN0KTtcbiAgICB9IGVsc2Uge1xuICAgICAgdGhpcy5uekZpbHRlckNoYW5nZS5lbWl0KHRoaXMuZmlsdGVyVmFsdWUpO1xuICAgIH1cbiAgfVxuXG4gIHJlc2V0KCk6IHZvaWQge1xuICAgIHRoaXMuaW5pdE11bHRpcGxlRmlsdGVyTGlzdCh0cnVlKTtcbiAgICB0aGlzLmluaXRTaW5nbGVGaWx0ZXJMaXN0KHRydWUpO1xuICAgIHRoaXMuaGFzRmlsdGVyVmFsdWUgPSBmYWxzZTtcbiAgfVxuXG4gIGNoZWNrTXVsdGlwbGUoZmlsdGVyOiBOelRoSXRlbUludGVyZmFjZSk6IHZvaWQge1xuICAgIGZpbHRlci5jaGVja2VkID0gIWZpbHRlci5jaGVja2VkO1xuICB9XG5cbiAgY2hlY2tTaW5nbGUoZmlsdGVyOiBOelRoSXRlbUludGVyZmFjZSk6IHZvaWQge1xuICAgIHRoaXMuc2luZ2xlRmlsdGVyTGlzdC5mb3JFYWNoKGl0ZW0gPT4gKGl0ZW0uY2hlY2tlZCA9IGl0ZW0gPT09IGZpbHRlcikpO1xuICB9XG5cbiAgaGlkZURyb3BEb3duKCk6IHZvaWQge1xuICAgIHRoaXMubnpEcm9wRG93bkNvbXBvbmVudC5zZXRWaXNpYmxlU3RhdGVXaGVuKGZhbHNlKTtcbiAgICB0aGlzLmZpbHRlclZpc2libGUgPSBmYWxzZTtcbiAgfVxuXG4gIGRyb3BEb3duVmlzaWJsZUNoYW5nZSh2YWx1ZTogYm9vbGVhbik6IHZvaWQge1xuICAgIHRoaXMuZmlsdGVyVmlzaWJsZSA9IHZhbHVlO1xuICAgIGlmICghdmFsdWUpIHtcbiAgICAgIHRoaXMuc2VhcmNoKCk7XG4gICAgfVxuICB9XG5cbiAgaW5pdE11bHRpcGxlRmlsdGVyTGlzdChmb3JjZT86IGJvb2xlYW4pOiB2b2lkIHtcbiAgICB0aGlzLm11bHRpcGxlRmlsdGVyTGlzdCA9IHRoaXMubnpGaWx0ZXJzLm1hcChpdGVtID0+IHtcbiAgICAgIGNvbnN0IGNoZWNrZWQgPSBmb3JjZSA/IGZhbHNlIDogISFpdGVtLmJ5RGVmYXVsdDtcbiAgICAgIGlmIChjaGVja2VkKSB7XG4gICAgICAgIHRoaXMuaGFzRGVmYXVsdEZpbHRlciA9IHRydWU7XG4gICAgICB9XG4gICAgICByZXR1cm4geyB0ZXh0OiBpdGVtLnRleHQsIHZhbHVlOiBpdGVtLnZhbHVlLCBjaGVja2VkIH07XG4gICAgfSk7XG4gICAgdGhpcy5jaGVja0RlZmF1bHRGaWx0ZXJzKCk7XG4gIH1cblxuICBpbml0U2luZ2xlRmlsdGVyTGlzdChmb3JjZT86IGJvb2xlYW4pOiB2b2lkIHtcbiAgICB0aGlzLnNpbmdsZUZpbHRlckxpc3QgPSB0aGlzLm56RmlsdGVycy5tYXAoaXRlbSA9PiB7XG4gICAgICBjb25zdCBjaGVja2VkID0gZm9yY2UgPyBmYWxzZSA6ICEhaXRlbS5ieURlZmF1bHQ7XG4gICAgICBpZiAoY2hlY2tlZCkge1xuICAgICAgICB0aGlzLmhhc0RlZmF1bHRGaWx0ZXIgPSB0cnVlO1xuICAgICAgfVxuICAgICAgcmV0dXJuIHsgdGV4dDogaXRlbS50ZXh0LCB2YWx1ZTogaXRlbS52YWx1ZSwgY2hlY2tlZCB9O1xuICAgIH0pO1xuICAgIHRoaXMuY2hlY2tEZWZhdWx0RmlsdGVycygpO1xuICB9XG5cbiAgY2hlY2tEZWZhdWx0RmlsdGVycygpOiB2b2lkIHtcbiAgICBpZiAoIXRoaXMubnpGaWx0ZXJzIHx8IHRoaXMubnpGaWx0ZXJzLmxlbmd0aCA9PT0gMCB8fCAhdGhpcy5oYXNEZWZhdWx0RmlsdGVyKSB7XG4gICAgICByZXR1cm47XG4gICAgfVxuICAgIHRoaXMudXBkYXRlRmlsdGVyU3RhdHVzKCk7XG4gIH1cblxuICBtYXJGb3JDaGVjaygpOiB2b2lkIHtcbiAgICB0aGlzLmNkci5tYXJrRm9yQ2hlY2soKTtcbiAgfVxuXG4gIGNvbnN0cnVjdG9yKHByaXZhdGUgY2RyOiBDaGFuZ2VEZXRlY3RvclJlZiwgcHJpdmF0ZSBpMThuOiBOekkxOG5TZXJ2aWNlKSB7fVxuXG4gIG5nT25Jbml0KCk6IHZvaWQge1xuICAgIHRoaXMuaTE4bi5sb2NhbGVDaGFuZ2UucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpLnN1YnNjcmliZSgoKSA9PiB7XG4gICAgICB0aGlzLmxvY2FsZSA9IHRoaXMuaTE4bi5nZXRMb2NhbGVEYXRhKCdUYWJsZScpO1xuICAgICAgdGhpcy5jZHIubWFya0ZvckNoZWNrKCk7XG4gICAgfSk7XG4gIH1cblxuICBuZ09uQ2hhbmdlcyhjaGFuZ2VzOiBTaW1wbGVDaGFuZ2VzKTogdm9pZCB7XG4gICAgaWYgKGNoYW5nZXMubnpGaWx0ZXJzKSB7XG4gICAgICB0aGlzLmluaXRNdWx0aXBsZUZpbHRlckxpc3QoKTtcbiAgICAgIHRoaXMuaW5pdFNpbmdsZUZpbHRlckxpc3QoKTtcbiAgICAgIHRoaXMudXBkYXRlRmlsdGVyU3RhdHVzKCk7XG4gICAgfVxuICAgIGlmIChjaGFuZ2VzLm56V2lkdGgpIHtcbiAgICAgIHRoaXMubnpXaWR0aENoYW5nZSQubmV4dCh0aGlzLm56V2lkdGgpO1xuICAgIH1cbiAgfVxuXG4gIG5nT25EZXN0cm95KCk6IHZvaWQge1xuICAgIHRoaXMuZGVzdHJveSQubmV4dCgpO1xuICAgIHRoaXMuZGVzdHJveSQuY29tcGxldGUoKTtcbiAgfVxufVxuIl19