/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { Provider } from '@angular/core';
export declare type EasyingFn = (t: number, b: number, c: number, d: number) => number;
export declare class NzScrollService {
    private doc;
    constructor(doc: any);
    /** 设置 `el` 滚动条位置 */
    setScrollTop(el: Element | Window, topValue?: number): void;
    /** 获取 `el` 相对于视窗距离 */
    getOffset(el: Element): {
        top: number;
        left: number;
    };
    /** 获取 `el` 滚动条位置 */
    getScroll(el?: Element | Window, top?: boolean): number;
    /**
     * 使用动画形式将 `el` 滚动至某位置
     *
     * @param containerEl 容器，默认 `window`
     * @param targetTopValue 滚动至目标 `top` 值，默认：0，相当于顶部
     * @param easing 动作算法，默认：`easeInOutCubic`
     * @param callback 动画结束后回调
     */
    scrollTo(containerEl: Element | Window, targetTopValue?: number, easing?: EasyingFn, callback?: () => void): void;
}
export declare function SCROLL_SERVICE_PROVIDER_FACTORY(doc: Document, scrollService: NzScrollService): NzScrollService;
export declare const SCROLL_SERVICE_PROVIDER: Provider;
