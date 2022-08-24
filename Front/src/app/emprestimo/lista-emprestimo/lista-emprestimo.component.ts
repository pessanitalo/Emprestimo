import { Component, OnInit } from '@angular/core';
import { Emprestimo } from '../models/emprestimo';
import { EmprestimoService } from '../services/emprestimo.service';

@Component({
  selector: 'app-lista-emprestimo',
  templateUrl: './lista-emprestimo.component.html',
  styleUrls: ['./lista-emprestimo.component.css']
})
export class ListaEmprestimoComponent implements OnInit {

  public emprestimos!: Emprestimo[];
  errorMessage!: string;

  constructor(private emprestimoService: EmprestimoService) { }

  ngOnInit(): void {
    this.getList();
  }

//teste123
  getList() {
    this.emprestimoService.list().subscribe(
      emprestimos => this.emprestimos = emprestimos,
      error => this.errorMessage
    );
  }

}
