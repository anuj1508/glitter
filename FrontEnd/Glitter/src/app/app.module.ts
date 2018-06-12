import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {TabViewModule} from 'primeng/tabview';
import {PanelModule} from 'primeng/panel';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {ButtonModule} from 'primeng/button';
import {CardModule} from 'primeng/card';
import {InputTextModule} from 'primeng/inputtext';
import { LoginComponent } from './login/login.component';
import { AppRoutingModule } from './/app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import {PasswordModule} from 'primeng/password';
import { RegisterComponent } from './register/register.component';
import {FileUploadModule} from 'primeng/fileupload';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
import {HttpModule} from '@angular/http';
import {HttpClientModule} from '@angular/common/http'
import { RouterModule, Routes } from '@angular/router';
import {FormGroup, FormBuilder, FormControl, Validators, NgForm } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    
    LoginComponent,
    DashboardComponent,
    HomeComponent,
    RegisterComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    RouterModule,
    HttpModule,
    HttpClientModule,
    FileUploadModule,
    TabViewModule,
    PanelModule,
    BrowserAnimationsModule,
    ButtonModule,
    CardModule,
    InputTextModule,
    AppRoutingModule,
    PasswordModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
