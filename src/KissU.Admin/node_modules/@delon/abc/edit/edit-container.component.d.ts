import { TemplateRef } from '@angular/core';
import { REP_TYPE } from '@delon/theme';
import { SEConfig } from './edit.config';
export declare class SEContainerComponent {
    colInCon: REP_TYPE;
    col: REP_TYPE;
    labelWidth: number;
    title: string | TemplateRef<void>;
    gutter: number;
    private _gutter;
    nzLayout: string;
    private _nzLayout;
    size: 'default' | 'compact';
    firstVisual: boolean;
    line: boolean;
    constructor(cog: SEConfig);
}
