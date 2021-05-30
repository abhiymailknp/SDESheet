import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../Sde-Services/user-service/user.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  status: boolean = false;
  errorMsg: string;
  msg: string;
  showDiv: boolean = false;
  userName: string;

  constructor(private _userService: UserService, private router: Router) {
    this.userName = sessionStorage.getItem('userName');

    if (this.userName) {
      this.router.navigate(['/home']);
    }


  }

  submitLoginForm(form: NgForm) {
    this._userService.validateCredentials(form.value.email, form.value.password).subscribe(
      responseLoginStatus => {
        this.status = responseLoginStatus;
        console.log(this.status);
        this.showDiv = true;
        if (this.status) {
          sessionStorage.setItem('userName', form.value.email);

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

  ngOnInit(): void {
  }

}
