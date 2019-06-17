import { HttpClient } from '@angular/common/http';
import { LazyService } from '@delon/util';
import { XlsxConfig } from './xlsx.config';
import { XlsxExportOptions } from './xlsx.types';
export declare class XlsxService {
    private cog;
    private http;
    private lazy;
    constructor(cog: XlsxConfig, http: HttpClient, lazy: LazyService);
    private init;
    private read;
    /**
     * 导入Excel并输出JSON，支持 `<input type="file">`、URL 形式
     * @param rABS 加载数据方式 `readAsBinaryString` （默认） 或 `readAsArrayBuffer`，[更多细节](http://t.cn/R3n63A0)
     */
    import(fileOrUrl: File | string, rABS?: 'readAsBinaryString' | 'readAsArrayBuffer'): Promise<{
        [key: string]: any[][];
    }>;
    /** 导出 */
    export(options: XlsxExportOptions): Promise<void>;
}
