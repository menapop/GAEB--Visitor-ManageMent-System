import { Component, OnInit } from '@angular/core';
import { Request } from '../../../shared/request'
import { RequestService } from '../../../Services/request.service'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.scss']
})
export class RequestComponent implements OnInit {
  public request: Request;
  public loginform: FormGroup;
  constructor(private frm: FormBuilder,private acntsrv:RequestService) {
    this.request = { direction: '', branch: '', employee: '' , reason: '' };
  }

  ngOnInit(): void {
      this.loginform = this.frm.group({
        Direction: ['', [ Validators.required, Validators.minLength(7)]],
        Branch: ['', [ Validators.required, Validators.minLength(7)]],
        Reason: ['', [ Validators.required, Validators.minLength(10)]],
        Employee: ['', [ Validators.required, Validators.minLength(7)]],
      });
  }

  addRequest()
  {
    this.acntsrv.AddRequest(this.request).subscribe(
      res => {alert('User Added'); },
      err => {console.log(err); }
    );
  }

}

