import {
  Component,
  ChangeDetectionStrategy,
  ElementRef,
  OnInit,
  OnDestroy,
  ChangeDetectorRef,
  Input,
  NgZone,
} from '@angular/core';
import { Subscription } from 'rxjs';
import * as format from 'date-fns/format';
import * as addSeconds from 'date-fns/add_seconds';
import { DataHealthyComponent } from '../healthy.component';

@Component({
  selector: 'data-healthy-internal',
  templateUrl: './internal.component.html',
  host: {
    '[class.card]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataHealthyInternalComponent implements OnInit, OnDestroy {
  private ref$: Subscription;
  private chart: any;
  private refTime: any;
  max = 20;
  loading = false;
  data = [];
  stat = [
    { key: 'x1', text: 'Download', color: '#a0d911', min: 0, max: 0, avg: 0, current: 0 },
    { key: 'x2', text: 'Upload', color: '#fadb14', min: 0, max: 0, avg: 0, current: 0 },
  ];

  constructor(private p: DataHealthyComponent, private ngZone: NgZone, private cdr: ChangeDetectorRef) {}

  render(er: ElementRef) {
    this.ngZone.runOutsideAngular(() => setTimeout(() => this.init(er.nativeElement), 50));
  }

  private genUnit(val: number) {
    return val === 0 ? `0 Bps` : val + 'MBps';
  }

  private init(container: HTMLElement) {
    const chart = (this.chart = new G2.Chart({
      container,
      forceFit: true,
      height: 182,
      padding: [16, 0, 32, 56],
    }));
    chart.tooltip({
      crosshairs: {
        type: 'line',
      },
    });
    chart.axis('value', {
      label: {
        formatter: val => this.genUnit(val),
      },
    });
    chart.scale('time', {
      tickCount: 6,
    });
    chart.legend(false);
    chart
      .area()
      .position('time*value')
      .tooltip('type*value', (type, val) => ({ name: type === 'x1' ? 'Read' : 'Write', value: this.genUnit(val) }))
      .color('type', ['#a0d911', '#fadb14'])
      .opacity(0.2);

    chart
      .line()
      .position('time*value')
      .tooltip(false)
      .color('type', ['#a0d911', '#fadb14'])
      .size(1);

    chart.render();

    this.attachData();
    this.refTime = this.ngZone.runOutsideAngular(() => setInterval(() => this.attachData(), 1000 * 5));
  }

  private genItem(second = 0) {
    return {
      time: format(addSeconds(new Date(), second), 'mm:ss'),
      x1: Math.floor(Math.random() * 101),
      x2: -Math.floor(Math.random() * 101),
    };
  }

  private initData() {
    this.data = new Array(this.max).fill({}).map((i, idx) => this.genItem(-(10 - idx)));
    if (this.chart) {
      this.ngZone.runOutsideAngular(() => this.attachData());
    }
  }

  private attachData() {
    const { chart, data, max } = this;
    if (data.length >= max) {
      data.shift();
    }
    data.push(this.genItem());
    const dv = new DataSet.DataView().source(data);
    dv.transform({
      type: 'fold',
      fields: ['x1', 'x2'],
      key: 'type',
      value: 'value',
    });
    chart.changeData(dv, {
      time: {
        range: [0, 1],
      },
    });
    this.statData();
  }

  private statData() {
    const { data, cdr, stat } = this;
    const dataClone = [...data];
    stat.forEach(i => {
      const sortData = dataClone.sort((a, b) => b[i.key] - a[i.key]);
      i.min = Math.abs(sortData[0][i.key]);
      i.max = Math.abs(sortData[sortData.length - 1][i.key]);
      i.avg = Math.abs(Math.ceil(dataClone.reduce((p, c) => (p += c[i.key]), 0) / dataClone.length));
      i.current = Math.abs(data[data.length - 1][i.key]);
    });
    cdr.detectChanges();
  }

  ngOnInit(): void {
    this.initData();
    this.ref$ = this.p.$refresh.subscribe(() => {
      this.initData();
    });
  }

  ngOnDestroy(): void {
    const { ref$, refTime } = this;
    ref$.unsubscribe();
    clearInterval(refTime);
  }
}
