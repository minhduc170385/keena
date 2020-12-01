import { Doctor } from './../_models/doctor';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class DoctorService {
  baseUrl = environment.api_url;

  constructor(private http: HttpClient) { }


  getDoctors(){    
    let api = 'doctor/all';    
    console.log(this.baseUrl + api);
    return this.http.get<Doctor[]>(this.baseUrl + api);          
  }
  getDoctor(id:number){
    console.log(this.baseUrl);
    let api="doctor/" + id;
    return this.http.get<Doctor>(this.baseUrl + api);
  }
  update(id:number, doctor: Doctor){
    doctor.id=id;    
    let api='doctor';   
    return this.http.put(this.baseUrl+api,JSON.stringify(doctor), httpOptions);
  }
  insert(doctor: Doctor){
    let api='doctor';
    return this.http.post<Doctor>(this.baseUrl+ api, JSON.stringify(doctor), httpOptions);
  }
  delete(id:number){
    let api='doctor/' + id;
    return this.http.delete<Doctor>(this.baseUrl + api);
  }

}

export const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}


// get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
//   return this.http.get(`${environment.api_url}${path}`, { params })
//     .pipe(catchError(this.formatErrors));
// }