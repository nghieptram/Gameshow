using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC
{
    class Question
    {
        public string NumberQ { get; set; }
        public string Content { get; set; }
        public string ImageLink { get; set; }
        public List<Answer> ListAnswers = new List<Answer>();
        public string CorrectAnswer { get; set; }
    }
}
