import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.scss'],
})
export class QuoteComponent {
  @Input() id: number;
  @Input() phrase: string;
  @Input() attribution: string;
}
