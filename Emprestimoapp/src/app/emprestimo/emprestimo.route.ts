import { NovoEmprestimoComponent } from './novo-emprestimo/novo-emprestimo.component';
import { ListaEmprestimoComponent } from './lista-emprestimo/lista-emprestimo.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VisualizarParcelasComponent } from './visualizar-parcelas/visualizar-parcelas.component';
import { BoletoResolve } from './services/boleto.resolve';


const routes: Routes = [
  { path: 'list', component: ListaEmprestimoComponent },
  { path: 'novoEmprestimo/:id', component: NovoEmprestimoComponent },
  { path: 'detalhesparcela/:id/:clienteId', component: VisualizarParcelasComponent, resolve: { parcelas: BoletoResolve } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmprestimoRoutingModule { }