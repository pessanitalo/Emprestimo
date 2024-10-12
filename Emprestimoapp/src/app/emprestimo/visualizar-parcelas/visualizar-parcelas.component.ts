import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { parcelas } from '../models/parcelas';
import { BoletoService } from '../services/boleto.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { PaginatedResult, Pagination } from 'src/app/cliente/models/pagination';

@Component({
  selector: 'app-visualizar-parcelas',
  templateUrl: './visualizar-parcelas.component.html',
  styleUrls: ['./visualizar-parcelas.component.css']
})
export class VisualizarParcelasComponent implements OnInit {

  modalRef?: BsModalRef;
  id!: number;
  public clienteId: number;
  parcelas!: parcelas[];
  public pagination = {} as Pagination;

  parcela!: number;
  valor!: number;

  constructor(
    private route: ActivatedRoute,
    private service: BoletoService,
    private toastr: ToastrService,
    private router: Router,
    private modalService: BsModalService

  ) { }

  public ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.clienteId = this.route.snapshot.params['clienteId'];
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
    this.service.pagination(this.id, this.pagination.currentPage, this.pagination.itemsPerPage).subscribe(
      (paginatedResult: PaginatedResult<parcelas[]>) => {
        this.parcelas = paginatedResult.result;
        this.pagination = paginatedResult.pagination;
      },
      falha => { console.log(falha) }
    )
  }

  pagarParcela(numeroparcela: number) {
    console.log(numeroparcela);
    this.service.pagarParcela(this.clienteId, numeroparcela, this.id)
      .subscribe({ next: () => this.processarSucesso(), error: () => this.processarFalha(), });
    this.closeModal();
  }

  processarSucesso() {
    let toast = this.toastr.success("Parcela paga com sucesso.", 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/emprestimo/list'])
      });
    }
  }

  openModal(template: TemplateRef<any>, parcela: number, valor: number) {
    this.parcela = parcela;
    this.valor = valor;
    this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
  }

  closeModal() {
    this.modalService.hide();
  }

  processarFalha() {
    this.toastr.warning("Não foi possível pagar essa parcela.", 'Error!');
  }
}




