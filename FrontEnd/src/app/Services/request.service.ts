import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Request } from '../shared/request'
import { HttpClient } from '@angular/common/http';
import { Mail } from 'src/app/shared/mail';
@Injectable()

export class RequestService {

  constructor(private httpclient: HttpClient) { }

  AddRequest(email:Mail):Observable<any>
  {
  return this.httpclient.post('https://localhost:44333/api/Email/SendEmail',email);
  }
}