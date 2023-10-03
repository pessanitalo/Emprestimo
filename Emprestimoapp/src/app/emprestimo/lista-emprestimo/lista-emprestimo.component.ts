import { parcelas } from './../models/parcelas';
import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Emprestimo } from '../models/emprestimo';
import { EmprestimoService } from '../services/emprestimo.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PaginatedResult, Pagination } from 'src/app/cliente/models/pagination';

@Component({
  selector: 'app-lista-emprestimo',
  templateUrl: './lista-emprestimo.component.html',
  styleUrls: ['./lista-emprestimo.component.css']
})
export class ListaEmprestimoComponent implements OnInit {

  public emprestimos!: Emprestimo[];
  public parcelas!: parcelas[];

  public parcela!: parcelas;
  public pagination = {} as Pagination;

  errorMessage!: string;
  modalRef?: BsModalRef;

  public emprestimo!: Emprestimo;

  constructor(
    private emprestimoService: EmprestimoService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private route: Router,
    private modalService: BsModalService) { }

  public ngOnInit(): void {
    this.pagination = {
      currentPage: 1,
      itemsPerPage: 12,
      totalItems: 1,
    } as Pagination;
    this.carregarLista();
  }

  public pageChanged(event): void {
    this.pagination.currentPage = event.page;
    this.carregarLista();
  }

  public carregarLista(): void {
    this.emprestimoService.pagination(this.pagination.currentPage, this.pagination.itemsPerPage).subscribe(
      (paginatedResult: PaginatedResult<Emprestimo[]>) => {
        this.emprestimos = paginatedResult.result;
        this.pagination = paginatedResult.pagination;
      },
      falha => { console.log(falha) }
    )
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
