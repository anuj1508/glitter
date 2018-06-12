import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent }      from './login/login.component';
import {DashboardComponent}  from './dashboard/dashboard.component';
import {HomeComponent}  from './home/home.component';
import {RegisterComponent}  from './register/register.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {path: 'dashboard', component: DashboardComponent},
  {path: 'home', component: HomeComponent},
  {path: 'register', component: RegisterComponent},
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ]
})
export class AppRoutingModule { }
