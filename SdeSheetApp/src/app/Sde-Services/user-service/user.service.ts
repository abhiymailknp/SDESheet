import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IUser } from 'src/app/interfaces/user';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

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
