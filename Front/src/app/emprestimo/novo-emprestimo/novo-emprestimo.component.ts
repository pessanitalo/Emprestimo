import { EmprestimoService } from 'src/app/emprestimo/services/emprestimo.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-novo-emprestimo',
  templateUrl: './novo-emprestimo.component.html',
  styleUrls: ['./novo-emprestimo.component.css']
})
export class NovoEmprestimoComponent implements OnInit {

  public valorEmprestimo!: number;
  public quantidadeParcela!: number;

  id: number = 3;

  constructor(private route: ActivatedRoute,
    private fb: FormBuilder,
    private emprestimoService: EmprestimoService
  ) { }

  ngOnInit(): void {
  }

  novoEmprestimo() {
    this.emprestimoService.update(this.valorEmprestimo, this.quantidadeParcela, this.id)
    .subscribe(sucesso => { alert('Emprestimo contratado com sucesso') },
          falha => { console.log(falha) })}
}
