import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../../../shared/user'
import { UserService } from '../../../Services/user.service'
import { LookUpService } from 'src/app/Services/Lookup.service';
import { Subscription } from 'rxjs';
import { LookupVM } from 'src/app/shared/LookupVM';
@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.scss']
})
export class RegisterationComponent implements OnInit ,OnDestroy{

  public subscriptions:Subscription[]=[];
  public selectedCity:string='';
  public cities:LookupVM[]=[];
  
  public user: User;
  public loginform: FormGroup;
  constructor(private frm: FormBuilder,private acntsrv:UserService,private lokupSRV:LookUpService) {
    this.user = { name: '', email: '', idNumber: '' , phone: '', address: '' , governrate:'', image :null };
  }
  ngOnDestroy(): void {
     this.subscriptions.forEach(element => {
       element.unsubscribe();
     });
  }

  ngOnInit(): void {
      this.loginform = this.frm.group({
        Idnumber: ['', [ Validators.required, Validators.minLength(7)]],
        UserName: ['', [ Validators.required, Validators.minLength(7)]],
        Phone: ['', [ Validators.required, Validators.minLength(10)]],
        Email: ['', [ Validators.required, Validators.email, Validators.minLength(7)]],
        address: ['' , [Validators.required, Validators.minLength(6)]],
        governrate: ['' , [Validators.required, Validators.minLength(6)]]
      });

      this.getCities();
  }

  getCities()
  {
    this.subscriptions.push(this.lokupSRV.GetGovernrates().subscribe(
         res=> {this.cities=res; console.log(JSON.stringify(res))} ,
         err=>console.error(err)      
    ));
  }
  addAccount()
  {
    this.acntsrv.AddAccount(this.user).subscribe(
      res => {alert('User Added'); },
      err => {console.log(err); }
    );
  }

}



