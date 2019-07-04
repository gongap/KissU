/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { ElementRef, Renderer2 } from '@angular/core';
import { Observable } from 'rxjs';
export declare class NzDropDownDirective {
    elementRef: ElementRef;
    private renderer;
    el: HTMLElement;
    hover$: Observable<boolean>;
    $click: Observable<boolean>;
    setDisabled(disabled: boolean): void;
    constructor(elementRef: ElementRef, renderer: Renderer2);
}
