using OopQuizSystem.Gui.Render;
using OopQuizSystem.Library;

namespace OopQuizSystem.Gui.Factories
{
    public class MultipleSelectionQuestionRendererFactory : GraphicalInterfaceQuestionRendererFactory
    {
        public override GraphicalInterfaceQuestionRenderer Create(Question question)
        {
            if (question is MultipleSelectionQuestion multipleSelectionQuestion)
            {
                return new MultipleSelectionQuestionRenderer(multipleSelectionQuestion);
            }

            return null;
        }
    }
}
