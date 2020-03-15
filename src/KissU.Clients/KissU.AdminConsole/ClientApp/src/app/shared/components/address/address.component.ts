import {
  Component,
  ChangeDetectionStrategy,
  Input,
  OnInit,
  ChangeDetectorRef,
  forwardRef,
} from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import {
  CascaderOption,
  NzCascaderExpandTrigger,
  NzCascaderSize,
  NzShowSearchOptions,
  NzCascaderTriggerType,
} from 'ng-zorro-antd';
import { InputBoolean } from '@delon/util';
import { AddressService, AddressType } from './address.service';

@Component({
  selector: 'address',
  templateUrl: './address.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => AddressComponent),
      multi: true,
    },
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddressComponent implements OnInit, ControlValueAccessor {
  private onChangeFn: (val: string) => void;
  private onTouchedFn: () => void;
  value: string[] = [];
  data: CascaderOption[];

  // #region fields

  @Input() type: AddressType = 'pca';

  // Original attributes
  @Input() @InputBoolean() allowClear = true;
  @Input() @InputBoolean() autoFocus = false;
  @Input() @InputBoolean() disabled: boolean;
  @Input() expandTrigger: NzCascaderExpandTrigger = 'click';
  @Input() notFoundContent: string;
  @Input() size: NzCascaderSize = 'default';
  @Input() showSearch: boolean | NzShowSearchOptions;
  @Input() placeHolder = '请选择所在地';
  @Input() mouseEnterDelay = 150; // ms
  @Input() mouseLeaveDelay = 150; // ms
  @Input() triggerAction: NzCascaderTriggerType | NzCascaderTriggerType[] = [
    'click',
  ] as NzCascaderTriggerType[];

  // #endregion

  constructor(private srv: AddressService, private cdr: ChangeDetectorRef) {}

  change() {
    this.onChangeFn(this.value.pop());
  }

  ngOnInit(): void {
    this.srv[this.type].subscribe(res => {
      this.data = res;
      this.cdr.markForCheck();
    });
  }

  writeValue(geo: string): void {
    if (geo == null) {
      this.value = [];
      return ;
    }
    this.value = this.srv.toValueArr(geo, this.type);
  }
  registerOnChange(fn: any): void {
    this.onChangeFn = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouchedFn = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }
}
