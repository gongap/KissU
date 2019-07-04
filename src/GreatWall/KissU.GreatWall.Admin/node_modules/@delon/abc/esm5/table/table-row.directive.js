/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { Directive, Host, Injectable, Input, TemplateRef } from '@angular/core';
var STRowSource = /** @class */ (function () {
    function STRowSource() {
        this.titles = {};
        this.rows = {};
    }
    /**
     * @param {?} type
     * @param {?} path
     * @param {?} ref
     * @return {?}
     */
    STRowSource.prototype.add = /**
     * @param {?} type
     * @param {?} path
     * @param {?} ref
     * @return {?}
     */
    function (type, path, ref) {
        this[type === 'title' ? 'titles' : 'rows'][path] = ref;
    };
    /**
     * @param {?} path
     * @return {?}
     */
    STRowSource.prototype.getTitle = /**
     * @param {?} path
     * @return {?}
     */
    function (path) {
        return this.titles[path];
    };
    /**
     * @param {?} path
     * @return {?}
     */
    STRowSource.prototype.getRow = /**
     * @param {?} path
     * @return {?}
     */
    function (path) {
        return this.rows[path];
    };
    STRowSource.decorators = [
        { type: Injectable }
    ];
    return STRowSource;
}());
export { STRowSource };
if (false) {
    /**
     * @type {?}
     * @private
     */
    STRowSource.prototype.titles;
    /**
     * @type {?}
     * @private
     */
    STRowSource.prototype.rows;
}
var STRowDirective = /** @class */ (function () {
    function STRowDirective(ref, source) {
        this.ref = ref;
        this.source = source;
    }
    /**
     * @return {?}
     */
    STRowDirective.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        this.source.add(this.type, this.id, this.ref);
    };
    STRowDirective.decorators = [
        { type: Directive, args: [{ selector: '[st-row]' },] }
    ];
    /** @nocollapse */
    STRowDirective.ctorParameters = function () { return [
        { type: TemplateRef },
        { type: STRowSource, decorators: [{ type: Host }] }
    ]; };
    STRowDirective.propDecorators = {
        id: [{ type: Input, args: ['st-row',] }],
        type: [{ type: Input }]
    };
    return STRowDirective;
}());
export { STRowDirective };
if (false) {
    /** @type {?} */
    STRowDirective.prototype.id;
    /** @type {?} */
    STRowDirective.prototype.type;
    /**
     * @type {?}
     * @private
     */
    STRowDirective.prototype.ref;
    /**
     * @type {?}
     * @private
     */
    STRowDirective.prototype.source;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidGFibGUtcm93LmRpcmVjdGl2ZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BkZWxvbi9hYmMvdGFibGUvIiwic291cmNlcyI6WyJ0YWJsZS1yb3cuZGlyZWN0aXZlLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7QUFBQSxPQUFPLEVBQUUsU0FBUyxFQUFFLElBQUksRUFBRSxVQUFVLEVBQUUsS0FBSyxFQUFVLFdBQVcsRUFBRSxNQUFNLGVBQWUsQ0FBQztBQUV4RjtJQUFBO1FBRVUsV0FBTSxHQUF5QyxFQUFFLENBQUM7UUFDbEQsU0FBSSxHQUF5QyxFQUFFLENBQUM7SUFhMUQsQ0FBQzs7Ozs7OztJQVhDLHlCQUFHOzs7Ozs7SUFBSCxVQUFJLElBQVksRUFBRSxJQUFZLEVBQUUsR0FBc0I7UUFDcEQsSUFBSSxDQUFDLElBQUksS0FBSyxPQUFPLENBQUMsQ0FBQyxDQUFDLFFBQVEsQ0FBQyxDQUFDLENBQUMsTUFBTSxDQUFDLENBQUMsSUFBSSxDQUFDLEdBQUcsR0FBRyxDQUFDO0lBQ3pELENBQUM7Ozs7O0lBRUQsOEJBQVE7Ozs7SUFBUixVQUFTLElBQVk7UUFDbkIsT0FBTyxJQUFJLENBQUMsTUFBTSxDQUFDLElBQUksQ0FBQyxDQUFDO0lBQzNCLENBQUM7Ozs7O0lBRUQsNEJBQU07Ozs7SUFBTixVQUFPLElBQVk7UUFDakIsT0FBTyxJQUFJLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxDQUFDO0lBQ3pCLENBQUM7O2dCQWZGLFVBQVU7O0lBZ0JYLGtCQUFDO0NBQUEsQUFoQkQsSUFnQkM7U0FmWSxXQUFXOzs7Ozs7SUFDdEIsNkJBQTBEOzs7OztJQUMxRCwyQkFBd0Q7O0FBZTFEO0lBUUUsd0JBQW9CLEdBQXNCLEVBQWtCLE1BQW1CO1FBQTNELFFBQUcsR0FBSCxHQUFHLENBQW1CO1FBQWtCLFdBQU0sR0FBTixNQUFNLENBQWE7SUFBRyxDQUFDOzs7O0lBRW5GLGlDQUFROzs7SUFBUjtRQUNFLElBQUksQ0FBQyxNQUFNLENBQUMsR0FBRyxDQUFDLElBQUksQ0FBQyxJQUFJLEVBQUUsSUFBSSxDQUFDLEVBQUUsRUFBRSxJQUFJLENBQUMsR0FBRyxDQUFDLENBQUM7SUFDaEQsQ0FBQzs7Z0JBWkYsU0FBUyxTQUFDLEVBQUUsUUFBUSxFQUFFLFVBQVUsRUFBRTs7OztnQkFwQmtCLFdBQVc7Z0JBNEJNLFdBQVcsdUJBQWxDLElBQUk7OztxQkFOaEQsS0FBSyxTQUFDLFFBQVE7dUJBR2QsS0FBSzs7SUFRUixxQkFBQztDQUFBLEFBYkQsSUFhQztTQVpZLGNBQWM7OztJQUN6Qiw0QkFDVzs7SUFFWCw4QkFDYzs7Ozs7SUFFRiw2QkFBOEI7Ozs7O0lBQUUsZ0NBQW1DIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgRGlyZWN0aXZlLCBIb3N0LCBJbmplY3RhYmxlLCBJbnB1dCwgT25Jbml0LCBUZW1wbGF0ZVJlZiB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuXG5ASW5qZWN0YWJsZSgpXG5leHBvcnQgY2xhc3MgU1RSb3dTb3VyY2Uge1xuICBwcml2YXRlIHRpdGxlczogeyBba2V5OiBzdHJpbmddOiBUZW1wbGF0ZVJlZjx2b2lkPiB9ID0ge307XG4gIHByaXZhdGUgcm93czogeyBba2V5OiBzdHJpbmddOiBUZW1wbGF0ZVJlZjx2b2lkPiB9ID0ge307XG5cbiAgYWRkKHR5cGU6IHN0cmluZywgcGF0aDogc3RyaW5nLCByZWY6IFRlbXBsYXRlUmVmPHZvaWQ+KSB7XG4gICAgdGhpc1t0eXBlID09PSAndGl0bGUnID8gJ3RpdGxlcycgOiAncm93cyddW3BhdGhdID0gcmVmO1xuICB9XG5cbiAgZ2V0VGl0bGUocGF0aDogc3RyaW5nKSB7XG4gICAgcmV0dXJuIHRoaXMudGl0bGVzW3BhdGhdO1xuICB9XG5cbiAgZ2V0Um93KHBhdGg6IHN0cmluZykge1xuICAgIHJldHVybiB0aGlzLnJvd3NbcGF0aF07XG4gIH1cbn1cblxuQERpcmVjdGl2ZSh7IHNlbGVjdG9yOiAnW3N0LXJvd10nIH0pXG5leHBvcnQgY2xhc3MgU1RSb3dEaXJlY3RpdmUgaW1wbGVtZW50cyBPbkluaXQge1xuICBASW5wdXQoJ3N0LXJvdycpXG4gIGlkOiBzdHJpbmc7XG5cbiAgQElucHV0KClcbiAgdHlwZTogJ3RpdGxlJztcblxuICBjb25zdHJ1Y3Rvcihwcml2YXRlIHJlZjogVGVtcGxhdGVSZWY8dm9pZD4sIEBIb3N0KCkgcHJpdmF0ZSBzb3VyY2U6IFNUUm93U291cmNlKSB7fVxuXG4gIG5nT25Jbml0KCk6IHZvaWQge1xuICAgIHRoaXMuc291cmNlLmFkZCh0aGlzLnR5cGUsIHRoaXMuaWQsIHRoaXMucmVmKTtcbiAgfVxufVxuIl19