using OopQuizSystem.Gui.Render;
using OopQuizSystem.Library;

namespace OopQuizSystem.Gui.Factories
{
    public class SingleSelectionQuestionRendererFactory : GraphicalInterfaceQuestionRendererFactory
    {
        public override GraphicalInterfaceQuestionRenderer Create(Question question)
        {
            if (question is SingleSelectionQuestion singleSelectionQuestion)
            {
                return new SingleSelectionQuestionRenderer(singleSelectionQuestion);
            }

            return null;
        }
    }
}
