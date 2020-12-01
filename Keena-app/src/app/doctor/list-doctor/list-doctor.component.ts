import { DoctorService } from './../../_services/doctor.service';
import { Doctor } from './../../_models/doctor';
import {  Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject  } from 'rxjs';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import {ConfirmDialogService} from '../../_services/confirm-dialog.service'
import { DataTableDirective } from 'angular-datatables';


@Component({
  selector: 'app-list-doctor',
  templateUrl: './list-doctor.component.html',
  styleUrls: ['./list-doctor.component.css']
})
export class ListDoctorComponent implements OnDestroy, OnInit {    

  doctors: Doctor[];  
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<Doctor> = new Subject();

  constructor(private doctorService: DoctorService,
              private confirmDialogService: ConfirmDialogService,
              private route: ActivatedRoute,
              private router: Router) {    
   }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10
    };

    this.loadDoctors();
  }

  loadDoctors(){
    this.doctorService.getDoctors().subscribe(doctors =>{          
      this.doctors = doctors;   
      this.dtTrigger.next();
    },error =>{
      console.log(error);
    })
  }

  onDelete(doctor: Doctor){
    let that = this;
    this.confirmDialogService.confirmThis("This will delete the doctor account. Are you sure you would like to proceed?", function () {
      that.doctorService.delete(doctor.id).subscribe(doc =>{
          console.log(doc);
      }, error =>{
        debugger;
        console.log(">>>>>>" + error);
      },() =>{
        console.log("Delete complete");           
        that.router.navigate(['doctor'])
        .then(() => {
            window.location.reload();
        });;
      })
    }, 
    function(){
    });    
  }
  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }
}
