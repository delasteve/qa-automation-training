import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Quote } from '../models/quote';

@Component({
  selector: 'app-quote-list',
  templateUrl: './quote-list.component.html',
  styleUrls: ['./quote-list.component.scss'],
})
export class QuoteListComponent implements OnInit {
  quotes$: Observable<any[]>;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.quotes$ = this.http
      .get<Quote[]>('${environment.apiUrl}/quotes')
      .pipe(map(quotes => quotes.sort((a, b) => (new Date(a.createdAt) > new Date(b.createdAt) ? -1 : 1))));
  }
}
