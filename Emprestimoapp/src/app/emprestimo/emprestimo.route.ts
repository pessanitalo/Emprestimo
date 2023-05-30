import { NovoEmprestimoComponent } from './novo-emprestimo/novo-emprestimo.component';
import { ListaEmprestimoComponent } from './lista-emprestimo/lista-emprestimo.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmprestimoResolve } from './services/emprestimo.resolve';
import { VisualizarParcelasComponent } from './visualizar-parcelas/visualizar-parcelas.component';
import { BoletoResolve } from './services/boleto.resolve';


const routes: Routes = [
  { path: 'list', component: ListaEmprestimoComponent },
  { path: 'novoEmprestimo/:id', component: NovoEmprestimoComponent },
  { path: 'detalhesparcela/:id', component: VisualizarParcelasComponent, resolve: { boleto: BoletoResolve } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmprestimoRoutingModule { }