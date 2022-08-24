import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Emprestimo } from '../models/emprestimo';

@Component({
  selector: 'app-novo-emprestimo',
  templateUrl: './novo-emprestimo.component.html',
  styleUrls: ['./novo-emprestimo.component.css']
})
export class NovoEmprestimoComponent implements OnInit {

  form!: FormGroup;
  emprestimo!: Emprestimo;
 
  constructor(private route: ActivatedRoute,  private fb: FormBuilder) { this.emprestimo = this.route.snapshot.data['emprestimo']}

  ngOnInit(): void {
    this.form = this.fb.group({
      valorTotal: ['', [Validators.required]],
      quantidadeParcelas: ['', [Validators.required]]
    });
  }
}
