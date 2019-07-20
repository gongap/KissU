/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @enum {number} */
const ReuseTabMatchMode = {
    /**
     * （推荐）按菜单 `Menu` 配置
     *
     * 可复用：
     * - `{ text:'Dashboard' }`
     * - `{ text:'Dashboard', reuse: true }`
     *
     * 不可复用：
     * - `{ text:'Dashboard', reuse: false }`
     */
    Menu: 0,
    /**
     * 按菜单 `Menu` 强制配置
     *
     * 可复用：
     * - `{ text:'Dashboard', reuse: true }`
     *
     * 不可复用：
     * - `{ text:'Dashboard' }`
     * - `{ text:'Dashboard', reuse: false }`
     */
    MenuForce: 1,
    /**
     * 对所有路由有效，可以配合 `excludes` 过滤无须复用路由
     */
    URL: 2,
};
export { ReuseTabMatchMode };
ReuseTabMatchMode[ReuseTabMatchMode.Menu] = 'Menu';
ReuseTabMatchMode[ReuseTabMatchMode.MenuForce] = 'MenuForce';
ReuseTabMatchMode[ReuseTabMatchMode.URL] = 'URL';
/**
 * @record
 */
export function ReuseTitle() { }
if (false) {
    /** @type {?} */
    ReuseTitle.prototype.text;
    /** @type {?|undefined} */
    ReuseTitle.prototype.i18n;
}
/**
 * @record
 */
export function ReuseTabCached() { }
if (false) {
    /** @type {?} */
    ReuseTabCached.prototype.title;
    /** @type {?} */
    ReuseTabCached.prototype.url;
    /**
     * 是否允许关闭，默认：`true`
     * @type {?|undefined}
     */
    ReuseTabCached.prototype.closable;
    /**
     * 当前滚动条位置
     * @type {?|undefined}
     */
    ReuseTabCached.prototype.position;
    /** @type {?} */
    ReuseTabCached.prototype._snapshot;
    /** @type {?} */
    ReuseTabCached.prototype._handle;
}
/**
 * @record
 */
export function ReuseTabNotify() { }
if (false) {
    /**
     * 事件类型
     * @type {?}
     */
    ReuseTabNotify.prototype.active;
    /* Skipping unhandled member: [key: string]: any;*/
}
/**
 * @record
 */
export function ReuseItem() { }
if (false) {
    /** @type {?} */
    ReuseItem.prototype.url;
    /** @type {?} */
    ReuseItem.prototype.title;
    /** @type {?} */
    ReuseItem.prototype.closable;
    /** @type {?} */
    ReuseItem.prototype.index;
    /** @type {?} */
    ReuseItem.prototype.active;
    /** @type {?} */
    ReuseItem.prototype.last;
}
/**
 * @record
 */
export function ReuseContextEvent() { }
if (false) {
    /** @type {?} */
    ReuseContextEvent.prototype.event;
    /** @type {?} */
    ReuseContextEvent.prototype.item;
    /** @type {?|undefined} */
    ReuseContextEvent.prototype.comp;
    /** @type {?|undefined} */
    ReuseContextEvent.prototype.customContextMenu;
}
/**
 * @record
 */
export function ReuseContextCloseEvent() { }
if (false) {
    /** @type {?} */
    ReuseContextCloseEvent.prototype.type;
    /** @type {?} */
    ReuseContextCloseEvent.prototype.item;
    /** @type {?} */
    ReuseContextCloseEvent.prototype.includeNonCloseable;
}
/**
 * @record
 */
export function ReuseContextI18n() { }
if (false) {
    /** @type {?|undefined} */
    ReuseContextI18n.prototype.close;
    /** @type {?|undefined} */
    ReuseContextI18n.prototype.closeOther;
    /** @type {?|undefined} */
    ReuseContextI18n.prototype.closeRight;
    /** @type {?|undefined} */
    ReuseContextI18n.prototype.clear;
}
/**
 * @record
 */
