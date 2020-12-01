import { DoctorService } from './../../_services/doctor.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DialogService } from 'src/app/_services/dialog.service';

@Component({
  selector: 'app-detail-doctor',
  templateUrl: './detail-doctor.component.html',
  styleUrls: ['./detail-doctor.component.css']
})
export class DetailDoctorComponent implements OnInit {

  doctorForm: FormGroup;
  isAddMode: boolean;
  id:number;
  phoneNumber = '^(\+\d{1,3}[- ]?)?\d{10}$';
  submitted = false;


  constructor(private doctorService: DoctorService,
              private router: Router,
              private route: ActivatedRoute,
              private dialogService: DialogService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    this.doctorForm = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      lastName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      phone: new FormControl('',[Validators.required,Validators.pattern("^[0-9]*$")]),
      gender: new FormControl('', Validators.required),
      address: new FormControl('')
    })

    if(!this.isAddMode){
      this.doctorService.getDoctor(this.id)
        .subscribe( x=>{
          this.doctorForm.patchValue(x);
        })
    }

  }
  get firstName() {
    return this.doctorForm.get('firstName');
  }
  get lastName() {
    return this.doctorForm.get('lastName');
  }
  get email() {
    return this.doctorForm.get('email');
  }
  get phone() {
    return this.doctorForm.get('phone');
  }
  get gender(){
    return this.doctorForm.get('gender');
  }
  get address(){
    return this.doctorForm.get('address');
  }  
  get formControls() { 
    return this.doctorForm.controls; 
  }

  
  changeGender(e) {
    this.gender.setValue(e.target.value, {
      onlySelf: true
    })
  }

  onSubmit() {
    console.log(">>>");
    this.submitted=true;
    if(this.doctorForm.invalid){
      return;
    }
    if(this.isAddMode){
      this.insert();
    }
    else {
      this.update();
    }
  }
  private insert(){
    this.doctorService.insert(this.doctorForm.value)
      .subscribe(res =>{          
      }, error =>{
        console.log(error);
      },() =>{
        console.log("Add New Complete");
        let that = this;
        this.dialogService.confirmThis("Doctor Added successfully", function () {
          that.router.navigate(["doctor"]);
        })

        
      })

  }

  private update(){
    this.doctorService.update(this.id,this.doctorForm.value)
      .subscribe( res=>{        
      },
      error=>{
        console.log(error);
      },()=>{        
        console.log("Update Complete");
        let that = this;
        this.dialogService.confirmThis("Doctor Updated successfully", function () {
          that.router.navigate(["doctor"]);
        })
      });           
  }

  onCancel(){
    this.router.navigate(["doctor"]);
  }

}
