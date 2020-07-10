using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace quiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public int SingleChoice { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}