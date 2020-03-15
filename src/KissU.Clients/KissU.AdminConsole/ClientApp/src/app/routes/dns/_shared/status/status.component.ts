import { Component, ChangeDetectionStrategy, OnInit, OnDestroy, ChangeDetectorRef, Input } from '@angular/core';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'dns-status',
  templateUrl: './status.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DnsStatusComponent implements OnInit, OnDestroy {
  status: boolean = null;

  @Input() domain: string;

  constructor(private http: _HttpClient, private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.http.get('/dns/status', { domain: this.domain }).subscribe((res: any) => {
      this.status = res;
      this.cdr.detectChanges();
    });
  }

  ngOnDestroy() {}
}
