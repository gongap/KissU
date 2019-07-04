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
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Input, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { of, Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { toBoolean, InputBoolean, InputNumber } from 'ng-zorro-antd/core';
import { NzI18nService } from 'ng-zorro-antd/i18n';
import { NzUploadBtnComponent } from './nz-upload-btn.component';
import { NzUploadListComponent } from './nz-upload-list.component';
var NzUploadComponent = /** @class */ (function () {
    // #endregion
    function NzUploadComponent(cdr, i18n) {
        var _this = this;
        this.cdr = cdr;
        this.i18n = i18n;
        // tslint:disable-next-line:no-any
        this.locale = {};
        // #region fields
        this.nzType = 'select';
        this.nzLimit = 0;
        this.nzSize = 0;
        this.nzDirectory = false;
        this.nzOpenFileDialogOnClick = true;
        this.nzFilter = [];
        this.nzFileList = [];
        this.nzDisabled = false;
        this.nzListType = 'text';
        this.nzMultiple = false;
        this.nzName = 'file';
        this._showUploadList = true;
        this.nzShowButton = true;
        this.nzWithCredentials = false;
        this.nzChange = new EventEmitter();
        this.nzFileListChange = new EventEmitter();
        this.onStart = (/**
         * @param {?} file
         * @return {?}
         */
        function (file) {
            if (!_this.nzFileList) {
                _this.nzFileList = [];
            }
            /** @type {?} */
            var targetItem = _this.fileToObject(file);
            targetItem.status = 'uploading';
            _this.nzFileList = _this.nzFileList.concat(targetItem);
            _this.nzFileListChange.emit(_this.nzFileList);
            _this.nzChange.emit({ file: targetItem, fileList: _this.nzFileList, type: 'start' });
            _this.detectChangesList();
        });
        this.onProgress = (/**
         * @param {?} e
         * @param {?} file
         * @return {?}
         */
        function (e, file) {
            /** @type {?} */
            var fileList = _this.nzFileList;
            /** @type {?} */
            var targetItem = _this.getFileItem(file, fileList);
            targetItem.percent = e.percent;
            _this.nzChange.emit({
                event: e,
                file: tslib_1.__assign({}, targetItem),
                fileList: _this.nzFileList,
                type: 'progress'
            });
            _this.detectChangesList();
        });
        this.onSuccess = (/**
         * @param {?} res
         * @param {?} file
         * @return {?}
         */
        function (res, file) {
            /** @type {?} */
            var fileList = _this.nzFileList;
            /** @type {?} */
            var targetItem = _this.getFileItem(file, fileList);
            targetItem.status = 'done';
            targetItem.response = res;
            _this.nzChange.emit({
                file: tslib_1.__assign({}, targetItem),
                fileList: fileList,
                type: 'success'
            });
            _this.detectChangesList();
        });
        this.onError = (/**
         * @param {?} err
         * @param {?} file
         * @return {?}
         */
        function (err, file) {
            /** @type {?} */
            var fileList = _this.nzFileList;
            /** @type {?} */
            var targetItem = _this.getFileItem(file, fileList);
            targetItem.error = err;
            targetItem.status = 'error';
            targetItem.message = _this.genErr(targetItem);
            _this.nzChange.emit({
                file: tslib_1.__assign({}, targetItem),
                fileList: fileList,
                type: 'error'
            });
            _this.detectChangesList();
        });
        this.onRemove = (/**
         * @param {?} file
         * @return {?}
         */
        function (file) {
            _this.uploadComp.abort(file);
            file.status = 'removed';
            /** @type {?} */
            var fnRes = typeof _this.nzRemove === 'function' ? _this.nzRemove(file) : _this.nzRemove == null ? true : _this.nzRemove;
            (fnRes instanceof Observable ? fnRes : of(fnRes)).pipe(filter((/**
             * @param {?} res
             * @return {?}
             */
            function (res) { return res; }))).subscribe((/**
             * @return {?}
             */
            function () {
                _this.nzFileList = _this.removeFileItem(file, _this.nzFileList);
                _this.nzChange.emit({
                    file: file,
                    fileList: _this.nzFileList,
                    type: 'removed'
                });
                _this.nzFileListChange.emit(_this.nzFileList);
                _this.cdr.detectChanges();
            }));
        });
        // #endregion
        // #region styles
        this.prefixCls = 'ant-upload';
        this.classList = [];
    }
    Object.defineProperty(NzUploadComponent.prototype, "nzShowUploadList", {
        get: /**
         * @return {?}
         */
        function () {
            return this._showUploadList;
        },
        set: /**
         * @param {?} value
         * @return {?}
         */
        function (value) {
            this._showUploadList = typeof value === 'boolean' ? toBoolean(value) : value;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @private
     * @template THIS
     * @this {THIS}
     * @return {THIS}
     */
    NzUploadComponent.prototype.zipOptions = /**
     * @private
     * @template THIS
     * @this {THIS}
     * @return {THIS}
     */
    function () {
        var _this = this;
        if (typeof (/** @type {?} */ (this)).nzShowUploadList === 'boolean' && (/** @type {?} */ (this)).nzShowUploadList) {
            (/** @type {?} */ (this)).nzShowUploadList = {
                showPreviewIcon: true,
                showRemoveIcon: true,
                hidePreviewIconInNonImage: false
            };
        }
        // filters
        /** @type {?} */
        var filters = (/** @type {?} */ (this)).nzFilter.slice();
        if ((/** @type {?} */ (this)).nzMultiple && (/** @type {?} */ (this)).nzLimit > 0 && filters.findIndex((/**
         * @param {?} w
         * @return {?}
         */
        function (w) { return w.name === 'limit'; })) === -1) {
            filters.push({
                name: 'limit',
                fn: (/**
                 * @param {?} fileList
                 * @return {?}
                 */
                function (fileList) { return fileList.slice(-(/** @type {?} */ (_this)).nzLimit); })
            });
        }
        if ((/** @type {?} */ (this)).nzSize > 0 && filters.findIndex((/**
         * @param {?} w
         * @return {?}
         */
        function (w) { return w.name === 'size'; })) === -1) {
            filters.push({
                name: 'size',
                fn: (/**
                 * @param {?} fileList
                 * @return {?}
                 */
                function (fileList) { return fileList.filter((/**
                 * @param {?} w
                 * @return {?}
                 */
                function (w) { return w.size / 1024 <= (/** @type {?} */ (_this)).nzSize; })); })
            });
        }
        if ((/** @type {?} */ (this)).nzFileType && (/** @type {?} */ (this)).nzFileType.length > 0 && filters.findIndex((/**
         * @param {?} w
         * @return {?}
         */
        function (w) { return w.name === 'type'; })) === -1) {
            /** @type {?} */
            var types_1 = (/** @type {?} */ (this)).nzFileType.split(',');
            filters.push({
                name: 'type',
                fn: (/**
                 * @param {?} fileList
                 * @return {?}
                 */
                function (fileList) { return fileList.filter((/**
                 * @param {?} w
                 * @return {?}
                 */
                function (w) { return ~types_1.indexOf(w.type); })); })
            });
        }
        (/** @type {?} */ (this))._btnOptions = {
            disabled: (/** @type {?} */ (this)).nzDisabled,
            accept: (/** @type {?} */ (this)).nzAccept,
            action: (/** @type {?} */ (this)).nzAction,
            directory: (/** @type {?} */ (this)).nzDirectory,
            openFileDialogOnClick: (/** @type {?} */ (this)).nzOpenFileDialogOnClick,
            beforeUpload: (/** @type {?} */ (this)).nzBeforeUpload,
            customRequest: (/** @type {?} */ (this)).nzCustomRequest,
            data: (/** @type {?} */ (this)).nzData,
            headers: (/** @type {?} */ (this)).nzHeaders,
            name: (/** @type {?} */ (this)).nzName,
            multiple: (/** @type {?} */ (this)).nzMultiple,
            withCredentials: (/** @type {?} */ (this)).nzWithCredentials,
            filters: filters,
            onStart: (/** @type {?} */ (this)).onStart,
            onProgress: (/** @type {?} */ (this)).onProgress,
            onSuccess: (/** @type {?} */ (this)).onSuccess,
            onError: (/** @type {?} */ (this)).onError
        };
        return (/** @type {?} */ (this));
    };
    // #region upload
    // #region upload
    /**
     * @private
     * @param {?} file
     * @return {?}
     */
    NzUploadComponent.prototype.fileToObject = 
    // #region upload
    /**
     * @private
     * @param {?} file
     * @return {?}
     */
    function (file) {
        return {
            lastModified: file.lastModified,
            lastModifiedDate: file.lastModifiedDate,
            name: file.filename || file.name,
            size: file.size,
            type: file.type,
            uid: file.uid,
            response: file.response,
            error: file.error,
            percent: 0,
            // tslint:disable-next-line:no-any
            originFileObj: (/** @type {?} */ (file))
        };
    };
    /**
     * @private
     * @param {?} file
     * @param {?} fileList
     * @return {?}
     */
    NzUploadComponent.prototype.getFileItem = /**
     * @private
     * @param {?} file
     * @param {?} fileList
     * @return {?}
     */
    function (file, fileList) {
        return fileList.filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return item.uid === file.uid; }))[0];
    };
    /**
     * @private
     * @param {?} file
     * @param {?} fileList
     * @return {?}
     */
    NzUploadComponent.prototype.removeFileItem = /**
     * @private
     * @param {?} file
     * @param {?} fileList
     * @return {?}
     */
    function (file, fileList) {
        return fileList.filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return item.uid !== file.uid; }));
    };
    /**
     * @private
     * @param {?} file
     * @return {?}
     */
    NzUploadComponent.prototype.genErr = /**
     * @private
     * @param {?} file
     * @return {?}
     */
    function (file) {
        return file.response && typeof file.response === 'string'
            ? file.response
            : (file.error && file.error.statusText) || this.locale.uploadError;
    };
    /**
     * @param {?} e
     * @return {?}
     */
    NzUploadComponent.prototype.fileDrop = /**
     * @param {?} e
     * @return {?}
     */
    function (e) {
        if (e.type === this.dragState) {
            return;
        }
        this.dragState = e.type;
        this.setClassMap();
    };
    // #endregion
    // #region list
    // #endregion
    // #region list
    /**
     * @private
     * @return {?}
     */
    NzUploadComponent.prototype.detectChangesList = 
    // #endregion
    // #region list
    /**
     * @private
     * @return {?}
     */
    function () {
        this.cdr.detectChanges();
        this.listComp.detectChanges();
    };
    /**
     * @private
     * @return {?}
     */
    NzUploadComponent.prototype.setClassMap = /**
     * @private
     * @return {?}
     */
    function () {
        /** @type {?} */
        var subCls = [];
        if (this.nzType === 'drag') {
            if (this.nzFileList.some((/**
             * @param {?} file
             * @return {?}
             */
            function (file) { return file.status === 'uploading'; }))) {
                subCls.push(this.prefixCls + "-drag-uploading");
            }
            if (this.dragState === 'dragover') {
                subCls.push(this.prefixCls + "-drag-hover");
            }
        }
        else {
            subCls = [this.prefixCls + "-select-" + this.nzListType];
        }
        this.classList = tslib_1.__spread([
            this.prefixCls,
            this.prefixCls + "-" + this.nzType
        ], subCls, [
            (this.nzDisabled && this.prefixCls + "-disabled") || ''
        ]).filter((/**
         * @param {?} item
         * @return {?}
         */
        function (item) { return !!item; }));
        this.cdr.detectChanges();
    };
    // #endregion
    // #endregion
    /**
     * @return {?}
     */
    NzUploadComponent.prototype.ngOnInit = 
    // #endregion
    /**
     * @return {?}
     */
    function () {
        var _this = this;
        this.i18n$ = this.i18n.localeChange.subscribe((/**
         * @return {?}
         */
        function () {
            _this.locale = _this.i18n.getLocaleData('Upload');
            _this.detectChangesList();
        }));
    };
    /**
     * @param {?} changes
     * @return {?}
     */
    NzUploadComponent.prototype.ngOnChanges = /**
     * @param {?} changes
     * @return {?}
     */
    function (changes) {
        var _this = this;
        if (changes.nzFileList) {
            (this.nzFileList || []).forEach((/**
             * @param {?} file
             * @return {?}
             */
            function (file) { return (file.message = _this.genErr(file)); }));
        }
        this.zipOptions().setClassMap();
    };
    /**
     * @return {?}
     */
    NzUploadComponent.prototype.ngOnDestroy = /**
     * @return {?}
     */
    function () {
        this.i18n$.unsubscribe();
    };
    NzUploadComponent.decorators = [
        { type: Component, args: [{
                    selector: 'nz-upload',
                    exportAs: 'nzUpload',
                    template: "<ng-template #list>\n  <nz-upload-list #listComp [style.display]=\"nzShowUploadList ? '' : 'none'\"\n    [locale]=\"locale\"\n    [listType]=\"nzListType\"\n    [items]=\"nzFileList || []\"\n    [icons]=\"nzShowUploadList\"\n    [onPreview]=\"nzPreview\"\n    [onRemove]=\"onRemove\"></nz-upload-list>\n</ng-template>\n<ng-template #con><ng-content></ng-content></ng-template>\n<ng-template #btn>\n  <div [ngClass]=\"classList\" [style.display]=\"nzShowButton ? '' : 'none'\">\n    <div nz-upload-btn #uploadComp [options]=\"_btnOptions\">\n      <ng-template [ngTemplateOutlet]=\"con\"></ng-template>\n    </div>\n  </div>\n</ng-template>\n<ng-container *ngIf=\"nzType === 'drag'; else select\">\n  <div [ngClass]=\"classList\"\n    (drop)=\"fileDrop($event)\"\n    (dragover)=\"fileDrop($event)\"\n    (dragleave)=\"fileDrop($event)\">\n    <div nz-upload-btn #uploadComp [options]=\"_btnOptions\" [classes]=\"{'ant-upload-btn': true}\">\n      <div class=\"ant-upload-drag-container\">\n        <ng-template [ngTemplateOutlet]=\"con\"></ng-template>\n      </div>\n    </div>\n  </div>\n  <ng-template [ngTemplateOutlet]=\"list\"></ng-template>\n</ng-container>\n<ng-template #select>\n  <ng-container *ngIf=\"nzListType === 'picture-card'; else pic\">\n    <ng-template [ngTemplateOutlet]=\"list\"></ng-template>\n    <ng-template [ngTemplateOutlet]=\"btn\"></ng-template>\n  </ng-container>\n</ng-template>\n<ng-template #pic>\n  <ng-template [ngTemplateOutlet]=\"btn\"></ng-template>\n  <ng-template [ngTemplateOutlet]=\"list\"></ng-template>\n</ng-template>",
                    preserveWhitespaces: false,
                    encapsulation: ViewEncapsulation.None,
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    NzUploadComponent.ctorParameters = function () { return [
        { type: ChangeDetectorRef },
        { type: NzI18nService }
    ]; };
    NzUploadComponent.propDecorators = {
        uploadComp: [{ type: ViewChild, args: ['uploadComp',] }],
        listComp: [{ type: ViewChild, args: ['listComp',] }],
        nzType: [{ type: Input }],
        nzLimit: [{ type: Input }],
        nzSize: [{ type: Input }],
        nzFileType: [{ type: Input }],
        nzAccept: [{ type: Input }],
        nzAction: [{ type: Input }],
        nzDirectory: [{ type: Input }],
        nzOpenFileDialogOnClick: [{ type: Input }],
        nzBeforeUpload: [{ type: Input }],
        nzCustomRequest: [{ type: Input }],
        nzData: [{ type: Input }],
        nzFilter: [{ type: Input }],
        nzFileList: [{ type: Input }],
        nzDisabled: [{ type: Input }],
        nzHeaders: [{ type: Input }],
        nzListType: [{ type: Input }],
        nzMultiple: [{ type: Input }],
        nzName: [{ type: Input }],
        nzShowUploadList: [{ type: Input }],
        nzShowButton: [{ type: Input }],
        nzWithCredentials: [{ type: Input }],
        nzRemove: [{ type: Input }],
        nzPreview: [{ type: Input }],
        nzChange: [{ type: Output }],
        nzFileListChange: [{ type: Output }]
    };
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Object)
    ], NzUploadComponent.prototype, "nzLimit", void 0);
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Object)
    ], NzUploadComponent.prototype, "nzSize", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzUploadComponent.prototype, "nzDirectory", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzUploadComponent.prototype, "nzOpenFileDialogOnClick", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzUploadComponent.prototype, "nzDisabled", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzUploadComponent.prototype, "nzMultiple", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzUploadComponent.prototype, "nzShowButton", void 0);
    tslib_1.__decorate([
        InputBoolean(),
        tslib_1.__metadata("design:type", Object)
    ], NzUploadComponent.prototype, "nzWithCredentials", void 0);
    return NzUploadComponent;
}());
export { NzUploadComponent };
if (false) {
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.i18n$;
    /** @type {?} */
    NzUploadComponent.prototype.uploadComp;
    /** @type {?} */
    NzUploadComponent.prototype.listComp;
    /** @type {?} */
    NzUploadComponent.prototype.locale;
    /** @type {?} */
    NzUploadComponent.prototype.nzType;
    /** @type {?} */
    NzUploadComponent.prototype.nzLimit;
    /** @type {?} */
    NzUploadComponent.prototype.nzSize;
    /** @type {?} */
    NzUploadComponent.prototype.nzFileType;
    /** @type {?} */
    NzUploadComponent.prototype.nzAccept;
    /** @type {?} */
    NzUploadComponent.prototype.nzAction;
    /** @type {?} */
    NzUploadComponent.prototype.nzDirectory;
    /** @type {?} */
    NzUploadComponent.prototype.nzOpenFileDialogOnClick;
    /** @type {?} */
    NzUploadComponent.prototype.nzBeforeUpload;
    /** @type {?} */
    NzUploadComponent.prototype.nzCustomRequest;
    /** @type {?} */
    NzUploadComponent.prototype.nzData;
    /** @type {?} */
    NzUploadComponent.prototype.nzFilter;
    /** @type {?} */
    NzUploadComponent.prototype.nzFileList;
    /** @type {?} */
    NzUploadComponent.prototype.nzDisabled;
    /** @type {?} */
    NzUploadComponent.prototype.nzHeaders;
    /** @type {?} */
    NzUploadComponent.prototype.nzListType;
    /** @type {?} */
    NzUploadComponent.prototype.nzMultiple;
    /** @type {?} */
    NzUploadComponent.prototype.nzName;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype._showUploadList;
    /** @type {?} */
    NzUploadComponent.prototype.nzShowButton;
    /** @type {?} */
    NzUploadComponent.prototype.nzWithCredentials;
    /** @type {?} */
    NzUploadComponent.prototype.nzRemove;
    /** @type {?} */
    NzUploadComponent.prototype.nzPreview;
    /** @type {?} */
    NzUploadComponent.prototype.nzChange;
    /** @type {?} */
    NzUploadComponent.prototype.nzFileListChange;
    /** @type {?} */
    NzUploadComponent.prototype._btnOptions;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.onStart;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.onProgress;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.onSuccess;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.onError;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.dragState;
    /** @type {?} */
    NzUploadComponent.prototype.onRemove;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.prefixCls;
    /** @type {?} */
    NzUploadComponent.prototype.classList;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.cdr;
    /**
     * @type {?}
     * @private
     */
    NzUploadComponent.prototype.i18n;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotdXBsb2FkLmNvbXBvbmVudC5qcyIsInNvdXJjZVJvb3QiOiJuZzovL25nLXpvcnJvLWFudGQvdXBsb2FkLyIsInNvdXJjZXMiOlsibnotdXBsb2FkLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7QUFRQSxPQUFPLEVBQ0wsdUJBQXVCLEVBQ3ZCLGlCQUFpQixFQUNqQixTQUFTLEVBQ1QsWUFBWSxFQUNaLEtBQUssRUFJTCxNQUFNLEVBR04sU0FBUyxFQUNULGlCQUFpQixFQUNsQixNQUFNLGVBQWUsQ0FBQztBQUN2QixPQUFPLEVBQUUsRUFBRSxFQUFFLFVBQVUsRUFBZ0IsTUFBTSxNQUFNLENBQUM7QUFDcEQsT0FBTyxFQUFFLE1BQU0sRUFBRSxNQUFNLGdCQUFnQixDQUFDO0FBRXhDLE9BQU8sRUFBRSxTQUFTLEVBQUUsWUFBWSxFQUFFLFdBQVcsRUFBRSxNQUFNLG9CQUFvQixDQUFDO0FBQzFFLE9BQU8sRUFBRSxhQUFhLEVBQUUsTUFBTSxvQkFBb0IsQ0FBQztBQVluRCxPQUFPLEVBQUUsb0JBQW9CLEVBQUUsTUFBTSwyQkFBMkIsQ0FBQztBQUNqRSxPQUFPLEVBQUUscUJBQXFCLEVBQUUsTUFBTSw0QkFBNEIsQ0FBQztBQUVuRTtJQThHRSxhQUFhO0lBRWIsMkJBQW9CLEdBQXNCLEVBQVUsSUFBbUI7UUFBdkUsaUJBQTJFO1FBQXZELFFBQUcsR0FBSCxHQUFHLENBQW1CO1FBQVUsU0FBSSxHQUFKLElBQUksQ0FBZTs7UUFuR3ZFLFdBQU0sR0FBUSxFQUFFLENBQUM7O1FBSVIsV0FBTSxHQUFlLFFBQVEsQ0FBQztRQUNmLFlBQU8sR0FBRyxDQUFDLENBQUM7UUFDWixXQUFNLEdBQUcsQ0FBQyxDQUFDO1FBS1YsZ0JBQVcsR0FBRyxLQUFLLENBQUM7UUFDcEIsNEJBQXVCLEdBQUcsSUFBSSxDQUFDO1FBSS9DLGFBQVEsR0FBbUIsRUFBRSxDQUFDO1FBQzlCLGVBQVUsR0FBaUIsRUFBRSxDQUFDO1FBQ2QsZUFB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bkMsdUNBQTRCOztJQUM1QixxQ0FBcUM7O0lBQ3JDLHFDQUEwQjs7SUFDMUIsd0NBQTZDOztJQUM3QyxvREFBd0Q7O0lBQ3hELDJDQUFxRzs7SUFDckcsNENBQWdFOztJQUNoRSxtQ0FBaUQ7O0lBQ2pELHFDQUF1Qzs7SUFDdkMsdUNBQXVDOztJQUN2Qyx1Q0FBNEM7O0lBQzVDLHNDQUFvRDs7SUFDcEQsdUNBQTZDOztJQUM3Qyx1Q0FBNEM7O0lBQzVDLG1DQUF5Qjs7Ozs7SUFFekIsNENBQWtFOztJQVdsRSx5Q0FBNkM7O0lBQzdDLDhDQUFtRDs7SUFFbkQscUNBQXVFOztJQUN2RSxzQ0FBK0M7O0lBRS9DLHFDQUFxRzs7SUFDckcsNkNBQW1HOztJQUVuRyx3Q0FBOEI7Ozs7O0lBeUY5QixvQ0FVRTs7Ozs7SUFFRix1Q0FXRTs7Ozs7SUFFRixzQ0FXRTs7Ozs7SUFFRixvQ0FZRTs7Ozs7SUFNRixzQ0FBMEI7O0lBbUIxQixxQ0FlRTs7Ozs7SUFNRixzQ0FBaUM7O0lBQ2pDLHNDQUF5Qjs7Ozs7SUFuSWIsZ0NBQThCOzs7OztJQUFFLGlDQUEyQiIsInNvdXJjZXNDb250ZW50IjpbIi8qKlxuICogQGxpY2Vuc2VcbiAqIENvcHlyaWdodCBBbGliYWJhLmNvbSBBbGwgUmlnaHRzIFJlc2VydmVkLlxuICpcbiAqIFVzZSBvZiB0aGlzIHNvdXJjZSBjb2RlIGlzIGdvdmVybmVkIGJ5IGFuIE1JVC1zdHlsZSBsaWNlbnNlIHRoYXQgY2FuIGJlXG4gKiBmb3VuZCBpbiB0aGUgTElDRU5TRSBmaWxlIGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9ORy1aT1JSTy9uZy16b3Jyby1hbnRkL2Jsb2IvbWFzdGVyL0xJQ0VOU0VcbiAqL1xuXG5pbXBvcnQge1xuICBDaGFuZ2VEZXRlY3Rpb25TdHJhdGVneSxcbiAgQ2hhbmdlRGV0ZWN0b3JSZWYsXG4gIENvbXBvbmVudCxcbiAgRXZlbnRFbWl0dGVyLFxuICBJbnB1dCxcbiAgT25DaGFuZ2VzLFxuICBPbkRlc3Ryb3ksXG4gIE9uSW5pdCxcbiAgT3V0cHV0LFxuICBTaW1wbGVDaGFuZ2UsXG4gIFNpbXBsZUNoYW5nZXMsXG4gIFZpZXdDaGlsZCxcbiAgVmlld0VuY2Fwc3VsYXRpb25cbn0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBvZiwgT2JzZXJ2YWJsZSwgU3Vic2NyaXB0aW9uIH0gZnJvbSAncnhqcyc7XG5pbXBvcnQgeyBmaWx0ZXIgfSBmcm9tICdyeGpzL29wZXJhdG9ycyc7XG5cbmltcG9ydCB7IHRvQm9vbGVhbiwgSW5wdXRCb29sZWFuLCBJbnB1dE51bWJlciB9IGZyb20gJ25nLXpvcnJvLWFudGQvY29yZSc7XG5pbXBvcnQgeyBOekkxOG5TZXJ2aWNlIH0gZnJvbSAnbmctem9ycm8tYW50ZC9pMThuJztcblxuaW1wb3J0IHtcbiAgU2hvd1VwbG9hZExpc3RJbnRlcmZhY2UsXG4gIFVwbG9hZENoYW5nZVBhcmFtLFxuICBVcGxvYWRGaWxlLFxuICBVcGxvYWRGaWx0ZXIsXG4gIFVwbG9hZExpc3RUeXBlLFxuICBVcGxvYWRUeXBlLFxuICBVcGxvYWRYSFJBcmdzLFxuICBaaXBCdXR0b25PcHRpb25zXG59IGZyb20gJy4vaW50ZXJmYWNlJztcbmltcG9ydCB7IE56VXBsb2FkQnRuQ29tcG9uZW50IH0gZnJvbSAnLi9uei11cGxvYWQtYnRuLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBOelVwbG9hZExpc3RDb21wb25lbnQgfSBmcm9tICcuL256LXVwbG9hZC1saXN0LmNvbXBvbmVudCc7XG5cbkBDb21wb25lbnQoe1xuICBzZWxlY3RvcjogJ256LXVwbG9hZCcsXG4gIGV4cG9ydEFzOiAnbnpVcGxvYWQnLFxuICB0ZW1wbGF0ZVVybDogJy4vbnotdXBsb2FkLmNvbXBvbmVudC5odG1sJyxcbiAgcHJlc2VydmVXaGl0ZXNwYWNlczogZmFsc2UsXG4gIGVuY2Fwc3VsYXRpb246IFZpZXdFbmNhcHN1bGF0aW9uLk5vbmUsXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoXG59KVxuZXhwb3J0IGNsYXNzIE56VXBsb2FkQ29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0LCBPbkNoYW5nZXMsIE9uRGVzdHJveSB7XG4gIHByaXZhdGUgaTE4biQ6IFN1YnNjcmlwdGlvbjtcbiAgQFZpZXdDaGlsZCgndXBsb2FkQ29tcCcpIHVwbG9hZENvbXA6IE56VXBsb2FkQnRuQ29tcG9uZW50O1xuICBAVmlld0NoaWxkKCdsaXN0Q29tcCcpIGxpc3RDb21wOiBOelVwbG9hZExpc3RDb21wb25lbnQ7XG4gIC8vIHRzbGludDpkaXNhYmxlLW5leHQtbGluZTpuby1hbnlcbiAgbG9jYWxlOiBhbnkgPSB7fTtcblxuICAvLyAjcmVnaW9uIGZpZWxkc1xuXG4gIEBJbnB1dCgpIG56VHlwZTogVXBsb2FkVHlwZSA9ICdzZWxlY3QnO1xuICBASW5wdXQoKSBASW5wdXROdW1iZXIoKSBuekxpbWl0ID0gMDtcbiAgQElucHV0KCkgQElucHV0TnVtYmVyKCkgbnpTaXplID0gMDtcblxuICBASW5wdXQoKSBuekZpbGVUeXBlOiBzdHJpbmc7XG4gIEBJbnB1dCgpIG56QWNjZXB0OiBzdHJpbmcgfCBzdHJpbmdbXTtcbiAgQElucHV0KCkgbnpBY3Rpb246IHN0cmluZztcbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56RGlyZWN0b3J5ID0gZmFsc2U7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuek9wZW5GaWxlRGlhbG9nT25DbGljayA9IHRydWU7XG4gIEBJbnB1dCgpIG56QmVmb3JlVXBsb2FkOiAoZmlsZTogVXBsb2FkRmlsZSwgZmlsZUxpc3Q6IFVwbG9hZEZpbGVbXSkgPT4gYm9vbGVhbiB8IE9ic2VydmFibGU8Ym9vbGVhbj47XG4gIEBJbnB1dCgpIG56Q3VzdG9tUmVxdWVzdDogKGl0ZW06IFVwbG9hZFhIUkFyZ3MpID0+IFN1YnNjcmlwdGlvbjtcbiAgQElucHV0KCkgbnpEYXRhOiB7fSB8ICgoZmlsZTogVXBsb2FkRmlsZSkgPT4ge30pO1xuICBASW5wdXQoKSBuekZpbHRlcjogVXBsb2FkRmlsdGVyW10gPSBbXTtcbiAgQElucHV0KCkgbnpGaWxlTGlzdDogVXBsb2FkRmlsZVtdID0gW107XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuekRpc2FibGVkID0gZmFsc2U7XG4gIEBJbnB1dCgpIG56SGVhZGVyczoge30gfCAoKGZpbGU6IFVwbG9hZEZpbGUpID0+IHt9KTtcbiAgQElucHV0KCkgbnpMaXN0VHlwZTogVXBsb2FkTGlzdFR5cGUgPSAndGV4dCc7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBuek11bHRpcGxlID0gZmFsc2U7XG4gIEBJbnB1dCgpIG56TmFtZSA9ICdmaWxlJztcblxuICBwcml2YXRlIF9zaG93VXBsb2FkTGlzdDogYm9vbGVhbiB8IFNob3dVcGxvYWRMaXN0SW50ZXJmYWNlID0gdHJ1ZTtcblxuICBASW5wdXQoKVxuICBzZXQgbnpTaG93VXBsb2FkTGlzdCh2YWx1ZTogYm9vbGVhbiB8IFNob3dVcGxvYWRMaXN0SW50ZXJmYWNlKSB7XG4gICAgdGhpcy5fc2hvd1VwbG9hZExpc3QgPSB0eXBlb2YgdmFsdWUgPT09ICdib29sZWFuJyA/IHRvQm9vbGVhbih2YWx1ZSkgOiB2YWx1ZTtcbiAgfVxuXG4gIGdldCBuelNob3dVcGxvYWRMaXN0KCk6IGJvb2xlYW4gfCBTaG93VXBsb2FkTGlzdEludGVyZmFjZSB7XG4gICAgcmV0dXJuIHRoaXMuX3Nob3dVcGxvYWRMaXN0O1xuICB9XG5cbiAgQElucHV0KCkgQElucHV0Qm9vbGVhbigpIG56U2hvd0J1dHRvbiA9IHRydWU7XG4gIEBJbnB1dCgpIEBJbnB1dEJvb2xlYW4oKSBueldpdGhDcmVkZW50aWFscyA9IGZhbHNlO1xuXG4gIEBJbnB1dCgpIG56UmVtb3ZlOiAoZmlsZTogVXBsb2FkRmlsZSkgPT4gYm9vbGVhbiB8IE9ic2VydmFibGU8Ym9vbGVhbj47XG4gIEBJbnB1dCgpIG56UHJldmlldzogKGZpbGU6IFVwbG9hZEZpbGUpID0+IHZvaWQ7XG5cbiAgQE91dHB1dCgpIHJlYWRvbmx5IG56Q2hhbmdlOiBFdmVudEVtaXR0ZXI8VXBsb2FkQ2hhbmdlUGFyYW0+ID0gbmV3IEV2ZW50RW1pdHRlcjxVcGxvYWRDaGFuZ2VQYXJhbT4oKTtcbiAgQE91dHB1dCgpIHJlYWRvbmx5IG56RmlsZUxpc3RDaGFuZ2U6IEV2ZW50RW1pdHRlcjxVcGxvYWRGaWxlW10+ID0gbmV3IEV2ZW50RW1pdHRlcjxVcGxvYWRGaWxlW10+KCk7XG5cbiAgX2J0bk9wdGlvbnM6IFppcEJ1dHRvbk9wdGlvbnM7XG5cbiAgcHJpdmF0ZSB6aXBPcHRpb25zKCk6IHRoaXMge1xuICAgIGlmICh0eXBlb2YgdGhpcy5uelNob3dVcGxvYWRMaXN0ID09PSAnYm9vbGVhbicgJiYgdGhpcy5uelNob3dVcGxvYWRMaXN0KSB7XG4gICAgICB0aGlzLm56U2hvd1VwbG9hZExpc3QgPSB7XG4gICAgICAgIHNob3dQcmV2aWV3SWNvbjogdHJ1ZSxcbiAgICAgICAgc2hvd1JlbW92ZUljb246IHRydWUsXG4gICAgICAgIGhpZGVQcmV2aWV3SWNvbkluTm9uSW1hZ2U6IGZhbHNlXG4gICAgICB9O1xuICAgIH1cbiAgICAvLyBmaWx0ZXJzXG4gICAgY29uc3QgZmlsdGVyczogVXBsb2FkRmlsdGVyW10gPSB0aGlzLm56RmlsdGVyLnNsaWNlKCk7XG4gICAgaWYgKHRoaXMubnpNdWx0aXBsZSAmJiB0aGlzLm56TGltaXQgPiAwICYmIGZpbHRlcnMuZmluZEluZGV4KHcgPT4gdy5uYW1lID09PSAnbGltaXQnKSA9PT0gLTEpIHtcbiAgICAgIGZpbHRlcnMucHVzaCh7XG4gICAgICAgIG5hbWU6ICdsaW1pdCcsXG4gICAgICAgIGZuOiAoZmlsZUxpc3Q6IFVwbG9hZEZpbGVbXSkgPT4gZmlsZUxpc3Quc2xpY2UoLXRoaXMubnpMaW1pdClcbiAgICAgIH0pO1xuICAgIH1cbiAgICBpZiAodGhpcy5uelNpemUgPiAwICYmIGZpbHRlcnMuZmluZEluZGV4KHcgPT4gdy5uYW1lID09PSAnc2l6ZScpID09PSAtMSkge1xuICAgICAgZmlsdGVycy5wdXNoKHtcbiAgICAgICAgbmFtZTogJ3NpemUnLFxuICAgICAgICBmbjogKGZpbGVMaXN0OiBVcGxvYWRGaWxlW10pID0+IGZpbGVMaXN0LmZpbHRlcih3ID0+IHcuc2l6ZSAvIDEwMjQgPD0gdGhpcy5uelNpemUpXG4gICAgICB9KTtcbiAgICB9XG4gICAgaWYgKHRoaXMubnpGaWxlVHlwZSAmJiB0aGlzLm56RmlsZVR5cGUubGVuZ3RoID4gMCAmJiBmaWx0ZXJzLmZpbmRJbmRleCh3ID0+IHcubmFtZSA9PT0gJ3R5cGUnKSA9PT0gLTEpIHtcbiAgICAgIGNvbnN0IHR5cGVzID0gdGhpcy5uekZpbGVUeXBlLnNwbGl0KCcsJyk7XG4gICAgICBmaWx0ZXJzLnB1c2goe1xuICAgICAgICBuYW1lOiAndHlwZScsXG4gICAgICAgIGZuOiAoZmlsZUxpc3Q6IFVwbG9hZEZpbGVbXSkgPT4gZmlsZUxpc3QuZmlsdGVyKHcgPT4gfnR5cGVzLmluZGV4T2Yody50eXBlKSlcbiAgICAgIH0pO1xuICAgIH1cbiAgICB0aGlzLl9idG5PcHRpb25zID0ge1xuICAgICAgZGlzYWJsZWQ6IHRoaXMubnpEaXNhYmxlZCxcbiAgICAgIGFjY2VwdDogdGhpcy5uekFjY2VwdCxcbiAgICAgIGFjdGlvbjogdGhpcy5uekFjdGlvbixcbiAgICAgIGRpcmVjdG9yeTogdGhpcy5uekRpcmVjdG9yeSxcbiAgICAgIG9wZW5GaWxlRGlhbG9nT25DbGljazogdGhpcy5uek9wZW5GaWxlRGlhbG9nT25DbGljayxcbiAgICAgIGJlZm9yZVVwbG9hZDogdGhpcy5uekJlZm9yZVVwbG9hZCxcbiAgICAgIGN1c3RvbVJlcXVlc3Q6IHRoaXMubnpDdXN0b21SZXF1ZXN0LFxuICAgICAgZGF0YTogdGhpcy5uekRhdGEsXG4gICAgICBoZWFkZXJzOiB0aGlzLm56SGVhZGVycyxcbiAgICAgIG5hbWU6IHRoaXMubnpOYW1lLFxuICAgICAgbXVsdGlwbGU6IHRoaXMubnpNdWx0aXBsZSxcbiAgICAgIHdpdGhDcmVkZW50aWFsczogdGhpcy5ueldpdGhDcmVkZW50aWFscyxcbiAgICAgIGZpbHRlcnMsXG4gICAgICBvblN0YXJ0OiB0aGlzLm9uU3RhcnQsXG4gICAgICBvblByb2dyZXNzOiB0aGlzLm9uUHJvZ3Jlc3MsXG4gICAgICBvblN1Y2Nlc3M6IHRoaXMub25TdWNjZXNzLFxuICAgICAgb25FcnJvcjogdGhpcy5vbkVycm9yXG4gICAgfTtcbiAgICByZXR1cm4gdGhpcztcbiAgfVxuXG4gIC8vICNlbmRyZWdpb25cblxuICBjb25zdHJ1Y3Rvcihwcml2YXRlIGNkcjogQ2hhbmdlRGV0ZWN0b3JSZWYsIHByaXZhdGUgaTE4bjogTnpJMThuU2VydmljZSkge31cblxuICAvLyAjcmVnaW9uIHVwbG9hZFxuXG4gIHByaXZhdGUgZmlsZVRvT2JqZWN0KGZpbGU6IFVwbG9hZEZpbGUpOiBVcGxvYWRGaWxlIHtcbiAgICByZXR1cm4ge1xuICAgICAgbGFzdE1vZGlmaWVkOiBmaWxlLmxhc3RNb2RpZmllZCxcbiAgICAgIGxhc3RNb2RpZmllZERhdGU6IGZpbGUubGFzdE1vZGlmaWVkRGF0ZSxcbiAgICAgIG5hbWU6IGZpbGUuZmlsZW5hbWUgfHwgZmlsZS5uYW1lLFxuICAgICAgc2l6ZTogZmlsZS5zaXplLFxuICAgICAgdHlwZTogZmlsZS50eXBlLFxuICAgICAgdWlkOiBmaWxlLnVpZCxcbiAgICAgIHJlc3BvbnNlOiBmaWxlLnJlc3BvbnNlLFxuICAgICAgZXJyb3I6IGZpbGUuZXJyb3IsXG4gICAgICBwZXJjZW50OiAwLFxuICAgICAgLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOm5vLWFueVxuICAgICAgb3JpZ2luRmlsZU9iajogZmlsZSBhcyBhbnlcbiAgICB9O1xuICB9XG5cbiAgcHJpdmF0ZSBnZXRGaWxlSXRlbShmaWxlOiBVcGxvYWRGaWxlLCBmaWxlTGlzdDogVXBsb2FkRmlsZVtdKTogVXBsb2FkRmlsZSB7XG4gICAgcmV0dXJuIGZpbGVMaXN0LmZpbHRlcihpdGVtID0+IGl0ZW0udWlkID09PSBmaWxlLnVpZClbMF07XG4gIH1cblxuICBwcml2YXRlIHJlbW92ZUZpbGVJdGVtKGZpbGU6IFVwbG9hZEZpbGUsIGZpbGVMaXN0OiBVcGxvYWRGaWxlW10pOiBVcGxvYWRGaWxlW10ge1xuICAgIHJldHVybiBmaWxlTGlzdC5maWx0ZXIoaXRlbSA9PiBpdGVtLnVpZCAhPT0gZmlsZS51aWQpO1xuICB9XG5cbiAgcHJpdmF0ZSBnZW5FcnIoZmlsZTogVXBsb2FkRmlsZSk6IHN0cmluZyB7XG4gICAgcmV0dXJuIGZpbGUucmVzcG9uc2UgJiYgdHlwZW9mIGZpbGUucmVzcG9uc2UgPT09ICdzdHJpbmcnXG4gICAgICA/IGZpbGUucmVzcG9uc2VcbiAgICAgIDogKGZpbGUuZXJyb3IgJiYgZmlsZS5lcnJvci5zdGF0dXNUZXh0KSB8fCB0aGlzLmxvY2FsZS51cGxvYWRFcnJvcjtcbiAgfVxuXG4gIHByaXZhdGUgb25TdGFydCA9IChmaWxlOiBVcGxvYWRGaWxlKTogdm9pZCA9PiB7XG4gICAgaWYgKCF0aGlzLm56RmlsZUxpc3QpIHtcbiAgICAgIHRoaXMubnpGaWxlTGlzdCA9IFtdO1xuICAgIH1cbiAgICBjb25zdCB0YXJnZXRJdGVtID0gdGhpcy5maWxlVG9PYmplY3QoZmlsZSk7XG4gICAgdGFyZ2V0SXRlbS5zdGF0dXMgPSAndXBsb2FkaW5nJztcbiAgICB0aGlzLm56RmlsZUxpc3QgPSB0aGlzLm56RmlsZUxpc3QuY29uY2F0KHRhcmdldEl0ZW0pO1xuICAgIHRoaXMubnpGaWxlTGlzdENoYW5nZS5lbWl0KHRoaXMubnpGaWxlTGlzdCk7XG4gICAgdGhpcy5uekNoYW5nZS5lbWl0KHsgZmlsZTogdGFyZ2V0SXRlbSwgZmlsZUxpc3Q6IHRoaXMubnpGaWxlTGlzdCwgdHlwZTogJ3N0YXJ0JyB9KTtcbiAgICB0aGlzLmRldGVjdENoYW5nZXNMaXN0KCk7XG4gIH07XG5cbiAgcHJpdmF0ZSBvblByb2dyZXNzID0gKGU6IHsgcGVyY2VudDogbnVtYmVyIH0sIGZpbGU6IFVwbG9hZEZpbGUpOiB2b2lkID0+IHtcbiAgICBjb25zdCBmaWxlTGlzdCA9IHRoaXMubnpGaWxlTGlzdDtcbiAgICBjb25zdCB0YXJnZXRJdGVtID0gdGhpcy5nZXRGaWxlSXRlbShmaWxlLCBmaWxlTGlzdCk7XG4gICAgdGFyZ2V0SXRlbS5wZXJjZW50ID0gZS5wZXJjZW50O1xuICAgIHRoaXMubnpDaGFuZ2UuZW1pdCh7XG4gICAgICBldmVudDogZSxcbiAgICAgIGZpbGU6IHsgLi4udGFyZ2V0SXRlbSB9LFxuICAgICAgZmlsZUxpc3Q6IHRoaXMubnpGaWxlTGlzdCxcbiAgICAgIHR5cGU6ICdwcm9ncmVzcydcbiAgICB9KTtcbiAgICB0aGlzLmRldGVjdENoYW5nZXNMaXN0KCk7XG4gIH07XG5cbiAgcHJpdmF0ZSBvblN1Y2Nlc3MgPSAocmVzOiB7fSwgZmlsZTogVXBsb2FkRmlsZSk6IHZvaWQgPT4ge1xuICAgIGNvbnN0IGZpbGVMaXN0ID0gdGhpcy5uekZpbGVMaXN0O1xuICAgIGNvbnN0IHRhcmdldEl0ZW0gPSB0aGlzLmdldEZpbGVJdGVtKGZpbGUsIGZpbGVMaXN0KTtcbiAgICB0YXJnZXRJdGVtLnN0YXR1cyA9ICdkb25lJztcbiAgICB0YXJnZXRJdGVtLnJlc3BvbnNlID0gcmVzO1xuICAgIHRoaXMubnpDaGFuZ2UuZW1pdCh7XG4gICAgICBmaWxlOiB7IC4uLnRhcmdldEl0ZW0gfSxcbiAgICAgIGZpbGVMaXN0LFxuICAgICAgdHlwZTogJ3N1Y2Nlc3MnXG4gICAgfSk7XG4gICAgdGhpcy5kZXRlY3RDaGFuZ2VzTGlzdCgpO1xuICB9O1xuXG4gIHByaXZhdGUgb25FcnJvciA9IChlcnI6IHt9LCBmaWxlOiBVcGxvYWRGaWxlKTogdm9pZCA9PiB7XG4gICAgY29uc3QgZmlsZUxpc3QgPSB0aGlzLm56RmlsZUxpc3Q7XG4gICAgY29uc3QgdGFyZ2V0SXRlbSA9IHRoaXMuZ2V0RmlsZUl0ZW0oZmlsZSwgZmlsZUxpc3QpO1xuICAgIHRhcmdldEl0ZW0uZXJyb3IgPSBlcnI7XG4gICAgdGFyZ2V0SXRlbS5zdGF0dXMgPSAnZXJyb3InO1xuICAgIHRhcmdldEl0ZW0ubWVzc2FnZSA9IHRoaXMuZ2VuRXJyKHRhcmdldEl0ZW0pO1xuICAgIHRoaXMubnpDaGFuZ2UuZW1pdCh7XG4gICAgICBmaWxlOiB7IC4uLnRhcmdldEl0ZW0gfSxcbiAgICAgIGZpbGVMaXN0LFxuICAgICAgdHlwZTogJ2Vycm9yJ1xuICAgIH0pO1xuICAgIHRoaXMuZGV0ZWN0Q2hhbmdlc0xpc3QoKTtcbiAgfTtcblxuICAvLyAjZW5kcmVnaW9uXG5cbiAgLy8gI3JlZ2lvbiBkcmFnXG5cbiAgcHJpdmF0ZSBkcmFnU3RhdGU6IHN0cmluZztcblxuICBmaWxlRHJvcChlOiBEcmFnRXZlbnQpOiB2b2lkIHtcbiAgICBpZiAoZS50eXBlID09PSB0aGlzLmRyYWdTdGF0ZSkge1xuICAgICAgcmV0dXJuO1xuICAgIH1cbiAgICB0aGlzLmRyYWdTdGF0ZSA9IGUudHlwZTtcbiAgICB0aGlzLnNldENsYXNzTWFwKCk7XG4gIH1cblxuICAvLyAjZW5kcmVnaW9uXG5cbiAgLy8gI3JlZ2lvbiBsaXN0XG5cbiAgcHJpdmF0ZSBkZXRlY3RDaGFuZ2VzTGlzdCgpOiB2b2lkIHtcbiAgICB0aGlzLmNkci5kZXRlY3RDaGFuZ2VzKCk7XG4gICAgdGhpcy5saXN0Q29tcC5kZXRlY3RDaGFuZ2VzKCk7XG4gIH1cblxuICBvblJlbW92ZSA9IChmaWxlOiBVcGxvYWRGaWxlKTogdm9pZCA9PiB7XG4gICAgdGhpcy51cGxvYWRDb21wLmFib3J0KGZpbGUpO1xuICAgIGZpbGUuc3RhdHVzID0gJ3JlbW92ZWQnO1xuICAgIGNvbnN0IGZuUmVzID1cbiAgICAgIHR5cGVvZiB0aGlzLm56UmVtb3ZlID09PSAnZnVuY3Rpb24nID8gdGhpcy5uelJlbW92ZShmaWxlKSA6IHRoaXMubnpSZW1vdmUgPT0gbnVsbCA/IHRydWUgOiB0aGlzLm56UmVtb3ZlO1xuICAgIChmblJlcyBpbnN0YW5jZW9mIE9ic2VydmFibGUgPyBmblJlcyA6IG9mKGZuUmVzKSkucGlwZShmaWx0ZXIoKHJlczogYm9vbGVhbikgPT4gcmVzKSkuc3Vic2NyaWJlKCgpID0+IHtcbiAgICAgIHRoaXMubnpGaWxlTGlzdCA9IHRoaXMucmVtb3ZlRmlsZUl0ZW0oZmlsZSwgdGhpcy5uekZpbGVMaXN0KTtcbiAgICAgIHRoaXMubnpDaGFuZ2UuZW1pdCh7XG4gICAgICAgIGZpbGUsXG4gICAgICAgIGZpbGVMaXN0OiB0aGlzLm56RmlsZUxpc3QsXG4gICAgICAgIHR5cGU6ICdyZW1vdmVkJ1xuICAgICAgfSk7XG4gICAgICB0aGlzLm56RmlsZUxpc3RDaGFuZ2UuZW1pdCh0aGlzLm56RmlsZUxpc3QpO1xuICAgICAgdGhpcy5jZHIuZGV0ZWN0Q2hhbmdlcygpO1xuICAgIH0pO1xuICB9O1xuXG4gIC8vICNlbmRyZWdpb25cblxuICAvLyAjcmVnaW9uIHN0eWxlc1xuXG4gIHByaXZhdGUgcHJlZml4Q2xzID0gJ2FudC11cGxvYWQnO1xuICBjbGFzc0xpc3Q6IHN0cmluZ1tdID0gW107XG5cbiAgcHJpdmF0ZSBzZXRDbGFzc01hcCgpOiB2b2lkIHtcbiAgICBsZXQgc3ViQ2xzOiBzdHJpbmdbXSA9IFtdO1xuICAgIGlmICh0aGlzLm56VHlwZSA9PT0gJ2RyYWcnKSB7XG4gICAgICBpZiAodGhpcy5uekZpbGVMaXN0LnNvbWUoZmlsZSA9PiBmaWxlLnN0YXR1cyA9PT0gJ3VwbG9hZGluZycpKSB7XG4gICAgICAgIHN1YkNscy5wdXNoKGAke3RoaXMucHJlZml4Q2xzfS1kcmFnLXVwbG9hZGluZ2ApO1xuICAgICAgfVxuICAgICAgaWYgKHRoaXMuZHJhZ1N0YXRlID09PSAnZHJhZ292ZXInKSB7XG4gICAgICAgIHN1YkNscy5wdXNoKGAke3RoaXMucHJlZml4Q2xzfS1kcmFnLWhvdmVyYCk7XG4gICAgICB9XG4gICAgfSBlbHNlIHtcbiAgICAgIHN1YkNscyA9IFtgJHt0aGlzLnByZWZpeENsc30tc2VsZWN0LSR7dGhpcy5uekxpc3RUeXBlfWBdO1xuICAgIH1cblxuICAgIHRoaXMuY2xhc3NMaXN0ID0gW1xuICAgICAgdGhpcy5wcmVmaXhDbHMsXG4gICAgICBgJHt0aGlzLnByZWZpeENsc30tJHt0aGlzLm56VHlwZX1gLFxuICAgICAgLi4uc3ViQ2xzLFxuICAgICAgKHRoaXMubnpEaXNhYmxlZCAmJiBgJHt0aGlzLnByZWZpeENsc30tZGlzYWJsZWRgKSB8fCAnJ1xuICAgIF0uZmlsdGVyKGl0ZW0gPT4gISFpdGVtKTtcblxuICAgIHRoaXMuY2RyLmRldGVjdENoYW5nZXMoKTtcbiAgfVxuXG4gIC8vICNlbmRyZWdpb25cblxuICBuZ09uSW5pdCgpOiB2b2lkIHtcbiAgICB0aGlzLmkxOG4kID0gdGhpcy5pMThuLmxvY2FsZUNoYW5nZS5zdWJzY3JpYmUoKCkgPT4ge1xuICAgICAgdGhpcy5sb2NhbGUgPSB0aGlzLmkxOG4uZ2V0TG9jYWxlRGF0YSgnVXBsb2FkJyk7XG4gICAgICB0aGlzLmRldGVjdENoYW5nZXNMaXN0KCk7XG4gICAgfSk7XG4gIH1cblxuICBuZ09uQ2hhbmdlcyhjaGFuZ2VzOiB7IFtQIGluIGtleW9mIHRoaXNdPzogU2ltcGxlQ2hhbmdlIH0gJiBTaW1wbGVDaGFuZ2VzKTogdm9pZCB7XG4gICAgaWYgKGNoYW5nZXMubnpGaWxlTGlzdCkge1xuICAgICAgKHRoaXMubnpGaWxlTGlzdCB8fCBbXSkuZm9yRWFjaChmaWxlID0+IChmaWxlLm1lc3NhZ2UgPSB0aGlzLmdlbkVycihmaWxlKSkpO1xuICAgIH1cbiAgICB0aGlzLnppcE9wdGlvbnMoKS5zZXRDbGFzc01hcCgpO1xuICB9XG5cbiAgbmdPbkRlc3Ryb3koKTogdm9pZCB7XG4gICAgdGhpcy5pMThuJC51bnN1YnNjcmliZSgpO1xuICB9XG59XG4iXX0=