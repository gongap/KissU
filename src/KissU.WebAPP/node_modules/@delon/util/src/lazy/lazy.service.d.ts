import { Observable } from 'rxjs';
export interface LazyResult {
    path: string;
    loaded: boolean;
    status: 'ok' | 'error';
    error?: {};
}
export declare class LazyService {
    private doc;
    private list;
    private cached;
    private _notify;
    constructor(doc: any);
    readonly change: Observable<LazyResult[]>;
    clear(): void;
    load(paths: string | string[]): Promise<LazyResult[]>;
    loadScript(path: string, innerContent?: string): Promise<LazyResult>;
    loadStyle(path: string, rel?: string, innerContent?: string): Promise<LazyResult>;
}
