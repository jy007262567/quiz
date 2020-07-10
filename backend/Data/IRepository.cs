using System;
using System.Collections.Generic;
using quiz.Dtos;
using quiz.Models;

namespace quiz.Data
{
    public interface IRepository
    {
        void UpdateAnswer(Answer answer);
        IEnumerable<Question> GetAllQuestions();
        Answer GetAnswerById(int id);


    }
}