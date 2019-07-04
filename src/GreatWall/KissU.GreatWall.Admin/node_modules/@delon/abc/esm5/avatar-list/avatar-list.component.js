/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ContentChildren, Input, QueryList, } from '@angular/core';
import { InputNumber } from '@delon/util';
import { AvatarListItemComponent } from './avatar-list-item.component';
var AvatarListComponent = /** @class */ (function () {
    function AvatarListComponent(cdr) {
        this.cdr = cdr;
        this.inited = false;
        this.items = [];
        this.exceedCount = 0;
        this.cls = '';
        this.avatarSize = '';
        this.maxLength = 0;
    }
    Object.defineProperty(AvatarListComponent.prototype, "size", {
        set: /**
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this.cls = 'avatar-list__item' + (value === 'default' ? '' : " avatar-list__" + value);
            switch (value) {
                case 'large':
                case 'small':
                case 'default':
                    this.avatarSize = value;
                    break;
                default:
                    this.avatarSize = 'small';
                    break;
            }
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @private
     * @return {?}
     */
    AvatarListComponent.prototype.gen = /**
     * @private
     * @return {?}
     */
    function () {
        var _items = this._items;
        /** @type {?} */
        var maxLength = this.maxLength > 0 ? this.maxLength : _items.length;
        /** @type {?} */
        var numOfChildren = _items.length;
        /** @type {?} */
        var numToShow = maxLength > 0 && maxLength >= numOfChildren ? numOfChildren : maxLength;
        this.items = _items.toArray().slice(0, numToShow);
        this.exceedCount = numToShow < numOfChildren ? numOfChildren - maxLength : 0;
        this.cdr.detectChanges();
    };
    /**
     * @return {?}
     */
    AvatarListComponent.prototype.ngAfterViewInit = /**
     * @return {?}
     */
    function () {
        this.gen();
        this.inited = true;
    };
    /**
     * @return {?}
     */
    AvatarListComponent.prototype.ngOnChanges = /**
     * @return {?}
     */
    function () {
        if (this.inited) {
            this.gen();
        }
    };
    AvatarListComponent.decorators = [
        { type: Component, args: [{
                    selector: 'avatar-list',
                    template: "<ul class=\"avatar-list__wrap\">\n  <li *ngFor=\"let i of items\"\n      [class]=\"cls\">\n    <nz-tooltip *ngIf=\"i.tips\"\n                [nzTitle]=\"i.tips\">\n      <nz-avatar nz-tooltip\n                 [nzSrc]=\"i.src\"\n                 [nzText]=\"i.text\"\n                 [nzIcon]=\"i.icon\"\n                 [nzSize]=\"avatarSize\"></nz-avatar>\n    </nz-tooltip>\n    <nz-avatar *ngIf=\"!i.tips\"\n               [nzSrc]=\"i.src\"\n               [nzText]=\"i.text\"\n               [nzIcon]=\"i.icon\"\n               [nzSize]=\"avatarSize\"></nz-avatar>\n  </li>\n  <li *ngIf=\"exceedCount > 0\"\n      [class]=\"cls\">\n    <nz-avatar [nzSize]=\"avatarSize\"\n               style=\"cursor: auto\"\n               [ngStyle]=\"excessItemsStyle\"\n               [nzText]=\"'+' + exceedCount\"></nz-avatar>\n  </li>\n</ul>\n",
                    host: { '[class.avatar-list]': 'true' },
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    AvatarListComponent.ctorParameters = function () { return [
        { type: ChangeDetectorRef }
    ]; };
    AvatarListComponent.propDecorators = {
        _items: [{ type: ContentChildren, args: [AvatarListItemComponent, { descendants: false },] }],
        size: [{ type: Input }],
        maxLength: [{ type: Input }],
        excessItemsStyle: [{ type: Input }]
    };
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Object)
    ], AvatarListComponent.prototype, "maxLength", void 0);
    return AvatarListComponent;
}());
export { AvatarListComponent };
if (false) {
    /**
     * @type {?}
     * @private
     */
    AvatarListComponent.prototype.inited;
    /**
     * @type {?}
     * @private
     */
    AvatarListComponent.prototype._items;
    /** @type {?} */
    AvatarListComponent.prototype.items;
    /** @type {?} */
    AvatarListComponent.prototype.exceedCount;
    /** @type {?} */
    AvatarListComponent.prototype.cls;
    /** @type {?} */
    AvatarListComponent.prototype.avatarSize;
    /** @type {?} */
    AvatarListComponent.prototype.maxLength;
    /** @type {?} */
    AvatarListComponent.prototype.excessItemsStyle;
    /**
     * @type {?}
     * @private
     */
    AvatarListComponent.prototype.cdr;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiYXZhdGFyLWxpc3QuY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy9hdmF0YXItbGlzdC8iLCJzb3VyY2VzIjpbImF2YXRhci1saXN0LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7OztBQUFBLE9BQU8sRUFFTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxlQUFlLEVBQ2YsS0FBSyxFQUVMLFNBQVMsR0FDVixNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQUUsV0FBVyxFQUFFLE1BQU0sYUFBYSxDQUFDO0FBRTFDLE9BQU8sRUFBRSx1QkFBdUIsRUFBRSxNQUFNLDhCQUE4QixDQUFDO0FBRXZFO0lBaUNFLDZCQUFvQixHQUFzQjtRQUF0QixRQUFHLEdBQUgsR0FBRyxDQUFtQjtRQTFCbEMsV0FBTSxHQUFHLEtBQUssQ0FBQztRQUl2QixVQUFLLEdBQThCLEVBQUUsQ0FBQztRQUN0QyxnQkFBVyxHQUFHLENBQUMsQ0FBQztRQUVoQixRQUFHLEdBQUcsRUFBRSxDQUFDO1FBQ1QsZUFBVSxHQUFHLEVBQUUsQ0FBQztRQWVRLGNBQVMsR0FBRyxDQUFDLENBQUM7SUFHTyxDQUFDO0lBakI5QyxzQkFDSSxxQ0FBSTs7Ozs7UUFEUixVQUNTLEtBQTZDO1lBQ3BELElBQUksQ0FBQyxHQUFHLEdBQUcsbUJBQW1CLEdBQUcsQ0FBQyxLQUFLLEtBQUssU0FBUyxDQUFDLENBQUMsQ0FBQyxFQUFFLENBQUMsQ0FBQyxDQUFDLG1CQUFpQixLQUFPLENBQUMsQ0FBQztZQUN2RixRQUFRLEtBQUssRUFBRTtnQkFDYixLQUFLLE9BQU8sQ0FBQztnQkFDYixLQUFLLE9BQU8sQ0FBQztnQkFDYixLQUFLLFNBQVM7b0JBQ1osSUFBSSxDQUFDLFVBQVUsR0FBRyxLQUFLLENBQUM7b0JBQ3hCLE1BQU07Z0JBQ1I7b0JBQ0UsSUFBSSxDQUFDLFVBQVUsR0FBRyxPQUFPLENBQUM7b0JBQzFCLE1BQU07YUFDVDtRQUNILENBQUM7OztPQUFBOzs7OztJQU1PLGlDQUFHOzs7O0lBQVg7UUFDVSxJQUFBLG9CQUFNOztZQUNSLFNBQVMsR0FBRyxJQUFJLENBQUMsU0FBUyxHQUFHLENBQUMsQ0FBQyxDQUFDLENBQUMsSUFBSSxDQUFDLFNBQVMsQ0FBQyxDQUFDLENBQUMsTUFBTSxDQUFDLE1BQU07O1lBQy9ELGFBQWEsR0FBRyxNQUFNLENBQUMsTUFBTTs7WUFDN0IsU0FBUyxHQUFHLFNBQVMsR0FBRyxDQUFDLElBQUksU0FBUyxJQUFJLGFBQWEsQ0FBQyxDQUFDLENBQUMsYUFBYSxDQUFDLENBQUMsQ0FBQyxTQUFTO1FBQ3pGLElBQUksQ0FBQyxLQUFLLEdBQUcsTUFBTSxDQUFDLE9BQU8sRUFBRSxDQUFDLEtBQUssQ0FBQyxDQUFDLEVBQUUsU0FBUyxDQUFDLENBQUM7UUFDbEQsSUFBSSxDQUFDLFdBQVcsR0FBRyxTQUFTLEdBQUcsYUFBYSxDQUFDLENBQUMsQ0FBQyxhQUFhLEdBQUcsU0FBUyxDQUFDLENBQUMsQ0FBQyxDQUFDLENBQUM7UUFDN0UsSUFBSSxDQUFDLEdBQUcsQ0FBQyxhQUFhLEVBQUUsQ0FBQztJQUMzQixDQUFDOzs7O0lBRUQsNkNBQWU7OztJQUFmO1FBQ0UsSUFBSSxDQUFDLEdBQUcsRUFBRSxDQUFDO1FBQ1gsSUFBSSxDQUFDLE1BQU0sR0FBRyxJQUFJLENBQUM7SUFDckIsQ0FBQzs7OztJQUVELHlDQUFXOzs7SUFBWDtRQUNFLElBQUksSUFBSSxDQUFDLE1BQU0sRUFBRTtZQUNmLElBQUksQ0FBQyxHQUFHLEVBQUUsQ0FBQztTQUNaO0lBQ0gsQ0FBQzs7Z0JBdERGLFNBQVMsU0FBQztvQkFDVCxRQUFRLEVBQUUsYUFBYTtvQkFDdkIsbzFCQUEyQztvQkFDM0MsSUFBSSxFQUFFLEVBQUUscUJBQXFCLEVBQUUsTUFBTSxFQUFFO29CQUN2QyxlQUFlLEVBQUUsdUJBQXVCLENBQUMsTUFBTTtpQkFDaEQ7Ozs7Z0JBaEJDLGlCQUFpQjs7O3lCQW1CaEIsZUFBZSxTQUFDLHVCQUF1QixFQUFFLEVBQUUsV0FBVyxFQUFFLEtBQUssRUFBRTt1QkFRL0QsS0FBSzs0QkFjTCxLQUFLO21DQUNMLEtBQUs7O0lBRGtCO1FBQWQsV0FBVyxFQUFFOzswREFBZTtJQXlCeEMsMEJBQUM7Q0FBQSxBQXZERCxJQXVEQztTQWpEWSxtQkFBbUI7Ozs7OztJQUM5QixxQ0FBdUI7Ozs7O0lBQ3ZCLHFDQUNvRDs7SUFFcEQsb0NBQXNDOztJQUN0QywwQ0FBZ0I7O0lBRWhCLGtDQUFTOztJQUNULHlDQUFnQjs7SUFlaEIsd0NBQXNDOztJQUN0QywrQ0FBOEI7Ozs7O0lBRWxCLGtDQUE4QiIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7XG4gIEFmdGVyVmlld0luaXQsXG4gIENoYW5nZURldGVjdGlvblN0cmF0ZWd5LFxuICBDaGFuZ2VEZXRlY3RvclJlZixcbiAgQ29tcG9uZW50LFxuICBDb250ZW50Q2hpbGRyZW4sXG4gIElucHV0LFxuICBPbkNoYW5nZXMsXG4gIFF1ZXJ5TGlzdCxcbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBJbnB1dE51bWJlciB9IGZyb20gJ0BkZWxvbi91dGlsJztcblxuaW1wb3J0IHsgQXZhdGFyTGlzdEl0ZW1Db21wb25lbnQgfSBmcm9tICcuL2F2YXRhci1saXN0LWl0ZW0uY29tcG9uZW50JztcblxuQENvbXBvbmVudCh7XG4gIHNlbGVjdG9yOiAnYXZhdGFyLWxpc3QnLFxuICB0ZW1wbGF0ZVVybDogJy4vYXZhdGFyLWxpc3QuY29tcG9uZW50Lmh0bWwnLFxuICBob3N0OiB7ICdbY2xhc3MuYXZhdGFyLWxpc3RdJzogJ3RydWUnIH0sXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxufSlcbmV4cG9ydCBjbGFzcyBBdmF0YXJMaXN0Q29tcG9uZW50IGltcGxlbWVudHMgQWZ0ZXJWaWV3SW5pdCwgT25DaGFuZ2VzIHtcbiAgcHJpdmF0ZSBpbml0ZWQgPSBmYWxzZTtcbiAgQENvbnRlbnRDaGlsZHJlbihBdmF0YXJMaXN0SXRlbUNvbXBvbmVudCwgeyBkZXNjZW5kYW50czogZmFsc2UgfSlcbiAgcHJpdmF0ZSBfaXRlbXMhOiBRdWVyeUxpc3Q8QXZhdGFyTGlzdEl0ZW1Db21wb25lbnQ+O1xuXG4gIGl0ZW1zOiBBdmF0YXJMaXN0SXRlbUNvbXBvbmVudFtdID0gW107XG4gIGV4Y2VlZENvdW50ID0gMDtcblxuICBjbHMgPSAnJztcbiAgYXZhdGFyU2l6ZSA9ICcnO1xuICBASW5wdXQoKVxuICBzZXQgc2l6ZSh2YWx1ZTogJ2xhcmdlJyB8ICdzbWFsbCcgfCAnbWluaScgfCAnZGVmYXVsdCcpIHtcbiAgICB0aGlzLmNscyA9ICdhdmF0YXItbGlzdF9faXRlbScgKyAodmFsdWUgPT09ICdkZWZhdWx0JyA/ICcnIDogYCBhdmF0YXItbGlzdF9fJHt2YWx1ZX1gKTtcbiAgICBzd2l0Y2ggKHZhbHVlKSB7XG4gICAgICBjYXNlICdsYXJnZSc6XG4gICAgICBjYXNlICdzbWFsbCc6XG4gICAgICBjYXNlICdkZWZhdWx0JzpcbiAgICAgICAgdGhpcy5hdmF0YXJTaXplID0gdmFsdWU7XG4gICAgICAgIGJyZWFrO1xuICAgICAgZGVmYXVsdDpcbiAgICAgICAgdGhpcy5hdmF0YXJTaXplID0gJ3NtYWxsJztcbiAgICAgICAgYnJlYWs7XG4gICAgfVxuICB9XG4gIEBJbnB1dCgpIEBJbnB1dE51bWJlcigpIG1heExlbmd0aCA9IDA7XG4gIEBJbnB1dCgpIGV4Y2Vzc0l0ZW1zU3R5bGU6IHt9O1xuXG4gIGNvbnN0cnVjdG9yKHByaXZhdGUgY2RyOiBDaGFuZ2VEZXRlY3RvclJlZikge31cblxuICBwcml2YXRlIGdlbigpIHtcbiAgICBjb25zdCB7IF9pdGVtcyB9ID0gdGhpcztcbiAgICBjb25zdCBtYXhMZW5ndGggPSB0aGlzLm1heExlbmd0aCA+IDAgPyB0aGlzLm1heExlbmd0aCA6IF9pdGVtcy5sZW5ndGg7XG4gICAgY29uc3QgbnVtT2ZDaGlsZHJlbiA9IF9pdGVtcy5sZW5ndGg7XG4gICAgY29uc3QgbnVtVG9TaG93ID0gbWF4TGVuZ3RoID4gMCAmJiBtYXhMZW5ndGggPj0gbnVtT2ZDaGlsZHJlbiA/IG51bU9mQ2hpbGRyZW4gOiBtYXhMZW5ndGg7XG4gICAgdGhpcy5pdGVtcyA9IF9pdGVtcy50b0FycmF5KCkuc2xpY2UoMCwgbnVtVG9TaG93KTtcbiAgICB0aGlzLmV4Y2VlZENvdW50ID0gbnVtVG9TaG93IDwgbnVtT2ZDaGlsZHJlbiA/IG51bU9mQ2hpbGRyZW4gLSBtYXhMZW5ndGggOiAwO1xuICAgIHRoaXMuY2RyLmRldGVjdENoYW5nZXMoKTtcbiAgfVxuXG4gIG5nQWZ0ZXJWaWV3SW5pdCgpIHtcbiAgICB0aGlzLmdlbigpO1xuICAgIHRoaXMuaW5pdGVkID0gdHJ1ZTtcbiAgfVxuXG4gIG5nT25DaGFuZ2VzKCkge1xuICAgIGlmICh0aGlzLmluaXRlZCkge1xuICAgICAgdGhpcy5nZW4oKTtcbiAgICB9XG4gIH1cbn1cbiJdfQ==