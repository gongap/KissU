import { Component, ChangeDetectionStrategy, Input, OnInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { BrandService } from '@brand';
import { HelpCategoryService, HelpMenu, HelpCategory } from '../../_core/help-category.service';

@Component({
  selector: 'help-detail-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HelpDetailMenuComponent implements OnInit, OnDestroy {
  private brand$: Subscription;

  @Input() cate: { id: number; title: string };

  visible = false;

  get isMobile() {
    return this.brand.isMobile;
  }

  categories: HelpCategory[];
  menus: HelpMenu[];

  constructor(private helpSrv: HelpCategoryService, private brand: BrandService, private cdr: ChangeDetectorRef) {
    this.brand$ = brand.notify.pipe(filter(() => !!this.menus)).subscribe(() => this.cdr.detectChanges());
  }

  ngOnInit(): void {
    this.helpSrv.data.subscribe(res => {
      this.categories = res;
      this.cdr.detectChanges();
    });
    this.helpSrv.getMenu(this.cate.id).subscribe(res => {
      this.menus = res;
      this.cdr.detectChanges();
    });
  }

  ngOnDestroy() {
    this.brand$.unsubscribe();
  }
}
