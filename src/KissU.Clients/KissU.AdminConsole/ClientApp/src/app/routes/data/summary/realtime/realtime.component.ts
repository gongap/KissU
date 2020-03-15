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
import { _HttpClient } from '@delon/theme';
import { DataSummaryComponent } from '../summary.component';

@Component({
  selector: 'data-summary-realtime',
  templateUrl: './realtime.component.html',
  host: {
    '[class.card]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataSummaryRealtimeComponent implements OnInit, OnDestroy {
  private ref$: Subscription;
  private chart: any;
  private refTime: any;
  max = 10;
  data = [];

  constructor(private p: DataSummaryComponent, public http: _HttpClient, private ngZone: NgZone) {}

  render(er: ElementRef) {
    this.ngZone.runOutsideAngular(() => setTimeout(() => this.init(er.nativeElement), 50));
  }

  private init(container: HTMLElement) {
    const chart = (this.chart = new G2.Chart({
      container,
      forceFit: true,
      height: 182,
      padding: 'auto',
    }));
    chart.source([], {
      time: {
        alias: '时间',
        type: 'time',
        mask: 'MM:ss',
        tickCount: 10,
        nice: false,
      },
      count: {
        alias: '访问量',
        min: 10,
        max: 35,
      },
      type: {
        type: 'cat',
      },
    });
    chart
      .line()
      .position('time*count')
      .color('#00c1de')
      .shape('smooth')
      .size(2);

    chart.render();

    this.refTime = setInterval(() => this.attachData(), 1000 * 3);
  }

  private attachData() {
    const { chart, data, max } = this;
    if (data.length >= max) {
      data.shift();
    }
    data.push({
      time: +new Date(),
      // tslint:disable-next-line: no-bitwise
      count: ~~(Math.random() * 5) + 22,
    });
    chart.changeData(data);
  }

  ngOnInit(): void {
    this.ref$ = this.p.$refresh.subscribe(() => {
      this.data.length = 0;
      this.ngZone.runOutsideAngular(() => this.attachData());
    });
  }

  ngOnDestroy(): void {
    const { ref$, refTime } = this;
    ref$.unsubscribe();
    clearInterval(refTime);
  }
}
