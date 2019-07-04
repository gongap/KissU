import { AfterViewInit, ChangeDetectorRef, OnChanges } from '@angular/core';
import { AvatarListItemComponent } from './avatar-list-item.component';
export declare class AvatarListComponent implements AfterViewInit, OnChanges {
    private cdr;
    private inited;
    private _items;
    items: AvatarListItemComponent[];
    exceedCount: number;
    cls: string;
    avatarSize: string;
    size: 'large' | 'small' | 'mini' | 'default';
    maxLength: number;
    excessItemsStyle: {};
    constructor(cdr: ChangeDetectorRef);
    private gen;
    ngAfterViewInit(): void;
    ngOnChanges(): void;
}
