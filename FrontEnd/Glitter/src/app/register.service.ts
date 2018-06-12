import { Injectable } from '@angular/core';
import { Signup } from './Config';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  httpOptions : any

  Base_URL ='http://localhost:9090/api/'
  constructor(private http:HttpClient) { 
    }
  postData(signupObject){
     return this.http.post(this.Base_URL + "User/UserRegisteration",signupObject)
    }
}
