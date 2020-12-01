import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { DialogService } from './_services/dialog.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { DetailDoctorComponent } from './doctor/detail-doctor/detail-doctor.component';
import { ListDoctorComponent } from './doctor/list-doctor/list-doctor.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DataTablesModule } from 'angular-datatables';
import { ConfirmDialogComponent } from './_shared/confirm-dialog/confirm-dialog.component';
import { ConfirmDialogService } from './_services/confirm-dialog.service';
import { DialogComponent } from './_shared/dialog/dialog.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { ToastrModule } from 'ngx-toastr';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    DetailDoctorComponent,
    ListDoctorComponent,
    ConfirmDialogComponent,
    DialogComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DataTablesModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    ConfirmDialogService,
    DialogService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
