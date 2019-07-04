/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { ElementRef, OnChanges, OnDestroy, OnInit, Renderer2, SimpleChanges } from '@angular/core';
import { Subject } from 'rxjs';
import { NzMenuBaseService, NzUpdateHostClassService } from 'ng-zorro-antd/core';
import { NzSubmenuService } from './nz-submenu.service';
export declare class NzMenuItemDirective implements OnInit, OnChanges, OnDestroy {
    private nzUpdateHostClassService;
    private nzMenuService;
    private nzSubmenuService;
    private renderer;
    private elementRef;
    private el;
    private destroy$;
    private originalPadding;
    selected$: Subject<boolean>;
    nzPaddingLeft: number;
    nzDisabled: boolean;
    nzSelected: boolean;
    /** clear all item selected status except this */
    clickMenuItem(e: MouseEvent): void;
    setClassMap(): void;
    setSelectedState(value: boolean): void;
    constructor(nzUpdateHostClassService: NzUpdateHostClassService, nzMenuService: NzMenuBaseService, nzSubmenuService: NzSubmenuService, renderer: Renderer2, elementRef: ElementRef);
    ngOnInit(): void;
    ngOnChanges(changes: SimpleChanges): void;
    ngOnDestroy(): void;
}
