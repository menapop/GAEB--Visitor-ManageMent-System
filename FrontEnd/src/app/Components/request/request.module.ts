import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RequestComponent } from './request/request.component';
import { Routes ,RouterModule } from '@angular/router';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { RequestService } from '../../Services/request.service';
import {DropdownModule} from 'primeng/dropdown';

const routes: Routes = [
  {path:'**' ,component:RequestComponent}
]


@NgModule({
  declarations: [RequestComponent],
  imports: [
    [RouterModule.forChild(routes)],
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    DropdownModule
  ],
  providers:[RequestService]
})
export class RequestModule { }
