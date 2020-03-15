import { Component, ChangeDetectionStrategy } from '@angular/core';
import { STColumn } from '@delon/abc';
import { SFSchema } from '@delon/form';

@Component({
  selector: 'dns-log',
  templateUrl: './log.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DnsLogComponent {
  params: any = {};
  searchSchema: SFSchema = {
    properties: {
      timeStart: {
        type: 'string',
        title: '',
        ui: { widget: 'date', end: 'timeEnd', width: 300, placeholder: '日期' },
      },
      timeEnd: {
        type: 'string',
      },
      type: {
        type: 'string',
        title: '',
        enum: [
          { label: '全部日志', value: '' },
          { label: '用户操作日志', value: 'user' },
          { label: '辅助DNS同步日志', value: 'sync' },
        ],
        default: '',
        ui: {
          widget: 'select',
          placeholder: '请选择日志类型',
        },
      },
      q: {
        type: 'string',
        title: '',
        ui: {
          placeholder: '关键字（如域名、行为、ip等）',
        },
      },
    },
  };

  url = '/domain/log';
  columns: STColumn[] = [
    { title: '操作时间(UTC+8)', index: 'time', type: 'date' },
    { title: '域名', index: 'domain' },
    { title: '操作行为', index: 'message' },
  ];
}
