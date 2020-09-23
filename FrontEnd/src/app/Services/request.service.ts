import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Request } from '../shared/request'
import { HttpClient } from '@angular/common/http';

@Injectable()

export class RequestService {

  constructor(private httpclient: HttpClient) { }

  AddRequest(request:Request):Observable<any>
  {
  return this.httpclient.get('http://localhost:50733/api/Categories');
  }
}