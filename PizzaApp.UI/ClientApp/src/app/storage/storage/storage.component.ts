import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-storage',
    templateUrl: './storage.component.html'
})
export class StorageComponent {
  public ingridients: Ingridient[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Ingridient[]>(baseUrl + 'api/storage').subscribe(result => {
      this.ingridients = result;
    }, error => console.error(error));
  }
}

interface Ingridient {
    id: string;
    name: string;
    count: number;
    price: number;
}