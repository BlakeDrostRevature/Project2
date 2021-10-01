import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Users } from '../users';
import { UsersService } from '../users.service';


@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {

  constructor(private usersService: UsersService) { }
  @Input() logintrue: boolean = false;
  // username?: string;
  // password?: string;

  reactiveloginform = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });


  ngOnInit(): void {
  }

  loginUser() {
    let u: Users = {
      firstName: this.reactiveloginform.get('fname')?.value,
      lastName: this.reactiveloginform.get('lname')?.value,
      email: this.reactiveloginform.get('email')?.value,
      Username: this.reactiveloginform.get('username')?.value,
      Password: this.reactiveloginform.get('password')?.value,
      dob: this.reactiveloginform.get('dob')?.value,
      userId: 0
    }
    this.usersService
      .loginuser(u)
      .subscribe(user => this.usersService.storeuser(user)
      );

    console.log("loggedin")
    // 
  }

}
