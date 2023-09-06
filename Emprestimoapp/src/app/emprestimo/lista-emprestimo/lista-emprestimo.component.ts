import { parcelas } from './../models/parcelas';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Emprestimo } from '../models/emprestimo';
import { EmprestimoService } from '../services/emprestimo.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { VisualizarParcelasComponent } from '../visualizar-parcelas/visualizar-parcelas.component';

@Component({
  selector: 'app-lista-emprestimo',
  templateUrl: './lista-emprestimo.component.html',
  styleUrls: ['./lista-emprestimo.component.css']
})
export class ListaEmprestimoComponent implements OnInit {

  public emprestimos!: Emprestimo[];
  public parcelas!: parcelas[];

  public parcela!: parcelas;

  errorMessage!: string;
  modalRef?: BsModalRef;

  public emprestimo!: Emprestimo;

  constructor(
    private emprestimoService: EmprestimoService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private route: Router,
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

  processarSucesso(response: any) {
    let toast = this.toastr.success('Emprestimo solicitado com sucesso!', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.route.navigate(['/cliente/list'])
      });
    }
  }
}
