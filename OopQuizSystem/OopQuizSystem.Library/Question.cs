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

        public void EvaluateAnswer(int[] optionsIndices)
        {
            if (optionsIndices is null || optionsIndices.Length == 0)
            {
                throw new ArgumentNullException(nameof(optionsIndices));
            }

            if (optionsIndices.Length > Options.Length)
            {
                throw new ArgumentException(
                    $"You cannot submit more responses than the number of options! The number of responses is {optionsIndices.Length}, while the number of options is {Options.Length}",
                    nameof(optionsIndices));
            }

            switch (Type)
            {
                case QuestionType.SingleSelection:
                    // 1) there should be a single submitted answer
                    if (optionsIndices.Length != 1)
                    {
                        throw new ArgumentException(
                            $"For single-selection options you can submit only 1 response! The number of responses is {optionsIndices.Length} is invalid.",
                            nameof(optionsIndices));
                    }

                    // 2) The response should point to a correct option
                    int answerIndex = optionsIndices[0];
                    if (answerIndex >= 0 && 
                        answerIndex < Options.Length && 
                        Options[answerIndex].IsCorrect)
                    {
                        Score = 1;
                    }
                    break;
            }
        }
    }
}
