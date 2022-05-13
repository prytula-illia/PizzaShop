import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-pizza',
    templateUrl: './pizza.component.html'
})
export class PizzaComponent {
    @Input() pizza: IPizza;
}

export interface IPizza {
    id: string;
    name: string;
    price: number;
    ingridientsIds: string[];
}

export class Pizza implements Pizza {
    id: string;
    name: string;
    price: number;
    ingridientsIds: string[];
}