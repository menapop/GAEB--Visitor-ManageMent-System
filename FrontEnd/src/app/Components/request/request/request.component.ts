import { Component, OnDestroy, OnInit } from '@angular/core';
import { Request } from '../../../shared/request'
import { RequestService } from '../../../Services/request.service'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LookupVM } from 'src/app/shared/LookupVM';
import { LookUpService } from 'src/app/Services/Lookup.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.scss']
})
export class RequestComponent implements OnInit ,OnDestroy{
  public request: Request;
  public loginform: FormGroup;
  public subscriptions:Subscription[]=[];
  public Branches:LookupVM[]=[];
  public Directions:LookupVM[]=[];
  public Employees:any[]=[];
  constructor(private frm: FormBuilder,private acntsrv:RequestService,private lokupSRV:LookUpService) {
    var vid=localStorage.getItem('nameid');
    this.request = { visitorId :vid ,empId:null,direction: '', branch: '', employee: '' , reason: '',subject:'' };
  }

  ngOnDestroy(): void {

    this.subscriptions.forEach(element => {
      element.unsubscribe();
    });
  }

  ngOnInit(): void {
      this.loginform = this.frm.group({
        Direction: ['', [ Validators.required, Validators.minLength(7)]],
        Branch: ['', [ Validators.required, Validators.minLength(7)]],
        Reason: ['', [ Validators.required, Validators.minLength(10)]],
        Subject: ['', [ Validators.required, Validators.minLength(7)]],
        Employee: ['', [ Validators.required, Validators.minLength(7)]],
      });
      this.GetBranches();
      this.GetDirections();
  }

  GetBranches()
  {
    this.subscriptions.push(this.lokupSRV.GetBranches().subscribe(
      res=> {this.Branches=res; } ,
      err=>console.error(err)     
     ));
  }

  GetDirections()
  {
    this.subscriptions.push(this.lokupSRV.GetDirections().subscribe(
      res=> {this.Directions=res; } ,
      err=>console.error(err)     
     ));
  }

  onChange(event) {
    console.log('event :' + event);
    console.log(event.value);
    
}

onChange2(event) {
  console.log('event :' + event);
  console.log(event.value);
  this.subscriptions.push(this.lokupSRV.GetEmployee(event.value.code).subscribe(
    res=> {this.Employees=res;  console.log(JSON.stringify(res));} ,
    err=>console.error(err)     
  ));
  
}

  addRequest()
  {
    this.acntsrv.AddRequest(this.request).subscribe(
      res => {alert('User Added'); },
      err => {console.log(err); }
    );
  }

}

