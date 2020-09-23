import { UserService } from './../../Services/user.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        console.log("Intercept method called from JWTInterceptor..");  
        // add authorization header with jwt token if available  
        var token = localStorage.getItem('token');
        if (Boolean(token)) {
            request = request.clone({  
                setHeaders: {  
                    Authorization: `Bearer ${token}`,
                }
            });  
        }  
        return next.handle(request);  
    
  }  
}
