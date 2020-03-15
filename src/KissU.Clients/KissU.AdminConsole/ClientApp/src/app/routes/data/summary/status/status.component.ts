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
  selector: 'data-summary-status',
  templateUrl: './status.component.html',
  host: {
    '[class.card]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataSummaryStatusComponent implements OnInit, OnDestroy {
  private ref$: Subscription;
  private chart: any;
  loading = true;
  data = [];
  sum = 0;
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
      padding: 'auto',
    }));
    chart.tooltip(true, {
      showTitle: false,
      inPlot: false,
    });
    chart.legend(false);
    chart.coord('theta', {
      radius: 1,
      innerRadius: 0.8,
    });
    chart
      .intervalStack()
      .position('num')
      .opacity(1);

    chart.render();

    this.attachData();
  }

  private attachData() {
    const { chart, ngZone } = this;
    ngZone.run(() => {
      this.loading = true;
      this.cdr.detectChanges();
    });
    this.http.get('/summary/status').subscribe((res: any) => {
      ngZone.run(() => {
        this.data = res;
        this.time = new Date();
        this.sum = this.data.reduce((p, c) => (p += c.num), 0);
        this.loading = false;
        this.cdr.detectChanges();
      });
      ngZone.runOutsideAngular(() => {
        const ds = new DataSet();
        const dv = ds.createView().source(this.data);
        dv.transform({
          type: 'map',
          callback: (row: any) => {
            row.value = +(this.sum * row.num);
            return row;
          },
        });

        chart.get('geoms')[0].color('type', this.data.filter(w => w.color).map(i => i.color));
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
