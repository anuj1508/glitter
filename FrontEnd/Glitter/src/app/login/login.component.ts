import { Component, OnInit } from '@angular/core';
import { RouterModule, Routes, Router, RouterEvent } from '@angular/router';
import { LoginService } from '../login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginIndicator:boolean=false;
  Email="";
  Password="";
  constructor(private data:LoginService, private router:Router) { }

  ngOnInit()
  {
    
  }


  send()
  {
    var loginData=
    {
      Email:this.Email,
      Password:this.Password,
    }
    this.data.Login(loginData)
    .subscribe((event:any)=>
  {
    
    if(event==null)
    {
      window.alert("Wrong Credentials, Login Again");
      
    }
    else
    {
      this.router.navigate(['/dashboard']);
    }
  })
  }
  
} 
