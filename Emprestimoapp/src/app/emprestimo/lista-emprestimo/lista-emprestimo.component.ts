import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
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
  modalRef?: BsModalRef;

  public emprestimo!: Emprestimo;

  constructor(
    private emprestimoService: EmprestimoService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getList();
  }


  getList() {
    this.emprestimoService.list().subscribe(
      emprestimos => this.emprestimos = emprestimos,
      error => this.errorMessage
    );
  }

  openModal(template: TemplateRef<any>, emprestimo: Emprestimo) {
    this.emprestimoService.obterPorId(emprestimo.id).subscribe((res) => {
      this.emprestimo = res;
      this.modalRef = this.modalService.show(template, {class: 'modal-lg'});
    })
  }
}
