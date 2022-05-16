import { Component,  Input } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Payment } from 'src/app/payments/payments.component';
import { Pizza } from '../pizza/pizza.component';
import { Router } from '@angular/router';

@Component({
    selector: 'app-orderbutton',
    templateUrl: './orderbutton.component.html'
})
export class OrderButtonComponent 
{
    constructor(private httpClient: HttpClient, private router: Router) {}

    @Input() Pizza: Pizza;

    makeOrder(){
        var payment = new Payment();
        payment.pizzaId = this.Pizza.id;
        payment.price = this.Pizza.price;
        this.httpClient.post<Payment>('api/payment', payment).subscribe(data => {
            this.router.navigateByUrl('/payments');
        },
          error => {
            if (error instanceof HttpErrorResponse) {
              if (error.error instanceof ErrorEvent) {
                console.error("Error Event");
              } else {
                console.log(`error status : ${error.status} ${error.statusText}`);
                switch (error.status) {
                  case 500:
                    this.router.navigateByUrl("/storageerror");
                    break;
                  case 502:
                    this.router.navigateByUrl("/transactionerror");
                    break;
                }
              }
            } else {
              console.error("something else happened");
            }
          });
    }
}
