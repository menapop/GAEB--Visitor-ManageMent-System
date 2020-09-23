import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlacklistuserComponent } from './blacklistuser/blacklistuser.component';
import { Routes ,RouterModule } from '@angular/router';

const routes: Routes = [
  {path:'**' ,component:BlacklistuserComponent}
]


@NgModule({
  declarations: [BlacklistuserComponent],
  imports: [
    [RouterModule.forChild(routes)],
    CommonModule
  ]
})
export class BlackListUsersModule { }
