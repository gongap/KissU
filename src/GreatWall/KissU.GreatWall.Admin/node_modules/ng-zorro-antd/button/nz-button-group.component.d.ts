/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { ElementRef, OnInit } from '@angular/core';
import { NzSizeLDSType, NzUpdateHostClassService } from 'ng-zorro-antd/core';
export declare class NzButtonGroupComponent implements OnInit {
    private nzUpdateHostClassService;
    private elementRef;
    nzSize: NzSizeLDSType;
    constructor(nzUpdateHostClassService: NzUpdateHostClassService, elementRef: ElementRef);
    private _size;
    private prefixCls;
    setClassMap(): void;
    ngOnInit(): void;
}
