import { NovoEmprestimoComponent } from './novo-emprestimo/novo-emprestimo.component';
import { ListaEmprestimoComponent } from './lista-emprestimo/lista-emprestimo.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmprestimoResolve } from './services/emprestimo.resolve';


const routes: Routes = [
  { path: 'list', component: ListaEmprestimoComponent },
  { path: 'novoEmprestimo/:id', component: NovoEmprestimoComponent, resolve: { cliente: EmprestimoResolve } },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmprestimoRoutingModule { }