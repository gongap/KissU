import { PipeTransform } from '@angular/core';
import { AlainI18NService } from './i18n';
export declare class I18nPipe implements PipeTransform {
    private i18n;
    constructor(i18n: AlainI18NService);
    transform(key: string, interpolateParams?: {}, isSafe?: boolean): string;
}
