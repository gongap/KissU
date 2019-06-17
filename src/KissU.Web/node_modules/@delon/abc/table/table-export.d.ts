import { XlsxService } from '@delon/abc/xlsx';
import { STExportOptions } from './table.interfaces';
export declare class STExport {
    private xlsxSrv;
    constructor(xlsxSrv: XlsxService);
    private _stGet;
    private genSheet;
    export(opt: STExportOptions): Promise<void>;
}
