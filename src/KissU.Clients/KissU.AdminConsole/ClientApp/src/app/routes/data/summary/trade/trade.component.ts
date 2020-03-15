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
  selector: 'data-summary-trade',
  templateUrl: './trade.component.html',
  host: {
    '[class.card]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataSummaryTradeComponent implements OnInit, OnDestroy {
  private ref$: Subscription;
  private chart: any;
  loading = true;
  data = [];
  time: Date;
  // 达标值
  top = 120;

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
    const { top } = this;
    const chart = (this.chart = new G2.Chart({
      container,
      forceFit: true,
      height: 160,
      padding: 'auto',
    }));
    chart.scale('num', { tickInterval: 20, alias: '数量' });
    chart
      .interval()
      .position('time*num')
      .color('#00c1de');
    chart.guide().region({
      start: ['start', 'max'],
      end: ['end', top],
      style: {
        lineWidth: 0,
        fill: '#d9f7be',
        fillOpacity: 1,
        stroke: '#ccc',
      },
    });
    chart.guide().text({
      top: true,
      position: ['end', 'max'],
      content: '销售达标区间',
      style: {
        fill: '#333',
        textAlign: 'end',
        textBaseline: 'top',
        fontWeight: 300,
      },
      offsetX: -10,
      offsetY: 6,
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
    this.http.get('/summary/trade').subscribe((res: any) => {
      ngZone.run(() => {
        this.data = res;
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
