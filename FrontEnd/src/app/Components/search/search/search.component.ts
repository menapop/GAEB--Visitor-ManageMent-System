import { UserService } from './../../../Services/user.service';
import { TokenAndMessageReturn } from './../../../shared/TokenAndMessageReturn';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';



@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  searchForm: FormGroup;

  constructor(private userService: UserService, private fb: FormBuilder,private router:Router) { }
  
  ngOnInit(): void {
    this.searchForm = this.fb.group({
      idNumber: ['',[Validators.maxLength(14),Validators.minLength(14),Validators.required]]
    })
  }

  search() {
    this.userService.GetSearch(this.searchForm.get("idNumber").value).subscribe(
      res => {
        if(res.statusCode == 200 && !Boolean(localStorage.getItem("token")))
         {
          console.log("OK Accept")
          localStorage.setItem('token', res.token);
          console.log(res.token);
         } 
        
      },
     err=> {
        if(err.statusCode == 404 || err.message == 'User Not Found')
        {
            console.log("Error")
           
        }

     }
    );
  }
}


