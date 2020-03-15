import { Component, ChangeDetectionStrategy, Input } from '@angular/core';
import { HelpItem } from '../interface';

@Component({
  selector: 'help-detail-share',
  templateUrl: './share.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HelpDetailShareComponent {
  @Input() item: HelpItem;
}
