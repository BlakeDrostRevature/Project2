import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Users } from './users'
import { Observable } from 'rxjs';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  private url = 'https://localhost:44348/';
  private loginurl = 'https://localhost:44348/login/'
  private registerurl = `https://localhost:44348/register/`

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

  registeruser(u: Users): Observable<Users> {
    console.log('made it to service')
    return this.http.post<Users>(`${this.registerurl}`, u, this.httpOptions);
  }



  getUserDetails(username: string, password: string): Observable<Users> {
    // post these details to API server return user info if correct
    return this.http.get<Users>(`${this.loginurl}${username}/${password}`, {
      //username,
      //password
    })
  }

}
