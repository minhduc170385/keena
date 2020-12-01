import { DialogService } from './../../_services/dialog.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  message: any;
  constructor(
    private dialogService: DialogService
  ) { }

  ngOnInit(): void {
    this.dialogService.getMessage().subscribe(message => {
      this.message = message;
  });
  }

}
