import { DecimalPipe } from '@angular/common';
import { DomSanitizer } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { _HttpClient, CNCurrencyPipe, DatePipe, YNPipe } from '@delon/theme';
import { STColumn, STData, STMultiSort, STPage, STReq, STRes, STRowClassName, STSingleSort, STStatisticalResults } from './table.interfaces';
export interface STDataSourceOptions {
    pi?: number;
    ps?: number;
    data?: string | STData[] | Observable<STData[]>;
    total?: number;
    req?: STReq;
    res?: STRes;
    page?: STPage;
    columns?: STColumn[];
    singleSort?: STSingleSort;
    multiSort?: STMultiSort;
    rowClassName?: STRowClassName;
}
export interface STDataSourceResult {
    /** 是否需要显示分页器 */
    pageShow?: boolean;
    /** 新 `pi`，若返回 `undefined` 表示用户受控 */
    pi?: number;
    /** 新 `ps`，若返回 `undefined` 表示用户受控 */
    ps?: number;
    /** 新 `total`，若返回 `undefined` 表示用户受控 */
    total?: number;
    /** 数据 */
    list?: STData[];
    /** 统计数据 */
    statistical?: STStatisticalResults;
}
export declare class STDataSource {
    private http;
    private currentyPipe;
    private datePipe;
    private ynPipe;
    private numberPipe;
    private dom;
    private sortTick;
    constructor(http: _HttpClient, currentyPipe: CNCurrencyPipe, datePipe: DatePipe, ynPipe: YNPipe, numberPipe: DecimalPipe, dom: DomSanitizer);
    process(options: STDataSourceOptions): Promise<STDataSourceResult>;
    private get;
    private getByHttp;
    getNoIndex(item: STData, col: STColumn, idx: number): number;
    private getValidSort;
    private getSorterFn;
    readonly nextSortTick: number;
    getReqSortMap(singleSort: STSingleSort, multiSort: STMultiSort, columns: STColumn[]): {
        [key: string]: string;
    };
    private getReqFilterMap;
    private genStatistical;
    private getStatistical;
    private toFixed;
    private getValues;
    private getSum;
}
