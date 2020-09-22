import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './search/search.component';
import { Routes ,RouterModule } from '@angular/router';
import {InputTextModule} from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import {CalendarModule} from 'primeng/calendar';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
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
    CommonModule
  ]
})
export class SearchModule { }
