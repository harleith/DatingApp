import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../_services/AuthenticationService.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  isLogin: boolean;
  constructor(
    private authservice: AuthenticationService,
    private router: Router,
    private alertify: AlertifyService,
    ) {}

  canActivate(): boolean {
    this.isLogin = this.authservice.loggedin();
    if (this.isLogin === true) {
      return this.isLogin;
    }
    this.alertify.error('You Shall Not Pass!');
    this.router.navigate(['/home']);
    this.isLogin = false;
    return this.isLogin;
    }
  }

