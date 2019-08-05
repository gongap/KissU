import { Component, ChangeDetectionStrategy } from '@angular/core';
import { SettingsService } from '@delon/theme';
import { StartupService } from "@core/startup/startup.service";

@Component({
  selector: 'layout-sidebar',
  templateUrl: './sidebar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidebarComponent {
  constructor(public settings: SettingsService, private startupService: StartupService ) {
  }

  ngOnInit() {
    this.startupService.load();
  }
}
