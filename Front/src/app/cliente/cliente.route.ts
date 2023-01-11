import { DetalhesClienteComponent } from './detalhes-cliente/detalhes-cliente.component';
import { NovoClienteComponent } from './novo-cliente/novo-cliente.component';
import { ListaClienteComponent } from './lista-cliente/lista-cliente.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClienteResolve } from './services/cliente.resolve';

const routes: Routes = [
  { path: 'list', component: ListaClienteComponent },
  { path: 'new', component: NovoClienteComponent },
  { path: 'detalhes/:id', component: DetalhesClienteComponent, resolve: { cliente: ClienteResolve } },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteRoutingModule { }