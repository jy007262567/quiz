using System.Collections.Generic;

namespace quiz.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public int SingleChoice { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
    }
}