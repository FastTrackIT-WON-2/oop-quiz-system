using System;

namespace OopQuizSystem.Library
{
    public static class QuestionsDatabase
    {
        public static Question[] Questions { get; private set; } = new Question[0];

        public static void Initialize(Question[] questions)
        {
            if (questions is null || questions.Length == 0)
            {
                throw new ArgumentNullException(nameof(questions));
            }

            Questions = questions;
        }

        public static Quiz GenerateQuiz(int nrOfQuestions)
        {
            if (nrOfQuestions <= 0)
            {
                throw new ArgumentException(
                    $"The number of questions must be strictly postitive, '{nrOfQuestions}' represents an invalid value",
                    nameof(nrOfQuestions));
            }

            if (Questions.Length < nrOfQuestions)
            {
                throw new ArgumentException(
                    $"The number of questions must be less than '{Questions.Length}', '{nrOfQuestions}' represents an invalid value",
                    nameof(nrOfQuestions));
            }

            Question[] result = new Question[nrOfQuestions];
            int index = 0;
            bool generatedAll = false;
            Random randomizer = new Random();

            while(!generatedAll)
            {
                // pick a random question from database
                int attemptedIndex = randomizer.Next(0, Questions.Length);
                Question questionAtIndex = Questions[attemptedIndex];
                
                // check if it's already present in the result
                bool isAlreadySelected = false;
                for (int i = 0; i < index; i++)
                {
                    if (result[i].Id == questionAtIndex.Id)
                    {
                        isAlreadySelected = true;
                        break;
                    }
                }

                if (!isAlreadySelected)
                {
                    result[index] = questionAtIndex;
                    index++;
                }

                generatedAll = (index == nrOfQuestions);
            }

            return new Quiz(result);
        }
    }
}
