using OopQuizSystem.Library;
using System;

namespace OopQuizSystem.Gui.Render
{
    public class SingleSelectionQuestionRenderer : QuestionConsoleRenderer
    {
        public SingleSelectionQuestionRenderer(SingleSelectionQuestion question)
            : base (question)
        {
        }

        public override int[] GetResponse()
        {
            while (true)
            {
                Console.Write($"Please type the index of the correct answer (numeric value between [{0}, {Question.Options.Length - 1}], only 1 value):");
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int index))
                {
                    if (index >= 0 && index < Question.Options.Length)
                    {
                        return new[] { index };
                    }
                    else
                    {
                        Console.WriteLine($"Index was outside of the bounds of the options, you must type a numeric value between [{0}, {Question.Options.Length - 1}]");
                    }
                }
                else
                {
                    Console.WriteLine($"Value '{answer}' is not a number, you must type a numeric value between [{0}, {Question.Options.Length - 1}]");
                }
            }
        }
    }
}
