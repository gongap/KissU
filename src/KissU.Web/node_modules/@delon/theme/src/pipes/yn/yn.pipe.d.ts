import { PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
export declare class YNPipe implements PipeTransform {
    private dom;
    constructor(dom: DomSanitizer);
    transform(value: boolean, yes: string, no: string): SafeHtml;
}
