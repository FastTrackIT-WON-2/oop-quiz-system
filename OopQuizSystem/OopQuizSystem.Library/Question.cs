using System;

namespace OopQuizSystem.Library
{
    public class Question
    {
        public Question(
            int id,
            QuestionType type,
            string text,
            Option[] options)
        {
            if (!Enum.IsDefined(type))
            {
                throw new ArgumentException($"Unknown question type '{type}'", nameof(type));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (options is null || options.Length == 0)
            {
                throw new ArgumentNullException(nameof(options));
            }

            Id = id;
            Type = type;
            Text = text;
            Options = options;
        }

        public int Id { get; }

        public QuestionType Type { get; }

        public string Text { get; }

        public Option[] Options { get; }

        public decimal Score { get; private set; } = decimal.Zero;
    }
}
