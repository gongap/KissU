import { OnDestroy } from '@angular/core';
import { Observable } from 'rxjs';
import { LazyService } from '@delon/util';
import { LodopConfig } from './lodop.config';
import { LodopPrintResult, LodopResult } from './lodop.types';
export declare class LodopService implements OnDestroy {
    private defCog;
    private scriptSrv;
    private _cog;
    private pending;
    private _lodop;
    private _init;
    private _events;
    constructor(defCog: LodopConfig, scriptSrv: LazyService);
    /**
     * 获取或重新设置配置
     *
     * **注：**重新设置会倒置重新加载脚本资源
     */
    cog: LodopConfig;
    /** 事件变更通知 */
    readonly events: Observable<LodopPrintResult>;
    private check;
    private request;
    /** 重置 lodop 对象 */
    reset(): void;
    /** 获取 lodop 对象 */
    readonly lodop: Observable<LodopResult>;
    /** 获取打印机列表 */
    readonly printer: string[];
    /**
     * 附加代码至 `lodop` 对象上，字符串类支持 `{{key}}` 的动态参数
     *
     * **注：** 代码是指打印设计所产生字符串数据
     *
     * @param code 代码
     * @param contextObj 动态参数上下文对象
     * @param parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
     */
    attachCode(code: string, contextObj?: {}, parser?: RegExp): void;
    /**
     * 打开打印设计关闭后自动返回代码
     *
     * **注：** 自动监听 `On_Return` 事件，运行后会移除
     */
    design(): Promise<string>;
    private printBuffer;
    private printDo;
    /**
     * 立即打印，一般用于批量套打
     *
     * @param code 代码
     * @param contextObj 动态参数上下文对象
     * @param parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
     */
    print(code: string, contextObj: {} | Array<{}>, parser?: RegExp): void;
    ngOnDestroy(): void;
}
