import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../Sde-Services/user-service/user.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  msg: string = '';
  errorMsg: string;
  status :string;
  emailId: string;
  constructor(private formBuilder: FormBuilder, private _userService: UserService, private router: Router) { }
  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      emailId: ['', [Validators.required, Validators.minLength(12), Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]],
    });
  }
  SubmitForm(form: FormGroup) {
    this._userService.registerUser(form.value.firstName, form.value.lastName, form.value.emailId, form.value.password).subscribe(
      responseRegisterStatus => {
        this.status = responseRegisterStatus;
        alert(this.status);
        this.router.navigate(['/home']);
        
      },
      responseRegisterError => {
        this.errorMsg = responseRegisterError;
      },
      () => console.log("SubmitLoginForm method executed successfully")
    );
  }
}
