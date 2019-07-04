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
import { Platform } from '@angular/cdk/platform';
import { DOCUMENT } from '@angular/common';
import { ChangeDetectionStrategy, Component, ElementRef, EventEmitter, Inject, Input, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { shallowEqual, throttleByAnimationFrameDecorator, toNumber, NzScrollService } from 'ng-zorro-antd/core';
export class NzAffixComponent {
    /**
     * @param {?} _el
     * @param {?} scrollSrv
     * @param {?} doc
     * @param {?} platform
     */
    constructor(_el, scrollSrv, doc, platform) {
        this.scrollSrv = scrollSrv;
        this.doc = doc;
        this.platform = platform;
        this.nzChange = new EventEmitter();
        this.events = ['resize', 'scroll', 'touchstart', 'touchmove', 'touchend', 'pageshow', 'load'];
        this._target = null;
        this.placeholderNode = _el.nativeElement;
        if (this.platform.isBrowser) {
            this._target = window;
        }
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set nzTarget(value) {
        if (this.platform.isBrowser) {
            this.clearEventListeners();
            this._target = typeof value === 'string' ? this.doc.querySelector(value) : value || window;
            this.setTargetEventListeners();
            this.updatePosition((/** @type {?} */ ({})));
        }
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set nzOffsetTop(value) {
        if (value === undefined || value === null) {
            return;
        }
        this._offsetTop = toNumber(value, null);
        this.updatePosition((/** @type {?} */ ({})));
    }
    /**
     * @return {?}
     */
    get nzOffsetTop() {
        return this._offsetTop;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set nzOffsetBottom(value) {
        if (typeof value === 'undefined') {
            return;
        }
        this._offsetBottom = toNumber(value, null);
        this.updatePosition((/** @type {?} */ ({})));
    }
    /**
     * @return {?}
     */
    ngOnInit() {
        this.timeout = setTimeout((/**
         * @return {?}
         */
        () => {
            this.setTargetEventListeners();
            this.updatePosition((/** @type {?} */ ({})));
        }));
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this.clearEventListeners();
        clearTimeout(this.timeout);
        // tslint:disable-next-line:no-any
        ((/** @type {?} */ (this.updatePosition))).cancel();
    }
    /**
     * @param {?} element
     * @param {?} target
     * @return {?}
     */
    getOffset(element, target) {
        /** @type {?} */
        const elemRect = element.getBoundingClientRect();
        /** @type {?} */
        const targetRect = this.getTargetRect(target);
        /** @type {?} */
        const scrollTop = this.scrollSrv.getScroll(target, true);
        /** @type {?} */
        const scrollLeft = this.scrollSrv.getScroll(target, false);
        /** @type {?} */
        const docElem = this.doc.body;
        /** @type {?} */
        const clientTop = docElem.clientTop || 0;
        /** @type {?} */
        const clientLeft = docElem.clientLeft || 0;
        return {
            top: elemRect.top - targetRect.top + scrollTop - clientTop,
            left: elemRect.left - targetRect.left + scrollLeft - clientLeft,
            width: elemRect.width,
            height: elemRect.height
        };
    }
    /**
     * @private
     * @return {?}
     */
    setTargetEventListeners() {
        this.clearEventListeners();
        if (this.platform.isBrowser) {
            this.events.forEach((/**
             * @param {?} eventName
             * @return {?}
             */
            (eventName) => {
                (/** @type {?} */ (this._target)).addEventListener(eventName, this.updatePosition, false);
            }));
        }
    }
    /**
     * @private
     * @return {?}
     */
    clearEventListeners() {
        if (this.platform.isBrowser) {
            this.events.forEach((/**
             * @param {?} eventName
             * @return {?}
             */
            eventName => {
                (/** @type {?} */ (this._target)).removeEventListener(eventName, this.updatePosition, false);
            }));
        }
    }
    /**
     * @private
     * @param {?} target
     * @return {?}
     */
    getTargetRect(target) {
        return target !== window
            ? ((/** @type {?} */ (target))).getBoundingClientRect()
            : ((/** @type {?} */ ({ top: 0, left: 0, bottom: 0 })));
    }
    /**
     * @private
     * @param {?=} affixStyle
     * @return {?}
     */
    genStyle(affixStyle) {
        if (!affixStyle) {
            return '';
        }
        return Object.keys(affixStyle)
            .map((/**
         * @param {?} key
         * @return {?}
         */
        key => {
            /** @type {?} */
            const val = affixStyle[key];
            return `${key}:${typeof val === 'string' ? val : val + 'px'}`;
        }))
            .join(';');
    }
    /**
     * @private
     * @param {?} e
     * @param {?=} affixStyle
     * @return {?}
     */
    setAffixStyle(e, affixStyle) {
        /** @type {?} */
        const originalAffixStyle = this.affixStyle;
        /** @type {?} */
        const isWindow = this._target === window;
        if (e.type === 'scroll' && originalAffixStyle && affixStyle && isWindow) {
            return;
        }
        if (shallowEqual(originalAffixStyle, affixStyle)) {
            return;
        }
        /** @type {?} */
        const fixed = !!affixStyle;
        /** @type {?} */
        const wrapEl = (/** @type {?} */ (this.fixedEl.nativeElement));
        wrapEl.style.cssText = this.genStyle(affixStyle);
        this.affixStyle = affixStyle;
        /** @type {?} */
        const cls = 'ant-affix';
        if (fixed) {
            wrapEl.classList.add(cls);
        }
        else {
            wrapEl.classList.remove(cls);
        }
        if ((affixStyle && !originalAffixStyle) || (!affixStyle && originalAffixStyle)) {
            this.nzChange.emit(fixed);
        }
    }
    /**
     * @private
     * @param {?=} placeholderStyle
     * @return {?}
     */
    setPlaceholderStyle(placeholderStyle) {
        /** @type {?} */
        const originalPlaceholderStyle = this.placeholderStyle;
        if (shallowEqual(placeholderStyle, originalPlaceholderStyle)) {
            return;
        }
        this.placeholderNode.style.cssText = this.genStyle(placeholderStyle);
        this.placeholderStyle = placeholderStyle;
    }
    /**
     * @private
     * @param {?} e
     * @return {?}
     */
    syncPlaceholderStyle(e) {
        if (!this.affixStyle) {
            return;
        }
        this.placeholderNode.style.cssText = '';
        this.placeholderStyle = undefined;
        /** @type {?} */
        const styleObj = { width: this.placeholderNode.offsetWidth, height: this.fixedEl.nativeElement.offsetHeight };
        this.setAffixStyle(e, Object.assign({}, this.affixStyle, styleObj));
        this.setPlaceholderStyle(styleObj);
    }
    /**
     * @param {?} e
     * @return {?}
     */
    updatePosition(e) {
        if (!this.platform.isBrowser) {
            return;
        }
        /** @type {?} */
        const targetNode = (/** @type {?} */ (this._target));
        // Backwards support
        /** @type {?} */
        let offsetTop = this.nzOffsetTop;
        /** @type {?} */
        const scrollTop = this.scrollSrv.getScroll((/** @type {?} */ (targetNode)), true);
        /** @type {?} */
        const elemOffset = this.getOffset(this.placeholderNode, (/** @type {?} */ (targetNode)));
        /** @type {?} */
        const fixedNode = (/** @type {?} */ (this.fixedEl.nativeElement));
        /** @type {?} */
        const elemSize = {
            width: fixedNode.offsetWidth,
            height: fixedNode.offsetHeight
        };
        /** @type {?} */
        const offsetMode = {
            top: false,
            bottom: false
        };
        // Default to `offsetTop=0`.
        if (typeof offsetTop !== 'number' && typeof this._offsetBottom !== 'number') {
            offsetMode.top = true;
            offsetTop = 0;
        }
        else {
            offsetMode.top = typeof offsetTop === 'number';
            offsetMode.bottom = typeof this._offsetBottom === 'number';
        }
        /** @type {?} */
        const targetRect = this.getTargetRect((/** @type {?} */ (targetNode)));
        /** @type {?} */
        const targetInnerHeight = ((/** @type {?} */ (targetNode))).innerHeight || ((/** @type {?} */ (targetNode))).clientHeight;
        if (scrollTop >= elemOffset.top - ((/** @type {?} */ (offsetTop))) && offsetMode.top) {
            /** @type {?} */
            const width = elemOffset.width;
            /** @type {?} */
            const top = targetRect.top + ((/** @type {?} */ (offsetTop)));
            this.setAffixStyle(e, {
                position: 'fixed',
                top,
                left: targetRect.left + elemOffset.left,
                maxHeight: `calc(100vh - ${top}px)`,
                width
            });
            this.setPlaceholderStyle({
                width,
                height: elemSize.height
            });
        }
        else if (scrollTop <= elemOffset.top + elemSize.height + ((/** @type {?} */ (this._offsetBottom))) - targetInnerHeight &&
            offsetMode.bottom) {
            /** @type {?} */
            const targetBottomOffet = targetNode === window ? 0 : window.innerHeight - targetRect.bottom;
            /** @type {?} */
            const width = elemOffset.width;
            this.setAffixStyle(e, {
                position: 'fixed',
                bottom: targetBottomOffet + ((/** @type {?} */ (this._offsetBottom))),
                left: targetRect.left + elemOffset.left,
                width
            });
            this.setPlaceholderStyle({
                width,
                height: elemOffset.height
            });
        }
        else {
            if (e.type === 'resize' &&
                this.affixStyle &&
                this.affixStyle.position === 'fixed' &&
                this.placeholderNode.offsetWidth) {
                this.setAffixStyle(e, Object.assign({}, this.affixStyle, { width: this.placeholderNode.offsetWidth }));
            }
            else {
                this.setAffixStyle(e);
            }
            this.setPlaceholderStyle();
        }
        if (e.type === 'resize') {
            this.syncPlaceholderStyle(e);
        }
    }
}
NzAffixComponent.decorators = [
    { type: Component, args: [{
                selector: 'nz-affix',
                exportAs: 'nzAffix',
                template: "<div #fixedEl>\n  <ng-content></ng-content>\n</div>",
                changeDetection: ChangeDetectionStrategy.OnPush,
                encapsulation: ViewEncapsulation.None,
                styles: [`
      nz-affix {
        display: block;
      }
    `]
            }] }
];
/** @nocollapse */
NzAffixComponent.ctorParameters = () => [
    { type: ElementRef },
    { type: NzScrollService },
    { type: undefined, decorators: [{ type: Inject, args: [DOCUMENT,] }] },
    { type: Platform }
];
NzAffixComponent.propDecorators = {
    nzTarget: [{ type: Input }],
    nzOffsetTop: [{ type: Input }],
    nzOffsetBottom: [{ type: Input }],
    nzChange: [{ type: Output }],
    fixedEl: [{ type: ViewChild, args: ['fixedEl',] }]
};
tslib_1.__decorate([
    throttleByAnimationFrameDecorator(),
    tslib_1.__metadata("design:type", Function),
    tslib_1.__metadata("design:paramtypes", [Event]),
    tslib_1.__metadata("design:returntype", void 0)
], NzAffixComponent.prototype, "updatePosition", null);
if (false) {
    /** @type {?} */
    NzAffixComponent.prototype.nzChange;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.timeout;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.events;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.fixedEl;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.placeholderNode;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.affixStyle;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.placeholderStyle;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype._target;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype._offsetTop;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype._offsetBottom;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.scrollSrv;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.doc;
    /**
     * @type {?}
     * @private
     */
    NzAffixComponent.prototype.platform;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotYWZmaXguY29tcG9uZW50LmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC9hZmZpeC8iLCJzb3VyY2VzIjpbIm56LWFmZml4LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQUUsUUFBUSxFQUFFLE1BQU0sdUJBQXVCLENBQUM7QUFDakQsT0FBTyxFQUFFLFFBQVEsRUFBRSxNQUFNLGlCQUFpQixDQUFDO0FBQzNDLE9BQU8sRUFDTCx1QkFBdUIsRUFDdkIsU0FBUyxFQUNULFVBQVUsRUFDVixZQUFZLEVBQ1osTUFBTSxFQUNOLEtBQUssRUFHTCxNQUFNLEVBQ04sU0FBUyxFQUNULGlCQUFpQixFQUNsQixNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQ0wsWUFBWSxFQUNaLGlDQUFpQyxFQUNqQyxRQUFRLEVBQ1IsZUFBZSxFQUVoQixNQUFNLG9CQUFvQixDQUFDO0FBZ0I1QixNQUFNLE9BQU8sZ0JBQWdCOzs7Ozs7O0lBK0MzQixZQUNFLEdBQWUsRUFDUCxTQUEwQixFQUVSLEdBQVEsRUFDMUIsUUFBa0I7UUFIbEIsY0FBUyxHQUFULFNBQVMsQ0FBaUI7UUFFUixRQUFHLEdBQUgsR0FBRyxDQUFLO1FBQzFCLGFBQVEsR0FBUixRQUFRLENBQVU7UUFuQlQsYUFBUSxHQUFHLElBQUksWUFBWSxFQUFXLENBQUM7UUFHekMsV0FBTSxHQUFHLENBQUMsUUFBUSxFQUFFLFFBQVEsRUFBRSxZQUFZLEVBQUUsV0FBVyxFQUFFLFVBQVUsRUFBRSxVQUFVLEVBQUUsTUFBTSxDQUFDLENBQUM7UUFPbEcsWUFBTyxHQUE0QixJQUFJLENBQUM7UUFXOUMsSUFBSSxDQUFDLGVBQWUsR0FBRyxHQUFHLENBQUMsYUFBYSxDQUFDO1FBQ3pDLElBQUksSUFBSSxDQUFDLFFBQVEsQ0FBQyxTQUFTLEVBQUU7WUFDM0IsSUFBSSxDQUFDLE9BQU8sR0FBRyxNQUFNLENBQUM7U0FDdkI7SUFDSCxDQUFD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SUFDdkQsbUNBQWdEOzs7OztJQUNoRCxzQ0FBa0M7Ozs7O0lBQ2xDLHlDQUFxQzs7Ozs7SUFJbkMscUNBQWtDOzs7OztJQUVsQywrQkFBa0M7Ozs7O0lBQ2xDLG9DQUEwQiIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQgeyBQbGF0Zm9ybSB9IGZyb20gJ0Bhbmd1bGFyL2Nkay9wbGF0Zm9ybSc7XG5pbXBvcnQgeyBET0NVTUVOVCB9IGZyb20gJ0Bhbmd1bGFyL2NvbW1vbic7XG5pbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ29tcG9uZW50LFxuICBFbGVtZW50UmVmLFxuICBFdmVudEVtaXR0ZXIsXG4gIEluamVjdCxcbiAgSW5wdXQsXG4gIE9uRGVzdHJveSxcbiAgT25Jbml0LFxuICBPdXRwdXQsXG4gIFZpZXdDaGlsZCxcbiAgVmlld0VuY2Fwc3VsYXRpb25cbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQge1xuICBzaGFsbG93RXF1YWwsXG4gIHRocm90dGxlQnlBbmltYXRpb25GcmFtZURlY29yYXRvcixcbiAgdG9OdW1iZXIsXG4gIE56U2Nyb2xsU2VydmljZSxcbiAgTkdTdHlsZUludGVyZmFjZVxufSBmcm9tICduZy16b3Jyby1hbnRkL2NvcmUnO1xuXG5AQ29tcG9uZW50KHtcbiAgc2VsZWN0b3I6ICduei1hZmZpeCcsXG4gIGV4cG9ydEFzOiAnbnpBZmZpeCcsXG4gIHRlbXBsYXRlVXJsOiAnLi9uei1hZmZpeC5jb21wb25lbnQuaHRtbCcsXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxuICBzdHlsZXM6IFtcbiAgICBgXG4gICAgICBuei1hZmZpeCB7XG4gICAgICAgIGRpc3BsYXk6IGJsb2NrO1xuICAgICAgfVxuICAgIGBcbiAgXSxcbiAgZW5jYXBzdWxhdGlvbjogVmlld0VuY2Fwc3VsYXRpb24uTm9uZVxufSlcbmV4cG9ydCBjbGFzcyBOekFmZml4Q29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0LCBPbkRlc3Ryb3kge1xuICBASW5wdXQoKVxuICBzZXQgbnpUYXJnZXQodmFsdWU6IHN0cmluZyB8IEVsZW1lbnQgfCBXaW5kb3cpIHtcbiAgICBpZiAodGhpcy5wbGF0Zm9ybS5pc0Jyb3dzZXIpIHtcbiAgICAgIHRoaXMuY2xlYXJFdmVudExpc3RlbmVycygpO1xuICAgICAgdGhpcy5fdGFyZ2V0ID0gdHlwZW9mIHZhbHVlID09PSAnc3RyaW5nJyA/IHRoaXMuZG9jLnF1ZXJ5U2VsZWN0b3IodmFsdWUpIDogdmFsdWUgfHwgd2luZG93O1xuICAgICAgdGhpcy5zZXRUYXJnZXRFdmVudExpc3RlbmVycygpO1xuICAgICAgdGhpcy51cGRhdGVQb3NpdGlvbih7fSBhcyBFdmVudCk7XG4gICAgfVxuICB9XG5cbiAgQElucHV0KClcbiAgc2V0IG56T2Zmc2V0VG9wKHZhbHVlOiBudW1iZXIgfCBudWxsKSB7XG4gICAgaWYgKHZhbHVlID09PSB1bmRlZmluZWQgfHwgdmFsdWUgPT09IG51bGwpIHtcbiAgICAgIHJldHVybjtcbiAgICB9XG4gICAgdGhpcy5fb2Zmc2V0VG9wID0gdG9OdW1iZXIodmFsdWUsIG51bGwpO1xuICAgIHRoaXMudXBkYXRlUG9zaXRpb24oe30gYXMgRXZlbnQpO1xuICB9XG5cbiAgZ2V0IG56T2Zmc2V0VG9wKCk6IG51bWJlciB8IG51bGwge1xuICAgIHJldHVybiB0aGlzLl9vZmZzZXRUb3A7XG4gIH1cblxuICBASW5wdXQoKVxuICBzZXQgbnpPZmZzZXRCb3R0b20odmFsdWU6IG51bWJlcikge1xuICAgIGlmICh0eXBlb2YgdmFsdWUgPT09ICd1bmRlZmluZWQnKSB7XG4gICAgICByZXR1cm47XG4gICAgfVxuICAgIHRoaXMuX29mZnNldEJvdHRvbSA9IHRvTnVtYmVyKHZhbHVlLCBudWxsKTtcbiAgICB0aGlzLnVwZGF0ZVBvc2l0aW9uKHt9IGFzIEV2ZW50KTtcbiAgfVxuXG4gIEBPdXRwdXQoKSByZWFkb25seSBuekNoYW5nZSA9IG5ldyBFdmVudEVtaXR0ZXI8Ym9vbGVhbj4oKTtcblxuICBwcml2YXRlIHRpbWVvdXQ6IG51bWJlcjtcbiAgcHJpdmF0ZSByZWFkb25seSBldmVudHMgPSBbJ3Jlc2l6ZScsICdzY3JvbGwnLCAndG91Y2hzdGFydCcsICd0b3VjaG1vdmUnLCAndG91Y2hlbmQnLCAncGFnZXNob3cnLCAnbG9hZCddO1xuICBAVmlld0NoaWxkKCdmaXhlZEVsJykgcHJpdmF0ZSBmaXhlZEVsOiBFbGVtZW50UmVmO1xuXG4gIHByaXZhdGUgcmVhZG9ubHkgcGxhY2Vob2xkZXJOb2RlOiBIVE1MRWxlbWVudDtcblxuICBwcml2YXRlIGFmZml4U3R5bGU6IE5HU3R5bGVJbnRlcmZhY2UgfCB1bmRlZmluZWQ7XG4gIHByaXZhdGUgcGxhY2Vob2xkZXJTdHlsZTogTkdTdHlsZUludGVyZmFjZSB8IHVuZGVmaW5lZDtcbiAgcHJpdmF0ZSBfdGFyZ2V0OiBFbGVtZW50IHwgV2luZG93IHwgbnVsbCA9IG51bGw7XG4gIHByaXZhdGUgX29mZnNldFRvcDogbnVtYmVyIHwgbnVsbDtcbiAgcHJpdmF0ZSBfb2Zmc2V0Qm90dG9tOiBudW1iZXIgfCBudWxsO1xuXG4gIGNvbnN0cnVjdG9yKFxuICAgIF9lbDogRWxlbWVudFJlZixcbiAgICBwcml2YXRlIHNjcm9sbFNydjogTnpTY3JvbGxTZXJ2aWNlLFxuICAgIC8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpuby1hbnlcbiAgICBASW5qZWN0KERPQ1VNRU5UKSBwcml2YXRlIGRvYzogYW55LFxuICAgIHByaXZhdGUgcGxhdGZvcm06IFBsYXRmb3JtXG4gICkge1xuICAgIHRoaXMucGxhY2Vob2xkZXJOb2RlID0gX2VsLm5hdGl2ZUVsZW1lbnQ7XG4gICAgaWYgKHRoaXMucGxhdGZvcm0uaXNCcm93c2VyKSB7XG4gICAgICB0aGlzLl90YXJnZXQgPSB3aW5kb3c7XG4gICAgfVxuICB9XG5cbiAgbmdPbkluaXQoKTogdm9pZCB7XG4gICAgdGhpcy50aW1lb3V0ID0gc2V0VGltZW91dCgoKSA9PiB7XG4gICAgICB0aGlzLnNldFRhcmdldEV2ZW50TGlzdGVuZXJzKCk7XG4gICAgICB0aGlzLnVwZGF0ZVBvc2l0aW9uKHt9IGFzIEV2ZW50KTtcbiAgICB9KTtcbiAgfVxuXG4gIG5nT25EZXN0cm95KCk6IHZvaWQge1xuICAgIHRoaXMuY2xlYXJFdmVudExpc3RlbmVycygpO1xuICAgIGNsZWFyVGltZW91dCh0aGlzLnRpbWVvdXQpO1xuICAgIC8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpuby1hbnlcbiAgICAodGhpcy51cGRhdGVQb3NpdGlvbiBhcyBhbnkpLmNhbmNlbCgpO1xuICB9XG5cbiAgZ2V0T2Zmc2V0KFxuICAgIGVsZW1lbnQ6IEVsZW1lbnQsXG4gICAgdGFyZ2V0OiBFbGVtZW50IHwgV2luZG93IHwgdW5kZWZpbmVkXG4gICk6IHtcbiAgICB0b3A6IG51bWJlcjtcbiAgICBsZWZ0OiBudW1iZXI7XG4gICAgd2lkdGg6IG51bWJlcjtcbiAgICBoZWlnaHQ6IG51bWJlcjtcbiAgfSB7XG4gICAgY29uc3QgZWxlbVJlY3QgPSBlbGVtZW50LmdldEJvdW5kaW5nQ2xpZW50UmVjdCgpO1xuICAgIGNvbnN0IHRhcmdldFJlY3QgPSB0aGlzLmdldFRhcmdldFJlY3QodGFyZ2V0KTtcblxuICAgIGNvbnN0IHNjcm9sbFRvcCA9IHRoaXMuc2Nyb2xsU3J2LmdldFNjcm9sbCh0YXJnZXQsIHRydWUpO1xuICAgIGNvbnN0IHNjcm9sbExlZnQgPSB0aGlzLnNjcm9sbFNydi5nZXRTY3JvbGwodGFyZ2V0LCBmYWxzZSk7XG5cbiAgICBjb25zdCBkb2NFbGVtID0gdGhpcy5kb2MuYm9keTtcbiAgICBjb25zdCBjbGllbnRUb3AgPSBkb2NFbGVtLmNsaWVudFRvcCB8fCAwO1xuICAgIGNvbnN0IGNsaWVudExlZnQgPSBkb2NFbGVtLmNsaWVudExlZnQgfHwgMDtcblxuICAgIHJldHVybiB7XG4gICAgICB0b3A6IGVsZW1SZWN0LnRvcCAtIHRhcmdldFJlY3QudG9wICsgc2Nyb2xsVG9wIC0gY2xpZW50VG9wLFxuICAgICAgbGVmdDogZWxlbVJlY3QubGVmdCAtIHRhcmdldFJlY3QubGVmdCArIHNjcm9sbExlZnQgLSBjbGllbnRMZWZ0LFxuICAgICAgd2lkdGg6IGVsZW1SZWN0LndpZHRoLFxuICAgICAgaGVpZ2h0OiBlbGVtUmVjdC5oZWlnaHRcbiAgICB9O1xuICB9XG5cbiAgcHJpdmF0ZSBzZXRUYXJnZXRFdmVudExpc3RlbmVycygpOiB2b2lkIHtcbiAgICB0aGlzLmNsZWFyRXZlbnRMaXN0ZW5lcnMoKTtcbiAgICBpZiAodGhpcy5wbGF0Zm9ybS5pc0Jyb3dzZXIpIHtcbiAgICAgIHRoaXMuZXZlbnRzLmZvckVhY2goKGV2ZW50TmFtZTogc3RyaW5nKSA9PiB7XG4gICAgICAgIHRoaXMuX3RhcmdldCEuYWRkRXZlbnRMaXN0ZW5lcihldmVudE5hbWUsIHRoaXMudXBkYXRlUG9zaXRpb24sIGZhbHNlKTtcbiAgICAgIH0pO1xuICAgIH1cbiAgfVxuXG4gIHByaXZhdGUgY2xlYXJFdmVudExpc3RlbmVycygpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5wbGF0Zm9ybS5pc0Jyb3dzZXIpIHtcbiAgICAgIHRoaXMuZXZlbnRzLmZvckVhY2goZXZlbnROYW1lID0+IHtcbiAgICAgICAgdGhpcy5fdGFyZ2V0IS5yZW1vdmVFdmVudExpc3RlbmVyKGV2ZW50TmFtZSwgdGhpcy51cGRhdGVQb3NpdGlvbiwgZmFsc2UpO1xuICAgICAgfSk7XG4gICAgfVxuICB9XG5cbiAgcHJpdmF0ZSBnZXRUYXJnZXRSZWN0KHRhcmdldDogRWxlbWVudCB8IFdpbmRvdyB8IHVuZGVmaW5lZCk6IENsaWVudFJlY3Qge1xuICAgIHJldHVybiB0YXJnZXQgIT09IHdpbmRvd1xuICAgICAgPyAodGFyZ2V0IGFzIEhUTUxFbGVtZW50KS5nZXRCb3VuZGluZ0NsaWVudFJlY3QoKVxuICAgICAgOiAoeyB0b3A6IDAsIGxlZnQ6IDAsIGJvdHRvbTogMCB9IGFzIENsaWVudFJlY3QpO1xuICB9XG5cbiAgcHJpdmF0ZSBnZW5TdHlsZShhZmZpeFN0eWxlPzogTkdTdHlsZUludGVyZmFjZSk6IHN0cmluZyB7XG4gICAgaWYgKCFhZmZpeFN0eWxlKSB7XG4gICAgICByZXR1cm4gJyc7XG4gICAgfVxuICAgIHJldHVybiBPYmplY3Qua2V5cyhhZmZpeFN0eWxlKVxuICAgICAgLm1hcChrZXkgPT4ge1xuICAgICAgICBjb25zdCB2YWwgPSBhZmZpeFN0eWxlW2tleV07XG4gICAgICAgIHJldHVybiBgJHtrZXl9OiR7dHlwZW9mIHZhbCA9PT0gJ3N0cmluZycgPyB2YWwgOiB2YWwgKyAncHgnfWA7XG4gICAgICB9KVxuICAgICAgLmpvaW4oJzsnKTtcbiAgfVxuXG4gIHByaXZhdGUgc2V0QWZmaXhTdHlsZShlOiBFdmVudCwgYWZmaXhTdHlsZT86IE5HU3R5bGVJbnRlcmZhY2UpOiB2b2lkIHtcbiAgICBjb25zdCBvcmlnaW5hbEFmZml4U3R5bGUgPSB0aGlzLmFmZml4U3R5bGU7XG4gICAgY29uc3QgaXNXaW5kb3cgPSB0aGlzLl90YXJnZXQgPT09IHdpbmRvdztcbiAgICBpZiAoZS50eXBlID09PSAnc2Nyb2xsJyAmJiBvcmlnaW5hbEFmZml4U3R5bGUgJiYgYWZmaXhTdHlsZSAmJiBpc1dpbmRvdykge1xuICAgICAgcmV0dXJuO1xuICAgIH1cbiAgICBpZiAoc2hhbGxvd0VxdWFsKG9yaWdpbmFsQWZmaXhTdHlsZSwgYWZmaXhTdHlsZSkpIHtcbiAgICAgIHJldHVybjtcbiAgICB9XG5cbiAgICBjb25zdCBmaXhlZCA9ICEhYWZmaXhTdHlsZTtcbiAgICBjb25zdCB3cmFwRWwgPSB0aGlzLmZpeGVkRWwubmF0aXZlRWxlbWVudCBhcyBIVE1MRWxlbWVudDtcbiAgICB3cmFwRWwuc3R5bGUuY3NzVGV4dCA9IHRoaXMuZ2VuU3R5bGUoYWZmaXhTdHlsZSk7XG4gICAgdGhpcy5hZmZpeFN0eWxlID0gYWZmaXhTdHlsZTtcbiAgICBjb25zdCBjbHMgPSAnYW50LWFmZml4JztcbiAgICBpZiAoZml4ZWQpIHtcbiAgICAgIHdyYXBFbC5jbGFzc0xpc3QuYWRkKGNscyk7XG4gICAgfSBlbHNlIHtcbiAgICAgIHdyYXBFbC5jbGFzc0xpc3QucmVtb3ZlKGNscyk7XG4gICAgfVxuXG4gICAgaWYgKChhZmZpeFN0eWxlICYmICFvcmlnaW5hbEFmZml4U3R5bGUpIHx8ICghYWZmaXhTdHlsZSAmJiBvcmlnaW5hbEFmZml4U3R5bGUpKSB7XG4gICAgICB0aGlzLm56Q2hhbmdlLmVtaXQoZml4ZWQpO1xuICAgIH1cbiAgfVxuXG4gIHByaXZhdGUgc2V0UGxhY2Vob2xkZXJTdHlsZShwbGFjZWhvbGRlclN0eWxlPzogTkdTdHlsZUludGVyZmFjZSk6IHZvaWQge1xuICAgIGNvbnN0IG9yaWdpbmFsUGxhY2Vob2xkZXJTdHlsZSA9IHRoaXMucGxhY2Vob2xkZXJTdHlsZTtcbiAgICBpZiAoc2hhbGxvd0VxdWFsKHBsYWNlaG9sZGVyU3R5bGUsIG9yaWdpbmFsUGxhY2Vob2xkZXJTdHlsZSkpIHtcbiAgICAgIHJldHVybjtcbiAgICB9XG4gICAgdGhpcy5wbGFjZWhvbGRlck5vZGUuc3R5bGUuY3NzVGV4dCA9IHRoaXMuZ2VuU3R5bGUocGxhY2Vob2xkZXJTdHlsZSk7XG4gICAgdGhpcy5wbGFjZWhvbGRlclN0eWxlID0gcGxhY2Vob2xkZXJTdHlsZTtcbiAgfVxuXG4gIHByaXZhdGUgc3luY1BsYWNlaG9sZGVyU3R5bGUoZTogRXZlbnQpOiB2b2lkIHtcbiAgICBpZiAoIXRoaXMuYWZmaXhTdHlsZSkge1xuICAgICAgcmV0dXJuO1xuICAgIH1cbiAgICB0aGlzLnBsYWNlaG9sZGVyTm9kZS5zdHlsZS5jc3NUZXh0ID0gJyc7XG4gICAgdGhpcy5wbGFjZWhvbGRlclN0eWxlID0gdW5kZWZpbmVkO1xuICAgIGNvbnN0IHN0eWxlT2JqID0geyB3aWR0aDogdGhpcy5wbGFjZWhvbGRlck5vZGUub2Zmc2V0V2lkdGgsIGhlaWdodDogdGhpcy5maXhlZEVsLm5hdGl2ZUVsZW1lbnQub2Zmc2V0SGVpZ2h0IH07XG4gICAgdGhpcy5zZXRBZmZpeFN0eWxlKGUsIHtcbiAgICAgIC4uLnRoaXMuYWZmaXhTdHlsZSxcbiAgICAgIC4uLnN0eWxlT2JqXG4gICAgfSk7XG4gICAgdGhpcy5zZXRQbGFjZWhvbGRlclN0eWxlKHN0eWxlT2JqKTtcbiAgfVxuXG4gIEB0aHJvdHRsZUJ5QW5pbWF0aW9uRnJhbWVEZWNvcmF0b3IoKVxuICB1cGRhdGVQb3NpdGlvbihlOiBFdmVudCk6IHZvaWQge1xuICAgIGlmICghdGhpcy5wbGF0Zm9ybS5pc0Jyb3dzZXIpIHtcbiAgICAgIHJldHVybjtcbiAgICB9XG4gICAgY29uc3QgdGFyZ2V0Tm9kZSA9IHRoaXMuX3RhcmdldCBhcyAoSFRNTEVsZW1lbnQgfCBXaW5kb3cpO1xuICAgIC8vIEJhY2t3YXJkcyBzdXBwb3J0XG4gICAgbGV0IG9mZnNldFRvcCA9IHRoaXMubnpPZmZzZXRUb3A7XG4gICAgY29uc3Qgc2Nyb2xsVG9wID0gdGhpcy5zY3JvbGxTcnYuZ2V0U2Nyb2xsKHRhcmdldE5vZGUhLCB0cnVlKTtcbiAgICBjb25zdCBlbGVtT2Zmc2V0ID0gdGhpcy5nZXRPZmZzZXQodGhpcy5wbGFjZWhvbGRlck5vZGUsIHRhcmdldE5vZGUhKTtcbiAgICBjb25zdCBmaXhlZE5vZGUgPSB0aGlzLmZpeGVkRWwubmF0aXZlRWxlbWVudCBhcyBIVE1MRWxlbWVudDtcbiAgICBjb25zdCBlbGVtU2l6ZSA9IHtcbiAgICAgIHdpZHRoOiBmaXhlZE5vZGUub2Zmc2V0V2lkdGgsXG4gICAgICBoZWlnaHQ6IGZpeGVkTm9kZS5vZmZzZXRIZWlnaHRcbiAgICB9O1xuICAgIGNvbnN0IG9mZnNldE1vZGUgPSB7XG4gICAgICB0b3A6IGZhbHNlLFxuICAgICAgYm90dG9tOiBmYWxzZVxuICAgIH07XG4gICAgLy8gRGVmYXVsdCB0byBgb2Zmc2V0VG9wPTBgLlxuICAgIGlmICh0eXBlb2Ygb2Zmc2V0VG9wICE9PSAnbnVtYmVyJyAmJiB0eXBlb2YgdGhpcy5fb2Zmc2V0Qm90dG9tICE9PSAnbnVtYmVyJykge1xuICAgICAgb2Zmc2V0TW9kZS50b3AgPSB0cnVlO1xuICAgICAgb2Zmc2V0VG9wID0gMDtcbiAgICB9IGVsc2Uge1xuICAgICAgb2Zmc2V0TW9kZS50b3AgPSB0eXBlb2Ygb2Zmc2V0VG9wID09PSAnbnVtYmVyJztcbiAgICAgIG9mZnNldE1vZGUuYm90dG9tID0gdHlwZW9mIHRoaXMuX29mZnNldEJvdHRvbSA9PT0gJ251bWJlcic7XG4gICAgfVxuICAgIGNvbnN0IHRhcmdldFJlY3QgPSB0aGlzLmdldFRhcmdldFJlY3QodGFyZ2V0Tm9kZSBhcyBXaW5kb3cpO1xuICAgIGNvbnN0IHRhcmdldElubmVySGVpZ2h0ID0gKHRhcmdldE5vZGUgYXMgV2luZG93KS5pbm5lckhlaWdodCB8fCAodGFyZ2V0Tm9kZSBhcyBIVE1MRWxlbWVudCkuY2xpZW50SGVpZ2h0O1xuICAgIGlmIChzY3JvbGxUb3AgPj0gZWxlbU9mZnNldC50b3AgLSAob2Zmc2V0VG9wIGFzIG51bWJlcikgJiYgb2Zmc2V0TW9kZS50b3ApIHtcbiAgICAgIGNvbnN0IHdpZHRoID0gZWxlbU9mZnNldC53aWR0aDtcbiAgICAgIGNvbnN0IHRvcCA9IHRhcmdldFJlY3QudG9wICsgKG9mZnNldFRvcCBhcyBudW1iZXIpO1xuICAgICAgdGhpcy5zZXRBZmZpeFN0eWxlKGUsIHtcbiAgICAgICAgcG9zaXRpb246ICdmaXhlZCcsXG4gICAgICAgIHRvcCxcbiAgICAgICAgbGVmdDogdGFyZ2V0UmVjdC5sZWZ0ICsgZWxlbU9mZnNldC5sZWZ0LFxuICAgICAgICBtYXhIZWlnaHQ6IGBjYWxjKDEwMHZoIC0gJHt0b3B9cHgpYCxcbiAgICAgICAgd2lkdGhcbiAgICAgIH0pO1xuICAgICAgdGhpcy5zZXRQbGFjZWhvbGRlclN0eWxlKHtcbiAgICAgICAgd2lkdGgsXG4gICAgICAgIGhlaWdodDogZWxlbVNpemUuaGVpZ2h0XG4gICAgICB9KTtcbiAgICB9IGVsc2UgaWYgKFxuICAgICAgc2Nyb2xsVG9wIDw9IGVsZW1PZmZzZXQudG9wICsgZWxlbVNpemUuaGVpZ2h0ICsgKHRoaXMuX29mZnNldEJvdHRvbSBhcyBudW1iZXIpIC0gdGFyZ2V0SW5uZXJIZWlnaHQgJiZcbiAgICAgIG9mZnNldE1vZGUuYm90dG9tXG4gICAgKSB7XG4gICAgICBjb25zdCB0YXJnZXRCb3R0b21PZmZldCA9IHRhcmdldE5vZGUgPT09IHdpbmRvdyA/IDAgOiB3aW5kb3cuaW5uZXJIZWlnaHQgLSB0YXJnZXRSZWN0LmJvdHRvbTtcbiAgICAgIGNvbnN0IHdpZHRoID0gZWxlbU9mZnNldC53aWR0aDtcbiAgICAgIHRoaXMuc2V0QWZmaXhTdHlsZShlLCB7XG4gICAgICAgIHBvc2l0aW9uOiAnZml4ZWQnLFxuICAgICAgICBib3R0b206IHRhcmdldEJvdHRvbU9mZmV0ICsgKHRoaXMuX29mZnNldEJvdHRvbSBhcyBudW1iZXIpLFxuICAgICAgICBsZWZ0OiB0YXJnZXRSZWN0LmxlZnQgKyBlbGVtT2Zmc2V0LmxlZnQsXG4gICAgICAgIHdpZHRoXG4gICAgICB9KTtcbiAgICAgIHRoaXMuc2V0UGxhY2Vob2xkZXJTdHlsZSh7XG4gICAgICAgIHdpZHRoLFxuICAgICAgICBoZWlnaHQ6IGVsZW1PZmZzZXQuaGVpZ2h0XG4gICAgICB9KTtcbiAgICB9IGVsc2Uge1xuICAgICAgaWYgKFxuICAgICAgICBlLnR5cGUgPT09ICdyZXNpemUnICYmXG4gICAgICAgIHRoaXMuYWZmaXhTdHlsZSAmJlxuICAgICAgICB0aGlzLmFmZml4U3R5bGUucG9zaXRpb24gPT09ICdmaXhlZCcgJiZcbiAgICAgICAgdGhpcy5wbGFjZWhvbGRlck5vZGUub2Zmc2V0V2lkdGhcbiAgICAgICkge1xuICAgICAgICB0aGlzLnNldEFmZml4U3R5bGUoZSwgeyAuLi50aGlzLmFmZml4U3R5bGUsIHdpZHRoOiB0aGlzLnBsYWNlaG9sZGVyTm9kZS5vZmZzZXRXaWR0aCB9KTtcbiAgICAgIH0gZWxzZSB7XG4gICAgICAgIHRoaXMuc2V0QWZmaXhTdHlsZShlKTtcbiAgICAgIH1cbiAgICAgIHRoaXMuc2V0UGxhY2Vob2xkZXJTdHlsZSgpO1xuICAgIH1cblxuICAgIGlmIChlLnR5cGUgPT09ICdyZXNpemUnKSB7XG4gICAgICB0aGlzLnN5bmNQbGFjZWhvbGRlclN0eWxlKGUpO1xuICAgIH1cbiAgfVxufVxuIl19