import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Payment } from 'src/app/payments/payments.component';
import { Pizza } from '../pizza/pizza.component';
import { Router } from '@angular/router';
import { Ingridient } from 'src/app/storage/ingridient/ingridient.component';
import { FormGroup, FormControl } from '@angular/forms';
import { PizzaNameComponent } from 'src/app/payments/pizzaNameComponent/pizzaName.component';

@Component({
    selector: 'app-userpizza',
    templateUrl: './userpizza.component.html'
})
export class UserPizzaComponent implements OnInit
{
    ingridients: Ingridient[];
    pizzaForm = new FormGroup({
        pizzaName: new FormControl('')
      });

    myIngridients: Ingridient[];

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
        httpClient.get<Ingridient[]>(baseUrl + 'api/storage').subscribe(result => {
            this.ingridients = result;
        }, error => console.error(error));
    }

    ngOnInit(){
     this.myIngridients = new Array<Ingridient>();   
    }

    AddIngridient(ingridient: Ingridient){
        const index: number = this.myIngridients.indexOf(ingridient);
        if (index == -1) {
            this.myIngridients.push(ingridient);
        }     
    }

    RemoveIngridient(ingridient: Ingridient){
        const index: number = this.myIngridients.indexOf(ingridient);
        if (index !== -1) {
            this.myIngridients.splice(index, 1);
        }        
    }

    onSubmit(){
        var pizza = new Pizza();
        pizza.name = this.pizzaForm.controls['pizzaName'].value;

        if (!pizza.name) {

          alert('Please, enter pizza name');
          return;
        }
        var ingridientIds = new Array<string>();
        var totalcost = 50.0;
        this.myIngridients.forEach(element => {
            ingridientIds.push(element.id);
            totalcost += element.price;
        });

        pizza.ingridientsIds = ingridientIds;
        pizza.price = totalcost;

        if (!pizza.ingridientsIds.some) {

          alert('Please, add ingridients to the pizza');
          return;
        }

        this.httpClient.post<Pizza>(this.baseUrl + 'api/pizza', pizza)
            .subscribe(error => console.error(error));

        alert('Your pizza recipe is created and you can order your pizza in menu!');
        this.router.navigateByUrl('/menu');
    }
}
