import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginUserComponent } from './login-user/login-user.component';
import { AppRoutingModule } from './app-routing.module';
import { RegisterUserComponent } from './register-user/register-user.component';
import { DiscussionsComponent } from './discussions/discussions.component';
import { ThreadComponent } from './thread/thread.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginUserComponent,
    RegisterUserComponent,
    DiscussionsComponent,
    ThreadComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
