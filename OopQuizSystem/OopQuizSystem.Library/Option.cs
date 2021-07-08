using System;

namespace OopQuizSystem.Library
{
    public class Option
    {
        public Option(string text, bool isCorrect)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
            IsCorrect = isCorrect;
        }

        public string Text { get; }

        public bool IsCorrect { get; }
    }
}
