import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

  confirm(messages: string, okCallBack: () => any) {
    alertify.confirm(messages, (e: any) => {
      if (e) {
        okCallBack();
      } else {}
    });
  }

  success(messages: string) {
    alertify.success(messages);
  }

  error(messages: string) {
    alertify.error(messages);
  }

  warning(messages: string) {
    alertify.warning(messages);
  }

  message(messages: string) {
    alertify.message(messages);
  }
}
