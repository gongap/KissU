import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn, STData, STChange } from '@delon/abc';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'dns-domain',
  templateUrl: './domain.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DnsDomainComponent {
  i: any = {
    group: '',
  };
  url = '/domain';
  columns: STColumn[] = [
    { title: '', type: 'checkbox' },
    {
      title: '域名',
      render: 'domain',
    },
    {
      title: '域名状态',
      render: 'status',
    },
    {
      title: '操作',
      buttons: [
        {
          text: '解析设置',
          type: 'link',
          click: (i: any) => `/dns/setting/${i.domain}`,
        },
        { text: 'SSL证书' },
        { text: '安全锁' },
        { text: '更多', children: [{ text: '升级VIP DNS' }] },
      ],
    },
  ];
  checkList: STData[] = [];

  constructor(private http: _HttpClient, private msg: NzMessageService) {}

  t() {
    this.msg.info('to');
  }

  change(e: STChange) {
    if (e.type === 'checkbox') {
      this.checkList = e.checkbox;
    }
  }

  // #region remark

  remarkVisible = false;
  remarkItem: any = {};
  remark = null;

  remarkOpen(i: any) {
    this.remarkItem = i;
    this.remark = i.remark;
    this.remarkVisible = true;
  }

  remarkSave() {
    this.http
      .post(this.url, {
        id: this.remarkItem.id,
        remark: this.remark,
      })
      .subscribe((res: any) => {
        this.remarkItem.remark = res.item.remark;
        this.remarkVisible = false;
        this.msg.success('Success');
      });
  }

  // #endregion
}
