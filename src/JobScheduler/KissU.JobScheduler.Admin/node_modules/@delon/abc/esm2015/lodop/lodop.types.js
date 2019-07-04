/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @record
 */
export function CLodop() { }
if (false) {
    /**
     * 判断是否支持https协议的属性
     *
     * - 0 不支持
     * - 1 支持
     * - 2 支持且已启动（https服务需单独启动)
     * @type {?}
     */
    CLodop.prototype.HTTPS_STATUS;
    /**
     * 结果回调函数保留
     * @type {?}
     */
    CLodop.prototype.On_Return_Remain;
    /**
     * 建立打印机名单
     * @param {?} el
     * @return {?}
     */
    CLodop.prototype.Create_Printer_List = function (el) { };
    /**
     * 建立纸张类型名单
     * @param {?} el
     * @param {?} iPrintIndex
     * @return {?}
     */
    CLodop.prototype.Create_PageSize_List = function (el, iPrintIndex) { };
    /**
     * 结果回调函数
     * @param {?} taskID
     * @param {?} value
     * @return {?}
     */
    CLodop.prototype.On_Return = function (taskID, value) { };
}
/**
 * @record
 */
export function Lodop() { }
if (false) {
    /**
     * 获得软件版本号
     * @type {?}
     */
    Lodop.prototype.VERSION;
    /** @type {?} */
    Lodop.prototype.webskt;
    /* Skipping unhandled member: [key: string]: any;*/
    /**
     * 打印初始化。初始化运行环境，清理异常打印遗留的系统资源，设定打印任务名。
     *
     * **建议或要求：**该函数与PRINT_INITA都有初始化功能，每个打印事务至少初始化一次，建议打印程序首先调用该函数。任务名要尽量区别于其它打印任务，譬如用“XX单位_XX管理信息系统_XX子系统_XX模块_XX打印作业”字样。
     * 不希望最终用户更改打印布局时，则设strTaskName空。
     *
     * @param {?} strTaskName 打印任务名
     * @return {?} 返回逻辑真表示初始化成功，逻辑假表示初始化失败，失败原因有：前一个打印事务没有完成；操作系统没有添加打印机(驱动)等
     */
    Lodop.prototype.PRINT_INIT = function (strTaskName) { };
    /**
     * 设定纸张大小
     * @param {?} intOrient
     * @param {?} PageWidth
     * @param {?} PageHeight
     * @param {?} strPageName
     * @return {?}
     */
    Lodop.prototype.SET_PRINT_PAGESIZE = function (intOrient, PageWidth, PageHeight, strPageName) { };
    /**
     * 增加超文本打印项(普通模式)
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strHtmlContent
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_HTM = function (Top, Left, Width, Height, strHtmlContent) { };
    /**
     * 增加表格打印项（超文本模式）
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strHtml
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_TABLE = function (Top, Left, Width, Height, strHtml) { };
    /**
     * 增加表格打印项（超文本模式）
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strHtml
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_TABLE = function (Top, Left, Width, Height, strHtml) { };
    /**
     * 增加超文本打印项（URL模式）
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strURL
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_URL = function (Top, Left, Width, Height, strURL) { };
    /**
     * 增加纯文本打印项
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strContent
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_TEXT = function (Top, Left, Width, Height, strContent) { };
    /**
     * 增加图片打印项
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strHtmlContent
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_IMAGE = function (Top, Left, Width, Height, strHtmlContent) { };
    /**
     * 增加矩形线
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} intLineStyle
     * @param {?} intLineWidth
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_RECT = function (Top, Left, Width, Height, intLineStyle, intLineWidth) { };
    /**
     * 增加椭圆线
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} intLineStyle
     * @param {?} intLineWidth
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_ELLIPSE = function (Top, Left, Width, Height, intLineStyle, intLineWidth) { };
    /**
     * 增加直线
     * @param {?} Top1
     * @param {?} Left1
     * @param {?} Top2
     * @param {?} Left2
     * @param {?} intLineStyle
     * @param {?} intLineWidth
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_LINE = function (Top1, Left1, Top2, Left2, intLineStyle, intLineWidth) { };
    /**
     * 增加条形码
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} CodeType
     * @param {?} CodeValue
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_BARCODE = function (Top, Left, Width, Height, CodeType, CodeValue) { };
    /**
     * 增加图表
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} ChartType
     * @param {?} strHtml
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_CHART = function (Top, Left, Width, Height, ChartType, strHtml) { };
    /**
     * 装载文档式模板
     * @param {?} strDataStyle
     * @param {?} varDataValue
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_DATA = function (strDataStyle, varDataValue) { };
    /**
     * 设置打印项风格
     * @param {?} strStyleName
     * @param {?} varStyleValue
     * @return {?}
     */
    Lodop.prototype.SET_PRINT_STYLE = function (strStyleName, varStyleValue) { };
    /**
     * 打印预览
     * @return {?}
     */
    Lodop.prototype.PREVIEW = function () { };
    /**
     * 直接打印
     * @return {?}
     */
    Lodop.prototype.PRINT = function () { };
    /**
     * 打印维护
     * @return {?}
     */
    Lodop.prototype.PRINT_SETUP = function () { };
    /**
     * 打印设计
     * @return {?}
     */
    Lodop.prototype.PRINT_DESIGN = function () { };
    /**
     * 强制分页
     * @return {?}
     */
    Lodop.prototype.NEWPAGE = function () { };
    /**
     * 获得打印设备个数
     * @return {?}
     */
    Lodop.prototype.GET_PRINTER_COUNT = function () { };
    /**
     * 获得打印设备名称
     * @param {?} strPrinterIDandType
     * @return {?}
     */
    Lodop.prototype.GET_PRINTER_NAME = function (strPrinterIDandType) { };
    /**
     * 指定打印设备
     * @param {?} oIndexOrName
     * @return {?}
     */
    Lodop.prototype.SET_PRINTER_INDEX = function (oIndexOrName) { };
    /**
     * 【CLodop】指定打印机
     * @param {?} DriverIndex
     * @param {?} PrinterIDandName
     * @param {?} SubDevIndex
     * @return {?}
     */
    Lodop.prototype.SET_PRINTER_INDEX = function (DriverIndex, PrinterIDandName, SubDevIndex) { };
    /**
     * 选择打印设备
     * @return {?}
     */
    Lodop.prototype.SELECT_PRINTER = function () { };
    /**
     * 设置显示模式
     * @param {?} strModeType
     * @param {?} varModeValue
     * @return {?}
     */
    Lodop.prototype.SET_SHOW_MODE = function (strModeType, varModeValue) { };
    /**
     * 设置打印模式
     * @param {?} strModeType
     * @param {?} varModeValue
     * @return {?}
     */
    Lodop.prototype.SET_PRINT_MODE = function (strModeType, varModeValue) { };
    /**
     * 设置打印份数
     * @param {?} intCopies
     * @return {?}
     */
    Lodop.prototype.SET_PRINT_COPIES = function (intCopies) { };
    /**
     * 设置预览窗口
     * @param {?} intDispMode
     * @param {?} intToolMode
     * @param {?} blDirectPrint
     * @param {?} inWidth
     * @param {?} intHeight
     * @param {?} strTitleButtonCaptoin
     * @return {?}
     */
    Lodop.prototype.SET_PREVIEW_WINDOW = function (intDispMode, intToolMode, blDirectPrint, inWidth, intHeight, strTitleButtonCaptoin) { };
    /**
     * 指定背景图
     * @param {?} strImgHtml
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_SETUP_BKIMG = function (strImgHtml) { };
    /**
     * 发送原始数据
     * @param {?} strRawData
     * @return {?}
     */
    Lodop.prototype.SEND_PRINT_RAWDATA = function (strRawData) { };
    /**
     * 写端口数据
     * @param {?} strPortName
     * @param {?} strData
     * @return {?}
     */
    Lodop.prototype.WRITE_PORT_DATA = function (strPortName, strData) { };
    /**
     * 读端口数据
     * @param {?} strPortName
     * @return {?}
     */
    Lodop.prototype.READ_PORT_DATA = function (strPortName) { };
    /**
     * 获得配置文件名
     * @param {?} strPrintTask
     * @return {?}
     */
    Lodop.prototype.GET_PRINT_INIFFNAME = function (strPrintTask) { };
    /**
     * 获得纸张类型名清单
     * @param {?} oPrinterName
     * @param {?} strSplit
     * @return {?}
     */
    Lodop.prototype.GET_PAGESIZES_LIST = function (oPrinterName, strSplit) { };
    /**
     * 写本地文件内容
     * @param {?} intWriteMode
     * @param {?} strFileName
     * @param {?} strText
     * @return {?}
     */
    Lodop.prototype.WRITE_FILE_TEXT = function (intWriteMode, strFileName, strText) { };
    /**
     * 读本地文件内容
     * @param {?} strFileName
     * @return {?}
     */
    Lodop.prototype.GET_FILE_TEXT = function (strFileName) { };
    /**
     * 读本地文件时间
     * @param {?} strFileName
     * @return {?}
     */
    Lodop.prototype.GET_FILE_TIME = function (strFileName) { };
    /**
     * 判断本地文件是否存在
     * @param {?} strFileName
     * @return {?}
     */
    Lodop.prototype.IS_FILE_EXIST = function (strFileName) { };
    /**
     * 获得系统信息
     * @param {?} strInfoType
     * @return {?}
     */
    Lodop.prototype.GET_SYSTEM_INFO = function (strInfoType) { };
    /**
     * 获得数据值
     * @param {?} ValueType
     * @param {?} ValueIndex
     * @return {?}
     */
    Lodop.prototype.GET_VALUE = function (ValueType, ValueIndex) { };
    /**
     * 数据格式转换
     * @param {?} oType
     * @param {?} oValue
     * @return {?}
     */
    Lodop.prototype.FORMAT = function (oType, oValue) { };
    /**
     * 获得对话框结果值
     * @param {?} oType
     * @param {?} oPreValue
     * @return {?}
     */
    Lodop.prototype.GET_DIALOG_VALUE = function (oType, oPreValue) { };
    /**
     * (增强型)打印初始化
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strPrintName
     * @return {?}
     */
    Lodop.prototype.PRINT_INITA = function (Top, Left, Width, Height, strPrintName) { };
    /**
     * (增强型)增加超文本打印项(图形模式)
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strHtmlContent
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_HTML = function (Top, Left, Width, Height, strHtmlContent) { };
    /**
     * (增强型)增加表格打印项（URL模式）
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strURL
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_TBURL = function (Top, Left, Width, Height, strURL) { };
    /**
     * (增强型)增加纯文本打印项
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} strContent
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_TEXTA = function (Top, Left, Width, Height, strContent) { };
    /**
     * (增强型)设置打印项风格A, 继承 `SET_PRINT_STYLE` 的所有属性
     * @param {?} varItemNameID
     * @param {?} strStyleName
     * @param {?} varStyleValue
     * @return {?}
     */
    Lodop.prototype.SET_PRINT_STYLEA = function (varItemNameID, strStyleName, varStyleValue) { };
    /**
     * (增强型)导出数据到文件
     * @param {?} strFileName
     * @return {?}
     */
    Lodop.prototype.SAVE_TO_FILE = function (strFileName) { };
    /**
     * (增强型)设置保存模式
     * @param {?} varModeName
     * @param {?} varModeValue
     * @return {?}
     */
    Lodop.prototype.SET_SAVE_MODE = function (varModeName, varModeValue) { };
    /**
     * (增强型)增加图形
     * @param {?} intShapeType
     * @param {?} Top
     * @param {?} Left
     * @param {?} Width
     * @param {?} Height
     * @param {?} intLineStyle
     * @param {?} intLineWidth
     * @param {?} varColor
     * @return {?}
     */
    Lodop.prototype.ADD_PRINT_SHAPE = function (intShapeType, Top, Left, Width, Height, intLineStyle, intLineWidth, varColor) { };
    /**
     * (增强型)指定打印设备
     * @param {?} oIndexOrName
     * @return {?}
     */
    Lodop.prototype.SET_PRINTER_INDEXA = function (oIndexOrName) { };
    /**
     * (增强型)强制分页
     * @return {?}
     */
    Lodop.prototype.NEWPAGEA = function () { };
    /**
     * (增强型)打印预览A
     * @return {?}
     */
    Lodop.prototype.PREVIEWA = function () { };
    /**
     * (增强型)打印预览B
     * @return {?}
     */
    Lodop.prototype.PREVIEWB = function () { };
    /**
     * 直接打印A
     * @return {?}
     */
    Lodop.prototype.PRINTA = function () { };
    /**
     * 直接打印B
     * @return {?}
     */
    Lodop.prototype.PRINTB = function () { };
    /**
     * 显示图表
     * @return {?}
     */
    Lodop.prototype.SHOW_CHART = function () { };
    /**
     * 控制界面动作
     * @param {?} ActName
     * @param {?} ActValue
     * @return {?}
     */
    Lodop.prototype.DO_ACTION = function (ActName, ActValue) { };
    /**
     * 设置软件产品注册信息
     *
     * @param {?} strCompanyName 注册单位名称，用途与控件参数CompanyName一样。
     * @param {?} strLicense 主注册号，用途与控件参数License一样。
     * @param {?=} strLicenseA 附加注册号A，用途与控件参数LicenseA一样。
     * @param {?=} strLicenseB 附加注册号B，用途与控件参数LicenseB一样。
     * @return {?}
     */
    Lodop.prototype.SET_LICENSES = function (strCompanyName, strLicense, strLicenseA, strLicenseB) { };
}
/**
 * @record
 */
