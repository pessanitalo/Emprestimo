import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Emprestimo } from '../models/emprestimo';

@Injectable({
  providedIn: 'root'
})
export class EmprestimoService {

  baseUrl = `${environment.mainUrlAPI}emprestimo`;
  
  constructor(private http: HttpClient) { }

  list(): Observable<Emprestimo[]> {
    return this.http.get<Emprestimo[]>(this.baseUrl);
  }

  obterPorId(id: number): Observable<Emprestimo> {
    return this.http.get<Emprestimo>(`${this.baseUrl}/${id}`);
}
}
