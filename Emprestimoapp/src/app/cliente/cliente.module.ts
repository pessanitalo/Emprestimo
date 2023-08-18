import { ListaClienteComponent } from './lista-cliente/lista-cliente.component';
import { NovoClienteComponent } from './novo-cliente/novo-cliente.component';
import { ClienteRoutingModule } from './cliente.route';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClienteResolve } from './services/cliente.resolve';
import { ClienteServicesService } from './services/cliente-services.service';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { PaginationModule } from 'ngx-bootstrap/pagination';



@NgModule({
  declarations: [
   NovoClienteComponent,
   ListaClienteComponent,
  ],
  imports: [
    CommonModule,
    ClienteRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskDirective,
    NgxMaskPipe,
    PaginationModule.forRoot(),
  ],
  providers: [
    ClienteResolve,
    ClienteServicesService,
    provideNgxMask()
  ]
})
export class ClienteModule { }
