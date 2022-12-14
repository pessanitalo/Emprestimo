import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EmprestimoService } from 'src/app/emprestimo/services/emprestimo.service';
import { Cliente } from '../models/cliente';

@Component({
  selector: 'app-novo-emprestimo',
  templateUrl: './novo-emprestimo.component.html',
  styleUrls: ['./novo-emprestimo.component.css']
})
export class NovoEmprestimoComponent implements OnInit {

  form!: FormGroup;
  cliente!: Cliente;
  constructor(
    private emprestimoServi: EmprestimoService,
    private fb: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    // this.form = this.fb.group({
    //   valorTotal: ['', [Validators.required]],
    //   quantidadeParcelas: ['', [Validators.required]]
    };

  }

