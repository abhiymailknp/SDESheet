import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IProgress } from '../interfaces/progress';
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
  quesStatus: number;
  questions: IQuestion[];
  progress: IProgress[];
  errMsg: any;
  progressArray = new Array<number>(10).fill(0)

  constructor(private router: Router, private _questionService: QuesService)
  {
    this.userName = sessionStorage.getItem('userName');
    if (this.userName) {
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
    if (this.userLayout) {
      this.getProgress();
    }
    console.log(this.progressArray);
    }

  getQuestions()
  {
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

  getProgress()
  {
    this._questionService.getProgress(this.userName).subscribe(
      responseProgressData => {
        this.progress = responseProgressData;
        console.log(this.progress);
        for (var i = 0; i < this.progress.length; i++) {
          this.progressArray[this.progress[i].quesId - 1] = this.progress[i].status;
        }
        console.log(this.progressArray);
      },
      responseProgressError => {
        this.progress = null;
        this.errMsg = responseProgressError;
        console.log(this.errMsg);
      }
    );

  }

  updateProgress(id: number, ischecked: Boolean) {
    let date: Date = new Date();
    console.log(id);
    console.log(ischecked);
    if (ischecked == true)
      this.quesStatus = 1;
    else
      this.quesStatus = 0;
    this._questionService.updateProgress(this.userName, id, this.quesStatus, date).subscribe(
      responseUpdateProgress => {
        if (responseUpdateProgress)
          console.log("Progress Updated Succesfully");
        else
          console.log("Progress not updtaed");
      },
      responseUpdateProgressError => {
        this.errMsg = responseUpdateProgressError;
        console.log(this.errMsg);
      }
    )
  }

}
