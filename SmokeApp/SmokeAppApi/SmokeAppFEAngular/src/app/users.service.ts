import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Users} from './users'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  private url = 'https://localhost:44348/';
  private loginurl = 'https://localhost:44348/login/'

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  userlist(): Observable<Users[]> {

    return this.http.get<Users[]>(`${this.url}userlist`);
  }

  loginuser(): Observable<Users[]> {

    return this.http.get<Users[]>(`${this.loginurl}`);
  }



  getUserDetails(username: string, password: string) {
    // post these details to API server return user info if correct
    return this.http.post<Users>(`${this.loginurl}${username}/${password}`, {
      username,
      password
    })
  }

}
