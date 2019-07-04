/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @return {?}
 */
export function preloaderFinished() {
    /** @type {?} */
    var body = document.querySelector('body');
    /** @type {?} */
    var preloader = document.querySelector('.preloader');
    body.style.overflow = 'hidden';
    /**
     * @return {?}
     */
    function remove() {
        // preloader value null when running --hmr
        if (!preloader)
            return;
        preloader.addEventListener('transitionend', (/**
         * @return {?}
         */
        function () {
            preloader.className = 'preloader-hidden';
        }));
        preloader.className += ' preloader-hidden-add preloader-hidden-add-active';
    }
    ((/** @type {?} */ (window))).appBootstrap = (/**
     * @return {?}
     */
    function () {
        setTimeout((/**
         * @return {?}
         */
        function () {
            remove();
            body.style.overflow = '';
        }), 100);
    });
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicHJlbG9hZGVyLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL3RoZW1lLyIsInNvdXJjZXMiOlsic3JjL3NlcnZpY2VzL3ByZWxvYWRlci9wcmVsb2FkZXIudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7OztBQUFBLE1BQU0sVUFBVSxpQkFBaUI7O1FBQ3pCLElBQUksR0FBRyxRQUFRLENBQUMsYUFBYSxDQUFDLE1BQU0sQ0FBQzs7UUFDckMsU0FBUyxHQUFHLFFBQVEsQ0FBQyxhQUFhLENBQUMsWUFBWSxDQUFDO0lBRXRELElBQUksQ0FBQyxLQUFLLENBQUMsUUFBUSxHQUFHLFFBQVEsQ0FBQzs7OztJQUUvQixTQUFTLE1BQU07UUFDYiwwQ0FBMEM7UUFDMUMsSUFBSSxDQUFDLFNBQVM7WUFBRSxPQUFPO1FBQ3ZCLFNBQVMsQ0FBQyxnQkFBZ0IsQ0FBQyxlQUFlOzs7UUFBRTtZQUMxQyxTQUFTLENBQUMsU0FBUyxHQUFHLGtCQUFrQixDQUFDO1FBQzNDLENBQUMsRUFBQyxDQUFDO1FBRUgsU0FBUyxDQUFDLFNBQVMsSUFBSSxtREFBbUQsQ0FBQztJQUM3RSxDQUFDO0lBRUQsQ0FBQyxtQkFBQSxNQUFNLEVBQU8sQ0FBQyxDQUFDLFlBQVk7OztJQUFHO1FBQzdCLFVBQVU7OztRQUFDO1lBQ1QsTUFBTSxFQUFFLENBQUM7WUFDVCxJQUFJLENBQUMsS0FBSyxDQUFDLFFBQVEsR0FBRyxFQUFFLENBQUM7UUFDM0IsQ0FBQyxHQUFFLEdBQUcsQ0FBQyxDQUFDO0lBQ1YsQ0FBQyxDQUFBLENBQUM7QUFDSixDQUFDIiwic291cmNlc0NvbnRlbnQiOlsiZXhwb3J0IGZ1bmN0aW9uIHByZWxvYWRlckZpbmlzaGVkKCkge1xuICBjb25zdCBib2R5ID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvcignYm9keScpO1xuICBjb25zdCBwcmVsb2FkZXIgPSBkb2N1bWVudC5xdWVyeVNlbGVjdG9yKCcucHJlbG9hZGVyJyk7XG5cbiAgYm9keS5zdHlsZS5vdmVyZmxvdyA9ICdoaWRkZW4nO1xuXG4gIGZ1bmN0aW9uIHJlbW92ZSgpIHtcbiAgICAvLyBwcmVsb2FkZXIgdmFsdWUgbnVsbCB3aGVuIHJ1bm5pbmcgLS1obXJcbiAgICBpZiAoIXByZWxvYWRlcikgcmV0dXJuO1xuICAgIHByZWxvYWRlci5hZGRFdmVudExpc3RlbmVyKCd0cmFuc2l0aW9uZW5kJywgZnVuY3Rpb24gKCkge1xuICAgICAgcHJlbG9hZGVyLmNsYXNzTmFtZSA9ICdwcmVsb2FkZXItaGlkZGVuJztcbiAgICB9KTtcblxuICAgIHByZWxvYWRlci5jbGFzc05hbWUgKz0gJyBwcmVsb2FkZXItaGlkZGVuLWFkZCBwcmVsb2FkZXItaGlkZGVuLWFkZC1hY3RpdmUnO1xuICB9XG5cbiAgKHdpbmRvdyBhcyBhbnkpLmFwcEJvb3RzdHJhcCA9ICgpID0+IHtcbiAgICBzZXRUaW1lb3V0KCgpID0+IHtcbiAgICAgIHJlbW92ZSgpO1xuICAgICAgYm9keS5zdHlsZS5vdmVyZmxvdyA9ICcnO1xuICAgIH0sIDEwMCk7XG4gIH07XG59XG4iXX0=