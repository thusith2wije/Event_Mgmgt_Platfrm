import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { User } from '../models/user.model';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable()
export class UserService {
  readonly rootUrl: 'http://localhost:25304/';
  selectedUser : User;

  constructor(private http : Http) { }

  registerUser(user: User){
    const body: User={
      FirstName: user.FirstName,
      LastName: user.LastName,
      UserName: user.UserName,
      Email: user.Email,
      Password: user.Password,
      CPassword:user.CPassword      
    }
    return this.http.post('http://localhost:25304/api/User/register', body);
  }

  userAuthentication(user){
    //var arr = [user.UserName,user.Password];
    var body = JSON.stringify(user);
   // alert(userName);
    //alert(password);
   //var data = "username="+userName+"&password="+password+"&grant_type=password";
   //var reqHeader = new HttpHeaders({'Content-Type':'application/x-www-urlencoded'});
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post, headers : headerOptions});
    return this.http.post('http://localhost:25304/api/User/authenticate',body,requestOptions).map(x => x.json());

    
    //return this.http.post(this.rootUrl+'/token',data,{headers: reqHeader});
  }
}
