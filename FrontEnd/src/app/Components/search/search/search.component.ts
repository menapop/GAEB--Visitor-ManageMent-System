import { UserService } from './../../../Services/user.service';
import { TokenAndMessageReturn } from './../../../shared/TokenAndMessageReturn';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';



@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  public IdentificationNum:string=''
  searchForm: FormGroup;

  constructor(private userService: UserService, private fb: FormBuilder) { }
  
  ngOnInit(): void {
    this.searchForm = this.fb.group({
      idNumber: [""]
    })
  }

  search() {
    this.userService.GetSearch(this.searchForm.get("idNumber").value).subscribe(
      (res: TokenAndMessageReturn) => {
        if(res.statusCode == 200 && !Boolean(localStorage.getItem("token")))
          localStorage.setItem('token', res.token);
      },
      console.log
    );
  }
}


