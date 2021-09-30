import { Component } from '@angular/core';

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

  viewdiscussions() {

  }

  viewusers() {

  }


}

