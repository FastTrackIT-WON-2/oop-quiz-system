namespace OopQuizSystem.Library
{
    public abstract class GraphicalInterface
    {
        public abstract GraphicalInterfaceQuestionRendererFactory[] QuestionRendererFactories { get; }

        public abstract void RenderQuizStart(QuizRespondent respondent);

        public abstract void RenderQuizScore(Quiz quiz);
    }
}
