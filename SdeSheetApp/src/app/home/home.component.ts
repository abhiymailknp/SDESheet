import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IQuestion } from '../interfaces/question';
import { QuesService } from '../Sde-Services/ques-service/ques.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userName: string;
  userLayout: boolean = false;
  commonLayout: boolean = false;
  questions: IQuestion[];
    errMsg: any;

  constructor(private router: Router, private _questionService: QuesService)
  {
    this.userName = sessionStorage.getItem('userName');
    if (this.userName == "true") {
      this.userLayout = true;
    }
    else {
      this.commonLayout = true;
    }
    console.log(this.userLayout);
    console.log(this.commonLayout);
  }
  ngOnInit() {
    this.getQuestions();
        
    }

  getQuestions() {
    this._questionService.getQuestions().subscribe(
      responseQuestionData => {
        this.questions = responseQuestionData;
        console.log(this.questions);
      },
      responseProductError => {
        this.questions = null;
        this.errMsg = responseProductError;
        console.log(this.errMsg);
      }
    );

  }

}
