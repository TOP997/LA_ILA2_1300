using System;

namespace Random_number
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            bool fertig = true;

            int highscore = 0;

            int bestHighscore = 100;

            string[] highscoreListe = new string[1];

            int listenPosition = 0;

            while (fertig)
            {
                fertig = true;

                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("Dies ist ein spiel in dem eine zufällige Zahl zwischen 1 und 100 generiert wird. " +
                       "Ihr Ziel ist es diese Zahl zu erraten \n");


                Random num = new Random();
                int richtigeZahl = num.Next(1, 100);

                int Zahl = -1;

                int versuche = 0;

                do
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Rate eine Zahl. Anzahl bisheriger versuche " + versuche);

                        Zahl = Convert.ToInt32(Console.ReadLine());

                        if (Zahl == richtigeZahl)
                        {
                            Console.WriteLine("\n" + Zahl + " ist richtig \n");
                            versuche++;

                            highscore = versuche;
                        }
                        else if (Zahl >= richtigeZahl && Zahl <= 100)
                        {
                            Console.WriteLine("\n" + Zahl + " ist zu gross \n");
                            versuche++;
                        }
                        else if (Zahl <= richtigeZahl && Zahl >= 1)
                        {
                            Console.WriteLine("\n" + Zahl + " ist zu klein \n");
                            versuche++;
                        }
                        else if (Zahl < 1 || Zahl > 100)
                        {
                            Console.WriteLine("\nDie Zahl liegt zwischen 1 und 100 \n");
                        }
                    }
                    catch
                    {
                            Console.WriteLine("Bitte geben sie eine ganze Zahl ein. \n");
                    }
                }
                while (Zahl != richtigeZahl);

                if (highscore <= bestHighscore)
                {
                    bestHighscore = highscore;
                }

                highscoreListe[listenPosition] = Convert.ToString(highscore);


                listenPosition++;

                    Console.WriteLine("Du hast " + versuche + " versuche gebraucht und dein Highscore ist " + bestHighscore);

                try
                {
                    Console.WriteLine("nochmal? [y/n] Highscore Liste ausgeben und nochmal [h]");

                    string done = Console.ReadLine();

                    if (done == "n")
                    {
                        fertig = false;
                    }
                    else if (done == "y")
                    {
                        Console.WriteLine("ok nochmal \n");
                    }
                    else if(done == "h" )
                    {
                        int ausgabe = 0;

                        foreach (var item in highscoreListe)
                        {
                            Console.WriteLine("\n" +"ihre Highscores sind " + highscoreListe[ausgabe] + ";");
                            ausgabe++;
                        }

                    }
                    else
                    {
                        throw new Exception();
                    }

                    Array.Resize(ref highscoreListe, highscoreListe.Length + 1);

                }
                catch
                {
                    Console.WriteLine("bitte geben sie entweder y oder n ein \n");
                }
            }
        }
    }
}