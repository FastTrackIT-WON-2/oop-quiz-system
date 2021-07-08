namespace OopQuizSystem.Library
{
    public abstract class GraphicalInterface
    {
        public abstract void RenderQuizStart(QuizRespondent respondent);

        public abstract int[] RenderQuestionAndGetResponse(Question question);

        public abstract void RenderQuizScore(Quiz quiz);
    }
}
