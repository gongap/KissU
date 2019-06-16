/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { RendererFactory2 } from '@angular/core';
export declare class NzUpdateHostClassService {
    private classMap;
    private renderer;
    updateHostClass(el: HTMLElement, classMap: object): void;
    private removeClass;
    private addClass;
    constructor(rendererFactory2: RendererFactory2);
}
