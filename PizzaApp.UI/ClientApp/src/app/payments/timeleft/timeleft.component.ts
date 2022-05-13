import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pizza } from 'src/app/pizza/pizza/pizza.component';
import { Payment } from '../payments.component';

@Component({
    selector: 'app-timeleft',
    template: "<button class='btn btn-secondary' (click)='howMuchTime()'>Time left</button>"
})
export class TimeLeftComponent {
  @Input() Payment: Payment;

  howMuchTime(){
    let today = new Date();
    let paytime = new Date(this.Payment.time);
    let diff = today.getTime() - paytime.getTime();

    if(diff < 60000){
        alert('Your pizza will be ready in one minute!');
    }
    else if (diff < 120 * 60000){
        alert('Pizza is ready!');
    }
    else {
        alert('Pizza was ready ages ago!');
    }
  }
}
