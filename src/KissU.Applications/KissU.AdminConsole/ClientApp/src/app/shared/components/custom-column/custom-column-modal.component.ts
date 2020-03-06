import { Component, ChangeDetectionStrategy, OnInit, Inject, ChangeDetectorRef } from '@angular/core';
import { NzModalRef } from 'ng-zorro-antd';
import { STComponent } from '@delon/abc';
import { ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';

@Component({
  selector: 'custom-column-modal',
  templateUrl: './custom-column-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CustomColumnModalComponent implements OnInit {
  st: STComponent;
  title: string;
  list: any[] = [];

  constructor(
    private ref: NzModalRef,
    @Inject(ALAIN_I18N_TOKEN) private i18n: I18NService,
    private cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    this.list = this.st.columns.map((i, idx) => ({
      label: i.i18n ? this.i18n.fanyi(i.i18n) : i.title,
      value: idx,
      checked: i.ccChecked !== false,
      disabled: i.ccDisabled === true,
    }));
    this.cdr.markForCheck();
  }

  ok() {
    this.st.columns.forEach((col, idx) => (col.ccChecked = this.list[idx].checked));
    this.ref.close(true);
  }

  close() {
    this.ref.close();
  }
}
