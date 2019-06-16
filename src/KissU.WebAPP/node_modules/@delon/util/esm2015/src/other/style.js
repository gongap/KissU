/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @param {?} el
 * @param {?} classMap
 * @param {?} renderer
 * @return {?}
 */
function removeClass(el, classMap, renderer) {
    for (const i in classMap) {
        renderer.removeClass(el, i);
    }
}
/**
 * @param {?} el
 * @param {?} classMap
 * @param {?} renderer
 * @return {?}
 */
function addClass(el, classMap, renderer) {
    for (const i in classMap) {
        if (classMap[i]) {
            renderer.addClass(el, i);
        }
    }
}
/**
 * 更新宿主组件样式 `class`，例如：
 *
 * ```ts
 * updateHostClass(
 *  this.el.nativeElement,
 *  this.renderer,
 *  {
 *    [ 'classname' ]: true,
 *    [ 'classname' ]: this.type === '1',
 *    [ this.cls ]: true,
 *    [ `a-${this.cls}` ]: true
 *  })
 * ```
 *
 * @param {?} el
 * @param {?} renderer
 * @param {?} classMap
 * @param {?=} cleanAll
 * @return {?}
 */
export function updateHostClass(el, renderer, classMap, cleanAll = false) {
    if (cleanAll === true) {
        renderer.removeAttribute(el, 'class');
    }
    else {
        removeClass(el, classMap, renderer);
    }
    classMap = Object.assign({}, classMap);
    addClass(el, classMap, renderer);
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoic3R5bGUuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vdXRpbC8iLCJzb3VyY2VzIjpbInNyYy9vdGhlci9zdHlsZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7O0FBRUEsU0FBUyxXQUFXLENBQUMsRUFBZSxFQUFFLFFBQWdCLEVBQUUsUUFBbUI7SUFDekUsS0FBSyxNQUFNLENBQUMsSUFBSSxRQUFRLEVBQUU7UUFDeEIsUUFBUSxDQUFDLFdBQVcsQ0FBQyxFQUFFLEVBQUUsQ0FBQyxDQUFDLENBQUM7S0FDN0I7QUFDSCxDQUFDOzs7Ozs7O0FBRUQsU0FBUyxRQUFRLENBQUMsRUFBZSxFQUFFLFFBQWdCLEVBQUUsUUFBbUI7SUFDdEUsS0FBSyxNQUFNLENBQUMsSUFBSSxRQUFRLEVBQUU7UUFDeEIsSUFBSSxRQUFRLENBQUMsQ0FBQyxDQUFDLEVBQUU7WUFDZixRQUFRLENBQUMsUUFBUSxDQUFDLEVBQUUsRUFBRSxDQUFDLENBQUMsQ0FBQztTQUMxQjtLQUNGO0FBQ0gsQ0FBQzs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztBQW1CRCxNQUFNLFVBQVUsZUFBZSxDQUM3QixFQUFlLEVBQ2YsUUFBbUIsRUFDbkIsUUFBZ0IsRUFDaEIsV0FBb0IsS0FBSztJQUV6QixJQUFJLFFBQVEsS0FBSyxJQUFJLEVBQUU7UUFDckIsUUFBUSxDQUFDLGVBQWUsQ0FBQyxFQUFFLEVBQUUsT0FBTyxDQUFDLENBQUM7S0FDdkM7U0FBTTtRQUNMLFdBQVcsQ0FBQyxFQUFFLEVBQUUsUUFBUSxFQUFFLFFBQVEsQ0FBQyxDQUFDO0tBQ3JDO0lBQ0QsUUFBUSxxQkFBUSxRQUFRLENBQUUsQ0FBQztJQUMzQixRQUFRLENBQUMsRUFBRSxFQUFFLFFBQVEsRUFBRSxRQUFRLENBQUMsQ0FBQztBQUNuQyxDQUFDIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgUmVuZGVyZXIyIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmZ1bmN0aW9uIHJlbW92ZUNsYXNzKGVsOiBIVE1MRWxlbWVudCwgY2xhc3NNYXA6IG9iamVjdCwgcmVuZGVyZXI6IFJlbmRlcmVyMik6IHZvaWQge1xuICBmb3IgKGNvbnN0IGkgaW4gY2xhc3NNYXApIHtcbiAgICByZW5kZXJlci5yZW1vdmVDbGFzcyhlbCwgaSk7XG4gIH1cbn1cblxuZnVuY3Rpb24gYWRkQ2xhc3MoZWw6IEhUTUxFbGVtZW50LCBjbGFzc01hcDogb2JqZWN0LCByZW5kZXJlcjogUmVuZGVyZXIyKTogdm9pZCB7XG4gIGZvciAoY29uc3QgaSBpbiBjbGFzc01hcCkge1xuICAgIGlmIChjbGFzc01hcFtpXSkge1xuICAgICAgcmVuZGVyZXIuYWRkQ2xhc3MoZWwsIGkpO1xuICAgIH1cbiAgfVxufVxuXG4vKipcbiAqIOabtOaWsOWuv+S4u+e7hOS7tuagt+W8jyBgY2xhc3Ng77yM5L6L5aaC77yaXG4gKlxuICogYGBgdHNcbiAqIHVwZGF0ZUhvc3RDbGFzcyhcbiAqICB0aGlzLmVsLm5hdGl2ZUVsZW1lbnQsXG4gKiAgdGhpcy5yZW5kZXJlcixcbiAqICB7XG4gKiAgICBbICdjbGFzc25hbWUnIF06IHRydWUsXG4gKiAgICBbICdjbGFzc25hbWUnIF06IHRoaXMudHlwZSA9PT0gJzEnLFxuICogICAgWyB0aGlzLmNscyBdOiB0cnVlLFxuICogICAgWyBgYS0ke3RoaXMuY2xzfWAgXTogdHJ1ZVxuICogIH0pXG4gKiBgYGBcbiAqXG4gKiBAcGFyYW0gW2NsZWFuQWxsXSDmmK/lkKblhYjmuIXnkIbmiYDmnIkgYGNsYXNzYCDlgLzvvIzpu5jorqTvvJpgZmFsc2VgXG4gKi9cbmV4cG9ydCBmdW5jdGlvbiB1cGRhdGVIb3N0Q2xhc3MoXG4gIGVsOiBIVE1MRWxlbWVudCxcbiAgcmVuZGVyZXI6IFJlbmRlcmVyMixcbiAgY2xhc3NNYXA6IG9iamVjdCxcbiAgY2xlYW5BbGw6IGJvb2xlYW4gPSBmYWxzZSxcbik6IHZvaWQge1xuICBpZiAoY2xlYW5BbGwgPT09IHRydWUpIHtcbiAgICByZW5kZXJlci5yZW1vdmVBdHRyaWJ1dGUoZWwsICdjbGFzcycpO1xuICB9IGVsc2Uge1xuICAgIHJlbW92ZUNsYXNzKGVsLCBjbGFzc01hcCwgcmVuZGVyZXIpO1xuICB9XG4gIGNsYXNzTWFwID0geyAuLi5jbGFzc01hcCB9O1xuICBhZGRDbGFzcyhlbCwgY2xhc3NNYXAsIHJlbmRlcmVyKTtcbn1cbiJdfQ==