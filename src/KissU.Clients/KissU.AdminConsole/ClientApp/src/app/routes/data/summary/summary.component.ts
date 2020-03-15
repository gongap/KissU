import { Component, ChangeDetectionStrategy, OnInit, OnDestroy } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { NzMessageService } from 'ng-zorro-antd';
import { BrandService } from '@brand';

@Component({
  selector: 'data-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.less'],
  host: {
    '[class.alain-ms__console-full]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataSummaryComponent implements OnInit, OnDestroy {
  private notify$: Subscription;
  type = '';
  $refresh = new Subject();

  constructor(private srv: BrandService, public msg: NzMessageService) {}

  ngOnInit(): void {
    this.notify$ = this.srv.notify.pipe(filter(type => type === 'page-nav')).subscribe(() => {
      window.dispatchEvent(new Event('resize'));
    });
  }

  ngOnDestroy(): void {
    this.notify$.unsubscribe();
    this.$refresh.unsubscribe();
  }
}
