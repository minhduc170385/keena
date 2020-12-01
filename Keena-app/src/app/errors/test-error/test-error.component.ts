import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { report } from 'process';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {

  baseUrl = 'https://localhost:5001/api/';
  
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get400Error() {
    this.http.get(this.baseUrl + 'buggy/bad-request')
      .subscribe(repsonse => {
        console.log(repsonse);
      }, error => {
        console.log(error);
      })
  }

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/server-error')
      .subscribe(repsonse => {
        console.log(repsonse);
      }, error => {
        console.log(error);
      })
  }
  get400ValidationError() {
    this.http.get(this.baseUrl + 'buggy/not-found')
      .subscribe(repsonse => {
        console.log(repsonse);
      }, error => {
        console.log(error);
      })
  }

}
