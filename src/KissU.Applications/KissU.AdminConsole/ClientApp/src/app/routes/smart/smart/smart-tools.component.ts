import { Component, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'smart-tools',
  templateUrl: './smart-tools.component.html',
  host: {
    '[class.tools]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SmartToolsComponent {
  expand = false;

  tools = Array(5)
    .fill({})
    .map((i, idx) => ({
      title: `会员账号-${idx + 1}`,
      expand: idx <= 1,
      list: [
        { title: '找回用户名', link: '/', icon: 'setting' },
        { title: '修改密码', link: '/', icon: 'unlock' },
        { title: '找回密码', link: '/', icon: 'key' },
        { title: '手机绑定', link: '/', icon: 'mobile' },
      ],
    }));

  guanggao = Array(3)
    .fill({})
    .map((i, idx) => ({
      mp: `//cdn-images-1.medium.com/max/1920/1*-qlPoLmTOjX1Cck-LJsN9w.jpeg`,
      list: [
        { title: `Item - ${idx + 1} - 1`, link: '/' },
        { title: `Item - ${idx + 1} - 2`, link: '/' },
        { title: `Item - ${idx + 1} - 3`, link: '/' },
      ],
    }));

  constructor(private cd: ChangeDetectorRef) {}

  toggleExpaned() {
    this.expand = !this.expand;
    this.tools.slice(2).forEach(i => (i.expand = this.expand));
  }

  // TODO: removed after nz-carousel support OnPush mode
  fixOnPush() {
    this.cd.markForCheck();
  }
}
