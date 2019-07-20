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
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output, TemplateRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { isInteger, toNumber, InputBoolean, InputNumber } from 'ng-zorro-antd/core';
import { NzI18nService } from 'ng-zorro-antd/i18n';
var NzPaginationComponent = /** @class */ (function () {
    function NzPaginationComponent(i18n, cdr) {
        this.i18n = i18n;
        this.cdr = cdr;
        // tslint:disable-next-line:no-any
        this.locale = {};
        this.firstIndex = 1;
        this.pages = [];
        this.$destroy = new Subject();
        this.nzPageSizeChange = new EventEmitter();
        this.nzPageIndexChange = new EventEmitter();
        this.nzInTable = false;
        this.nzSize = 'default';
        this.nzPageSizeOptions = [10, 20, 30, 40];
        this.nzShowSizeChanger = false;
        this.nzHideOnSinglePage = false;
        this.nzShowQuickJumper = false;
        this.nzSimple = false;
        this.nzTotal = 0;
        this.nzPageIndex = 1;
        this.nzPageSize = 10;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    NzPaginationComponent.prototype.validatePageIndex = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        if (value > this.lastIndex) {
            return this.lastIndex;
        }
        else if (value < this.firstIndex) {
            return this.firstIndex;
        }
        else {
            return value;
        }
    };
    /**
     * @param {?} page
     * @return {?}
     */
    NzPaginationComponent.prototype.updatePageIndexValue = /**
     * @param {?} page
     * @return {?}
     */
    function (page) {
        this.nzPageIndex = page;
        this.nzPageIndexChange.emit(this.nzPageIndex);
        this.buildIndexes();
    };
    /**
     * @param {?} value
     * @return {?}
     */
    NzPaginationComponent.prototype.isPageIndexValid = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        return this.validatePageIndex(value) === value;
    };
    /**
     * @param {?} index
     * @return {?}
     */
    NzPaginationComponent.prototype.jumpPage = /**
     * @param {?} index
     * @return {?}
     */
    function (index) {
        if (index !== this.nzPageIndex) {
            /** @type {?} */
            var pageIndex = this.validatePageIndex(index);
            if (pageIndex !== this.nzPageIndex) {
                this.updatePageIndexValue(pageIndex);
            }
        }
    };
    /**
     * @param {?} diff
     * @return {?}
     */
    NzPaginationComponent.prototype.jumpDiff = /**
     * @param {?} diff
     * @return {?}
     */
    function (diff) {
        this.jumpPage(this.nzPageIndex + diff);
    };
    /**
     * @param {?} $event
     * @return {?}
     */
    NzPaginationComponent.prototype.onPageSizeChange = /**
     * @param {?} $event
     * @return {?}
     */
    function ($event) {
        this.nzPageSize = $event;
        this.nzPageSizeChange.emit($event);
        this.buildIndexes();
        if (this.nzPageIndex > this.lastIndex) {
            this.updatePageIndexValue(this.lastIndex);
        }
    };
    /**
     * @param {?} _
     * @param {?} input
     * @param {?} clearInputValue
     * @return {?}
     */
    NzPaginationComponent.prototype.handleKeyDown = /**
     * @param {?} _
     * @param {?} input
     * @param {?} clearInputValue
     * @return {?}
     */
    function (_, input, clearInputValue) {
        /** @type {?} */
        var target = input;
        /** @type {?} */
        var page = toNumber(target.value, this.nzPageIndex);
        if (isInteger(page) && this.isPageIndexValid(page) && page !== this.nzPageIndex) {
            this.updatePageIndexValue(page);
        }
        if (clearInputValue) {
            target.value = '';
        }
        else {
            target.value = "" + this.nzPageIndex;
        }
    };
    /** generate indexes list */
    /**
     * generate indexes list
     * @return {?}
     */
    NzPaginationComponent.prototype.buildIndexes = /**
     * generate indexes list
     * @return {?}
     */
    function () {
        /** @type {?} */
        var pages = [];
        if (this.lastIndex <= 9) {
            for (var i = 2; i <= this.lastIndex - 1; i++) {
                pages.push(i);
            }
        }
        else {
            /** @type {?} */
            var current = +this.nzPageIndex;
            /** @type {?} */
            var left = Math.max(2, current - 2);
            /** @type {?} */
            var right = Math.min(current + 2, this.lastIndex - 1);
            if (current - 1 <= 2) {
                right = 5;
            }
            if (this.lastIndex - current <= 2) {
                left = this.lastIndex - 4;
            }
            for (var i = left; i <= right; i++) {
                pages.push(i);
            }
        }
        this.pages = pages;
        this.cdr.markForCheck();
    };
    Object.defineProperty(NzPaginationComponent.prototype, "lastIndex", {
        get: /**
         * @return {?}
         */
        function () {
            return Math.ceil(this.nzTotal / this.nzPageSize);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzPaginationComponent.prototype, "isLastIndex", {
        get: /**
         * @return {?}
         */
        function () {
            return this.nzPageIndex === this.lastIndex;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzPaginationComponent.prototype, "isFirstIndex", {
        get: /**
         * @return {?}
         */
        function () {
            return this.nzPageIndex === this.firstIndex;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzPaginationComponent.prototype, "ranges", {
        get: /**
         * @return {?}
         */
        function () {
            return [(this.nzPageIndex - 1) * this.nzPageSize + 1, Math.min(this.nzPageIndex * this.nzPageSize, this.nzTotal)];
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzPaginationComponent.prototype, "showAddOption", {
        get: /**
         * @return {?}
         */
        function () {
            return this.nzPageSizeOptions.indexOf(this.nzPageSize) === -1;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    NzPaginationComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        this.i18n.localeChange.pipe(takeUntil(this.$destroy)).subscribe((/**
         * @return {?}
         */
        function () {
            _this.locale = _this.i18n.getLocaleData('Pagination');
            _this.cdr.markForCheck();
        }));
    };
    /**
     * @return {?}
     */
    NzPaginationComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.$destroy.next();
        this.$destroy.complete();
    };
    /**
     * @param {?} changes
     * @return {?}
     */
    NzPaginationComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        if (changes.nzTotal || changes.nzPageSize || changes.nzPageIndex) {
            this.buildIndexes();
        }
    };
    NzPaginationComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-pagination',
                    exportAs: 'nzPagination',
                    preserveWhitespaces: false,
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    template: "<ng-template #renderItemTemplate let-type let-page=\"page\">\n  <a class=\"ant-pagination-item-link\" *ngIf=\"type==='pre'\"><i nz-icon type=\"left\"></i></a>\n  <a class=\"ant-pagination-item-link\" *ngIf=\"type==='next'\"><i nz-icon type=\"right\"></i></a>\n  <a *ngIf=\"type=='page'\">{{ page }}</a>\n</ng-template>\n<ng-container *ngIf=\"nzHideOnSinglePage && (nzTotal > nzPageSize) || !nzHideOnSinglePage\">\n  <ul class=\"ant-pagination\"\n    [class.ant-table-pagination]=\"nzInTable\"\n    [class.ant-pagination-simple]=\"nzSimple\"\n    [class.mini]=\"(nzSize === 'small') && !nzSimple\">\n    <ng-container *ngIf=\"nzSimple; else normalTemplate\">\n      <li class=\"ant-pagination-prev\"\n        [attr.title]=\"locale.prev_page\"\n        [class.ant-pagination-disabled]=\"isFirstIndex\"\n        (click)=\"jumpDiff(-1)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'pre'}\"></ng-template>\n      </li>\n      <li [attr.title]=\"nzPageIndex+'/'+lastIndex\" class=\"ant-pagination-simple-pager\">\n        <input #simplePagerInput [value]=\"nzPageIndex\" (keydown.enter)=\"handleKeyDown($event,simplePagerInput,false)\" size=\"3\">\n        <span class=\"ant-pagination-slash\">\uFF0F</span>\n        {{ lastIndex }}\n      </li>\n      <li class=\"ant-pagination-next\"\n        [attr.title]=\"locale.next_page\"\n        [class.ant-pagination-disabled]=\"isLastIndex\"\n        (click)=\"jumpDiff(1)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'next'}\"></ng-template>\n      </li>\n    </ng-container>\n    <ng-template #normalTemplate>\n      <li class=\"ant-pagination-total-text\" *ngIf=\"nzShowTotal\">\n        <ng-template [ngTemplateOutlet]=\"nzShowTotal\" [ngTemplateOutletContext]=\"{ $implicit: nzTotal,range:ranges }\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-prev\"\n        [attr.title]=\"locale.prev_page\"\n        [class.ant-pagination-disabled]=\"isFirstIndex\"\n        (click)=\"jumpDiff(-1)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'pre'}\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-item\"\n        [attr.title]=\"firstIndex\"\n        [class.ant-pagination-item-active]=\"isFirstIndex\"\n        (click)=\"jumpPage(firstIndex)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'page',page: firstIndex }\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-jump-prev\"\n        *ngIf=\"(lastIndex > 9) && (nzPageIndex - 3 > firstIndex)\"\n        [attr.title]=\"locale.prev_5\"\n        (click)=\"jumpDiff(-5)\">\n        <a class=\"ant-pagination-item-link\">\n          <div class=\"ant-pagination-item-container\">\n            <i nz-icon type=\"double-left\" class=\"ant-pagination-item-link-icon\"></i>\n            <span class=\"ant-pagination-item-ellipsis\">\u2022\u2022\u2022</span>\n          </div>\n        </a>\n      </li>\n      <li class=\"ant-pagination-item\"\n        *ngFor=\"let page of pages\"\n        [attr.title]=\"page\"\n        [class.ant-pagination-item-active]=\"nzPageIndex === page\"\n        (click)=\"jumpPage(page)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'page',page: page }\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-jump-next ant-pagination-item-link-icon\"\n        [attr.title]=\"locale.next_5\"\n        (click)=\"jumpDiff(5)\"\n        *ngIf=\"(lastIndex > 9) && (nzPageIndex + 3 < lastIndex)\">\n        <a class=\"ant-pagination-item-link\">\n          <div class=\"ant-pagination-item-container\">\n            <i nz-icon type=\"double-right\" class=\"ant-pagination-item-link-icon\"></i>\n            <span class=\"ant-pagination-item-ellipsis\">\u2022\u2022\u2022</span>\n          </div>\n        </a>\n      </li>\n      <li class=\"ant-pagination-item\"\n        [attr.title]=\"lastIndex\"\n        (click)=\"jumpPage(lastIndex)\"\n        *ngIf=\"(lastIndex > 0) && (lastIndex !== firstIndex)\"\n        [class.ant-pagination-item-active]=\"isLastIndex\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'page',page: lastIndex }\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-next\"\n        [title]=\"locale.next_page\"\n        [class.ant-pagination-disabled]=\"isLastIndex\"\n        (click)=\"jumpDiff(1)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'next'}\"></ng-template>\n      </li>\n      <div class=\"ant-pagination-options\" *ngIf=\"nzShowQuickJumper || nzShowSizeChanger\">\n        <nz-select class=\"ant-pagination-options-size-changer\"\n          *ngIf=\"nzShowSizeChanger\"\n          [nzSize]=\"nzSize\"\n          [ngModel]=\"nzPageSize\"\n          (ngModelChange)=\"onPageSizeChange($event)\">\n          <nz-option *ngFor=\"let option of nzPageSizeOptions\"\n            [nzLabel]=\"option + locale.items_per_page\"\n            [nzValue]=\"option\">\n          </nz-option>\n          <nz-option *ngIf=\"showAddOption\"\n            [nzLabel]=\"nzPageSize + locale.items_per_page\"\n            [nzValue]=\"nzPageSize\">\n          </nz-option>\n        </nz-select>\n        <div class=\"ant-pagination-options-quick-jumper\" *ngIf=\"nzShowQuickJumper\">\n          {{ locale.jump_to }}\n          <input #quickJumperInput (keydown.enter)=\"handleKeyDown($event,quickJumperInput,true)\">\n          {{ locale.page }}\n        </div>\n      </div>\n    </ng-template>\n  </ul>\n</ng-container>"
                }] }
    ];
    /** @nocollapse */
    NzPaginationComponent.ctorParameters = function () { return [
        { type: NzI18nService },
        { type: ChangeDetectorRef }
    ]; };
    NzPaginationComponent.propDecorators = {
        nzPageSizeChange: [{ type: Output }],
        nzPageIndexChange: [{ type: Output }],
        nzShowTotal: [{ type: Input }],
        nzInTable: [{ type: Input }],
        nzSize: [{ type: Input }],
        nzPageSizeOptions: [{ type: Input }],
        nzItemRender: [{ type: Input }, { type: ViewChild, args: ['renderItemTemplate',] }],
        nzShowSizeChanger: [{ type: Input }],
        nzHideOnSinglePage: [{ type: Input }],
        nzShowQuickJumper: [{ type: Input }],
        nzSimple: [{ type: Input }],
        nzTotal: [{ type: Input }],
        nzPageIndex: [{ type: Input }],
        nzPageSize: [{ type: Input }]
    };
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzPaginationComponent.prototype, "nzShowSizeChanger", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzPaginationComponent.prototype, "nzHideOnSinglePage", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzPaginationComponent.prototype, "nzShowQuickJumper", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzPaginationComponent.prototype, "nzSimple", void 0);
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Object)
    ], NzPaginationComponent.prototype, "nzTotal", void 0);
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Object)
    ], NzPaginationComponent.prototype, "nzPageIndex", void 0);
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Object)
    ], NzPaginationComponent.prototype, "nzPageSize", void 0);
    return NzPaginationComponent;
}());
export { NzPaginationComponent };
if (false) {
    /** @type {?} */
    NzPaginationComponent.prototype.locale;
    /** @type {?} */
    NzPaginationComponent.prototype.firstIndex;
    /** @type {?} */
    NzPaginationComponent.prototype.pages;
    /**
     * @type {?}
     * @private
     */
    NzPaginationComponent.prototype.$destroy;
    /** @type {?} */
    NzPaginationComponent.prototype.nzPageSizeChange;
    /** @type {?} */
    NzPaginationComponent.prototype.nzPageIndexChange;
    /** @type {?} */
    NzPaginationComponent.prototype.nzShowTotal;
    /** @type {?} */
    NzPaginationComponent.prototype.nzInTable;
    /** @type {?} */
    NzPaginationComponent.prototype.nzSize;
    /** @type {?} */
    NzPaginationComponent.prototype.nzPageSizeOptions;
    /** @type {?} */
    NzPaginationComponent.prototype.nzItemRender;
    /** @type {?} */
    NzPaginationComponent.prototype.nzShowSizeChanger;
    /** @type {?} */
    NzPaginationComponent.prototype.nzHideOnSinglePage;
    /** @type {?} */
    NzPaginationComponent.prototype.nzShowQuickJumper;
    /** @type {?} */
    NzPaginationComponent.prototype.nzSimple;
    /** @type {?} */
    NzPaginationComponent.prototype.nzTotal;
    /** @type {?} */
    NzPaginationComponent.prototype.nzPageIndex;
    /** @type {?} */
    NzPaginationComponent.prototype.nzPageSize;
    /**
     * @type {?}
     * @private
     */
    NzPaginationComponent.prototype.i18n;
    /**
     * @type {?}
     * @private
     */
    NzPaginationComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotcGFnaW5hdGlvbi5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9uZy16b3Jyby1hbnRkL3BhZ2luYXRpb24vIiwic291cmNlcyI6WyJuei1wYWdpbmF0aW9uLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQ0wsdUJBQXVCLEVBQ3ZCLGlCQUFpQixFQUNqQixTQUFTLEVBQ1QsWUFBWSxFQUNaLEtBQUssRUFJTCxNQUFNLEVBRU4sV0FBVyxFQUNYLFNBQVMsRUFDVCxpQkFBaUIsRUFDbEIsTUFBTSxlQUFlLENBQUM7QUFDdkIsT0FBTyxFQUFFLE9BQU8sRUFBRSxNQUFNLE1BQU0sQ0FBQztBQUMvQixPQUFPLEVBQUUsU0FBUyxFQUFFLE1BQU0sZ0JBQWdCLENBQUM7QUFFM0MsT0FBTyxFQUFFLFNBQVMsRUFBRSxRQUFRLEVBQUUsWUFBWSxFQUFFLFdBQVcsRUFBRSxNQUFNLG9CQUFvQixDQUFDO0FBQ3BGLE9BQU8sRUFBRSxhQUFhLEVBQUUsTUFBTSxvQkFBb0IsQ0FBQztBQUVuRDtJQW9JRSwrQkFBb0IsSUFBbUIsRUFBVSxHQUFzQjtRQUFuRCxTQUFJLEdBQUosSUFBSSxDQUFlO1FBQVUsUUFBRyxHQUFILEdBQUcsQ0FBbUI7O1FBMUh2RSxXQUFNLEdBQVEsRUFBRSxDQUFDO1FBQ2pCLGVBQVUsR0FBRyxDQUFDLENBQUM7UUFDZixVQUFLLEdBQWEsRUFBRSxDQUFDO1FBQ2IsYUFBUSxHQUFHLElBQUksT0FBTyxFQUFRLENBQUM7UUFDcEIscUJBQWdCLEdBQXlCLElBQUksWUFBWSxFQUFFLENBQUM7UUFDNUQsc0JBQWlCLEdBQXlCLElBQUksWUFBWSxFQUFFLENBQUM7UUFFdkUsY0FBUyxHQUFHLEtBQUssQ0FBQztRQUNsQixXQUFNLEdBQXdCLFNBQVMsQ0FBQztRQUN4QyxzQkFBaUIsR0FBRyxDQUFDLEVBQUUsRUFBRSxFQUFFLEVBQUUsRUFBRSxFQUFFLEVBQUUsQ0FBQyxDQUFD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O0lBQ2xGLDBDQUEyQjs7SUFDM0IsdUNBQWlEOztJQUNqRCxrREFBOEM7O0lBQzlDLDZDQUdHOztJQUNILGtEQUFtRDs7SUFDbkQsbURBQW9EOztJQUNwRCxrREFBbUQ7O0lBQ25ELHlDQUEwQzs7SUFDMUMsd0NBQW9DOztJQUNwQyw0Q0FBd0M7O0lBQ3hDLDJDQUF3Qzs7Ozs7SUFzRzVCLHFDQUEyQjs7Ozs7SUFBRSxvQ0FBOEIiLCJzb3VyY2VzQ29udGVudCI6WyIvKipcbiAqIEBsaWNlbnNlXG4gKiBDb3B5cmlnaHQgQWxpYmFiYS5jb20gQWxsIFJpZ2h0cyBSZXNlcnZlZC5cbiAqXG4gKiBVc2Ugb2YgdGhpcyBzb3VyY2UgY29kZSBpcyBnb3Zlcm5lZCBieSBhbiBNSVQtc3R5bGUgbGljZW5zZSB0aGF0IGNhbiBiZVxuICogZm91bmQgaW4gdGhlIExJQ0VOU0UgZmlsZSBhdCBodHRwczovL2dpdGh1Yi5jb20vTkctWk9SUk8vbmctem9ycm8tYW50ZC9ibG9iL21hc3Rlci9MSUNFTlNFXG4gKi9cblxuaW1wb3J0IHtcbiAgQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3ksXG4gIENoYW5nZURldGVjdG9yUmVmLFxuICBDb21wb25lbnQsXG4gIEV2ZW50RW1pdHRlcixcbiAgSW5wdXQsXG4gIE9uQ2hhbmdlcyxcbiAgT25EZXN0cm95LFxuICBPbkluaXQsXG4gIE91dHB1dCxcbiAgU2ltcGxlQ2hhbmdlcyxcbiAgVGVtcGxhdGVSZWYsXG4gIFZpZXdDaGlsZCxcbiAgVmlld0VuY2Fwc3VsYXRpb25cbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBTdWJqZWN0IH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyB0YWtlVW50aWwgfSBmcm9tICdyeGpzL29wZXJhdG9ycyc7XG5cbmltcG9ydCB7IGlzSW50ZWdlciwgdG9OdW1iZXIsIElucHV0Qm9vbGVhbiwgSW5wdXROdW1iZXIgfSBmcm9tICduZy16b3Jyby1hbnRkL2NvcmUnO1xuaW1wb3J0IHsgTnpJMThuU2VydmljZSB9IGZyb20gJ25nLXpvcnJvLWFudGQvaTE4bic7XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ256LXBhZ2luYXRpb24nLFxuICBleHBvcnRBczogJ256UGFnaW5hdGlvbicsXG4gIHByZXNlcnZlV2hpdGVzcGFjZXM6IGZhbHNlLFxuICBlbmNhcHN1bGF0aW9uOiBWaWV3RW5jYXBzdWxhdGlvbi5Ob25lLFxuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbiAgdGVtcGxhdGVVcmw6ICcuL256LXBhZ2luYXRpb24uY29tcG9uZW50Lmh0bWwnXG59KVxuZXhwb3J0IGNsYXNzIE56UGFnaW5hdGlvbkNvbXBvbmVudCBpbXBsZW1lbnRzIE9uSW5pdCwgT25EZXN0cm95LCBPbkNoYW5nZXMge1xuICAvLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6bm8tYW55XG4gIGxvY2FsZTogYW55ID0ge307XG4gIGZpcnN0SW5kZXggPSAxO1xuICBwYWdlczogbnVtYmVyW10gPSBbXTtcbiAgcHJpdmF0ZSAkZGVzdHJveSA9IG5ldyBTdWJqZWN0PHZvaWQ+KCk7XG4gIEBPdXRwdXQoKSByZWFkb25seSBuelBhZ2VTaXplQ2hhbmdlOiBFdmVudEVtaXR0ZXI8bnVtYmVyPiA9IG5ldyBFdmVudEVtaXR0ZXIoKTtcbiAgQE91dHB1dCgpIHJlYWRvbmx5IG56UGFnZUluZGV4Q2hhbmdlOiBFdmVudEVtaXR0ZXI8bnVtYmVyPiA9IG5ldyBFdmVudEVtaXR0ZXIoKTtcbiAgQElucHV0KCkgbnpTaG93VG90YWw6IFRlbXBsYXRlUmVmPHsgJGltcGxpY2l0OiBudW1iZXI7IHJhbmdlOiBbbnVtYmVyLCBudW1iZXJdIH0+O1xuICBASW5wdXQoKSBuekluVGFibGUgPSBmYWxzZTtcbiAgQElucHV0KCkgbnpTaXplOiAnZGVmYXVsdCcgfCAnc21hbGwnID0gJ2RlZmF1bHQnO1xuICBASW5wdXQoKSBuelBhZ2VTaXplT3B0aW9ucyA9IFsxMCwgMjAsIDMwLCA0MF07XG4gIEBJbnB1dCgpIEBWaWV3Q2hpbGQoJ3JlbmRlckl0ZW1UZW1wbGF0ZScpIG56SXRlbVJlbmRlcjogVGVtcGxhdGVSZWY8e1xuICAgICRpbXBsaWNpdDogJ3BhZ2UnIHwgJ3ByZXYnIHwgJ25leHQnO1xuICAgIHBhZ2U6IG51bWJlcjtcbiAgfT47XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuelNob3dTaXplQ2hhbmdlciA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpIaWRlT25TaW5nbGVQYWdlID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuelNob3dRdWlja0p1bXBlciA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpTaW1wbGUgPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0TnVtYmVyKCkgbnpUb3RhbCA9IDA7XG4gIEBJbnB1dCgpIEBJbnB1dE51bWJlcigpIG56UGFnZUluZGV4ID0gMTtcbiAgQElucHV0KCkgQElucHV0TnVtYmVyKCkgbnpQYWdlU2l6ZSA9IDEwO1xuXG4gIHZhbGlkYXRlUGFnZUluZGV4KHZhbHVlOiBudW1iZXIpOiBudW1iZXIge1xuICAgIGlmICh2YWx1ZSA+IHRoaXMubGFzdEluZGV4KSB7XG4gICAgICByZXR1cm4gdGhpcy5sYXN0SW5kZXg7XG4gICAgfSBlbHNlIGlmICh2YWx1ZSA8IHRoaXMuZmlyc3RJbmRleCkge1xuICAgICAgcmV0dXJuIHRoaXMuZmlyc3RJbmRleDtcbiAgICB9IGVsc2Uge1xuICAgICAgcmV0dXJuIHZhbHVlO1xuICAgIH1cbiAgfVxuXG4gIHVwZGF0ZVBhZ2VJbmRleFZhbHVlKHBhZ2U6IG51bWJlcik6IHZvaWQge1xuICAgIHRoaXMubnpQYWdlSW5kZXggPSBwYWdlO1xuICAgIHRoaXMubnpQYWdlSW5kZXhDaGFuZ2UuZW1pdCh0aGlzLm56UGFnZUluZGV4KTtcbiAgICB0aGlzLmJ1aWxkSW5kZXhlcygpO1xuICB9XG5cbiAgaXNQYWdlSW5kZXhWYWxpZCh2YWx1ZTogbnVtYmVyKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHRoaXMudmFsaWRhdGVQYWdlSW5kZXgodmFsdWUpID09PSB2YWx1ZTtcbiAgfVxuXG4gIGp1bXBQYWdlKGluZGV4OiBudW1iZXIpOiB2b2lkIHtcbiAgICBpZiAoaW5kZXggIT09IHRoaXMubnpQYWdlSW5kZXgpIHtcbiAgICAgIGNvbnN0IHBhZ2VJbmRleCA9IHRoaXMudmFsaWRhdGVQYWdlSW5kZXgoaW5kZXgpO1xuICAgICAgaWYgKHBhZ2VJbmRleCAhPT0gdGhpcy5uelBhZ2VJbmRleCkge1xuICAgICAgICB0aGlzLnVwZGF0ZVBhZ2VJbmRleFZhbHVlKHBhZ2VJbmRleCk7XG4gICAgICB9XG4gICAgfVxuICB9XG5cbiAganVtcERpZmYoZGlmZjogbnVtYmVyKTogdm9pZCB7XG4gICAgdGhpcy5qdW1wUGFnZSh0aGlzLm56UGFnZUluZGV4ICsgZGlmZik7XG4gIH1cblxuICBvblBhZ2VTaXplQ2hhbmdlKCRldmVudDogbnVtYmVyKTogdm9pZCB7XG4gICAgdGhpcy5uelBhZ2VTaXplID0gJGV2ZW50O1xuICAgIHRoaXMubnpQYWdlU2l6ZUNoYW5nZS5lbWl0KCRldmVudCk7XG4gICAgdGhpcy5idWlsZEluZGV4ZXMoKTtcbiAgICBpZiAodGhpcy5uelBhZ2VJbmRleCA+IHRoaXMubGFzdEluZGV4KSB7XG4gICAgICB0aGlzLnVwZGF0ZVBhZ2VJbmRleFZhbHVlKHRoaXMubGFzdEluZGV4KTtcbiAgICB9XG4gIH1cblxuICBoYW5kbGVLZXlEb3duKF86IEtleWJvYXJkRXZlbnQsIGlucHV0OiBIVE1MSW5wdXRFbGVtZW50LCBjbGVhcklucHV0VmFsdWU6IGJvb2xlYW4pOiB2b2lkIHtcbiAgICBjb25zdCB0YXJnZXQgPSBpbnB1dDtcbiAgICBjb25zdCBwYWdlID0gdG9OdW1iZXIodGFyZ2V0LnZhbHVlLCB0aGlzLm56UGFnZUluZGV4KTtcbiAgICBpZiAoaXNJbnRlZ2VyKHBhZ2UpICYmIHRoaXMuaXNQYWdlSW5kZXhWYWxpZChwYWdlKSAmJiBwYWdlICE9PSB0aGlzLm56UGFnZUluZGV4KSB7XG4gICAgICB0aGlzLnVwZGF0ZVBhZ2VJbmRleFZhbHVlKHBhZ2UpO1xuICAgIH1cbiAgICBpZiAoY2xlYXJJbnB1dFZhbHVlKSB7XG4gICAgICB0YXJnZXQudmFsdWUgPSAnJztcbiAgICB9IGVsc2Uge1xuICAgICAgdGFyZ2V0LnZhbHVlID0gYCR7dGhpcy5uelBhZ2VJbmRleH1gO1xuICAgIH1cbiAgfVxuXG4gIC8qKiBnZW5lcmF0ZSBpbmRleGVzIGxpc3QgKi9cbiAgYnVpbGRJbmRleGVzKCk6IHZvaWQge1xuICAgIGNvbnN0IHBhZ2VzOiBudW1iZXJbXSA9IFtdO1xuICAgIGlmICh0aGlzLmxhc3RJbmRleCA8PSA5KSB7XG4gICAgICBmb3IgKGxldCBpID0gMjsgaSA8PSB0aGlzLmxhc3RJbmRleCAtIDE7IGkrKykge1xuICAgICAgICBwYWdlcy5wdXNoKGkpO1xuICAgICAgfVxuICAgIH0gZWxzZSB7XG4gICAgICBjb25zdCBjdXJyZW50ID0gK3RoaXMubnpQYWdlSW5kZXg7XG4gICAgICBsZXQgbGVmdCA9IE1hdGgubWF4KDIsIGN1cnJlbnQgLSAyKTtcbiAgICAgIGxldCByaWdodCA9IE1hdGgubWluKGN1cnJlbnQgKyAyLCB0aGlzLmxhc3RJbmRleCAtIDEpO1xuICAgICAgaWYgKGN1cnJlbnQgLSAxIDw9IDIpIHtcbiAgICAgICAgcmlnaHQgPSA1O1xuICAgICAgfVxuICAgICAgaWYgKHRoaXMubGFzdEluZGV4IC0gY3VycmVudCA8PSAyKSB7XG4gICAgICAgIGxlZnQgPSB0aGlzLmxhc3RJbmRleCAtIDQ7XG4gICAgICB9XG4gICAgICBmb3IgKGxldCBpID0gbGVmdDsgaSA8PSByaWdodDsgaSsrKSB7XG4gICAgICAgIHBhZ2VzLnB1c2goaSk7XG4gICAgICB9XG4gICAgfVxuICAgIHRoaXMucGFnZXMgPSBwYWdlcztcbiAgICB0aGlzLmNkci5tYXJrRm9yQ2hlY2soKTtcbiAgfVxuXG4gIGdldCBsYXN0SW5kZXgoKTogbnVtYmVyIHtcbiAgICByZXR1cm4gTWF0aC5jZWlsKHRoaXMubnpUb3RhbCAvIHRoaXMubnpQYWdlU2l6ZSk7XG4gIH1cblxuICBnZXQgaXNMYXN0SW5kZXgoKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHRoaXMubnpQYWdlSW5kZXggPT09IHRoaXMubGFzdEluZGV4O1xuICB9XG5cbiAgZ2V0IGlzRmlyc3RJbmRleCgpOiBib29sZWFuIHtcbiAgICByZXR1cm4gdGhpcy5uelBhZ2VJbmRleCA9PT0gdGhpcy5maXJzdEluZGV4O1xuICB9XG5cbiAgZ2V0IHJhbmdlcygpOiBudW1iZXJbXSB7XG4gICAgcmV0dXJuIFsodGhpcy5uelBhZ2VJbmRleCAtIDEpICogdGhpcy5uelBhZ2VTaXplICsgMSwgTWF0aC5taW4odGhpcy5uelBhZ2VJbmRleCAqIHRoaXMubnpQYWdlU2l6ZSwgdGhpcy5uelRvdGFsKV07XG4gIH1cblxuICBnZXQgc2hvd0FkZE9wdGlvbigpOiBib29sZWFuIHtcbiAgICByZXR1cm4gdGhpcy5uelBhZ2VTaXplT3B0aW9ucy5pbmRleE9mKHRoaXMubnpQYWdlU2l6ZSkgPT09IC0xO1xuICB9XG5cbiAgY29uc3RydWN0b3IocHJpdmF0ZSBpMThuOiBOekkxOG5TZXJ2aWNlLCBwcml2YXRlIGNkcjogQ2hhbmdlRGV0ZWN0b3JSZWYpIHt9XG5cbiAgbmdPbkluaXQoKTogdm9pZCB7XG4gICAgdGhpcy5pMThuLmxvY2FsZUNoYW5nZS5waXBlKHRha2VVbnRpbCh0aGlzLiRkZXN0cm95KSkuc3Vic2NyaWJlKCgpID0+IHtcbiAgICAgIHRoaXMubG9jYWxlID0gdGhpcy5pMThuLmdldExvY2FsZURhdGEoJ1BhZ2luYXRpb24nKTtcbiAgICAgIHRoaXMuY2RyLm1hcmtGb3JDaGVjaygpO1xuICAgIH0pO1xuICB9XG5cbiAgbmdPbkRlc3Ryb3koKTogdm9pZCB7XG4gICAgdGhpcy4kZGVzdHJveS5uZXh0KCk7XG4gICAgdGhpcy4kZGVzdHJveS5jb21wbGV0ZSgpO1xuICB9XG5cbiAgbmdPbkNoYW5nZXMoY2hhbmdlczogU2ltcGxlQ2hhbmdlcyk6IHZvaWQge1xuICAgIGlmIChjaGFuZ2VzLm56VG90YWwgfHwgY2hhbmdlcy5uelBhZ2VTaXplIHx8IGNoYW5nZXMubnpQYWdlSW5kZXgpIHtcbiAgICAgIHRoaXMuYnVpbGRJbmRleGVzKCk7XG4gICAgfVxuICB9XG59XG4iXX0=