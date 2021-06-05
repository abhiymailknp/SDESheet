import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../Sde-Services/user-service/user.service';

@Component({
  selector: 'app-common-layout',
  templateUrl: './common-layout.component.html',
  styleUrls: ['./common-layout.component.css']
})
export class CommonLayoutComponent implements OnInit {
  showModal: boolean;
  registerForm: FormGroup;
  submitted = false;
  status: boolean = false;
  errorMsg: string;
  msg: string;
  showDiv: boolean = false;
  userName: string;
  registerStatus: string;

  constructor(private formBuilder: FormBuilder, private _userService: UserService, private router: Router) { }
  show() {
    this.userName = sessionStorage.getItem('userName');
    if (this.userName) {
      this.router.navigate(['/home']);
    }
    else {
      this.showModal = true; // Show-Hide Modal Check
      const signUpButton = document.getElementById('signUp');
      const signInButton = document.getElementById('signIn');
      const container1 = document.getElementById('container_login');
      signUpButton.addEventListener('click', () => {
        container1.classList.add("right-panel-active");
      });

      signInButton.addEventListener('click', () => {
        container1.classList.remove("right-panel-active");
      });
    }
  }
  hide() {
    this.showModal = false;
  }
  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      emailId: ['', [Validators.required, Validators.minLength(12), Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]],
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(16)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(16)]],
    });
  }
  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  submitLoginForm(form: NgForm) {
    this._userService.validateCredentials(form.value.email, form.value.password).subscribe(
      responseLoginStatus => {
        this.status = responseLoginStatus;
        console.log(this.status);
        this.showDiv = true;
        if (this.status) {
          sessionStorage.setItem('userName', form.value.email);
          sessionStorage.setItem('loginStatus', 'true');

          this.router.navigate(['/home']);
        }
        else {
          this.msg = "Try again with valid credentials.";
        }
      },
      responseLoginError => {
        this.errorMsg = responseLoginError;
      },
      () => console.log("SubmitLoginForm method executed successfully")
    );
  }

  SubmitRegisterForm(form: FormGroup) {
    this._userService.registerUser(form.value.firstName, form.value.lastName, form.value.emailId, form.value.password).subscribe(
      responseRegisterStatus => {
        this.registerStatus = responseRegisterStatus;
        alert(this.registerStatus);
        if (this.registerStatus != "User Exists") {
          sessionStorage.setItem('userName', form.value.emailId);
          sessionStorage.setItem('loginStatus', 'true');

          this.router.navigate(['/success']);
        }

      },
      responseRegisterError => {
        this.errorMsg = responseRegisterError;
      },
      () => console.log("SubmitLoginForm method executed successfully")
    );
  }
}
