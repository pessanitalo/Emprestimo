import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from '../models/cliente';
import { ClienteServicesService } from '../services/cliente-services.service';
import { ValidatorsService } from 'src/app/Utils/validators.service';


@Component({
  selector: 'app-novo-cliente',
  templateUrl: './novo-cliente.component.html',
  styleUrls: ['./novo-cliente.component.css']
})
export class NovoClienteComponent implements OnInit {

  cliente!: Cliente;
  Form!: UntypedFormGroup;

  validate!: string;

  constructor(
    private clienteService: ClienteServicesService,
    private fb: UntypedFormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    public validator: ValidatorsService
  ) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      idade: ['', [Validators.required]],
      score: ['', [Validators.required]],
      cpf: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      saldoAtual: ['', [Validators.required]],
    });
  }

  novoCliente() {
    this.cliente = Object.assign({}, this.cliente, this.Form.value);
    this.clienteService.addCliente(this.cliente)
      .subscribe(sucesso => { this.processarSucesso(sucesso) },
        falha => { this.processarFalha(falha) }
      )
  }

  processarSucesso(response: any) {
    this.Form.reset();
    let toast = this.toastr.success('Cliente cadastrado', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/cliente/list'])
      });
    }
  }

  processarFalha(fail: any) {
    this.toastr.warning( fail.error, 'Error!' );
   }
}
