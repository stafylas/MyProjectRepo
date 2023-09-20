import { Injectable } from '@angular/core';
import { product } from '../models/product';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, Subject, BehaviorSubject, of, from, throwError, firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private tokenKey = 'authToken';
  constructor(private http: HttpClient) { }

  getProducts(): Observable<product[]> { // Return an Observable
    const token = localStorage.getItem(this.tokenKey);
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    return this.http.get<product[]>('https://localhost:44311/api/product/products', { headers });
  }
}
