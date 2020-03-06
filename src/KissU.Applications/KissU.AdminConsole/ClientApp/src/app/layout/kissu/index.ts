export * from './public_api';

// #region widgets

import { MSAllNavComponent } from './_widgets/all-nav/all-nav.component';
import { MSSearchComponent } from './_widgets/search/search.component';
import { MSLangsComponent } from './_widgets/langs/langs.component';
import { MSUserComponent } from './_widgets/user/user.component';
import { MSNoticeComponent } from './_widgets/notice/notice.component';
import { MSRegionComponent } from './_widgets/region/region.component';

const MS_WIDGETS = [
  MSAllNavComponent,
  MSSearchComponent,
  MSLangsComponent,
  MSUserComponent,
  MSNoticeComponent,
  MSRegionComponent,
];

// #endregion

// #region entry components

export const MS_ENTRYCOMPONENTS = [];

// #endregion

// #region components

import { KissULayoutComponent } from './kissu.component';
import { MSSidebarComponent } from './components/sidebar/sidebar.component';
import { MSTopbarComponent } from './components/topbar/topbar.component';

export const MS_COMPONENTS = [
  KissULayoutComponent,
  MSSidebarComponent,
  MSTopbarComponent,
  ...MS_ENTRYCOMPONENTS,
  ...MS_WIDGETS,
];

// #endregion

// #region shared components

import { MSHelpComponent } from './shared/help/help.component';
import { MSPageNavComponent } from './shared/page-nav/page-nav.component';
import { MSPageBarComponent } from './shared/page-bar/page-bar.component';
import { MSPageSingleComponent } from './shared/page-single/page-single.component';
import { MSServiceLayoutComponent } from './shared/service-layout/service-layout.component';
import { MSPanelComponent } from './shared/panel/panel.component';
import { MSLinkToDirective } from './shared/link-to/link-to.directive';

export const MS_SHARED_COMPONENTS = [
  MSHelpComponent,
  MSPageNavComponent,
  MSPageBarComponent,
  MSPageSingleComponent,
  MSPanelComponent,
  MSServiceLayoutComponent,
  MSLinkToDirective,
];

// #endregion
