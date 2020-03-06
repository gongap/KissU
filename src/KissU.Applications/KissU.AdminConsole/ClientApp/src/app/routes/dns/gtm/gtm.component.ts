import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'dns-gtm',
  templateUrl: './gtm.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DnsGTMComponent {
  constructor(public msg: NzMessageService) {}
}
