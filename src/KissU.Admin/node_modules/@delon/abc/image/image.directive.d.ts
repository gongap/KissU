import { ElementRef, OnChanges, OnInit, Renderer2, SimpleChange, SimpleChanges } from '@angular/core';
import { ImageConfig } from './image.config';
/**
 * img标签
 * + 支持微信、qq头像规则缩略图规则
 * + 支持移除http&https协议http
 * + 支持增加onerror事件
 */
export declare class ImageDirective implements OnChanges, OnInit {
    private el;
    private render;
    src: string;
    size: number;
    error: string;
    private inited;
    constructor(cog: ImageConfig, el: ElementRef, render: Renderer2);
    ngOnInit(): void;
    ngOnChanges(changes: {
        [P in keyof this]?: SimpleChange;
    } & SimpleChanges): void;
    private update;
    private updateError;
}
