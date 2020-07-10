using AutoMapper;
using quiz.Dtos;
using quiz.Models;

namespace quiz.Profiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<Answer, AnswerDto>();
            CreateMap<Question, QuestionDto>();
            CreateMap<AnswerDto, Answer>();
        }
    }
}