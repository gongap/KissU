import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
// delon
import { AlainThemeModule } from '@delon/theme';
import { DelonABCModule } from '@delon/abc';
import { DelonACLModule } from '@delon/acl';
import { DelonFormModule } from '@delon/form';
// i18n
import { TranslateModule } from '@ngx-translate/core';

// #region third libs
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CountdownModule } from 'ngx-countdown';
import { ViserModule } from 'viser-ng';
const THIRDMODULES = [
  NgZorroAntdModule,
  CountdownModule,
  ViserModule
];
// #endregion

// #region your componets & directives
//viser componets
import { LineWrapperComponent } from "./viser/line-wrapper.component";
import { ColumnWrapperComponent } from "./viser/column-wrapper.component";
import { BarWrapperComponent } from "./viser/bar-wrapper.component";
import { AreaWrapperComponent } from "./viser/area-wrapper.component";
import { PieWrapperComponent } from "./viser/pie-wrapper.component";
import { RosePieWrapperComponent } from "./viser/rose-pie-wrapper.component";

//zorro componets
import { Button } from "./zorro/button-wrapper.component";
import { TextBox } from "./zorro/textbox-wrapper.component";
import { DatePicker } from "./zorro/datepicker-wrapper.component";
import { TextArea } from "./zorro/textarea-wrapper.component";
import { NumberTextBox } from "./zorro/number-textbox-wrapper.component";
import { Select } from "./zorro/select-wrapper.component";
import { Radio } from "./zorro/radio-wrapper.component";
import { CheckboxGroup } from "./zorro/checkbox-group-wrapper.component";
import { Table } from "./zorro/table-wrapper.component";
import { Upload } from "./zorro/upload-wrapper.component";
import { SingleUpload } from "./zorro/single-upload-wrapper.component";
import { Tree } from "./zorro/tree-wrapper.component";
import { TreeSelect } from "./zorro/tree-select-wrapper.component";
import { TreeTable } from "./zorro/tree-table-wrapper.component";

//directives
import { EditTableDirective } from "./zorro/edit-table.directive";
import { EditRowDirective } from "./zorro/edit-row.directive";
import { EditControlDirective } from "./zorro/edit-control.directive";

//pipes
import { SafeUrlPipe } from './pipes/safe-url.pipe';
import { TruncatePipe } from "./pipes/truncate.pipe";
import { IsTruncatePipe } from "./pipes/is-truncate.pipe";

const COMPONENTS = [
    SafeUrlPipe, TruncatePipe, IsTruncatePipe,
    LineWrapperComponent, ColumnWrapperComponent, BarWrapperComponent, AreaWrapperComponent,
    PieWrapperComponent, RosePieWrapperComponent,
    Button, TextBox, DatePicker, TextArea, NumberTextBox,
    Select, Radio, CheckboxGroup,
    Table, Upload, SingleUpload,
    Tree, TreeSelect, TreeTable
  ];
const DIRECTIVES = [
    EditTableDirective, EditRowDirective, EditControlDirective
];
// #endregion

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    AlainThemeModule.forChild(),
    DelonABCModule,
    DelonACLModule,
    DelonFormModule,
    // third libs
    ...THIRDMODULES
  ],
  declarations: [
    // your components
    ...COMPONENTS,
    ...DIRECTIVES
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    AlainThemeModule,
    DelonABCModule,
    DelonACLModule,
    DelonFormModule,
    // i18n
    TranslateModule,
    // third libs
    ...THIRDMODULES,
    // your components
    ...COMPONENTS,
    ...DIRECTIVES
  ]
})
export class SharedModule { }
