import { OnInit, TemplateRef } from '@angular/core';
export declare class STRowSource {
    private titles;
    private rows;
    add(type: string, path: string, ref: TemplateRef<void>): void;
    getTitle(path: string): TemplateRef<void>;
    getRow(path: string): TemplateRef<void>;
}
export declare class STRowDirective implements OnInit {
    private ref;
    private source;
    id: string;
    type: 'title';
    constructor(ref: TemplateRef<void>, source: STRowSource);
    ngOnInit(): void;
}
