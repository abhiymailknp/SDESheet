import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IQuestion } from 'src/app/interfaces/question';
import { IProgress } from '../../interfaces/progress';


@Injectable({
  providedIn: 'root'
})
export class QuesService {

  questions: IQuestion[];


  constructor(private http: HttpClient) { }

  getQuestions(): Observable<IQuestion[]> {

    let tempVar = this.http.get<IQuestion[]>('https://localhost:44327/api/Questions/GetAllQuestions').pipe(catchError(this.errorHandler));;
    return tempVar;

  }

  updateProgress(id: string, qid: number, status: number,completedOn:Date): Observable<boolean> {
    var progressObj: IProgress;
    progressObj = { emailId: id, quesId: qid, status: status, dateOfCompletion: completedOn };
    return this.http.post<boolean>('http://localhost:11990/api/user/InsertUserDetails', progressObj).pipe(catchError(this.errorHandler));
  }

  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }

}
