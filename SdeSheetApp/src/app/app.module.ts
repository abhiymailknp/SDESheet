import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CommonLayoutComponent } from './layouts/common-layout/common-layout.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from './Sde-Services/user-service/user.service';
import { routing } from './app.routing';
@NgModule({
  declarations: [
    AppComponent,
    CommonLayoutComponent,
    LoginPageComponent
  ],
  imports: [
    BrowserModule, FormsModule, ReactiveFormsModule, HttpClientModule, routing
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
