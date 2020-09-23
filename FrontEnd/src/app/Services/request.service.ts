import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Request } from '../shared/request'
import { HttpClient } from '@angular/common/http';

@Injectable()

export class RequestService {

  constructor(private httpclient: HttpClient) { }

  AddRequest(request:Request):Observable<any>
  {
  return this.httpclient.post('https://localhost:44333/api/Email/sendemail',request);
  }
}