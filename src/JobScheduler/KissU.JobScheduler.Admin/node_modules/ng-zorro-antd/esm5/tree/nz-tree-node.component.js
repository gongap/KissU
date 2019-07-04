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
var NzTreeNodeComponent = /** @class */ (function () {
    function NzTreeNodeComponent(nzTreeService, ngZone, renderer, elRef, cdr, noAnimation) {
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
    Object.defineProperty(NzTreeNodeComponent.prototype, "nzDraggable", {
        get: /**
         * @return {?}
         */
        function () {
            return this._nzDraggable;
        },
        set: /**
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this._nzDraggable = value;
            this.handDragEvent();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "nzDefaultExpandAll", {
        get: /**
         * @return {?}
         */
        function () {
            return this._nzExpandAll;
        },
        /**
         * @deprecated use
         * nzExpandAll instead
         */
        set: /**
         * @deprecated use
         * nzExpandAll instead
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this._nzExpandAll = value;
            if (value && this.nzTreeNode && !this.nzTreeNode.isLeaf) {
                this.nzTreeNode.isExpanded = true;
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "nzExpandAll", {
        get: /**
         * @return {?}
         */
        function () {
            return this._nzExpandAll;
        },
        // default set
        set: 
        // default set
        /**
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this._nzExpandAll = value;
            if (value && this.nzTreeNode && !this.nzTreeNode.isLeaf) {
                this.nzTreeNode.isExpanded = true;
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "nzSearchValue", {
        get: /**
         * @return {?}
         */
        function () {
            return this._searchValue;
        },
        set: /**
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this.highlightKeys = [];
            if (value && (/** @type {?} */ (this.nzTreeNode.title)).includes(value)) {
                // match the search value
                /** @type {?} */
                var index = this.nzTreeNode.title.indexOf(value);
                this.highlightKeys = [
                    this.nzTreeNode.title.slice(0, index),
                    this.nzTreeNode.title.slice(index + value.length, this.nzTreeNode.title.length)
                ];
            }
            this._searchValue = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "nzIcon", {
        get: /**
         * @return {?}
         */
        function () {
            return this.nzTreeNode.icon;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "canDraggable", {
        get: /**
         * @return {?}
         */
        function () {
            return this.nzDraggable && !this.nzTreeNode.isDisabled ? true : null;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "isShowLineIcon", {
        get: /**
         * @return {?}
         */
        function () {
            return !this.nzTreeNode.isLeaf && this.nzShowLine;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "isShowSwitchIcon", {
        get: /**
         * @return {?}
         */
        function () {
            return !this.nzTreeNode.isLeaf && !this.nzShowLine;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "isSwitcherOpen", {
        get: /**
         * @return {?}
         */
        function () {
            return this.nzTreeNode.isExpanded && !this.nzTreeNode.isLeaf;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "isSwitcherClose", {
        get: /**
         * @return {?}
         */
        function () {
            return !this.nzTreeNode.isExpanded && !this.nzTreeNode.isLeaf;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(NzTreeNodeComponent.prototype, "displayStyle", {
        get: /**
         * @return {?}
         */
        function () {
            // to hide unmatched nodes
            return this.nzSearchValue && this.nzHideUnMatched && !this.nzTreeNode.isMatched && !this.nzTreeNode.isExpanded
                ? 'none'
                : '';
        },
        enumerable: true,
        configurable: true
    });
    /**
     * reset node class
     */
    /**
     * reset node class
     * @return {?}
     */
    NzTreeNodeComponent.prototype.setClassMap = /**
     * reset node class
     * @return {?}
     */
    function () {
        var _a, _b, _c, _d, _e, _f;
        this.prefixCls = this.nzSelectMode ? 'ant-select-tree' : 'ant-tree';
        this.nzNodeClass = (_a = {},
            _a[this.prefixCls + "-treenode-disabled"] = this.nzTreeNode.isDisabled,
            _a[this.prefixCls + "-treenode-switcher-open"] = this.isSwitcherOpen,
            _a[this.prefixCls + "-treenode-switcher-close"] = this.isSwitcherClose,
            _a[this.prefixCls + "-treenode-checkbox-checked"] = this.nzTreeNode.isChecked,
            _a[this.prefixCls + "-treenode-checkbox-indeterminate"] = this.nzTreeNode.isHalfChecked,
            _a[this.prefixCls + "-treenode-selected"] = this.nzTreeNode.isSelected,
            _a[this.prefixCls + "-treenode-loading"] = this.nzTreeNode.isLoading,
            _a);
        this.nzNodeSwitcherClass = (_b = {},
            _b[this.prefixCls + "-switcher"] = true,
            _b[this.prefixCls + "-switcher-noop"] = this.nzTreeNode.isLeaf,
            _b[this.prefixCls + "-switcher_open"] = this.isSwitcherOpen,
            _b[this.prefixCls + "-switcher_close"] = this.isSwitcherClose,
            _b);
        this.nzNodeCheckboxClass = (_c = {},
            _c[this.prefixCls + "-checkbox"] = true,
            _c[this.prefixCls + "-checkbox-checked"] = this.nzTreeNode.isChecked,
            _c[this.prefixCls + "-checkbox-indeterminate"] = this.nzTreeNode.isHalfChecked,
            _c[this.prefixCls + "-checkbox-disabled"] = this.nzTreeNode.isDisabled || this.nzTreeNode.isDisableCheckbox,
            _c);
        this.nzNodeContentClass = (_d = {},
            _d[this.prefixCls + "-node-content-wrapper"] = true,
            _d[this.prefixCls + "-node-content-wrapper-open"] = this.isSwitcherOpen,
            _d[this.prefixCls + "-node-content-wrapper-close"] = this.isSwitcherClose,
            _d[this.prefixCls + "-node-selected"] = this.nzTreeNode.isSelected,
            _d);
        this.nzNodeContentIconClass = (_e = {},
            _e[this.prefixCls + "-iconEle"] = true,
            _e[this.prefixCls + "-icon__customize"] = true,
            _e);
        this.nzNodeContentLoadingClass = (_f = {},
            _f[this.prefixCls + "-iconEle"] = true,
            _f);
    };
    /**
     * @param {?} event
     * @return {?}
     */
    NzTreeNodeComponent.prototype.onMousedown = /**
     * @param {?} event
     * @return {?}
     */
    function (event) {
        if (this.nzSelectMode) {
            event.preventDefault();
        }
    };
    /**
     * click node to select, 200ms to dbl click
     */
    /**
     * click node to select, 200ms to dbl click
     * @param {?} event
     * @return {?}
     */
    NzTreeNodeComponent.prototype.nzClick = /**
     * click node to select, 200ms to dbl click
     * @param {?} event
     * @return {?}
     */
    function (event) {
        event.preventDefault();
        event.stopPropagation();
        if (this.nzTreeNode.isSelectable && !this.nzTreeNode.isDisabled) {
            this.nzTreeNode.isSelected = !this.nzTreeNode.isSelected;
        }
        /** @type {?} */
        var eventNext = this.nzTreeService.formatEvent('click', this.nzTreeNode, event);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    };
    /**
     * @param {?} event
     * @return {?}
     */
    NzTreeNodeComponent.prototype.nzDblClick = /**
     * @param {?} event
     * @return {?}
     */
    function (event) {
        event.preventDefault();
        event.stopPropagation();
        /** @type {?} */
        var eventNext = this.nzTreeService.formatEvent('dblclick', this.nzTreeNode, event);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    };
    /**
     * @param event
     */
    /**
     * @param {?} event
     * @return {?}
     */
    NzTreeNodeComponent.prototype.nzContextMenu = /**
     * @param {?} event
     * @return {?}
     */
    function (event) {
        event.preventDefault();
        event.stopPropagation();
        /** @type {?} */
        var eventNext = this.nzTreeService.formatEvent('contextmenu', this.nzTreeNode, event);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    };
    /**
     * collapse node
     * @param event
     */
    /**
     * collapse node
     * @param {?} event
     * @return {?}
     */
    NzTreeNodeComponent.prototype._clickExpand = /**
     * collapse node
     * @param {?} event
     * @return {?}
     */
    function (event) {
        event.preventDefault();
        event.stopPropagation();
        if (!this.nzTreeNode.isLoading && !this.nzTreeNode.isLeaf) {
            // set async state
            if (this.nzAsyncData && this.nzTreeNode.children.length === 0 && !this.nzTreeNode.isExpanded) {
                this.nzTreeNode.isLoading = true;
            }
            this.nzTreeNode.isExpanded = !this.nzTreeNode.isExpanded;
            /** @type {?} */
            var eventNext = this.nzTreeService.formatEvent('expand', this.nzTreeNode, event);
            (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
        }
    };
    /**
     * check node
     * @param event
     */
    /**
     * check node
     * @param {?} event
     * @return {?}
     */
    NzTreeNodeComponent.prototype._clickCheckBox = /**
     * check node
     * @param {?} event
     * @return {?}
     */
    function (event) {
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
        var eventNext = this.nzTreeService.formatEvent('check', this.nzTreeNode, event);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    };
    /**
     * drag event
     * @param e
     */
    /**
     * drag event
     * @return {?}
     */
    NzTreeNodeComponent.prototype.clearDragClass = /**
     * drag event
     * @return {?}
     */
    function () {
        var _this = this;
        /** @type {?} */
        var dragClass = ['drag-over-gap-top', 'drag-over-gap-bottom', 'drag-over'];
        dragClass.forEach((/**
         * @param {?} e
         * @return {?}
         */
        function (e) {
            _this.renderer.removeClass(_this.dragElement.nativeElement, e);
        }));
    };
    /**
     * @param {?} e
     * @return {?}
     */
    NzTreeNodeComponent.prototype.handleDragStart = /**
     * @param {?} e
     * @return {?}
     */
    function (e) {
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
        var eventNext = this.nzTreeService.formatEvent('dragstart', this.nzTreeNode, e);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    };
    /**
     * @param {?} e
     * @return {?}
     */
    NzTreeNodeComponent.prototype.handleDragEnter = /**
     * @param {?} e
     * @return {?}
     */
    function (e) {
        var _this = this;
        e.preventDefault();
        e.stopPropagation();
        // reset position
        this.dragPos = 2;
        this.ngZone.run((/**
         * @return {?}
         */
        function () {
            /** @type {?} */
            var node = _this.nzTreeService.getSelectedNode();
            if (node && node.key !== _this.nzTreeNode.key && !_this.nzTreeNode.isExpanded && !_this.nzTreeNode.isLeaf) {
                _this.nzTreeNode.isExpanded = true;
            }
            /** @type {?} */
            var eventNext = _this.nzTreeService.formatEvent('dragenter', _this.nzTreeNode, e);
            (/** @type {?} */ ((/** @type {?} */ (_this.nzTreeService)).triggerEventChange$)).next(eventNext);
        }));
    };
    /**
     * @param {?} e
     * @return {?}
     */
    NzTreeNodeComponent.prototype.handleDragOver = /**
     * @param {?} e
     * @return {?}
     */
    function (e) {
        e.preventDefault();
        e.stopPropagation();
        /** @type {?} */
        var dropPosition = this.nzTreeService.calcDropPosition(e);
        if (this.dragPos !== dropPosition) {
            this.clearDragClass();
            this.dragPos = dropPosition;
            // leaf node will pass
            if (!(this.dragPos === 0 && this.nzTreeNode.isLeaf)) {
                this.renderer.addClass(this.dragElement.nativeElement, this.dragPosClass[this.dragPos]);
            }
        }
        /** @type {?} */
        var eventNext = this.nzTreeService.formatEvent('dragover', this.nzTreeNode, e);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    };
    /**
     * @param {?} e
     * @return {?}
     */
    NzTreeNodeComponent.prototype.handleDragLeave = /**
     * @param {?} e
     * @return {?}
     */
    function (e) {
        var _this = this;
        e.stopPropagation();
        this.ngZone.run((/**
         * @return {?}
         */
        function () {
            _this.clearDragClass();
        }));
        /** @type {?} */
        var eventNext = this.nzTreeService.formatEvent('dragleave', this.nzTreeNode, e);
        (/** @type {?} */ ((/** @type {?} */ (this.nzTreeService)).triggerEventChange$)).next(eventNext);
    };
    /**
     * @param {?} e
     * @return {?}
     */
    NzTreeNodeComponent.prototype.handleDragDrop = /**
     * @param {?} e
     * @return {?}
     */
    function (e) {
        var _this = this;
        e.preventDefault();
        e.stopPropagation();
        this.ngZone.run((/**
         * @return {?}
         */
        function () {
            _this.clearDragClass();
            /** @type {?} */
            var node = _this.nzTreeService.getSelectedNode();
            if (!node || (node && node.key === _this.nzTreeNode.key) || (_this.dragPos === 0 && _this.nzTreeNode.isLeaf)) {
                return;
            }
            // pass if node is leafNo
            /** @type {?} */
            var dropEvent = _this.nzTreeService.formatEvent('drop', _this.nzTreeNode, e);
            /** @type {?} */
            var dragEndEvent = _this.nzTreeService.formatEvent('dragend', _this.nzTreeNode, e);
            if (_this.nzBeforeDrop) {
                _this.nzBeforeDrop({
                    dragNode: (/** @type {?} */ (_this.nzTreeService.getSelectedNode())),
                    node: _this.nzTreeNode,
                    pos: _this.dragPos
                }).subscribe((/**
                 * @param {?} canDrop
                 * @return {?}
                 */
                function (canDrop) {
                    if (canDrop) {
                        _this.nzTreeService.dropAndApply(_this.nzTreeNode, _this.dragPos);
                    }
                    (/** @type {?} */ ((/** @type {?} */ (_this.nzTreeService)).triggerEventChange$)).next(dropEvent);
                    (/** @type {?} */ ((/** @type {?} */ (_this.nzTreeService)).triggerEventChange$)).next(dragEndEvent);
                }));
            }
            else if (_this.nzTreeNode) {
                _this.nzTreeService.dropAndApply(_this.nzTreeNode, _this.dragPos);
                (/** @type {?} */ ((/** @type {?} */ (_this.nzTreeService)).triggerEventChange$)).next(dropEvent);
            }
        }));
    };
    /**
     * @param {?} e
     * @return {?}
     */
    NzTreeNodeComponent.prototype.handleDragEnd = /**
     * @param {?} e
     * @return {?}
     */
    function (e) {
        var _this = this;
        e.stopPropagation();
        this.ngZone.run((/**
         * @return {?}
         */
        function () {
            // if user do not custom beforeDrop
            if (!_this.nzBeforeDrop) {
                /** @type {?} */
                var eventNext = _this.nzTreeService.formatEvent('dragend', _this.nzTreeNode, e);
                (/** @type {?} */ ((/** @type {?} */ (_this.nzTreeService)).triggerEventChange$)).next(eventNext);
            }
        }));
    };
    /**
     * 监听拖拽事件
     */
    /**
     * 监听拖拽事件
     * @return {?}
     */
    NzTreeNodeComponent.prototype.handDragEvent = /**
     * 监听拖拽事件
     * @return {?}
     */
    function () {
        var _this = this;
        this.ngZone.runOutsideAngular((/**
         * @return {?}
         */
        function () {
            if (_this.nzDraggable) {
                _this.destroy$ = new Subject();
                fromEvent(_this.elRef.nativeElement, 'dragstart')
                    .pipe(takeUntil(_this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                function (e) { return _this.handleDragStart(e); }));
                fromEvent(_this.elRef.nativeElement, 'dragenter')
                    .pipe(takeUntil(_this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                function (e) { return _this.handleDragEnter(e); }));
                fromEvent(_this.elRef.nativeElement, 'dragover')
                    .pipe(takeUntil(_this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                function (e) { return _this.handleDragOver(e); }));
                fromEvent(_this.elRef.nativeElement, 'dragleave')
                    .pipe(takeUntil(_this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                function (e) { return _this.handleDragLeave(e); }));
                fromEvent(_this.elRef.nativeElement, 'drop')
                    .pipe(takeUntil(_this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                function (e) { return _this.handleDragDrop(e); }));
                fromEvent(_this.elRef.nativeElement, 'dragend')
                    .pipe(takeUntil(_this.destroy$))
                    .subscribe((/**
                 * @param {?} e
                 * @return {?}
                 */
                function (e) { return _this.handleDragEnd(e); }));
            }
            else {
                _this.destroy$.next();
                _this.destroy$.complete();
            }
        }));
    };
    /**
     * @param {?} value
     * @return {?}
     */
    NzTreeNodeComponent.prototype.isTemplateRef = /**
     * @param {?} value
     * @return {?}
     */
    function (value) {
        return value instanceof TemplateRef;
    };
    /**
     * @return {?}
     */
    NzTreeNodeComponent.prototype.markForCheck = /**
     * @return {?}
     */
    function () {
        this.cdr.markForCheck();
    };
    /**
     * @return {?}
     */
    NzTreeNodeComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        var _this = this;
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
        function (data) { return (/** @type {?} */ (data.node)).key === _this.nzTreeNode.key; })), takeUntil(this.destroy$))
            .subscribe((/**
         * @return {?}
         */
        function () {
            _this.setClassMap();
            _this.markForCheck();
        }));
        this.setClassMap();
    };
    /**
     * @return {?}
     */
    NzTreeNodeComponent.prototype.ngOnChanges = /**
     * @return {?}
     */
    function () {
        this.setClassMap();
    };
    /**
     * @return {?}
     */
    NzTreeNodeComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.destroy$.next();
        this.destroy$.complete();
    };
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
    NzTreeNodeComponent.ctorParameters = function () { return [
        { type: NzTreeBaseService },
        { type: NgZone },
        { type: Renderer2 },
        { type: ElementRef },
        { type: ChangeDetectorRef },
        { type: NzNoAnimationDirective, decorators: [{ type: Host }, { type: Optional }] }
    ]; };
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
    return NzTreeNodeComponent;
}());
export { NzTreeNodeComponent };
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
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotdHJlZS1ub2RlLmNvbXBvbmVudC5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvdHJlZS8iLCJzb3VyY2VzIjpbIm56LXRyZWUtbm9kZS5jb21wb25lbnQudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7O0FBUUEsT0FBTyxFQUNMLHVCQUF1QixFQUN2QixpQkFBaUIsRUFDakIsU0FBUyxFQUNULFVBQVUsRUFDVixJQUFJLEVBQ0osWUFBWSxFQUNaLEtBQUssRUFDTCxNQUFNLEVBSU4sUUFBUSxFQUNSLFNBQVMsRUFDVCxXQUFXLEVBQ1gsU0FBUyxFQUNWLE1BQU0sZUFBZSxDQUFDO0FBQ3ZCLE9BQU8sRUFBRSxTQUFTLEVBQWMsT0FBTyxFQUFFLE1BQU0sTUFBTSxDQUFDO0FBQ3RELE9BQU8sRUFBRSxNQUFNLEVBQUUsU0FBUyxFQUFFLE1BQU0sZ0JBQWdCLENBQUM7QUFFbkQsT0FBTyxFQUNMLGNBQWMsRUFDZCxZQUFZLEVBRVosc0JBQXNCLEVBQ3RCLGlCQUFpQixFQUNqQixVQUFVLEVBQ1gsTUFBTSxvQkFBb0IsQ0FBQztBQUU1QjtJQTRaRSw2QkFDUyxhQUFnQyxFQUMvQixNQUFjLEVBQ2QsUUFBbUIsRUFDbkIsS0FBaUIsRUFDakIsR0FBc0IsRUFDSCxXQUFvQztRQUx4RCxrQkFBYSxHQUFiLGFBQWEsQ0FBbUI7UUFDL0IsV0FBTSxHQUFOLE1BQU0sQ0FBUTtRQUNkLGFBQVEsR0FBUixRQUFRLENBQVc7UUFDbkIsVUFBSyxHQUFMLEtBQUssQ0FBWTtRQUNqQixRQUFHLEdBQUgsR0FBRyxDQUFtQjtRQUNILGdCQUFXLEdBQVgsV0FBVyxDQUF5QjtRQS9ZeEMsb0JBQWUsR0FBRyxLQUFLLENBQUM7UUFDeEIsa0JBQWEsR0FBRyxLQUFLLENBQUM7UUFDdEIsaUJBQVksR0FBRyxLQUFLLENBQUM7UUFDckIsZUFBVSxHQUFHLEtBQUssQ0FBQzs7UUErRDVDLGNBQVMsR0FBRyxVQUFVLENBQUM7UUFDdkIsa0JBQWEs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L0MsMkNBQThDOztJQUM5Qyx5Q0FBNEM7O0lBQzVDLDZDQUFnRTs7SUFDaEUsNkNBQWdFOztJQUNoRSwyQ0FBaUY7O0lBNERqRix3Q0FBdUI7O0lBQ3ZCLDRDQUE2Qjs7SUFDN0IsMENBQWlCOztJQUNqQixrREFBeUI7O0lBQ3pCLGlEQUF3Qjs7SUFDeEIsa0RBQXlCOztJQUN6QixxREFBNEI7O0lBQzVCLHdEQUErQjs7Ozs7SUFLL0IsdUNBQXlCOztJQUN6QixzQ0FBWTs7SUFDWiwyQ0FJRTs7Ozs7SUFLRiwyQ0FBa0I7O0lBQ2xCLDJDQUFxQjs7SUFDckIsMkNBQXFCOztJQStTbkIsNENBQXVDOzs7OztJQUN2QyxxQ0FBc0I7Ozs7O0lBQ3RCLHVDQUEyQjs7Ozs7SUFDM0Isb0NBQXlCOzs7OztJQUN6QixrQ0FBOEI7O0lBQzlCLDBDQUErRCIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gIENvbXBvbmVudCxcbiAgRWxlbWVudFJlZixcbiAgSG9zdCxcbiAgSG9zdExpc3RlbmVyLFxuICBJbnB1dCxcbiAgTmdab25lLFxuICBPbkNoYW5nZXMsXG4gIE9uRGVzdHJveSxcbiAgT25Jbml0LFxuICBPcHRpb25hbCxcbiAgUmVuZGVyZXIyLFxuICBUZW1wbGF0ZVJlZixcbiAgVmlld0NoaWxkXG59IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgZnJvbUV2ZW50LCBPYnNlcnZhYmxlLCBTdWJqZWN0IH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyBmaWx0ZXIsIHRha2VVbnRpbCB9IGZyb20gJ3J4anMvb3BlcmF0b3JzJztcblxuaW1wb3J0IHtcbiAgY29sbGFwc2VNb3Rpb24sXG4gIElucHV0Qm9vbGVhbixcbiAgTnpGb3JtYXRCZWZvcmVEcm9wRXZlbnQsXG4gIE56Tm9BbmltYXRpb25EaXJlY3RpdmUsXG4gIE56VHJlZUJhc2VTZXJ2aWNlLFxuICBOelRyZWVOb2RlXG59IGZyb20gJ25nLXpvcnJvLWFudGQvY29yZSc7XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ256LXRyZWUtbm9kZScsXG4gIGV4cG9ydEFzOiAnbnpUcmVlTm9kZScsXG4gIHRlbXBsYXRlVXJsOiAnLi9uei10cmVlLW5vZGUuY29tcG9uZW50Lmh0bWwnLFxuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbiAgcHJlc2VydmVXaGl0ZXNwYWNlczogZmFsc2UsXG4gIGFuaW1hdGlvbnM6IFtjb2xsYXBzZU1vdGlvbl1cbn0pXG5leHBvcnQgY2xhc3MgTnpUcmVlTm9kZUNvbXBvbmVudCBpbXBsZW1lbnRzIE9uSW5pdCwgT25DaGFuZ2VzLCBPbkRlc3Ryb3kge1xuICBAVmlld0NoaWxkKCdkcmFnRWxlbWVudCcpIGRyYWdFbGVtZW50OiBFbGVtZW50UmVmO1xuXG4gIC8qKlxuICAgKiBmb3IgZ2xvYmFsIHByb3BlcnR5XG4gICAqL1xuICBASW5wdXQoKSBuelRyZWVOb2RlOiBOelRyZWVOb2RlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpTaG93TGluZTogYm9vbGVhbjtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56U2hvd0V4cGFuZDogYm9vbGVhbjtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56Q2hlY2thYmxlOiBib29sZWFuO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpBc3luY0RhdGE6IGJvb2xlYW47XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekhpZGVVbk1hdGNoZWQgPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56Tm9BbmltYXRpb24gPSBmYWxzZTtcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56U2VsZWN0TW9kZSA9IGZhbHNlO1xuICBASW5wdXQoKSBASW5wdXRCb29sZWFuKCkgbnpTaG93SWNvbiA9IGZhbHNlO1xuICBASW5wdXQoKSBuekV4cGFuZGVkSWNvbjogVGVtcGxhdGVSZWY8eyAkaW1wbGljaXQ6IE56VHJlZU5vZGUgfT47XG4gIEBJbnB1dCgpIG56VHJlZVRlbXBsYXRlOiBUZW1wbGF0ZVJlZjx7ICRpbXBsaWNpdDogTnpUcmVlTm9kZSB9PjtcbiAgQElucHV0KCkgbnpCZWZvcmVEcm9wOiAoY29uZmlybTogTnpGb3JtYXRCZWZvcmVEcm9wRXZlbnQpID0+IE9ic2VydmFibGU8Ym9vbGVhbj47XG5cbiAgQElucHV0KClcbiAgc2V0IG56RHJhZ2dhYmxlKHZhbHVlOiBib29sZWFuKSB7XG4gICAgdGhpcy5fbnpEcmFnZ2FibGUgPSB2YWx1ZTtcbiAgICB0aGlzLmhhbmREcmFnRXZlbnQoKTtcbiAgfVxuXG4gIGdldCBuekRyYWdnYWJsZSgpOiBib29sZWFuIHtcbiAgICByZXR1cm4gdGhpcy5fbnpEcmFnZ2FibGU7XG4gIH1cblxuICAvKipcbiAgICogQGRlcHJlY2F0ZWQgdXNlXG4gICAqIG56RXhwYW5kQWxsIGluc3RlYWRcbiAgICovXG4gIEBJbnB1dCgpXG4gIHNldCBuekRlZmF1bHRFeHBhbmRBbGwodmFsdWU6IGJvb2xlYW4pIHtcbiAgICB0aGlzLl9uekV4cGFuZEFsbCA9IHZhbHVlO1xuICAgIGlmICh2YWx1ZSAmJiB0aGlzLm56VHJlZU5vZGUgJiYgIXRoaXMubnpUcmVlTm9kZS5pc0xlYWYpIHtcbiAgICAgIHRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkID0gdHJ1ZTtcbiAgICB9XG4gIH1cblxuICBnZXQgbnpEZWZhdWx0RXhwYW5kQWxsKCk6IGJvb2xlYW4ge1xuICAgIHJldHVybiB0aGlzLl9uekV4cGFuZEFsbDtcbiAgfVxuXG4gIC8vIGRlZmF1bHQgc2V0XG4gIEBJbnB1dCgpXG4gIHNldCBuekV4cGFuZEFsbCh2YWx1ZTogYm9vbGVhbikge1xuICAgIHRoaXMuX256RXhwYW5kQWxsID0gdmFsdWU7XG4gICAgaWYgKHZhbHVlICYmIHRoaXMubnpUcmVlTm9kZSAmJiAhdGhpcy5uelRyZWVOb2RlLmlzTGVhZikge1xuICAgICAgdGhpcy5uelRyZWVOb2RlLmlzRXhwYW5kZWQgPSB0cnVlO1xuICAgIH1cbiAgfVxuXG4gIGdldCBuekV4cGFuZEFsbCgpOiBib29sZWFuIHtcbiAgICByZXR1cm4gdGhpcy5fbnpFeHBhbmRBbGw7XG4gIH1cblxuICBASW5wdXQoKVxuICBzZXQgbnpTZWFyY2hWYWx1ZSh2YWx1ZTogc3RyaW5nKSB7XG4gICAgdGhpcy5oaWdobGlnaHRLZXlzID0gW107XG4gICAgaWYgKHZhbHVlICYmIHRoaXMubnpUcmVlTm9kZS50aXRsZSEuaW5jbHVkZXModmFsdWUpKSB7XG4gICAgICAvLyBtYXRjaCB0aGUgc2VhcmNoIHZhbHVlXG4gICAgICBjb25zdCBpbmRleCA9IHRoaXMubnpUcmVlTm9kZS50aXRsZS5pbmRleE9mKHZhbHVlKTtcbiAgICAgIHRoaXMuaGlnaGxpZ2h0S2V5cyA9IFtcbiAgICAgICAgdGhpcy5uelRyZWVOb2RlLnRpdGxlLnNsaWNlKDAsIGluZGV4KSxcbiAgICAgICAgdGhpcy5uelRyZWVOb2RlLnRpdGxlLnNsaWNlKGluZGV4ICsgdmFsdWUubGVuZ3RoLCB0aGlzLm56VHJlZU5vZGUudGl0bGUubGVuZ3RoKVxuICAgICAgXTtcbiAgICB9XG4gICAgdGhpcy5fc2VhcmNoVmFsdWUgPSB2YWx1ZTtcbiAgfVxuXG4gIGdldCBuelNlYXJjaFZhbHVlKCk6IHN0cmluZyB7XG4gICAgcmV0dXJuIHRoaXMuX3NlYXJjaFZhbHVlO1xuICB9XG5cbiAgLy8gZGVmYXVsdCB2YXJcbiAgcHJlZml4Q2xzID0gJ2FudC10cmVlJztcbiAgaGlnaGxpZ2h0S2V5czogc3RyaW5nW10gPSBbXTtcbiAgbnpOb2RlQ2xhc3MgPSB7fTtcbiAgbnpOb2RlU3dpdGNoZXJDbGFzcyA9IHt9O1xuICBuek5vZGVDb250ZW50Q2xhc3MgPSB7fTtcbiAgbnpOb2RlQ2hlY2tib3hDbGFzcyA9IHt9O1xuICBuek5vZGVDb250ZW50SWNvbkNsYXNzID0ge307XG4gIG56Tm9kZUNvbnRlbnRMb2FkaW5nQ2xhc3MgPSB7fTtcblxuICAvKipcbiAgICogZHJhZyB2YXJcbiAgICovXG4gIGRlc3Ryb3kkID0gbmV3IFN1YmplY3QoKTtcbiAgZHJhZ1BvcyA9IDI7XG4gIGRyYWdQb3NDbGFzczogeyBba2V5OiBzdHJpbmddOiBzdHJpbmcgfSA9IHtcbiAgICAnMCc6ICdkcmFnLW92ZXInLFxuICAgICcxJzogJ2RyYWctb3Zlci1nYXAtYm90dG9tJyxcbiAgICAnLTEnOiAnZHJhZy1vdmVyLWdhcC10b3AnXG4gIH07XG5cbiAgLyoqXG4gICAqIGRlZmF1bHQgc2V0XG4gICAqL1xuICBfc2VhcmNoVmFsdWUgPSAnJztcbiAgX256RHJhZ2dhYmxlID0gZmFsc2U7XG4gIF9uekV4cGFuZEFsbCA9IGZhbHNlO1xuXG4gIGdldCBuekljb24oKTogc3RyaW5nIHtcbiAgICByZXR1cm4gdGhpcy5uelRyZWVOb2RlLmljb247XG4gIH1cblxuICBnZXQgY2FuRHJhZ2dhYmxlKCk6IGJvb2xlYW4gfCBudWxsIHtcbiAgICByZXR1cm4gdGhpcy5uekRyYWdnYWJsZSAmJiAhdGhpcy5uelRyZWVOb2RlLmlzRGlzYWJsZWQgPyB0cnVlIDogbnVsbDtcbiAgfVxuXG4gIGdldCBpc1Nob3dMaW5lSWNvbigpOiBib29sZWFuIHtcbiAgICByZXR1cm4gIXRoaXMubnpUcmVlTm9kZS5pc0xlYWYgJiYgdGhpcy5uelNob3dMaW5lO1xuICB9XG5cbiAgZ2V0IGlzU2hvd1N3aXRjaEljb24oKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuICF0aGlzLm56VHJlZU5vZGUuaXNMZWFmICYmICF0aGlzLm56U2hvd0xpbmU7XG4gIH1cblxuICBnZXQgaXNTd2l0Y2hlck9wZW4oKTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkICYmICF0aGlzLm56VHJlZU5vZGUuaXNMZWFmO1xuICB9XG5cbiAgZ2V0IGlzU3dpdGNoZXJDbG9zZSgpOiBib29sZWFuIHtcbiAgICByZXR1cm4gIXRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkICYmICF0aGlzLm56VHJlZU5vZGUuaXNMZWFmO1xuICB9XG5cbiAgZ2V0IGRpc3BsYXlTdHlsZSgpOiBzdHJpbmcge1xuICAgIC8vIHRvIGhpZGUgdW5tYXRjaGVkIG5vZGVzXG4gICAgcmV0dXJuIHRoaXMubnpTZWFyY2hWYWx1ZSAmJiB0aGlzLm56SGlkZVVuTWF0Y2hlZCAmJiAhdGhpcy5uelRyZWVOb2RlLmlzTWF0Y2hlZCAmJiAhdGhpcy5uelRyZWVOb2RlLmlzRXhwYW5kZWRcbiAgICAgID8gJ25vbmUnXG4gICAgICA6ICcnO1xuICB9XG5cbiAgLyoqXG4gICAqIHJlc2V0IG5vZGUgY2xhc3NcbiAgICovXG4gIHNldENsYXNzTWFwKCk6IHZvaWQge1xuICAgIHRoaXMucHJlZml4Q2xzID0gdGhpcy5uelNlbGVjdE1vZGUgPyAnYW50LXNlbGVjdC10cmVlJyA6ICdhbnQtdHJlZSc7XG4gICAgdGhpcy5uek5vZGVDbGFzcyA9IHtcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tdHJlZW5vZGUtZGlzYWJsZWRgXTogdGhpcy5uelRyZWVOb2RlLmlzRGlzYWJsZWQsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXRyZWVub2RlLXN3aXRjaGVyLW9wZW5gXTogdGhpcy5pc1N3aXRjaGVyT3BlbixcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tdHJlZW5vZGUtc3dpdGNoZXItY2xvc2VgXTogdGhpcy5pc1N3aXRjaGVyQ2xvc2UsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXRyZWVub2RlLWNoZWNrYm94LWNoZWNrZWRgXTogdGhpcy5uelRyZWVOb2RlLmlzQ2hlY2tlZCxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tdHJlZW5vZGUtY2hlY2tib3gtaW5kZXRlcm1pbmF0ZWBdOiB0aGlzLm56VHJlZU5vZGUuaXNIYWxmQ2hlY2tlZCxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tdHJlZW5vZGUtc2VsZWN0ZWRgXTogdGhpcy5uelRyZWVOb2RlLmlzU2VsZWN0ZWQsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXRyZWVub2RlLWxvYWRpbmdgXTogdGhpcy5uelRyZWVOb2RlLmlzTG9hZGluZ1xuICAgIH07XG4gICAgdGhpcy5uek5vZGVTd2l0Y2hlckNsYXNzID0ge1xuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1zd2l0Y2hlcmBdOiB0cnVlLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1zd2l0Y2hlci1ub29wYF06IHRoaXMubnpUcmVlTm9kZS5pc0xlYWYsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LXN3aXRjaGVyX29wZW5gXTogdGhpcy5pc1N3aXRjaGVyT3BlbixcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tc3dpdGNoZXJfY2xvc2VgXTogdGhpcy5pc1N3aXRjaGVyQ2xvc2VcbiAgICB9O1xuXG4gICAgdGhpcy5uek5vZGVDaGVja2JveENsYXNzID0ge1xuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1jaGVja2JveGBdOiB0cnVlLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1jaGVja2JveC1jaGVja2VkYF06IHRoaXMubnpUcmVlTm9kZS5pc0NoZWNrZWQsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LWNoZWNrYm94LWluZGV0ZXJtaW5hdGVgXTogdGhpcy5uelRyZWVOb2RlLmlzSGFsZkNoZWNrZWQsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LWNoZWNrYm94LWRpc2FibGVkYF06IHRoaXMubnpUcmVlTm9kZS5pc0Rpc2FibGVkIHx8IHRoaXMubnpUcmVlTm9kZS5pc0Rpc2FibGVDaGVja2JveFxuICAgIH07XG5cbiAgICB0aGlzLm56Tm9kZUNvbnRlbnRDbGFzcyA9IHtcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tbm9kZS1jb250ZW50LXdyYXBwZXJgXTogdHJ1ZSxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tbm9kZS1jb250ZW50LXdyYXBwZXItb3BlbmBdOiB0aGlzLmlzU3dpdGNoZXJPcGVuLFxuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1ub2RlLWNvbnRlbnQtd3JhcHBlci1jbG9zZWBdOiB0aGlzLmlzU3dpdGNoZXJDbG9zZSxcbiAgICAgIFtgJHt0aGlzLnByZWZpeENsc30tbm9kZS1zZWxlY3RlZGBdOiB0aGlzLm56VHJlZU5vZGUuaXNTZWxlY3RlZFxuICAgIH07XG4gICAgdGhpcy5uek5vZGVDb250ZW50SWNvbkNsYXNzID0ge1xuICAgICAgW2Ake3RoaXMucHJlZml4Q2xzfS1pY29uRWxlYF06IHRydWUsXG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LWljb25fX2N1c3RvbWl6ZWBdOiB0cnVlXG4gICAgfTtcbiAgICB0aGlzLm56Tm9kZUNvbnRlbnRMb2FkaW5nQ2xhc3MgPSB7XG4gICAgICBbYCR7dGhpcy5wcmVmaXhDbHN9LWljb25FbGVgXTogdHJ1ZVxuICAgIH07XG4gIH1cblxuICBASG9zdExpc3RlbmVyKCdtb3VzZWRvd24nLCBbJyRldmVudCddKVxuICBvbk1vdXNlZG93bihldmVudDogTW91c2VFdmVudCk6IHZvaWQge1xuICAgIGlmICh0aGlzLm56U2VsZWN0TW9kZSkge1xuICAgICAgZXZlbnQucHJldmVudERlZmF1bHQoKTtcbiAgICB9XG4gIH1cblxuICAvKipcbiAgICogY2xpY2sgbm9kZSB0byBzZWxlY3QsIDIwMG1zIHRvIGRibCBjbGlja1xuICAgKi9cbiAgQEhvc3RMaXN0ZW5lcignY2xpY2snLCBbJyRldmVudCddKVxuICBuekNsaWNrKGV2ZW50OiBNb3VzZUV2ZW50KTogdm9pZCB7XG4gICAgZXZlbnQucHJldmVudERlZmF1bHQoKTtcbiAgICBldmVudC5zdG9wUHJvcGFnYXRpb24oKTtcbiAgICBpZiAodGhpcy5uelRyZWVOb2RlLmlzU2VsZWN0YWJsZSAmJiAhdGhpcy5uelRyZWVOb2RlLmlzRGlzYWJsZWQpIHtcbiAgICAgIHRoaXMubnpUcmVlTm9kZS5pc1NlbGVjdGVkID0gIXRoaXMubnpUcmVlTm9kZS5pc1NlbGVjdGVkO1xuICAgIH1cbiAgICBjb25zdCBldmVudE5leHQgPSB0aGlzLm56VHJlZVNlcnZpY2UuZm9ybWF0RXZlbnQoJ2NsaWNrJywgdGhpcy5uelRyZWVOb2RlLCBldmVudCk7XG4gICAgdGhpcy5uelRyZWVTZXJ2aWNlIS50cmlnZ2VyRXZlbnRDaGFuZ2UkIS5uZXh0KGV2ZW50TmV4dCk7XG4gIH1cblxuICBASG9zdExpc3RlbmVyKCdkYmxjbGljaycsIFsnJGV2ZW50J10pXG4gIG56RGJsQ2xpY2soZXZlbnQ6IE1vdXNlRXZlbnQpOiB2b2lkIHtcbiAgICBldmVudC5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGV2ZW50LnN0b3BQcm9wYWdhdGlvbigpO1xuICAgIGNvbnN0IGV2ZW50TmV4dCA9IHRoaXMubnpUcmVlU2VydmljZS5mb3JtYXRFdmVudCgnZGJsY2xpY2snLCB0aGlzLm56VHJlZU5vZGUsIGV2ZW50KTtcbiAgICB0aGlzLm56VHJlZVNlcnZpY2UhLnRyaWdnZXJFdmVudENoYW5nZSQhLm5leHQoZXZlbnROZXh0KTtcbiAgfVxuXG4gIC8qKlxuICAgKiBAcGFyYW0gZXZlbnRcbiAgICovXG4gIEBIb3N0TGlzdGVuZXIoJ2NvbnRleHRtZW51JywgWyckZXZlbnQnXSlcbiAgbnpDb250ZXh0TWVudShldmVudDogTW91c2VFdmVudCk6IHZvaWQge1xuICAgIGV2ZW50LnByZXZlbnREZWZhdWx0KCk7XG4gICAgZXZlbnQuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgY29uc3QgZXZlbnROZXh0ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdjb250ZXh0bWVudScsIHRoaXMubnpUcmVlTm9kZSwgZXZlbnQpO1xuICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChldmVudE5leHQpO1xuICB9XG5cbiAgLyoqXG4gICAqIGNvbGxhcHNlIG5vZGVcbiAgICogQHBhcmFtIGV2ZW50XG4gICAqL1xuICBfY2xpY2tFeHBhbmQoZXZlbnQ6IE1vdXNlRXZlbnQpOiB2b2lkIHtcbiAgICBldmVudC5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGV2ZW50LnN0b3BQcm9wYWdhdGlvbigpO1xuICAgIGlmICghdGhpcy5uelRyZWVOb2RlLmlzTG9hZGluZyAmJiAhdGhpcy5uelRyZWVOb2RlLmlzTGVhZikge1xuICAgICAgLy8gc2V0IGFzeW5jIHN0YXRlXG4gICAgICBpZiAodGhpcy5uekFzeW5jRGF0YSAmJiB0aGlzLm56VHJlZU5vZGUuY2hpbGRyZW4ubGVuZ3RoID09PSAwICYmICF0aGlzLm56VHJlZU5vZGUuaXNFeHBhbmRlZCkge1xuICAgICAgICB0aGlzLm56VHJlZU5vZGUuaXNMb2FkaW5nID0gdHJ1ZTtcbiAgICAgIH1cbiAgICAgIHRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkID0gIXRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkO1xuICAgICAgY29uc3QgZXZlbnROZXh0ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdleHBhbmQnLCB0aGlzLm56VHJlZU5vZGUsIGV2ZW50KTtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChldmVudE5leHQpO1xuICAgIH1cbiAgfVxuXG4gIC8qKlxuICAgKiBjaGVjayBub2RlXG4gICAqIEBwYXJhbSBldmVudFxuICAgKi9cbiAgX2NsaWNrQ2hlY2tCb3goZXZlbnQ6IE1vdXNlRXZlbnQpOiB2b2lkIHtcbiAgICBldmVudC5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGV2ZW50LnN0b3BQcm9wYWdhdGlvbigpO1xuICAgIC8vIHJldHVybiBpZiBub2RlIGlzIGRpc2FibGVkXG4gICAgaWYgKHRoaXMubnpUcmVlTm9kZS5pc0Rpc2FibGVkIHx8IHRoaXMubnpUcmVlTm9kZS5pc0Rpc2FibGVDaGVja2JveCkge1xuICAgICAgcmV0dXJuO1xuICAgIH1cbiAgICB0aGlzLm56VHJlZU5vZGUuaXNDaGVja2VkID0gIXRoaXMubnpUcmVlTm9kZS5pc0NoZWNrZWQ7XG4gICAgdGhpcy5uelRyZWVOb2RlLmlzSGFsZkNoZWNrZWQgPSBmYWxzZTtcbiAgICBpZiAoIXRoaXMubnpUcmVlU2VydmljZS5pc0NoZWNrU3RyaWN0bHkpIHtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZS5jb25kdWN0KHRoaXMubnpUcmVlTm9kZSk7XG4gICAgfVxuICAgIGNvbnN0IGV2ZW50TmV4dCA9IHRoaXMubnpUcmVlU2VydmljZS5mb3JtYXRFdmVudCgnY2hlY2snLCB0aGlzLm56VHJlZU5vZGUsIGV2ZW50KTtcbiAgICB0aGlzLm56VHJlZVNlcnZpY2UhLnRyaWdnZXJFdmVudENoYW5nZSQhLm5leHQoZXZlbnROZXh0KTtcbiAgfVxuXG4gIC8qKlxuICAgKiBkcmFnIGV2ZW50XG4gICAqIEBwYXJhbSBlXG4gICAqL1xuICBjbGVhckRyYWdDbGFzcygpOiB2b2lkIHtcbiAgICBjb25zdCBkcmFnQ2xhc3MgPSBbJ2RyYWctb3Zlci1nYXAtdG9wJywgJ2RyYWctb3Zlci1nYXAtYm90dG9tJywgJ2RyYWctb3ZlciddO1xuICAgIGRyYWdDbGFzcy5mb3JFYWNoKGUgPT4ge1xuICAgICAgdGhpcy5yZW5kZXJlci5yZW1vdmVDbGFzcyh0aGlzLmRyYWdFbGVtZW50Lm5hdGl2ZUVsZW1lbnQsIGUpO1xuICAgIH0pO1xuICB9XG5cbiAgaGFuZGxlRHJhZ1N0YXJ0KGU6IERyYWdFdmVudCk6IHZvaWQge1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgdHJ5IHtcbiAgICAgIC8vIGllIHRocm93IGVycm9yXG4gICAgICAvLyBmaXJlZm94LW5lZWQtaXRcbiAgICAgIGUuZGF0YVRyYW5zZmVyIS5zZXREYXRhKCd0ZXh0L3BsYWluJywgdGhpcy5uelRyZWVOb2RlLmtleSEpO1xuICAgIH0gY2F0Y2ggKGVycm9yKSB7XG4gICAgICAvLyBlbXB0eVxuICAgIH1cbiAgICB0aGlzLm56VHJlZVNlcnZpY2Uuc2V0U2VsZWN0ZWROb2RlKHRoaXMubnpUcmVlTm9kZSk7XG4gICAgdGhpcy5uelRyZWVOb2RlLmlzRXhwYW5kZWQgPSBmYWxzZTtcbiAgICBjb25zdCBldmVudE5leHQgPSB0aGlzLm56VHJlZVNlcnZpY2UuZm9ybWF0RXZlbnQoJ2RyYWdzdGFydCcsIHRoaXMubnpUcmVlTm9kZSwgZSk7XG4gICAgdGhpcy5uelRyZWVTZXJ2aWNlIS50cmlnZ2VyRXZlbnRDaGFuZ2UkIS5uZXh0KGV2ZW50TmV4dCk7XG4gIH1cblxuICBoYW5kbGVEcmFnRW50ZXIoZTogRHJhZ0V2ZW50KTogdm9pZCB7XG4gICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgLy8gcmVzZXQgcG9zaXRpb25cbiAgICB0aGlzLmRyYWdQb3MgPSAyO1xuICAgIHRoaXMubmdab25lLnJ1bigoKSA9PiB7XG4gICAgICBjb25zdCBub2RlID0gdGhpcy5uelRyZWVTZXJ2aWNlLmdldFNlbGVjdGVkTm9kZSgpO1xuICAgICAgaWYgKG5vZGUgJiYgbm9kZS5rZXkgIT09IHRoaXMubnpUcmVlTm9kZS5rZXkgJiYgIXRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkICYmICF0aGlzLm56VHJlZU5vZGUuaXNMZWFmKSB7XG4gICAgICAgIHRoaXMubnpUcmVlTm9kZS5pc0V4cGFuZGVkID0gdHJ1ZTtcbiAgICAgIH1cbiAgICAgIGNvbnN0IGV2ZW50TmV4dCA9IHRoaXMubnpUcmVlU2VydmljZS5mb3JtYXRFdmVudCgnZHJhZ2VudGVyJywgdGhpcy5uelRyZWVOb2RlLCBlKTtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChldmVudE5leHQpO1xuICAgIH0pO1xuICB9XG5cbiAgaGFuZGxlRHJhZ092ZXIoZTogRHJhZ0V2ZW50KTogdm9pZCB7XG4gICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgY29uc3QgZHJvcFBvc2l0aW9uID0gdGhpcy5uelRyZWVTZXJ2aWNlLmNhbGNEcm9wUG9zaXRpb24oZSk7XG4gICAgaWYgKHRoaXMuZHJhZ1BvcyAhPT0gZHJvcFBvc2l0aW9uKSB7XG4gICAgICB0aGlzLmNsZWFyRHJhZ0NsYXNzKCk7XG4gICAgICB0aGlzLmRyYWdQb3MgPSBkcm9wUG9zaXRpb247XG4gICAgICAvLyBsZWFmIG5vZGUgd2lsbCBwYXNzXG4gICAgICBpZiAoISh0aGlzLmRyYWdQb3MgPT09IDAgJiYgdGhpcy5uelRyZWVOb2RlLmlzTGVhZikpIHtcbiAgICAgICAgdGhpcy5yZW5kZXJlci5hZGRDbGFzcyh0aGlzLmRyYWdFbGVtZW50Lm5hdGl2ZUVsZW1lbnQsIHRoaXMuZHJhZ1Bvc0NsYXNzW3RoaXMuZHJhZ1Bvc10pO1xuICAgICAgfVxuICAgIH1cbiAgICBjb25zdCBldmVudE5leHQgPSB0aGlzLm56VHJlZVNlcnZpY2UuZm9ybWF0RXZlbnQoJ2RyYWdvdmVyJywgdGhpcy5uelRyZWVOb2RlLCBlKTtcbiAgICB0aGlzLm56VHJlZVNlcnZpY2UhLnRyaWdnZXJFdmVudENoYW5nZSQhLm5leHQoZXZlbnROZXh0KTtcbiAgfVxuXG4gIGhhbmRsZURyYWdMZWF2ZShlOiBEcmFnRXZlbnQpOiB2b2lkIHtcbiAgICBlLnN0b3BQcm9wYWdhdGlvbigpO1xuICAgIHRoaXMubmdab25lLnJ1bigoKSA9PiB7XG4gICAgICB0aGlzLmNsZWFyRHJhZ0NsYXNzKCk7XG4gICAgfSk7XG4gICAgY29uc3QgZXZlbnROZXh0ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdkcmFnbGVhdmUnLCB0aGlzLm56VHJlZU5vZGUsIGUpO1xuICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChldmVudE5leHQpO1xuICB9XG5cbiAgaGFuZGxlRHJhZ0Ryb3AoZTogRHJhZ0V2ZW50KTogdm9pZCB7XG4gICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xuICAgIGUuc3RvcFByb3BhZ2F0aW9uKCk7XG4gICAgdGhpcy5uZ1pvbmUucnVuKCgpID0+IHtcbiAgICAgIHRoaXMuY2xlYXJEcmFnQ2xhc3MoKTtcbiAgICAgIGNvbnN0IG5vZGUgPSB0aGlzLm56VHJlZVNlcnZpY2UuZ2V0U2VsZWN0ZWROb2RlKCk7XG4gICAgICBpZiAoIW5vZGUgfHwgKG5vZGUgJiYgbm9kZS5rZXkgPT09IHRoaXMubnpUcmVlTm9kZS5rZXkpIHx8ICh0aGlzLmRyYWdQb3MgPT09IDAgJiYgdGhpcy5uelRyZWVOb2RlLmlzTGVhZikpIHtcbiAgICAgICAgcmV0dXJuO1xuICAgICAgfVxuICAgICAgLy8gcGFzcyBpZiBub2RlIGlzIGxlYWZOb1xuICAgICAgY29uc3QgZHJvcEV2ZW50ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdkcm9wJywgdGhpcy5uelRyZWVOb2RlLCBlKTtcbiAgICAgIGNvbnN0IGRyYWdFbmRFdmVudCA9IHRoaXMubnpUcmVlU2VydmljZS5mb3JtYXRFdmVudCgnZHJhZ2VuZCcsIHRoaXMubnpUcmVlTm9kZSwgZSk7XG4gICAgICBpZiAodGhpcy5uekJlZm9yZURyb3ApIHtcbiAgICAgICAgdGhpcy5uekJlZm9yZURyb3Aoe1xuICAgICAgICAgIGRyYWdOb2RlOiB0aGlzLm56VHJlZVNlcnZpY2UuZ2V0U2VsZWN0ZWROb2RlKCkhLFxuICAgICAgICAgIG5vZGU6IHRoaXMubnpUcmVlTm9kZSxcbiAgICAgICAgICBwb3M6IHRoaXMuZHJhZ1Bvc1xuICAgICAgICB9KS5zdWJzY3JpYmUoKGNhbkRyb3A6IGJvb2xlYW4pID0+IHtcbiAgICAgICAgICBpZiAoY2FuRHJvcCkge1xuICAgICAgICAgICAgdGhpcy5uelRyZWVTZXJ2aWNlLmRyb3BBbmRBcHBseSh0aGlzLm56VHJlZU5vZGUsIHRoaXMuZHJhZ1Bvcyk7XG4gICAgICAgICAgfVxuICAgICAgICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChkcm9wRXZlbnQpO1xuICAgICAgICAgIHRoaXMubnpUcmVlU2VydmljZSEudHJpZ2dlckV2ZW50Q2hhbmdlJCEubmV4dChkcmFnRW5kRXZlbnQpO1xuICAgICAgICB9KTtcbiAgICAgIH0gZWxzZSBpZiAodGhpcy5uelRyZWVOb2RlKSB7XG4gICAgICAgIHRoaXMubnpUcmVlU2VydmljZS5kcm9wQW5kQXBwbHkodGhpcy5uelRyZWVOb2RlLCB0aGlzLmRyYWdQb3MpO1xuICAgICAgICB0aGlzLm56VHJlZVNlcnZpY2UhLnRyaWdnZXJFdmVudENoYW5nZSQhLm5leHQoZHJvcEV2ZW50KTtcbiAgICAgIH1cbiAgICB9KTtcbiAgfVxuXG4gIGhhbmRsZURyYWdFbmQoZTogRHJhZ0V2ZW50KTogdm9pZCB7XG4gICAgZS5zdG9wUHJvcGFnYXRpb24oKTtcbiAgICB0aGlzLm5nWm9uZS5ydW4oKCkgPT4ge1xuICAgICAgLy8gaWYgdXNlciBkbyBub3QgY3VzdG9tIGJlZm9yZURyb3BcbiAgICAgIGlmICghdGhpcy5uekJlZm9yZURyb3ApIHtcbiAgICAgICAgY29uc3QgZXZlbnROZXh0ID0gdGhpcy5uelRyZWVTZXJ2aWNlLmZvcm1hdEV2ZW50KCdkcmFnZW5kJywgdGhpcy5uelRyZWVOb2RlLCBlKTtcbiAgICAgICAgdGhpcy5uelRyZWVTZXJ2aWNlIS50cmlnZ2VyRXZlbnRDaGFuZ2UkIS5uZXh0KGV2ZW50TmV4dCk7XG4gICAgICB9XG4gICAgfSk7XG4gIH1cblxuICAvKipcbiAgICog55uR5ZCs5ouW5ou95LqL5Lu2XG4gICAqL1xuICBoYW5kRHJhZ0V2ZW50KCk6IHZvaWQge1xuICAgIHRoaXMubmdab25lLnJ1bk91dHNpZGVBbmd1bGFyKCgpID0+IHtcbiAgICAgIGlmICh0aGlzLm56RHJhZ2dhYmxlKSB7XG4gICAgICAgIHRoaXMuZGVzdHJveSQgPSBuZXcgU3ViamVjdCgpO1xuICAgICAgICBmcm9tRXZlbnQ8RHJhZ0V2ZW50Pih0aGlzLmVsUmVmLm5hdGl2ZUVsZW1lbnQsICdkcmFnc3RhcnQnKVxuICAgICAgICAgIC5waXBlKHRha2VVbnRpbCh0aGlzLmRlc3Ryb3kkKSlcbiAgICAgICAgICAuc3Vic2NyaWJlKChlOiBEcmFnRXZlbnQpID0+IHRoaXMuaGFuZGxlRHJhZ1N0YXJ0KGUpKTtcbiAgICAgICAgZnJvbUV2ZW50PERyYWdFdmVudD4odGhpcy5lbFJlZi5uYXRpdmVFbGVtZW50LCAnZHJhZ2VudGVyJylcbiAgICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAgICAgLnN1YnNjcmliZSgoZTogRHJhZ0V2ZW50KSA9PiB0aGlzLmhhbmRsZURyYWdFbnRlcihlKSk7XG4gICAgICAgIGZyb21FdmVudDxEcmFnRXZlbnQ+KHRoaXMuZWxSZWYubmF0aXZlRWxlbWVudCwgJ2RyYWdvdmVyJylcbiAgICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAgICAgLnN1YnNjcmliZSgoZTogRHJhZ0V2ZW50KSA9PiB0aGlzLmhhbmRsZURyYWdPdmVyKGUpKTtcbiAgICAgICAgZnJvbUV2ZW50PERyYWdFdmVudD4odGhpcy5lbFJlZi5uYXRpdmVFbGVtZW50LCAnZHJhZ2xlYXZlJylcbiAgICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAgICAgLnN1YnNjcmliZSgoZTogRHJhZ0V2ZW50KSA9PiB0aGlzLmhhbmRsZURyYWdMZWF2ZShlKSk7XG4gICAgICAgIGZyb21FdmVudDxEcmFnRXZlbnQ+KHRoaXMuZWxSZWYubmF0aXZlRWxlbWVudCwgJ2Ryb3AnKVxuICAgICAgICAgIC5waXBlKHRha2VVbnRpbCh0aGlzLmRlc3Ryb3kkKSlcbiAgICAgICAgICAuc3Vic2NyaWJlKChlOiBEcmFnRXZlbnQpID0+IHRoaXMuaGFuZGxlRHJhZ0Ryb3AoZSkpO1xuICAgICAgICBmcm9tRXZlbnQ8RHJhZ0V2ZW50Pih0aGlzLmVsUmVmLm5hdGl2ZUVsZW1lbnQsICdkcmFnZW5kJylcbiAgICAgICAgICAucGlwZSh0YWtlVW50aWwodGhpcy5kZXN0cm95JCkpXG4gICAgICAgICAgLnN1YnNjcmliZSgoZTogRHJhZ0V2ZW50KSA9PiB0aGlzLmhhbmRsZURyYWdFbmQoZSkpO1xuICAgICAgfSBlbHNlIHtcbiAgICAgICAgdGhpcy5kZXN0cm95JC5uZXh0KCk7XG4gICAgICAgIHRoaXMuZGVzdHJveSQuY29tcGxldGUoKTtcbiAgICAgIH1cbiAgICB9KTtcbiAgfVxuXG4gIGlzVGVtcGxhdGVSZWYodmFsdWU6IHt9KTogYm9vbGVhbiB7XG4gICAgcmV0dXJuIHZhbHVlIGluc3RhbmNlb2YgVGVtcGxhdGVSZWY7XG4gIH1cblxuICBtYXJrRm9yQ2hlY2soKTogdm9pZCB7XG4gICAgdGhpcy5jZHIubWFya0ZvckNoZWNrKCk7XG4gIH1cblxuICBjb25zdHJ1Y3RvcihcbiAgICBwdWJsaWMgbnpUcmVlU2VydmljZTogTnpUcmVlQmFzZVNlcnZpY2UsXG4gICAgcHJpdmF0ZSBuZ1pvbmU6IE5nWm9uZSxcbiAgICBwcml2YXRlIHJlbmRlcmVyOiBSZW5kZXJlcjIsXG4gICAgcHJpdmF0ZSBlbFJlZjogRWxlbWVudFJlZixcbiAgICBwcml2YXRlIGNkcjogQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gICAgQEhvc3QoKSBAT3B0aW9uYWwoKSBwdWJsaWMgbm9BbmltYXRpb24/OiBOek5vQW5pbWF0aW9uRGlyZWN0aXZlXG4gICkge31cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICAvLyBpbml0IGV4cGFuZGVkIC8gc2VsZWN0ZWQgLyBjaGVja2VkIGxpc3RcbiAgICBpZiAodGhpcy5uelRyZWVOb2RlLmlzU2VsZWN0ZWQpIHtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZS5zZXROb2RlQWN0aXZlKHRoaXMubnpUcmVlTm9kZSk7XG4gICAgfVxuICAgIGlmICh0aGlzLm56VHJlZU5vZGUuaXNFeHBhbmRlZCkge1xuICAgICAgdGhpcy5uelRyZWVTZXJ2aWNlLnNldEV4cGFuZGVkTm9kZUxpc3QodGhpcy5uelRyZWVOb2RlKTtcbiAgICB9XG4gICAgaWYgKHRoaXMubnpUcmVlTm9kZS5pc0NoZWNrZWQpIHtcbiAgICAgIHRoaXMubnpUcmVlU2VydmljZS5zZXRDaGVja2VkTm9kZUxpc3QodGhpcy5uelRyZWVOb2RlKTtcbiAgICB9XG4gICAgLy8gVE9ET1xuICAgIHRoaXMubnpUcmVlTm9kZS5jb21wb25lbnQgPSB0aGlzO1xuICAgIHRoaXMubnpUcmVlU2VydmljZVxuICAgICAgLmV2ZW50VHJpZ2dlckNoYW5nZWQoKVxuICAgICAgLnBpcGUoXG4gICAgICAgIGZpbHRlcihkYXRhID0+IGRhdGEubm9kZSEua2V5ID09PSB0aGlzLm56VHJlZU5vZGUua2V5KSxcbiAgICAgICAgdGFrZVVudGlsKHRoaXMuZGVzdHJveSQpXG4gICAgICApXG4gICAgICAuc3Vic2NyaWJlKCgpID0+IHtcbiAgICAgICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICAgICAgICB0aGlzLm1hcmtGb3JDaGVjaygpO1xuICAgICAgfSk7XG4gICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICB9XG5cbiAgbmdPbkNoYW5nZXMoKTogdm9pZCB7XG4gICAgdGhpcy5zZXRDbGFzc01hcCgpO1xuICB9XG5cbiAgbmdPbkRlc3Ryb3koKTogdm9pZCB7XG4gICAgdGhpcy5kZXN0cm95JC5uZXh0KCk7XG4gICAgdGhpcy5kZXN0cm95JC5jb21wbGV0ZSgpO1xuICB9XG59XG4iXX0=