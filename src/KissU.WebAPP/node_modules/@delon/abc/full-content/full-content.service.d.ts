import { Observable } from 'rxjs';
export declare class FullContentService {
    private _change;
    /** 切换全屏工作区状态 */
    toggle(): void;
    readonly change: Observable<boolean>;
}
