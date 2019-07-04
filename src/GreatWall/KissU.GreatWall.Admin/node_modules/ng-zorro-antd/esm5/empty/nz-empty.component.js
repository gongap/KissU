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
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, ViewEncapsulation } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { NzI18nService } from 'ng-zorro-antd/i18n';
import { emptyImage } from './nz-empty-config';
var NzEmptyComponent = /** @class */ (function () {
    function NzEmptyComponent(sanitizer, i18n, cdr) {
        this.sanitizer = sanitizer;
        this.i18n = i18n;
        this.cdr = cdr;
        // NOTE: It would be very hack to use `ContentChild`, because Angular could
        // tell if user actually pass something to <ng-content>.
        // See: https://github.com/angular/angular/issues/12530.
        // I can use a directive but this would expose the name `footer`.
        // @ContentChild(TemplateRef) nzNotFoundFooter: TemplateRef<void>;
        this.defaultSvg = this.sanitizer.bypassSecurityTrustResourceUrl(emptyImage);
        this.isContentString = false;
        this.locale = {};
        this.destroy$ = new Subject();
    }
    Object.defineProperty(NzEmptyComponent.prototype, "shouldRenderContent", {
        get: /**
         * @return {?}
         */
        function () {
            /** @type {?} */
            var content = this.nzNotFoundContent;
            return !!(content || typeof content === 'string');
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @param {?} changes
     * @return {?}
     */
    NzEmptyComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        var nzNotFoundContent = changes.nzNotFoundContent;
        if (nzNotFoundContent) {
            this.isContentString = typeof nzNotFoundContent.currentValue === 'string';
        }
    };
    /**
     * @return {?}
     */
    NzEmptyComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
        this.i18n.localeChange.pipe(takeUntil(this.destroy$)).subscribe((/**
         * @return {?}
         */
        function () {
            _this.locale = _this.i18n.getLocaleData('Empty');
            _this.cdr.markForCheck();
        }));
    };
    /**
     * @return {?}
     */
    NzEmptyComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.destroy$.next();
        this.destroy$.complete();
    };
    NzEmptyComponent.decorators = [
        { type: Component, args: [{
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    encapsulation: ViewEncapsulation.None,
                    selector: 'nz-empty',
                    exportAs: 'nzEmpty',
                    template: "<div class=\"ant-empty-image\">\n  <ng-container *nzStringTemplateOutlet=\"nzNotFoundImage\">\n    <img [src]=\"nzNotFoundImage || defaultSvg\" [alt]=\"isContentString ? nzNotFoundContent : 'empty'\">\n  </ng-container>\n</div>\n<p class=\"ant-empty-description\">\n  <ng-container *nzStringTemplateOutlet=\"nzNotFoundContent\">\n    {{ shouldRenderContent ? nzNotFoundContent : locale['description'] }}\n  </ng-container>\n</p>\n<div class=\"ant-empty-footer\" *ngIf=\"nzNotFoundFooter\">\n  <ng-container *nzStringTemplateOutlet=\"nzNotFoundFooter\">\n    {{ nzNotFoundFooter }}\n  </ng-container>\n</div>\n",
                    host: {
                        class: 'ant-empty'
                    },
                    styles: ['nz-empty { display: block; }']
                }] }
    ];
    /** @nocollapse */
    NzEmptyComponent.ctorParameters = function () { return [
        { type: DomSanitizer },
        { type: NzI18nService },
        { type: ChangeDetectorRef }
    ]; };
    NzEmptyComponent.propDecorators = {
        nzNotFoundImage: [{ type: Input }],
        nzNotFoundContent: [{ type: Input }],
        nzNotFoundFooter: [{ type: Input }]
    };
    return NzEmptyComponent;
}());
export { NzEmptyComponent };
if (false) {
    /** @type {?} */
    NzEmptyComponent.prototype.nzNotFoundImage;
    /** @type {?} */
    NzEmptyComponent.prototype.nzNotFoundContent;
    /** @type {?} */
    NzEmptyComponent.prototype.nzNotFoundFooter;
    /** @type {?} */
    NzEmptyComponent.prototype.defaultSvg;
    /** @type {?} */
    NzEmptyComponent.prototype.isContentString;
    /** @type {?} */
    NzEmptyComponent.prototype.locale;
    /**
     * @type {?}
     * @private
     */
    NzEmptyComponent.prototype.destroy$;
    /**
     * @type {?}
     * @private
     */
    NzEmptyComponent.prototype.sanitizer;
    /**
     * @type {?}
     * @private
     */
    NzEmptyComponent.prototype.i18n;
    /**
     * @type {?}
     * @private
     */
    NzEmptyComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotZW1wdHkuY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC9lbXB0eS8iLCJzb3VyY2VzIjpbIm56LWVtcHR5LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7OztBQVFBLE9BQU8sRUFDTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxLQUFLLEVBTUwsaUJBQWlCLEVBQ2xCLE1BQU0sZUFBZSxDQUFDO0FBQ3ZCLE9BQU8sRUFBRSxZQUFZLEVBQUUsTUFBTSwyQkFBMkIsQ0FBQztBQUN6RCxPQUFPLEVBQUUsT0FBTyxFQUFFLE1BQU0sTUFBTSxDQUFDO0FBQy9CLE9BQU8sRUFBRSxTQUFTLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUUzQyxPQUFPLEVBQUUsYUFBYSxFQUFFLE1BQU0sb0JBQW9CLENBQUM7QUFFbkQsT0FBTyxFQUFFLFVBQVUsRUFBRSxNQUFNLG1CQUFtQixDQUFDO0FBRS9DO0lBaUNFLDBCQUFvQixTQUF1QixFQUFVLElBQW1CLEVBQVUsR0FBc0I7UUFBcEYsY0FBUyxHQUFULFNBQVMsQ0FBYztRQUFVLFNBQUksR0FBSixJQUFJLENBQWU7UUFBVSxRQUFHLEdBQUgsR0FBRyxDQUFtQjs7Ozs7O1FBWHhHLGVBQVUsR0FBRyxJQUFJLENBQUMsU0FBUyxDQUFDLDhCQUE4QixDQUFDLFVBQVUsQ0FBQyxDQUFDO1FBQ3ZFLG9CQUFlLEdBQUcsS0FBSyxDQUFDO1FBQ3hCLFdBQU0sR0FBOEIsRUFBRSxDQUFDO1FBTy9CLGFBQVEsR0FBRyxJQUFJLE9BQU8sRUFBUSxDQUFDO0lBRW9FLENBQUM7SUFQNUcsc0JBQUksaURBQW1COzs7O1FBQXZCOztnQkFDUSxPQUFPLEdBQUcsSUFBSSxDQUFDLGlCQUFpQjtZQUN0QyxPQUFPLENBQUMsQ0FBQyxDQUFDLE9BQU8sSUFBSSxPQUFPLE9BQU8sS0FBSyxRQUFRLENBQUMsQ0FBQztRQUNwRCxDQUFDOzs7T0FBQTs7Ozs7SUFNRCxzQ0FBVzs7OztJQUFYLFVBQVksT0FBc0I7UUFDeEIsSUFBQSw2Q0FBaUI7UUFDekIsSUFBSSxpQkFBaUIsRUFBRTtZQUNyQixJQUFJLENBQUMsZUFBZSxHQUFHLE9BQU8saUJBQWlCLENBQUMsWUFBWSxLQUFLLFFBQVEsQ0FBQztTQUMzRTtJQUNILENBQUM7Ozs7SUFFRCxtQ0FBUTs7O0lBQVI7UUFBQSxpQkFLQztRQUpDLElBQUksQ0FBQyxJQUFJLENBQUMsWUFBWSxDQUFDLElBQUksQ0FBQyxTQUFTLENBQUMsSUFBSSxDQUFDLFFBQVEsQ0FBQyxDQUFDLENBQUMsU0FBUzs7O1FBQUM7WUFDOUQsS0FBSSxDQUFDLE1BQU0sR0FBRyxLQUFJLENBQUMsSUFBSSxDQUFDLGFBQWEsQ0FBQyxPQUFPLENBQUMsQ0FBQztZQUMvQyxLQUFJLENBQUMsR0FBRyxDQUFDLFlBQVksRUFBRSxDQUFDO1FBQzFCLENBQUMsRUFBQyxDQUFDO0lBQ0wsQ0FBQzs7OztJQUVELHNDQUFXOzs7SUFBWDtRQUNFLElBQUksQ0FBQyxRQUFRLENBQUMsSUFBSSxFQUFFLENBQUM7UUFDckIsSUFBSSxDQUFDLFFBQVEsQ0FBQyxRQUFRLEVBQUUsQ0FBQztJQUMzQixDQUFDOztnQkFwREYsU0FBUyxTQUFDO29CQUNULGVBQWUsRUFBRSx1QkFBdUIsQ0FBQyxNQUFNO29CQUMvQyxhQUFhLEVBQUUsaUJBQWlCLENBQUMsSUFBSTtvQkFDckMsUUFBUSxFQUFFLFVBQVU7b0JBQ3BCLFFBQVEsRUFBRSxTQUFTO29CQUNuQiw2bUJBQXdDO29CQUV4QyxJQUFJLEVBQUU7d0JBQ0osS0FBSyxFQUFFLFdBQVc7cUJBQ25COzZCQUhRLDhCQUE4QjtpQkFJeEM7Ozs7Z0JBbEJRLFlBQVk7Z0JBSVosYUFBYTtnQkFkcEIsaUJBQWlCOzs7a0NBOEJoQixLQUFLO29DQUNMLEtBQUs7bUNBQ0wsS0FBSzs7SUF1Q1IsdUJBQUM7Q0FBQSxBQXJERCxJQXFEQztTQTFDWSxnQkFBZ0I7OztJQUMzQiwyQ0FBcUQ7O0lBQ3JELDZDQUF1RDs7SUFDdkQsNENBQXNEOztJQVF0RCxzQ0FBdUU7O0lBQ3ZFLDJDQUF3Qjs7SUFDeEIsa0NBQXVDOzs7OztJQU92QyxvQ0FBdUM7Ozs7O0lBRTNCLHFDQUErQjs7Ozs7SUFBRSxnQ0FBMkI7Ozs7O0lBQUUsK0JBQThCIiwic291cmNlc0NvbnRlbnQiOlsiLyoqXG4gKiBAbGljZW5zZVxuICogQ29weXJpZ2h0IEFsaWJhYmEuY29tIEFsbCBSaWdodHMgUmVzZXJ2ZWQuXG4gKlxuICogVXNlIG9mIHRoaXMgc291cmNlIGNvZGUgaXMgZ292ZXJuZWQgYnkgYW4gTUlULXN0eWxlIGxpY2Vuc2UgdGhhdCBjYW4gYmVcbiAqIGZvdW5kIGluIHRoZSBMSUNFTlNFIGZpbGUgYXQgaHR0cHM6Ly9naXRodWIuY29tL05HLVpPUlJPL25nLXpvcnJvLWFudGQvYmxvYi9tYXN0ZXIvTElDRU5TRVxuICovXG5cbmltcG9ydCB7XG4gIENoYW5nZURldGVjdGlvblN0cmF0ZWd5LFxuICBDaGFuZ2VEZXRlY3RvclJlZixcbiAgQ29tcG9uZW50LFxuICBJbnB1dCxcbiAgT25DaGFuZ2VzLFxuICBPbkRlc3Ryb3ksXG4gIE9uSW5pdCxcbiAgU2ltcGxlQ2hhbmdlcyxcbiAgVGVtcGxhdGVSZWYsXG4gIFZpZXdFbmNhcHN1bGF0aW9uXG59IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgRG9tU2FuaXRpemVyIH0gZnJvbSAnQGFuZ3VsYXIvcGxhdGZvcm0tYnJvd3Nlcic7XG5pbXBvcnQgeyBTdWJqZWN0IH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyB0YWtlVW50aWwgfSBmcm9tICdyeGpzL29wZXJhdG9ycyc7XG5cbmltcG9ydCB7IE56STE4blNlcnZpY2UgfSBmcm9tICduZy16b3Jyby1hbnRkL2kxOG4nO1xuXG5pbXBvcnQgeyBlbXB0eUltYWdlIH0gZnJvbSAnLi9uei1lbXB0eS1jb25maWcnO1xuXG5AQ29tcG9uZW50KHtcbiAgY2hhbmdlRGV0ZWN0aW9uOiBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneS5PblB1c2gsXG4gIGVuY2Fwc3VsYXRpb246IFZpZXdFbmNhcHN1bGF0aW9uLk5vbmUsXG4gIHNlbGVjdG9yOiAnbnotZW1wdHknLFxuICBleHBvcnRBczogJ256RW1wdHknLFxuICB0ZW1wbGF0ZVVybDogJy4vbnotZW1wdHkuY29tcG9uZW50Lmh0bWwnLFxuICBzdHlsZXM6IFsnbnotZW1wdHkgeyBkaXNwbGF5OiBibG9jazsgfSddLFxuICBob3N0OiB7XG4gICAgY2xhc3M6ICdhbnQtZW1wdHknXG4gIH1cbn0pXG5leHBvcnQgY2xhc3MgTnpFbXB0eUNvbXBvbmVudCBpbXBsZW1lbnRzIE9uQ2hhbmdlcywgT25Jbml0LCBPbkRlc3Ryb3kge1xuICBASW5wdXQoKSBuek5vdEZvdW5kSW1hZ2U6IHN0cmluZyB8IFRlbXBsYXRlUmVmPHZvaWQ+O1xuICBASW5wdXQoKSBuek5vdEZvdW5kQ29udGVudDogc3RyaW5nIHwgVGVtcGxhdGVSZWY8dm9pZD47XG4gIEBJbnB1dCgpIG56Tm90Rm91bmRGb290ZXI6IHN0cmluZyB8IFRlbXBsYXRlUmVmPHZvaWQ+O1xuXG4gIC8vIE5PVEU6IEl0IHdvdWxkIGJlIHZlcnkgaGFjayB0byB1c2UgYENvbnRlbnRDaGlsZGAsIGJlY2F1c2UgQW5ndWxhciBjb3VsZFxuICAvLyB0ZWxsIGlmIHVzZXIgYWN0dWFsbHkgcGFzcyBzb21ldGhpbmcgdG8gPG5nLWNvbnRlbnQ+LlxuICAvLyBTZWU6IGh0dHBzOi8vZ2l0aHViLmNvbS9hbmd1bGFyL2FuZ3VsYXIvaXNzdWVzLzEyNTMwLlxuICAvLyBJIGNhbiB1c2UgYSBkaXJlY3RpdmUgYnV0IHRoaXMgd291bGQgZXhwb3NlIHRoZSBuYW1lIGBmb290ZXJgLlxuICAvLyBAQ29udGVudENoaWxkKFRlbXBsYXRlUmVmKSBuek5vdEZvdW5kRm9vdGVyOiBUZW1wbGF0ZVJlZjx2b2lkPjtcblxuICBkZWZhdWx0U3ZnID0gdGhpcy5zYW5pdGl6ZXIuYnlwYXNzU2VjdXJpdHlUcnVzdFJlc291cmNlVXJsKGVtcHR5SW1hZ2UpO1xuICBpc0NvbnRlbnRTdHJpbmcgPSBmYWxzZTtcbiAgbG9jYWxlOiB7IFtrZXk6IHN0cmluZ106IHN0cmluZyB9ID0ge307XG5cbiAgZ2V0IHNob3VsZFJlbmRlckNvbnRlbnQoKTogYm9vbGVhbiB7XG4gICAgY29uc3QgY29udGVudCA9IHRoaXMubnpOb3RGb3VuZENvbnRlbnQ7XG4gICAgcmV0dXJuICEhKGNvbnRlbnQgfHwgdHlwZW9mIGNvbnRlbnQgPT09ICdzdHJpbmcnKTtcbiAgfVxuXG4gIHByaXZhdGUgZGVzdHJveSQgPSBuZXcgU3ViamVjdDx2b2lkPigpO1xuXG4gIGNvbnN0cnVjdG9yKHByaXZhdGUgc2FuaXRpemVyOiBEb21TYW5pdGl6ZXIsIHByaXZhdGUgaTE4bjogTnpJMThuU2VydmljZSwgcHJpdmF0ZSBjZHI6IENoYW5nZURldGVjdG9yUmVmKSB7fVxuXG4gIG5nT25DaGFuZ2VzKGNoYW5nZXM6IFNpbXBsZUNoYW5nZXMpOiB2b2lkIHtcbiAgICBjb25zdCB7IG56Tm90Rm91bmRDb250ZW50IH0gPSBjaGFuZ2VzO1xuICAgIGlmIChuek5vdEZvdW5kQ29udGVudCkge1xuICAgICAgdGhpcy5pc0NvbnRlbnRTdHJpbmcgPSB0eXBlb2YgbnpOb3RGb3VuZENvbnRlbnQuY3VycmVudFZhbHVlID09PSAnc3RyaW5nJztcbiAgICB9XG4gIH1cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICB0aGlzLmkxOG4ubG9jYWxlQ2hhbmdlLnBpcGUodGFrZVVudGlsKHRoaXMuZGVzdHJveSQpKS5zdWJzY3JpYmUoKCkgPT4ge1xuICAgICAgdGhpcy5sb2NhbGUgPSB0aGlzLmkxOG4uZ2V0TG9jYWxlRGF0YSgnRW1wdHknKTtcbiAgICAgIHRoaXMuY2RyLm1hcmtGb3JDaGVjaygpO1xuICAgIH0pO1xuICB9XG5cbiAgbmdPbkRlc3Ryb3koKTogdm9pZCB7XG4gICAgdGhpcy5kZXN0cm95JC5uZXh0KCk7XG4gICAgdGhpcy5kZXN0cm95JC5jb21wbGV0ZSgpO1xuICB9XG59XG4iXX0=