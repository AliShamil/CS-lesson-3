using System;
using System.Threading;
namespace CS_lesson_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Questions_And_Answers

            string[][] Questions = new string[10][];
            Questions[0] = new string[] { "Where in the world is Leonardo da Vinci's Mona Lisa exhibited ?", "Paris" };
            Questions[1] = new string[] { "Which club won the 1986 FA Cup final ?", "Liverpool" };
            Questions[2] = new string[] { "In which year was The Godfather first released ?", "1972" };
            Questions[3] = new string[] { "Which actor play as Doctor Strange role ?", "Benedict Cumberbatch" };
            Questions[4] = new string[] { "What sports game did James Naismith invent in 1891 ?", "Basketball"};
            Questions[5] = new string[] { "What is the capital of Finland ?", "Helsinki" };
            Questions[6] = new string[] { "What is the smallest country in the world ?", "Vatican City" };
            Questions[7] = new string[] { "Which country in the world is believed to have the most miles of motorway ?", "China" };
            Questions[8] = new string[] { "What language is spoken in Brazil ?", "Portuguese" };
            Questions[9] = new string[] { "How many Pirates of the Caribbean films have been released ?", "Five" };

			string[][] Answers = new string[10][];
			Answers[0] = new string[] { "Paris", "Madrid", "Melbrune" };
			Answers[1] = new string[] { "Real Madrid", "Manchester United", "Liverpool" };
			Answers[2] = new string[] { "1968", "1950", "1972" };
			Answers[3] = new string[] { "Robert Downey.JR", "Benedict Cumberbatch", "Brad Pitt" };
			Answers[4] = new string[] { "FootBall", "Basketball", "Volleyball" };
			Answers[5] = new string[] { "Sydney", "London", "Helsinki" };
			Answers[6] = new string[] { "Vatican City", "New Caledonia", "Luksemburg" };
			Answers[7] = new string[] { "Russia", "America", "China" };
			Answers[8] = new string[] { "Portuguese", "Spanish", "English" };
			Answers[9] = new string[] { "Seven", "Five", "Six" };

            #endregion



            #region Game

            for (int i = 0; i < Answers.Length; i++)
            {
                Randomize(Answers[i]);
            }

            int questionIndex = default;
            int answerIndex = default;
            string username = default;
            double score = default;


            Console.Write("Enter username: ");
            username = Console.ReadLine();
            
            Console.Clear();
            Console.WriteLine( $"\n\n\n\n\t\t\t\t~~~~~~~~~~~~~~~~    WELCOME  {username}    ~~~~~~~~~~~~~~~~");
            Thread.Sleep(1500);
            
            while (questionIndex<10)
            {
                while (true)
                {

                Console.Clear();
                showQuestion(Questions, Answers[questionIndex],ref questionIndex,ref answerIndex);
                
                ConsoleKey temp = Console.ReadKey().Key;    
                cursorControl(ref answerIndex, Answers[questionIndex].Length, temp);
                
                if (temp == ConsoleKey.Enter)
                {
                    if (checkAnswer(Questions, questionIndex, Answers[questionIndex][answerIndex]))
                        score += 10;
                    else 
                        score -= 10;
                    
                    if (score < 0)  
                        score = 0;
                    
                    Console.Clear();
                        ShowQuestionWithColor(Questions, questionIndex, Answers[questionIndex]);
                        Console.WriteLine("\n\nPress Enter to continue...");
                        Console.ReadKey(false);

                    break;
                }
                }
                questionIndex++;
            }

            Console.Clear();

            Console.WriteLine($"Your Score: {score}");

            Console.WriteLine("\n\nPress any key to finish....");
            Console.ReadKey(false);

            Console.Clear();

            Console.WriteLine($"\n\n\n\n\t\t\t\t~~~~~~~~~~~~~~~~    SEE YOU LATER  {username}  !  ~~~~~~~~~~~~~~~~");

            #endregion
        }




        #region Methods

        public static bool checkAnswer(string[][] Questions, int questionIndex, string choice) => Questions[questionIndex][1] == choice;


        public static void ShowQuestionWithColor(string[][] Questions, int questionIndex, string[] answers)
        {
            Console.WriteLine($"{questionIndex + 1}. {Questions[questionIndex][0]}");
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < answers.Length; i++)
            {
                if (checkAnswer(Questions, questionIndex, answers[i]))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(answers[i]);
                    Console.ResetColor();
                    continue;
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(answers[i]);
                Console.ResetColor();
            }
        }


        public static void cursorControl(ref int index, int answerSize, ConsoleKey temp)
        {
            if (temp == ConsoleKey.UpArrow)
                --index;
            else if (temp == ConsoleKey.DownArrow)
                ++index;

            if (index < 0) index = answerSize - 1;
            if (index >= answerSize) index = 0;
        }


        public static void Randomize(string[] items)
        {
            Random rand = new Random();

            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                string temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }


        public static void showQuestion(string[][] question, string[] answers, ref int questionIndex, ref int answerIndex)
        {
            Console.WriteLine($"{questionIndex + 1}. {question[questionIndex][0]}");
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < answers.Length; i++)
            {
                if (i == answerIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(answers[i]);
                    Console.ResetColor();

                    continue;
                }
                Console.WriteLine(answers[i]);

            }
        }

        #endregion


    }
}
