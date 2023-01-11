import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from '../models/cliente';
import { ClienteServicesService } from '../services/cliente-services.service';


@Component({
  selector: 'app-novo-cliente',
  templateUrl: './novo-cliente.component.html',
  styleUrls: ['./novo-cliente.component.css']
})
export class NovoClienteComponent implements OnInit {

  cliente!: Cliente;
  clienteForm!: FormGroup;


  constructor(
    private clienteService: ClienteServicesService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService,
  ) {  }

  ngOnInit(): void {
    this.clienteForm = this.fb.group({
      nome: ['', [Validators.required]],
      idade: ['', [Validators.required]],
      score: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      saldoAtual: ['', [Validators.required]],
    });
  }

  novoCliente() {
    this.cliente = Object.assign({}, this.cliente, this.clienteForm.value);
    this.clienteService.addCliente(this.cliente)
      .subscribe(sucesso => { this.processarSucesso(sucesso) },
        falha => { console.log(falha) }
      )
  }

  processarSucesso(response: any) {
    this.clienteForm.reset();
    let toast = this.toastr.success('Cliente cadastrado', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/cliente/list'])
      });
    }
  }

  processarFalha(fail: any) {
    this.toastr.error('Houve algum erro', 'Error!');
  }
}
