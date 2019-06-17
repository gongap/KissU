import { ChangeDetectorRef, EventEmitter, OnDestroy, OnInit } from '@angular/core';
import { DelonLocaleService, LocaleData } from '@delon/theme';
export declare class TagSelectComponent implements OnInit, OnDestroy {
    private i18n;
    private cdr;
    private i18n$;
    locale: LocaleData;
    expand: boolean;
    /** 是否启用 `展开与收进` */
    expandable: boolean;
    readonly change: EventEmitter<boolean>;
    constructor(i18n: DelonLocaleService, cdr: ChangeDetectorRef);
    ngOnInit(): void;
    trigger(): void;
    ngOnDestroy(): void;
}
