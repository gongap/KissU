/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import * as tslib_1 from "tslib";
import { CommonModule } from '@angular/common';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { DelonACLModule } from '@delon/acl';
import { DelonUtilModule } from '@delon/util';
import { STRowDirective } from './table-row.directive';
import { STComponent } from './table.component';
/** @type {?} */
var COMPONENTS = [STComponent, STRowDirective];
var STModule = /** @class */ (function () {
    function STModule() {
    }
    STModule.decorators = [
        { type: NgModule, args: [{
                    schemas: [NO_ERRORS_SCHEMA],
                    imports: [CommonModule, FormsModule, DelonUtilModule, DelonACLModule, NgZorroAntdModule],
                    declarations: tslib_1.__spread(COMPONENTS),
                    exports: tslib_1.__spread(COMPONENTS),
                },] }
    ];
    return STModule;
}());
export { STModule };
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoidGFibGUubW9kdWxlLmpzIiwic291cmNlUm9vdCI6Im5nOi8vQGRlbG9uL2FiYy90YWJsZS8iLCJzb3VyY2VzIjpbInRhYmxlLm1vZHVsZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7OztBQUFBLE9BQU8sRUFBRSxZQUFZLEVBQUUsTUFBTSxpQkFBaUIsQ0FBQztBQUMvQyxPQUFPLEVBQUUsUUFBUSxFQUFFLGdCQUFnQixFQUFFLE1BQU0sZUFBZSxDQUFDO0FBQzNELE9BQU8sRUFBRSxXQUFXLEVBQUUsTUFBTSxnQkFBZ0IsQ0FBQztBQUM3QyxPQUFPLEVBQUUsaUJBQWlCLEVBQUUsTUFBTSxlQUFlLENBQUM7QUFFbEQsT0FBTyxFQUFFLGNBQWMsRUFBRSxNQUFNLFlBQVksQ0FBQztBQUM1QyxPQUFPLEVBQUUsZUFBZSxFQUFFLE1BQU0sYUFBYSxDQUFDO0FBRTlDLE9BQU8sRUFBRSxjQUFjLEVBQUUsTUFBTSx1QkFBdUIsQ0FBQztBQUN2RCxPQUFPLEVBQUUsV0FBVyxFQUFFLE1BQU0sbUJBQW1CLENBQUM7O0lBRTFDLFVBQVUsR0FBRyxDQUFDLFdBQVcsRUFBRSxjQUFjLENBQUM7QUFFaEQ7SUFBQTtJQU11QixDQUFDOztnQkFOdkIsUUFBUSxTQUFDO29CQUNSLE9BQU8sRUFBRSxDQUFDLGdCQUFnQixDQUFDO29CQUMzQixPQUFPLEVBQUUsQ0FBQyxZQUFZLEVBQUUsV0FBVyxFQUFFLGVBQWUsRUFBRSxjQUFjLEVBQUUsaUJBQWlCLENBQUM7b0JBQ3hGLFlBQVksbUJBQU0sVUFBVSxDQUFDO29CQUM3QixPQUFPLG1CQUFNLFVBQVUsQ0FBQztpQkFDekI7O0lBQ3NCLGVBQUM7Q0FBQSxBQU54QixJQU13QjtTQUFYLFFBQVEiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBDb21tb25Nb2R1bGUgfSBmcm9tICdAYW5ndWxhci9jb21tb24nO1xuaW1wb3J0IHsgTmdNb2R1bGUsIE5PX0VSUk9SU19TQ0hFTUEgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IEZvcm1zTW9kdWxlIH0gZnJvbSAnQGFuZ3VsYXIvZm9ybXMnO1xuaW1wb3J0IHsgTmdab3Jyb0FudGRNb2R1bGUgfSBmcm9tICduZy16b3Jyby1hbnRkJztcblxuaW1wb3J0IHsgRGVsb25BQ0xNb2R1bGUgfSBmcm9tICdAZGVsb24vYWNsJztcbmltcG9ydCB7IERlbG9uVXRpbE1vZHVsZSB9IGZyb20gJ0BkZWxvbi91dGlsJztcblxuaW1wb3J0IHsgU1RSb3dEaXJlY3RpdmUgfSBmcm9tICcuL3RhYmxlLXJvdy5kaXJlY3RpdmUnO1xuaW1wb3J0IHsgU1RDb21wb25lbnQgfSBmcm9tICcuL3RhYmxlLmNvbXBvbmVudCc7XG5cbmNvbnN0IENPTVBPTkVOVFMgPSBbU1RDb21wb25lbnQsIFNUUm93RGlyZWN0aXZlXTtcblxuQE5nTW9kdWxlKHtcbiAgc2NoZW1hczogW05PX0VSUk9SU19TQ0hFTUFdLFxuICBpbXBvcnRzOiBbQ29tbW9uTW9kdWxlLCBGb3Jtc01vZHVsZSwgRGVsb25VdGlsTW9kdWxlLCBEZWxvbkFDTE1vZHVsZSwgTmdab3Jyb0FudGRNb2R1bGVdLFxuICBkZWNsYXJhdGlvbnM6IFsuLi5DT01QT05FTlRTXSxcbiAgZXhwb3J0czogWy4uLkNPTVBPTkVOVFNdLFxufSlcbmV4cG9ydCBjbGFzcyBTVE1vZHVsZSB7fVxuIl19