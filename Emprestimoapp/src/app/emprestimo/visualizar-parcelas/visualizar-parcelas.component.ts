import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { parcelas } from '../models/parcelas';
import { BoletoService } from '../services/boleto.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-visualizar-parcelas',
  templateUrl: './visualizar-parcelas.component.html',
  styleUrls: ['./visualizar-parcelas.component.css']
})
export class VisualizarParcelasComponent implements OnInit {

  id!: number;
  parcelas!: parcelas[];
  constructor(
    private route: ActivatedRoute,
    private service: BoletoService,
    private toastr: ToastrService,
    private router: Router,

  ) {
    this.parcelas = this.route.snapshot.data['parcelas'];
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
  }

  pagarParcela(numeroparcela: number) {
    this.service.pagarParcela(numeroparcela,this.id)
      .subscribe(sucesso => { this.processarSucesso(sucesso) },
        falha => { console.log(falha) })
  }

  processarSucesso(response: any) {
    let toast = this.toastr.success('Parcela Paga com sucesso!', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/emprestimo/list'])
      });
    }
  }

}
