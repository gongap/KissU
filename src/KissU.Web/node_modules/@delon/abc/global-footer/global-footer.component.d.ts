import { QueryList } from '@angular/core';
import { Router } from '@angular/router';
import { GlobalFooterItemComponent } from './global-footer-item.component';
import { GlobalFooterLink } from './global-footer.types';
export declare class GlobalFooterComponent {
    private router;
    private win;
    links: GlobalFooterLink[];
    items: QueryList<GlobalFooterItemComponent>;
    constructor(router: Router, win: Window);
    to(item: GlobalFooterLink): void;
}
