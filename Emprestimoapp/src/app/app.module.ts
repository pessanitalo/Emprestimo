import { provideNgxMask  } from 'ngx-mask';
import { ModalModule } from 'ngx-bootstrap/modal';
import { EmprestimoModule } from './emprestimo/emprestimo.module';
import { ClienteModule } from './cliente/cliente.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FooterComponent } from './navegacao/footer/footer.component';
import { HomeComponent } from './navegacao/home/home.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ToastNoAnimationModule, ToastrModule } from 'ngx-toastr';
import { EmprestimoResolve } from './emprestimo/services/emprestimo.resolve';
import { BoletoResolve } from './emprestimo/services/boleto.resolve';


// const maskConfig: Partial<IConfig> = {
//   validation: false,
// };

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HomeComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ClienteModule,
    EmprestimoModule,
    NoopAnimationsModule,
    BrowserAnimationsModule,
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true
    })
  ],
  providers: [EmprestimoResolve, BoletoResolve, provideNgxMask()],
  bootstrap: [AppComponent]
})
export class AppModule { }
