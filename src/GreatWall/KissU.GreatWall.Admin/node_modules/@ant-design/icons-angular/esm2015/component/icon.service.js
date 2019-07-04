/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { DOCUMENT } from '@angular/common';
import { HttpBackend, HttpClient } from '@angular/common/http';
import { Inject, Optional, RendererFactory2, SecurityContext } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { of as observableOf } from 'rxjs';
import { catchError, finalize, map, share, tap } from 'rxjs/operators';
import { cloneSVG, getIconDefinitionFromAbbr, getNameAndNamespace, getSecondaryColor, hasNamespace, isIconDefinition, replaceFillColor, withSuffix, withSuffixAndColor } from '../utils';
import { HttpModuleNotImport, IconNotFoundError, NameSpaceIsNotSpecifyError, SVGTagNotFoundError, UrlNotSafeError } from './icon.error';
export class IconService {
    /**
     * @param {?} _rendererFactory
     * @param {?} _handler
     * @param {?} _document
     * @param {?} sanitizer
     */
    constructor(_rendererFactory, _handler, _document, sanitizer) {
        this._rendererFactory = _rendererFactory;
        this._handler = _handler;
        this._document = _document;
        this.sanitizer = sanitizer;
        this.defaultTheme = 'outline';
        /**
         * All icon definitions would be registered here.
         */
        this._svgDefinitions = new Map();
        /**
         * Cache all rendered icons. Icons are identified by name, theme,
         * and for twotone icons, primary color and secondary color.
         */
        this._svgRenderedDefinitions = new Map();
        this._inProgressFetches = new Map();
        /**
         * Url prefix for fetching inline SVG by dynamic importing.
         */
        this._assetsUrlRoot = '';
        this._twoToneColorPalette = {
            primaryColor: '#333333',
            secondaryColor: '#E6E6E6'
        };
        this._renderer = this._rendererFactory.createRenderer(null, null);
        if (this._handler) {
            this._http = new HttpClient(this._handler);
        }
    }
    /**
     * @param {?} __0
     * @return {?}
     */
    set twoToneColor({ primaryColor, secondaryColor }) {
        this._twoToneColorPalette.primaryColor = primaryColor;
        this._twoToneColorPalette.secondaryColor = secondaryColor || getSecondaryColor(primaryColor);
    }
    /**
     * @return {?}
     */
    get twoToneColor() {
        return (/** @type {?} */ (Object.assign({}, this._twoToneColorPalette))); // Make a copy to avoid unexpected changes.
    }
    /**
     * Change the prefix of the inline svg resources, so they could be deployed elsewhere, like CDN.
     * @param {?} prefix
     * @return {?}
     */
    changeAssetsSource(prefix) {
        this._assetsUrlRoot = prefix.endsWith('/') ? prefix : prefix + '/';
    }
    /**
     * Add icons provided by ant design.
     * @param {...?} icons
     * @return {?}
     */
    addIcon(...icons) {
        icons.forEach((/**
         * @param {?} icon
         * @return {?}
         */
        icon => {
            this._svgDefinitions.set(withSuffix(icon.name, icon.theme), icon);
        }));
    }
    /**
     * Register an icon. Namespace is required.
     * @param {?} type
     * @param {?} literal
     * @return {?}
     */
    addIconLiteral(type, literal) {
        const [name, namespace] = getNameAndNamespace(type);
        if (!namespace) {
            throw NameSpaceIsNotSpecifyError();
        }
        this.addIcon({ name: type, icon: literal });
    }
    /**
     * Remove all cache.
     * @return {?}
     */
    clear() {
        this._svgDefinitions.clear();
        this._svgRenderedDefinitions.clear();
    }
    /**
     * Get a rendered `SVGElement`.
     * @param {?} icon
     * @param {?=} twoToneColor
     * @return {?}
     */
    getRenderedContent(icon, twoToneColor) {
        // If `icon` is a `IconDefinition`, go to the next step. If not, try to fetch it from cache.
        /** @type {?} */
        const definition = isIconDefinition(icon) ? (/** @type {?} */ (icon)) : this._svgDefinitions.get((/** @type {?} */ (icon)));
        // If `icon` is a `IconDefinition` of successfully fetch, wrap it in an `Observable`. Otherwise try to fetch it from remote.
        /** @type {?} */
        const $iconDefinition = definition ? observableOf(definition) : this._getFromRemote((/** @type {?} */ (icon)));
        // If finally get an `IconDefinition`, render and return it. Otherwise throw an error.
        return $iconDefinition.pipe(map((/**
         * @param {?} i
         * @return {?}
         */
        i => {
            if (!i) {
                throw IconNotFoundError((/** @type {?} */ (icon)));
            }
            return this._loadSVGFromCacheOrCreateNew(i, twoToneColor);
        })));
    }
    /**
     * @return {?}
     */
    getCachedIcons() {
        return this._svgDefinitions;
    }
    /**
     * Get raw svg and assemble a `IconDefinition` object.
     * @protected
     * @param {?} type
     * @return {?}
     */
    _getFromRemote(type) {
        if (!this._http) {
            return observableOf(HttpModuleNotImport());
        }
        // If multi directive ask for the same icon at the same time, http request should only be fired once.
        /** @type {?} */
        let inProgress = this._inProgressFetches.get(type);
        // If there's no other directive asking for the same icon, fire a request.
        if (!inProgress) {
            const [name, namespace] = getNameAndNamespace(type);
            // If the string has a namespace within, create a simple `IconDefinition`.
            /** @type {?} */
            const icon = namespace
                ? { name: type, icon: '' }
                : getIconDefinitionFromAbbr(name);
            /** @type {?} */
            const url = namespace
                ? `${this._assetsUrlRoot}assets/${namespace}/${name}.svg`
                : `${this._assetsUrlRoot}assets/${icon.theme}/${icon.name}.svg`;
            /** @type {?} */
            const safeUrl = this.sanitizer.sanitize(SecurityContext.URL, url);
            if (!safeUrl) {
                throw UrlNotSafeError(url);
            }
            // Wrap a `IconDefinition`, cache it, delete the shared work.
            inProgress = this._http.get(safeUrl, { responseType: 'text' }).pipe(map((/**
             * @param {?} literal
             * @return {?}
             */
            literal => (Object.assign({}, icon, { icon: literal })))), tap((/**
             * @param {?} definition
             * @return {?}
             */
            definition => this.addIcon(definition))), finalize((/**
             * @return {?}
             */
            () => this._inProgressFetches.delete(type))), catchError((/**
             * @return {?}
             */
            () => observableOf(null))), share());
            this._inProgressFetches.set(type, inProgress);
        }
        // Otherwise just reuse other directive's request.
        return inProgress;
    }
    /**
     * Render a new `SVGElement` for given `IconDefinition`, or make a copy from cache.
     * @protected
     * @param {?} icon
     * @param {?=} twoToneColor
     * @return {?}
     */
    _loadSVGFromCacheOrCreateNew(icon, twoToneColor) {
        /** @type {?} */
        let svg;
        /** @type {?} */
        const pri = twoToneColor || this._twoToneColorPalette.primaryColor;
        /** @type {?} */
        const sec = getSecondaryColor(pri) || this._twoToneColorPalette.secondaryColor;
        /** @type {?} */
        const key = icon.theme === 'twotone'
            ? withSuffixAndColor(icon.name, icon.theme, pri, sec)
            : icon.theme === undefined ? icon.name : withSuffix(icon.name, icon.theme);
        // Try to make a copy from cache.
        /** @type {?} */
        const cached = this._svgRenderedDefinitions.get(key);
        if (cached) {
            svg = cached.icon;
        }
        else {
            svg = this._setSVGAttribute(this._colorizeSVGIcon(
            // Icons provided by ant design should be refined to remove preset colors.
            this._createSVGElementFromString(hasNamespace(icon.name) ? icon.icon : replaceFillColor(icon.icon)), icon.theme === 'twotone', pri, sec));
            // Cache it.
            this._svgRenderedDefinitions.set(key, (/** @type {?} */ (Object.assign({}, icon, { icon: svg }))));
        }
        return cloneSVG(svg);
    }
    /**
     * @protected
     * @param {?} str
     * @return {?}
     */
    _createSVGElementFromString(str) {
        /** @type {?} */
        const div = this._document.createElement('div');
        div.innerHTML = str;
        /** @type {?} */
        const svg = div.querySelector('svg');
        if (!svg) {
            throw SVGTagNotFoundError;
        }
        return svg;
    }
    /**
     * @protected
     * @param {?} svg
     * @return {?}
     */
    _setSVGAttribute(svg) {
        this._renderer.setAttribute(svg, 'width', '1em');
        this._renderer.setAttribute(svg, 'height', '1em');
        return svg;
    }
    /**
     * @protected
     * @param {?} svg
     * @param {?} twotone
     * @param {?} pri
     * @param {?} sec
     * @return {?}
     */
    _colorizeSVGIcon(svg, twotone, pri, sec) {
        if (twotone) {
            /** @type {?} */
            const children = svg.childNodes;
            /** @type {?} */
            const length = children.length;
            for (let i = 0; i < length; i++) {
                /** @type {?} */
                const child = (/** @type {?} */ (children[i]));
                if (child.getAttribute('fill') === 'secondaryColor') {
                    this._renderer.setAttribute(child, 'fill', sec);
                }
                else {
                    this._renderer.setAttribute(child, 'fill', pri);
                }
            }
        }
        this._renderer.setAttribute(svg, 'fill', 'currentColor');
        return svg;
    }
}
/** @nocollapse */
IconService.ctorParameters = () => [
    { type: RendererFactory2 },
    { type: HttpBackend, decorators: [{ type: Optional }] },
    { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [DOCUMENT,] }] },
    { type: DomSanitizer }
];
if (false) {
    /** @type {?} */
    IconService.prototype.defaultTheme;
    /**
     * @type {?}
     * @protected
     */
    IconService.prototype._renderer;
    /**
     * @type {?}
     * @protected
     */
    IconService.prototype._http;
    /**
     * All icon definitions would be registered here.
     * @type {?}
     * @protected
     */
    IconService.prototype._svgDefinitions;
    /**
     * Cache all rendered icons. Icons are identified by name, theme,
     * and for twotone icons, primary color and secondary color.
     * @type {?}
     * @protected
     */
    IconService.prototype._svgRenderedDefinitions;
    /**
     * @type {?}
     * @protected
     */
    IconService.prototype._inProgressFetches;
    /**
     * Url prefix for fetching inline SVG by dynamic importing.
     * @type {?}
     * @protected
     */
    IconService.prototype._assetsUrlRoot;
    /**
     * @type {?}
     * @protected
     */
    IconService.prototype._twoToneColorPalette;
    /**
     * @type {?}
     * @protected
     */
    IconService.prototype._rendererFactory;
    /**
     * @type {?}
     * @protected
     */
    IconService.prototype._handler;
    /**
     * @type {?}
     * @protected
     */
    IconService.prototype._document;
    /**
     * @type {?}
     * @protected
     */
    IconService.prototype.sanitizer;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiaWNvbi5zZXJ2aWNlLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGFudC1kZXNpZ24vaWNvbnMtYW5ndWxhci8iLCJzb3VyY2VzIjpbImNvbXBvbmVudC9pY29uLnNlcnZpY2UudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7OztBQUFBLE9BQU8sRUFBRSxRQUFRLEVBQUUsTUFBTSxpQkFBaUIsQ0FBQztBQUMzQyxPQUFPLEVBQUUsV0FBVyxFQUFFLFVBQVUsRUFBRSxNQUFNLHNCQUFzQixDQUFDO0FBQy9ELE9BQU8sRUFBRSxNQUFNLEVBQUUsUUFBUSxFQUFhLGdCQUFnQixFQUFFLGVBQWUsRUFBRSxNQUFNLGVBQWUsQ0FBQztBQUMvRixPQUFPLEVBQUUsWUFBWSxFQUFFLE1BQU0sMkJBQTJCLENBQUM7QUFDekQsT0FBTyxFQUFFLEVBQUUsSUFBSSxZQUFZLEVBQWMsTUFBTSxNQUFNLENBQUM7QUFDdEQsT0FBTyxFQUFFLFVBQVUsRUFBRSxRQUFRLEVBQUUsR0FBRyxFQUFFLEtBQUssRUFBRSxHQUFHLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUV2RSxPQUFPLEVBQ0wsUUFBUSxFQUNSLHlCQUF5QixFQUN6QixtQkFBbUIsRUFDbkIsaUJBQWlCLEVBQ2pCLFlBQVksRUFDWixnQkFBZ0IsRUFDaEIsZ0JBQWdCLEVBQ2hCLFVBQVUsRUFDVixrQkFBa0IsRUFDbkIsTUFBTSxVQUFVLENBQUM7QUFDbEIsT0FBTyxFQUFFLG1CQUFtQixFQUFFLGlCQUFpQixFQUFFLDBCQUEwQixFQUFFLG1CQUFtQixFQUFFLGVBQWUsRUFBRSxNQUFNLGNBQWMsQ0FBQztBQUV4SSxNQUFNLE9BQU8sV0FBVzs7Ozs7OztJQXNDdEIsWUFDWSxnQkFBa0MsRUFDdEIsUUFBcUIsRUFFSCxTQUFjLEVBQzVDLFNBQXVCO1FBSnZCLHFCQUFnQixHQUFoQixnQkFBZ0IsQ0FBa0I7UUFDdEIsYUFBUSxHQUFSLFFBQVEsQ0FBYTtRQUVILGNBQVMsR0FBVCxTQUFTLENBQUs7UUFDNUMsY0FBUyxH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UUFBUTtZQTNEdkIsWUFBWTs7OztJQWtCbkIsbUNBQW9DOzs7OztJQUVwQyxnQ0FBK0I7Ozs7O0lBQy9CLDRCQUE0Qjs7Ozs7O0lBSzVCLHNDQUE4RDs7Ozs7OztJQU05RCw4Q0FBNEU7Ozs7O0lBRTVFLHlDQUFvRjs7Ozs7O0lBS3BGLHFDQUE4Qjs7Ozs7SUFFOUIsMkNBR0U7Ozs7O0lBWUEsdUNBQTRDOzs7OztJQUM1QywrQkFBMkM7Ozs7O0lBRTNDLGdDQUFzRDs7Ozs7SUFDdEQsZ0NBQWlDIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgRE9DVU1FTlQgfSBmcm9tICdAYW5ndWxhci9jb21tb24nO1xuaW1wb3J0IHsgSHR0cEJhY2tlbmQsIEh0dHBDbGllbnQgfSBmcm9tICdAYW5ndWxhci9jb21tb24vaHR0cCc7XG5pbXBvcnQgeyBJbmplY3QsIE9wdGlvbmFsLCBSZW5kZXJlcjIsIFJlbmRlcmVyRmFjdG9yeTIsIFNlY3VyaXR5Q29udGV4dCB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgRG9tU2FuaXRpemVyIH0gZnJvbSAnQGFuZ3VsYXIvcGxhdGZvcm0tYnJvd3Nlcic7XG5pbXBvcnQgeyBvZiBhcyBvYnNlcnZhYmxlT2YsIE9ic2VydmFibGUgfSBmcm9tICdyeGpzJztcbmltcG9ydCB7IGNhdGNoRXJyb3IsIGZpbmFsaXplLCBtYXAsIHNoYXJlLCB0YXAgfSBmcm9tICdyeGpzL29wZXJhdG9ycyc7XG5pbXBvcnQgeyBDYWNoZWRJY29uRGVmaW5pdGlvbiwgSWNvbkRlZmluaXRpb24sIFRoZW1lVHlwZSwgVHdvVG9uZUNvbG9yUGFsZXR0ZSwgVHdvVG9uZUNvbG9yUGFsZXR0ZVNldHRlciB9IGZyb20gJy4uL3R5cGVzJztcbmltcG9ydCB7XG4gIGNsb25lU1ZHLFxuICBnZXRJY29uRGVmaW5pdGlvbkZyb21BYmJyLFxuICBnZXROYW1lQW5kTmFtZXNwYWNlLFxuICBnZXRTZWNvbmRhcnlDb2xvcixcbiAgaGFzTmFtZXNwYWNlLFxuICBpc0ljb25EZWZpbml0aW9uLFxuICByZXBsYWNlRmlsbENvbG9yLFxuICB3aXRoU3VmZml4LFxuICB3aXRoU3VmZml4QW5kQ29sb3Jcbn0gZnJvbSAnLi4vdXRpbHMnO1xuaW1wb3J0IHsgSHR0cE1vZHVsZU5vdEltcG9ydCwgSWNvbk5vdEZvdW5kRXJyb3IsIE5hbWVTcGFjZUlzTm90U3BlY2lmeUVycm9yLCBTVkdUYWdOb3RGb3VuZEVycm9yLCBVcmxOb3RTYWZlRXJyb3IgfSBmcm9tICcuL2ljb24uZXJyb3InO1xuXG5leHBvcnQgY2xhc3MgSWNvblNlcnZpY2Uge1xuICBkZWZhdWx0VGhlbWU6IFRoZW1lVHlwZSA9ICdvdXRsaW5lJztcblxuICBwcm90ZWN0ZWQgX3JlbmRlcmVyOiBSZW5kZXJlcjI7XG4gIHByb3RlY3RlZCBfaHR0cDogSHR0cENsaWVudDtcblxuICAvKipcbiAgICogQWxsIGljb24gZGVmaW5pdGlvbnMgd291bGQgYmUgcmVnaXN0ZXJlZCBoZXJlLlxuICAgKi9cbiAgcHJvdGVjdGVkIF9zdmdEZWZpbml0aW9ucyA9IG5ldyBNYXA8c3RyaW5nLCBJY29uRGVmaW5pdGlvbj4oKTtcblxuICAvKipcbiAgICogQ2FjaGUgYWxsIHJlbmRlcmVkIGljb25zLiBJY29ucyBhcmUgaWRlbnRpZmllZCBieSBuYW1lLCB0aGVtZSxcbiAgICogYW5kIGZvciB0d290b25lIGljb25zLCBwcmltYXJ5IGNvbG9yIGFuZCBzZWNvbmRhcnkgY29sb3IuXG4gICAqL1xuICBwcm90ZWN0ZWQgX3N2Z1JlbmRlcmVkRGVmaW5pdGlvbnMgPSBuZXcgTWFwPHN0cmluZywgQ2FjaGVkSWNvbkRlZmluaXRpb24+KCk7XG5cbiAgcHJvdGVjdGVkIF9pblByb2dyZXNzRmV0Y2hlcyA9IG5ldyBNYXA8c3RyaW5nLCBPYnNlcnZhYmxlPEljb25EZWZpbml0aW9uIHwgbnVsbD4+KCk7XG5cbiAgLyoqXG4gICAqIFVybCBwcmVmaXggZm9yIGZldGNoaW5nIGlubGluZSBTVkcgYnkgZHluYW1pYyBpbXBvcnRpbmcuXG4gICAqL1xuICBwcm90ZWN0ZWQgX2Fzc2V0c1VybFJvb3QgPSAnJztcblxuICBwcm90ZWN0ZWQgX3R3b1RvbmVDb2xvclBhbGV0dGU6IFR3b1RvbmVDb2xvclBhbGV0dGUgPSB7XG4gICAgcHJpbWFyeUNvbG9yICA6ICcjMzMzMzMzJyxcbiAgICBzZWNvbmRhcnlDb2xvcjogJyNFNkU2RTYnXG4gIH07XG5cbiAgc2V0IHR3b1RvbmVDb2xvcih7IHByaW1hcnlDb2xvciwgc2Vjb25kYXJ5Q29sb3IgfTogVHdvVG9uZUNvbG9yUGFsZXR0ZVNldHRlcikge1xuICAgIHRoaXMuX3R3b1RvbmVDb2xvclBhbGV0dGUucHJpbWFyeUNvbG9yID0gcHJpbWFyeUNvbG9yO1xuICAgIHRoaXMuX3R3b1RvbmVDb2xvclBhbGV0dGUuc2Vjb25kYXJ5Q29sb3IgPSBzZWNvbmRhcnlDb2xvciB8fCBnZXRTZWNvbmRhcnlDb2xvcihwcmltYXJ5Q29sb3IpO1xuICB9XG5cbiAgZ2V0IHR3b1RvbmVDb2xvcigpOiBUd29Ub25lQ29sb3JQYWxldHRlU2V0dGVyIHtcbiAgICByZXR1cm4geyAuLi50aGlzLl90d29Ub25lQ29sb3JQYWxldHRlIH0gYXMgVHdvVG9uZUNvbG9yUGFsZXR0ZTsgLy8gTWFrZSBhIGNvcHkgdG8gYXZvaWQgdW5leHBlY3RlZCBjaGFuZ2VzLlxuICB9XG5cbiAgY29uc3RydWN0b3IoXG4gICAgcHJvdGVjdGVkIF9yZW5kZXJlckZhY3Rvcnk6IFJlbmRlcmVyRmFjdG9yeTIsXG4gICAgQE9wdGlvbmFsKCkgcHJvdGVjdGVkIF9oYW5kbGVyOiBIdHRwQmFja2VuZCxcbiAgICAvLyB0c2xpbnQ6ZGlzYWJsZS1uZXh0LWxpbmU6bm8tYW55XG4gICAgQE9wdGlvbmFsKCkgQEluamVjdChET0NVTUVOVCkgcHJvdGVjdGVkIF9kb2N1bWVudDogYW55LFxuICAgIHByb3RlY3RlZCBzYW5pdGl6ZXI6IERvbVNhbml0aXplclxuICApIHtcbiAgICB0aGlzLl9yZW5kZXJlciA9IHRoaXMuX3JlbmRlcmVyRmFjdG9yeS5jcmVhdGVSZW5kZXJlcihudWxsLCBudWxsKTtcbiAgICBpZiAodGhpcy5faGFuZGxlcikge1xuICAgICAgdGhpcy5faHR0cCA9IG5ldyBIdHRwQ2xpZW50KHRoaXMuX2hhbmRsZXIpO1xuICAgIH1cbiAgfVxuXG4gIC8qKlxuICAgKiBDaGFuZ2UgdGhlIHByZWZpeCBvZiB0aGUgaW5saW5lIHN2ZyByZXNvdXJjZXMsIHNvIHRoZXkgY291bGQgYmUgZGVwbG95ZWQgZWxzZXdoZXJlLCBsaWtlIENETi5cbiAgICogQHBhcmFtIHByZWZpeFxuICAgKi9cbiAgY2hhbmdlQXNzZXRzU291cmNlKHByZWZpeDogc3RyaW5nKTogdm9pZCB7XG4gICAgdGhpcy5fYXNzZXRzVXJsUm9vdCA9IHByZWZpeC5lbmRzV2l0aCgnLycpID8gcHJlZml4IDogcHJlZml4ICsgJy8nO1xuICB9XG5cbiAgLyoqXG4gICAqIEFkZCBpY29ucyBwcm92aWRlZCBieSBhbnQgZGVzaWduLlxuICAgKiBAcGFyYW0gaWNvbnNcbiAgICovXG4gIGFkZEljb24oLi4uaWNvbnM6IEljb25EZWZpbml0aW9uW10pOiB2b2lkIHtcbiAgICBpY29ucy5mb3JFYWNoKGljb24gPT4ge1xuICAgICAgdGhpcy5fc3ZnRGVmaW5pdGlvbnMuc2V0KHdpdGhTdWZmaXgoaWNvbi5uYW1lLCBpY29uLnRoZW1lKSwgaWNvbik7XG4gICAgfSk7XG4gIH1cblxuICAvKipcbiAgICogUmVnaXN0ZXIgYW4gaWNvbi4gTmFtZXNwYWNlIGlzIHJlcXVpcmVkLlxuICAgKiBAcGFyYW0gdHlwZVxuICAgKiBAcGFyYW0gbGl0ZXJhbFxuICAgKi9cbiAgYWRkSWNvbkxpdGVyYWwodHlwZTogc3RyaW5nLCBsaXRlcmFsOiBzdHJpbmcpOiB2b2lkIHtcbiAgICBjb25zdCBbIG5hbWUsIG5hbWVzcGFjZSBdID0gZ2V0TmFtZUFuZE5hbWVzcGFjZSh0eXBlKTtcbiAgICBpZiAoIW5hbWVzcGFjZSkge1xuICAgICAgdGhyb3cgTmFtZVNwYWNlSXNOb3RTcGVjaWZ5RXJyb3IoKTtcbiAgICB9XG4gICAgdGhpcy5hZGRJY29uKHsgbmFtZTogdHlwZSwgaWNvbjogbGl0ZXJhbCB9KTtcbiAgfVxuXG4gIC8qKlxuICAgKiBSZW1vdmUgYWxsIGNhY2hlLlxuICAgKi9cbiAgY2xlYXIoKTogdm9pZCB7XG4gICAgdGhpcy5fc3ZnRGVmaW5pdGlvbnMuY2xlYXIoKTtcbiAgICB0aGlzLl9zdmdSZW5kZXJlZERlZmluaXRpb25zLmNsZWFyKCk7XG4gIH1cblxuICAvKipcbiAgICogR2V0IGEgcmVuZGVyZWQgYFNWR0VsZW1lbnRgLlxuICAgKiBAcGFyYW0gaWNvblxuICAgKiBAcGFyYW0gdHdvVG9uZUNvbG9yXG4gICAqL1xuICBnZXRSZW5kZXJlZENvbnRlbnQoaWNvbjogSWNvbkRlZmluaXRpb24gfCBzdHJpbmcsIHR3b1RvbmVDb2xvcj86IHN0cmluZyk6IE9ic2VydmFibGU8U1ZHRWxlbWVudD4ge1xuICAgIC8vIElmIGBpY29uYCBpcyBhIGBJY29uRGVmaW5pdGlvbmAsIGdvIHRvIHRoZSBuZXh0IHN0ZXAuIElmIG5vdCwgdHJ5IHRvIGZldGNoIGl0IGZyb20gY2FjaGUuXG4gICAgY29uc3QgZGVmaW5pdGlvbjogSWNvbkRlZmluaXRpb24gfCBudWxsIHwgdW5kZWZpbmVkID0gaXNJY29uRGVmaW5pdGlvbihpY29uKSA/IGljb24gYXMgSWNvbkRlZmluaXRpb24gOiB0aGlzLl9zdmdEZWZpbml0aW9ucy5nZXQoaWNvbiBhcyBzdHJpbmcpO1xuXG4gICAgLy8gSWYgYGljb25gIGlzIGEgYEljb25EZWZpbml0aW9uYCBvZiBzdWNjZXNzZnVsbHkgZmV0Y2gsIHdyYXAgaXQgaW4gYW4gYE9ic2VydmFibGVgLiBPdGhlcndpc2UgdHJ5IHRvIGZldGNoIGl0IGZyb20gcmVtb3RlLlxuICAgIGNvbnN0ICRpY29uRGVmaW5pdGlvbiA9IGRlZmluaXRpb24gPyBvYnNlcnZhYmxlT2YoZGVmaW5pdGlvbikgOiB0aGlzLl9nZXRGcm9tUmVtb3RlKGljb24gYXMgc3RyaW5nKTtcblxuICAgIC8vIElmIGZpbmFsbHkgZ2V0IGFuIGBJY29uRGVmaW5pdGlvbmAsIHJlbmRlciBhbmQgcmV0dXJuIGl0LiBPdGhlcndpc2UgdGhyb3cgYW4gZXJyb3IuXG4gICAgcmV0dXJuICRpY29uRGVmaW5pdGlvbi5waXBlKG1hcChpID0+IHtcbiAgICAgIGlmICghaSkgeyB0aHJvdyBJY29uTm90Rm91bmRFcnJvcihpY29uIGFzIHN0cmluZyk7IH1cbiAgICAgIHJldHVybiB0aGlzLl9sb2FkU1ZHRnJvbUNhY2hlT3JDcmVhdGVOZXcoaSwgdHdvVG9uZUNvbG9yKTtcbiAgICB9KSk7XG4gIH1cblxuICBnZXRDYWNoZWRJY29ucygpIHtcbiAgICByZXR1cm4gdGhpcy5fc3ZnRGVmaW5pdGlvbnM7XG4gIH1cblxuICAvKipcbiAgICogR2V0IHJhdyBzdmcgYW5kIGFzc2VtYmxlIGEgYEljb25EZWZpbml0aW9uYCBvYmplY3QuXG4gICAqIEBwYXJhbSB0eXBlXG4gICAqL1xuICBwcm90ZWN0ZWQgX2dldEZyb21SZW1vdGUodHlwZTogc3RyaW5nKTogT2JzZXJ2YWJsZTxJY29uRGVmaW5pdGlvbiB8IG51bGw+IHtcbiAgICBpZiAoIXRoaXMuX2h0dHApIHsgcmV0dXJuIG9ic2VydmFibGVPZihIdHRwTW9kdWxlTm90SW1wb3J0KCkpOyB9XG5cbiAgICAvLyBJZiBtdWx0aSBkaXJlY3RpdmUgYXNrIGZvciB0aGUgc2FtZSBpY29uIGF0IHRoZSBzYW1lIHRpbWUsIGh0dHAgcmVxdWVzdCBzaG91bGQgb25seSBiZSBmaXJlZCBvbmNlLlxuICAgIGxldCBpblByb2dyZXNzID0gdGhpcy5faW5Qcm9ncmVzc0ZldGNoZXMuZ2V0KHR5cGUpO1xuXG4gICAgLy8gSWYgdGhlcmUncyBubyBvdGhlciBkaXJlY3RpdmUgYXNraW5nIGZvciB0aGUgc2FtZSBpY29uLCBmaXJlIGEgcmVxdWVzdC5cbiAgICBpZiAoIWluUHJvZ3Jlc3MpIHtcbiAgICAgIGNvbnN0IFsgbmFtZSwgbmFtZXNwYWNlIF0gPSBnZXROYW1lQW5kTmFtZXNwYWNlKHR5cGUpO1xuXG4gICAgICAvLyBJZiB0aGUgc3RyaW5nIGhhcyBhIG5hbWVzcGFjZSB3aXRoaW4sIGNyZWF0ZSBhIHNpbXBsZSBgSWNvbkRlZmluaXRpb25gLlxuICAgICAgY29uc3QgaWNvbjogSWNvbkRlZmluaXRpb24gPSBuYW1lc3BhY2VcbiAgICAgICAgPyB7IG5hbWU6IHR5cGUsIGljb246ICcnIH1cbiAgICAgICAgOiBnZXRJY29uRGVmaW5pdGlvbkZyb21BYmJyKG5hbWUpO1xuXG4gICAgICBjb25zdCB1cmwgPSBuYW1lc3BhY2VcbiAgICAgICAgPyBgJHt0aGlzLl9hc3NldHNVcmxSb290fWFzc2V0cy8ke25hbWVzcGFjZX0vJHtuYW1lfS5zdmdgXG4gICAgICAgIDogYCR7dGhpcy5fYXNzZXRzVXJsUm9vdH1hc3NldHMvJHtpY29uLnRoZW1lfS8ke2ljb24ubmFtZX0uc3ZnYDtcblxuICAgICAgY29uc3Qgc2FmZVVybCA9IHRoaXMuc2FuaXRpemVyLnNhbml0aXplKFNlY3VyaXR5Q29udGV4dC5VUkwsIHVybCk7XG5cbiAgICAgIGlmICghc2FmZVVybCkgeyB0aHJvdyBVcmxOb3RTYWZlRXJyb3IodXJsKTsgfVxuXG4gICAgICAvLyBXcmFwIGEgYEljb25EZWZpbml0aW9uYCwgY2FjaGUgaXQsIGRlbGV0ZSB0aGUgc2hhcmVkIHdvcmsuXG4gICAgICBpblByb2dyZXNzID0gdGhpcy5faHR0cC5nZXQoc2FmZVVybCwgeyByZXNwb25zZVR5cGU6ICd0ZXh0JyB9KS5waXBlKFxuICAgICAgICBtYXAobGl0ZXJhbCA9PiAoeyAuLi5pY29uLCBpY29uOiBsaXRlcmFsIH0pKSxcbiAgICAgICAgdGFwKGRlZmluaXRpb24gPT4gdGhpcy5hZGRJY29uKGRlZmluaXRpb24pKSxcbiAgICAgICAgZmluYWxpemUoKCkgPT4gdGhpcy5faW5Qcm9ncmVzc0ZldGNoZXMuZGVsZXRlKHR5cGUpKSxcbiAgICAgICAgY2F0Y2hFcnJvcigoKSA9PiBvYnNlcnZhYmxlT2YobnVsbCkpLFxuICAgICAgICBzaGFyZSgpXG4gICAgICApO1xuXG4gICAgICB0aGlzLl9pblByb2dyZXNzRmV0Y2hlcy5zZXQodHlwZSwgaW5Qcm9ncmVzcyk7XG4gICAgfVxuXG4gICAgLy8gT3RoZXJ3aXNlIGp1c3QgcmV1c2Ugb3RoZXIgZGlyZWN0aXZlJ3MgcmVxdWVzdC5cbiAgICByZXR1cm4gaW5Qcm9ncmVzcztcbiAgfVxuXG4gIC8qKlxuICAgKiBSZW5kZXIgYSBuZXcgYFNWR0VsZW1lbnRgIGZvciBnaXZlbiBgSWNvbkRlZmluaXRpb25gLCBvciBtYWtlIGEgY29weSBmcm9tIGNhY2hlLlxuICAgKiBAcGFyYW0gaWNvblxuICAgKiBAcGFyYW0gdHdvVG9uZUNvbG9yXG4gICAqL1xuICBwcm90ZWN0ZWQgX2xvYWRTVkdGcm9tQ2FjaGVPckNyZWF0ZU5ldyhpY29uOiBJY29uRGVmaW5pdGlvbiwgdHdvVG9uZUNvbG9yPzogc3RyaW5nKTogU1ZHRWxlbWVudCB7XG4gICAgbGV0IHN2ZzogU1ZHRWxlbWVudDtcblxuICAgIGNvbnN0IHByaSA9IHR3b1RvbmVDb2xvciB8fCB0aGlzLl90d29Ub25lQ29sb3JQYWxldHRlLnByaW1hcnlDb2xvcjtcbiAgICBjb25zdCBzZWMgPSBnZXRTZWNvbmRhcnlDb2xvcihwcmkpIHx8IHRoaXMuX3R3b1RvbmVDb2xvclBhbGV0dGUuc2Vjb25kYXJ5Q29sb3I7XG4gICAgY29uc3Qga2V5ID0gaWNvbi50aGVtZSA9PT0gJ3R3b3RvbmUnXG4gICAgICA/IHdpdGhTdWZmaXhBbmRDb2xvcihpY29uLm5hbWUsIGljb24udGhlbWUsIHByaSwgc2VjKVxuICAgICAgOiBpY29uLnRoZW1lID09PSB1bmRlZmluZWQgPyBpY29uLm5hbWUgOiB3aXRoU3VmZml4KGljb24ubmFtZSwgaWNvbi50aGVtZSk7XG5cbiAgICAvLyBUcnkgdG8gbWFrZSBhIGNvcHkgZnJvbSBjYWNoZS5cbiAgICBjb25zdCBjYWNoZWQgPSB0aGlzLl9zdmdSZW5kZXJlZERlZmluaXRpb25zLmdldChrZXkpO1xuXG4gICAgaWYgKGNhY2hlZCkge1xuICAgICAgc3ZnID0gY2FjaGVkLmljb247XG4gICAgfSBlbHNlIHtcbiAgICAgIHN2ZyA9IHRoaXMuX3NldFNWR0F0dHJpYnV0ZSh0aGlzLl9jb2xvcml6ZVNWR0ljb24oXG4gICAgICAgIC8vIEljb25zIHByb3ZpZGVkIGJ5IGFudCBkZXNpZ24gc2hvdWxkIGJlIHJlZmluZWQgdG8gcmVtb3ZlIHByZXNldCBjb2xvcnMuXG4gICAgICAgIHRoaXMuX2NyZWF0ZVNWR0VsZW1lbnRGcm9tU3RyaW5nKGhhc05hbWVzcGFjZShpY29uLm5hbWUpID8gaWNvbi5pY29uIDogcmVwbGFjZUZpbGxDb2xvcihpY29uLmljb24pKSxcbiAgICAgICAgaWNvbi50aGVtZSA9PT0gJ3R3b3RvbmUnLFxuICAgICAgICBwcmksXG4gICAgICAgIHNlY1xuICAgICAgKSk7XG4gICAgICAvLyBDYWNoZSBpdC5cbiAgICAgIHRoaXMuX3N2Z1JlbmRlcmVkRGVmaW5pdGlvbnMuc2V0KGtleSwgeyAuLi5pY29uLCBpY29uOiBzdmcgfSBhcyBDYWNoZWRJY29uRGVmaW5pdGlvbik7XG4gICAgfVxuXG4gICAgcmV0dXJuIGNsb25lU1ZHKHN2Zyk7XG4gIH1cblxuICBwcm90ZWN0ZWQgX2NyZWF0ZVNWR0VsZW1lbnRGcm9tU3RyaW5nKHN0cjogc3RyaW5nKTogU1ZHRWxlbWVudCB7XG4gICAgY29uc3QgZGl2ID0gdGhpcy5fZG9jdW1lbnQuY3JlYXRlRWxlbWVudCgnZGl2Jyk7XG4gICAgZGl2LmlubmVySFRNTCA9IHN0cjtcbiAgICBjb25zdCBzdmc6IFNWR0VsZW1lbnQgPSBkaXYucXVlcnlTZWxlY3Rvcignc3ZnJyk7XG4gICAgaWYgKCFzdmcpIHsgdGhyb3cgU1ZHVGFnTm90Rm91bmRFcnJvcjsgfVxuICAgIHJldHVybiBzdmc7XG4gIH1cblxuICBwcm90ZWN0ZWQgX3NldFNWR0F0dHJpYnV0ZShzdmc6IFNWR0VsZW1lbnQpOiBTVkdFbGVtZW50IHtcbiAgICB0aGlzLl9yZW5kZXJlci5zZXRBdHRyaWJ1dGUoc3ZnLCAnd2lkdGgnLCAnMWVtJyk7XG4gICAgdGhpcy5fcmVuZGVyZXIuc2V0QXR0cmlidXRlKHN2ZywgJ2hlaWdodCcsICcxZW0nKTtcbiAgICByZXR1cm4gc3ZnO1xuICB9XG5cbiAgcHJvdGVjdGVkIF9jb2xvcml6ZVNWR0ljb24oc3ZnOiBTVkdFbGVtZW50LCB0d290b25lOiBib29sZWFuLCBwcmk6IHN0cmluZywgc2VjOiBzdHJpbmcpOiBTVkdFbGVtZW50IHtcbiAgICBpZiAodHdvdG9uZSkge1xuICAgICAgY29uc3QgY2hpbGRyZW4gPSBzdmcuY2hpbGROb2RlcztcbiAgICAgIGNvbnN0IGxlbmd0aCA9IGNoaWxkcmVuLmxlbmd0aDtcbiAgICAgIGZvciAobGV0IGkgPSAwOyBpIDwgbGVuZ3RoOyBpKyspIHtcbiAgICAgICAgY29uc3QgY2hpbGQ6IEhUTUxFbGVtZW50ID0gY2hpbGRyZW5bIGkgXSBhcyBIVE1MRWxlbWVudDtcbiAgICAgICAgaWYgKGNoaWxkLmdldEF0dHJpYnV0ZSgnZmlsbCcpID09PSAnc2Vjb25kYXJ5Q29sb3InKSB7XG4gICAgICAgICAgdGhpcy5fcmVuZGVyZXIuc2V0QXR0cmlidXRlKGNoaWxkLCAnZmlsbCcsIHNlYyk7XG4gICAgICAgIH0gZWxzZSB7XG4gICAgICAgICAgdGhpcy5fcmVuZGVyZXIuc2V0QXR0cmlidXRlKGNoaWxkLCAnZmlsbCcsIHByaSk7XG4gICAgICAgIH1cbiAgICAgIH1cbiAgICB9XG4gICAgdGhpcy5fcmVuZGVyZXIuc2V0QXR0cmlidXRlKHN2ZywgJ2ZpbGwnLCAnY3VycmVudENvbG9yJyk7XG4gICAgcmV0dXJuIHN2ZztcbiAgfVxufVxuIl19