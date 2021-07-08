using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopQuizSystem.Library
{
    public class Quiz
    {
        public Quiz(Question[] questions)
        {
            if (questions is null || questions.Length == 0)
            {
                throw new ArgumentNullException(nameof(questions));
            }

            Questions = questions;
        }

        public Question[] Questions { get; }

        public decimal Score { get; private set; }

        public void UpdateScore()
        {
            decimal score = decimal.Zero;
            foreach (Question q in Questions)
            {
                score += q.Score;
            }

            Score = score;
        }
    }
}
