import { EmprestimoService } from 'src/app/emprestimo/services/emprestimo.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Emprestimo } from '../models/emprestimo';



@Component({
  selector: 'app-novo-emprestimo',
  templateUrl: './novo-emprestimo.component.html',
  styleUrls: ['./novo-emprestimo.component.css']
})
export class NovoEmprestimoComponent implements OnInit {

  modalRef?: BsModalRef;
  public valorEmprestimo!: number;
  public quantidadeParcela!: number;

  public id!: number;

  public emprestimos!: Emprestimo;

  constructor(
    private emprestimoService: EmprestimoService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private route: Router,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.id = this.router.snapshot.params['id'];
  }

  novoEmprestimo() {
    this.emprestimoService.create(this.valorEmprestimo, this.quantidadeParcela, this.id)
      .subscribe(sucesso => { this.processarSucesso(sucesso) },
        falha => { console.log(falha) })
  }

  SimularEmprestimo() {
    this.emprestimoService.SimularEmprestimo(this.valorEmprestimo, this.quantidadeParcela)
      .subscribe(sucesso => { console.log(sucesso) },
        falha => { console.log(falha) })
  }

  openModal(template: TemplateRef<any>) {
    this.emprestimoService.SimularEmprestimo(this.valorEmprestimo, this.quantidadeParcela)
    .subscribe((res) => { this.emprestimos = res;
      this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
    })
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
    this.toastr.error('Houve algum erro', 'Error!');
  }
}
