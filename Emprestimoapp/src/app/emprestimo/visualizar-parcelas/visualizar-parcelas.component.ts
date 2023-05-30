import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { parcelas } from '../models/parcelas';

@Component({
  selector: 'app-visualizar-parcelas',
  templateUrl: './visualizar-parcelas.component.html',
  styleUrls: ['./visualizar-parcelas.component.css']
})
export class VisualizarParcelasComponent implements OnInit {

  id!: number;
  parcela!: parcelas;
  parcelas!: parcelas[];
  constructor(
    private route: ActivatedRoute,
  ) { this.parcelas = this.route.snapshot.data['boleto'] }

  ngOnInit(): void {
  }

}
