import { Injectable } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { of, Observable } from 'rxjs';
import { MSLink } from '@brand';
import { map, tap } from 'rxjs/operators';
import { ArrayService } from '@delon/util';

export interface HelpCategory {
  [key: string]: any;
  title?: string;
  icon?: string;
  list?: HelpCategoryLink[];
  more?: boolean;
}

export interface HelpCategoryLink extends MSLink {
  [key: string]: any;
  id?: number;
  hide?: boolean;
}

export interface HelpMenu extends MSLink {
  [key: string]: any;

  id: number;
  title: string;
  line?: boolean;
  children?: HelpMenu[];

  /** 是否展开 */
  expand?: boolean;
  /** 是否当前项 */
  active?: boolean;
  _parent?: HelpMenu;
}

@Injectable()
export class HelpCategoryService {
  private _data: HelpCategory[];
  private _menuCached: { [key: number]: HelpMenu[] } = {};
  readonly max = 5;

  constructor(private http: _HttpClient, private arrSrv: ArrayService) {}

  get data(): Observable<HelpCategory[]> {
    return (this._data ? of(this._data) : this.getCategoryByHttp()).pipe(
      map(list =>
        list.map(p => {
          p.more = false;
          p.list.slice(this.max).forEach((i: any) => (i.hide = true));
          return p;
        }),
      ),
    );
  }

  getMenu(cid: number): Observable<HelpMenu[]> {
    return (this._menuCached[cid] ? of(this._menuCached[cid]) : this.getMenuByHttp(cid)).pipe(
      map(res => {
        let activeItem: HelpMenu;
        this.arrSrv.visitTree(res, (item: HelpMenu, parent: HelpMenu) => {
          item._parent = parent;
          if (item.id === cid) {
            item.active = true;
            activeItem = item;
          }
        });
        while (activeItem && activeItem._parent) {
          activeItem._parent.expand = true;
          activeItem = activeItem._parent;
        }
        return res;
      }),
    );
  }

  private getCategoryByHttp(): Observable<HelpCategory[]> {
    return this.http.get('/help/categories').pipe(tap((res: HelpCategory[]) => (this._data = res)));
  }

  private getMenuByHttp(cid: number): Observable<HelpMenu[]> {
    return this.http.get('/help/menu').pipe(
      tap((res: HelpMenu[]) => {
        this._menuCached[cid] = res;
      }),
    );
  }

  setMore(category: HelpCategory): void {
    category.more = !category.more;
    category.list.slice(this.max).forEach((i: any) => (i.hide = !category.more));
  }
}
