import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../shared/user'
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpclient: HttpClient) { }

  AddAccount(user:User):Observable<any>
  {
    return this.httpclient.get('http://localhost:50733/api/Categories');
  }
}
