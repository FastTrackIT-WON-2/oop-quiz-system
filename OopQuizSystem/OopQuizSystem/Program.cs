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

            // Cum facem rezolvarea unui quiz?
            //  - pentru fiecare intrebare
            //      - afisam intrebarea
            //      - afisam optiunile
            //      - solicitam userului sa introduca optiunile de raspuns
            //      - evaluam raspunsul si ajustam scorul
            //  - afisam scorul final

            Console.WriteLine("Hello World!");
        }

        private static void InitializeQuestionsDatabase()
        {
            QuestionsDatabase.Initialize(new[]
            {
                new Question(
                    1,
                    QuestionType.SingleSelection,
                    "What is the best language?",
                    new[]
                    {
                        new Option("C#", true),
                        new Option("Java", false),
                        new Option("Phyton", false),
                    }),

                new Question(
                    2,
                    QuestionType.SingleSelection,
                    "What is the best database system?",
                    new[]
                    {
                        new Option("MySQL", false),
                        new Option("SQL Server", true),
                        new Option("Oracle", false)
                    }),

                new Question(
                    3,
                    QuestionType.SingleSelection,
                    "What is the best mobile platform?",
                    new[]
                    {
                        new Option("Android", true),
                        new Option("iOS", false)
                    }),

                new Question(
                    4,
                    QuestionType.SingleSelection,
                    "What is the best OS?",
                    new[]
                    {
                        new Option("Windows 10", false),
                        new Option("Mac OS", false),
                        new Option("Linux", true)
                    })
            });
        }
    }
}
