import { EmprestimoService } from 'src/app/emprestimo/services/emprestimo.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

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
    private router: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.id = this.router.snapshot.params['id'];
  }

  novoEmprestimo() {
    this.emprestimoService.create(this.valorEmprestimo, this.quantidadeParcela, this.id)
      .subscribe(sucesso => { alert('Emprestimo contratado com sucesso') },
        falha => { console.log(falha) })
  }
}
