import { Component, Input, OnInit } from '@angular/core';


@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {

  constructor() {}
  @Input() logintrue: boolean = false;
  username?: string;
  password?: string;


  ngOnInit(): void {
  }

}
