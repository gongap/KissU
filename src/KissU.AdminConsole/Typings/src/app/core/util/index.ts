export { Util as util } from './util';
export { HttpContentType, HttpMethod } from "./angular/http-helper";
export { IKey, ViewModel, QueryParameter } from './core/model';
export { TreeViewModel, TreeQueryParameter } from './core/tree-model';
export { PagerList } from './core/pager-list';
export { Result, FailResult, StateCode } from './core/result';
export { SelectItem } from './core/select-model';
export { DicService } from './services/dic.service';
export { UploadService } from './services/upload.service';
export { IDialogOptions } from './common/dialog';
export { Session } from './security/session';
export { Authorize } from './security/authorize';
export { Authorize as OidcAuthorize } from './security/openid-connect/authorize';
export { AuthorizeService as OidcAuthorizeService } from './security/openid-connect/authorize-service';
export { AuthorizeConfig as OidcAuthorizeConfig } from './security/openid-connect/authorize-config';
export { ComponentBase } from './base/component-base';
export { FormComponentBase } from './base/form-component-base';
export { EditComponentBase } from './base/edit-component-base';
export { DialogEditComponentBase } from './base/dialog-edit-component-base';
export { DialogTreeEditComponentBase } from './base/dialog-tree-edit-component-base';
export { TableQueryComponentBase } from './base/table-query-component-base';
export { TableEditComponentBase } from './base/table-edit-component-base';
export { TreeTableQueryComponentBase } from './base/tree-table-query-component-base';

// #region components
//pipes
import { SafeUrlPipe } from './pipes/safe-url.pipe';
import { TruncatePipe } from "./pipes/truncate.pipe";
import { IsTruncatePipe } from "./pipes/is-truncate.pipe";

//viser componets
//import { LineWrapperComponent } from "./viser/line-wrapper.component";
//import { ColumnWrapperComponent } from "./viser/column-wrapper.component";
//import { BarWrapperComponent } from "./viser/bar-wrapper.component";
//import { AreaWrapperComponent } from "./viser/area-wrapper.component";
//import { PieWrapperComponent } from "./viser/pie-wrapper.component";
//import { RosePieWrapperComponent } from "./viser/rose-pie-wrapper.component";

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

export const UTIL_SHARED_COMPONENTS = [
    SafeUrlPipe, TruncatePipe, IsTruncatePipe,
    //LineWrapperComponent, ColumnWrapperComponent, BarWrapperComponent, AreaWrapperComponent,
    //PieWrapperComponent, RosePieWrapperComponent,
    Button, TextBox, DatePicker, TextArea, NumberTextBox,
    Select, Radio, CheckboxGroup,
    Table, Upload, SingleUpload,
    Tree, TreeSelect, TreeTable
];

export const UTIL_SHARED_DIRECTIVES = [
    EditTableDirective, EditRowDirective, EditControlDirective
];

// #endregion


