import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { StorageComponent } from './storage/storage/storage.component';
import { BookButtonComponent } from './storage/bookButton/bookButton.component';
import { PizzaComponent } from './pizza/pizza/pizza.component';
import { MenuComponent } from './pizza/menu/menu.component';
import { IngridientComponent } from './storage/ingridient/ingridient.component';
import { PaymentsComponent } from './payments/payments.component';
import { PizzaNameComponent } from './payments/pizzaNameComponent/pizzaName.component';
import { OrderButtonComponent } from './pizza/orderbutton/orderbutton.component';
import { UserPizzaComponent } from './pizza/userpizza/userpizza.component';
import { TimeLeftComponent } from './payments/timeleft/timeleft.component';
import { TransactionErrorComponent } from './errors/transactionerror/trnsactionerror.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    StorageComponent,
    BookButtonComponent,
    PizzaComponent,
    MenuComponent,
    IngridientComponent,
    PaymentsComponent,
    PizzaNameComponent,
    OrderButtonComponent,
    UserPizzaComponent,
    TimeLeftComponent,
    TransactionErrorComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'transactionerror', component: TransactionErrorComponent },
      { path: 'userpizza', component: UserPizzaComponent },
      { path: 'payments', component: PaymentsComponent },
      { path: 'menu', component: MenuComponent },
      { path: 'storage', component: StorageComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
