import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../shared/user'
import { HttpClient } from '@angular/common/http';
import { TokenAndMessageReturn } from '../shared/TokenAndMessageReturn';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  http: any;

  constructor(private httpclient: HttpClient) { }

  GetSearch(idNumber: string): Observable<TokenAndMessageReturn> {
    return this.httpclient.get<TokenAndMessageReturn>(`https://localhost:44333/api/Search/${idNumber}`)
  }

  AddAccount(user:User):Observable<any>
  {
    const userFormData = new FormData();
    userFormData.append('name', user.name);
    userFormData.append('idNumber', user.idNumber);
    userFormData.append('phone', user.phone);
    userFormData.append('email', user.email);
    userFormData.append('governrate', user.governrate);
    userFormData.append('address', user.address);


    return this.httpclient.post('https://localhost:44333/api/RegisterVisitor', userFormData);
  }
}
