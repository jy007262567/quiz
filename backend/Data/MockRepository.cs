using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using quiz.Dtos;
using quiz.Models;

namespace quiz.Data
{
    public class MockRepository:IRepository
    {


        private List<Answer> _answerList;
        private List<Question> _questionList;
        public MockRepository()
        {

            _questionList=new List<Question>
            {

                new Question{Id=1,Content = "Which of the following converts a type to a 16-bit integer in C#?",Type = "singleChoice"},
                new Question{Id=2,Content = "How to create an Array in C#?",Type = "multipleChoice"},
                new Question{Id=3,Content = "What is MVC",Type = "text"},
                new Question{Id=4,Content = "Question multipleChoice",Type = "multipleChoice"}
            };

            _answerList = new List<Answer>
            {
                new Answer{Id=1,QuestionId=1,Content="ToDecimal",Selected = false},
                new Answer{Id=2,QuestionId=1,Content="ToDouble",Selected = false},
                new Answer{Id=3,QuestionId=1,Content="ToInt16",Selected = false},
                new Answer{Id=4,QuestionId=1,Content="ToInt32",Selected = false},

                new Answer{Id=5,QuestionId=2,Content="int[] array1 = new int[5];",Selected = false},
                new Answer{Id=6,QuestionId=2,Content="int[] array2 = new int[] { 1, 3, 5, 7, 9 };",Selected = false},
                new Answer{Id=7,QuestionId=2,Content="int[] array2 = new int { };",Selected = false},
                new Answer{Id=8,QuestionId=2,Content="int array2 = new int[5];",Selected = false},

                new Answer{Id=9,QuestionId=3,Content="",Selected = false},

                new Answer{Id=10,QuestionId=4,Content="Answer01",Selected = false},
                new Answer{Id=11,QuestionId=4,Content="Answer02",Selected = false},
                new Answer{Id=12,QuestionId=4,Content="Answer03",Selected = false},
                new Answer{Id=13,QuestionId=4,Content="Answer04",Selected = false},
                new Answer{Id=14,QuestionId=4,Content="Answer05",Selected = false}

            };
        }

        public void UpdateAnswer(Answer updateAnswer)
        {
            Answer answer = _answerList.FirstOrDefault(a => a.Id == updateAnswer.Id);

            if (answer != null)
            {
                answer.Content = updateAnswer.Content;
                answer.Selected = updateAnswer.Selected;
            }
        }
        public IEnumerable<Question> GetAllQuestions()
        {

            foreach (var m in _questionList)
            {
                m.Answers= _answerList.Where(a=>a.QuestionId==m.Id);
                if (m.Type == "singleChoice")
                {

                    if (m.Answers.Where(a => a.Selected).FirstOrDefault() != null)
                    {
                        m.SingleChoice = m.Answers.Where(a => a.Selected).FirstOrDefault().Id;
                    }
                    else
                    {
                        m.SingleChoice = 0;
                    }
                }
            }

            return _questionList;
        }

        public Answer GetAnswerById(int id)
        {
            return _answerList.FirstOrDefault(a => a.Id == id);
        }

    }
}