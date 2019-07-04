/**
 * @license
 * Copyright Alibaba.com All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/NG-ZORRO/ng-zorro-antd/blob/master/LICENSE
 */
import { TemplateRef, ViewContainerRef } from '@angular/core';
export declare class NzStringTemplateOutletDirective {
    private viewContainer;
    private defaultTemplate;
    private isTemplate;
    private inputTemplate;
    private inputViewRef;
    private defaultViewRef;
    constructor(viewContainer: ViewContainerRef, defaultTemplate: TemplateRef<void>);
    nzStringTemplateOutlet: string | TemplateRef<void>;
    updateView(): void;
}
