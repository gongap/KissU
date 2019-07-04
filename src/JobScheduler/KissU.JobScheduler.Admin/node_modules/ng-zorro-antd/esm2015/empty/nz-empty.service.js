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
// tslint:disable-next-line:no-any
export class NzEmptyService {
    /**
     * @param {?} defaultEmptyContent
     */
    constructor(defaultEmptyContent) {
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
    setDefaultContent(content) {
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
    }
    /**
     * @return {?}
     */
    resetDefault() {
        this.userDefaultContent$.next(undefined);
    }
}
NzEmptyService.decorators = [
    { type: Injectable, args: [{
                providedIn: 'root'
            },] }
];
/** @nocollapse */
NzEmptyService.ctorParameters = () => [
    { type: Type, decorators: [{ type: Inject, args: [NZ_DEFAULT_EMPTY_CONTENT,] }, { type: Optional }] }
];
/** @nocollapse */ NzEmptyService.ngInjectableDef = i0.defineInjectable({ factory: function NzEmptyService_Factory() { return new NzEmptyService(i0.inject(i1.NZ_DEFAULT_EMPTY_CONTENT, 8)); }, token: NzEmptyService, providedIn: "root" });
if (false) {
    /** @type {?} */
    NzEmptyService.prototype.userDefaultContent$;
    /**
     * @type {?}
     * @private
     */
    NzEmptyService.prototype.defaultEmptyContent;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotZW1wdHkuc2VydmljZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvZW1wdHkvIiwic291cmNlcyI6WyJuei1lbXB0eS5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7O0FBUUEsT0FBTyxFQUFFLE1BQU0sRUFBRSxVQUFVLEVBQUUsUUFBUSxFQUFFLFdBQVcsRUFBRSxJQUFJLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFDaEYsT0FBTyxFQUFFLGVBQWUsRUFBRSxNQUFNLE1BQU0sQ0FBQztBQUN2QyxPQUFPLEVBQXdCLHdCQUF3QixFQUFFLE1BQU0sbUJBQW1CLENBQUM7QUFDbkYsT0FBTyxFQUFFLHdCQUF3QixFQUFFLE1BQU0sa0JBQWtCLENBQUM7Ozs7OztBQUs1RCxrQ0FBa0M7QUFDbEMsTUFBTSxPQUFPLGNBQWM7Ozs7SUFHekIsWUFBa0UsbUJBQTRCO1FBQTVCLHdCQUFtQixHQUFuQixtQkFBbUIsQ0FBUztRQUY5Rix3QkFBbUIsR0FBRyxJQUFJLGVBQWUsQ0FBbUMsU0FBUyxDQUFDLENBQUM7UUFHckYsSUFBSSxJQUFJLENBQUMsbUJBQW1CLEVBQUU7WUFDNUIsSUFBSSxDQUFDLG1CQUFtQixDQUFDLElBQUksQ0FBQyxJQUFJLENBQUMsbUJBQW1CLENBQUMsQ0FBQztTQUN6RDtJQUNILENBQUM7Ozs7O0lBRUQsaUJBQWlCLENBQUMsT0FBOEI7UUFDOUMsSUFDRSxPQUFPLE9BQU8sS0FBSyxRQUFRO1lBQzNCLE9BQU8sS0FBSyxTQUFTO1lBQ3JCLE9BQU8sS0FBSyxJQUFJO1lBQ2hCLE9BQU8sWUFBWSxXQUFXO1lBQzlCLE9BQU8sWUFBWSxJQUFJLEVBQ3ZCO1lBQ0EsSUFBSSxDQUFDLG1CQUFtQixDQUFDLElBQUksQ0FBQyxPQUFPLENBQUMsQ0FBQztTQUN4QzthQUFNO1lBQ0wsTUFBTSx3QkFBd0IsQ0FBQyxPQUFPLENBQUMsQ0FBQztTQUN6QztJQUNILENBQUM7Ozs7SUFFRCxZQUFZO1FBQ1YsSUFBSSxDQUFDLG1CQUFtQixDQUFDLElBQUksQ0FBQyxTQUFTLENBQUMsQ0FBQztJQUMzQyxDQUFDOzs7WUE3QkYsVUFBVSxTQUFDO2dCQUNWLFVBQVUsRUFBRSxNQUFNO2FBQ25COzs7O1lBUG1ELElBQUksdUJBWXpDLE1BQU0sU0FBQyx3QkFBd0IsY0FBRyxRQUFROzs7OztJQUZ2RCw2Q0FBdUY7Ozs7O0lBRTNFLDZDQUFrRiIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQgeyBJbmplY3QsIEluamVjdGFibGUsIE9wdGlvbmFsLCBUZW1wbGF0ZVJlZiwgVHlwZSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgQmVoYXZpb3JTdWJqZWN0IH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyBOekVtcHR5Q3VzdG9tQ29udGVudCwgTlpfREVGQVVMVF9FTVBUWV9DT05URU5UIH0gZnJvbSAnLi9uei1lbXB0eS1jb25maWcnO1xuaW1wb3J0IHsgZ2V0RW1wdHlDb250ZW50VHlwZUVycm9yIH0gZnJvbSAnLi9uei1lbXB0eS1lcnJvcic7XG5cbkBJbmplY3RhYmxlKHtcbiAgcHJvdmlkZWRJbjogJ3Jvb3QnXG59KVxuLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOm5vLWFueVxuZXhwb3J0IGNsYXNzIE56RW1wdHlTZXJ2aWNlPFQgPSBhbnk+IHtcbiAgdXNlckRlZmF1bHRDb250ZW50JCA9IG5ldyBCZWhhdmlvclN1YmplY3Q8TnpFbXB0eUN1c3RvbUNvbnRlbnQgfCB1bmRlZmluZWQ+KHVuZGVmaW5lZCk7XG5cbiAgY29uc3RydWN0b3IoQEluamVjdChOWl9ERUZBVUxUX0VNUFRZX0NPTlRFTlQpIEBPcHRpb25hbCgpIHByaXZhdGUgZGVmYXVsdEVtcHR5Q29udGVudDogVHlwZTxUPikge1xuICAgIGlmICh0aGlzLmRlZmF1bHRFbXB0eUNvbnRlbnQpIHtcbiAgICAgIHRoaXMudXNlckRlZmF1bHRDb250ZW50JC5uZXh0KHRoaXMuZGVmYXVsdEVtcHR5Q29udGVudCk7XG4gICAgfVxuICB9XG5cbiAgc2V0RGVmYXVsdENvbnRlbnQoY29udGVudD86IE56RW1wdHlDdXN0b21Db250ZW50KTogdm9pZCB7XG4gICAgaWYgKFxuICAgICAgdHlwZW9mIGNvbnRlbnQgPT09ICdzdHJpbmcnIHx8XG4gICAgICBjb250ZW50ID09PSB1bmRlZmluZWQgfHxcbiAgICAgIGNvbnRlbnQgPT09IG51bGwgfHxcbiAgICAgIGNvbnRlbnQgaW5zdGFuY2VvZiBUZW1wbGF0ZVJlZiB8fFxuICAgICAgY29udGVudCBpbnN0YW5jZW9mIFR5cGVcbiAgICApIHtcbiAgICAgIHRoaXMudXNlckRlZmF1bHRDb250ZW50JC5uZXh0KGNvbnRlbnQpO1xuICAgIH0gZWxzZSB7XG4gICAgICB0aHJvdyBnZXRFbXB0eUNvbnRlbnRUeXBlRXJyb3IoY29udGVudCk7XG4gICAgfVxuICB9XG5cbiAgcmVzZXREZWZhdWx0KCk6IHZvaWQge1xuICAgIHRoaXMudXNlckRlZmF1bHRDb250ZW50JC5uZXh0KHVuZGVmaW5lZCk7XG4gIH1cbn1cbiJdfQ==