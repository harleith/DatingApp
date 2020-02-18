import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/AuthenticationService.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})

export class NavbarComponent implements OnInit {
  model: any = {};
  isLogin: boolean;
  constructor(private authenticationService: AuthenticationService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authenticationService.login(this.model).subscribe(next => {
        this.alertify.success('Logged in Successfully');
        this.isLogin = true;

    }, error => {
      this.alertify.error('Failed to Login');
      console.log(error);
    }, () => {
      this.router.navigate(['/members']);
    });
  }

  loggedIn() {
    console.log('loggedIn');
    // const token = localStorage.getItem('tokenHandler');
    // return !!token;
    // this.isLogin = true;
    return this.authenticationService.loggedin();
  }

  logout() {
    localStorage.removeItem('handlerToken');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
    this.isLogin = false;
  }

}
