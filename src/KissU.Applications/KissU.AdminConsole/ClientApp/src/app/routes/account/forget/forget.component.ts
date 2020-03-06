import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'account-forget',
  templateUrl: './forget.component.html',
  host: {
    '[class.account-container]': 'true',
    '[class.account-container__light]': 'true',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ForgetComponent {
  type = 0;

  findMobile: FormGroup;
  findDomain: FormGroup;

  constructor(fb: FormBuilder, private msg: NzMessageService) {
    this.findMobile = fb.group({
      mobilePrefix: ['+86'],
      mobile: [null, [Validators.required, Validators.pattern(/^1\d{10}$/)]],
      captcha: [null, [Validators.required]],
    });
    this.findDomain = fb.group({
      domain: [null, [Validators.required]],
    });
  }

  get mobile() {
    return this.findMobile.controls.mobile;
  }

  sendCaptcha() {
    this.msg.success('发送成功');
  }

  submit() {
    this.msg.success('OK');
  }
}
