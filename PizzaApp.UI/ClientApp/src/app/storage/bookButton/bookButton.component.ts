import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-bookButton',
    templateUrl: './bookButton.component.html'
})
export class BookButtonComponent 
{
    constructor(private httpClient: HttpClient) {}

    @Input() IngridientId: string;

    orderMore(){
        this.httpClient.put<string>('api/storage/' + this.IngridientId, this.IngridientId)
        .subscribe(success => window.location.reload(), error => console.log(error));
    }
}