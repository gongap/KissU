/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { DOCUMENT } from '@angular/common';
import { Inject, Injectable, Injector, Optional } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { ALAIN_I18N_TOKEN } from '../i18n/i18n';
import { MenuService } from '../menu/menu.service';
import * as i0 from "@angular/core";
import * as i1 from "@angular/platform-browser";
import * as i2 from "../menu/menu.service";
import * as i3 from "../i18n/i18n";
import * as i4 from "@angular/common";
var TitleService = /** @class */ (function () {
    function TitleService(injector, title, menuSrv, i18nSrv, doc) {
        var _this = this;
        this.injector = injector;
        this.title = title;
        this.menuSrv = menuSrv;
        this.i18nSrv = i18nSrv;
        this.doc = doc;
        this._prefix = '';
        this._suffix = '';
        this._separator = ' - ';
        this._reverse = false;
        /**
         * 设置默认标题名
         */
        this.default = "Not Page Name";
        this.i18n$ = this.i18nSrv.change
            .pipe(filter((/**
         * @return {?}
         */
        function () { return !!_this.i18n$; })))
            .subscribe((/**
         * @return {?}
         */
        function () { return _this.setTitle(); }));
    }
    Object.defineProperty(TitleService.prototype, "separator", {
        /** 设置分隔符 */
        set: /**
         * 设置分隔符
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this._separator = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TitleService.prototype, "prefix", {
        /** 设置前缀 */
        set: /**
         * 设置前缀
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this._prefix = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TitleService.prototype, "suffix", {
        /** 设置后缀 */
        set: /**
         * 设置后缀
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this._suffix = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TitleService.prototype, "reverse", {
        /** 设置是否反转 */
        set: /**
         * 设置是否反转
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this._reverse = value;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @private
     * @return {?}
     */
    TitleService.prototype.getByElement = /**
     * @private
     * @return {?}
     */
    function () {
        /** @type {?} */
        var el = this.doc.querySelector('.alain-default__content-title h1') ||
            this.doc.querySelector('.page-header__title');
        if (el) {
            return el.firstChild.textContent.trim();
        }
        return '';
    };
    /**
     * @private
     * @return {?}
     */
    TitleService.prototype.getByRoute = /**
     * @private
     * @return {?}
     */
    function () {
        /** @type {?} */
        var next = this.injector.get(ActivatedRoute);
        while (next.firstChild)
            next = next.firstChild;
        /** @type {?} */
        var data = (next.snapshot && next.snapshot.data) || {};
        if (data.titleI18n && this.i18nSrv)
            data.title = this.i18nSrv.fanyi(data.titleI18n);
        return data.title;
    };
    /**
     * @private
     * @return {?}
     */
    TitleService.prototype.getByMenu = /**
     * @private
     * @return {?}
     */
    function () {
        /** @type {?} */
        var menus = this.menuSrv.getPathByUrl(this.injector.get(Router).url);
        if (!menus || menus.length <= 0)
            return '';
        /** @type {?} */
        var item = menus[menus.length - 1];
        /** @type {?} */
        var title;
        if (item.i18n && this.i18nSrv)
            title = this.i18nSrv.fanyi(item.i18n);
        return title || item.text;
    };
    /**
     * 设置标题
     */
    /**
     * 设置标题
     * @param {?=} title
     * @return {?}
     */
    TitleService.prototype.setTitle = /**
     * 设置标题
     * @param {?=} title
     * @return {?}
     */
    function (title) {
        if (!title) {
            title = this.getByRoute() || this.getByMenu() || this.getByElement() || this.default;
        }
        if (title && !Array.isArray(title)) {
            title = [title];
        }
        /** @type {?} */
        var newTitles = [];
        if (this._prefix) {
            newTitles.push(this._prefix);
        }
        newTitles.push.apply(newTitles, tslib_1.__spread(((/** @type {?} */ (title)))));
        if (this._suffix) {
            newTitles.push(this._suffix);
        }
        if (this._reverse) {
            newTitles = newTitles.reverse();
        }
        this.title.setTitle(newTitles.join(this._separator));
    };
    /**
     * 设置国际化标题
     */
    /**
     * 设置国际化标题
     * @param {?} key
     * @param {?=} params
     * @return {?}
     */
    TitleService.prototype.setTitleByI18n = /**
     * 设置国际化标题
     * @param {?} key
     * @param {?=} params
     * @return {?}
     */
    function (key, params) {
        this.setTitle(this.i18nSrv.fanyi(key, params));
    };
    /**
     * @return {?}
     */
    TitleService.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.i18n$.unsubscribe();
    };
    TitleService.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */
    TitleService.ctorParameters = function () { return [
        { type: Injector },
        { type: Title },
        { type: MenuService },
        { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [ALAIN_I18N_TOKEN,] }] },
        { type: undefined, decorators: [{ type: Inject, args: [DOCUMENT,] }] }
    ]; };
    /** @nocollapse */ TitleService.ngInjectableDef = i0.defineInjectable({ factory: function TitleService_Factory() { return new TitleService(i0.inject(i0.INJECTOR), i0.inject(i1.Title), i0.inject(i2.MenuService), i0.inject(i3.ALAIN_I18N_TOKEN, 8), i0.inject(i4.DOCUMENT)); }, token: TitleService, providedIn: "root" });
    return TitleService;
}());
export { TitleService };
if (false) {
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype._prefix;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype._suffix;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype._separator;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype._reverse;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype.i18n$;
    /**
     * 设置默认标题名
     * @type {?}
     */
    TitleService.prototype.default;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype.injector;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype.title;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype.menuSrv;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype.i18nSrv;
    /**
     * @type {?}
     * @private
     */
    TitleService.prototype.doc;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidGl0bGUuc2VydmljZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi90aGVtZS8iLCJzb3VyY2VzIjpbInNyYy9zZXJ2aWNlcy90aXRsZS90aXRsZS5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7O0FBQUEsT0FBTyxFQUFFLFFBQVEsRUFBRSxNQUFNLGlCQUFpQixDQUFDO0FBQzNDLE9BQU8sRUFBRSxNQUFNLEVBQUUsVUFBVSxFQUFFLFFBQVEsRUFBYSxRQUFRLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFDbEYsT0FBTyxFQUFFLEtBQUssRUFBRSxNQUFNLDJCQUEyQixDQUFDO0FBQ2xELE9BQU8sRUFBRSxjQUFjLEVBQUUsTUFBTSxFQUFFLE1BQU0saUJBQWlCLENBQUM7QUFFekQsT0FBTyxFQUFFLE1BQU0sRUFBRSxNQUFNLGdCQUFnQixDQUFDO0FBRXhDLE9BQU8sRUFBb0IsZ0JBQWdCLEVBQUUsTUFBTSxjQUFjLENBQUM7QUFDbEUsT0FBTyxFQUFFLFdBQVcsRUFBRSxNQUFNLHNCQUFzQixDQUFDOzs7Ozs7QUFFbkQ7SUFRRSxzQkFDVSxRQUFrQixFQUNsQixLQUFZLEVBQ1osT0FBb0IsRUFHcEIsT0FBeUIsRUFDUCxHQUFRO1FBUHBDLGlCQVlDO1FBWFMsYUFBUSxHQUFSLFFBQVEsQ0FBVTtRQUNsQixVQUFLLEdBQUwsS0FBSyxDQUFPO1FBQ1osWUFBTyxHQUFQLE9BQU8sQ0FBYTtRQUdwQixZQUFPLEdBQVAsT0FBTyxDQUFrQjtRQUNQLFFBQUcsR0FBSCxHQUFHLENBQUs7UUFiNUIsWUFBTyxHQUFHLEVBQUUsQ0FBQztRQUNiLFlBQU8sR0FBRyxFQUFFLENBQUM7UUFDYixlQUFVLEdBQUcsS0FBSyxDQUFDO1FBQ25CLGFBQVEsR0FBRyxLQUFLLENBQUM7Ozs7UUFzQ3pCLFlBQU8sR0FBRyxlQUFlLENBQUM7UUExQnhCLElBQUksQ0FBQyxLQUFLLEdBQUcsSUFBSSxDQUFDLE9BQU8sQ0FBQyxNQUFNO2FBQzdCLElBQUksQ0FB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QyxRQUFROzs7dUJBekJwQjtDQXNIQyxBQTVHRCxJQTRHQztTQTNHWSxZQUFZOzs7Ozs7SUFDdkIsK0JBQXFCOzs7OztJQUNyQiwrQkFBcUI7Ozs7O0lBQ3JCLGtDQUEyQjs7Ozs7SUFDM0IsZ0NBQXlCOzs7OztJQUN6Qiw2QkFBNEI7Ozs7O0lBcUM1QiwrQkFBMEI7Ozs7O0lBbEN4QixnQ0FBMEI7Ozs7O0lBQzFCLDZCQUFvQjs7Ozs7SUFDcEIsK0JBQTRCOzs7OztJQUM1QiwrQkFFaUM7Ozs7O0lBQ2pDLDJCQUFrQyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IERPQ1VNRU5UIH0gZnJvbSAnQGFuZ3VsYXIvY29tbW9uJztcbmltcG9ydCB7IEluamVjdCwgSW5qZWN0YWJsZSwgSW5qZWN0b3IsIE9uRGVzdHJveSwgT3B0aW9uYWwgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IFRpdGxlIH0gZnJvbSAnQGFuZ3VsYXIvcGxhdGZvcm0tYnJvd3Nlcic7XG5pbXBvcnQgeyBBY3RpdmF0ZWRSb3V0ZSwgUm91dGVyIH0gZnJvbSAnQGFuZ3VsYXIvcm91dGVyJztcbmltcG9ydCB7IFN1YnNjcmlwdGlvbiB9IGZyb20gJ3J4anMnO1xuaW1wb3J0IHsgZmlsdGVyIH0gZnJvbSAncnhqcy9vcGVyYXRvcnMnO1xuXG5pbXBvcnQgeyBBbGFpbkkxOE5TZXJ2aWNlLCBBTEFJTl9JMThOX1RPS0VOIH0gZnJvbSAnLi4vaTE4bi9pMThuJztcbmltcG9ydCB7IE1lbnVTZXJ2aWNlIH0gZnJvbSAnLi4vbWVudS9tZW51LnNlcnZpY2UnO1xuXG5ASW5qZWN0YWJsZSh7IHByb3ZpZGVkSW46ICdyb290JyB9KVxuZXhwb3J0IGNsYXNzIFRpdGxlU2VydmljZSBpbXBsZW1lbnRzIE9uRGVzdHJveSB7XG4gIHByaXZhdGUgX3ByZWZpeCA9ICcnO1xuICBwcml2YXRlIF9zdWZmaXggPSAnJztcbiAgcHJpdmF0ZSBfc2VwYXJhdG9yID0gJyAtICc7XG4gIHByaXZhdGUgX3JldmVyc2UgPSBmYWxzZTtcbiAgcHJpdmF0ZSBpMThuJDogU3Vic2NyaXB0aW9uO1xuXG4gIGNvbnN0cnVjdG9yKFxuICAgIHByaXZhdGUgaW5qZWN0b3I6IEluamVjdG9yLFxuICAgIHByaXZhdGUgdGl0bGU6IFRpdGxlLFxuICAgIHByaXZhdGUgbWVudVNydjogTWVudVNlcnZpY2UsXG4gICAgQE9wdGlvbmFsKClcbiAgICBASW5qZWN0KEFMQUlOX0kxOE5fVE9LRU4pXG4gICAgcHJpdmF0ZSBpMThuU3J2OiBBbGFpbkkxOE5TZXJ2aWNlLFxuICAgIEBJbmplY3QoRE9DVU1FTlQpIHByaXZhdGUgZG9jOiBhbnksXG4gICkge1xuICAgIHRoaXMuaTE4biQgPSB0aGlzLmkxOG5TcnYuY2hhbmdlXG4gICAgICAucGlwZShmaWx0ZXIoKCkgPT4gISF0aGlzLmkxOG4kKSlcbiAgICAgIC5zdWJzY3JpYmUoKCkgPT4gdGhpcy5zZXRUaXRsZSgpKTtcbiAgfVxuXG4gIC8qKiDorr7nva7liIbpmpTnrKYgKi9cbiAgc2V0IHNlcGFyYXRvcih2YWx1ZTogc3RyaW5nKSB7XG4gICAgdGhpcy5fc2VwYXJhdG9yID0gdmFsdWU7XG4gIH1cblxuICAvKiog6K6+572u5YmN57yAICovXG4gIHNldCBwcmVmaXgodmFsdWU6IHN0cmluZykge1xuICAgIHRoaXMuX3ByZWZpeCA9IHZhbHVlO1xuICB9XG5cbiAgLyoqIOiuvue9ruWQjue8gCAqL1xuICBzZXQgc3VmZml4KHZhbHVlOiBzdHJpbmcpIHtcbiAgICB0aGlzLl9zdWZmaXggPSB2YWx1ZTtcbiAgfVxuXG4gIC8qKiDorr7nva7mmK/lkKblj43ovawgKi9cbiAgc2V0IHJldmVyc2UodmFsdWU6IGJvb2xlYW4pIHtcbiAgICB0aGlzLl9yZXZlcnNlID0gdmFsdWU7XG4gIH1cblxuICAvKiog6K6+572u6buY6K6k5qCH6aKY5ZCNICovXG4gIGRlZmF1bHQgPSBgTm90IFBhZ2UgTmFtZWA7XG5cbiAgcHJpdmF0ZSBnZXRCeUVsZW1lbnQoKTogc3RyaW5nIHtcbiAgICBjb25zdCBlbCA9XG4gICAgICB0aGlzLmRvYy5xdWVyeVNlbGVjdG9yKCcuYWxhaW4tZGVmYXVsdF9fY29udGVudC10aXRsZSBoMScpIHx8XG4gICAgICB0aGlzLmRvYy5xdWVyeVNlbGVjdG9yKCcucGFnZS1oZWFkZXJfX3RpdGxlJyk7XG4gICAgaWYgKGVsKSB7XG4gICAgICByZXR1cm4gZWwuZmlyc3RDaGlsZC50ZXh0Q29udGVudC50cmltKCk7XG4gICAgfVxuICAgIHJldHVybiAnJztcbiAgfVxuXG4gIHByaXZhdGUgZ2V0QnlSb3V0ZSgpOiBzdHJpbmcge1xuICAgIGxldCBuZXh0ID0gdGhpcy5pbmplY3Rvci5nZXQoQWN0aXZhdGVkUm91dGUpO1xuICAgIHdoaWxlIChuZXh0LmZpcnN0Q2hpbGQpIG5leHQgPSBuZXh0LmZpcnN0Q2hpbGQ7XG4gICAgY29uc3QgZGF0YSA9IChuZXh0LnNuYXBzaG90ICYmIG5leHQuc25hcHNob3QuZGF0YSkgfHwge307XG4gICAgaWYgKGRhdGEudGl0bGVJMThuICYmIHRoaXMuaTE4blNydikgZGF0YS50aXRsZSA9IHRoaXMuaTE4blNydi5mYW55aShkYXRhLnRpdGxlSTE4bik7XG4gICAgcmV0dXJuIGRhdGEudGl0bGU7XG4gIH1cblxuICBwcml2YXRlIGdldEJ5TWVudSgpOiBzdHJpbmcge1xuICAgIGNvbnN0IG1lbnVzID0gdGhpcy5tZW51U3J2LmdldFBhdGhCeVVybCh0aGlzLmluamVjdG9yLmdldChSb3V0ZXIpLnVybCk7XG4gICAgaWYgKCFtZW51cyB8fCBtZW51cy5sZW5ndGggPD0gMCkgcmV0dXJuICcnO1xuXG4gICAgY29uc3QgaXRlbSA9IG1lbnVzW21lbnVzLmxlbmd0aCAtIDFdO1xuICAgIGxldCB0aXRsZTtcbiAgICBpZiAoaXRlbS5pMThuICYmIHRoaXMuaTE4blNydikgdGl0bGUgPSB0aGlzLmkxOG5TcnYuZmFueWkoaXRlbS5pMThuKTtcbiAgICByZXR1cm4gdGl0bGUgfHwgaXRlbS50ZXh0O1xuICB9XG5cbiAgLyoqXG4gICAqIOiuvue9ruagh+mimFxuICAgKi9cbiAgc2V0VGl0bGUodGl0bGU/OiBzdHJpbmcgfCBzdHJpbmdbXSkge1xuICAgIGlmICghdGl0bGUpIHtcbiAgICAgIHRpdGxlID0gdGhpcy5nZXRCeVJvdXRlKCkgfHwgdGhpcy5nZXRCeU1lbnUoKSB8fCB0aGlzLmdldEJ5RWxlbWVudCgpIHx8IHRoaXMuZGVmYXVsdDtcbiAgICB9XG4gICAgaWYgKHRpdGxlICYmICFBcnJheS5pc0FycmF5KHRpdGxlKSkge1xuICAgICAgdGl0bGUgPSBbdGl0bGVdO1xuICAgIH1cblxuICAgIGxldCBuZXdUaXRsZXMgPSBbXTtcbiAgICBpZiAodGhpcy5fcHJlZml4KSB7XG4gICAgICBuZXdUaXRsZXMucHVzaCh0aGlzLl9wcmVmaXgpO1xuICAgIH1cbiAgICBuZXdUaXRsZXMucHVzaCguLi4odGl0bGUgYXMgc3RyaW5nW10pKTtcbiAgICBpZiAodGhpcy5fc3VmZml4KSB7XG4gICAgICBuZXdUaXRsZXMucHVzaCh0aGlzLl9zdWZmaXgpO1xuICAgIH1cbiAgICBpZiAodGhpcy5fcmV2ZXJzZSkge1xuICAgICAgbmV3VGl0bGVzID0gbmV3VGl0bGVzLnJldmVyc2UoKTtcbiAgICB9XG4gICAgdGhpcy50aXRsZS5zZXRUaXRsZShuZXdUaXRsZXMuam9pbih0aGlzLl9zZXBhcmF0b3IpKTtcbiAgfVxuXG4gIC8qKlxuICAgKiDorr7nva7lm73pmYXljJbmoIfpophcbiAgICovXG4gIHNldFRpdGxlQnlJMThuKGtleTogc3RyaW5nLCBwYXJhbXM/OiB7fSkge1xuICAgIHRoaXMuc2V0VGl0bGUodGhpcy5pMThuU3J2LmZhbnlpKGtleSwgcGFyYW1zKSk7XG4gIH1cblxuICBuZ09uRGVzdHJveSgpOiB2b2lkIHtcbiAgICB0aGlzLmkxOG4kLnVuc3Vic2NyaWJlKCk7XG4gIH1cbn1cbiJdfQ==