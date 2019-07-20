import { WINDOW } from '@delon/theme';
import { __decorate, __metadata } from 'tslib';
import { CommonModule } from '@angular/common';
import { Component, Input, ViewChild, ChangeDetectionStrategy, ContentChildren, Inject, NgModule } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { InputBoolean, DelonUtilModule } from '@delon/util';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class GlobalFooterItemComponent {
}
GlobalFooterItemComponent.decorators = [
    { type: Component, args: [{
                selector: 'global-footer-item',
                template: `
    <ng-template #host><ng-content></ng-content></ng-template>
  `
            }] }
];
GlobalFooterItemComponent.propDecorators = {
    host: [{ type: ViewChild, args: ['host',] }],
    href: [{ type: Input }],
    blankTarget: [{ type: Input }]
};
__decorate([
    InputBoolean(),
    __metadata("design:type", Boolean)
], GlobalFooterItemComponent.prototype, "blankTarget", void 0);

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class GlobalFooterComponent {
    /**
     * @param {?} router
     * @param {?} win
     */
    constructor(router, win) {
        this.router = router;
        this.win = win;
        this.links = [];
    }
    /**
     * @param {?} item
     * @return {?}
     */
    to(item) {
        if (!item.href) {
            return;
        }
        if (item.blankTarget) {
            this.win.open(item.href);
            return;
        }
        if (/^https?:\/\//.test(item.href)) {
            this.win.location.href = item.href;
        }
        else {
            this.router.navigateByUrl(item.href);
        }
    }
}
GlobalFooterComponent.decorators = [
    { type: Component, args: [{
                selector: 'global-footer',
                template: "<div *ngIf=\"links.length > 0 || items.length > 0\" class=\"global-footer__links\">\n  <a *ngFor=\"let i of links\" class=\"global-footer__links-item\" (click)=\"to(i)\" [innerHTML]=\"i.title\"></a>\n  <a *ngFor=\"let i of items\" class=\"global-footer__links-item\" (click)=\"to(i)\">\n    <ng-container *ngTemplateOutlet=\"i.host\"></ng-container>\n  </a>\n</div>\n<div class=\"global-footer__copyright\">\n  <ng-content></ng-content>\n</div>\n",
                host: { '[class.global-footer]': 'true' },
                changeDetection: ChangeDetectionStrategy.OnPush
            }] }
];
/** @nocollapse */
GlobalFooterComponent.ctorParameters = () => [
    { type: Router },
    { type: Window, decorators: [{ type: Inject, args: [WINDOW,] }] }
];
GlobalFooterComponent.propDecorators = {
    links: [{ type: Input }],
    items: [{ type: ContentChildren, args: [GlobalFooterItemComponent,] }]
};

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
const COMPONENTS = [GlobalFooterComponent, GlobalFooterItemComponent];
class GlobalFooterModule {
}
GlobalFooterModule.decorators = [
    { type: NgModule, args: [{
                imports: [CommonModule, RouterModule, DelonUtilModule],
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

export { GlobalFooterComponent, GlobalFooterItemComponent, GlobalFooterModule };

//# sourceMappingURL=globalFooter.js.map