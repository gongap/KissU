import {
  Component,
  ChangeDetectionStrategy,
  ElementRef,
  OnInit,
  OnDestroy,
  ChangeDetectorRef,
  NgZone,
} from '@angular/core';
import { Subscription } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd';
import * as format from 'date-fns/format';
import * as addDays from 'date-fns/add_days';

import { _HttpClient } from '@delon/theme';
import { DataSummaryComponent } from '../summary.component';

@Component({
  selector: 'data-summary-month',
  templateUrl: './month.component.html',
  host: {
    '[class.card]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataSummaryMonthComponent implements OnInit, OnDestroy {
  private ref$: Subscription;
  private chart: any;
  loading = true;
  data = [];
  time: Date;

  constructor(
    private p: DataSummaryComponent,
    public http: _HttpClient,
    public msg: NzMessageService,
    private ngZone: NgZone,
    private cdr: ChangeDetectorRef,
  ) {}

  render(er: ElementRef) {
    this.ngZone.runOutsideAngular(() => setTimeout(() => this.init(er.nativeElement), 250));
  }

  private init(container: HTMLElement) {
    const chart = (this.chart = new G2.Chart({
      container,
      forceFit: true,
      height: 160,
      padding: [16, 16, 24, 32],
    }));
    chart.source([]);
    chart.scale({
      time: {
        alias: '日期',
      },
      num: {
        alias: '过期活动（个）',
      },
    });
    chart.axis('time', {
      label: {
        formatter: (value: string) => format(value, 'MM-DD'),
      },
    });
    chart.tooltip({
      showTitle: false,
    });
    chart.legend(false);
    chart
      .point()
      .position('time*num')
      .size('num', [4, 14])
      .shape('circle')
      .tooltip('time*num')
      .color('time', (time: string) => this.genType(time).color)
      .style('time', {
        lineWidth: 1,
        strokeOpacity: 1,
        fillOpacity: 0.3,
        opacity: 0.8,
        stroke: (time: string) => this.genType(time).color,
      });

    chart.render();

    this.attachData();
  }

  private genType(time: string) {
    const now = new Date();
    if (time >= format(addDays(now, 15), 'YYYY-MM-DD')) {
      return { color: '#bfbfbf', text: '15天~30天' };
    } else if (time >= format(addDays(now, 7), 'YYYY-MM-DD')) {
      return { color: '#00c1de', text: '7天~15天' };
    } else if (time >= format(addDays(now, 3), 'YYYY-MM-DD')) {
      return { color: '#faad14', text: '3天~7天' };
    }
    return { color: '#f5222d', text: '3天内' };
  }

  private genGroup(data: any[]) {
    this.data = data
      .slice(0)
      .map(i => ({ ...i, ...this.genType(i.time) }))
      .reduce((p: any[], c) => {
        let item = p.find(w => w.text === c.text);
        if (!item) {
          item = { text: c.text, color: c.color, num: 0 };
          p.push(item);
        }
        item.num += c.num;
        return p;
      }, []);
  }

  private attachData() {
    const { chart, ngZone } = this;
    ngZone.run(() => {
      this.loading = true;
      this.cdr.detectChanges();
    });
    this.http.get('/summary/month').subscribe((res: any) => {
      ngZone.run(() => {
        this.genGroup(res);
        this.time = new Date();
        this.loading = false;
        this.cdr.detectChanges();
      });
      ngZone.runOutsideAngular(() => chart.changeData(res));
    });
  }

  ngOnInit(): void {
    this.ref$ = this.p.$refresh.subscribe(() => this.ngZone.runOutsideAngular(() => this.attachData()));
  }

  ngOnDestroy(): void {
    this.ref$.unsubscribe();
  }
}
