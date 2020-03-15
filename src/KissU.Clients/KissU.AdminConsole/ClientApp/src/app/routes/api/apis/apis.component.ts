import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn, STData, STChange } from '@delon/abc';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'apis',
  templateUrl: './apis.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class APIsComponent {
  i: any = {
    q: '',
  };
  url = '/apis';
  columns: STColumn[] = [
    { title: '', type: 'checkbox' },
    {
      title: 'API名称',
      index: 'name',
      type: 'link',
      click: (i: STData) => this.toDetail(i),
    },
    {
      title: '类型',
      index: 'visibility',
      format: (i: STData) => (i.visibility === 'PRIVATE' ? '私有' : '公共'),
    },
    { title: '分组', index: 'group' },
    { title: '描述', index: 'description' },
    { title: '最后修改', index: 'modified', type: 'date' },
    { title: '运行环境', index: 'deployed' },
    {
      title: '操作',
      buttons: [
        {
          text: '管理',
          type: 'link',
          click: (i: STData) => this.toDetail(i),
        },
        {
          text: '删除',
          type: 'del',
          click: (i, modal, c) => {
            this.http.delete(this.url, { id: i.id }).subscribe(() => {
              this.msg.success('success');
              c.removeRow(i);
            });
          },
        },
        { text: '自定义示例代码', click: () => this.t() },
        { text: '发布', click: () => this.t() },
        { text: '授权', click: () => this.t() },
        { text: '下线', click: () => this.t() },
      ],
    },
  ];
  checkList: STData[] = [];

  constructor(private http: _HttpClient, private msg: NzMessageService) {}

  private toDetail(i: STData) {
    return `/api/detail/${i.id}`;
  }

  t() {
    this.msg.info('to');
  }

  change(e: STChange) {
    if (e.type === 'checkbox') {
      this.checkList = e.checkbox;
    }
  }
}
