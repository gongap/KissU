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
import { forwardRef, ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, EventEmitter, Input, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { fromEvent, merge } from 'rxjs';
import { distinctUntilChanged, filter, map, pluck, takeUntil, tap } from 'rxjs/operators';
import { arraysEqual, ensureNumberInRange, getElementOffset, getPercent, getPrecision, shallowCopyArray, silentEvent, InputBoolean } from 'ng-zorro-antd/core';
import { isValueARange } from './nz-slider-definitions';
import { getValueTypeNotMatchError } from './nz-slider-error';
export class NzSliderComponent {
    /**
     * @param {?} cdr
     * @param {?} platform
     */
    constructor(cdr, platform) {
        this.cdr = cdr;
        this.platform = platform;
        this.nzDisabled = false;
        this.nzDots = false;
        this.nzIncluded = true;
        this.nzRange = false;
        this.nzVertical = false;
        this.nzDefaultValue = null;
        this.nzMarks = null;
        this.nzMax = 100;
        this.nzMin = 0;
        this.nzStep = 1;
        this.nzTooltipVisible = 'default';
        this.nzOnAfterChange = new EventEmitter();
        this.value = null;
        this.cacheSliderStart = null;
        this.cacheSliderLength = null;
        this.activeValueIndex = undefined; // Current activated handle's index ONLY for range=true
        // Current activated handle's index ONLY for range=true
        this.track = { offset: null, length: null }; // Track's offset and length
        // "steps" in array type with more data & FILTER out the invalid mark
        this.bounds = { lower: null, upper: null }; // now for nz-slider-step
        // now for nz-slider-step
        this.isDragging = false; // Current dragging state
    }
    /**
     * @return {?}
     */
    ngOnInit() {
        this.handles = this.generateHandles(this.nzRange ? 2 : 1);
        this.sliderDOM = this.slider.nativeElement;
        this.marksArray = this.nzMarks ? this.generateMarkItems(this.nzMarks) : null;
        if (this.platform.isBrowser) {
            this.createDraggingObservables();
        }
        this.toggleDragDisabled(this.nzDisabled);
        if (this.getValue() === null) {
            this.setValue(this.formatValue(null));
        }
    }
    /**
     * @param {?} changes
     * @return {?}
     */
    ngOnChanges(changes) {
        const { nzDisabled, nzMarks, nzRange } = changes;
        if (nzDisabled && !nzDisabled.firstChange) {
            this.toggleDragDisabled(nzDisabled.currentValue);
        }
        else if (nzMarks && !nzMarks.firstChange) {
            this.marksArray = this.nzMarks ? this.generateMarkItems(this.nzMarks) : null;
        }
        else if (nzRange && !nzRange.firstChange) {
            this.setValue(this.formatValue(null));
        }
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this.unsubscribeDrag();
    }
    /**
     * @param {?} val
     * @return {?}
     */
    writeValue(val) {
        this.setValue(val, true);
    }
    /**
     * @param {?} _value
     * @return {?}
     */
    onValueChange(_value) { }
    /**
     * @return {?}
     */
    onTouched() { }
    /**
     * @param {?} fn
     * @return {?}
     */
    registerOnChange(fn) {
        this.onValueChange = fn;
    }
    /**
     * @param {?} fn
     * @return {?}
     */
    registerOnTouched(fn) {
        this.onTouched = fn;
    }
    /**
     * @param {?} isDisabled
     * @return {?}
     */
    setDisabledState(isDisabled) {
        this.nzDisabled = isDisabled;
        this.toggleDragDisabled(isDisabled);
    }
    /**
     * @private
     * @param {?} value
     * @param {?=} isWriteValue
     * @return {?}
     */
    setValue(value, isWriteValue = false) {
        if (isWriteValue) {
            this.value = this.formatValue(value);
            this.updateTrackAndHandles();
        }
        else if (!this.valuesEqual((/** @type {?} */ (this.value)), (/** @type {?} */ (value)))) {
            this.value = value;
            this.updateTrackAndHandles();
            this.onValueChange(this.getValue(true));
        }
    }
    /**
     * @private
     * @param {?=} cloneAndSort
     * @return {?}
     */
    getValue(cloneAndSort = false) {
        if (cloneAndSort && this.value && isValueARange(this.value)) {
            return shallowCopyArray(this.value).sort((/**
             * @param {?} a
             * @param {?} b
             * @return {?}
             */
            (a, b) => a - b));
        }
        return (/** @type {?} */ (this.value));
    }
    /**
     * Clone & sort current value and convert them to offsets, then return the new one.
     * @private
     * @param {?=} value
     * @return {?}
     */
    getValueToOffset(value) {
        /** @type {?} */
        let normalizedValue = value;
        if (typeof normalizedValue === 'undefined') {
            normalizedValue = this.getValue(true);
        }
        return isValueARange(normalizedValue)
            ? normalizedValue.map((/**
             * @param {?} val
             * @return {?}
             */
            val => this.valueToOffset(val)))
            : this.valueToOffset(normalizedValue);
    }
    /**
     * Find the closest value to be activated (only for range = true).
     * @private
     * @param {?} pointerValue
     * @return {?}
     */
    setActiveValueIndex(pointerValue) {
        /** @type {?} */
        const value = this.getValue();
        if (isValueARange(value)) {
            /** @type {?} */
            let minimal = null;
            /** @type {?} */
            let gap;
            /** @type {?} */
            let activeIndex = -1;
            value.forEach((/**
             * @param {?} val
             * @param {?} index
             * @return {?}
             */
            (val, index) => {
                gap = Math.abs(pointerValue - val);
                if (minimal === null || gap < (/** @type {?} */ (minimal))) {
                    minimal = gap;
                    activeIndex = index;
                }
            }));
            this.activeValueIndex = activeIndex;
        }
    }
    /**
     * @private
     * @param {?} pointerValue
     * @return {?}
     */
    setActiveValue(pointerValue) {
        if (isValueARange((/** @type {?} */ (this.value)))) {
            /** @type {?} */
            const newValue = shallowCopyArray((/** @type {?} */ (this.value)));
            newValue[(/** @type {?} */ (this.activeValueIndex))] = pointerValue;
            this.setValue(newValue);
        }
        else {
            this.setValue(pointerValue);
        }
    }
    /**
     * Update track and handles' position and length.
     * @private
     * @return {?}
     */
    updateTrackAndHandles() {
        /** @type {?} */
        const value = this.getValue();
        /** @type {?} */
        const offset = this.getValueToOffset(value);
        /** @type {?} */
        const valueSorted = this.getValue(true);
        /** @type {?} */
        const offsetSorted = this.getValueToOffset(valueSorted);
        /** @type {?} */
        const boundParts = isValueARange(valueSorted) ? valueSorted : [0, valueSorted];
        /** @type {?} */
        const trackParts = isValueARange(offsetSorted)
            ? [offsetSorted[0], offsetSorted[1] - offsetSorted[0]]
            : [0, offsetSorted];
        this.handles.forEach((/**
         * @param {?} handle
         * @param {?} index
         * @return {?}
         */
        (handle, index) => {
            handle.offset = isValueARange(offset) ? offset[index] : offset;
            handle.value = isValueARange(value) ? value[index] : value || 0;
        }));
        [this.bounds.lower, this.bounds.upper] = boundParts;
        [this.track.offset, this.track.length] = trackParts;
        this.cdr.markForCheck();
    }
    /**
     * @private
     * @param {?} value
     * @return {?}
     */
    onDragStart(value) {
        this.toggleDragMoving(true);
        this.cacheSliderProperty();
        this.setActiveValueIndex(value);
        this.setActiveValue(value);
        this.showHandleTooltip(this.nzRange ? this.activeValueIndex : 0);
    }
    /**
     * @private
     * @param {?} value
     * @return {?}
     */
    onDragMove(value) {
        this.setActiveValue(value);
        this.cdr.markForCheck();
    }
    /**
     * @private
     * @return {?}
     */
    onDragEnd() {
        this.nzOnAfterChange.emit(this.getValue(true));
        this.toggleDragMoving(false);
        this.cacheSliderProperty(true);
        this.hideAllHandleTooltip();
        this.cdr.markForCheck();
    }
    /**
     * Create user interactions handles.
     * @private
     * @return {?}
     */
    createDraggingObservables() {
        /** @type {?} */
        const sliderDOM = this.sliderDOM;
        /** @type {?} */
        const orientField = this.nzVertical ? 'pageY' : 'pageX';
        /** @type {?} */
        const mouse = {
            start: 'mousedown',
            move: 'mousemove',
            end: 'mouseup',
            pluckKey: [orientField]
        };
        /** @type {?} */
        const touch = {
            start: 'touchstart',
            move: 'touchmove',
            end: 'touchend',
            pluckKey: ['touches', '0', orientField],
            filter: (/**
             * @param {?} e
             * @return {?}
             */
            (e) => e instanceof TouchEvent)
        };
        [mouse, touch].forEach((/**
         * @param {?} source
         * @return {?}
         */
        source => {
            const { start, move, end, pluckKey, filter: filterFunc = (/**
             * @return {?}
             */
            () => true) } = source;
            source.startPlucked$ = fromEvent(sliderDOM, start).pipe(filter(filterFunc), tap(silentEvent), pluck(...pluckKey), map((/**
             * @param {?} position
             * @return {?}
             */
            (position) => this.findClosestValue(position))));
            source.end$ = fromEvent(document, end);
            source.moveResolved$ = fromEvent(document, move).pipe(filter(filterFunc), tap(silentEvent), pluck(...pluckKey), distinctUntilChanged(), map((/**
             * @param {?} position
             * @return {?}
             */
            (position) => this.findClosestValue(position))), distinctUntilChanged(), takeUntil(source.end$));
        }));
        this.dragStart$ = merge((/** @type {?} */ (mouse.startPlucked$)), (/** @type {?} */ (touch.startPlucked$)));
        this.dragMove$ = merge((/** @type {?} */ (mouse.moveResolved$)), (/** @type {?} */ (touch.moveResolved$)));
        this.dragEnd$ = merge((/** @type {?} */ (mouse.end$)), (/** @type {?} */ (touch.end$)));
    }
    /**
     * @private
     * @param {?=} periods
     * @return {?}
     */
    subscribeDrag(periods = ['start', 'move', 'end']) {
        if (periods.indexOf('start') !== -1 && this.dragStart$ && !this.dragStart_) {
            this.dragStart_ = this.dragStart$.subscribe(this.onDragStart.bind(this));
        }
        if (periods.indexOf('move') !== -1 && this.dragMove$ && !this.dragMove_) {
            this.dragMove_ = this.dragMove$.subscribe(this.onDragMove.bind(this));
        }
        if (periods.indexOf('end') !== -1 && this.dragEnd$ && !this.dragEnd_) {
            this.dragEnd_ = this.dragEnd$.subscribe(this.onDragEnd.bind(this));
        }
    }
    /**
     * @private
     * @param {?=} periods
     * @return {?}
     */
    unsubscribeDrag(periods = ['start', 'move', 'end']) {
        if (periods.indexOf('start') !== -1 && this.dragStart_) {
            this.dragStart_.unsubscribe();
            this.dragStart_ = null;
        }
        if (periods.indexOf('move') !== -1 && this.dragMove_) {
            this.dragMove_.unsubscribe();
            this.dragMove_ = null;
        }
        if (periods.indexOf('end') !== -1 && this.dragEnd_) {
            this.dragEnd_.unsubscribe();
            this.dragEnd_ = null;
        }
    }
    /**
     * @private
     * @param {?} movable
     * @return {?}
     */
    toggleDragMoving(movable) {
        /** @type {?} */
        const periods = ['move', 'end'];
        if (movable) {
            this.isDragging = true;
            this.subscribeDrag(periods);
        }
        else {
            this.isDragging = false;
            this.unsubscribeDrag(periods);
        }
    }
    /**
     * @private
     * @param {?} disabled
     * @return {?}
     */
    toggleDragDisabled(disabled) {
        if (disabled) {
            this.unsubscribeDrag();
        }
        else {
            this.subscribeDrag(['start']);
        }
    }
    /**
     * @private
     * @param {?} position
     * @return {?}
     */
    findClosestValue(position) {
        /** @type {?} */
        const sliderStart = this.getSliderStartPosition();
        /** @type {?} */
        const sliderLength = this.getSliderLength();
        /** @type {?} */
        const ratio = ensureNumberInRange((position - sliderStart) / sliderLength, 0, 1);
        /** @type {?} */
        const val = (this.nzMax - this.nzMin) * (this.nzVertical ? 1 - ratio : ratio) + this.nzMin;
        /** @type {?} */
        const points = this.nzMarks === null ? [] : Object.keys(this.nzMarks).map(parseFloat);
        if (this.nzStep !== null && !this.nzDots) {
            /** @type {?} */
            const closestOne = Math.round(val / this.nzStep) * this.nzStep;
            points.push(closestOne);
        }
        /** @type {?} */
        const gaps = points.map((/**
         * @param {?} point
         * @return {?}
         */
        point => Math.abs(val - point)));
        /** @type {?} */
        const closest = points[gaps.indexOf(Math.min(...gaps))];
        return this.nzStep === null ? closest : parseFloat(closest.toFixed(getPrecision(this.nzStep)));
    }
    /**
     * @private
     * @param {?} value
     * @return {?}
     */
    valueToOffset(value) {
        return getPercent(this.nzMin, this.nzMax, value);
    }
    /**
     * @private
     * @return {?}
     */
    getSliderStartPosition() {
        if (this.cacheSliderStart !== null) {
            return this.cacheSliderStart;
        }
        /** @type {?} */
        const offset = getElementOffset(this.sliderDOM);
        return this.nzVertical ? offset.top : offset.left;
    }
    /**
     * @private
     * @return {?}
     */
    getSliderLength() {
        if (this.cacheSliderLength !== null) {
            return this.cacheSliderLength;
        }
        /** @type {?} */
        const sliderDOM = this.sliderDOM;
        return this.nzVertical ? sliderDOM.clientHeight : sliderDOM.clientWidth;
    }
    /**
     * Cache DOM layout/reflow operations for performance (may not necessary?)
     * @private
     * @param {?=} remove
     * @return {?}
     */
    cacheSliderProperty(remove = false) {
        this.cacheSliderStart = remove ? null : this.getSliderStartPosition();
        this.cacheSliderLength = remove ? null : this.getSliderLength();
    }
    /**
     * @private
     * @param {?} value
     * @return {?}
     */
    formatValue(value) {
        /** @type {?} */
        let res = value;
        if (!this.assertValueValid((/** @type {?} */ (value)))) {
            res = this.nzDefaultValue === null ? (this.nzRange ? [this.nzMin, this.nzMax] : this.nzMin) : this.nzDefaultValue;
        }
        else {
            res = isValueARange((/** @type {?} */ (value)))
                ? ((/** @type {?} */ (value))).map((/**
                 * @param {?} val
                 * @return {?}
                 */
                val => ensureNumberInRange(val, this.nzMin, this.nzMax)))
                : ensureNumberInRange((/** @type {?} */ (value)), this.nzMin, this.nzMax);
        }
        return res;
    }
    /**
     * Check if value is valid and throw error if value-type/range not match.
     * @private
     * @param {?} value
     * @return {?}
     */
    assertValueValid(value) {
        if (!Array.isArray(value) && isNaN(typeof value !== 'number' ? parseFloat(value) : value)) {
            return false;
        }
        return this.assertValueTypeMatch(value);
    }
    /**
     * Assert that if `this.nzRange` is `true`, value is also a range, vice versa.
     * @private
     * @param {?} value
     * @return {?}
     */
    assertValueTypeMatch(value) {
        if (!value) {
            return true;
        }
        else if (isValueARange(value) !== this.nzRange) {
            throw getValueTypeNotMatchError();
        }
        else {
            return true;
        }
    }
    /**
     * @private
     * @param {?} valA
     * @param {?} valB
     * @return {?}
     */
    valuesEqual(valA, valB) {
        if (typeof valA !== typeof valB) {
            return false;
        }
        return isValueARange(valA) && isValueARange(valB) ? arraysEqual(valA, valB) : valA === valB;
    }
    /**
     * Show one handle's tooltip and hide others'.
     * @private
     * @param {?=} handleIndex
     * @return {?}
     */
    showHandleTooltip(handleIndex = 0) {
        this.handles.forEach((/**
         * @param {?} handle
         * @param {?} index
         * @return {?}
         */
        (handle, index) => {
            handle.active = index === handleIndex;
        }));
    }
    /**
     * @private
     * @return {?}
     */
    hideAllHandleTooltip() {
        this.handles.forEach((/**
         * @param {?} handle
         * @return {?}
         */
        handle => (handle.active = false)));
    }
    /**
     * @private
     * @param {?} amount
     * @return {?}
     */
    generateHandles(amount) {
        return Array(amount)
            .fill(0)
            .map((/**
         * @return {?}
         */
        () => ({ offset: null, value: null, active: false })));
    }
    /**
     * @private
     * @param {?} marks
     * @return {?}
     */
    generateMarkItems(marks) {
        /** @type {?} */
        const marksArray = [];
        for (const key in marks) {
            /** @type {?} */
            const mark = marks[key];
            /** @type {?} */
            const val = typeof key === 'number' ? key : parseFloat(key);
            if (val >= this.nzMin && val <= this.nzMax) {
                marksArray.push({ value: val, offset: this.valueToOffset(val), config: mark });
            }
        }
        return marksArray.length ? marksArray : null;
    }
}
NzSliderComponent.decorators = [
    { type: Component, args: [{
                changeDetection: ChangeDetectionStrategy.OnPush,
                encapsulation: ViewEncapsulation.None,
                selector: 'nz-slider',
                exportAs: 'nzSlider',
                preserveWhitespaces: false,
                providers: [
                    {
                        provide: NG_VALUE_ACCESSOR,
                        useExisting: forwardRef((/**
                         * @return {?}
                         */
                        () => NzSliderComponent)),
                        multi: true
                    }
                ],
                template: "<div #slider\n  class=\"ant-slider\"\n  [class.ant-slider-disabled]=\"nzDisabled\"\n  [class.ant-slider-vertical]=\"nzVertical\"\n  [class.ant-slider-with-marks]=\"marksArray\">\n  <div class=\"ant-slider-rail\"></div>\n  <nz-slider-track\n    [nzVertical]=\"nzVertical\"\n    [nzIncluded]=\"nzIncluded\"\n    [nzOffset]=\"track.offset\"\n    [nzLength]=\"track.length\"></nz-slider-track>\n  <nz-slider-step\n    *ngIf=\"marksArray\"\n    [nzVertical]=\"nzVertical\"\n    [nzLowerBound]=\"bounds.lower\"\n    [nzUpperBound]=\"bounds.upper\"\n    [nzMarksArray]=\"marksArray\"\n    [nzIncluded]=\"nzIncluded\"></nz-slider-step>\n  <nz-slider-handle\n    *ngFor=\"let handle of handles\"\n    [nzVertical]=\"nzVertical\"\n    [nzOffset]=\"handle.offset\"\n    [nzValue]=\"handle.value\"\n    [nzActive]=\"handle.active\"\n    [nzTipFormatter]=\"nzTipFormatter\"\n    [nzTooltipVisible]=\"nzTooltipVisible\"></nz-slider-handle>\n  <nz-slider-marks \n    *ngIf=\"marksArray\"\n    [nzVertical]=\"nzVertical\"\n    [nzMin]=\"nzMin\"\n    [nzMax]=\"nzMax\"\n    [nzLowerBound]=\"bounds.lower\"\n    [nzUpperBound]=\"bounds.upper\"\n    [nzMarksArray]=\"marksArray\"\n    [nzIncluded]=\"nzIncluded\"></nz-slider-marks>\n</div>"
            }] }
];
/** @nocollapse */
NzSliderComponent.ctorParameters = () => [
    { type: ChangeDetectorRef },
    { type: Platform }
];
NzSliderComponent.propDecorators = {
    slider: [{ type: ViewChild, args: ['slider',] }],
    nzDisabled: [{ type: Input }],
    nzDots: [{ type: Input }],
    nzIncluded: [{ type: Input }],
    nzRange: [{ type: Input }],
    nzVertical: [{ type: Input }],
    nzDefaultValue: [{ type: Input }],
    nzMarks: [{ type: Input }],
    nzMax: [{ type: Input }],
    nzMin: [{ type: Input }],
    nzStep: [{ type: Input }],
    nzTooltipVisible: [{ type: Input }],
    nzTipFormatter: [{ type: Input }],
    nzOnAfterChange: [{ type: Output }]
};
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzSliderComponent.prototype, "nzDisabled", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzSliderComponent.prototype, "nzDots", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzSliderComponent.prototype, "nzIncluded", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzSliderComponent.prototype, "nzRange", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzSliderComponent.prototype, "nzVertical", void 0);
if (false) {
    /** @type {?} */
    NzSliderComponent.prototype.slider;
    /** @type {?} */
    NzSliderComponent.prototype.nzDisabled;
    /** @type {?} */
    NzSliderComponent.prototype.nzDots;
    /** @type {?} */
    NzSliderComponent.prototype.nzIncluded;
    /** @type {?} */
    NzSliderComponent.prototype.nzRange;
    /** @type {?} */
    NzSliderComponent.prototype.nzVertical;
    /** @type {?} */
    NzSliderComponent.prototype.nzDefaultValue;
    /** @type {?} */
    NzSliderComponent.prototype.nzMarks;
    /** @type {?} */
    NzSliderComponent.prototype.nzMax;
    /** @type {?} */
    NzSliderComponent.prototype.nzMin;
    /** @type {?} */
    NzSliderComponent.prototype.nzStep;
    /** @type {?} */
    NzSliderComponent.prototype.nzTooltipVisible;
    /** @type {?} */
    NzSliderComponent.prototype.nzTipFormatter;
    /** @type {?} */
    NzSliderComponent.prototype.nzOnAfterChange;
    /** @type {?} */
    NzSliderComponent.prototype.value;
    /** @type {?} */
    NzSliderComponent.prototype.sliderDOM;
    /** @type {?} */
    NzSliderComponent.prototype.cacheSliderStart;
    /** @type {?} */
    NzSliderComponent.prototype.cacheSliderLength;
    /** @type {?} */
    NzSliderComponent.prototype.activeValueIndex;
    /** @type {?} */
    NzSliderComponent.prototype.track;
    /** @type {?} */
    NzSliderComponent.prototype.handles;
    /** @type {?} */
    NzSliderComponent.prototype.marksArray;
    /** @type {?} */
    NzSliderComponent.prototype.bounds;
    /** @type {?} */
    NzSliderComponent.prototype.isDragging;
    /**
     * @type {?}
     * @private
     */
    NzSliderComponent.prototype.dragStart$;
    /**
     * @type {?}
     * @private
     */
    NzSliderComponent.prototype.dragMove$;
    /**
     * @type {?}
     * @private
     */
    NzSliderComponent.prototype.dragEnd$;
    /**
     * @type {?}
     * @private
     */
    NzSliderComponent.prototype.dragStart_;
    /**
     * @type {?}
     * @private
     */
    NzSliderComponent.prototype.dragMove_;
    /**
     * @type {?}
     * @private
     */
    NzSliderComponent.prototype.dragEnd_;
    /**
     * @type {?}
     * @private
     */
    NzSliderComponent.prototype.cdr;
    /**
     * @type {?}
     * @private
     */
    NzSliderComponent.prototype.platform;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotc2xpZGVyLmNvbXBvbmVudC5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvc2xpZGVyLyIsInNvdXJjZXMiOlsibnotc2xpZGVyLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQUUsUUFBUSxFQUFFLE1BQU0sdUJBQXVCLENBQUM7QUFDakQsT0FBTyxFQUNMLFVBQVUsRUFDVix1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxVQUFVLEVBQ1YsWUFBWSxFQUNaLEtBQUssRUFJTCxNQUFNLEVBRU4sU0FBUyxFQUNULGlCQUFpQixFQUNsQixNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQXdCLGlCQUFpQixFQUFFLE1BQU0sZ0JBQWdCLENBQUM7QUFDekUsT0FBTyxFQUFFLFNBQVMsRUFBRSxLQUFLLEVBQTRCLE1BQU0sTUFBTSxDQUFDO0FBQ2xFLE9BQU8sRUFBRSxvQkFBb0IsRUFBRSxNQUFNLEVBQUUsR0FBRyxFQUFFLEtBQUssRUFBRSxTQUFTLEVBQUUsR0FBRyxFQUFFLE1BQU0sZ0JBQWdCLENBQUM7QUFFMUYsT0FBTyxFQUNMLFdBQVcsRUFDWCxtQkFBbUIsRUFDbkIsZ0JBQWdCLEVBQ2hCLFVBQVUsRUFDVixZQUFZLEVBQ1osZ0JBQWdCLEVBQ2hCLFdBQVcsRUFDWCxZQUFZLEVBRWIsTUFBTSxvQkFBb0IsQ0FBQztBQUU1QixPQUFPLEVBQ0wsYUFBYSxFQU1kLE1BQU0seUJBQXlCLENBQUM7QUFDakMsT0FBTyxFQUFFLHlCQUF5QixFQUFFLE1BQU0sbUJBQW1CLENBQUM7QUFpQjlELE1BQU0sT0FBTyxpQkFBaUI7Ozs7O0lBb0M1QixZQUFvQixHQUFzQixFQUFVLFFBQWtCO1FBQWxELFFBQUcsR0FBSCxHQUFHLENBQW1CO1FBQVUsYUFBUSxHQUFSLFFBQVEsQ0FBVTtRQWpDN0MsZUFBVSxHQUFHLEtBQUssQ0FBQztRQUNuQixXQUFNLEdBQVksS0FB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QzFDOzs7O1lBckRDLGlCQUFpQjtZQUpWLFFBQVE7OztxQkEyRGQsU0FBUyxTQUFDLFFBQVE7eUJBRWxCLEtBQUs7cUJBQ0wsS0FBSzt5QkFDTCxLQUFLO3NCQUNMLEtBQUs7eUJBQ0wsS0FBSzs2QkFDTCxLQUFLO3NCQUNMLEtBQUs7b0JBQ0wsS0FBSztvQkFDTCxLQUFLO3FCQUNMLEtBQUs7K0JBQ0wsS0FBSzs2QkFDTCxLQUFLOzhCQUVMLE1BQU07O0FBYmtCO0lBQWYsWUFBWSxFQUFFOztxREFBb0I7QUFDbkI7SUFBZixZQUFZLEVBQUU7O2lEQUF5QjtBQUN4QjtJQUFmLFlBQVksRUFBRTs7cURBQTRCO0FBQzNCO0lBQWYsWUFBWSxFQUFFOztrREFBMEI7QUFDekI7SUFBZixZQUFZLEVBQUU7O3FEQUE2Qjs7O0lBTnJELG1DQUF3Qzs7SUFFeEMsdUNBQTRDOztJQUM1QyxtQ0FBaUQ7O0lBQ2pELHVDQUFvRDs7SUFDcEQsb0NBQWtEOztJQUNsRCx1Q0FBcUQ7O0lBQ3JELDJDQUFtRDs7SUFDbkQsb0NBQXNDOztJQUN0QyxrQ0FBcUI7O0lBQ3JCLGtDQUFtQjs7SUFDbkIsbUNBQW9COztJQUNwQiw2Q0FBeUQ7O0lBQ3pELDJDQUFtRDs7SUFFbkQsNENBQXFFOztJQUVyRSxrQ0FBaUM7O0lBQ2pDLHNDQUEwQjs7SUFDMUIsNkNBQXVDOztJQUN2Qyw4Q0FBd0M7O0lBQ3hDLDZDQUFpRDs7SUFDakQsa0NBQXlGOztJQUN6RixvQ0FBeUI7O0lBQ3pCLHVDQUFrQzs7SUFDbEMsbUNBQWdHOztJQUNoRyx1Q0FBbUI7Ozs7O0lBRW5CLHVDQUF1Qzs7Ozs7SUFDdkMsc0NBQXNDOzs7OztJQUN0QyxxQ0FBb0M7Ozs7O0lBQ3BDLHVDQUF3Qzs7Ozs7SUFDeEMsc0NBQXVDOzs7OztJQUN2QyxxQ0FBc0M7Ozs7O0lBRTFCLGdDQUE4Qjs7Ozs7SUFBRSxxQ0FBMEIiLCJzb3VyY2VzQ29udGVudCI6WyIvKipcbiAqIEBsaWNlbnNlXG4gKiBDb3B5cmlnaHQgQWxpYmFiYS5jb20gQWxsIFJpZ2h0cyBSZXNlcnZlZC5cbiAqXG4gKiBVc2Ugb2YgdGhpcyBzb3VyY2UgY29kZSBpcyBnb3Zlcm5lZCBieSBhbiBNSVQtc3R5bGUgbGljZW5zZSB0aGF0IGNhbiBiZVxuICogZm91bmQgaW4gdGhlIExJQ0VOU0UgZmlsZSBhdCBodHRwczovL2dpdGh1Yi5jb20vTkctWk9SUk8vbmctem9ycm8tYW50ZC9ibG9iL21hc3Rlci9MSUNFTlNFXG4gKi9cblxuaW1wb3J0IHsgUGxhdGZvcm0gfSBmcm9tICdAYW5ndWxhci9jZGsvcGxhdGZvcm0nO1xuaW1wb3J0IHtcbiAgZm9yd2FyZFJlZixcbiAgQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3ksXG4gIENoYW5nZURldGVjdG9yUmVmLFxuICBDb21wb25lbnQsXG4gIEVsZW1lbnRSZWYsXG4gIEV2ZW50RW1pdHRlcixcbiAgSW5wdXQsXG4gIE9uQ2hhbmdlcyxcbiAgT25EZXN0cm95LFxuICBPbkluaXQsXG4gIE91dHB1dCxcbiAgU2ltcGxlQ2hhbmdlcyxcbiAgVmlld0NoaWxkLFxuICBWaWV3RW5jYXBzdWxhdGlvblxufSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IENvbnRyb2xWYWx1ZUFjY2Vzc29yLCBOR19WQUxVRV9BQ0NFU1NPUiB9IGZyb20gJ0Bhbmd1bGFyL2Zvcm1zJztcbmltcG9ydCB7IGZyb21FdmVudCwgbWVyZ2UsIE9ic2VydmFibGUsIFN1YnNjcmlwdGlvbiB9IGZyb20gJ3J4anMnO1xuaW1wb3J0IHsgZGlzdGluY3RVbnRpbENoYW5nZWQsIGZpbHRlciwgbWFwLCBwbHVjaywgdGFrZVVudGlsLCB0YXAgfSBmcm9tICdyeGpzL29wZXJhdG9ycyc7XG5cbmltcG9ydCB7XG4gIGFycmF5c0VxdWFsLFxuICBlbnN1cmVOdW1iZXJJblJhbmdlLFxuICBnZXRFbGVtZW50T2Zmc2V0LFxuICBnZXRQZXJjZW50LFxuICBnZXRQcmVjaXNpb24sXG4gIHNoYWxsb3dDb3B5QXJyYXksXG4gIHNpbGVudEV2ZW50LFxuICBJbnB1dEJvb2xlYW4sXG4gIE1vdXNlVG91Y2hPYnNlcnZlckNvbmZpZ1xufSBmcm9tICduZy16b3Jyby1hbnRkL2NvcmUnO1xuXG5pbXBvcnQge1xuICBpc1ZhbHVlQVJhbmdlLFxuICBFeHRlbmRlZE1hcmssXG4gIE1hcmtzLFxuICBTbGlkZXJIYW5kbGVyLFxuICBTbGlkZXJTaG93VG9vbHRpcCxcbiAgU2xpZGVyVmFsdWVcbn0gZnJvbSAnLi9uei1zbGlkZXItZGVmaW5pdGlvbnMnO1xuaW1wb3J0IHsgZ2V0VmFsdWVUeXBlTm90TWF0Y2hFcnJvciB9IGZyb20gJy4vbnotc2xpZGVyLWVycm9yJztcblxuQENvbXBvbmVudCh7XG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxuICBlbmNhcHN1bGF0aW9uOiBWaWV3RW5jYXBzdWxhdGlvbi5Ob25lLFxuICBzZWxlY3RvcjogJ256LXNsaWRlcicsXG4gIGV4cG9ydEFzOiAnbnpTbGlkZXInLFxuICBwcmVzZXJ2ZVdoaXRlc3BhY2VzOiBmYWxzZSxcbiAgcHJvdmlkZXJzOiBbXG4gICAge1xuICAgICAgcHJvdmlkZTogTkdfVkFMVUVfQUNDRVNTT1IsXG4gICAgICB1c2VFeGlzdGluZzogZm9yd2FyZFJlZigoKSA9PiBOelNsaWRlckNvbXBvbmVudCksXG4gICAgICBtdWx0aTogdHJ1ZVxuICAgIH1cbiAgXSxcbiAgdGVtcGxhdGVVcmw6ICcuL256LXNsaWRlci5jb21wb25lbnQuaHRtbCdcbn0pXG5leHBvcnQgY2xhc3MgTnpTbGlkZXJDb21wb25lbnQgaW1wbGVtZW50cyBDb250cm9sVmFsdWVBY2Nlc3NvciwgT25Jbml0LCBPbkNoYW5nZXMsIE9uRGVzdHJveSB7XG4gIEBWaWV3Q2hpbGQoJ3NsaWRlcicpIHNsaWRlcjogRWxlbWVudFJlZjtcblxuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpEaXNhYmxlZCA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpEb3RzOiBib29sZWFuID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekluY2x1ZGVkOiBib29sZWFuID0gdHJ1ZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56UmFuZ2U6IGJvb2xlYW4gPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56VmVydGljYWw6IGJvb2xlYW4gPSBmYWxzZTtcbiAgQElucHV0KCkgbnpEZWZhdWx0VmFsdWU6IFNsaWRlclZhbHVlIHwgbnVsbCA9IG51bGw7XG4gIEBJbnB1dCgpIG56TWFya3M6IE1hcmtzIHwgbnVsbCA9IG51bGw7XG4gIEBJbnB1dCgpIG56TWF4ID0gMTAwO1xuICBASW5wdXQoKSBuek1pbiA9IDA7XG4gIEBJbnB1dCgpIG56U3RlcCA9IDE7XG4gIEBJbnB1dCgpIG56VG9vbHRpcFZpc2libGU6IFNsaWRlclNob3dUb29sdGlwID0gJ2RlZmF1bHQnO1xuICBASW5wdXQoKSBuelRpcEZvcm1hdHRlcjogKHZhbHVlOiBudW1iZXIpID0+IHN0cmluZztcblxuICBAT3V0cHV0KCkgcmVhZG9ubHkgbnpPbkFmdGVyQ2hhbmdlID0gbmV3IEV2ZW50RW1pdHRlcjxTbGlkZXJWYWx1ZT4oKTtcblxuICB2YWx1ZTogU2xpZGVyVmFsdWUgfCBudWxsID0gbnVsbDtcbiAgc2xpZGVyRE9NOiBIVE1MRGl2RWxlbWVudDtcbiAgY2FjaGVTbGlkZXJTdGFydDogbnVtYmVyIHwgbnVsbCA9IG51bGw7XG4gIGNhY2hlU2xpZGVyTGVuZ3RoOiBudW1iZXIgfCBudWxsID0gbnVsbDtcbiAgYWN0aXZlVmFsdWVJbmRleDogbnVtYmVyIHwgdW5kZWZpbmVkID0gdW5kZWZpbmVkOyAvLyBDdXJyZW50IGFjdGl2YXRlZCBoYW5kbGUncyBpbmRleCBPTkxZIGZvciByYW5nZT10cnVlXG4gIHRyYWNrOiB7IG9mZnNldDogbnVsbCB8IG51bWJlcjsgbGVuZ3RoOiBudWxsIHwgbnVtYmVyIH0gPSB7IG9mZnNldDogbnVsbCwgbGVuZ3RoOiBudWxsIH07IC8vIFRyYWNrJ3Mgb2Zmc2V0IGFuZCBsZW5ndGhcbiAgaGFuZGxlczogU2xpZGVySGFuZGxlcltdOyAvLyBIYW5kbGVzJyBvZmZzZXRcbiAgbWFya3NBcnJheTogRXh0ZW5kZWRNYXJrW10gfCBudWxsOyAvLyBcInN0ZXBzXCIgaW4gYXJyYXkgdHlwZSB3aXRoIG1vcmUgZGF0YSAmIEZJTFRFUiBvdXQgdGhlIGludmFsaWQgbWFya1xuICBib3VuZHM6IHsgbG93ZXI6IFNsaWRlclZhbHVlIHwgbnVsbDsgdXBwZXI6IFNsaWRlclZhbHVlIHwgbnVsbCB9ID0geyBsb3dlcjogbnVsbCwgdXBwZXI6IG51bGwgfTsgLy8gbm93IGZvciBuei1zbGlkZXItc3RlcFxuICBpc0RyYWdnaW5nID0gZmFsc2U7IC8vIEN1cnJlbnQgZHJhZ2dpbmcgc3RhdGVcblxuICBwcml2YXRlIGRyYWdTdGFydCQ6IE9ic2VydmFibGU8bnVtYmVyPjtcbiAgcHJpdmF0ZSBkcmFnTW92ZSQ6IE9ic2VydmFibGU8bnVtYmVyPjtcbiAgcHJpdmF0ZSBkcmFnRW5kJDogT2JzZXJ2YWJsZTxFdmVudD47XG4gIHByaXZhdGUgZHJhZ1N0YXJ0XzogU3Vic2NyaXB0aW9uIHwgbnVsbDtcbiAgcHJpdmF0ZSBkcmFnTW92ZV86IFN1YnNjcmlwdGlvbiB8IG51bGw7XG4gIHByaXZhdGUgZHJhZ0VuZF86IFN1YnNjcmlwdGlvbiB8IG51bGw7XG5cbiAgY29uc3RydWN0b3IocHJpdmF0ZSBjZHI6IENoYW5nZURldGVjdG9yUmVmLCBwcml2YXRlIHBsYXRmb3JtOiBQbGF0Zm9ybSkge31cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICB0aGlzLmhhbmRsZXMgPSB0aGlzLmdlbmVyYXRlSGFuZGxlcyh0aGlzLm56UmFuZ2UgPyAyIDogMSk7XG4gICAgdGhpcy5zbGlkZXJET00gPSB0aGlzLnNsaWRlci5uYXRpdmVFbGVtZW50O1xuICAgIHRoaXMubWFya3NBcnJheSA9IHRoaXMubnpNYXJrcyA/IHRoaXMuZ2VuZXJhdGVNYXJrSXRlbXModGhpcy5uek1hcmtzKSA6IG51bGw7XG4gICAgaWYgKHRoaXMucGxhdGZvcm0uaXNCcm93c2VyKSB7XG4gICAgICB0aGlzLmNyZWF0ZURyYWdnaW5nT2JzZXJ2YWJsZXMoKTtcbiAgICB9XG4gICAgdGhpcy50b2dnbGVEcmFnRGlzYWJsZWQodGhpcy5uekRpc2FibGVkKTtcblxuICAgIGlmICh0aGlzLmdldFZhbHVlKCkgPT09IG51bGwpIHtcbiAgICAgIHRoaXMuc2V0VmFsdWUodGhpcy5mb3JtYXRWYWx1ZShudWxsKSk7XG4gICAgfVxuICB9XG5cbiAgbmdPbkNoYW5nZXMoY2hhbmdlczogU2ltcGxlQ2hhbmdlcyk6IHZvaWQge1xuICAgIGNvbnN0IHsgbnpEaXNhYmxlZCwgbnpNYXJrcywgbnpSYW5nZSB9ID0gY2hhbmdlcztcblxuICAgIGlmIChuekRpc2FibGVkICYmICFuekRpc2FibGVkLmZpcnN0Q2hhbmdlKSB7XG4gICAgICB0aGlzLnRvZ2dsZURyYWdEaXNhYmxlZChuekRpc2FibGVkLmN1cnJlbnRWYWx1ZSk7XG4gICAgfSBlbHNlIGlmIChuek1hcmtzICYmICFuek1hcmtzLmZpcnN0Q2hhbmdlKSB7XG4gICAgICB0aGlzLm1hcmtzQXJyYXkgPSB0aGlzLm56TWFya3MgPyB0aGlzLmdlbmVyYXRlTWFya0l0ZW1zKHRoaXMubnpNYXJrcykgOiBudWxsO1xuICAgIH0gZWxzZSBpZiAobnpSYW5nZSAmJiAhbnpSYW5nZS5maXJzdENoYW5nZSkge1xuICAgICAgdGhpcy5zZXRWYWx1ZSh0aGlzLmZvcm1hdFZhbHVlKG51bGwpKTtcbiAgICB9XG4gIH1cblxuICBuZ09uRGVzdHJveSgpOiB2b2lkIHtcbiAgICB0aGlzLnVuc3Vic2NyaWJlRHJhZygpO1xuICB9XG5cbiAgd3JpdGVWYWx1ZSh2YWw6IFNsaWRlclZhbHVlIHwgbnVsbCk6IHZvaWQge1xuICAgIHRoaXMuc2V0VmFsdWUodmFsLCB0cnVlKTtcbiAgfVxuXG4gIG9uVmFsdWVDaGFuZ2UoX3ZhbHVlOiBTbGlkZXJWYWx1ZSk6IHZvaWQge31cblxuICBvblRvdWNoZWQoKTogdm9pZCB7fVxuXG4gIHJlZ2lzdGVyT25DaGFuZ2UoZm46ICh2YWx1ZTogU2xpZGVyVmFsdWUpID0+IHZvaWQpOiB2b2lkIHtcbiAgICB0aGlzLm9uVmFsdWVDaGFuZ2UgPSBmbjtcbiAgfVxuXG4gIHJlZ2lzdGVyT25Ub3VjaGVkKGZuOiAoKSA9PiB2b2lkKTogdm9pZCB7XG4gICAgdGhpcy5vblRvdWNoZWQgPSBmbjtcbiAgfVxuXG4gIHNldERpc2FibGVkU3RhdGUoaXNEaXNhYmxlZDogYm9vbGVhbik6IHZvaWQge1xuICAgIHRoaXMubnpEaXNhYmxlZCA9IGlzRGlzYWJsZWQ7XG4gICAgdGhpcy50b2dnbGVEcmFnRGlzYWJsZWQoaXNEaXNhYmxlZCk7XG4gIH1cblxuICBwcml2YXRlIHNldFZhbHVlKHZhbHVlOiBTbGlkZXJWYWx1ZSB8IG51bGwsIGlzV3JpdGVWYWx1ZTogYm9vbGVhbiA9IGZhbHNlKTogdm9pZCB7XG4gICAgaWYgKGlzV3JpdGVWYWx1ZSkge1xuICAgICAgdGhpcy52YWx1ZSA9IHRoaXMuZm9ybWF0VmFsdWUodmFsdWUpO1xuICAgICAgdGhpcy51cGRhdGVUcmFja0FuZEhhbmRsZXMoKTtcbiAgICB9IGVsc2UgaWYgKCF0aGlzLnZhbHVlc0VxdWFsKHRoaXMudmFsdWUhLCB2YWx1ZSEpKSB7XG4gICAgICB0aGlzLnZhbHVlID0gdmFsdWU7XG4gICAgICB0aGlzLnVwZGF0ZVRyYWNrQW5kSGFuZGxlcygpO1xuICAgICAgdGhpcy5vblZhbHVlQ2hhbmdlKHRoaXMuZ2V0VmFsdWUodHJ1ZSkpO1xuICAgIH1cbiAgfVxuXG4gIHByaXZhdGUgZ2V0VmFsdWUoY2xvbmVBbmRTb3J0OiBib29sZWFuID0gZmFsc2UpOiBTbGlkZXJWYWx1ZSB7XG4gICAgaWYgKGNsb25lQW5kU29ydCAmJiB0aGlzLnZhbHVlICYmIGlzVmFsdWVBUmFuZ2UodGhpcy52YWx1ZSkpIHtcbiAgICAgIHJldHVybiBzaGFsbG93Q29weUFycmF5KHRoaXMudmFsdWUpLnNvcnQoKGEsIGIpID0+IGEgLSBiKTtcbiAgICB9XG4gICAgcmV0dXJuIHRoaXMudmFsdWUhO1xuICB9XG5cbiAgLyoqXG4gICAqIENsb25lICYgc29ydCBjdXJyZW50IHZhbHVlIGFuZCBjb252ZXJ0IHRoZW0gdG8gb2Zmc2V0cywgdGhlbiByZXR1cm4gdGhlIG5ldyBvbmUuXG4gICAqL1xuICBwcml2YXRlIGdldFZhbHVlVG9PZmZzZXQodmFsdWU/OiBTbGlkZXJWYWx1ZSk6IFNsaWRlclZhbHVlIHtcbiAgICBsZXQgbm9ybWFsaXplZFZhbHVlID0gdmFsdWU7XG5cbiAgICBpZiAodHlwZW9mIG5vcm1hbGl6ZWRWYWx1ZSA9PT0gJ3VuZGVmaW5lZCcpIHtcbiAgICAgIG5vcm1hbGl6ZWRWYWx1ZSA9IHRoaXMuZ2V0VmFsdWUodHJ1ZSk7XG4gICAgfVxuXG4gICAgcmV0dXJuIGlzVmFsdWVBUmFuZ2Uobm9ybWFsaXplZFZhbHVlKVxuICAgICAgPyBub3JtYWxpemVkVmFsdWUubWFwKHZhbCA9PiB0aGlzLnZhbHVlVG9PZmZzZXQodmFsKSlcbiAgICAgIDogdGhpcy52YWx1ZVRvT2Zmc2V0KG5vcm1hbGl6ZWRWYWx1ZSk7XG4gIH1cblxuICAvKipcbiAgICogRmluZCB0aGUgY2xvc2VzdCB2YWx1ZSB0byBiZSBhY3RpdmF0ZWQgKG9ubHkgZm9yIHJhbmdlID0gdHJ1ZSkuXG4gICAqL1xuICBwcml2YXRlIHNldEFjdGl2ZVZhbHVlSW5kZXgocG9pbnRlclZhbHVlOiBudW1iZXIpOiB2b2lkIHtcbiAgICBjb25zdCB2YWx1ZSA9IHRoaXMuZ2V0VmFsdWUoKTtcbiAgICBpZiAoaXNWYWx1ZUFSYW5nZSh2YWx1ZSkpIHtcbiAgICAgIGxldCBtaW5pbWFsOiBudW1iZXIgfCBudWxsID0gbnVsbDtcbiAgICAgIGxldCBnYXA6IG51bWJlcjtcbiAgICAgIGxldCBhY3RpdmVJbmRleCA9IC0xO1xuICAgICAgdmFsdWUuZm9yRWFjaCgodmFsLCBpbmRleCkgPT4ge1xuICAgICAgICBnYXAgPSBNYXRoLmFicyhwb2ludGVyVmFsdWUgLSB2YWwpO1xuICAgICAgICBpZiAobWluaW1hbCA9PT0gbnVsbCB8fCBnYXAgPCBtaW5pbWFsISkge1xuICAgICAgICAgIG1pbmltYWwgPSBnYXA7XG4gICAgICAgICAgYWN0aXZlSW5kZXggPSBpbmRleDtcbiAgICAgICAgfVxuICAgICAgfSk7XG4gICAgICB0aGlzLmFjdGl2ZVZhbHVlSW5kZXggPSBhY3RpdmVJbmRleDtcbiAgICB9XG4gIH1cblxuICBwcml2YXRlIHNldEFjdGl2ZVZhbHVlKHBvaW50ZXJWYWx1ZTogbnVtYmVyKTogdm9pZCB7XG4gICAgaWYgKGlzVmFsdWVBUmFuZ2UodGhpcy52YWx1ZSEpKSB7XG4gICAgICBjb25zdCBuZXdWYWx1ZSA9IHNoYWxsb3dDb3B5QXJyYXkodGhpcy52YWx1ZSBhcyBudW1iZXJbXSk7XG4gICAgICBuZXdWYWx1ZVt0aGlzLmFjdGl2ZVZhbHVlSW5kZXghXSA9IHBvaW50ZXJWYWx1ZTtcbiAgICAgIHRoaXMuc2V0VmFsdWUobmV3VmFsdWUpO1xuICAgIH0gZWxzZSB7XG4gICAgICB0aGlzLnNldFZhbHVlKHBvaW50ZXJWYWx1ZSk7XG4gICAgfVxuICB9XG5cbiAgLyoqXG4gICAqIFVwZGF0ZSB0cmFjayBhbmQgaGFuZGxlcycgcG9zaXRpb24gYW5kIGxlbmd0aC5cbiAgICovXG4gIHByaXZhdGUgdXBkYXRlVHJhY2tBbmRIYW5kbGVzKCk6IHZvaWQge1xuICAgIGNvbnN0IHZhbHVlID0gdGhpcy5nZXRWYWx1ZSgpO1xuICAgIGNvbnN0IG9mZnNldCA9IHRoaXMuZ2V0VmFsdWVUb09mZnNldCh2YWx1ZSk7XG4gICAgY29uc3QgdmFsdWVTb3J0ZWQgPSB0aGlzLmdldFZhbHVlKHRydWUpO1xuICAgIGNvbnN0IG9mZnNldFNvcnRlZCA9IHRoaXMuZ2V0VmFsdWVUb09mZnNldCh2YWx1ZVNvcnRlZCk7XG4gICAgY29uc3QgYm91bmRQYXJ0cyA9IGlzVmFsdWVBUmFuZ2UodmFsdWVTb3J0ZWQpID8gdmFsdWVTb3J0ZWQgOiBbMCwgdmFsdWVTb3J0ZWRdO1xuICAgIGNvbnN0IHRyYWNrUGFydHMgPSBpc1ZhbHVlQVJhbmdlKG9mZnNldFNvcnRlZClcbiAgICAgID8gW29mZnNldFNvcnRlZFswXSwgb2Zmc2V0U29ydGVkWzFdIC0gb2Zmc2V0U29ydGVkWzBdXVxuICAgICAgOiBbMCwgb2Zmc2V0U29ydGVkXTtcblxuICAgIHRoaXMuaGFuZGxlcy5mb3JFYWNoKChoYW5kbGUsIGluZGV4KSA9PiB7XG4gICAgICBoYW5kbGUub2Zmc2V0ID0gaXNWYWx1ZUFSYW5nZShvZmZzZXQpID8gb2Zmc2V0W2luZGV4XSA6IG9mZnNldDtcbiAgICAgIGhhbmRsZS52YWx1ZSA9IGlzVmFsdWVBUmFuZ2UodmFsdWUpID8gdmFsdWVbaW5kZXhdIDogdmFsdWUgfHwgMDtcbiAgICB9KTtcblxuICAgIFt0aGlzLmJvdW5kcy5sb3dlciwgdGhpcy5ib3VuZHMudXBwZXJdID0gYm91bmRQYXJ0cztcbiAgICBbdGhpcy50cmFjay5vZmZzZXQsIHRoaXMudHJhY2subGVuZ3RoXSA9IHRyYWNrUGFydHM7XG5cbiAgICB0aGlzLmNkci5tYXJrRm9yQ2hlY2soKTtcbiAgfVxuXG4gIHByaXZhdGUgb25EcmFnU3RhcnQodmFsdWU6IG51bWJlcik6IHZvaWQge1xuICAgIHRoaXMudG9nZ2xlRHJhZ01vdmluZyh0cnVlKTtcbiAgICB0aGlzLmNhY2hlU2xpZGVyUHJvcGVydHkoKTtcbiAgICB0aGlzLnNldEFjdGl2ZVZhbHVlSW5kZXgodmFsdWUpO1xuICAgIHRoaXMuc2V0QWN0aXZlVmFsdWUodmFsdWUpO1xuICAgIHRoaXMuc2hvd0hhbmRsZVRvb2x0aXAodGhpcy5uelJhbmdlID8gdGhpcy5hY3RpdmVWYWx1ZUluZGV4IDogMCk7XG4gIH1cblxuICBwcml2YXRlIG9uRHJhZ01vdmUodmFsdWU6IG51bWJlcik6IHZvaWQge1xuICAgIHRoaXMuc2V0QWN0aXZlVmFsdWUodmFsdWUpO1xuICAgIHRoaXMuY2RyLm1hcmtGb3JDaGVjaygpO1xuICB9XG5cbiAgcHJpdmF0ZSBvbkRyYWdFbmQoKTogdm9pZCB7XG4gICAgdGhpcy5uek9uQWZ0ZXJDaGFuZ2UuZW1pdCh0aGlzLmdldFZhbHVlKHRydWUpKTtcbiAgICB0aGlzLnRvZ2dsZURyYWdNb3ZpbmcoZmFsc2UpO1xuICAgIHRoaXMuY2FjaGVTbGlkZXJQcm9wZXJ0eSh0cnVlKTtcbiAgICB0aGlzLmhpZGVBbGxIYW5kbGVUb29sdGlwKCk7XG4gICAgdGhpcy5jZHIubWFya0ZvckNoZWNrKCk7XG4gIH1cblxuICAvKipcbiAgICogQ3JlYXRlIHVzZXIgaW50ZXJhY3Rpb25zIGhhbmRsZXMuXG4gICAqL1xuICBwcml2YXRlIGNyZWF0ZURyYWdnaW5nT2JzZXJ2YWJsZXMoKTogdm9pZCB7XG4gICAgY29uc3Qgc2xpZGVyRE9NID0gdGhpcy5zbGlkZXJET007XG4gICAgY29uc3Qgb3JpZW50RmllbGQgPSB0aGlzLm56VmVydGljYWwgPyAncGFnZVknIDogJ3BhZ2VYJztcbiAgICBjb25zdCBtb3VzZTogTW91c2VUb3VjaE9ic2VydmVyQ29uZmlnID0ge1xuICAgICAgc3RhcnQ6ICdtb3VzZWRvd24nLFxuICAgICAgbW92ZTogJ21vdXNlbW92ZScsXG4gICAgICBlbmQ6ICdtb3VzZXVwJyxcbiAgICAgIHBsdWNrS2V5OiBbb3JpZW50RmllbGRdXG4gICAgfTtcbiAgICBjb25zdCB0b3VjaDogTW91c2VUb3VjaE9ic2VydmVyQ29uZmlnID0ge1xuICAgICAgc3RhcnQ6ICd0b3VjaHN0YXJ0JyxcbiAgICAgIG1vdmU6ICd0b3VjaG1vdmUnLFxuICAgICAgZW5kOiAndG91Y2hlbmQnLFxuICAgICAgcGx1Y2tLZXk6IFsndG91Y2hlcycsICcwJywgb3JpZW50RmllbGRdLFxuICAgICAgZmlsdGVyOiAoZTogTW91c2VFdmVudCB8IFRvdWNoRXZlbnQpID0+IGUgaW5zdGFuY2VvZiBUb3VjaEV2ZW50XG4gICAgfTtcblxuICAgIFttb3VzZSwgdG91Y2hdLmZvckVhY2goc291cmNlID0+IHtcbiAgICAgIGNvbnN0IHsgc3RhcnQsIG1vdmUsIGVuZCwgcGx1Y2tLZXksIGZpbHRlcjogZmlsdGVyRnVuYyA9ICgpID0+IHRydWUgfSA9IHNvdXJjZTtcblxuICAgICAgc291cmNlLnN0YXJ0UGx1Y2tlZCQgPSBmcm9tRXZlbnQoc2xpZGVyRE9NLCBzdGFydCkucGlwZShcbiAgICAgICAgZmlsdGVyKGZpbHRlckZ1bmMpLFxuICAgICAgICB0YXAoc2lsZW50RXZlbnQpLFxuICAgICAgICBwbHVjazxFdmVudCwgbnVtYmVyPiguLi5wbHVja0tleSksXG4gICAgICAgIG1hcCgocG9zaXRpb246IG51bWJlcikgPT4gdGhpcy5maW5kQ2xvc2VzdFZhbHVlKHBvc2l0aW9uKSlcbiAgICAgICk7XG4gICAgICBzb3VyY2UuZW5kJCA9IGZyb21FdmVudChkb2N1bWVudCwgZW5kKTtcbiAgICAgIHNvdXJjZS5tb3ZlUmVzb2x2ZWQkID0gZnJvbUV2ZW50KGRvY3VtZW50LCBtb3ZlKS5waXBlKFxuICAgICAgICBmaWx0ZXIoZmlsdGVyRnVuYyksXG4gICAgICAgIHRhcChzaWxlbnRFdmVudCksXG4gICAgICAgIHBsdWNrPEV2ZW50LCBudW1iZXI+KC4uLnBsdWNrS2V5KSxcbiAgICAgICAgZGlzdGluY3RVbnRpbENoYW5nZWQoKSxcbiAgICAgICAgbWFwKChwb3NpdGlvbjogbnVtYmVyKSA9PiB0aGlzLmZpbmRDbG9zZXN0VmFsdWUocG9zaXRpb24pKSxcbiAgICAgICAgZGlzdGluY3RVbnRpbENoYW5nZWQoKSxcbiAgICAgICAgdGFrZVVudGlsKHNvdXJjZS5lbmQkKVxuICAgICAgKTtcbiAgICB9KTtcblxuICAgIHRoaXMuZHJhZ1N0YXJ0JCA9IG1lcmdlKG1vdXNlLnN0YXJ0UGx1Y2tlZCQhLCB0b3VjaC5zdGFydFBsdWNrZWQkISk7XG4gICAgdGhpcy5kcmFnTW92ZSQgPSBtZXJnZShtb3VzZS5tb3ZlUmVzb2x2ZWQkISwgdG91Y2gubW92ZVJlc29sdmVkJCEpO1xuICAgIHRoaXMuZHJhZ0VuZCQgPSBtZXJnZShtb3VzZS5lbmQkISwgdG91Y2guZW5kJCEpO1xuICB9XG5cbiAgcHJpdmF0ZSBzdWJzY3JpYmVEcmFnKHBlcmlvZHM6IHN0cmluZ1tdID0gWydzdGFydCcsICdtb3ZlJywgJ2VuZCddKTogdm9pZCB7XG4gICAgaWYgKHBlcmlvZHMuaW5kZXhPZignc3RhcnQnKSAhPT0gLTEgJiYgdGhpcy5kcmFnU3RhcnQkICYmICF0aGlzLmRyYWdTdGFydF8pIHtcbiAgICAgIHRoaXMuZHJhZ1N0YXJ0XyA9IHRoaXMuZHJhZ1N0YXJ0JC5zdWJzY3JpYmUodGhpcy5vbkRyYWdTdGFydC5iaW5kKHRoaXMpKTtcbiAgICB9XG5cbiAgICBpZiAocGVyaW9kcy5pbmRleE9mKCdtb3ZlJykgIT09IC0xICYmIHRoaXMuZHJhZ01vdmUkICYmICF0aGlzLmRyYWdNb3ZlXykge1xuICAgICAgdGhpcy5kcmFnTW92ZV8gPSB0aGlzLmRyYWdNb3ZlJC5zdWJzY3JpYmUodGhpcy5vbkRyYWdNb3ZlLmJpbmQodGhpcykpO1xuICAgIH1cblxuICAgIGlmIChwZXJpb2RzLmluZGV4T2YoJ2VuZCcpICE9PSAtMSAmJiB0aGlzLmRyYWdFbmQkICYmICF0aGlzLmRyYWdFbmRfKSB7XG4gICAgICB0aGlzLmRyYWdFbmRfID0gdGhpcy5kcmFnRW5kJC5zdWJzY3JpYmUodGhpcy5vbkRyYWdFbmQuYmluZCh0aGlzKSk7XG4gICAgfVxuICB9XG5cbiAgcHJpdmF0ZSB1bnN1YnNjcmliZURyYWcocGVyaW9kczogc3RyaW5nW10gPSBbJ3N0YXJ0JywgJ21vdmUnLCAnZW5kJ10pOiB2b2lkIHtcbiAgICBpZiAocGVyaW9kcy5pbmRleE9mKCdzdGFydCcpICE9PSAtMSAmJiB0aGlzLmRyYWdTdGFydF8pIHtcbiAgICAgIHRoaXMuZHJhZ1N0YXJ0Xy51bnN1YnNjcmliZSgpO1xuICAgICAgdGhpcy5kcmFnU3RhcnRfID0gbnVsbDtcbiAgICB9XG5cbiAgICBpZiAocGVyaW9kcy5pbmRleE9mKCdtb3ZlJykgIT09IC0xICYmIHRoaXMuZHJhZ01vdmVfKSB7XG4gICAgICB0aGlzLmRyYWdNb3ZlXy51bnN1YnNjcmliZSgpO1xuICAgICAgdGhpcy5kcmFnTW92ZV8gPSBudWxsO1xuICAgIH1cblxuICAgIGlmIChwZXJpb2RzLmluZGV4T2YoJ2VuZCcpICE9PSAtMSAmJiB0aGlzLmRyYWdFbmRfKSB7XG4gICAgICB0aGlzLmRyYWdFbmRfLnVuc3Vic2NyaWJlKCk7XG4gICAgICB0aGlzLmRyYWdFbmRfID0gbnVsbDtcbiAgICB9XG4gIH1cblxuICBwcml2YXRlIHRvZ2dsZURyYWdNb3ZpbmcobW92YWJsZTogYm9vbGVhbik6IHZvaWQge1xuICAgIGNvbnN0IHBlcmlvZHMgPSBbJ21vdmUnLCAnZW5kJ107XG4gICAgaWYgKG1vdmFibGUpIHtcbiAgICAgIHRoaXMuaXNEcmFnZ2luZyA9IHRydWU7XG4gICAgICB0aGlzLnN1YnNjcmliZURyYWcocGVyaW9kcyk7XG4gICAgfSBlbHNlIHtcbiAgICAgIHRoaXMuaXNEcmFnZ2luZyA9IGZhbHNlO1xuICAgICAgdGhpcy51bnN1YnNjcmliZURyYWcocGVyaW9kcyk7XG4gICAgfVxuICB9XG5cbiAgcHJpdmF0ZSB0b2dnbGVEcmFnRGlzYWJsZWQoZGlzYWJsZWQ6IGJvb2xlYW4pOiB2b2lkIHtcbiAgICBpZiAoZGlzYWJsZWQpIHtcbiAgICAgIHRoaXMudW5zdWJzY3JpYmVEcmFnKCk7XG4gICAgfSBlbHNlIHtcbiAgICAgIHRoaXMuc3Vic2NyaWJlRHJhZyhbJ3N0YXJ0J10pO1xuICAgIH1cbiAgfVxuXG4gIHByaXZhdGUgZmluZENsb3Nlc3RWYWx1ZShwb3NpdGlvbjogbnVtYmVyKTogbnVtYmVyIHtcbiAgICBjb25zdCBzbGlkZXJTdGFydCA9IHRoaXMuZ2V0U2xpZGVyU3RhcnRQb3NpdGlvbigpO1xuICAgIGNvbnN0IHNsaWRlckxlbmd0aCA9IHRoaXMuZ2V0U2xpZGVyTGVuZ3RoKCk7XG4gICAgY29uc3QgcmF0aW8gPSBlbnN1cmVOdW1iZXJJblJhbmdlKChwb3NpdGlvbiAtIHNsaWRlclN0YXJ0KSAvIHNsaWRlckxlbmd0aCwgMCwgMSk7XG4gICAgY29uc3QgdmFsID0gKHRoaXMubnpNYXggLSB0aGlzLm56TWluKSAqICh0aGlzLm56VmVydGljYWwgPyAxIC0gcmF0aW8gOiByYXRpbykgKyB0aGlzLm56TWluO1xuICAgIGNvbnN0IHBvaW50cyA9IHRoaXMubnpNYXJrcyA9PT0gbnVsbCA/IFtdIDogT2JqZWN0LmtleXModGhpcy5uek1hcmtzKS5tYXAocGFyc2VGbG9hdCk7XG4gICAgaWYgKHRoaXMubnpTdGVwICE9PSBudWxsICYmICF0aGlzLm56RG90cykge1xuICAgICAgY29uc3QgY2xvc2VzdE9uZSA9IE1hdGgucm91bmQodmFsIC8gdGhpcy5uelN0ZXApICogdGhpcy5uelN0ZXA7XG4gICAgICBwb2ludHMucHVzaChjbG9zZXN0T25lKTtcbiAgICB9XG4gICAgY29uc3QgZ2FwcyA9IHBvaW50cy5tYXAocG9pbnQgPT4gTWF0aC5hYnModmFsIC0gcG9pbnQpKTtcbiAgICBjb25zdCBjbG9zZXN0ID0gcG9pbnRzW2dhcHMuaW5kZXhPZihNYXRoLm1pbiguLi5nYXBzKSldO1xuICAgIHJldHVybiB0aGlzLm56U3RlcCA9PT0gbnVsbCA/IGNsb3Nlc3QgOiBwYXJzZUZsb2F0KGNsb3Nlc3QudG9GaXhlZChnZXRQcmVjaXNpb24odGhpcy5uelN0ZXApKSk7XG4gIH1cblxuICBwcml2YXRlIHZhbHVlVG9PZmZzZXQodmFsdWU6IG51bWJlcik6IG51bWJlciB7XG4gICAgcmV0dXJuIGdldFBlcmNlbnQodGhpcy5uek1pbiwgdGhpcy5uek1heCwgdmFsdWUpO1xuICB9XG5cbiAgcHJpdmF0ZSBnZXRTbGlkZXJTdGFydFBvc2l0aW9uKCk6IG51bWJlciB7XG4gICAgaWYgKHRoaXMuY2FjaGVTbGlkZXJTdGFydCAhPT0gbnVsbCkge1xuICAgICAgcmV0dXJuIHRoaXMuY2FjaGVTbGlkZXJTdGFydDtcbiAgICB9XG4gICAgY29uc3Qgb2Zmc2V0ID0gZ2V0RWxlbWVudE9mZnNldCh0aGlzLnNsaWRlckRPTSk7XG4gICAgcmV0dXJuIHRoaXMubnpWZXJ0aWNhbCA/IG9mZnNldC50b3AgOiBvZmZzZXQubGVmdDtcbiAgfVxuXG4gIHByaXZhdGUgZ2V0U2xpZGVyTGVuZ3RoKCk6IG51bWJlciB7XG4gICAgaWYgKHRoaXMuY2FjaGVTbGlkZXJMZW5ndGggIT09IG51bGwpIHtcbiAgICAgIHJldHVybiB0aGlzLmNhY2hlU2xpZGVyTGVuZ3RoO1xuICAgIH1cbiAgICBjb25zdCBzbGlkZXJET00gPSB0aGlzLnNsaWRlckRPTTtcbiAgICByZXR1cm4gdGhpcy5uelZlcnRpY2FsID8gc2xpZGVyRE9NLmNsaWVudEhlaWdodCA6IHNsaWRlckRPTS5jbGllbnRXaWR0aDtcbiAgfVxuXG4gIC8qKlxuICAgKiBDYWNoZSBET00gbGF5b3V0L3JlZmxvdyBvcGVyYXRpb25zIGZvciBwZXJmb3JtYW5jZSAobWF5IG5vdCBuZWNlc3Nhcnk/KVxuICAgKi9cbiAgcHJpdmF0ZSBjYWNoZVNsaWRlclByb3BlcnR5KHJlbW92ZTogYm9vbGVhbiA9IGZhbHNlKTogdm9pZCB7XG4gICAgdGhpcy5jYWNoZVNsaWRlclN0YXJ0ID0gcmVtb3ZlID8gbnVsbCA6IHRoaXMuZ2V0U2xpZGVyU3RhcnRQb3NpdGlvbigpO1xuICAgIHRoaXMuY2FjaGVTbGlkZXJMZW5ndGggPSByZW1vdmUgPyBudWxsIDogdGhpcy5nZXRTbGlkZXJMZW5ndGgoKTtcbiAgfVxuXG4gIHByaXZhdGUgZm9ybWF0VmFsdWUodmFsdWU6IFNsaWRlclZhbHVlIHwgbnVsbCk6IFNsaWRlclZhbHVlIHtcbiAgICBsZXQgcmVzID0gdmFsdWU7XG4gICAgaWYgKCF0aGlzLmFzc2VydFZhbHVlVmFsaWQodmFsdWUhKSkge1xuICAgICAgcmVzID0gdGhpcy5uekRlZmF1bHRWYWx1ZSA9PT0gbnVsbCA/ICh0aGlzLm56UmFuZ2UgPyBbdGhpcy5uek1pbiwgdGhpcy5uek1heF0gOiB0aGlzLm56TWluKSA6IHRoaXMubnpEZWZhdWx0VmFsdWU7XG4gICAgfSBlbHNlIHtcbiAgICAgIHJlcyA9IGlzVmFsdWVBUmFuZ2UodmFsdWUhKVxuICAgICAgICA/ICh2YWx1ZSBhcyBudW1iZXJbXSkubWFwKHZhbCA9PiBlbnN1cmVOdW1iZXJJblJhbmdlKHZhbCwgdGhpcy5uek1pbiwgdGhpcy5uek1heCkpXG4gICAgICAgIDogZW5zdXJlTnVtYmVySW5SYW5nZSh2YWx1ZSBhcyBudW1iZXIsIHRoaXMubnpNaW4sIHRoaXMubnpNYXgpO1xuICAgIH1cblxuICAgIHJldHVybiByZXM7XG4gIH1cblxuICAvKipcbiAgICogQ2hlY2sgaWYgdmFsdWUgaXMgdmFsaWQgYW5kIHRocm93IGVycm9yIGlmIHZhbHVlLXR5cGUvcmFuZ2Ugbm90IG1hdGNoLlxuICAgKi9cbiAgcHJpdmF0ZSBhc3NlcnRWYWx1ZVZhbGlkKHZhbHVlOiBTbGlkZXJWYWx1ZSk6IGJvb2xlYW4ge1xuICAgIGlmICghQXJyYXkuaXNBcnJheSh2YWx1ZSkgJiYgaXNOYU4odHlwZW9mIHZhbHVlICE9PSAnbnVtYmVyJyA/IHBhcnNlRmxvYXQodmFsdWUpIDogdmFsdWUpKSB7XG4gICAgICByZXR1cm4gZmFsc2U7XG4gICAgfVxuICAgIHJldHVybiB0aGlzLmFzc2VydFZhbHVlVHlwZU1hdGNoKHZhbHVlKTtcbiAgfVxuXG4gIC8qKlxuICAgKiBBc3NlcnQgdGhhdCBpZiBgdGhpcy5uelJhbmdlYCBpcyBgdHJ1ZWAsIHZhbHVlIGlzIGFsc28gYSByYW5nZSwgdmljZSB2ZXJzYS5cbiAgICovXG4gIHByaXZhdGUgYXNzZXJ0VmFsdWVUeXBlTWF0Y2godmFsdWU6IFNsaWRlclZhbHVlIHwgbnVsbCk6IGJvb2xlYW4ge1xuICAgIGlmICghdmFsdWUpIHtcbiAgICAgIHJldHVybiB0cnVlO1xuICAgIH0gZWxzZSBpZiAoaXNWYWx1ZUFSYW5nZSh2YWx1ZSkgIT09IHRoaXMubnpSYW5nZSkge1xuICAgICAgdGhyb3cgZ2V0VmFsdWVUeXBlTm90TWF0Y2hFcnJvcigpO1xuICAgIH0gZWxzZSB7XG4gICAgICByZXR1cm4gdHJ1ZTtcbiAgICB9XG4gIH1cblxuICBwcml2YXRlIHZhbHVlc0VxdWFsKHZhbEE6IFNsaWRlclZhbHVlLCB2YWxCOiBTbGlkZXJWYWx1ZSk6IGJvb2xlYW4ge1xuICAgIGlmICh0eXBlb2YgdmFsQSAhPT0gdHlwZW9mIHZhbEIpIHtcbiAgICAgIHJldHVybiBmYWxzZTtcbiAgICB9XG4gICAgcmV0dXJuIGlzVmFsdWVBUmFuZ2UodmFsQSkgJiYgaXNWYWx1ZUFSYW5nZSh2YWxCKSA/IGFycmF5c0VxdWFsPG51bWJlcj4odmFsQSwgdmFsQikgOiB2YWxBID09PSB2YWxCO1xuICB9XG5cbiAgLyoqXG4gICAqIFNob3cgb25lIGhhbmRsZSdzIHRvb2x0aXAgYW5kIGhpZGUgb3RoZXJzJy5cbiAgICovXG4gIHByaXZhdGUgc2hvd0hhbmRsZVRvb2x0aXAoaGFuZGxlSW5kZXg6IG51bWJlciA9IDApOiB2b2lkIHtcbiAgICB0aGlzLmhhbmRsZXMuZm9yRWFjaCgoaGFuZGxlLCBpbmRleCkgPT4ge1xuICAgICAgaGFuZGxlLmFjdGl2ZSA9IGluZGV4ID09PSBoYW5kbGVJbmRleDtcbiAgICB9KTtcbiAgfVxuXG4gIHByaXZhdGUgaGlkZUFsbEhhbmRsZVRvb2x0aXAoKTogdm9pZCB7XG4gICAgdGhpcy5oYW5kbGVzLmZvckVhY2goaGFuZGxlID0+IChoYW5kbGUuYWN0aXZlID0gZmFsc2UpKTtcbiAgfVxuXG4gIHByaXZhdGUgZ2VuZXJhdGVIYW5kbGVzKGFtb3VudDogbnVtYmVyKTogU2xpZGVySGFuZGxlcltdIHtcbiAgICByZXR1cm4gQXJyYXkoYW1vdW50KVxuICAgICAgLmZpbGwoMClcbiAgICAgIC5tYXAoKCkgPT4gKHsgb2Zmc2V0OiBudWxsLCB2YWx1ZTogbnVsbCwgYWN0aXZlOiBmYWxzZSB9KSk7XG4gIH1cblxuICBwcml2YXRlIGdlbmVyYXRlTWFya0l0ZW1zKG1hcmtzOiBNYXJrcyk6IEV4dGVuZGVkTWFya1tdIHwgbnVsbCB7XG4gICAgY29uc3QgbWFya3NBcnJheTogRXh0ZW5kZWRNYXJrW10gPSBbXTtcbiAgICBmb3IgKGNvbnN0IGtleSBpbiBtYXJrcykge1xuICAgICAgY29uc3QgbWFyayA9IG1hcmtzW2tleV07XG4gICAgICBjb25zdCB2YWwgPSB0eXBlb2Yga2V5ID09PSAnbnVtYmVyJyA/IGtleSA6IHBhcnNlRmxvYXQoa2V5KTtcbiAgICAgIGlmICh2YWwgPj0gdGhpcy5uek1pbiAmJiB2YWwgPD0gdGhpcy5uek1heCkge1xuICAgICAgICBtYXJrc0FycmF5LnB1c2goeyB2YWx1ZTogdmFsLCBvZmZzZXQ6IHRoaXMudmFsdWVUb09mZnNldCh2YWwpLCBjb25maWc6IG1hcmsgfSk7XG4gICAgICB9XG4gICAgfVxuICAgIHJldHVybiBtYXJrc0FycmF5Lmxlbmd0aCA/IG1hcmtzQXJyYXkgOiBudWxsO1xuICB9XG59XG4iXX0=