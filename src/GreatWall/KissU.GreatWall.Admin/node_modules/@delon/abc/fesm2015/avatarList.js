import { __decorate, __metadata } from 'tslib';
import { InputNumber } from '@delon/util';
import { CommonModule } from '@angular/common';
import { Component, Input, ChangeDetectionStrategy, ChangeDetectorRef, ContentChildren, NgModule } from '@angular/core';
import { NgZorroAntdModule } from 'ng-zorro-antd';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class AvatarListItemComponent {
}
AvatarListItemComponent.decorators = [
    { type: Component, args: [{
                selector: 'avatar-list-item, [avatar-list-item]',
                template: `<ng-content></ng-content>`
            }] }
];
AvatarListItemComponent.propDecorators = {
    src: [{ type: Input }],
    text: [{ type: Input }],
    icon: [{ type: Input }],
    tips: [{ type: Input }]
};

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
class AvatarListComponent {
    /**
     * @param {?} cdr
     */
    constructor(cdr) {
        this.cdr = cdr;
        this.inited = false;
        this.items = [];
        this.exceedCount = 0;
        this.cls = '';
        this.avatarSize = '';
        this.maxLength = 0;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set size(value) {
        this.cls = 'avatar-list__item' + (value === 'default' ? '' : ` avatar-list__${value}`);
        switch (value) {
            case 'large':
            case 'small':
            case 'default':
                this.avatarSize = value;
                break;
            default:
                this.avatarSize = 'small';
                break;
        }
    }
    /**
     * @private
     * @return {?}
     */
    gen() {
        const { _items } = this;
        /** @type {?} */
        const maxLength = this.maxLength > 0 ? this.maxLength : _items.length;
        /** @type {?} */
        const numOfChildren = _items.length;
        /** @type {?} */
        const numToShow = maxLength > 0 && maxLength >= numOfChildren ? numOfChildren : maxLength;
        this.items = _items.toArray().slice(0, numToShow);
        this.exceedCount = numToShow < numOfChildren ? numOfChildren - maxLength : 0;
        this.cdr.detectChanges();
    }
    /**
     * @return {?}
     */
    ngAfterViewInit() {
        this.gen();
        this.inited = true;
    }
    /**
     * @return {?}
     */
    ngOnChanges() {
        if (this.inited) {
            this.gen();
        }
    }
}
AvatarListComponent.decorators = [
    { type: Component, args: [{
                selector: 'avatar-list',
                template: "<ul class=\"avatar-list__wrap\">\n  <li *ngFor=\"let i of items\"\n      [class]=\"cls\">\n    <nz-tooltip *ngIf=\"i.tips\"\n                [nzTitle]=\"i.tips\">\n      <nz-avatar nz-tooltip\n                 [nzSrc]=\"i.src\"\n                 [nzText]=\"i.text\"\n                 [nzIcon]=\"i.icon\"\n                 [nzSize]=\"avatarSize\"></nz-avatar>\n    </nz-tooltip>\n    <nz-avatar *ngIf=\"!i.tips\"\n               [nzSrc]=\"i.src\"\n               [nzText]=\"i.text\"\n               [nzIcon]=\"i.icon\"\n               [nzSize]=\"avatarSize\"></nz-avatar>\n  </li>\n  <li *ngIf=\"exceedCount > 0\"\n      [class]=\"cls\">\n    <nz-avatar [nzSize]=\"avatarSize\"\n               style=\"cursor: auto\"\n               [ngStyle]=\"excessItemsStyle\"\n               [nzText]=\"'+' + exceedCount\"></nz-avatar>\n  </li>\n</ul>\n",
                host: { '[class.avatar-list]': 'true' },
                changeDetection: ChangeDetectionStrategy.OnPush
            }] }
];
/** @nocollapse */
AvatarListComponent.ctorParameters = () => [
    { type: ChangeDetectorRef }
];
AvatarListComponent.propDecorators = {
    _items: [{ type: ContentChildren, args: [AvatarListItemComponent, { descendants: false },] }],
    size: [{ type: Input }],
    maxLength: [{ type: Input }],
    excessItemsStyle: [{ type: Input }]
};
__decorate([
    InputNumber(),
    __metadata("design:type", Object)
], AvatarListComponent.prototype, "maxLength", void 0);

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
const COMPONENTS = [AvatarListComponent, AvatarListItemComponent];
class AvatarListModule {
}
AvatarListModule.decorators = [
    { type: NgModule, args: [{
                imports: [CommonModule, NgZorroAntdModule],
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

export { AvatarListItemComponent, AvatarListComponent, AvatarListModule };

//# sourceMappingURL=avatarList.js.map