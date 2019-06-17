import { ElementRef, OnDestroy, OnInit, Renderer2, TemplateRef } from '@angular/core';
export declare class FooterToolbarComponent implements OnInit, OnDestroy {
    private el;
    private renderer;
    private doc;
    errorCollect: boolean;
    extra: string | TemplateRef<void>;
    constructor(el: ElementRef, renderer: Renderer2, doc: any);
    private readonly bodyCls;
    ngOnInit(): void;
    ngOnDestroy(): void;
}
