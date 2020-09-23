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
      (res:TokenAndMessageReturn) => {
        if(res.statusCode == 200)
         {
          console.log(res.message)
          localStorage.setItem('token', res.token);
          console.log(res.token);
          this.router.navigate(['/request'])
         } 
        
       },

       (err)=> {      
            
        if(err.error.statusCode == 404)
        {
         this.router.navigate(['/register'])
        } 

        if(err.error.statusCode == 422)
        {
          console.log('اطلع بره يبن الكلب '+ err.error.message);
          
        } 

      }
    );
  }
}


