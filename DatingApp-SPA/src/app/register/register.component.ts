import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthenticationService } from '../_services/AuthenticationService.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @Input() valuesFromHome: any;
  @Output() btnCancel = new EventEmitter();
  model: any = {};

  constructor(private authenticateService: AuthenticationService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authenticateService.register(this.model).subscribe(() => {
      this.alertify.success('masuk ke method register');
    }, error => {
      console.log(error);
    } );
    this.alertify.error('hit button register');
  }

  cancel() {
    this.btnCancel.emit(false);
    // this.alertify.message('hit button cancel');
  }

}
