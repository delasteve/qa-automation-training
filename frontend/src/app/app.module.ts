import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { QuoteListComponent } from './quote-list/quote-list.component';
import { AddEditQuoteComponent } from './add-edit-quote/add-edit-quote.component';
import { QuoteComponent } from './quote/quote.component';
import { DeleteQuoteDialogComponent } from './delete-quote-dialog/delete-quote-dialog.component';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatToolbarModule,
    AppRoutingModule,
  ],
  declarations: [AppComponent, QuoteListComponent, AddEditQuoteComponent, QuoteComponent, DeleteQuoteDialogComponent],
  bootstrap: [AppComponent],
  entryComponents: [DeleteQuoteDialogComponent],
})
export class AppModule {}
