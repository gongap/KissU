import { AfterViewInit, ElementRef, OnChanges, Renderer2 } from '@angular/core';
import { ResponsiveService } from '@delon/theme';
import { SGContainerComponent } from './grid-container.component';
export declare class SGComponent implements OnChanges, AfterViewInit {
    private ren;
    private parent;
    private rep;
    private el;
    private clsMap;
    private inited;
    col: number;
    readonly paddingValue: number;
    constructor(el: ElementRef, ren: Renderer2, parent: SGContainerComponent, rep: ResponsiveService);
    private setClass;
    ngOnChanges(): void;
    ngAfterViewInit(): void;
}
