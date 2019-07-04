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
import { ChangeDetectionStrategy, Component, ContentChild, ElementRef, EventEmitter, Input, Output, TemplateRef, ViewEncapsulation } from '@angular/core';
import { NzPageHeaderFooterDirective } from './nz-page-header-cells';
var NzPageHeaderComponent = /** @class */ (function () {
    function NzPageHeaderComponent() {
        this.isTemplateRefBackIcon = false;
        this.isStringBackIcon = false;
        this.nzBackIcon = null;
        this.nzBack = new EventEmitter();
    }
    /**
     * @return {?}
     */
    NzPageHeaderComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () { };
    /**
     * @param {?} changes
     * @return {?}
     */
    NzPageHeaderComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        if (changes.hasOwnProperty('nzBackIcon')) {
            this.isTemplateRefBackIcon = changes.nzBackIcon.currentValue instanceof TemplateRef;
            this.isStringBackIcon = typeof changes.nzBackIcon.currentValue === 'string';
        }
    };
    /**
     * @return {?}
     */
    NzPageHeaderComponent.prototype.onBack = /**
     * @return {?}
     */
    function () {
        this.nzBack.emit();
    };
    NzPageHeaderComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-page-header',
                    exportAs: 'nzPageHeader',
                    template: "<ng-content select=\"nz-breadcrumb[nz-page-header-breadcrumb]\"></ng-content>\n\n<div *ngIf=\"nzBackIcon !== null\" (click)=\"onBack()\" class=\"ant-page-header-back-icon\">\n  <i *ngIf=\"isStringBackIcon\" nz-icon [type]=\"nzBackIcon ? nzBackIcon : 'arrow-left'\" theme=\"outline\"></i>\n  <ng-container *ngIf=\"isTemplateRefBackIcon\" [ngTemplateOutlet]=\"nzBackIcon\"></ng-container>\n  <nz-divider nzType=\"vertical\"></nz-divider>\n</div>\n\n<div class=\"ant-page-header-title-view\">\n  <span class=\"ant-page-header-title-view-title\" *ngIf=\"nzTitle\">\n    <ng-container *nzStringTemplateOutlet=\"nzTitle\">{{ nzTitle }}</ng-container>\n  </span>\n  <ng-content *ngIf=\"!nzTitle\" select=\"nz-page-header-title, [nz-page-header-title]\"></ng-content>\n  <span class=\"ant-page-header-title-view-sub-title\" *ngIf=\"nzSubtitle\">\n    <ng-container *nzStringTemplateOutlet=\"nzSubtitle\">{{ nzSubtitle }}</ng-container>\n  </span>\n  <ng-content *ngIf=\"!nzSubtitle\" select=\"nz-page-header-subtitle, [nz-page-header-subtitle]\"></ng-content>\n  <ng-content select=\"nz-page-header-tags, [nz-page-header-tags]\"></ng-content>\n  <ng-content select=\"nz-page-header-extra, [nz-page-header-extra]\"></ng-content>\n</div>\n\n<ng-content select=\"nz-page-header-content, [nz-page-header-content]\"></ng-content>\n<ng-content select=\"nz-page-header-footer, [nz-page-header-footer]\"></ng-content>\n",
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    encapsulation: ViewEncapsulation.None,
                    host: {
                        class: 'ant-page-header',
                        '[class.ant-page-header-has-footer]': 'nzPageHeaderFooter'
                    },
                    styles: ["nz-page-header,nz-page-header-content,nz-page-header-footer{display:block}"]
                }] }
    ];
    /** @nocollapse */
    NzPageHeaderComponent.ctorParameters = function () { return []; };
    NzPageHeaderComponent.propDecorators = {
        nzBackIcon: [{ type: Input }],
        nzTitle: [{ type: Input }],
        nzSubtitle: [{ type: Input }],
        nzBack: [{ type: Output }],
        nzPageHeaderFooter: [{ type: ContentChild, args: [NzPageHeaderFooterDirective,] }]
    };
    return NzPageHeaderComponent;
}());
export { NzPageHeaderComponent };
if (false) {
    /** @type {?} */
    NzPageHeaderComponent.prototype.isTemplateRefBackIcon;
    /** @type {?} */
    NzPageHeaderComponent.prototype.isStringBackIcon;
    /** @type {?} */
    NzPageHeaderComponent.prototype.nzBackIcon;
    /** @type {?} */
    NzPageHeaderComponent.prototype.nzTitle;
    /** @type {?} */
    NzPageHeaderComponent.prototype.nzSubtitle;
    /** @type {?} */
    NzPageHeaderComponent.prototype.nzBack;
    /** @type {?} */
    NzPageHeaderComponent.prototype.nzPageHeaderFooter;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotcGFnZS1oZWFkZXIuY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC9wYWdlLWhlYWRlci8iLCJzb3VyY2VzIjpbIm56LXBhZ2UtaGVhZGVyLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7OztBQVFBLE9BQU8sRUFDTCx1QkFBdUIsRUFDdkIsU0FBUyxFQUNULFlBQVksRUFDWixVQUFVLEVBQ1YsWUFBWSxFQUNaLEtBQUssRUFHTCxNQUFNLEVBRU4sV0FBVyxFQUNYLGlCQUFpQixFQUNsQixNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQUUsMkJBQTJCLEVBQUUsTUFBTSx3QkFBd0IsQ0FBQztBQUVyRTtJQXVCRTtRQVZBLDBCQUFxQixHQUFHLEtBQUssQ0FBQztRQUM5QixxQkFBZ0IsR0FBRyxLQUFLLENBQUM7UUFFaEIsZUFBVSxHQUFzQyxJQUFJLENBQUM7UUFHM0MsV0FBTSxHQUFHLElBQUksWUFBWSxFQUFRLENBQUM7SUFJdEMsQ0FBQzs7OztJQUVoQix3Q0FBUTs7O0lBQVIsY0FBa0IsQ0FBQzs7Ozs7SUFFbkIsMkNBQVc7Ozs7SUFBWCxVQUFZLE9BQXNCO1FBQ2hDLElBQUksT0FBTyxDQUFDLGNBQWMsQ0FBQyxZQUFZLENBQUMsRUFBRTtZQUN4QyxJQUFJLENBQUMscUJBQXFCLEdBQUcsT0FBTyxDQUFDLFVBQVUsQ0FBQyxZQUFZLFlBQVksV0FBVyxDQUFDO1lBQ3BGLElBQUksQ0FBQyxnQkFBZ0IsR0FBRyxPQUFPLE9BQU8sQ0FBQyxVQUFVLENBQUMsWUFBWSxLQUFLLFFBQVEsQ0FBQztTQUM3RTtJQUNILENBQUM7Ozs7SUFFRCxzQ0FBTTs7O0lBQU47UUFDRSxJQUFJLENBQUMsTUFBTSxDQUFDLElBQUksRUFBRSxDQUFDO0lBQ3JCLENBQUM7O2dCQXBDRixTQUFTLFNBQUM7b0JBQ1QsUUFBUSxFQUFFLGdCQUFnQjtvQkFDMUIsUUFBUSxFQUFFLGNBQWM7b0JBQ3hCLHU0Q0FBOEM7b0JBRTlDLGVBQWUsRUFBRSx1QkFBdUIsQ0FBQyxNQUFNO29CQUMvQyxhQUFhLEVBQUUsaUJBQWlCLENBQUMsSUFBSTtvQkFDckMsSUFBSSxFQUFFO3dCQUNKLEtBQUssRUFBRSxpQkFBaUI7d0JBQ3hCLG9DQUFvQyxFQUFFLG9CQUFvQjtxQkFDM0Q7O2lCQUNGOzs7Ozs2QkFLRSxLQUFLOzBCQUNMLEtBQUs7NkJBQ0wsS0FBSzt5QkFDTCxNQUFNO3FDQUVOLFlBQVksU0FBQywyQkFBMkI7O0lBZ0IzQyw0QkFBQztDQUFBLEFBckNELElBcUNDO1NBekJZLHFCQUFxQjs7O0lBQ2hDLHNEQUE4Qjs7SUFDOUIsaURBQXlCOztJQUV6QiwyQ0FBOEQ7O0lBQzlELHdDQUE2Qzs7SUFDN0MsMkNBQWdEOztJQUNoRCx1Q0FBcUQ7O0lBRXJELG1EQUF1RyIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ29tcG9uZW50LFxuICBDb250ZW50Q2hpbGQsXG4gIEVsZW1lbnRSZWYsXG4gIEV2ZW50RW1pdHRlcixcbiAgSW5wdXQsXG4gIE9uQ2hhbmdlcyxcbiAgT25Jbml0LFxuICBPdXRwdXQsXG4gIFNpbXBsZUNoYW5nZXMsXG4gIFRlbXBsYXRlUmVmLFxuICBWaWV3RW5jYXBzdWxhdGlvblxufSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IE56UGFnZUhlYWRlckZvb3RlckRpcmVjdGl2ZSB9IGZyb20gJy4vbnotcGFnZS1oZWFkZXItY2VsbHMnO1xuXG5AQ29tcG9uZW50KHtcbiAgc2VsZWN0b3I6ICduei1wYWdlLWhlYWRlcicsXG4gIGV4cG9ydEFzOiAnbnpQYWdlSGVhZGVyJyxcbiAgdGVtcGxhdGVVcmw6ICcuL256LXBhZ2UtaGVhZGVyLmNvbXBvbmVudC5odG1sJyxcbiAgc3R5bGVVcmxzOiBbJy4vbnotcGFnZS1oZWFkZXIuY29tcG9uZW50Lmxlc3MnXSxcbiAgY2hhbmdlRGV0ZWN0aW9uOiBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneS5PblB1c2gsXG4gIGVuY2Fwc3VsYXRpb246IFZpZXdFbmNhcHN1bGF0aW9uLk5vbmUsXG4gIGhvc3Q6IHtcbiAgICBjbGFzczogJ2FudC1wYWdlLWhlYWRlcicsXG4gICAgJ1tjbGFzcy5hbnQtcGFnZS1oZWFkZXItaGFzLWZvb3Rlcl0nOiAnbnpQYWdlSGVhZGVyRm9vdGVyJ1xuICB9XG59KVxuZXhwb3J0IGNsYXNzIE56UGFnZUhlYWRlckNvbXBvbmVudCBpbXBsZW1lbnRzIE9uSW5pdCwgT25DaGFuZ2VzIHtcbiAgaXNUZW1wbGF0ZVJlZkJhY2tJY29uID0gZmFsc2U7XG4gIGlzU3RyaW5nQmFja0ljb24gPSBmYWxzZTtcblxuICBASW5wdXQoKSBuekJhY2tJY29uOiBzdHJpbmcgfCBUZW1wbGF0ZVJlZjx2b2lkPiB8IG51bGwgPSBudWxsO1xuICBASW5wdXQoKSBuelRpdGxlOiBzdHJpbmcgfCBUZW1wbGF0ZVJlZjx2b2lkPjtcbiAgQElucHV0KCkgbnpTdWJ0aXRsZTogc3RyaW5nIHwgVGVtcGxhdGVSZWY8dm9pZD47XG4gIEBPdXRwdXQoKSByZWFkb25seSBuekJhY2sgPSBuZXcgRXZlbnRFbWl0dGVyPHZvaWQ+KCk7XG5cbiAgQENvbnRlbnRDaGlsZChOelBhZ2VIZWFkZXJGb290ZXJEaXJlY3RpdmUpIG56UGFnZUhlYWRlckZvb3RlcjogRWxlbWVudFJlZjxOelBhZ2VIZWFkZXJGb290ZXJEaXJlY3RpdmU+O1xuXG4gIGNvbnN0cnVjdG9yKCkge31cblxuICBuZ09uSW5pdCgpOiB2b2lkIHt9XG5cbiAgbmdPbkNoYW5nZXMoY2hhbmdlczogU2ltcGxlQ2hhbmdlcyk6IHZvaWQge1xuICAgIGlmIChjaGFuZ2VzLmhhc093blByb3BlcnR5KCduekJhY2tJY29uJykpIHtcbiAgICAgIHRoaXMuaXNUZW1wbGF0ZVJlZkJhY2tJY29uID0gY2hhbmdlcy5uekJhY2tJY29uLmN1cnJlbnRWYWx1ZSBpbnN0YW5jZW9mIFRlbXBsYXRlUmVmO1xuICAgICAgdGhpcy5pc1N0cmluZ0JhY2tJY29uID0gdHlwZW9mIGNoYW5nZXMubnpCYWNrSWNvbi5jdXJyZW50VmFsdWUgPT09ICdzdHJpbmcnO1xuICAgIH1cbiAgfVxuXG4gIG9uQmFjaygpOiB2b2lkIHtcbiAgICB0aGlzLm56QmFjay5lbWl0KCk7XG4gIH1cbn1cbiJdfQ==