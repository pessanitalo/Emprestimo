import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Cliente } from '../models/cliente';
import { PaginatedResult } from '../models/pagination';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ClienteServicesService {

  baseUrl = `${environment.mainUrlAPI}cliente`;

  constructor(private http: HttpClient) { }


//  list(cpf: string): Observable<Cliente[]> {
//   return this.http.get<Cliente[]>(`${this.baseUrl}/list/${cpf}`);
// }

public list(cpf: string, page?: number, itemsPerPage?: number): Observable<PaginatedResult<Cliente[]>> {
  const paginatedResult: PaginatedResult<Cliente[]> = new PaginatedResult<Cliente[]>();

  let params = new HttpParams;

  if (page != null && itemsPerPage != null) {
    params = params.append('pageNumber', page.toString());
    params = params.append('pageSize', itemsPerPage.toString());
  }

  return this.http
    .get<Cliente[]>(`${this.baseUrl}/list/${cpf}`, { observe: 'response', params })
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

  obterPorId(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.baseUrl}/getId/${id}`);
  }

  addCliente(cliente: Cliente) {
    return this.http.post<Cliente>(this.baseUrl, cliente);
  }
}
