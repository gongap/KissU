import { ACLService } from '@delon/acl';
import { AlainI18NService } from '@delon/theme';
import { STRowSource } from './table-row.directive';
import { STConfig } from './table.config';
import { STColumn, STColumnSort } from './table.interfaces';
export interface STSortMap extends STColumnSort {
    [key: string]: any;
    /** 是否启用排序 */
    enabled?: boolean;
}
export declare class STColumnSource {
    private rowSource;
    private acl;
    private i18nSrv;
    private cog;
    constructor(rowSource: STRowSource, acl: ACLService, i18nSrv: AlainI18NService, cog: STConfig);
    private btnCoerce;
    private btnCoerceIf;
    private fixedCoerce;
    private sortCoerce;
    private filterCoerce;
    private restoreRender;
    process(list: STColumn[]): STColumn[];
    restoreAllRender(columns: STColumn[]): void;
}
