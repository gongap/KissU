import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzModalRef } from 'ng-zorro-antd';

@Component({
  selector: 'home-custom',
  templateUrl: './custom.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DashboardHomeCustomComponent {
  panels = [
    {
      name: '新产品快报',
      list: [
        {
          tip: '新版本/新规格',
          text: '云数据库POLARDB 新增多款计算型规格，最高可达88核',
        },
        {
          tip: '新版本/新规格',
          text: '云数据库POLARDB 新增多款计算型规格，最高可达88核',
        },
        {
          tip: '新版本/新规格',
          text: '云数据库POLARDB 新增多款计算型规格，最高可达88核',
        },
      ],
      key: 'yunqi',
      selected: true,
    },
    {
      name: 'XXX头条',
      list: [
        {
          tip: '头条',
          text: '这次双11你可能已经成为首批IPv6用户，还不知道？',
        },
        {
          tip: '热点',
          text: '深度解读阿里巴巴云原生镜像分发系统 Dragonfly',
        },
        {
          tip: '热点',
          text: 'HBase技术与应用实践 | HBase2.0重新定义小对象实时存取',
        },
      ],
      key: 'yunqi',
    },
    {
      name: '安全情报',
      list: [
        {
          tip: '公告',
          text: 'Xen/QEMU内存越界访问漏洞',
        },
        {
          tip: '专题',
          text: '4万加密勒索事件频发，如何防范',
        },
      ],
      key: 'anquan',
    },
  ];

  constructor(private mr: NzModalRef) {}

  save() {
    this.mr.close(this.panels.filter(w => w.selected).map(i => i.key));
  }

  cancel() {
    this.mr.close();
  }
}
