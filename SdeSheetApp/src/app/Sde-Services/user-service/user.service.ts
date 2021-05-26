import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IUser } from 'src/app/interfaces/user';
import { INewUser } from '../../interfaces/newuser';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }


  registerUser(firstname:string,lastname:string,id: string, password: string): Observable<string> {
    var newuserObj: INewUser;
    newuserObj = { firstName: firstname, lastName: lastname, emailId: id, userPassword: password };
    return this.http.post<string>('https://localhost:44327/api/Questions/AddUser', newuserObj).pipe(catchError(this.errorHandler));
  }

  validateCredentials(id: string, password: string): Observable<boolean> {
    var userObj: IUser;
    userObj = { emailId: id, userPassword: password };
    return this.http.post<boolean>('https://localhost:44327/api/Questions/ValidateUserCredentials', userObj).pipe(catchError(this.errorHandler));
  }

  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }
}
