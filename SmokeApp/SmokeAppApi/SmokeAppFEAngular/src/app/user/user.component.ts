import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Users } from '../users';
import { UsersService } from '../users.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private userService: UsersService, private router: Router, private http: HttpClient) { }
  @Input() logintrue: boolean = false;
  //username?: string;
  //password?: string;

  
  selectedUser?: Users;
  userlist: Users[] = [];
  loginlist: Users[] = [];
  //creating an observable to route through games service to have access the list of games by using dependency injection
  
  observablelistuser = this.userService.userlist();
  




  ngOnInit(): void {
    this.getGames()
    this.logintrue = true;

    this.observablelistuser
      .subscribe(
        y => {
          this.userlist = y;
        },
        //if there was an error in the retrival of the list of games this will run
        error => console.log(`There was a ${error} error`),

        //this will always get ran regardless
        () => console.log(`This is running by default as always `),
      );

    
  }



      
  userdetails(id: number): void {
    this.selectedUser = this.userlist.find(y => y.userId === id)
  }
 
  data: any = []
  private url = 'https://localhost:44348/userlist'
  getGames() {

    this.http.get(this.url).subscribe((res) => {
      this.data = res
      this.userlist = this.data
      console.log(this.userlist)
    })

  }



}
