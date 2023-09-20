import { Injectable } from '@angular/core';
import { loginUser } from '../models/loginUser';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, Subject, BehaviorSubject, of, from, throwError, firstValueFrom } from 'rxjs';
import { AuthenticationResponse } from '../models/authenticationResponse';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) { }

  login(userCredentials: loginUser): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>('https://localhost:44311/api/auth', userCredentials);
  }
    
}
