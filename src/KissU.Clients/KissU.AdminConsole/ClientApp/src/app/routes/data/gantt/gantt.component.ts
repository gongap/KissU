import { Component, ChangeDetectionStrategy, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { LazyService } from '@delon/util';
import { NzMessageService } from 'ng-zorro-antd';

declare var Gantt: any;

// #region MOCK TASKS DATA

const names = [
  ['Redesign website', [0, 7]],
  ['Write new content', [1, 4]],
  ['Apply new styles', [3, 6]],
  ['Review', [7, 7]],
  ['Deploy', [8, 9]],
  ['Go Live!', [10, 10]],
];
const TASKS: any = names.map((name: any, i: any) => {
  const today = new Date();
  const start = new Date(today.getFullYear(), today.getMonth(), today.getDate());
  const end = new Date(today.getFullYear(), today.getMonth(), today.getDate());
  start.setDate(today.getDate() + name[1][0]);
  end.setDate(today.getDate() + name[1][1]);
  return {
    start,
    end,
    name: name[0],
    id: `Task ${i}`,
    progress: parseInt((Math.random() * 100).toString(), 10),
  };
});
TASKS[1].dependencies = 'Task 0';
TASKS[2].dependencies = 'Task 1';
TASKS[3].dependencies = 'Task 2';
TASKS[5].dependencies = 'Task 4';

// #endregion

@Component({
  selector: 'app-data-gantt',
  templateUrl: './gantt.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DataGanttComponent implements OnInit {
  inited = false;
  gantt: any;
  options: any = {
    header_height: 50,
    column_width: 30,
    step: 24,
    view_modes: ['Quarter Day', 'Half Day', 'Day', 'Week', 'Month'],
    bar_height: 20,
    bar_corner_radius: 3,
    arrow_curve: 5,
    padding: 18,
    view_mode: 'Day',
    date_format: 'YYYY-MM-DD',
    custom_popup_html: null,
    on_click: (task: any) => {
      this.msg.info(`click: ${task.name}`);
    },
    on_date_change: (task: any, start: any, end: any) => {
      this.msg.info(`date change: ${task.name}, from: ${start}, end: ${end}`);
    },
    on_progress_change: (task: any, progress: any) => {
      this.msg.info(`progress change: ${task.name}, progress: ${progress}`);
    },
    on_view_change: (mode: string) => {
      this.msg.info(`view change: ${mode}`);
    },
  };
  tasks: any[] = TASKS;
  type = 'Day';

  constructor(
    private lazy: LazyService,
    private msg: NzMessageService,
    private ngZone: NgZone,
    private cdr: ChangeDetectorRef,
  ) {}

  private init() {
    const { cdr, tasks, options } = this;
    this.inited = true;
    cdr.detectChanges();
    this.ngZone.runOutsideAngular(() => (this.gantt = new Gantt('#gantt', tasks, options)));
  }

  typeChange() {
    const { gantt, type } = this;
    this.ngZone.runOutsideAngular(() => gantt.change_view_mode(type));
  }

  ngOnInit(): void {
    this.lazy
      .load([
        'https://unpkg.com/frappe-gantt@0.3.0/dist/frappe-gantt.css',
        'https://unpkg.com/frappe-gantt@0.3.0/dist/frappe-gantt.min.js',
      ])
      .then(() => this.init());
  }
}
