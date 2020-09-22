import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RegisterationComponent } from './registeration/registeration.component';
import { Routes ,RouterModule } from '@angular/router';
import {InputMaskModule} from 'primeng/inputmask';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { RadioButtonModule } from 'primeng/radiobutton';
import { CheckboxModule } from 'primeng/checkbox';
import {DropdownModule} from 'primeng/dropdown';
const routes: Routes = [
  {path:'**' ,component:RegisterationComponent}
]


@NgModule({
  declarations: [RegisterationComponent],
  imports: [
    InputMaskModule,
    FormsModule,
    RadioButtonModule,
    CheckboxModule,
    ReactiveFormsModule,
    HttpClientModule,
    DropdownModule,
    [RouterModule.forChild(routes)],
    CommonModule
  ]
})
export class RegisterationModule { }
