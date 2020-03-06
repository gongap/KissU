import { Component, ViewChild, DebugElement, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestBed, TestBedStatic, ComponentFixture } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { configureTestSuite, createTestContext } from '@delon/testing';
import { AlainThemeModule, ALAIN_I18N_TOKEN } from '@delon/theme';
import { I18NService } from '@core';

import { BrandService } from '../kissu.service';
import { KissULayoutComponent } from '../kissu.component';

describe('ms: layout-ms', () => {
  let injector: TestBedStatic;
  let fixture: ComponentFixture<TestComponent>;
  let dl: DebugElement;
  let context: TestComponent;
  let srv: BrandService;
  let page: PageObject;

  configureTestSuite(() => {
    injector = TestBed.configureTestingModule({
      imports: [
        NoopAnimationsModule,
        HttpClientTestingModule,
        RouterTestingModule.withRoutes([]),
        NgZorroAntdModule,
        AlainThemeModule.forRoot(),
      ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
      providers: [{ provide: ALAIN_I18N_TOKEN, useClass: I18NService, multi: false }],
      declarations: [KissULayoutComponent, TestComponent],
    });
  });

  describe('should set the body style', () => {
    beforeEach(() => {
      ({ fixture, dl, context } = createTestContext(TestComponent));
      fixture.detectChanges();
      srv = injector.get(BrandService);
      page = new PageObject();
    });

    it('when inited', () => {
      srv.triggerNotify();
      fixture.detectChanges();
      page
        .checkBodyClass('alain-ms__has-topbar')
        .checkBodyClass('alain-ms__has-sidebar', false)
        .checkBodyClass('alain-ms__has-fixed', false);
    });
    it('when destroy', () => {
      context.comp.ngOnDestroy();
      page
        .checkBodyClass('alain-ms__has-topbar', false)
        .checkBodyClass('alain-ms__has-sidebar', false)
        .checkBodyClass('alain-ms__has-fixed', false);
    });
    it('when changed', () => {
      srv.setTopbar(true);
      srv.setSidebar(false);
      srv.setFixed(true);
      fixture.detectChanges();
      page
        .checkBodyClass('alain-ms__has-topbar', true)
        .checkBodyClass('alain-ms__has-sidebar', false)
        .checkBodyClass('alain-ms__has-fixed', true);
    });
  });

  describe('should be change layout via route data', () => {
    it('with hasAllNav', () => {
      TestBed.overrideProvider(ActivatedRoute, { useValue: { snapshot: { data: { hasAllNav: true } } } });
      ({ fixture, dl, context } = createTestContext(TestComponent));
      fixture.detectChanges();
      expect(context.comp.hasAllNav).toBe(true);
    });

    it('with hasSidebar', () => {
      TestBed.overrideProvider(ActivatedRoute, { useValue: { snapshot: { data: { hasSidebar: false } } } });
      ({ fixture, dl, context } = createTestContext(TestComponent));
      fixture.detectChanges();
      expect(context.comp.hasSidebar).toBe(false);
    });
  });

  class PageObject {
    checkBodyClass(cls: string, status = true): this {
      expect(document.body.classList.contains(cls)).toBe(status);
      return this;
    }
    checkCls(cls: string, status = true): this {
      const nodes = document.querySelectorAll(cls);
      if (status) {
        expect(nodes.length).toBe(1);
      } else {
        expect(nodes.length).toBe(0);
      }
      return this;
    }
  }
});

@Component({
  template: `
    <layout-ms #comp></layout-ms>
  `,
})
class TestComponent {
  @ViewChild('comp', { static: true }) comp: KissULayoutComponent;
}
