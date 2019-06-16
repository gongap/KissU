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
import { Inject, Injectable, Optional, TemplateRef, Type } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { NZ_DEFAULT_EMPTY_CONTENT } from './nz-empty-config';
import { getEmptyContentTypeError } from './nz-empty-error';
import * as i0 from "@angular/core";
import * as i1 from "./nz-empty-config";
/**
 * @template T
 */
var NzEmptyService = /** @class */ (function () {
    function NzEmptyService(defaultEmptyContent) {
        this.defaultEmptyContent = defaultEmptyContent;
        this.userDefaultContent$ = new BehaviorSubject(undefined);
        if (this.defaultEmptyContent) {
            this.userDefaultContent$.next(this.defaultEmptyContent);
        }
    }
    /**
     * @param {?=} content
     * @return {?}
     */
    NzEmptyService.prototype.setDefaultContent = /**
     * @param {?=} content
     * @return {?}
     */
    function (content) {
        if (typeof content === 'string' ||
            content === undefined ||
            content === null ||
            content instanceof TemplateRef ||
            content instanceof Type) {
            this.userDefaultContent$.next(content);
        }
        else {
            throw getEmptyContentTypeError(content);
        }
    };
    /**
     * @return {?}
     */
    NzEmptyService.prototype.resetDefault = /**
     * @return {?}
     */
    function () {
        this.userDefaultContent$.next(undefined);
    };
    NzEmptyService.decorators = [
        { type: Injectable, args: [{
                    providedIn: 'root'
                },] }
    ];
    /** @nocollapse */
    NzEmptyService.ctorParameters = function () { return [
        { type: Type, decorators: [{ type: Inject, args: [NZ_DEFAULT_EMPTY_CONTENT,] }, { type: Optional }] }
    ]; };
    /** @nocollapse */ NzEmptyService.ngInjectableDef = i0.defineInjectable({ factory: function NzEmptyService_Factory() { return new NzEmptyService(i0.inject(i1.NZ_DEFAULT_EMPTY_CONTENT, 8)); }, token: NzEmptyService, providedIn: "root" });
    return NzEmptyService;
}());
export { NzEmptyService };
if (false) {
    /** @type {?} */
    NzEmptyService.prototype.userDefaultContent$;
    /**
     * @type {?}
     * @private
     */
    NzEmptyService.prototype.defaultEmptyContent;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotZW1wdHkuc2VydmljZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvZW1wdHkvIiwic291cmNlcyI6WyJuei1lbXB0eS5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7O0FBUUEsT0FBTyxFQUFFLE1BQU0sRUFBRSxVQUFVLEVBQUUsUUFBUSxFQUFFLFdBQVcsRUFBRSxJQUFJLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFDaEYsT0FBTyxFQUFFLGVBQWUsRUFBRSxNQUFNLE1BQU0sQ0FBQztBQUN2QyxPQUFPLEVBQXdCLHdCQUF3QixFQUFFLE1BQU0sbUJBQW1CLENBQUM7QUFDbkYsT0FBTyxFQUFFLHdCQUF3QixFQUFFLE1BQU0sa0JBQWtCLENBQUM7Ozs7OztBQUU1RDtJQU9FLHdCQUFrRSxtQkFBNEI7UUFBNUIsd0JBQW1CLEdBQW5CLG1CQUFtQixDQUFTO1FBRjlGLHdCQUFtQixHQUFHLElBQUksZUFBZSxDQUFtQyxTQUFTLENBQUMsQ0FBQztRQUdyRixJQUFJLElBQUksQ0FBQyxtQkFBbUIsRUFBRTtZQUM1QixJQUFJLENBQUMsbUJBQW1CLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxtQkFBbUIsQ0FBQyxDQUFDO1NBQ3pEO0lBQ0gsQ0FBQzs7Ozs7SUFFRCwwQ0FBaUI7Ozs7SUFBakIsVUFBa0IsT0FBOEI7UUFDOUMsSUFDRSxPQUFPLE9BQU8sS0FBSyxRQUFRO1lBQzNCLE9BQU8sS0FBSyxTQUFTO1lBQ3JCLE9BQU8sS0FBSyxJQUFJO1lBQ2hCLE9BQU8sWUFBWSxXQUFXO1lBQzlCLE9BQU8sWUFBWSxJQUFJLEVBQ3ZCO1lBQ0EsSUFBSSxDQUFDLG1CQUFtQixDQUFDLElBQUksQ0FBQyxPQUFPLENBQUMsQ0FBQztTQUN4QzthQUFNO1lBQ0wsTUFBTSx3QkFBd0IsQ0FBQyxPQUFPLENBQUMsQ0FBQztTQUN6QztJQUNILENBQUM7Ozs7SUFFRCxxQ0FBWTs7O0lBQVo7UUFDRSxJQUFJLENBQUMsbUJBQW1CLENBQUMsSUFBSSxDQUFDLFNBQVMsQ0FBQyxDQUFDO0lBQzNDLENBQUM7O2dCQTdCRixVQUFVLFNBQUM7b0JBQ1YsVUFBVSxFQUFFLE1BQU07aUJBQ25COzs7O2dCQVBtRCxJQUFJLHVCQVl6QyxNQUFNLFNBQUMsd0JBQXdCLGNBQUcsUUFBUTs7O3lCQXBCekQ7Q0EyQ0MsQUE5QkQsSUE4QkM7U0ExQlksY0FBYzs7O0lBQ3pCLDZDQUF1Rjs7Ozs7SUFFM0UsNkNBQWtGIiwic291cmNlc0NvbnRlbnQiOlsiLyoqXG4gKiBAbGljZW5zZVxuICogQ29weXJpZ2h0IEFsaWJhYmEuY29tIEFsbCBSaWdodHMgUmVzZXJ2ZWQuXG4gKlxuICogVXNlIG9mIHRoaXMgc291cmNlIGNvZGUgaXMgZ292ZXJuZWQgYnkgYW4gTUlULXN0eWxlIGxpY2Vuc2UgdGhhdCBjYW4gYmVcbiAqIGZvdW5kIGluIHRoZSBMSUNFTlNFIGZpbGUgYXQgaHR0cHM6Ly9naXRodWIuY29tL05HLVpPUlJPL25nLXpvcnJvLWFudGQvYmxvYi9tYXN0ZXIvTElDRU5TRVxuICovXG5cbmltcG9ydCB7IEluamVjdCwgSW5qZWN0YWJsZSwgT3B0aW9uYWwsIFRlbXBsYXRlUmVmLCBUeXBlIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBCZWhhdmlvclN1YmplY3QgfSBmcm9tICdyeGpzJztcbmltcG9ydCB7IE56RW1wdHlDdXN0b21Db250ZW50LCBOWl9ERUZBVUxUX0VNUFRZX0NPTlRFTlQgfSBmcm9tICcuL256LWVtcHR5LWNvbmZpZyc7XG5pbXBvcnQgeyBnZXRFbXB0eUNvbnRlbnRUeXBlRXJyb3IgfSBmcm9tICcuL256LWVtcHR5LWVycm9yJztcblxuQEluamVjdGFibGUoe1xuICBwcm92aWRlZEluOiAncm9vdCdcbn0pXG4vLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6bm8tYW55XG5leHBvcnQgY2xhc3MgTnpFbXB0eVNlcnZpY2U8VCA9IGFueT4ge1xuICB1c2VyRGVmYXVsdENvbnRlbnQkID0gbmV3IEJlaGF2aW9yU3ViamVjdDxOekVtcHR5Q3VzdG9tQ29udGVudCB8IHVuZGVmaW5lZD4odW5kZWZpbmVkKTtcblxuICBjb25zdHJ1Y3RvcihASW5qZWN0KE5aX0RFRkFVTFRfRU1QVFlfQ09OVEVOVCkgQE9wdGlvbmFsKCkgcHJpdmF0ZSBkZWZhdWx0RW1wdHlDb250ZW50OiBUeXBlPFQ+KSB7XG4gICAgaWYgKHRoaXMuZGVmYXVsdEVtcHR5Q29udGVudCkge1xuICAgICAgdGhpcy51c2VyRGVmYXVsdENvbnRlbnQkLm5leHQodGhpcy5kZWZhdWx0RW1wdHlDb250ZW50KTtcbiAgICB9XG4gIH1cblxuICBzZXREZWZhdWx0Q29udGVudChjb250ZW50PzogTnpFbXB0eUN1c3RvbUNvbnRlbnQpOiB2b2lkIHtcbiAgICBpZiAoXG4gICAgICB0eXBlb2YgY29udGVudCA9PT0gJ3N0cmluZycgfHxcbiAgICAgIGNvbnRlbnQgPT09IHVuZGVmaW5lZCB8fFxuICAgICAgY29udGVudCA9PT0gbnVsbCB8fFxuICAgICAgY29udGVudCBpbnN0YW5jZW9mIFRlbXBsYXRlUmVmIHx8XG4gICAgICBjb250ZW50IGluc3RhbmNlb2YgVHlwZVxuICAgICkge1xuICAgICAgdGhpcy51c2VyRGVmYXVsdENvbnRlbnQkLm5leHQoY29udGVudCk7XG4gICAgfSBlbHNlIHtcbiAgICAgIHRocm93IGdldEVtcHR5Q29udGVudFR5cGVFcnJvcihjb250ZW50KTtcbiAgICB9XG4gIH1cblxuICByZXNldERlZmF1bHQoKTogdm9pZCB7XG4gICAgdGhpcy51c2VyRGVmYXVsdENvbnRlbnQkLm5leHQodW5kZWZpbmVkKTtcbiAgfVxufVxuIl19