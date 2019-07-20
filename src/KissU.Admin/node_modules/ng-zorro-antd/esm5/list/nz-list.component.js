/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { ChangeDetectionStrategy, Component, ElementRef, Input, TemplateRef, ViewEncapsulation } from '@angular/core';
import { InputBoolean, NzUpdateHostClassService } from 'ng-zorro-antd/core';
var NzListComponent = /** @class */ (function () {
    // #endregion
    function NzListComponent(el, updateHostClassService) {
        this.el = el;
        this.updateHostClassService = updateHostClassService;
        this.nzBordered = false;
        this.nzItemLayout = 'horizontal';
        this.nzLoading = false;
        this.nzSize = 'default';
        this.nzSplit = true;
        // #endregion
        // #region styles
        this.prefixCls = 'ant-list';
    }
    /**
     * @private
     * @return {?}
     */
    NzListComponent.prototype._setClassMap = /**
     * @private
     * @return {?}
     */
    function () {
        var _a;
        /** @type {?} */
        var classMap = (_a = {},
            _a[this.prefixCls] = true,
            _a[this.prefixCls + "-vertical"] = this.nzItemLayout === 'vertical',
            _a[this.prefixCls + "-lg"] = this.nzSize === 'large',
            _a[this.prefixCls + "-sm"] = this.nzSize === 'small',
            _a[this.prefixCls + "-split"] = this.nzSplit,
            _a[this.prefixCls + "-bordered"] = this.nzBordered,
            _a[this.prefixCls + "-loading"] = this.nzLoading,
            _a[this.prefixCls + "-grid"] = this.nzGrid,
            _a[this.prefixCls + "-something-after-last-item"] = !!(this.nzLoadMore || this.nzPagination || this.nzFooter),
            _a);
        this.updateHostClassService.updateHostClass(this.el.nativeElement, classMap);
    };
    /**
     * @return {?}
     */
    NzListComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        this._setClassMap();
    };
    /**
     * @return {?}
     */
    NzListComponent.prototype.ngOnChanges = /**
     * @return {?}
     */
    function () {
        this._setClassMap();
    };
    NzListComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-list',
                    exportAs: 'nzList',
                    template: "<ng-template #itemsTpl>\n  <ng-container *ngFor=\"let item of nzDataSource; let index = index\">\n    <ng-template [ngTemplateOutlet]=\"nzRenderItem\" [ngTemplateOutletContext]=\"{ $implicit: item, index: index }\"></ng-template>\n  </ng-container>\n</ng-template>\n<div *ngIf=\"nzHeader\" class=\"ant-list-header\">\n  <ng-container *nzStringTemplateOutlet=\"nzHeader\">{{ nzHeader }}</ng-container>\n</div>\n<nz-spin [nzSpinning]=\"nzLoading\">\n  <ng-container *ngIf=\"nzDataSource\">\n    <div *ngIf=\"nzLoading && nzDataSource.length === 0\" [style.min-height.px]=\"53\"></div>\n    <div *ngIf=\"nzGrid; else itemsTpl\" nz-row [nzGutter]=\"nzGrid.gutter\">\n      <div nz-col [nzSpan]=\"nzGrid.span\" [nzXs]=\"nzGrid.xs\" [nzSm]=\"nzGrid.sm\" [nzMd]=\"nzGrid.md\" [nzLg]=\"nzGrid.lg\" [nzXl]=\"nzGrid.xl\"\n           [nzXXl]=\"nzGrid.xxl\" *ngFor=\"let item of nzDataSource; let index = index\">\n        <ng-template [ngTemplateOutlet]=\"nzRenderItem\" [ngTemplateOutletContext]=\"{ $implicit: item, index: index }\"></ng-template>\n      </div>\n    </div>\n    <div *ngIf=\"!nzLoading && nzDataSource.length === 0\" class=\"ant-list-empty-text\">\n      <nz-embed-empty [nzComponentName]=\"'list'\" [specificContent]=\"nzNoResult\"></nz-embed-empty>\n    </div>\n  </ng-container>\n  <ng-content></ng-content>\n</nz-spin>\n<div *ngIf=\"nzFooter\" class=\"ant-list-footer\">\n  <ng-container *nzStringTemplateOutlet=\"nzFooter\">{{ nzFooter }}</ng-container>\n</div>\n<ng-template [ngTemplateOutlet]=\"nzLoadMore\"></ng-template>\n<div *ngIf=\"nzPagination\" class=\"ant-list-pagination\">\n  <ng-template [ngTemplateOutlet]=\"nzPagination\"></ng-template>\n</div>",
                    providers: [NzUpdateHostClassService],
                    preserveWhitespaces: false,
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush,
                    styles: ["\n      nz-list,\n      nz-list nz-spin {\n        display: block;\n      }\n    "]
                }] }
    ];
    /** @nocollapse */
    NzListComponent.ctorParameters = function () { return [
        { type: ElementRef },
        { type: NzUpdateHostClassService }
    ]; };
    NzListComponent.propDecorators = {
        nzDataSource: [{ type: Input }],
        nzBordered: [{ type: Input }],
        nzGrid: [{ type: Input }],
        nzHeader: [{ type: Input }],
        nzFooter: [{ type: Input }],
        nzItemLayout: [{ type: Input }],
        nzRenderItem: [{ type: Input }],
        nzLoading: [{ type: Input }],
        nzLoadMore: [{ type: Input }],
        nzPagination: [{ type: Input }],
        nzSize: [{ type: Input }],
        nzSplit: [{ type: Input }],
        nzNoResult: [{ type: Input }]
    };
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzListComponent.prototype, "nzBordered", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzListComponent.prototype, "nzLoading", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzListComponent.prototype, "nzSplit", void 0);
    return NzListComponent;
}());
export { NzListComponent };
if (false) {
    /** @type {?} */
    NzListComponent.prototype.nzDataSource;
    /** @type {?} */
    NzListComponent.prototype.nzBordered;
    /** @type {?} */
    NzListComponent.prototype.nzGrid;
    /** @type {?} */
    NzListComponent.prototype.nzHeader;
    /** @type {?} */
    NzListComponent.prototype.nzFooter;
    /** @type {?} */
    NzListComponent.prototype.nzItemLayout;
    /** @type {?} */
    NzListComponent.prototype.nzRenderItem;
    /** @type {?} */
    NzListComponent.prototype.nzLoading;
    /** @type {?} */
    NzListComponent.prototype.nzLoadMore;
    /** @type {?} */
    NzListComponent.prototype.nzPagination;
    /** @type {?} */
    NzListComponent.prototype.nzSize;
    /** @type {?} */
    NzListComponent.prototype.nzSplit;
    /** @type {?} */
    NzListComponent.prototype.nzNoResult;
    /**
     * @type {?}
     * @private
     */
    NzListComponent.prototype.prefixCls;
    /**
     * @type {?}
     * @private
     */
    NzListComponent.prototype.el;
    /**
     * @type {?}
     * @private
     */
    NzListComponent.prototype.updateHostClassService;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotbGlzdC5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9uZy16b3Jyby1hbnRkL2xpc3QvIiwic291cmNlcyI6WyJuei1saXN0LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQ0wsdUJBQXVCLEVBQ3ZCLFNBQVMsRUFDVCxVQUFVLEVBQ1YsS0FBSyxFQUdMLFdBQVcsRUFDWCxpQkFBaUIsRUFDbEIsTUFBTSxlQUFlLENBQUM7QUFFdkIsT0FBTyxFQUFFLFlBQVksRUFBaUIsd0JBQXdCLEVBQUUsTUFBTSxvQkFBb0IsQ0FBQztBQUkzRjtJQW1FRSxhQUFhO0lBRWIseUJBQW9CLEVBQWMsRUFBVSxzQkFBZ0Q7UUFBeEUsT0FBRSxHQUFGLEVBQUUsQ0FBWTtRQUFVLDJCQUFzQixHQUF0QixzQkFBc0IsQ0FBMEI7UUEvQ25FLGVBQVUsR0FBRyxLQUFLLENBQUM7UUFRbkMsaUJBQVksR0FBOEIsWUFBWSxDQUFDO1FBSXZDLGNBQVMsR0FBRyxLQUFLLENBQUM7UUFNbEMsV0FBTSxHQUFrQixTQUFTLENBQUM7UUFFbEIsWUFBTyxHQUFHLElBQUksQ0FBQzs7O1FBUWhDLGNBQVMsR0FBRyxVQUFVLENBQUM7SUFtQmdFLENBQUM7Ozs7O0lBakJ4RixzQ0FBWTs7OztJQUFwQjs7O1lBQ1EsUUFBUTtZQUNaLEdBQUMsSUFBSSxDQUFDLFNBQVMsSUFBRyxJQUFJO1lBQ3RCLEdBQUksSUFBSSxDQUFDLFNBQVMsY0FBVyxJQUFHLElBQUksQ0FBQyxZQUFZLEtBQUssVUFBVTtZQUNoRSxHQUFJLElBQUksQ0FBQyxTQUFTLFFBQUssSUFBRyxJQUFJLENBQUMsTUFBTSxLQUFLLE9BQU87WUFDakQsR0FBSSxJQUFJLENBQUMsU0FBUyxRQUFLLElBQUcsSUFBSSxDQUFDLE1BQU0sS0FBSyxPQUFPO1lBQ2pELEdBQUksSUFBSSxDQUFDLFNBQVMsV0FBUSxJQUFHLElBQUksQ0FBQyxPQUFPO1lBQ3pDLEdBQUksSUFBSSxDQUFDLFNBQVMsY0FBVyxJQUFHLElBQUksQ0FBQyxVQUFVO1lBQy9DLEdBQUksSUFBSSxDQUFDLFNBQVMsYUFBVSxJQUFHLElBQUksQ0FBQyxTQUFTO1lBQzdDLEdBQUksSUFBSSxDQUFDLFNBQVMsVUFBTyxJQUFHLElBQUksQ0FBQyxNQUFNO1lBQ3ZDLEdBQUksSUFBSSxDQUFDLFNBQVMsK0JBQTRCLElBQUcsQ0FBQyxDQUFDLENBQUMsSUFBSSxDQUFDLFVBQVUsSUFBSSxJQUFJLENBQUMsWUFBWSxJQUFJLElBQUksQ0FBQyxRQUFRLENBQUM7ZUFDM0c7UUFDRCxJQUFJLENBQUMsc0JBQXNCLENBQUMsZUFBZSxDQUFDLElBQUksQ0FBQyxFQUFFLENBQUMsYUFBYSxFQUFFLFFBQVEsQ0FBQyxDQUFDO0lBQy9FLENBQUM7Ozs7SUFNRCxrQ0FBUTs7O0lBQVI7UUFDRSxJQUFJLENBQUMsWUFBWSxFQUFFLENBQUM7SUFDdEIsQ0FBQzs7OztJQUVELHFDQUFXOzs7SUFBWDtRQUNFLElBQUksQ0FBQyxZQUFZLEVBQUUsQ0FBQztJQUN0QixDQUFDOztnQkE3RUYsU0FBUyxTQUFDO29CQUNULFFBQVEsRUFBRSxTQUFTO29CQUNuQixRQUFRLEVBQUUsUUFBUTtvQkFDbEIsb3BEQUF1QztvQkFDdkMsU0FBUyxFQUFFLENBQUMsd0JBQXdCLENBQUM7b0JBQ3JDLG1CQUFtQixFQUFFLEtBQUs7b0JBQzFCLGFBQWEsRUFBRSxpQkFBaUIsQ0FBQyxJQUFJO29CQUNyQyxlQUFlLEVBQUUsdUJBQXVCLENBQUMsTUFBTTs2QkFFN0MsbUZBS0M7aUJBRUo7Ozs7Z0JBNUJDLFVBQVU7Z0JBUTBCLHdCQUF3Qjs7OytCQXdCM0QsS0FBSzs2QkFFTCxLQUFLO3lCQUVMLEtBQUs7MkJBRUwsS0FBSzsyQkFFTCxLQUFLOytCQUVMLEtBQUs7K0JBRUwsS0FBSzs0QkFFTCxLQUFLOzZCQUVMLEtBQUs7K0JBRUwsS0FBSzt5QkFFTCxLQUFLOzBCQUVMLEtBQUs7NkJBRUwsS0FBSzs7SUF0Qm1CO1FBQWYsWUFBWSxFQUFFOzt1REFBb0I7SUFZbkI7UUFBZixZQUFZLEVBQUU7O3NEQUFtQjtJQVFsQjtRQUFmLFlBQVksRUFBRTs7b0RBQWdCO0lBb0MxQyxzQkFBQztDQUFBLEFBOUVELElBOEVDO1NBN0RZLGVBQWU7OztJQUcxQix1Q0FBNkI7O0lBRTdCLHFDQUE0Qzs7SUFFNUMsaUNBQTRCOztJQUU1QixtQ0FBOEM7O0lBRTlDLG1DQUE4Qzs7SUFFOUMsdUNBQWdFOztJQUVoRSx1Q0FBeUM7O0lBRXpDLG9DQUEyQzs7SUFFM0MscUNBQXVDOztJQUV2Qyx1Q0FBeUM7O0lBRXpDLGlDQUEyQzs7SUFFM0Msa0NBQXdDOztJQUV4QyxxQ0FBZ0Q7Ozs7O0lBTWhELG9DQUErQjs7Ozs7SUFtQm5CLDZCQUFzQjs7Ozs7SUFBRSxpREFBd0QiLCJzb3VyY2VzQ29udGVudCI6WyIvKipcbiAqIEBsaWNlbnNlXG4gKiBDb3B5cmlnaHQgQWxpYmFiYS5jb20gQWxsIFJpZ2h0cyBSZXNlcnZlZC5cbiAqXG4gKiBVc2Ugb2YgdGhpcyBzb3VyY2UgY29kZSBpcyBnb3Zlcm5lZCBieSBhbiBNSVQtc3R5bGUgbGljZW5zZSB0aGF0IGNhbiBiZVxuICogZm91bmQgaW4gdGhlIExJQ0VOU0UgZmlsZSBhdCBodHRwczovL2dpdGh1Yi5jb20vTkctWk9SUk8vbmctem9ycm8tYW50ZC9ibG9iL21hc3Rlci9MSUNFTlNFXG4gKi9cblxuaW1wb3J0IHtcbiAgQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3ksXG4gIENvbXBvbmVudCxcbiAgRWxlbWVudFJlZixcbiAgSW5wdXQsXG4gIE9uQ2hhbmdlcyxcbiAgT25Jbml0LFxuICBUZW1wbGF0ZVJlZixcbiAgVmlld0VuY2Fwc3VsYXRpb25cbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmltcG9ydCB7IElucHV0Qm9vbGVhbiwgTnpTaXplTERTVHlwZSwgTnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlIH0gZnJvbSAnbmctem9ycm8tYW50ZC9jb3JlJztcblxuaW1wb3J0IHsgTnpMaXN0R3JpZCB9IGZyb20gJy4vaW50ZXJmYWNlJztcblxuQENvbXBvbmVudCh7XG4gIHNlbGVjdG9yOiAnbnotbGlzdCcsXG4gIGV4cG9ydEFzOiAnbnpMaXN0JyxcbiAgdGVtcGxhdGVVcmw6ICcuL256LWxpc3QuY29tcG9uZW50Lmh0bWwnLFxuICBwcm92aWRlcnM6IFtOelVwZGF0ZUhvc3RDbGFzc1NlcnZpY2VdLFxuICBwcmVzZXJ2ZVdoaXRlc3BhY2VzOiBmYWxzZSxcbiAgZW5jYXBzdWxhdGlvbjogVmlld0VuY2Fwc3VsYXRpb24uTm9uZSxcbiAgY2hhbmdlRGV0ZWN0aW9uOiBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneS5PblB1c2gsXG4gIHN0eWxlczogW1xuICAgIGBcbiAgICAgIG56LWxpc3QsXG4gICAgICBuei1saXN0IG56LXNwaW4ge1xuICAgICAgICBkaXNwbGF5OiBibG9jaztcbiAgICAgIH1cbiAgICBgXG4gIF1cbn0pXG5leHBvcnQgY2xhc3MgTnpMaXN0Q29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0LCBPbkNoYW5nZXMge1xuICAvLyAjcmVnaW9uIGZpZWxkc1xuICAvLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6bm8tYW55XG4gIEBJbnB1dCgpIG56RGF0YVNvdXJjZTogYW55W107XG5cbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56Qm9yZGVyZWQgPSBmYWxzZTtcblxuICBASW5wdXQoKSBuekdyaWQ6IE56TGlzdEdyaWQ7XG5cbiAgQElucHV0KCkgbnpIZWFkZXI6IHN0cmluZyB8IFRlbXBsYXRlUmVmPHZvaWQ+O1xuXG4gIEBJbnB1dCgpIG56Rm9vdGVyOiBzdHJpbmcgfCBUZW1wbGF0ZVJlZjx2b2lkPjtcblxuICBASW5wdXQoKSBuekl0ZW1MYXlvdXQ6ICd2ZXJ0aWNhbCcgfCAnaG9yaXpvbnRhbCcgPSAnaG9yaXpvbnRhbCc7XG5cbiAgQElucHV0KCkgbnpSZW5kZXJJdGVtOiBUZW1wbGF0ZVJlZjx2b2lkPjtcblxuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpMb2FkaW5nID0gZmFsc2U7XG5cbiAgQElucHV0KCkgbnpMb2FkTW9yZTogVGVtcGxhdGVSZWY8dm9pZD47XG5cbiAgQElucHV0KCkgbnpQYWdpbmF0aW9uOiBUZW1wbGF0ZVJlZjx2b2lkPjtcblxuICBASW5wdXQoKSBuelNpemU6IE56U2l6ZUxEU1R5cGUgPSAnZGVmYXVsdCc7XG5cbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56U3BsaXQgPSB0cnVlO1xuXG4gIEBJbnB1dCgpIG56Tm9SZXN1bHQ6IHN0cmluZyB8IFRlbXBsYXRlUmVmPHZvaWQ+O1xuXG4gIC8vICNlbmRyZWdpb25cblxuICAvLyAjcmVnaW9uIHN0eWxlc1xuXG4gIHByaXZhdGUgcHJlZml4Q2xzID0gJ2FudC1saXN0JztcblxuICBwcml2YXRlIF9zZXRDbGFzc01hcCgpOiB2b2lkIHtcbiAgICBjb25zdCBjbGFzc01hcCA9IHtcbiAgICAgIFt0aGlzLnByZWZpeENsc106IHRydWUsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXZlcnRpY2FsYF06IHRoaXMubnpJdGVtTGF5b3V0ID09PSAndmVydGljYWwnLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1sZ2BdOiB0aGlzLm56U2l6ZSA9PT0gJ2xhcmdlJyxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tc21gXTogdGhpcy5uelNpemUgPT09ICdzbWFsbCcsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXNwbGl0YF06IHRoaXMubnpTcGxpdCxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tYm9yZGVyZWRgXTogdGhpcy5uekJvcmRlcmVkLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1sb2FkaW5nYF06IHRoaXMubnpMb2FkaW5nLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1ncmlkYF06IHRoaXMubnpHcmlkLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1zb21ldGhpbmctYWZ0ZXItbGFzdC1pdGVtYF06ICEhKHRoaXMubnpMb2FkTW9yZSB8fCB0aGlzLm56UGFnaW5hdGlvbiB8fCB0aGlzLm56Rm9vdGVyKVxuICAgIH07XG4gICAgdGhpcy51cGRhdGVIb3N0Q2xhc3NTZXJ2aWNlLnVwZGF0ZUhvc3RDbGFzcyh0aGlzLmVsLm5hdGl2ZUVsZW1lbnQsIGNsYXNzTWFwKTtcbiAgfVxuXG4gIC8vICNlbmRyZWdpb25cblxuICBjb25zdHJ1Y3Rvcihwcml2YXRlIGVsOiBFbGVtZW50UmVmLCBwcml2YXRlIHVwZGF0ZUhvc3RDbGFzc1NlcnZpY2U6IE56VXBkYXRlSG9zdENsYXNzU2VydmljZSkge31cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICB0aGlzLl9zZXRDbGFzc01hcCgpO1xuICB9XG5cbiAgbmdPbkNoYW5nZXMoKTogdm9pZCB7XG4gICAgdGhpcy5fc2V0Q2xhc3NNYXAoKTtcbiAgfVxufVxuIl19