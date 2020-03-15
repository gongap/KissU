import { Component, ChangeDetectionStrategy, OnInit, ChangeDetectorRef } from '@angular/core';
import { NzModalRef, UploadFile } from 'ng-zorro-antd';
import { _HttpClient, SettingsService } from '@delon/theme';

@Component({
  selector: 'user-secure-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserSecureAvatarComponent implements OnInit {
  defaultAvatar: any[];
  type = 0;
  avatar = this.settings.user.avatar;
  customAvatar = '';

  constructor(
    private http: _HttpClient,
    private settings: SettingsService,
    private cdr: ChangeDetectorRef,
    private ref: NzModalRef,
  ) {}

  choose(i: any) {
    this.avatar = i.mp;
    this.defaultAvatar.forEach(item => (item.active = false));
    i.active = true;
    this.cdr.detectChanges();
  }

  change(e: UploadFile) {
    if (e.type === 'success') {
      this.customAvatar = `./assets/tmp/img/avatar.jpg`;
      this.save();
    }
  }

  save() {
    const { type, avatar, customAvatar } = this;
    const saveAvatar = type === 0 ? avatar : customAvatar;
    this.settings.user.avatar = saveAvatar;
    this.ref.close(saveAvatar);
  }

  cancel() {
    this.ref.close();
  }

  ngOnInit(): void {
    this.http.get('/user-ms/default-avatar').subscribe((res: any[]) => {
      this.defaultAvatar = res;
      this.cdr.detectChanges();
    });
  }
}
