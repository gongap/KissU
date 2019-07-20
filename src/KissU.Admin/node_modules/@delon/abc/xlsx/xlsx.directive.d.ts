import { XlsxService } from './xlsx.service';
import { XlsxExportOptions } from './xlsx.types';
export declare class XlsxDirective {
    private srv;
    data: XlsxExportOptions;
    constructor(srv: XlsxService);
    _click(): void;
}
