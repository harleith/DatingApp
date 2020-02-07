import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/AuthenticationService.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})

export class NavbarComponent implements OnInit {
  model: any = {};

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }

  login() {
    this.authenticationService.login(this.model).subscribe(next => {
        console.log('Logged in Successfully');
    }, error => {
      console.log('Failed to Login');
    });
  }

  loggedIn() {
    const token = localStorage.getItem('tokenHandler');
    return !!token;
  }

  logout() {
    localStorage.removeItem('handlerToken');
    console.log('logged out');
  }

}
