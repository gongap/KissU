import { __decorate, __metadata } from 'tslib';
import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, ElementRef, Input, ViewEncapsulation, NgModule } from '@angular/core';
import { InputBoolean, NzUpdateHostClassService, NzAddOnModule } from 'ng-zorro-antd/core';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var NzDividerComponent = /** @class */ (function () {
    function NzDividerComponent(elementRef, nzUpdateHostClassService) {
        this.elementRef = elementRef;
        this.nzUpdateHostClassService = nzUpdateHostClassService;
        this.nzType = 'horizontal';
        this.nzOrientation = '';
        this.nzDashed = false;
    }
    /**
     * @private
     * @return {?}
     */
    NzDividerComponent.prototype.setClass = /**
     * @private
     * @return {?}
     */
    function () {
        var _a;
        /** @type {?} */
        var orientationPrefix = this.nzOrientation.length > 0 ? '-' + this.nzOrientation : this.nzOrientation;
        this.nzUpdateHostClassService.updateHostClass(this.elementRef.nativeElement, (_a = {},
            _a['ant-divider'] = true,
            _a["ant-divider-" + this.nzType] = true,
            _a["ant-divider-with-text" + orientationPrefix] = this.nzText,
            _a["ant-divider-dashed"] = this.nzDashed,
            _a));
    };
    /**
     * @return {?}
     */
    NzDividerComponent.prototype.ngOnChanges = /**
     * @return {?}
     */
    function () {
        this.setClass();
    };
    /**
     * @return {?}
     */
    NzDividerComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        this.setClass();
    };
    NzDividerComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-divider',
                    exportAs: 'nzDivider',
                    template: "<span *ngIf=\"nzText\" class=\"ant-divider-inner-text\">\n  <ng-container *nzStringTemplateOutlet=\"nzText\">{{ nzText }}</ng-container>\n</span>",
                    preserveWhitespaces: false,
                    providers: [NzUpdateHostClassService],
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    NzDividerComponent.ctorParameters = function () { return [
        { type: ElementRef },
        { type: NzUpdateHostClassService }
    ]; };
    NzDividerComponent.propDecorators = {
        nzText: [{ type: Input }],
        nzType: [{ type: Input }],
        nzOrientation: [{ type: Input }],
        nzDashed: [{ type: Input }]
    };
    __decorate([
        InputBoolean(),
        __metadata("design:type", Object)
    ], NzDividerComponent.prototype, "nzDashed", void 0);
    return NzDividerComponent;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
var NzDividerModule = /** @class */ (function () {
    function NzDividerModule() {
    }
    NzDividerModule.decorators = [
        { type: NgModule, args: [{
                    imports: [CommonModule, NzAddOnModule],
                    declarations: [NzDividerComponent],
                    exports: [NzDividerComponent]
                },] }
    ];
    return NzDividerModule;
}());

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

export { NzDividerComponent, NzDividerModule };

//# sourceMappingURL=ng-zorro-antd-divider.js.map