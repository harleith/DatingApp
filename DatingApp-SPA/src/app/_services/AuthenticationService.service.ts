import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import {JwtHelperService} from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseUrl = environment.apiUrl + 'Authenticate/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) {}

  login(model: any) {
   return this.http.post(this.baseUrl + 'login', model).pipe(map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('handlerToken', user.handlerToken);
        this.decodedToken = this.jwtHelper.decodeToken(user.handlerToken);
        console.log(this.decodedToken);
      }
    })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }

  loggedin() {
    const token = localStorage.getItem('handlerToken');
    return !this.jwtHelper.isTokenExpired(token);
  }

}
