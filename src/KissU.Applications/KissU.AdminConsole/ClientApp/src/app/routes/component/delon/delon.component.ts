import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumnBadge, STColumnTag, STColumn } from '@delon/abc';
import { SFSchema } from '@delon/form';

const BADGE: STColumnBadge = {
  1: { text: '成功', color: 'success' },
  2: { text: '错误', color: 'error' },
  3: { text: '进行中', color: 'processing' },
  4: { text: '默认', color: 'default' },
  5: { text: '警告', color: 'warning' },
};
const TAG: STColumnTag = {
  1: { text: '成功', color: 'green' },
  2: { text: '错误', color: 'red' },
  3: { text: '进行中', color: 'blue' },
  4: { text: '默认', color: '' },
  5: { text: '警告', color: 'orange' },
};
const r = (min: number, max: number) => Math.floor(Math.random() * (max - min + 1) + min);

@Component({
  selector: 'component-delon',
  templateUrl: './delon.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompDelonComponent {
  i: any = {
    ak: 'xxxxx',
  };

  // #region st
  users: any[] = [];
  columns: STColumn[] = [
    { title: '行号', type: 'no' },
    { title: '姓名', index: 'name' },
    { title: '年龄', index: 'age', type: 'number' },
    { title: 'tag', index: 'tag', type: 'tag', tag: TAG },
    { title: 'badge', index: 'badge', type: 'badge', badge: BADGE },
    { title: 'yn', index: 'yn', type: 'yn' },
  ];

  reload() {
    this.users = Array(5)
      .fill({})
      .map((item: any, idx: number) => {
        return {
          id: idx + 1,
          name: `name ${idx + 1}`,
          age: r(10, 50),
          tag: r(1, 5),
          badge: r(1, 5),
          yn: [true, false][r(1, 5) % 2],
        };
      });
  }

  // #endregion

  // #region sf

  schema: SFSchema = {
    properties: {
      id1: { type: 'number', ui: { widget: 'text' } },
      id2: {
        type: 'number',
        ui: { widget: 'text', defaultText: 'default text' },
      },
      name: {
        type: 'string',
        title: 'Name',
        ui: {
          addOnAfter: 'RMB',
          placeholder: 'RMB结算',
        },
      },
      datetime: {
        type: 'string',
        format: 'date-time',
      },
      unit: { type: 'number', default: 10, ui: { unit: '%' } },
      status: {
        type: 'string',
        title: '状态',
        enum: [
          { label: '待支付', value: 'WAIT_BUYER_PAY' },
          { label: '已支付', value: 'TRADE_SUCCESS' },
          { label: '交易完成', value: 'TRADE_FINISHED' },
        ],
        default: 'WAIT_BUYER_PAY',
        ui: {
          widget: 'select',
        },
      },
      single: {
        type: 'boolean',
        title: '同意本协议',
        ui: {
          widget: 'checkbox',
        },
        default: true,
      },
    },
    required: ['name'],
  };

  sfSubmit(value: any) {
    this.msg.success(JSON.stringify(value));
  }

  // #endregion

  constructor(public msg: NzMessageService) {
    this.reload();
  }
}
