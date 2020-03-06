import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FinanceLayoutComponent } from './_layout/layout.component';
import { FinanceHomeComponent } from './home/home.component';
import { FinanceBillComponent } from './bill/bill.component';
import { FinanceInvoiceComponent } from './invoice/invoice.component';

const routes: Routes = [
  {
    path: '',
    component: FinanceLayoutComponent,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: FinanceHomeComponent },
      { path: 'bill', component: FinanceBillComponent },
      { path: 'invoice', component: FinanceInvoiceComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FinanceRoutingModule {}
