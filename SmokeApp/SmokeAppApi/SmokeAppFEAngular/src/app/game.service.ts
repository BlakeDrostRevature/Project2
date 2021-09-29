import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Game } from './game';

@Injectable({
  providedIn: 'root'

})
export class GameService {

  constructor(private http: HttpClient) { }

  private url = 'https://localhost:44348/Api_E_Games'



  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  //this will go the the controller and fetch the list of games that were pulled in from the Api at the local host addes, the format for each datatype
  //is provided by the game interface class

  gameslist(): Observable<Game[]> {

    return this.http.get<Game[]>(`${this.url}allgames`);
  }


}
