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
    dob: new FormControl('', [Validators.required]),
    email: new FormControl('', Validators.email),
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  @Output() passNewUserToParent = new EventEmitter<Users>();

  ngOnInit(): void {
  }


  registeruser() {

    let u: Users = {
      Username: this.reactiveform.get('username')?.value, firstName: this.reactiveform.get('fname')?.value, lastName: this.reactiveform.get('lname')?.value, dob: this.reactiveform.get('dob')?.value, Password: this.reactiveform.get('password')?.value, email: this.reactiveform.get('email')?.value, userId: 0
    }
    u.dob = this.reactiveform.get('dob')?.value + `T00:00:00.000Z`;
    console.log(u)
    this.usersService
      .registeruser(u)
      .subscribe(Users => u)

    console.log(u)


    this.passNewUserToParent.emit(u);
  }

}
