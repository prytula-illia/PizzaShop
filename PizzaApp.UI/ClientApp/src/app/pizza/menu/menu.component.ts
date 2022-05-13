import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html'
})
export class MenuComponent {
  public pizzas: Pizza[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    http.get<Pizza[]>(baseUrl + 'api/pizza').subscribe(result => {
      this.pizzas = result;
    }, error => console.error(error));
  }

  public redirectToPizzaWithIngridients(){
    this.router.navigateByUrl('/userpizza');
  }
}

interface Pizza {
    id: string;
    name: string;
    price: number;
    ingridients: string[];
}