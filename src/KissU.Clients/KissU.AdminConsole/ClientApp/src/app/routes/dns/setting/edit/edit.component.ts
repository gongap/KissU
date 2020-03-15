import { Component, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

const URL = '/dns/setting';

@Component({
  selector: 'dns-setting-edit',
  templateUrl: './edit.component.html',
})
export class DnsSettingEditComponent implements OnInit {
  i: any = {
    id: 0,
    type: 'A',
    line: 'default',
    tTL: 600,
    status: 'ENABLE',
  };

  constructor(public http: _HttpClient, private msg: NzMessageService, private modal: NzModalRef) {}

  ngOnInit() {
    if (this.i.id > 0) {
      this.http.get(`${URL}/${this.i.id}`).subscribe((res: any) => (this.i = res));
    }
  }

  save() {
    this.http.post(URL, this.i).subscribe(res => {
      this.msg.success('Success');
      this.modal.close(res);
    });
  }

  close() {
    this.modal.close();
  }
}
