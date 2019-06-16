(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/cdk/platform'), require('ng-zorro-antd/core'), require('@angular/common'), require('@angular/core'), require('ng-zorro-antd/icon')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/avatar', ['exports', '@angular/cdk/platform', 'ng-zorro-antd/core', '@angular/common', '@angular/core', 'ng-zorro-antd/icon'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].avatar = {}),global.ng.cdk.platform,global['ng-zorro-antd'].core,global.ng.common,global.ng.core,global['ng-zorro-antd'].icon));
}(this, (function (exports,platform,core,common,core$1,icon) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzAvatarComponent = /** @class */ (function () {
        function NzAvatarComponent(elementRef, cd, updateHostClassService, renderer, platform$$1) {
            this.elementRef = elementRef;
            this.cd = cd;
            this.updateHostClassService = updateHostClassService;
            this.renderer = renderer;
            this.platform = platform$$1;
            this.nzShape = 'circle';
            this.nzSize = 'default';
            this.oldAPIIcon = true; // Make the user defined icon compatible to old API. Should be removed in 2.0.
            // Make the user defined icon compatible to old API. Should be removed in 2.0.
            this.hasText = false;
            this.hasSrc = true;
            this.hasIcon = false;
            this.el = this.elementRef.nativeElement;
            this.prefixCls = 'ant-avatar';
            this.sizeMap = { large: 'lg', small: 'sm' };
        }
        /**
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
        NzAvatarComponent.prototype.setClass = /**
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
            function () {
                var _a;
                /** @type {?} */
                var classMap = (_a = {},
                    _a[( /** @type {?} */(this)).prefixCls] = true,
                    _a[( /** @type {?} */(this)).prefixCls + "-" + ( /** @type {?} */(this)).sizeMap[( /** @type {?} */(this)).nzSize]] = ( /** @type {?} */(this)).sizeMap[( /** @type {?} */(this)).nzSize],
                    _a[( /** @type {?} */(this)).prefixCls + "-" + ( /** @type {?} */(this)).nzShape] = ( /** @type {?} */(this)).nzShape,
                    _a[( /** @type {?} */(this)).prefixCls + "-icon"] = ( /** @type {?} */(this)).nzIcon,
                    _a[( /** @type {?} */(this)).prefixCls + "-image"] = ( /** @type {?} */(this)).hasSrc // downgrade after image error
                    ,
                        _a);
                ( /** @type {?} */(this)).updateHostClassService.updateHostClass(( /** @type {?} */(this)).el, classMap);
                ( /** @type {?} */(this)).cd.detectChanges();
                return ( /** @type {?} */(this));
            };
        /**
         * @return {?}
         */
        NzAvatarComponent.prototype.imgError = /**
         * @return {?}
         */
            function () {
                this.hasSrc = false;
                this.hasIcon = false;
                this.hasText = false;
                if (this.nzIcon) {
                    this.hasIcon = true;
                }
                else if (this.nzText) {
                    this.hasText = true;
                }
                this.setClass().notifyCalc();
                this.setSizeStyle();
            };
        /**
         * @param {?} changes
         * @return {?}
         */
        NzAvatarComponent.prototype.ngOnChanges = /**
         * @param {?} changes
         * @return {?}
         */
            function (changes) {
                if (changes.hasOwnProperty('nzIcon') && changes.nzIcon.currentValue) {
                    this.oldAPIIcon = changes.nzIcon.currentValue.indexOf('anticon') > -1;
                }
                this.hasText = !this.nzSrc && !!this.nzText;
                this.hasIcon = !this.nzSrc && !!this.nzIcon;
                this.hasSrc = !!this.nzSrc;
                this.setClass().notifyCalc();
                this.setSizeStyle();
            };
        /**
         * @private
         * @return {?}
         */
        NzAvatarComponent.prototype.calcStringSize = /**
         * @private
         * @return {?}
         */
            function () {
                if (!this.hasText) {
                    return;
                }
                /** @type {?} */
                var childrenWidth = this.textEl.nativeElement.offsetWidth;
                /** @type {?} */
                var avatarWidth = this.el.getBoundingClientRect().width;
                /** @type {?} */
                var scale = avatarWidth - 8 < childrenWidth ? (avatarWidth - 8) / childrenWidth : 1;
                this.textStyles = {
                    transform: "scale(" + scale + ") translateX(-50%)"
                };
                if (typeof this.nzSize === 'number') {
                    Object.assign(this.textStyles, {
                        lineHeight: this.nzSize + "px"
                    });
                }
                this.cd.detectChanges();
            };
        /**
         * @private
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
        NzAvatarComponent.prototype.notifyCalc = /**
         * @private
         * @template THIS
         * @this {THIS}
         * @return {THIS}
         */
            function () {
                var _this = this;
                // If use ngAfterViewChecked, always demands more computations, so......
                if (( /** @type {?} */(this)).platform.isBrowser) {
                    setTimeout(( /**
                     * @return {?}
                     */function () {
                        ( /** @type {?} */(_this)).calcStringSize();
                    }));
                }
                return ( /** @type {?} */(this));
            };
        /**
         * @private
         * @return {?}
         */
        NzAvatarComponent.prototype.setSizeStyle = /**
         * @private
         * @return {?}
         */
            function () {
                if (typeof this.nzSize === 'string') {
                    return;
                }
                this.renderer.setStyle(this.el, 'width', this.nzSize + "px");
                this.renderer.setStyle(this.el, 'height', this.nzSize + "px");
                this.renderer.setStyle(this.el, 'line-height', this.nzSize + "px");
                if (this.hasIcon) {
                    this.renderer.setStyle(this.el, 'font-size', this.nzSize / 2 + "px");
                }
            };
        NzAvatarComponent.decorators = [
            { type: core$1.Component, args: [{
                        selector: 'nz-avatar',
                        exportAs: 'nzAvatar',
                        template: "<i nz-icon *ngIf=\"nzIcon && hasIcon\" [type]=\"!oldAPIIcon && nzIcon\" [ngClass]=\"oldAPIIcon && nzIcon\"></i>\n<img [src]=\"nzSrc\" *ngIf=\"nzSrc && hasSrc\" (error)=\"imgError()\"/>\n<span class=\"ant-avatar-string\" #textEl [ngStyle]=\"textStyles\" *ngIf=\"nzText && hasText\">{{ nzText }}</span>",
                        providers: [core.NzUpdateHostClassService],
                        preserveWhitespaces: false,
                        changeDetection: core$1.ChangeDetectionStrategy.OnPush,
                        encapsulation: core$1.ViewEncapsulation.None
                    }] }
        ];
        /** @nocollapse */
        NzAvatarComponent.ctorParameters = function () {
            return [
                { type: core$1.ElementRef },
                { type: core$1.ChangeDetectorRef },
                { type: core.NzUpdateHostClassService },
                { type: core$1.Renderer2 },
                { type: platform.Platform }
            ];
        };
        NzAvatarComponent.propDecorators = {
            nzShape: [{ type: core$1.Input }],
            nzSize: [{ type: core$1.Input }],
            nzText: [{ type: core$1.Input }],
            nzSrc: [{ type: core$1.Input }],
            nzIcon: [{ type: core$1.Input }],
            textEl: [{ type: core$1.ViewChild, args: ['textEl',] }]
        };
        return NzAvatarComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzAvatarModule = /** @class */ (function () {
        function NzAvatarModule() {
        }
        NzAvatarModule.decorators = [
            { type: core$1.NgModule, args: [{
                        declarations: [NzAvatarComponent],
                        exports: [NzAvatarComponent],
                        imports: [common.CommonModule, icon.NzIconModule]
                    },] }
        ];
        return NzAvatarModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzAvatarComponent = NzAvatarComponent;
    exports.NzAvatarModule = NzAvatarModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-avatar.umd.js.map