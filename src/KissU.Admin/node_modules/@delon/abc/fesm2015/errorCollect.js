import { __decorate, __metadata } from 'tslib';
import { DOCUMENT, CommonModule } from '@angular/common';
import { Injectable, defineInjectable, NgModule, Component, ChangeDetectionStrategy, ElementRef, ChangeDetectorRef, Inject, Input } from '@angular/core';
import { InputNumber, DelonUtilModule } from '@delon/util';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class ErrorCollectConfig {
    constructor() {
        /**
         * 监听频率
         */
        this.freq = 500;
        /**
         * 顶部偏移值
         */
        this.offsetTop = 65 + 64 + 8 * 2;
    }
}
ErrorCollectConfig.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */ ErrorCollectConfig.ngInjectableDef = defineInjectable({ factory: function ErrorCollectConfig_Factory() { return new ErrorCollectConfig(); }, token: ErrorCollectConfig, providedIn: "root" });

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class ErrorCollectComponent {
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
__decorate([
    InputNumber(),
    __metadata("design:type", Number)
], ErrorCollectComponent.prototype, "freq", void 0);
__decorate([
    InputNumber(),
    __metadata("design:type", Number)
], ErrorCollectComponent.prototype, "offsetTop", void 0);

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
const COMPONENTS = [ErrorCollectComponent];
class ErrorCollectModule {
}
ErrorCollectModule.decorators = [
    { type: NgModule, args: [{
                imports: [CommonModule, DelonUtilModule],
                declarations: [...COMPONENTS],
                exports: [...COMPONENTS],
            },] }
];

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