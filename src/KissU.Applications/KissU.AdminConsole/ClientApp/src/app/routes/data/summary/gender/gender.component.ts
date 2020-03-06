import { Component, ChangeDetectionStrategy, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { Subscription } from 'rxjs';
import { _HttpClient } from '@delon/theme';
import { DataSummaryComponent } from '../summary.component';

@Component({
  selector: 'data-summary-gender',
  templateUrl: './gender.component.html',
  host: {
    '[class.card]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataSummaryGenderComponent implements OnInit, OnDestroy {
  private ref$: Subscription;
  loading = true;
  data = [];
  time: Date;

  constructor(private p: DataSummaryComponent, public http: _HttpClient, private cdr: ChangeDetectorRef) {}

  private loadData() {
    this.loading = true;
    this.cdr.detectChanges();
    this.http.get('/summary/gender').subscribe((res: any[]) => {
      this.data = res;
      this.time = new Date();
      this.loading = false;
      this.cdr.detectChanges();
    });
  }

  ngOnInit(): void {
    this.ref$ = this.p.$refresh.subscribe(() => this.loadData());
    this.loadData();
  }

  ngOnDestroy(): void {
    this.ref$.unsubscribe();
  }
}
