import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuoteListComponent } from './quote-list/quote-list.component';
import { AddEditQuoteComponent } from './add-edit-quote/add-edit-quote.component';

const routes: Routes = [
  {
    path: '',
    component: QuoteListComponent,
    pathMatch: 'full',
  },
  {
    path: 'new',
    component: AddEditQuoteComponent,
  },
  {
    path: ':id',
    component: AddEditQuoteComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
