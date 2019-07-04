/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Injectable } from '@angular/core';
import { of, Subject } from 'rxjs';
import { LazyService } from '@delon/util';
import { LodopConfig } from './lodop.config';
import * as i0 from "@angular/core";
import * as i1 from "./lodop.config";
import * as i2 from "@delon/util";
export class LodopService {
    /**
     * @param {?} defCog
     * @param {?} scriptSrv
     */
    constructor(defCog, scriptSrv) {
        this.defCog = defCog;
        this.scriptSrv = scriptSrv;
        this.pending = false;
        this._lodop = null;
        this._init = new Subject();
        this._events = new Subject();
        this.printBuffer = [];
        this.cog = defCog;
    }
    /**
     * 获取或重新设置配置
     *
     * **注：**重新设置会倒置重新加载脚本资源
     * @return {?}
     */
    get cog() {
        return this._cog;
    }
    /**
     * @param {?} value
     * @return {?}
     */
    set cog(value) {
        this._cog = Object.assign({ url: 'https://localhost:8443/CLodopfuncs.js', name: 'CLODOP', companyName: '', checkMaxCount: 100 }, this.defCog, value);
    }
    /**
     * 事件变更通知
     * @return {?}
     */
    get events() {
        return this._events.asObservable();
    }
    /**
     * @private
     * @return {?}
     */
    check() {
        if (!this._lodop)
            throw new Error(`请务必先调用 lodop 获取对象`);
    }
    /**
     * @private
     * @return {?}
     */
    request() {
        this.pending = true;
        /** @type {?} */
        const url = `${this.cog.url}?name=${this.cog.name}`;
        /** @type {?} */
        let checkMaxCount = this.cog.checkMaxCount;
        /** @type {?} */
        const onResolve = (/**
         * @param {?} status
         * @param {?=} error
         * @return {?}
         */
        (status, error) => {
            this._init.next({
                ok: status === 'ok',
                status,
                error,
                lodop: this._lodop,
            });
        });
        /** @type {?} */
        const checkStatus = (/**
         * @return {?}
         */
        () => {
            --checkMaxCount;
            if (this._lodop.webskt && this._lodop.webskt.readyState === 1) {
                onResolve('ok');
            }
            else {
                if (checkMaxCount < 0) {
                    onResolve('check-limit');
                    return;
                }
                setTimeout((/**
                 * @return {?}
                 */
                () => checkStatus()), 100);
            }
        });
        this.scriptSrv.loadScript(url).then((/**
         * @param {?} res
         * @return {?}
         */
        res => {
            if (res.status !== 'ok') {
                this.pending = false;
                onResolve('script-load-error', res[0]);
                return;
            }
            this._lodop = window.hasOwnProperty(this.cog.name) && ((/** @type {?} */ (window[this.cog.name])));
            if (this._lodop === null) {
                onResolve('load-variable-name-error', { name: this.cog.name });
                return;
            }
            this._lodop.SET_LICENSES(this.cog.companyName, this.cog.license, this.cog.licenseA, this.cog.licenseB);
            checkStatus();
        }));
    }
    /**
     * 重置 lodop 对象
     * @return {?}
     */
    reset() {
        this._lodop = null;
        this.pending = false;
        this.request();
    }
    /**
     * 获取 lodop 对象
     * @return {?}
     */
    get lodop() {
        if (this._lodop)
            return of((/** @type {?} */ ({ ok: true, lodop: this._lodop })));
        if (this.pending)
            return this._init.asObservable();
        this.request();
        return this._init.asObservable();
    }
    /**
     * 获取打印机列表
     * @return {?}
     */
    get printer() {
        this.check();
        /** @type {?} */
        const ret = [];
        /** @type {?} */
        const count = this._lodop.GET_PRINTER_COUNT();
        for (let index = 0; index < count; index++) {
            ret.push(this._lodop.GET_PRINTER_NAME(index));
        }
        return ret;
    }
    /**
     * 附加代码至 `lodop` 对象上，字符串类支持 `{{key}}` 的动态参数
     *
     * **注：** 代码是指打印设计所产生字符串数据
     *
     * @param {?} code 代码
     * @param {?=} contextObj 动态参数上下文对象
     * @param {?=} parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
     * @return {?}
     */
    attachCode(code, contextObj, parser) {
        this.check();
        if (!parser)
            parser = /LODOP\.([^(]+)\(([^\n]+)\);/i;
        code.split('\n').forEach((/**
         * @param {?} line
         * @return {?}
         */
        line => {
            /** @type {?} */
            const res = parser.exec(line.trim());
            if (!res)
                return;
            /** @type {?} */
            const fn = this._lodop[res[1]];
            if (fn) {
                /** @type {?} */
                let arr;
                try {
                    /** @type {?} */
                    const fakeFn = new Function(`return [${res[2]}]`);
                    arr = fakeFn();
                }
                catch (_a) { }
                if (Array.isArray(arr) && contextObj) {
                    for (let i = 0; i < arr.length; i++) {
                        if (typeof arr[i] === 'string') {
                            arr[i] = arr[i].replace(/{{(.*?)}}/g, (/**
                             * @param {?} match
                             * @param {?} key
                             * @return {?}
                             */
                            (match, key) => contextObj[key.trim()] || ''));
                        }
                    }
                }
                fn.apply(this._lodop, arr);
            }
        }));
    }
    /**
     * 打开打印设计关闭后自动返回代码
     *
     * **注：** 自动监听 `On_Return` 事件，运行后会移除
     * @return {?}
     */
    design() {
        this.check();
        /** @type {?} */
        const tid = this._lodop.PRINT_DESIGN();
        return new Promise((/**
         * @param {?} resolve
         * @return {?}
         */
        resolve => {
            this._lodop.On_Return = (/**
             * @param {?} taskID
             * @param {?} value
             * @return {?}
             */
            (taskID, value) => {
                if (tid !== taskID)
                    return;
                this._lodop.On_Return = null;
                resolve('' + value);
            });
        }));
    }
    /**
     * @private
     * @return {?}
     */
    printDo() {
        /** @type {?} */
        const data = this.printBuffer.shift();
        if (!data)
            return;
        this.attachCode(data.code, data.item, data.parser);
        /** @type {?} */
        const tid = this._lodop.PRINT();
        this._lodop.On_Return = (/**
         * @param {?} taskID
         * @param {?} value
         * @return {?}
         */
        (taskID, value) => {
            if (tid !== taskID)
                return;
            this._lodop.On_Return = null;
            this._events.next(Object.assign({ ok: value === true, error: value === true ? null : value }, data));
            this.printDo();
        });
    }
    /**
     * 立即打印，一般用于批量套打
     *
     * @param {?} code 代码
     * @param {?} contextObj 动态参数上下文对象
     * @param {?=} parser 自定义解析表达式，默认：`/LODOP\.([^(]+)\(([^\n]+)\);/i`
     * @return {?}
     */
    print(code, contextObj, parser) {
        this.check();
        if (contextObj) {
            this.printBuffer.push(...(Array.isArray(contextObj) ? contextObj : [contextObj]).map((/**
             * @param {?} item
             * @return {?}
             */
            item => {
                return { code, parser, item };
            })));
        }
        this.printDo();
    }
    /**
     * @return {?}
     */
    ngOnDestroy() {
        this._init.unsubscribe();
        this._events.unsubscribe();
    }
}
LodopService.decorators = [
    { type: Injectable, args: [{ providedIn: 'root' },] }
];
/** @nocollapse */
LodopService.ctorParameters = () => [
    { type: LodopConfig },
    { type: LazyService }
];
/** @nocollapse */ LodopService.ngInjectableDef = i0.defineInjectable({ factory: function LodopService_Factory() { return new LodopService(i0.inject(i1.LodopConfig), i0.inject(i2.LazyService)); }, token: LodopService, providedIn: "root" });
if (false) {
    /**
     * @type {?}
     * @private
     */
    LodopService.prototype._cog;
    /**
     * @type {?}
     * @private
     */
    LodopService.prototype.pending;
    /**
     * @type {?}
     * @private
     */
    LodopService.prototype._lodop;
    /**
     * @type {?}
     * @private
     */
    LodopService.prototype._init;
    /**
     * @type {?}
     * @private
     */
    LodopService.prototype._events;
    /**
     * @type {?}
     * @private
     */
    LodopService.prototype.printBuffer;
    /**
     * @type {?}
     * @private
     */
    LodopService.prototype.defCog;
    /**
     * @type {?}
     * @private
     */
    LodopService.prototype.scriptSrv;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibG9kb3Auc2VydmljZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi9hYmMvbG9kb3AvIiwic291cmNlcyI6WyJsb2RvcC5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsVUFBVSxFQUFhLE1BQU0sZUFBZSxDQUFDO0FBQ3RELE9BQU8sRUFBRSxFQUFFLEVBQWMsT0FBTyxFQUFFLE1BQU0sTUFBTSxDQUFDO0FBRS9DLE9BQU8sRUFBRSxXQUFXLEVBQUUsTUFBTSxhQUFhLENBQUM7QUFFMUMsT0FBTyxFQUFFLFdBQVcsRUFBRSxNQUFNLGdCQUFnQixDQUFDOzs7O0FBSTdDLE1BQU0sT0FBTyxZQUFZOzs7OztJQU92QixZQUFvQixNQUFtQixFQUFVLFNBQXNCO1FBQW5ELFdBQU0sR0FBTixNQUFNLENBQWE7UUFBVSxjQUFTLEdBQVQsU0FBUyxDQUFhO1FBTC9ELFlBQU8sR0FBRyxLQUFLLENBQUM7UUFDaEIsV0FBTSxHQUFVLElBQUksQ0FBQztRQUNyQixVQUFLLEdBQXlCLElBQUksT0FBTyxFQUFlLENBQUM7UUFDekQsWUFBTyxHQUE4QixJQUFJLE9BQU8sRUFBb0IsQ0FBQztRQWlLckUsZ0JBQVcsR0FBVSxFQUFFLENBQUM7UUE5SjlCLElBQUksQ0FBQyxHQUFHLEdBQUcsTUFBTSxDQUFDO0lBQ3BCLENBQUM7Ozs7Ozs7SUFPRCxJQUFJLEdBQUc7UUFDTCxPQUFPLElBQUksQ0FBQyxJQUFJLENBQUM7SUFDbkIsQ0FBQzs7Ozs7SUFDRCxJQUFJLEdBQUcsQ0FBQyxLQUFrQjtRQUN4QixJQUFJLENBQUMsSUFBSSxtQkFDUCxHQUFHLEVBQUUsdUNBQXVDLEVBQzVDLElBQUksRUFBRSxRQUFRLEVBQ2QsV0FBVyxFQUFFLEVBQUUsRUFDZixhQUFhLEVBQUUsR0FBRyxJQUNmLElBQUksQ0FBQyxNQUFNLEVBQ1gsS0FBSyxDQUNULENBQUM7SUFDSixDQUFDOzs7OztJQUdELElBQUksTUFBTTtRQUNSLE9BQU8sSUFB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QyxVQUFVLENBQUMsQ0FBQyxDQUFDLENBQUMsVUFBVSxDQUFDLENBQUMsQ0FBQyxHQUFHOzs7O1lBQUMsSUFBSSxDQUFDLEVBQUU7Z0JBQ3BFLE9BQU8sRUFBRSxJQUFJLEVBQUUsTUFBTSxFQUFFLElBQUksRUFBRSxDQUFDO1lBQ2hDLENBQUMsRUFBQyxDQUNILENBQUM7U0FDSDtRQUNELElBQUksQ0FBQyxPQUFPLEVBQUUsQ0FBQztJQUNqQixDQUFDOzs7O0lBRUQsV0FBVztRQUNULElBQUksQ0FBQyxLQUFLLENBQUMsV0FBVyxFQUFFLENBQUM7UUFDekIsSUFBSSxDQUFDLE9BQU8sQ0FBQyxXQUFXLEVBQUUsQ0FBQztJQUM3QixDQUFDOzs7WUEvTUYsVUFBVSxTQUFDLEVBQUUsVUFBVSxFQUFFLE1BQU0sRUFBRTs7OztZQUh6QixXQUFXO1lBRlgsV0FBVzs7Ozs7Ozs7SUFPbEIsNEJBQTBCOzs7OztJQUMxQiwrQkFBd0I7Ozs7O0lBQ3hCLDhCQUE2Qjs7Ozs7SUFDN0IsNkJBQWlFOzs7OztJQUNqRSwrQkFBNkU7Ozs7O0lBaUs3RSxtQ0FBZ0M7Ozs7O0lBL0pwQiw4QkFBMkI7Ozs7O0lBQUUsaUNBQThCIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgSW5qZWN0YWJsZSwgT25EZXN0cm95IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XG5pbXBvcnQgeyBvZiwgT2JzZXJ2YWJsZSwgU3ViamVjdCB9IGZyb20gJ3J4anMnO1xuXG5pbXBvcnQgeyBMYXp5U2VydmljZSB9IGZyb20gJ0BkZWxvbi91dGlsJztcblxuaW1wb3J0IHsgTG9kb3BDb25maWcgfSBmcm9tICcuL2xvZG9wLmNvbmZpZyc7XG5pbXBvcnQgeyBMb2RvcCwgTG9kb3BQcmludFJlc3VsdCwgTG9kb3BSZXN1bHQgfSBmcm9tICcuL2xvZG9wLnR5cGVzJztcblxuQEluamVjdGFibGUoeyBwcm92aWRlZEluOiAncm9vdCcgfSlcbmV4cG9ydCBjbGFzcyBMb2RvcFNlcnZpY2UgaW1wbGVtZW50cyBPbkRlc3Ryb3kge1xuICBwcml2YXRlIF9jb2c6IExvZG9wQ29uZmlnO1xuICBwcml2YXRlIHBlbmRpbmcgPSBmYWxzZTtcbiAgcHJpdmF0ZSBfbG9kb3A6IExvZG9wID0gbnVsbDtcbiAgcHJpdmF0ZSBfaW5pdDogU3ViamVjdDxMb2RvcFJlc3VsdD4gPSBuZXcgU3ViamVjdDxMb2RvcFJlc3VsdD4oKTtcbiAgcHJpdmF0ZSBfZXZlbnRzOiBTdWJqZWN0PExvZG9wUHJpbnRSZXN1bHQ+ID0gbmV3IFN1YmplY3Q8TG9kb3BQcmludFJlc3VsdD4oKTtcblxuICBjb25zdHJ1Y3Rvcihwcml2YXRlIGRlZkNvZzogTG9kb3BDb25maWcsIHByaXZhdGUgc2NyaXB0U3J2OiBMYXp5U2VydmljZSkge1xuICAgIHRoaXMuY29nID0gZGVmQ29nO1xuICB9XG5cbiAgLyoqXG4gICAqIOiOt+WPluaIlumHjeaWsOiuvue9rumFjee9rlxuICAgKlxuICAgKiAqKuazqO+8mioq6YeN5paw6K6+572u5Lya5YCS572u6YeN5paw5Yqg6L296ISa5pys6LWE5rqQXG4gICAqL1xuICBnZXQgY29nKCkge1xuICAgIHJldHVybiB0aGlzLl9jb2c7XG4gIH1cbiAgc2V0IGNvZyh2YWx1ZTogTG9kb3BDb25maWcpIHtcbiAgICB0aGlzLl9jb2cgPSB7XG4gICAgICB1cmw6ICdodHRwczovL2xvY2FsaG9zdDo4NDQzL0NMb2RvcGZ1bmNzLmpzJyxcbiAgICAgIG5hbWU6ICdDTE9ET1AnLFxuICAgICAgY29tcGFueU5hbWU6ICcnLFxuICAgICAgY2hlY2tNYXhDb3VudDogMTAwLFxuICAgICAgLi4udGhpcy5kZWZDb2csXG4gICAgICAuLi52YWx1ZSxcbiAgICB9O1xuICB9XG5cbiAgLyoqIOS6i+S7tuWPmOabtOmAmuefpSAqL1xuICBnZXQgZXZlbnRzKCk6IE9ic2VydmFibGU8TG9kb3BQcmludFJlc3VsdD4ge1xuICAgIHJldHVybiB0aGlzLl9ldmVudHMuYXNPYnNlcnZhYmxlKCk7XG4gIH1cblxuICBwcml2YXRlIGNoZWNrKCkge1xuICAgIGlmICghdGhpcy5fbG9kb3ApIHRocm93IG5ldyBFcnJvcihg6K+35Yqh5b+F5YWI6LCD55SoIGxvZG9wIOiOt+WPluWvueixoWApO1xuICB9XG5cbiAgcHJpdmF0ZSByZXF1ZXN0KCk6IHZvaWQge1xuICAgIHRoaXMucGVuZGluZyA9IHRydWU7XG5cbiAgICBjb25zdCB1cmwgPSBgJHt0aGlzLmNvZy51cmx9P25hbWU9JHt0aGlzLmNvZy5uYW1lfWA7XG4gICAgbGV0IGNoZWNrTWF4Q291bnQgPSB0aGlzLmNvZy5jaGVja01heENvdW50O1xuICAgIGNvbnN0IG9uUmVzb2x2ZSA9IChzdGF0dXMsIGVycm9yPzoge30pID0+IHtcbiAgICAgIHRoaXMuX2luaXQubmV4dCh7XG4gICAgICAgIG9rOiBzdGF0dXMgPT09ICdvaycsXG4gICAgICAgIHN0YXR1cyxcbiAgICAgICAgZXJyb3IsXG4gICAgICAgIGxvZG9wOiB0aGlzLl9sb2RvcCxcbiAgICAgIH0pO1xuICAgIH07XG4gICAgY29uc3QgY2hlY2tTdGF0dXMgPSAoKSA9PiB7XG4gICAgICAtLWNoZWNrTWF4Q291bnQ7XG4gICAgICBpZiAodGhpcy5fbG9kb3Aud2Vic2t0ICYmIHRoaXMuX2xvZG9wLndlYnNrdC5yZWFkeVN0YXRlID09PSAxKSB7XG4gICAgICAgIG9uUmVzb2x2ZSgnb2snKTtcbiAgICAgIH0gZWxzZSB7XG4gICAgICAgIGlmIChjaGVja01heENvdW50IDwgMCkge1xuICAgICAgICAgIG9uUmVzb2x2ZSgnY2hlY2stbGltaXQnKTtcbiAgICAgICAgICByZXR1cm47XG4gICAgICAgIH1cbiAgICAgICAgc2V0VGltZW91dCgoKSA9PiBjaGVja1N0YXR1cygpLCAxMDApO1xuICAgICAgfVxuICAgIH07XG5cbiAgICB0aGlzLnNjcmlwdFNydi5sb2FkU2NyaXB0KHVybCkudGhlbihyZXMgPT4ge1xuICAgICAgaWYgKHJlcy5zdGF0dXMgIT09ICdvaycpIHtcbiAgICAgICAgdGhpcy5wZW5kaW5nID0gZmFsc2U7XG4gICAgICAgIG9uUmVzb2x2ZSgnc2NyaXB0LWxvYWQtZXJyb3InLCByZXNbMF0pO1xuICAgICAgICByZXR1cm47XG4gICAgICB9XG4gICAgICB0aGlzLl9sb2RvcCA9IHdpbmRvdy5oYXNPd25Qcm9wZXJ0eSh0aGlzLmNvZy5uYW1lKSAmJiAod2luZG93W3RoaXMuY29nLm5hbWVdIGFzIExvZG9wKTtcbiAgICAgIGlmICh0aGlzLl9sb2RvcCA9PT0gbnVsbCkge1xuICAgICAgICBvblJlc29sdmUoJ2xvYWQtdmFyaWFibGUtbmFtZS1lcnJvcicsIHsgbmFtZTogdGhpcy5jb2cubmFtZSB9KTtcbiAgICAgICAgcmV0dXJuO1xuICAgICAgfVxuICAgICAgdGhpcy5fbG9kb3AuU0VUX0xJQ0VOU0VTKFxuICAgICAgICB0aGlzLmNvZy5jb21wYW55TmFtZSxcbiAgICAgICAgdGhpcy5jb2cubGljZW5zZSxcbiAgICAgICAgdGhpcy5jb2cubGljZW5zZUEsXG4gICAgICAgIHRoaXMuY29nLmxpY2Vuc2VCLFxuICAgICAgKTtcbiAgICAgIGNoZWNrU3RhdHVzKCk7XG4gICAgfSk7XG4gIH1cblxuICAvKiog6YeN572uIGxvZG9wIOWvueixoSAqL1xuICByZXNldCgpIHtcbiAgICB0aGlzLl9sb2RvcCA9IG51bGw7XG4gICAgdGhpcy5wZW5kaW5nID0gZmFsc2U7XG4gICAgdGhpcy5yZXF1ZXN0KCk7XG4gIH1cblxuICAvKiog6I635Y+WIGxvZG9wIOWvueixoSAqL1xuICBnZXQgbG9kb3AoKTogT2JzZXJ2YWJsZTxMb2RvcFJlc3VsdD4ge1xuICAgIGlmICh0aGlzLl9sb2RvcCkgcmV0dXJuIG9mKHsgb2s6IHRydWUsIGxvZG9wOiB0aGlzLl9sb2RvcCB9IGFzIExvZG9wUmVzdWx0KTtcbiAgICBpZiAodGhpcy5wZW5kaW5nKSByZXR1cm4gdGhpcy5faW5pdC5hc09ic2VydmFibGUoKTtcblxuICAgIHRoaXMucmVxdWVzdCgpO1xuXG4gICAgcmV0dXJuIHRoaXMuX2luaXQuYXNPYnNlcnZhYmxlKCk7XG4gIH1cblxuICAvKiog6I635Y+W5omT5Y2w5py65YiX6KGoICovXG4gIGdldCBwcmludGVyKCk6IHN0cmluZ1tdIHtcbiAgICB0aGlzLmNoZWNrKCk7XG4gICAgY29uc3QgcmV0OiBzdHJpbmdbXSA9IFtdO1xuICAgIGNvbnN0IGNvdW50ID0gdGhpcy5fbG9kb3AuR0VUX1BSSU5URVJfQ09VTlQoKTtcbiAgICBmb3IgKGxldCBpbmRleCA9IDA7IGluZGV4IDwgY291bnQ7IGluZGV4KyspIHtcbiAgICAgIHJldC5wdXNoKHRoaXMuX2xvZG9wLkdFVF9QUklOVEVSX05BTUUoaW5kZXgpKTtcbiAgICB9XG4gICAgcmV0dXJuIHJldDtcbiAgfVxuXG4gIC8qKlxuICAgKiDpmYTliqDku6PnoIHoh7MgYGxvZG9wYCDlr7nosaHkuIrvvIzlrZfnrKbkuLLnsbvmlK/mjIEgYHt7a2V5fX1gIOeahOWKqOaAgeWPguaVsFxuICAgKlxuICAgKiAqKuazqO+8mioqIOS7o+eggeaYr+aMh+aJk+WNsOiuvuiuoeaJgOS6p+eUn+Wtl+espuS4suaVsOaNrlxuICAgKlxuICAgKiBAcGFyYW0gY29kZSDku6PnoIFcbiAgICogQHBhcmFtIGNvbnRleHRPYmog5Yqo5oCB5Y+C5pWw5LiK5LiL5paH5a+56LGhXG4gICAqIEBwYXJhbSBwYXJzZXIg6Ieq5a6a5LmJ6Kej5p6Q6KGo6L6+5byP77yM6buY6K6k77yaYC9MT0RPUFxcLihbXihdKylcXCgoW15cXG5dKylcXCk7L2lgXG4gICAqL1xuICBhdHRhY2hDb2RlKGNvZGU6IHN0cmluZywgY29udGV4dE9iaj86IHt9LCBwYXJzZXI/OiBSZWdFeHApOiB2b2lkIHtcbiAgICB0aGlzLmNoZWNrKCk7XG4gICAgaWYgKCFwYXJzZXIpIHBhcnNlciA9IC9MT0RPUFxcLihbXihdKylcXCgoW15cXG5dKylcXCk7L2k7XG4gICAgY29kZS5zcGxpdCgnXFxuJykuZm9yRWFjaChsaW5lID0+IHtcbiAgICAgIGNvbnN0IHJlcyA9IHBhcnNlci5leGVjKGxpbmUudHJpbSgpKTtcbiAgICAgIGlmICghcmVzKSByZXR1cm47XG4gICAgICBjb25zdCBmbiA9IHRoaXMuX2xvZG9wW3Jlc1sxXV07XG4gICAgICBpZiAoZm4pIHtcbiAgICAgICAgbGV0IGFycjogYW55W107XG4gICAgICAgIHRyeSB7XG4gICAgICAgICAgY29uc3QgZmFrZUZuID0gbmV3IEZ1bmN0aW9uKGByZXR1cm4gWyR7cmVzWzJdfV1gKTtcbiAgICAgICAgICBhcnIgPSBmYWtlRm4oKTtcbiAgICAgICAgfSBjYXRjaCB7fVxuXG4gICAgICAgIGlmIChBcnJheS5pc0FycmF5KGFycikgJiYgY29udGV4dE9iaikge1xuICAgICAgICAgIGZvciAobGV0IGkgPSAwOyBpIDwgYXJyLmxlbmd0aDsgaSsrKSB7XG4gICAgICAgICAgICBpZiAodHlwZW9mIGFycltpXSA9PT0gJ3N0cmluZycpIHtcbiAgICAgICAgICAgICAgYXJyW2ldID0gYXJyW2ldLnJlcGxhY2UoL3t7KC4qPyl9fS9nLCAobWF0Y2gsIGtleSkgPT4gY29udGV4dE9ialtrZXkudHJpbSgpXSB8fCAnJyk7XG4gICAgICAgICAgICB9XG4gICAgICAgICAgfVxuICAgICAgICB9XG4gICAgICAgIGZuLmFwcGx5KHRoaXMuX2xvZG9wLCBhcnIpO1xuICAgICAgfVxuICAgIH0pO1xuICB9XG5cbiAgLyoqXG4gICAqIOaJk+W8gOaJk+WNsOiuvuiuoeWFs+mXreWQjuiHquWKqOi/lOWbnuS7o+eggVxuICAgKlxuICAgKiAqKuazqO+8mioqIOiHquWKqOebkeWQrCBgT25fUmV0dXJuYCDkuovku7bvvIzov5DooYzlkI7kvJrnp7vpmaRcbiAgICovXG4gIGRlc2lnbigpOiBQcm9taXNlPHN0cmluZz4ge1xuICAgIHRoaXMuY2hlY2soKTtcbiAgICBjb25zdCB0aWQgPSB0aGlzLl9sb2RvcC5QUklOVF9ERVNJR04oKTtcbiAgICByZXR1cm4gbmV3IFByb21pc2UocmVzb2x2ZSA9PiB7XG4gICAgICB0aGlzLl9sb2RvcC5Pbl9SZXR1cm4gPSAodGFza0lEOiBzdHJpbmcsIHZhbHVlOiBib29sZWFuIHwgc3RyaW5nKSA9PiB7XG4gICAgICAgIGlmICh0aWQgIT09IHRhc2tJRCkgcmV0dXJuO1xuICAgICAgICB0aGlzLl9sb2RvcC5Pbl9SZXR1cm4gPSBudWxsO1xuICAgICAgICByZXNvbHZlKCcnICsgdmFsdWUpO1xuICAgICAgfTtcbiAgICB9KTtcbiAgfVxuXG4gIHByaXZhdGUgcHJpbnRCdWZmZXI6IGFueVtdID0gW107XG4gIHByaXZhdGUgcHJpbnREbygpIHtcbiAgICBjb25zdCBkYXRhID0gdGhpcy5wcmludEJ1ZmZlci5zaGlmdCgpO1xuICAgIGlmICghZGF0YSkgcmV0dXJuO1xuICAgIHRoaXMuYXR0YWNoQ29kZShkYXRhLmNvZGUsIGRhdGEuaXRlbSwgZGF0YS5wYXJzZXIpO1xuICAgIGNvbnN0IHRpZCA9IHRoaXMuX2xvZG9wLlBSSU5UKCk7XG4gICAgdGhpcy5fbG9kb3AuT25fUmV0dXJuID0gKHRhc2tJRDogc3RyaW5nLCB2YWx1ZTogYm9vbGVhbiB8IHN0cmluZykgPT4ge1xuICAgICAgaWYgKHRpZCAhPT0gdGFza0lEKSByZXR1cm47XG4gICAgICB0aGlzLl9sb2RvcC5Pbl9SZXR1cm4gPSBudWxsO1xuICAgICAgdGhpcy5fZXZlbnRzLm5leHQoe1xuICAgICAgICBvazogdmFsdWUgPT09IHRydWUsXG4gICAgICAgIGVycm9yOiB2YWx1ZSA9PT0gdHJ1ZSA/IG51bGwgOiB2YWx1ZSxcbiAgICAgICAgLi4uZGF0YSxcbiAgICAgIH0pO1xuICAgICAgdGhpcy5wcmludERvKCk7XG4gICAgfTtcbiAgfVxuXG4gIC8qKlxuICAgKiDnq4vljbPmiZPljbDvvIzkuIDoiKznlKjkuo7mibnph4/lpZfmiZNcbiAgICpcbiAgICogQHBhcmFtIGNvZGUg5Luj56CBXG4gICAqIEBwYXJhbSBjb250ZXh0T2JqIOWKqOaAgeWPguaVsOS4iuS4i+aWh+WvueixoVxuICAgKiBAcGFyYW0gcGFyc2VyIOiHquWumuS5ieino+aekOihqOi+vuW8j++8jOm7mOiupO+8mmAvTE9ET1BcXC4oW14oXSspXFwoKFteXFxuXSspXFwpOy9pYFxuICAgKi9cbiAgcHJpbnQoY29kZTogc3RyaW5nLCBjb250ZXh0T2JqOiB7fSB8IEFycmF5PHt9PiwgcGFyc2VyPzogUmVnRXhwKTogdm9pZCB7XG4gICAgdGhpcy5jaGVjaygpO1xuICAgIGlmIChjb250ZXh0T2JqKSB7XG4gICAgICB0aGlzLnByaW50QnVmZmVyLnB1c2goXG4gICAgICAgIC4uLihBcnJheS5pc0FycmF5KGNvbnRleHRPYmopID8gY29udGV4dE9iaiA6IFtjb250ZXh0T2JqXSkubWFwKGl0ZW0gPT4ge1xuICAgICAgICAgIHJldHVybiB7IGNvZGUsIHBhcnNlciwgaXRlbSB9O1xuICAgICAgICB9KSxcbiAgICAgICk7XG4gICAgfVxuICAgIHRoaXMucHJpbnREbygpO1xuICB9XG5cbiAgbmdPbkRlc3Ryb3koKTogdm9pZCB7XG4gICAgdGhpcy5faW5pdC51bnN1YnNjcmliZSgpO1xuICAgIHRoaXMuX2V2ZW50cy51bnN1YnNjcmliZSgpO1xuICB9XG59XG4iXX0=