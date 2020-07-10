import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { QuestionDto } from './data-types/common.types';
import { HomeService } from './home.service';
import { Observable } from 'rxjs';
import { NgbCarouselConfig, NgbCarousel, NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [NgbCarouselConfig]
})
export class HomeComponent implements OnInit, AfterViewInit {

  public questions$: Observable<QuestionDto[]>;

  public questions: QuestionDto[] = [];
  showNavigationArrows = false;
  showNavigationIndicators = true;
  closeResult = '';
  @ViewChild('carousel') carousel: NgbCarousel;
  @ViewChild('content') content: NgbModal;
  constructor(private homeService: HomeService
    ,private modalService: NgbModal) {
  }
  ngAfterViewInit(): void {
    this.carousel.pause();
  }

  ngOnInit(): void {

    this.questions$ = this.homeService.getAllQuestions();
    this.questions$.subscribe(result => {
      this.questions = result;
      console.log(this.questions);
    });

  }

  next(e) {

    this.questions.forEach(e => {
      if(e.id===parseInt(this.carousel.activeId)+1){
        if(e.type==="singleChoice"){
          e.answers.forEach(m => {
            if(e.singleChoice==m.id){
              m.selected=true;
            }
          });
        }else if(e.type==="text"){
          e.answers[0].selected=true;
        }
        this.homeService.updateAnswers(e.answers).subscribe(result => {
          console.log(result);
        });
      }
    });


    if (this.carousel.activeId === this.carousel.slides.last.id) {
      
      console.log(this.questions);
      this.open(this.content);
    }else{
      this.carousel.next();
    }
  }
  prev() {
    this.carousel.prev();

  }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
    });
  }
}
