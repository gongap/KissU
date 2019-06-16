import { __spread, __assign, __decorate, __metadata } from 'tslib';
import { DOCUMENT, CommonModule } from '@angular/common';
import { Injectable, defineInjectable, NgModule, Component, ChangeDetectionStrategy, ElementRef, ChangeDetectorRef, Inject, Input } from '@angular/core';
import { InputNumber, DelonUtilModule } from '@delon/util';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var ErrorCollectConfig = /** @class */ (function () {
    function ErrorCollectConfig() {
        /**
         * 监听频率
         */
        this.freq = 500;
        /**
         * 顶部偏移值
         */
        this.offsetTop = 65 + 64 + 8 * 2;
    }
    ErrorCollectConfig.decorators = [
        { type: Injectable, args: [{ providedIn: 'root' },] }
    ];
    /** @nocollapse */ ErrorCollectConfig.ngInjectableDef = defineInjectable({ factory: function ErrorCollectConfig_Factory() { return new ErrorCollectConfig(); }, token: ErrorCollectConfig, providedIn: "root" });
    return ErrorCollectConfig;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var ErrorCollectComponent = /** @class */ (function () {
    function ErrorCollectComponent(cog, el, cdr, doc) {
        this.el = el;
        this.cdr = cdr;
        this.doc = doc;
        this.$time = null;
        this._hiden = true;
        this.count = 0;
        Object.assign(this, __assign({}, new ErrorCollectConfig(), cog));
    }
    Object.defineProperty(ErrorCollectComponent.prototype, "errEls", {
        get: /**
         * @private
         * @return {?}
         */
        function () {
            return this.formEl.querySelectorAll('.has-error');
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @private
     * @return {?}
     */
    ErrorCollectComponent.prototype.update = /**
     * @private
     * @return {?}
     */
    function () {
        /** @type {?} */
        var count = this.errEls.length;
        if (count === this.count)
            return;
        this.count = count;
        this._hiden = count === 0;
        this.cdr.markForCheck();
    };
    /**
     * @return {?}
     */
    ErrorCollectComponent.prototype._click = /**
     * @return {?}
     */
    function () {
        if (this.count === 0)
            return false;
        // nz-form-control
        /** @type {?} */
        var els = this.errEls;
        /** @type {?} */
        var formItemEl = this.findParent(els[0], '[nz-form-control]') || els[0];
        formItemEl.scrollIntoView(true);
        // fix header height
        this.doc.documentElement.scrollTop -= this.offsetTop;
    };
    /**
     * @private
     * @return {?}
     */
    ErrorCollectComponent.prototype.install = /**
     * @private
     * @return {?}
     */
    function () {
        var _this = this;
        this.uninstall();
        this.$time = setInterval((/**
         * @return {?}
         */
        function () { return _this.update(); }), this.freq);
        this.update();
    };
    /**
     * @private
     * @return {?}
     */
    ErrorCollectComponent.prototype.uninstall = /**
     * @private
     * @return {?}
     */
    function () {
        clearInterval(this.$time);
    };
    /**
     * @private
     * @param {?} el
     * @param {?} selector
     * @return {?}
     */
    ErrorCollectComponent.prototype.findParent = /**
     * @private
     * @param {?} el
     * @param {?} selector
     * @return {?}
     */
    function (el, selector) {
        /** @type {?} */
        var retEl = null;
        while (el) {
            if (el.querySelector(selector)) {
                retEl = el;
                break;
            }
            el = el.parentElement;
        }
        return retEl;
    };
    /**
     * @return {?}
     */
    ErrorCollectComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        this.formEl = this.findParent(this.el.nativeElement, 'form');
        if (this.formEl === null)
            throw new Error('No found form element');
        this.install();
    };
    /**
     * @return {?}
     */
    ErrorCollectComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.uninstall();
    };
    ErrorCollectComponent.decorators = [
        { type: Component, args: [{
                    selector: 'error-collect, [error-collect]',
                    template: "\n    <i nz-icon type=\"exclamation-circle\"></i>\n    <span class=\"pl-sm\">{{ count }}</span>\n  ",
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
    ErrorCollectComponent.ctorParameters = function () { return [
        { type: ErrorCollectConfig },
        { type: ElementRef },
        { type: ChangeDetectorRef },
        { type: undefined, decorators: [{ type: Inject, args: [DOCUMENT,] }] }
    ]; };
    ErrorCollectComponent.propDecorators = {
        freq: [{ type: Input }],
        offsetTop: [{ type: Input }]
    };
    __decorate([
        InputNumber(),
        __metadata("design:type", Number)
    ], ErrorCollectComponent.prototype, "freq", void 0);
    __decorate([
        InputNumber(),
        __metadata("design:type", Number)
    ], ErrorCollectComponent.prototype, "offsetTop", void 0);
    return ErrorCollectComponent;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
var COMPONENTS = [ErrorCollectComponent];
var ErrorCollectModule = /** @class */ (function () {
    function ErrorCollectModule() {
    }
    ErrorCollectModule.decorators = [
        { type: NgModule, args: [{
                    imports: [CommonModule, DelonUtilModule],
                    declarations: __spread(COMPONENTS),
                    exports: __spread(COMPONENTS),
                },] }
    ];
    return ErrorCollectModule;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

export { ErrorCollectComponent, ErrorCollectConfig, ErrorCollectModule };

//# sourceMappingURL=errorCollect.js.map