import { AfterViewInit, ChangeDetectorRef, ElementRef, EventEmitter, OnChanges, OnDestroy, Renderer2, SimpleChange, SimpleChanges, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { AlainI18NService, DelonLocaleService, DrawerHelper, ModalHelper } from '@delon/theme';
import { Observable } from 'rxjs';
import { STColumnSource } from './table-column-source';
import { STDataSource } from './table-data-source';
import { STExport } from './table-export';
import { STConfig } from './table.config';
import { STChange, STColumn, STColumnButton, STColumnFilterMenu, STColumnSelection, STData, STError, STExportOptions, STLoadOptions, STPage, STReq, STRes, STRowClassName, STSingleSort, STStatisticalResults } from './table.interfaces';
export declare class STComponent implements AfterViewInit, OnChanges, OnDestroy {
    private cdr;
    private cog;
    private router;
    private el;
    private renderer;
    private exportSrv;
    private modalHelper;
    private drawerHelper;
    private doc;
    private columnSource;
    private dataSource;
    private delonI18n;
    private unsubscribe$;
    private totalTpl;
    private locale;
    private clonePage;
    private copyCog;
    _data: STData[];
    _statistical: STStatisticalResults;
    _isPagination: boolean;
    _allChecked: boolean;
    _allCheckedDisabled: boolean;
    _indeterminate: boolean;
    _columns: STColumn[];
    data: string | STData[] | Observable<STData[]>;
    /** 请求体配置 */
    req: STReq;
    private _req;
    /** 返回体配置 */
    res: STRes;
    private _res;
    columns: STColumn[];
    ps: number;
    pi: number;
    total: number;
    /** 分页器配置 */
    page: STPage;
    private _page;
    /** 是否显示Loading */
    loading: boolean;
    /** 延迟显示加载效果的时间（防止闪烁） */
    loadingDelay: number;
    /** 是否显示边框 */
    bordered: boolean;
    /** table大小 */
    size: 'small' | 'middle' | 'default';
    /** 纵向支持滚动，也可用于指定滚动区域的高度：`{ y: '300px', x: '300px' }` */
    scroll: {
        y?: string;
        x?: string;
    };
    /**
     * 单排序规则
     * - 若不指定，则返回：`columnName=ascend|descend`
     * - 若指定，则返回：`sort=columnName.(ascend|descend)`
     */
    singleSort: STSingleSort;
    private _multiSort;
    /** 是否多排序，当 `sort` 多个相同值时自动合并，建议后端支持时使用 */
    multiSort: any;
    rowClassName: STRowClassName;
    /** `header` 标题 */
    header: string | TemplateRef<void>;
    /** `footer` 底部 */
    footer: string | TemplateRef<void>;
    /** 额外 `body` 顶部内容 */
    bodyHeader: TemplateRef<STStatisticalResults>;
    /** 额外 `body` 内容 */
    body: TemplateRef<STStatisticalResults>;
    expandRowByClick: boolean;
    /** `expand` 可展开，当数据源中包括 `expand` 表示展开状态 */
    expand: TemplateRef<{
        $implicit: {};
        column: STColumn;
    }>;
    noResult: string | TemplateRef<void>;
    widthConfig: string[];
    /** 行单击多少时长之类为双击（单位：毫秒），默认：`200` */
    rowClickTime: number;
    responsiveHideHeaderFooter: boolean;
    /** 请求异常时回调 */
    readonly error: EventEmitter<STError>;
    /**
     * 变化时回调，包括：`pi`、`ps`、`checkbox`、`radio`、`sort`、`filter`、`click`、`dblClick` 变动
     */
    readonly change: EventEmitter<STChange>;
    constructor(i18nSrv: AlainI18NService, cdr: ChangeDetectorRef, cog: STConfig, router: Router, el: ElementRef, renderer: Renderer2, exportSrv: STExport, modalHelper: ModalHelper, drawerHelper: DrawerHelper, doc: any, columnSource: STColumnSource, dataSource: STDataSource, delonI18n: DelonLocaleService);
    cd(): this;
    renderTotal(total: string, range: string[]): string;
    private changeEmit;
    private readonly routerState;
    private _load;
    /** 清空所有数据 */
    clear(cleanStatus?: boolean): this;
    /** 清空所有状态 */
    clearStatus(): this;
    /**
     * 根据页码重新加载数据
     *
     * @param pi 指定当前页码，默认：`1`
     * @param extraParams 重新指定 `extraParams` 值
     * @param options 选项
     */
    load(pi?: number, extraParams?: {}, options?: STLoadOptions): this;
    /**
     * 重新刷新当前页
     * @param extraParams 重新指定 `extraParams` 值
     */
    reload(extraParams?: {}, options?: STLoadOptions): this;
    /**
     * 重置且重新设置 `pi` 为 `1`，包含以下值：
     * - `check` 数据
     * - `radio` 数据
     * - `sort` 数据
     * - `fileter` 数据
     *
     * @param extraParams 重新指定 `extraParams` 值
     */
    reset(extraParams?: {}, options?: STLoadOptions): this;
    private _toTop;
    _change(type: 'pi' | 'ps'): void;
    _click(e: Event, item: STData, col: STColumn): boolean;
    private rowClickCount;
    _rowClick(e: Event, item: STData, index: number): void;
    /** 移除某行数据 */
    removeRow(data: STData | STData[]): this;
    sort(col: STColumn, idx: number, value: any): void;
    clearSort(): this;
    private handleFilter;
    _filterConfirm(col: STColumn): void;
    _filterClear(col: STColumn): void;
    _filterRadio(col: STColumn, item: STColumnFilterMenu, checked: boolean): void;
    clearFilter(): this;
    /** 清除所有 `checkbox` */
    clearCheck(): this;
    private _refCheck;
    _checkAll(checked?: boolean): this;
    _checkSelection(i: STData, value: boolean): this;
    _rowSelection(row: STColumnSelection): this;
    _checkNotify(): this;
    /** 清除所有 `radio` */
    clearRadio(): this;
    _refRadio(checked: boolean, item: STData): this;
    _btnClick(e: Event, record: STData, btn: STColumnButton): void;
    private btnCallback;
    _btnText(record: STData, btn: STColumnButton): string;
    _validBtns(item: STData, col: STColumn): STColumnButton[];
    /**
     * 导出当前页，确保已经注册 `XlsxModule`
     * @param newData 重新指定数据，例如希望导出所有数据非常有用
     * @param opt 额外参数
     */
    export(newData?: STData[], opt?: STExportOptions): void;
    resetColumns(): Promise<void | this>;
    private refreshColumns;
    private setClass;
    ngAfterViewInit(): void;
    ngOnChanges(changes: {
        [P in keyof this]?: SimpleChange;
    } & SimpleChanges): void;
    ngOnDestroy(): void;
}
