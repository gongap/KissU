import { AfterViewInit, OnChanges, SimpleChanges, ViewContainerRef } from '@angular/core';
import { PluginContext } from './PluginService';
export declare class PluginComponent implements AfterViewInit, OnChanges {
    context: PluginContext;
    vcRef: any;
    private config;
    constructor(context: PluginContext, vcRef: ViewContainerRef);
    ngAfterViewInit(): void;
    ngOnChanges(changes: SimpleChanges): void;
    private combineContentConfig;
    private getProps;
    private initPlugin;
    private renderPlugin;
}