export function ReuseCustomContextMenu() { }
if (false) {
    /** @type {?} */
    ReuseCustomContextMenu.prototype.id;
    /** @type {?} */
    ReuseCustomContextMenu.prototype.title;
    /** @type {?} */
    ReuseCustomContextMenu.prototype.fn;
    /** @type {?|undefined} */
    ReuseCustomContextMenu.prototype.disabled;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicmV1c2UtdGFiLmludGVyZmFjZXMuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL3JldXNlLXRhYi8iLCJzb3VyY2VzIjpbInJldXNlLXRhYi5pbnRlcmZhY2VzLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7OztJQU9FOzs7Ozs7Ozs7T0FTRztJQUNILE9BQUk7SUFDSjs7Ozs7Ozs7O09BU0c7SUFDSCxZQUFTO0lBQ1Q7O09BRUc7SUFDSCxNQUFHOzs7Ozs7Ozs7QUFHTCxnQ0FHQzs7O0lBRkMsMEJBQWE7O0lBQ2IsMEJBQWM7Ozs7O0FBR2hCLG9DQWNDOzs7SUFiQywrQkFBa0I7O0lBRWxCLDZCQUFZOzs7OztJQUdaLGtDQUFtQjs7Ozs7SUFHbkIsa0NBQTRCOztJQUU1QixtQ0FBa0M7O0lBRWxDLGlDQUFhOzs7OztBQUdmLG9DQUtDOzs7Ozs7SUFIQyxnQ0FBZTs7Ozs7O0FBS2pCLCtCQU9DOzs7SUFOQyx3QkFBWTs7SUFDWiwwQkFBYzs7SUFDZCw2QkFBa0I7O0lBQ2xCLDBCQUFjOztJQUNkLDJCQUFnQjs7SUFDaEIseUJBQWM7Ozs7O0FBR2hCLHVDQUtDOzs7SUFKQyxrQ0FBa0I7O0lBQ2xCLGlDQUFnQjs7SUFDaEIsaUNBQWdDOztJQUNoQyw4Q0FBNkM7Ozs7O0FBSy9DLDRDQUlDOzs7SUFIQyxzQ0FBZ0I7O0lBQ2hCLHNDQUFnQjs7SUFDaEIscURBQTZCOzs7OztBQUcvQixzQ0FLQzs7O0lBSkMsaUNBQWU7O0lBQ2Ysc0NBQW9COztJQUNwQixzQ0FBb0I7O0lBQ3BCLGlDQUFlOzs7OztBQUdqQiw0Q0FLQzs7O0lBSkMsb0NBQVc7O0lBQ1gsdUNBQWM7O0lBQ2Qsb0NBQTREOztJQUM1RCwwQ0FBd0MiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBBY3RpdmF0ZWRSb3V0ZVNuYXBzaG90IH0gZnJvbSAnQGFuZ3VsYXIvcm91dGVyJztcbmltcG9ydCB7IFJldXNlVGFiQ29udGV4dENvbXBvbmVudCB9IGZyb20gJy4vcmV1c2UtdGFiLWNvbnRleHQuY29tcG9uZW50JztcblxuLyoqXG4gKiDlpI3nlKjljLnphY3mqKHlvI9cbiAqL1xuZXhwb3J0IGVudW0gUmV1c2VUYWJNYXRjaE1vZGUge1xuICAvKipcbiAgICog77yI5o6o6I2Q77yJ5oyJ6I+c5Y2VIGBNZW51YCDphY3nva5cbiAgICpcbiAgICog5Y+v5aSN55So77yaXG4gICAqIC0gYHsgdGV4dDonRGFzaGJvYXJkJyB9YFxuICAgKiAtIGB7IHRleHQ6J0Rhc2hib2FyZCcsIHJldXNlOiB0cnVlIH1gXG4gICAqXG4gICAqIOS4jeWPr+WkjeeUqO+8mlxuICAgKiAtIGB7IHRleHQ6J0Rhc2hib2FyZCcsIHJldXNlOiBmYWxzZSB9YFxuICAgKi9cbiAgTWVudSxcbiAgLyoqXG4gICAqIOaMieiPnOWNlSBgTWVudWAg5by65Yi26YWN572uXG4gICAqXG4gICAqIOWPr+WkjeeUqO+8mlxuICAgKiAtIGB7IHRleHQ6J0Rhc2hib2FyZCcsIHJldXNlOiB0cnVlIH1gXG4gICAqXG4gICAqIOS4jeWPr+WkjeeUqO+8mlxuICAgKiAtIGB7IHRleHQ6J0Rhc2hib2FyZCcgfWBcbiAgICogLSBgeyB0ZXh0OidEYXNoYm9hcmQnLCByZXVzZTogZmFsc2UgfWBcbiAgICovXG4gIE1lbnVGb3JjZSxcbiAgLyoqXG4gICAqIOWvueaJgOaciei3r+eUseacieaViO+8jOWPr+S7pemFjeWQiCBgZXhjbHVkZXNgIOi/h+a7pOaXoOmhu+WkjeeUqOi3r+eUsVxuICAgKi9cbiAgVVJMLFxufVxuXG5leHBvcnQgaW50ZXJmYWNlIFJldXNlVGl0bGUge1xuICB0ZXh0OiBzdHJpbmc7XG4gIGkxOG4/OiBzdHJpbmc7XG59XG5cbmV4cG9ydCBpbnRlcmZhY2UgUmV1c2VUYWJDYWNoZWQge1xuICB0aXRsZTogUmV1c2VUaXRsZTtcblxuICB1cmw6IHN0cmluZztcblxuICAvKiog5piv5ZCm5YWB6K645YWz6Zet77yM6buY6K6k77yaYHRydWVgICovXG4gIGNsb3NhYmxlPzogYm9vbGVhbjtcblxuICAvKiog5b2T5YmN5rua5Yqo5p2h5L2N572uICovXG4gIHBvc2l0aW9uPzogW251bWJlciwgbnVtYmVyXTtcblxuICBfc25hcHNob3Q6IEFjdGl2YXRlZFJvdXRlU25hcHNob3Q7XG5cbiAgX2hhbmRsZTogYW55O1xufVxuXG5leHBvcnQgaW50ZXJmYWNlIFJldXNlVGFiTm90aWZ5IHtcbiAgLyoqIOS6i+S7tuexu+WeiyAqL1xuICBhY3RpdmU6IHN0cmluZztcblxuICBba2V5OiBzdHJpbmddOiBhbnk7XG59XG5cbmV4cG9ydCBpbnRlcmZhY2UgUmV1c2VJdGVtIHtcbiAgdXJsOiBzdHJpbmc7XG4gIHRpdGxlOiBzdHJpbmc7XG4gIGNsb3NhYmxlOiBib29sZWFuO1xuICBpbmRleDogbnVtYmVyO1xuICBhY3RpdmU6IGJvb2xlYW47XG4gIGxhc3Q6IGJvb2xlYW47XG59XG5cbmV4cG9ydCBpbnRlcmZhY2UgUmV1c2VDb250ZXh0RXZlbnQge1xuICBldmVudDogTW91c2VFdmVudDtcbiAgaXRlbTogUmV1c2VJdGVtO1xuICBjb21wPzogUmV1c2VUYWJDb250ZXh0Q29tcG9uZW50O1xuICBjdXN0b21Db250ZXh0TWVudT86IFJldXNlQ3VzdG9tQ29udGV4dE1lbnVbXTtcbn1cblxuZXhwb3J0IHR5cGUgQ2xvc2VUeXBlID0gJ2Nsb3NlJyB8ICdjbG9zZU90aGVyJyB8ICdjbG9zZVJpZ2h0JyB8ICdjbGVhcicgfCAnY3VzdG9tJyB8IG51bGw7XG5cbmV4cG9ydCBpbnRlcmZhY2UgUmV1c2VDb250ZXh0Q2xvc2VFdmVudCB7XG4gIHR5cGU6IENsb3NlVHlwZTtcbiAgaXRlbTogUmV1c2VJdGVtO1xuICBpbmNsdWRlTm9uQ2xvc2VhYmxlOiBib29sZWFuO1xufVxuXG5leHBvcnQgaW50ZXJmYWNlIFJldXNlQ29udGV4dEkxOG4ge1xuICBjbG9zZT86IHN0cmluZztcbiAgY2xvc2VPdGhlcj86IHN0cmluZztcbiAgY2xvc2VSaWdodD86IHN0cmluZztcbiAgY2xlYXI/OiBzdHJpbmc7XG59XG5cbmV4cG9ydCBpbnRlcmZhY2UgUmV1c2VDdXN0b21Db250ZXh0TWVudSB7XG4gIGlkOiBzdHJpbmc7XG4gIHRpdGxlOiBzdHJpbmc7XG4gIGZuOiAoaXRlbTogUmV1c2VJdGVtLCBtZW51OiBSZXVzZUN1c3RvbUNvbnRleHRNZW51KSA9PiB2b2lkO1xuICBkaXNhYmxlZD86IChpdGVtOiBSZXVzZUl0ZW0pID0+IGJvb2xlYW47XG59XG4iXX0=