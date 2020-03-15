import { Component, ChangeDetectionStrategy } from '@angular/core';
import { STColumn } from '@delon/abc';
import { enabledLastYear } from '@core';
import { applyCC } from '@shared';

@Component({
  selector: 'finance-bill-list',
  templateUrl: './list.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FinanceBillListComponent {
  params = {
    month: new Date(),
    type: 1,
    q: '',
  };
  disabledDate = enabledLastYear;
  list = [];
  columns: STColumn[] = applyCC([
    {
      title: '月份',
      index: 'month',
      fixed: 'left',
      width: 80,
      ccChecked: false,
    },
    {
      title: '账号',
      index: 'email',
      fixed: 'left',
      width: 120,
      ccDisabled: true,
    },
    { title: '项目类型', index: 'type' },
    { title: '消费方式', index: 'charge' },
    { title: '商品名称', index: 'name' },
    { title: '价格项一', index: 'price1', type: 'currency', ccChecked: false },
    { title: '价格项二', index: 'price2', type: 'currency' },
    { title: '价格项三', index: 'price3', type: 'currency' },
    { title: '价格项四', index: 'price4', type: 'currency' },
    { title: '价格项五', index: 'price5', type: 'currency' },
    {
      title: '价格项六',
      index: 'price6',
      type: 'currency',
      fixed: 'right',
      width: 150,
    },
  ]);
}
