import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn, STData, STChange } from '@delon/abc';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'api-authorization',
  templateUrl: './authorization.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class APIAuthorizationComponent {
  data: STData[] = [];
  columns: STColumn[] = [
    { title: '', type: 'checkbox' },
    { title: '应用ID', index: 'id' },
    { title: '应用名称', index: 'id' },
    { title: '环境', index: 'id' },
    { title: '授权时间', index: 'id' },
    { title: '授权者', index: 'id' },
    { title: '授权有效期', index: 'id' },
  ];
  checkList: STData[] = [];

  constructor(private msg: NzMessageService) {}

  t() {
    this.msg.info('to');
  }

  change(e: STChange) {
    if (e.type === 'checkbox') {
      this.checkList = e.checkbox;
    }
  }
}
