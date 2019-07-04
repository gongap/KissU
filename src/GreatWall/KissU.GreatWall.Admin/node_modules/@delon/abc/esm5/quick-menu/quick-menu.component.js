/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, Input, Renderer2, } from '@angular/core';
import { InputNumber } from '@delon/util';
var QuickMenuComponent = /** @class */ (function () {
    // #endregion
    function QuickMenuComponent(cdr, el, render) {
        this.cdr = cdr;
        this.el = el;
        this.render = render;
        // #region fields
        this.icon = 'question-circle';
        this.top = 120;
        this.width = 200;
        this.bgColor = '#fff';
        this.borderColor = '#ddd';
        this.show = false;
        this.ctrlStyle = {};
        this.initFlag = false;
    }
    /**
     * @return {?}
     */
    QuickMenuComponent.prototype._click = /**
     * @return {?}
     */
    function () {
        this.show = !this.show;
        this.setStyle();
    };
    /**
     * @private
     * @return {?}
     */
    QuickMenuComponent.prototype.setStyle = /**
     * @private
     * @return {?}
     */
    function () {
        this.ctrlStyle = {
            'background-color': this.bgColor,
            'border-color': this.borderColor,
        };
        /** @type {?} */
        var res = [
            "top:" + this.top + "px",
            "width:" + this.width + "px",
            "background-color:" + this.bgColor,
            "border-color:" + this.borderColor,
            "margin-right:-" + (this.show ? 0 : this.width) + "px",
        ];
        this.render.setAttribute(this.el.nativeElement, 'style', res.join(';'));
        this.cdr.detectChanges();
    };
    /**
     * @return {?}
     */
    QuickMenuComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        this.initFlag = true;
        this.setStyle();
    };
    /**
     * @return {?}
     */
    QuickMenuComponent.prototype.ngOnChanges = /**
     * @return {?}
     */
    function () {
        if (this.initFlag)
            this.setStyle();
    };
    QuickMenuComponent.decorators = [
        { type: Component, args: [{
                    selector: 'quick-menu',
                    template: "<div class=\"quick-menu__inner\">\n  <div class=\"quick-menu__ctrl\"\n       [ngStyle]=\"ctrlStyle\">\n    <div class=\"quick-menu__ctrl-icon\">\n      <ng-container *stringTemplateOutlet=\"icon\"><i nz-icon\n           [type]=\"icon\"></i></ng-container>\n    </div>\n  </div>\n  <ng-content></ng-content>\n</div>\n",
                    host: {
                        '[class.quick-menu]': 'true',
                        '(click)': '_click()',
                    },
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    QuickMenuComponent.ctorParameters = function () { return [
        { type: ChangeDetectorRef },
        { type: ElementRef },
        { type: Renderer2 }
    ]; };
    QuickMenuComponent.propDecorators = {
        icon: [{ type: Input }],
        top: [{ type: Input }],
        width: [{ type: Input }],
        bgColor: [{ type: Input }],
        borderColor: [{ type: Input }]
    };
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Object)
    ], QuickMenuComponent.prototype, "top", void 0);
    tslib_1.__decorate([
        InputNumber(),
        tslib_1.__metadata("design:type", Object)
    ], QuickMenuComponent.prototype, "width", void 0);
    return QuickMenuComponent;
}());
export { QuickMenuComponent };
if (false) {
    /** @type {?} */
    QuickMenuComponent.prototype.icon;
    /** @type {?} */
    QuickMenuComponent.prototype.top;
    /** @type {?} */
    QuickMenuComponent.prototype.width;
    /** @type {?} */
    QuickMenuComponent.prototype.bgColor;
    /** @type {?} */
    QuickMenuComponent.prototype.borderColor;
    /**
     * @type {?}
     * @private
     */
    QuickMenuComponent.prototype.show;
    /** @type {?} */
    QuickMenuComponent.prototype.ctrlStyle;
    /**
     * @type {?}
     * @private
     */
    QuickMenuComponent.prototype.initFlag;
    /**
     * @type {?}
     * @private
     */
    QuickMenuComponent.prototype.cdr;
    /**
     * @type {?}
     * @private
     */
    QuickMenuComponent.prototype.el;
    /**
     * @type {?}
     * @private
     */
    QuickMenuComponent.prototype.render;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicXVpY2stbWVudS5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL3F1aWNrLW1lbnUvIiwic291cmNlcyI6WyJxdWljay1tZW51LmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7OztBQUFBLE9BQU8sRUFDTCx1QkFBdUIsRUFDdkIsaUJBQWlCLEVBQ2pCLFNBQVMsRUFDVCxVQUFVLEVBQ1YsS0FBSyxFQUdMLFNBQVMsR0FFVixNQUFNLGVBQWUsQ0FBQztBQUV2QixPQUFPLEVBQUUsV0FBVyxFQUFFLE1BQU0sYUFBYSxDQUFDO0FBRTFDO0lBa0JFLGFBQWE7SUFFYiw0QkFBb0IsR0FBc0IsRUFBVSxFQUFjLEVBQVUsTUFBaUI7UUFBekUsUUFBRyxHQUFILEdBQUcsQ0FBbUI7UUFBVSxPQUFFLEdBQUYsRUFBRSxDQUFZO1FBQVUsV0FBTSxHQUFOLE1BQU0sQ0FBVzs7UUFScEYsU0FBSSxHQUErQixpQkFBaUIsQ0FBQztRQUN0QyxRQUFHLEdBQUcsR0FBRyxDQUFDO1FBQ1YsVUFBSyxHQUFHLEdBQUcsQ0FBQztRQUMzQixZQUFPLEdBQUcsTUFBTSxDQUFDO1FBQ2pCLGdCQUFXLEdBQUcsTUFBTSxDQUFDO1FBTXRCLFNBQUksR0FBRyxLQUFLLENBQUM7UUFPckIsY0FBUyxHQUE4QixFQUFFLENBQUM7UUFrQmxDLGFBQVEsR0FBRyxLQUFLLENBQUM7SUEzQnVFLENBQUM7Ozs7SUFJakcsbUNBQU07OztJQUFOO1FBQ0UsSUFBSSxDQUFDLElBQUksR0FBRyxDQUFDLElBQUksQ0FBQyxJQUFJLENBQUM7UUFDdkIsSUFBSSxDQUFDLFFBQVEsRUFBRSxDQUFDO0lBQ2xCLENBQUM7Ozs7O0lBR08scUNBQVE7Ozs7SUFBaEI7UUFDRSxJQUFJLENBQUMsU0FBUyxHQUFHO1lBQ2Ysa0JBQWtCLEVBQUUsSUFBSSxDQUFDLE9BQU87WUFDaEMsY0FBYyxFQUFFLElBQUksQ0FBQyxXQUFXO1NBQ2pDLENBQUM7O1lBRUksR0FBRyxHQUFhO1lBQ3BCLFNBQU8sSUFBSSxDQUFDLEdBQUcsT0FBSTtZQUNuQixXQUFTLElBQUksQ0FBQyxLQUFLLE9BQUk7WUFDdkIsc0JBQW9CLElBQUksQ0FBQyxPQUFTO1lBQ2xDLGtCQUFnQixJQUFJLENBQUMsV0FBYTtZQUNsQyxvQkFBaUIsSUFBSSxDQUFDLElBQUksQ0FBQyxDQUFDLENBQUMsQ0FBQyxDQUFDLENBQUMsQ0FBQyxJQUFJLENBQUMsS0FBSyxRQUFJO1NBQ2hEO1FBQ0QsSUFBSSxDQUFDLE1BQU0sQ0FBQyxZQUFZLENBQUMsSUFBSSxDQUFDLEVBQUUsQ0FBQyxhQUFhLEVBQUUsT0FBTyxFQUFFLEdBQUcsQ0FBQyxJQUFJLENBQUMsR0FBRyxDQUFDLENBQUMsQ0FBQztRQUN4RSxJQUFJLENBQUMsR0FBRyxDQUFDLGFBQWEsRUFBRSxDQUFDO0lBQzNCLENBQUM7Ozs7SUFHRCxxQ0FBUTs7O0lBQVI7UUFDRSxJQUFJLENBQUMsUUFBUSxHQUFHLElBQUksQ0FBQztRQUNyQixJQUFJLENBQUMsUUFBUSxFQUFFLENBQUM7SUFDbEIsQ0FBQzs7OztJQUNELHdDQUFXOzs7SUFBWDtRQUNFLElBQUksSUFBSSxDQUFDLFFBQVE7WUFBRSxJQUFJLENBQUMsUUFBUSxFQUFFLENBQUM7SUFDckMsQ0FBQzs7Z0JBdERGLFNBQVMsU0FBQztvQkFDVCxRQUFRLEVBQUUsWUFBWTtvQkFDdEIsd1VBQTBDO29CQUMxQyxJQUFJLEVBQUU7d0JBQ0osb0JBQW9CLEVBQUUsTUFBTTt3QkFDNUIsU0FBUyxFQUFFLFVBQVU7cUJBQ3RCO29CQUNELGVBQWUsRUFBRSx1QkFBdUIsQ0FBQyxNQUFNO2lCQUNoRDs7OztnQkFwQkMsaUJBQWlCO2dCQUVqQixVQUFVO2dCQUlWLFNBQVM7Ozt1QkFrQlIsS0FBSztzQkFDTCxLQUFLO3dCQUNMLEtBQUs7MEJBQ0wsS0FBSzs4QkFDTCxLQUFLOztJQUhrQjtRQUFkLFdBQVcsRUFBRTs7bURBQVc7SUFDVjtRQUFkLFdBQVcsRUFBRTs7cURBQWE7SUF5Q3RDLHlCQUFDO0NBQUEsQUF2REQsSUF1REM7U0E5Q1ksa0JBQWtCOzs7SUFHN0Isa0NBQThEOztJQUM5RCxpQ0FBa0M7O0lBQ2xDLG1DQUFvQzs7SUFDcEMscUNBQTBCOztJQUMxQix5Q0FBOEI7Ozs7O0lBTTlCLGtDQUFxQjs7SUFPckIsdUNBQTBDOzs7OztJQWtCMUMsc0NBQXlCOzs7OztJQTNCYixpQ0FBOEI7Ozs7O0lBQUUsZ0NBQXNCOzs7OztJQUFFLG9DQUF5QiIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7XG4gIENoYW5nZURldGVjdGlvblN0cmF0ZWd5LFxuICBDaGFuZ2VEZXRlY3RvclJlZixcbiAgQ29tcG9uZW50LFxuICBFbGVtZW50UmVmLFxuICBJbnB1dCxcbiAgT25DaGFuZ2VzLFxuICBPbkluaXQsXG4gIFJlbmRlcmVyMixcbiAgVGVtcGxhdGVSZWYsXG59IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuXG5pbXBvcnQgeyBJbnB1dE51bWJlciB9IGZyb20gJ0BkZWxvbi91dGlsJztcblxuQENvbXBvbmVudCh7XG4gIHNlbGVjdG9yOiAncXVpY2stbWVudScsXG4gIHRlbXBsYXRlVXJsOiAnLi9xdWljay1tZW51LmNvbXBvbmVudC5odG1sJyxcbiAgaG9zdDoge1xuICAgICdbY2xhc3MucXVpY2stbWVudV0nOiAndHJ1ZScsXG4gICAgJyhjbGljayknOiAnX2NsaWNrKCknLFxuICB9LFxuICBjaGFuZ2VEZXRlY3Rpb246IENoYW5nZURldGVjdGlvblN0cmF0ZWd5Lk9uUHVzaCxcbn0pXG5leHBvcnQgY2xhc3MgUXVpY2tNZW51Q29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0LCBPbkNoYW5nZXMge1xuICAvLyAjcmVnaW9uIGZpZWxkc1xuXG4gIEBJbnB1dCgpIGljb246IHN0cmluZyB8IFRlbXBsYXRlUmVmPHZvaWQ+ID0gJ3F1ZXN0aW9uLWNpcmNsZSc7XG4gIEBJbnB1dCgpIEBJbnB1dE51bWJlcigpIHRvcCA9IDEyMDtcbiAgQElucHV0KCkgQElucHV0TnVtYmVyKCkgd2lkdGggPSAyMDA7XG4gIEBJbnB1dCgpIGJnQ29sb3IgPSAnI2ZmZic7XG4gIEBJbnB1dCgpIGJvcmRlckNvbG9yID0gJyNkZGQnO1xuXG4gIC8vICNlbmRyZWdpb25cblxuICBjb25zdHJ1Y3Rvcihwcml2YXRlIGNkcjogQ2hhbmdlRGV0ZWN0b3JSZWYsIHByaXZhdGUgZWw6IEVsZW1lbnRSZWYsIHByaXZhdGUgcmVuZGVyOiBSZW5kZXJlcjIpIHt9XG5cbiAgcHJpdmF0ZSBzaG93ID0gZmFsc2U7XG5cbiAgX2NsaWNrKCkge1xuICAgIHRoaXMuc2hvdyA9ICF0aGlzLnNob3c7XG4gICAgdGhpcy5zZXRTdHlsZSgpO1xuICB9XG5cbiAgY3RybFN0eWxlOiB7IFtrZXk6IHN0cmluZ106IHN0cmluZyB9ID0ge307XG4gIHByaXZhdGUgc2V0U3R5bGUoKSB7XG4gICAgdGhpcy5jdHJsU3R5bGUgPSB7XG4gICAgICAnYmFja2dyb3VuZC1jb2xvcic6IHRoaXMuYmdDb2xvcixcbiAgICAgICdib3JkZXItY29sb3InOiB0aGlzLmJvcmRlckNvbG9yLFxuICAgIH07XG5cbiAgICBjb25zdCByZXM6IHN0cmluZ1tdID0gW1xuICAgICAgYHRvcDoke3RoaXMudG9wfXB4YCxcbiAgICAgIGB3aWR0aDoke3RoaXMud2lkdGh9cHhgLFxuICAgICAgYGJhY2tncm91bmQtY29sb3I6JHt0aGlzLmJnQ29sb3J9YCxcbiAgICAgIGBib3JkZXItY29sb3I6JHt0aGlzLmJvcmRlckNvbG9yfWAsXG4gICAgICBgbWFyZ2luLXJpZ2h0Oi0ke3RoaXMuc2hvdyA/IDAgOiB0aGlzLndpZHRofXB4YCxcbiAgICBdO1xuICAgIHRoaXMucmVuZGVyLnNldEF0dHJpYnV0ZSh0aGlzLmVsLm5hdGl2ZUVsZW1lbnQsICdzdHlsZScsIHJlcy5qb2luKCc7JykpO1xuICAgIHRoaXMuY2RyLmRldGVjdENoYW5nZXMoKTtcbiAgfVxuXG4gIHByaXZhdGUgaW5pdEZsYWcgPSBmYWxzZTtcbiAgbmdPbkluaXQoKTogdm9pZCB7XG4gICAgdGhpcy5pbml0RmxhZyA9IHRydWU7XG4gICAgdGhpcy5zZXRTdHlsZSgpO1xuICB9XG4gIG5nT25DaGFuZ2VzKCk6IHZvaWQge1xuICAgIGlmICh0aGlzLmluaXRGbGFnKSB0aGlzLnNldFN0eWxlKCk7XG4gIH1cbn1cbiJdfQ==