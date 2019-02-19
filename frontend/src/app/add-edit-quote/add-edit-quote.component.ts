import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { switchMap, filter, tap } from 'rxjs/operators';

import { DeleteQuoteDialogComponent } from '../delete-quote-dialog/delete-quote-dialog.component';
import { environment } from '../../environments/environment';
import { Quote } from '../models/quote';

@Component({
  selector: 'app-add-edit-quote',
  templateUrl: './add-edit-quote.component.html',
  styleUrls: ['./add-edit-quote.component.scss'],
})
export class AddEditQuoteComponent implements OnInit {
  form: FormGroup;
  isEditing: boolean;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private dialog: MatDialog,
  ) {}

  ngOnInit() {
    this.isEditing = this.route.snapshot.params.id !== undefined;

    this.form = this.formBuilder.group({
      phrase: ['', [Validators.required]],
      attribution: ['', [Validators.required]],
    });

    if (this.isEditing) {
      this.http.get<Quote>(`${environment.apiUrl}/quotes/${this.route.snapshot.params.id}`).subscribe(quote => {
        this.form.patchValue({
          phrase: quote.phrase,
          attribution: quote.attribution,
        });
      });
    }
  }

  onSubmit() {
    if (this.form.invalid) {
      return;
    }

    let observable$;

    if (this.isEditing) {
      observable$ = this.http.put<Quote>(`${environment.apiUrl}/quotes/${this.route.snapshot.params.id}`, this.form.value);
    } else {
      observable$ = this.http.post<Quote>(`${environment.apiUrl}/quotes`, this.form.value);
    }

    observable$.subscribe(() => this.router.navigate(['']));
  }

  openDeleteConfirmationDialog() {
    const dialogRef = this.dialog.open(DeleteQuoteDialogComponent);

    dialogRef
      .afterClosed()
      .pipe(
        filter(result => result),
        switchMap(() => this.http.delete(`${environment.apiUrl}/quotes/${this.route.snapshot.params.id}`)),
        tap(() => this.router.navigate([''])),
      )
      .subscribe();
  }
}
