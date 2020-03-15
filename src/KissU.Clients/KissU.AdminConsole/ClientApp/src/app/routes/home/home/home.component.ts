import { Component, ChangeDetectionStrategy, ChangeDetectorRef, OnInit } from '@angular/core';
import { delay } from 'rxjs/operators';
import { NzMessageService } from 'ng-zorro-antd';
import { _HttpClient, TitleService, ModalHelper } from '@delon/theme';

import { DashboardHomeCustomComponent } from './custom/custom.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent implements OnInit {
  data: any;
  recentlies = ['组件', 'Ng Alain', 'Smart', 'API 网关', '数据'];

  constructor(
    titSrv: TitleService,
    private modal: ModalHelper,
    private cdr: ChangeDetectorRef,
    public msg: NzMessageService,
    public http: _HttpClient,
  ) {
    titSrv.setTitleByI18n('home.title');
  }

  ngOnInit() {
    this.http
      .get('/home')
      .pipe(delay(500))
      .subscribe(res => {
        this.data = res;
        this.cdr.detectChanges();
      });
  }

  openCustom() {
    this.modal.createStatic(DashboardHomeCustomComponent, {}, { size: 'md' }).subscribe(res => {
      this.msg.success(JSON.stringify(res));
    });
  }
}
