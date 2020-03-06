import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn, STData, STChange } from '@delon/abc';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'api-definition',
  templateUrl: './definition.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class APIDefinitionComponent {
  paramData: STData[] = [
    { name: 'id', location: 'QUERY', type: 'int', required: true, default: '1', demo: '1', desc: '编号' },
    { name: 'name', location: 'BODY', type: 'string', required: false, demo: 'asdf', desc: '名称' },
  ];
  paramColumns: STColumn[] = [
    { title: '参数名', index: 'name' },
    { title: '参数位置', index: 'location' },
    { title: '类型', index: 'type' },
    { title: '必填', index: 'required', type: 'yn' },
    { title: '默认值', index: 'default', default: '-' },
    { title: '示例', index: 'demo' },
    { title: '描述', index: 'desc' },
    { title: '更多', render: 'more' },
  ];

  errData: STData[] = [
    { code: 400, text: 'Missing User1', desc: '无效用户1' },
    { code: 401, text: 'Missing User2', desc: '无效用户2' },
  ];
  errColumns: STColumn[] = [
    { title: '错误码', index: 'code' },
    { title: '错误信息', index: 'text' },
    { title: '描述', index: 'desc' },
  ];

  constructor(private msg: NzMessageService) {}

  t() {
    this.msg.info('to');
  }
}
