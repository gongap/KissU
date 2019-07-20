(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('rxjs'), require('rxjs/operators'), require('ng-zorro-antd/core'), require('@angular/common'), require('@angular/core'), require('@angular/forms'), require('ng-zorro-antd/button'), require('ng-zorro-antd/checkbox'), require('ng-zorro-antd/empty'), require('ng-zorro-antd/i18n'), require('ng-zorro-antd/icon'), require('ng-zorro-antd/input')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/transfer', ['exports', 'rxjs', 'rxjs/operators', 'ng-zorro-antd/core', '@angular/common', '@angular/core', '@angular/forms', 'ng-zorro-antd/button', 'ng-zorro-antd/checkbox', 'ng-zorro-antd/empty', 'ng-zorro-antd/i18n', 'ng-zorro-antd/icon', 'ng-zorro-antd/input'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].transfer = {}),global.rxjs,global.rxjs.operators,global['ng-zorro-antd'].core,global.ng.common,global.ng.core,global.ng.forms,global['ng-zorro-antd'].button,global['ng-zorro-antd'].checkbox,global['ng-zorro-antd'].empty,global['ng-zorro-antd'].i18n,global['ng-zorro-antd'].icon,global['ng-zorro-antd'].input));
}(this, (function (exports,rxjs,operators,core,common,core$1,forms,button,checkbox,empty,i18n,icon,input) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
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
            this.handleSelectAll = new core$1.EventEmitter();
            this.handleSelect = new core$1.EventEmitter();
            this.filterChange = new core$1.EventEmitter();
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
                this.dataSource.forEach(( /**
                 * @param {?} item
                 * @return {?}
                 */function (item) {
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
                var validCount = this.dataSource.filter(( /**
                 * @param {?} w
                 * @return {?}
                 */function (w) { return !w.disabled; })).length;
                this.stat.checkCount = this.dataSource.filter(( /**
                 * @param {?} w
                 * @return {?}
                 */function (w) { return w.checked && !w.disabled; })).length;
                this.stat.shownCount = this.dataSource.filter(( /**
                 * @param {?} w
                 * @return {?}
                 */function (w) { return !w._hiden; })).length;
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
                this.dataSource.forEach(( /**
                 * @param {?} item
                 * @return {?}
                 */function (item) {
                    item._hiden = value.length > 0 && !_this.matchFilter(value, item);
                }));
                this.stat.shownCount = this.dataSource.filter(( /**
                 * @param {?} w
                 * @return {?}
                 */function (w) { return !w._hiden; })).length;
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
            { type: core$1.Component, args: [{
                        selector: 'nz-transfer-list',
                        exportAs: 'nzTransferList',
                        preserveWhitespaces: false,
                        providers: [core.NzUpdateHostClassService],
                        template: "<div class=\"ant-transfer-list-header\">\n  <label nz-checkbox [nzChecked]=\"stat.checkAll\" (nzCheckedChange)=\"onHandleSelectAll($event)\"\n    [nzIndeterminate]=\"stat.checkHalf\" [nzDisabled]=\"stat.shownCount == 0 || disabled\">\n  </label>\n  <span class=\"ant-transfer-list-header-selected\">\n    <span>{{ (stat.checkCount > 0 ? stat.checkCount + '/' : '') + stat.shownCount }} {{ dataSource.length > 1 ? itemsUnit : itemUnit }}</span>\n    <span *ngIf=\"titleText\" class=\"ant-transfer-list-header-title\">{{ titleText }}</span>\n  </span>\n</div>\n<div class=\"{{showSearch ? 'ant-transfer-list-body ant-transfer-list-body-with-search' : 'ant-transfer-list-body'}}\"\n  [ngClass]=\"{'ant-transfer__nodata': stat.shownCount === 0}\">\n  <div *ngIf=\"showSearch\" class=\"ant-transfer-list-body-search-wrapper\">\n    <div nz-transfer-search\n      (valueChanged)=\"handleFilter($event)\"\n      (valueClear)=\"handleClear()\"\n      [placeholder]=\"searchPlaceholder\"\n      [disabled]=\"disabled\"\n      [value]=\"filter\"></div>\n  </div>\n  <ul *ngIf=\"stat.shownCount > 0\" class=\"ant-transfer-list-content\">\n    <div class=\"LazyLoad\" *ngFor=\"let item of dataSource\">\n      <li *ngIf=\"!item._hiden\" (click)=\"_handleSelect(item)\"\n        class=\"ant-transfer-list-content-item\" [ngClass]=\"{'ant-transfer-list-content-item-disabled': disabled || item.disabled}\">\n        <label nz-checkbox [nzChecked]=\"item.checked\" (nzCheckedChange)=\"_handleSelect(item)\"\n          (click)=\"$event.stopPropagation()\" [nzDisabled]=\"disabled || item.disabled\">\n          <ng-container *ngIf=\"!render; else renderContainer\">{{ item.title }}</ng-container>\n          <ng-template #renderContainer [ngTemplateOutlet]=\"render\" [ngTemplateOutletContext]=\"{ $implicit: item }\"></ng-template>\n        </label>\n      </li>\n    </div>\n  </ul>\n  <div *ngIf=\"stat.shownCount === 0\" class=\"ant-transfer-list-body-not-found\">\n    <nz-embed-empty [nzComponentName]=\"'transfer'\" [specificContent]=\"notFoundContent\"></nz-embed-empty>\n  </div>\n</div>\n<div *ngIf=\"footer\" class=\"ant-transfer-list-footer\">\n  <ng-template [ngTemplateOutlet]=\"footer\" [ngTemplateOutletContext]=\"{ $implicit: direction }\"></ng-template>\n</div>",
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        NzTransferListComponent.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core.NzUpdateHostClassService },
                { type: core$1.ChangeDetectorRef }
            ];
        };
        NzTransferListComponent.propDecorators = {
            direction: [{ type: core$1.Input }],
            titleText: [{ type: core$1.Input }],
            dataSource: [{ type: core$1.Input }],
            itemUnit: [{ type: core$1.Input }],
            itemsUnit: [{ type: core$1.Input }],
            filter: [{ type: core$1.Input }],
            disabled: [{ type: core$1.Input }],
            showSearch: [{ type: core$1.Input }],
            searchPlaceholder: [{ type: core$1.Input }],
            notFoundContent: [{ type: core$1.Input }],
            filterOption: [{ type: core$1.Input }],
            render: [{ type: core$1.Input }],
            footer: [{ type: core$1.Input }],
            handleSelectAll: [{ type: core$1.Output }],
            handleSelect: [{ type: core$1.Output }],
            filterChange: [{ type: core$1.Output }]
        };
        return NzTransferListComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzTransferSearchComponent = /** @class */ (function () {
        // endregion
        function NzTransferSearchComponent(cdr) {
            this.cdr = cdr;
            this.valueChanged = new core$1.EventEmitter();
            this.valueClear = new core$1.EventEmitter();
        }
        /**
         * @return {?}
         */
        NzTransferSearchComponent.prototype._handle = /**
         * @return {?}
         */
            function () {
                this.valueChanged.emit(this.value);
            };
        /**
         * @return {?}
         */
        NzTransferSearchComponent.prototype._clear = /**
         * @return {?}
         */
            function () {
                if (this.disabled) {
                    return;
                }
                this.value = '';
                this.valueClear.emit();
            };
        /**
         * @return {?}
         */
        NzTransferSearchComponent.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                this.cdr.detectChanges();
            };
        NzTransferSearchComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: '[nz-transfer-search]',
                        exportAs: 'nzTransferSearch',
                        preserveWhitespaces: false,
                        template: "<input [(ngModel)]=\"value\" (ngModelChange)=\"_handle()\" [disabled]=\"disabled\" [placeholder]=\"placeholder\"\n  class=\"ant-input ant-transfer-list-search\" [ngClass]=\"{'ant-input-disabled': disabled}\">\n<a *ngIf=\"value && value.length > 0; else def\" class=\"ant-transfer-list-search-action\" (click)=\"_clear()\">\n  <i nz-icon type=\"close-circle\"></i>\n</a>\n<ng-template #def>\n  <span class=\"ant-transfer-list-search-action\"><i nz-icon type=\"search\"></i></span>\n</ng-template>",
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        NzTransferSearchComponent.ctorParameters = function () {
            return [
                { type: core$1.ChangeDetectorRef }
            ];
        };
        NzTransferSearchComponent.propDecorators = {
            placeholder: [{ type: core$1.Input }],
            value: [{ type: core$1.Input }],
            disabled: [{ type: core$1.Input }],
            valueChanged: [{ type: core$1.Output }],
            valueClear: [{ type: core$1.Output }]
        };
        return NzTransferSearchComponent;
    }());

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
    function __values(o) {
        var m = typeof Symbol === "function" && o[Symbol.iterator], i = 0;
        if (m)
            return m.call(o);
        return {
            next: function () {
                if (o && i >= o.length)
                    o = void 0;
                return { value: o && o[i++], done: !o };
            }
        };
    }
    function __read(o, n) {
        var m = typeof Symbol === "function" && o[Symbol.iterator];
        if (!m)
            return o;
        var i = m.call(o), r, ar = [], e;
        try {
            while ((n === void 0 || n-- > 0) && !(r = i.next()).done)
                ar.push(r.value);
        }
        catch (error) {
            e = { error: error };
        }
        finally {
            try {
                if (r && !r.done && (m = i["return"]))
                    m.call(i);
            }
            finally {
                if (e)
                    throw e.error;
            }
        }
        return ar;
    }
    function __spread() {
        for (var ar = [], i = 0; i < arguments.length; i++)
            ar = ar.concat(__read(arguments[i]));
        return ar;
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzTransferComponent = /** @class */ (function () {
        // #endregion
        function NzTransferComponent(cdr, i18n$$1, renderer, elementRef) {
            var _this = this;
            this.cdr = cdr;
            this.i18n = i18n$$1;
            this.unsubscribe$ = new rxjs.Subject();
            // tslint:disable-next-line:no-any
            this.locale = {};
            this.leftFilter = '';
            this.rightFilter = '';
            // #region fields
            this.nzDisabled = false;
            this.nzDataSource = [];
            this.nzTitles = ['', ''];
            this.nzOperations = [];
            this.nzCanMove = ( /**
             * @param {?} arg
             * @return {?}
             */function (arg) { return rxjs.of(arg.list); });
            this.nzShowSearch = false;
            // events
            this.nzChange = new core$1.EventEmitter();
            this.nzSearchChange = new core$1.EventEmitter();
            this.nzSelectChange = new core$1.EventEmitter();
            // #endregion
            // #region process data
            // left
            this.leftDataSource = [];
            // right
            this.rightDataSource = [];
            this.handleLeftSelectAll = ( /**
             * @param {?} checked
             * @return {?}
             */function (checked) { return _this.handleSelect('left', checked); });
            this.handleRightSelectAll = ( /**
             * @param {?} checked
             * @return {?}
             */function (checked) { return _this.handleSelect('right', checked); });
            this.handleLeftSelect = ( /**
             * @param {?} item
             * @return {?}
             */function (item) { return _this.handleSelect('left', !!item.checked, item); });
            this.handleRightSelect = ( /**
             * @param {?} item
             * @return {?}
             */function (item) { return _this.handleSelect('right', !!item.checked, item); });
            // #endregion
            // #region operation
            this.leftActive = false;
            this.rightActive = false;
            this.moveToLeft = ( /**
             * @return {?}
             */function () { return _this.moveTo('left'); });
            this.moveToRight = ( /**
             * @return {?}
             */function () { return _this.moveTo('right'); });
            renderer.addClass(elementRef.nativeElement, 'ant-transfer');
        }
        /**
         * @private
         * @return {?}
         */
        NzTransferComponent.prototype.splitDataSource = /**
         * @private
         * @return {?}
         */
            function () {
                var _this = this;
                this.leftDataSource = [];
                this.rightDataSource = [];
                this.nzDataSource.forEach(( /**
                 * @param {?} record
                 * @return {?}
                 */function (record) {
                    if (record.direction === 'right') {
                        _this.rightDataSource.push(record);
                    }
                    else {
                        _this.leftDataSource.push(record);
                    }
                }));
            };
        /**
         * @private
         * @param {?} direction
         * @return {?}
         */
        NzTransferComponent.prototype.getCheckedData = /**
         * @private
         * @param {?} direction
         * @return {?}
         */
            function (direction) {
                return this[direction === 'left' ? 'leftDataSource' : 'rightDataSource'].filter(( /**
                 * @param {?} w
                 * @return {?}
                 */function (w) { return w.checked; }));
            };
        /**
         * @param {?} direction
         * @param {?} checked
         * @param {?=} item
         * @return {?}
         */
        NzTransferComponent.prototype.handleSelect = /**
         * @param {?} direction
         * @param {?} checked
         * @param {?=} item
         * @return {?}
         */
            function (direction, checked, item) {
                /** @type {?} */
                var list = this.getCheckedData(direction);
                this.updateOperationStatus(direction, list.length);
                this.nzSelectChange.emit({ direction: direction, checked: checked, list: list, item: item });
            };
        /**
         * @param {?} ret
         * @return {?}
         */
        NzTransferComponent.prototype.handleFilterChange = /**
         * @param {?} ret
         * @return {?}
         */
            function (ret) {
                this.nzSearchChange.emit(ret);
            };
        /**
         * @private
         * @param {?} direction
         * @param {?=} count
         * @return {?}
         */
        NzTransferComponent.prototype.updateOperationStatus = /**
         * @private
         * @param {?} direction
         * @param {?=} count
         * @return {?}
         */
            function (direction, count) {
                this[direction === 'right' ? 'leftActive' : 'rightActive'] =
                    (typeof count === 'undefined' ? this.getCheckedData(direction).filter(( /**
                     * @param {?} w
                     * @return {?}
                     */function (w) { return !w.disabled; })).length : count) > 0;
            };
        /**
         * @param {?} direction
         * @return {?}
         */
        NzTransferComponent.prototype.moveTo = /**
         * @param {?} direction
         * @return {?}
         */
            function (direction) {
                var _this = this;
                /** @type {?} */
                var oppositeDirection = direction === 'left' ? 'right' : 'left';
                this.updateOperationStatus(oppositeDirection, 0);
                /** @type {?} */
                var datasource = direction === 'left' ? this.rightDataSource : this.leftDataSource;
                /** @type {?} */
                var moveList = datasource.filter(( /**
                 * @param {?} item
                 * @return {?}
                 */function (item) { return item.checked === true && !item.disabled; }));
                this.nzCanMove({ direction: direction, list: moveList }).subscribe(( /**
                 * @param {?} newMoveList
                 * @return {?}
                 */function (newMoveList) {
                    return _this.truthMoveTo(direction, newMoveList.filter(( /**
                     * @param {?} i
                     * @return {?}
                     */function (i) { return !!i; })));
                }), ( /**
                 * @return {?}
                 */function () {
                    return moveList.forEach(( /**
                     * @param {?} i
                     * @return {?}
                     */function (i) { return (i.checked = false); }));
                }));
            };
        /**
         * @private
         * @param {?} direction
         * @param {?} list
         * @return {?}
         */
        NzTransferComponent.prototype.truthMoveTo = /**
         * @private
         * @param {?} direction
         * @param {?} list
         * @return {?}
         */
            function (direction, list) {
                var e_1, _a;
                /** @type {?} */
                var oppositeDirection = direction === 'left' ? 'right' : 'left';
                /** @type {?} */
                var datasource = direction === 'left' ? this.rightDataSource : this.leftDataSource;
                /** @type {?} */
                var targetDatasource = direction === 'left' ? this.leftDataSource : this.rightDataSource;
                try {
                    for (var list_1 = __values(list), list_1_1 = list_1.next(); !list_1_1.done; list_1_1 = list_1.next()) {
                        var item = list_1_1.value;
                        item.checked = false;
                        item._hiden = false;
                        datasource.splice(datasource.indexOf(item), 1);
                    }
                }
                catch (e_1_1) {
                    e_1 = { error: e_1_1 };
                }
                finally {
                    try {
                        if (list_1_1 && !list_1_1.done && (_a = list_1.return))
                            _a.call(list_1);
                    }
                    finally {
                        if (e_1)
                            throw e_1.error;
                    }
                }
                targetDatasource.splice.apply(targetDatasource, __spread([0, 0], list));
                this.updateOperationStatus(oppositeDirection);
                this.nzChange.emit({
                    from: oppositeDirection,
                    to: direction,
                    list: list
                });
                this.markForCheckAllList();
            };
        /**
         * @private
         * @return {?}
         */
        NzTransferComponent.prototype.markForCheckAllList = /**
         * @private
         * @return {?}
         */
            function () {
                if (!this.lists) {
                    return;
                }
                this.lists.forEach(( /**
                 * @param {?} i
                 * @return {?}
                 */function (i) { return i.markForCheck(); }));
            };
        /**
         * @return {?}
         */
        NzTransferComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.i18n.localeChange.pipe(operators.takeUntil(this.unsubscribe$)).subscribe(( /**
                 * @return {?}
                 */function () {
                    _this.locale = _this.i18n.getLocaleData('Transfer');
                    _this.markForCheckAllList();
                }));
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzTransferComponent.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if ('nzDataSource' in changes) {
                    this.splitDataSource();
                    this.updateOperationStatus('left');
                    this.updateOperationStatus('right');
                    this.cdr.detectChanges();
                    this.markForCheckAllList();
                }
            };
        /**
         * @return {?}
         */
        NzTransferComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.unsubscribe$.next();
                this.unsubscribe$.complete();
            };
        NzTransferComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-transfer',
                        exportAs: 'nzTransfer',
                        preserveWhitespaces: false,
                        template: "<nz-transfer-list class=\"ant-transfer-list\" [ngStyle]=\"nzListStyle\" data-direction=\"left\"\n  [titleText]=\"nzTitles[0]\"\n  [dataSource]=\"leftDataSource\"\n  [filter]=\"leftFilter\"\n  [filterOption]=\"nzFilterOption\"\n  (filterChange)=\"handleFilterChange($event)\"\n  [render]=\"nzRender\"\n  [disabled]=\"nzDisabled\"\n  [showSearch]=\"nzShowSearch\"\n  [searchPlaceholder]=\"nzSearchPlaceholder || locale.searchPlaceholder\"\n  [notFoundContent]=\"nzNotFoundContent\"\n  [itemUnit]=\"nzItemUnit || locale.itemUnit\"\n  [itemsUnit]=\"nzItemsUnit || locale.itemsUnit\"\n  [footer]=\"nzFooter\"\n  (handleSelect)=\"handleLeftSelect($event)\"\n  (handleSelectAll)=\"handleLeftSelectAll($event)\">\n</nz-transfer-list>\n<div class=\"ant-transfer-operation\">\n  <button nz-button (click)=\"moveToLeft()\" [disabled]=\"nzDisabled || !leftActive\" [nzType]=\"'primary'\" [nzSize]=\"'small'\">\n    <i nz-icon type=\"left\"></i><span *ngIf=\"nzOperations[1]\">{{ nzOperations[1] }}</span>\n  </button>\n  <button nz-button (click)=\"moveToRight()\" [disabled]=\"nzDisabled || !rightActive\" [nzType]=\"'primary'\" [nzSize]=\"'small'\">\n    <i nz-icon type=\"right\"></i><span *ngIf=\"nzOperations[0]\">{{ nzOperations[0] }}</span>\n  </button>\n</div>\n<nz-transfer-list class=\"ant-transfer-list\" [ngStyle]=\"nzListStyle\" data-direction=\"right\"\n  [titleText]=\"nzTitles[1]\"\n  [dataSource]=\"rightDataSource\"\n  [filter]=\"rightFilter\"\n  [filterOption]=\"nzFilterOption\"\n  (filterChange)=\"handleFilterChange($event)\"\n  [render]=\"nzRender\"\n  [disabled]=\"nzDisabled\"\n  [showSearch]=\"nzShowSearch\"\n  [searchPlaceholder]=\"nzSearchPlaceholder || locale.searchPlaceholder\"\n  [notFoundContent]=\"nzNotFoundContent\"\n  [itemUnit]=\"nzItemUnit || locale.itemUnit\"\n  [itemsUnit]=\"nzItemsUnit || locale.itemsUnit\"\n  [footer]=\"nzFooter\"\n  (handleSelect)=\"handleRightSelect($event)\"\n  (handleSelectAll)=\"handleRightSelectAll($event)\">\n</nz-transfer-list>",
                        host: {
                            '[class.ant-transfer-disabled]': 'nzDisabled'
                        },
                        encapsulation: core$1.ViewEncapsulation.None,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        NzTransferComponent.ctorParameters = function () {
            return [
                { type: core$1.ChangeDetectorRef },
                { type: i18n.NzI18nService },
                { type: core$1.Renderer2 },
                { type: core$1.ElementRef }
            ];
        };
        NzTransferComponent.propDecorators = {
            lists: [{ type: core$1.ViewChildren, args: [NzTransferListComponent,] }],
            nzDisabled: [{ type: core$1.Input }],
            nzDataSource: [{ type: core$1.Input }],
            nzTitles: [{ type: core$1.Input }],
            nzOperations: [{ type: core$1.Input }],
            nzListStyle: [{ type: core$1.Input }],
            nzItemUnit: [{ type: core$1.Input }],
            nzItemsUnit: [{ type: core$1.Input }],
            nzCanMove: [{ type: core$1.Input }],
            nzRender: [{ type: core$1.Input }],
            nzFooter: [{ type: core$1.Input }],
            nzShowSearch: [{ type: core$1.Input }],
            nzFilterOption: [{ type: core$1.Input }],
            nzSearchPlaceholder: [{ type: core$1.Input }],
            nzNotFoundContent: [{ type: core$1.Input }],
            nzChange: [{ type: core$1.Output }],
            nzSearchChange: [{ type: core$1.Output }],
            nzSelectChange: [{ type: core$1.Output }]
        };
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzTransferComponent.prototype, "nzDisabled", void 0);
        __decorate([
            core.InputBoolean(),
            __metadata("design:type", Object)
        ], NzTransferComponent.prototype, "nzShowSearch", void 0);
        return NzTransferComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzTransferModule = /** @class */ (function () {
        function NzTransferModule() {
        }
        NzTransferModule.decorators = [
            { type: core$1.NgModule, args: [{
                        imports: [
                            common.CommonModule,
                            forms.FormsModule,
                            checkbox.NzCheckboxModule,
                            button.NzButtonModule,
                            input.NzInputModule,
                            i18n.NzI18nModule,
                            icon.NzIconModule,
                            empty.NzEmptyModule
                        ],
                        declarations: [NzTransferComponent, NzTransferListComponent, NzTransferSearchComponent],
                        exports: [NzTransferComponent]
                    },] }
        ];
        return NzTransferModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzTransferListComponent = NzTransferListComponent;
    exports.NzTransferSearchComponent = NzTransferSearchComponent;
    exports.NzTransferComponent = NzTransferComponent;
    exports.NzTransferModule = NzTransferModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-transfer.umd.js.map