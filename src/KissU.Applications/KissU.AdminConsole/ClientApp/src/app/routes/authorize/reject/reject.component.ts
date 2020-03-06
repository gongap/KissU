import { Component, ChangeDetectionStrategy } from '@angular/core';
import { Location } from '@angular/common';
import { TitleService } from '@delon/theme';

@Component({
  selector: 'authorize-reject',
  templateUrl: './reject.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AuthorizeRejectComponent {
  constructor(titleSrv: TitleService, private loc: Location) {
    titleSrv.setTitleByI18n('authorize.deny.title');
  }

  back() {
    this.loc.back();
  }
}
