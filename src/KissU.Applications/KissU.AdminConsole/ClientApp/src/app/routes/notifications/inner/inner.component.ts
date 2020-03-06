import { Component, ChangeDetectionStrategy, ViewChild, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn, STComponent, STChange, STData } from '@delon/abc';
import { RouteService } from '@core';
import { NotificationsService } from '../_core/notifications.service';

@Component({
  selector: 'notifications-inner',
  templateUrl: './inner.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NotificationsInnerComponent implements OnInit, OnDestroy {
  private route$: Subscription;
  @ViewChild('st', { static: true }) private st: STComponent;

  get types() {
    return ['全部类型消息', ...this.srv.types];
  }

  pi = 10;
  params: any = {};
  url = '/message/inner';
  columns: STColumn[] = [
    { title: '', type: 'checkbox' },
    { title: '标题内容', render: 'title' },
    { title: '提交时间', index: 'time', type: 'date' },
    { title: '类型', index: 'type' },
  ];
  checkList: STData[] = [];

  constructor(
    routeStateSrv: RouteService,
    private route: ActivatedRoute,
    private router: Router,
    private srv: NotificationsService,
    public msg: NzMessageService,
  ) {
    this.pi = routeStateSrv.pi;
  }

  private updateType() {
    const { params } = this;
    const text = this.types[params.index];
    params.q = text === '全部类型消息' ? '' : text;
  }

  private get checkIds() {
    return this.checkList.map(i => i.id);
  }

  changeType() {
    this.updateType();
    this.router.navigateByUrl(`/notifications/inner/${this.params.type}/${this.params.index}`);
  }

  change(e: STChange) {
    if (e.type === 'checkbox') {
      this.checkList = e.checkbox;
    }
  }

  remove() {
    this.msg.success(JSON.stringify(this.checkIds));
  }

  ngOnInit(): void {
    this.route$ = this.route.params.subscribe(p => {
      this.params.type = p.type;
      this.params.index = +p.index;
      this.updateType();
      if (this.st) {
        this.st.reload(this.params);
      }
    });
  }

  ngOnDestroy(): void {
    this.route$.unsubscribe();
  }
}
