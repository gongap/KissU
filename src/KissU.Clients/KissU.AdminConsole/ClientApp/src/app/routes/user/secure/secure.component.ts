import { Component, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { SettingsService, ModalHelper } from '@delon/theme';
import { NzMessageService } from 'ng-zorro-antd';
import { UserSecureAvatarComponent } from './avatar/avatar.component';

@Component({
  selector: 'user-secure',
  templateUrl: './secure.component.html',
  styleUrls: ['./secure.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserSecureComponent {
  get user() {
    return this.settings.user;
  }

  constructor(
    private settings: SettingsService,
    private modalHelpr: ModalHelper,
    private cdr: ChangeDetectorRef,
    public msg: NzMessageService,
  ) {}

  openAvatar() {
    this.modalHelpr.static(UserSecureAvatarComponent, null, 'md').subscribe(() => this.cdr.detectChanges());
  }
}
