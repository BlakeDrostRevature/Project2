import { Component } from '@angular/core';
import { Users } from './users';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css']
})
export class AppComponent {
  title = 'AngularApp';
  something?: string;// variables need to be initialized so a ? is placed to quiet that error
  logintrue: boolean = false;
  registertrue: boolean = false;
  time = new Date();
  titleclicked(value: string) {
    console.log(`${value}`)
  }

  loginuser() {
    this.logintrue = this.logintrue;
  }

  registeruser() {
    this.registertrue = !this.registertrue;
  }

  registernewcustomer(user: Users) {

    console.log(`The new customer is ${user.firstName} ${user.lastName}`)
  }

  viewdiscussions() {

  }

  viewusers() {

  }


}

