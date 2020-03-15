import { Component, ChangeDetectionStrategy } from '@angular/core';
import { STColumn } from '@delon/abc';

@Component({
  selector: 'api-groups',
  templateUrl: './groups.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class APIGroupsComponent {
  data = [];
  columns: STColumn[] = [{ title: '序号', type: 'no' }, { title: '名称' }, { title: '数量' }, { title: '操作' }];
}
