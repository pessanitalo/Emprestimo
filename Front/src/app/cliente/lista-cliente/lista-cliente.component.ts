import { Cliente } from './../models/cliente';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { informationModel } from '../models/informationModel';
import { ClienteServicesService } from '../services/cliente-services.service';


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
  information!: informationModel;

  nome: string = "";

  modalRef?: BsModalRef;

  constructor(
    private clienteService: ClienteServicesService,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    //this.filtro();
    this.list();
  }

  getModal(){
    return this.modal
  }

  // getList() {
  //   this.clienteService.list(this.nome).subscribe(
  //     clientes => this.clientes = clientes,
  //     error => this.errorMessage
  //   );
  // }

  filtro() {
    this.clienteService.filtro(this.nome).subscribe(
      clientes => this.clientes = clientes,
      error => this.errorMessage
    );
  }

  list() {
    this.clienteService.list(this.nome).subscribe(
      clientes => this.clientes = clientes,
      error => this.errorMessage
    );
  }


  openModal(template: TemplateRef<any>, cliente: Cliente) {
    this.clienteService.obterPorId(cliente.id).subscribe((res) => {
      this.cliente = res;
      this.modalRef = this.modalService.show(template, {class: 'modal-lg'});
    })
  }
}
