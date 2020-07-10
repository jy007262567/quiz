using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using quiz.Data;
using quiz.Dtos;

namespace quiz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public QuizController(IRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<QuestionDto>> GetAllQuestions()
        {
            var items = _repository.GetAllQuestions();
            return Ok(_mapper.Map<IEnumerable<QuestionDto>>(items));
        }

        [HttpPut]
        public ActionResult UpdateAnswers([FromBody]  AnswerDto[] answerDtos)
        {
            foreach (var m in answerDtos)
            {
                var modelFromRepo = _repository.GetAnswerById(m.Id);
                if (modelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(m, modelFromRepo);
                _repository.UpdateAnswer(modelFromRepo);
            }
            return NoContent();
        }
    }
}