import { Component, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'account-topbar',
  templateUrl: './topbar.component.html',
  host: {
    '[class.account-topbar]': 'true',
    '[class.account-topbar__light]': `theme === 'light'`,
    '[class.account-topbar__dark]': `theme === 'dark'`,
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AccountTopbarComponent {
  @Input() theme: 'light' | 'dark' = 'dark';
}
