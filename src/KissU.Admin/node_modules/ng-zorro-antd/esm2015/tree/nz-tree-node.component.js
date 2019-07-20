/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, Host, HostListener, Input, NgZone, Optional, Renderer2, TemplateRef, ViewChild } from '@angular/core';
import { fromEvent, Subject } from 'rxjs';
import { filter, takeUntil } from 'rxjs/operators';
import { collapseMotion, InputBoolean, NzNoAnimationDirective, NzTreeBaseService, NzTreeNode } from 'ng-zorro-antd/core';
export class NzTreeNodeComponent {
    /**
     * @param {?} nzTreeService
     * @param {?} ngZone
     * @param {?} renderer
     * @param {?} elRef
     * @param {?} cdr
     * @param {?=} noAnimation
     */
    constructor(nzTreeService, ngZone, renderer, elRef, cdr, noAnimation) {
        this.nzTreeService = nzTreeService;
        this.ngZone = ngZone;
        this.renderer = renderer;
        this.elRef = elRef;
        this.cdr = cdr;
        this.noAnimation = noAnimation;
        this.nzHideUnMatched = false;
        this.nzNoAnimation = false;
        this.nzSelectMode = false;
        this.nzShowIcon = false;
        // default var
        this.prefixCls = 'ant-tree';
        this.highlightKeys = [];
        this.nzNodeClass = {};
        this.nzNodeSwitcherClass = {};
        this.nzNodeContentClass = {};
        this.nzNodeCheckboxClass = {};
        this.nzNodeContentIconClass = {};
        this.nzNodeContentLoadingClass = {};
        /**
         * drag var
         */
        this.destroy$ = new Subject();
        this.dragPos = 2;
        this.dragPosClass = {
            '0': 'drag-over',
            '1': 'drag-over-gap-bottom',
            '-1': 'drag-over-gap-top'
        };
        /**
         * default set
         */
        this._searchValue = '';
        this._nzDraggable = false;
        this._nzExpandAll = false;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set nzDraggable(value) {
        this._nzDraggable = value;
        this.handDragEvent();
    }
    /**
     * @return {?}
     */
    get nzDraggable() {
        return this._nzDraggable;
    }
    /**
     * @deprecated use
     * nzExpandAll instead
     * @param {?} value
     * @return {?}
     */
    set nzDefaultExpandAll(value) {
        this._nzExpandAll = value;
        if (value && this.nzTreeNode && !this.nzTreeNode.isLeaf) {
            this.nzTreeNode.isExpanded = true;
        }
    }
    /**
     * @return {?}
     */
    get nzDefaultExpandAll() {
        return this._nzExpandAll;
    }
    // default set
    /**
     * @param {?} value
     * @return {?}
     */
    set nzExpandAll(value) {
        this._nzExpandAll = value;
        if (value && this.nzTreeNode && !this.nzTreeNode.isLeaf) {
            this.nzTreeNode.isExpanded = true;
        }
    }
    /**
     * @return {?}
     */
    get nzExpandAll() {
        return this._nzExpandAll;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set nzSearchValue(value) {
        this.highlightKeys = [];
        if (value && (/** @type {?} */ (this.nzTreeNode.title)).includes(value)) {
            // match the search value
            /** @type {?} */
            const index = this.nzTreeNode.title.indexOf(value);
            this.highlightKeys = [
                this.nzTreeNode.title.slice(0, index),
                this.nzTreeNode.title.slice(index + value.length, this.nzTreeNode.title.length)
            ];
        }
        this._searchValue = value;
    }
    /**
     * @return {?}
     */
    get nzSearchValue() {
        return this._searchValue;
    }
    /**
     * @return {?}
     */
    get nzIcon() {
        return this.nzTreeNode.icon;
    }
    /**
     * @return {?}
     */
    get canDraggable() {
        return this.nzDraggable && !this.nzTreeNode.isDisabled ? true : null;
    }
    /**
     * @return {?}
     */
    get isShowLineIcon() {
        return !this.nzTreeNode.isLeaf && this.nzShowLine;
    }
    /**
     * @return {?}
     */
    get isShowSwitchIcon() {
        return !this.nzTreeNode.isLeaf && !this.nzShowLine;
    }
    /**
     * @return {?}
     */
    get isSwitcherOpen() {
        return this.nzTreeNode.isExpanded && !this.nzTreeNode.isLeaf;
    }
    /**
     * @return {?}
     */
    get isSwitcherClose() {
        return !this.nzTreeNode.isExpanded && !this.nzTreeNode.isLeaf;
    }
    /**
     * @return {?}
     */
    get displayStyle() {
        // to hide unmatched nodes
        return this.nzSearchValue && this.nzHideUnMatched && !this.nzTreeNode.isMatched && !this.nzTreeNode.isExpanded
            ? 'none'
            : '';
    }
    /**
     * reset node class
     * @return {?}
     */
    setClassMap() {
        this.prefixCls = this.nzSelectMode ? 'ant-select-tree' : 'ant-tree';
        this.nzNodeClass = {
            [`${this.prefixCls}-treenode-disabled`]: this.nzTreeNode.isDisabled,
            [`${this.prefixCls}-treenode-switcher-open`]: this.isSwitcherOpen,
            [`${this.prefixCls}-treenode-switcher-close`]: this.isSwitcherClose,
            [`${this.prefixCls}-treenode-checkbox-checked`]: this.nzTreeNode.isChecked,
            [`${this.prefixCls}-treenode-checkbox-indeterminate`]: this.nzTreeNode.isHalfChecked,
            [`${this.prefixCls}-treenode-selected`]: this.nzTreeNode.isSelected,
            [`${this.prefixCls}-treenode-loading`]: this.nzTreeNode.isLoading
        };
        this.nzNodeSwitcherClass = {
            [`${this.prefixCls}-switcher`]: true,
            [`${this.prefixCls}-switcher-noop`]: this.nzTreeNode.isLeaf,
            [`${this.prefixCls}-switcher_open`]: this.isSwitcherOpen,
            [`${this.prefixCls}-switcher_close`]: this.isSwitcherClose
        };
        this.nzNodeCheckboxClass = {
            [`${this.prefixCls}-checkbox`]: true,
            [`${this.prefixCls}-checkbox-checked`]: this.nzTreeNode.isChecked,
            [`${this.prefixCls}-checkbox-indeterminate`]: this.nzTreeNode.isHalfChecked,
            [`${this.prefixCls}-checkbox-disabled`]: this.nzTreeNode.isDisabled || this.nzTreeNode.isDisableCheckbox
        };
        this.nzNodeContentClass = {
            [`${this.prefixCls}-node-content-wrapper`]: true,
            [`${this.prefixCls}-node-content-wrapper-open`]: this.isSwitcherOpen,
            [`${this.prefixCls}-node-content-wrapper-close`]: this.isSwitcherClose,
            [`${this.prefixCls}-node-selected`]: this.nzTreeNode.isSelected
        };
        this.nzNodeContentIconClass = {
            [`${this.prefixCls}-iconEle`]: true,
            [`${this.prefixCls}-icon__customize`]: true
        };
        this.nzNodeContentLoadingClass = {
            [`${this.prefixCls}-iconEle`]: true
        };
    }
    /**
     * @param {?} event
     * @return {?}
     */
    onMousedown(event) {
        if (this.nzSelectMode) {
            event.preventDefault();
        }
    }
    /**
     * click node to select, 200ms to dbl click
     * @param {?} event
     * @return {?}
     */
    nzClick(event) {
        event.preventDefault();
        event.stopPropagation();
        if (this.nzTreeNode.isSelectable && !this.nzTreeNode.isDisabled) {
            this.nzTreeNode.isSelected = !this.nzTreeNode.isSelected;
        }
        /** @type {?} */
        const eventNext = this.nzTreeService.formatEvent('click', this.nzTreeNode, event);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    }
    /**
     * @param {?} event
     * @return {?}
     */
    nzDblClick(event) {
        event.preventDefault();
        event.stopPropagation();
        /** @type {?} */
        const eventNext = this.nzTreeService.formatEvent('dblclick', this.nzTreeNode, event);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    }
    /**
     * @param {?} event
     * @return {?}
     */
    nzContextMenu(event) {
        event.preventDefault();
        event.stopPropagation();
        /** @type {?} */
        const eventNext = this.nzTreeService.formatEvent('contextmenu', this.nzTreeNode, event);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    }
    /**
     * collapse node
     * @param {?} event
     * @return {?}
     */
    _clickExpand(event) {
        event.preventDefault();
        event.stopPropagation();
        if (!this.nzTreeNode.isLoading && !this.nzTreeNode.isLeaf) {
            // set async state
            if (this.nzAsyncData && this.nzTreeNode.children.length === 0 && !this.nzTreeNode.isExpanded) {
                this.nzTreeNode.isLoading = true;
            }
            this.nzTreeNode.isExpanded = !this.nzTreeNode.isExpanded;
            /** @type {?} */
            const eventNext = this.nzTreeService.formatEvent('expand', this.nzTreeNode, event);
            (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
        }
    }
    /**
     * check node
     * @param {?} event
     * @return {?}
     */
    _clickCheckBox(event) {
        event.preventDefault();
        event.stopPropagation();
        // return if node is disabled
        if (this.nzTreeNode.isDisabled || this.nzTreeNode.isDisableCheckbox) {
            return;
        }
        this.nzTreeNode.isChecked = !this.nzTreeNode.isChecked;
        this.nzTreeNode.isHalfChecked = false;
        if (!this.nzTreeService.isCheckStrictly) {
            this.nzTreeService.conduct(this.nzTreeNode);
        }
        /** @type {?} */
        const eventNext = this.nzTreeService.formatEvent('check', this.nzTreeNode, event);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    }
    /**
     * drag event
     * @return {?}
     */
    clearDragClass() {
        /** @type {?} */
        const dragClass = ['drag-over-gap-top', 'drag-over-gap-bottom', 'drag-over'];
        dragClass.forEach((/**
         * @param {?} e
         * @return {?}
         */
        e => {
            this.renderer.removeClass(this.dragElement.nativeElement, e);
        }));
    }
    /**
     * @param {?} e
     * @return {?}
     */
    handleDragStart(e) {
        e.stopPropagation();
        try {
            // ie throw error
            // firefox-need-it
            (/** @type {?} */ (e.dataTransfer)).setData('text/plain', (/** @type {?} */ (this.nzTreeNode.key)));
        }
        catch (error) {
            // empty
        }
        this.nzTreeService.setSelectedNode(this.nzTreeNode);
        this.nzTreeNode.isExpanded = false;
        /** @type {?} */
        const eventNext = this.nzTreeService.formatEvent('dragstart', this.nzTreeNode, e);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    }
    /**
     * @param {?} e
     * @return {?}
     */
    handleDragEnter(e) {
        e.preventDefault();
        e.stopPropagation();
        // reset position
        this.dragPos = 2;
        this.ngZone.run((/**
         * @return {?}
         */
        () => {
            /** @type {?} */
            const node = this.nzTreeService.getSelectedNode();
            if (node && node.key !== this.nzTreeNode.key && !this.nzTreeNode.isExpanded && !this.nzTreeNode.isLeaf) {
                this.nzTreeNode.isExpanded = true;
            }
            /** @type {?} */
            const eventNext = this.nzTreeService.formatEvent('dragenter', this.nzTreeNode, e);
            (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
        }));
    }
    /**
     * @param {?} e
     * @return {?}
     */
    handleDragOver(e) {
        e.preventDefault();
        e.stopPropagation();
        /** @type {?} */
        const dropPosition = this.nzTreeService.calcDropPosition(e);
        if (this.dragPos !== dropPosition) {
            this.clearDragClass();
            this.dragPos = dropPosition;
            // leaf node will pass
            if (!(this.dragPos === 0 && this.nzTreeNode.isLeaf)) {
                this.renderer.addClass(this.dragElement.nativeElement, this.dragPosClass[this.dragPos]);
            }
        }
        /** @type {?} */
        const eventNext = this.nzTreeService.formatEvent('dragover', this.nzTreeNode, e);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    }
    /**
     * @param {?} e
     * @return {?}
     */
    handleDragLeave(e) {
        e.stopPropagation();
        this.ngZone.run((/**
         * @return {?}
         */
        () => {
            this.clearDragClass();
        }));
        /** @type {?} */
        const eventNext = this.nzTreeService.formatEvent('dragleave', this.nzTreeNode, e);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    }
    /**
     * @param {?} e
     * @return {?}
     */
    handleDragDrop(e) {
        e.preventDefault();
        e.stopPropagation();
        this.ngZone.run((/**
         * @return {?}
         */
        () => {
            this.clearDragClass();
            /** @type {?} */
            const node = this.nzTreeService.getSelectedNode();
            if (!node || (node && node.key === this.nzTreeNode.key) || (this.dragPos === 0 && this.nzTreeNode.isLeaf)) {
                return;
            }
            // pass if node is leafNo
            /** @type {?} */
            const dropEvent = this.nzTreeService.formatEvent('drop', this.nzTreeNode, e);
            /** @type {?} */
            const dragEndEvent = this.nzTreeService.formatEvent('dragend', this.nzTreeNode, e);
            if (this.nzBeforeDrop) {
                this.nzBeforeDrop({
                    dragNode: (/** @type {?} */ (this.nzTreeService.getSelectedNode())),
                    node: this.nzTreeNode,
                    pos: this.dragPos
                }).subscribe((/**
                 * @param {?} canDrop
                 * @return {?}
                 */
                (canDrop) => {
                    if (canDrop) {
                        this.nzTreeService.dropAndApply(this.nzTreeNode, this.dragPos);
                    }
                    (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(dropEvent);
                    (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(dragEndEvent);
                }));
            }
            else if (this.nzTreeNode) {
                this.nzTreeService.dropAndApply(this.nzTreeNode, this.dragPos);
                (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(dropEvent);
            }
        }));
    }
    /**
     * @param {?} e
     * @return {?}
     */
    handleDragEnd(e) {
        e.stopPropagation();
        this.ngZone.run((/**
         * @return {?}
         */
        () => {
            // if user do not custom beforeDrop
            if (!this.nzBeforeDrop) {
                /** @type {?} */
                const eventNext = this.nzTreeService.formatEvent('dragend', this.nzTreeNode, e);
                (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
            }
        }));
    }
    /**
     * 监听拖拽事件
     * @return {?}
     */
    handDragEvent() {
        this.ngZone.runOutsideAngular((/**
         * @return {?}
         */
        () => {
            if (this.nzDraggable) {
                this.destroy$ = new Subject();
                fromEvent(this.elRef.nativeElement, 'dragstart')
                    .pipe(takeUntil(this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                (e) => this.handleDragStart(e)));
                fromEvent(this.elRef.nativeElement, 'dragenter')
                    .pipe(takeUntil(this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                (e) => this.handleDragEnter(e)));
                fromEvent(this.elRef.nativeElement, 'dragover')
                    .pipe(takeUntil(this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                (e) => this.handleDragOver(e)));
                fromEvent(this.elRef.nativeElement, 'dragleave')
                    .pipe(takeUntil(this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                (e) => this.handleDragLeave(e)));
                fromEvent(this.elRef.nativeElement, 'drop')
                    .pipe(takeUntil(this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                (e) => this.handleDragDrop(e)));
                fromEvent(this.elRef.nativeElement, 'dragend')
                    .pipe(takeUntil(this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                (e) => this.handleDragEnd(e)));
            }
            else {
                this.destroy$.next();
                this.destroy$.complete();
            }
        }));
    }
    /**
     * @param {?} value
     * @return {?}
     */
    isTemplateRef(value) {
        return value instanceof TemplateRef;
    }
    /**
     * @return {?}
     */
    markForCheck() {
        this.cdr.markForCheck();
    }
    /**
     * @return {?}
     */
    ngOnInit() {
        // init expanded / selected / checked list
        if (this.nzTreeNode.isSelected) {
            this.nzTreeService.setNodeActive(this.nzTreeNode);
        }
        if (this.nzTreeNode.isExpanded) {
            this.nzTreeService.setExpandedNodeList(this.nzTreeNode);
        }
        if (this.nzTreeNode.isChecked) {
            this.nzTreeService.setCheckedNodeList(this.nzTreeNode);
        }
        // TODO
        this.nzTreeNode.component = this;
        this.nzTreeService
            .eventTriggerChanged()
            .pipe(filter((/**
         * @param {?} data
         * @return {?}
         */
        data => (/** @type {?} */ (data.node)).key === this.nzTreeNode.key)), takeUntil(this.destroy$))
            .subscribe((/**
         * @return {?}
         */
        () => {
            this.setClassMap();
            this.markForCheck();
        }));
        this.setClassMap();
    }
    /**
     * @return {?}
     */
    ngOnChanges() {
        this.setClassMap();
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this.destroy$.next();
        this.destroy$.complete();
    }
}
NzTreeNodeComponent.decorators = [
    { type: Component, args: [{
                selector: 'nz-tree-node',
                exportAs: 'nzTreeNode',
                template: "<li\n  #dragElement\n  role=\"treeitem\"\n  [style.display]=\"displayStyle\"\n  [ngClass]=\"nzNodeClass\">\n  <ng-container *ngIf=\"nzShowExpand\">\n    <span\n      [ngClass]=\"nzNodeSwitcherClass\"\n      (click)=\"_clickExpand($event)\">\n      <ng-container *ngIf=\"isShowSwitchIcon\">\n        <ng-container *ngIf=\"!nzTreeNode.isLoading\">\n          <ng-template\n            *ngIf=\"isTemplateRef(nzExpandedIcon)\"\n            [ngTemplateOutlet]=\"nzExpandedIcon\"\n            [ngTemplateOutletContext]=\"{ $implicit: nzTreeNode }\">\n          </ng-template>\n          <i\n            *ngIf=\"!isTemplateRef(nzExpandedIcon)\" \n            nz-icon \n            type=\"caret-down\"           \n            [class.ant-select-switcher-icon]=\"nzSelectMode\"\n            [class.ant-tree-switcher-icon]=\"!nzSelectMode\">\n          </i>\n        </ng-container>\n        <i *ngIf=\"nzTreeNode.isLoading\" nz-icon type=\"loading\" [spin]=\"true\" class=\"ant-tree-switcher-loading-icon\"></i>\n      </ng-container>\n      <ng-container *ngIf=\"nzShowLine\">\n        <ng-template\n          *ngIf=\"isTemplateRef(nzExpandedIcon)\"\n          [ngTemplateOutlet]=\"nzExpandedIcon\"\n          [ngTemplateOutletContext]=\"{ $implicit: nzTreeNode }\">\n        </ng-template>\n        <ng-container *ngIf=\"!isTemplateRef(nzExpandedIcon)\">\n          <i *ngIf=\"isShowLineIcon\" nz-icon [type]=\"isSwitcherOpen ? 'minus-square' : 'plus-square'\" class=\"ant-tree-switcher-line-icon\"></i>\n          <i *ngIf=\"!isShowLineIcon\" nz-icon type=\"file\" class=\"ant-tree-switcher-line-icon\"></i>\n        </ng-container>\n      </ng-container>\n    </span>\n  </ng-container>\n  <ng-container *ngIf=\"nzCheckable\">\n    <span\n      [ngClass]=\"nzNodeCheckboxClass\"\n      (click)=\"_clickCheckBox($event)\">\n      <span [class.ant-tree-checkbox-inner]=\"!nzSelectMode\"\n            [class.ant-select-tree-checkbox-inner]=\"nzSelectMode\"></span>\n    </span>\n  </ng-container>\n  <ng-container *ngIf=\"!nzTreeTemplate\">\n    <span\n      title=\"{{nzTreeNode.title}}\"\n      [attr.draggable]=\"canDraggable\"\n      [attr.aria-grabbed]=\"canDraggable\"\n      [ngClass]=\"nzNodeContentClass\"\n      [class.draggable]=\"canDraggable\">\n      <span\n        *ngIf=\"nzTreeNode.icon && nzShowIcon\"\n        [class.ant-tree-icon__open]=\"isSwitcherOpen\"\n        [class.ant-tree-icon__close]=\"isSwitcherClose\"\n        [class.ant-tree-icon_loading]=\"nzTreeNode.isLoading\"\n        [ngClass]=\"nzNodeContentLoadingClass\">\n        <span\n          [ngClass]=\"nzNodeContentIconClass\">\n          <i nz-icon *ngIf=\"nzIcon\" [type]=\"nzIcon\"></i>\n        </span>\n      </span>\n      <span class=\"ant-tree-title\">\n        <ng-container *ngIf=\"nzTreeNode.isMatched\">\n          <span>\n            {{highlightKeys[0]}}<span class=\"font-highlight\">{{nzSearchValue}}</span>{{highlightKeys[1]}}\n          </span>\n        </ng-container>\n        <ng-container *ngIf=\"!nzTreeNode.isMatched\">\n          {{nzTreeNode.title}}\n        </ng-container>\n      </span>\n    </span>\n  </ng-container>\n  <ng-template\n    [ngTemplateOutlet]=\"nzTreeTemplate\"\n    [ngTemplateOutletContext]=\"{ $implicit: nzTreeNode }\">\n  </ng-template>\n\n  <ul\n    role=\"group\"\n    class=\"ant-tree-child-tree\"\n    [class.ant-tree-child-tree-open]=\"!nzSelectMode || nzTreeNode.isExpanded\"\n    data-expanded=\"true\"\n    [@.disabled]=\"noAnimation?.nzNoAnimation\"\n    [@collapseMotion]=\"nzTreeNode.isExpanded ? 'expanded' : 'collapsed'\">\n    <nz-tree-node\n      *ngFor=\"let node of nzTreeNode.getChildren()\"\n      [nzTreeNode]=\"node\"\n      [nzShowExpand]=\"nzShowExpand\"\n      [nzNoAnimation]=\"noAnimation?.nzNoAnimation\"\n      [nzSelectMode]=\"nzSelectMode\"\n      [nzShowLine]=\"nzShowLine\"\n      [nzExpandedIcon]=\"nzExpandedIcon\"\n      [nzDraggable]=\"nzDraggable\"\n      [nzCheckable]=\"nzCheckable\"\n      [nzAsyncData]=\"nzAsyncData\"\n      [nzExpandAll]=\"nzExpandAll\"\n      [nzDefaultExpandAll]=\"nzDefaultExpandAll\"\n      [nzShowIcon]=\"nzShowIcon\"\n      [nzSearchValue]=\"nzSearchValue\"\n      [nzHideUnMatched]=\"nzHideUnMatched\"\n      [nzBeforeDrop]=\"nzBeforeDrop\"\n      [nzTreeTemplate]=\"nzTreeTemplate\">\n    </nz-tree-node>\n  </ul>\n</li>",
                changeDetection: ChangeDetectionStrategy.OnPush,
                preserveWhitespaces: false,
                animations: [collapseMotion]
            }] }
];
/** @nocollapse */
NzTreeNodeComponent.ctorParameters = () => [
    { type: NzTreeBaseService },
    { type: NgZone },
    { type: Renderer2 },
    { type: ElementRef },
    { type: ChangeDetectorRef },
    { type: NzNoAnimationDirective, decorators: [{ type: Host }, { type: Optional }] }
];
NzTreeNodeComponent.propDecorators = {
    dragElement: [{ type: ViewChild, args: ['dragElement',] }],
    nzTreeNode: [{ type: Input }],
    nzShowLine: [{ type: Input }],
    nzShowExpand: [{ type: Input }],
    nzCheckable: [{ type: Input }],
    nzAsyncData: [{ type: Input }],
    nzHideUnMatched: [{ type: Input }],
    nzNoAnimation: [{ type: Input }],
    nzSelectMode: [{ type: Input }],
    nzShowIcon: [{ type: Input }],
    nzExpandedIcon: [{ type: Input }],
    nzTreeTemplate: [{ type: Input }],
    nzBeforeDrop: [{ type: Input }],
    nzDraggable: [{ type: Input }],
    nzDefaultExpandAll: [{ type: Input }],
    nzExpandAll: [{ type: Input }],
    nzSearchValue: [{ type: Input }],
    onMousedown: [{ type: HostListener, args: ['mousedown', ['$event'],] }],
    nzClick: [{ type: HostListener, args: ['click', ['$event'],] }],
    nzDblClick: [{ type: HostListener, args: ['dblclick', ['$event'],] }],
    nzContextMenu: [{ type: HostListener, args: ['contextmenu', ['$event'],] }]
};
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzTreeNodeComponent.prototype, "nzShowLine", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzTreeNodeComponent.prototype, "nzShowExpand", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzTreeNodeComponent.prototype, "nzCheckable", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Boolean)
], NzTreeNodeComponent.prototype, "nzAsyncData", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzTreeNodeComponent.prototype, "nzHideUnMatched", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzTreeNodeComponent.prototype, "nzNoAnimation", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzTreeNodeComponent.prototype, "nzSelectMode", void 0);
tslib_1.__decorate([
    InputBoolean(),
    tslib_1.__metadata("design:type", Object)
], NzTreeNodeComponent.prototype, "nzShowIcon", void 0);
if (false) {
    /** @type {?} */
    NzTreeNodeComponent.prototype.dragElement;
    /**
     * for global property
     * @type {?}
     */
    NzTreeNodeComponent.prototype.nzTreeNode;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzShowLine;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzShowExpand;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzCheckable;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzAsyncData;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzHideUnMatched;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzNoAnimation;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzSelectMode;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzShowIcon;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzExpandedIcon;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzTreeTemplate;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzBeforeDrop;
    /** @type {?} */
    NzTreeNodeComponent.prototype.prefixCls;
    /** @type {?} */
    NzTreeNodeComponent.prototype.highlightKeys;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzNodeClass;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzNodeSwitcherClass;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzNodeContentClass;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzNodeCheckboxClass;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzNodeContentIconClass;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzNodeContentLoadingClass;
    /**
     * drag var
     * @type {?}
     */
    NzTreeNodeComponent.prototype.destroy$;
    /** @type {?} */
    NzTreeNodeComponent.prototype.dragPos;
    /** @type {?} */
    NzTreeNodeComponent.prototype.dragPosClass;
    /**
     * default set
     * @type {?}
     */
    NzTreeNodeComponent.prototype._searchValue;
    /** @type {?} */
    NzTreeNodeComponent.prototype._nzDraggable;
    /** @type {?} */
    NzTreeNodeComponent.prototype._nzExpandAll;
    /** @type {?} */
    NzTreeNodeComponent.prototype.nzTreeService;
    /**
     * @type {?}
     * @private
     */
    NzTreeNodeComponent.prototype.ngZone;
    /**
     * @type {?}
     * @private
     */
    NzTreeNodeComponent.prototype.renderer;
    /**
     * @type {?}
     * @private
     */
    NzTreeNodeComponent.prototype.elRef;
    /**
     * @type {?}
     * @private
     */
    NzTreeNodeComponent.prototype.cdr;
    /** @type {?} */
    NzTreeNodeComponent.prototype.noAnimation;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotdHJlZS1ub2RlLmNvbXBvbmVudC5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvdHJlZS8iLCJzb3VyY2VzIjpbIm56LXRyZWUtbm9kZS5jb21wb25lbnQudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7O0FBUUEsT0FBTyxFQUNMLHVCQUF1QixFQUN2QixpQkFBaUIsRUFDakIsU0FBUyxFQUNULFVBQVUsRUFDVixJQUFJLEVBQ0osWUFBWSxFQUNaLEtBQUssRUFDTCxNQUFNLEVBSU4sUUFBUSxFQUNSLFNBQVMsRUFDVCxXQUFXLEVBQ1gsU0FBUyxFQUNWLE1BQU0sZUFBZSxDQUFDO0FBQ3ZCLE9BQU8sRUFBRSxTQUFTLEVBQWMsT0FBTyxFQUFFLE1BQU0sTUFBTSxDQUFDO0FBQ3RELE9BQU8sRUFBRSxNQUFNLEVBQUUsU0FBUyxFQUFFLE1BQU0sZ0JBQWdCLENBQUM7QUFFbkQsT0FBTyxFQUNMLGNBQWMsRUFDZCxZQUFZLEVBRVosc0JBQXNCLEVBQ3RCLGlCQUFpQixFQUNqQixVQUFVLEVBQ1gsTUFBTSxvQkFBb0IsQ0FBQztBQVU1QixNQUFNLE9BQU8sbUJBQW1COzs7Ozs7Ozs7SUFvWjlCLFlBQ1MsYUFBZ0MsRUFDL0IsTUFBYyxFQUNkLFFBQW1CLEVBQ25CLEtBQWlCLEVBQ2pCLEdBQXNCLEVBQ0gsV0FBb0M7UUFMeEQsa0JBQWEsR0FBYixhQUFhLENBQW1CO1FBQy9CLFdBQU0sR0FBTixNQUFNLENBQVE7UUFDZCxhQUFRLEdBQVIsUUFBUSxDQUFXO1FBQ25CLFVBQUssR0FBTCxLQUFLLENBQVk7UUFDakIsUUFBRyxHQUFILEdBQUcsQ0FBbUI7UUFDSCxnQkFBVyxHQUFYLFdBQVcsQ0FBeUI7UUEvWXhDLG9CQUFlLEdBQUcsS0FBSyxDQUFDO1FBQ3hCLGtCQUFhLEdBQUcsS0FBSyxDQUFDO1FBQ3RCLGlCQUFZLEdBQUcsS0FBSyxDQUFDO1FBQ3JCLGVBQVUsR0FBRyxLQUFLLENBQUM7O1FBK0Q1QyxjQUFTLEdB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SUFBSSxPQUFPLEVBQUUsQ0FBQztnQkFDOUIsU0FBUyxDQUFZLElBQUksQ0FBQyxLQUFLLENBQUMsYUFBYSxFQUFFLFdBQVcsQ0FBQztxQkFDeEQsSUFBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMsUUFBUSxDQUFDLENBQUM7cUJBQzlCLFNBQVM7Ozs7Z0JBQUMsQ0FBQyxDQUFZLEVBQUUsRUFBRSxDQUFDLElBQUksQ0FBQyxlQUFlLENBQUMsQ0FBQyxDQUFDLEVBQUMsQ0FBQztnQkFDeEQsU0FBUyxDQUFZLElBQUksQ0FBQyxLQUFLLENBQUMsYUFBYSxFQUFFLFdBQVcsQ0FBQztxQkFDeEQsSUFBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMsUUFBUSxDQUFDLENBQUM7cUJBQzlCLFNBQVM7Ozs7Z0JBQUMsQ0FBQyxDQUFZLEVBQUUsRUFBRSxDQUFDLElBQUksQ0FBQyxlQUFlLENBQUMsQ0FBQyxDQUFDLEVBQUMsQ0FBQztnQkFDeEQsU0FBUyxDQUFZLElBQUksQ0FBQyxLQUFLLENBQUMsYUFBYSxFQUFFLFVBQVUsQ0FBQztxQkFDdkQsSUFBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMsUUFBUSxDQUFDLENBQUM7cUJBQzlCLFNBQVM7Ozs7Z0JBQUMsQ0FBQyxDQUFZLEVBQUUsRUFBRSxDQUFDLElBQUksQ0FBQyxjQUFjLENBQUMsQ0FBQyxDQUFDLEVBQUMsQ0FBQztnQkFDdkQsU0FBUyxDQUFZLElBQUksQ0FBQyxLQUFLLENBQUMsYUFBYSxFQUFFLFdBQVcsQ0FBQztxQkFDeEQsSUFBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMsUUFBUSxDQUFDLENBQUM7cUJBQzlCLFNBQVM7Ozs7Z0JBQUMsQ0FBQyxDQUFZLEVBQUUsRUFBRSxDQUFDLElBQUksQ0FBQyxlQUFlLENBQUMsQ0FBQyxDQUFDLEVBQUMsQ0FBQztnQkFDeEQsU0FBUyxDQUFZLElBQUksQ0FBQyxLQUFLLENBQUMsYUFBYSxFQUFFLE1BQU0sQ0FBQztxQkFDbkQsSUFBSSxDQUFDLFNBQVMsQ0FBQyxJQUFJLENBQUMsUUFBUSxD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LDJDQUFxQjs7SUFDckIsMkNBQXFCOztJQStTbkIsNENBQXVDOzs7OztJQUN2QyxxQ0FBc0I7Ozs7O0lBQ3RCLHVDQUEyQjs7Ozs7SUFDM0Isb0NBQXlCOzs7OztJQUN6QixrQ0FBOEI7O0lBQzlCLDBDQUErRCIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gIENvbXBvbmVudCxcbiAgRWxlbWVudFJlZixcbiAgSG9zdCxcbiAgSG9zdExpc3RlbmVyLFxuICBJbnB1dCxcbiAgTmdab25lLFxuICBPbkNoYW5nZXMsXG4gIE9uRGVzdHJveSxcbiAgT25Jbml0LFxuICBPcHRpb25hbCxcbiAgUmVuZGVyZXIyLFxuICBUZW1wbGF0ZVJlZixcbiAgVmlld0NoaWxkXG59IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgZnJvbUV2ZW50LCBPYnNlcnZhYmxlLCBTdWJqZWN0IH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyBmaWx0ZXIsIHRha2VVbnRpbCB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuaW1wb3J0IHtcbiAgY29sbGFwc2VNb3Rpb24sXG4gIElucHV0Qm9vbGVhbixcbiAgTnpGb3JtYXRCZWZvcmVEcm9wRXZlbnQsXG4gIE56Tm9BbmltYXRpb25EaXJlY3RpdmUsXG4gIE56VHJlZUJhc2VTZXJ2aWNlLFxuICBOelRyZWVOb2RlXG59IGZyb20gJ25nLXpvcnJvLWFudGQvY29yZSc7XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ256LXRyZWUtbm9kZScsXG4gIGV4cG9ydEFzOiAnbnpUcmVlTm9kZScsXG4gIHRlbXBsYXRlVXJsOiAnLi9uei10cmVlLW5vZGUuY29tcG9uZW50Lmh0bWwnLFxuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbiAgcHJlc2VydmVXaGl0ZXNwYWNlczogZmFsc2UsXG4gIGFuaW1hdGlvbnM6IFtjb2xsYXBzZU1vdGlvbl1cbn0pXG5leHBvcnQgY2xhc3MgTnpUcmVlTm9kZUNvbXBvbmVudCBpbXBsZW1lbnRzIE9uSW5pdCwgT25DaGFuZ2VzLCBPbkRlc3Ryb3kge1xuICBAVmlld0NoaWxkKCdkcmFnRWxlbWVudCcpIGRyYWdFbGVtZW50OiBFbGVtZW50UmVmO1xuXG4gIC8qKlxuICAgKiBmb3IgZ2xvYmFsIHByb3BlcnR5XG4gICAqL1xuICBASW5wdXQoKSBuelRyZWVOb2RlOiBOelRyZWVOb2RlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpTaG93TGluZTogYm9vbGVhbjtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56U2hvd0V4cGFuZDogYm9vbGVhbjtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56Q2hlY2thYmxlOiBib29sZWFuO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpBc3luY0RhdGE6IGJvb2xlYW47XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekhpZGVVbk1hdGNoZWQgPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56Tm9BbmltYXRpb24gPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56U2VsZWN0TW9kZSA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpTaG93SWNvbiA9IGZhbHNlO1xuICBASW5wdXQoKSBuekV4cGFuZGVkSWNvbjogVGVtcGxhdGVSZWY8eyAkaW1wbGljaXQ6IE56VHJlZU5vZGUgfT47XG4gIEBJbnB1dCgpIG56VHJlZVRlbXBsYXRlOiBUZW1wbGF0ZVJlZjx7ICRpbXBsaWNpdDogTnpUcmVlTm9kZSB9PjtcbiAgQElucHV0KCkgbnpCZWZvcmVEcm9wOiAoY29uZmlybTogTnpGb3JtYXRCZWZvcmVEcm9wRXZlbnQpID0+IE9ic2VydmFibGU8Ym9vbGVhbj47XG5cbiAgQElucHV0KClcbiAgc2V0IG56RHJhZ2dhYmxlKHZhbHVlOiBib29sZWFuKSB7XG4gICAgdGhpcy5fbnpEcmFnZ2FibGUgPSB2YWx1ZTtcbiAgICB0aGlzLmhhbmREcmFnRXZlbnQoKTtcbiAgfVxuXG4gIGdldCBuekRyYWdnYWJsZSgpOiBib29sZWFuIHtcbiAgICByZXR1cm4gdGhpcy5fbnpEcmFnZ2FibGU7XG4gIH1cblxuICAvKipcbiAgICogQGRlcHJlY2F0ZWQgdXNlXG4gICAqIG56RXhwYW5kQWxsIGluc3RlYWRcbiAgICovXG4gIEBJbnB1dCgpXG4gIHNldCBuekRlZmF1bHRFeHBhbmRBbGwodmFsdWU6IGJvb2xlYW4pIHtcbiAgICB0aGlzLl9uekV4cGFuZEFsbCA9IHZhbHVlO1xuICAgIGlmICh2YWx1ZSAmJiB0aGlzLm56VHJlZU5vZGUgJiYgIXRoaXMubnpUcmVlTm9kZS5pc0xlYWYpIHtcbiAgICAgIHRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkID0gdHJ1ZTtcbiAgICB9XG4gIH1cblxuICBnZXQgbnpEZWZhdWx0RXhwYW5kQWxsKCk6IGJvb2xlYW4ge1xuICAgIHJldHVybiB0aGlzLl9uekV4cGFuZEFsbDtcbiAgfVxuXG4gIC8vIGRlZmF1bHQgc2V0XG4gIEBJbnB1dCgpXG4gIHNldCBuekV4cGFuZEFsbCh2YWx1ZTogYm9vbGVhbikge1xuICAgIHRoaXMuX256RXhwYW5kQWxsID0gdmFsdWU7XG4gICAgaWYgKHZhbHVlICYmIHRoaXMubnpUcmVlTm9kZSAmJiAhdGhpcy5uelRyZWVOb2RlLmlzTGVhZikge1xuICAgICAgdGhpcy5uelRyZWVOb2RlLmlzRXhwYW5kZWQgPSB0cnVlO1xuICAgIH1cbiAgfVxuXG4gIGdldCBuekV4cGFuZEFsbCgpOiBib29sZWFuIHtcbiAgICByZXR1cm4gdGhpcy5fbnpFeHBhbmRBbGw7XG4gIH1cblxuICBASW5wdXQoKVxuICBzZXQgbnpTZWFyY2hWYWx1ZSh2YWx1ZTogc3RyaW5nKSB7XG4gICAgdGhpcy5oaWdobGlnaHRLZXlzID0gW107XG4gICAgaWYgKHZhbHVlICYmIHRoaXMubnpUcmVlTm9kZS50aXRsZSEuaW5jbHVkZXModmFsdWUpKSB7XG4gICAgICAvLyBtYXRjaCB0aGUgc2VhcmNoIHZhbHVlXG4gICAgICBjb25zdCBpbmRleCA9IHRoaXMubnpUcmVlTm9kZS50aXRsZS5pbmRleE9mKHZhbHVlKTtcbiAgICAgIHRoaXMuaGlnaGxpZ2h0S2V5cyA9IFtcbiAgICAgICAgdGhpcy5uelRyZWVOb2RlLnRpdGxlLnNsaWNlKDAsIGluZGV4KSxcbiAgICAgICAgdGhpcy5uelRyZWVOb2RlLnRpdGxlLnNsaWNlKGluZGV4ICsgdmFsdWUubGVuZ3RoLCB0aGlzLm56VHJlZU5vZGUudGl0bGUubGVuZ3RoKVxuICAgICAgXTtcbiAgICB9XG4gICAgdGhpcy5fc2VhcmNoVmFsdWUgPSB2YWx1ZTtcbiAgfVxuXG4gIGdldCBuelNlYXJjaFZhbHVlKCk6IHN0cmluZyB7XG4gICAgcmV0dXJuIHRoaXMuX3NlYXJjaFZhbHVlO1xuICB9XG5cbiAgLy8gZGVmYXVsdCB2YXJcbiAgcHJlZml4Q2xzID0gJ2FudC10cmVlJztcbiAgaGlnaGxpZ2h0S2V5czogc3RyaW5nW10gPSBbXTtcbiAgbnpOb2RlQ2xhc3MgPSB7fTtcbiAgbnpOb2RlU3dpdGNoZXJDbGFzcyA9IHt9O1xuICBuek5vZGVDb250ZW50Q2xhc3MgPSB7fTtcbiAgbnpOb2RlQ2hlY2tib3hDbGFzcyA9IHt9O1xuICBuek5vZGVDb250ZW50SWNvbkNsYXNzID0ge307XG4gIG56Tm9kZUNvbnRlbnRMb2FkaW5nQ2xhc3MgPSB7fTtcblxuICAvKipcbiAgICogZHJhZyB2YXJcbiAgICovXG4gIGRlc3Ryb3kkID0gbmV3IFN1YmplY3QoKTtcbiAgZHJhZ1BvcyA9IDI7XG4gIGRyYWdQb3NDbGFzczogeyBba2V5OiBzdHJpbmddOiBzdHJpbmcgfSA9IHtcbiAgICAnMCc6ICdkcmFnLW92ZXInLFxuICAgICcxJzogJ2RyYWctb3Zlci1nYXAtYm90dG9tJyxcbiAgICAnLTEnOiAnZHJhZy1vdmVyLWdhcC10b3AnXG4gIH07XG5cbiAgLyoqXG4gICAqIGRlZmF1bHQgc2V0XG4gICAqL1xuICBfc2VhcmNoVmFsdWUgPSAnJztcbiAgX256RHJhZ2dhYmxlID0gZmFsc2U7XG4gIF9uekV4cGFuZEFsbCA9IGZhbHNlO1xuXG4gIGdldCBuekljb24oKTogc3RyaW5nIHtcbiAgICByZXR1cm4gdGhpcy5uelRyZWVOb2RlLmljb247XG4gIH1cblxuICBnZXQgY2FuRHJhZ2dhYmxlKCk6IGJvb2xlYW4gfCBudWxsIHtcbiAgICByZXR1cm4gdGhpcy5uekRyYWdnYWJsZSAmJiAhdGhpcy5uelRyZWVOb2RlLmlzRGlzYWJsZWQgPyB0cnVlIDogbnVsbDtcbiAgfVxuXG4gIGdldCBpc1Nob3dMaW5lSWNvbigpOiBib29sZWFuIHtcbiAgICByZXR1cm4gIXRoaXMubnpUcmVlTm9kZS5pc0xlYWYgJiYgdGhpcy5uelNob3dMaW5lO1xuICB9XG5cbiAgZ2V0IGlzU2hvd1N3aXRjaEljb24oKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuICF0aGlzLm56VHJlZU5vZGUuaXNMZWFmICYmICF0aGlzLm56U2hvd0xpbmU7XG4gIH1cblxuICBnZXQgaXNTd2l0Y2hlck9wZW4oKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkICYmICF0aGlzLm56VHJlZU5vZGUuaXNMZWFmO1xuICB9XG5cbiAgZ2V0IGlzU3dpdGNoZXJDbG9zZSgpOiBib29sZWFuIHtcbiAgICByZXR1cm4gIXRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkICYmICF0aGlzLm56VHJlZU5vZGUuaXNMZWFmO1xuICB9XG5cbiAgZ2V0IGRpc3BsYXlTdHlsZSgpOiBzdHJpbmcge1xuICAgIC8vIHRvIGhpZGUgdW5tYXRjaGVkIG5vZGVzXG4gICAgcmV0dXJuIHRoaXMubnpTZWFyY2hWYWx1ZSAmJiB0aGlzLm56SGlkZVVuTWF0Y2hlZCAmJiAhdGhpcy5uelRyZWVOb2RlLmlzTWF0Y2hlZCAmJiAhdGhpcy5uelRyZWVOb2RlLmlzRXhwYW5kZWRcbiAgICAgID8gJ25vbmUnXG4gICAgICA6ICcnO1xuICB9XG5cbiAgLyoqXG4gICAqIHJlc2V0IG5vZGUgY2xhc3NcbiAgICovXG4gIHNldENsYXNzTWFwKCk6IHZvaWQge1xuICAgIHRoaXMucHJlZml4Q2xzID0gdGhpcy5uelNlbGVjdE1vZGUgPyAnYW50LXNlbGVjdC10cmVlJyA6ICdhbnQtdHJlZSc7XG4gICAgdGhpcy5uek5vZGVDbGFzcyA9IHtcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tdHJlZW5vZGUtZGlzYWJsZWRgXTogdGhpcy5uelRyZWVOb2RlLmlzRGlzYWJsZWQsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXRyZWVub2RlLXN3aXRjaGVyLW9wZW5gXTogdGhpcy5pc1N3aXRjaGVyT3BlbixcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tdHJlZW5vZGUtc3dpdGNoZXItY2xvc2VgXTogdGhpcy5pc1N3aXRjaGVyQ2xvc2UsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXRyZWVub2RlLWNoZWNrYm94LWNoZWNrZWRgXTogdGhpcy5uelRyZWVOb2RlLmlzQ2hlY2tlZCxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tdHJlZW5vZGUtY2hlY2tib3gtaW5kZXRlcm1pbmF0ZWBdOiB0aGlzLm56VHJlZU5vZGUuaXNIYWxmQ2hlY2tlZCxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tdHJlZW5vZGUtc2VsZWN0ZWRgXTogdGhpcy5uelRyZWVOb2RlLmlzU2VsZWN0ZWQsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXRyZWVub2RlLWxvYWRpbmdgXTogdGhpcy5uelRyZWVOb2RlLmlzTG9hZGluZ1xuICAgIH07XG4gICAgdGhpcy5uek5vZGVTd2l0Y2hlckNsYXNzID0ge1xuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1zd2l0Y2hlcmBdOiB0cnVlLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1zd2l0Y2hlci1ub29wYF06IHRoaXMubnpUcmVlTm9kZS5pc0xlYWYsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXN3aXRjaGVyX29wZW5gXTogdGhpcy5pc1N3aXRjaGVyT3BlbixcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tc3dpdGNoZXJfY2xvc2VgXTogdGhpcy5pc1N3aXRjaGVyQ2xvc2VcbiAgICB9O1xuXG4gICAgdGhpcy5uek5vZGVDaGVja2JveENsYXNzID0ge1xuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1jaGVja2JveGBdOiB0cnVlLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1jaGVja2JveC1jaGVja2VkYF06IHRoaXMubnpUcmVlTm9kZS5pc0NoZWNrZWQsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LWNoZWNrYm94LWluZGV0ZXJtaW5hdGVgXTogdGhpcy5uelRyZWVOb2RlLmlzSGFsZkNoZWNrZWQsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LWNoZWNrYm94LWRpc2FibGVkYF06IHRoaXMubnpUcmVlTm9kZS5pc0Rpc2FibGVkIHx8IHRoaXMubnpUcmVlTm9kZS5pc0Rpc2FibGVDaGVja2JveFxuICAgIH07XG5cbiAgICB0aGlzLm56Tm9kZUNvbnRlbnRDbGFzcyA9IHtcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tbm9kZS1jb250ZW50LXdyYXBwZXJgXTogdHJ1ZSxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tbm9kZS1jb250ZW50LXdyYXBwZXItb3BlbmBdOiB0aGlzLmlzU3dpdGNoZXJPcGVuLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1ub2RlLWNvbnRlbnQtd3JhcHBlci1jbG9zZWBdOiB0aGlzLmlzU3dpdGNoZXJDbG9zZSxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tbm9kZS1zZWxlY3RlZGBdOiB0aGlzLm56VHJlZU5vZGUuaXNTZWxlY3RlZFxuICAgIH07XG4gICAgdGhpcy5uek5vZGVDb250ZW50SWNvbkNsYXNzID0ge1xuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1pY29uRWxlYF06IHRydWUsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LWljb25fX2N1c3RvbWl6ZWBdOiB0cnVlXG4gICAgfTtcbiAgICB0aGlzLm56Tm9kZUNvbnRlbnRMb2FkaW5nQ2xhc3MgPSB7XG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LWljb25FbGVgXTogdHJ1ZVxuICAgIH07XG4gIH1cblxuICBASG9zdExpc3RlbmVyKCdtb3VzZWRvd24nLCBbJyRldmVudCddKVxuICBvbk1vdXNlZG93bihldmVudDogTW91c2VFdmVudCk6IHZvaWQge1xuICAgIGlmICh0aGlzLm56U2VsZWN0TW9kZSkge1xuICAgICAgZXZlbnQucHJldmVudERlZmF1bHQoKTtcbiAgICB9XG4gIH1cblxuICAvKipcbiAgICogY2xpY2sgbm9kZSB0byBzZWxlY3QsIDIwMG1zIHRvIGRibCBjbGlja1xuICAgKi9cbiAgQEhvc3RMaXN0ZW5lcignY2xpY2snLCBbJyRldmVudCddKVxuICBuekNsaWNrKGV2ZW50OiBNb3VzZUV2ZW50KTogdm9pZCB7XG4gICAgZXZlbnQucHJldmVudERlZmF1bHQoKTtcbiAgICBldmVudC5zdG9wUHJvcGFnYXRpb24oKTtcbiAgICBpZiAodGhpcy5uelRyZWVOb2RlLmlzU2VsZWN0YWJsZSAmJiAhdGhpcy5uelRyZWVOb2RlLmlzRGlzYWJsZWQpIHtcbiAgICAgIHRoaXMubnpUcmVlTm9kZS5pc1NlbGVjdGVkID0gIXRoaXMubnpUcmVlTm9kZS5pc1NlbGVjdGVkO1xuICAgIH1cbiAgICBjb25zdCBldmVudE5leHQgPSB0aGlzLm56VHJlZVNlcnZpY2UuZm9ybWF0RXZlbnQoJ2NsaWNrJywgdGhpcy5uelRyZWVOb2RlLCBldmVudCk7XG4gICAgdGhpcy5uelRyZWVTZXJ2aWNlIS50cmlnZ2VyRXZlbnRDaGFuZ2UkIS5uZXh0KGV2ZW50TmV4dCk7XG4gIH1cblxuICBASG9zdExpc3RlbmVyKCdkYmxjbGljaycsIFsnJGV2ZW50J10pXG4gIG56RGJsQ2xpY2soZXZlbnQ6IE1vdXNlRXZlbnQpOiB2b2lkIHtcbiAgICBldmVudC5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGV2ZW50LnN0b3BQcm9wYWdhdGlvbigpO1xuICAgIGNvbnN0IGV2ZW50TmV4dCA9IHRoaXMubnpUcmVlU2VydmljZS5mb3JtYXRFdmVudCgnZGJsY2xpY2snLCB0aGlzLm56VHJlZU5vZGUsIGV2ZW50KTtcbiAgICB0aGlzLm56VHJlZVNlcnZpY2UhLnRyaWdnZXJFdmVudENoYW5nZSQhLm5leHQoZXZlbnROZXh0KTtcbiAgfVxuXG4gIC8qKlxuICAgKiBAcGFyYW0gZXZlbnRcbiAgICovXG4gIEBIb3N0TGlzdGVuZXIoJ2NvbnRleHRtZW51JywgWyckZXZlbnQnXSlcbiAgbnpDb250ZXh0TWVudShldmVudDogTW91c2VFdmVudCk6IHZvaWQge1xuICAgIGV2ZW50LnByZXZlbnREZWZhdWx0KCk7XG4gICAgZXZlbnQuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgY29uc3QgZXZlbnROZXh0ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdjb250ZXh0bWVudScsIHRoaXMubnpUcmVlTm9kZSwgZXZlbnQpO1xuICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChldmVudE5leHQpO1xuICB9XG5cbiAgLyoqXG4gICAqIGNvbGxhcHNlIG5vZGVcbiAgICogQHBhcmFtIGV2ZW50XG4gICAqL1xuICBfY2xpY2tFeHBhbmQoZXZlbnQ6IE1vdXNlRXZlbnQpOiB2b2lkIHtcbiAgICBldmVudC5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGV2ZW50LnN0b3BQcm9wYWdhdGlvbigpO1xuICAgIGlmICghdGhpcy5uelRyZWVOb2RlLmlzTG9hZGluZyAmJiAhdGhpcy5uelRyZWVOb2RlLmlzTGVhZikge1xuICAgICAgLy8gc2V0IGFzeW5jIHN0YXRlXG4gICAgICBpZiAodGhpcy5uekFzeW5jRGF0YSAmJiB0aGlzLm56VHJlZU5vZGUuY2hpbGRyZW4ubGVuZ3RoID09PSAwICYmICF0aGlzLm56VHJlZU5vZGUuaXNFeHBhbmRlZCkge1xuICAgICAgICB0aGlzLm56VHJlZU5vZGUuaXNMb2FkaW5nID0gdHJ1ZTtcbiAgICAgIH1cbiAgICAgIHRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkID0gIXRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkO1xuICAgICAgY29uc3QgZXZlbnROZXh0ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdleHBhbmQnLCB0aGlzLm56VHJlZU5vZGUsIGV2ZW50KTtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChldmVudE5leHQpO1xuICAgIH1cbiAgfVxuXG4gIC8qKlxuICAgKiBjaGVjayBub2RlXG4gICAqIEBwYXJhbSBldmVudFxuICAgKi9cbiAgX2NsaWNrQ2hlY2tCb3goZXZlbnQ6IE1vdXNlRXZlbnQpOiB2b2lkIHtcbiAgICBldmVudC5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGV2ZW50LnN0b3BQcm9wYWdhdGlvbigpO1xuICAgIC8vIHJldHVybiBpZiBub2RlIGlzIGRpc2FibGVkXG4gICAgaWYgKHRoaXMubnpUcmVlTm9kZS5pc0Rpc2FibGVkIHx8IHRoaXMubnpUcmVlTm9kZS5pc0Rpc2FibGVDaGVja2JveCkge1xuICAgICAgcmV0dXJuO1xuICAgIH1cbiAgICB0aGlzLm56VHJlZU5vZGUuaXNDaGVja2VkID0gIXRoaXMubnpUcmVlTm9kZS5pc0NoZWNrZWQ7XG4gICAgdGhpcy5uelRyZWVOb2RlLmlzSGFsZkNoZWNrZWQgPSBmYWxzZTtcbiAgICBpZiAoIXRoaXMubnpUcmVlU2VydmljZS5pc0NoZWNrU3RyaWN0bHkpIHtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZS5jb25kdWN0KHRoaXMubnpUcmVlTm9kZSk7XG4gICAgfVxuICAgIGNvbnN0IGV2ZW50TmV4dCA9IHRoaXMubnpUcmVlU2VydmljZS5mb3JtYXRFdmVudCgnY2hlY2snLCB0aGlzLm56VHJlZU5vZGUsIGV2ZW50KTtcbiAgICB0aGlzLm56VHJlZVNlcnZpY2UhLnRyaWdnZXJFdmVudENoYW5nZSQhLm5leHQoZXZlbnROZXh0KTtcbiAgfVxuXG4gIC8qKlxuICAgKiBkcmFnIGV2ZW50XG4gICAqIEBwYXJhbSBlXG4gICAqL1xuICBjbGVhckRyYWdDbGFzcygpOiB2b2lkIHtcbiAgICBjb25zdCBkcmFnQ2xhc3MgPSBbJ2RyYWctb3Zlci1nYXAtdG9wJywgJ2RyYWctb3Zlci1nYXAtYm90dG9tJywgJ2RyYWctb3ZlciddO1xuICAgIGRyYWdDbGFzcy5mb3JFYWNoKGUgPT4ge1xuICAgICAgdGhpcy5yZW5kZXJlci5yZW1vdmVDbGFzcyh0aGlzLmRyYWdFbGVtZW50Lm5hdGl2ZUVsZW1lbnQsIGUpO1xuICAgIH0pO1xuICB9XG5cbiAgaGFuZGxlRHJhZ1N0YXJ0KGU6IERyYWdFdmVudCk6IHZvaWQge1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgdHJ5IHtcbiAgICAgIC8vIGllIHRocm93IGVycm9yXG4gICAgICAvLyBmaXJlZm94LW5lZWQtaXRcbiAgICAgIGUuZGF0YVRyYW5zZmVyIS5zZXREYXRhKCd0ZXh0L3BsYWluJywgdGhpcy5uelRyZWVOb2RlLmtleSEpO1xuICAgIH0gY2F0Y2ggKGVycm9yKSB7XG4gICAgICAvLyBlbXB0eVxuICAgIH1cbiAgICB0aGlzLm56VHJlZVNlcnZpY2Uuc2V0U2VsZWN0ZWROb2RlKHRoaXMubnpUcmVlTm9kZSk7XG4gICAgdGhpcy5uelRyZWVOb2RlLmlzRXhwYW5kZWQgPSBmYWxzZTtcbiAgICBjb25zdCBldmVudE5leHQgPSB0aGlzLm56VHJlZVNlcnZpY2UuZm9ybWF0RXZlbnQoJ2RyYWdzdGFydCcsIHRoaXMubnpUcmVlTm9kZSwgZSk7XG4gICAgdGhpcy5uelRyZWVTZXJ2aWNlIS50cmlnZ2VyRXZlbnRDaGFuZ2UkIS5uZXh0KGV2ZW50TmV4dCk7XG4gIH1cblxuICBoYW5kbGVEcmFnRW50ZXIoZTogRHJhZ0V2ZW50KTogdm9pZCB7XG4gICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgLy8gcmVzZXQgcG9zaXRpb25cbiAgICB0aGlzLmRyYWdQb3MgPSAyO1xuICAgIHRoaXMubmdab25lLnJ1bigoKSA9PiB7XG4gICAgICBjb25zdCBub2RlID0gdGhpcy5uelRyZWVTZXJ2aWNlLmdldFNlbGVjdGVkTm9kZSgpO1xuICAgICAgaWYgKG5vZGUgJiYgbm9kZS5rZXkgIT09IHRoaXMubnpUcmVlTm9kZS5rZXkgJiYgIXRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkICYmICF0aGlzLm56VHJlZU5vZGUuaXNMZWFmKSB7XG4gICAgICAgIHRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkID0gdHJ1ZTtcbiAgICAgIH1cbiAgICAgIGNvbnN0IGV2ZW50TmV4dCA9IHRoaXMubnpUcmVlU2VydmljZS5mb3JtYXRFdmVudCgnZHJhZ2VudGVyJywgdGhpcy5uelRyZWVOb2RlLCBlKTtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChldmVudE5leHQpO1xuICAgIH0pO1xuICB9XG5cbiAgaGFuZGxlRHJhZ092ZXIoZTogRHJhZ0V2ZW50KTogdm9pZCB7XG4gICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgY29uc3QgZHJvcFBvc2l0aW9uID0gdGhpcy5uelRyZWVTZXJ2aWNlLmNhbGNEcm9wUG9zaXRpb24oZSk7XG4gICAgaWYgKHRoaXMuZHJhZ1BvcyAhPT0gZHJvcFBvc2l0aW9uKSB7XG4gICAgICB0aGlzLmNsZWFyRHJhZ0NsYXNzKCk7XG4gICAgICB0aGlzLmRyYWdQb3MgPSBkcm9wUG9zaXRpb247XG4gICAgICAvLyBsZWFmIG5vZGUgd2lsbCBwYXNzXG4gICAgICBpZiAoISh0aGlzLmRyYWdQb3MgPT09IDAgJiYgdGhpcy5uelRyZWVOb2RlLmlzTGVhZikpIHtcbiAgICAgICAgdGhpcy5yZW5kZXJlci5hZGRDbGFzcyh0aGlzLmRyYWdFbGVtZW50Lm5hdGl2ZUVsZW1lbnQsIHRoaXMuZHJhZ1Bvc0NsYXNzW3RoaXMuZHJhZ1Bvc10pO1xuICAgICAgfVxuICAgIH1cbiAgICBjb25zdCBldmVudE5leHQgPSB0aGlzLm56VHJlZVNlcnZpY2UuZm9ybWF0RXZlbnQoJ2RyYWdvdmVyJywgdGhpcy5uelRyZWVOb2RlLCBlKTtcbiAgICB0aGlzLm56VHJlZVNlcnZpY2UhLnRyaWdnZXJFdmVudENoYW5nZSQhLm5leHQoZXZlbnROZXh0KTtcbiAgfVxuXG4gIGhhbmRsZURyYWdMZWF2ZShlOiBEcmFnRXZlbnQpOiB2b2lkIHtcbiAgICBlLnN0b3BQcm9wYWdhdGlvbigpO1xuICAgIHRoaXMubmdab25lLnJ1bigoKSA9PiB7XG4gICAgICB0aGlzLmNsZWFyRHJhZ0NsYXNzKCk7XG4gICAgfSk7XG4gICAgY29uc3QgZXZlbnROZXh0ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdkcmFnbGVhdmUnLCB0aGlzLm56VHJlZU5vZGUsIGUpO1xuICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChldmVudE5leHQpO1xuICB9XG5cbiAgaGFuZGxlRHJhZ0Ryb3AoZTogRHJhZ0V2ZW50KTogdm9pZCB7XG4gICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgdGhpcy5uZ1pvbmUucnVuKCgpID0+IHtcbiAgICAgIHRoaXMuY2xlYXJEcmFnQ2xhc3MoKTtcbiAgICAgIGNvbnN0IG5vZGUgPSB0aGlzLm56VHJlZVNlcnZpY2UuZ2V0U2VsZWN0ZWROb2RlKCk7XG4gICAgICBpZiAoIW5vZGUgfHwgKG5vZGUgJiYgbm9kZS5rZXkgPT09IHRoaXMubnpUcmVlTm9kZS5rZXkpIHx8ICh0aGlzLmRyYWdQb3MgPT09IDAgJiYgdGhpcy5uelRyZWVOb2RlLmlzTGVhZikpIHtcbiAgICAgICAgcmV0dXJuO1xuICAgICAgfVxuICAgICAgLy8gcGFzcyBpZiBub2RlIGlzIGxlYWZOb1xuICAgICAgY29uc3QgZHJvcEV2ZW50ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdkcm9wJywgdGhpcy5uelRyZWVOb2RlLCBlKTtcbiAgICAgIGNvbnN0IGRyYWdFbmRFdmVudCA9IHRoaXMubnpUcmVlU2VydmljZS5mb3JtYXRFdmVudCgnZHJhZ2VuZCcsIHRoaXMubnpUcmVlTm9kZSwgZSk7XG4gICAgICBpZiAodGhpcy5uekJlZm9yZURyb3ApIHtcbiAgICAgICAgdGhpcy5uekJlZm9yZURyb3Aoe1xuICAgICAgICAgIGRyYWdOb2RlOiB0aGlzLm56VHJlZVNlcnZpY2UuZ2V0U2VsZWN0ZWROb2RlKCkhLFxuICAgICAgICAgIG5vZGU6IHRoaXMubnpUcmVlTm9kZSxcbiAgICAgICAgICBwb3M6IHRoaXMuZHJhZ1Bvc1xuICAgICAgICB9KS5zdWJzY3JpYmUoKGNhbkRyb3A6IGJvb2xlYW4pID0+IHtcbiAgICAgICAgICBpZiAoY2FuRHJvcCkge1xuICAgICAgICAgICAgdGhpcy5uelRyZWVTZXJ2aWNlLmRyb3BBbmRBcHBseSh0aGlzLm56VHJlZU5vZGUsIHRoaXMuZHJhZ1Bvcyk7XG4gICAgICAgICAgfVxuICAgICAgICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChkcm9wRXZlbnQpO1xuICAgICAgICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChkcmFnRW5kRXZlbnQpO1xuICAgICAgICB9KTtcbiAgICAgIH0gZWxzZSBpZiAodGhpcy5uelRyZWVOb2RlKSB7XG4gICAgICAgIHRoaXMubnpUcmVlU2VydmljZS5kcm9wQW5kQXBwbHkodGhpcy5uelRyZWVOb2RlLCB0aGlzLmRyYWdQb3MpO1xuICAgICAgICB0aGlzLm56VHJlZVNlcnZpY2UhLnRyaWdnZXJFdmVudENoYW5nZSQhLm5leHQoZHJvcEV2ZW50KTtcbiAgICAgIH1cbiAgICB9KTtcbiAgfVxuXG4gIGhhbmRsZURyYWdFbmQoZTogRHJhZ0V2ZW50KTogdm9pZCB7XG4gICAgZS5zdG9wUHJvcGFnYXRpb24oKTtcbiAgICB0aGlzLm5nWm9uZS5ydW4oKCkgPT4ge1xuICAgICAgLy8gaWYgdXNlciBkbyBub3QgY3VzdG9tIGJlZm9yZURyb3BcbiAgICAgIGlmICghdGhpcy5uekJlZm9yZURyb3ApIHtcbiAgICAgICAgY29uc3QgZXZlbnROZXh0ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdkcmFnZW5kJywgdGhpcy5uelRyZWVOb2RlLCBlKTtcbiAgICAgICAgdGhpcy5uelRyZWVTZXJ2aWNlIS50cmlnZ2VyRXZlbnRDaGFuZ2UkIS5uZXh0KGV2ZW50TmV4dCk7XG4gICAgICB9XG4gICAgfSk7XG4gIH1cblxuICAvKipcbiAgICog55uR5ZCs5ouW5ou95LqL5Lu2XG4gICAqL1xuICBoYW5kRHJhZ0V2ZW50KCk6IHZvaWQge1xuICAgIHRoaXMubmdab25lLnJ1bk91dHNpZGVBbmd1bGFyKCgpID0+IHtcbiAgICAgIGlmICh0aGlzLm56RHJhZ2dhYmxlKSB7XG4gICAgICAgIHRoaXMuZGVzdHJveSQgPSBuZXcgU3ViamVjdCgpO1xuICAgICAgICBmcm9tRXZlbnQ8RHJhZ0V2ZW50Pih0aGlzLmVsUmVmLm5hdGl2ZUVsZW1lbnQsICdkcmFnc3RhcnQnKVxuICAgICAgICAgIC5waXBlKHRha2VVbnRpbCh0aGlzLmRlc3Ryb3kkKSlcbiAgICAgICAgICAuc3Vic2NyaWJlKChlOiBEcmFnRXZlbnQpID0+IHRoaXMuaGFuZGxlRHJhZ1N0YXJ0KGUpKTtcbiAgICAgICAgZnJvbUV2ZW50PERyYWdFdmVudD4odGhpcy5lbFJlZi5uYXRpdmVFbGVtZW50LCAnZHJhZ2VudGVyJylcbiAgICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAgICAgLnN1YnNjcmliZSgoZTogRHJhZ0V2ZW50KSA9PiB0aGlzLmhhbmRsZURyYWdFbnRlcihlKSk7XG4gICAgICAgIGZyb21FdmVudDxEcmFnRXZlbnQ+KHRoaXMuZWxSZWYubmF0aXZlRWxlbWVudCwgJ2RyYWdvdmVyJylcbiAgICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAgICAgLnN1YnNjcmliZSgoZTogRHJhZ0V2ZW50KSA9PiB0aGlzLmhhbmRsZURyYWdPdmVyKGUpKTtcbiAgICAgICAgZnJvbUV2ZW50PERyYWdFdmVudD4odGhpcy5lbFJlZi5uYXRpdmVFbGVtZW50LCAnZHJhZ2xlYXZlJylcbiAgICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAgICAgLnN1YnNjcmliZSgoZTogRHJhZ0V2ZW50KSA9PiB0aGlzLmhhbmRsZURyYWdMZWF2ZShlKSk7XG4gICAgICAgIGZyb21FdmVudDxEcmFnRXZlbnQ+KHRoaXMuZWxSZWYubmF0aXZlRWxlbWVudCwgJ2Ryb3AnKVxuICAgICAgICAgIC5waXBlKHRha2VVbnRpbCh0aGlzLmRlc3Ryb3kkKSlcbiAgICAgICAgICAuc3Vic2NyaWJlKChlOiBEcmFnRXZlbnQpID0+IHRoaXMuaGFuZGxlRHJhZ0Ryb3AoZSkpO1xuICAgICAgICBmcm9tRXZlbnQ8RHJhZ0V2ZW50Pih0aGlzLmVsUmVmLm5hdGl2ZUVsZW1lbnQsICdkcmFnZW5kJylcbiAgICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAgICAgLnN1YnNjcmliZSgoZTogRHJhZ0V2ZW50KSA9PiB0aGlzLmhhbmRsZURyYWdFbmQoZSkpO1xuICAgICAgfSBlbHNlIHtcbiAgICAgICAgdGhpcy5kZXN0cm95JC5uZXh0KCk7XG4gICAgICAgIHRoaXMuZGVzdHJveSQuY29tcGxldGUoKTtcbiAgICAgIH1cbiAgICB9KTtcbiAgfVxuXG4gIGlzVGVtcGxhdGVSZWYodmFsdWU6IHt9KTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHZhbHVlIGluc3RhbmNlb2YgVGVtcGxhdGVSZWY7XG4gIH1cblxuICBtYXJrRm9yQ2hlY2soKTogdm9pZCB7XG4gICAgdGhpcy5jZHIubWFya0ZvckNoZWNrKCk7XG4gIH1cblxuICBjb25zdHJ1Y3RvcihcbiAgICBwdWJsaWMgbnpUcmVlU2VydmljZTogTnpUcmVlQmFzZVNlcnZpY2UsXG4gICAgcHJpdmF0ZSBuZ1pvbmU6IE5nWm9uZSxcbiAgICBwcml2YXRlIHJlbmRlcmVyOiBSZW5kZXJlcjIsXG4gICAgcHJpdmF0ZSBlbFJlZjogRWxlbWVudFJlZixcbiAgICBwcml2YXRlIGNkcjogQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gICAgQEhvc3QoKSBAT3B0aW9uYWwoKSBwdWJsaWMgbm9BbmltYXRpb24/OiBOek5vQW5pbWF0aW9uRGlyZWN0aXZlXG4gICkge31cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICAvLyBpbml0IGV4cGFuZGVkIC8gc2VsZWN0ZWQgLyBjaGVja2VkIGxpc3RcbiAgICBpZiAodGhpcy5uelRyZWVOb2RlLmlzU2VsZWN0ZWQpIHtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZS5zZXROb2RlQWN0aXZlKHRoaXMubnpUcmVlTm9kZSk7XG4gICAgfVxuICAgIGlmICh0aGlzLm56VHJlZU5vZGUuaXNFeHBhbmRlZCkge1xuICAgICAgdGhpcy5uelRyZWVTZXJ2aWNlLnNldEV4cGFuZGVkTm9kZUxpc3QodGhpcy5uelRyZWVOb2RlKTtcbiAgICB9XG4gICAgaWYgKHRoaXMubnpUcmVlTm9kZS5pc0NoZWNrZWQpIHtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZS5zZXRDaGVja2VkTm9kZUxpc3QodGhpcy5uelRyZWVOb2RlKTtcbiAgICB9XG4gICAgLy8gVE9ET1xuICAgIHRoaXMubnpUcmVlTm9kZS5jb21wb25lbnQgPSB0aGlzO1xuICAgIHRoaXMubnpUcmVlU2VydmljZVxuICAgICAgLmV2ZW50VHJpZ2dlckNoYW5nZWQoKVxuICAgICAgLnBpcGUoXG4gICAgICAgIGZpbHRlcihkYXRhID0+IGRhdGEubm9kZSEua2V5ID09PSB0aGlzLm56VHJlZU5vZGUua2V5KSxcbiAgICAgICAgdGFrZVVudGlsKHRoaXMuZGVzdHJveSQpXG4gICAgICApXG4gICAgICAuc3Vic2NyaWJlKCgpID0+IHtcbiAgICAgICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICAgICAgICB0aGlzLm1hcmtGb3JDaGVjaygpO1xuICAgICAgfSk7XG4gICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICB9XG5cbiAgbmdPbkNoYW5nZXMoKTogdm9pZCB7XG4gICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICB9XG5cbiAgbmdPbkRlc3Ryb3koKTogdm9pZCB7XG4gICAgdGhpcy5kZXN0cm95JC5uZXh0KCk7XG4gICAgdGhpcy5kZXN0cm95JC5jb21wbGV0ZSgpO1xuICB9XG59XG4iXX0=