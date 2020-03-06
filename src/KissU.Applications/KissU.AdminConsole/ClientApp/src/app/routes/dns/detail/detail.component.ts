import { Component, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'dns-detail',
  templateUrl: './detail.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DnsDetailComponent {
  domain = '';
  constructor(route: ActivatedRoute) {
    this.domain = route.snapshot.params.domain;
  }
}
