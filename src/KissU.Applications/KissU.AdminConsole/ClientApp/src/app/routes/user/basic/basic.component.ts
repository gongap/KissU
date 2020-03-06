import { Component, ChangeDetectionStrategy, OnInit, ChangeDetectorRef } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'user-basic',
  templateUrl: './basic.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserBasicComponent implements OnInit {
  i: any;

  constructor(private http: _HttpClient, private msg: NzMessageService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.http.get('/user-ms').subscribe(res => {
      this.i = res;
      this.cdr.markForCheck();
    });
  }

  save() {
    this.http.post('/user-ms', this.i).subscribe(res => this.msg.success('Success'));
  }
}
