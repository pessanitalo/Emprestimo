import { Emprestimo } from './../models/emprestimo';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmprestimoService {

  baseUrl = `${environment.mainUrlAPI}emprestimo`;

  constructor(private http: HttpClient) { }

  list(): Observable<Emprestimo[]> {
    return this.http.get<Emprestimo[]>(`${this.baseUrl}/list`);
  }

  obterPorId(id: number): Observable<Emprestimo> {
    return this.http.get<Emprestimo>(`${this.baseUrl}/${id}`);
  }

  create(id: number, emprestimo: Emprestimo) {
    return this.http.get<Emprestimo>(`${this.baseUrl}/${id}`);
  }

  update(valor: number, quantidade: number, id: number) {
    const ValorEmprestimo = {
      ValorEmprestimo: valor,
      QuantidadeParcelas: quantidade,
      id: id
    }
    return this.http.post(`${this.baseUrl}`, ValorEmprestimo);
  }
}
