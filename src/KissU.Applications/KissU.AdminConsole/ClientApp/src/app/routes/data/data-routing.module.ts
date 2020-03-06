import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DataLayoutComponent } from './_layout/layout.component';
import { DataSummaryComponent } from './summary/summary.component';
import { DataHealthyComponent } from './healthy/healthy.component';
import { DataMermaidComponent } from './mermaid/mermaid.component';
import { DataGanttComponent } from './gantt/gantt.component';
import { DataTrendComponent } from './trend/trend.component';

const routes: Routes = [
  {
    path: '',
    component: DataLayoutComponent,
    children: [
      { path: '', redirectTo: 'summary', pathMatch: 'full' },
      { path: 'summary', component: DataSummaryComponent },
      { path: 'healthy', component: DataHealthyComponent },
      { path: 'mermaid', component: DataMermaidComponent },
      { path: 'gantt', component: DataGanttComponent },
      { path: 'trend', component: DataTrendComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DataRoutingModule {}
