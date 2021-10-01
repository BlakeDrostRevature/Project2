import { Component, Input, OnInit } from '@angular/core';
import { GameService } from '../game.service';
import { Game } from '../game';
import { Users } from '../users';
import { UsersService } from '../users.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private gameService: GameService, private userService: UsersService, private router: Router, private http: HttpClient) { }
  @Input() logintrue: boolean = false;
  //username?: string;
  //password?: string;

  selectedGame?: Game;

  //cerating an array for the games recived storing them to variable gamelist
  gamelist: Game[] = [];

  loginlist: Users[] = [];
  //creating an observable to route through games service to have access the list of games by using dependency injection
  observablelist = this.gameService.gameslist();





  // loginUser(event: { preventDefault: () => void; target: any; }) {
  //   event.preventDefault()
  //   const target = event.target
  //   const username = target.querySelector('#username').value
  //   const password = target.querySelector('#password').value
  //   console.log(username, password)

  //   this.userService.getUserDetails(username, password)
  //     .subscribe(data => {
  //       if (data.Username) {
  //         console.log("loging successful");
  //       }
  //       else { window.alert("Incorrect login") }
  //     })



  // }









  ngOnInit(): void {
    this.getGames()
    this.logintrue = true;

    //this.observablelist
    //  .subscribe(
    //    x => {
    //      this.gamelist = x;
    //    },
    //    //if there was an error in the retrival of the list of games this will run
    //    error => console.log(`There was a ${error} error`),

    //    //this will always get ran regardless
    //    () => console.log(`This is running by default as always `),
    //  );



    // this.observablelistlogin
    //   .subscribe(
    //     z => {
    //       this.loginlist = z;
    //     },
    //     //if there was an error in the retrival of the list of games this will run
    //     error => console.log(`There was a ${error} error`),

    //     //this will always get ran regardless
    //     () => console.log(`This is running by default as always `),
    //   );




  }




  data: any = []
  private url = 'https://localhost:44348/Api_E_Games/allgames'
  getGames() {

    this.http.get(this.url).subscribe((res) => {
      this.data = res
      console.log(this.data)
    })

  }



  gamedetails(id: number): void {
    this.selectedGame = this.gamelist.find(x => x.id === id)

  }


  //userlogin(username, password): void {


  //  this.selectedUser = this.loginlist.find(z => z.Username === userName && z.Password === password)
  //}
}
