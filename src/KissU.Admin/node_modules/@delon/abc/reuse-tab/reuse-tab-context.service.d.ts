import { Overlay } from '@angular/cdk/overlay';
import { Subject } from 'rxjs';
import { ReuseContextCloseEvent, ReuseContextEvent, ReuseContextI18n } from './reuse-tab.interfaces';
export declare class ReuseTabContextService {
    private overlay;
    private ref;
    i18n: ReuseContextI18n;
    show: Subject<ReuseContextEvent>;
    close: Subject<ReuseContextCloseEvent>;
    constructor(overlay: Overlay);
    remove(): void;
    open(context: ReuseContextEvent): void;
}
