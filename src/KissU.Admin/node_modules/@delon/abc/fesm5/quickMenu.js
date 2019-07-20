import { __spread, __decorate, __metadata } from 'tslib';
import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, Input, Renderer2, NgModule } from '@angular/core';
import { InputNumber, DelonUtilModule } from '@delon/util';
import { NgZorroAntdModule } from 'ng-zorro-antd';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var QuickMenuComponent = /** @class */ (function () {
    // #endregion
    function QuickMenuComponent(cdr, el, render) {
        this.cdr = cdr;
        this.el = el;
        this.render = render;
        // #region fields
        this.icon = 'question-circle';
        this.top = 120;
        this.width = 200;
        this.bgColor = '#fff';
        this.borderColor = '#ddd';
        this.show = false;
        this.ctrlStyle = {};
        this.initFlag = false;
    }
    /**
     * @return {?}
     */
    QuickMenuComponent.prototype._click = /**
     * @return {?}
     */
    function () {
        this.show = !this.show;
        this.setStyle();
    };
    /**
     * @private
     * @return {?}
     */
    QuickMenuComponent.prototype.setStyle = /**
     * @private
     * @return {?}
     */
    function () {
        this.ctrlStyle = {
            'background-color': this.bgColor,
            'border-color': this.borderColor,
        };
        /** @type {?} */
        var res = [
            "top:" + this.top + "px",
            "width:" + this.width + "px",
            "background-color:" + this.bgColor,
            "border-color:" + this.borderColor,
            "margin-right:-" + (this.show ? 0 : this.width) + "px",
        ];
        this.render.setAttribute(this.el.nativeElement, 'style', res.join(';'));
        this.cdr.detectChanges();
    };
    /**
     * @return {?}
     */
    QuickMenuComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        this.initFlag = true;
        this.setStyle();
    };
    /**
     * @return {?}
     */
    QuickMenuComponent.prototype.ngOnChanges = /**
     * @return {?}
     */
    function () {
        if (this.initFlag)
            this.setStyle();
    };
    QuickMenuComponent.decorators = [
        { type: Component, args: [{
                    selector: 'quick-menu',
                    template: "<div class=\"quick-menu__inner\">\n  <div class=\"quick-menu__ctrl\"\n       [ngStyle]=\"ctrlStyle\">\n    <div class=\"quick-menu__ctrl-icon\">\n      <ng-container *stringTemplateOutlet=\"icon\"><i nz-icon\n           [type]=\"icon\"></i></ng-container>\n    </div>\n  </div>\n  <ng-content></ng-content>\n</div>\n",
                    host: {
                        '[class.quick-menu]': 'true',
                        '(click)': '_click()',
                    },
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    QuickMenuComponent.ctorParameters = function () { return [
        { type: ChangeDetectorRef },
        { type: ElementRef },
        { type: Renderer2 }
    ]; };
    QuickMenuComponent.propDecorators = {
        icon: [{ type: Input }],
        top: [{ type: Input }],
        width: [{ type: Input }],
        bgColor: [{ type: Input }],
        borderColor: [{ type: Input }]
    };
    __decorate([
        InputNumber(),
        __metadata("design:type", Object)
    ], QuickMenuComponent.prototype, "top", void 0);
    __decorate([
        InputNumber(),
        __metadata("design:type", Object)
    ], QuickMenuComponent.prototype, "width", void 0);
    return QuickMenuComponent;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
var COMPONENTS = [QuickMenuComponent];
var QuickMenuModule = /** @class */ (function () {
    function QuickMenuModule() {
    }
    QuickMenuModule.decorators = [
        { type: NgModule, args: [{
                    imports: [CommonModule, NgZorroAntdModule, DelonUtilModule],
                    declarations: __spread(COMPONENTS),
                    exports: __spread(COMPONENTS),
                },] }
    ];
    return QuickMenuModule;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

export { QuickMenuComponent, QuickMenuModule };

//# sourceMappingURL=quickMenu.js.map