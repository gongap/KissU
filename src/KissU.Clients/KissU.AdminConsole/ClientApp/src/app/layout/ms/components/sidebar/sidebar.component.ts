import {
  Component,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  AfterViewInit,
  ElementRef,
  ViewChild,
  OnDestroy,
} from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

import { NzMessageService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

import { BrandService } from '../../ms.service';
import { MSProductCategory, MSProduct, MSProductService } from '../../services/product.service';

@Component({
  selector: 'ms-sidebar',
  templateUrl: './sidebar.component.html',
  host: {
    '[class.alain-ms__sidebar]': 'true',
    '[class.alain-ms__sidebar-showproduct]': 'showProduct',
  },
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MSSidebarComponent implements AfterViewInit, OnDestroy {
  @ViewChild('categoryEl', { static: false })
  private categoryEl: ElementRef;

  showProduct = false;
  inited = false;

  get shortcuts() {
    return this.srv.shortcuts;
  }

  get l() {
    return this.srv.i18n;
  }

  q: string;
  searchList: MSProductCategory[][];
  searchCategories: MSProductCategory[] = [];

  constructor(
    private brand: BrandService,
    private srv: MSProductService,
    private msg: NzMessageService,
    private cdr: ChangeDetectorRef,
  ) {
    brand.setSidebar(true);
  }

  updateShortcutDropped(e: CdkDragDrop<MSProduct[]>) {
    moveItemInArray(this.shortcuts, e.previousIndex, e.currentIndex);

    this.msg.success(`New preference: ${this.shortcuts.map(i => i.name)}`);
  }

  search(scroll = true) {
    const res = this.srv.search(this.q);
    this.searchList = res.list;
    this.searchCategories = res.categories;

    this.cdr.detectChanges();

    if (scroll) {
      // wait angular render
      setTimeout(() => {
        // 滚动至顶部
        this.categoryEl.nativeElement.scrollTop = 0;
      });
    }
  }

  setShortcut(i: MSProduct) {
    this.srv.setShortcut(i);
    this.search(false);
  }

  ngAfterViewInit(): void {
    this.srv.getData().subscribe(() => {
      this.inited = true;
      this.search();
    });
  }

  ngOnDestroy() {
    this.brand.setSidebar(false);
  }
}
