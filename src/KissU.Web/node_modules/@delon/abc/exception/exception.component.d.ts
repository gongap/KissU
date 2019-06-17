import { OnDestroy, OnInit } from '@angular/core';
import { DelonLocaleService, LocaleData } from '@delon/theme';
export declare type ExceptionType = 403 | 404 | 500;
export declare class ExceptionComponent implements OnInit, OnDestroy {
    private i18n;
    private i18n$;
    private conTpl;
    _type: ExceptionType;
    locale: LocaleData;
    hasCon: boolean;
    _img: string;
    _title: string;
    _desc: string;
    type: ExceptionType;
    img: string;
    title: string;
    desc: string;
    checkContent(): void;
    constructor(i18n: DelonLocaleService);
    ngOnInit(): void;
    ngOnDestroy(): void;
}
