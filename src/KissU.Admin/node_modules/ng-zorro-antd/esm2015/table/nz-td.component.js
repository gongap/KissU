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
import { ChangeDetectionStrategy, Component, ElementRef, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';
import { isNotNil, InputBoolean, NzUpdateHostClassService } from 'ng-zorro-antd/core';
export class NzTdComponent {
    /**
     * @param {?} elementRef
     * @param {?} nzUpdateHostClassService
     */
    constructor(elementRef, nzUpdateHostClassService) {
        this.elementRef = elementRef;
        this.nzUpdateHostClassService = nzUpdateHostClassService;
        this.nzChecked = false;
        this.nzDisabled = false;
        this.nzIndeterminate = false;
        this.nzExpand = false;
        this.nzShowExpand = false;
        this.nzShowCheckbox = false;
        this.nzCheckedChange = new EventEmitter();
        this.nzExpandChange = new EventEmitter();
    }
    /**
     * @param {?} e
     * @return {?}
     */
    expandChange(e) {
        e.stopPropagation();
        this.nzExpand = !this.nzExpand;
        this.nzExpandChange.emit(this.nzExpand);
    }
    /**
     * @return {?}
     */
    setClassMap() {
        this.nzUpdateHostClassService.updateHostClass(this.elementRef.nativeElement, {
            [`ant-table-row-expand-icon-cell`]: this.nzShowExpand && !isNotNil(this.nzIndentSize),
            [`ant-table-selection-column`]: this.nzShowCheckbox,
            [`ant-table-td-left-sticky`]: isNotNil(this.nzLeft),
            [`ant-table-td-right-sticky`]: isNotNil(this.nzRight)
        });
    }
    /**
     * @param {?} changes
     * @return {?}
     */
    ngOnChanges(changes) {
        if (changes.nzIndentSize || changes.nzShowExpand || changes.nzShowCheckbox || changes.nzRight || changes.nzLeft) {
            this.setClassMap();
        }
    }
}
NzTdComponent.decorators = [
    { type: Component, args: [{
                // tslint:disable-next-line:component-selector
                selector: 'td:not(.nz-disable-td)',
                changeDetection: ChangeDetectionStrategy.OnPush,
                providers: [NzUpdateHostClassService],
                preserveWhitespaces: false,
                encapsulation: ViewEncapsulation.None,
                template: "<span class=\"ant-table-row-indent\" *ngIf=\"nzIndentSize >= 0\" [style.padding-left.px]=\"nzIndentSize\"></span>\n<label *ngIf=\"nzShowCheckbox\"\n  nz-checkbox\n  [nzDisabled]=\"nzDisabled\"\n  [(ngModel)]=\"nzChecked\"\n  [nzIndeterminate]=\"nzIndeterminate\"\n  (ngModelChange)=\"nzCheckedChange.emit($event)\">\n</label>\n<span *ngIf=\"!nzShowExpand && nzIndentSize >= 0\"\n  class=\"ant-table-row-expand-icon ant-table-row-spaced\">\n</span>\n<span *ngIf=\"nzShowExpand\"\n  class=\"ant-table-row-expand-icon\"\n  [class.ant-table-row-expanded]=\"nzExpand\"\n  [class.ant-table-row-collapsed]=\"!nzExpand\"\n  (click)=\"expandChange($event)\">\n</span>\n<ng-content></ng-content>",
                host: {
                    '[style.left]': 'nzLeft',
                    '[style.right]': 'nzRight',
                    '[style.text-align]': 'nzAlign'
                }
            }] }
];
/** @nocollapse */
NzTdComponent.ctorParameters = () => [
    { type: ElementRef },
    { type: NzUpdateHostClassService }
];
NzTdComponent.propDecorators = {
    nzChecked: [{ type: Input }],
    nzDisabled: [{ type: Input }],
    nzIndeterminate: [{ type: Input }],
    nzLeft: [{ type: Input }],
    nzRight: [{ type: Input }],
    nzAlign: [{ type: Input }],
    nzIndentSize: [{ type: Input }],
    nzExpand: [{ type: Input }],
    nzShowExpand: [{ type: Input }],
    nzShowCheckbox: [{ type: Input }],
    nzCheckedChange: [{ type: Output }],
    nzExpandChange: [{ type: Output }]
};
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzTdComponent.prototype, "nzExpand", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzTdComponent.prototype, "nzShowExpand", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzTdComponent.prototype, "nzShowCheckbox", void 0);
if (false) {
    /** @type {?} */
    NzTdComponent.prototype.nzChecked;
    /** @type {?} */
    NzTdComponent.prototype.nzDisabled;
    /** @type {?} */
    NzTdComponent.prototype.nzIndeterminate;
    /** @type {?} */
    NzTdComponent.prototype.nzLeft;
    /** @type {?} */
    NzTdComponent.prototype.nzRight;
    /** @type {?} */
    NzTdComponent.prototype.nzAlign;
    /** @type {?} */
    NzTdComponent.prototype.nzIndentSize;
    /** @type {?} */
    NzTdComponent.prototype.nzExpand;
    /** @type {?} */
    NzTdComponent.prototype.nzShowExpand;
    /** @type {?} */
    NzTdComponent.prototype.nzShowCheckbox;
    /** @type {?} */
    NzTdComponent.prototype.nzCheckedChange;
    /** @type {?} */
    NzTdComponent.prototype.nzExpandChange;
    /**
     * @type {?}
     * @private
     */
    NzTdComponent.prototype.elementRef;
    /**
     * @type {?}
     * @private
     */
    NzTdComponent.prototype.nzUpdateHostClassService;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotdGQuY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC90YWJsZS8iLCJzb3VyY2VzIjpbIm56LXRkLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQ0wsdUJBQXVCLEVBQ3ZCLFNBQVMsRUFDVCxVQUFVLEVBQ1YsWUFBWSxFQUNaLEtBQUssRUFFTCxNQUFNLEVBRU4saUJBQWlCLEVBQ2xCLE1BQU0sZUFBZSxDQUFDO0FBRXZCLE9BQU8sRUFBRSxRQUFRLEVBQUUsWUFBWSxFQUFFLHdCQUF3QixFQUFFLE1BQU0sb0JBQW9CLENBQUM7QUFnQnRGLE1BQU0sT0FBTyxhQUFhOzs7OztJQTZCeEIsWUFBb0IsVUFBc0IsRUFBVSx3QkFBa0Q7UUFBbEYsZUFBVSxHQUFWLFVBQVUsQ0FBWTtRQUFVLDZCQUF3QixHQUF4Qix3QkFBd0IsQ0FBMEI7UUE1QjdGLGNBQVMsR0FBRyxLQUFLLENBQUM7UUFDbEIsZUFBVSxHQUFHLEtBQUssQ0FBQztRQUNuQixvQkFBZSxHQUFHLEtBQUssQ0FBQztRQUtSLGFBQVEsR0FBRyxLQUFLLENBQUM7UUFDakIsaUJBQVksR0FBRyxLQUFLLENBQUM7UUFDckIsbUJBQWMsR0FBRyxLQUFLLENBQUM7UUFDN0Isb0JBQWUsR0FBRyxJQUFJLFlBQVksRUFBVyxDQUFDO1FBQzlDLG1CQUFjLEdBQUcsSUFBSSxZQUFZLEVBQVcsQ0FBQztJQWlCeUMsQ0FBQzs7Ozs7SUFmMUcsWUFBWSxDQUFDLENBQVE7UUFDbkIsQ0FBQyxDQUFDLGVBQWUsRUFBRSxDQUFDO1FBQ3BCLElBQUksQ0FBQyxRQUFRLEdBQUcsQ0FBQyxJQUFJLENBQUMsUUFBUSxDQUFDO1FBQy9CLElBQUksQ0FBQyxjQUFjLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxRQUFRLENBQUMsQ0FBQztJQUMxQyxDQUFDOzs7O0lBRUQsV0FBVztRQUNULElBQUksQ0FBQyx3QkFBd0IsQ0FBQyxlQUFlLENBQUMsSUFBSSxDQUFDLFVBQVUsQ0FBQyxhQUFhLEVBQUU7WUFDM0UsQ0FBQyxnQ0FBZ0MsQ0FBQyxFQUFFLElBQUksQ0FBQyxZQUFZLElBQUksQ0FBQyxRQUFRLENBQUMsSUFBSSxDQUFDLFlBQVksQ0FBQztZQUNyRixDQUFDLDRCQUE0QixDQUFDLEVBQUUsSUFBSSxDQUFDLGNBQWM7WUFDbkQsQ0FBQywwQkFBMEIsQ0FBQyxFQUFFLFFBQVEsQ0FBQyxJQUFJLENBQUMsTUFBTSxDQUFDO1lBQ25ELENBQUMsMkJBQTJCLENBQUMsRUFBRSxRQUFRLENBQUMsSUFBSSxDQUFDLE9BQU8sQ0FBQztTQUN0RCxDQUFDLENBQUM7SUFDTCxDQUFDOzs7OztJQUlELFdBQVcsQ0FBQyxPQUFzQjtRQUNoQyxJQUFJLE9BQU8sQ0FBQyxZQUFZLElBQUksT0FBTyxDQUFDLFlBQVksSUFBSSxPQUFPLENBQUMsY0FBYyxJQUFJLE9BQU8sQ0FBQyxPQUFPLElBQUksT0FBTyxDQUFDLE1BQU0sRUFBRTtZQUMvRyxJQUFJLENBQUMsV0FBVyxFQUFFLENBQUM7U0FDcEI7SUFDSCxDQUFDOzs7WUFqREYsU0FBUyxTQUFDOztnQkFFVCxRQUFRLEVBQUUsd0JBQXdCO2dCQUNsQyxlQUFlLEVBQUUsdUJBQXVCLENBQUMsTUFBTTtnQkFDL0MsU0FBUyxFQUFFLENBQUMsd0JBQXdCLENBQUM7Z0JBQ3JDLG1CQUFtQixFQUFFLEtBQUs7Z0JBQzFCLGFBQWEsRUFBRSxpQkFBaUIsQ0FBQyxJQUFJO2dCQUNyQyx5ckJBQXFDO2dCQUNyQyxJQUFJLEVBQUU7b0JBQ0osY0FBYyxFQUFFLFFBQVE7b0JBQ3hCLGVBQWUsRUFBRSxTQUFTO29CQUMxQixvQkFBb0IsRUFBRSxTQUFTO2lCQUNoQzthQUNGOzs7O1lBeEJDLFVBQVU7WUFTcUIsd0JBQXdCOzs7d0JBaUJ0RCxLQUFLO3lCQUNMLEtBQUs7OEJBQ0wsS0FBSztxQkFDTCxLQUFLO3NCQUNMLEtBQUs7c0JBQ0wsS0FBSzsyQkFDTCxLQUFLO3VCQUNMLEtBQUs7MkJBQ0wsS0FBSzs2QkFDTCxLQUFLOzhCQUNMLE1BQU07NkJBQ04sTUFBTTs7QUFKa0I7SUFBZixZQUFZLEVBQUU7OytDQUFrQjtBQUNqQjtJQUFmLFlBQVksRUFBRTs7bURBQXNCO0FBQ3JCO0lBQWYsWUFBWSxFQUFFOztxREFBd0I7OztJQVRoRCxrQ0FBMkI7O0lBQzNCLG1DQUE0Qjs7SUFDNUIsd0NBQWlDOztJQUNqQywrQkFBd0I7O0lBQ3hCLGdDQUF5Qjs7SUFDekIsZ0NBQThDOztJQUM5QyxxQ0FBOEI7O0lBQzlCLGlDQUEwQzs7SUFDMUMscUNBQThDOztJQUM5Qyx1Q0FBZ0Q7O0lBQ2hELHdDQUFpRTs7SUFDakUsdUNBQWdFOzs7OztJQWlCcEQsbUNBQThCOzs7OztJQUFFLGlEQUEwRCIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ29tcG9uZW50LFxuICBFbGVtZW50UmVmLFxuICBFdmVudEVtaXR0ZXIsXG4gIElucHV0LFxuICBPbkNoYW5nZXMsXG4gIE91dHB1dCxcbiAgU2ltcGxlQ2hhbmdlcyxcbiAgVmlld0VuY2Fwc3VsYXRpb25cbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5cbmltcG9ydCB7IGlzTm90TmlsLCBJbnB1dEJvb2xlYW4sIE56VXBkYXRlSG9zdENsYXNzU2VydmljZSB9IGZyb20gJ25nLXpvcnJvLWFudGQvY29yZSc7XG5cbkBDb21wb25lbnQoe1xuICAvLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6Y29tcG9uZW50LXNlbGVjdG9yXG4gIHNlbGVjdG9yOiAndGQ6bm90KC5uei1kaXNhYmxlLXRkKScsXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxuICBwcm92aWRlcnM6IFtOelVwZGF0ZUhvc3RDbGFzc1NlcnZpY2VdLFxuICBwcmVzZXJ2ZVdoaXRlc3BhY2VzOiBmYWxzZSxcbiAgZW5jYXBzdWxhdGlvbjogVmlld0VuY2Fwc3VsYXRpb24uTm9uZSxcbiAgdGVtcGxhdGVVcmw6ICcuL256LXRkLmNvbXBvbmVudC5odG1sJyxcbiAgaG9zdDoge1xuICAgICdbc3R5bGUubGVmdF0nOiAnbnpMZWZ0JyxcbiAgICAnW3N0eWxlLnJpZ2h0XSc6ICduelJpZ2h0JyxcbiAgICAnW3N0eWxlLnRleHQtYWxpZ25dJzogJ256QWxpZ24nXG4gIH1cbn0pXG5leHBvcnQgY2xhc3MgTnpUZENvbXBvbmVudCBpbXBsZW1lbnRzIE9uQ2hhbmdlcyB7XG4gIEBJbnB1dCgpIG56Q2hlY2tlZCA9IGZhbHNlO1xuICBASW5wdXQoKSBuekRpc2FibGVkID0gZmFsc2U7XG4gIEBJbnB1dCgpIG56SW5kZXRlcm1pbmF0ZSA9IGZhbHNlO1xuICBASW5wdXQoKSBuekxlZnQ6IHN0cmluZztcbiAgQElucHV0KCkgbnpSaWdodDogc3RyaW5nO1xuICBASW5wdXQoKSBuekFsaWduOiAnbGVmdCcgfCAncmlnaHQnIHwgJ2NlbnRlcic7XG4gIEBJbnB1dCgpIG56SW5kZW50U2l6ZTogbnVtYmVyO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpFeHBhbmQgPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56U2hvd0V4cGFuZCA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpTaG93Q2hlY2tib3ggPSBmYWxzZTtcbiAgQE91dHB1dCgpIHJlYWRvbmx5IG56Q2hlY2tlZENoYW5nZSA9IG5ldyBFdmVudEVtaXR0ZXI8Ym9vbGVhbj4oKTtcbiAgQE91dHB1dCgpIHJlYWRvbmx5IG56RXhwYW5kQ2hhbmdlID0gbmV3IEV2ZW50RW1pdHRlcjxib29sZWFuPigpO1xuXG4gIGV4cGFuZENoYW5nZShlOiBFdmVudCk6IHZvaWQge1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgdGhpcy5uekV4cGFuZCA9ICF0aGlzLm56RXhwYW5kO1xuICAgIHRoaXMubnpFeHBhbmRDaGFuZ2UuZW1pdCh0aGlzLm56RXhwYW5kKTtcbiAgfVxuXG4gIHNldENsYXNzTWFwKCk6IHZvaWQge1xuICAgIHRoaXMubnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlLnVwZGF0ZUhvc3RDbGFzcyh0aGlzLmVsZW1lbnRSZWYubmF0aXZlRWxlbWVudCwge1xuICAgICAgW2BhbnQtdGFibGUtcm93LWV4cGFuZC1pY29uLWNlbGxgXTogdGhpcy5uelNob3dFeHBhbmQgJiYgIWlzTm90TmlsKHRoaXMubnpJbmRlbnRTaXplKSxcbiAgICAgIFtgYW50LXRhYmxlLXNlbGVjdGlvbi1jb2x1bW5gXTogdGhpcy5uelNob3dDaGVja2JveCxcbiAgICAgIFtgYW50LXRhYmxlLXRkLWxlZnQtc3RpY2t5YF06IGlzTm90TmlsKHRoaXMubnpMZWZ0KSxcbiAgICAgIFtgYW50LXRhYmxlLXRkLXJpZ2h0LXN0aWNreWBdOiBpc05vdE5pbCh0aGlzLm56UmlnaHQpXG4gICAgfSk7XG4gIH1cblxuICBjb25zdHJ1Y3Rvcihwcml2YXRlIGVsZW1lbnRSZWY6IEVsZW1lbnRSZWYsIHByaXZhdGUgbnpVcGRhdGVIb3N0Q2xhc3NTZXJ2aWNlOiBOelVwZGF0ZUhvc3RDbGFzc1NlcnZpY2UpIHt9XG5cbiAgbmdPbkNoYW5nZXMoY2hhbmdlczogU2ltcGxlQ2hhbmdlcyk6IHZvaWQge1xuICAgIGlmIChjaGFuZ2VzLm56SW5kZW50U2l6ZSB8fCBjaGFuZ2VzLm56U2hvd0V4cGFuZCB8fCBjaGFuZ2VzLm56U2hvd0NoZWNrYm94IHx8IGNoYW5nZXMubnpSaWdodCB8fCBjaGFuZ2VzLm56TGVmdCkge1xuICAgICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICAgIH1cbiAgfVxufVxuIl19