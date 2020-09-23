import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LookupVM } from '../shared/LookupVM'
import { HttpClient } from '@angular/common/http';

@Injectable()
export class LookUpService {

  constructor(private httpclient: HttpClient) { }

 GetGovernrates():Observable<LookupVM[]>
  {
    return this.httpclient.get<LookupVM[]>('http://lookupapi2-001-site1.ctempurl.com/api/Governorates');
  }


  GetBranches():Observable<LookupVM[]>
  {
    return this.httpclient.get<LookupVM[]>('http://lookupapi2-001-site1.ctempurl.com/api/BranchCodes');
  }


  GetVillages():Observable<LookupVM[]>
  {
    return this.httpclient.get<LookupVM[]>('http://lookupapi2-001-site1.ctempurl.com/api/Villages');
  }


  GetDirections():Observable<LookupVM[]>
  {
    return this.httpclient.get<LookupVM[]>('http://lookupapi2-001-site1.ctempurl.com/api/CentralDepartments');
  }

  GetEmployee(code:string):Observable<any>
  {
    return this.httpclient.get<LookupVM[]>('https://localhost:44333/api/request/GetEmployeesbyCentralDepartmentCode/'+code);
  }
 
}
