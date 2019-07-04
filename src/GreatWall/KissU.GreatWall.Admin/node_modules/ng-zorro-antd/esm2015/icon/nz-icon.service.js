/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { DOCUMENT } from '@angular/common';
import { HttpBackend } from '@angular/common/http';
import { Inject, Injectable, InjectionToken, Optional, RendererFactory2 } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { IconService } from '@ant-design/icons-angular';
import { BarsOutline, CalendarOutline, CaretDownFill, CaretDownOutline, CaretUpFill, CaretUpOutline, CheckCircleFill, CheckCircleOutline, CheckOutline, ClockCircleOutline, CloseCircleFill, CloseCircleOutline, CloseOutline, DoubleLeftOutline, DoubleRightOutline, DownOutline, EllipsisOutline, ExclamationCircleFill, ExclamationCircleOutline, EyeOutline, FileFill, FileOutline, FilterFill, InfoCircleFill, InfoCircleOutline, LeftOutline, LoadingOutline, PaperClipOutline, QuestionCircleOutline, RightOutline, SearchOutline, StarFill, UploadOutline, UpOutline } from '@ant-design/icons-angular/icons';
import * as i0 from "@angular/core";
import * as i1 from "@angular/platform-browser";
import * as i2 from "@angular/common/http";
import * as i3 from "@angular/common";
/**
 * @record
 */
export function NzIconfontOption() { }
if (false) {
    /** @type {?} */
    NzIconfontOption.prototype.scriptUrl;
}
/** @type {?} */
export const NZ_ICONS = new InjectionToken('nz_icons');
/** @type {?} */
export const NZ_ICON_DEFAULT_TWOTONE_COLOR = new InjectionToken('nz_icon_default_twotone_color');
/** @type {?} */
export const DEFAULT_TWOTONE_COLOR = '#1890ff';
/** @type {?} */
export const NZ_ICONS_USED_BY_ZORRO = [
    BarsOutline,
    CalendarOutline,
    CaretUpFill,
    CaretUpOutline,
    CaretDownFill,
    CaretDownOutline,
    CheckCircleFill,
    CheckCircleOutline,
    CheckOutline,
    ClockCircleOutline,
    CloseCircleOutline,
    CloseCircleFill,
    CloseOutline,
    DoubleLeftOutline,
    DoubleRightOutline,
    DownOutline,
    EllipsisOutline,
    ExclamationCircleFill,
    ExclamationCircleOutline,
    EyeOutline,
    FileFill,
    FileOutline,
    FilterFill,
    InfoCircleFill,
    InfoCircleOutline,
    LeftOutline,
    LoadingOutline,
    PaperClipOutline,
    QuestionCircleOutline,
    RightOutline,
    StarFill,
    SearchOutline,
    StarFill,
    UploadOutline,
    UpOutline
];
/**
 * It should be a global singleton, otherwise registered icons could not be found.
 */
