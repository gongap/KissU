(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs'), require('rxjs/operators'), require('ng-zorro-antd/core'), require('@angular/common'), require('@angular/core'), require('@angular/forms'), require('ng-zorro-antd/i18n'), require('ng-zorro-antd/icon'), require('ng-zorro-antd/select')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/pagination', ['exports', 'rxjs', 'rxjs/operators', 'ng-zorro-antd/core', '@angular/common', '@angular/core', '@angular/forms', 'ng-zorro-antd/i18n', 'ng-zorro-antd/icon', 'ng-zorro-antd/select'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].pagination = {}),global.rxjs,global.rxjs.operators,global['ng-zorro-antd'].core,global.ng.common,global.ng.core,global.ng.forms,global['ng-zorro-antd'].i18n,global['ng-zorro-antd'].icon,global['ng-zorro-antd'].select));
}(this, (function (exports,rxjs,operators,core,common,core$1,forms,i18n,icon,select) { 'use strict';

    /*! *****************************************************************************
    Copyright (c) Microsoft Corporation. All rights reserved.
    Licensed under the Apache License, Version 2.0 (the "License"); you may not use
    this file except in compliance with the License. You may obtain a copy of the
    License at http://www.apache.org/licenses/LICENSE-2.0

    THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
    KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
    WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
    MERCHANTABLITY OR NON-INFRINGEMENT.

    See the Apache Version 2.0 License for specific language governing permissions
    and limitations under the License.
    ***************************************************************************** */
    function __decorate(decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function")
            r = Reflect.decorate(decorators, target, key, desc);
        else
            for (var i = decorators.length - 1; i >= 0; i--)
                if (d = decorators[i])
                    r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    }
    function __metadata(metadataKey, metadataValue) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function")
            return Reflect.metadata(metadataKey, metadataValue);
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzPaginationComponent = /** @class */ (function () {
        function NzPaginationComponent(i18n$$1, cdr) {
            this.i18n = i18n$$1;
            this.cdr = cdr;
            // tslint:disable-next-line:no-any
            this.locale = {};
            this.firstIndex = 1;
            this.pages = [];
            this.$destroy = new rxjs.Subject();
            this.nzPageSizeChange = new core$1.EventEmitter();
            this.nzPageIndexChange = new core$1.EventEmitter();
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
                var page = core.toNumber(target.value, this.nzPageIndex);
                if (core.isInteger(page) && this.isPageIndexValid(page) && page !== this.nzPageIndex) {
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
             */ function () {
                return Math.ceil(this.nzTotal / this.nzPageSize);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzPaginationComponent.prototype, "isLastIndex", {
            get: /**
             * @return {?}
             */ function () {
                return this.nzPageIndex === this.lastIndex;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzPaginationComponent.prototype, "isFirstIndex", {
            get: /**
             * @return {?}
             */ function () {
                return this.nzPageIndex === this.firstIndex;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzPaginationComponent.prototype, "ranges", {
            get: /**
             * @return {?}
             */ function () {
                return [(this.nzPageIndex - 1) * this.nzPageSize + 1, Math.min(this.nzPageIndex * this.nzPageSize, this.nzTotal)];
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzPaginationComponent.prototype, "showAddOption", {
            get: /**
             * @return {?}
             */ function () {
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
                this.i18n.localeChange.pipe(operators.takeUntil(this.$destroy)).subscribe(( /**
                 * @return {?}
                 */function () {
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
            { type: core$1.Component, args: [{
                        selector: 'nz-pagination',
                        exportAs: 'nzPagination',
                        preserveWhitespaces: false,
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        template: "<ng-template #renderItemTemplate let-type let-page=\"page\">\n  <a class=\"ant-pagination-item-link\" *ngIf=\"type==='pre'\"><i nz-icon type=\"left\"></i></a>\n  <a class=\"ant-pagination-item-link\" *ngIf=\"type==='next'\"><i nz-icon type=\"right\"></i></a>\n  <a *ngIf=\"type=='page'\">{{ page }}</a>\n</ng-template>\n<ng-container *ngIf=\"nzHideOnSinglePage && (nzTotal > nzPageSize) || !nzHideOnSinglePage\">\n  <ul class=\"ant-pagination\"\n    [class.ant-table-pagination]=\"nzInTable\"\n    [class.ant-pagination-simple]=\"nzSimple\"\n    [class.mini]=\"(nzSize === 'small') && !nzSimple\">\n    <ng-container *ngIf=\"nzSimple; else normalTemplate\">\n      <li class=\"ant-pagination-prev\"\n        [attr.title]=\"locale.prev_page\"\n        [class.ant-pagination-disabled]=\"isFirstIndex\"\n        (click)=\"jumpDiff(-1)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'pre'}\"></ng-template>\n      </li>\n      <li [attr.title]=\"nzPageIndex+'/'+lastIndex\" class=\"ant-pagination-simple-pager\">\n        <input #simplePagerInput [value]=\"nzPageIndex\" (keydown.enter)=\"handleKeyDown($event,simplePagerInput,false)\" size=\"3\">\n        <span class=\"ant-pagination-slash\">\uFF0F</span>\n        {{ lastIndex }}\n      </li>\n      <li class=\"ant-pagination-next\"\n        [attr.title]=\"locale.next_page\"\n        [class.ant-pagination-disabled]=\"isLastIndex\"\n        (click)=\"jumpDiff(1)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'next'}\"></ng-template>\n      </li>\n    </ng-container>\n    <ng-template #normalTemplate>\n      <li class=\"ant-pagination-total-text\" *ngIf=\"nzShowTotal\">\n        <ng-template [ngTemplateOutlet]=\"nzShowTotal\" [ngTemplateOutletContext]=\"{ $implicit: nzTotal,range:ranges }\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-prev\"\n        [attr.title]=\"locale.prev_page\"\n        [class.ant-pagination-disabled]=\"isFirstIndex\"\n        (click)=\"jumpDiff(-1)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'pre'}\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-item\"\n        [attr.title]=\"firstIndex\"\n        [class.ant-pagination-item-active]=\"isFirstIndex\"\n        (click)=\"jumpPage(firstIndex)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'page',page: firstIndex }\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-jump-prev\"\n        *ngIf=\"(lastIndex > 9) && (nzPageIndex - 3 > firstIndex)\"\n        [attr.title]=\"locale.prev_5\"\n        (click)=\"jumpDiff(-5)\">\n        <a class=\"ant-pagination-item-link\">\n          <div class=\"ant-pagination-item-container\">\n            <i nz-icon type=\"double-left\" class=\"ant-pagination-item-link-icon\"></i>\n            <span class=\"ant-pagination-item-ellipsis\">\u2022\u2022\u2022</span>\n          </div>\n        </a>\n      </li>\n      <li class=\"ant-pagination-item\"\n        *ngFor=\"let page of pages\"\n        [attr.title]=\"page\"\n        [class.ant-pagination-item-active]=\"nzPageIndex === page\"\n        (click)=\"jumpPage(page)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'page',page: page }\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-jump-next ant-pagination-item-link-icon\"\n        [attr.title]=\"locale.next_5\"\n        (click)=\"jumpDiff(5)\"\n        *ngIf=\"(lastIndex > 9) && (nzPageIndex + 3 < lastIndex)\">\n        <a class=\"ant-pagination-item-link\">\n          <div class=\"ant-pagination-item-container\">\n            <i nz-icon type=\"double-right\" class=\"ant-pagination-item-link-icon\"></i>\n            <span class=\"ant-pagination-item-ellipsis\">\u2022\u2022\u2022</span>\n          </div>\n        </a>\n      </li>\n      <li class=\"ant-pagination-item\"\n        [attr.title]=\"lastIndex\"\n        (click)=\"jumpPage(lastIndex)\"\n        *ngIf=\"(lastIndex > 0) && (lastIndex !== firstIndex)\"\n        [class.ant-pagination-item-active]=\"isLastIndex\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'page',page: lastIndex }\"></ng-template>\n      </li>\n      <li class=\"ant-pagination-next\"\n        [title]=\"locale.next_page\"\n        [class.ant-pagination-disabled]=\"isLastIndex\"\n        (click)=\"jumpDiff(1)\">\n        <ng-template [ngTemplateOutlet]=\"nzItemRender\" [ngTemplateOutletContext]=\"{ $implicit: 'next'}\"></ng-template>\n      </li>\n      <div class=\"ant-pagination-options\" *ngIf=\"nzShowQuickJumper || nzShowSizeChanger\">\n        <nz-select class=\"ant-pagination-options-size-changer\"\n          *ngIf=\"nzShowSizeChanger\"\n          [nzSize]=\"nzSize\"\n          [ngModel]=\"nzPageSize\"\n          (ngModelChange)=\"onPageSizeChange($event)\">\n          <nz-option *ngFor=\"let option of nzPageSizeOptions\"\n            [nzLabel]=\"option + locale.items_per_page\"\n            [nzValue]=\"option\">\n          </nz-option>\n          <nz-option *ngIf=\"showAddOption\"\n            [nzLabel]=\"nzPageSize + locale.items_per_page\"\n            [nzValue]=\"nzPageSize\">\n          </nz-option>\n        </nz-select>\n        <div class=\"ant-pagination-options-quick-jumper\" *ngIf=\"nzShowQuickJumper\">\n          {{ locale.jump_to }}\n          <input #quickJumperInput (keydown.enter)=\"handleKeyDown($event,quickJumperInput,true)\">\n          {{ locale.page }}\n        </div>\n      </div>\n    </ng-template>\n  </ul>\n</ng-container>"
                    }] }
        ];
        /** @nocollapse */
        NzPaginationComponent.ctorParameters = function () {
            return [
                { type: i18n.NzI18nService },
                { type: core$1.ChangeDetectorRef }
            ];
        };
        NzPaginationComponent.propDecorators = {
            nzPageSizeChange: [{ type: core$1.Output }],
            nzPageIndexChange: [{ type: core$1.Output }],
            nzShowTotal: [{ type: core$1.Input }],
            nzInTable: [{ type: core$1.Input }],
            nzSize: [{ type: core$1.Input }],
            nzPageSizeOptions: [{ type: core$1.Input }],
            nzItemRender: [{ type: core$1.Input }, { type: core$1.ViewChild, args: ['renderItemTemplate',] }],
            nzShowSizeChanger: [{ type: core$1.Input }],
            nzHideOnSinglePage: [{ type: core$1.Input }],
            nzShowQuickJumper: [{ type: core$1.Input }],
            nzSimple: [{ type: core$1.Input }],
            nzTotal: [{ type: core$1.Input }],
            nzPageIndex: [{ type: core$1.Input }],
            nzPageSize: [{ type: core$1.Input }]
        };
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzPaginationComponent.prototype, "nzShowSizeChanger", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzPaginationComponent.prototype, "nzHideOnSinglePage", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzPaginationComponent.prototype, "nzShowQuickJumper", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzPaginationComponent.prototype, "nzSimple", void 0);
        __decorate([
            core.InputNumber(),
            __metadata("design:type", Object)
        ], NzPaginationComponent.prototype, "nzTotal", void 0);
        __decorate([
            core.InputNumber(),
            __metadata("design:type", Object)
        ], NzPaginationComponent.prototype, "nzPageIndex", void 0);
        __decorate([
            core.InputNumber(),
            __metadata("design:type", Object)
        ], NzPaginationComponent.prototype, "nzPageSize", void 0);
        return NzPaginationComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzPaginationModule = /** @class */ (function () {
        function NzPaginationModule() {
        }
        NzPaginationModule.decorators = [
            { type: core$1.NgModule, args: [{
                        declarations: [NzPaginationComponent],
                        exports: [NzPaginationComponent],
                        imports: [common.CommonModule, forms.FormsModule, select.NzSelectModule, i18n.NzI18nModule, icon.NzIconModule]
                    },] }
        ];
        return NzPaginationModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzPaginationComponent = NzPaginationComponent;
    exports.NzPaginationModule = NzPaginationModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-pagination.umd.js.map