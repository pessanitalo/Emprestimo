import { EmprestimoResolve } from './services/emprestimo.resolve';
import { EmprestimoService } from './services/emprestimo.service';

import { EmprestimoRoutingModule } from './emprestimo.route';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListaEmprestimoComponent } from './lista-emprestimo/lista-emprestimo.component';
import { NovoEmprestimoComponent } from './novo-emprestimo/novo-emprestimo.component';
import { VisualizarParcelasComponent } from './visualizar-parcelas/visualizar-parcelas.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';



@NgModule({
  declarations: [
    ListaEmprestimoComponent,
    NovoEmprestimoComponent,
    VisualizarParcelasComponent
  ],
  imports: [
    CommonModule,
    EmprestimoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    PaginationModule.forRoot(),
  ],
  providers:[
    EmprestimoService,
    EmprestimoResolve
  ]

})
export class EmprestimoModule { }
