import { Component, Optional, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';

import { _HttpClient } from '@delon/theme';
import { ReuseTabService } from '@delon/abc';
import { DA_SERVICE_TOKEN, TokenService } from '@delon/auth';

import { StartupService } from '@core';

const BIG_IMAGES = [
  `//cdn-images-1.medium.com/max/1920/1*-qlPoLmTOjX1Cck-LJsN9w.jpeg`,
  `//cdn-images-1.medium.com/max/1920/1*KJs5TOVmpBXJ1cx6-fJpOg.jpeg`,
  `//cdn-images-1.medium.com/max/1920/1*Gwg2zamC0M3hlvvqrtiD1w.jpeg`,
];

@Component({
  selector: 'account-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less'],
  host: {
    '[style.background-image]': `'url(' + bigImage + ')'`,
  },
})
export class LoginComponent {
  // tslint:disable-next-line: no-bitwise
  bigImage = BIG_IMAGES[(Math.random() * BIG_IMAGES.length) | 0];

  type = 'user';
  error = '';
  form: FormGroup;

  constructor(
    fb: FormBuilder,
    private router: Router,
    private msg: NzMessageService,
    public http: _HttpClient,
    @Optional()
    @Inject(ReuseTabService)
    private reuseTabService: ReuseTabService,
    @Inject(DA_SERVICE_TOKEN) private tokenService: TokenService,
    private startupSrv: StartupService,
  ) {
    this.form = fb.group({
      userName: [null, [Validators.required, Validators.pattern(/^(admin|user)$/)]],
      password: [null, [Validators.required, Validators.pattern(/^ng\-alain\.com$/)]],
    });
  }

  get password() {
    return this.form.controls.password;
  }

  get userName() {
    return this.form.controls.userName;
  }

  t() {
    this.msg.info('info');
  }

  submit() {
    this.error = '';
    const data = this.form.value;

    // 默认配置中对所有HTTP请求都会强制 [校验](https://ng-alain.com/auth/getting-started) 用户 Token
    // 然一般来说登录请求不需要校验，因此可以在请求URL加上：`/login?_allow_anonymous=true` 表示不触发用户 Token 校验
    this.http.post('/login/account?_allow_anonymous=true', data).subscribe((res: any) => {
      if (res.msg !== 'ok') {
        this.error = res.msg;
        return;
      }
      // 清空路由复用信息
      this.reuseTabService.clear();
      // 设置用户Token信息
      this.tokenService.set(res.user);
      // 重新获取 StartupService 内容，我们始终认为应用信息一般都会受当前用户授权范围而影响
      this.startupSrv.load().then(() => {
        this.router.navigate(['/home']);
      });
    });
  }
}
