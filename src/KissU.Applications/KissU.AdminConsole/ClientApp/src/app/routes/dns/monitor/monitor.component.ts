import { Component, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'dns-monitor',
  templateUrl: './monitor.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DnsMonitorComponent {
  domain = '';
  loading = true;
  constructor(route: ActivatedRoute, private cdr: ChangeDetectorRef) {
    this.domain = route.snapshot.params.domain;
    setTimeout(() => {
      this.loading = false;
      this.cdr.detectChanges();
    }, 666);
  }
}
