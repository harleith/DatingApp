import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/AuthenticationService.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})

export class NavbarComponent implements OnInit {
  model: any = {};
  isLogin: boolean;
  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }

  login() {
    this.authenticationService.login(this.model).subscribe(next => {
        console.log('Logged in Successfully');
        this.isLogin = true;

    }, error => {
      console.log('Failed to Login');
      console.log(error);
    });
  }

  loggedIn() {
    console.log('test');
    const token = localStorage.getItem('tokenHandler');
    // return !!token;
    this.isLogin = true;
  }

  logout() {
    localStorage.removeItem('handlerToken');
    console.log('logged out');
    this.isLogin = false;
  }

}
