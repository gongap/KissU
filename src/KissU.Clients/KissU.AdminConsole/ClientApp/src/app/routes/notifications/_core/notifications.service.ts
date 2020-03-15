import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { _HttpClient } from '@delon/theme';

export interface NotificationsCount {
  type: string;
  index: number;
  count: number;
  read: number;
  unread: number;
}

@Injectable()
export class NotificationsService {
  readonly types = ['优惠活动', '产品消息', '服务消息', '用户消息'];
  private _count: NotificationsCount[];

  constructor(private http: _HttpClient) {}

  get count(): Observable<NotificationsCount[]> {
    return this._count ? of(this._count) : this.getCountByHttp();
  }

  private getCountByHttp(): Observable<NotificationsCount[]> {
    return this.http.get('/message/count').pipe(
      map((res: NotificationsCount[]) => {
        this._count = res.map(i => {
          i.index = this.types.indexOf(i.type);
          return i;
        });
        return this._count;
      }),
    );
  }
}
