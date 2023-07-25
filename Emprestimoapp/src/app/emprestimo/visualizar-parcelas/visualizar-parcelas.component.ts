import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { parcelas } from '../models/parcelas';
import { BoletoService } from '../services/boleto.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-visualizar-parcelas',
  templateUrl: './visualizar-parcelas.component.html',
  styleUrls: ['./visualizar-parcelas.component.css']
})
export class VisualizarParcelasComponent implements OnInit {

  modalRef?: BsModalRef;
  id!: number;
  parcelas!: parcelas[];

  parcela!: number;
  valor!: number;

  constructor(
    private route: ActivatedRoute,
    private service: BoletoService,
    private toastr: ToastrService,
    private router: Router,
    private modalService: BsModalService

  ) {
    this.parcelas = this.route.snapshot.data['parcelas'];
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
  }

  pagarParcela(numeroparcela: number) {
    this.service.pagarParcela(numeroparcela, this.id)
      .subscribe(sucesso => { this.processarSucesso(sucesso) },
        falha => { console.log(falha) }),
      this.closeModal();
  }

  processarSucesso(response: any) {
    let toast = this.toastr.success('Parcela Paga com sucesso!', 'Sucesso!');
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
}




