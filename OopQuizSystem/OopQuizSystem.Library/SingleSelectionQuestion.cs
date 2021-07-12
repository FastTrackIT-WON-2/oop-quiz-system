using System;

namespace OopQuizSystem.Library
{
    public class SingleSelectionQuestion : Question
    {
        public SingleSelectionQuestion(
            int id,
            string text,
            Option[] options)
            : base (id, text, options)
        {
        }

        public override void EvaluateAnswer(int[] optionsIndices)
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
        }
    }
}
