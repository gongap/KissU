import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
// delon
import { AlainThemeModule } from '@delon/theme';
import { DelonABCModule } from '@delon/abc';
import { DelonChartModule } from '@delon/chart';
import { DelonACLModule } from '@delon/acl';
import { DelonFormModule } from '@delon/form';
import { DelonUtilModule } from '@delon/util';

// #region third libs
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CountdownModule } from 'ngx-countdown';
import { NgxImageGalleryModule } from 'ngx-image-gallery';

const THIRDMODULES = [NgZorroAntdModule, CountdownModule, NgxImageGalleryModule];
// #endregion

// #region your componets & directives
import { MS_SHARED_COMPONENTS } from '../layout/ms';
import { LangsComponent } from './components/langs/langs.component';
import { EditorComponent } from './components/editor/editor.component';
import { ImgComponent } from './components/img/img.component';
import { ImgDirective } from './components/img/img.directive';
import { DelayDirective } from './components/delay/delay.directive';
import { MasonryDirective } from './components/masonry/masonry.directive';
import { ScrollbarDirective } from './components/scrollbar/scrollbar.directive';
import { FileManagerComponent } from './components/file-manager/file-manager.component';
import { StatusLabelComponent } from './components/status-label/status-label.component';
import { CaptchaBtnComponent } from './components/captcha-btn/captcha-btn.component';
import { MouseFocusDirective } from './components/mouse-focus/mouse-focus.directive';
import { FooterCopyrightComponent } from './components/footer-copyright/footer-copyright.component';
import { FooterGlobalComponent } from './components/footer-global/footer-global.component';
import { AddressComponent } from './components/address/address.component';
import { CustomColumnComponent } from './components/custom-column/custom-column.component';
import { CustomColumnModalComponent } from './components/custom-column/custom-column-modal.component';

const COMPONENTS_ENTRY = [
  LangsComponent,
  ImgComponent,
  FileManagerComponent,
  StatusLabelComponent,
  CaptchaBtnComponent,
  FooterCopyrightComponent,
  FooterGlobalComponent,
  AddressComponent,
  CustomColumnComponent,
  CustomColumnModalComponent,
];
const COMPONENTS = [EditorComponent, ...COMPONENTS_ENTRY, ...MS_SHARED_COMPONENTS];
const DIRECTIVES = [ImgDirective, DelayDirective, MasonryDirective, ScrollbarDirective, MouseFocusDirective];
// #endregion

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    AlainThemeModule.forChild(),
    DelonABCModule,
    DelonChartModule,
    DelonACLModule,
    DelonFormModule,
    DelonUtilModule,
    // third libs
    ...THIRDMODULES,
  ],
  declarations: [
    // your components
    ...COMPONENTS,
    ...DIRECTIVES,
  ],
  entryComponents: COMPONENTS_ENTRY,
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    AlainThemeModule,
    DelonABCModule,
    DelonChartModule,
    DelonACLModule,
    DelonFormModule,
    // third libs
    ...THIRDMODULES,
    // your components
    ...COMPONENTS,
    ...DIRECTIVES,
  ],
})
export class SharedModule {}
