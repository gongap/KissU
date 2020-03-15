import { Component, ChangeDetectionStrategy, ViewChild } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn, STComponent, STChange, STData } from '@delon/abc';
import { SFSchema } from '@delon/form';

@Component({
  selector: 'component-table',
  templateUrl: './table.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompTableComponent {
  @ViewChild('st', { static: true }) private st: STComponent;

  tabs = ['全部域名', '急需续费域名', '急需赎回域名', '未实名认证域名', '预登记域名'];

  params: any = {};

  searchSchema: SFSchema = {
    properties: {
      domain: {
        type: 'string',
        title: '域名',
        ui: { placeholder: '输入域名进行搜索' },
      },
      domainType: {
        type: 'string',
        title: '域名类型',
        enum: [
          { label: '全部', value: '' },
          { label: 'New gTLD', value: 'New gTLD' },
          { label: 'gTLD', value: 'gTLD' },
          { label: 'ccTLD', value: 'ccTLD' },
          { label: '其他', value: 'Other' },
        ],
        default: '',
      },
      domainGroup: {
        type: 'string',
        title: '域名分组',
        enum: [{ label: '全部', value: '' }, { label: '未分组', value: 'Other' }],
        default: '',
      },
      registrantDateStart: {
        type: 'string',
        title: '注册日期',
        ui: { widget: 'date', end: 'registrantDateEnd' },
      },
      registrantDateEnd: {
        type: 'string',
      },
      expirationDateStart: {
        type: 'string',
        title: '到期日期',
        ui: { widget: 'date', end: 'expirationDateEnd' },
      },
      expirationDateEnd: {
        type: 'string',
      },
    },
  };

  url = '/domain';
  columns: STColumn[] = [
    { title: '', type: 'checkbox' },
    {
      title: '域名',
      index: 'domain',
      type: 'link',
      click: (i: any) => this.msg.success(`To ${i.domain}`),
    },
    { title: '域名类型', index: 'domainType' },
    { title: '域名状态', index: 'status' },
    { title: '注册日期', index: 'registrantDate', type: 'date', sort: true },
    { title: '到期日期', index: 'expirationDate', type: 'date', sort: true },
    {
      title: '操作',
      buttons: [{ text: '续费' }, { text: '解析' }, { text: '安全锁' }, { text: '备注' }, { text: '管理' }],
    },
  ];

  checkList: STData[] = [];

  constructor(public msg: NzMessageService) {}

  changeType(index: number) {
    this.params.type = index;
    this.st.reload(this.params);
  }

  change(e: STChange) {
    if (e.type === 'checkbox') {
      this.checkList = e.checkbox;
    }
  }
}
