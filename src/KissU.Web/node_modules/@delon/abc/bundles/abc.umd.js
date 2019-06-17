/**
 * @license ng-alain(cipchk@qq.com) v7.0.3
 * (c) 2019 cipchk https://ng-alain.com/
 * License: MIT
 */
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/core'), require('@delon/abc/avatar-list'), require('@delon/abc/count-down'), require('@delon/abc/date-picker'), require('@delon/abc/down-file'), require('@delon/abc/edit'), require('@delon/abc/ellipsis'), require('@delon/abc/error-collect'), require('@delon/abc/exception'), require('@delon/abc/footer-toolbar'), require('@delon/abc/full-content'), require('@delon/abc/global-footer'), require('@delon/abc/grid'), require('@delon/abc/image'), require('@delon/abc/lodop'), require('@delon/abc/notice-icon'), require('@delon/abc/number-to-chinese'), require('@delon/abc/page-header'), require('@delon/abc/qr'), require('@delon/abc/quick-menu'), require('@delon/abc/result'), require('@delon/abc/reuse-tab'), require('@delon/abc/sidebar-nav'), require('@delon/abc/table'), require('@delon/abc/tag-select'), require('@delon/abc/view'), require('@delon/abc/xlsx'), require('@delon/abc/zip')) :
    typeof define === 'function' && define.amd ? define('@delon/abc', ['exports', '@angular/core', '@delon/abc/avatar-list', '@delon/abc/count-down', '@delon/abc/date-picker', '@delon/abc/down-file', '@delon/abc/edit', '@delon/abc/ellipsis', '@delon/abc/error-collect', '@delon/abc/exception', '@delon/abc/footer-toolbar', '@delon/abc/full-content', '@delon/abc/global-footer', '@delon/abc/grid', '@delon/abc/image', '@delon/abc/lodop', '@delon/abc/notice-icon', '@delon/abc/number-to-chinese', '@delon/abc/page-header', '@delon/abc/qr', '@delon/abc/quick-menu', '@delon/abc/result', '@delon/abc/reuse-tab', '@delon/abc/sidebar-nav', '@delon/abc/table', '@delon/abc/tag-select', '@delon/abc/view', '@delon/abc/xlsx', '@delon/abc/zip'], factory) :
    (factory((global.delon = global.delon || {}, global.delon.abc = {}),global.ng.core,global.delon.abc['avatar-list'],global.delon.abc['count-down'],global.delon.abc['date-picker'],global.delon.abc['down-file'],global.delon.abc.edit,global.delon.abc.ellipsis,global.delon.abc['error-collect'],global.delon.abc.exception,global.delon.abc['footer-toolbar'],global.delon.abc['full-content'],global.delon.abc['global-footer'],global.delon.abc.grid,global.delon.abc.image,global.delon.abc.lodop,global.delon.abc['notice-icon'],global.delon.abc['number-to-chinese'],global.delon.abc['page-header'],global.delon.abc.qr,global.delon.abc['quick-menu'],global.delon.abc.result,global.delon.abc['reuse-tab'],global.delon.abc['sidebar-nav'],global.delon.abc.table,global.delon.abc['tag-select'],global.delon.abc.view,global.delon.abc.xlsx,global.delon.abc.zip));
}(this, (function (exports,core,avatarList,countDown,datePicker,downFile,edit,ellipsis,errorCollect,exception,footerToolbar,fullContent,globalFooter,grid,image,lodop,noticeIcon,numberToChinese,pageHeader,qr,quickMenu,result,reuseTab,sidebarNav,table,tagSelect,view,xlsx,zip) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    /** @type {?} */
    var MODULES = [
        errorCollect.ErrorCollectModule,
        footerToolbar.FooterToolbarModule,
        sidebarNav.SidebarNavModule,
        downFile.DownFileModule,
        image.ImageModule,
        avatarList.AvatarListModule,
        ellipsis.EllipsisModule,
        globalFooter.GlobalFooterModule,
        exception.ExceptionModule,
        noticeIcon.NoticeIconModule,
        pageHeader.PageHeaderModule,
        result.ResultModule,
        tagSelect.TagSelectModule,
        countDown.CountDownModule,
        table.STModule,
        reuseTab.ReuseTabModule,
        fullContent.FullContentModule,
        xlsx.XlsxModule,
        zip.ZipModule,
        numberToChinese.NumberToChineseModule,
        lodop.LodopModule,
        quickMenu.QuickMenuModule,
        qr.QRModule,
        view.SVModule,
        edit.SEModule,
        grid.SGModule,
        datePicker.DatePickerModule,
    ];
    var DelonABCModule = /** @class */ (function () {
        function DelonABCModule() {
        }
        DelonABCModule.decorators = [
            { type: core.NgModule, args: [{ exports: MODULES },] }
        ];
        return DelonABCModule;
    }());

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */

    exports.AvatarListItemComponent = avatarList.AvatarListItemComponent;
    exports.AvatarListComponent = avatarList.AvatarListComponent;
    exports.AvatarListModule = avatarList.AvatarListModule;
    exports.CountDownComponent = countDown.CountDownComponent;
    exports.CountDownModule = countDown.CountDownModule;
    exports.RangePickerComponent = datePicker.RangePickerComponent;
    exports.DatePickerModule = datePicker.DatePickerModule;
    exports.DateRangePickerConfig = datePicker.DateRangePickerConfig;
    exports.DatePickerConfig = datePicker.DatePickerConfig;
    exports.DownFileDirective = downFile.DownFileDirective;
    exports.DownFileModule = downFile.DownFileModule;
    exports.SEContainerComponent = edit.SEContainerComponent;
    exports.SEErrorComponent = edit.SEErrorComponent;
    exports.SETitleComponent = edit.SETitleComponent;
    exports.SEComponent = edit.SEComponent;
    exports.SEConfig = edit.SEConfig;
    exports.SEModule = edit.SEModule;
    exports.EllipsisComponent = ellipsis.EllipsisComponent;
    exports.EllipsisModule = ellipsis.EllipsisModule;
    exports.ErrorCollectComponent = errorCollect.ErrorCollectComponent;
    exports.ErrorCollectConfig = errorCollect.ErrorCollectConfig;
    exports.ErrorCollectModule = errorCollect.ErrorCollectModule;
    exports.ExceptionModule = exception.ExceptionModule;
    exports.ExceptionComponent = exception.ExceptionComponent;
    exports.FooterToolbarComponent = footerToolbar.FooterToolbarComponent;
    exports.FooterToolbarModule = footerToolbar.FooterToolbarModule;
    exports.FullContentComponent = fullContent.FullContentComponent;
    exports.FullContentService = fullContent.FullContentService;
    exports.FullContentToggleDirective = fullContent.FullContentToggleDirective;
    exports.FullContentModule = fullContent.FullContentModule;
    exports.GlobalFooterComponent = globalFooter.GlobalFooterComponent;
    exports.GlobalFooterItemComponent = globalFooter.GlobalFooterItemComponent;
    exports.GlobalFooterModule = globalFooter.GlobalFooterModule;
    exports.SGContainerComponent = grid.SGContainerComponent;
    exports.SGComponent = grid.SGComponent;
    exports.SGConfig = grid.SGConfig;
    exports.SGModule = grid.SGModule;
    exports.ImageDirective = image.ImageDirective;
    exports.ImageConfig = image.ImageConfig;
    exports.ImageModule = image.ImageModule;
    exports.LodopService = lodop.LodopService;
    exports.LodopConfig = lodop.LodopConfig;
    exports.LodopModule = lodop.LodopModule;
    exports.NoticeIconTabComponent = noticeIcon.NoticeIconTabComponent;
    exports.NoticeIconComponent = noticeIcon.NoticeIconComponent;
    exports.NoticeIconModule = noticeIcon.NoticeIconModule;
    exports.numberToChinese = numberToChinese.numberToChinese;
    exports.NaNumberToChinesePipe = numberToChinese.NaNumberToChinesePipe;
    exports.NumberToChineseModule = numberToChinese.NumberToChineseModule;
    exports.PageHeaderConfig = pageHeader.PageHeaderConfig;
    exports.PageHeaderComponent = pageHeader.PageHeaderComponent;
    exports.PageHeaderModule = pageHeader.PageHeaderModule;
    exports.QRService = qr.QRService;
    exports.QRComponent = qr.QRComponent;
    exports.QRConfig = qr.QRConfig;
    exports.QRModule = qr.QRModule;
    exports.QuickMenuComponent = quickMenu.QuickMenuComponent;
    exports.QuickMenuModule = quickMenu.QuickMenuModule;
    exports.ResultComponent = result.ResultComponent;
    exports.ResultModule = result.ResultModule;
    exports.ReuseTabContextMenuComponent = reuseTab.ReuseTabContextMenuComponent;
    exports.ReuseTabContextComponent = reuseTab.ReuseTabContextComponent;
    exports.ReuseTabContextDirective = reuseTab.ReuseTabContextDirective;
    exports.ReuseTabContextService = reuseTab.ReuseTabContextService;
    exports.ReuseTabComponent = reuseTab.ReuseTabComponent;
    exports.ReuseTabService = reuseTab.ReuseTabService;
    exports.ReuseTabStrategy = reuseTab.ReuseTabStrategy;
    exports.ReuseTabModule = reuseTab.ReuseTabModule;
    exports.ReuseTabMatchMode = reuseTab.ReuseTabMatchMode;
    exports.SidebarNavComponent = sidebarNav.SidebarNavComponent;
    exports.SidebarNavModule = sidebarNav.SidebarNavModule;
    exports.ɵa = table.ɵa;
    exports.STComponent = table.STComponent;
    exports.STRowDirective = table.STRowDirective;
    exports.STConfig = table.STConfig;
    exports.STModule = table.STModule;
    exports.STColumnSource = table.STColumnSource;
    exports.STDataSource = table.STDataSource;
    exports.STExport = table.STExport;
    exports.TagSelectComponent = tagSelect.TagSelectComponent;
    exports.TagSelectModule = tagSelect.TagSelectModule;
    exports.SVContainerComponent = view.SVContainerComponent;
    exports.SVTitleComponent = view.SVTitleComponent;
    exports.SVComponent = view.SVComponent;
    exports.SVConfig = view.SVConfig;
    exports.SVModule = view.SVModule;
    exports.XlsxConfig = xlsx.XlsxConfig;
    exports.XlsxService = xlsx.XlsxService;
    exports.XlsxDirective = xlsx.XlsxDirective;
    exports.XlsxModule = xlsx.XlsxModule;
    exports.ZipService = zip.ZipService;
    exports.ZipModule = zip.ZipModule;
    exports.ZipConfig = zip.ZipConfig;
    exports.DelonABCModule = DelonABCModule;

    Object.defineProperty(exports, '__esModule', { value: true });

})));

//# sourceMappingURL=abc.umd.js.map