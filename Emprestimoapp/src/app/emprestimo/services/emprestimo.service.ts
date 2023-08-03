import { Emprestimo } from './../models/emprestimo';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { pedirEmprestimo } from '../models/pedirEmprestimo';


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

  create(pedirEmprestimo: pedirEmprestimo) {
    return this.http.post<pedirEmprestimo>(`${this.baseUrl}`, pedirEmprestimo);
  }

  SimularEmprestimo(valor: number, quantidade: number) : Observable<Emprestimo> {
    const ValorEmprestimo = {
      valorEmprestimo: valor,
      QuantidadeParcelas: quantidade,
    }
    return this.http.post<Emprestimo>(`${this.baseUrl}/simular-emprestimo`, ValorEmprestimo);
  }
}
