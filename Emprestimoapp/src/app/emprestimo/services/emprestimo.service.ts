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

  create(valor: number, quantidade: number, id: number) {
    const ValorEmprestimo = {
      ValorEmprestimo: valor,
      QuantidadeParcelas: quantidade,
      ClienteId: id
    }
    return this.http.post(`${this.baseUrl}`, ValorEmprestimo);
  }

  SimularEmprestimo(valor: number, quantidade: number) : Observable<Emprestimo> {
    const ValorEmprestimo = {
      valorEmprestimo: valor,
      QuantidadeParcelas: quantidade,
    }
    return this.http.post<Emprestimo>(`${this.baseUrl}/simular-emprestimo`, ValorEmprestimo);
  }
}
