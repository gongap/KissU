/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { AfterViewInit, ElementRef, OnChanges, OnInit, Renderer2, SimpleChanges, TemplateRef } from '@angular/core';
export declare type NzBadgeStatusType = 'success' | 'processing' | 'default' | 'error' | 'warning';
export declare class NzBadgeComponent implements OnInit, AfterViewInit, OnChanges {
    private renderer;
    private elementRef;
    maxNumberArray: string[];
    countArray: number[];
    countSingleArray: number[];
    colorArray: string[];
    presetColor: string | null;
    count: number;
    contentElement: ElementRef;
    nzShowZero: boolean;
    nzShowDot: boolean;
    nzDot: boolean;
    nzOverflowCount: number;
    nzText: string;
    nzColor: string;
    nzStyle: {
        [key: string]: string;
    };
    nzStatus: NzBadgeStatusType;
    nzCount: number | TemplateRef<void>;
    checkContent(): void;
    readonly showSup: boolean;
    generateMaxNumberArray(): void;
    constructor(renderer: Renderer2, elementRef: ElementRef);
    ngOnInit(): void;
    ngAfterViewInit(): void;
    ngOnChanges(changes: SimpleChanges): void;
}
