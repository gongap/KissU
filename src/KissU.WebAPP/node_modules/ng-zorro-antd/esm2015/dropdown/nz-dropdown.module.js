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
import { OverlayModule } from '@angular/cdk/overlay';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzNoAnimationModule, NzOverlayModule } from 'ng-zorro-antd/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzDropDownADirective } from './nz-dropdown-a.directive';
import { NzDropDownButtonComponent } from './nz-dropdown-button.component';
import { NzDropdownContextComponent } from './nz-dropdown-context.component';
import { NzDropDownComponent } from './nz-dropdown.component';
import { NzDropDownDirective } from './nz-dropdown.directive';
import { NzDropdownService } from './nz-dropdown.service';
export class NzDropDownModule {
}
NzDropDownModule.decorators = [
    { type: NgModule, args: [{
                imports: [
                    CommonModule,
                    OverlayModule,
                    FormsModule,
                    NzButtonModule,
                    NzMenuModule,
                    NzIconModule,
                    NzNoAnimationModule,
                    NzOverlayModule
                ],
                entryComponents: [NzDropdownContextComponent],
                declarations: [
                    NzDropDownComponent,
                    NzDropDownButtonComponent,
                    NzDropDownDirective,
                    NzDropDownADirective,
                    NzDropdownContextComponent
                ],
                exports: [NzMenuModule, NzDropDownComponent, NzDropDownButtonComponent, NzDropDownDirective, NzDropDownADirective],
                providers: [NzDropdownService]
            },] }
];
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoibnotZHJvcGRvd24ubW9kdWxlLmpzIiwic291cmNlUm9vdCI6Im5nOi8vbmctem9ycm8tYW50ZC9kcm9wZG93bi8iLCJzb3VyY2VzIjpbIm56LWRyb3Bkb3duLm1vZHVsZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7OztBQVFBLE9BQU8sRUFBRSxhQUFhLEVBQUUsTUFBTSxzQkFBc0IsQ0FBQztBQUNyRCxPQUFPLEVBQUUsWUFBWSxFQUFFLE1BQU0saUJBQWlCLENBQUM7QUFDL0MsT0FBTyxFQUFFLFFBQVEsRUFBRSxNQUFNLGVBQWUsQ0FBQztBQUN6QyxPQUFPLEVBQUUsV0FBVyxFQUFFLE1BQU0sZ0JBQWdCLENBQUM7QUFFN0MsT0FBTyxFQUFFLGNBQWMsRUFBRSxNQUFNLHNCQUFzQixDQUFDO0FBQ3RELE9BQU8sRUFBRSxtQkFBbUIsRUFBRSxlQUFlLEVBQUUsTUFBTSxvQkFBb0IsQ0FBQztBQUMxRSxPQUFPLEVBQUUsWUFBWSxFQUFFLE1BQU0sb0JBQW9CLENBQUM7QUFDbEQsT0FBTyxFQUFFLFlBQVksRUFBRSxNQUFNLG9CQUFvQixDQUFDO0FBRWxELE9BQU8sRUFBRSxvQkFBb0IsRUFBRSxNQUFNLDJCQUEyQixDQUFDO0FBQ2pFLE9BQU8sRUFBRSx5QkFBeUIsRUFBRSxNQUFNLGdDQUFnQyxDQUFDO0FBQzNFLE9BQU8sRUFBRSwwQkFBMEIsRUFBRSxNQUFNLGlDQUFpQyxDQUFDO0FBQzdFLE9BQU8sRUFBRSxtQkFBbUIsRUFBRSxNQUFNLHlCQUF5QixDQUFDO0FBQzlELE9BQU8sRUFBRSxtQkFBbUIsRUFBRSxNQUFNLHlCQUF5QixDQUFDO0FBQzlELE9BQU8sRUFBRSxpQkFBaUIsRUFBRSxNQUFNLHVCQUF1QixDQUFDO0FBd0IxRCxNQUFNLE9BQU8sZ0JBQWdCOzs7WUF0QjVCLFFBQVEsU0FBQztnQkFDUixPQUFPLEVBQUU7b0JBQ1AsWUFBWTtvQkFDWixhQUFhO29CQUNiLFdBQVc7b0JBQ1gsY0FBYztvQkFDZCxZQUFZO29CQUNaLFlBQVk7b0JBQ1osbUJBQW1CO29CQUNuQixlQUFlO2lCQUNoQjtnQkFDRCxlQUFlLEVBQUUsQ0FBQywwQkFBMEIsQ0FBQztnQkFDN0MsWUFBWSxFQUFFO29CQUNaLG1CQUFtQjtvQkFDbkIseUJBQXlCO29CQUN6QixtQkFBbUI7b0JBQ25CLG9CQUFvQjtvQkFDcEIsMEJBQTBCO2lCQUMzQjtnQkFDRCxPQUFPLEVBQUUsQ0FBQyxZQUFZLEVBQUUsbUJBQW1CLEVBQUUseUJBQXlCLEVBQUUsbUJBQW1CLEVBQUUsb0JBQW9CLENBQUM7Z0JBQ2xILFNBQVMsRUFBRSxDQUFDLGlCQUFpQixDQUFDO2FBQy9CIiwic291cmNlc0NvbnRlbnQiOlsiLyoqXG4gKiBAbGljZW5zZVxuICogQ29weXJpZ2h0IEFsaWJhYmEuY29tIEFsbCBSaWdodHMgUmVzZXJ2ZWQuXG4gKlxuICogVXNlIG9mIHRoaXMgc291cmNlIGNvZGUgaXMgZ292ZXJuZWQgYnkgYW4gTUlULXN0eWxlIGxpY2Vuc2UgdGhhdCBjYW4gYmVcbiAqIGZvdW5kIGluIHRoZSBMSUNFTlNFIGZpbGUgYXQgaHR0cHM6Ly9naXRodWIuY29tL05HLVpPUlJPL25nLXpvcnJvLWFudGQvYmxvYi9tYXN0ZXIvTElDRU5TRVxuICovXG5cbmltcG9ydCB7IE92ZXJsYXlNb2R1bGUgfSBmcm9tICdAYW5ndWxhci9jZGsvb3ZlcmxheSc7XG5pbXBvcnQgeyBDb21tb25Nb2R1bGUgfSBmcm9tICdAYW5ndWxhci9jb21tb24nO1xuaW1wb3J0IHsgTmdNb2R1bGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IEZvcm1zTW9kdWxlIH0gZnJvbSAnQGFuZ3VsYXIvZm9ybXMnO1xuXG5pbXBvcnQgeyBOekJ1dHRvbk1vZHVsZSB9IGZyb20gJ25nLXpvcnJvLWFudGQvYnV0dG9uJztcbmltcG9ydCB7IE56Tm9BbmltYXRpb25Nb2R1bGUsIE56T3ZlcmxheU1vZHVsZSB9IGZyb20gJ25nLXpvcnJvLWFudGQvY29yZSc7XG5pbXBvcnQgeyBOekljb25Nb2R1bGUgfSBmcm9tICduZy16b3Jyby1hbnRkL2ljb24nO1xuaW1wb3J0IHsgTnpNZW51TW9kdWxlIH0gZnJvbSAnbmctem9ycm8tYW50ZC9tZW51JztcblxuaW1wb3J0IHsgTnpEcm9wRG93bkFEaXJlY3RpdmUgfSBmcm9tICcuL256LWRyb3Bkb3duLWEuZGlyZWN0aXZlJztcbmltcG9ydCB7IE56RHJvcERvd25CdXR0b25Db21wb25lbnQgfSBmcm9tICcuL256LWRyb3Bkb3duLWJ1dHRvbi5jb21wb25lbnQnO1xuaW1wb3J0IHsgTnpEcm9wZG93bkNvbnRleHRDb21wb25lbnQgfSBmcm9tICcuL256LWRyb3Bkb3duLWNvbnRleHQuY29tcG9uZW50JztcbmltcG9ydCB7IE56RHJvcERvd25Db21wb25lbnQgfSBmcm9tICcuL256LWRyb3Bkb3duLmNvbXBvbmVudCc7XG5pbXBvcnQgeyBOekRyb3BEb3duRGlyZWN0aXZlIH0gZnJvbSAnLi9uei1kcm9wZG93bi5kaXJlY3RpdmUnO1xuaW1wb3J0IHsgTnpEcm9wZG93blNlcnZpY2UgfSBmcm9tICcuL256LWRyb3Bkb3duLnNlcnZpY2UnO1xuXG5ATmdNb2R1bGUoe1xuICBpbXBvcnRzOiBbXG4gICAgQ29tbW9uTW9kdWxlLFxuICAgIE92ZXJsYXlNb2R1bGUsXG4gICAgRm9ybXNNb2R1bGUsXG4gICAgTnpCdXR0b25Nb2R1bGUsXG4gICAgTnpNZW51TW9kdWxlLFxuICAgIE56SWNvbk1vZHVsZSxcbiAgICBOek5vQW5pbWF0aW9uTW9kdWxlLFxuICAgIE56T3ZlcmxheU1vZHVsZVxuICBdLFxuICBlbnRyeUNvbXBvbmVudHM6IFtOekRyb3Bkb3duQ29udGV4dENvbXBvbmVudF0sXG4gIGRlY2xhcmF0aW9uczogW1xuICAgIE56RHJvcERvd25Db21wb25lbnQsXG4gICAgTnpEcm9wRG93bkJ1dHRvbkNvbXBvbmVudCxcbiAgICBOekRyb3BEb3duRGlyZWN0aXZlLFxuICAgIE56RHJvcERvd25BRGlyZWN0aXZlLFxuICAgIE56RHJvcGRvd25Db250ZXh0Q29tcG9uZW50XG4gIF0sXG4gIGV4cG9ydHM6IFtOek1lbnVNb2R1bGUsIE56RHJvcERvd25Db21wb25lbnQsIE56RHJvcERvd25CdXR0b25Db21wb25lbnQsIE56RHJvcERvd25EaXJlY3RpdmUsIE56RHJvcERvd25BRGlyZWN0aXZlXSxcbiAgcHJvdmlkZXJzOiBbTnpEcm9wZG93blNlcnZpY2VdXG59KVxuZXhwb3J0IGNsYXNzIE56RHJvcERvd25Nb2R1bGUge31cbiJdfQ==