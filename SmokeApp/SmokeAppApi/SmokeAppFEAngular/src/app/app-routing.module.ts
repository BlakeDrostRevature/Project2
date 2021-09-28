import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginUserComponent } from './login-user/login-user.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { DiscussionsComponent } from './discussions/discussions.component';
import { ThreadComponent } from './thread/thread.component';
import { DashboardComponent } from './dashboard/dashboard.component';


const routes: Routes = [
  //main page to display a list of heroes 
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginUserComponent },
  { path: 'register', component: RegisterUserComponent },
  { path: 'discussions', component: DiscussionsComponent },
  { path: 'thread', component: ThreadComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
