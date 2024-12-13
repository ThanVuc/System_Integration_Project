import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginModel } from '../models/login-model';
import { HttpClient } from '@angular/common/http';
import { JwtToken } from '../models/jwt-token';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginModel: LoginModel = {
    username: "",
    password: ""
  }

  tokenModel: JwtToken = {
    token: ""
  }

  http = inject(HttpClient);
  document = inject(DOCUMENT);
  router = inject(Router)

  login(){
    this.http.post<JwtToken>("http://localhost:5003/api/auth/login",this.loginModel)
    .subscribe({
      next: (res) => {
        this.tokenModel = res;
        this.document.defaultView?.localStorage.setItem("jwtToken",res.token);
        console.log(res.token);
        this.router.navigate([""]);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

}
