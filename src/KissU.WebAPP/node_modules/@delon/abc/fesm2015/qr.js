import { __decorate, __metadata } from 'tslib';
import { CommonModule } from '@angular/common';
import { Injectable, defineInjectable, inject, EventEmitter, Component, ChangeDetectionStrategy, ChangeDetectorRef, Input, Output, NgModule } from '@angular/core';
import { InputNumber, DelonUtilModule } from '@delon/util';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class QRConfig {
    constructor() {
        /**
         * 背景，默认：`white`
         */
        this.background = 'white';
        /**
         * 背景透明级别，范围：`0-1` 之间，默认：`1.0`
         */
        this.backgroundAlpha = 1;
        /**
         * 前景，默认：`black`
         */
        this.foreground = 'black';
        /**
         * 前景透明级别，范围：`0-1` 之间，默认：`1.0`
         */
        this.foregroundAlpha = 1;
        /**
         * 误差校正级别，默认：`L`
         */
        this.level = 'L';
        /**
         * 二维码输出图片MIME类型，默认：`image/png`
         */
        this.mime = 'image/png';
        /**
         * 内边距（单位：px），默认：`10`
         */
        this.padding = 10;
        /**
         * 大小（单位：px），默认：`220`
         */
        this.size = 220;
    }
}
QRConfig.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */ QRConfig.ngInjectableDef = defineInjectable({ factory: function QRConfig_Factory() { return new QRConfig(); }, token: QRConfig, providedIn: "root" });

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class QRService {
    /**
     * @param {?} cog
     */
    constructor(cog) {
        /**
         * 背景透明级别，范围：`0-1` 之间
         */
        this.backgroundAlpha = 1;
        Object.assign(this, cog);
        this.qr = new QRious();
    }
    /**
     * 生成二维码，并返回Base64编码
     *
     * @param {?=} value
     * @return {?}
     */
    refresh(value) {
        this.qr.set(typeof value === 'object'
            ? value
            : {
                background: this.background,
                backgroundAlpha: this.backgroundAlpha,
                foreground: this.foreground,
                foregroundAlpha: this.foregroundAlpha,
                level: this.level,
                padding: this.padding,
                size: this.size,
                value: value || this.value,
            });
        return this.dataURL;
    }
    /**
     * 返回当前二维码Base64编码
     * @return {?}
     */
    get dataURL() {
        return this.qr.toDataURL();
    }
}
QRService.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */
QRService.ctorParameters = () => [
    { type: QRConfig }
];
/** @nocollapse */ QRService.ngInjectableDef = defineInjectable({ factory: function QRService_Factory() { return new QRService(inject(QRConfig)); }, token: QRService, providedIn: "root" });

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class QRComponent {
    // #endregion
    /**
     * @param {?} cog
     * @param {?} srv
     * @param {?} cdr
     */
    constructor(cog, srv, cdr) {
        this.srv = srv;
        this.cdr = cdr;
        this.change = new EventEmitter();
        Object.assign(this, Object.assign({}, new QRConfig(), cog));
    }
    /**
     * @return {?}
     */
    ngOnChanges() {
        this.dataURL = this.srv.refresh({
            background: this.background,
            backgroundAlpha: this.backgroundAlpha,
            foreground: this.foreground,
            foregroundAlpha: this.foregroundAlpha,
            level: this.level,
            mime: this.mime,
            padding: this.padding,
            size: this.size,
            value: this.value,
        });
        this.cdr.detectChanges();
        this.change.emit(this.dataURL);
    }
}
QRComponent.decorators = [
    { type: Component, args: [{
                selector: 'qr',
                template: `
    <img class="qr__img" src="{{ dataURL }}" />
  `,
                host: {
                    '[class.qr]': 'true',
                    '[style.height.px]': 'size',
                    '[style.width.px]': 'size',
                },
                changeDetection: ChangeDetectionStrategy.OnPush
            }] }
];
/** @nocollapse */
QRComponent.ctorParameters = () => [
    { type: QRConfig },
    { type: QRService },
    { type: ChangeDetectorRef }
];
QRComponent.propDecorators = {
    background: [{ type: Input }],
    backgroundAlpha: [{ type: Input }],
    foreground: [{ type: Input }],
    foregroundAlpha: [{ type: Input }],
    level: [{ type: Input }],
    mime: [{ type: Input }],
    padding: [{ type: Input }],
    size: [{ type: Input }],
    value: [{ type: Input }],
    change: [{ type: Output }]
};
__decorate([
    InputNumber(),
    __metadata("design:type", Number)
], QRComponent.prototype, "padding", void 0);
__decorate([
    InputNumber(),
    __metadata("design:type", Number)
], QRComponent.prototype, "size", void 0);

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
const COMPONENTS = [QRComponent];
class QRModule {
}
QRModule.decorators = [
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

export { QRService, QRComponent, QRConfig, QRModule };

//# sourceMappingURL=qr.js.map