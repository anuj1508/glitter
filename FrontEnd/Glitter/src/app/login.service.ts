import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  Base_URL ='http://localhost:9090/api/User/Login'
  constructor(private http:HttpClient) { 
    }
  Login(value){
    return this.http.post(this.Base_URL,value)
  }
}
