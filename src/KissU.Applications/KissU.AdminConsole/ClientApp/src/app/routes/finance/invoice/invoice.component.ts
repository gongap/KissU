import { Component, ChangeDetectionStrategy } from '@angular/core';
import { STColumn, XlsxService } from '@delon/abc';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'finance-invoice',
  templateUrl: './invoice.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FinanceInvoiceComponent {
  i = {
    start: null,
    end: null,
    status: 1,
    q: '',
  };
  columns: STColumn[] = [
    { title: '时间', index: 'time' },
    { title: '发票抬头', index: 'name' },
    { title: '金额', index: 'price1' },
    {
      title: '发票状态',
      index: 'status',
      type: 'badge',
      badge: {
        1: { text: '开票中', color: 'processing' },
        2: { text: '已开票', color: 'success' },
        3: { text: '已作废', color: 'error' },
      },
    },
    {
      title: '操作',
      buttons: [
        {
          text: '详情',
          click: item => this.msg.info(`to ${item.name}`),
        },
        {
          text: '导出明细',
          click: item => {
            this.xlsxSrv.export({
              filename: `${item.name}-明细.xlsx`,
              sheets: [
                {
                  name: item.name,
                  data: [['A1', 'B1'], ['1', '1'], ['2', '2']],
                },
              ],
            });
          },
        },
      ],
    },
  ];

  constructor(private msg: NzMessageService, private xlsxSrv: XlsxService) {}
}
