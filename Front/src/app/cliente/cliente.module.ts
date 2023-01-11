import { ListaClienteComponent } from './lista-cliente/lista-cliente.component';
import { NovoClienteComponent } from './novo-cliente/novo-cliente.component';
import { DetalhesClienteComponent } from './detalhes-cliente/detalhes-cliente.component';
import { ClienteRoutingModule } from './cliente.route';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClienteResolve } from './services/cliente.resolve';
import { ClienteServicesService } from './services/cliente-services.service';
import { NgxMaskModule } from 'ngx-mask';


@NgModule({
  declarations: [
   DetalhesClienteComponent,
   NovoClienteComponent,
   ListaClienteComponent,
  ],
  imports: [
    CommonModule,
    ClienteRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
  ],
  providers: [
    ClienteResolve,
    ClienteServicesService
  ]
})
export class ClienteModule { }
