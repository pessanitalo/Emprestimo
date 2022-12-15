import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Cliente } from '../models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteServicesService {

  baseUrl = `${environment.mainUrlAPI}cliente`;

  constructor(private http: HttpClient) { }


 filtro(nome: string): Observable<Cliente[]> {
  return this.http.get<Cliente[]>(`${this.baseUrl}/filtro/${nome}`);
}

list(nome: string): Observable<Cliente[]> {
  return this.http.get<Cliente[]>(`${this.baseUrl}/list`);
}
  obterPorId(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.baseUrl}/getId/${id}`);
  }

  addCliente(cliente: Cliente) {
    return this.http.post<Cliente>(this.baseUrl, cliente);
  }
}
