import { Component, ChangeDetectionStrategy, ChangeDetectorRef, forwardRef, OnInit } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { _HttpClient } from '@delon/theme';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { deepCopy } from '@delon/util';

@Component({
  selector: 'dns-group-select',
  templateUrl: './group.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DnsGroupComponent),
      multi: true,
    },
  ],
})
export class DnsGroupComponent implements ControlValueAccessor, OnInit {
  url = '/dns/group';
  visible = false;
  value: any;
  list: any[];
  editI: any;

  get text() {
    return this.list ? this.list.find(w => w.selected).name : '';
  }

  get isAdd() {
    return this.editI && this.editI.idx === -1;
  }

  constructor(
    private http: _HttpClient,
    private msg: NzMessageService,
    private modalSrv: NzModalService,
    private cdr: ChangeDetectorRef,
  ) {}

  ngOnInit() {
    this.http.get(this.url).subscribe((res: any) => {
      res[0].selected = true;
      this.list = res;
      this.cdr.detectChanges();
    });
  }

  choose(i: any) {
    if (i.id === this.value) return;

    this.list.filter(w => w.selected).forEach(item => (item.selected = false));
    i.selected = true;
    this.value = i.id;
    this.onChange(i.id);
    this.visible = false;
  }

  private cleanAction() {
    this.list.forEach(i => (i.action = ''));
  }

  remove(i: any, idx: number, e: MouseEvent) {
    e.stopPropagation();
    this.modalSrv.confirm({
      nzTitle: '删除确认',
      nzContent: '确定要删除此分组吗？',
      nzOnOk: () => {
        this.http.delete(this.url, { id: i.id }).subscribe(() => {
          this.list.splice(idx, 1);
          this.msg.success(`删除成功`);
          this.cdr.detectChanges();
        });
      },
    });
  }

  edit(i: any, idx: number, e: MouseEvent) {
    e.stopPropagation();
    i.action = 'edit';
    i.idx = idx;
    this.editI = deepCopy(i);
  }

  add(e: MouseEvent) {
    e.stopPropagation();
    this.cleanAction();
    this.editI = {
      idx: -1,
      count: 0,
    };
  }

  cancel(e: MouseEvent) {
    e.stopPropagation();
    this.cleanAction();
    this.editI = null;
    this.cdr.detectChanges();
  }

  save(e: MouseEvent) {
    this.http.post(this.url, this.editI).subscribe((res: any) => {
      const idx = this.editI.idx;
      if (idx === -1) {
        this.list.push(res.item);
      } else {
        this.list[idx].name = res.item.name;
      }
      this.msg.success('保存成功');
      this.cancel(e);
    });
  }

  // #region ngModel

  private onChange: (value: string | string[]) => void = () => null;
  private onTouched: () => void = () => null;

  writeValue(obj: any): void {
    this.value = obj;
    this.cdr.detectChanges();
  }
  registerOnChange(fn: (value: string | string[]) => void): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: () => void): void {
    this.onTouched = fn;
  }
  setDisabledState?(): void {}

  // #endregion
}
