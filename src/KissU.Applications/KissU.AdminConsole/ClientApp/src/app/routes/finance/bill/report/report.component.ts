import { Component, ChangeDetectionStrategy, ElementRef, NgZone } from '@angular/core';
import { STColumn } from '@delon/abc';
import { enabledLastYear } from '@core';
import { applyCC } from '@shared';
import { Random } from 'mockjs';
import { take } from 'rxjs/operators';

@Component({
  selector: 'finance-bill-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FinanceBillReportComponent {
  chartCog = {
    show: true,
    type: 1,
  };
  month = new Date();
  disabledDate = enabledLastYear;
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

  constructor(private ngZone: NgZone) {}

  // #region chart

  chart: any;

  render(er: ElementRef) {
    this.ngZone.onStable
      .asObservable()
      .pipe(take(1))
      .subscribe(() => this.ngZone.runOutsideAngular(() => this.init(er.nativeElement)));
  }

  private init(container: HTMLElement) {
    const chart = (this.chart = new G2.Chart({
      container,
      forceFit: true,
      height: 270,
      padding: [0, 48, 24, 48],
    }));

    chart.axis('value', false);

    chart
      .intervalStack()
      .position('year*value')
      .color('type', ['#fadb14', '#52c41a', '#b37feb', '#b5f5ec', '#00c1de']);

    chart.legend(false);
    chart.render();

    this.typeChange();
  }

  typeChange() {
    if (this.chartCog.type === 1) {
      this.attachTypeData();
    } else {
      this.attachProductData();
    }
  }

  private attachTypeData() {
    const { chart } = this;

    chart.tooltip({
      htmlContent: (title: string, items: any[]) => {
        return `<div class="g2-tooltip">
          <div class="g2-tooltip-title" style="margin-bottom: 4px;">
            ${title}
            <span>总计：${items.reduce((p, c) => (p += +c.value), 0)}</span>
          </div>
          <div class="g2-tooltip-list">
            <p style="color: ${items[0].color}">项目一：${+items[0].value}</p>
            <p style="color: ${items[1].color}">项目二：${+items[1].value}</p>
            <p style="color: ${items[2].color}">项目三：${+items[2].value}</p>
            <p style="color: ${items[3].color}">项目四：${+items[3].value}</p>
            <p style="color: ${items[4].color}">项目五：${+items[4].value}</p>
          </div>
        </div>`;
      },
    });

    // Mock data
    const year = new Date().getFullYear();
    const data = new Array(6).fill({}).map((i, idx) => {
      const item: any = {
        year: `${year}-${idx + 1}`,
        item1: Random.integer(0, 10),
        item2: Random.integer(0, 50),
        item3: Random.integer(0, 80),
        item4: Random.integer(0, 100),
        item5: Random.integer(0, 300),
      };
      return item;
    });
    const dv = new DataSet.DataView();
    dv.source(data).transform({
      type: 'fold',
      fields: ['item1', 'item2', 'item3', 'item4', 'item5'],
      key: 'type',
      value: 'value',
      retains: ['year'],
    });

    chart.source(dv);
    chart.repaint();
  }

  private attachProductData() {
    const { chart } = this;

    chart.tooltip({
      htmlContent: (title: string, items: any[]) => {
        return `<div class="g2-tooltip">
          <div class="g2-tooltip-title" style="margin-bottom: 4px;">${title}</div>
          <div class="g2-tooltip-list">
            <p style="color: ${items[0].color}">产品一：${+items[0].value}</p>
            <p style="color: ${items[1].color}">产品二：${+items[1].value}</p>
          </div>
        </div>`;
      },
    });

    // Mock data
    const year = new Date().getFullYear();
    const data = new Array(6).fill({}).map((i, idx) => {
      const item: any = {
        year: `${year}-${idx + 1}`,
        product1: Random.integer(0, 10),
        product2: Random.integer(0, 100),
      };
      return item;
    });
    const dv = new DataSet.DataView();
    dv.source(data).transform({
      type: 'fold',
      fields: ['product1', 'product2'],
      key: 'type',
      value: 'value',
      retains: ['year'],
    });

    chart.source(dv);
    chart.repaint();
  }

  // #endregion
}
