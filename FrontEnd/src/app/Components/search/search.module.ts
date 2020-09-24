import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './search/search.component';
import { Routes ,RouterModule } from '@angular/router';
import {InputTextModule} from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import {CalendarModule} from 'primeng/calendar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { ToastrModule } from 'ngx-toastr';

const routes: Routes = [
  {path:'**' ,component:SearchComponent}
]

@NgModule({
  declarations: [SearchComponent],
  imports: [
    InputTextModule,
    InputNumberModule,
    CalendarModule,
    FormsModule,
    ButtonModule,
 
    [RouterModule.forChild(routes)],
    CommonModule,
    ToastrModule.forRoot({
      timeOut: 1000000, enableHtml: true,
      positionClass: 'toast-top-right',
      progressBar:true,
      toastClass: 'toast toast-bootstrap-compatibility-fix',
      closeButton: true,
      iconClasses : {
        error: 'toast-error',
        info: 'toast-info',
        success: 'toast-success',
        warning: 'toast-warning',
      }
    }),
    ReactiveFormsModule
  ],
  providers: []
})
export class SearchModule { }