export function LodopResult() { }
if (false) {
    /**
     * 是否成功
     * @type {?}
     */
    LodopResult.prototype.ok;
    /**
     * 错误码
     * @type {?|undefined}
     */
    LodopResult.prototype.status;
    /**
     * 成功时携带 LODOP 对象
     * @type {?|undefined}
     */
    LodopResult.prototype.lodop;
    /**
     * 错误信息
     * @type {?|undefined}
     */
    LodopResult.prototype.error;
}
/**
 * @record
 */
export function LodopPrintResult() { }
if (false) {
    /**
     * 是否成功
     * @type {?}
     */
    LodopPrintResult.prototype.ok;
    /**
     * 错误信息
     * @type {?|undefined}
     */
    LodopPrintResult.prototype.error;
    /**
     * 代码
     * @type {?}
     */
    LodopPrintResult.prototype.code;
    /**
     * 动态参数上下文对象
     * @type {?}
     */
    LodopPrintResult.prototype.item;
    /**
     * 代码解析表达式
     * @type {?|undefined}
     */
    LodopPrintResult.prototype.parser;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibG9kb3AudHlwZXMuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL2xvZG9wLyIsInNvdXJjZXMiOlsibG9kb3AudHlwZXMudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7OztBQUFBLDRCQXFCQzs7Ozs7Ozs7OztJQVBDLDhCQUE4Qjs7Ozs7SUFNOUIsa0NBQW1DOzs7Ozs7SUFsQm5DLHlEQUF1Qzs7Ozs7OztJQUd2Qyx1RUFBNkQ7Ozs7Ozs7SUFZN0QsMERBQXlEOzs7OztBQU0zRCwyQkEwVUM7Ozs7OztJQXRVQyx3QkFBZ0I7O0lBcVVoQix1QkFBa0I7Ozs7Ozs7Ozs7O0lBMVRsQix3REFBeUM7Ozs7Ozs7OztJQUd6QyxrR0FLUTs7Ozs7Ozs7OztJQUdSLHdGQU1ROzs7Ozs7Ozs7O0lBR1IsbUZBTVE7Ozs7Ozs7Ozs7SUFHUixtRkFNUTs7Ozs7Ozs7OztJQUdSLGdGQU1ROzs7Ozs7Ozs7O0lBR1IscUZBTVE7Ozs7Ozs7Ozs7SUFHUiwwRkFNUTs7Ozs7Ozs7Ozs7SUFHUixxR0FPUTs7Ozs7Ozs7Ozs7SUFHUix3R0FPUTs7Ozs7Ozs7Ozs7SUFHUixxR0FPUTs7Ozs7Ozs7Ozs7SUFHUixpR0FPUTs7Ozs7Ozs7Ozs7SUFHUiw4RkFPUTs7Ozs7OztJQUdSLDJFQUE4RDs7Ozs7OztJQUc5RCw2RUFBcUY7Ozs7O0lBR3JGLDBDQUFrQjs7Ozs7SUFHbEIsd0NBQWdCOzs7OztJQUdoQiw4Q0FBc0I7Ozs7O0lBR3RCLCtDQUF1Qjs7Ozs7SUFHdkIsMENBQW1COzs7OztJQUduQixvREFBNEI7Ozs7OztJQUc1QixzRUFBK0Q7Ozs7OztJQUcvRCxnRUFBMEQ7Ozs7Ozs7O0lBRTFELDhGQUlXOzs7OztJQUdYLGlEQUF5Qjs7Ozs7OztJQUd6Qix5RUFBMkU7Ozs7Ozs7SUFHM0UsMEVBQXFGOzs7Ozs7SUFHckYsNERBQTZDOzs7Ozs7Ozs7OztJQUc3Qyx1SUFPUTs7Ozs7O0lBR1Isa0VBQWdEOzs7Ozs7SUFHaEQsK0RBQWdEOzs7Ozs7O0lBR2hELHNFQUErRDs7Ozs7O0lBRy9ELDREQUE0Qzs7Ozs7O0lBRzVDLGtFQUFrRDs7Ozs7OztJQUdsRCwyRUFBNEU7Ozs7Ozs7O0lBRzVFLG9GQUE2Rjs7Ozs7O0lBRzdGLDJEQUFrRDs7Ozs7O0lBR2xELDJEQUFrRDs7Ozs7O0lBR2xELDJEQUE0Qzs7Ozs7O0lBRzVDLDZEQUE4Qzs7Ozs7OztJQUc5QyxpRUFBK0Q7Ozs7Ozs7SUFHL0Qsc0RBQXdDOzs7Ozs7O0lBR3hDLG1FQUEyRDs7Ozs7Ozs7OztJQUczRCxvRkFNVzs7Ozs7Ozs7OztJQUdYLHlGQU1ROzs7Ozs7Ozs7O0lBR1Isa0ZBTVE7Ozs7Ozs7Ozs7SUFHUixzRkFNUTs7Ozs7Ozs7SUFHUiw2RkFJUTs7Ozs7O0lBR1IsMERBQTJDOzs7Ozs7O0lBRzNDLHlFQUEyRTs7Ozs7Ozs7Ozs7OztJQUczRSw4SEFTUTs7Ozs7O0lBR1IsaUVBQTJEOzs7OztJQUczRCwyQ0FBb0I7Ozs7O0lBR3BCLDJDQUFtQjs7Ozs7SUFHbkIsMkNBQW1COzs7OztJQUduQix5Q0FBa0I7Ozs7O0lBR2xCLHlDQUFrQjs7Ozs7SUFHbEIsNkNBQW1COzs7Ozs7O0lBR25CLDZEQUE0RDs7Ozs7Ozs7OztJQVU1RCxtR0FLUTs7Ozs7QUF1QlYsaUNBU0M7Ozs7OztJQVBDLHlCQUFZOzs7OztJQUVaLDZCQUFnQjs7Ozs7SUFFaEIsNEJBQWM7Ozs7O0lBRWQsNEJBQVk7Ozs7O0FBR2Qsc0NBV0M7Ozs7OztJQVRDLDhCQUFZOzs7OztJQUVaLGlDQUFlOzs7OztJQUVmLGdDQUFhOzs7OztJQUViLGdDQUFVOzs7OztJQUVWLGtDQUFnQiIsInNvdXJjZXNDb250ZW50IjpbImV4cG9ydCBpbnRlcmZhY2UgQ0xvZG9wIHtcbiAgLyoqIOW7uueri+aJk+WNsOacuuWQjeWNlSAqL1xuICBDcmVhdGVfUHJpbnRlcl9MaXN0KGVsOiBFbGVtZW50KTogdm9pZDtcblxuICAvKiog5bu656uL57q45byg57G75Z6L5ZCN5Y2VICovXG4gIENyZWF0ZV9QYWdlU2l6ZV9MaXN0KGVsOiBFbGVtZW50LCBpUHJpbnRJbmRleDogbnVtYmVyKTogdm9pZDtcblxuICAvKipcbiAgICog5Yik5pat5piv5ZCm5pSv5oyBaHR0cHPljY/orq7nmoTlsZ7mgKdcbiAgICpcbiAgICogLSAwIOS4jeaUr+aMgVxuICAgKiAtIDEg5pSv5oyBXG4gICAqIC0gMiDmlK/mjIHkuJTlt7LlkK/liqjvvIhodHRwc+acjeWKoemcgOWNleeLrOWQr+WKqClcbiAgICovXG4gIHJlYWRvbmx5IEhUVFBTX1NUQVRVUzogbnVtYmVyO1xuXG4gIC8qKiDnu5Pmnpzlm57osIPlh73mlbAgKi9cbiAgT25fUmV0dXJuKHRhc2tJRDogc3RyaW5nLCB2YWx1ZTogYm9vbGVhbiB8IHN0cmluZyk6IHZvaWQ7XG5cbiAgLyoqIOe7k+aenOWbnuiwg+WHveaVsOS/neeVmSAqL1xuICByZWFkb25seSBPbl9SZXR1cm5fUmVtYWluOiBib29sZWFuO1xufVxuXG5leHBvcnQgaW50ZXJmYWNlIExvZG9wIGV4dGVuZHMgQ0xvZG9wIHtcbiAgW2tleTogc3RyaW5nXTogYW55O1xuXG4gIC8qKiDojrflvpfova/ku7bniYjmnKzlj7cgKi9cbiAgVkVSU0lPTjogc3RyaW5nO1xuXG4gIC8qKlxuICAgKiDmiZPljbDliJ3lp4vljJbjgILliJ3lp4vljJbov5DooYznjq/looPvvIzmuIXnkIblvILluLjmiZPljbDpgZfnlZnnmoTns7vnu5/otYTmupDvvIzorr7lrprmiZPljbDku7vliqHlkI3jgIJcbiAgICpcbiAgICogKirlu7rorq7miJbopoHmsYLvvJoqKuivpeWHveaVsOS4jlBSSU5UX0lOSVRB6YO95pyJ5Yid5aeL5YyW5Yqf6IO977yM5q+P5Liq5omT5Y2w5LqL5Yqh6Iez5bCR5Yid5aeL5YyW5LiA5qyh77yM5bu66K6u5omT5Y2w56iL5bqP6aaW5YWI6LCD55So6K+l5Ye95pWw44CC5Lu75Yqh5ZCN6KaB5bC96YeP5Yy65Yir5LqO5YW25a6D5omT5Y2w5Lu75Yqh77yM6K2s5aaC55So4oCcWFjljZXkvY1fWFjnrqHnkIbkv6Hmga/ns7vnu59fWFjlrZDns7vnu59fWFjmqKHlnZdfWFjmiZPljbDkvZzkuJrigJ3lrZfmoLfjgIJcbiAgICog5LiN5biM5pyb5pyA57uI55So5oi35pu05pS55omT5Y2w5biD5bGA5pe277yM5YiZ6K6+c3RyVGFza05hbWXnqbrjgIJcbiAgICpcbiAgICogQHBhcmFtIHN0clRhc2tOYW1lIOaJk+WNsOS7u+WKoeWQjVxuICAgKiBAcmV0dXJucyDov5Tlm57pgLvovpHnnJ/ooajnpLrliJ3lp4vljJbmiJDlip/vvIzpgLvovpHlgYfooajnpLrliJ3lp4vljJblpLHotKXvvIzlpLHotKXljp/lm6DmnInvvJrliY3kuIDkuKrmiZPljbDkuovliqHmsqHmnInlrozmiJDvvJvmk43kvZzns7vnu5/msqHmnInmt7vliqDmiZPljbDmnLoo6amx5YqoKeetiVxuICAgKi9cbiAgUFJJTlRfSU5JVChzdHJUYXNrTmFtZTogc3RyaW5nKTogYm9vbGVhbjtcblxuICAvKiog6K6+5a6a57q45byg5aSn5bCPICovXG4gIFNFVF9QUklOVF9QQUdFU0laRShcbiAgICBpbnRPcmllbnQ6IG51bWJlcixcbiAgICBQYWdlV2lkdGg6IG51bWJlciB8IHN0cmluZyxcbiAgICBQYWdlSGVpZ2h0OiBudW1iZXIgfCBzdHJpbmcsXG4gICAgc3RyUGFnZU5hbWU6IHN0cmluZyxcbiAgKTogdm9pZDtcblxuICAvKiog5aKe5Yqg6LaF5paH5pys5omT5Y2w6aG5KOaZrumAmuaooeW8jykgKi9cbiAgQUREX1BSSU5UX0hUTShcbiAgICBUb3A6IG51bWJlciB8IHN0cmluZyxcbiAgICBMZWZ0OiBudW1iZXIgfCBzdHJpbmcsXG4gICAgV2lkdGg6IG51bWJlciB8IHN0cmluZyxcbiAgICBIZWlnaHQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBzdHJIdG1sQ29udGVudDogc3RyaW5nLFxuICApOiB2b2lkO1xuXG4gIC8qKiDlop7liqDooajmoLzmiZPljbDpobnvvIjotoXmlofmnKzmqKHlvI/vvIkqL1xuICBBRERfUFJJTlRfVEFCTEUoXG4gICAgVG9wOiBudW1iZXIgfCBzdHJpbmcsXG4gICAgTGVmdDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIFdpZHRoOiBudW1iZXIgfCBzdHJpbmcsXG4gICAgSGVpZ2h0OiBudW1iZXIgfCBzdHJpbmcsXG4gICAgc3RySHRtbDogc3RyaW5nLFxuICApOiB2b2lkO1xuXG4gIC8qKiDlop7liqDooajmoLzmiZPljbDpobnvvIjotoXmlofmnKzmqKHlvI/vvIkqL1xuICBBRERfUFJJTlRfVEFCTEUoXG4gICAgVG9wOiBudW1iZXIgfCBzdHJpbmcsXG4gICAgTGVmdDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIFdpZHRoOiBudW1iZXIgfCBzdHJpbmcsXG4gICAgSGVpZ2h0OiBudW1iZXIgfCBzdHJpbmcsXG4gICAgc3RySHRtbDogc3RyaW5nLFxuICApOiB2b2lkO1xuXG4gIC8qKiDlop7liqDotoXmlofmnKzmiZPljbDpobnvvIhVUkzmqKHlvI/vvIkqL1xuICBBRERfUFJJTlRfVVJMKFxuICAgIFRvcDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBXaWR0aDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIEhlaWdodDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIHN0clVSTDogc3RyaW5nLFxuICApOiB2b2lkO1xuXG4gIC8qKiDlop7liqDnuq/mlofmnKzmiZPljbDpobkgKi9cbiAgQUREX1BSSU5UX1RFWFQoXG4gICAgVG9wOiBudW1iZXIgfCBzdHJpbmcsXG4gICAgTGVmdDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIFdpZHRoOiBudW1iZXIgfCBzdHJpbmcsXG4gICAgSGVpZ2h0OiBudW1iZXIgfCBzdHJpbmcsXG4gICAgc3RyQ29udGVudDogc3RyaW5nLFxuICApOiB2b2lkO1xuXG4gIC8qKiDlop7liqDlm77niYfmiZPljbDpobkgKi9cbiAgQUREX1BSSU5UX0lNQUdFKFxuICAgIFRvcDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBXaWR0aDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIEhlaWdodDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIHN0ckh0bWxDb250ZW50OiBzdHJpbmcsXG4gICk6IHZvaWQ7XG5cbiAgLyoqIOWinuWKoOefqeW9oue6vyAqL1xuICBBRERfUFJJTlRfUkVDVChcbiAgICBUb3A6IG51bWJlciB8IHN0cmluZyxcbiAgICBMZWZ0OiBudW1iZXIgfCBzdHJpbmcsXG4gICAgV2lkdGg6IG51bWJlciB8IHN0cmluZyxcbiAgICBIZWlnaHQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBpbnRMaW5lU3R5bGU6IG51bWJlcixcbiAgICBpbnRMaW5lV2lkdGg6IG51bWJlcixcbiAgKTogdm9pZDtcblxuICAvKiog5aKe5Yqg5qSt5ZyG57q/ICovXG4gIEFERF9QUklOVF9FTExJUFNFKFxuICAgIFRvcDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBXaWR0aDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIEhlaWdodDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIGludExpbmVTdHlsZTogbnVtYmVyLFxuICAgIGludExpbmVXaWR0aDogbnVtYmVyLFxuICApOiB2b2lkO1xuXG4gIC8qKiDlop7liqDnm7Tnur8gKi9cbiAgQUREX1BSSU5UX0xJTkUoXG4gICAgVG9wMTogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQxOiBudW1iZXIgfCBzdHJpbmcsXG4gICAgVG9wMjogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQyOiBudW1iZXIgfCBzdHJpbmcsXG4gICAgaW50TGluZVN0eWxlOiBudW1iZXIsXG4gICAgaW50TGluZVdpZHRoOiBudW1iZXIsXG4gICk6IHZvaWQ7XG5cbiAgLyoqIOWinuWKoOadoeW9oueggSAqL1xuICBBRERfUFJJTlRfQkFSQ09ERShcbiAgICBUb3A6IG51bWJlciB8IHN0cmluZyxcbiAgICBMZWZ0OiBudW1iZXIgfCBzdHJpbmcsXG4gICAgV2lkdGg6IG51bWJlciB8IHN0cmluZyxcbiAgICBIZWlnaHQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBDb2RlVHlwZTogc3RyaW5nLFxuICAgIENvZGVWYWx1ZTogc3RyaW5nLFxuICApOiB2b2lkO1xuXG4gIC8qKiDlop7liqDlm77ooaggKi9cbiAgQUREX1BSSU5UX0NIQVJUKFxuICAgIFRvcDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBXaWR0aDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIEhlaWdodDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIENoYXJ0VHlwZTogbnVtYmVyLFxuICAgIHN0ckh0bWw6IHN0cmluZyxcbiAgKTogdm9pZDtcblxuICAvKiog6KOF6L295paH5qGj5byP5qih5p2/ICovXG4gIEFERF9QUklOVF9EQVRBKHN0ckRhdGFTdHlsZTogc3RyaW5nLCB2YXJEYXRhVmFsdWU6IGFueSk6IHZvaWQ7XG5cbiAgLyoqIOiuvue9ruaJk+WNsOmhuemjjuagvCAqL1xuICBTRVRfUFJJTlRfU1RZTEUoc3RyU3R5bGVOYW1lOiBMb2RvcFN0eWxlVmFsdWUsIHZhclN0eWxlVmFsdWU6IG51bWJlciB8IHN0cmluZyk6IHZvaWQ7XG5cbiAgLyoqIOaJk+WNsOmihOiniCAqL1xuICBQUkVWSUVXKCk6IG51bWJlcjtcblxuICAvKiog55u05o6l5omT5Y2wICovXG4gIFBSSU5UKCk6IHN0cmluZztcblxuICAvKiog5omT5Y2w57u05oqkICovXG4gIFBSSU5UX1NFVFVQKCk6IHN0cmluZztcblxuICAvKiog5omT5Y2w6K6+6K6hICovXG4gIFBSSU5UX0RFU0lHTigpOiBzdHJpbmc7XG5cbiAgLyoqIOW8uuWItuWIhumhtSAqL1xuICBORVdQQUdFKCk6IGJvb2xlYW47XG5cbiAgLyoqIOiOt+W+l+aJk+WNsOiuvuWkh+S4quaVsCAqL1xuICBHRVRfUFJJTlRFUl9DT1VOVCgpOiBudW1iZXI7XG5cbiAgLyoqIOiOt+W+l+aJk+WNsOiuvuWkh+WQjeensCAqL1xuICBHRVRfUFJJTlRFUl9OQU1FKHN0clByaW50ZXJJRGFuZFR5cGU6IG51bWJlciB8IHN0cmluZyk6IHN0cmluZztcblxuICAvKiog5oyH5a6a5omT5Y2w6K6+5aSHICovXG4gIFNFVF9QUklOVEVSX0lOREVYKG9JbmRleE9yTmFtZTogbnVtYmVyIHwgc3RyaW5nKTogYm9vbGVhbjtcbiAgLyoqIOOAkENMb2RvcOOAkeaMh+WumuaJk+WNsOacuiAqL1xuICBTRVRfUFJJTlRFUl9JTkRFWChcbiAgICBEcml2ZXJJbmRleDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIFByaW50ZXJJRGFuZE5hbWU6IG51bWJlciB8IHN0cmluZyxcbiAgICBTdWJEZXZJbmRleDogbnVtYmVyIHwgc3RyaW5nLFxuICApOiBib29sZWFuO1xuXG4gIC8qKiDpgInmi6nmiZPljbDorr7lpIcgKi9cbiAgU0VMRUNUX1BSSU5URVIoKTogbnVtYmVyO1xuXG4gIC8qKiDorr7nva7mmL7npLrmqKHlvI8gKi9cbiAgU0VUX1NIT1dfTU9ERShzdHJNb2RlVHlwZTogc3RyaW5nLCB2YXJNb2RlVmFsdWU6IG51bWJlciB8IHN0cmluZyk6IGJvb2xlYW47XG5cbiAgLyoqIOiuvue9ruaJk+WNsOaooeW8jyAqL1xuICBTRVRfUFJJTlRfTU9ERShzdHJNb2RlVHlwZTogc3RyaW5nLCB2YXJNb2RlVmFsdWU6IG51bWJlciB8IHN0cmluZyk6IGJvb2xlYW4gfCBzdHJpbmc7XG5cbiAgLyoqIOiuvue9ruaJk+WNsOS7veaVsCAqL1xuICBTRVRfUFJJTlRfQ09QSUVTKGludENvcGllczogbnVtYmVyKTogYm9vbGVhbjtcblxuICAvKiog6K6+572u6aKE6KeI56qX5Y+jICovXG4gIFNFVF9QUkVWSUVXX1dJTkRPVyhcbiAgICBpbnREaXNwTW9kZTogbnVtYmVyLFxuICAgIGludFRvb2xNb2RlOiBudW1iZXIsXG4gICAgYmxEaXJlY3RQcmludDogbnVtYmVyLFxuICAgIGluV2lkdGg6IG51bWJlcixcbiAgICBpbnRIZWlnaHQ6IG51bWJlcixcbiAgICBzdHJUaXRsZUJ1dHRvbkNhcHRvaW46IHN0cmluZyxcbiAgKTogdm9pZDtcblxuICAvKiog5oyH5a6a6IOM5pmv5Zu+ICovXG4gIEFERF9QUklOVF9TRVRVUF9CS0lNRyhzdHJJbWdIdG1sOiBzdHJpbmcpOiB2b2lkO1xuXG4gIC8qKiDlj5HpgIHljp/lp4vmlbDmja4gKi9cbiAgU0VORF9QUklOVF9SQVdEQVRBKHN0clJhd0RhdGE6IHN0cmluZyk6IGJvb2xlYW47XG5cbiAgLyoqIOWGmeerr+WPo+aVsOaNriAqL1xuICBXUklURV9QT1JUX0RBVEEoc3RyUG9ydE5hbWU6IHN0cmluZywgc3RyRGF0YTogc3RyaW5nKTogYm9vbGVhbjtcblxuICAvKiog6K+756uv5Y+j5pWw5o2uICovXG4gIFJFQURfUE9SVF9EQVRBKHN0clBvcnROYW1lOiBzdHJpbmcpOiBzdHJpbmc7XG5cbiAgLyoqIOiOt+W+l+mFjee9ruaWh+S7tuWQjSAqL1xuICBHRVRfUFJJTlRfSU5JRkZOQU1FKHN0clByaW50VGFzazogc3RyaW5nKTogc3RyaW5nO1xuXG4gIC8qKiDojrflvpfnurjlvKDnsbvlnovlkI3muIXljZUgKi9cbiAgR0VUX1BBR0VTSVpFU19MSVNUKG9QcmludGVyTmFtZTogbnVtYmVyIHwgc3RyaW5nLCBzdHJTcGxpdDogc3RyaW5nKTogc3RyaW5nO1xuXG4gIC8qKiDlhpnmnKzlnLDmlofku7blhoXlrrkgKi9cbiAgV1JJVEVfRklMRV9URVhUKGludFdyaXRlTW9kZTogbnVtYmVyIHwgc3RyaW5nLCBzdHJGaWxlTmFtZTogc3RyaW5nLCBzdHJUZXh0OiBzdHJpbmcpOiBzdHJpbmc7XG5cbiAgLyoqIOivu+acrOWcsOaWh+S7tuWGheWuuSAqL1xuICBHRVRfRklMRV9URVhUKHN0ckZpbGVOYW1lOiBzdHJpbmcpOiBzdHJpbmcgfCBudWxsO1xuXG4gIC8qKiDor7vmnKzlnLDmlofku7bml7bpl7QgKi9cbiAgR0VUX0ZJTEVfVElNRShzdHJGaWxlTmFtZTogc3RyaW5nKTogc3RyaW5nIHwgbnVsbDtcblxuICAvKiog5Yik5pat5pys5Zyw5paH5Lu25piv5ZCm5a2Y5ZyoICovXG4gIElTX0ZJTEVfRVhJU1Qoc3RyRmlsZU5hbWU6IHN0cmluZyk6IGJvb2xlYW47XG5cbiAgLyoqIOiOt+W+l+ezu+e7n+S/oeaBryAqL1xuICBHRVRfU1lTVEVNX0lORk8oc3RySW5mb1R5cGU6IHN0cmluZyk6IGJvb2xlYW47XG5cbiAgLyoqIOiOt+W+l+aVsOaNruWAvCAqL1xuICBHRVRfVkFMVUUoVmFsdWVUeXBlOiBzdHJpbmcsIFZhbHVlSW5kZXg6IG51bWJlciB8IHN0cmluZyk6IGFueTtcblxuICAvKiog5pWw5o2u5qC85byP6L2s5o2iICovXG4gIEZPUk1BVChvVHlwZTogc3RyaW5nLCBvVmFsdWU6IGFueSk6IGFueTtcblxuICAvKiog6I635b6X5a+56K+d5qGG57uT5p6c5YC8ICovXG4gIEdFVF9ESUFMT0dfVkFMVUUob1R5cGU6IHN0cmluZywgb1ByZVZhbHVlOiBzdHJpbmcpOiBzdHJpbmc7XG5cbiAgLyoqICjlop7lvLrlnosp5omT5Y2w5Yid5aeL5YyWICovXG4gIFBSSU5UX0lOSVRBKFxuICAgIFRvcDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBXaWR0aDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIEhlaWdodDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIHN0clByaW50TmFtZTogc3RyaW5nLFxuICApOiBib29sZWFuO1xuXG4gIC8qKiAo5aKe5by65Z6LKeWinuWKoOi2heaWh+acrOaJk+WNsOmhuSjlm77lvaLmqKHlvI8pICovXG4gIEFERF9QUklOVF9IVE1MKFxuICAgIFRvcDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBXaWR0aDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIEhlaWdodDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIHN0ckh0bWxDb250ZW50OiBzdHJpbmcsXG4gICk6IHZvaWQ7XG5cbiAgLyoqICjlop7lvLrlnosp5aKe5Yqg6KGo5qC85omT5Y2w6aG577yIVVJM5qih5byP77yJICovXG4gIEFERF9QUklOVF9UQlVSTChcbiAgICBUb3A6IG51bWJlciB8IHN0cmluZyxcbiAgICBMZWZ0OiBudW1iZXIgfCBzdHJpbmcsXG4gICAgV2lkdGg6IG51bWJlciB8IHN0cmluZyxcbiAgICBIZWlnaHQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBzdHJVUkw6IHN0cmluZyxcbiAgKTogdm9pZDtcblxuICAvKiogKOWinuW8uuWeiynlop7liqDnuq/mlofmnKzmiZPljbDpobkgKi9cbiAgQUREX1BSSU5UX1RFWFRBKFxuICAgIFRvcDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBXaWR0aDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIEhlaWdodDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIHN0ckNvbnRlbnQ6IHN0cmluZyxcbiAgKTogdm9pZDtcblxuICAvKiogKOWinuW8uuWeiynorr7nva7miZPljbDpobnpo47moLxBLCDnu6fmib8gYFNFVF9QUklOVF9TVFlMRWAg55qE5omA5pyJ5bGe5oCnICovXG4gIFNFVF9QUklOVF9TVFlMRUEoXG4gICAgdmFySXRlbU5hbWVJRDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIHN0clN0eWxlTmFtZTogc3RyaW5nLFxuICAgIHZhclN0eWxlVmFsdWU6IG51bWJlciB8IHN0cmluZyxcbiAgKTogdm9pZDtcblxuICAvKiogKOWinuW8uuWeiynlr7zlh7rmlbDmja7liLDmlofku7YgKi9cbiAgU0FWRV9UT19GSUxFKHN0ckZpbGVOYW1lOiBzdHJpbmcpOiBib29sZWFuO1xuXG4gIC8qKiAo5aKe5by65Z6LKeiuvue9ruS/neWtmOaooeW8jyAqL1xuICBTRVRfU0FWRV9NT0RFKHZhck1vZGVOYW1lOiBzdHJpbmcsIHZhck1vZGVWYWx1ZTogbnVtYmVyIHwgc3RyaW5nKTogYm9vbGVhbjtcblxuICAvKiogKOWinuW8uuWeiynlop7liqDlm77lvaIgKi9cbiAgQUREX1BSSU5UX1NIQVBFKFxuICAgIGludFNoYXBlVHlwZTogbnVtYmVyLFxuICAgIFRvcDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIExlZnQ6IG51bWJlciB8IHN0cmluZyxcbiAgICBXaWR0aDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIEhlaWdodDogbnVtYmVyIHwgc3RyaW5nLFxuICAgIGludExpbmVTdHlsZTogbnVtYmVyLFxuICAgIGludExpbmVXaWR0aDogbnVtYmVyLFxuICAgIHZhckNvbG9yOiBudW1iZXIgfCBzdHJpbmcsXG4gICk6IHZvaWQ7XG5cbiAgLyoqICjlop7lvLrlnosp5oyH5a6a5omT5Y2w6K6+5aSHICovXG4gIFNFVF9QUklOVEVSX0lOREVYQShvSW5kZXhPck5hbWU6IG51bWJlciB8IHN0cmluZyk6IGJvb2xlYW47XG5cbiAgLyoqICjlop7lvLrlnosp5by65Yi25YiG6aG1ICovXG4gIE5FV1BBR0VBKCk6IGJvb2xlYW47XG5cbiAgLyoqICjlop7lvLrlnosp5omT5Y2w6aKE6KeIQSAqL1xuICBQUkVWSUVXQSgpOiBudW1iZXI7XG5cbiAgLyoqICjlop7lvLrlnosp5omT5Y2w6aKE6KeIQiAqL1xuICBQUkVWSUVXQigpOiBudW1iZXI7XG5cbiAgLyoqIOebtOaOpeaJk+WNsEEgKi9cbiAgUFJJTlRBKCk6IGJvb2xlYW47XG5cbiAgLyoqIOebtOaOpeaJk+WNsEIgKi9cbiAgUFJJTlRCKCk6IGJvb2xlYW47XG5cbiAgLyoqIOaYvuekuuWbvuihqCAqL1xuICBTSE9XX0NIQVJUKCk6IHZvaWQ7XG5cbiAgLyoqIOaOp+WItueVjOmdouWKqOS9nCAqL1xuICBET19BQ1RJT04oQWN0TmFtZTogc3RyaW5nLCBBY3RWYWx1ZTogbnVtYmVyIHwgc3RyaW5nKTogdm9pZDtcblxuICAvKipcbiAgICog6K6+572u6L2v5Lu25Lqn5ZOB5rOo5YaM5L+h5oGvXG4gICAqXG4gICAqIEBwYXJhbSAgc3RyQ29tcGFueU5hbWUg5rOo5YaM5Y2V5L2N5ZCN56ew77yM55So6YCU5LiO5o6n5Lu25Y+C5pWwQ29tcGFueU5hbWXkuIDmoLfjgIJcbiAgICogQHBhcmFtICBzdHJMaWNlbnNlIOS4u+azqOWGjOWPt++8jOeUqOmAlOS4juaOp+S7tuWPguaVsExpY2Vuc2XkuIDmoLfjgIJcbiAgICogQHBhcmFtICBzdHJMaWNlbnNlQSDpmYTliqDms6jlhozlj7dB77yM55So6YCU5LiO5o6n5Lu25Y+C5pWwTGljZW5zZUHkuIDmoLfjgIJcbiAgICogQHBhcmFtICBzdHJMaWNlbnNlQiDpmYTliqDms6jlhozlj7dC77yM55So6YCU5LiO5o6n5Lu25Y+C5pWwTGljZW5zZULkuIDmoLfjgIJcbiAgICovXG4gIFNFVF9MSUNFTlNFUyhcbiAgICBzdHJDb21wYW55TmFtZTogc3RyaW5nLFxuICAgIHN0ckxpY2Vuc2U6IHN0cmluZyxcbiAgICBzdHJMaWNlbnNlQT86IHN0cmluZyxcbiAgICBzdHJMaWNlbnNlQj86IHN0cmluZyxcbiAgKTogdm9pZDtcblxuICB3ZWJza3Q6IFdlYlNvY2tldDtcbn1cblxuZXhwb3J0IHR5cGUgTG9kb3BTdHlsZVZhbHVlID1cbiAgfCAnRm9udE5hbWUnXG4gIHwgJ0ZvbnRTaXplJ1xuICB8ICdGb250Q29sb3InXG4gIHwgJ0JvbGQnXG4gIHwgJ0l0YWxpYydcbiAgfCAnVW5kZXJsaW5lJ1xuICB8ICdBbGlnbm1lbnQnXG4gIHwgJ0FuZ2xlJ1xuICB8ICdJdGVtVHlwZSdcbiAgfCAnSE9yaWVudCdcbiAgfCAnVk9yaWVudCdcbiAgfCAnUGVuV2lkdGgnXG4gIHwgJ1BlblN0eWxlJ1xuICB8ICdTdHJldGNoJ1xuICB8ICdQcmV2aWV3T25seSdcbiAgfCAnUmVhZE9ubHknO1xuXG5leHBvcnQgaW50ZXJmYWNlIExvZG9wUmVzdWx0IHtcbiAgLyoqIOaYr+WQpuaIkOWKnyAqL1xuICBvazogYm9vbGVhbjtcbiAgLyoqIOmUmeivr+eggSAqL1xuICBzdGF0dXM/OiBzdHJpbmc7XG4gIC8qKiDmiJDlip/ml7bmkLrluKYgTE9ET1Ag5a+56LGhICovXG4gIGxvZG9wPzogTG9kb3A7XG4gIC8qKiDplJnor6/kv6Hmga8gKi9cbiAgZXJyb3I/OiBhbnk7XG59XG5cbmV4cG9ydCBpbnRlcmZhY2UgTG9kb3BQcmludFJlc3VsdCB7XG4gIC8qKiDmmK/lkKbmiJDlip8gKi9cbiAgb2s6IGJvb2xlYW47XG4gIC8qKiDplJnor6/kv6Hmga8gKi9cbiAgZXJyb3I/OiBzdHJpbmc7XG4gIC8qKiDku6PnoIEgKi9cbiAgY29kZTogc3RyaW5nO1xuICAvKiog5Yqo5oCB5Y+C5pWw5LiK5LiL5paH5a+56LGhICovXG4gIGl0ZW06IGFueTtcbiAgLyoqIOS7o+eggeino+aekOihqOi+vuW8jyAqL1xuICBwYXJzZXI/OiBSZWdFeHA7XG59XG4iXX0=