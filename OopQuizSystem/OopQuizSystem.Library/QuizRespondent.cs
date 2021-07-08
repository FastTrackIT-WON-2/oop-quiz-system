using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopQuizSystem.Library
{
    public class QuizRespondent
    {
        public QuizRespondent(
            string name,
            Quiz quiz)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (quiz is null)
            {
                throw new ArgumentNullException(nameof(quiz));
            }

            Name = name;
            Quiz = quiz;
        }

        public string Name { get; }

        public Quiz Quiz { get; }

        public void Resolve(GraphicalInterface gui)
        {
            if (gui is null)
            {
                throw new ArgumentNullException(nameof(gui));
            }

            gui.RenderQuizStart(this);

            // Cum facem rezolvarea unui quiz?
            //  - pentru fiecare intrebare
            //      - afisam intrebarea
            //      - afisam optiunile
            //      - solicitam userului sa introduca optiunile de raspuns
            //      - evaluam raspunsul si ajustam scorul
            //  - afisam scorul final

            foreach (Question q in Quiz.Questions)
            {
                int[] selectedOptions = gui.RenderQuestionAndGetResponse(q);

                q.EvaluateAnswer(selectedOptions);
            }

            Quiz.UpdateScore();

            gui.RenderQuizScore(Quiz);
        }
    }
}
