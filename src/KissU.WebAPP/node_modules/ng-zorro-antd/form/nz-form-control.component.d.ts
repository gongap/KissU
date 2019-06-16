/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { AfterContentInit, AfterViewInit, ChangeDetectorRef, ElementRef, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { FormControl, FormControlName, NgModel } from '@angular/forms';
import { Subscription } from 'rxjs';
import { NgClassType, NzUpdateHostClassService } from 'ng-zorro-antd/core';
import { NzColDirective, NzRowDirective } from 'ng-zorro-antd/grid';
import { NzFormItemComponent } from './nz-form-item.component';
export declare class NzFormControlComponent extends NzColDirective implements OnDestroy, OnInit, AfterContentInit, AfterViewInit, OnDestroy {
    private cdr;
    private _hasFeedback;
    validateChanges: Subscription | null;
    validateString: string | null;
    status: 'warning' | 'validating' | 'error' | 'success' | 'init';
    controlClassMap: NgClassType;
    iconType: string;
    validateControl: FormControl | NgModel | null;
    defaultValidateControl: FormControlName;
    nzHasFeedback: boolean;
    nzValidateStatus: string | FormControl | FormControlName | NgModel;
    removeSubscribe(): void;
    watchControl(): void;
    validateControlStatus(status: string): boolean;
    setControlClassMap(): void;
    constructor(nzUpdateHostClassService: NzUpdateHostClassService, elementRef: ElementRef, nzFormItemComponent: NzFormItemComponent, nzRowDirective: NzRowDirective, cdr: ChangeDetectorRef, renderer: Renderer2);
    ngOnInit(): void;
    ngOnDestroy(): void;
    ngAfterContentInit(): void;
    ngAfterViewInit(): void;
}
