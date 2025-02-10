import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrdenService {
  private apiUrl = 'http://localhost:5189/api/orden';  

  constructor(private http: HttpClient) { }

  getOrdenesPorCliente(customerId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${customerId}`);
  }

}
