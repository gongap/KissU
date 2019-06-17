import { ReuseTabContextService } from './reuse-tab-context.service';
import { ReuseCustomContextMenu, ReuseItem } from './reuse-tab.interfaces';
export declare class ReuseTabContextDirective {
    private srv;
    item: ReuseItem;
    customContextMenu: ReuseCustomContextMenu[];
    constructor(srv: ReuseTabContextService);
    _onContextMenu(event: MouseEvent): void;
}
