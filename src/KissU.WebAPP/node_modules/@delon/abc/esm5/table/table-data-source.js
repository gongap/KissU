/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { DecimalPipe } from '@angular/common';
import { Host, Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { _HttpClient, CNCurrencyPipe, DatePipe, YNPipe } from '@delon/theme';
import { deepCopy, deepGet } from '@delon/util';
/**
 * @record
 */
export function STDataSourceOptions() { }
if (false) {
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.pi;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.ps;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.data;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.total;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.req;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.res;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.page;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.columns;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.singleSort;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.multiSort;
    /** @type {?|undefined} */
    STDataSourceOptions.prototype.rowClassName;
}
/**
 * @record
 */
export function STDataSourceResult() { }
if (false) {
    /**
     * 是否需要显示分页器
     * @type {?|undefined}
     */
    STDataSourceResult.prototype.pageShow;
    /**
     * 新 `pi`，若返回 `undefined` 表示用户受控
     * @type {?|undefined}
     */
    STDataSourceResult.prototype.pi;
    /**
     * 新 `ps`，若返回 `undefined` 表示用户受控
     * @type {?|undefined}
     */
    STDataSourceResult.prototype.ps;
    /**
     * 新 `total`，若返回 `undefined` 表示用户受控
     * @type {?|undefined}
     */
    STDataSourceResult.prototype.total;
    /**
     * 数据
     * @type {?|undefined}
     */
    STDataSourceResult.prototype.list;
    /**
     * 统计数据
     * @type {?|undefined}
     */
    STDataSourceResult.prototype.statistical;
}
var STDataSource = /** @class */ (function () {
    function STDataSource(http, currentyPipe, datePipe, ynPipe, numberPipe, dom) {
        this.http = http;
        this.currentyPipe = currentyPipe;
        this.datePipe = datePipe;
        this.ynPipe = ynPipe;
        this.numberPipe = numberPipe;
        this.dom = dom;
        this.sortTick = 0;
    }
    /**
     * @param {?} options
     * @return {?}
     */
    STDataSource.prototype.process = /**
     * @param {?} options
     * @return {?}
     */
    function (options) {
        var _this = this;
        return new Promise((/**
         * @param {?} resolvePromise
         * @param {?} rejectPromise
         * @return {?}
         */
        function (resolvePromise, rejectPromise) {
            /** @type {?} */
            var data$;
            /** @type {?} */
            var isRemote = false;
            var data = options.data, res = options.res, total = options.total, page = options.page, pi = options.pi, ps = options.ps, columns = options.columns;
            /** @type {?} */
            var retTotal;
            /** @type {?} */
            var retPs;
            /** @type {?} */
            var retList;
            /** @type {?} */
            var retPi;
            /** @type {?} */
            var rawData;
            /** @type {?} */
            var showPage = page.show;
            if (typeof data === 'string') {
                isRemote = true;
                data$ = _this.getByHttp(data, options).pipe(map((/**
                 * @param {?} result
                 * @return {?}
                 */
                function (result) {
                    rawData = result;
                    /** @type {?} */
                    var ret;
                    if (Array.isArray(result)) {
                        ret = result;
                        retTotal = ret.length;
                        retPs = retTotal;
                        showPage = false;
                    }
                    else {
                        // list
                        ret = deepGet(result, (/** @type {?} */ (res.reName.list)), []);
                        if (ret == null || !Array.isArray(ret)) {
                            ret = [];
                        }
                        // total
                        /** @type {?} */
                        var resultTotal = res.reName.total && deepGet(result, (/** @type {?} */ (res.reName.total)), null);
                        retTotal = resultTotal == null ? total || 0 : +resultTotal;
                    }
                    return deepCopy(ret);
                })), catchError((/**
                 * @param {?} err
                 * @return {?}
                 */
                function (err) {
                    rejectPromise(err);
                    return [];
                })));
            }
            else if (Array.isArray(data)) {
                data$ = of(data);
            }
            else {
                // a cold observable
                data$ = data;
            }
            if (!isRemote) {
                data$ = data$.pipe(
                // sort
                map((/**
                 * @param {?} result
                 * @return {?}
                 */
                function (result) {
                    rawData = result;
                    /** @type {?} */
                    var copyResult = deepCopy(result);
                    /** @type {?} */
                    var sorterFn = _this.getSorterFn(columns);
                    if (sorterFn) {
                        copyResult = copyResult.sort(sorterFn);
                    }
                    return copyResult;
                })), 
                // filter
                map((/**
                 * @param {?} result
                 * @return {?}
                 */
                function (result) {
                    columns
                        .filter((/**
                     * @param {?} w
                     * @return {?}
                     */
                    function (w) { return w.filter; }))
                        .forEach((/**
                     * @param {?} c
                     * @return {?}
                     */
                    function (c) {
                        /** @type {?} */
                        var values = c.filter.menus.filter((/**
                         * @param {?} w
                         * @return {?}
                         */
                        function (w) { return w.checked; }));
                        if (values.length === 0)
                            return;
                        /** @type {?} */
                        var onFilter = c.filter.fn;
                        if (typeof onFilter !== 'function') {
                            console.warn("[st] Muse provide the fn function in filter");
                            return;
                        }
                        result = result.filter((/**
                         * @param {?} record
                         * @return {?}
                         */
                        function (record) { return values.some((/**
                         * @param {?} v
                         * @return {?}
                         */
                        function (v) { return onFilter(v, record); })); }));
                    }));
                    return result;
                })), 
                // paging
                map((/**
                 * @param {?} result
                 * @return {?}
                 */
                function (result) {
                    if (page.front) {
                        /** @type {?} */
                        var maxPageIndex = Math.ceil(result.length / ps);
                        retPi = Math.max(1, pi > maxPageIndex ? maxPageIndex : pi);
                        retTotal = result.length;
                        if (page.show === true) {
                            return result.slice((retPi - 1) * ps, retPi * ps);
                        }
                    }
                    return result;
                })));
            }
            // pre-process
            if (typeof res.process === 'function') {
                data$ = data$.pipe(map((/**
                 * @param {?} result
                 * @return {?}
                 */
                function (result) { return res.process(result); })));
            }
            // data accelerator
            data$ = data$.pipe(map((/**
             * @param {?} result
             * @return {?}
             */
            function (result) {
                var _loop_1 = function (i, len) {
                    result[i]._values = columns.map((/**
                     * @param {?} c
                     * @return {?}
                     */
                    function (c) { return _this.get(result[i], c, i); }));
                    if (options.rowClassName) {
                        result[i]._rowClassName = options.rowClassName(result[i], i);
                    }
                };
                for (var i = 0, len = result.length; i < len; i++) {
                    _loop_1(i, len);
                }
                return result;
            })));
            data$
                .forEach((/**
             * @param {?} result
             * @return {?}
             */
            function (result) { return (retList = result); }))
                .then((/**
             * @return {?}
             */
            function () {
                /** @type {?} */
                var realTotal = retTotal || total;
                /** @type {?} */
                var realPs = retPs || ps;
                resolvePromise({
                    pi: retPi,
                    ps: retPs,
                    total: retTotal,
                    list: retList,
                    statistical: _this.genStatistical(columns, retList, rawData),
                    pageShow: typeof showPage === 'undefined' ? realTotal > realPs : showPage,
                });
            }));
        }));
    };
    /**
     * @private
     * @param {?} item
     * @param {?} col
     * @param {?} idx
     * @return {?}
     */
    STDataSource.prototype.get = /**
     * @private
     * @param {?} item
     * @param {?} col
     * @param {?} idx
     * @return {?}
     */
    function (item, col, idx) {
        if (col.format) {
            /** @type {?} */
            var formatRes = col.format(item, col);
            if (formatRes && ~formatRes.indexOf('</')) {
                return { text: this.dom.bypassSecurityTrustHtml(formatRes), org: formatRes };
            }
            return { text: formatRes == null ? '' : formatRes, org: formatRes };
        }
        /** @type {?} */
        var value = deepGet(item, (/** @type {?} */ (col.index)), col.default);
        /** @type {?} */
        var ret = value;
        switch (col.type) {
            case 'no':
                ret = this.getNoIndex(item, col, idx);
                break;
            case 'img':
                ret = value ? "<img src=\"" + value + "\" class=\"img\">" : '';
                break;
            case 'number':
                ret = this.numberPipe.transform(value, col.numberDigits);
                break;
            case 'currency':
                ret = this.currentyPipe.transform(value);
                break;
            case 'date':
                ret = this.datePipe.transform(value, col.dateFormat);
                break;
            case 'yn':
                ret = this.ynPipe.transform(value === col.yn.truth, col.yn.yes, col.yn.no);
                break;
        }
        return { text: ret == null ? '' : ret, org: value };
    };
    /**
     * @private
     * @param {?} url
     * @param {?} options
     * @return {?}
     */
    STDataSource.prototype.getByHttp = /**
     * @private
     * @param {?} url
     * @param {?} options
     * @return {?}
     */
    function (url, options) {
        var _a, _b;
        var req = options.req, page = options.page, pi = options.pi, ps = options.ps, singleSort = options.singleSort, multiSort = options.multiSort, columns = options.columns;
        /** @type {?} */
        var method = (req.method || 'GET').toUpperCase();
        /** @type {?} */
        var params = {};
        if (req.type === 'page') {
            params = (_a = {},
                _a[req.reName.pi] = page.zeroIndexed ? pi - 1 : pi,
                _a[req.reName.ps] = ps,
                _a);
        }
        else {
            params = (_b = {},
                _b[req.reName.skip] = (pi - 1) * ps,
                _b[req.reName.limit] = ps,
                _b);
        }
        params = tslib_1.__assign({}, params, req.params, this.getReqSortMap(singleSort, multiSort, columns), this.getReqFilterMap(columns));
        /** @type {?} */
        var reqOptions = {
            params: params,
            body: req.body,
            headers: req.headers,
        };
        if (method === 'POST' && req.allInBody === true) {
            reqOptions = {
                body: tslib_1.__assign({}, req.body, params),
                headers: req.headers,
            };
        }
        if (typeof req.process === 'function') {
            reqOptions = req.process(reqOptions);
        }
        return this.http.request(method, url, reqOptions);
    };
    /**
     * @param {?} item
     * @param {?} col
     * @param {?} idx
     * @return {?}
     */
    STDataSource.prototype.getNoIndex = /**
     * @param {?} item
     * @param {?} col
     * @param {?} idx
     * @return {?}
     */
    function (item, col, idx) {
        return typeof col.noIndex === 'function' ? col.noIndex(item, col, idx) : col.noIndex + idx;
    };
    // #region sort
    // #region sort
    /**
     * @private
     * @param {?} columns
     * @return {?}
     */
    STDataSource.prototype.getValidSort = 
    // #region sort
    /**
     * @private
     * @param {?} columns
     * @return {?}
     */
    function (columns) {
        return columns
            .filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return item._sort && item._sort.enabled && item._sort.default; }))
            .map((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return item._sort; }));
    };
    /**
     * @private
     * @param {?} columns
     * @return {?}
     */
    STDataSource.prototype.getSorterFn = /**
     * @private
     * @param {?} columns
     * @return {?}
     */
    function (columns) {
        /** @type {?} */
        var sortList = this.getValidSort(columns);
        if (sortList.length === 0) {
            return;
        }
        if (typeof sortList[0].compare !== 'function') {
            console.warn("[st] Muse provide the compare function in sort");
            return;
        }
        return (/**
         * @param {?} a
         * @param {?} b
         * @return {?}
         */
        function (a, b) {
            /** @type {?} */
            var result = sortList[0].compare(a, b);
            if (result !== 0) {
                return sortList[0].default === 'descend' ? -result : result;
            }
            return 0;
        });
    };
    Object.defineProperty(STDataSource.prototype, "nextSortTick", {
        get: /**
         * @return {?}
         */
        function () {
            return ++this.sortTick;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @param {?} singleSort
     * @param {?} multiSort
     * @param {?} columns
     * @return {?}
     */
    STDataSource.prototype.getReqSortMap = /**
     * @param {?} singleSort
     * @param {?} multiSort
     * @param {?} columns
     * @return {?}
     */
    function (singleSort, multiSort, columns) {
        var _a;
        /** @type {?} */
        var ret = {};
        /** @type {?} */
        var sortList = this.getValidSort(columns);
        if (!multiSort && sortList.length === 0)
            return ret;
        if (multiSort) {
            /** @type {?} */
            var ms_1 = tslib_1.__assign({ key: 'sort', separator: '-', nameSeparator: '.' }, multiSort);
            ret = (_a = {},
                _a[ms_1.key] = sortList.sort((/**
                 * @param {?} a
                 * @param {?} b
                 * @return {?}
                 */
                function (a, b) { return a.tick - b.tick; }))
                    .map((/**
                 * @param {?} item
                 * @return {?}
                 */
                function (item) { return item.key + ms_1.nameSeparator + ((item.reName || {})[item.default] || item.default); }))
                    .join(ms_1.separator),
                _a);
        }
        else {
            /** @type {?} */
            var mapData = sortList[0];
            /** @type {?} */
            var sortFiled = mapData.key;
            /** @type {?} */
            var sortValue = (sortList[0].reName || {})[mapData.default] || mapData.default;
            if (singleSort) {
                sortValue = sortFiled + (singleSort.nameSeparator || '.') + sortValue;
                sortFiled = singleSort.key || 'sort';
            }
            ret[sortFiled] = sortValue;
        }
        return ret;
    };
    // #endregion
    // #region filter
    // #endregion
    // #region filter
    /**
     * @private
     * @param {?} columns
     * @return {?}
     */
    STDataSource.prototype.getReqFilterMap = 
    // #endregion
    // #region filter
    /**
     * @private
     * @param {?} columns
     * @return {?}
     */
    function (columns) {
        /** @type {?} */
        var ret = {};
        columns
            .filter((/**
         * @param {?} w
         * @return {?}
         */
        function (w) { return w.filter && w.filter.default === true; }))
            .forEach((/**
         * @param {?} col
         * @return {?}
         */
        function (col) {
            /** @type {?} */
            var values = col.filter.menus.filter((/**
             * @param {?} f
             * @return {?}
             */
            function (f) { return f.checked === true; }));
            /** @type {?} */
            var obj = {};
            if (col.filter.reName) {
                obj = col.filter.reName(col.filter.menus, col);
            }
            else {
                obj[col.filter.key] = values.map((/**
                 * @param {?} i
                 * @return {?}
                 */
                function (i) { return i.value; })).join(',');
            }
            ret = tslib_1.__assign({}, ret, obj);
        }));
        return ret;
    };
    // #endregion
    // #region statistical
    // #endregion
    // #region statistical
    /**
     * @private
     * @param {?} columns
     * @param {?} list
     * @param {?} rawData
     * @return {?}
     */
    STDataSource.prototype.genStatistical = 
    // #endregion
    // #region statistical
    /**
     * @private
     * @param {?} columns
     * @param {?} list
     * @param {?} rawData
     * @return {?}
     */
    function (columns, list, rawData) {
        var _this = this;
        /** @type {?} */
        var res = {};
        columns.forEach((/**
         * @param {?} col
         * @param {?} index
         * @return {?}
         */
        function (col, index) {
            res[col.key ? col.key : index] =
                col.statistical == null ? {} : _this.getStatistical(col, index, list, rawData);
        }));
        return res;
    };
    /**
     * @private
     * @param {?} col
     * @param {?} index
     * @param {?} list
     * @param {?} rawData
     * @return {?}
     */
    STDataSource.prototype.getStatistical = /**
     * @private
     * @param {?} col
     * @param {?} index
     * @param {?} list
     * @param {?} rawData
     * @return {?}
     */
    function (col, index, list, rawData) {
        /** @type {?} */
        var val = col.statistical;
        /** @type {?} */
        var item = tslib_1.__assign({ digits: 2, currenty: null }, (typeof val === 'string' ? { type: (/** @type {?} */ (val)) } : ((/** @type {?} */ (val)))));
        /** @type {?} */
        var res = { value: 0 };
        /** @type {?} */
        var currenty = false;
        if (typeof item.type === 'function') {
            res = item.type(this.getValues(index, list), col, list, rawData);
            currenty = true;
        }
        else {
            switch (item.type) {
                case 'count':
                    res.value = list.length;
                    break;
                case 'distinctCount':
                    res.value = this.getValues(index, list).filter((/**
                     * @param {?} value
                     * @param {?} idx
                     * @param {?} self
                     * @return {?}
                     */
                    function (value, idx, self) { return self.indexOf(value) === idx; })).length;
                    break;
                case 'sum':
                    res.value = this.toFixed(this.getSum(index, list), item.digits);
                    currenty = true;
                    break;
                case 'average':
                    res.value = this.toFixed(this.getSum(index, list) / list.length, item.digits);
                    currenty = true;
                    break;
                case 'max':
                    res.value = Math.max.apply(Math, tslib_1.__spread(this.getValues(index, list)));
                    currenty = true;
                    break;
                case 'min':
                    res.value = Math.min.apply(Math, tslib_1.__spread(this.getValues(index, list)));
                    currenty = true;
                    break;
            }
        }
        if (item.currenty === true || (item.currenty == null && currenty === true)) {
            res.text = this.currentyPipe.transform(res.value);
        }
        else {
            res.text = String(res.value);
        }
        return res;
    };
    /**
     * @private
     * @param {?} val
     * @param {?} digits
     * @return {?}
     */
    STDataSource.prototype.toFixed = /**
     * @private
     * @param {?} val
     * @param {?} digits
     * @return {?}
     */
    function (val, digits) {
        if (isNaN(val) || !isFinite(val)) {
            return 0;
        }
        return parseFloat(val.toFixed(digits));
    };
    /**
     * @private
     * @param {?} index
     * @param {?} list
     * @return {?}
     */
    STDataSource.prototype.getValues = /**
     * @private
     * @param {?} index
     * @param {?} list
     * @return {?}
     */
    function (index, list) {
        return list.map((/**
         * @param {?} i
         * @return {?}
         */
        function (i) { return i._values[index].org; })).map((/**
         * @param {?} i
         * @return {?}
         */
        function (i) { return (i === '' || i == null ? 0 : i); }));
    };
    /**
     * @private
     * @param {?} index
     * @param {?} list
     * @return {?}
     */
    STDataSource.prototype.getSum = /**
     * @private
     * @param {?} index
     * @param {?} list
     * @return {?}
     */
    function (index, list) {
        return this.getValues(index, list).reduce((/**
         * @param {?} p
         * @param {?} i
         * @return {?}
         */
        function (p, i) { return (p += parseFloat(String(i))); }), 0);
    };
    STDataSource.decorators = [
        { type: Injectable }
    ];
    /** @nocollapse */
    STDataSource.ctorParameters = function () { return [
        { type: _HttpClient },
        { type: CNCurrencyPipe, decorators: [{ type: Host }] },
        { type: DatePipe, decorators: [{ type: Host }] },
        { type: YNPipe, decorators: [{ type: Host }] },
        { type: DecimalPipe, decorators: [{ type: Host }] },
        { type: DomSanitizer }
    ]; };
    return STDataSource;
}());
export { STDataSource };
if (false) {
    /**
     * @type {?}
     * @private
     */
    STDataSource.prototype.sortTick;
    /**
     * @type {?}
     * @private
     */
    STDataSource.prototype.http;
    /**
     * @type {?}
     * @private
     */
    STDataSource.prototype.currentyPipe;
    /**
     * @type {?}
     * @private
     */
    STDataSource.prototype.datePipe;
    /**
     * @type {?}
     * @private
     */
    STDataSource.prototype.ynPipe;
    /**
     * @type {?}
     * @private
     */
    STDataSource.prototype.numberPipe;
    /**
     * @type {?}
     * @private
     */
    STDataSource.prototype.dom;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidGFibGUtZGF0YS1zb3VyY2UuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL3RhYmxlLyIsInNvdXJjZXMiOlsidGFibGUtZGF0YS1zb3VyY2UudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7QUFBQSxPQUFPLEVBQUUsV0FBVyxFQUFFLE1BQU0saUJBQWlCLENBQUM7QUFDOUMsT0FBTyxFQUFFLElBQUksRUFBRSxVQUFVLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFDakQsT0FBTyxFQUFFLFlBQVksRUFBRSxNQUFNLDJCQUEyQixDQUFDO0FBQ3pELE9BQU8sRUFBRSxFQUFFLEVBQWMsTUFBTSxNQUFNLENBQUM7QUFDdEMsT0FBTyxFQUFFLFVBQVUsRUFBRSxHQUFHLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUVqRCxPQUFPLEVBQUUsV0FBVyxFQUFFLGNBQWMsRUFBRSxRQUFRLEVBQUUsTUFBTSxFQUFFLE1BQU0sY0FBYyxDQUFDO0FBQzdFLE9BQU8sRUFBRSxRQUFRLEVBQUUsT0FBTyxFQUFFLE1BQU0sYUFBYSxDQUFDOzs7O0FBbUJoRCx5Q0FZQzs7O0lBWEMsaUNBQVk7O0lBQ1osaUNBQVk7O0lBQ1osbUNBQWdEOztJQUNoRCxvQ0FBZTs7SUFDZixrQ0FBWTs7SUFDWixrQ0FBWTs7SUFDWixtQ0FBYzs7SUFDZCxzQ0FBcUI7O0lBQ3JCLHlDQUEwQjs7SUFDMUIsd0NBQXdCOztJQUN4QiwyQ0FBOEI7Ozs7O0FBR2hDLHdDQWFDOzs7Ozs7SUFYQyxzQ0FBbUI7Ozs7O0lBRW5CLGdDQUFZOzs7OztJQUVaLGdDQUFZOzs7OztJQUVaLG1DQUFlOzs7OztJQUVmLGtDQUFnQjs7Ozs7SUFFaEIseUNBQW1DOztBQUdyQztJQUlFLHNCQUNVLElBQWlCLEVBQ1QsWUFBNEIsRUFDNUIsUUFBa0IsRUFDbEIsTUFBYyxFQUNkLFVBQXVCLEVBQy9CLEdBQWlCO1FBTGpCLFNBQUksR0FBSixJQUFJLENBQWE7UUFDVCxpQkFBWSxHQUFaLFlBQVksQ0FBZ0I7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QUFDLENBQUMsR0FBRyxFQUFwQixDQUFvQixFQUFDLENBQUMsR0FBRzs7OztRQUFDLFVBQUEsQ0FBQyxJQUFJLE9BQUEsQ0FBQyxDQUFDLEtBQUssRUFBRSxJQUFJLENBQUMsSUFBSSxJQUFJLENBQUMsQ0FBQyxDQUFDLENBQUMsQ0FBQyxDQUFDLENBQUMsQ0FBQyxDQUFDLEVBQS9CLENBQStCLEVBQUMsQ0FBQztJQUN2RixDQUFDOzs7Ozs7O0lBRU8sNkJBQU07Ozs7OztJQUFkLFVBQWUsS0FBYSxFQUFFLElBQWM7UUFDMUMsT0FBTyxJQUFJLENBQUMsU0FBUyxDQUFDLEtBQUssRUFBRSxJQUFJLENBQUMsQ0FBQyxNQUFNOzs7OztRQUFDLFVBQUMsQ0FBQyxFQUFFLENBQUMsSUFBSyxPQUFBLENBQUMsQ0FBQyxJQUFJLFVBQVUsQ0FBQyxNQUFNLENBQUMsQ0FBQyxDQUFDLENBQUMsQ0FBQyxFQUE1QixDQUE0QixHQUFFLENBQUMsQ0FBQyxDQUFDO0lBQ3ZGLENBQUM7O2dCQTFYRixVQUFVOzs7O2dCQWpERixXQUFXO2dCQUFFLGNBQWMsdUJBdUQvQixJQUFJO2dCQXZENkIsUUFBUSx1QkF3RHpDLElBQUk7Z0JBeER1QyxNQUFNLHVCQXlEakQsSUFBSTtnQkEvREEsV0FBVyx1QkFnRWYsSUFBSTtnQkE5REEsWUFBWTs7SUFrYnJCLG1CQUFDO0NBQUEsQUE3WEQsSUE2WEM7U0E1WFksWUFBWTs7Ozs7O0lBQ3ZCLGdDQUFxQjs7Ozs7SUFHbkIsNEJBQXlCOzs7OztJQUN6QixvQ0FBNEM7Ozs7O0lBQzVDLGdDQUFrQzs7Ozs7SUFDbEMsOEJBQThCOzs7OztJQUM5QixrQ0FBdUM7Ozs7O0lBQ3ZDLDJCQUF5QiIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IERlY2ltYWxQaXBlIH0gZnJvbSAnQGFuZ3VsYXIvY29tbW9uJztcbmltcG9ydCB7IEhvc3QsIEluamVjdGFibGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IERvbVNhbml0aXplciB9IGZyb20gJ0Bhbmd1bGFyL3BsYXRmb3JtLWJyb3dzZXInO1xuaW1wb3J0IHsgb2YsIE9ic2VydmFibGUgfSBmcm9tICdyeGpzJztcbmltcG9ydCB7IGNhdGNoRXJyb3IsIG1hcCB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuaW1wb3J0IHsgX0h0dHBDbGllbnQsIENOQ3VycmVuY3lQaXBlLCBEYXRlUGlwZSwgWU5QaXBlIH0gZnJvbSAnQGRlbG9uL3RoZW1lJztcbmltcG9ydCB7IGRlZXBDb3B5LCBkZWVwR2V0IH0gZnJvbSAnQGRlbG9uL3V0aWwnO1xuXG5pbXBvcnQgeyBTVFNvcnRNYXAgfSBmcm9tICcuL3RhYmxlLWNvbHVtbi1zb3VyY2UnO1xuaW1wb3J0IHtcbiAgU1RDb2x1bW4sXG4gIFNURGF0YSxcbiAgU1RNdWx0aVNvcnQsXG4gIFNUUGFnZSxcbiAgU1RSZXEsXG4gIFNUUmVxdWVzdE9wdGlvbnMsXG4gIFNUUmVzLFxuICBTVFJvd0NsYXNzTmFtZSxcbiAgU1RTaW5nbGVTb3J0LFxuICBTVFN0YXRpc3RpY2FsLFxuICBTVFN0YXRpc3RpY2FsUmVzdWx0LFxuICBTVFN0YXRpc3RpY2FsUmVzdWx0cyxcbiAgU1RTdGF0aXN0aWNhbFR5cGUsXG59IGZyb20gJy4vdGFibGUuaW50ZXJmYWNlcyc7XG5cbmV4cG9ydCBpbnRlcmZhY2UgU1REYXRhU291cmNlT3B0aW9ucyB7XG4gIHBpPzogbnVtYmVyO1xuICBwcz86IG51bWJlcjtcbiAgZGF0YT86IHN0cmluZyB8IFNURGF0YVtdIHwgT2JzZXJ2YWJsZTxTVERhdGFbXT47XG4gIHRvdGFsPzogbnVtYmVyO1xuICByZXE/OiBTVFJlcTtcbiAgcmVzPzogU1RSZXM7XG4gIHBhZ2U/OiBTVFBhZ2U7XG4gIGNvbHVtbnM/OiBTVENvbHVtbltdO1xuICBzaW5nbGVTb3J0PzogU1RTaW5nbGVTb3J0O1xuICBtdWx0aVNvcnQ/OiBTVE11bHRpU29ydDtcbiAgcm93Q2xhc3NOYW1lPzogU1RSb3dDbGFzc05hbWU7XG59XG5cbmV4cG9ydCBpbnRlcmZhY2UgU1REYXRhU291cmNlUmVzdWx0IHtcbiAgLyoqIOaYr+WQpumcgOimgeaYvuekuuWIhumhteWZqCAqL1xuICBwYWdlU2hvdz86IGJvb2xlYW47XG4gIC8qKiDmlrAgYHBpYO+8jOiLpei/lOWbniBgdW5kZWZpbmVkYCDooajnpLrnlKjmiLflj5fmjqcgKi9cbiAgcGk/OiBudW1iZXI7XG4gIC8qKiDmlrAgYHBzYO+8jOiLpei/lOWbniBgdW5kZWZpbmVkYCDooajnpLrnlKjmiLflj5fmjqcgKi9cbiAgcHM/OiBudW1iZXI7XG4gIC8qKiDmlrAgYHRvdGFsYO+8jOiLpei/lOWbniBgdW5kZWZpbmVkYCDooajnpLrnlKjmiLflj5fmjqcgKi9cbiAgdG90YWw/OiBudW1iZXI7XG4gIC8qKiDmlbDmja4gKi9cbiAgbGlzdD86IFNURGF0YVtdO1xuICAvKiog57uf6K6h5pWw5o2uICovXG4gIHN0YXRpc3RpY2FsPzogU1RTdGF0aXN0aWNhbFJlc3VsdHM7XG59XG5cbkBJbmplY3RhYmxlKClcbmV4cG9ydCBjbGFzcyBTVERhdGFTb3VyY2Uge1xuICBwcml2YXRlIHNvcnRUaWNrID0gMDtcblxuICBjb25zdHJ1Y3RvcihcbiAgICBwcml2YXRlIGh0dHA6IF9IdHRwQ2xpZW50LFxuICAgIEBIb3N0KCkgcHJpdmF0ZSBjdXJyZW50eVBpcGU6IENOQ3VycmVuY3lQaXBlLFxuICAgIEBIb3N0KCkgcHJpdmF0ZSBkYXRlUGlwZTogRGF0ZVBpcGUsXG4gICAgQEhvc3QoKSBwcml2YXRlIHluUGlwZTogWU5QaXBlLFxuICAgIEBIb3N0KCkgcHJpdmF0ZSBudW1iZXJQaXBlOiBEZWNpbWFsUGlwZSxcbiAgICBwcml2YXRlIGRvbTogRG9tU2FuaXRpemVyLFxuICApIHt9XG5cbiAgcHJvY2VzcyhvcHRpb25zOiBTVERhdGFTb3VyY2VPcHRpb25zKTogUHJvbWlzZTxTVERhdGFTb3VyY2VSZXN1bHQ+IHtcbiAgICByZXR1cm4gbmV3IFByb21pc2UoKHJlc29sdmVQcm9taXNlLCByZWplY3RQcm9taXNlKSA9PiB7XG4gICAgICBsZXQgZGF0YSQ6IE9ic2VydmFibGU8U1REYXRhW10+O1xuICAgICAgbGV0IGlzUmVtb3RlID0gZmFsc2U7XG4gICAgICBjb25zdCB7IGRhdGEsIHJlcywgdG90YWwsIHBhZ2UsIHBpLCBwcywgY29sdW1ucyB9ID0gb3B0aW9ucztcbiAgICAgIGxldCByZXRUb3RhbDogbnVtYmVyO1xuICAgICAgbGV0IHJldFBzOiBudW1iZXI7XG4gICAgICBsZXQgcmV0TGlzdDogU1REYXRhW107XG4gICAgICBsZXQgcmV0UGk6IG51bWJlcjtcbiAgICAgIGxldCByYXdEYXRhOiBhbnk7XG4gICAgICBsZXQgc2hvd1BhZ2UgPSBwYWdlLnNob3c7XG5cbiAgICAgIGlmICh0eXBlb2YgZGF0YSA9PT0gJ3N0cmluZycpIHtcbiAgICAgICAgaXNSZW1vdGUgPSB0cnVlO1xuICAgICAgICBkYXRhJCA9IHRoaXMuZ2V0QnlIdHRwKGRhdGEsIG9wdGlvbnMpLnBpcGUoXG4gICAgICAgICAgbWFwKHJlc3VsdCA9PiB7XG4gICAgICAgICAgICByYXdEYXRhID0gcmVzdWx0O1xuICAgICAgICAgICAgbGV0IHJldDogU1REYXRhW107XG4gICAgICAgICAgICBpZiAoQXJyYXkuaXNBcnJheShyZXN1bHQpKSB7XG4gICAgICAgICAgICAgIHJldCA9IHJlc3VsdDtcbiAgICAgICAgICAgICAgcmV0VG90YWwgPSByZXQubGVuZ3RoO1xuICAgICAgICAgICAgICByZXRQcyA9IHJldFRvdGFsO1xuICAgICAgICAgICAgICBzaG93UGFnZSA9IGZhbHNlO1xuICAgICAgICAgICAgfSBlbHNlIHtcbiAgICAgICAgICAgICAgLy8gbGlzdFxuICAgICAgICAgICAgICByZXQgPSBkZWVwR2V0KHJlc3VsdCwgcmVzLnJlTmFtZS5saXN0IGFzIHN0cmluZ1tdLCBbXSk7XG4gICAgICAgICAgICAgIGlmIChyZXQgPT0gbnVsbCB8fCAhQXJyYXkuaXNBcnJheShyZXQpKSB7XG4gICAgICAgICAgICAgICAgcmV0ID0gW107XG4gICAgICAgICAgICAgIH1cbiAgICAgICAgICAgICAgLy8gdG90YWxcbiAgICAgICAgICAgICAgY29uc3QgcmVzdWx0VG90YWwgPVxuICAgICAgICAgICAgICAgIHJlcy5yZU5hbWUudG90YWwgJiYgZGVlcEdldChyZXN1bHQsIHJlcy5yZU5hbWUudG90YWwgYXMgc3RyaW5nW10sIG51bGwpO1xuICAgICAgICAgICAgICByZXRUb3RhbCA9IHJlc3VsdFRvdGFsID09IG51bGwgPyB0b3RhbCB8fCAwIDogK3Jlc3VsdFRvdGFsO1xuICAgICAgICAgICAgfVxuICAgICAgICAgICAgcmV0dXJuIGRlZXBDb3B5KHJldCk7XG4gICAgICAgICAgfSksXG4gICAgICAgICAgY2F0Y2hFcnJvcihlcnIgPT4ge1xuICAgICAgICAgICAgcmVqZWN0UHJvbWlzZShlcnIpO1xuICAgICAgICAgICAgcmV0dXJuIFtdO1xuICAgICAgICAgIH0pLFxuICAgICAgICApO1xuICAgICAgfSBlbHNlIGlmIChBcnJheS5pc0FycmF5KGRhdGEpKSB7XG4gICAgICAgIGRhdGEkID0gb2YoZGF0YSk7XG4gICAgICB9IGVsc2Uge1xuICAgICAgICAvLyBhIGNvbGQgb2JzZXJ2YWJsZVxuICAgICAgICBkYXRhJCA9IGRhdGE7XG4gICAgICB9XG5cbiAgICAgIGlmICghaXNSZW1vdGUpIHtcbiAgICAgICAgZGF0YSQgPSBkYXRhJC5waXBlKFxuICAgICAgICAgIC8vIHNvcnRcbiAgICAgICAgICBtYXAoKHJlc3VsdDogU1REYXRhW10pID0+IHtcbiAgICAgICAgICAgIHJhd0RhdGEgPSByZXN1bHQ7XG4gICAgICAgICAgICBsZXQgY29weVJlc3VsdCA9IGRlZXBDb3B5KHJlc3VsdCk7XG4gICAgICAgICAgICBjb25zdCBzb3J0ZXJGbiA9IHRoaXMuZ2V0U29ydGVyRm4oY29sdW1ucyk7XG4gICAgICAgICAgICBpZiAoc29ydGVyRm4pIHtcbiAgICAgICAgICAgICAgY29weVJlc3VsdCA9IGNvcHlSZXN1bHQuc29ydChzb3J0ZXJGbik7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICByZXR1cm4gY29weVJlc3VsdDtcbiAgICAgICAgICB9KSxcbiAgICAgICAgICAvLyBmaWx0ZXJcbiAgICAgICAgICBtYXAoKHJlc3VsdDogU1REYXRhW10pID0+IHtcbiAgICAgICAgICAgIGNvbHVtbnNcbiAgICAgICAgICAgICAgLmZpbHRlcih3ID0+IHcuZmlsdGVyKVxuICAgICAgICAgICAgICAuZm9yRWFjaChjID0+IHtcbiAgICAgICAgICAgICAgICBjb25zdCB2YWx1ZXMgPSBjLmZpbHRlci5tZW51cy5maWx0ZXIodyA9PiB3LmNoZWNrZWQpO1xuICAgICAgICAgICAgICAgIGlmICh2YWx1ZXMubGVuZ3RoID09PSAwKSByZXR1cm47XG4gICAgICAgICAgICAgICAgY29uc3Qgb25GaWx0ZXIgPSBjLmZpbHRlci5mbjtcbiAgICAgICAgICAgICAgICBpZiAodHlwZW9mIG9uRmlsdGVyICE9PSAnZnVuY3Rpb24nKSB7XG4gICAgICAgICAgICAgICAgICBjb25zb2xlLndhcm4oYFtzdF0gTXVzZSBwcm92aWRlIHRoZSBmbiBmdW5jdGlvbiBpbiBmaWx0ZXJgKTtcbiAgICAgICAgICAgICAgICAgIHJldHVybjtcbiAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICAgICAgcmVzdWx0ID0gcmVzdWx0LmZpbHRlcihyZWNvcmQgPT4gdmFsdWVzLnNvbWUodiA9PiBvbkZpbHRlcih2LCByZWNvcmQpKSk7XG4gICAgICAgICAgICAgIH0pO1xuICAgICAgICAgICAgcmV0dXJuIHJlc3VsdDtcbiAgICAgICAgICB9KSxcbiAgICAgICAgICAvLyBwYWdpbmdcbiAgICAgICAgICBtYXAoKHJlc3VsdDogU1REYXRhW10pID0+IHtcbiAgICAgICAgICAgIGlmIChwYWdlLmZyb250KSB7XG4gICAgICAgICAgICAgIGNvbnN0IG1heFBhZ2VJbmRleCA9IE1hdGguY2VpbChyZXN1bHQubGVuZ3RoIC8gcHMpO1xuICAgICAgICAgICAgICByZXRQaSA9IE1hdGgubWF4KDEsIHBpID4gbWF4UGFnZUluZGV4ID8gbWF4UGFnZUluZGV4IDogcGkpO1xuICAgICAgICAgICAgICByZXRUb3RhbCA9IHJlc3VsdC5sZW5ndGg7XG4gICAgICAgICAgICAgIGlmIChwYWdlLnNob3cgPT09IHRydWUpIHtcbiAgICAgICAgICAgICAgICByZXR1cm4gcmVzdWx0LnNsaWNlKChyZXRQaSAtIDEpICogcHMsIHJldFBpICogcHMpO1xuICAgICAgICAgICAgICB9XG4gICAgICAgICAgICB9XG4gICAgICAgICAgICByZXR1cm4gcmVzdWx0O1xuICAgICAgICAgIH0pLFxuICAgICAgICApO1xuICAgICAgfVxuXG4gICAgICAvLyBwcmUtcHJvY2Vzc1xuICAgICAgaWYgKHR5cGVvZiByZXMucHJvY2VzcyA9PT0gJ2Z1bmN0aW9uJykge1xuICAgICAgICBkYXRhJCA9IGRhdGEkLnBpcGUobWFwKHJlc3VsdCA9PiByZXMucHJvY2VzcyhyZXN1bHQpKSk7XG4gICAgICB9XG5cbiAgICAgIC8vIGRhdGEgYWNjZWxlcmF0b3JcbiAgICAgIGRhdGEkID0gZGF0YSQucGlwZShcbiAgICAgICAgbWFwKHJlc3VsdCA9PiB7XG4gICAgICAgICAgZm9yIChsZXQgaSA9IDAsIGxlbiA9IHJlc3VsdC5sZW5ndGg7IGkgPCBsZW47IGkrKykge1xuICAgICAgICAgICAgcmVzdWx0W2ldLl92YWx1ZXMgPSBjb2x1bW5zLm1hcChjID0+IHRoaXMuZ2V0KHJlc3VsdFtpXSwgYywgaSkpO1xuICAgICAgICAgICAgaWYgKG9wdGlvbnMucm93Q2xhc3NOYW1lKSB7XG4gICAgICAgICAgICAgIHJlc3VsdFtpXS5fcm93Q2xhc3NOYW1lID0gb3B0aW9ucy5yb3dDbGFzc05hbWUocmVzdWx0W2ldLCBpKTtcbiAgICAgICAgICAgIH1cbiAgICAgICAgICB9XG4gICAgICAgICAgcmV0dXJuIHJlc3VsdDtcbiAgICAgICAgfSksXG4gICAgICApO1xuXG4gICAgICBkYXRhJFxuICAgICAgICAuZm9yRWFjaCgocmVzdWx0OiBTVERhdGFbXSkgPT4gKHJldExpc3QgPSByZXN1bHQpKVxuICAgICAgICAudGhlbigoKSA9PiB7XG4gICAgICAgICAgY29uc3QgcmVhbFRvdGFsID0gcmV0VG90YWwgfHwgdG90YWw7XG4gICAgICAgICAgY29uc3QgcmVhbFBzID0gcmV0UHMgfHwgcHM7XG4gICAgICAgICAgcmVzb2x2ZVByb21pc2Uoe1xuICAgICAgICAgICAgcGk6IHJldFBpLFxuICAgICAgICAgICAgcHM6IHJldFBzLFxuICAgICAgICAgICAgdG90YWw6IHJldFRvdGFsLFxuICAgICAgICAgICAgbGlzdDogcmV0TGlzdCxcbiAgICAgICAgICAgIHN0YXRpc3RpY2FsOiB0aGlzLmdlblN0YXRpc3RpY2FsKGNvbHVtbnMsIHJldExpc3QsIHJhd0RhdGEpLFxuICAgICAgICAgICAgcGFnZVNob3c6IHR5cGVvZiBzaG93UGFnZSA9PT0gJ3VuZGVmaW5lZCcgPyByZWFsVG90YWwgPiByZWFsUHMgOiBzaG93UGFnZSxcbiAgICAgICAgICB9KTtcbiAgICAgICAgfSk7XG4gICAgfSk7XG4gIH1cblxuICBwcml2YXRlIGdldChpdGVtOiBTVERhdGEsIGNvbDogU1RDb2x1bW4sIGlkeDogbnVtYmVyKTogeyB0ZXh0OiBhbnk7IG9yZz86IGFueSB9IHtcbiAgICBpZiAoY29sLmZvcm1hdCkge1xuICAgICAgY29uc3QgZm9ybWF0UmVzID0gY29sLmZvcm1hdChpdGVtLCBjb2wpO1xuICAgICAgaWYgKGZvcm1hdFJlcyAmJiB+Zm9ybWF0UmVzLmluZGV4T2YoJzwvJykpIHtcbiAgICAgICAgcmV0dXJuIHsgdGV4dDogdGhpcy5kb20uYnlwYXNzU2VjdXJpdHlUcnVzdEh0bWwoZm9ybWF0UmVzKSwgb3JnOiBmb3JtYXRSZXMgfTtcbiAgICAgIH1cbiAgICAgIHJldHVybiB7IHRleHQ6IGZvcm1hdFJlcyA9PSBudWxsID8gJycgOiBmb3JtYXRSZXMsIG9yZzogZm9ybWF0UmVzIH07XG4gICAgfVxuXG4gICAgY29uc3QgdmFsdWUgPSBkZWVwR2V0KGl0ZW0sIGNvbC5pbmRleCBhcyBzdHJpbmdbXSwgY29sLmRlZmF1bHQpO1xuXG4gICAgbGV0IHJldCA9IHZhbHVlO1xuICAgIHN3aXRjaCAoY29sLnR5cGUpIHtcbiAgICAgIGNhc2UgJ25vJzpcbiAgICAgICAgcmV0ID0gdGhpcy5nZXROb0luZGV4KGl0ZW0sIGNvbCwgaWR4KTtcbiAgICAgICAgYnJlYWs7XG4gICAgICBjYXNlICdpbWcnOlxuICAgICAgICByZXQgPSB2YWx1ZSA/IGA8aW1nIHNyYz1cIiR7dmFsdWV9XCIgY2xhc3M9XCJpbWdcIj5gIDogJyc7XG4gICAgICAgIGJyZWFrO1xuICAgICAgY2FzZSAnbnVtYmVyJzpcbiAgICAgICAgcmV0ID0gdGhpcy5udW1iZXJQaXBlLnRyYW5zZm9ybSh2YWx1ZSwgY29sLm51bWJlckRpZ2l0cyk7XG4gICAgICAgIGJyZWFrO1xuICAgICAgY2FzZSAnY3VycmVuY3knOlxuICAgICAgICByZXQgPSB0aGlzLmN1cnJlbnR5UGlwZS50cmFuc2Zvcm0odmFsdWUpO1xuICAgICAgICBicmVhaztcbiAgICAgIGNhc2UgJ2RhdGUnOlxuICAgICAgICByZXQgPSB0aGlzLmRhdGVQaXBlLnRyYW5zZm9ybSh2YWx1ZSwgY29sLmRhdGVGb3JtYXQpO1xuICAgICAgICBicmVhaztcbiAgICAgIGNhc2UgJ3luJzpcbiAgICAgICAgcmV0ID0gdGhpcy55blBpcGUudHJhbnNmb3JtKHZhbHVlID09PSBjb2wueW4udHJ1dGgsIGNvbC55bi55ZXMsIGNvbC55bi5ubyk7XG4gICAgICAgIGJyZWFrO1xuICAgIH1cbiAgICByZXR1cm4geyB0ZXh0OiByZXQgPT0gbnVsbCA/ICcnIDogcmV0LCBvcmc6IHZhbHVlIH07XG4gIH1cblxuICBwcml2YXRlIGdldEJ5SHR0cCh1cmw6IHN0cmluZywgb3B0aW9uczogU1REYXRhU291cmNlT3B0aW9ucyk6IE9ic2VydmFibGU8e30+IHtcbiAgICBjb25zdCB7IHJlcSwgcGFnZSwgcGksIHBzLCBzaW5nbGVTb3J0LCBtdWx0aVNvcnQsIGNvbHVtbnMgfSA9IG9wdGlvbnM7XG4gICAgY29uc3QgbWV0aG9kID0gKHJlcS5tZXRob2QgfHwgJ0dFVCcpLnRvVXBwZXJDYXNlKCk7XG4gICAgbGV0IHBhcmFtcyA9IHt9O1xuICAgIGlmIChyZXEudHlwZSA9PT0gJ3BhZ2UnKSB7XG4gICAgICBwYXJhbXMgPSB7XG4gICAgICAgIFtyZXEucmVOYW1lLnBpXTogcGFnZS56ZXJvSW5kZXhlZCA/IHBpIC0gMSA6IHBpLFxuICAgICAgICBbcmVxLnJlTmFtZS5wc106IHBzLFxuICAgICAgfTtcbiAgICB9IGVsc2Uge1xuICAgICAgcGFyYW1zID0ge1xuICAgICAgICBbcmVxLnJlTmFtZS5za2lwXTogKHBpIC0gMSkgKiBwcyxcbiAgICAgICAgW3JlcS5yZU5hbWUubGltaXRdOiBwcyxcbiAgICAgIH07XG4gICAgfVxuICAgIHBhcmFtcyA9IHtcbiAgICAgIC4uLnBhcmFtcyxcbiAgICAgIC4uLnJlcS5wYXJhbXMsXG4gICAgICAuLi50aGlzLmdldFJlcVNvcnRNYXAoc2luZ2xlU29ydCwgbXVsdGlTb3J0LCBjb2x1bW5zKSxcbiAgICAgIC4uLnRoaXMuZ2V0UmVxRmlsdGVyTWFwKGNvbHVtbnMpLFxuICAgIH07XG5cbiAgICBsZXQgcmVxT3B0aW9uczogU1RSZXF1ZXN0T3B0aW9ucyA9IHtcbiAgICAgIHBhcmFtcyxcbiAgICAgIGJvZHk6IHJlcS5ib2R5LFxuICAgICAgaGVhZGVyczogcmVxLmhlYWRlcnMsXG4gICAgfTtcbiAgICBpZiAobWV0aG9kID09PSAnUE9TVCcgJiYgcmVxLmFsbEluQm9keSA9PT0gdHJ1ZSkge1xuICAgICAgcmVxT3B0aW9ucyA9IHtcbiAgICAgICAgYm9keTogeyAuLi5yZXEuYm9keSwgLi4ucGFyYW1zIH0sXG4gICAgICAgIGhlYWRlcnM6IHJlcS5oZWFkZXJzLFxuICAgICAgfTtcbiAgICB9XG4gICAgaWYgKHR5cGVvZiByZXEucHJvY2VzcyA9PT0gJ2Z1bmN0aW9uJykge1xuICAgICAgcmVxT3B0aW9ucyA9IHJlcS5wcm9jZXNzKHJlcU9wdGlvbnMpO1xuICAgIH1cbiAgICByZXR1cm4gdGhpcy5odHRwLnJlcXVlc3QobWV0aG9kLCB1cmwsIHJlcU9wdGlvbnMpO1xuICB9XG5cbiAgZ2V0Tm9JbmRleChpdGVtOiBTVERhdGEsIGNvbDogU1RDb2x1bW4sIGlkeDogbnVtYmVyKTogbnVtYmVyIHtcbiAgICByZXR1cm4gdHlwZW9mIGNvbC5ub0luZGV4ID09PSAnZnVuY3Rpb24nID8gY29sLm5vSW5kZXgoaXRlbSwgY29sLCBpZHgpIDogY29sLm5vSW5kZXggKyBpZHg7XG4gIH1cblxuICAvLyAjcmVnaW9uIHNvcnRcblxuICBwcml2YXRlIGdldFZhbGlkU29ydChjb2x1bW5zOiBTVENvbHVtbltdKTogU1RTb3J0TWFwW10ge1xuICAgIHJldHVybiBjb2x1bW5zXG4gICAgICAuZmlsdGVyKGl0ZW0gPT4gaXRlbS5fc29ydCAmJiBpdGVtLl9zb3J0LmVuYWJsZWQgJiYgaXRlbS5fc29ydC5kZWZhdWx0KVxuICAgICAgLm1hcChpdGVtID0+IGl0ZW0uX3NvcnQpO1xuICB9XG5cbiAgcHJpdmF0ZSBnZXRTb3J0ZXJGbihjb2x1bW5zOiBTVENvbHVtbltdKSB7XG4gICAgY29uc3Qgc29ydExpc3QgPSB0aGlzLmdldFZhbGlkU29ydChjb2x1bW5zKTtcbiAgICBpZiAoc29ydExpc3QubGVuZ3RoID09PSAwKSB7XG4gICAgICByZXR1cm47XG4gICAgfVxuICAgIGlmICh0eXBlb2Ygc29ydExpc3RbMF0uY29tcGFyZSAhPT0gJ2Z1bmN0aW9uJykge1xuICAgICAgY29uc29sZS53YXJuKGBbc3RdIE11c2UgcHJvdmlkZSB0aGUgY29tcGFyZSBmdW5jdGlvbiBpbiBzb3J0YCk7XG4gICAgICByZXR1cm47XG4gICAgfVxuXG4gICAgcmV0dXJuIChhOiBTVERhdGEsIGI6IFNURGF0YSkgPT4ge1xuICAgICAgY29uc3QgcmVzdWx0ID0gc29ydExpc3RbMF0uY29tcGFyZShhLCBiKTtcbiAgICAgIGlmIChyZXN1bHQgIT09IDApIHtcbiAgICAgICAgcmV0dXJuIHNvcnRMaXN0WzBdLmRlZmF1bHQgPT09ICdkZXNjZW5kJyA/IC1yZXN1bHQgOiByZXN1bHQ7XG4gICAgICB9XG4gICAgICByZXR1cm4gMDtcbiAgICB9O1xuICB9XG5cbiAgZ2V0IG5leHRTb3J0VGljaygpOiBudW1iZXIge1xuICAgIHJldHVybiArK3RoaXMuc29ydFRpY2s7XG4gIH1cblxuICBnZXRSZXFTb3J0TWFwKFxuICAgIHNpbmdsZVNvcnQ6IFNUU2luZ2xlU29ydCxcbiAgICBtdWx0aVNvcnQ6IFNUTXVsdGlTb3J0LFxuICAgIGNvbHVtbnM6IFNUQ29sdW1uW10sXG4gICk6IHsgW2tleTogc3RyaW5nXTogc3RyaW5nIH0ge1xuICAgIGxldCByZXQ6IHsgW2tleTogc3RyaW5nXTogc3RyaW5nIH0gPSB7fTtcbiAgICBjb25zdCBzb3J0TGlzdCA9IHRoaXMuZ2V0VmFsaWRTb3J0KGNvbHVtbnMpO1xuICAgIGlmICghbXVsdGlTb3J0ICYmIHNvcnRMaXN0Lmxlbmd0aCA9PT0gMCkgcmV0dXJuIHJldDtcblxuICAgIGlmIChtdWx0aVNvcnQpIHtcbiAgICAgIGNvbnN0IG1zID0ge1xuICAgICAgICBrZXk6ICdzb3J0JyxcbiAgICAgICAgc2VwYXJhdG9yOiAnLScsXG4gICAgICAgIG5hbWVTZXBhcmF0b3I6ICcuJyxcbiAgICAgICAgLi4ubXVsdGlTb3J0LFxuICAgICAgfTtcblxuICAgICAgcmV0ID0ge1xuICAgICAgICBbbXMua2V5XTogc29ydExpc3Quc29ydCgoYSwgYikgPT4gYS50aWNrIC0gYi50aWNrKVxuICAgICAgICAgIC5tYXAoaXRlbSA9PiBpdGVtLmtleSArIG1zLm5hbWVTZXBhcmF0b3IgKyAoKGl0ZW0ucmVOYW1lIHx8IHt9KVtpdGVtLmRlZmF1bHRdIHx8IGl0ZW0uZGVmYXVsdCkpXG4gICAgICAgICAgLmpvaW4obXMuc2VwYXJhdG9yKSxcbiAgICAgIH07XG4gICAgfSBlbHNlIHtcbiAgICAgIGNvbnN0IG1hcERhdGEgPSBzb3J0TGlzdFswXTtcbiAgICAgIGxldCBzb3J0RmlsZWQgPSBtYXBEYXRhLmtleTtcbiAgICAgIGxldCBzb3J0VmFsdWUgPSAoc29ydExpc3RbMF0ucmVOYW1lIHx8IHt9KVttYXBEYXRhLmRlZmF1bHRdIHx8IG1hcERhdGEuZGVmYXVsdDtcbiAgICAgIGlmIChzaW5nbGVTb3J0KSB7XG4gICAgICAgIHNvcnRWYWx1ZSA9IHNvcnRGaWxlZCArIChzaW5nbGVTb3J0Lm5hbWVTZXBhcmF0b3IgfHwgJy4nKSArIHNvcnRWYWx1ZTtcbiAgICAgICAgc29ydEZpbGVkID0gc2luZ2xlU29ydC5rZXkgfHwgJ3NvcnQnO1xuICAgICAgfVxuICAgICAgcmV0W3NvcnRGaWxlZF0gPSBzb3J0VmFsdWU7XG4gICAgfVxuICAgIHJldHVybiByZXQ7XG4gIH1cblxuICAvLyAjZW5kcmVnaW9uXG5cbiAgLy8gI3JlZ2lvbiBmaWx0ZXJcblxuICBwcml2YXRlIGdldFJlcUZpbHRlck1hcChjb2x1bW5zOiBTVENvbHVtbltdKTogeyBba2V5OiBzdHJpbmddOiBzdHJpbmcgfSB7XG4gICAgbGV0IHJldCA9IHt9O1xuICAgIGNvbHVtbnNcbiAgICAgIC5maWx0ZXIodyA9PiB3LmZpbHRlciAmJiB3LmZpbHRlci5kZWZhdWx0ID09PSB0cnVlKVxuICAgICAgLmZvckVhY2goY29sID0+IHtcbiAgICAgICAgY29uc3QgdmFsdWVzID0gY29sLmZpbHRlci5tZW51cy5maWx0ZXIoZiA9PiBmLmNoZWNrZWQgPT09IHRydWUpO1xuICAgICAgICBsZXQgb2JqOiB7fSA9IHt9O1xuICAgICAgICBpZiAoY29sLmZpbHRlci5yZU5hbWUpIHtcbiAgICAgICAgICBvYmogPSBjb2wuZmlsdGVyLnJlTmFtZShjb2wuZmlsdGVyLm1lbnVzLCBjb2wpO1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgIG9ialtjb2wuZmlsdGVyLmtleV0gPSB2YWx1ZXMubWFwKGkgPT4gaS52YWx1ZSkuam9pbignLCcpO1xuICAgICAgICB9XG4gICAgICAgIHJldCA9IHsgLi4ucmV0LCAuLi5vYmogfTtcbiAgICAgIH0pO1xuICAgIHJldHVybiByZXQ7XG4gIH1cblxuICAvLyAjZW5kcmVnaW9uXG5cbiAgLy8gI3JlZ2lvbiBzdGF0aXN0aWNhbFxuXG4gIHByaXZhdGUgZ2VuU3RhdGlzdGljYWwoY29sdW1uczogU1RDb2x1bW5bXSwgbGlzdDogU1REYXRhW10sIHJhd0RhdGE6IGFueSk6IFNUU3RhdGlzdGljYWxSZXN1bHRzIHtcbiAgICBjb25zdCByZXMgPSB7fTtcbiAgICBjb2x1bW5zLmZvckVhY2goKGNvbCwgaW5kZXgpID0+IHtcbiAgICAgIHJlc1tjb2wua2V5ID8gY29sLmtleSA6IGluZGV4XSA9XG4gICAgICAgIGNvbC5zdGF0aXN0aWNhbCA9PSBudWxsID8ge30gOiB0aGlzLmdldFN0YXRpc3RpY2FsKGNvbCwgaW5kZXgsIGxpc3QsIHJhd0RhdGEpO1xuICAgIH0pO1xuICAgIHJldHVybiByZXM7XG4gIH1cblxuICBwcml2YXRlIGdldFN0YXRpc3RpY2FsKGNvbDogU1RDb2x1bW4sIGluZGV4OiBudW1iZXIsIGxpc3Q6IFNURGF0YVtdLCByYXdEYXRhOiBhbnkpOiBTVFN0YXRpc3RpY2FsUmVzdWx0IHtcbiAgICBjb25zdCB2YWwgPSBjb2wuc3RhdGlzdGljYWw7XG4gICAgY29uc3QgaXRlbTogU1RTdGF0aXN0aWNhbCA9IHtcbiAgICAgIGRpZ2l0czogMixcbiAgICAgIGN1cnJlbnR5OiBudWxsLFxuICAgICAgLi4uKHR5cGVvZiB2YWwgPT09ICdzdHJpbmcnID8geyB0eXBlOiB2YWwgYXMgU1RTdGF0aXN0aWNhbFR5cGUgfSA6ICh2YWwgYXMgU1RTdGF0aXN0aWNhbCkpLFxuICAgIH07XG4gICAgbGV0IHJlczogU1RTdGF0aXN0aWNhbFJlc3VsdCA9IHsgdmFsdWU6IDAgfTtcbiAgICBsZXQgY3VycmVudHkgPSBmYWxzZTtcbiAgICBpZiAodHlwZW9mIGl0ZW0udHlwZSA9PT0gJ2Z1bmN0aW9uJykge1xuICAgICAgcmVzID0gaXRlbS50eXBlKHRoaXMuZ2V0VmFsdWVzKGluZGV4LCBsaXN0KSwgY29sLCBsaXN0LCByYXdEYXRhKTtcbiAgICAgIGN1cnJlbnR5ID0gdHJ1ZTtcbiAgICB9IGVsc2Uge1xuICAgICAgc3dpdGNoIChpdGVtLnR5cGUpIHtcbiAgICAgICAgY2FzZSAnY291bnQnOlxuICAgICAgICAgIHJlcy52YWx1ZSA9IGxpc3QubGVuZ3RoO1xuICAgICAgICAgIGJyZWFrO1xuICAgICAgICBjYXNlICdkaXN0aW5jdENvdW50JzpcbiAgICAgICAgICByZXMudmFsdWUgPSB0aGlzLmdldFZhbHVlcyhpbmRleCwgbGlzdCkuZmlsdGVyKFxuICAgICAgICAgICAgKHZhbHVlLCBpZHgsIHNlbGYpID0+IHNlbGYuaW5kZXhPZih2YWx1ZSkgPT09IGlkeCxcbiAgICAgICAgICApLmxlbmd0aDtcbiAgICAgICAgICBicmVhaztcbiAgICAgICAgY2FzZSAnc3VtJzpcbiAgICAgICAgICByZXMudmFsdWUgPSB0aGlzLnRvRml4ZWQodGhpcy5nZXRTdW0oaW5kZXgsIGxpc3QpLCBpdGVtLmRpZ2l0cyk7XG4gICAgICAgICAgY3VycmVudHkgPSB0cnVlO1xuICAgICAgICAgIGJyZWFrO1xuICAgICAgICBjYXNlICdhdmVyYWdlJzpcbiAgICAgICAgICByZXMudmFsdWUgPSB0aGlzLnRvRml4ZWQodGhpcy5nZXRTdW0oaW5kZXgsIGxpc3QpIC8gbGlzdC5sZW5ndGgsIGl0ZW0uZGlnaXRzKTtcbiAgICAgICAgICBjdXJyZW50eSA9IHRydWU7XG4gICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgJ21heCc6XG4gICAgICAgICAgcmVzLnZhbHVlID0gTWF0aC5tYXgoLi4udGhpcy5nZXRWYWx1ZXMoaW5kZXgsIGxpc3QpKTtcbiAgICAgICAgICBjdXJyZW50eSA9IHRydWU7XG4gICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgJ21pbic6XG4gICAgICAgICAgcmVzLnZhbHVlID0gTWF0aC5taW4oLi4udGhpcy5nZXRWYWx1ZXMoaW5kZXgsIGxpc3QpKTtcbiAgICAgICAgICBjdXJyZW50eSA9IHRydWU7XG4gICAgICAgICAgYnJlYWs7XG4gICAgICB9XG4gICAgfVxuICAgIGlmIChpdGVtLmN1cnJlbnR5ID09PSB0cnVlIHx8IChpdGVtLmN1cnJlbnR5ID09IG51bGwgJiYgY3VycmVudHkgPT09IHRydWUpKSB7XG4gICAgICByZXMudGV4dCA9IHRoaXMuY3VycmVudHlQaXBlLnRyYW5zZm9ybShyZXMudmFsdWUpO1xuICAgIH0gZWxzZSB7XG4gICAgICByZXMudGV4dCA9IFN0cmluZyhyZXMudmFsdWUpO1xuICAgIH1cbiAgICByZXR1cm4gcmVzO1xuICB9XG5cbiAgcHJpdmF0ZSB0b0ZpeGVkKHZhbDogbnVtYmVyLCBkaWdpdHM6IG51bWJlcik6IG51bWJlciB7XG4gICAgaWYgKGlzTmFOKHZhbCkgfHwgIWlzRmluaXRlKHZhbCkpIHtcbiAgICAgIHJldHVybiAwO1xuICAgIH1cbiAgICByZXR1cm4gcGFyc2VGbG9hdCh2YWwudG9GaXhlZChkaWdpdHMpKTtcbiAgfVxuXG4gIHByaXZhdGUgZ2V0VmFsdWVzKGluZGV4OiBudW1iZXIsIGxpc3Q6IFNURGF0YVtdKTogbnVtYmVyW10ge1xuICAgIHJldHVybiBsaXN0Lm1hcChpID0+IGkuX3ZhbHVlc1tpbmRleF0ub3JnKS5tYXAoaSA9PiAoaSA9PT0gJycgfHwgaSA9PSBudWxsID8gMCA6IGkpKTtcbiAgfVxuXG4gIHByaXZhdGUgZ2V0U3VtKGluZGV4OiBudW1iZXIsIGxpc3Q6IFNURGF0YVtdKTogbnVtYmVyIHtcbiAgICByZXR1cm4gdGhpcy5nZXRWYWx1ZXMoaW5kZXgsIGxpc3QpLnJlZHVjZSgocCwgaSkgPT4gKHAgKz0gcGFyc2VGbG9hdChTdHJpbmcoaSkpKSwgMCk7XG4gIH1cblxuICAvLyAjZW5kcmVnaW9uXG59XG4iXX0=