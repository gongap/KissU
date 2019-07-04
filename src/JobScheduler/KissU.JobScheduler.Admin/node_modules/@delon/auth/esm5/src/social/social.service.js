/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { DOCUMENT } from '@angular/common';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { DA_SERVICE_TOKEN } from '../token/interface';
/** @type {?} */
var OPENTYPE = '_delonAuthSocialType';
/** @type {?} */
var HREFCALLBACK = '_delonAuthSocialCallbackByHref';
var SocialService = /** @class */ (function () {
    function SocialService(tokenService, doc, router) {
        this.tokenService = tokenService;
        this.doc = doc;
        this.router = router;
    }
    /**
     * 跳转至登录页，若为 `type=window` 时，返回值是 `Observable<ITokenModel>`
     * @param url 获取授权地址
     * @param callback 当 `type=href` 成功时的回调路由地址
     * @param options.type 打开方式，默认 `window`
     * @param options.windowFeatures 等同 `window.open` 的 `features` 参数值
     */
    /**
     * 跳转至登录页，若为 `type=window` 时，返回值是 `Observable<ITokenModel>`
     * @param {?} url 获取授权地址
     * @param {?=} callback 当 `type=href` 成功时的回调路由地址
     * @param {?=} options
     * @return {?}
     */
    SocialService.prototype.login = /**
     * 跳转至登录页，若为 `type=window` 时，返回值是 `Observable<ITokenModel>`
     * @param {?} url 获取授权地址
     * @param {?=} callback 当 `type=href` 成功时的回调路由地址
     * @param {?=} options
     * @return {?}
     */
    function (url, callback, options) {
        var _this = this;
        if (callback === void 0) { callback = '/'; }
        if (options === void 0) { options = {}; }
        options = tslib_1.__assign({ type: 'window', windowFeatures: 'location=yes,height=570,width=520,scrollbars=yes,status=yes' }, options);
        localStorage.setItem(OPENTYPE, options.type);
        localStorage.setItem(HREFCALLBACK, callback);
        if (options.type === 'href') {
            this.doc.location.href = url;
            return;
        }
        this._win = window.open(url, '_blank', options.windowFeatures);
        this._winTime = setInterval((/**
         * @return {?}
         */
        function () {
            if (_this._win && _this._win.closed) {
                _this.ngOnDestroy();
                /** @type {?} */
                var model = _this.tokenService.get();
                if (model && !model.token)
                    model = null;
                // 触发变更通知
                if (model) {
                    _this.tokenService.set(model);
                }
                _this.observer.next(model);
                _this.observer.complete();
            }
        }), 100);
        return Observable.create((/**
         * @param {?} observer
         * @return {?}
         */
        function (observer) {
            _this.observer = observer;
        }));
    };
    /**
     * 授权成功后的回调处理
     *
     * @param rawData 指定回调认证信息，为空时从根据当前URL解析
     */
    /**
     * 授权成功后的回调处理
     *
     * @param {?=} rawData 指定回调认证信息，为空时从根据当前URL解析
     * @return {?}
     */
    SocialService.prototype.callback = /**
     * 授权成功后的回调处理
     *
     * @param {?=} rawData 指定回调认证信息，为空时从根据当前URL解析
     * @return {?}
     */
    function (rawData) {
        // from uri
        if (!rawData && this.router.url.indexOf('?') === -1) {
            throw new Error("url muse contain a ?");
        }
        // parse
        /** @type {?} */
        var data = { token: "" };
        if (typeof rawData === 'string') {
            /** @type {?} */
            var rightUrl = rawData.split('?')[1].split('#')[0];
            data = (/** @type {?} */ (this.router.parseUrl('./?' + rightUrl).queryParams));
        }
        else {
            data = rawData;
        }
        if (!data || !data.token)
            throw new Error("invalide token data");
        this.tokenService.set(data);
        /** @type {?} */
        var url = localStorage.getItem(HREFCALLBACK) || '/';
        localStorage.removeItem(HREFCALLBACK);
        /** @type {?} */
        var type = localStorage.getItem(OPENTYPE);
        localStorage.removeItem(OPENTYPE);
        if (type === 'window') {
            window.close();
        }
        else {
            this.router.navigateByUrl(url);
        }
        return data;
    };
    /**
     * @return {?}
     */
    SocialService.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        clearInterval(this._winTime);
        this._winTime = null;
    };
    SocialService.decorators = [
        { type: Injectable }
    ];
    /** @nocollapse */
    SocialService.ctorParameters = function () { return [
        { type: undefined, decorators: [{ type: Inject, args: [DA_SERVICE_TOKEN,] }] },
        { type: undefined, decorators: [{ type: Inject, args: [DOCUMENT,] }] },
        { type: Router }
    ]; };
    return SocialService;
}());
export { SocialService };
if (false) {
    /**
     * @type {?}
     * @private
     */
    SocialService.prototype._win;
    /**
     * @type {?}
     * @private
     */
    SocialService.prototype._winTime;
    /**
     * @type {?}
     * @private
     */
    SocialService.prototype.observer;
    /**
     * @type {?}
     * @private
     */
    SocialService.prototype.tokenService;
    /**
     * @type {?}
     * @private
     */
    SocialService.prototype.doc;
    /**
     * @type {?}
     * @private
     */
    SocialService.prototype.router;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoic29jaWFsLnNlcnZpY2UuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYXV0aC8iLCJzb3VyY2VzIjpbInNyYy9zb2NpYWwvc29jaWFsLnNlcnZpY2UudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7QUFBQSxPQUFPLEVBQUUsUUFBUSxFQUFFLE1BQU0saUJBQWlCLENBQUM7QUFDM0MsT0FBTyxFQUFFLE1BQU0sRUFBRSxVQUFVLEVBQWEsTUFBTSxlQUFlLENBQUM7QUFDOUQsT0FBTyxFQUFFLE1BQU0sRUFBRSxNQUFNLGlCQUFpQixDQUFDO0FBQ3pDLE9BQU8sRUFBRSxVQUFVLEVBQVksTUFBTSxNQUFNLENBQUM7QUFFNUMsT0FBTyxFQUFFLGdCQUFnQixFQUE4QixNQUFNLG9CQUFvQixDQUFDOztJQUU1RSxRQUFRLEdBQUcsc0JBQXNCOztJQUNqQyxZQUFZLEdBQUcsZ0NBQWdDO0FBSXJEO0lBTUUsdUJBQ29DLFlBQTJCLEVBQ25DLEdBQVEsRUFDMUIsTUFBYztRQUZZLGlCQUFZLEdBQVosWUFBWSxDQUFlO1FBQ25DLFFBQUcsR0FBSCxHQUFHLENBQUs7UUFDMUIsV0FBTSxHQUFOLE1BQU0sQ0FBUTtJQUNyQixDQUFDO0lBOEJKOzs7Ozs7T0FNRzs7Ozs7Ozs7SUFDSCw2QkFBSzs7Ozs7OztJQUFMLFVBQ0UsR0FBVyxFQUNYLFFBQXNCLEVBQ3RCLE9BR007UUFOUixpQkF3Q0M7UUF0Q0MseUJBQUEsRUFBQSxjQUFzQjtRQUN0Qix3QkFBQSxFQUFBLFlBR007UUFFTixPQUFPLHNCQUNMLElBQUksRUFBRSxRQUFRLEVBQ2QsY0FBYyxFQUFFLDZEQUE2RCxJQUMxRSxPQUFPLENBQ1gsQ0FBQztRQUNGLFlBQVksQ0FBQyxPQUFPLENBQUMsUUFBUSxFQUFFLE9BQU8sQ0FBQyxJQUFJLENBQUMsQ0FBQztRQUM3QyxZQUFZLENBQUMsT0FBTyxDQUFDLFlBQVksRUFBRSxRQUFRLENBQUMsQ0FBQztRQUM3QyxJQUFJLE9BQU8sQ0FBQyxJQUFJLEtBQUss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UUFBUSxDQUFDLENBQUM7UUFDN0IsSUFBSSxDQUFDLFFBQVEsR0FBRyxJQUFJLENBQUM7SUFDdkIsQ0FBQzs7Z0JBL0hGLFVBQVU7Ozs7Z0RBT04sTUFBTSxTQUFDLGdCQUFnQjtnREFDdkIsTUFBTSxTQUFDLFFBQVE7Z0JBbEJYLE1BQU07O0lBMElmLG9CQUFDO0NBQUEsQUFoSUQsSUFnSUM7U0EvSFksYUFBYTs7Ozs7O0lBQ3hCLDZCQUFxQjs7Ozs7SUFDckIsaUNBQWlCOzs7OztJQUNqQixpQ0FBd0M7Ozs7O0lBR3RDLHFDQUE2RDs7Ozs7SUFDN0QsNEJBQWtDOzs7OztJQUNsQywrQkFBc0IiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBET0NVTUVOVCB9IGZyb20gJ0Bhbmd1bGFyL2NvbW1vbic7XG5pbXBvcnQgeyBJbmplY3QsIEluamVjdGFibGUsIE9uRGVzdHJveSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgUm91dGVyIH0gZnJvbSAnQGFuZ3VsYXIvcm91dGVyJztcbmltcG9ydCB7IE9ic2VydmFibGUsIE9ic2VydmVyIH0gZnJvbSAncnhqcyc7XG5cbmltcG9ydCB7IERBX1NFUlZJQ0VfVE9LRU4sIElUb2tlbk1vZGVsLCBJVG9rZW5TZXJ2aWNlIH0gZnJvbSAnLi4vdG9rZW4vaW50ZXJmYWNlJztcblxuY29uc3QgT1BFTlRZUEUgPSAnX2RlbG9uQXV0aFNvY2lhbFR5cGUnO1xuY29uc3QgSFJFRkNBTExCQUNLID0gJ19kZWxvbkF1dGhTb2NpYWxDYWxsYmFja0J5SHJlZic7XG5cbmV4cG9ydCB0eXBlIFNvY2lhbE9wZW5UeXBlID0gJ2hyZWYnIHwgJ3dpbmRvdyc7XG5cbkBJbmplY3RhYmxlKClcbmV4cG9ydCBjbGFzcyBTb2NpYWxTZXJ2aWNlIGltcGxlbWVudHMgT25EZXN0cm95IHtcbiAgcHJpdmF0ZSBfd2luOiBXaW5kb3c7XG4gIHByaXZhdGUgX3dpblRpbWU7XG4gIHByaXZhdGUgb2JzZXJ2ZXI6IE9ic2VydmVyPElUb2tlbk1vZGVsPjtcblxuICBjb25zdHJ1Y3RvcihcbiAgICBASW5qZWN0KERBX1NFUlZJQ0VfVE9LRU4pIHByaXZhdGUgdG9rZW5TZXJ2aWNlOiBJVG9rZW5TZXJ2aWNlLFxuICAgIEBJbmplY3QoRE9DVU1FTlQpIHByaXZhdGUgZG9jOiBhbnksXG4gICAgcHJpdmF0ZSByb3V0ZXI6IFJvdXRlcixcbiAgKSB7fVxuXG4gIC8qKlxuICAgKiDkvb/nlKjnqpfkvZPmiZPlvIDmjojmnYPpobXvvIzov5Tlm57lgLzmmK8gYE9ic2VydmFibGU8SVRva2VuTW9kZWw+YCDnlKjkuo7orqLpmIXmjojmnYPlkI7ov5Tlm57nmoTnu5PmnpxcbiAgICogQHBhcmFtIHVybCDojrflj5bmjojmnYPlnLDlnYBcbiAgICogQHBhcmFtIGNhbGxiYWNrIOWbnuiwg+i3r+eUseWcsOWdgFxuICAgKiBAcGFyYW0gb3B0aW9ucy53aW5kb3dGZWF0dXJlcyDnrYnlkIwgYHdpbmRvdy5vcGVuYCDnmoQgYGZlYXR1cmVzYCDlj4LmlbDlgLxcbiAgICovXG4gIGxvZ2luKFxuICAgIHVybDogc3RyaW5nLFxuICAgIGNhbGxiYWNrPzogc3RyaW5nLFxuICAgIG9wdGlvbnM/OiB7XG4gICAgICB0eXBlPzogJ3dpbmRvdyc7XG4gICAgICB3aW5kb3dGZWF0dXJlcz86IHN0cmluZztcbiAgICB9LFxuICApOiBPYnNlcnZhYmxlPElUb2tlbk1vZGVsPjtcblxuICAvKipcbiAgICog6Lez6L2s6Iez5o6I5p2D6aG1XG4gICAqIEBwYXJhbSB1cmwg6I635Y+W5o6I5p2D5Zyw5Z2AXG4gICAqIEBwYXJhbSBjYWxsYmFjayDlm57osIPot6/nlLHlnLDlnYBcbiAgICovXG4gIGxvZ2luKFxuICAgIHVybDogc3RyaW5nLFxuICAgIGNhbGxiYWNrPzogc3RyaW5nLFxuICAgIG9wdGlvbnM/OiB7XG4gICAgICB0eXBlPzogJ2hyZWYnO1xuICAgIH0sXG4gICk6IHZvaWQ7XG5cbiAgLyoqXG4gICAqIOi3s+i9rOiHs+eZu+W9lemhte+8jOiLpeS4uiBgdHlwZT13aW5kb3dgIOaXtu+8jOi/lOWbnuWAvOaYryBgT2JzZXJ2YWJsZTxJVG9rZW5Nb2RlbD5gXG4gICAqIEBwYXJhbSB1cmwg6I635Y+W5o6I5p2D5Zyw5Z2AXG4gICAqIEBwYXJhbSBjYWxsYmFjayDlvZMgYHR5cGU9aHJlZmAg5oiQ5Yqf5pe255qE5Zue6LCD6Lev55Sx5Zyw5Z2AXG4gICAqIEBwYXJhbSBvcHRpb25zLnR5cGUg5omT5byA5pa55byP77yM6buY6K6kIGB3aW5kb3dgXG4gICAqIEBwYXJhbSBvcHRpb25zLndpbmRvd0ZlYXR1cmVzIOetieWQjCBgd2luZG93Lm9wZW5gIOeahCBgZmVhdHVyZXNgIOWPguaVsOWAvFxuICAgKi9cbiAgbG9naW4oXG4gICAgdXJsOiBzdHJpbmcsXG4gICAgY2FsbGJhY2s6IHN0cmluZyA9ICcvJyxcbiAgICBvcHRpb25zOiB7XG4gICAgICB0eXBlPzogU29jaWFsT3BlblR5cGU7XG4gICAgICB3aW5kb3dGZWF0dXJlcz86IHN0cmluZztcbiAgICB9ID0ge30sXG4gICk6IE9ic2VydmFibGU8SVRva2VuTW9kZWw+IHwgdm9pZCB7XG4gICAgb3B0aW9ucyA9IHtcbiAgICAgIHR5cGU6ICd3aW5kb3cnLFxuICAgICAgd2luZG93RmVhdHVyZXM6ICdsb2NhdGlvbj15ZXMsaGVpZ2h0PTU3MCx3aWR0aD01MjAsc2Nyb2xsYmFycz15ZXMsc3RhdHVzPXllcycsXG4gICAgICAuLi5vcHRpb25zLFxuICAgIH07XG4gICAgbG9jYWxTdG9yYWdlLnNldEl0ZW0oT1BFTlRZUEUsIG9wdGlvbnMudHlwZSk7XG4gICAgbG9jYWxTdG9yYWdlLnNldEl0ZW0oSFJFRkNBTExCQUNLLCBjYWxsYmFjayk7XG4gICAgaWYgKG9wdGlvbnMudHlwZSA9PT0gJ2hyZWYnKSB7XG4gICAgICB0aGlzLmRvYy5sb2NhdGlvbi5ocmVmID0gdXJsO1xuICAgICAgcmV0dXJuO1xuICAgIH1cblxuICAgIHRoaXMuX3dpbiA9IHdpbmRvdy5vcGVuKHVybCwgJ19ibGFuaycsIG9wdGlvbnMud2luZG93RmVhdHVyZXMpO1xuICAgIHRoaXMuX3dpblRpbWUgPSBzZXRJbnRlcnZhbCgoKSA9PiB7XG4gICAgICBpZiAodGhpcy5fd2luICYmIHRoaXMuX3dpbi5jbG9zZWQpIHtcbiAgICAgICAgdGhpcy5uZ09uRGVzdHJveSgpO1xuXG4gICAgICAgIGxldCBtb2RlbCA9IHRoaXMudG9rZW5TZXJ2aWNlLmdldCgpO1xuICAgICAgICBpZiAobW9kZWwgJiYgIW1vZGVsLnRva2VuKSBtb2RlbCA9IG51bGw7XG5cbiAgICAgICAgLy8g6Kem5Y+R5Y+Y5pu06YCa55+lXG4gICAgICAgIGlmIChtb2RlbCkge1xuICAgICAgICAgIHRoaXMudG9rZW5TZXJ2aWNlLnNldChtb2RlbCk7XG4gICAgICAgIH1cblxuICAgICAgICB0aGlzLm9ic2VydmVyLm5leHQobW9kZWwpO1xuICAgICAgICB0aGlzLm9ic2VydmVyLmNvbXBsZXRlKCk7XG4gICAgICB9XG4gICAgfSwgMTAwKTtcbiAgICByZXR1cm4gT2JzZXJ2YWJsZS5jcmVhdGUoKG9ic2VydmVyOiBPYnNlcnZlcjxJVG9rZW5Nb2RlbD4pID0+IHtcbiAgICAgIHRoaXMub2JzZXJ2ZXIgPSBvYnNlcnZlcjtcbiAgICB9KTtcbiAgfVxuXG4gIC8qKlxuICAgKiDmjojmnYPmiJDlip/lkI7nmoTlm57osIPlpITnkIZcbiAgICpcbiAgICogQHBhcmFtIHJhd0RhdGEg5oyH5a6a5Zue6LCD6K6k6K+B5L+h5oGv77yM5Li656m65pe25LuO5qC55o2u5b2T5YmNVVJM6Kej5p6QXG4gICAqL1xuICBjYWxsYmFjayhyYXdEYXRhPzogc3RyaW5nIHwgSVRva2VuTW9kZWwpOiBJVG9rZW5Nb2RlbCB7XG4gICAgLy8gZnJvbSB1cmlcbiAgICBpZiAoIXJhd0RhdGEgJiYgdGhpcy5yb3V0ZXIudXJsLmluZGV4T2YoJz8nKSA9PT0gLTEpIHtcbiAgICAgIHRocm93IG5ldyBFcnJvcihgdXJsIG11c2UgY29udGFpbiBhID9gKTtcbiAgICB9XG4gICAgLy8gcGFyc2VcbiAgICBsZXQgZGF0YTogSVRva2VuTW9kZWwgPSB7IHRva2VuOiBgYCB9O1xuICAgIGlmICh0eXBlb2YgcmF3RGF0YSA9PT0gJ3N0cmluZycpIHtcbiAgICAgIGNvbnN0IHJpZ2h0VXJsID0gcmF3RGF0YS5zcGxpdCgnPycpWzFdLnNwbGl0KCcjJylbMF07XG4gICAgICBkYXRhID0gdGhpcy5yb3V0ZXIucGFyc2VVcmwoJy4vPycgKyByaWdodFVybCkucXVlcnlQYXJhbXMgYXMgSVRva2VuTW9kZWw7XG4gICAgfSBlbHNlIHtcbiAgICAgIGRhdGEgPSByYXdEYXRhO1xuICAgIH1cblxuICAgIGlmICghZGF0YSB8fCAhZGF0YS50b2tlbikgdGhyb3cgbmV3IEVycm9yKGBpbnZhbGlkZSB0b2tlbiBkYXRhYCk7XG4gICAgdGhpcy50b2tlblNlcnZpY2Uuc2V0KGRhdGEpO1xuXG4gICAgY29uc3QgdXJsID0gbG9jYWxTdG9yYWdlLmdldEl0ZW0oSFJFRkNBTExCQUNLKSB8fCAnLyc7XG4gICAgbG9jYWxTdG9yYWdlLnJlbW92ZUl0ZW0oSFJFRkNBTExCQUNLKTtcbiAgICBjb25zdCB0eXBlID0gbG9jYWxTdG9yYWdlLmdldEl0ZW0oT1BFTlRZUEUpO1xuICAgIGxvY2FsU3RvcmFnZS5yZW1vdmVJdGVtKE9QRU5UWVBFKTtcbiAgICBpZiAodHlwZSA9PT0gJ3dpbmRvdycpIHtcbiAgICAgIHdpbmRvdy5jbG9zZSgpO1xuICAgIH0gZWxzZSB7XG4gICAgICB0aGlzLnJvdXRlci5uYXZpZ2F0ZUJ5VXJsKHVybCk7XG4gICAgfVxuXG4gICAgcmV0dXJuIGRhdGE7XG4gIH1cblxuICBuZ09uRGVzdHJveSgpOiB2b2lkIHtcbiAgICBjbGVhckludGVydmFsKHRoaXMuX3dpblRpbWUpO1xuICAgIHRoaXMuX3dpblRpbWUgPSBudWxsO1xuICB9XG59XG4iXX0=