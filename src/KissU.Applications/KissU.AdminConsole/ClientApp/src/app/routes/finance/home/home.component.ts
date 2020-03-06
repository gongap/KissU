import { Component, ChangeDetectionStrategy, ElementRef, NgZone } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { Random } from 'mockjs';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'finance-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FinanceHomeComponent {
  chart: any;
  year = new Date().getFullYear();
  status = {
    i1: false,
    i2: false,
    i3: true,
  };

  constructor(private http: _HttpClient, private msg: NzMessageService, private ngZone: NgZone) {}

  updateStatus(type: string, value: boolean) {
    this.msg.info(`${type}: ${value}`);
  }

  render(er: ElementRef) {
    this.ngZone.runOutsideAngular(() => this.init(er.nativeElement));
  }

  private init(container: HTMLElement) {
    const chart = (this.chart = new G2.Chart({
      container,
      forceFit: true,
      height: 300,
    }));

    chart
      .interval()
      .position('year*value')
      .color('type', ['#00c1de', '#ff8a00'])
      .adjust([
        {
          type: 'dodge',
          marginRatio: 0,
        },
      ]);
    chart.tooltip({
      offset: 50,
      htmlContent: (title: string, items: any[]) => {
        const item1Price = +items[0].value;
        const item2Price = +items[1].value;
        const other = items[0].point._origin.other;
        return `<div class="g2-tooltip chart-tooltip">
          <div class="g2-tooltip-title" style="margin-bottom: 4px;">${title}</div>
          <div class="arrow"><span></span></div>
          <div class="content">
            <p>项目一：${item1Price}</p>
            <p>项目二：${item2Price}</p>
            <p>其他金额：${other}</p>
            <p>计算公式：${item1Price} + ${item2Price} = ${item1Price + item2Price}</p>
          </div>
        </div>`;
      },
    });
    chart.legend({
      custom: true,
      items: [
        { value: '项目一', marker: { symbol: 'square', fill: '#00c1de' } },
        { value: '项目二', marker: { symbol: 'square', fill: '#ff8a00' } },
      ],
    });
    chart.render();

    this.attachData();
  }

  private mockData() {
    // Mock data
    const data = new Array(12).fill({}).map((i, idx) => {
      const item: any = {
        year: `${this.year}-${idx + 1}`,
        // 项目一
        item1: 0,
        // 项目二
        item2: 0,
        other: 0,
      };
      if (Random.boolean()) {
        item.item1 = Random.integer(1, 1000);
        item.item2 = Random.integer(1, 1000);
        item.other = Random.integer(1, 1000);
      }
      return item;
    });

    return data;
  }

  private attachData() {
    const { chart } = this;
    // Mock data
    const data = this.mockData();

    const dv = new DataSet.DataView();
    dv.source(data).transform({
      type: 'fold',
      fields: ['item1', 'item2'],
      key: 'type',
      value: 'value',
      retains: ['year', 'other'],
    });

    chart.source(dv);
    chart.repaint();
  }
}
