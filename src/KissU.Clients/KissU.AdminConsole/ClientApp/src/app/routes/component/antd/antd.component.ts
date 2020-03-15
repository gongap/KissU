import { Component, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService, NzTreeNodeOptions, NzNotificationService } from 'ng-zorro-antd';

@Component({
  selector: 'component-antd',
  templateUrl: './antd.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompAntdComponent {
  value: any;
  tabs = [1, 2, 3];

  nodes: NzTreeNodeOptions[] = [
    {
      title: 'parent 1',
      key: '100',
      selected: true,
      children: [
        {
          title: 'parent 1-0',
          key: '1001',
          disabled: true,
          children: [
            {
              title: 'leaf 1-0-0',
              key: '10010',
              disableCheckbox: true,
              isLeaf: true,
            },
            { title: 'leaf 1-0-1', key: '10011', isLeaf: true, checked: true },
          ],
        },
        {
          title: 'parent 1-1',
          key: '1002',
          children: [{ title: 'leaf 1-1-0', key: '10020', isLeaf: true }],
        },
      ],
    },
  ];

  isVisible = false;

  showModal(): void {
    this.isVisible = true;
  }

  handleOk(): void {
    this.msg.success('Button ok clicked!');
    this.isVisible = false;
  }

  handleCancel(): void {
    this.msg.info('Button cancel clicked!');
    this.isVisible = false;
  }

  constructor(public msg: NzMessageService, public notify: NzNotificationService) {}
}
