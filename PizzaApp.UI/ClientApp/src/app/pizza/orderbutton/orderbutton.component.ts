import { Component,  Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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
        error => { this.router.navigateByUrl('/transactionerror')});
    }
}