/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { ChangeDetectionStrategy, Component, ElementRef, Host, Optional, Renderer2, } from '@angular/core';
import { SVContainerComponent } from './view-container.component';
var SVTitleComponent = /** @class */ (function () {
    function SVTitleComponent(el, parent, ren) {
        this.parent = parent;
        this.ren = ren;
        if (parent == null) {
            throw new Error("[sv-title] must include 'sv-container' component");
        }
        this.el = el.nativeElement;
    }
    /**
     * @private
     * @return {?}
     */
    SVTitleComponent.prototype.setClass = /**
     * @private
     * @return {?}
     */
    function () {
        var gutter = this.parent.gutter;
        var el = this.el;
        this.ren.setStyle(el, 'padding-left', gutter / 2 + "px");
        this.ren.setStyle(el, 'padding-right', gutter / 2 + "px");
    };
    /**
     * @return {?}
     */
    SVTitleComponent.prototype.ngOnInit = /**
     * @return {?}
     */
    function () {
        this.setClass();
    };
    SVTitleComponent.decorators = [
        { type: Component, args: [{
                    selector: 'sv-title, [sv-title]',
                    template: '<ng-content></ng-content>',
                    host: {
                        '[class.sv__title]': 'true',
                    },
                    changeDetection: ChangeDetectionStrategy.OnPush
                }] }
    ];
    /** @nocollapse */
    SVTitleComponent.ctorParameters = function () { return [
        { type: ElementRef },
        { type: SVContainerComponent, decorators: [{ type: Host }, { type: Optional }] },
        { type: Renderer2 }
    ]; };
    return SVTitleComponent;
}());
export { SVTitleComponent };
if (false) {
    /**
     * @type {?}
     * @private
     */
    SVTitleComponent.prototype.el;
    /**
     * @type {?}
     * @private
     */
    SVTitleComponent.prototype.parent;
    /**
     * @type {?}
     * @private
     */
    SVTitleComponent.prototype.ren;
}
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidmlldy10aXRsZS5jb21wb25lbnQuanMiLCJzb3VyY2VSb290Ijoibmc6Ly9AZGVsb24vYWJjL3ZpZXcvIiwic291cmNlcyI6WyJ2aWV3LXRpdGxlLmNvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7O0FBQUEsT0FBTyxFQUNMLHVCQUF1QixFQUN2QixTQUFTLEVBQ1QsVUFBVSxFQUNWLElBQUksRUFFSixRQUFRLEVBQ1IsU0FBUyxHQUNWLE1BQU0sZUFBZSxDQUFDO0FBQ3ZCLE9BQU8sRUFBRSxvQkFBb0IsRUFBRSxNQUFNLDRCQUE0QixDQUFDO0FBRWxFO0lBVUUsMEJBQ0UsRUFBYyxFQUNjLE1BQTRCLEVBQ2hELEdBQWM7UUFETSxXQUFNLEdBQU4sTUFBTSxDQUFzQjtRQUNoRCxRQUFHLEdBQUgsR0FBRyxDQUFXO1FBRXRCLElBQUksTUFBTSxJQUFJLElBQUksRUFBRTtZQUNsQixNQUFNLElBQUksS0FBSyxDQUFDLGtEQUFrRCxDQUFDLENBQUM7U0FDckU7UUFDRCxJQUFJLENBQUMsRUFBRSxHQUFHLEVBQUUsQ0FBQyxhQUFhLENBQUM7SUFDN0IsQ0FBQzs7Ozs7SUFFTyxtQ0FBUTs7OztJQUFoQjtRQUNVLElBQUEsMkJBQU07UUFDTixJQUFBLFlBQUU7UUFDVixJQUFJLENBQUMsR0FBRyxDQUFDLFFBQVEsQ0FBQyxFQUFFLEVBQUUsY0FBYyxFQUFLLE1BQU0sR0FBRyxDQUFDLE9BQUksQ0FBQyxDQUFDO1FBQ3pELElBQUksQ0FBQyxHQUFHLENBQUMsUUFBUSxDQUFDLEVBQUUsRUFBRSxlQUFlLEVBQUssTUFBTSxHQUFHLENBQUMsT0FBSSxDQUFDLENBQUM7SUFDNUQsQ0FBQzs7OztJQUVELG1DQUFROzs7SUFBUjtRQUNFLElBQUksQ0FBQyxRQUFRLEVBQUUsQ0FBQztJQUNsQixDQUFDOztnQkE5QkYsU0FBUyxTQUFDO29CQUNULFFBQVEsRUFBRSxzQkFBc0I7b0JBQ2hDLFFBQVEsRUFBRSwyQkFBMkI7b0JBQ3JDLElBQUksRUFBRTt3QkFDSixtQkFBbUIsRUFBRSxNQUFNO3FCQUM1QjtvQkFDRCxlQUFlLEVBQUUsdUJBQXVCLENBQUMsTUFBTTtpQkFDaEQ7Ozs7Z0JBZkMsVUFBVTtnQkFNSCxvQkFBb0IsdUJBY3hCLElBQUksWUFBSSxRQUFRO2dCQWhCbkIsU0FBUzs7SUFtQ1gsdUJBQUM7Q0FBQSxBQS9CRCxJQStCQztTQXZCWSxnQkFBZ0I7Ozs7OztJQUMzQiw4QkFBd0I7Ozs7O0lBR3RCLGtDQUF3RDs7Ozs7SUFDeEQsK0JBQXNCIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHtcbiAgQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3ksXG4gIENvbXBvbmVudCxcbiAgRWxlbWVudFJlZixcbiAgSG9zdCxcbiAgT25Jbml0LFxuICBPcHRpb25hbCxcbiAgUmVuZGVyZXIyLFxufSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IFNWQ29udGFpbmVyQ29tcG9uZW50IH0gZnJvbSAnLi92aWV3LWNvbnRhaW5lci5jb21wb25lbnQnO1xuXG5AQ29tcG9uZW50KHtcbiAgc2VsZWN0b3I6ICdzdi10aXRsZSwgW3N2LXRpdGxlXScsXG4gIHRlbXBsYXRlOiAnPG5nLWNvbnRlbnQ+PC9uZy1jb250ZW50PicsXG4gIGhvc3Q6IHtcbiAgICAnW2NsYXNzLnN2X190aXRsZV0nOiAndHJ1ZScsXG4gIH0sXG4gIGNoYW5nZURldGVjdGlvbjogQ2hhbmdlRGV0ZWN0aW9uU3RyYXRlZ3kuT25QdXNoLFxufSlcbmV4cG9ydCBjbGFzcyBTVlRpdGxlQ29tcG9uZW50IGltcGxlbWVudHMgT25Jbml0IHtcbiAgcHJpdmF0ZSBlbDogSFRNTEVsZW1lbnQ7XG4gIGNvbnN0cnVjdG9yKFxuICAgIGVsOiBFbGVtZW50UmVmLFxuICAgIEBIb3N0KCkgQE9wdGlvbmFsKCkgcHJpdmF0ZSBwYXJlbnQ6IFNWQ29udGFpbmVyQ29tcG9uZW50LFxuICAgIHByaXZhdGUgcmVuOiBSZW5kZXJlcjIsXG4gICkge1xuICAgIGlmIChwYXJlbnQgPT0gbnVsbCkge1xuICAgICAgdGhyb3cgbmV3IEVycm9yKGBbc3YtdGl0bGVdIG11c3QgaW5jbHVkZSAnc3YtY29udGFpbmVyJyBjb21wb25lbnRgKTtcbiAgICB9XG4gICAgdGhpcy5lbCA9IGVsLm5hdGl2ZUVsZW1lbnQ7XG4gIH1cblxuICBwcml2YXRlIHNldENsYXNzKCkge1xuICAgIGNvbnN0IHsgZ3V0dGVyIH0gPSB0aGlzLnBhcmVudDtcbiAgICBjb25zdCB7IGVsIH0gPSB0aGlzO1xuICAgIHRoaXMucmVuLnNldFN0eWxlKGVsLCAncGFkZGluZy1sZWZ0JywgYCR7Z3V0dGVyIC8gMn1weGApO1xuICAgIHRoaXMucmVuLnNldFN0eWxlKGVsLCAncGFkZGluZy1yaWdodCcsIGAke2d1dHRlciAvIDJ9cHhgKTtcbiAgfVxuXG4gIG5nT25Jbml0KCkge1xuICAgIHRoaXMuc2V0Q2xhc3MoKTtcbiAgfVxufVxuIl19