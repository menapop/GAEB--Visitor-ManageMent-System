import { UserService } from './../../../Services/user.service';
import { TokenAndMessageReturn } from './../../../shared/TokenAndMessageReturn';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  searchForm: FormGroup;

  constructor(private userService: UserService, private fb: FormBuilder,private router:Router,private toasterSRV:ToastrService) { }
  
  ngOnInit(): void {
    this.searchForm = this.fb.group({
      idNumber: ['',[Validators.maxLength(14),Validators.minLength(14),Validators.required]]
    })
  }

  showToaster(){
    this.toasterSRV.error("عزرا, لايمكنكم استخدام هذا التطبيق حاليا يرجي التوجه لاقرب فرع")
  
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

          const helper = new JwtHelperService();

          const decodedToken = helper.decodeToken(res.token);
          
          console.log("hiiiiiiiiiiiii"+ decodedToken['nameid']);
          localStorage.setItem('nameid',decodedToken['nameid']);
            // let JWTData=res['token'].split('.')[1];
            // let DecodedJWTJsonData=window.atob(JWTData);
            // let Decodeddata = JSON.parse(DecodedJWTJsonData);

            // console.log("hiiiiiiiiiiiii22"+Decodeddata);

         } 
        
       },

       (err)=> {      
            
        if(err.error.statusCode == 404)
        {
         this.router.navigate(['/register'])
        } 

        if(err.error.statusCode == 422)
        {
          this.showToaster()  
        } 

      }
    );
  }
}


