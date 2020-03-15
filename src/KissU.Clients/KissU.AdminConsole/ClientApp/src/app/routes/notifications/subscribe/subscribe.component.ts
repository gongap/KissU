import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'notifications-subscribe',
  templateUrl: './subscribe.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NotificationsSubscribeComponent {
  data = [
    {
      title: '消息类型一',
      linkName: 'asdf',
      expand: true,
      innerMsg: {
        value: true,
        disabled: true,
      },
      email: {
        value: true,
        disabled: true,
      },
      sms: {
        value: true,
        disabled: true,
      },
      children: [
        {
          title: '子类型一',
          linkName: 'asdf',
          tip: '这是一段额外描述',
          innerMsg: {
            value: true,
            disabled: true,
          },
          email: {
            value: true,
            disabled: true,
          },
          sms: {
            value: true,
          },
        },
        {
          title: '子类型二',
          linkName: 'asdf',
          innerMsg: {
            value: false,
          },
          email: {
            value: true,
          },
          sms: {
            value: true,
          },
        },
      ],
    },
    {
      title: '消息类型二',
      linkName: 'asdf',
      expand: true,
      innerMsg: {
        value: true,
      },
      email: {
        value: true,
      },
      sms: {
        value: true,
      },
      children: [
        {
          title: '子类型一',
          linkName: 'asdf',
          innerMsg: {
            value: true,
          },
          email: {
            value: true,
          },
          sms: {
            value: true,
          },
        },
      ],
    },
  ];
}
