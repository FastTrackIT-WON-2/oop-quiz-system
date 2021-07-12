using System;

namespace OopQuizSystem.Library
{
    public abstract class Question
    {
        public Question(
            int id,
            string text,
            Option[] options)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (options is null || options.Length == 0)
            {
                throw new ArgumentNullException(nameof(options));
            }

            Id = id;
            Text = text;
            Options = options;
        }

        public int Id { get; }

        public string Text { get; }

        public Option[] Options { get; }

        public decimal Score { get; protected set; } = decimal.Zero;

        public abstract void EvaluateAnswer(int[] optionsIndices);
    }
}
