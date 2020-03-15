// tslint:disable: unified-signatures
// Please refer to: https://ng-alain.com/docs/i18n
import { Injectable } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { Observable, BehaviorSubject } from 'rxjs';
import { filter } from 'rxjs/operators';

import { registerLocaleData } from '@angular/common';
import ngZh from '@angular/common/locales/zh';
import ngEn from '@angular/common/locales/en';
import ngZhTw from '@angular/common/locales/zh-Hant';

import { en_US, zh_CN, zh_TW, NzI18nService } from 'ng-zorro-antd';
import * as df_en from 'date-fns/locale/en';
import * as df_zh_cn from 'date-fns/locale/zh_cn';
import * as df_zh_tw from 'date-fns/locale/zh_tw';
import {
  SettingsService,
  AlainI18NService,
  DelonLocaleService,
  en_US as delonEnUS,
  zh_CN as delonZhCn,
  zh_TW as delonZhTw,
} from '@delon/theme';

export type LangType = 'zh-CN' | 'zh-TW' | 'en-US';

interface LangConfig {
  text: string;
  ng: any;
  zorro: any;
  dateFns: any;
  delon: any;
  abbr: string;
}

const DEFAULT = 'zh-CN';
const LANGS: { [key: string]: LangConfig } = {
  'zh-CN': {
    text: '简体中文',
    ng: ngZh,
    zorro: zh_CN,
    dateFns: df_zh_cn,
    delon: delonZhCn,
    abbr: '🇨🇳',
  },
  'zh-TW': {
    text: '繁体中文',
    ng: ngZhTw,
    zorro: zh_TW,
    dateFns: df_zh_tw,
    delon: delonZhTw,
    abbr: '🇭🇰',
  },
  'en-US': {
    text: 'English',
    ng: ngEn,
    zorro: en_US,
    dateFns: df_en,
    delon: delonEnUS,
    abbr: '🇬🇧',
  },
};

@Injectable({ providedIn: 'root' })
export class I18NService implements AlainI18NService {
  private _default: LangType = DEFAULT;
  private _data: { [lang: string]: {} } = {};
  private _currentLang: LangType;
  private change$ = new BehaviorSubject<string>(null);

  private _langCodes = Object.keys(LANGS);
  private _langs = Object.keys(LANGS).map(code => {
    const item = LANGS[code];
    return { code, text: item.text, abbr: item.abbr };
  });

  get change(): Observable<string> {
    return this.change$.asObservable().pipe(filter(w => w != null));
  }

  constructor(
    settings: SettingsService,
    private nzI18nService: NzI18nService,
    private delonLocaleService: DelonLocaleService,
    private dom: DomSanitizer,
  ) {
    const defaultLan = settings.layout.lang || this.getBrowserLang();

    this._default = (this._langCodes.includes(defaultLan) ? defaultLan : this._langCodes[0]) as LangType;
    this.use(this._default);
  }

  private getBrowserLang(): string {
    const winNav: any = window.navigator;
    if (typeof window === 'undefined' || typeof winNav === 'undefined') {
      return undefined;
    }

    let browserLang: any = winNav.languages ? winNav.languages[0] : null;
    browserLang = browserLang || winNav.language || winNav.browserLanguage || winNav.userLanguage;

    // tslint:disable-next-line: no-bitwise
    if (~this._langCodes.indexOf(browserLang)) {
      return browserLang;
    }

    if (browserLang.indexOf('-') !== -1) {
      browserLang = browserLang.split('-')[0];
    }

    if (browserLang.indexOf('_') !== -1) {
      browserLang = browserLang.split('_')[0];
    }

    return this.getFullLang(browserLang);
  }

  getFullLang(lang: LangType) {
    const res = this._langs.filter(l => l.code.split('-')[0] === lang);
    return res.length > 0 ? res[0].code : this.defaultLang;
  }

  /**
   * 装载语言数据
   */
  load(lang: LangType, data: {}) {
    this._data[lang] = { ...this._data[lang], ...data };
  }

  get zone() {
    return this._currentLang.split('-')[0];
  }

  get text() {
    return LANGS[this._currentLang].text;
  }

  // #region AlainI18NService interface

  use(lang: LangType): void {
    if (this._currentLang === lang) return;

    this._currentLang = lang;

    // 变更库语言
    const item = LANGS[lang];
    registerLocaleData(item.ng);
    this.nzI18nService.setLocale(item.zorro);
    this.nzI18nService.setDateLocale(item.dateFns);
    (window as any).__locale__ = item.dateFns;
    this.delonLocaleService.setLocale(item.delon);

    this.change$.next(lang);
  }

  /** 获取语言列表 */
  getLangs() {
    return this._langs;
  }

  /** 翻译 */
  fanyi(key: string): string;
  fanyi(key: string, params?: {}): string;
  fanyi(key: string, params?: {}, isSafe?: boolean): string | SafeHtml;
  fanyi(key: string, params?: {}, isSafe?: boolean): any {
    const data = this._data[this._currentLang];
    let res = data ? data[key] : null;
    if (res == null) {
      console.warn(`Not found "${key}" key of i18n service`);
      return '';
    }
    // tslint:disable-next-line: no-bitwise
    if (~res.indexOf(`{{`) && params != null) {
      res = res.replace(/{{\s?([^{}\s]*)\s?}}/g, (substring: string, b: string) => params[b] || substring);
    }
    if (isSafe === true) {
      return this.dom.bypassSecurityTrustHtml(res);
    }
    return res;
  }

  /** 默认语言 */
  get defaultLang() {
    return this._default;
  }

  /** 当前语言 */
  get currentLang() {
    return this._currentLang;
  }

  // #endregion
}
