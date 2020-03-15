import { Component, ChangeDetectionStrategy, Input, ChangeDetectorRef, OnChanges } from '@angular/core';

@Component({
  selector: 'data-healthy-num',
  templateUrl: './num.component.html',
  host: {
    '[class.card]': 'true',
    '[class.card__small]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataHealthyNumComponent implements OnChanges {
  @Input() title = '';
  @Input() value = 0;
  @Input() valueCls = {};
  @Input() loading = true;

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnChanges(): void {
    this.cdr.detectChanges();
  }
}
