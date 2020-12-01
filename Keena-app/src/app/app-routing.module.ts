import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { ListDoctorComponent } from './doctor/list-doctor/list-doctor.component';
import { DetailDoctorComponent } from './doctor/detail-doctor/detail-doctor.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path:'', component: ListDoctorComponent},
  {path:'doctor', component: ListDoctorComponent},
  {path:'doctor-detail/:id', component: DetailDoctorComponent},
  {path:'doctor-detail', component: DetailDoctorComponent},
  {path:'errors', component: TestErrorComponent},
  {path:'not-found', component: NotFoundComponent},
  {path:'server-error', component: ServerErrorComponent},
  {path:'**', component: ListDoctorComponent, pathMatch:'full'}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
