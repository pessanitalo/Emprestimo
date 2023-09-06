import { Emprestimo } from './../models/emprestimo';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { parcelas } from '../models/parcelas';

@Injectable({
  providedIn: 'root'
})
export class BoletoService {

  baseUrl = `${environment.mainUrlAPI}boleto`;

  constructor(private http: HttpClient) { }

  obterPorId(id: number): Observable<Emprestimo> {
    return this.http.get<Emprestimo>(`${this.baseUrl}/detalhesparcela/${id}`);
  }

  pagarParcela(clienteId: number,numeroDaParcela: number, id: number) {
    const pagarParcela = {
      id: id,
      clienteId: clienteId,
      numeroParcela: numeroDaParcela
    }
    return this.http.post(`${this.baseUrl}/pagarparcela`, pagarParcela);
  }
}
