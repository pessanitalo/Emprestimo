import { EmprestimoService } from 'src/app/emprestimo/services/emprestimo.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/cliente/models/cliente';

@Component({
  selector: 'app-novo-emprestimo',
  templateUrl: './novo-emprestimo.component.html',
  styleUrls: ['./novo-emprestimo.component.css']
})
export class NovoEmprestimoComponent implements OnInit {

  public valorEmprestimo!: number;
  public quantidadeParcela!: number;

  public id!: number;

  constructor(
    private emprestimoService: EmprestimoService,
    private router: ActivatedRoute,
    private toastr: ToastrService,
    private route: Router,
  ) { }

  ngOnInit(): void {
    this.id = this.router.snapshot.params['id'];
  }

  novoEmprestimo() {
    this.emprestimoService.create(this.valorEmprestimo, this.quantidadeParcela, this.id)
      .subscribe(sucesso => { this.processarSucesso(sucesso) },
        falha => { console.log(falha) })
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
