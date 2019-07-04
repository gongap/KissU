/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { DOCUMENT } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, Inject, Input, } from '@angular/core';
import { InputNumber } from '@delon/util';
import { ErrorCollectConfig } from './error-collect.config';
export class ErrorCollectComponent {
    /**
     * @param {?} cog
     * @param {?} el
     * @param {?} cdr
     * @param {?} doc
     */
    constructor(cog, el, cdr, doc) {
        this.el = el;
        this.cdr = cdr;
        this.doc = doc;
        this.$time = null;
        this._hiden = true;
        this.count = 0;
        Object.assign(this, Object.assign({}, new ErrorCollectConfig(), cog));
    }
    /**
     * @private
     * @return {?}
     */
    get errEls() {
        return this.formEl.querySelectorAll('.has-error');
    }
    /**
     * @private
     * @return {?}
     */
    update() {
        /** @type {?} */
        const count = this.errEls.length;
        if (count === this.count)
            return;
        this.count = count;
        this._hiden = count === 0;
        this.cdr.markForCheck();
    }
    /**
     * @return {?}
     */
    _click() {
        if (this.count === 0)
            return false;
        // nz-form-control
        /** @type {?} */
        const els = this.errEls;
        /** @type {?} */
        const formItemEl = this.findParent(els[0], '[nz-form-control]') || els[0];
        formItemEl.scrollIntoView(true);
        // fix header height
        this.doc.documentElement.scrollTop -= this.offsetTop;
    }
    /**
     * @private
     * @return {?}
     */
    install() {
        this.uninstall();
        this.$time = setInterval((/**
         * @return {?}
         */
        () => this.update()), this.freq);
        this.update();
    }
    /**
     * @private
     * @return {?}
     */
    uninstall() {
        clearInterval(this.$time);
    }
    /**
     * @private
     * @param {?} el
     * @param {?} selector
     * @return {?}
     */
    findParent(el, selector) {
        /** @type {?} */
        let retEl = null;
        while (el) {
            if (el.querySelector(selector)) {
                retEl = el;
                break;
            }
            el = el.parentElement;
        }
        return retEl;
    }
    /**
     * @return {?}
     */
    ngOnInit() {
        this.formEl = this.findParent(this.el.nativeElement, 'form');
        if (this.formEl === null)
            throw new Error('No found form element');
        this.install();
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this.uninstall();
    }
}
ErrorCollectComponent.decorators = [
    { type: Component, args: [{
                selector: 'error-collect, [error-collect]',
                template: `
    <i nz-icon type="exclamation-circle"></i>
    <span class="pl-sm">{{ count }}</span>
  `,
                host: {
                    '[class.error-collect]': 'true',
                    '[class.d-none]': '_hiden',
                    '(click)': '_click()',
                },
                changeDetection: ChangeDetectionStrategy.OnPush,
                exportAs: 'errorCollect'
            }] }
];
/** @nocollapse */
ErrorCollectComponent.ctorParameters = () => [
    { type: ErrorCollectConfig },
    { type: ElementRef },
    { type: ChangeDetectorRef },
    { type: undefined, decorators: [{ type: Inject, args: [DOCUMENT,] }] }
];
ErrorCollectComponent.propDecorators = {
    freq: [{ type: Input }],
    offsetTop: [{ type: Input }]
};
tslib_1.__decorate([
    InputNumber(),
    tslib_1.__metadata("design:type", Number)
], ErrorCollectComponent.prototype, "freq", void 0);
tslib_1.__decorate([
    InputNumber(),
    tslib_1.__metadata("design:type", Number)
], ErrorCollectComponent.prototype, "offsetTop", void 0);
if (false) {
    /**
     * @type {?}
     * @private
     */
    ErrorCollectComponent.prototype.$time;
    /**
     * @type {?}
     * @private
     */
    ErrorCollectComponent.prototype.formEl;
    /** @type {?} */
    ErrorCollectComponent.prototype.freq;
    /** @type {?} */
    ErrorCollectComponent.prototype.offsetTop;
    /** @type {?} */
    ErrorCollectComponent.prototype._hiden;
    /** @type {?} */
    ErrorCollectComponent.prototype.count;
    /**
     * @type {?}
     * @private
     */
    ErrorCollectComponent.prototype.el;
    /**
     * @type {?}
     * @private
     */
    ErrorCollectComponent.prototype.cdr;
    /**
     * @type {?}
     * @private
     */
    ErrorCollectComponent.prototype.doc;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiZXJyb3ItY29sbGVjdC5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL2Vycm9yLWNvbGxlY3QvIiwic291cmNlcyI6WyJlcnJvci1jb2xsZWN0LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7OztBQUFBLE9BQU8sRUFBRSxRQUFRLEVBQUUsTUFBTSxpQkFBaUIsQ0FBQztBQUMzQyxPQUFPLEVBQ0wsdUJBQXVCLEVBQ3ZCLGlCQUFpQixFQUNqQixTQUFTLEVBQ1QsVUFBVSxFQUNWLE1BQU0sRUFDTixLQUFLLEdBR04sTUFBTSxlQUFlLENBQUM7QUFDdkIsT0FBTyxFQUFFLFdBQVcsRUFBRSxNQUFNLGFBQWEsQ0FBQztBQUUxQyxPQUFPLEVBQUUsa0JBQWtCLEVBQUUsTUFBTSx3QkFBd0IsQ0FBQztBQWdCNUQsTUFBTSxPQUFPLHFCQUFxQjs7Ozs7OztJQVdoQyxZQUNFLEdBQXVCLEVBQ2YsRUFBYyxFQUNkLEdBQXNCLEVBQ0osR0FBUTtRQUYxQixPQUFFLEdBQUYsRUFBRSxDQUFZO1FBQ2QsUUFBRyxHQUFILEdBQUcsQ0FBbUI7UUFDSixRQUFHLEdBQUgsR0FBRyxDQUFLO1FBZDVCLFVBQUssR0FBRyxJQUFJLENBQUM7UUFNckIsV0FBTSxHQUFHLElBQUksQ0FBQztRQUVkLFVBQUssR0FBRyxDQUFDLENBQUM7UUFRUixNQUFNLENBQUMsTUFBTSxDQUFDLElBQUksb0JBQU8sSUFBSSxrQkFBa0IsRUFBRSxFQUFLLEdBQUcsRUFBRyxDQUFDO0lBQy9ELENBQUM7Ozs7O0lBRUQsSUFBWSxNQUFNO1FBQ2hCLE9BQU8sSUFBSSxDQUFDLE1BQU0sQ0FBQyxnQkFBZ0IsQ0FBQyxZQUFZLENBQUMsQ0FBQztJQUNwRCxDQUFDOzs7OztJQUVPLE1BQU07O2NBQ04sS0FBSyxHQUFHLElBQUksQ0FBQyxNQUFNLENBQUMsTUFBTTtRQUNoQyxJQUFJLEtBQUssS0FBSyxJQUFJLENBQUMsS0FBSztZQUFFLE9BQU87UUFDakMsSUFBSSxDQUFDLEtBQUssR0FBRyxLQUFLLENBQUM7UUFDbkIsSUFBSSxDQUFDLE1BQU0sR0FBRyxLQUFLLEtBQUssQ0FBQyxDQUFDO1FBQzFCLElBQUksQ0FBQyxHQUFHLENBQUMsWUFBWSxFQUFFLENBQUM7SUFDMUIsQ0FBQzs7OztJQUVELE1BQU07UUFDSixJQUFJLElBQUksQ0FBQyxLQUFLLEtBQUssQ0FBQztZQUFFLE9BQU8sS0FBSyxDQUFDOzs7Y0FFN0IsR0FBRyxHQUFHLElBQUksQ0FBQyxNQUFNOztjQUNqQixVQUFVLEdBQUcsSUFBSSxDQUFDLFVBQVUsQ0FBQyxHQUFHLENBQUMsQ0FBQyxDQUFDLEVBQUUsbUJBQW1CLENBQUMsSUFBSSxHQUFHLENBQUMsQ0FBQyxDQUFDO1FBQ3pFLFVBQVUsQ0FBQyxjQUFjLENBQUMsSUFBSSxDQUFDLENBQUM7UUFDaEMsb0JBQW9CO1FBQ3BCLElBQUksQ0FBQyxHQUFHLENBQUMsZUFBZSxDQUFDLFNBQVMsSUFBSSxJQUFJLENBQUMsU0FBUyxDQUFDO0lBQ3ZELENBQUM7Ozs7O0lBRU8sT0FBTztRQUNiLElBQUksQ0FBQyxTQUFTLEVBQUUsQ0FBQztRQUNqQixJQUFJLENBQUMsS0FBSyxHQUFHLFdBQVc7OztRQUFDLEdBQUcsRUFBRSxDQUFDLElBQUksQ0FBQyxNQUFNLEVBQUUsR0FBRSxJQUFJLENBQUMsSUFBSSxDQUFDLENBQUM7UUFDekQsSUFBSSxDQUFDLE1BQU0sRUFBRSxDQUFDO0lBQ2hCLENBQUM7Ozs7O0lBRU8sU0FBUztRQUNmLGFBQWEsQ0FBQyxJQUFJLENBQUMsS0FBSyxDQUFDLENBQUM7SUFDNUIsQ0FBQzs7Ozs7OztJQUVPLFVBQVUsQ0FBQyxFQUFXLEVBQUUsUUFBZ0I7O1lBQzFDLEtBQUssR0FBRyxJQUFJO1FBQ2hCLE9BQU8sRUFBRSxFQUFFO1lBQ1QsSUFBSSxFQUFFLENBQUMsYUFBYSxDQUFDLFFBQVEsQ0FBQyxFQUFFO2dCQUM5QixLQUFLLEdBQUcsRUFBRSxDQUFDO2dCQUNYLE1BQU07YUFDUDtZQUNELEVBQUUsR0FBRyxFQUFFLENBQUMsYUFBYSxDQUFDO1NBQ3ZCO1FBQ0QsT0FBTyxLQUFLLENBQUM7SUFDZixDQUFDOzs7O0lBRUQsUUFBUTtRQUNOLElBQUksQ0FBQyxNQUFNLEdBQUcsSUFBSSxDQUFDLFVBQVUsQ0FBQyxJQUFJLENBQUMsRUFBRSxDQUFDLGFBQWEsRUFBRSxNQUFNLENBQUMsQ0FBQztRQUM3RCxJQUFJLElBQUksQ0FBQyxNQUFNLEtBQUssSUFBSTtZQUFFLE1BQU0sSUFBSSxLQUFLLENBQUMsdUJBQXVCLENBQUMsQ0FBQztRQUNuRSxJQUFJLENBQUMsT0FBTyxFQUFFLENBQUM7SUFDakIsQ0FBQzs7OztJQUVELFdBQVc7UUFDVCxJQUFJLENBQUMsU0FBUyxFQUFFLENBQUM7SUFDbkIsQ0FBQzs7O1lBdEZGLFNBQVMsU0FBQztnQkFDVCxRQUFRLEVBQUUsZ0NBQWdDO2dCQUMxQyxRQUFRLEVBQUU7OztHQUdUO2dCQUNELElBQUksRUFBRTtvQkFDSix1QkFBdUIsRUFBRSxNQUFNO29CQUMvQixnQkFBZ0IsRUFBRSxRQUFRO29CQUMxQixTQUFTLEVBQUUsVUFBVTtpQkFDdEI7Z0JBQ0QsZUFBZSxFQUFFLHVCQUF1QixDQUFDLE1BQU07Z0JBQy9DLFFBQVEsRUFBRSxjQUFjO2FBQ3pCOzs7O1lBZlEsa0JBQWtCO1lBUnpCLFVBQVU7WUFGVixpQkFBaUI7NENBeUNkLE1BQU0sU0FBQyxRQUFROzs7bUJBWGpCLEtBQUs7d0JBQ0wsS0FBSzs7QUFEa0I7SUFBZCxXQUFXLEVBQUU7O21EQUFjO0FBQ2I7SUFBZCxXQUFXLEVBQUU7O3dEQUFtQjs7Ozs7O0lBSjFDLHNDQUFxQjs7Ozs7SUFDckIsdUNBQWdDOztJQUVoQyxxQ0FBcUM7O0lBQ3JDLDBDQUEwQzs7SUFFMUMsdUNBQWM7O0lBRWQsc0NBQVU7Ozs7O0lBSVIsbUNBQXNCOzs7OztJQUN0QixvQ0FBOEI7Ozs7O0lBQzlCLG9DQUFrQyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IERPQ1VNRU5UIH0gZnJvbSAnQGFuZ3VsYXIvY29tbW9uJztcbmltcG9ydCB7XG4gIENoYW5nZURldGVjdGlvblN0cmF0ZWd5LFxuICBDaGFuZ2VEZXRlY3RvclJlZixcbiAgQ29tcG9uZW50LFxuICBFbGVtZW50UmVmLFxuICBJbmplY3QsXG4gIElucHV0LFxuICBPbkRlc3Ryb3ksXG4gIE9uSW5pdCxcbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBJbnB1dE51bWJlciB9IGZyb20gJ0BkZWxvbi91dGlsJztcblxuaW1wb3J0IHsgRXJyb3JDb2xsZWN0Q29uZmlnIH0gZnJvbSAnLi9lcnJvci1jb2xsZWN0LmNvbmZpZyc7XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ2Vycm9yLWNvbGxlY3QsIFtlcnJvci1jb2xsZWN0XScsXG4gIHRlbXBsYXRlOiBgXG4gICAgPGkgbnotaWNvbiB0eXBlPVwiZXhjbGFtYXRpb24tY2lyY2xlXCI+PC9pPlxuICAgIDxzcGFuIGNsYXNzPVwicGwtc21cIj57eyBjb3VudCB9fTwvc3Bhbj5cbiAgYCxcbiAgaG9zdDoge1xuICAgICdbY2xhc3MuZXJyb3ItY29sbGVjdF0nOiAndHJ1ZScsXG4gICAgJ1tjbGFzcy5kLW5vbmVdJzogJ19oaWRlbicsXG4gICAgJyhjbGljayknOiAnX2NsaWNrKCknLFxuICB9LFxuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbiAgZXhwb3J0QXM6ICdlcnJvckNvbGxlY3QnLFxufSlcbmV4cG9ydCBjbGFzcyBFcnJvckNvbGxlY3RDb21wb25lbnQgaW1wbGVtZW50cyBPbkluaXQsIE9uRGVzdHJveSB7XG4gIHByaXZhdGUgJHRpbWUgPSBudWxsO1xuICBwcml2YXRlIGZvcm1FbDogSFRNTEZvcm1FbGVtZW50O1xuXG4gIEBJbnB1dCgpIEBJbnB1dE51bWJlcigpIGZyZXE6IG51bWJlcjtcbiAgQElucHV0KCkgQElucHV0TnVtYmVyKCkgb2Zmc2V0VG9wOiBudW1iZXI7XG5cbiAgX2hpZGVuID0gdHJ1ZTtcblxuICBjb3VudCA9IDA7XG5cbiAgY29uc3RydWN0b3IoXG4gICAgY29nOiBFcnJvckNvbGxlY3RDb25maWcsXG4gICAgcHJpdmF0ZSBlbDogRWxlbWVudFJlZixcbiAgICBwcml2YXRlIGNkcjogQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gICAgQEluamVjdChET0NVTUVOVCkgcHJpdmF0ZSBkb2M6IGFueSxcbiAgKSB7XG4gICAgT2JqZWN0LmFzc2lnbih0aGlzLCB7IC4uLm5ldyBFcnJvckNvbGxlY3RDb25maWcoKSwgLi4uY29nIH0pO1xuICB9XG5cbiAgcHJpdmF0ZSBnZXQgZXJyRWxzKCkge1xuICAgIHJldHVybiB0aGlzLmZvcm1FbC5xdWVyeVNlbGVjdG9yQWxsKCcuaGFzLWVycm9yJyk7XG4gIH1cblxuICBwcml2YXRlIHVwZGF0ZSgpIHtcbiAgICBjb25zdCBjb3VudCA9IHRoaXMuZXJyRWxzLmxlbmd0aDtcbiAgICBpZiAoY291bnQgPT09IHRoaXMuY291bnQpIHJldHVybjtcbiAgICB0aGlzLmNvdW50ID0gY291bnQ7XG4gICAgdGhpcy5faGlkZW4gPSBjb3VudCA9PT0gMDtcbiAgICB0aGlzLmNkci5tYXJrRm9yQ2hlY2soKTtcbiAgfVxuXG4gIF9jbGljaygpIHtcbiAgICBpZiAodGhpcy5jb3VudCA9PT0gMCkgcmV0dXJuIGZhbHNlO1xuICAgIC8vIG56LWZvcm0tY29udHJvbFxuICAgIGNvbnN0IGVscyA9IHRoaXMuZXJyRWxzO1xuICAgIGNvbnN0IGZvcm1JdGVtRWwgPSB0aGlzLmZpbmRQYXJlbnQoZWxzWzBdLCAnW256LWZvcm0tY29udHJvbF0nKSB8fCBlbHNbMF07XG4gICAgZm9ybUl0ZW1FbC5zY3JvbGxJbnRvVmlldyh0cnVlKTtcbiAgICAvLyBmaXggaGVhZGVyIGhlaWdodFxuICAgIHRoaXMuZG9jLmRvY3VtZW50RWxlbWVudC5zY3JvbGxUb3AgLT0gdGhpcy5vZmZzZXRUb3A7XG4gIH1cblxuICBwcml2YXRlIGluc3RhbGwoKSB7XG4gICAgdGhpcy51bmluc3RhbGwoKTtcbiAgICB0aGlzLiR0aW1lID0gc2V0SW50ZXJ2YWwoKCkgPT4gdGhpcy51cGRhdGUoKSwgdGhpcy5mcmVxKTtcbiAgICB0aGlzLnVwZGF0ZSgpO1xuICB9XG5cbiAgcHJpdmF0ZSB1bmluc3RhbGwoKSB7XG4gICAgY2xlYXJJbnRlcnZhbCh0aGlzLiR0aW1lKTtcbiAgfVxuXG4gIHByaXZhdGUgZmluZFBhcmVudChlbDogRWxlbWVudCwgc2VsZWN0b3I6IHN0cmluZykge1xuICAgIGxldCByZXRFbCA9IG51bGw7XG4gICAgd2hpbGUgKGVsKSB7XG4gICAgICBpZiAoZWwucXVlcnlTZWxlY3RvcihzZWxlY3RvcikpIHtcbiAgICAgICAgcmV0RWwgPSBlbDtcbiAgICAgICAgYnJlYWs7XG4gICAgICB9XG4gICAgICBlbCA9IGVsLnBhcmVudEVsZW1lbnQ7XG4gICAgfVxuICAgIHJldHVybiByZXRFbDtcbiAgfVxuXG4gIG5nT25Jbml0KCkge1xuICAgIHRoaXMuZm9ybUVsID0gdGhpcy5maW5kUGFyZW50KHRoaXMuZWwubmF0aXZlRWxlbWVudCwgJ2Zvcm0nKTtcbiAgICBpZiAodGhpcy5mb3JtRWwgPT09IG51bGwpIHRocm93IG5ldyBFcnJvcignTm8gZm91bmQgZm9ybSBlbGVtZW50Jyk7XG4gICAgdGhpcy5pbnN0YWxsKCk7XG4gIH1cblxuICBuZ09uRGVzdHJveSgpIHtcbiAgICB0aGlzLnVuaW5zdGFsbCgpO1xuICB9XG59XG4iXX0=