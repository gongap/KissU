import { Component, ChangeDetectionStrategy, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { NzMessageService } from 'ng-zorro-antd';
import { BrandService } from '@brand';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'data-healthy',
  templateUrl: './healthy.component.html',
  styleUrls: ['./healthy.component.less'],
  host: {
    '[class.alain-ms__console-full]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataHealthyComponent implements OnInit, OnDestroy {
  private notify$: Subscription;
  data: any = {};
  loading = true;
  $refresh = new Subject();

  constructor(
    private srv: BrandService,
    private http: _HttpClient,
    public msg: NzMessageService,
    private cdr: ChangeDetectorRef,
  ) {}

  load() {
    this.$refresh.next(true);
    this.loading = true;
    this.cdr.detectChanges();
    this.http.get('/summary/healthy').subscribe(res => {
      this.data = res;
      this.loading = false;
      this.cdr.detectChanges();
    });
  }

  ngOnInit(): void {
    this.load();
    this.notify$ = this.srv.notify.pipe(filter(type => type === 'page-nav')).subscribe(() => {
      window.dispatchEvent(new Event('resize'));
    });
  }

  ngOnDestroy(): void {
    this.notify$.unsubscribe();
    this.$refresh.unsubscribe();
  }
}
