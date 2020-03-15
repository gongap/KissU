import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'finance-bill',
  templateUrl: './bill.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FinanceBillComponent {
  showReport = false;
}
