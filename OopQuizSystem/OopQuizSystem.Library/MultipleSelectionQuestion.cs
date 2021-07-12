using System;

namespace OopQuizSystem.Library
{
    public class MultipleSelectionQuestion : Question
    {
        public MultipleSelectionQuestion(
            int id,
            string text,
            Option[] options)
            : base(id, text, options)
        {
        }

        public override void EvaluateAnswer(int[] optionsIndices)
        {
            if (optionsIndices is null)
            {
                throw new ArgumentNullException(nameof(optionsIndices));
            }

            if (optionsIndices.Length > Options.Length)
            {
                throw new ArgumentException(
                    $"You cannot submit more responses than the number of options! The number of responses is {optionsIndices.Length}, while the number of options is {Options.Length}",
                    nameof(optionsIndices));
            }

            //1) calculate the number of correct options
            int nrOfCorrectOptions = 0;
            foreach (var option in this.Options)
            {
                if (option.IsCorrect)
                {
                    nrOfCorrectOptions++;
                }
            }

            if (nrOfCorrectOptions == 0)
            {
                // there are no correct options => we expect the response to be emtpy
                if (optionsIndices.Length == 0)
                {
                    Score = 1;
                }
            }
            else // we have at least 1 correct option
            {
                decimal scoreFraction = decimal.One / nrOfCorrectOptions;
                foreach (var answerIndex in optionsIndices)
                {
                    if (answerIndex >= 0 &&
                        answerIndex < Options.Length &&
                        Options[answerIndex].IsCorrect)
                    {
                        Score += scoreFraction;
                    }
                }
            }
        }
    }
}
