import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DialogService {
  private subject = new Subject<any>();

  confirmThis(message: string, okFn: () => void): any {
    this.setConfirmation(message, okFn);
  }

  setConfirmation(message: string, okFn: () => void): any {
    const that = this;
    this.subject.next({
      type: 'confirm',
      text: message,
      okFn(): any {
        that.subject.next(); // This will close the modal
        okFn();
      },
    });

  }

  getMessage(): Observable<any> {
    return this.subject.asObservable();
  }
}
