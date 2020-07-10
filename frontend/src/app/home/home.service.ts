import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QuestionDto, AnswerDto } from './data-types/common.types';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private basicUrl: string = "http://localhost:5000/api/quiz"

  private questions$: Observable<QuestionDto[]>;


  constructor(private http: HttpClient) { }

  getAllQuestions(): Observable<QuestionDto[]> {
    if (!this.questions$) {
      this.questions$ = this.http.get<QuestionDto[]>(this.basicUrl);
    }
    return this.questions$;
  }

  updateAnswers(answerDtos: AnswerDto[]): Observable<any[]> {

    return this.http.put<any>(this.basicUrl,answerDtos);
  }


}
