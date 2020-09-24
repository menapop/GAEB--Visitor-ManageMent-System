import { TokenAndMessageReturn } from './../../../shared/TokenAndMessageReturn';
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
  public Villages:LookupVM[]=[];
  public FilterdVillages:LookupVM[]=[];
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
        Idnumber: ['', [ Validators.required, Validators.minLength(14),Validators.maxLength(14)]],
        UserName: ['', [ Validators.required, Validators.minLength(7)]],
        Phone: ['', [ Validators.required, Validators.minLength(11),Validators.maxLength(14)]],
        Email: ['', [ Validators.required, Validators.email, Validators.minLength(7)]],
        address: ['' , [Validators.required, Validators.minLength(3)]],
        governrate: ['' , [Validators.required, Validators.minLength(3)]]
      });

      this.getCities();
      this.getAddresses();
  }

  getCities()
  {
    this.subscriptions.push(this.lokupSRV.GetGovernrates().subscribe(
         res=> {this.cities=res; } ,
         err=>console.error(err)      
    ));
  }

  onChange(event) {
    console.log('event :' + event);
    console.log(event.value);
    this.filteredVillages(event.value.code)
    this.user.governrate=event.value.name;
}

onChange2(event) {
  console.log('event :' + event);
  console.log(event.value);
  this.user.address=event.value.name
}
  

  getAddresses()
  {
    this.subscriptions.push(this.lokupSRV.GetVillages().subscribe(
         res=> {this.Villages=res; } ,
         err=>console.error(err)      
    ));
  }

  filteredVillages(code:string)
  {
      this.FilterdVillages=this.Villages.filter(v=>v.code.includes(code))
      console.log(this.FilterdVillages);
  }

  addAccount()
  {
    this.acntsrv.AddAccount(this.user).subscribe(
      (res: TokenAndMessageReturn) => {
        if(res.statusCode == 201)
          localStorage.setItem('token', res.token);
          console.log("Created sussss")
       },
      err => {console.log(err); }
    );
  }

}



