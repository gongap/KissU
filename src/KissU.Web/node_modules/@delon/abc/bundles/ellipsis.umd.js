/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/platform-browser'), require('rxjs/operators'), require('@angular/cdk/observers'), require('@angular/common'), require('@angular/core'), require('@delon/util'), require('ng-zorro-antd')) :
    typeof define === 'function' && define.amd ? define('@delon/abc/ellipsis', ['exports', '@angular/platform-browser', 'rxjs/operators', '@angular/cdk/observers', '@angular/common', '@angular/core', '@delon/util', 'ng-zorro-antd'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = global.delon.abc || {}, global.delon.abc.ellipsis = {}),global.ng.platformBrowser,global.rxjs.operators,global.ng.cdk.observers,global.ng.common,global.ng.core,global.delon.util,global['ng-zorro-antd']));
}(this, (function (exports,platformBrowser,operators,observers,common,core,util,ngZorroAntd) { 'use strict';

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
    function __read(o, n) {
        var m = typeof Symbol === "function" && o[Symbol.iterator];
        if (!m)
            return o;
        var i = m.call(o), r, ar = [], e;
        try {
            while ((n === void 0 || n-- > 0) && !(r = i.next()).done)
                ar.push(r.value);
        }
        catch (error) {
            e = { error: error };
        }
        finally {
            try {
                if (r && !r.done && (m = i["return"]))
                    m.call(i);
            }
            finally {
                if (e)
                    throw e.error;
            }
        }
        return ar;
    }
    function __spread() {
        for (var ar = [], i = 0; i < arguments.length; i++)
            ar = ar.concat(__read(arguments[i]));
        return ar;
    }

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var EllipsisComponent = /** @class */ (function () {
        // #endregion
        function EllipsisComponent(el, ngZone, dom, doc, cdr) {
            this.el = el;
            this.ngZone = ngZone;
            this.dom = dom;
            this.doc = doc;
            this.cdr = cdr;
            // tslint:disable-next-line:no-string-literal
            this.isSupportLineClamp = this.doc.body.style['webkitLineClamp'] !== undefined;
            this.inited = false;
            this.type = 'default';
            this.cls = {};
            this.text = '';
            this.targetCount = 0;
            // #region fields
            this.tooltip = false;
            this.fullWidthRecognition = false;
            this.tail = '...';
        }
        /**
         * @private
         * @param {?} str
         * @return {?}
         */
        EllipsisComponent.prototype.getStrFullLength = /**
         * @private
         * @param {?} str
         * @return {?}
         */
            function (str) {
                return str.split('').reduce(( /**
                 * @param {?} pre
                 * @param {?} cur
                 * @return {?}
                 */function (pre, cur) {
                    /** @type {?} */
                    var charCode = cur.charCodeAt(0);
                    if (charCode >= 0 && charCode <= 128) {
                        return pre + 1;
                    }
                    return pre + 2;
                }), 0);
            };
        /**
         * @private
         * @param {?} str
         * @param {?} maxLength
         * @return {?}
         */
        EllipsisComponent.prototype.cutStrByFullLength = /**
         * @private
         * @param {?} str
         * @param {?} maxLength
         * @return {?}
         */
            function (str, maxLength) {
                /** @type {?} */
                var showLength = 0;
                return str.split('').reduce(( /**
                 * @param {?} pre
                 * @param {?} cur
                 * @return {?}
                 */function (pre, cur) {
                    /** @type {?} */
                    var charCode = cur.charCodeAt(0);
                    if (charCode >= 0 && charCode <= 128) {
                        showLength += 1;
                    }
                    else {
                        showLength += 2;
                    }
                    if (showLength <= maxLength) {
                        return pre + cur;
                    }
                    return pre;
                }), '');
            };
        /**
         * @private
         * @param {?} th
         * @param {?} m
         * @param {?} b
         * @param {?} e
         * @param {?} text
         * @param {?} shadowNode
         * @return {?}
         */
        EllipsisComponent.prototype.bisection = /**
         * @private
         * @param {?} th
         * @param {?} m
         * @param {?} b
         * @param {?} e
         * @param {?} text
         * @param {?} shadowNode
         * @return {?}
         */
            function (th, m, b, e, text, shadowNode) {
                /** @type {?} */
                var suffix = this.tail;
                /** @type {?} */
                var mid = m;
                /** @type {?} */
                var end = e;
                /** @type {?} */
                var begin = b;
                shadowNode.innerHTML = text.substring(0, mid) + suffix;
                /** @type {?} */
                var sh = shadowNode.offsetHeight;
                if (sh <= th) {
                    shadowNode.innerHTML = text.substring(0, mid + 1) + suffix;
                    sh = shadowNode.offsetHeight;
                    if (sh > th || mid === begin) {
                        return mid;
                    }
                    begin = mid;
                    if (end - begin === 1) {
                        mid = begin + 1;
                    }
                    else {
                        mid = Math.floor((end - begin) / 2) + begin;
                    }
                    return this.bisection(th, mid, begin, end, text, shadowNode);
                }
                if (mid - 1 < 0) {
                    return mid;
                }
                shadowNode.innerHTML = text.substring(0, mid - 1) + suffix;
                sh = shadowNode.offsetHeight;
                if (sh <= th) {
                    return mid - 1;
                }
                end = mid;
                mid = Math.floor((end - begin) / 2) + begin;
                return this.bisection(th, mid, begin, end, text, shadowNode);
            };
        /**
         * @private
         * @return {?}
         */
        EllipsisComponent.prototype.genType = /**
         * @private
         * @return {?}
         */
            function () {
                var _a = this, lines = _a.lines, length = _a.length, isSupportLineClamp = _a.isSupportLineClamp, cdr = _a.cdr;
                this.cls = {
                    ellipsis: true,
                    ellipsis__lines: lines && !isSupportLineClamp,
                    'ellipsis__line-clamp': lines && isSupportLineClamp,
                };
                if (!lines && !length) {
                    this.type = 'default';
                }
                else if (!lines) {
                    this.type = 'length';
                }
                else if (isSupportLineClamp) {
                    this.type = 'line-clamp';
                }
                else {
                    this.type = 'line';
                }
                cdr.detectChanges();
            };
        /**
         * @private
         * @return {?}
         */
        EllipsisComponent.prototype.gen = /**
         * @private
         * @return {?}
         */
            function () {
                var _a = this, type = _a.type, lines = _a.lines, length = _a.length, fullWidthRecognition = _a.fullWidthRecognition, tail = _a.tail, orgEl = _a.orgEl, cdr = _a.cdr;
                if (type === 'length') {
                    /** @type {?} */
                    var el = ( /** @type {?} */(orgEl.nativeElement));
                    if (el.children.length > 0) {
                        throw new Error('Ellipsis content must be string.');
                    }
                    /** @type {?} */
                    var text = el.textContent;
                    /** @type {?} */
                    var textLength = fullWidthRecognition ? this.getStrFullLength(text) : text.length;
                    if (textLength <= length || length < 0) {
                        this.text = text;
                    }
                    else {
                        /** @type {?} */
                        var displayText = void 0;
                        if (length - tail.length <= 0) {
                            displayText = '';
                        }
                        else {
                            displayText = fullWidthRecognition
                                ? this.cutStrByFullLength(text, length)
                                : text.slice(0, length);
                        }
                        this.text = displayText + tail;
                    }
                    cdr.detectChanges();
                }
                else if (type === 'line') {
                    var _b = this, shadowOrgEl = _b.shadowOrgEl, shadowTextEl = _b.shadowTextEl;
                    /** @type {?} */
                    var orgNode = ( /** @type {?} */(shadowOrgEl.nativeElement));
                    /** @type {?} */
                    var text = orgNode.innerText || orgNode.textContent;
                    /** @type {?} */
                    var lineHeight = parseInt(getComputedStyle(this.getEl('.ellipsis')).lineHeight, 10);
                    /** @type {?} */
                    var targetHeight = lines * lineHeight;
                    this.getEl('.ellipsis__handle').style.height = targetHeight + "px";
                    if (orgNode.offsetHeight <= targetHeight) {
                        this.text = text;
                        this.targetCount = text.length;
                    }
                    else {
                        // bisection
                        /** @type {?} */
                        var len = text.length;
                        /** @type {?} */
                        var mid = Math.ceil(len / 2);
                        /** @type {?} */
                        var count = this.bisection(targetHeight, mid, 0, len, text, shadowTextEl.nativeElement.firstChild);
                        this.text = text;
                        this.targetCount = count;
                    }
                    cdr.detectChanges();
                }
            };
        /**
         * @private
         * @param {?} cls
         * @return {?}
         */
        EllipsisComponent.prototype.getEl = /**
         * @private
         * @param {?} cls
         * @return {?}
         */
            function (cls) {
                return this.el.nativeElement.querySelector(cls);
            };
        /**
         * @private
         * @param {?} fn
         * @return {?}
         */
        EllipsisComponent.prototype.executeOnStable = /**
         * @private
         * @param {?} fn
         * @return {?}
         */
            function (fn) {
                if (this.ngZone.isStable) {
                    fn();
                }
                else {
                    this.ngZone.onStable
                        .asObservable()
                        .pipe(operators.take(1))
                        .subscribe(fn);
                }
            };
        /**
         * @return {?}
         */
        EllipsisComponent.prototype.refresh = /**
         * @return {?}
         */
            function () {
                var _this = this;
                this.genType();
                this.executeOnStable(( /**
                 * @return {?}
                 */function () {
                    var _a = _this, type = _a.type, dom = _a.dom, orgEl = _a.orgEl, cdr = _a.cdr;
                    /** @type {?} */
                    var html = orgEl.nativeElement.innerHTML;
                    _this.orgHtml = dom.bypassSecurityTrustHtml(html);
                    cdr.detectChanges();
                    _this.gen();
                    if (type !== 'line') {
                        /** @type {?} */
                        var el = _this.getEl('.ellipsis');
                        if (el) {
                            el.innerHTML = html;
                        }
                    }
                }));
            };
        /**
         * @return {?}
         */
        EllipsisComponent.prototype.ngAfterViewInit = /**
         * @return {?}
         */
            function () {
                this.inited = true;
                this.refresh();
            };
        /**
         * @return {?}
         */
        EllipsisComponent.prototype.ngOnChanges = /**
         * @return {?}
         */
            function () {
                if (this.inited) {
                    this.refresh();
                }
            };
        EllipsisComponent.decorators = [
            { type: core.Component, args: [{
                        selector: 'ellipsis',
                        template: "<div (cdkObserveContent)=\"refresh()\"\n     #orgEl\n     style=\"display: none;\">\n  <ng-content></ng-content>\n</div>\n<ng-template #tooltipTpl\n             let-con>\n  <span *ngIf=\"tooltip; else con\"\n        nz-tooltip\n        [nzTitle]=\"titleTpl\"\n        [nzOverlayStyle]=\"{ 'overflow-wrap': 'break-word', 'word-wrap': 'break-word' }\">\n    <ng-container *ngTemplateOutlet=\"con\"></ng-container>\n    <ng-template #titleTpl>\n      <div [innerHTML]=\"orgHtml\"></div>\n    </ng-template>\n  </span>\n</ng-template>\n<ng-container [ngSwitch]=\"type\">\n  <span *ngSwitchCase=\"'default'\"\n        [ngClass]=\"cls\"></span>\n  <ng-container *ngSwitchCase=\"'length'\">\n    <ng-template [ngTemplateOutlet]=\"tooltipTpl\"\n                 [ngTemplateOutletContext]=\"{$implicit: lengthTpl}\"></ng-template>\n    <ng-template #lengthTpl>{{text}}</ng-template>\n  </ng-container>\n  <ng-container *ngSwitchCase=\"'line-clamp'\">\n    <ng-template [ngTemplateOutlet]=\"tooltipTpl\"\n                 [ngTemplateOutletContext]=\"{$implicit: lineClampTpl}\"></ng-template>\n    <ng-template #lineClampTpl>\n      <div [ngClass]=\"cls\"\n           [ngStyle]=\"{'-webkit-line-clamp': lines, '-webkit-box-orient': 'vertical'}\"></div>\n    </ng-template>\n  </ng-container>\n  <div *ngSwitchCase=\"'line'\"\n       [ngClass]=\"cls\">\n    <div class=\"ellipsis__handle\">\n      <ng-template [ngTemplateOutlet]=\"tooltipTpl\"\n                   [ngTemplateOutletContext]=\"{$implicit: lineTpl}\"></ng-template>\n      <ng-template #lineTpl>\n        {{ (targetCount > 0 ? text.substring(0, targetCount) : '') + (targetCount > 0 && targetCount < text.length\n          ?\n          tail\n          : ''\n          )\n          }}\n          </ng-template>\n          <div\n          class=\"ellipsis__shadow\"\n          #shadowOrgEl\n          [innerHTML]=\"orgHtml\">\n    </div>\n    <div class=\"ellipsis__shadow\"\n         #shadowTextEl><span>{{text}}</span></div>\n  </div>\n  </div>\n</ng-container>\n",
                        changeDetection: core.ChangeDetectionStrategy.OnPush
                    }] }
        ];
        /** @nocollapse */
        EllipsisComponent.ctorParameters = function () {
            return [
                { type: core.ElementRef },
                { type: core.NgZone },
                { type: platformBrowser.DomSanitizer },
                { type: Document, decorators: [{ type: core.Inject, args: [common.DOCUMENT,] }] },
                { type: core.ChangeDetectorRef }
            ];
        };
        EllipsisComponent.propDecorators = {
            orgEl: [{ type: core.ViewChild, args: ['orgEl',] }],
            shadowOrgEl: [{ type: core.ViewChild, args: ['shadowOrgEl',] }],
            shadowTextEl: [{ type: core.ViewChild, args: ['shadowTextEl',] }],
            tooltip: [{ type: core.Input }],
            length: [{ type: core.Input }],
            lines: [{ type: core.Input }],
            fullWidthRecognition: [{ type: core.Input }],
            tail: [{ type: core.Input }]
        };
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], EllipsisComponent.prototype, "tooltip", void 0);
        __decorate([
            util.InputNumber(null),
            __metadata("design:type", Number)
        ], EllipsisComponent.prototype, "length", void 0);
        __decorate([
            util.InputNumber(null),
            __metadata("design:type", Number)
        ], EllipsisComponent.prototype, "lines", void 0);
        __decorate([
            util.InputBoolean(),
            __metadata("design:type", Object)
        ], EllipsisComponent.prototype, "fullWidthRecognition", void 0);
        return EllipsisComponent;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var COMPONENTS = [EllipsisComponent];
    var EllipsisModule = /** @class */ (function () {
        function EllipsisModule() {
        }
        EllipsisModule.decorators = [
            { type: core.NgModule, args: [{
                        imports: [common.CommonModule, observers.ObserversModule, util.DelonUtilModule, ngZorroAntd.NgZorroAntdModule],
                        declarations: __spread(COMPONENTS),
                        exports: __spread(COMPONENTS),
                    },] }
        ];
        return EllipsisModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.EllipsisComponent = EllipsisComponent;
    exports.EllipsisModule = EllipsisModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=ellipsis.umd.js.map