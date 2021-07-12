using OopQuizSystem.Library;
using System;

namespace OopQuizSystem.Gui.Render
{
    public abstract class QuestionConsoleRenderer : GraphicalInterfaceQuestionRenderer
    {
        public QuestionConsoleRenderer(Question question)
        {
            Question = question;
        }

        public Question Question { get; }

        public override void Render()
        {
            Console.WriteLine("");
            Console.WriteLine(new string('=', Console.WindowWidth - 1));
            Console.WriteLine($"{Question.Text}");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            for (int i = 0; i < Question.Options.Length; i++)
            {
                Console.WriteLine($"{i}) {Question.Options[i].Text}");
            }
            Console.WriteLine(new string('=', Console.WindowWidth - 1));
        }
    }
}
