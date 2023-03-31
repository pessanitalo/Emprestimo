import { NovoClienteComponent } from './novo-cliente/novo-cliente.component';
import { ListaClienteComponent } from './lista-cliente/lista-cliente.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'list', component: ListaClienteComponent },
  { path: 'new', component: NovoClienteComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteRoutingModule { }