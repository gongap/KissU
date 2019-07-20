/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Host, Inject, Injectable, Optional } from '@angular/core';
import { ACLService } from '@delon/acl';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { deepCopy } from '@delon/util';
import { STRowSource } from './table-row.directive';
import { STConfig } from './table.config';
/**
 * @record
 */
export function STSortMap() { }
if (false) {
    /**
     * 是否启用排序
     * @type {?|undefined}
     */
    STSortMap.prototype.enabled;
    /* Skipping unhandled member: [key: string]: any;*/
}
export class STColumnSource {
    /**
     * @param {?} rowSource
     * @param {?} acl
     * @param {?} i18nSrv
     * @param {?} cog
     */
    constructor(rowSource, acl, i18nSrv, cog) {
        this.rowSource = rowSource;
        this.acl = acl;
        this.i18nSrv = i18nSrv;
        this.cog = cog;
    }
    /**
     * @private
     * @param {?} list
     * @return {?}
     */
    btnCoerce(list) {
        if (!list)
            return [];
        /** @type {?} */
        const ret = [];
        const { modal, drawer, popTitle, btnIcon } = this.cog;
        for (const item of list) {
            if (this.acl && item.acl && !this.acl.can(item.acl)) {
                continue;
            }
            if (item.type === 'modal' || item.type === 'static') {
                // compatible
                if (item.component != null) {
                    item.modal = {
                        component: item.component,
                        params: item.params,
                        paramsName: item.paramName || modal.paramsName,
                        size: item.size || modal.size,
                        modalOptions: item.modalOptions || modal.modalOptions,
                    };
                }
                if (item.modal == null || item.modal.component == null) {
                    console.warn(`[st] Should specify modal parameter`);
                    item.type = 'none';
                }
                else {
                    item.modal = Object.assign({ paramsName: 'record', size: 'lg' }, modal, item.modal);
                }
            }
            if (item.type === 'drawer') {
                if (item.drawer == null || item.drawer.component == null) {
                    console.warn(`[st] Should specify drawer parameter`);
                    item.type = 'none';
                }
                else {
                    item.drawer = Object.assign({ paramsName: 'record', size: 'lg' }, drawer, item.drawer);
                }
            }
            if (item.type === 'del' && typeof item.pop === 'undefined') {
                item.pop = true;
            }
            if (item.pop === true) {
                item.popTitle = item.popTitle || popTitle;
            }
            else {
                item.pop = false;
            }
            if (item.icon) {
                item.icon = Object.assign({}, btnIcon, (typeof item.icon === 'string' ? { type: item.icon } : item.icon));
            }
            item.children =
                item.children && item.children.length > 0 ? this.btnCoerce(item.children) : [];
            // i18n
            if (item.i18n && this.i18nSrv) {
                item.text = this.i18nSrv.fanyi(item.i18n);
            }
            ret.push(item);
        }
        this.btnCoerceIf(ret);
        return ret;
    }
    /**
     * @private
     * @param {?} list
     * @return {?}
     */
    btnCoerceIf(list) {
        for (const item of list) {
            if (!item.iif)
                item.iif = (/**
                 * @return {?}
                 */
                () => true);
            if (item.children.length > 0) {
                this.btnCoerceIf(item.children);
            }
        }
    }
    /**
     * @private
     * @param {?} list
     * @return {?}
     */
    fixedCoerce(list) {
        /** @type {?} */
        const countReduce = (/**
         * @param {?} a
         * @param {?} b
         * @return {?}
         */
        (a, b) => a + +b.width.toString().replace('px', ''));
        // left width
        list
            .filter((/**
         * @param {?} w
         * @return {?}
         */
        w => w.fixed && w.fixed === 'left' && w.width))
            .forEach((/**
         * @param {?} item
         * @param {?} idx
         * @return {?}
         */
        (item, idx) => (item._left = list.slice(0, idx).reduce(countReduce, 0) + 'px')));
        // right width
        list
            .filter((/**
         * @param {?} w
         * @return {?}
         */
        w => w.fixed && w.fixed === 'right' && w.width))
            .reverse()
            .forEach((/**
         * @param {?} item
         * @param {?} idx
         * @return {?}
         */
        (item, idx) => (item._right = (idx > 0 ? list.slice(-idx).reduce(countReduce, 0) : 0) + 'px')));
    }
    /**
     * @private
     * @param {?} item
     * @return {?}
     */
    sortCoerce(item) {
        // compatible
        if (item.sorter && typeof item.sorter === 'function') {
            return {
                enabled: true,
                default: (/** @type {?} */ (item.sort)),
                compare: item.sorter,
                key: item.sortKey || item.indexKey,
                reName: item.sortReName,
            };
        }
        if (typeof item.sort === 'undefined') {
            return { enabled: false };
        }
        /** @type {?} */
        let res = {};
        if (typeof item.sort === 'string') {
            res.key = item.sort;
        }
        else if (typeof item.sort !== 'boolean') {
            res = item.sort;
        }
        if (!res.key) {
            res.key = item.indexKey;
        }
        res.enabled = true;
        return res;
    }
    /**
     * @private
     * @param {?} item
     * @return {?}
     */
    filterCoerce(item) {
        /** @type {?} */
        let res = null;
        // compatible
        if (item.filters && item.filters.length > 0) {
            res = {
                confirmText: item.filterConfirmText,
                clearText: item.filterClearText,
                default: item.filtered,
                fn: (/** @type {?} */ (item.filter)),
                icon: item.filterIcon,
                key: item.filterKey || item.indexKey,
                menus: item.filters,
                multiple: item.filterMultiple,
                reName: item.filterReName,
            };
        }
        else {
            res = item.filter;
        }
        if (res == null || res.menus.length === 0) {
            return null;
        }
        if (typeof res.multiple === 'undefined') {
            res.multiple = true;
        }
        if (!res.confirmText) {
            res.confirmText = this.cog.filterConfirmText;
        }
        if (!res.clearText) {
            res.clearText = this.cog.filterClearText;
        }
        if (!res.icon) {
            res.icon = `filter`;
        }
        if (!res.key) {
            res.key = item.indexKey;
        }
        res.default = res.menus.findIndex((/**
         * @param {?} w
         * @return {?}
         */
        w => w.checked)) !== -1;
        if (this.acl) {
            res.menus = res.menus.filter((/**
             * @param {?} w
             * @return {?}
             */
            w => this.acl.can(w.acl)));
        }
        if (res.menus.length <= 0) {
            res = null;
        }
        return res;
    }
    /**
     * @private
     * @param {?} item
     * @return {?}
     */
    restoreRender(item) {
        if (item.renderTitle) {
            item.__renderTitle = this.rowSource.getTitle(item.renderTitle);
        }
        if (item.render) {
            item.__render = this.rowSource.getRow(item.render);
        }
    }
    /**
     * @param {?} list
     * @return {?}
     */
    process(list) {
        if (!list || list.length === 0)
            throw new Error(`[st]: the columns property muse be define!`);
        const { noIndex } = this.cog;
        /** @type {?} */
        let checkboxCount = 0;
        /** @type {?} */
        let radioCount = 0;
        /** @type {?} */
        let point = 0;
        /** @type {?} */
        const columns = [];
        /** @type {?} */
        const copyColumens = (/** @type {?} */ (deepCopy(list)));
        for (const item of copyColumens) {
            if (item.iif && !item.iif(item)) {
                continue;
            }
            if (this.acl && item.acl && !this.acl.can(item.acl)) {
                continue;
            }
            // index
            if (item.index) {
                if (!Array.isArray(item.index)) {
                    item.index = item.index.split('.');
                }
                item.indexKey = item.index.join('.');
            }
            // title
            if (item.i18n && this.i18nSrv) {
                item.title = this.i18nSrv.fanyi(item.i18n);
            }
            // no
            if (item.type === 'no') {
                item.noIndex = item.noIndex == null ? noIndex : item.noIndex;
            }
            // checkbox
            if (item.selections == null) {
                item.selections = [];
            }
            if (item.type === 'checkbox') {
                ++checkboxCount;
                if (!item.width) {
                    item.width = `${item.selections.length > 0 ? 62 : 50}px`;
                }
            }
            if (this.acl) {
                item.selections = item.selections.filter((/**
                 * @param {?} w
                 * @return {?}
                 */
                w => this.acl.can(w.acl)));
            }
            // radio
            if (item.type === 'radio') {
                ++radioCount;
                item.selections = [];
                if (!item.width) {
                    item.width = '50px';
                }
            }
            // types
            if (item.type === 'yn') {
                item.yn = Object.assign({ truth: true }, item.yn);
                // compatible
                if (item.ynTruth != null)
                    item.yn.truth = item.ynTruth;
                if (item.ynYes != null)
                    item.yn.yes = item.ynYes;
                if (item.ynNo != null)
                    item.yn.no = item.ynNo;
            }
            if ((item.type === 'link' && typeof item.click !== 'function') ||
                (item.type === 'badge' && item.badge == null) ||
                (item.type === 'tag' && item.tag == null)) {
                ((/** @type {?} */ (item))).type = '';
            }
            // className
            if (!item.className) {
                item.className = {
                    number: 'text-right',
                    currency: 'text-right',
                    date: 'text-center',
                }[item.type];
            }
            // width
            if (typeof item.width === 'number') {
                item.width = `${item.width}px`;
            }
            // sorter
            item._sort = this.sortCoerce(item);
            // filter
            item.filter = this.filterCoerce(item);
            // buttons
            item.buttons = this.btnCoerce(item.buttons);
            // restore custom row
            this.restoreRender(item);
            item.__point = point++;
            columns.push(item);
        }
        if (checkboxCount > 1) {
            throw new Error(`[st]: just only one column checkbox`);
        }
        if (radioCount > 1) {
            throw new Error(`[st]: just only one column radio`);
        }
        this.fixedCoerce(columns);
        return columns;
    }
    /**
     * @param {?} columns
     * @return {?}
     */
    restoreAllRender(columns) {
        columns.forEach((/**
         * @param {?} i
         * @return {?}
         */
        i => this.restoreRender(i)));
    }
}
STColumnSource.decorators = [
    { type: Injectable }
];
/** @nocollapse */
STColumnSource.ctorParameters = () => [
    { type: STRowSource, decorators: [{ type: Host }] },
    { type: ACLService, decorators: [{ type: Optional }] },
    { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [ALAIN_I18N_TOKEN,] }] },
    { type: STConfig }
];
if (false) {
    /**
     * @type {?}
     * @private
     */
    STColumnSource.prototype.rowSource;
    /**
     * @type {?}
     * @private
     */
    STColumnSource.prototype.acl;
    /**
     * @type {?}
     * @private
     */
    STColumnSource.prototype.i18nSrv;
    /**
     * @type {?}
     * @private
     */
    STColumnSource.prototype.cog;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidGFibGUtY29sdW1uLXNvdXJjZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi9hYmMvdGFibGUvIiwic291cmNlcyI6WyJ0YWJsZS1jb2x1bW4tc291cmNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsSUFBSSxFQUFFLE1BQU0sRUFBRSxVQUFVLEVBQUUsUUFBUSxFQUFFLE1BQU0sZUFBZSxDQUFDO0FBQ25FLE9BQU8sRUFBRSxVQUFVLEVBQUUsTUFBTSxZQUFZLENBQUM7QUFDeEMsT0FBTyxFQUFvQixnQkFBZ0IsRUFBRSxNQUFNLGNBQWMsQ0FBQztBQUNsRSxPQUFPLEVBQUUsUUFBUSxFQUFFLE1BQU0sYUFBYSxDQUFDO0FBRXZDLE9BQU8sRUFBRSxXQUFXLEVBQUUsTUFBTSx1QkFBdUIsQ0FBQztBQUNwRCxPQUFPLEVBQUUsUUFBUSxFQUFFLE1BQU0sZ0JBQWdCLENBQUM7Ozs7QUFHMUMsK0JBS0M7Ozs7OztJQURDLDRCQUFrQjs7O0FBSXBCLE1BQU0sT0FBTyxjQUFjOzs7Ozs7O0lBQ3pCLFlBQ2tCLFNBQXNCLEVBQ2xCLEdBQWUsRUFDVyxPQUF5QixFQUMvRCxHQUFhO1FBSEwsY0FBUyxHQUFULFNBQVMsQ0FBYTtRQUNsQixRQUFHLEdBQUgsR0FBRyxDQUFZO1FBQ1csWUFBTyxHQUFQLE9BQU8sQ0FBa0I7UUFDL0QsUUFBRyxHQUFILEdBQUcsQ0FBVTtJQUNwQixDQUFDOzs7Ozs7SUFFSSxTQUFTLENBQUMsSUFBc0I7UUFDdEMsSUFBSSxDQUFDLElBQUk7WUFBRSxPQUFPLEVBQUUsQ0FBQzs7Y0FDZixHQUFHLEdBQXFCLEVBQUU7Y0FDMUIsRUFBRSxLQUFLLEVBQUUsTUFBTSxFQUFFLFFBQVEsRUFBRSxPQUFPLEVBQUUsR0FBRyxJQUFJLENBQUMsR0FBRztRQUVyRCxLQUFLLE1BQU0sSUFBSSxJQUFJLElBQUksRUFBRTtZQUN2QixJQUFJLElBQUksQ0FBQyxHQUFHLElBQUksSUFBSSxDQUFDLEdBQUcsSUFB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LE9BQU8sQ0FBQyxDQUFDO1FBRTFCLE9BQU8sT0FBTyxDQUFDO0lBQ2pCLENBQUM7Ozs7O0lBRUQsZ0JBQWdCLENBQUMsT0FBbUI7UUFDbEMsT0FBTyxDQUFDLE9BQU87Ozs7UUFBQyxDQUFDLENBQUMsRUFBRSxDQUFDLElBQUksQ0FBQyxhQUFhLENBQUMsQ0FBQyxDQUFDLEVBQUMsQ0FBQztJQUM5QyxDQUFDOzs7WUEvU0YsVUFBVTs7OztZQVhGLFdBQVcsdUJBY2YsSUFBSTtZQWxCQSxVQUFVLHVCQW1CZCxRQUFROzRDQUNSLFFBQVEsWUFBSSxNQUFNLFNBQUMsZ0JBQWdCO1lBZi9CLFFBQVE7Ozs7Ozs7SUFhYixtQ0FBc0M7Ozs7O0lBQ3RDLDZCQUFtQzs7Ozs7SUFDbkMsaUNBQXVFOzs7OztJQUN2RSw2QkFBcUIiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBIb3N0LCBJbmplY3QsIEluamVjdGFibGUsIE9wdGlvbmFsIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBBQ0xTZXJ2aWNlIH0gZnJvbSAnQGRlbG9uL2FjbCc7XG5pbXBvcnQgeyBBbGFpbkkxOE5TZXJ2aWNlLCBBTEFJTl9JMThOX1RPS0VOIH0gZnJvbSAnQGRlbG9uL3RoZW1lJztcbmltcG9ydCB7IGRlZXBDb3B5IH0gZnJvbSAnQGRlbG9uL3V0aWwnO1xuXG5pbXBvcnQgeyBTVFJvd1NvdXJjZSB9IGZyb20gJy4vdGFibGUtcm93LmRpcmVjdGl2ZSc7XG5pbXBvcnQgeyBTVENvbmZpZyB9IGZyb20gJy4vdGFibGUuY29uZmlnJztcbmltcG9ydCB7IFNUQ29sdW1uLCBTVENvbHVtbkJ1dHRvbiwgU1RDb2x1bW5GaWx0ZXIsIFNUQ29sdW1uU29ydCB9IGZyb20gJy4vdGFibGUuaW50ZXJmYWNlcyc7XG5cbmV4cG9ydCBpbnRlcmZhY2UgU1RTb3J0TWFwIGV4dGVuZHMgU1RDb2x1bW5Tb3J0IHtcbiAgW2tleTogc3RyaW5nXTogYW55O1xuXG4gIC8qKiDmmK/lkKblkK/nlKjmjpLluo8gKi9cbiAgZW5hYmxlZD86IGJvb2xlYW47XG59XG5cbkBJbmplY3RhYmxlKClcbmV4cG9ydCBjbGFzcyBTVENvbHVtblNvdXJjZSB7XG4gIGNvbnN0cnVjdG9yKFxuICAgIEBIb3N0KCkgcHJpdmF0ZSByb3dTb3VyY2U6IFNUUm93U291cmNlLFxuICAgIEBPcHRpb25hbCgpIHByaXZhdGUgYWNsOiBBQ0xTZXJ2aWNlLFxuICAgIEBPcHRpb25hbCgpIEBJbmplY3QoQUxBSU5fSTE4Tl9UT0tFTikgcHJpdmF0ZSBpMThuU3J2OiBBbGFpbkkxOE5TZXJ2aWNlLFxuICAgIHByaXZhdGUgY29nOiBTVENvbmZpZyxcbiAgKSB7fVxuXG4gIHByaXZhdGUgYnRuQ29lcmNlKGxpc3Q6IFNUQ29sdW1uQnV0dG9uW10pOiBTVENvbHVtbkJ1dHRvbltdIHtcbiAgICBpZiAoIWxpc3QpIHJldHVybiBbXTtcbiAgICBjb25zdCByZXQ6IFNUQ29sdW1uQnV0dG9uW10gPSBbXTtcbiAgICBjb25zdCB7IG1vZGFsLCBkcmF3ZXIsIHBvcFRpdGxlLCBidG5JY29uIH0gPSB0aGlzLmNvZztcblxuICAgIGZvciAoY29uc3QgaXRlbSBvZiBsaXN0KSB7XG4gICAgICBpZiAodGhpcy5hY2wgJiYgaXRlbS5hY2wgJiYgIXRoaXMuYWNsLmNhbihpdGVtLmFjbCkpIHtcbiAgICAgICAgY29udGludWU7XG4gICAgICB9XG5cbiAgICAgIGlmIChpdGVtLnR5cGUgPT09ICdtb2RhbCcgfHwgaXRlbS50eXBlID09PSAnc3RhdGljJykge1xuICAgICAgICAvLyBjb21wYXRpYmxlXG4gICAgICAgIGlmIChpdGVtLmNvbXBvbmVudCAhPSBudWxsKSB7XG4gICAgICAgICAgaXRlbS5tb2RhbCA9IHtcbiAgICAgICAgICAgIGNvbXBvbmVudDogaXRlbS5jb21wb25lbnQsXG4gICAgICAgICAgICBwYXJhbXM6IGl0ZW0ucGFyYW1zLFxuICAgICAgICAgICAgcGFyYW1zTmFtZTogaXRlbS5wYXJhbU5hbWUgfHwgbW9kYWwucGFyYW1zTmFtZSxcbiAgICAgICAgICAgIHNpemU6IGl0ZW0uc2l6ZSB8fCBtb2RhbC5zaXplLFxuICAgICAgICAgICAgbW9kYWxPcHRpb25zOiBpdGVtLm1vZGFsT3B0aW9ucyB8fCBtb2RhbC5tb2RhbE9wdGlvbnMsXG4gICAgICAgICAgfTtcbiAgICAgICAgfVxuICAgICAgICBpZiAoaXRlbS5tb2RhbCA9PSBudWxsIHx8IGl0ZW0ubW9kYWwuY29tcG9uZW50ID09IG51bGwpIHtcbiAgICAgICAgICBjb25zb2xlLndhcm4oYFtzdF0gU2hvdWxkIHNwZWNpZnkgbW9kYWwgcGFyYW1ldGVyYCk7XG4gICAgICAgICAgaXRlbS50eXBlID0gJ25vbmUnO1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgIGl0ZW0ubW9kYWwgPSB7IC4uLnsgcGFyYW1zTmFtZTogJ3JlY29yZCcsIHNpemU6ICdsZycgfSwgLi4ubW9kYWwsIC4uLml0ZW0ubW9kYWwgfTtcbiAgICAgICAgfVxuICAgICAgfVxuXG4gICAgICBpZiAoaXRlbS50eXBlID09PSAnZHJhd2VyJykge1xuICAgICAgICBpZiAoaXRlbS5kcmF3ZXIgPT0gbnVsbCB8fCBpdGVtLmRyYXdlci5jb21wb25lbnQgPT0gbnVsbCkge1xuICAgICAgICAgIGNvbnNvbGUud2FybihgW3N0XSBTaG91bGQgc3BlY2lmeSBkcmF3ZXIgcGFyYW1ldGVyYCk7XG4gICAgICAgICAgaXRlbS50eXBlID0gJ25vbmUnO1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgIGl0ZW0uZHJhd2VyID0geyAuLi57IHBhcmFtc05hbWU6ICdyZWNvcmQnLCBzaXplOiAnbGcnIH0sIC4uLmRyYXdlciwgLi4uaXRlbS5kcmF3ZXIgfTtcbiAgICAgICAgfVxuICAgICAgfVxuXG4gICAgICBpZiAoaXRlbS50eXBlID09PSAnZGVsJyAmJiB0eXBlb2YgaXRlbS5wb3AgPT09ICd1bmRlZmluZWQnKSB7XG4gICAgICAgIGl0ZW0ucG9wID0gdHJ1ZTtcbiAgICAgIH1cblxuICAgICAgaWYgKGl0ZW0ucG9wID09PSB0cnVlKSB7XG4gICAgICAgIGl0ZW0ucG9wVGl0bGUgPSBpdGVtLnBvcFRpdGxlIHx8IHBvcFRpdGxlO1xuICAgICAgfSBlbHNlIHtcbiAgICAgICAgaXRlbS5wb3AgPSBmYWxzZTtcbiAgICAgIH1cblxuICAgICAgaWYgKGl0ZW0uaWNvbikge1xuICAgICAgICBpdGVtLmljb24gPSB7XG4gICAgICAgICAgLi4uYnRuSWNvbixcbiAgICAgICAgICAuLi4odHlwZW9mIGl0ZW0uaWNvbiA9PT0gJ3N0cmluZycgPyB7IHR5cGU6IGl0ZW0uaWNvbiB9IDogaXRlbS5pY29uKSxcbiAgICAgICAgfTtcbiAgICAgIH1cblxuICAgICAgaXRlbS5jaGlsZHJlbiA9XG4gICAgICAgIGl0ZW0uY2hpbGRyZW4gJiYgaXRlbS5jaGlsZHJlbi5sZW5ndGggPiAwID8gdGhpcy5idG5Db2VyY2UoaXRlbS5jaGlsZHJlbikgOiBbXTtcblxuICAgICAgLy8gaTE4blxuICAgICAgaWYgKGl0ZW0uaTE4biAmJiB0aGlzLmkxOG5TcnYpIHtcbiAgICAgICAgaXRlbS50ZXh0ID0gdGhpcy5pMThuU3J2LmZhbnlpKGl0ZW0uaTE4bik7XG4gICAgICB9XG5cbiAgICAgIHJldC5wdXNoKGl0ZW0pO1xuICAgIH1cbiAgICB0aGlzLmJ0bkNvZXJjZUlmKHJldCk7XG4gICAgcmV0dXJuIHJldDtcbiAgfVxuXG4gIHByaXZhdGUgYnRuQ29lcmNlSWYobGlzdDogU1RDb2x1bW5CdXR0b25bXSkge1xuICAgIGZvciAoY29uc3QgaXRlbSBvZiBsaXN0KSB7XG4gICAgICBpZiAoIWl0ZW0uaWlmKSBpdGVtLmlpZiA9ICgpID0+IHRydWU7XG4gICAgICBpZiAoaXRlbS5jaGlsZHJlbi5sZW5ndGggPiAwKSB7XG4gICAgICAgIHRoaXMuYnRuQ29lcmNlSWYoaXRlbS5jaGlsZHJlbik7XG4gICAgICB9XG4gICAgfVxuICB9XG5cbiAgcHJpdmF0ZSBmaXhlZENvZXJjZShsaXN0OiBTVENvbHVtbltdKSB7XG4gICAgY29uc3QgY291bnRSZWR1Y2UgPSAoYTogbnVtYmVyLCBiOiBTVENvbHVtbikgPT4gYSArICtiLndpZHRoLnRvU3RyaW5nKCkucmVwbGFjZSgncHgnLCAnJyk7XG4gICAgLy8gbGVmdCB3aWR0aFxuICAgIGxpc3RcbiAgICAgIC5maWx0ZXIodyA9PiB3LmZpeGVkICYmIHcuZml4ZWQgPT09ICdsZWZ0JyAmJiB3LndpZHRoKVxuICAgICAgLmZvckVhY2goKGl0ZW0sIGlkeCkgPT4gKGl0ZW0uX2xlZnQgPSBsaXN0LnNsaWNlKDAsIGlkeCkucmVkdWNlKGNvdW50UmVkdWNlLCAwKSArICdweCcpKTtcbiAgICAvLyByaWdodCB3aWR0aFxuICAgIGxpc3RcbiAgICAgIC5maWx0ZXIodyA9PiB3LmZpeGVkICYmIHcuZml4ZWQgPT09ICdyaWdodCcgJiYgdy53aWR0aClcbiAgICAgIC5yZXZlcnNlKClcbiAgICAgIC5mb3JFYWNoKFxuICAgICAgICAoaXRlbSwgaWR4KSA9PlxuICAgICAgICAgIChpdGVtLl9yaWdodCA9IChpZHggPiAwID8gbGlzdC5zbGljZSgtaWR4KS5yZWR1Y2UoY291bnRSZWR1Y2UsIDApIDogMCkgKyAncHgnKSxcbiAgICAgICk7XG4gIH1cblxuICBwcml2YXRlIHNvcnRDb2VyY2UoaXRlbTogU1RDb2x1bW4pOiBTVFNvcnRNYXAge1xuICAgIC8vIGNvbXBhdGlibGVcbiAgICBpZiAoaXRlbS5zb3J0ZXIgJiYgdHlwZW9mIGl0ZW0uc29ydGVyID09PSAnZnVuY3Rpb24nKSB7XG4gICAgICByZXR1cm4ge1xuICAgICAgICBlbmFibGVkOiB0cnVlLFxuICAgICAgICBkZWZhdWx0OiBpdGVtLnNvcnQgYXMgYW55LFxuICAgICAgICBjb21wYXJlOiBpdGVtLnNvcnRlcixcbiAgICAgICAga2V5OiBpdGVtLnNvcnRLZXkgfHwgaXRlbS5pbmRleEtleSxcbiAgICAgICAgcmVOYW1lOiBpdGVtLnNvcnRSZU5hbWUsXG4gICAgICB9O1xuICAgIH1cblxuICAgIGlmICh0eXBlb2YgaXRlbS5zb3J0ID09PSAndW5kZWZpbmVkJykge1xuICAgICAgcmV0dXJuIHsgZW5hYmxlZDogZmFsc2UgfTtcbiAgICB9XG5cbiAgICBsZXQgcmVzOiBTVFNvcnRNYXAgPSB7fTtcblxuICAgIGlmICh0eXBlb2YgaXRlbS5zb3J0ID09PSAnc3RyaW5nJykge1xuICAgICAgcmVzLmtleSA9IGl0ZW0uc29ydDtcbiAgICB9IGVsc2UgaWYgKHR5cGVvZiBpdGVtLnNvcnQgIT09ICdib29sZWFuJykge1xuICAgICAgcmVzID0gaXRlbS5zb3J0O1xuICAgIH1cblxuICAgIGlmICghcmVzLmtleSkge1xuICAgICAgcmVzLmtleSA9IGl0ZW0uaW5kZXhLZXk7XG4gICAgfVxuXG4gICAgcmVzLmVuYWJsZWQgPSB0cnVlO1xuXG4gICAgcmV0dXJuIHJlcztcbiAgfVxuXG4gIHByaXZhdGUgZmlsdGVyQ29lcmNlKGl0ZW06IFNUQ29sdW1uKTogU1RDb2x1bW5GaWx0ZXIge1xuICAgIGxldCByZXM6IFNUQ29sdW1uRmlsdGVyID0gbnVsbDtcbiAgICAvLyBjb21wYXRpYmxlXG4gICAgaWYgKGl0ZW0uZmlsdGVycyAmJiBpdGVtLmZpbHRlcnMubGVuZ3RoID4gMCkge1xuICAgICAgcmVzID0ge1xuICAgICAgICBjb25maXJtVGV4dDogaXRlbS5maWx0ZXJDb25maXJtVGV4dCxcbiAgICAgICAgY2xlYXJUZXh0OiBpdGVtLmZpbHRlckNsZWFyVGV4dCxcbiAgICAgICAgZGVmYXVsdDogaXRlbS5maWx0ZXJlZCxcbiAgICAgICAgZm46IGl0ZW0uZmlsdGVyIGFzIGFueSxcbiAgICAgICAgaWNvbjogaXRlbS5maWx0ZXJJY29uLFxuICAgICAgICBrZXk6IGl0ZW0uZmlsdGVyS2V5IHx8IGl0ZW0uaW5kZXhLZXksXG4gICAgICAgIG1lbnVzOiBpdGVtLmZpbHRlcnMsXG4gICAgICAgIG11bHRpcGxlOiBpdGVtLmZpbHRlck11bHRpcGxlLFxuICAgICAgICByZU5hbWU6IGl0ZW0uZmlsdGVyUmVOYW1lLFxuICAgICAgfTtcbiAgICB9IGVsc2Uge1xuICAgICAgcmVzID0gaXRlbS5maWx0ZXI7XG4gICAgfVxuXG4gICAgaWYgKHJlcyA9PSBudWxsIHx8IHJlcy5tZW51cy5sZW5ndGggPT09IDApIHtcbiAgICAgIHJldHVybiBudWxsO1xuICAgIH1cblxuICAgIGlmICh0eXBlb2YgcmVzLm11bHRpcGxlID09PSAndW5kZWZpbmVkJykge1xuICAgICAgcmVzLm11bHRpcGxlID0gdHJ1ZTtcbiAgICB9XG4gICAgaWYgKCFyZXMuY29uZmlybVRleHQpIHtcbiAgICAgIHJlcy5jb25maXJtVGV4dCA9IHRoaXMuY29nLmZpbHRlckNvbmZpcm1UZXh0O1xuICAgIH1cbiAgICBpZiAoIXJlcy5jbGVhclRleHQpIHtcbiAgICAgIHJlcy5jbGVhclRleHQgPSB0aGlzLmNvZy5maWx0ZXJDbGVhclRleHQ7XG4gICAgfVxuICAgIGlmICghcmVzLmljb24pIHtcbiAgICAgIHJlcy5pY29uID0gYGZpbHRlcmA7XG4gICAgfVxuICAgIGlmICghcmVzLmtleSkge1xuICAgICAgcmVzLmtleSA9IGl0ZW0uaW5kZXhLZXk7XG4gICAgfVxuXG4gICAgcmVzLmRlZmF1bHQgPSByZXMubWVudXMuZmluZEluZGV4KHcgPT4gdy5jaGVja2VkKSAhPT0gLTE7XG5cbiAgICBpZiAodGhpcy5hY2wpIHtcbiAgICAgIHJlcy5tZW51cyA9IHJlcy5tZW51cy5maWx0ZXIodyA9PiB0aGlzLmFjbC5jYW4ody5hY2wpKTtcbiAgICB9XG5cbiAgICBpZiAocmVzLm1lbnVzLmxlbmd0aCA8PSAwKSB7XG4gICAgICByZXMgPSBudWxsO1xuICAgIH1cblxuICAgIHJldHVybiByZXM7XG4gIH1cblxuICBwcml2YXRlIHJlc3RvcmVSZW5kZXIoaXRlbTogU1RDb2x1bW4pIHtcbiAgICBpZiAoaXRlbS5yZW5kZXJUaXRsZSkge1xuICAgICAgaXRlbS5fX3JlbmRlclRpdGxlID0gdGhpcy5yb3dTb3VyY2UuZ2V0VGl0bGUoaXRlbS5yZW5kZXJUaXRsZSk7XG4gICAgfVxuICAgIGlmIChpdGVtLnJlbmRlcikge1xuICAgICAgaXRlbS5fX3JlbmRlciA9IHRoaXMucm93U291cmNlLmdldFJvdyhpdGVtLnJlbmRlcik7XG4gICAgfVxuICB9XG5cbiAgcHJvY2VzcyhsaXN0OiBTVENvbHVtbltdKTogU1RDb2x1bW5bXSB7XG4gICAgaWYgKCFsaXN0IHx8IGxpc3QubGVuZ3RoID09PSAwKSB0aHJvdyBuZXcgRXJyb3IoYFtzdF06IHRoZSBjb2x1bW5zIHByb3BlcnR5IG11c2UgYmUgZGVmaW5lIWApO1xuXG4gICAgY29uc3QgeyBub0luZGV4IH0gPSB0aGlzLmNvZztcbiAgICBsZXQgY2hlY2tib3hDb3VudCA9IDA7XG4gICAgbGV0IHJhZGlvQ291bnQgPSAwO1xuICAgIGxldCBwb2ludCA9IDA7XG4gICAgY29uc3QgY29sdW1uczogU1RDb2x1bW5bXSA9IFtdO1xuICAgIGNvbnN0IGNvcHlDb2x1bWVucyA9IGRlZXBDb3B5KGxpc3QpIGFzIFNUQ29sdW1uW107XG4gICAgZm9yIChjb25zdCBpdGVtIG9mIGNvcHlDb2x1bWVucykge1xuICAgICAgaWYgKGl0ZW0uaWlmICYmICFpdGVtLmlpZihpdGVtKSkge1xuICAgICAgICBjb250aW51ZTtcbiAgICAgIH1cbiAgICAgIGlmICh0aGlzLmFjbCAmJiBpdGVtLmFjbCAmJiAhdGhpcy5hY2wuY2FuKGl0ZW0uYWNsKSkge1xuICAgICAgICBjb250aW51ZTtcbiAgICAgIH1cbiAgICAgIC8vIGluZGV4XG4gICAgICBpZiAoaXRlbS5pbmRleCkge1xuICAgICAgICBpZiAoIUFycmF5LmlzQXJyYXkoaXRlbS5pbmRleCkpIHtcbiAgICAgICAgICBpdGVtLmluZGV4ID0gaXRlbS5pbmRleC5zcGxpdCgnLicpO1xuICAgICAgICB9XG4gICAgICAgIGl0ZW0uaW5kZXhLZXkgPSBpdGVtLmluZGV4LmpvaW4oJy4nKTtcbiAgICAgIH1cbiAgICAgIC8vIHRpdGxlXG4gICAgICBpZiAoaXRlbS5pMThuICYmIHRoaXMuaTE4blNydikge1xuICAgICAgICBpdGVtLnRpdGxlID0gdGhpcy5pMThuU3J2LmZhbnlpKGl0ZW0uaTE4bik7XG4gICAgICB9XG4gICAgICAvLyBub1xuICAgICAgaWYgKGl0ZW0udHlwZSA9PT0gJ25vJykge1xuICAgICAgICBpdGVtLm5vSW5kZXggPSBpdGVtLm5vSW5kZXggPT0gbnVsbCA/IG5vSW5kZXggOiBpdGVtLm5vSW5kZXg7XG4gICAgICB9XG4gICAgICAvLyBjaGVja2JveFxuICAgICAgaWYgKGl0ZW0uc2VsZWN0aW9ucyA9PSBudWxsKSB7XG4gICAgICAgIGl0ZW0uc2VsZWN0aW9ucyA9IFtdO1xuICAgICAgfVxuICAgICAgaWYgKGl0ZW0udHlwZSA9PT0gJ2NoZWNrYm94Jykge1xuICAgICAgICArK2NoZWNrYm94Q291bnQ7XG4gICAgICAgIGlmICghaXRlbS53aWR0aCkge1xuICAgICAgICAgIGl0ZW0ud2lkdGggPSBgJHtpdGVtLnNlbGVjdGlvbnMubGVuZ3RoID4gMCA/IDYyIDogNTB9cHhgO1xuICAgICAgICB9XG4gICAgICB9XG4gICAgICBpZiAodGhpcy5hY2wpIHtcbiAgICAgICAgaXRlbS5zZWxlY3Rpb25zID0gaXRlbS5zZWxlY3Rpb25zLmZpbHRlcih3ID0+IHRoaXMuYWNsLmNhbih3LmFjbCkpO1xuICAgICAgfVxuICAgICAgLy8gcmFkaW9cbiAgICAgIGlmIChpdGVtLnR5cGUgPT09ICdyYWRpbycpIHtcbiAgICAgICAgKytyYWRpb0NvdW50O1xuICAgICAgICBpdGVtLnNlbGVjdGlvbnMgPSBbXTtcbiAgICAgICAgaWYgKCFpdGVtLndpZHRoKSB7XG4gICAgICAgICAgaXRlbS53aWR0aCA9ICc1MHB4JztcbiAgICAgICAgfVxuICAgICAgfVxuICAgICAgLy8gdHlwZXNcbiAgICAgIGlmIChpdGVtLnR5cGUgPT09ICd5bicpIHtcbiAgICAgICAgaXRlbS55biA9IHsgdHJ1dGg6IHRydWUsIC4uLml0ZW0ueW4gfTtcbiAgICAgICAgLy8gY29tcGF0aWJsZVxuICAgICAgICBpZiAoaXRlbS55blRydXRoICE9IG51bGwpIGl0ZW0ueW4udHJ1dGggPSBpdGVtLnluVHJ1dGg7XG4gICAgICAgIGlmIChpdGVtLnluWWVzICE9IG51bGwpIGl0ZW0ueW4ueWVzID0gaXRlbS55blllcztcbiAgICAgICAgaWYgKGl0ZW0ueW5ObyAhPSBudWxsKSBpdGVtLnluLm5vID0gaXRlbS55bk5vO1xuICAgICAgfVxuICAgICAgaWYgKFxuICAgICAgICAoaXRlbS50eXBlID09PSAnbGluaycgJiYgdHlwZW9mIGl0ZW0uY2xpY2sgIT09ICdmdW5jdGlvbicpIHx8XG4gICAgICAgIChpdGVtLnR5cGUgPT09ICdiYWRnZScgJiYgaXRlbS5iYWRnZSA9PSBudWxsKSB8fFxuICAgICAgICAoaXRlbS50eXBlID09PSAndGFnJyAmJiBpdGVtLnRhZyA9PSBudWxsKVxuICAgICAgKSB7XG4gICAgICAgIChpdGVtIGFzIGFueSkudHlwZSA9ICcnO1xuICAgICAgfVxuICAgICAgLy8gY2xhc3NOYW1lXG4gICAgICBpZiAoIWl0ZW0uY2xhc3NOYW1lKSB7XG4gICAgICAgIGl0ZW0uY2xhc3NOYW1lID0ge1xuICAgICAgICAgIG51bWJlcjogJ3RleHQtcmlnaHQnLFxuICAgICAgICAgIGN1cnJlbmN5OiAndGV4dC1yaWdodCcsXG4gICAgICAgICAgZGF0ZTogJ3RleHQtY2VudGVyJyxcbiAgICAgICAgfVtpdGVtLnR5cGVdO1xuICAgICAgfVxuICAgICAgLy8gd2lkdGhcbiAgICAgIGlmICh0eXBlb2YgaXRlbS53aWR0aCA9PT0gJ251bWJlcicpIHtcbiAgICAgICAgaXRlbS53aWR0aCA9IGAke2l0ZW0ud2lkdGh9cHhgO1xuICAgICAgfVxuXG4gICAgICAvLyBzb3J0ZXJcbiAgICAgIGl0ZW0uX3NvcnQgPSB0aGlzLnNvcnRDb2VyY2UoaXRlbSk7XG4gICAgICAvLyBmaWx0ZXJcbiAgICAgIGl0ZW0uZmlsdGVyID0gdGhpcy5maWx0ZXJDb2VyY2UoaXRlbSk7XG4gICAgICAvLyBidXR0b25zXG4gICAgICBpdGVtLmJ1dHRvbnMgPSB0aGlzLmJ0bkNvZXJjZShpdGVtLmJ1dHRvbnMpO1xuICAgICAgLy8gcmVzdG9yZSBjdXN0b20gcm93XG4gICAgICB0aGlzLnJlc3RvcmVSZW5kZXIoaXRlbSk7XG5cbiAgICAgIGl0ZW0uX19wb2ludCA9IHBvaW50Kys7XG4gICAgICBjb2x1bW5zLnB1c2goaXRlbSk7XG4gICAgfVxuICAgIGlmIChjaGVja2JveENvdW50ID4gMSkge1xuICAgICAgdGhyb3cgbmV3IEVycm9yKGBbc3RdOiBqdXN0IG9ubHkgb25lIGNvbHVtbiBjaGVja2JveGApO1xuICAgIH1cbiAgICBpZiAocmFkaW9Db3VudCA+IDEpIHtcbiAgICAgIHRocm93IG5ldyBFcnJvcihgW3N0XToganVzdCBvbmx5IG9uZSBjb2x1bW4gcmFkaW9gKTtcbiAgICB9XG5cbiAgICB0aGlzLmZpeGVkQ29lcmNlKGNvbHVtbnMpO1xuXG4gICAgcmV0dXJuIGNvbHVtbnM7XG4gIH1cblxuICByZXN0b3JlQWxsUmVuZGVyKGNvbHVtbnM6IFNUQ29sdW1uW10pIHtcbiAgICBjb2x1bW5zLmZvckVhY2goaSA9PiB0aGlzLnJlc3RvcmVSZW5kZXIoaSkpO1xuICB9XG59XG4iXX0=