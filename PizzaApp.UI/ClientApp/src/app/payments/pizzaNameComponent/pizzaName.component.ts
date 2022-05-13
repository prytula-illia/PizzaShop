import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pizza } from 'src/app/pizza/pizza/pizza.component';

@Component({
    selector: 'app-pizzaNaming',
    template: '<p>{{ pizzaName }}</p>'
})
export class PizzaNameComponent implements OnInit{
  @Input() PizzaId: string;
  public pizzaName: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit(){
    this.http.get<Pizza>(this.baseUrl + 'api/pizza/' + this.PizzaId).subscribe(result => {
      this.pizzaName = result.name;
    }, error => console.error(error));
  }
}