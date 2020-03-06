import { Component, ChangeDetectionStrategy, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { _HttpClient, TitleService } from '@delon/theme';
import { HelpItem } from './interface';
import { DomSanitizer } from '@angular/platform-browser';
import { NzMessageService } from 'ng-zorro-antd';
import { deepCopy } from '@delon/util';

@Component({
  selector: 'help-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HelpDetailComponent implements OnInit {
  id: number;
  item: HelpItem;
  search = {
    type: 1,
    q: '',
  };
  feedback = {
    rate: 0,
    types: [
      { value: 1, label: '内容错误' },
      { value: 2, label: '更新不及时' },
      { value: 3, label: '链接错误' },
      { value: 4, label: '缺少代码/图片示例' },
      { value: 5, label: '太简单/步骤待完善' },
      { value: 6, label: '其他' },
    ],
    remark: '',
    anonymous: true,
  };

  constructor(
    route: ActivatedRoute,
    private titleSrv: TitleService,
    private http: _HttpClient,
    private dom: DomSanitizer,
    private msgSrv: NzMessageService,
    private cdr: ChangeDetectorRef,
  ) {
    this.id = +route.snapshot.params.id;
  }

  ngOnInit(): void {
    this.http.get(`/help/categories/${this.id}`).subscribe((res: any) => {
      res.content = this.dom.bypassSecurityTrustHtml(res.content);
      this.item = res;
      this.titleSrv.setTitle(res.title);
      this.cdr.detectChanges();
    });
  }

  feedbackTypeChecked = false;
  feedbackRateTip = '';
  feedbackRateChange(val: number) {
    let text = '文档很好';
    switch (val) {
      case 4:
        text = `文档不错`;
        break;
      case 3:
        text = `文档一般`;
        break;
      case 2:
        text = `文档较差`;
        break;
      case 1:
        text = `根本没帮助`;
        break;
    }
    this.feedbackRateTip = text;
  }

  feedbackTypesChange(ls: any[]) {
    this.feedbackTypeChecked = ls.some(i => i.checked);
    this.cdr.detectChanges();
  }

  feedbackSave() {
    const postData: any = deepCopy(this.feedback);
    postData.types = postData.types.filter(i => i.checked).map(i => i.value);
    this.msgSrv.info(JSON.stringify(postData));
  }
}
