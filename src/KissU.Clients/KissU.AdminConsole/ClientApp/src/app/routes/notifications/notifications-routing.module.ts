import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NotificationsLayoutComponent } from './_layout/layout.component';
import { NotificationsInnerComponent } from './inner/inner.component';
import { NotificationsInnerDetailComponent } from './detail/detail.component';
import { NotificationsSubscribeComponent } from './subscribe/subscribe.component';
import { NotificationsTTSComponent } from './tts/tts.component';

const routes: Routes = [
  {
    path: '',
    component: NotificationsLayoutComponent,
    children: [
      { path: 'inner/all', redirectTo: 'inner/all/0', pathMatch: 'full' },
      { path: 'inner/unread', redirectTo: 'inner/unread/0', pathMatch: 'full' },
      { path: 'inner/read', redirectTo: 'inner/read/0', pathMatch: 'full' },
      { path: 'inner/:type/:index', component: NotificationsInnerComponent },
      { path: 'inner/:type/detail/:id', component: NotificationsInnerDetailComponent },
      { path: 'subscribe', component: NotificationsSubscribeComponent },
      { path: 'tts', component: NotificationsTTSComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ComponentRoutingModule {}
