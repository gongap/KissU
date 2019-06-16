/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @license
 * Copyright Google LLC All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
/**
 * Creates a browser MouseEvent with the specified options.
 * @param {?} type
 * @param {?=} x
 * @param {?=} y
 * @return {?}
 */
export function createMouseEvent(type, x = 0, y = 0) {
    /** @type {?} */
    const event = document.createEvent('MouseEvent');
    event.initMouseEvent(type, false /* canBubble */, false /* cancelable */, window /* view */, 0 /* detail */, x /* screenX */, y /* screenY */, x /* clientX */, y /* clientY */, false /* ctrlKey */, false /* altKey */, false /* shiftKey */, false /* metaKey */, 0 /* button */, null /* relatedTarget */);
    return event;
}
/**
 * Creates a browser TouchEvent with the specified pointer coordinates.
 * @param {?} type
 * @param {?=} pageX
 * @param {?=} pageY
 * @return {?}
 */
export function createTouchEvent(type, pageX = 0, pageY = 0) {
    // In favor of creating events that work for most of the browsers, the event is created
    // as a basic UI Event. The necessary details for the event will be set manually.
    /** @type {?} */
    const event = document.createEvent('UIEvent');
    /** @type {?} */
    const touchDetails = { pageX, pageY };
    event.initUIEvent(type, true, true, window, 0);
    // Most of the browsers don't have a "initTouchEvent" method that can be used to define
    // the touch details.
    Object.defineProperties(event, {
        touches: { value: [touchDetails] }
    });
    return (/** @type {?} */ (event));
}
/**
 * Dispatches a keydown event from an element.
 * @param {?} type
 * @param {?} keyCode
 * @param {?=} target
 * @param {?=} key
 * @return {?}
 */
export function createKeyboardEvent(type, keyCode, target, key) {
    /** @type {?} */
    const event = (/** @type {?} */ (document.createEvent('KeyboardEvent')));
    // Firefox does not support `initKeyboardEvent`, but supports `initKeyEvent`.
    /** @type {?} */
    const initEventFn = (event.initKeyEvent || event.initKeyboardEvent).bind(event);
    /** @type {?} */
    const originalPreventDefault = event.preventDefault;
    initEventFn(type, true, true, window, 0, 0, 0, 0, 0, keyCode);
    // Webkit Browsers don't set the keyCode when calling the init function.
    // See related bug https://bugs.webkit.org/show_bug.cgi?id=16735
    Object.defineProperties(event, {
        keyCode: { get: (/**
             * @return {?}
             */
            () => keyCode) },
        key: { get: (/**
             * @return {?}
             */
            () => key) },
        target: { get: (/**
             * @return {?}
             */
            () => target) }
    });
    // IE won't set `defaultPrevented` on synthetic events so we need to do it manually.
    event.preventDefault = (/**
     * @return {?}
     */
    function () {
        Object.defineProperty(event, 'defaultPrevented', { get: (/**
             * @return {?}
             */
            () => true) });
        return originalPreventDefault.apply(this, arguments);
    });
    return event;
}
/**
 * Creates a fake event object with any desired event type.
 * @param {?} type
 * @param {?=} canBubble
 * @param {?=} cancelable
 * @return {?}
 */
