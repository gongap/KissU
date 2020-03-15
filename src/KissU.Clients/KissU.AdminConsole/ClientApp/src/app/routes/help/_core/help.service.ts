import { Injectable } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { of, Observable } from 'rxjs';
import { MSLink } from '@brand';

export interface HelpCategory {
  [key: string]: any;
  title?: string;
  icon?: string;
  list?: HelpCategoryLink[];
}

export interface HelpCategoryLink extends MSLink {
  [key: string]: any;
  id?: number;
}

@Injectable()
export class HelpService {
  private _data: HelpCategory[];

  constructor(private http: _HttpClient) {}

  get data(): Observable<HelpCategory[]> {
    return this._data ? of(this._data) : this.getByHttp();
  }

  private getByHttp(): Observable<HelpCategory[]> {
    return this.http.get('/help/categories');
  }
}
