import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { loginUser } from '../models/loginUser';
import { AuthenticationResponse } from '../models/authenticationResponse';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent implements OnInit{
  userLogin: loginUser = {
    userName: '',
    password: ''
  }
  displayErrorMessage: boolean = false;
  loginError: string = '';
  private tokenKey = 'authToken';
  ngOnInit(): void {
    
  }
  constructor(private loginService: LoginService, 
              private router: Router){
  }
  onSubmit() {
    this.displayErrorMessage = false;
    this.loginService.login(this.userLogin).subscribe(
      (response: AuthenticationResponse) => {
        // Handle success response
        if (response) {
          console.log(response);
          localStorage.setItem(this.tokenKey, response.accessToken);
          this.router.navigate(['/product']);
          // You can also store the token or do other actions here
        } else {
          console.log('error');
          this.displayErrorMessage = true;
          this.loginError = 'Login failed. Please check your credentials.';
        }
      },
      (error) => {
        // Handle error response
        console.error('An error occurred:', error);
        this.displayErrorMessage = true;
        this.loginError = 'Login failed. Please check your credentials.';
      }
    );
  }
}

