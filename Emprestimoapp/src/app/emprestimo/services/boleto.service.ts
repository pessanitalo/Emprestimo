import { Emprestimo } from './../models/emprestimo';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { parcelas } from '../models/parcelas';
import { map, take } from 'rxjs';
import { PaginatedResult } from 'src/app/cliente/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class BoletoService {

  baseUrl = `${environment.mainUrlAPI}boleto`;

  constructor(private http: HttpClient) { }

  obterPorId(id: number): Observable<Emprestimo> {
    return this.http.get<Emprestimo>(`${this.baseUrl}/detalhesparcela/${id}`);
  }

  public pagination(id:number, page?: number, itemsPerPage?: number): Observable<PaginatedResult<parcelas[]>> {
    const paginatedResult: PaginatedResult<parcelas[]> = new PaginatedResult<parcelas[]>();

    let params = new HttpParams;

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }
    return this.http
      .get<parcelas[]>(`${this.baseUrl}/pagination/${id}`, { observe: 'response', params })
      .pipe(
        take(1),
        map((response) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination')) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        }));
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
