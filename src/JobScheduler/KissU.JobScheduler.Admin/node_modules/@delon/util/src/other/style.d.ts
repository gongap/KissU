import { Renderer2 } from '@angular/core';
/**
 * 更新宿主组件样式 `class`，例如：
 *
 * ```ts
 * updateHostClass(
 *  this.el.nativeElement,
 *  this.renderer,
 *  {
 *    [ 'classname' ]: true,
 *    [ 'classname' ]: this.type === '1',
 *    [ this.cls ]: true,
 *    [ `a-${this.cls}` ]: true
 *  })
 * ```
 *
 * @param [cleanAll] 是否先清理所有 `class` 值，默认：`false`
 */
export declare function updateHostClass(el: HTMLElement, renderer: Renderer2, classMap: object, cleanAll?: boolean): void;
