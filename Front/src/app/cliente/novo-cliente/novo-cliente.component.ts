import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
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

    private route: ActivatedRoute
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
      .subscribe(sucesso => { alert('Cliente cadastrado') },
        falha => { console.log(falha) }
      )
  }

}
