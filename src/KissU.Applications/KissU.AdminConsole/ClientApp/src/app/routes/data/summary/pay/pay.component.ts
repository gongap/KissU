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
import { _HttpClient } from '@delon/theme';
import { DataSummaryComponent } from '../summary.component';

@Component({
  selector: 'data-summary-pay',
  templateUrl: './pay.component.html',
  host: {
    '[class.card]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataSummaryPayComponent implements OnInit, OnDestroy {
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
    this.ngZone.runOutsideAngular(() => setTimeout(() => this.init(er.nativeElement), 50));
  }

  private init(container: HTMLElement) {
    const chart = (this.chart = new G2.Chart({
      container,
      forceFit: true,
      height: 160,
      padding: 0,
    }));
    chart.legend(false);
    chart.coord('theta', {
      radius: 0.75,
    });

    chart
      .intervalStack()
      .position('count')
      .color('text', ['#00c1de50', '#00c1de'])
      .opacity(1)
      .label('percent', {
        textStyle: {
          fill: '#1890ff',
        },
        formatter: (val: any, item: any) => `${item.point.text}: ${item.point.count} 笔`,
      });

    chart.render();

    this.attachData();
  }

  private attachData() {
    const { chart, ngZone } = this;
    ngZone.run(() => {
      this.loading = true;
      this.cdr.detectChanges();
    });
    this.http.get('/summary/pay').subscribe((res: any) => {
      ngZone.run(() => {
        this.time = new Date();
        this.loading = false;
        this.cdr.detectChanges();
      });
      ngZone.runOutsideAngular(() => {
        const ds = new DataSet();
        const dv = ds.createView().source(res);
        dv.transform({
          type: 'percent',
          field: 'count',
          dimension: 'text',
          as: 'percent',
        });
        chart.changeData(dv);
      });
    });
  }

  ngOnInit(): void {
    this.ref$ = this.p.$refresh.subscribe(() => this.ngZone.runOutsideAngular(() => this.attachData()));
  }

  ngOnDestroy(): void {
    this.ref$.unsubscribe();
  }
}
