import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
    selector: 'app-payments',
    templateUrl: './payments.component.html'
})
export class PaymentsComponent{
    public payments: Payment[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
      http.get<Payment[]>(baseUrl + 'api/payment')
        .subscribe
        (
            (result) => { this.payments = result;}, 
            (error) => router.navigateByUrl('./transactionerror')
        );
    }
}

export class Payment {
    id: string;
    price: number;
    time: string;
    pizzaId: string;
}