import { Component, ChangeDetectionStrategy, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn, STData, STChange, STComponent } from '@delon/abc';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { DnsSettingEditComponent } from './edit/edit.component';

@Component({
  selector: 'dns-setting',
  templateUrl: './setting.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DnsSettingComponent {
  @ViewChild('st', { static: false }) st: STComponent;
  domain = '';
  i: any = {
    group: '',
  };
  url = '/dns/setting';
  columns: STColumn[] = [
    { title: '', type: 'checkbox' },
    { title: '记录类型', index: 'type', sort: true },
    { title: '主机记录', index: 'rR', sort: true },
    { title: '解析线路(isp)', format: () => `默认`, sort: true },
    { title: '记录值', index: 'value' },
    { title: 'MX优先级', format: () => `--` },
    { title: 'TTL', format: (i: any) => `${i.tTL / 60} 分钟` },
    {
      title: '状态',
      index: 'status',
      type: 'badge',
      badge: {
        ENABLE: { text: '正常', color: 'success' },
      },
    },
    {
      title: '操作',
      buttons: [
        {
          text: '修改',
          type: 'modal',
          modal: {
            component: DnsSettingEditComponent,
            paramsName: 'i',
            size: 'md',
          },
          click: 'load',
        },
        { text: '暂停' },
        { text: '删除', type: 'del', click: (i: STData) => this.remove(i.id) },
        { text: '备注' },
      ],
    },
  ];

  checkList: STData[] = [];

  get ids() {
    return this.checkList.map(i => i.id);
  }

  constructor(
    route: ActivatedRoute,
    private http: _HttpClient,
    private msg: NzMessageService,
    private modal: ModalHelper,
    private cdr: ChangeDetectorRef,
  ) {
    this.domain = route.snapshot.params.domain;
  }

  add() {
    this.modal.create(DnsSettingEditComponent, null, { size: 'md' }).subscribe(() => this.st.load());
  }

  remove(id: number | number[]) {
    const isBatch = Array.isArray(id);
    this.http.delete(this.url, { id: isBatch ? (id as number[]).join(',') : id }).subscribe(() => {
      this.st.load();
      if (isBatch) {
        this.checkList.length = 0;
        this.cdr.detectChanges();
      }
    });
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
