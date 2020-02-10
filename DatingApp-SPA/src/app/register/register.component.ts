import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthenticationService } from '../_services/AuthenticationService.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @Input() valuesFromHome: any;
  @Output() btnCancel = new EventEmitter();
  model: any = {};

  constructor(private authenticateService: AuthenticationService) { }

  ngOnInit() {
  }

  register() {
    this.authenticateService.register(this.model).subscribe(() => {
      console.log('masuk ke method register');
    }, error => {
      console.log(error);
    } );
    console.log('hit button register');
  }

  cancel() {
    this.btnCancel.emit(false);
    console.log('hit button cancel');
  }

}
