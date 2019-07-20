/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
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
export class TitleService {
    /**
     * @param {?} injector
     * @param {?} title
     * @param {?} menuSrv
     * @param {?} i18nSrv
     * @param {?} doc
     */
    constructor(injector, title, menuSrv, i18nSrv, doc) {
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
        this.default = `Not Page Name`;
        this.i18n$ = this.i18nSrv.change
            .pipe(filter((/**
         * @return {?}
         */
        () => !!this.i18n$)))
            .subscribe((/**
         * @return {?}
         */
        () => this.setTitle()));
    }
    /**
     * 设置分隔符
     * @param {?} value
     * @return {?}
     */
    set separator(value) {
        this._separator = value;
    }
    /**
     * 设置前缀
     * @param {?} value
     * @return {?}
     */
    set prefix(value) {
        this._prefix = value;
    }
    /**
     * 设置后缀
     * @param {?} value
     * @return {?}
     */
    set suffix(value) {
        this._suffix = value;
    }
    /**
     * 设置是否反转
     * @param {?} value
     * @return {?}
     */
    set reverse(value) {
        this._reverse = value;
    }
    /**
     * @private
     * @return {?}
     */
    getByElement() {
        /** @type {?} */
        const el = this.doc.querySelector('.alain-default__content-title h1') ||
            this.doc.querySelector('.page-header__title');
        if (el) {
            return el.firstChild.textContent.trim();
        }
        return '';
    }
    /**
     * @private
     * @return {?}
     */
    getByRoute() {
        /** @type {?} */
        let next = this.injector.get(ActivatedRoute);
        while (next.firstChild)
            next = next.firstChild;
        /** @type {?} */
        const data = (next.snapshot && next.snapshot.data) || {};
        if (data.titleI18n && this.i18nSrv)
            data.title = this.i18nSrv.fanyi(data.titleI18n);
        return data.title;
    }
    /**
     * @private
     * @return {?}
     */
    getByMenu() {
        /** @type {?} */
        const menus = this.menuSrv.getPathByUrl(this.injector.get(Router).url);
        if (!menus || menus.length <= 0)
            return '';
        /** @type {?} */
        const item = menus[menus.length - 1];
        /** @type {?} */
        let title;
        if (item.i18n && this.i18nSrv)
            title = this.i18nSrv.fanyi(item.i18n);
        return title || item.text;
    }
    /**
     * 设置标题
     * @param {?=} title
     * @return {?}
     */
    setTitle(title) {
        if (!title) {
            title = this.getByRoute() || this.getByMenu() || this.getByElement() || this.default;
        }
        if (title && !Array.isArray(title)) {
            title = [title];
        }
        /** @type {?} */
        let newTitles = [];
        if (this._prefix) {
            newTitles.push(this._prefix);
        }
        newTitles.push(...((/** @type {?} */ (title))));
        if (this._suffix) {
            newTitles.push(this._suffix);
        }
        if (this._reverse) {
            newTitles = newTitles.reverse();
        }
        this.title.setTitle(newTitles.join(this._separator));
    }
    /**
     * 设置国际化标题
     * @param {?} key
     * @param {?=} params
     * @return {?}
     */
    setTitleByI18n(key, params) {
        this.setTitle(this.i18nSrv.fanyi(key, params));
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this.i18n$.unsubscribe();
    }
}
TitleService.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */
TitleService.ctorParameters = () => [
    { type: Injector },
    { type: Title },
    { type: MenuService },
    { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [ALAIN_I18N_TOKEN,] }] },
    { type: undefined, decorators: [{ type: Inject, args: [DOCUMENT,] }] }
];
/** @nocollapse */ TitleService.ngInjectableDef = i0.defineInjectable({ factory: function TitleService_Factory() { return new TitleService(i0.inject(i0.INJECTOR), i0.inject(i1.Title), i0.inject(i2.MenuService), i0.inject(i3.ALAIN_I18N_TOKEN, 8), i0.inject(i4.DOCUMENT)); }, token: TitleService, providedIn: "root" });
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
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidGl0bGUuc2VydmljZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi90aGVtZS8iLCJzb3VyY2VzIjpbInNyYy9zZXJ2aWNlcy90aXRsZS90aXRsZS5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsUUFBUSxFQUFFLE1BQU0saUJBQWlCLENBQUM7QUFDM0MsT0FBTyxFQUFFLE1BQU0sRUFBRSxVQUFVLEVBQUUsUUFBUSxFQUFhLFFBQVEsRUFBRSxNQUFNLGVBQWUsQ0FBQztBQUNsRixPQUFPLEVBQUUsS0FBSyxFQUFFLE1BQU0sMkJBQTJCLENBQUM7QUFDbEQsT0FBTyxFQUFFLGNBQWMsRUFBRSxNQUFNLEVBQUUsTUFBTSxpQkFBaUIsQ0FBQztBQUV6RCxPQUFPLEVBQUUsTUFBTSxFQUFFLE1BQU0sZ0JBQWdCLENBQUM7QUFFeEMsT0FBTyxFQUFvQixnQkFBZ0IsRUFBRSxNQUFNLGNBQWMsQ0FBQztBQUNsRSxPQUFPLEVBQUUsV0FBVyxFQUFFLE1BQU0sc0JBQXNCLENBQUM7Ozs7OztBQUduRCxNQUFNLE9BQU8sWUFBWTs7Ozs7Ozs7SUFPdkIsWUFDVSxRQUFrQixFQUNsQixLQUFZLEVBQ1osT0FBb0IsRUFHcEIsT0FBeUIsRUFDUCxHQUFRO1FBTjFCLGFBQVEsR0FBUixRQUFRLENBQVU7UUFDbEIsVUFBSyxHQUFMLEtBQUssQ0FBTztRQUNaLFlBQU8sR0FBUCxPQUFPLENBQWE7UUFHcEIsWUFBTyxHQUFQLE9BQU8sQ0FBa0I7UUFDUCxRQUFHLEdBQUgsR0FBRyxDQUFLO1FBYjVCLFlBQU8sR0FBRyxFQUFFLENBQUM7UUFDYixZQUFPLEdBQUcsRUFBRSxDQUFDO1FBQ2IsZUFBVSxHQUFHLEtBQUssQ0FBQztRQUNuQixhQUFRLEdBQUcsS0FBSyxDQUFDOzs7O1FBc0N6QixZQUFPLEdBQUcsZUFBZSxDQUFDO1FBMUJ4QixJQUFJLENBQUMsS0FBSyxHQUFHLElBQUksQ0FBQyxPQUFPLENBQUMsTUFBTTthQUM3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Ozs7OztJQUNqQywyQkFBa0MiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBET0NVTUVOVCB9IGZyb20gJ0Bhbmd1bGFyL2NvbW1vbic7XG5pbXBvcnQgeyBJbmplY3QsIEluamVjdGFibGUsIEluamVjdG9yLCBPbkRlc3Ryb3ksIE9wdGlvbmFsIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBUaXRsZSB9IGZyb20gJ0Bhbmd1bGFyL3BsYXRmb3JtLWJyb3dzZXInO1xuaW1wb3J0IHsgQWN0aXZhdGVkUm91dGUsIFJvdXRlciB9IGZyb20gJ0Bhbmd1bGFyL3JvdXRlcic7XG5pbXBvcnQgeyBTdWJzY3JpcHRpb24gfSBmcm9tICdyeGpzJztcbmltcG9ydCB7IGZpbHRlciB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuaW1wb3J0IHsgQWxhaW5JMThOU2VydmljZSwgQUxBSU5fSTE4Tl9UT0tFTiB9IGZyb20gJy4uL2kxOG4vaTE4bic7XG5pbXBvcnQgeyBNZW51U2VydmljZSB9IGZyb20gJy4uL21lbnUvbWVudS5zZXJ2aWNlJztcblxuQEluamVjdGFibGUoeyBwcm92aWRlZEluOiAncm9vdCcgfSlcbmV4cG9ydCBjbGFzcyBUaXRsZVNlcnZpY2UgaW1wbGVtZW50cyBPbkRlc3Ryb3kge1xuICBwcml2YXRlIF9wcmVmaXggPSAnJztcbiAgcHJpdmF0ZSBfc3VmZml4ID0gJyc7XG4gIHByaXZhdGUgX3NlcGFyYXRvciA9ICcgLSAnO1xuICBwcml2YXRlIF9yZXZlcnNlID0gZmFsc2U7XG4gIHByaXZhdGUgaTE4biQ6IFN1YnNjcmlwdGlvbjtcblxuICBjb25zdHJ1Y3RvcihcbiAgICBwcml2YXRlIGluamVjdG9yOiBJbmplY3RvcixcbiAgICBwcml2YXRlIHRpdGxlOiBUaXRsZSxcbiAgICBwcml2YXRlIG1lbnVTcnY6IE1lbnVTZXJ2aWNlLFxuICAgIEBPcHRpb25hbCgpXG4gICAgQEluamVjdChBTEFJTl9JMThOX1RPS0VOKVxuICAgIHByaXZhdGUgaTE4blNydjogQWxhaW5JMThOU2VydmljZSxcbiAgICBASW5qZWN0KERPQ1VNRU5UKSBwcml2YXRlIGRvYzogYW55LFxuICApIHtcbiAgICB0aGlzLmkxOG4kID0gdGhpcy5pMThuU3J2LmNoYW5nZVxuICAgICAgLnBpcGUoZmlsdGVyKCgpID0+ICEhdGhpcy5pMThuJCkpXG4gICAgICAuc3Vic2NyaWJlKCgpID0+IHRoaXMuc2V0VGl0bGUoKSk7XG4gIH1cblxuICAvKiog6K6+572u5YiG6ZqU56ymICovXG4gIHNldCBzZXBhcmF0b3IodmFsdWU6IHN0cmluZykge1xuICAgIHRoaXMuX3NlcGFyYXRvciA9IHZhbHVlO1xuICB9XG5cbiAgLyoqIOiuvue9ruWJjee8gCAqL1xuICBzZXQgcHJlZml4KHZhbHVlOiBzdHJpbmcpIHtcbiAgICB0aGlzLl9wcmVmaXggPSB2YWx1ZTtcbiAgfVxuXG4gIC8qKiDorr7nva7lkI7nvIAgKi9cbiAgc2V0IHN1ZmZpeCh2YWx1ZTogc3RyaW5nKSB7XG4gICAgdGhpcy5fc3VmZml4ID0gdmFsdWU7XG4gIH1cblxuICAvKiog6K6+572u5piv5ZCm5Y+N6L2sICovXG4gIHNldCByZXZlcnNlKHZhbHVlOiBib29sZWFuKSB7XG4gICAgdGhpcy5fcmV2ZXJzZSA9IHZhbHVlO1xuICB9XG5cbiAgLyoqIOiuvue9rum7mOiupOagh+mimOWQjSAqL1xuICBkZWZhdWx0ID0gYE5vdCBQYWdlIE5hbWVgO1xuXG4gIHByaXZhdGUgZ2V0QnlFbGVtZW50KCk6IHN0cmluZyB7XG4gICAgY29uc3QgZWwgPVxuICAgICAgdGhpcy5kb2MucXVlcnlTZWxlY3RvcignLmFsYWluLWRlZmF1bHRfX2NvbnRlbnQtdGl0bGUgaDEnKSB8fFxuICAgICAgdGhpcy5kb2MucXVlcnlTZWxlY3RvcignLnBhZ2UtaGVhZGVyX190aXRsZScpO1xuICAgIGlmIChlbCkge1xuICAgICAgcmV0dXJuIGVsLmZpcnN0Q2hpbGQudGV4dENvbnRlbnQudHJpbSgpO1xuICAgIH1cbiAgICByZXR1cm4gJyc7XG4gIH1cblxuICBwcml2YXRlIGdldEJ5Um91dGUoKTogc3RyaW5nIHtcbiAgICBsZXQgbmV4dCA9IHRoaXMuaW5qZWN0b3IuZ2V0KEFjdGl2YXRlZFJvdXRlKTtcbiAgICB3aGlsZSAobmV4dC5maXJzdENoaWxkKSBuZXh0ID0gbmV4dC5maXJzdENoaWxkO1xuICAgIGNvbnN0IGRhdGEgPSAobmV4dC5zbmFwc2hvdCAmJiBuZXh0LnNuYXBzaG90LmRhdGEpIHx8IHt9O1xuICAgIGlmIChkYXRhLnRpdGxlSTE4biAmJiB0aGlzLmkxOG5TcnYpIGRhdGEudGl0bGUgPSB0aGlzLmkxOG5TcnYuZmFueWkoZGF0YS50aXRsZUkxOG4pO1xuICAgIHJldHVybiBkYXRhLnRpdGxlO1xuICB9XG5cbiAgcHJpdmF0ZSBnZXRCeU1lbnUoKTogc3RyaW5nIHtcbiAgICBjb25zdCBtZW51cyA9IHRoaXMubWVudVNydi5nZXRQYXRoQnlVcmwodGhpcy5pbmplY3Rvci5nZXQoUm91dGVyKS51cmwpO1xuICAgIGlmICghbWVudXMgfHwgbWVudXMubGVuZ3RoIDw9IDApIHJldHVybiAnJztcblxuICAgIGNvbnN0IGl0ZW0gPSBtZW51c1ttZW51cy5sZW5ndGggLSAxXTtcbiAgICBsZXQgdGl0bGU7XG4gICAgaWYgKGl0ZW0uaTE4biAmJiB0aGlzLmkxOG5TcnYpIHRpdGxlID0gdGhpcy5pMThuU3J2LmZhbnlpKGl0ZW0uaTE4bik7XG4gICAgcmV0dXJuIHRpdGxlIHx8IGl0ZW0udGV4dDtcbiAgfVxuXG4gIC8qKlxuICAgKiDorr7nva7moIfpophcbiAgICovXG4gIHNldFRpdGxlKHRpdGxlPzogc3RyaW5nIHwgc3RyaW5nW10pIHtcbiAgICBpZiAoIXRpdGxlKSB7XG4gICAgICB0aXRsZSA9IHRoaXMuZ2V0QnlSb3V0ZSgpIHx8IHRoaXMuZ2V0QnlNZW51KCkgfHwgdGhpcy5nZXRCeUVsZW1lbnQoKSB8fCB0aGlzLmRlZmF1bHQ7XG4gICAgfVxuICAgIGlmICh0aXRsZSAmJiAhQXJyYXkuaXNBcnJheSh0aXRsZSkpIHtcbiAgICAgIHRpdGxlID0gW3RpdGxlXTtcbiAgICB9XG5cbiAgICBsZXQgbmV3VGl0bGVzID0gW107XG4gICAgaWYgKHRoaXMuX3ByZWZpeCkge1xuICAgICAgbmV3VGl0bGVzLnB1c2godGhpcy5fcHJlZml4KTtcbiAgICB9XG4gICAgbmV3VGl0bGVzLnB1c2goLi4uKHRpdGxlIGFzIHN0cmluZ1tdKSk7XG4gICAgaWYgKHRoaXMuX3N1ZmZpeCkge1xuICAgICAgbmV3VGl0bGVzLnB1c2godGhpcy5fc3VmZml4KTtcbiAgICB9XG4gICAgaWYgKHRoaXMuX3JldmVyc2UpIHtcbiAgICAgIG5ld1RpdGxlcyA9IG5ld1RpdGxlcy5yZXZlcnNlKCk7XG4gICAgfVxuICAgIHRoaXMudGl0bGUuc2V0VGl0bGUobmV3VGl0bGVzLmpvaW4odGhpcy5fc2VwYXJhdG9yKSk7XG4gIH1cblxuICAvKipcbiAgICog6K6+572u5Zu96ZmF5YyW5qCH6aKYXG4gICAqL1xuICBzZXRUaXRsZUJ5STE4bihrZXk6IHN0cmluZywgcGFyYW1zPzoge30pIHtcbiAgICB0aGlzLnNldFRpdGxlKHRoaXMuaTE4blNydi5mYW55aShrZXksIHBhcmFtcykpO1xuICB9XG5cbiAgbmdPbkRlc3Ryb3koKTogdm9pZCB7XG4gICAgdGhpcy5pMThuJC51bnN1YnNjcmliZSgpO1xuICB9XG59XG4iXX0=