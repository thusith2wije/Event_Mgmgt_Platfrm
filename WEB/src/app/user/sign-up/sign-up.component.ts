import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user.model';
import { NgForm } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  user: User;
  constructor(private userService: UserService, private toastr: ToastrService, private router : Router ) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form? :NgForm){
    if(form !=null)
    form.reset();
    this.user = {
      FirstName:'',
      LastName:'',
      UserName:'',
      Email:'',
      Password:'',
      CPassword:''    
    }
  }
  OnSubmit(form: NgForm){
    alert(form.value.id);
    this.userService.registerUser(form.value).subscribe((data : any) => {
      
        this.resetForm(form);
        this.toastr.success('User registred');
        this.router.navigate(['/login']);  
           
      
    });
  }
}
