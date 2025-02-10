import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private apiUrl = 'http://localhost:5189/api/cliente';  

  constructor(private http: HttpClient) { }

  //getClientes(): Observable<any[]> {
  //  return this.http.get<any[]>(this.apiUrl);
  //}
  getClientes(searchTerm: string = ''): Observable<any[]> {
    let params = new HttpParams();
    if (searchTerm) {
      params = params.set('searchTerm', searchTerm);
    }

    return this.http.get<any[]>(this.apiUrl, { params });
  }
}
