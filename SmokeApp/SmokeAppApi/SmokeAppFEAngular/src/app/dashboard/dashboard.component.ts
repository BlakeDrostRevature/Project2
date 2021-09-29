import { Component, OnInit } from '@angular/core';
import { GameService } from '../game.service'
import {Game} from '../game'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private gameService: GameService) { }


  selectedGame?: Game;
  //cerating an array for the games recived storing them to variable gamelist
  gamelist: Game[] = [];
  //creating an observable to route through games service to have access the list of games by using dependency injection
  observablelist = this.gameService.gameslist();







  ngOnInit(): void {
    this.observablelist
      .subscribe(
        x => {
          this.gamelist = x;
        },
        //if there was an error in the retrival of the list of games this will run
        error => console.log(`There was a ${error} error`),

        //this will always get ran regardless
        () => console.log(`This is running by default as always `),
    );
  }


  gamedetails(id: number): void  {
    this.selectedGame = this.gamelist.find(x => x.id === id)
  }


}
