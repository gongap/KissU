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
import { BACKSPACE, DOWN_ARROW, ENTER, SPACE, TAB, UP_ARROW } from '@angular/cdk/keycodes';
import { Injectable } from '@angular/core';
import { combineLatest, merge, BehaviorSubject, ReplaySubject, Subject } from 'rxjs';
import { distinctUntilChanged, filter, map, share, skip, tap } from 'rxjs/operators';
import { isNil, isNotNil } from 'ng-zorro-antd/core';
import { NzOptionComponent } from './nz-option.component';
import { defaultFilterOption, NzFilterOptionPipe } from './nz-option.pipe';
var NzSelectService = /** @class */ (function () {
    function NzSelectService() {
        var _this = this;
        // Input params
        this.autoClearSearchValue = true;
        this.serverSearch = false;
        this.filterOption = defaultFilterOption;
        this.mode = 'default';
        this.maxMultipleCount = Infinity;
        this.disabled = false;
        // tslint:disable-next-line:no-any
        this.compareWith = (/**
         * @param {?} o1
         * @param {?} o2
         * @return {?}
         */
        function (o1, o2) { return o1 === o2; });
        // selectedValueChanged should emit ngModelChange or not
        // tslint:disable-next-line:no-any
        this.listOfSelectedValueWithEmit$ = new BehaviorSubject({
            value: [],
            emit: false
        });
        // ContentChildren Change
        this.mapOfTemplateOption$ = new BehaviorSubject({
            listOfNzOptionComponent: [],
            listOfNzOptionGroupComponent: []
        });
        // searchValue Change
        this.searchValueRaw$ = new BehaviorSubject('');
        this.listOfFilteredOption = [];
        this.openRaw$ = new Subject();
        this.checkRaw$ = new Subject();
        this.open = false;
        this.clearInput$ = new Subject();
        this.searchValue = '';
        this.isShowNotFound = false;
        // open
        this.open$ = this.openRaw$.pipe(distinctUntilChanged(), share(), tap((/**
         * @return {?}
         */
        function () { return _this.clearInput(); })));
        this.activatedOption$ = new ReplaySubject(1);
        this.listOfSelectedValue$ = this.listOfSelectedValueWithEmit$.pipe(map((/**
         * @param {?} data
         * @return {?}
         */
        function (data) { return data.value; })));
        this.modelChange$ = this.listOfSelectedValueWithEmit$.pipe(filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return item.emit; })), map((/**
         * @param {?} data
         * @return {?}
         */
        function (data) {
            /** @type {?} */
            var selectedList = data.value;
            /** @type {?} */
            var modelValue = null;
            if (_this.isSingleMode) {
                if (selectedList.length) {
                    modelValue = selectedList[0];
                }
            }
            else {
                modelValue = selectedList;
            }
            return modelValue;
        })));
        this.searchValue$ = this.searchValueRaw$.pipe(distinctUntilChanged(), skip(1), share(), tap((/**
         * @param {?} value
         * @return {?}
         */
        function (value) {
            _this.searchValue = value;
            if (value) {
                _this.updateActivatedOption(_this.listOfFilteredOption[0]);
            }
            _this.updateListOfFilteredOption();
        })));
        // tslint:disable-next-line:no-any
        this.listOfSelectedValue = [];
        // flat ViewChildren
        this.listOfTemplateOption = [];
        // tag option
        this.listOfTagOption = [];
        // tag option concat template option
        this.listOfTagAndTemplateOption = [];
        // ViewChildren
        this.listOfNzOptionComponent = [];
        this.listOfNzOptionGroupComponent = [];
        // display in top control
        this.listOfCachedSelectedOption = [];
        // selected value or ViewChildren change
        this.valueOrOption$ = combineLatest(this.listOfSelectedValue$, this.mapOfTemplateOption$).pipe(tap((/**
         * @param {?} data
         * @return {?}
         */
        function (data) {
            _this.listOfSelectedValue = data[0];
            _this.listOfNzOptionComponent = data[1].listOfNzOptionComponent;
            _this.listOfNzOptionGroupComponent = data[1].listOfNzOptionGroupComponent;
            _this.listOfTemplateOption = _this.listOfNzOptionComponent.concat(_this.listOfNzOptionGroupComponent.reduce((/**
             * @param {?} pre
             * @param {?} cur
             * @return {?}
             */
            function (pre, cur) { return tslib_1.__spread(pre, cur.listOfNzOptionComponent.toArray()); }), (/** @type {?} */ ([]))));
            _this.updateListOfTagOption();
            _this.updateListOfFilteredOption();
            _this.resetActivatedOptionIfNeeded();
            _this.updateListOfCachedOption();
        })), share());
        this.check$ = merge(this.checkRaw$, this.valueOrOption$, this.searchValue$, this.activatedOption$, this.open$, this.modelChange$).pipe(share());
    }
    /**
     * @param {?} option
     * @return {?}
     */
    NzSelectService.prototype.clickOption = /**
     * @param {?} option
     * @return {?}
     */
    function (option) {
        var _this = this;
        /** update listOfSelectedOption -> update listOfSelectedValue -> next listOfSelectedValue$ **/
        if (!option.nzDisabled) {
            this.updateActivatedOption(option);
            /** @type {?} */
            var listOfSelectedValue = tslib_1.__spread(this.listOfSelectedValue);
            if (this.isMultipleOrTags) {
                /** @type {?} */
                var targetValue = listOfSelectedValue.find((/**
                 * @param {?} o
                 * @return {?}
                 */
                function (o) { return _this.compareWith(o, option.nzValue); }));
                if (isNotNil(targetValue)) {
                    listOfSelectedValue.splice(listOfSelectedValue.indexOf(targetValue), 1);
                    this.updateListOfSelectedValue(listOfSelectedValue, true);
                }
                else if (listOfSelectedValue.length < this.maxMultipleCount) {
                    listOfSelectedValue.push(option.nzValue);
                    this.updateListOfSelectedValue(listOfSelectedValue, true);
                }
            }
            else if (!this.compareWith(listOfSelectedValue[0], option.nzValue)) {
                listOfSelectedValue = [option.nzValue];
                this.updateListOfSelectedValue(listOfSelectedValue, true);
            }
            if (this.isSingleMode) {
                this.setOpenState(false);
            }
            else if (this.autoClearSearchValue) {
                this.clearInput();
            }
        }
    };
    /**
     * @return {?}
     */
    NzSelectService.prototype.updateListOfCachedOption = /**
     * @return {?}
     */
    function () {
        var _this = this;
        if (this.isSingleMode) {
            /** @type {?} */
            var selectedOption = this.listOfTemplateOption.find((/**
             * @param {?} o
             * @return {?}
             */
            function (o) {
                return _this.compareWith(o.nzValue, _this.listOfSelectedValue[0]);
            }));
            if (!isNil(selectedOption)) {
                this.listOfCachedSelectedOption = [selectedOption];
            }
        }
        else {
            /** @type {?} */
            var listOfCachedSelectedOption_1 = [];
            this.listOfSelectedValue.forEach((/**
             * @param {?} v
             * @return {?}
             */
            function (v) {
                /** @type {?} */
                var listOfMixedOption = tslib_1.__spread(_this.listOfTagAndTemplateOption, _this.listOfCachedSelectedOption);
                /** @type {?} */
                var option = listOfMixedOption.find((/**
                 * @param {?} o
                 * @return {?}
                 */
                function (o) { return _this.compareWith(o.nzValue, v); }));
                if (option) {
                    listOfCachedSelectedOption_1.push(option);
                }
            }));
            this.listOfCachedSelectedOption = listOfCachedSelectedOption_1;
        }
    };
    /**
     * @return {?}
     */
    NzSelectService.prototype.updateListOfTagOption = /**
     * @return {?}
     */
    function () {
        var _this = this;
        if (this.isTagsMode) {
            /** @type {?} */
            var listOfMissValue = this.listOfSelectedValue.filter((/**
             * @param {?} value
             * @return {?}
             */
            function (value) { return !_this.listOfTemplateOption.find((/**
             * @param {?} o
             * @return {?}
             */
            function (o) { return _this.compareWith(o.nzValue, value); })); }));
            this.listOfTagOption = listOfMissValue.map((/**
             * @param {?} value
             * @return {?}
             */
            function (value) {
                /** @type {?} */
                var nzOptionComponent = new NzOptionComponent();
                nzOptionComponent.nzValue = value;
                nzOptionComponent.nzLabel = value;
                return nzOptionComponent;
            }));
            this.listOfTagAndTemplateOption = tslib_1.__spread(this.listOfTemplateOption.concat(this.listOfTagOption));
        }
        else {
            this.listOfTagAndTemplateOption = tslib_1.__spread(this.listOfTemplateOption);
        }
    };
    /**
     * @return {?}
     */
    NzSelectService.prototype.updateAddTagOption = /**
     * @return {?}
     */
    function () {
        var _this = this;
        /** @type {?} */
        var isMatch = this.listOfTagAndTemplateOption.find((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return item.nzLabel === _this.searchValue; }));
        if (this.isTagsMode && this.searchValue && !isMatch) {
            /** @type {?} */
            var option = new NzOptionComponent();
            option.nzValue = this.searchValue;
            option.nzLabel = this.searchValue;
            this.addedTagOption = option;
            this.updateActivatedOption(option);
        }
        else {
            this.addedTagOption = null;
        }
    };
    /**
     * @return {?}
     */
    NzSelectService.prototype.updateListOfFilteredOption = /**
     * @return {?}
     */
    function () {
        this.updateAddTagOption();
        /** @type {?} */
        var listOfFilteredOption = new NzFilterOptionPipe().transform(this.listOfTagAndTemplateOption, this.searchValue, this.filterOption, this.serverSearch);
        this.listOfFilteredOption = this.addedTagOption
            ? tslib_1.__spread([this.addedTagOption], listOfFilteredOption) : tslib_1.__spread(listOfFilteredOption);
        this.isShowNotFound = !this.isTagsMode && !this.listOfFilteredOption.length;
    };
    /**
     * @return {?}
     */
    NzSelectService.prototype.clearInput = /**
     * @return {?}
     */
    function () {
        this.clearInput$.next();
    };
    // tslint:disable-next-line:no-any
    // tslint:disable-next-line:no-any
    /**
     * @param {?} value
     * @param {?} emit
     * @return {?}
     */
    NzSelectService.prototype.updateListOfSelectedValue = 
    // tslint:disable-next-line:no-any
    /**
     * @param {?} value
     * @param {?} emit
     * @return {?}
     */
    function (value, emit) {
        this.listOfSelectedValueWithEmit$.next({ value: value, emit: emit });
    };
    /**
     * @param {?} option
     * @return {?}
     */
    NzSelectService.prototype.updateActivatedOption = /**
     * @param {?} option
     * @return {?}
     */
    function (option) {
        this.activatedOption$.next(option);
        this.activatedOption = option;
    };
    /**
     * @param {?} inputValue
     * @param {?} tokenSeparators
     * @return {?}
     */
    NzSelectService.prototype.tokenSeparate = /**
     * @param {?} inputValue
     * @param {?} tokenSeparators
     * @return {?}
     */
    function (inputValue, tokenSeparators) {
        // auto tokenSeparators
        if (inputValue &&
            inputValue.length &&
            tokenSeparators.length &&
            this.isMultipleOrTags &&
            this.includesSeparators(inputValue, tokenSeparators)) {
            /** @type {?} */
            var listOfLabel = this.splitBySeparators(inputValue, tokenSeparators);
            this.updateSelectedValueByLabelList(listOfLabel);
            this.clearInput();
        }
    };
    /**
     * @param {?} str
     * @param {?} separators
     * @return {?}
     */
    NzSelectService.prototype.includesSeparators = /**
     * @param {?} str
     * @param {?} separators
     * @return {?}
     */
    function (str, separators) {
        // tslint:disable-next-line:prefer-for-of
        for (var i = 0; i < separators.length; ++i) {
            if (str.lastIndexOf(separators[i]) > 0) {
                return true;
            }
        }
        return false;
    };
    /**
     * @param {?} str
     * @param {?} separators
     * @return {?}
     */
    NzSelectService.prototype.splitBySeparators = /**
     * @param {?} str
     * @param {?} separators
     * @return {?}
     */
    function (str, separators) {
        /** @type {?} */
        var reg = new RegExp("[" + separators.join() + "]");
        /** @type {?} */
        var array = ((/** @type {?} */ (str))).split(reg).filter((/**
         * @param {?} token
         * @return {?}
         */
        function (token) { return token; }));
        return Array.from(new Set(array));
    };
    /**
     * @return {?}
     */
    NzSelectService.prototype.resetActivatedOptionIfNeeded = /**
     * @return {?}
     */
    function () {
        var _this = this;
        /** @type {?} */
        var resetActivatedOption = (/**
         * @return {?}
         */
        function () {
            /** @type {?} */
            var activatedOption = _this.listOfFilteredOption.find((/**
             * @param {?} item
             * @return {?}
             */
            function (item) {
                return _this.compareWith(item.nzValue, _this.listOfSelectedValue[0]);
            }));
            _this.updateActivatedOption(activatedOption || null);
        });
        if (this.activatedOption) {
            if (!this.listOfFilteredOption.find((/**
             * @param {?} item
             * @return {?}
             */
            function (item) { return _this.compareWith(item.nzValue, (/** @type {?} */ (_this.activatedOption)).nzValue); })) ||
                !this.listOfSelectedValue.find((/**
                 * @param {?} item
                 * @return {?}
                 */
                function (item) { return _this.compareWith(item, (/** @type {?} */ (_this.activatedOption)).nzValue); }))) {
                resetActivatedOption();
            }
        }
        else {
            resetActivatedOption();
        }
    };
    /**
     * @param {?} listOfNzOptionComponent
     * @param {?} listOfNzOptionGroupComponent
     * @return {?}
     */
    NzSelectService.prototype.updateTemplateOption = /**
     * @param {?} listOfNzOptionComponent
     * @param {?} listOfNzOptionGroupComponent
     * @return {?}
     */
    function (listOfNzOptionComponent, listOfNzOptionGroupComponent) {
        this.mapOfTemplateOption$.next({ listOfNzOptionComponent: listOfNzOptionComponent, listOfNzOptionGroupComponent: listOfNzOptionGroupComponent });
    };
    /**
     * @param {?} value
     * @return {?}
     */
    NzSelectService.prototype.updateSearchValue = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        this.searchValueRaw$.next(value);
    };
    /**
     * @param {?} listOfLabel
     * @return {?}
     */
    NzSelectService.prototype.updateSelectedValueByLabelList = /**
     * @param {?} listOfLabel
     * @return {?}
     */
    function (listOfLabel) {
        var _this = this;
        /** @type {?} */
        var listOfSelectedValue = tslib_1.__spread(this.listOfSelectedValue);
        /** @type {?} */
        var listOfMatchOptionValue = this.listOfTagAndTemplateOption
            .filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return listOfLabel.indexOf(item.nzLabel) !== -1; }))
            .map((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return item.nzValue; }))
            .filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return !isNotNil(_this.listOfSelectedValue.find((/**
         * @param {?} v
         * @return {?}
         */
        function (v) { return _this.compareWith(v, item); }))); }));
        if (this.isMultipleMode) {
            this.updateListOfSelectedValue(tslib_1.__spread(listOfSelectedValue, listOfMatchOptionValue), true);
        }
        else {
            /** @type {?} */
            var listOfUnMatchOptionValue = listOfLabel.filter((/**
             * @param {?} label
             * @return {?}
             */
            function (label) { return _this.listOfTagAndTemplateOption.map((/**
             * @param {?} item
             * @return {?}
             */
            function (item) { return item.nzLabel; })).indexOf(label) === -1; }));
            this.updateListOfSelectedValue(tslib_1.__spread(listOfSelectedValue, listOfMatchOptionValue, listOfUnMatchOptionValue), true);
        }
    };
    /**
     * @param {?} e
     * @return {?}
     */
    NzSelectService.prototype.onKeyDown = /**
     * @param {?} e
     * @return {?}
     */
    function (e) {
        var _this = this;
        /** @type {?} */
        var keyCode = e.keyCode;
        /** @type {?} */
        var eventTarget = (/** @type {?} */ (e.target));
        /** @type {?} */
        var listOfFilteredOptionWithoutDisabled = this.listOfFilteredOption.filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return !item.nzDisabled; }));
        /** @type {?} */
        var activatedIndex = listOfFilteredOptionWithoutDisabled.findIndex((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return item === _this.activatedOption; }));
        switch (keyCode) {
            case UP_ARROW:
                e.preventDefault();
                /** @type {?} */
                var preIndex = activatedIndex > 0 ? activatedIndex - 1 : listOfFilteredOptionWithoutDisabled.length - 1;
                this.updateActivatedOption(listOfFilteredOptionWithoutDisabled[preIndex]);
                break;
            case DOWN_ARROW:
                e.preventDefault();
                /** @type {?} */
                var nextIndex = activatedIndex < listOfFilteredOptionWithoutDisabled.length - 1 ? activatedIndex + 1 : 0;
                this.updateActivatedOption(listOfFilteredOptionWithoutDisabled[nextIndex]);
                if (!this.disabled && !this.open) {
                    this.setOpenState(true);
                }
                break;
            case ENTER:
                e.preventDefault();
                if (this.open) {
                    if (this.activatedOption && !this.activatedOption.nzDisabled) {
                        this.clickOption(this.activatedOption);
                    }
                }
                else {
                    this.setOpenState(true);
                }
                break;
            case BACKSPACE:
                if (this.isMultipleOrTags && !eventTarget.value && this.listOfCachedSelectedOption.length) {
                    e.preventDefault();
                    this.removeValueFormSelected(this.listOfCachedSelectedOption[this.listOfCachedSelectedOption.length - 1]);
                }
                break;
            case SPACE:
                if (!this.disabled && !this.open) {
                    this.setOpenState(true);
                    e.preventDefault();
                }
                break;
            case TAB:
                this.setOpenState(false);
                break;
        }
    };
    // tslint:disable-next-line:no-any
    // tslint:disable-next-line:no-any
    /**
     * @param {?} option
     * @return {?}
     */
    NzSelectService.prototype.removeValueFormSelected = 
    // tslint:disable-next-line:no-any
    /**
     * @param {?} option
     * @return {?}
     */
    function (option) {
        var _this = this;
        if (this.disabled || option.nzDisabled) {
            return;
        }
        /** @type {?} */
        var listOfSelectedValue = this.listOfSelectedValue.filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return !_this.compareWith(item, option.nzValue); }));
        this.updateListOfSelectedValue(listOfSelectedValue, true);
        this.clearInput();
    };
    /**
     * @param {?} value
     * @return {?}
     */
    NzSelectService.prototype.setOpenState = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        this.openRaw$.next(value);
        this.open = value;
    };
    /**
     * @return {?}
     */
    NzSelectService.prototype.check = /**
     * @return {?}
     */
    function () {
        this.checkRaw$.next();
    };
    Object.defineProperty(NzSelectService.prototype, "isSingleMode", {
        get: /**
         * @return {?}
         */
        function () {
            return this.mode === 'default';
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzSelectService.prototype, "isTagsMode", {
        get: /**
         * @return {?}
         */
        function () {
            return this.mode === 'tags';
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzSelectService.prototype, "isMultipleMode", {
        get: /**
         * @return {?}
         */
        function () {
            return this.mode === 'multiple';
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzSelectService.prototype, "isMultipleOrTags", {
        get: /**
         * @return {?}
         */
        function () {
            return this.mode === 'tags' || this.mode === 'multiple';
        },
        enumerable: true,
        configurable: true
    });
    NzSelectService.decorators = [
        { type: Injectable }
    ];
    return NzSelectService;
}());
export { NzSelectService };
if (false) {
    /** @type {?} */
    NzSelectService.prototype.autoClearSearchValue;
    /** @type {?} */
    NzSelectService.prototype.serverSearch;
    /** @type {?} */
    NzSelectService.prototype.filterOption;
    /** @type {?} */
    NzSelectService.prototype.mode;
    /** @type {?} */
    NzSelectService.prototype.maxMultipleCount;
    /** @type {?} */
    NzSelectService.prototype.disabled;
    /** @type {?} */
    NzSelectService.prototype.compareWith;
    /**
     * @type {?}
     * @private
     */
    NzSelectService.prototype.listOfSelectedValueWithEmit$;
    /**
     * @type {?}
     * @private
     */
    NzSelectService.prototype.mapOfTemplateOption$;
    /**
     * @type {?}
     * @private
     */
    NzSelectService.prototype.searchValueRaw$;
    /**
     * @type {?}
     * @private
     */
    NzSelectService.prototype.listOfFilteredOption;
    /**
     * @type {?}
     * @private
     */
    NzSelectService.prototype.openRaw$;
    /**
     * @type {?}
     * @private
     */
    NzSelectService.prototype.checkRaw$;
    /**
     * @type {?}
     * @private
     */
    NzSelectService.prototype.open;
    /** @type {?} */
    NzSelectService.prototype.clearInput$;
    /** @type {?} */
    NzSelectService.prototype.searchValue;
    /** @type {?} */
    NzSelectService.prototype.isShowNotFound;
    /** @type {?} */
    NzSelectService.prototype.open$;
    /** @type {?} */
    NzSelectService.prototype.activatedOption;
    /** @type {?} */
    NzSelectService.prototype.activatedOption$;
    /** @type {?} */
    NzSelectService.prototype.listOfSelectedValue$;
    /** @type {?} */
    NzSelectService.prototype.modelChange$;
    /** @type {?} */
    NzSelectService.prototype.searchValue$;
    /** @type {?} */
    NzSelectService.prototype.listOfSelectedValue;
    /** @type {?} */
    NzSelectService.prototype.listOfTemplateOption;
    /** @type {?} */
    NzSelectService.prototype.listOfTagOption;
    /** @type {?} */
    NzSelectService.prototype.listOfTagAndTemplateOption;
    /** @type {?} */
    NzSelectService.prototype.listOfNzOptionComponent;
    /** @type {?} */
    NzSelectService.prototype.listOfNzOptionGroupComponent;
    /** @type {?} */
    NzSelectService.prototype.addedTagOption;
    /** @type {?} */
    NzSelectService.prototype.listOfCachedSelectedOption;
    /** @type {?} */
    NzSelectService.prototype.valueOrOption$;
    /** @type {?} */
    NzSelectService.prototype.check$;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotc2VsZWN0LnNlcnZpY2UuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9uZy16b3Jyby1hbnRkL3NlbGVjdC8iLCJzb3VyY2VzIjpbIm56LXNlbGVjdC5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7OztBQVFBLE9BQU8sRUFBRSxTQUFTLEVBQUUsVUFBVSxFQUFFLEtBQUssRUFBRSxLQUFLLEVBQUUsR0FBRyxFQUFFLFFBQVEsRUFBRSxNQUFNLHVCQUF1QixDQUFDO0FBQzNGLE9BQU8sRUFBRSxVQUFVLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFDM0MsT0FBTyxFQUFFLGFBQWEsRUFBRSxLQUFLLEVBQUUsZUFBZSxFQUFFLGFBQWEsRUFBRSxPQUFPLEVBQUUsTUFBTSxNQUFNLENBQUM7QUFDckYsT0FBTyxFQUFFLG9CQUFvQixFQUFFLE1BQU0sRUFBRSxHQUFHLEVBQUUsS0FBSyxFQUFFLElBQUksRUFBRSxHQUFHLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUVyRixPQUFPLEVBQUUsS0FBSyxFQUFFLFFBQVEsRUFBRSxNQUFNLG9CQUFvQixDQUFDO0FBR3JELE9BQU8sRUFBRSxpQkFBaUIsRUFBRSxNQUFNLHVCQUF1QixDQUFDO0FBQzFELE9BQU8sRUFBRSxtQkFBbUIsRUFBRSxrQkFBa0IsRUFBaUIsTUFBTSxrQkFBa0IsQ0FBQztBQUUxRjtJQUFBO1FBQUEsaUJBMlhDOztRQXhYQyx5QkFBb0IsR0FBRyxJQUFJLENBQUM7UUFDNUIsaUJBQVksR0FBRyxLQUFLLENBQUM7UUFDckIsaUJBQVksR0FBa0IsbUJBQW1CLENBQUM7UUFDbEQsU0FBSSxHQUFvQyxTQUFTLENBQUM7UUFDbEQscUJBQWdCLEdBQUcsUUFBUSxDQUFDO1FBQzVCLGFBQVEsR0FBRyxLQUFLLENBQUM7O1FBRWpCLGdCQUFXOzs7OztRQUFHLFVBQUMsRUFBTyxFQUFFLEVBQU8sSUFBSyxPQUFBLEVBQUUsS0FBSyxFQUFFLEVBQVQsQ0FBUyxFQUFDOzs7UUFHdEMs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RUQsc0JBQUksNkNBQWdCOzs7O1FBQXBCO1lBQ0UsT0FBTyxJQUFJLENBQUMsSUFBSSxLQUFLLE1BQU0sSUFBSSxJQUFJLENBQUMsSUFBSSxLQUFLLFVBQVUsQ0FBQztRQUMxRCxDQUFDOzs7T0FBQTs7Z0JBMVhGLFVBQVU7O0lBMlhYLHNCQUFDO0NBQUEsQUEzWEQsSUEyWEM7U0ExWFksZUFBZTs7O0lBRTFCLCtDQUE0Qjs7SUFDNUIsdUNBQXFCOztJQUNyQix1Q0FBa0Q7O0lBQ2xELCtCQUFrRDs7SUFDbEQsMkNBQTRCOztJQUM1QixtQ0FBaUI7O0lBRWpCLHNDQUE4Qzs7Ozs7SUFHOUMsdURBR0c7Ozs7O0lBRUgsK0NBTUc7Ozs7O0lBRUgsMENBQTBEOzs7OztJQUMxRCwrQ0FBdUQ7Ozs7O0lBQ3ZELG1DQUEwQzs7Ozs7SUFDMUMsb0NBQWtDOzs7OztJQUNsQywrQkFBcUI7O0lBQ3JCLHNDQUFxQzs7SUFDckMsc0NBQWlCOztJQUNqQix5Q0FBdUI7O0lBRXZCLGdDQUlFOztJQUNGLDBDQUEwQzs7SUFDMUMsMkNBQWtFOztJQUNsRSwrQ0FBdUY7O0lBQ3ZGLHVDQWNFOztJQUNGLHVDQVdFOztJQUVGLDhDQUFnQzs7SUFFaEMsK0NBQStDOztJQUUvQywwQ0FBMEM7O0lBRTFDLHFEQUFxRDs7SUFFckQsa0RBQWtEOztJQUNsRCx1REFBNEQ7O0lBRTVELHlDQUF5Qzs7SUFFekMscURBQXFEOztJQUVyRCx5Q0FpQkU7O0lBQ0YsaUNBT2dCIiwic291cmNlc0NvbnRlbnQiOlsiLyoqXG4gKiBAbGljZW5zZVxuICogQ29weXJpZ2h0IEFsaWJhYmEuY29tIEFsbCBSaWdodHMgUmVzZXJ2ZWQuXG4gKlxuICogVXNlIG9mIHRoaXMgc291cmNlIGNvZGUgaXMgZ292ZXJuZWQgYnkgYW4gTUlULXN0eWxlIGxpY2Vuc2UgdGhhdCBjYW4gYmVcbiAqIGZvdW5kIGluIHRoZSBMSUNFTlNFIGZpbGUgYXQgaHR0cHM6Ly9naXRodWIuY29tL05HLVpPUlJPL25nLXpvcnJvLWFudGQvYmxvYi9tYXN0ZXIvTElDRU5TRVxuICovXG5cbmltcG9ydCB7IEJBQ0tTUEFDRSwgRE9XTl9BUlJPVywgRU5URVIsIFNQQUNFLCBUQUIsIFVQX0FSUk9XIH0gZnJvbSAnQGFuZ3VsYXIvY2RrL2tleWNvZGVzJztcbmltcG9ydCB7IEluamVjdGFibGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IGNvbWJpbmVMYXRlc3QsIG1lcmdlLCBCZWhhdmlvclN1YmplY3QsIFJlcGxheVN1YmplY3QsIFN1YmplY3QgfSBmcm9tICdyeGpzJztcbmltcG9ydCB7IGRpc3RpbmN0VW50aWxDaGFuZ2VkLCBmaWx0ZXIsIG1hcCwgc2hhcmUsIHNraXAsIHRhcCB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuaW1wb3J0IHsgaXNOaWwsIGlzTm90TmlsIH0gZnJvbSAnbmctem9ycm8tYW50ZC9jb3JlJztcblxuaW1wb3J0IHsgTnpPcHRpb25Hcm91cENvbXBvbmVudCB9IGZyb20gJy4vbnotb3B0aW9uLWdyb3VwLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBOek9wdGlvbkNvbXBvbmVudCB9IGZyb20gJy4vbnotb3B0aW9uLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBkZWZhdWx0RmlsdGVyT3B0aW9uLCBOekZpbHRlck9wdGlvblBpcGUsIFRGaWx0ZXJPcHRpb24gfSBmcm9tICcuL256LW9wdGlvbi5waXBlJztcblxuQEluamVjdGFibGUoKVxuZXhwb3J0IGNsYXNzIE56U2VsZWN0U2VydmljZSB7XG4gIC8vIElucHV0IHBhcmFtc1xuICBhdXRvQ2xlYXJTZWFyY2hWYWx1ZSA9IHRydWU7XG4gIHNlcnZlclNlYXJjaCA9IGZhbHNlO1xuICBmaWx0ZXJPcHRpb246IFRGaWx0ZXJPcHRpb24gPSBkZWZhdWx0RmlsdGVyT3B0aW9uO1xuICBtb2RlOiAnZGVmYXVsdCcgfCAnbXVsdGlwbGUnIHwgJ3RhZ3MnID0gJ2RlZmF1bHQnO1xuICBtYXhNdWx0aXBsZUNvdW50ID0gSW5maW5pdHk7XG4gIGRpc2FibGVkID0gZmFsc2U7XG4gIC8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpuby1hbnlcbiAgY29tcGFyZVdpdGggPSAobzE6IGFueSwgbzI6IGFueSkgPT4gbzEgPT09IG8yO1xuICAvLyBzZWxlY3RlZFZhbHVlQ2hhbmdlZCBzaG91bGQgZW1pdCBuZ01vZGVsQ2hhbmdlIG9yIG5vdFxuICAvLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6bm8tYW55XG4gIHByaXZhdGUgbGlzdE9mU2VsZWN0ZWRWYWx1ZVdpdGhFbWl0JCA9IG5ldyBCZWhhdmlvclN1YmplY3Q8eyB2YWx1ZTogYW55W107IGVtaXQ6IGJvb2xlYW4gfT4oe1xuICAgIHZhbHVlOiBbXSxcbiAgICBlbWl0OiBmYWxzZVxuICB9KTtcbiAgLy8gQ29udGVudENoaWxkcmVuIENoYW5nZVxuICBwcml2YXRlIG1hcE9mVGVtcGxhdGVPcHRpb24kID0gbmV3IEJlaGF2aW9yU3ViamVjdDx7XG4gICAgbGlzdE9mTnpPcHRpb25Db21wb25lbnQ6IE56T3B0aW9uQ29tcG9uZW50W107XG4gICAgbGlzdE9mTnpPcHRpb25Hcm91cENvbXBvbmVudDogTnpPcHRpb25Hcm91cENvbXBvbmVudFtdO1xuICB9Pih7XG4gICAgbGlzdE9mTnpPcHRpb25Db21wb25lbnQ6IFtdLFxuICAgIGxpc3RPZk56T3B0aW9uR3JvdXBDb21wb25lbnQ6IFtdXG4gIH0pO1xuICAvLyBzZWFyY2hWYWx1ZSBDaGFuZ2VcbiAgcHJpdmF0ZSBzZWFyY2hWYWx1ZVJhdyQgPSBuZXcgQmVoYXZpb3JTdWJqZWN0PHN0cmluZz4oJycpO1xuICBwcml2YXRlIGxpc3RPZkZpbHRlcmVkT3B0aW9uOiBOek9wdGlvbkNvbXBvbmVudFtdID0gW107XG4gIHByaXZhdGUgb3BlblJhdyQgPSBuZXcgU3ViamVjdDxib29sZWFuPigpO1xuICBwcml2YXRlIGNoZWNrUmF3JCA9IG5ldyBTdWJqZWN0KCk7XG4gIHByaXZhdGUgb3BlbiA9IGZhbHNlO1xuICBjbGVhcklucHV0JCA9IG5ldyBTdWJqZWN0PGJvb2xlYW4+KCk7XG4gIHNlYXJjaFZhbHVlID0gJyc7XG4gIGlzU2hvd05vdEZvdW5kID0gZmFsc2U7XG4gIC8vIG9wZW5cbiAgb3BlbiQgPSB0aGlzLm9wZW5SYXckLnBpcGUoXG4gICAgZGlzdGluY3RVbnRpbENoYW5nZWQoKSxcbiAgICBzaGFyZSgpLFxuICAgIHRhcCgoKSA9PiB0aGlzLmNsZWFySW5wdXQoKSlcbiAgKTtcbiAgYWN0aXZhdGVkT3B0aW9uOiBOek9wdGlvbkNvbXBvbmVudCB8IG51bGw7XG4gIGFjdGl2YXRlZE9wdGlvbiQgPSBuZXcgUmVwbGF5U3ViamVjdDxOek9wdGlvbkNvbXBvbmVudCB8IG51bGw+KDEpO1xuICBsaXN0T2ZTZWxlY3RlZFZhbHVlJCA9IHRoaXMubGlzdE9mU2VsZWN0ZWRWYWx1ZVdpdGhFbWl0JC5waXBlKG1hcChkYXRhID0+IGRhdGEudmFsdWUpKTtcbiAgbW9kZWxDaGFuZ2UkID0gdGhpcy5saXN0T2ZTZWxlY3RlZFZhbHVlV2l0aEVtaXQkLnBpcGUoXG4gICAgZmlsdGVyKGl0ZW0gPT4gaXRlbS5lbWl0KSxcbiAgICBtYXAoZGF0YSA9PiB7XG4gICAgICBjb25zdCBzZWxlY3RlZExpc3QgPSBkYXRhLnZhbHVlO1xuICAgICAgbGV0IG1vZGVsVmFsdWU6IGFueVtdIHwgbnVsbCA9IG51bGw7IC8vIHRzbGludDpkaXNhYmxlLWxpbmU6bm8tYW55XG4gICAgICBpZiAodGhpcy5pc1NpbmdsZU1vZGUpIHtcbiAgICAgICAgaWYgKHNlbGVjdGVkTGlzdC5sZW5ndGgpIHtcbiAgICAgICAgICBtb2RlbFZhbHVlID0gc2VsZWN0ZWRMaXN0WzBdO1xuICAgICAgICB9XG4gICAgICB9IGVsc2Uge1xuICAgICAgICBtb2RlbFZhbHVlID0gc2VsZWN0ZWRMaXN0O1xuICAgICAgfVxuICAgICAgcmV0dXJuIG1vZGVsVmFsdWU7XG4gICAgfSlcbiAgKTtcbiAgc2VhcmNoVmFsdWUkID0gdGhpcy5zZWFyY2hWYWx1ZVJhdyQucGlwZShcbiAgICBkaXN0aW5jdFVudGlsQ2hhbmdlZCgpLFxuICAgIHNraXAoMSksXG4gICAgc2hhcmUoKSxcbiAgICB0YXAodmFsdWUgPT4ge1xuICAgICAgdGhpcy5zZWFyY2hWYWx1ZSA9IHZhbHVlO1xuICAgICAgaWYgKHZhbHVlKSB7XG4gICAgICAgIHRoaXMudXBkYXRlQWN0aXZhdGVkT3B0aW9uKHRoaXMubGlzdE9mRmlsdGVyZWRPcHRpb25bMF0pO1xuICAgICAgfVxuICAgICAgdGhpcy51cGRhdGVMaXN0T2ZGaWx0ZXJlZE9wdGlvbigpO1xuICAgIH0pXG4gICk7XG4gIC8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpuby1hbnlcbiAgbGlzdE9mU2VsZWN0ZWRWYWx1ZTogYW55W10gPSBbXTtcbiAgLy8gZmxhdCBWaWV3Q2hpbGRyZW5cbiAgbGlzdE9mVGVtcGxhdGVPcHRpb246IE56T3B0aW9uQ29tcG9uZW50W10gPSBbXTtcbiAgLy8gdGFnIG9wdGlvblxuICBsaXN0T2ZUYWdPcHRpb246IE56T3B0aW9uQ29tcG9uZW50W10gPSBbXTtcbiAgLy8gdGFnIG9wdGlvbiBjb25jYXQgdGVtcGxhdGUgb3B0aW9uXG4gIGxpc3RPZlRhZ0FuZFRlbXBsYXRlT3B0aW9uOiBOek9wdGlvbkNvbXBvbmVudFtdID0gW107XG4gIC8vIFZpZXdDaGlsZHJlblxuICBsaXN0T2ZOek9wdGlvbkNvbXBvbmVudDogTnpPcHRpb25Db21wb25lbnRbXSA9IFtdO1xuICBsaXN0T2ZOek9wdGlvbkdyb3VwQ29tcG9uZW50OiBOek9wdGlvbkdyb3VwQ29tcG9uZW50W10gPSBbXTtcbiAgLy8gY2xpY2sgb3IgZW50ZXIgYWRkIHRhZyBvcHRpb25cbiAgYWRkZWRUYWdPcHRpb246IE56T3B0aW9uQ29tcG9uZW50IHwgbnVsbDtcbiAgLy8gZGlzcGxheSBpbiB0b3AgY29udHJvbFxuICBsaXN0T2ZDYWNoZWRTZWxlY3RlZE9wdGlvbjogTnpPcHRpb25Db21wb25lbnRbXSA9IFtdO1xuICAvLyBzZWxlY3RlZCB2YWx1ZSBvciBWaWV3Q2hpbGRyZW4gY2hhbmdlXG4gIHZhbHVlT3JPcHRpb24kID0gY29tYmluZUxhdGVzdCh0aGlzLmxpc3RPZlNlbGVjdGVkVmFsdWUkLCB0aGlzLm1hcE9mVGVtcGxhdGVPcHRpb24kKS5waXBlKFxuICAgIHRhcChkYXRhID0+IHtcbiAgICAgIHRoaXMubGlzdE9mU2VsZWN0ZWRWYWx1ZSA9IGRhdGFbMF07XG4gICAgICB0aGlzLmxpc3RPZk56T3B0aW9uQ29tcG9uZW50ID0gZGF0YVsxXS5saXN0T2ZOek9wdGlvbkNvbXBvbmVudDtcbiAgICAgIHRoaXMubGlzdE9mTnpPcHRpb25Hcm91cENvbXBvbmVudCA9IGRhdGFbMV0ubGlzdE9mTnpPcHRpb25Hcm91cENvbXBvbmVudDtcbiAgICAgIHRoaXMubGlzdE9mVGVtcGxhdGVPcHRpb24gPSB0aGlzLmxpc3RPZk56T3B0aW9uQ29tcG9uZW50LmNvbmNhdChcbiAgICAgICAgdGhpcy5saXN0T2ZOek9wdGlvbkdyb3VwQ29tcG9uZW50LnJlZHVjZShcbiAgICAgICAgICAocHJlLCBjdXIpID0+IFsuLi5wcmUsIC4uLmN1ci5saXN0T2ZOek9wdGlvbkNvbXBvbmVudC50b0FycmF5KCldLFxuICAgICAgICAgIFtdIGFzIE56T3B0aW9uQ29tcG9uZW50W11cbiAgICAgICAgKVxuICAgICAgKTtcbiAgICAgIHRoaXMudXBkYXRlTGlzdE9mVGFnT3B0aW9uKCk7XG4gICAgICB0aGlzLnVwZGF0ZUxpc3RPZkZpbHRlcmVkT3B0aW9uKCk7XG4gICAgICB0aGlzLnJlc2V0QWN0aXZhdGVkT3B0aW9uSWZOZWVkZWQoKTtcbiAgICAgIHRoaXMudXBkYXRlTGlzdE9mQ2FjaGVkT3B0aW9uKCk7XG4gICAgfSksXG4gICAgc2hhcmUoKVxuICApO1xuICBjaGVjayQgPSBtZXJnZShcbiAgICB0aGlzLmNoZWNrUmF3JCxcbiAgICB0aGlzLnZhbHVlT3JPcHRpb24kLFxuICAgIHRoaXMuc2VhcmNoVmFsdWUkLFxuICAgIHRoaXMuYWN0aXZhdGVkT3B0aW9uJCxcbiAgICB0aGlzLm9wZW4kLFxuICAgIHRoaXMubW9kZWxDaGFuZ2UkXG4gICkucGlwZShzaGFyZSgpKTtcblxuICBjbGlja09wdGlvbihvcHRpb246IE56T3B0aW9uQ29tcG9uZW50KTogdm9pZCB7XG4gICAgLyoqIHVwZGF0ZSBsaXN0T2ZTZWxlY3RlZE9wdGlvbiAtPiB1cGRhdGUgbGlzdE9mU2VsZWN0ZWRWYWx1ZSAtPiBuZXh0IGxpc3RPZlNlbGVjdGVkVmFsdWUkICoqL1xuICAgIGlmICghb3B0aW9uLm56RGlzYWJsZWQpIHtcbiAgICAgIHRoaXMudXBkYXRlQWN0aXZhdGVkT3B0aW9uKG9wdGlvbik7XG4gICAgICBsZXQgbGlzdE9mU2VsZWN0ZWRWYWx1ZSA9IFsuLi50aGlzLmxpc3RPZlNlbGVjdGVkVmFsdWVdO1xuICAgICAgaWYgKHRoaXMuaXNNdWx0aXBsZU9yVGFncykge1xuICAgICAgICBjb25zdCB0YXJnZXRWYWx1ZSA9IGxpc3RPZlNlbGVjdGVkVmFsdWUuZmluZChvID0+IHRoaXMuY29tcGFyZVdpdGgobywgb3B0aW9uLm56VmFsdWUpKTtcbiAgICAgICAgaWYgKGlzTm90TmlsKHRhcmdldFZhbHVlKSkge1xuICAgICAgICAgIGxpc3RPZlNlbGVjdGVkVmFsdWUuc3BsaWNlKGxpc3RPZlNlbGVjdGVkVmFsdWUuaW5kZXhPZih0YXJnZXRWYWx1ZSksIDEpO1xuICAgICAgICAgIHRoaXMudXBkYXRlTGlzdE9mU2VsZWN0ZWRWYWx1ZShsaXN0T2ZTZWxlY3RlZFZhbHVlLCB0cnVlKTtcbiAgICAgICAgfSBlbHNlIGlmIChsaXN0T2ZTZWxlY3RlZFZhbHVlLmxlbmd0aCA8IHRoaXMubWF4TXVsdGlwbGVDb3VudCkge1xuICAgICAgICAgIGxpc3RPZlNlbGVjdGVkVmFsdWUucHVzaChvcHRpb24ubnpWYWx1ZSk7XG4gICAgICAgICAgdGhpcy51cGRhdGVMaXN0T2ZTZWxlY3RlZFZhbHVlKGxpc3RPZlNlbGVjdGVkVmFsdWUsIHRydWUpO1xuICAgICAgICB9XG4gICAgICB9IGVsc2UgaWYgKCF0aGlzLmNvbXBhcmVXaXRoKGxpc3RPZlNlbGVjdGVkVmFsdWVbMF0sIG9wdGlvbi5uelZhbHVlKSkge1xuICAgICAgICBsaXN0T2ZTZWxlY3RlZFZhbHVlID0gW29wdGlvbi5uelZhbHVlXTtcbiAgICAgICAgdGhpcy51cGRhdGVMaXN0T2ZTZWxlY3RlZFZhbHVlKGxpc3RPZlNlbGVjdGVkVmFsdWUsIHRydWUpO1xuICAgICAgfVxuICAgICAgaWYgKHRoaXMuaXNTaW5nbGVNb2RlKSB7XG4gICAgICAgIHRoaXMuc2V0T3BlblN0YXRlKGZhbHNlKTtcbiAgICAgIH0gZWxzZSBpZiAodGhpcy5hdXRvQ2xlYXJTZWFyY2hWYWx1ZSkge1xuICAgICAgICB0aGlzLmNsZWFySW5wdXQoKTtcbiAgICAgIH1cbiAgICB9XG4gIH1cblxuICB1cGRhdGVMaXN0T2ZDYWNoZWRPcHRpb24oKTogdm9pZCB7XG4gICAgaWYgKHRoaXMuaXNTaW5nbGVNb2RlKSB7XG4gICAgICBjb25zdCBzZWxlY3RlZE9wdGlvbiA9IHRoaXMubGlzdE9mVGVtcGxhdGVPcHRpb24uZmluZChvID0+XG4gICAgICAgIHRoaXMuY29tcGFyZVdpdGgoby5uelZhbHVlLCB0aGlzLmxpc3RPZlNlbGVjdGVkVmFsdWVbMF0pXG4gICAgICApO1xuICAgICAgaWYgKCFpc05pbChzZWxlY3RlZE9wdGlvbikpIHtcbiAgICAgICAgdGhpcy5saXN0T2ZDYWNoZWRTZWxlY3RlZE9wdGlvbiA9IFtzZWxlY3RlZE9wdGlvbl07XG4gICAgICB9XG4gICAgfSBlbHNlIHtcbiAgICAgIGNvbnN0IGxpc3RPZkNhY2hlZFNlbGVjdGVkT3B0aW9uOiBOek9wdGlvbkNvbXBvbmVudFtdID0gW107XG4gICAgICB0aGlzLmxpc3RPZlNlbGVjdGVkVmFsdWUuZm9yRWFjaCh2ID0+IHtcbiAgICAgICAgY29uc3QgbGlzdE9mTWl4ZWRPcHRpb24gPSBbLi4udGhpcy5saXN0T2ZUYWdBbmRUZW1wbGF0ZU9wdGlvbiwgLi4udGhpcy5saXN0T2ZDYWNoZWRTZWxlY3RlZE9wdGlvbl07XG4gICAgICAgIGNvbnN0IG9wdGlvbiA9IGxpc3RPZk1peGVkT3B0aW9uLmZpbmQobyA9PiB0aGlzLmNvbXBhcmVXaXRoKG8ubnpWYWx1ZSwgdikpO1xuICAgICAgICBpZiAob3B0aW9uKSB7XG4gICAgICAgICAgbGlzdE9mQ2FjaGVkU2VsZWN0ZWRPcHRpb24ucHVzaChvcHRpb24pO1xuICAgICAgICB9XG4gICAgICB9KTtcbiAgICAgIHRoaXMubGlzdE9mQ2FjaGVkU2VsZWN0ZWRPcHRpb24gPSBsaXN0T2ZDYWNoZWRTZWxlY3RlZE9wdGlvbjtcbiAgICB9XG4gIH1cblxuICB1cGRhdGVMaXN0T2ZUYWdPcHRpb24oKTogdm9pZCB7XG4gICAgaWYgKHRoaXMuaXNUYWdzTW9kZSkge1xuICAgICAgY29uc3QgbGlzdE9mTWlzc1ZhbHVlID0gdGhpcy5saXN0T2ZTZWxlY3RlZFZhbHVlLmZpbHRlcihcbiAgICAgICAgdmFsdWUgPT4gIXRoaXMubGlzdE9mVGVtcGxhdGVPcHRpb24uZmluZChvID0+IHRoaXMuY29tcGFyZVdpdGgoby5uelZhbHVlLCB2YWx1ZSkpXG4gICAgICApO1xuICAgICAgdGhpcy5saXN0T2ZUYWdPcHRpb24gPSBsaXN0T2ZNaXNzVmFsdWUubWFwKHZhbHVlID0+IHtcbiAgICAgICAgY29uc3QgbnpPcHRpb25Db21wb25lbnQgPSBuZXcgTnpPcHRpb25Db21wb25lbnQoKTtcbiAgICAgICAgbnpPcHRpb25Db21wb25lbnQubnpWYWx1ZSA9IHZhbHVlO1xuICAgICAgICBuek9wdGlvbkNvbXBvbmVudC5uekxhYmVsID0gdmFsdWU7XG4gICAgICAgIHJldHVybiBuek9wdGlvbkNvbXBvbmVudDtcbiAgICAgIH0pO1xuICAgICAgdGhpcy5saXN0T2ZUYWdBbmRUZW1wbGF0ZU9wdGlvbiA9IFsuLi50aGlzLmxpc3RPZlRlbXBsYXRlT3B0aW9uLmNvbmNhdCh0aGlzLmxpc3RPZlRhZ09wdGlvbildO1xuICAgIH0gZWxzZSB7XG4gICAgICB0aGlzLmxpc3RPZlRhZ0FuZFRlbXBsYXRlT3B0aW9uID0gWy4uLnRoaXMubGlzdE9mVGVtcGxhdGVPcHRpb25dO1xuICAgIH1cbiAgfVxuXG4gIHVwZGF0ZUFkZFRhZ09wdGlvbigpOiB2b2lkIHtcbiAgICBjb25zdCBpc01hdGNoID0gdGhpcy5saXN0T2ZUYWdBbmRUZW1wbGF0ZU9wdGlvbi5maW5kKGl0ZW0gPT4gaXRlbS5uekxhYmVsID09PSB0aGlzLnNlYXJjaFZhbHVlKTtcbiAgICBpZiAodGhpcy5pc1RhZ3NNb2RlICYmIHRoaXMuc2VhcmNoVmFsdWUgJiYgIWlzTWF0Y2gpIHtcbiAgICAgIGNvbnN0IG9wdGlvbiA9IG5ldyBOek9wdGlvbkNvbXBvbmVudCgpO1xuICAgICAgb3B0aW9uLm56VmFsdWUgPSB0aGlzLnNlYXJjaFZhbHVlO1xuICAgICAgb3B0aW9uLm56TGFiZWwgPSB0aGlzLnNlYXJjaFZhbHVlO1xuICAgICAgdGhpcy5hZGRlZFRhZ09wdGlvbiA9IG9wdGlvbjtcbiAgICAgIHRoaXMudXBkYXRlQWN0aXZhdGVkT3B0aW9uKG9wdGlvbik7XG4gICAgfSBlbHNlIHtcbiAgICAgIHRoaXMuYWRkZWRUYWdPcHRpb24gPSBudWxsO1xuICAgIH1cbiAgfVxuXG4gIHVwZGF0ZUxpc3RPZkZpbHRlcmVkT3B0aW9uKCk6IHZvaWQge1xuICAgIHRoaXMudXBkYXRlQWRkVGFnT3B0aW9uKCk7XG4gICAgY29uc3QgbGlzdE9mRmlsdGVyZWRPcHRpb24gPSBuZXcgTnpGaWx0ZXJPcHRpb25QaXBlKCkudHJhbnNmb3JtKFxuICAgICAgdGhpcy5saXN0T2ZUYWdBbmRUZW1wbGF0ZU9wdGlvbixcbiAgICAgIHRoaXMuc2VhcmNoVmFsdWUsXG4gICAgICB0aGlzLmZpbHRlck9wdGlvbixcbiAgICAgIHRoaXMuc2VydmVyU2VhcmNoXG4gICAgKTtcbiAgICB0aGlzLmxpc3RPZkZpbHRlcmVkT3B0aW9uID0gdGhpcy5hZGRlZFRhZ09wdGlvblxuICAgICAgPyBbdGhpcy5hZGRlZFRhZ09wdGlvbiwgLi4ubGlzdE9mRmlsdGVyZWRPcHRpb25dXG4gICAgICA6IFsuLi5saXN0T2ZGaWx0ZXJlZE9wdGlvbl07XG4gICAgdGhpcy5pc1Nob3dOb3RGb3VuZCA9ICF0aGlzLmlzVGFnc01vZGUgJiYgIXRoaXMubGlzdE9mRmlsdGVyZWRPcHRpb24ubGVuZ3RoO1xuICB9XG5cbiAgY2xlYXJJbnB1dCgpOiB2b2lkIHtcbiAgICB0aGlzLmNsZWFySW5wdXQkLm5leHQoKTtcbiAgfVxuXG4gIC8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpuby1hbnlcbiAgdXBkYXRlTGlzdE9mU2VsZWN0ZWRWYWx1ZSh2YWx1ZTogYW55W10sIGVtaXQ6IGJvb2xlYW4pOiB2b2lkIHtcbiAgICB0aGlzLmxpc3RPZlNlbGVjdGVkVmFsdWVXaXRoRW1pdCQubmV4dCh7IHZhbHVlLCBlbWl0IH0pO1xuICB9XG5cbiAgdXBkYXRlQWN0aXZhdGVkT3B0aW9uKG9wdGlvbjogTnpPcHRpb25Db21wb25lbnQgfCBudWxsKTogdm9pZCB7XG4gICAgdGhpcy5hY3RpdmF0ZWRPcHRpb24kLm5leHQob3B0aW9uKTtcbiAgICB0aGlzLmFjdGl2YXRlZE9wdGlvbiA9IG9wdGlvbjtcbiAgfVxuXG4gIHRva2VuU2VwYXJhdGUoaW5wdXRWYWx1ZTogc3RyaW5nLCB0b2tlblNlcGFyYXRvcnM6IHN0cmluZ1tdKTogdm9pZCB7XG4gICAgLy8gYXV0byB0b2tlblNlcGFyYXRvcnNcbiAgICBpZiAoXG4gICAgICBpbnB1dFZhbHVlICYmXG4gICAgICBpbnB1dFZhbHVlLmxlbmd0aCAmJlxuICAgICAgdG9rZW5TZXBhcmF0b3JzLmxlbmd0aCAmJlxuICAgICAgdGhpcy5pc011bHRpcGxlT3JUYWdzICYmXG4gICAgICB0aGlzLmluY2x1ZGVzU2VwYXJhdG9ycyhpbnB1dFZhbHVlLCB0b2tlblNlcGFyYXRvcnMpXG4gICAgKSB7XG4gICAgICBjb25zdCBsaXN0T2ZMYWJlbCA9IHRoaXMuc3BsaXRCeVNlcGFyYXRvcnMoaW5wdXRWYWx1ZSwgdG9rZW5TZXBhcmF0b3JzKTtcbiAgICAgIHRoaXMudXBkYXRlU2VsZWN0ZWRWYWx1ZUJ5TGFiZWxMaXN0KGxpc3RPZkxhYmVsKTtcbiAgICAgIHRoaXMuY2xlYXJJbnB1dCgpO1xuICAgIH1cbiAgfVxuXG4gIGluY2x1ZGVzU2VwYXJhdG9ycyhzdHI6IHN0cmluZyB8IHN0cmluZ1tdLCBzZXBhcmF0b3JzOiBzdHJpbmdbXSk6IGJvb2xlYW4ge1xuICAgIC8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpwcmVmZXItZm9yLW9mXG4gICAgZm9yIChsZXQgaSA9IDA7IGkgPCBzZXBhcmF0b3JzLmxlbmd0aDsgKytpKSB7XG4gICAgICBpZiAoc3RyLmxhc3RJbmRleE9mKHNlcGFyYXRvcnNbaV0pID4gMCkge1xuICAgICAgICByZXR1cm4gdHJ1ZTtcbiAgICAgIH1cbiAgICB9XG4gICAgcmV0dXJuIGZhbHNlO1xuICB9XG5cbiAgc3BsaXRCeVNlcGFyYXRvcnMoc3RyOiBzdHJpbmcgfCBzdHJpbmdbXSwgc2VwYXJhdG9yczogc3RyaW5nW10pOiBzdHJpbmdbXSB7XG4gICAgY29uc3QgcmVnID0gbmV3IFJlZ0V4cChgWyR7c2VwYXJhdG9ycy5qb2luKCl9XWApO1xuICAgIGNvbnN0IGFycmF5ID0gKHN0ciBhcyBzdHJpbmcpLnNwbGl0KHJlZykuZmlsdGVyKHRva2VuID0+IHRva2VuKTtcbiAgICByZXR1cm4gQXJyYXkuZnJvbShuZXcgU2V0KGFycmF5KSk7XG4gIH1cblxuICByZXNldEFjdGl2YXRlZE9wdGlvbklmTmVlZGVkKCk6IHZvaWQge1xuICAgIGNvbnN0IHJlc2V0QWN0aXZhdGVkT3B0aW9uID0gKCkgPT4ge1xuICAgICAgY29uc3QgYWN0aXZhdGVkT3B0aW9uID0gdGhpcy5saXN0T2ZGaWx0ZXJlZE9wdGlvbi5maW5kKGl0ZW0gPT5cbiAgICAgICAgdGhpcy5jb21wYXJlV2l0aChpdGVtLm56VmFsdWUsIHRoaXMubGlzdE9mU2VsZWN0ZWRWYWx1ZVswXSlcbiAgICAgICk7XG4gICAgICB0aGlzLnVwZGF0ZUFjdGl2YXRlZE9wdGlvbihhY3RpdmF0ZWRPcHRpb24gfHwgbnVsbCk7XG4gICAgfTtcbiAgICBpZiAodGhpcy5hY3RpdmF0ZWRPcHRpb24pIHtcbiAgICAgIGlmIChcbiAgICAgICAgIXRoaXMubGlzdE9mRmlsdGVyZWRPcHRpb24uZmluZChpdGVtID0+IHRoaXMuY29tcGFyZVdpdGgoaXRlbS5uelZhbHVlLCB0aGlzLmFjdGl2YXRlZE9wdGlvbiEubnpWYWx1ZSkpIHx8XG4gICAgICAgICF0aGlzLmxpc3RPZlNlbGVjdGVkVmFsdWUuZmluZChpdGVtID0+IHRoaXMuY29tcGFyZVdpdGgoaXRlbSwgdGhpcy5hY3RpdmF0ZWRPcHRpb24hLm56VmFsdWUpKVxuICAgICAgKSB7XG4gICAgICAgIHJlc2V0QWN0aXZhdGVkT3B0aW9uKCk7XG4gICAgICB9XG4gICAgfSBlbHNlIHtcbiAgICAgIHJlc2V0QWN0aXZhdGVkT3B0aW9uKCk7XG4gICAgfVxuICB9XG5cbiAgdXBkYXRlVGVtcGxhdGVPcHRpb24oXG4gICAgbGlzdE9mTnpPcHRpb25Db21wb25lbnQ6IE56T3B0aW9uQ29tcG9uZW50W10sXG4gICAgbGlzdE9mTnpPcHRpb25Hcm91cENvbXBvbmVudDogTnpPcHRpb25Hcm91cENvbXBvbmVudFtdXG4gICk6IHZvaWQge1xuICAgIHRoaXMubWFwT2ZUZW1wbGF0ZU9wdGlvbiQubmV4dCh7IGxpc3RPZk56T3B0aW9uQ29tcG9uZW50LCBsaXN0T2ZOek9wdGlvbkdyb3VwQ29tcG9uZW50IH0pO1xuICB9XG5cbiAgdXBkYXRlU2VhcmNoVmFsdWUodmFsdWU6IHN0cmluZyk6IHZvaWQge1xuICAgIHRoaXMuc2VhcmNoVmFsdWVSYXckLm5leHQodmFsdWUpO1xuICB9XG5cbiAgdXBkYXRlU2VsZWN0ZWRWYWx1ZUJ5TGFiZWxMaXN0KGxpc3RPZkxhYmVsOiBzdHJpbmdbXSk6IHZvaWQge1xuICAgIGNvbnN0IGxpc3RPZlNlbGVjdGVkVmFsdWUgPSBbLi4udGhpcy5saXN0T2ZTZWxlY3RlZFZhbHVlXTtcbiAgICBjb25zdCBsaXN0T2ZNYXRjaE9wdGlvblZhbHVlID0gdGhpcy5saXN0T2ZUYWdBbmRUZW1wbGF0ZU9wdGlvblxuICAgICAgLmZpbHRlcihpdGVtID0+IGxpc3RPZkxhYmVsLmluZGV4T2YoaXRlbS5uekxhYmVsKSAhPT0gLTEpXG4gICAgICAubWFwKGl0ZW0gPT4gaXRlbS5uelZhbHVlKVxuICAgICAgLmZpbHRlcihpdGVtID0+ICFpc05vdE5pbCh0aGlzLmxpc3RPZlNlbGVjdGVkVmFsdWUuZmluZCh2ID0+IHRoaXMuY29tcGFyZVdpdGgodiwgaXRlbSkpKSk7XG4gICAgaWYgKHRoaXMuaXNNdWx0aXBsZU1vZGUpIHtcbiAgICAgIHRoaXMudXBkYXRlTGlzdE9mU2VsZWN0ZWRWYWx1ZShbLi4ubGlzdE9mU2VsZWN0ZWRWYWx1ZSwgLi4ubGlzdE9mTWF0Y2hPcHRpb25WYWx1ZV0sIHRydWUpO1xuICAgIH0gZWxzZSB7XG4gICAgICBjb25zdCBsaXN0T2ZVbk1hdGNoT3B0aW9uVmFsdWUgPSBsaXN0T2ZMYWJlbC5maWx0ZXIoXG4gICAgICAgIGxhYmVsID0+IHRoaXMubGlzdE9mVGFnQW5kVGVtcGxhdGVPcHRpb24ubWFwKGl0ZW0gPT4gaXRlbS5uekxhYmVsKS5pbmRleE9mKGxhYmVsKSA9PT0gLTFcbiAgICAgICk7XG4gICAgICB0aGlzLnVwZGF0ZUxpc3RPZlNlbGVjdGVkVmFsdWUoXG4gICAgICAgIFsuLi5saXN0T2ZTZWxlY3RlZFZhbHVlLCAuLi5saXN0T2ZNYXRjaE9wdGlvblZhbHVlLCAuLi5saXN0T2ZVbk1hdGNoT3B0aW9uVmFsdWVdLFxuICAgICAgICB0cnVlXG4gICAgICApO1xuICAgIH1cbiAgfVxuXG4gIG9uS2V5RG93bihlOiBLZXlib2FyZEV2ZW50KTogdm9pZCB7XG4gICAgY29uc3Qga2V5Q29kZSA9IGUua2V5Q29kZTtcbiAgICBjb25zdCBldmVudFRhcmdldCA9IGUudGFyZ2V0IGFzIEhUTUxJbnB1dEVsZW1lbnQ7XG4gICAgY29uc3QgbGlzdE9mRmlsdGVyZWRPcHRpb25XaXRob3V0RGlzYWJsZWQgPSB0aGlzLmxpc3RPZkZpbHRlcmVkT3B0aW9uLmZpbHRlcihpdGVtID0+ICFpdGVtLm56RGlzYWJsZWQpO1xuICAgIGNvbnN0IGFjdGl2YXRlZEluZGV4ID0gbGlzdE9mRmlsdGVyZWRPcHRpb25XaXRob3V0RGlzYWJsZWQuZmluZEluZGV4KGl0ZW0gPT4gaXRlbSA9PT0gdGhpcy5hY3RpdmF0ZWRPcHRpb24pO1xuICAgIHN3aXRjaCAoa2V5Q29kZSkge1xuICAgICAgY2FzZSBVUF9BUlJPVzpcbiAgICAgICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xuICAgICAgICBjb25zdCBwcmVJbmRleCA9IGFjdGl2YXRlZEluZGV4ID4gMCA/IGFjdGl2YXRlZEluZGV4IC0gMSA6IGxpc3RPZkZpbHRlcmVkT3B0aW9uV2l0aG91dERpc2FibGVkLmxlbmd0aCAtIDE7XG4gICAgICAgIHRoaXMudXBkYXRlQWN0aXZhdGVkT3B0aW9uKGxpc3RPZkZpbHRlcmVkT3B0aW9uV2l0aG91dERpc2FibGVkW3ByZUluZGV4XSk7XG4gICAgICAgIGJyZWFrO1xuICAgICAgY2FzZSBET1dOX0FSUk9XOlxuICAgICAgICBlLnByZXZlbnREZWZhdWx0KCk7XG4gICAgICAgIGNvbnN0IG5leHRJbmRleCA9IGFjdGl2YXRlZEluZGV4IDwgbGlzdE9mRmlsdGVyZWRPcHRpb25XaXRob3V0RGlzYWJsZWQubGVuZ3RoIC0gMSA/IGFjdGl2YXRlZEluZGV4ICsgMSA6IDA7XG4gICAgICAgIHRoaXMudXBkYXRlQWN0aXZhdGVkT3B0aW9uKGxpc3RPZkZpbHRlcmVkT3B0aW9uV2l0aG91dERpc2FibGVkW25leHRJbmRleF0pO1xuICAgICAgICBpZiAoIXRoaXMuZGlzYWJsZWQgJiYgIXRoaXMub3Blbikge1xuICAgICAgICAgIHRoaXMuc2V0T3BlblN0YXRlKHRydWUpO1xuICAgICAgICB9XG4gICAgICAgIGJyZWFrO1xuICAgICAgY2FzZSBFTlRFUjpcbiAgICAgICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xuICAgICAgICBpZiAodGhpcy5vcGVuKSB7XG4gICAgICAgICAgaWYgKHRoaXMuYWN0aXZhdGVkT3B0aW9uICYmICF0aGlzLmFjdGl2YXRlZE9wdGlvbi5uekRpc2FibGVkKSB7XG4gICAgICAgICAgICB0aGlzLmNsaWNrT3B0aW9uKHRoaXMuYWN0aXZhdGVkT3B0aW9uKTtcbiAgICAgICAgICB9XG4gICAgICAgIH0gZWxzZSB7XG4gICAgICAgICAgdGhpcy5zZXRPcGVuU3RhdGUodHJ1ZSk7XG4gICAgICAgIH1cbiAgICAgICAgYnJlYWs7XG4gICAgICBjYXNlIEJBQ0tTUEFDRTpcbiAgICAgICAgaWYgKHRoaXMuaXNNdWx0aXBsZU9yVGFncyAmJiAhZXZlbnRUYXJnZXQudmFsdWUgJiYgdGhpcy5saXN0T2ZDYWNoZWRTZWxlY3RlZE9wdGlvbi5sZW5ndGgpIHtcbiAgICAgICAgICBlLnByZXZlbnREZWZhdWx0KCk7XG4gICAgICAgICAgdGhpcy5yZW1vdmVWYWx1ZUZvcm1TZWxlY3RlZCh0aGlzLmxpc3RPZkNhY2hlZFNlbGVjdGVkT3B0aW9uW3RoaXMubGlzdE9mQ2FjaGVkU2VsZWN0ZWRPcHRpb24ubGVuZ3RoIC0gMV0pO1xuICAgICAgICB9XG4gICAgICAgIGJyZWFrO1xuICAgICAgY2FzZSBTUEFDRTpcbiAgICAgICAgaWYgKCF0aGlzLmRpc2FibGVkICYmICF0aGlzLm9wZW4pIHtcbiAgICAgICAgICB0aGlzLnNldE9wZW5TdGF0ZSh0cnVlKTtcbiAgICAgICAgICBlLnByZXZlbnREZWZhdWx0KCk7XG4gICAgICAgIH1cbiAgICAgICAgYnJlYWs7XG4gICAgICBjYXNlIFRBQjpcbiAgICAgICAgdGhpcy5zZXRPcGVuU3RhdGUoZmFsc2UpO1xuICAgICAgICBicmVhaztcbiAgICB9XG4gIH1cblxuICAvLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6bm8tYW55XG4gIHJlbW92ZVZhbHVlRm9ybVNlbGVjdGVkKG9wdGlvbjogTnpPcHRpb25Db21wb25lbnQpOiB2b2lkIHtcbiAgICBpZiAodGhpcy5kaXNhYmxlZCB8fCBvcHRpb24ubnpEaXNhYmxlZCkge1xuICAgICAgcmV0dXJuO1xuICAgIH1cbiAgICBjb25zdCBsaXN0T2ZTZWxlY3RlZFZhbHVlID0gdGhpcy5saXN0T2ZTZWxlY3RlZFZhbHVlLmZpbHRlcihpdGVtID0+ICF0aGlzLmNvbXBhcmVXaXRoKGl0ZW0sIG9wdGlvbi5uelZhbHVlKSk7XG4gICAgdGhpcy51cGRhdGVMaXN0T2ZTZWxlY3RlZFZhbHVlKGxpc3RPZlNlbGVjdGVkVmFsdWUsIHRydWUpO1xuICAgIHRoaXMuY2xlYXJJbnB1dCgpO1xuICB9XG5cbiAgc2V0T3BlblN0YXRlKHZhbHVlOiBib29sZWFuKTogdm9pZCB7XG4gICAgdGhpcy5vcGVuUmF3JC5uZXh0KHZhbHVlKTtcbiAgICB0aGlzLm9wZW4gPSB2YWx1ZTtcbiAgfVxuXG4gIGNoZWNrKCk6IHZvaWQge1xuICAgIHRoaXMuY2hlY2tSYXckLm5leHQoKTtcbiAgfVxuXG4gIGdldCBpc1NpbmdsZU1vZGUoKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHRoaXMubW9kZSA9PT0gJ2RlZmF1bHQnO1xuICB9XG5cbiAgZ2V0IGlzVGFnc01vZGUoKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHRoaXMubW9kZSA9PT0gJ3RhZ3MnO1xuICB9XG5cbiAgZ2V0IGlzTXVsdGlwbGVNb2RlKCk6IGJvb2xlYW4ge1xuICAgIHJldHVybiB0aGlzLm1vZGUgPT09ICdtdWx0aXBsZSc7XG4gIH1cblxuICBnZXQgaXNNdWx0aXBsZU9yVGFncygpOiBib29sZWFuIHtcbiAgICByZXR1cm4gdGhpcy5tb2RlID09PSAndGFncycgfHwgdGhpcy5tb2RlID09PSAnbXVsdGlwbGUnO1xuICB9XG59XG4iXX0=