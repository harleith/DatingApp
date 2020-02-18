import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './_services/AuthenticationService.service';
import {JwtHelperService} from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  tittle = 'app';
  jwtHelper = new JwtHelperService();

  constructor(private authenticateService: AuthenticationService) {}

    ngOnInit() {
      const token = localStorage.getItem('tokenHandler');
      if (token) {
        this.authenticateService.decodedToken = this.jwtHelper.decodeToken(token);
      }
    }
}
