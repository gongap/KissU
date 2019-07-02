import { Component, ChangeDetectionStrategy, ChangeDetectorRef, OnInit, Injector } from '@angular/core';
import * as distanceInWordsToNow from 'date-fns/distance_in_words_to_now';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { NoticeItem, NoticeIconList } from '@delon/abc';
import { _HttpClient } from '@delon/theme';
import { List } from 'linqts';
import { util } from '@shared/util';


/**
 * 菜单通知
 */
@Component({
  selector: 'header-notify',
  template: `
  <notice-icon
    [data]="data"
    [(count)]="count"
    [loading]="loading"
    btnClass="alain-default__nav-item"
    btnIconClass="alain-default__nav-item-icon"
    (select)="select($event)"
    (clear)="clear($event)"
    (popoverVisibleChange)="loadData()"></notice-icon>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderNotifyComponent implements OnInit {
  data: NoticeItem[] = [
    {
      title: '消息',
      list: [],
      emptyText: '暂无消息',
      emptyImage: '',
      clearText: '清空消息',
    },
    {
      title: '通知',
      list: [],
      emptyText: '暂无通知',
      emptyImage: '',
      clearText: '清空通知',
    },
    {
      title: '待办',
      list: [],
      emptyText: '暂无待办',
      emptyImage: '',
      clearText: '清空待办',
    },
  ];
  count = 0;
  loading = false;

  constructor(private msg: NzMessageService, private cdr: ChangeDetectorRef, private http: _HttpClient,
    protected modalService: NzModalService,
    injector: Injector,
  ) {
    util.ioc.componentInjector = injector;
  }

  ngOnInit(): void {
    util.webapi.get(`/identity/account/invitation/count`).handleAsync({
      ok: (result: any) => {
        this.count = result;
        this.cdr.detectChanges();
      }
    });
  }

  private updateNoticeData(notices: NoticeIconList[]): NoticeItem[] {
    const data = this.data.slice();
    data.forEach(i => (i.list = []));

    notices.forEach(item => {
      const newItem = { ...item };
      if (newItem.datetime)
        newItem.datetime = distanceInWordsToNow(item.datetime, {
          locale: (window as any).__locale__,
        });
      if (newItem.extra && newItem.status) {
        newItem.color = {
          todo: undefined,
          processing: 'blue',
          urgent: 'red',
          doing: 'gold',
        }[newItem.status];
      }
      data.find(w => w.title === newItem.type).list.push(newItem);
    });
    return data;
  }

  loadData() {
    if (this.loading) return;
    this.loading = true;
    util.webapi.get(`/identity/account/invitation`).handleAsync({
      ok: (result: any[]) => {
        const notices = [];
        new List(result).ForEach((item) => {
          notices.push({
            id: item.id,
            avatar: '',
            title: `${item.fromUserName} 邀请你加入 ${item.enterpriseName}`,
            description: item.comment,
            datetime: item.invitationDate,
            type: '消息',
          });
        });
        this.count = notices.length;
        this.data = this.updateNoticeData(notices);
        this.loading = false;
        this.cdr.detectChanges();
      }
    });
  }

  clear(type: string) {
    this.modalService.confirm({
      nzTitle: '确定要清空所有消息吗?',
      nzOnOk: () => {
        util.webapi.get(`/identity/account/invitation/clear`).handleAsync({
          ok: (result: any) => {
            this.loadData();
          }
        });
      },
    });
  }

  select(res: any) {
    this.modalService.info({
      nzClosable: true,
      nzTitle: res.item.title,
      nzContent: `<b style="color: red;">${res.item.description ?  res.item.description : ''}</b>`,
      nzOkText: '同意',
      nzOnOk: () => {
        util.webapi.get(`/identity/account/invitation/agree`).param({ invitationId: res.item.id }).handleAsync({
          ok: (result: any) => {
            this.loadData();
          }
        });
      },
      nzCancelText: '拒绝',
      nzOnCancel: () => {
        util.webapi.get(`/identity/account/invitation/refuse`).param({ invitationId: res.item.id }).handleAsync({
          ok: (result: any) => {
            this.loadData();
          }
        });
      }
    });
  }
}
