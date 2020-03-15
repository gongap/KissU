import { Component, ChangeDetectionStrategy, ChangeDetectorRef, ViewChild } from '@angular/core';
import { TitleService } from '@delon/theme';
import { ScrollbarDirective } from '@shared';

@Component({
  selector: 'smart',
  templateUrl: './smart.component.html',
  styleUrls: ['./smart.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SmartComponent {
  messages: any[] = [
    {
      type: 'text',
      dir: 'left',
      mp: './assets/logo-color.svg',
      msg: '请<span class="text-success">一句话</span>描述您的问题，我们来帮您解决并转到合适的人工服务。😎',
    },
  ];
  text = '';
  @ViewChild('messageScrollbar', { static: false }) messageScrollbar?: ScrollbarDirective;
  hots = ['ng-alain', 'ECS', '域名', '备案', '已备案信息核查', '邮箱', '组件'];
  constructor(titSrv: TitleService, private cdr: ChangeDetectorRef) {
    titSrv.setTitleByI18n('smart.title');
  }

  private scrollToBottom() {
    this.cdr.detectChanges();
    setTimeout(() => this.messageScrollbar.scrollToBottom());
  }

  send() {
    if (!this.text) return false;

    this.messages.push({
      type: 'text',
      msg: this.text,
      dir: 'right',
    });
    this.text = '';
    this.scrollToBottom();
    return false;
  }

  enterSend(e: KeyboardEvent) {
    // tslint:disable-next-line: deprecation
    if (e.keyCode !== 13) return;
    if (e) {
      e.preventDefault();
      e.stopPropagation();
    }
    this.send();
  }
}