export function createFakeEvent(type, canBubble = true, cancelable = true) {
    /** @type {?} */
    const event = document.createEvent('Event');
    event.initEvent(type, canBubble, cancelable);
    return event;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiZXZlbnQtb2JqZWN0cy5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvY29yZS8iLCJzb3VyY2VzIjpbInRlc3RpbmcvZXZlbnQtb2JqZWN0cy50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7Ozs7Ozs7QUFTQSxNQUFNLFVBQVUsZ0JBQWdCLENBQUMsSUFBWSxFQUFFLENBQUMsR0FBRyxDQUFDLEVBQUUsQ0FBQyxHQUFHLENBQUM7O1VBQ25ELEtBQUssR0FBRyxRQUFRLENBQUMsV0FBVyxDQUFDLFlBQVksQ0FBQztJQUVoRCxLQUFLLENBQUMsY0FBYyxDQUNsQixJQUFJLEVBQ0osS0FBSyxDQUFDLGVBQWUsRUFDckIsS0FBSyxDQUFDLGdCQUFnQixFQUN0QixNQUFNLENBQUMsVUFBVSxFQUNqQixDQUFDLENBQUMsWUFBWSxFQUNkLENBQUMsQ0FBQyxhQUFhLEVBQ2YsQ0FBQyxDQUFDLGFBQWEsRUFDZixDQUFDLENBQUMsYUFBYSxFQUNmLENBQUMsQ0FBQyxhQUFhLEVBQ2YsS0FBSyxDQUFDLGFBQWEsRUFDbkIsS0FBSyxDQUFDLFlBQVksRUFDbEIsS0FBSyxDQUFDLGNBQWMsRUFDcEIsS0FBSyxDQUFDLGFBQWEsRUFDbkIsQ0FBQyxDQUFDLFlBQVksRUFDZCxJQUFJLENBQUMsbUJBQW1CLENBQ3pCLENBQUM7SUFFRixPQUFPLEtBQUssQ0FBQztBQUNmLENBQUM7Ozs7Ozs7O0FBR0QsTUFBTSxVQUFVLGdCQUFnQixDQUFDLElBQVksRUFBRSxRQUFnQixDQUFDLEVBQUUsUUFBZ0IsQ0FBQzs7OztVQUczRSxLQUFLLEdBQUcsUUFBUSxDQUFDLFdBQVcsQ0FBQyxTQUFTLENBQUM7O1VBQ3ZDLFlBQVksR0FBRyxFQUFFLEtBQUssRUFBRSxLQUFLLEVBQUU7SUFFckMsS0FBSyxDQUFDLFdBQVcsQ0FBQyxJQUFJLEVBQUUsSUFBSSxFQUFFLElBQUksRUFBRSxNQUFNLEVBQUUsQ0FBQyxDQUFDLENBQUM7SUFFL0MsdUZBQXVGO0lBQ3ZGLHFCQUFxQjtJQUNyQixNQUFNLENBQUMsZ0JBQWdCLENBQUMsS0FBSyxFQUFFO1FBQzdCLE9BQU8sRUFBRSxFQUFFLEtBQUssRUFBRSxDQUFDLFlBQVksQ0FBQyxFQUFFO0tBQ25DLENBQUMsQ0FBQztJQUVILE9BQU8sbUJBQUEsS0FBSyxFQUFXLENBQUM7QUFDMUIsQ0FBQzs7Ozs7Ozs7O0FBR0QsTUFBTSxVQUFVLG1CQUFtQixDQUFDLElBQVksRUFBRSxPQUFlLEVBQUUsTUFBZ0IsRUFBRSxHQUFZOztVQUN6RixLQUFLLEdBQUcsbUJBQUEsUUFBUSxDQUFDLFdBQVcsQ0FBQyxlQUFlLENBQUMsRUFBTzs7O1VBRXBELFdBQVcsR0FBRyxDQUFDLEtBQUssQ0FBQyxZQUFZLElBQUksS0FBSyxDQUFDLGlCQUFpQixDQUFDLENBQUMsSUFBSSxDQUFDLEtBQUssQ0FBQzs7VUFDekUsc0JBQXNCLEdBQUcsS0FBSyxDQUFDLGNBQWM7SUFFbkQsV0FBVyxDQUFDLElBQUksRUFBRSxJQUFJLEVBQUUsSUFBSSxFQUFFLE1BQU0sRUFBRSxDQUFDLEVBQUUsQ0FBQyxFQUFFLENBQUMsRUFBRSxDQUFDLEVBQUUsQ0FBQyxFQUFFLE9BQU8sQ0FBQyxDQUFDO0lBRTlELHdFQUF3RTtJQUN4RSxnRUFBZ0U7SUFDaEUsTUFBTSxDQUFDLGdCQUFnQixDQUFDLEtBQUssRUFBRTtRQUM3QixPQUFPLEVBQUUsRUFBRSxHQUFHOzs7WUFBRSxHQUFHLEVBQUUsQ0FBQyxPQUFPLENBQUEsRUFBRTtRQUMvQixHQUFHLEVBQUUsRUFBRSxHQUFHOzs7WUFBRSxHQUFHLEVBQUUsQ0FBQyxHQUFHLENBQUEsRUFBRTtRQUN2QixNQUFNLEVBQUUsRUFBRSxHQUFHOzs7WUFBRSxHQUFHLEVBQUUsQ0FBQyxNQUFNLENBQUEsRUFBRTtLQUM5QixDQUFDLENBQUM7SUFFSCxvRkFBb0Y7SUFDcEYsS0FBSyxDQUFDLGNBQWM7OztJQUFHO1FBQ3JCLE1BQU0sQ0FBQyxjQUFjLENBQUMsS0FBSyxFQUFFLGtCQUFrQixFQUFFLEVBQUUsR0FBRzs7O1lBQUUsR0FBRyxFQUFFLENBQUMsSUFBSSxDQUFBLEVBQUUsQ0FBQyxDQUFDO1FBQ3RFLE9BQU8sc0JBQXNCLENBQUMsS0FBSyxDQUFDLElBQUksRUFBRSxTQUFTLENBQUMsQ0FBQztJQUN2RCxDQUFDLENBQUEsQ0FBQztJQUVGLE9BQU8sS0FBSyxDQUFDO0FBQ2YsQ0FBQzs7Ozs7Ozs7QUFHRCxNQUFNLFVBQVUsZUFBZSxDQUFDLElBQVksRUFBRSxZQUFxQixJQUFJLEVBQUUsYUFBc0IsSUFBSTs7VUFDM0YsS0FBSyxHQUFHLFFBQVEsQ0FBQyxXQUFXLENBQUMsT0FBTyxDQUFDO0lBQzNDLEtBQUssQ0FBQyxTQUFTLENBQUMsSUFBSSxFQUFFLFNBQVMsRUFBRSxVQUFVLENBQUMsQ0FBQztJQUM3QyxPQUFPLEtBQUssQ0FBQztBQUNmLENBQUMiLCJzb3VyY2VzQ29udGVudCI6WyIvKipcbiAqIEBsaWNlbnNlXG4gKiBDb3B5cmlnaHQgR29vZ2xlIExMQyBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vYW5ndWxhci5pby9saWNlbnNlXG4gKi9cblxuLyoqIENyZWF0ZXMgYSBicm93c2VyIE1vdXNlRXZlbnQgd2l0aCB0aGUgc3BlY2lmaWVkIG9wdGlvbnMuICovXG5leHBvcnQgZnVuY3Rpb24gY3JlYXRlTW91c2VFdmVudCh0eXBlOiBzdHJpbmcsIHggPSAwLCB5ID0gMCk6IE1vdXNlRXZlbnQge1xuICBjb25zdCBldmVudCA9IGRvY3VtZW50LmNyZWF0ZUV2ZW50KCdNb3VzZUV2ZW50Jyk7XG5cbiAgZXZlbnQuaW5pdE1vdXNlRXZlbnQoXG4gICAgdHlwZSxcbiAgICBmYWxzZSAvKiBjYW5CdWJibGUgKi8sXG4gICAgZmFsc2UgLyogY2FuY2VsYWJsZSAqLyxcbiAgICB3aW5kb3cgLyogdmlldyAqLyxcbiAgICAwIC8qIGRldGFpbCAqLyxcbiAgICB4IC8qIHNjcmVlblggKi8sXG4gICAgeSAvKiBzY3JlZW5ZICovLFxuICAgIHggLyogY2xpZW50WCAqLyxcbiAgICB5IC8qIGNsaWVudFkgKi8sXG4gICAgZmFsc2UgLyogY3RybEtleSAqLyxcbiAgICBmYWxzZSAvKiBhbHRLZXkgKi8sXG4gICAgZmFsc2UgLyogc2hpZnRLZXkgKi8sXG4gICAgZmFsc2UgLyogbWV0YUtleSAqLyxcbiAgICAwIC8qIGJ1dHRvbiAqLyxcbiAgICBudWxsIC8qIHJlbGF0ZWRUYXJnZXQgKi9cbiAgKTtcblxuICByZXR1cm4gZXZlbnQ7XG59XG5cbi8qKiBDcmVhdGVzIGEgYnJvd3NlciBUb3VjaEV2ZW50IHdpdGggdGhlIHNwZWNpZmllZCBwb2ludGVyIGNvb3JkaW5hdGVzLiAqL1xuZXhwb3J0IGZ1bmN0aW9uIGNyZWF0ZVRvdWNoRXZlbnQodHlwZTogc3RyaW5nLCBwYWdlWDogbnVtYmVyID0gMCwgcGFnZVk6IG51bWJlciA9IDApOiBVSUV2ZW50IHtcbiAgLy8gSW4gZmF2b3Igb2YgY3JlYXRpbmcgZXZlbnRzIHRoYXQgd29yayBmb3IgbW9zdCBvZiB0aGUgYnJvd3NlcnMsIHRoZSBldmVudCBpcyBjcmVhdGVkXG4gIC8vIGFzIGEgYmFzaWMgVUkgRXZlbnQuIFRoZSBuZWNlc3NhcnkgZGV0YWlscyBmb3IgdGhlIGV2ZW50IHdpbGwgYmUgc2V0IG1hbnVhbGx5LlxuICBjb25zdCBldmVudCA9IGRvY3VtZW50LmNyZWF0ZUV2ZW50KCdVSUV2ZW50Jyk7XG4gIGNvbnN0IHRvdWNoRGV0YWlscyA9IHsgcGFnZVgsIHBhZ2VZIH07XG5cbiAgZXZlbnQuaW5pdFVJRXZlbnQodHlwZSwgdHJ1ZSwgdHJ1ZSwgd2luZG93LCAwKTtcblxuICAvLyBNb3N0IG9mIHRoZSBicm93c2VycyBkb24ndCBoYXZlIGEgXCJpbml0VG91Y2hFdmVudFwiIG1ldGhvZCB0aGF0IGNhbiBiZSB1c2VkIHRvIGRlZmluZVxuICAvLyB0aGUgdG91Y2ggZGV0YWlscy5cbiAgT2JqZWN0LmRlZmluZVByb3BlcnRpZXMoZXZlbnQsIHtcbiAgICB0b3VjaGVzOiB7IHZhbHVlOiBbdG91Y2hEZXRhaWxzXSB9XG4gIH0pO1xuXG4gIHJldHVybiBldmVudCBhcyBVSUV2ZW50O1xufVxuXG4vKiogRGlzcGF0Y2hlcyBhIGtleWRvd24gZXZlbnQgZnJvbSBhbiBlbGVtZW50LiAqL1xuZXhwb3J0IGZ1bmN0aW9uIGNyZWF0ZUtleWJvYXJkRXZlbnQodHlwZTogc3RyaW5nLCBrZXlDb2RlOiBudW1iZXIsIHRhcmdldD86IEVsZW1lbnQsIGtleT86IHN0cmluZyk6IEtleWJvYXJkRXZlbnQge1xuICBjb25zdCBldmVudCA9IGRvY3VtZW50LmNyZWF0ZUV2ZW50KCdLZXlib2FyZEV2ZW50JykgYXMgYW55O1xuICAvLyBGaXJlZm94IGRvZXMgbm90IHN1cHBvcnQgYGluaXRLZXlib2FyZEV2ZW50YCwgYnV0IHN1cHBvcnRzIGBpbml0S2V5RXZlbnRgLlxuICBjb25zdCBpbml0RXZlbnRGbiA9IChldmVudC5pbml0S2V5RXZlbnQgfHwgZXZlbnQuaW5pdEtleWJvYXJkRXZlbnQpLmJpbmQoZXZlbnQpO1xuICBjb25zdCBvcmlnaW5hbFByZXZlbnREZWZhdWx0ID0gZXZlbnQucHJldmVudERlZmF1bHQ7XG5cbiAgaW5pdEV2ZW50Rm4odHlwZSwgdHJ1ZSwgdHJ1ZSwgd2luZG93LCAwLCAwLCAwLCAwLCAwLCBrZXlDb2RlKTtcblxuICAvLyBXZWJraXQgQnJvd3NlcnMgZG9uJ3Qgc2V0IHRoZSBrZXlDb2RlIHdoZW4gY2FsbGluZyB0aGUgaW5pdCBmdW5jdGlvbi5cbiAgLy8gU2VlIHJlbGF0ZWQgYnVnIGh0dHBzOi8vYnVncy53ZWJraXQub3JnL3Nob3dfYnVnLmNnaT9pZD0xNjczNVxuICBPYmplY3QuZGVmaW5lUHJvcGVydGllcyhldmVudCwge1xuICAgIGtleUNvZGU6IHsgZ2V0OiAoKSA9PiBrZXlDb2RlIH0sXG4gICAga2V5OiB7IGdldDogKCkgPT4ga2V5IH0sXG4gICAgdGFyZ2V0OiB7IGdldDogKCkgPT4gdGFyZ2V0IH1cbiAgfSk7XG5cbiAgLy8gSUUgd29uJ3Qgc2V0IGBkZWZhdWx0UHJldmVudGVkYCBvbiBzeW50aGV0aWMgZXZlbnRzIHNvIHdlIG5lZWQgdG8gZG8gaXQgbWFudWFsbHkuXG4gIGV2ZW50LnByZXZlbnREZWZhdWx0ID0gZnVuY3Rpb24oKSB7XG4gICAgT2JqZWN0LmRlZmluZVByb3BlcnR5KGV2ZW50LCAnZGVmYXVsdFByZXZlbnRlZCcsIHsgZ2V0OiAoKSA9PiB0cnVlIH0pO1xuICAgIHJldHVybiBvcmlnaW5hbFByZXZlbnREZWZhdWx0LmFwcGx5KHRoaXMsIGFyZ3VtZW50cyk7XG4gIH07XG5cbiAgcmV0dXJuIGV2ZW50O1xufVxuXG4vKiogQ3JlYXRlcyBhIGZha2UgZXZlbnQgb2JqZWN0IHdpdGggYW55IGRlc2lyZWQgZXZlbnQgdHlwZS4gKi9cbmV4cG9ydCBmdW5jdGlvbiBjcmVhdGVGYWtlRXZlbnQodHlwZTogc3RyaW5nLCBjYW5CdWJibGU6IGJvb2xlYW4gPSB0cnVlLCBjYW5jZWxhYmxlOiBib29sZWFuID0gdHJ1ZSk6IEV2ZW50IHtcbiAgY29uc3QgZXZlbnQgPSBkb2N1bWVudC5jcmVhdGVFdmVudCgnRXZlbnQnKTtcbiAgZXZlbnQuaW5pdEV2ZW50KHR5cGUsIGNhbkJ1YmJsZSwgY2FuY2VsYWJsZSk7XG4gIHJldHVybiBldmVudDtcbn1cbiJdfQ==