import { Emprestimo } from './../models/emprestimo';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { pedirEmprestimo } from '../models/pedirEmprestimo';
import { PaginatedResult } from 'src/app/cliente/models/pagination';
import { map, take } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class EmprestimoService {

  baseUrl = `${environment.mainUrlAPI}emprestimo`;

  constructor(private http: HttpClient) { }

  public pagination(page?: number, itemsPerPage?: number): Observable<PaginatedResult<Emprestimo[]>> {
    const paginatedResult: PaginatedResult<Emprestimo[]> = new PaginatedResult<Emprestimo[]>();

    let params = new HttpParams;

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }
    return this.http
      .get<Emprestimo[]>(`${this.baseUrl}/listaEmprestimos`, { observe: 'response', params })
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

  // list(): Observable<Emprestimo[]> {
  //   return this.http.get<Emprestimo[]>(`${this.baseUrl}/pagination`);
  // }

  obterPorId(id: number): Observable<Emprestimo> {
    return this.http.get<Emprestimo>(`${this.baseUrl}/${id}`);
  }

  create(pedirEmprestimo: pedirEmprestimo) {
    return this.http.post<pedirEmprestimo>(`${this.baseUrl}`, pedirEmprestimo);
  }

  SimularEmprestimo(valor: number, quantidade: number): Observable<Emprestimo> {
    const ValorEmprestimo = {
      valorEmprestimo: valor,
      QuantidadeParcelas: quantidade,
    }
    return this.http.post<Emprestimo>(`${this.baseUrl}/simular-emprestimo`, ValorEmprestimo);
  }
}
