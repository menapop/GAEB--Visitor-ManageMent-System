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
}
