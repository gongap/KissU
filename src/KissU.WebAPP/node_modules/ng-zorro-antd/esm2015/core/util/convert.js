/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { coerceBooleanProperty, coerceCssPixelValue, _isNumberValue } from '@angular/cdk/coercion';
/**
 * @param {?} value
 * @return {?}
 */
export function toBoolean(value) {
    return coerceBooleanProperty(value);
}
/**
 * @param {?} value
 * @param {?=} fallbackValue
 * @return {?}
 */
export function toNumber(value, fallbackValue = 0) {
    return _isNumberValue(value) ? Number(value) : fallbackValue;
}
/**
 * @param {?} value
 * @return {?}
 */
export function toCssPixel(value) {
    return coerceCssPixelValue(value);
}
/**
 * Get the function-property type's value
 * @template T
 * @param {?} prop
 * @param {...?} args
 * @return {?}
 */
// tslint:disable-next-line: no-any
export function valueFunctionProp(prop, ...args) {
    return typeof prop === 'function' ? prop(...args) : prop;
}
// tslint:disable-next-line: no-any
/**
 * @template T, D
 * @param {?} name
 * @param {?} fallback
 * @return {?}
 */
function propDecoratorFactory(name, fallback) {
    // tslint:disable-next-line: no-any
    /**
     * @param {?} target
     * @param {?} propName
     * @return {?}
     */
    function propDecorator(target, propName) {
        /** @type {?} */
        const privatePropName = `$$__${propName}`;
        if (Object.prototype.hasOwnProperty.call(target, privatePropName)) {
            console.warn(`The prop "${privatePropName}" is already exist, it will be overrided by ${name} decorator.`);
        }
        Object.defineProperty(target, privatePropName, {
            configurable: true,
            writable: true
        });
        Object.defineProperty(target, propName, {
            /**
             * @return {?}
             */
            get() {
                return this[privatePropName]; // tslint:disable-line:no-invalid-this
            },
            /**
             * @param {?} value
             * @return {?}
             */
            set(value) {
                this[privatePropName] = fallback(value); // tslint:disable-line:no-invalid-this
            }
        });
    }
    return propDecorator;
}
/**
 * Input decorator that handle a prop to do get/set automatically with toBoolean
 *
 * Why not using \@InputBoolean alone without \@Input? AOT needs \@Input to be visible
 *
 * \@howToUse
 * ```
 * \@Input() \@InputBoolean() visible: boolean = false;
 *
 * // Act as below:
 * // \@Input()
 * // get visible() { return this.__visible; }
 * // set visible(value) { this.__visible = value; }
 * // __visible = false;
 * ```
 * @return {?}
 */
// tslint:disable-next-line: no-any
export function InputBoolean() {
    return propDecoratorFactory('InputBoolean', toBoolean);
}
// tslint:disable-next-line: no-any
/**
 * @return {?}
 */
export function InputCssPixel() {
    return propDecoratorFactory('InputCssPixel', toCssPixel);
}
// tslint:disable-next-line: no-any
/**
 * @return {?}
 */
