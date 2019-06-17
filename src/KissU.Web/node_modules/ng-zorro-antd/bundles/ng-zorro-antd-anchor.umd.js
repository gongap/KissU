(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/cdk/platform'), require('rxjs'), require('rxjs/operators'), require('@angular/common'), require('@angular/core'), require('ng-zorro-antd/affix'), require('ng-zorro-antd/core')) :
    typeof define === 'function' && define.amd ? define('ng-zorro-antd/anchor', ['exports', '@angular/cdk/platform', 'rxjs', 'rxjs/operators', '@angular/common', '@angular/core', 'ng-zorro-antd/affix', 'ng-zorro-antd/core'], factory) :
    (factory((global['ng-zorro-antd'] = global['ng-zorro-antd'] || {}, global['ng-zorro-antd'].anchor = {}),global.ng.cdk.platform,global.rxjs,global.rxjs.operators,global.ng.common,global.ng.core,global['ng-zorro-antd'].affix,global['ng-zorro-antd'].core));
}(this, (function (exports,platform,rxjs,operators,common,core,affix,core$1) { 'use strict';

    /*! *****************************************************************************
    Copyright (c) Microsoft Corporation. All rights reserved.
    Licensed under the Apache License, Version 2.0 (the "License"); you may not use
    this file except in compliance with the License. You may obtain a copy of the
    License at http://www.apache.org/licenses/LICENSE-2.0

    THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
    KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
    WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
    MERCHANTABLITY OR NON-INFRINGEMENT.

    See the Apache Version 2.0 License for specific language governing permissions
    and limitations under the License.
    ***************************************************************************** */
    function __decorate(decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function")
            r = Reflect.decorate(decorators, target, key, desc);
        else
            for (var i = decorators.length - 1; i >= 0; i--)
                if (d = decorators[i])
                    r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    }
    function __metadata(metadataKey, metadataValue) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function")
            return Reflect.metadata(metadataKey, metadataValue);
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var sharpMatcherRegx = /#([^#]+)$/;
    var NzAnchorComponent = /** @class */ (function () {
        function NzAnchorComponent(scrollSrv, doc, cdr, platform$$1) {
            this.scrollSrv = scrollSrv;
            this.doc = doc;
            this.cdr = cdr;
            this.platform = platform$$1;
            this.nzAffix = true;
            this.nzShowInkInFixed = false;
            this.nzBounds = 5;
            this.nzClick = new core.EventEmitter();
            this.nzScroll = new core.EventEmitter();
            this.visible = false;
            this.wrapperStyle = { 'max-height': '100vh' };
            this.links = [];
            this.animating = false;
            this.target = null;
            this.scroll$ = null;
            this.destroyed = false;
        }
        Object.defineProperty(NzAnchorComponent.prototype, "nzOffsetTop", {
            get: /**
             * @return {?}
             */ function () {
                return this._offsetTop;
            },
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                this._offsetTop = core$1.toNumber(value, 0);
                this.wrapperStyle = {
                    'max-height': "calc(100vh - " + this._offsetTop + "px)"
                };
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(NzAnchorComponent.prototype, "nzTarget", {
            set: /**
             * @param {?} el
             * @return {?}
             */ function (el) {
                this.target = typeof el === 'string' ? this.doc.querySelector(el) : el;
                this.registerScrollEvent();
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @param {?} link
         * @return {?}
         */
        NzAnchorComponent.prototype.registerLink = /**
         * @param {?} link
         * @return {?}
         */
            function (link) {
                this.links.push(link);
            };
        /**
         * @param {?} link
         * @return {?}
         */
        NzAnchorComponent.prototype.unregisterLink = /**
         * @param {?} link
         * @return {?}
         */
            function (link) {
                this.links.splice(this.links.indexOf(link), 1);
            };
        /**
         * @private
         * @return {?}
         */
        NzAnchorComponent.prototype.getTarget = /**
         * @private
         * @return {?}
         */
            function () {
                return this.target || window;
            };
        /**
         * @return {?}
         */
        NzAnchorComponent.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                this.registerScrollEvent();
            };
        /**
         * @return {?}
         */
        NzAnchorComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.destroyed = true;
                this.removeListen();
            };
        /**
         * @private
         * @return {?}
         */
        NzAnchorComponent.prototype.registerScrollEvent = /**
         * @private
         * @return {?}
         */
            function () {
                var _this = this;
                if (!this.platform.isBrowser) {
                    return;
                }
                this.removeListen();
                this.scroll$ = rxjs.fromEvent(this.getTarget(), 'scroll')
                    .pipe(operators.throttleTime(50), operators.distinctUntilChanged())
                    .subscribe(( /**
             * @return {?}
             */function () { return _this.handleScroll(); }));
                // 浏览器在刷新时保持滚动位置，会倒置在dom未渲染完成时计算不正确，因此延迟重新计算
                // 与之相对应可能会引起组件移除后依然触发 `handleScroll` 的 `detectChanges`
                setTimeout(( /**
                 * @return {?}
                 */function () { return _this.handleScroll(); }));
            };
        /**
         * @private
         * @return {?}
         */
        NzAnchorComponent.prototype.removeListen = /**
         * @private
         * @return {?}
         */
            function () {
                if (this.scroll$) {
                    this.scroll$.unsubscribe();
                }
            };
        /**
         * @private
         * @param {?} element
         * @return {?}
         */
        NzAnchorComponent.prototype.getOffsetTop = /**
         * @private
         * @param {?} element
         * @return {?}
         */
            function (element) {
                if (!element || !element.getClientRects().length) {
                    return 0;
                }
                /** @type {?} */
                var rect = element.getBoundingClientRect();
                if (rect.width || rect.height) {
                    if (this.getTarget() === window) {
                        return rect.top - ( /** @type {?} */(( /** @type {?} */(element.ownerDocument)).documentElement)).clientTop;
                    }
                    return rect.top - (( /** @type {?} */(this.getTarget()))).getBoundingClientRect().top;
                }
                return rect.top;
            };
        /**
         * @return {?}
         */
        NzAnchorComponent.prototype.handleScroll = /**
         * @return {?}
         */
            function () {
                var _this = this;
                if (typeof document === 'undefined' || this.destroyed || this.animating) {
                    return;
                }
                /** @type {?} */
                var sections = [];
                /** @type {?} */
                var scope = (this.nzOffsetTop || 0) + this.nzBounds;
                this.links.forEach(( /**
                 * @param {?} comp
                 * @return {?}
                 */function (comp) {
                    /** @type {?} */
                    var sharpLinkMatch = sharpMatcherRegx.exec(comp.nzHref.toString());
                    if (!sharpLinkMatch) {
                        return;
                    }
                    /** @type {?} */
                    var target = _this.doc.getElementById(sharpLinkMatch[1]);
                    if (target) {
                        /** @type {?} */
                        var top_1 = _this.getOffsetTop(target);
                        if (top_1 < scope) {
                            sections.push({
                                top: top_1,
                                comp: comp
                            });
                        }
                    }
                }));
                this.visible = !!sections.length;
                if (!this.visible) {
                    this.clearActive();
                    this.cdr.detectChanges();
                }
                else {
                    /** @type {?} */
                    var maxSection = sections.reduce(( /**
                     * @param {?} prev
                     * @param {?} curr
                     * @return {?}
                     */function (prev, curr) { return (curr.top > prev.top ? curr : prev); }));
                    this.handleActive(maxSection.comp);
                }
            };
        /**
         * @private
         * @return {?}
         */
        NzAnchorComponent.prototype.clearActive = /**
         * @private
         * @return {?}
         */
            function () {
                this.links.forEach(( /**
                 * @param {?} i
                 * @return {?}
                 */function (i) {
                    i.active = false;
                    i.markForCheck();
                }));
            };
        /**
         * @private
         * @param {?} comp
         * @return {?}
         */
        NzAnchorComponent.prototype.handleActive = /**
         * @private
         * @param {?} comp
         * @return {?}
         */
            function (comp) {
                this.clearActive();
                comp.active = true;
                comp.markForCheck();
                /** @type {?} */
                var linkNode = ( /** @type {?} */((( /** @type {?} */(comp.elementRef.nativeElement))).querySelector('.ant-anchor-link-title')));
                this.ink.nativeElement.style.top = linkNode.offsetTop + linkNode.clientHeight / 2 - 4.5 + "px";
                this.visible = true;
                this.cdr.detectChanges();
                this.nzScroll.emit(comp);
            };
        /**
         * @param {?} linkComp
         * @return {?}
         */
        NzAnchorComponent.prototype.handleScrollTo = /**
         * @param {?} linkComp
         * @return {?}
         */
            function (linkComp) {
                var _this = this;
                /** @type {?} */
                var el = this.doc.querySelector(linkComp.nzHref);
                if (!el) {
                    return;
                }
                this.animating = true;
                /** @type {?} */
                var containerScrollTop = this.scrollSrv.getScroll(this.getTarget());
                /** @type {?} */
                var elOffsetTop = this.getOffsetTop(el);
                /** @type {?} */
                var targetScrollTop = containerScrollTop + elOffsetTop - (this.nzOffsetTop || 0);
                this.scrollSrv.scrollTo(this.getTarget(), targetScrollTop, undefined, ( /**
                 * @return {?}
                 */function () {
                    _this.animating = false;
                    _this.handleActive(linkComp);
                }));
                this.nzClick.emit(linkComp.nzHref);
            };
        NzAnchorComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'nz-anchor',
                        exportAs: 'nzAnchor',
                        preserveWhitespaces: false,
                        template: "<nz-affix *ngIf=\"nzAffix;else content\" [nzOffsetTop]=\"nzOffsetTop\">\n  <ng-template [ngTemplateOutlet]=\"content\"></ng-template>\n</nz-affix>\n<ng-template #content>\n  <div class=\"ant-anchor-wrapper\" [ngStyle]=\"wrapperStyle\">\n    <div class=\"ant-anchor\" [ngClass]=\"{'fixed': !nzAffix && !nzShowInkInFixed}\">\n      <div class=\"ant-anchor-ink\">\n        <div class=\"ant-anchor-ink-ball\" [class.visible]=\"visible\" #ink></div>\n      </div>\n      <ng-content></ng-content>\n    </div>\n  </div>\n</ng-template>",
                        encapsulation: core.ViewEncapsulation.None,
                        changeDetection: core.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        NzAnchorComponent.ctorParameters = function () {
            return [
                { type: core$1.NzScrollService },
                { type: undefined, decorators: [{ type: core.Inject, args: [common.DOCUMENT,] }] },
                { type: core.ChangeDetectorRef },
                { type: platform.Platform }
            ];
        };
        NzAnchorComponent.propDecorators = {
            ink: [{ type: core.ViewChild, args: ['ink',] }],
            nzAffix: [{ type: core.Input }],
            nzShowInkInFixed: [{ type: core.Input }],
            nzBounds: [{ type: core.Input }],
            nzOffsetTop: [{ type: core.Input }],
            nzTarget: [{ type: core.Input }],
            nzClick: [{ type: core.Output }],
            nzScroll: [{ type: core.Output }]
        };
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzAnchorComponent.prototype, "nzAffix", void 0);
        __decorate([
            core$1.InputBoolean(),
            __metadata("design:type", Object)
        ], NzAnchorComponent.prototype, "nzShowInkInFixed", void 0);
        __decorate([
            core$1.InputNumber(),
            __metadata("design:type", Number)
        ], NzAnchorComponent.prototype, "nzBounds", void 0);
        return NzAnchorComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzAnchorLinkComponent = /** @class */ (function () {
        function NzAnchorLinkComponent(elementRef, anchorComp, cdr, platform$$1, renderer) {
            this.elementRef = elementRef;
            this.anchorComp = anchorComp;
            this.cdr = cdr;
            this.platform = platform$$1;
            this.nzHref = '#';
            this.titleStr = '';
            this.active = false;
            renderer.addClass(elementRef.nativeElement, 'ant-anchor-link');
        }
        Object.defineProperty(NzAnchorLinkComponent.prototype, "nzTitle", {
            set: /**
             * @param {?} value
             * @return {?}
             */ function (value) {
                if (value instanceof core.TemplateRef) {
                    this.titleStr = null;
                    this.titleTpl = value;
                }
                else {
                    this.titleStr = value;
                }
            },
            enumerable: true,
            configurable: true
        });
        /**
         * @return {?}
         */
        NzAnchorLinkComponent.prototype.ngOnInit = /**
         * @return {?}
         */
            function () {
                this.anchorComp.registerLink(this);
            };
        /**
         * @param {?} e
         * @return {?}
         */
        NzAnchorLinkComponent.prototype.goToClick = /**
         * @param {?} e
         * @return {?}
         */
            function (e) {
                e.preventDefault();
                e.stopPropagation();
                if (this.platform.isBrowser) {
                    this.anchorComp.handleScrollTo(this);
                }
            };
        /**
         * @return {?}
         */
        NzAnchorLinkComponent.prototype.markForCheck = /**
         * @return {?}
         */
            function () {
                this.cdr.markForCheck();
            };
        /**
         * @return {?}
         */
        NzAnchorLinkComponent.prototype.ngOnDestroy = /**
         * @return {?}
         */
            function () {
                this.anchorComp.unregisterLink(this);
            };
        NzAnchorLinkComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'nz-link',
                        exportAs: 'nzLink',
                        preserveWhitespaces: false,
                        template: "<a (click)=\"goToClick($event)\" href=\"{{nzHref}}\" class=\"ant-anchor-link-title\" title=\"{{titleStr}}\">\n  <span *ngIf=\"titleStr; else (titleTpl || nzTemplate)\">{{ titleStr }}</span>\n</a>\n<ng-content></ng-content>",
                        host: {
                            '[class.ant-anchor-link-active]': 'active'
                        },
                        encapsulation: core.ViewEncapsulation.None,
                        changeDetection: core.ChangeDetectionStrategy.OnPush,
                        styles: ["\n      nz-link {\n        display: block;\n      }\n    "]
                    }] }
        ];
        /** @nocollapse */
        NzAnchorLinkComponent.ctorParameters = function () {
            return [
                { type: core.ElementRef },
                { type: NzAnchorComponent },
                { type: core.ChangeDetectorRef },
                { type: platform.Platform },
                { type: core.Renderer2 }
            ];
        };
        NzAnchorLinkComponent.propDecorators = {
            nzHref: [{ type: core.Input }],
            nzTitle: [{ type: core.Input }],
            nzTemplate: [{ type: core.ContentChild, args: ['nzTemplate',] }]
        };
        return NzAnchorLinkComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var NzAnchorModule = /** @class */ (function () {
        function NzAnchorModule() {
        }
        NzAnchorModule.decorators = [
            { type: core.NgModule, args: [{
                        declarations: [NzAnchorComponent, NzAnchorLinkComponent],
                        exports: [NzAnchorComponent, NzAnchorLinkComponent],
                        imports: [common.CommonModule, affix.NzAffixModule],
                        providers: [core$1.SCROLL_SERVICE_PROVIDER]
                    },] }
        ];
        return NzAnchorModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.NzAnchorLinkComponent = NzAnchorLinkComponent;
    exports.NzAnchorComponent = NzAnchorComponent;
    exports.NzAnchorModule = NzAnchorModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ng-zorro-antd-anchor.umd.js.map