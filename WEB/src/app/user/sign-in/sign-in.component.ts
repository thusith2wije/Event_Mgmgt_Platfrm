import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms/src/directives/ng_form';
import { HttpErrorResponse } from '@angular/common/http/src/response';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private userService : UserService, private router : Router) { }

  isLoginError: boolean = false;
  ngOnInit() {
    /*
    this.userService.selectedUser = {
      username: '',
      password: ''
    }*/
  }
  OnSubmit(form: NgForm){
    alert(form.value.id);
    this.userService.userAuthentication(form.value).subscribe((data : any) => {
      localStorage.setItem('userToken', data.access_token);
      this.router.navigate(['/clients']);        
    },
    (err: HttpErrorResponse)=>{
      this.isLoginError = true;
    });
  }  
 
}
