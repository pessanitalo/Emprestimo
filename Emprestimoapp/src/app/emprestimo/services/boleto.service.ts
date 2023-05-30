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

  obterPorId(id: number): Observable<Emprestimo[]> {
    return this.http.get<Emprestimo[]>(`${this.baseUrl}/detalhesparcela/${id}`);
  }

  verparcelas(id: number): Observable<parcelas[]> {
    return this.http.get<parcelas[]>(`${this.baseUrl}/detalhesparcela/${id}`);
  }

}
