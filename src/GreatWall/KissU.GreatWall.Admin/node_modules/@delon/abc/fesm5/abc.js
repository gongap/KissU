import { NgModule } from '@angular/core';
import { AvatarListModule } from '@delon/abc/avatar-list';
export { AvatarListItemComponent, AvatarListComponent, AvatarListModule } from '@delon/abc/avatar-list';
import { CountDownModule } from '@delon/abc/count-down';
export { CountDownComponent, CountDownModule } from '@delon/abc/count-down';
import { DatePickerModule } from '@delon/abc/date-picker';
export { RangePickerComponent, DatePickerModule, DateRangePickerConfig, DatePickerConfig } from '@delon/abc/date-picker';
import { DownFileModule } from '@delon/abc/down-file';
export { DownFileDirective, DownFileModule } from '@delon/abc/down-file';
import { SEModule } from '@delon/abc/edit';
export { SEContainerComponent, SEErrorComponent, SETitleComponent, SEComponent, SEConfig, SEModule } from '@delon/abc/edit';
import { EllipsisModule } from '@delon/abc/ellipsis';
export { EllipsisComponent, EllipsisModule } from '@delon/abc/ellipsis';
import { ErrorCollectModule } from '@delon/abc/error-collect';
export { ErrorCollectComponent, ErrorCollectConfig, ErrorCollectModule } from '@delon/abc/error-collect';
import { ExceptionModule } from '@delon/abc/exception';
export { ExceptionModule, ExceptionComponent } from '@delon/abc/exception';
import { FooterToolbarModule } from '@delon/abc/footer-toolbar';
export { FooterToolbarComponent, FooterToolbarModule } from '@delon/abc/footer-toolbar';
import { FullContentModule } from '@delon/abc/full-content';
export { FullContentComponent, FullContentService, FullContentToggleDirective, FullContentModule } from '@delon/abc/full-content';
import { GlobalFooterModule } from '@delon/abc/global-footer';
export { GlobalFooterComponent, GlobalFooterItemComponent, GlobalFooterModule } from '@delon/abc/global-footer';
import { SGModule } from '@delon/abc/grid';
export { SGContainerComponent, SGComponent, SGConfig, SGModule } from '@delon/abc/grid';
import { ImageModule } from '@delon/abc/image';
export { ImageDirective, ImageConfig, ImageModule } from '@delon/abc/image';
import { LodopModule } from '@delon/abc/lodop';
export { LodopService, LodopConfig, LodopModule } from '@delon/abc/lodop';
import { NoticeIconModule } from '@delon/abc/notice-icon';
export { NoticeIconTabComponent, NoticeIconComponent, NoticeIconModule } from '@delon/abc/notice-icon';
import { NumberToChineseModule } from '@delon/abc/number-to-chinese';
export { numberToChinese, NaNumberToChinesePipe, NumberToChineseModule } from '@delon/abc/number-to-chinese';
import { PageHeaderModule } from '@delon/abc/page-header';
export { PageHeaderConfig, PageHeaderComponent, PageHeaderModule } from '@delon/abc/page-header';
import { QRModule } from '@delon/abc/qr';
export { QRService, QRComponent, QRConfig, QRModule } from '@delon/abc/qr';
import { QuickMenuModule } from '@delon/abc/quick-menu';
export { QuickMenuComponent, QuickMenuModule } from '@delon/abc/quick-menu';
import { ResultModule } from '@delon/abc/result';
export { ResultComponent, ResultModule } from '@delon/abc/result';
import { ReuseTabModule } from '@delon/abc/reuse-tab';
export { ReuseTabContextMenuComponent, ReuseTabContextComponent, ReuseTabContextDirective, ReuseTabContextService, ReuseTabComponent, ReuseTabService, ReuseTabStrategy, ReuseTabModule, ReuseTabMatchMode } from '@delon/abc/reuse-tab';
import { SidebarNavModule } from '@delon/abc/sidebar-nav';
export { SidebarNavComponent, SidebarNavModule } from '@delon/abc/sidebar-nav';
import { STModule } from '@delon/abc/table';
export { ɵa, STComponent, STRowDirective, STConfig, STModule, STColumnSource, STDataSource, STExport } from '@delon/abc/table';
import { TagSelectModule } from '@delon/abc/tag-select';
export { TagSelectComponent, TagSelectModule } from '@delon/abc/tag-select';
import { SVModule } from '@delon/abc/view';
export { SVContainerComponent, SVTitleComponent, SVComponent, SVConfig, SVModule } from '@delon/abc/view';
import { XlsxModule } from '@delon/abc/xlsx';
export { XlsxConfig, XlsxService, XlsxDirective, XlsxModule } from '@delon/abc/xlsx';
import { ZipModule } from '@delon/abc/zip';
export { ZipService, ZipModule, ZipConfig } from '@delon/abc/zip';

/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/** @type {?} */
var MODULES = [
    ErrorCollectModule,
    FooterToolbarModule,
    SidebarNavModule,
    DownFileModule,
    ImageModule,
    AvatarListModule,
    EllipsisModule,
    GlobalFooterModule,
    ExceptionModule,
    NoticeIconModule,
    PageHeaderModule,
    ResultModule,
    TagSelectModule,
    CountDownModule,
    STModule,
    ReuseTabModule,
    FullContentModule,
    XlsxModule,
    ZipModule,
    NumberToChineseModule,
    LodopModule,
    QuickMenuModule,
    QRModule,
    SVModule,
    SEModule,
    SGModule,
    DatePickerModule,
];
var DelonABCModule = /** @class */ (function () {
    function DelonABCModule() {
    }
    DelonABCModule.decorators = [
        { type: NgModule, args: [{ exports: MODULES },] }
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

export { DelonABCModule };

//# sourceMappingURL=abc.js.map