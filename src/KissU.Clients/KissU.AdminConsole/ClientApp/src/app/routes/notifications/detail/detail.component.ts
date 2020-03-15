import { Component, ChangeDetectionStrategy, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { NzMessageService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { RouteService } from '@core';

@Component({
  selector: 'notifications-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NotificationsInnerDetailComponent implements OnInit {
  i: any;
  params: any;
  constructor(
    route: ActivatedRoute,
    private routeStateSrv: RouteService,
    private router: Router,
    private http: _HttpClient,
    private cdr: ChangeDetectorRef,
    private dom: DomSanitizer,
    public msg: NzMessageService,
  ) {
    this.params = route.snapshot.params;
  }

  back() {
    this.router.navigateByUrl(`/notifications/inner/${this.params.type}/${this.routeStateSrv.data.index}`, {
      state: { pi: this.routeStateSrv.pi },
    });
  }

  ngOnInit(): void {
    this.http.get(`/message/inner/${this.params.id}`).subscribe((res: any) => {
      res.content = this.dom.bypassSecurityTrustHtml(res.content);
      this.i = res;
      this.cdr.detectChanges();
    });
  }
}
