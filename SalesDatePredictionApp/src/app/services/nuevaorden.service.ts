import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NuevaOrdenService {
  private apiUrl = 'http://localhost:5189/api/OrdenNueva'; 

  constructor(private http: HttpClient) { }

  crearOrden(orden: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, orden);
  }
}
