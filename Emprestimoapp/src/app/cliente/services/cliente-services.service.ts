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


 list(cpf: string): Observable<Cliente[]> {
  return this.http.get<Cliente[]>(`${this.baseUrl}/list/${cpf}`);
}


  obterPorId(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.baseUrl}/getId/${id}`);
  }

  addCliente(cliente: Cliente) {
    return this.http.post<Cliente>(this.baseUrl, cliente);
  }
}