export class NzIconService extends IconService {
    /**
     * @param {?} rendererFactory
     * @param {?} sanitizer
     * @param {?} handler
     * @param {?} document
     * @param {?} icons
     * @param {?} defaultColor
     */
    constructor(rendererFactory, sanitizer, handler, document, icons, defaultColor) {
        super(rendererFactory, handler, document, sanitizer);
        this.rendererFactory = rendererFactory;
        this.sanitizer = sanitizer;
        this.handler = handler;
        this.document = document;
        this.icons = icons;
        this.defaultColor = defaultColor;
        this.iconfontCache = new Set();
        this.warnedAboutAPI = false;
        this.warnedAboutCross = false;
        this.warnedAboutVertical = false;
        this.addIcon(...NZ_ICONS_USED_BY_ZORRO, ...(this.icons || []));
        /** @type {?} */
        let primaryColor = DEFAULT_TWOTONE_COLOR;
        if (this.defaultColor) {
            if (this.defaultColor.startsWith('#')) {
                primaryColor = this.defaultColor;
            }
            else {
                console.warn('[NG-ZORRO]: twotone color must be a hex color!');
            }
        }
        this.twoToneColor = { primaryColor };
    }
    /**
     * @param {?} type
     * @return {?}
     */
    warnAPI(type) {
        if (type === 'old' && !this.warnedAboutAPI) {
            console.warn(`<i class="anticon"></i> would be deprecated soon. Please use <i nz-icon type=""></i> API.`);
            this.warnedAboutAPI = true;
        }
        if (type === 'cross' && !this.warnedAboutCross) {
            console.warn(`'cross' icon is replaced by 'close' icon.`);
            this.warnedAboutCross = true;
        }
        if (type === 'vertical' && !this.warnedAboutVertical) {
            console.warn(`'verticle' is misspelled, would be corrected in the next major version.`);
            this.warnedAboutVertical = true;
        }
    }
    /**
     * @param {?} svg
     * @return {?}
     */
    normalizeSvgElement(svg) {
        if (!svg.getAttribute('viewBox')) {
            this._renderer.setAttribute(svg, 'viewBox', '0 0 1024 1024');
        }
        if (!svg.getAttribute('width') || !svg.getAttribute('height')) {
            this._renderer.setAttribute(svg, 'width', '1em');
            this._renderer.setAttribute(svg, 'height', '1em');
        }
        if (!svg.getAttribute('fill')) {
            this._renderer.setAttribute(svg, 'fill', 'currentColor');
        }
    }
    /**
     * @param {?} opt
     * @return {?}
     */
    fetchFromIconfont(opt) {
        const { scriptUrl } = opt;
        if (this.document && !this.iconfontCache.has(scriptUrl)) {
            /** @type {?} */
            const script = this._renderer.createElement('script');
            this._renderer.setAttribute(script, 'src', scriptUrl);
            this._renderer.setAttribute(script, 'data-namespace', scriptUrl.replace(/^(https?|http):/g, ''));
            this._renderer.appendChild(this.document.body, script);
            this.iconfontCache.add(scriptUrl);
        }
    }
    /**
     * @param {?} type
     * @return {?}
     */
    createIconfontIcon(type) {
        return this._createSVGElementFromString(`<svg><use xlink:href="${type}"></svg>`);
    }
}
NzIconService.decorators = [
    { type: Injectable, args: [{
                providedIn: 'root'
            },] }
];
/** @nocollapse */
NzIconService.ctorParameters = () => [
    { type: RendererFactory2 },
    { type: DomSanitizer },
    { type: HttpBackend, decorators: [{ type: Optional }] },
    { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [DOCUMENT,] }] },
    { type: Array, decorators: [{ type: Optional }, { type: Inject, args: [NZ_ICONS,] }] },
    { type: String, decorators: [{ type: Optional }, { type: Inject, args: [NZ_ICON_DEFAULT_TWOTONE_COLOR,] }] }
];
/** @nocollapse */ NzIconService.ngInjectableDef = i0.defineInjectable({ factory: function NzIconService_Factory() { return new NzIconService(i0.inject(i0.RendererFactory2), i0.inject(i1.DomSanitizer), i0.inject(i2.HttpBackend, 8), i0.inject(i3.DOCUMENT, 8), i0.inject(NZ_ICONS, 8), i0.inject(NZ_ICON_DEFAULT_TWOTONE_COLOR, 8)); }, token: NzIconService, providedIn: "root" });
if (false) {
    /**
     * @type {?}
     * @private
     */
    NzIconService.prototype.iconfontCache;
    /**
     * @type {?}
     * @private
     */
    NzIconService.prototype.warnedAboutAPI;
    /**
     * @type {?}
     * @private
     */
    NzIconService.prototype.warnedAboutCross;
    /**
     * @type {?}
     * @private
     */
    NzIconService.prototype.warnedAboutVertical;
    /**
     * @type {?}
     * @protected
     */
    NzIconService.prototype.rendererFactory;
    /**
     * @type {?}
     * @protected
     */
    NzIconService.prototype.sanitizer;
    /**
     * @type {?}
     * @protected
     */
    NzIconService.prototype.handler;
    /**
     * @type {?}
     * @protected
     */
    NzIconService.prototype.document;
    /**
     * @type {?}
     * @private
     */
    NzIconService.prototype.icons;
    /**
     * @type {?}
     * @private
     */
    NzIconService.prototype.defaultColor;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotaWNvbi5zZXJ2aWNlLmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC9pY29uLyIsInNvdXJjZXMiOlsibnotaWNvbi5zZXJ2aWNlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7O0FBUUEsT0FBTyxFQUFFLFFBQVEsRUFBRSxNQUFNLGlCQUFpQixDQUFDO0FBQzNDLE9BQU8sRUFBRSxXQUFXLEVBQUUsTUFBTSxzQkFBc0IsQ0FBQztBQUNuRCxPQUFPLEVBQUUsTUFBTSxFQUFFLFVBQVUsRUFBRSxjQUFjLEVBQUUsUUFBUSxFQUFFLGdCQUFnQixFQUFFLE1BQU0sZUFBZSxDQUFDO0FBQy9GLE9BQU8sRUFBRSxZQUFZLEVBQUUsTUFBTSwyQkFBMkIsQ0FBQztBQUN6RCxPQUFPLEVBQWtCLFdBQVcsRUFBRSxNQUFNLDJCQUEyQixDQUFDO0FBQ3hFLE9BQU8sRUFDTCxXQUFXLEVBQ1gsZUFBZSxFQUNmLGFBQWEsRUFDYixnQkFBZ0IsRUFDaEIsV0FBVyxFQUNYLGNBQWMsRUFDZCxlQUFlLEVBQ2Ysa0JBQWtCLEVBQ2xCLFlBQVksRUFDWixrQkFBa0IsRUFDbEIsZUFBZSxFQUNmLGtCQUFrQixFQUNsQixZQUFZLEVBQ1osaUJBQWlCLEVBQ2pCLGtCQUFrQixFQUNsQixXQUFXLEVBQ1gsZUFBZSxFQUNmLHFCQUFxQixFQUNyQix3QkFBd0IsRUFDeEIsVUFBVSxFQUNWLFFBQVEsRUFDUixXQUFXLEVBQ1gsVUFBVSxFQUNWLGNBQWMsRUFDZCxpQkFBaUIsRUFDakIsV0FBVyxFQUNYLGNBQWMsRUFDZCxnQkFBZ0IsRUFDaEIscUJBQXFCLEVBQ3JCLFlBQVksRUFDWixhQUFhLEVBQ2IsUUFBUSxFQUNSLGFBQWEsRUFDYixTQUFTLEVBQ1YsTUFBTSxpQ0FBaUMsQ0FBQzs7Ozs7Ozs7QUFFekMsc0NBRUM7OztJQURDLHFDQUFrQjs7O0FBR3BCLE1BQU0sT0FBTyxRQUFRLEdBQUcsSUFBSSxjQUFjLENBQUMsVUFBVSxDQUFDOztBQUN0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QUksQ0FBQyxTQUFTLENBQUMsV0FBVyxDQUFDLElBQUksQ0FBQyxRQUFRLENBQUMsSUFBSSxFQUFFLE1BQU0sQ0FBQyxDQUFDO1lBQ3ZELElBQUksQ0FBQyxhQUFhLENBQUMsR0FBRyxDQUFDLFNBQVMsQ0FBQyxDQUFDO1NBQ25DO0lBQ0gsQ0FBQzs7Ozs7SUFFRCxrQkFBa0IsQ0FBQyxJQUFZO1FBQzdCLE9BQU8sSUFBSSxDQUFDLDJCQUEyQixDQUFDLHlCQUF5QixJQUFJLFVBQVUsQ0FBQyxDQUFDO0lBQ25GLENBQUM7OztZQWxERixVQUFVLFNBQUM7Z0JBQ1YsVUFBVSxFQUFFLE1BQU07YUFDbkI7Ozs7WUExRnNELGdCQUFnQjtZQUM5RCxZQUFZO1lBRlosV0FBVyx1QkFnSmYsUUFBUTs0Q0FFUixRQUFRLFlBQUksTUFBTSxTQUFDLFFBQVE7d0NBQzNCLFFBQVEsWUFBSSxNQUFNLFNBQUMsUUFBUTt5Q0FDM0IsUUFBUSxZQUFJLE1BQU0sU0FBQyw2QkFBNkI7Ozs7Ozs7O0lBdkRuRCxzQ0FBMEM7Ozs7O0lBQzFDLHVDQUErQjs7Ozs7SUFDL0IseUNBQWlDOzs7OztJQUNqQyw0Q0FBb0M7Ozs7O0lBOENsQyx3Q0FBMkM7Ozs7O0lBQzNDLGtDQUFpQzs7Ozs7SUFDakMsZ0NBQTBDOzs7OztJQUUxQyxpQ0FBcUQ7Ozs7O0lBQ3JELDhCQUE2RDs7Ozs7SUFDN0QscUNBQStFIiwic291cmNlc0NvbnRlbnQiOlsiLyoqXG4gKiBAbGljZW5zZVxuICogQ29weXJpZ2h0IEFsaWJhYmEuY29tIEFsbCBSaWdodHMgUmVzZXJ2ZWQuXG4gKlxuICogVXNlIG9mIHRoaXMgc291cmNlIGNvZGUgaXMgZ292ZXJuZWQgYnkgYW4gTUlULXN0eWxlIGxpY2Vuc2UgdGhhdCBjYW4gYmVcbiAqIGZvdW5kIGluIHRoZSBMSUNFTlNFIGZpbGUgYXQgaHR0cHM6Ly9naXRodWIuY29tL05HLVpPUlJPL25nLXpvcnJvLWFudGQvYmxvYi9tYXN0ZXIvTElDRU5TRVxuICovXG5cbmltcG9ydCB7IERPQ1VNRU5UIH0gZnJvbSAnQGFuZ3VsYXIvY29tbW9uJztcbmltcG9ydCB7IEh0dHBCYWNrZW5kIH0gZnJvbSAnQGFuZ3VsYXIvY29tbW9uL2h0dHAnO1xuaW1wb3J0IHsgSW5qZWN0LCBJbmplY3RhYmxlLCBJbmplY3Rpb25Ub2tlbiwgT3B0aW9uYWwsIFJlbmRlcmVyRmFjdG9yeTIgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IERvbVNhbml0aXplciB9IGZyb20gJ0Bhbmd1bGFyL3BsYXRmb3JtLWJyb3dzZXInO1xuaW1wb3J0IHsgSWNvbkRlZmluaXRpb24sIEljb25TZXJ2aWNlIH0gZnJvbSAnQGFudC1kZXNpZ24vaWNvbnMtYW5ndWxhcic7XG5pbXBvcnQge1xuICBCYXJzT3V0bGluZSxcbiAgQ2FsZW5kYXJPdXRsaW5lLFxuICBDYXJldERvd25GaWxsLFxuICBDYXJldERvd25PdXRsaW5lLFxuICBDYXJldFVwRmlsbCxcbiAgQ2FyZXRVcE91dGxpbmUsXG4gIENoZWNrQ2lyY2xlRmlsbCxcbiAgQ2hlY2tDaXJjbGVPdXRsaW5lLFxuICBDaGVja091dGxpbmUsXG4gIENsb2NrQ2lyY2xlT3V0bGluZSxcbiAgQ2xvc2VDaXJjbGVGaWxsLFxuICBDbG9zZUNpcmNsZU91dGxpbmUsXG4gIENsb3NlT3V0bGluZSxcbiAgRG91YmxlTGVmdE91dGxpbmUsXG4gIERvdWJsZVJpZ2h0T3V0bGluZSxcbiAgRG93bk91dGxpbmUsXG4gIEVsbGlwc2lzT3V0bGluZSxcbiAgRXhjbGFtYXRpb25DaXJjbGVGaWxsLFxuICBFeGNsYW1hdGlvbkNpcmNsZU91dGxpbmUsXG4gIEV5ZU91dGxpbmUsXG4gIEZpbGVGaWxsLFxuICBGaWxlT3V0bGluZSxcbiAgRmlsdGVyRmlsbCxcbiAgSW5mb0NpcmNsZUZpbGwsXG4gIEluZm9DaXJjbGVPdXRsaW5lLFxuICBMZWZ0T3V0bGluZSxcbiAgTG9hZGluZ091dGxpbmUsXG4gIFBhcGVyQ2xpcE91dGxpbmUsXG4gIFF1ZXN0aW9uQ2lyY2xlT3V0bGluZSxcbiAgUmlnaHRPdXRsaW5lLFxuICBTZWFyY2hPdXRsaW5lLFxuICBTdGFyRmlsbCxcbiAgVXBsb2FkT3V0bGluZSxcbiAgVXBPdXRsaW5lXG59IGZyb20gJ0BhbnQtZGVzaWduL2ljb25zLWFuZ3VsYXIvaWNvbnMnO1xuXG5leHBvcnQgaW50ZXJmYWNlIE56SWNvbmZvbnRPcHRpb24ge1xuICBzY3JpcHRVcmw6IHN0cmluZztcbn1cblxuZXhwb3J0IGNvbnN0IE5aX0lDT05TID0gbmV3IEluamVjdGlvblRva2VuKCduel9pY29ucycpO1xuZXhwb3J0IGNvbnN0IE5aX0lDT05fREVGQVVMVF9UV09UT05FX0NPTE9SID0gbmV3IEluamVjdGlvblRva2VuKCduel9pY29uX2RlZmF1bHRfdHdvdG9uZV9jb2xvcicpO1xuZXhwb3J0IGNvbnN0IERFRkFVTFRfVFdPVE9ORV9DT0xPUiA9ICcjMTg5MGZmJztcbmV4cG9ydCBjb25zdCBOWl9JQ09OU19VU0VEX0JZX1pPUlJPOiBJY29uRGVmaW5pdGlvbltdID0gW1xuICBCYXJzT3V0bGluZSxcbiAgQ2FsZW5kYXJPdXRsaW5lLFxuICBDYXJldFVwRmlsbCxcbiAgQ2FyZXRVcE91dGxpbmUsXG4gIENhcmV0RG93bkZpbGwsXG4gIENhcmV0RG93bk91dGxpbmUsXG4gIENoZWNrQ2lyY2xlRmlsbCxcbiAgQ2hlY2tDaXJjbGVPdXRsaW5lLFxuICBDaGVja091dGxpbmUsXG4gIENsb2NrQ2lyY2xlT3V0bGluZSxcbiAgQ2xvc2VDaXJjbGVPdXRsaW5lLFxuICBDbG9zZUNpcmNsZUZpbGwsXG4gIENsb3NlT3V0bGluZSxcbiAgRG91YmxlTGVmdE91dGxpbmUsXG4gIERvdWJsZVJpZ2h0T3V0bGluZSxcbiAgRG93bk91dGxpbmUsXG4gIEVsbGlwc2lzT3V0bGluZSxcbiAgRXhjbGFtYXRpb25DaXJjbGVGaWxsLFxuICBFeGNsYW1hdGlvbkNpcmNsZU91dGxpbmUsXG4gIEV5ZU91dGxpbmUsXG4gIEZpbGVGaWxsLFxuICBGaWxlT3V0bGluZSxcbiAgRmlsdGVyRmlsbCxcbiAgSW5mb0NpcmNsZUZpbGwsXG4gIEluZm9DaXJjbGVPdXRsaW5lLFxuICBMZWZ0T3V0bGluZSxcbiAgTG9hZGluZ091dGxpbmUsXG4gIFBhcGVyQ2xpcE91dGxpbmUsXG4gIFF1ZXN0aW9uQ2lyY2xlT3V0bGluZSxcbiAgUmlnaHRPdXRsaW5lLFxuICBTdGFyRmlsbCxcbiAgU2VhcmNoT3V0bGluZSxcbiAgU3RhckZpbGwsXG4gIFVwbG9hZE91dGxpbmUsXG4gIFVwT3V0bGluZVxuXTtcblxuLyoqXG4gKiBJdCBzaG91bGQgYmUgYSBnbG9iYWwgc2luZ2xldG9uLCBvdGhlcndpc2UgcmVnaXN0ZXJlZCBpY29ucyBjb3VsZCBub3QgYmUgZm91bmQuXG4gKi9cbkBJbmplY3RhYmxlKHtcbiAgcHJvdmlkZWRJbjogJ3Jvb3QnXG59KVxuZXhwb3J0IGNsYXNzIE56SWNvblNlcnZpY2UgZXh0ZW5kcyBJY29uU2VydmljZSB7XG4gIHByaXZhdGUgaWNvbmZvbnRDYWNoZSA9IG5ldyBTZXQ8c3RyaW5nPigpO1xuICBwcml2YXRlIHdhcm5lZEFib3V0QVBJID0gZmFsc2U7XG4gIHByaXZhdGUgd2FybmVkQWJvdXRDcm9zcyA9IGZhbHNlO1xuICBwcml2YXRlIHdhcm5lZEFib3V0VmVydGljYWwgPSBmYWxzZTtcblxuICB3YXJuQVBJKHR5cGU6ICdvbGQnIHwgJ2Nyb3NzJyB8ICd2ZXJ0aWNhbCcpOiB2b2lkIHtcbiAgICBpZiAodHlwZSA9PT0gJ29sZCcgJiYgIXRoaXMud2FybmVkQWJvdXRBUEkpIHtcbiAgICAgIGNvbnNvbGUud2FybihgPGkgY2xhc3M9XCJhbnRpY29uXCI+PC9pPiB3b3VsZCBiZSBkZXByZWNhdGVkIHNvb24uIFBsZWFzZSB1c2UgPGkgbnotaWNvbiB0eXBlPVwiXCI+PC9pPiBBUEkuYCk7XG4gICAgICB0aGlzLndhcm5lZEFib3V0QVBJID0gdHJ1ZTtcbiAgICB9XG4gICAgaWYgKHR5cGUgPT09ICdjcm9zcycgJiYgIXRoaXMud2FybmVkQWJvdXRDcm9zcykge1xuICAgICAgY29uc29sZS53YXJuKGAnY3Jvc3MnIGljb24gaXMgcmVwbGFjZWQgYnkgJ2Nsb3NlJyBpY29uLmApO1xuICAgICAgdGhpcy53YXJuZWRBYm91dENyb3NzID0gdHJ1ZTtcbiAgICB9XG4gICAgaWYgKHR5cGUgPT09ICd2ZXJ0aWNhbCcgJiYgIXRoaXMud2FybmVkQWJvdXRWZXJ0aWNhbCkge1xuICAgICAgY29uc29sZS53YXJuKGAndmVydGljbGUnIGlzIG1pc3NwZWxsZWQsIHdvdWxkIGJlIGNvcnJlY3RlZCBpbiB0aGUgbmV4dCBtYWpvciB2ZXJzaW9uLmApO1xuICAgICAgdGhpcy53YXJuZWRBYm91dFZlcnRpY2FsID0gdHJ1ZTtcbiAgICB9XG4gIH1cblxuICBub3JtYWxpemVTdmdFbGVtZW50KHN2ZzogU1ZHRWxlbWVudCk6IHZvaWQge1xuICAgIGlmICghc3ZnLmdldEF0dHJpYnV0ZSgndmlld0JveCcpKSB7XG4gICAgICB0aGlzLl9yZW5kZXJlci5zZXRBdHRyaWJ1dGUoc3ZnLCAndmlld0JveCcsICcwIDAgMTAyNCAxMDI0Jyk7XG4gICAgfVxuICAgIGlmICghc3ZnLmdldEF0dHJpYnV0ZSgnd2lkdGgnKSB8fCAhc3ZnLmdldEF0dHJpYnV0ZSgnaGVpZ2h0JykpIHtcbiAgICAgIHRoaXMuX3JlbmRlcmVyLnNldEF0dHJpYnV0ZShzdmcsICd3aWR0aCcsICcxZW0nKTtcbiAgICAgIHRoaXMuX3JlbmRlcmVyLnNldEF0dHJpYnV0ZShzdmcsICdoZWlnaHQnLCAnMWVtJyk7XG4gICAgfVxuICAgIGlmICghc3ZnLmdldEF0dHJpYnV0ZSgnZmlsbCcpKSB7XG4gICAgICB0aGlzLl9yZW5kZXJlci5zZXRBdHRyaWJ1dGUoc3ZnLCAnZmlsbCcsICdjdXJyZW50Q29sb3InKTtcbiAgICB9XG4gIH1cblxuICBmZXRjaEZyb21JY29uZm9udChvcHQ6IE56SWNvbmZvbnRPcHRpb24pOiB2b2lkIHtcbiAgICBjb25zdCB7IHNjcmlwdFVybCB9ID0gb3B0O1xuICAgIGlmICh0aGlzLmRvY3VtZW50ICYmICF0aGlzLmljb25mb250Q2FjaGUuaGFzKHNjcmlwdFVybCkpIHtcbiAgICAgIGNvbnN0IHNjcmlwdCA9IHRoaXMuX3JlbmRlcmVyLmNyZWF0ZUVsZW1lbnQoJ3NjcmlwdCcpO1xuICAgICAgdGhpcy5fcmVuZGVyZXIuc2V0QXR0cmlidXRlKHNjcmlwdCwgJ3NyYycsIHNjcmlwdFVybCk7XG4gICAgICB0aGlzLl9yZW5kZXJlci5zZXRBdHRyaWJ1dGUoc2NyaXB0LCAnZGF0YS1uYW1lc3BhY2UnLCBzY3JpcHRVcmwucmVwbGFjZSgvXihodHRwcz98aHR0cCk6L2csICcnKSk7XG4gICAgICB0aGlzLl9yZW5kZXJlci5hcHBlbmRDaGlsZCh0aGlzLmRvY3VtZW50LmJvZHksIHNjcmlwdCk7XG4gICAgICB0aGlzLmljb25mb250Q2FjaGUuYWRkKHNjcmlwdFVybCk7XG4gICAgfVxuICB9XG5cbiAgY3JlYXRlSWNvbmZvbnRJY29uKHR5cGU6IHN0cmluZyk6IFNWR0VsZW1lbnQge1xuICAgIHJldHVybiB0aGlzLl9jcmVhdGVTVkdFbGVtZW50RnJvbVN0cmluZyhgPHN2Zz48dXNlIHhsaW5rOmhyZWY9XCIke3R5cGV9XCI+PC9zdmc+YCk7XG4gIH1cblxuICBjb25zdHJ1Y3RvcihcbiAgICBwcm90ZWN0ZWQgcmVuZGVyZXJGYWN0b3J5OiBSZW5kZXJlckZhY3RvcnkyLFxuICAgIHByb3RlY3RlZCBzYW5pdGl6ZXI6IERvbVNhbml0aXplcixcbiAgICBAT3B0aW9uYWwoKSBwcm90ZWN0ZWQgaGFuZGxlcjogSHR0cEJhY2tlbmQsXG4gICAgLy8gdHNsaW50OmRpc2FibGUtbmV4dC1saW5lOm5vLWFueVxuICAgIEBPcHRpb25hbCgpIEBJbmplY3QoRE9DVU1FTlQpIHByb3RlY3RlZCBkb2N1bWVudDogYW55LFxuICAgIEBPcHRpb25hbCgpIEBJbmplY3QoTlpfSUNPTlMpIHByaXZhdGUgaWNvbnM6IEljb25EZWZpbml0aW9uW10sXG4gICAgQE9wdGlvbmFsKCkgQEluamVjdChOWl9JQ09OX0RFRkFVTFRfVFdPVE9ORV9DT0xPUikgcHJpdmF0ZSBkZWZhdWx0Q29sb3I6IHN0cmluZ1xuICApIHtcbiAgICBzdXBlcihyZW5kZXJlckZhY3RvcnksIGhhbmRsZXIsIGRvY3VtZW50LCBzYW5pdGl6ZXIpO1xuXG4gICAgdGhpcy5hZGRJY29uKC4uLk5aX0lDT05TX1VTRURfQllfWk9SUk8sIC4uLih0aGlzLmljb25zIHx8IFtdKSk7XG5cbiAgICBsZXQgcHJpbWFyeUNvbG9yID0gREVGQVVMVF9UV09UT05FX0NPTE9SO1xuICAgIGlmICh0aGlzLmRlZmF1bHRDb2xvcikge1xuICAgICAgaWYgKHRoaXMuZGVmYXVsdENvbG9yLnN0YXJ0c1dpdGgoJyMnKSkge1xuICAgICAgICBwcmltYXJ5Q29sb3IgPSB0aGlzLmRlZmF1bHRDb2xvcjtcbiAgICAgIH0gZWxzZSB7XG4gICAgICAgIGNvbnNvbGUud2FybignW05HLVpPUlJPXTogdHdvdG9uZSBjb2xvciBtdXN0IGJlIGEgaGV4IGNvbG9yIScpO1xuICAgICAgfVxuICAgIH1cbiAgICB0aGlzLnR3b1RvbmVDb2xvciA9IHsgcHJpbWFyeUNvbG9yIH07XG4gIH1cbn1cbiJdfQ==