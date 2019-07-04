import { ChangeDetectorRef, EventEmitter, OnChanges, OnDestroy, OnInit } from '@angular/core';
import { DelonLocaleService, LocaleData } from '@delon/theme';
import { NoticeIconSelect, NoticeItem } from './notice-icon.types';
export declare class NoticeIconComponent implements OnInit, OnChanges, OnDestroy {
    private i18n;
    private cdr;
    private i18n$;
    locale: LocaleData;
    data: NoticeItem[];
    count: number;
    loading: boolean;
    popoverVisible: boolean;
    btnClass: string;
    btnIconClass: string;
    readonly select: EventEmitter<NoticeIconSelect>;
    readonly clear: EventEmitter<string>;
    readonly popoverVisibleChange: EventEmitter<boolean>;
    constructor(i18n: DelonLocaleService, cdr: ChangeDetectorRef);
    onVisibleChange(result: boolean): void;
    onSelect(i: NoticeIconSelect): void;
    onClear(title: string): void;
    ngOnInit(): void;
    ngOnChanges(): void;
    ngOnDestroy(): void;
}
