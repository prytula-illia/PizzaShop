import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-ingridient',
    templateUrl: './ingridient.component.html'
})
export class IngridientComponent implements OnInit {
  @Input() ingridientId: string;
  public myIngridient: Ingridient;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(){
    this.http.get<Ingridient>(this.baseUrl + 'api/storage/' + this.ingridientId).subscribe(result => {
      this.myIngridient = result;
    }, error => console.error(error));
  }
}

export class Ingridient {
    id: string;
    name: string;
    count: number;
    price: number;
}