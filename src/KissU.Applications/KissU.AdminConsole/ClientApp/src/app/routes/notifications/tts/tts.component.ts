import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'notifications-tts',
  templateUrl: './tts.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NotificationsTTSComponent {
  data = [
    {
      title: '消息类型一',
      linkName: 'asdf',
      expand: true,
      tts: {
        value: true,
        disabled: true,
      },
      children: [
        {
          title: '子类型一',
          linkName: 'asdf',
          tip: '这是一段额外描述',
          tts: {
            value: true,
            disabled: true,
          },
        },
        {
          title: '子类型二',
          linkName: 'asdf',
          tts: {
            value: false,
          },
        },
      ],
    },
    {
      title: '消息类型二',
      linkName: 'asdf',
      expand: true,
      tts: {
        value: true,
      },
      children: [
        {
          title: '子类型一',
          linkName: 'asdf',
          tts: {
            value: true,
          },
        },
      ],
    },
  ];
}
