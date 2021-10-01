import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Users } from '../users';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  constructor(private usersService: UsersService) { }
  // userID: number = -1;
  // username: string = " ";
  // fname: string = " ";
  // lname: string = " ";
  // DOB: string = " ";
  // password: string = " ";
  // email: string = " ";

  reactiveform = new FormGroup({
    fname: new FormControl('', [Validators.required, Validators.maxLength(20), Validators.minLength(3), Validators.pattern('[a-zA-Z]*')]),
    lname: new FormControl('', [Validators.required, Validators.maxLength(20), Validators.minLength(3)]),
    email: new FormControl('', Validators.email),
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    dob: new FormControl('', [Validators.required])
  });

  @Output() passNewUserToParent = new EventEmitter<Users>();

  ngOnInit(): void {

  }



  registeruser() {

    let u: Users = {
      firstName: this.reactiveform.get('fname')?.value, lastName: this.reactiveform.get('lname')?.value, email: this.reactiveform.get('email')?.value, Username: this.reactiveform.get('username')?.value, Password: this.reactiveform.get('password')?.value, dob: this.reactiveform.get('dob')?.value, userId: 0
    }
    u.dob = this.reactiveform.get('dob')?.value + `T00:00:00.000Z`;
    this.usersService
      .registeruser(u)
      .subscribe(user => this.usersService.storeuser(user))



    this.passNewUserToParent.emit(u);

  }

}
