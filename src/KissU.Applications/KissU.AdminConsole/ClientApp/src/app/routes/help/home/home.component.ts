import { Component, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { TitleService } from '@delon/theme';
import { NzMessageService } from 'ng-zorro-antd';
import { HelpCategoryService, HelpCategory } from '../_core/help-category.service';

@Component({
  selector: 'help-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HelpHomeComponent {
  q = '';
  list = [];

  get categories$() {
    return this.helpSrv.data;
  }

  constructor(
    private helpSrv: HelpCategoryService,
    titSrv: TitleService,
    public msg: NzMessageService,
    private cdr: ChangeDetectorRef,
  ) {
    titSrv.setTitleByI18n('help.menu.home');
  }

  search() {
    this.list = this.q ? new Array(5).fill({}).map((i, idx) => ({ value: idx + 1, label: `Item ${this.q}` })) : [];
  }

  more(p: HelpCategory) {
    this.helpSrv.setMore(p);
    this.cdr.detectChanges();
  }
}
