namespace quiz.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public bool Selected { get; set; }
    }
}