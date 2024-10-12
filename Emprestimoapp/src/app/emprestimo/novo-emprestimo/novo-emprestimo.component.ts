import { EmprestimoService } from 'src/app/emprestimo/services/emprestimo.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Emprestimo } from '../models/emprestimo';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { pedirEmprestimo } from '../models/pedirEmprestimo';
import { ValidatorsService } from 'src/app/Utils/validators.service';

@Component({
  selector: 'app-novo-emprestimo',
  templateUrl: './novo-emprestimo.component.html',
  styleUrls: ['./novo-emprestimo.component.css']
})
export class NovoEmprestimoComponent implements OnInit {

  modalRef?: BsModalRef;

  Form!: UntypedFormGroup;

  public pedirEmprestimo!: pedirEmprestimo;

  public valorEmprestimo!: number;
  public quantidadeParcela!: number;

  public id!: number;
  public ClienteId!: number;

  public emprestimos!: Emprestimo;

  constructor(
    private emprestimoService: EmprestimoService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private route: Router,
    private fb: UntypedFormBuilder,
    private modalService: BsModalService,
    public validator: ValidatorsService
  ) { }


  ngOnInit(): void {
    this.id = this.router.snapshot.params['id'];
    console.log('id ', this.id);
    this.Form = this.fb.group({
      ClienteId: this.id,
      valorEmprestimo: ['', [Validators.required]],
      QuantidadeParcelas: ['', [Validators.required]]
    });
  }

  novoEmprestimo() {
    this.pedirEmprestimo = Object.assign({}, this.pedirEmprestimo, this.Form.value);
    this.emprestimoService.create(this.pedirEmprestimo)
      .subscribe(sucesso => { this.processarSucesso(sucesso) },
        falha => { this.processarFalha(falha) }
      );
    this.closeModal();
  }

  openModal(template: TemplateRef<any>) {
    if (this.Form.get('valorEmprestimo').value >= 1 && this.Form.get('QuantidadeParcelas').value >= 1) {
      this.pedirEmprestimo = Object.assign({}, this.pedirEmprestimo, this.Form.value);
      this.emprestimoService.SimularEmprestimo(this.pedirEmprestimo.valorEmprestimo, this.pedirEmprestimo.QuantidadeParcelas)
        .subscribe((res) => {
          this.emprestimos = res;
          this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
        });
      return true;
    }
    else {
      this.toastr.warning('Valor Inválido', 'Ops!')
      return false;
    }
  }

  processarSucesso(response: any) {
    let toast = this.toastr.success('Emprestimo solicitado com sucesso!', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.route.navigate(['/emprestimo/list'])
      });
    }
  }

  processarFalha(fail: any) {
    this.toastr.error('Houve algum erro', fail);
  }

  closeModal() {
    this.modalService.hide();
  }
}