export function InputNumber() {
    // tslint:disable-line: no-any
    return propDecoratorFactory('InputNumber', toNumber);
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiY29udmVydC5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvY29yZS8iLCJzb3VyY2VzIjpbInV0aWwvY29udmVydC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7OztBQVFBLE9BQU8sRUFBRSxxQkFBcUIsRUFBRSxtQkFBbUIsRUFBRSxjQUFjLEVBQUUsTUFBTSx1QkFBdUIsQ0FBQzs7Ozs7QUFJbkcsTUFBTSxVQUFVLFNBQVMsQ0FBQyxLQUF1QjtJQUMvQyxPQUFPLHFCQUFxQixDQUFDLEtBQUssQ0FBQyxDQUFDO0FBQ3RDLENBQUM7Ozs7OztBQUlELE1BQU0sVUFBVSxRQUFRLENBQUMsS0FBc0IsRUFBRSxnQkFBd0IsQ0FBQztJQUN4RSxPQUFPLGNBQWMsQ0FBQyxLQUFLLENBQUMsQ0FBQyxDQUFDLENBQUMsTUFBTSxDQUFDLEtBQUssQ0FBQyxDQUFDLENBQUMsQ0FBQyxhQUFhLENBQUM7QUFDL0QsQ0FBQzs7Ozs7QUFFRCxNQUFNLFVBQVUsVUFBVSxDQUFDLEtBQXNCO0lBQy9DLE9BQU8sbUJBQW1CLENBQUMsS0FBSyxDQUFDLENBQUM7QUFDcEMsQ0FBQzs7Ozs7Ozs7O0FBTUQsTUFBTSxVQUFVLGlCQUFpQixDQUFJLElBQXFCLEVBQUUsR0FBRyxJQUFXO0lBQ3hFLE9BQU8sT0FBTyxJQUFJLEtBQUssVUFBVSxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsR0FBRyxJQUFJLENBQUMsQ0FBQyxDQUFDLENBQUMsSUFBSSxDQUFDO0FBQzNELENBQUM7Ozs7Ozs7O0FBR0QsU0FBUyxvQkFBb0IsQ0FBTyxJQUFZLEVBQUUsUUFBcUI7Ozs7Ozs7SUFFckUsU0FBUyxhQUFhLENBQUMsTUFBVyxFQUFFLFFBQWdCOztjQUM1QyxlQUFlLEdBQUcsT0FBTyxRQUFRLEVBQUU7UUFFekMsSUFBSSxNQUFNLENBQUMsU0FBUyxDQUFDLGNBQWMsQ0FBQyxJQUFJLENBQUMsTUFBTSxFQUFFLGVBQWUsQ0FBQyxFQUFFO1lBQ2pFLE9BQU8sQ0FBQyxJQUFJLENBQUMsYUFBYSxlQUFlLCtDQUErQyxJQUFJLGFBQWEsQ0FBQyxDQUFDO1NBQzVHO1FBRUQsTUFBTSxDQUFDLGNBQWMsQ0FBQyxNQUFNLEVBQUUsZUFBZSxFQUFFO1lBQzdDLFlBQVksRUFBRSxJQUFJO1lBQ2xCLFFBQVEsRUFBRSxJQUFJO1NBQ2YsQ0FBQyxDQUFDO1FBRUgsTUFBTSxDQUFDLGNBQWMsQ0FBQyxNQUFNLEVBQUUsUUFBUSxFQUFFOzs7O1lBQ3RDLEdBQUc7Z0JBQ0QsT0FBTyxJQUFJLENBQUMsZUFBZSxDQUFDLENBQUMsQ0FBQyxzQ0FBc0M7WUFDdEUsQ0FBQzs7Ozs7WUFDRCxHQUFHLENBQUMsS0FBUTtnQkFDVixJQUFJLENBQUMsZUFBZSxDQUFDLEdBQUcsUUFBUSxDQUFDLEtBQUssQ0FBQyxDQUFDLENBQUMsc0NBQXNDO1lBQ2pGLENBQUM7U0FDRixDQUFDLENBQUM7SUFDTCxDQUFDO0lBRUQsT0FBTyxhQUFhLENBQUM7QUFDdkIsQ0FBQzs7Ozs7Ozs7Ozs7Ozs7Ozs7OztBQW1CRCxNQUFNLFVBQVUsWUFBWTtJQUMxQixPQUFPLG9CQUFvQixDQUFDLGNBQWMsRUFBRSxTQUFTLENBQUMsQ0FBQztBQUN6RCxDQUFDOzs7OztBQUdELE1BQU0sVUFBVSxhQUFhO0lBQzNCLE9BQU8sb0JBQW9CLENBQUMsZUFBZSxFQUFFLFVBQVUsQ0FBQyxDQUFDO0FBQzNELENBQUM7Ozs7O0FBR0QsTUFBTSxVQUFVLFdBQVc7SUFDekIsOEJBQThCO0lBQzlCLE9BQU8sb0JBQW9CLENBQUMsYUFBYSxFQUFFLFFBQVEsQ0FBQyxDQUFDO0FBQ3ZELENBQUMiLCJzb3VyY2VzQ29udGVudCI6WyIvKipcbiAqIEBsaWNlbnNlXG4gKiBDb3B5cmlnaHQgQWxpYmFiYS5jb20gQWxsIFJpZ2h0cyBSZXNlcnZlZC5cbiAqXG4gKiBVc2Ugb2YgdGhpcyBzb3VyY2UgY29kZSBpcyBnb3Zlcm5lZCBieSBhbiBNSVQtc3R5bGUgbGljZW5zZSB0aGF0IGNhbiBiZVxuICogZm91bmQgaW4gdGhlIExJQ0VOU0UgZmlsZSBhdCBodHRwczovL2dpdGh1Yi5jb20vTkctWk9SUk8vbmctem9ycm8tYW50ZC9ibG9iL21hc3Rlci9MSUNFTlNFXG4gKi9cblxuaW1wb3J0IHsgY29lcmNlQm9vbGVhblByb3BlcnR5LCBjb2VyY2VDc3NQaXhlbFZhbHVlLCBfaXNOdW1iZXJWYWx1ZSB9IGZyb20gJ0Bhbmd1bGFyL2Nkay9jb2VyY2lvbic7XG5cbmltcG9ydCB7IEZ1bmN0aW9uUHJvcCB9IGZyb20gJy4uL3R5cGVzL2NvbW1vbi13cmFwJztcblxuZXhwb3J0IGZ1bmN0aW9uIHRvQm9vbGVhbih2YWx1ZTogYm9vbGVhbiB8IHN0cmluZyk6IGJvb2xlYW4ge1xuICByZXR1cm4gY29lcmNlQm9vbGVhblByb3BlcnR5KHZhbHVlKTtcbn1cblxuZXhwb3J0IGZ1bmN0aW9uIHRvTnVtYmVyKHZhbHVlOiBudW1iZXIgfCBzdHJpbmcpOiBudW1iZXI7XG5leHBvcnQgZnVuY3Rpb24gdG9OdW1iZXI8RD4odmFsdWU6IG51bWJlciB8IHN0cmluZywgZmFsbGJhY2s6IEQpOiBudW1iZXIgfCBEO1xuZXhwb3J0IGZ1bmN0aW9uIHRvTnVtYmVyKHZhbHVlOiBudW1iZXIgfCBzdHJpbmcsIGZhbGxiYWNrVmFsdWU6IG51bWJlciA9IDApOiBudW1iZXIge1xuICByZXR1cm4gX2lzTnVtYmVyVmFsdWUodmFsdWUpID8gTnVtYmVyKHZhbHVlKSA6IGZhbGxiYWNrVmFsdWU7XG59XG5cbmV4cG9ydCBmdW5jdGlvbiB0b0Nzc1BpeGVsKHZhbHVlOiBudW1iZXIgfCBzdHJpbmcpOiBzdHJpbmcge1xuICByZXR1cm4gY29lcmNlQ3NzUGl4ZWxWYWx1ZSh2YWx1ZSk7XG59XG5cbi8qKlxuICogR2V0IHRoZSBmdW5jdGlvbi1wcm9wZXJ0eSB0eXBlJ3MgdmFsdWVcbiAqL1xuLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOiBuby1hbnlcbmV4cG9ydCBmdW5jdGlvbiB2YWx1ZUZ1bmN0aW9uUHJvcDxUPihwcm9wOiBGdW5jdGlvblByb3A8VD4sIC4uLmFyZ3M6IGFueVtdKTogVCB7XG4gIHJldHVybiB0eXBlb2YgcHJvcCA9PT0gJ2Z1bmN0aW9uJyA/IHByb3AoLi4uYXJncykgOiBwcm9wO1xufVxuXG4vLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6IG5vLWFueVxuZnVuY3Rpb24gcHJvcERlY29yYXRvckZhY3Rvcnk8VCwgRD4obmFtZTogc3RyaW5nLCBmYWxsYmFjazogKHY6IFQpID0+IEQpOiAodGFyZ2V0OiBhbnksIHByb3BOYW1lOiBzdHJpbmcpID0+IHZvaWQge1xuICAvLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6IG5vLWFueVxuICBmdW5jdGlvbiBwcm9wRGVjb3JhdG9yKHRhcmdldDogYW55LCBwcm9wTmFtZTogc3RyaW5nKTogdm9pZCB7XG4gICAgY29uc3QgcHJpdmF0ZVByb3BOYW1lID0gYCQkX18ke3Byb3BOYW1lfWA7XG5cbiAgICBpZiAoT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsKHRhcmdldCwgcHJpdmF0ZVByb3BOYW1lKSkge1xuICAgICAgY29uc29sZS53YXJuKGBUaGUgcHJvcCBcIiR7cHJpdmF0ZVByb3BOYW1lfVwiIGlzIGFscmVhZHkgZXhpc3QsIGl0IHdpbGwgYmUgb3ZlcnJpZGVkIGJ5ICR7bmFtZX0gZGVjb3JhdG9yLmApO1xuICAgIH1cblxuICAgIE9iamVjdC5kZWZpbmVQcm9wZXJ0eSh0YXJnZXQsIHByaXZhdGVQcm9wTmFtZSwge1xuICAgICAgY29uZmlndXJhYmxlOiB0cnVlLFxuICAgICAgd3JpdGFibGU6IHRydWVcbiAgICB9KTtcblxuICAgIE9iamVjdC5kZWZpbmVQcm9wZXJ0eSh0YXJnZXQsIHByb3BOYW1lLCB7XG4gICAgICBnZXQoKTogc3RyaW5nIHtcbiAgICAgICAgcmV0dXJuIHRoaXNbcHJpdmF0ZVByb3BOYW1lXTsgLy8gdHNsaW50OmRpc2FibGUtbGluZTpuby1pbnZhbGlkLXRoaXNcbiAgICAgIH0sXG4gICAgICBzZXQodmFsdWU6IFQpOiB2b2lkIHtcbiAgICAgICAgdGhpc1twcml2YXRlUHJvcE5hbWVdID0gZmFsbGJhY2sodmFsdWUpOyAvLyB0c2xpbnQ6ZGlzYWJsZS1saW5lOm5vLWludmFsaWQtdGhpc1xuICAgICAgfVxuICAgIH0pO1xuICB9XG5cbiAgcmV0dXJuIHByb3BEZWNvcmF0b3I7XG59XG5cbi8qKlxuICogSW5wdXQgZGVjb3JhdG9yIHRoYXQgaGFuZGxlIGEgcHJvcCB0byBkbyBnZXQvc2V0IGF1dG9tYXRpY2FsbHkgd2l0aCB0b0Jvb2xlYW5cbiAqXG4gKiBXaHkgbm90IHVzaW5nIEBJbnB1dEJvb2xlYW4gYWxvbmUgd2l0aG91dCBASW5wdXQ/IEFPVCBuZWVkcyBASW5wdXQgdG8gYmUgdmlzaWJsZVxuICpcbiAqIEBob3dUb1VzZVxuICogYGBgXG4gKiBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgdmlzaWJsZTogYm9vbGVhbiA9IGZhbHNlO1xuICpcbiAqIC8vIEFjdCBhcyBiZWxvdzpcbiAqIC8vIEBJbnB1dCgpXG4gKiAvLyBnZXQgdmlzaWJsZSgpIHsgcmV0dXJuIHRoaXMuX192aXNpYmxlOyB9XG4gKiAvLyBzZXQgdmlzaWJsZSh2YWx1ZSkgeyB0aGlzLl9fdmlzaWJsZSA9IHZhbHVlOyB9XG4gKiAvLyBfX3Zpc2libGUgPSBmYWxzZTtcbiAqIGBgYFxuICovXG4vLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6IG5vLWFueVxuZXhwb3J0IGZ1bmN0aW9uIElucHV0Qm9vbGVhbigpOiBhbnkge1xuICByZXR1cm4gcHJvcERlY29yYXRvckZhY3RvcnkoJ0lucHV0Qm9vbGVhbicsIHRvQm9vbGVhbik7XG59XG5cbi8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTogbm8tYW55XG5leHBvcnQgZnVuY3Rpb24gSW5wdXRDc3NQaXhlbCgpOiBhbnkge1xuICByZXR1cm4gcHJvcERlY29yYXRvckZhY3RvcnkoJ0lucHV0Q3NzUGl4ZWwnLCB0b0Nzc1BpeGVsKTtcbn1cblxuLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOiBuby1hbnlcbmV4cG9ydCBmdW5jdGlvbiBJbnB1dE51bWJlcigpOiBhbnkge1xuICAvLyB0c2xpbnQ6ZGlzYWJsZS1saW5lOiBuby1hbnlcbiAgcmV0dXJuIHByb3BEZWNvcmF0b3JGYWN0b3J5KCdJbnB1dE51bWJlcicsIHRvTnVtYmVyKTtcbn1cbiJdfQ==