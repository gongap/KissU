import { Component, OnInit } from '@angular/core';
import { MSServiceNavConfig, MSMenu } from '@brand';
import { _HttpClient } from '@delon/theme';
import { NotificationsService, NotificationsCount } from '../_core/notifications.service';

@Component({
  selector: 'notifications-layout',
  template: `
    <service-layout *ngIf="navList" nav [navConfig]="navConfig" [navList]="navList">
      <router-outlet></router-outlet>
    </service-layout>
  `,
})
export class NotificationsLayoutComponent implements OnInit {
  nav = true;
  navConfig: MSServiceNavConfig = {
    titleI18n: 'notifications.title',
    docI18n: 'notifications.title.doc',
  };
  navList: MSMenu[];

  constructor(private srv: NotificationsService) {}

  private genNavList(unread: number) {
    this.navList = [
      {
        text: '',
        i18n: 'notifications.menu.inner',
        children: [
          {
            text: '',
            i18n: 'notifications.menu.inner.all',
            link: '/notifications/inner/all',
          },
          {
            text: '',
            i18n: 'notifications.menu.inner.unread',
            link: '/notifications/inner/unread',
            badge: unread,
          },
          {
            text: '',
            i18n: 'notifications.menu.inner.read',
            link: '/notifications/inner/read',
          },
        ],
      },
      {
        text: '',
        i18n: 'notifications.menu.manage',
        children: [
          {
            text: '',
            i18n: 'notifications.menu.manage.subscribe',
            link: '/notifications/subscribe',
          },
          {
            text: '',
            i18n: 'notifications.menu.manage.tts',
            link: '/notifications/tts',
          },
        ],
      },
    ];
  }

  ngOnInit(): void {
    this.srv.count.subscribe(res =>
      this.genNavList(res.reduce((p: number, c: NotificationsCount) => (p += c.unread), 0)),
    );
  }
}
