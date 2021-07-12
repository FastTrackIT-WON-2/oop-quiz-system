using OopQuizSystem.Library;
using System;

namespace OopQuizSystem.Gui.Render
{
    public class MultipleSelectionQuestionRenderer : QuestionConsoleRenderer
    {
        public MultipleSelectionQuestionRenderer(MultipleSelectionQuestion question)
            : base(question)
        {
        }

        public override int[] GetResponse()
        {
            while (true)
            {
                Console.Write($"Please type the indices of the correct answer(s) (numeric value between [{0}, {Question.Options.Length - 1}]), use ',' as separator:");
                string answer = Console.ReadLine();

                bool allIndicesAreValid = true;
                string[] answerParts = answer.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (string answerPart in answerParts)
                {
                    if (int.TryParse(answerPart, out int index))
                    {
                        if (index >= 0 && index < Question.Options.Length)
                        {
                            // index is valid
                        }
                        else
                        {
                            Console.WriteLine($"Index was outside of the bounds of the options, you must type a numeric value between [{0}, {Question.Options.Length - 1}]");
                            allIndicesAreValid = false;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Value '{answerPart}' is not a number, you must type a numeric value between [{0}, {Question.Options.Length - 1}]");
                        allIndicesAreValid = false;
                        break;
                    }
                }

                if (allIndicesAreValid)
                {
                    int[] indices = new int[answerParts.Length];
                    for (int i = 0; i < answerParts.Length; i++)
                    {
                        indices[i] = int.Parse(answerParts[i]);
                    }

                    return indices;
                }
            }
        }
    }
}
