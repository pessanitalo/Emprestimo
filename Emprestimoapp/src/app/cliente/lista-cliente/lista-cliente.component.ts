import { Cliente } from './../models/cliente';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { informationModel } from '../models/informationModel';
import { ClienteServicesService } from '../services/cliente-services.service';
import { PaginatedResult, Pagination } from '../models/pagination';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';


@Component({
  selector: 'app-lista-cliente',
  templateUrl: './lista-cliente.component.html',
  styleUrls: ['./lista-cliente.component.css']
})
export class ListaClienteComponent implements OnInit {

  @ViewChild('modal') public modal: any;

  public clientes!: Cliente[];
  public cliente!: Cliente;

  errorMessage!: string;

  cpf: string = "";

  public pagination = {} as Pagination;
  modalRef?: BsModalRef;

  constructor(
    private clienteService: ClienteServicesService,
    private modalService: BsModalService
  ) { }

  public ngOnInit(): void {
    this.pagination = {
      currentPage: 1,
      itemsPerPage: 10,
      totalItems: 1,
    } as Pagination;
    this.carregarLista();
  }

  public pageChanged(event): void {
    this.pagination.currentPage = event.page;
    this.carregarLista();
  }

  getModal() {
    return this.modal
  }

  // filtro() {
  //   this.clienteService.list(this.cpf, this.pagination.currentPage, this.pagination.itemsPerPage).subscribe(
  //     clientes => PaginatedResult <Cliente[]>> = clientes,
  //     error => this.errorMessage
  //   );
  // }

  public carregarLista(): void {
    this.clienteService.list(this.cpf, this.pagination.currentPage, this.pagination.itemsPerPage).subscribe(
      (paginatedResult: PaginatedResult<Cliente[]>) => {
        this.clientes = paginatedResult.result;
        this.pagination = paginatedResult.pagination;
      },
      (error: any) => {
        console.log()
      }
    )
  }

  openModal(template: TemplateRef<any>, cliente: Cliente) {
    this.clienteService.obterPorId(cliente.id)
      .subscribe((res) => {
        this.cliente = res;
        this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
      })
  }
}