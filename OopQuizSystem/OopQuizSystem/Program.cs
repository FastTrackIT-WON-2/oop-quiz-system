using OopQuizSystem.Library;
using System;

namespace OopQuizSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializare baza de date (specificam setul general de intrebari)
            InitializeQuestionsDatabase();

            // Alegand un set de intrebari din baza de date, sa putem creea un Quiz
            Quiz quiz = QuestionsDatabase.GenerateQuiz(2);

            // John Doe is preparing to answer the quiz
            QuizRespondent johnDoe = new QuizRespondent("John Doe", quiz);

            johnDoe.Resolve(new ConsoleGraphicalInterface());
        }

        private static void InitializeQuestionsDatabase()
        {
            QuestionsDatabase.Initialize(new Question[]
            {
                new SingleSelectionQuestion(
                    1,
                    "What is the best language?",
                    new[]
                    {
                        new Option("C#", true),
                        new Option("Java", false),
                        new Option("Phyton", false),
                    }),

                new MultipleSelectionQuestion(
                    2,
                    "What is the best database system?",
                    new[]
                    {
                        new Option("MySQL", false),
                        new Option("SQL Server", true),
                        new Option("Oracle", true)
                    }),

                new MultipleSelectionQuestion(
                    3,
                    "What is the best mobile platform?",
                    new[]
                    {
                        new Option("Android", true),
                        new Option("iOS", true)
                    }),

                new MultipleSelectionQuestion(
                    4,
                    "What is the best OS?",
                    new[]
                    {
                        new Option("Windows 10", true),
                        new Option("Mac OS", false),
                        new Option("Linux", true)
                    })
            });
        }
    }
}
